Imports System.Globalization
Imports System.Windows.Forms
Imports System.IO
Imports System.Runtime.InteropServices

Imports CommonDB
Imports LibEntity
Imports PublicUtility

Public Class FrmPlanHour : Inherits DevExpress.XtraEditors.XtraForm

    Private DB As DBSql
    Private bs As BindingSource

    Private EnuActionForm As ActionForm = ActionForm.FormLoad

    Enum ActionForm
        None = 0
        FormLoad = 1
        Edit = 2
        Export = 3
        Run = 4
    End Enum

    ReadOnly Property GetFormEvents As ActionForm
        Get
            Return EnuActionForm
        End Get
    End Property

    WriteOnly Property SetFormEvents As ActionForm
        Set(ByVal value As ActionForm)
            EnuActionForm = value
            gridProcessHour.ReadOnly = True
            gridProcessHour.AllowUserToAddRows = False
            Me.Cursor = Cursors.WaitCursor
            Try
                Select Case value
                    Case ActionForm.Edit
                        gridProcessHour.ReadOnly = False
                        SetReadOnlyGrid()
                    Case ActionForm.FormLoad
                        LoadCombox()
                End Select
                Me.Cursor = Cursors.Arrow
            Catch ex As Exception
                Me.Cursor = Cursors.Arrow
                ShowError(ex, "SetFormEvents", Me.Name)
            End Try
        End Set
    End Property

#Region "User Function"

    Private Sub SetReadOnlyGrid()
        gridProcessHour.Columns("ProcessNumber").ReadOnly = True
        gridProcessHour.Columns("ProcessName").ReadOnly = True
        gridProcessHour.Columns("Leadtime").ReadOnly = True
        For Each c As DataGridViewColumn In gridProcessHour.Columns
            If c.HeaderText.Contains("NGÀY") Then
                c.ReadOnly = True
            End If
        Next
    End Sub

    Private Sub LoadCombox()
        Dim sql As String = "select NULL as Product union all select Product from PD_DoubleSideProduct"
        Dim tbl As DataTable = DB.FillDataTable(sql)
        cboProduct.ValueMember = "Product"
        cboProduct.DisplayMember = "Product"
        cboProduct.DataSource = tbl
    End Sub

#End Region

#Region "Form Function"

    Private Sub FrmPlanHour_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        DB = New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        SetFormEvents = ActionForm.FormLoad
    End Sub

    Private Sub FrmPlanHour_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 And mnuRun.Enabled Then
            mnuRun.PerformClick()
        End If
        If e.KeyCode = Keys.E And e.Control And mnuEdit.Enabled Then
            mnuEdit.PerformClick()
        End If
    End Sub


    'clean grid
    Private Sub CleanGrid()
        Try
            gridProcessHour.EndEdit()
            Me.bs.EndEdit()
            'Duyệt từng lô (cột) & từng dòng
            'Có sự khác nhau công thức giữa lô đầu tiên và các lô còn lại
            Dim tbl As DataTable = CType(CType(gridProcessHour.DataSource, BindingSource).DataSource, DataTable)
            For Each col As DataColumn In tbl.Columns
                If col.ColumnName = "Leadtime" _
                    Or col.ColumnName = "ProcessNumber" _
                    Or col.ColumnName = "ProcessName" _
                    Or col.ColumnName.Contains("Date") Then Continue For
                Dim bFirstValue As Boolean = True
                For Each r As DataRow In tbl.Rows
                    If bFirstValue Then If r(col.ColumnName) Is DBNull.Value Then Continue For
                    If bFirstValue Then
                        bFirstValue = False
                        Continue For
                    End If
                    r(col.ColumnName) = DBNull.Value
                Next
            Next
            tbl.AcceptChanges()
        Catch ex As Exception
            ShowError(ex, mnuRun.Text, Me.Text)
        Finally
            SetFormEvents = ActionForm.Run
        End Try
    End Sub

    'Không làm ngày nghỉ
    Private Sub KNN()
        Dim sqlrestdate As String = String.Format(
                                    " SELECT " +
                                    " DATEADD(second, 0, " +
                                                " DATEADD(minute, 30, " +
                                                " DATEADD(hour, 6, " +
                                                " DATEADD(day, day([HolidayDate])-1, " +
                                                " DATEADD(month, month([HolidayDate])-1, " +
                                                " DATEADD(Year, year([HolidayDate])-1900, 0)))))) AS FromDate, " +
                                    " DATEADD(second, 0, " +
                                                " DATEADD(minute, 30, " +
                                                " DATEADD(hour, 6, " +
                                                " DATEADD(day, day([HolidayDate]), " +
                                                " DATEADD(month, month([HolidayDate])-1, " +
                                                " DATEADD(Year, year([HolidayDate])-1900, 0)))))) AS ToDate " +
                                    " FROM {0} where [HolidayDate]>=getdate()",
                                    PublicTable.Table_FPICS_HolidayDate)
        Dim lstRestDate As List(Of DataRow) = DB.FillDataTable(sqlrestdate).AsEnumerable().ToList()
        Try
            gridProcessHour.EndEdit()
            Me.bs.EndEdit()
            'Duyệt từng lô (cột) & từng dòng
            'So sánh giữa TGGC & TGKT
            'Có sự khác nhau công thức giữa lô đầu tiên và các lô còn lại
            Dim tbl As DataTable = CType(CType(gridProcessHour.DataSource, BindingSource).DataSource, DataTable)
            Dim bFirstLot As Boolean = True
            Dim colBefore As DataColumn = Nothing
            For Each col As DataColumn In tbl.Columns
                If col.ColumnName = "Leadtime" _
                    Or col.ColumnName = "ProcessNumber" _
                    Or col.ColumnName = "ProcessName" _
                    Or col.ColumnName.Contains("Date") Then Continue For
                Dim bFirstValue As Boolean = True
                Dim tgkt As Nullable(Of DateTime) = Nothing
                Dim time_remain As Int32 = 0 'remain của cột hiện tại
                Dim time_remain_bf As Int32 = 0 'remain của cột trước đó
                For Each r As DataRow In tbl.Rows
                    'Tìm giá trị đầu tiên của cột
                    'Kiểm tra thời gian kết thúc & cộng tiếp leadtime
                    If bFirstValue Then If r(col.ColumnName) Is DBNull.Value Then Continue For
                    If bFirstValue Then
                        tgkt = New DateTime(dtpPlanDate.Value.Year, _
                                            dtpPlanDate.Value.Month, _
                                            dtpPlanDate.Value.Day, _
                                            CType(r(col.ColumnName), DateTime).Hour, _
                                            CType(r(col.ColumnName), DateTime).Minute, _
                                            0)
                        If tgkt > DateTime.MinValue Then
                            If CType(tgkt, DateTime).Hour < 6 Then
                                tgkt = CType(tgkt, DateTime).AddDays(1)
                            End If
                        End If
                        r(col.ColumnName.Replace("Leadtime", "Date")) = tgkt
                        r(col.ColumnName) = tgkt
                        bFirstValue = False
                        Continue For
                    End If
                    If bFirstLot Then 'xử lý trường hợp lô đầu tiên
                        Dim tgkt_2check As DateTime = tgkt.Value.AddHours(r(Leadtime.DataPropertyName))
                        'kiểm tra có phải ngày nghỉ không
                        'nếu là ngày nghỉ thì bỏ qua
                        Dim bfirst_sub As Boolean = True
                        While True
                            Dim sRestTime = (From p In lstRestDate Where p("FromDate") <= tgkt_2check And p("ToDate") >= tgkt_2check
                                                Select p).FirstOrDefault()
                            If sRestTime Is Nothing Then 'nếu không phải ngày nghỉ
                                If time_remain > 0 Then
                                    tgkt = tgkt.Value.AddMinutes(time_remain)
                                    time_remain = 0
                                Else
                                    tgkt = tgkt.Value.AddMinutes(60 * r(Leadtime.DataPropertyName))
                                End If
                                r(col.ColumnName) = tgkt
                                r(col.ColumnName.Replace("Leadtime", "Date")) = tgkt
                                Exit While
                            Else 'nếu là ngày nghỉ
                                'tính lại thời gian gia công cho tới lúc bắt đầu nghỉ
                                'chỉ tính khi gặp ngày nghỉ đầu tiên (ngày liền kề tiếp theo không tính)
                                If bfirst_sub Then
                                    Dim cur_time_minute As Int32 = CType(r(Leadtime.DataPropertyName), Decimal) * 60 'tính giờ ra phút
                                    Dim timespn As TimeSpan = CType(sRestTime("FromDate"), DateTime) - tgkt
                                    time_remain = cur_time_minute - timespn.Minutes
                                    bfirst_sub = False
                                End If
                                tgkt_2check = CType(sRestTime("ToDate"), DateTime).AddMinutes(1)
                                tgkt = CType(sRestTime("ToDate"), DateTime)
                            End If
                        End While
                    Else 'xử lý trường hợp lô tiếp theo
                        'tính tgkt
                        Dim tgkt_2check As DateTime = tgkt.Value.AddHours(r(Leadtime.DataPropertyName))
                        'kiểm tra có phải ngày nghỉ không
                        'nếu là ngày nghỉ thì bỏ qua
                        Dim bfirst_sub As Boolean = True
                        While True
                            Dim sRestTime = (From p In lstRestDate Where p("FromDate") <= tgkt_2check And p("ToDate") >= tgkt_2check
                                                Select p).FirstOrDefault()
                            If sRestTime Is Nothing Then 'nếu không phải ngày nghỉ
                                If time_remain > 0 Then
                                    tgkt = tgkt.Value.AddMinutes(time_remain)
                                    time_remain = 0
                                Else
                                    tgkt = tgkt.Value.AddHours(r(Leadtime.DataPropertyName))
                                End If
                                Exit While
                            Else 'nếu là ngày nghỉ
                                'tính lại thời gian gia công cho tới lúc bắt đầu nghỉ
                                'chỉ tính khi gặp ngày nghỉ đầu tiên (ngày liền kề tiếp theo không tính)
                                If bfirst_sub Then
                                    Dim cur_time_minute As Int32 = CType(r(Leadtime.DataPropertyName), Decimal) * 60 'tính giờ ra phút
                                    Dim timespn As TimeSpan = CType(sRestTime("FromDate"), DateTime) - tgkt
                                    time_remain = cur_time_minute - timespn.Minutes
                                    bfirst_sub = False
                                End If
                                tgkt_2check = CType(sRestTime("ToDate"), DateTime).AddMinutes(1)
                                tgkt = CType(sRestTime("ToDate"), DateTime)
                            End If
                        End While
                        '-----------------
                        bfirst_sub = True
                        Dim sProcess As String = CType(r(ProcessName.DataPropertyName), String)
                        If _
                            sProcess = "Lam Press (Vacuum)" _
                            Or sProcess = "Steel Rule Die_B/S" _
                            Or sProcess = "Curing" _
                            Or sProcess = "Autoclave No Make" Then
                            r(col.ColumnName) = tgkt
                        Else
                            'tính tgkt_before
                            Dim tgkt_before As Nullable(Of DateTime) = Nothing
                            If r(colBefore.ColumnName) IsNot DBNull.Value Then
                                tgkt_before = CType(r(colBefore.ColumnName), DateTime)
                                Dim tgkt_2check_bf As DateTime = CType(r(colBefore.ColumnName), DateTime).AddHours(r(Leadtime.DataPropertyName))
                                'kiểm tra có phải ngày nghỉ không
                                'nếu là ngày nghỉ thì bỏ qua
                                Dim bfirst_sub_bf As Boolean = True
                                While True
                                    Dim sRestTime = (From p In lstRestDate Where p("FromDate") <= tgkt_2check_bf And p("ToDate") >= tgkt_2check_bf
                                                        Select p).FirstOrDefault()
                                    If sRestTime Is Nothing Then 'nếu không phải ngày nghỉ
                                        If time_remain_bf > 0 Then
                                            tgkt_before = tgkt_before.Value.AddMinutes(time_remain_bf)
                                            time_remain_bf = 0
                                        Else
                                            tgkt_before = tgkt_before.Value.AddHours(r(Leadtime.DataPropertyName))
                                        End If
                                        Exit While
                                    Else 'nếu là ngày nghỉ
                                        'tính lại thời gian gia công cho tới lúc bắt đầu nghỉ
                                        'chỉ tính khi gặp ngày nghỉ đầu tiên (ngày liền kề tiếp theo không tính)
                                        If bfirst_sub Then
                                            Dim cur_time_minute As Int32 = CType(r(Leadtime.DataPropertyName), Decimal) * 60 'tính giờ ra phút
                                            Dim timespn As TimeSpan = CType(sRestTime("FromDate"), DateTime) - tgkt_before
                                            time_remain_bf = cur_time_minute - timespn.Minutes
                                            bfirst_sub = False
                                        End If
                                        tgkt_2check_bf = CType(sRestTime("ToDate"), DateTime).AddMinutes(1)
                                        tgkt_before = CType(sRestTime("ToDate"), DateTime)
                                    End If
                                End While
                            End If
                            '--------------
                            If tgkt_before Is Nothing Then
                                r(col.ColumnName) = tgkt
                            Else
                                r(col.ColumnName) = If(tgkt > tgkt_before, tgkt, tgkt_before)
                            End If
                        End If
                        tgkt = r(col.ColumnName)
                        r(col.ColumnName.Replace("Leadtime", "Date")) = tgkt
                    End If
                Next
                If bFirstLot Then
                    bFirstLot = False
                End If
                colBefore = col
            Next
        Catch ex As Exception
            ShowError(ex, mnuRun.Text, Me.Text)
        Finally
            SetFormEvents = ActionForm.Run
        End Try
    End Sub

    'Có làm ngày nghỉ
    Private Sub CNN()
        Try
            gridProcessHour.EndEdit()
            Me.bs.EndEdit()
            'Duyệt từng lô (cột) & từng dòng
            'Có sự khác nhau công thức giữa lô đầu tiên và các lô còn lại
            Dim tbl As DataTable = CType(CType(gridProcessHour.DataSource, BindingSource).DataSource, DataTable)
            Dim bFirstLot As Boolean = True
            Dim colBefore As DataColumn = Nothing
            For Each col As DataColumn In tbl.Columns
                If col.ColumnName = "Leadtime" _
                    Or col.ColumnName = "ProcessNumber" _
                    Or col.ColumnName = "ProcessName" _
                    Or col.ColumnName.Contains("Date") Then Continue For
                Dim bFirstValue As Boolean = True
                Dim tgkt As Nullable(Of DateTime) = Nothing
                For Each r As DataRow In tbl.Rows
                    'Tìm giá trị đầu tiên của cột
                    'Kiểm tra thời gian kết thúc & cộng tiếp leadtime
                    If bFirstValue Then If r(col.ColumnName) Is DBNull.Value Then Continue For
                    If bFirstValue Then
                        tgkt = New DateTime(dtpPlanDate.Value.Year, _
                                            dtpPlanDate.Value.Month, _
                                            dtpPlanDate.Value.Day, _
                                            CType(r(col.ColumnName), DateTime).Hour, _
                                            CType(r(col.ColumnName), DateTime).Minute, _
                                            0)
                        If tgkt > DateTime.MinValue Then
                            If CType(tgkt, DateTime).Hour < 6 Then
                                tgkt = CType(tgkt, DateTime).AddDays(1)
                            End If
                        End If
                        r(col.ColumnName.Replace("Leadtime", "Date")) = tgkt
                        r(col.ColumnName) = tgkt
                        bFirstValue = False
                        Continue For
                    End If
                    If bFirstLot Then 'xử lý trường hợp lô đầu tiên
                        tgkt = tgkt.Value.AddMinutes(60 * CType(r(Leadtime.DataPropertyName), Decimal))
                        r(col.ColumnName) = tgkt
                        r(col.ColumnName.Replace("Leadtime", "Date")) = tgkt
                    Else 'xử lý trường hợp lô tiếp theo
                        tgkt = tgkt.Value.AddHours(CType(r(Leadtime.DataPropertyName), Decimal))
                        Dim sProcess As String = CType(r(ProcessName.DataPropertyName), String)
                        If _
                            sProcess = "Lam Press (Vacuum)" _
                            Or sProcess = "Steel Rule Die_B/S" _
                            Or sProcess = "Curing" _
                            Or sProcess = "Autoclave No Make" Then
                            r(col.ColumnName) = tgkt
                        Else
                            'tính tgkt_before
                            Dim tgkt_before As Nullable(Of DateTime) = Nothing
                            If r(colBefore.ColumnName) IsNot DBNull.Value Then
                                tgkt_before = CType(r(colBefore.ColumnName), DateTime)
                                tgkt_before = tgkt_before.Value.AddHours(CType(r(Leadtime.DataPropertyName), Decimal))
                            End If
                            '--------------
                            If tgkt_before Is Nothing Then
                                r(col.ColumnName) = tgkt
                            Else
                                r(col.ColumnName) = If(tgkt > tgkt_before, tgkt, tgkt_before)
                            End If
                        End If
                        tgkt = CType(r(col.ColumnName), DateTime)
                        r(col.ColumnName.Replace("Leadtime", "Date")) = tgkt
                    End If
                Next
                If bFirstLot Then
                    bFirstLot = False
                End If
                colBefore = col
            Next
        Catch ex As Exception
            ShowError(ex, mnuRun.Text, Me.Text)
        Finally
            SetFormEvents = ActionForm.Run
        End Try
    End Sub

    Private Sub mnuRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRun.Click
        If gridProcessHour.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu trên lưới", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Me.CleanGrid()
        'không làm ngày nghỉ
        If rdKNN.Checked Then
            Me.KNN()
        ElseIf rdCNN.Checked Then 'có làm ngày nghỉ
            Me.CNN()
        End If
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        mnuRun.PerformClick()
        SetFormEvents = ActionForm.Edit
    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        If gridProcessHour.Rows.Count > 0 Then
            ExportEXCEL(gridProcessHour, True)
        End If
    End Sub

#End Region

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If txtProductCode.Text = String.Empty Then
            MessageBox.Show("Chưa nhập ProductCode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductCode.Focus()
            Exit Sub
        End If
        If cboProduct.Text = String.Empty Then
            MessageBox.Show("Chưa chọn leadtime cho Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboProduct.Focus()
            Exit Sub
        End If
        If txtLotNoList.Text = String.Empty Then
            MessageBox.Show("Chưa nhập Lotno", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLotNoList.Focus()
            Exit Sub
        End If

        Dim lstColRemove As New List(Of DataGridViewColumn)
        For Each colgrid As DataGridViewColumn In gridProcessHour.Columns
            If colgrid.Name <> ProcessNumber.Name _
                And colgrid.Name <> ProcessName.Name _
                And colgrid.Name <> Leadtime.Name Then lstColRemove.Add(colgrid)
        Next
        For Each crm In lstColRemove
            gridProcessHour.Columns.Remove(crm)
        Next

        Me.Cursor = Cursors.WaitCursor
        Try
            'Tách lô sản phẩm
            Dim lstLotNo As New List(Of String)
            Dim arrLot() As String = Trim(txtLotNoList.Text.Replace(" ", "")).Split(",")
            For Each sLot As String In arrLot
                Dim arrLotRange() As String = Trim(sLot.Replace(" ", "")).Split("-")
                If arrLotRange.Length > 1 Then
                    Dim iLot1 As Int32 = CType(arrLotRange(0), Int32)
                    Dim iLot2 As Int32 = CType(arrLotRange(1), Int32)
                    While iLot1 <= iLot2
                        lstLotNo.Add(iLot1.ToString())
                        iLot1 += 1
                    End While
                Else
                    lstLotNo.Add(sLot)
                End If
            Next
            'Khởi tạo bảng dữ liệu cho lưới
            Dim tbl As New DataTable
            'Lead leadtime product
            Dim sql As String = String.Format(" SELECT ProcessNumber, ProcessName, Leadtime" +
                                              " FROM [dbo].[PD_ProcessHour] WHERE Product = '{0}'",
                                              cboProduct.Text)
            tbl = DB.FillDataTable(sql)
            For Each sLot In lstLotNo
                Dim colLeadtime As New DataColumn(sLot + "_" + "Leadtime", Type.GetType("System.DateTime"))
                If Not tbl.Columns.Contains(colLeadtime.ColumnName) Then
                    tbl.Columns.Add(colLeadtime)
                    Dim cgLT As New DataGridViewTextBoxColumn
                    cgLT.HeaderText = "Lô" + sLot + "_TGKT"
                    cgLT.DataPropertyName = colLeadtime.ColumnName
                    cgLT.Name = colLeadtime.ColumnName
                    cgLT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    cgLT.DefaultCellStyle.Format = "HH:mm"
                    cgLT.SortMode = DataGridViewColumnSortMode.NotSortable
                    cgLT.Width = 65
                    If Not gridProcessHour.Columns.Contains(cgLT.Name) Then gridProcessHour.Columns.Add(cgLT)
                End If

                Dim colDate As New DataColumn(sLot + "_" + "Date", Type.GetType("System.DateTime"))
                If Not tbl.Columns.Contains(colDate.ColumnName) Then
                    tbl.Columns.Add(colDate)
                    Dim cgDate As New DataGridViewTextBoxColumn
                    cgDate.HeaderText = "Lô" + sLot + "_NGÀY"
                    cgDate.DataPropertyName = colDate.ColumnName
                    cgDate.Name = colDate.ColumnName
                    cgDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    cgDate.DefaultCellStyle.Format = "dd-MMM"
                    cgDate.SortMode = DataGridViewColumnSortMode.NotSortable
                    cgDate.Width = 65
                    If Not gridProcessHour.Columns.Contains(cgDate.Name) Then gridProcessHour.Columns.Add(cgDate)
                End If
            Next
            gridProcessHour.AutoGenerateColumns = False
            Me.bs = New BindingSource
            bs.DataSource = tbl
            gridProcessHour.DataSource = bs
            gridProcessHour.AutoResizeColumns()
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            ShowError(ex, btnAdd.Text, Me.Name)
        End Try
    End Sub

End Class