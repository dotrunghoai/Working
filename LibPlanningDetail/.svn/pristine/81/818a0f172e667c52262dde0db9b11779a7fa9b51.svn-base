Imports System.Globalization
Imports System.Windows.Forms
Imports System.IO
Imports System.Runtime.InteropServices

Imports CommonDB
Imports LibEntity
Imports PublicUtility

Public Class FrmFirstLotHS : Inherits DevExpress.XtraEditors.XtraForm

    Private DB As DBSql
    Private dbFpics As DBSql
    Private bs As BindingSource

    Private EnuActionForm As ActionForm = ActionForm.FormLoad

    Enum ActionForm
        None = 0
        FormLoad = 1
        Edit = 2
        Export = 3
        GetPrintDate = 4
        Refresh = 5
        Delete = 6
    End Enum

    ReadOnly Property GetFormEvents As ActionForm
        Get
            Return EnuActionForm
        End Get
    End Property

    WriteOnly Property SetFormEvents As ActionForm
        Set(ByVal value As ActionForm)
            EnuActionForm = value
            gridFirstLot.ReadOnly = True
            gridFirstLot.AllowUserToAddRows = False
            Me.Cursor = Cursors.WaitCursor
            Try
                Select Case value
                    Case ActionForm.GetPrintDate
                        GetPrintDate()
                    Case ActionForm.Edit
                        gridFirstLot.ReadOnly = False
                        gridFirstLot.AllowUserToAddRows = True
                    Case ActionForm.FormLoad, ActionForm.Refresh
                        LoadAll()
                End Select
                Me.Cursor = Cursors.Arrow
            Catch ex As Exception
                Me.Cursor = Cursors.Arrow
                ShowError(ex, "SetFormEvents", Me.Name)
            End Try
        End Set
    End Property

#Region "User Function"

    Private Sub CalTotalLot()
        If gridFirstLot.Rows.Count = 0 Then Exit Sub
        Dim iTotalLot As Int32 = 0
        For Each r As DataGridViewRow In gridFirstLot.Rows
            iTotalLot += If(r.Cells("TotalLot").Value Is DBNull.Value, 0D, r.Cells("TotalLot").Value)
        Next
        txtTotalLot.Text = iTotalLot.ToString()
    End Sub

    Private Sub GetPrintDate()
        If gridFirstLot.DataSource Is Nothing Then Exit Sub
        Dim tbl As DataTable = CType(CType(gridFirstLot.DataSource, BindingSource).DataSource, DataTable)
        If tbl.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu trên lưới", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim sql As String = " SELECT COUNT(ProductCode) " +
                            " FROM [FPiCS-B03].[dbo].[t_PDSheetPrintHistory] " +
                            " WHERE ProductCode = '{0}' AND LotNumber = '{1}' AND ComponentCode = 'B00' "
        gridFirstLot.EndEdit()
        Me.bs.EndEdit()
        For Each r As DataRow In tbl.Rows
            Dim iTotalLot As Int32 = If(r("TotalLot") Is DBNull.Value, 0, r("TotalLot"))
            If iTotalLot <= 0 Then
                r("PrintDateStatus") = "N/A"
                Continue For
            End If
            Dim istart As Int32 = r("StartLot")
            Dim iend As Int32 = r("EndLot")
            Dim sPdCode As String = r("ProductCode").ToString().PadLeft(5, "0").Substring(0, 5)
            Dim str As String = String.Empty
            For i = istart To iend
                Dim slot As String = i.ToString().PadLeft(5, "0")
                Dim icount As Int32 = dbFpics.ExecuteScalar(String.Format(sql, sPdCode, slot))
                If icount = 0 Then
                    str += slot + ", "
                End If
            Next
            If str.Length > 0 Then
                str = Trim(str)
                r("PrintDateStatus") = String.Format("NG ({0})", str.Substring(0, str.Length - 1))
            Else
                r("PrintDateStatus") = "OK"
            End If
        Next
    End Sub

    Private Sub LoadAll()
        'transaction
        'đồng bộ dữ liệu với chương trình chỉnh lưu
        DB.BeginTransaction()
        Try
            Dim para(2) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Action", "insert")
            para(1) = New SqlClient.SqlParameter("@RPDate", dtpDate.Value.AddDays(-1).ToString("yyyyMMdd"))
            para(2) = New SqlClient.SqlParameter("@HSDate", dtpDate.Value.ToString("yyyyMMdd"))
            DB.ExecuteStoreProcedure("sp_PD_FirstLotHS", para)
            DB.Commit()
        Catch ex As Exception
            DB.RollBack()
            Throw ex
            Exit Sub
        End Try
        'load data
        Dim sql As String = String.Format(
                            " declare @tabl as table(ProductCode varchar(5), CustomerCode varchar(4), CustomerNameE varchar(100)) " +
                            " insert into @tabl exec sp_Sys_ProductCustomer " +
                            " select Customer = B.CustomerNameE, A.ProductCode, StartLot = A.LotNo, A.EndLot, TotalLot = cast(0 as int), PrintDateStatus = '', A.IsCL, M.Machine " +
                            " from [dbo].[PD_FirstLotHS] A " +
                            " left join PD_HSMachine M on left(A.ProductCode, 5) = M.ProductCode " +
                            " left join @tabl B " +
                            " on left(A.ProductCode, 5) = B.ProductCode " +
                            " where IssueDate = '{0}' Order By IsCL Desc, Customer, ProductCode ", dtpDate.Value.ToString("yyyyMMdd"))
        Dim tmp As DataTable = DB.FillDataTable(sql)
        Dim tbl As DataTable = Me.InitTable(tmp)
        gridFirstLot.AutoGenerateColumns = False
        bs = New BindingSource
        bs.DataSource = tbl
        gridFirstLot.DataSource = bs
        bnFirstLot.BindingSource = bs
    End Sub

    Private Function GetMaxLotNo(ByVal r As DataRow) As Int32
        Dim lstLotNo As New List(Of Int32)
        Dim arrLot() As String = Trim(r("StartLot").ToString().Replace(" ", "")).Split(",")
        For Each sLot As String In arrLot
            Dim arrLotRange() As String = Trim(sLot.Replace(" ", "")).Split("-")
            If arrLotRange.Length > 1 Then
                Dim iLot1 As Int32 = CType(arrLotRange(0), Int32)
                Dim iLot2 As Int32 = CType(arrLotRange(1), Int32)
                While iLot1 <= iLot2
                    lstLotNo.Add(iLot1)
                    iLot1 += 1
                End While
            Else
                lstLotNo.Add(CType(sLot, Int32))
            End If
        Next
        Return lstLotNo.Max()
    End Function

    Private Function InitTable(ByRef tblOrg As DataTable) As DataTable
        Dim desTbl As New DataTable
        'columns
        Dim colCustomer As New DataColumn("Customer", Type.GetType("System.String"))
        Dim colProductCode As New DataColumn("ProductCode", Type.GetType("System.String"))
        Dim colStartLot As New DataColumn("StartLot", Type.GetType("System.Int32"))
        Dim colEndLot As New DataColumn("EndLot", Type.GetType("System.Int32"))
        Dim colTotalLot As New DataColumn("TotalLot", Type.GetType("System.Int32"))
        Dim colPrintDateStatus As New DataColumn("PrintDateStatus", Type.GetType("System.String"))
        Dim colIsCL As New DataColumn("IsCL", Type.GetType("System.Boolean"))
        Dim colMachine As New DataColumn("Machine", Type.GetType("System.String"))
        desTbl.Columns.AddRange({colCustomer, colProductCode, colStartLot, colEndLot, colTotalLot, colPrintDateStatus, colIsCL, colMachine})
        '-----
        For Each r As DataRow In tblOrg.Rows
            If Not r("IsCL") Then
                Dim rn As DataRow = desTbl.NewRow()
                rn("Customer") = r("Customer")
                rn("ProductCode") = r("ProductCode")
                rn("StartLot") = r("StartLot")
                rn("EndLot") = r("EndLot")
                rn("IsCL") = r("IsCL")
                rn("Machine") = r("Machine")
                desTbl.Rows.Add(rn)
                Continue For
            End If
            'kiểm tra mã sp của dòng đã có trong bảng desTbl chưa
            'nếu chưa add row/ngược lại add lotno
            Dim rs() As DataRow = desTbl.Select(String.Format("ProductCode = '{0}'", r("ProductCode")))
            If rs.Length > 0 Then
                Dim iMaxLot As Int32 = Me.GetMaxLotNo(r)
                If iMaxLot > (rs(0)("StartLot") - 1) Then
                    rs(0)("StartLot") = iMaxLot + 1
                End If
            Else
                Dim rn As DataRow = desTbl.NewRow()
                rn("Customer") = r("Customer")
                rn("ProductCode") = r("ProductCode")
                rn("StartLot") = Me.GetMaxLotNo(r) + 1
                rn("EndLot") = r("EndLot")
                rn("IsCL") = r("IsCL")
                rn("Machine") = r("Machine")
                desTbl.Rows.Add(rn)
            End If
        Next
        desTbl.Columns("TotalLot").Expression = "EndLot - StartLot + 1"
        Return desTbl
    End Function

#End Region

#Region "Form Function"

    Private Sub FrmFirstLotHS_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        DB = New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        dbFpics = New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
        SetFormEvents = ActionForm.FormLoad
    End Sub

    Private Sub FrmFirstLotHS_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 And mnuGetPrintDate.Enabled Then
            mnuGetPrintDate.PerformClick()
        End If
        If e.KeyCode = Keys.E And e.Control And mnuEdit.Enabled Then
            mnuEdit.PerformClick()
        End If
    End Sub


    Private Sub mnuGetPrintDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGetPrintDate.Click
        SetFormEvents = ActionForm.GetPrintDate
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        SetFormEvents = ActionForm.Edit
    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        If gridFirstLot.Rows.Count > 0 Then
            ExportEXCEL(gridFirstLot, True)
        End If
    End Sub

#End Region

    Private Sub dtpDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpDate.ValueChanged
        LoadAll()
    End Sub

    Private Sub gridFirstLot_DataBindingComplete(sender As System.Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles gridFirstLot.DataBindingComplete
        CalTotalLot()
    End Sub

    Private Sub gridFirstLot_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridFirstLot.CellValueChanged
        Try
            If GetFormEvents <> ActionForm.Edit Then Exit Sub
            If gridFirstLot.CurrentRow Is Nothing Then Exit Sub

            If e.ColumnIndex = IsCL.Index Then Exit Sub
            If e.ColumnIndex = StartLot.Index Then Exit Sub

            gridFirstLot.EndEdit()
            bs.EndEdit()

            Dim r As DataGridViewRow = gridFirstLot.CurrentRow

            If r.Cells("ProductCode").Value Is DBNull.Value Then Exit Sub

            Dim bIsCL As Boolean = If(r.Cells("IsCL").Value Is DBNull.Value, False, r.Cells("IsCL").Value)

            If bIsCL Then
                Dim sql As String = String.Format(
                                    " update A set EndLot = {2} " +
                                    " from [dbo].[PD_FirstLotHS] A " +
                                    " where IssueDate = '{0}' and ProductCode = '{1}' ",
                                    dtpDate.Value.ToString("yyyyMMdd"),
                                    r.Cells("ProductCode").Value,
                                    r.Cells("EndLot").Value)
                DB.ExecuteNonQuery(sql)
            Else
                'Tìm và tính startlot của mã hàng này
                Dim sPdCode As String = r.Cells("ProductCode").Value.ToString().PadLeft(5, "0")
                Dim para(2) As SqlClient.SqlParameter
                para(0) = New SqlClient.SqlParameter("@Action", "search_before")
                para(1) = New SqlClient.SqlParameter("@RPDate", dtpDate.Value.AddDays(-1).ToString("yyyyMMdd"))
                para(2) = New SqlClient.SqlParameter("@ProductCode", sPdCode)
                Dim tbl As DataTable = DB.ExecuteStoreProcedureTB("sp_PD_FirstLotHS", para)
                Dim lst As New List(Of Int32)
                For Each rbf As DataRow In tbl.Rows
                    lst.Add(Me.GetMaxLotNo(rbf))
                Next
                If lst.Count <= 0 Then Exit Sub
                Dim iStartLot As Int32 = 0
                If lst.Count > 0 Then iStartLot = lst.Max() + 1
                '-----
                Dim obj As New PD_FirstLotHS
                'khóa
                obj.IssueDate_K = dtpDate.Value.Date
                obj.LineNumber_K = 0
                obj.OrderNo_K = 0
                obj.ProductCode_K = r.Cells("ProductCode").Value.ToString().PadLeft(5, "0")
                obj.LotNo_K = iStartLot.ToString()
                '----
                DB.GetObject(obj)
                If obj.ProductCode_K Is Nothing Then
                    'khóa
                    obj.IssueDate_K = dtpDate.Value.Date
                    obj.LineNumber_K = 0
                    obj.OrderNo_K = 0
                    obj.ProductCode_K = r.Cells("ProductCode").Value.ToString().PadLeft(5, "0")
                    obj.LotNo_K = iStartLot.ToString()
                    '----
                    obj.EndLot = If(r.Cells("EndLot").Value Is DBNull.Value, 0, r.Cells("EndLot").Value)
                    obj.IsCL = False
                    DB.Insert(obj)
                Else
                    obj.EndLot = If(r.Cells("EndLot").Value Is DBNull.Value, 0, r.Cells("EndLot").Value)
                    DB.Update(obj)
                End If
                r.Cells("IsCL").Value = False
                r.Cells("StartLot").Value = iStartLot.ToString()
            End If

            CalTotalLot()
        Catch ex As Exception
            ShowError(ex, "gridFirstLot_CellValueChanged", Me.Name)
        End Try
    End Sub

    Private Sub gridFirstLot_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridFirstLot.CellEnter
        Try
            If GetFormEvents <> ActionForm.Edit Then Exit Sub
            Dim r As DataGridViewRow = gridFirstLot.CurrentRow
            If r Is Nothing Then Exit Sub
            Dim bIsCL As Boolean = If(r.Cells("IsCL").Value Is DBNull.Value, False, r.Cells("IsCL").Value)
            If _
                bIsCL And _
                (e.ColumnIndex = ProductCode.Index) Then
                r.Cells(e.ColumnIndex).ReadOnly = True
                Exit Sub
            End If
            '----------------------------------------------------------

            'Các cột mặc định không focus
            If _
                e.ColumnIndex = Customer.Index _
                Or e.ColumnIndex = StartLot.Index _
                Or e.ColumnIndex = TotalLot.Index _
                Or e.ColumnIndex = PrintDateStatus.Index _
                Or e.ColumnIndex = Machine.Index Then
                r.Cells(e.ColumnIndex).ReadOnly = True
            End If
            '----------------------------------------------------------
        Catch ex As Exception
            ShowError(ex, "gridFirstLot_CellEnter", Me.Name)
        End Try
    End Sub

    Private Sub mnuRefresh_Click(sender As System.Object, e As System.EventArgs) Handles mnuRefresh.Click
        SetFormEvents = ActionForm.Refresh
    End Sub

    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click
        Try
            If gridFirstLot.Rows.Count = 0 Then Exit Sub
            If gridFirstLot.CurrentRow Is Nothing Then Exit Sub
            Dim r = gridFirstLot.CurrentRow
            Dim bIsCL As Boolean = If(r.Cells("IsCL").Value Is DBNull.Value, False, r.Cells("IsCL").Value)
            If bIsCL Then
                MessageBox.Show("Bạn không thể xóa dữ liệu vẽ chỉnh lưu", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If ShowQuestionDelete() = Windows.Forms.DialogResult.No Then Exit Sub
            Dim obj As New PD_FirstLotHS
            obj.IssueDate_K = dtpDate.Value.Date
            obj.ProductCode_K = If(r.Cells("ProductCode").Value Is DBNull.Value, String.Empty, r.Cells("ProductCode").Value)
            obj.LotNo_K = If(r.Cells("StartLot").Value Is DBNull.Value, String.Empty, r.Cells("StartLot").Value)
            DB.Delete(obj)
            gridFirstLot.Rows.Remove(r)
        Catch ex As Exception
            ShowError(ex, mnuDelete.Text, Me.Name)
        End Try
    End Sub

    Private Sub gridFirstLot_RowPrePaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles gridFirstLot.RowPrePaint
        If GetFormEvents = ActionForm.Edit Then Exit Sub
        Try
            Dim r As DataGridViewRow = gridFirstLot.Rows(e.RowIndex)
            If r.IsNewRow Then Exit Sub

            Dim value As Boolean = If(r.Cells("IsCL").Value Is DBNull.Value, False, r.Cells("IsCL").Value)

            If Not value Then
                r.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E7F4CF")
                r.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#E7F4CF")
                r.DefaultCellStyle.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#0000FF")
            End If
        Catch ex As Exception
            ShowError(ex, "gridFirstLot_RowPrePaint", Me.Name)
        End Try
    End Sub

End Class