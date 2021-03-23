Imports System.Globalization
Imports System.Windows.Forms
Imports System.IO
Imports System.Runtime.InteropServices

Imports CommonDB
Imports LibEntity
Imports PublicUtility
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Threading

Public Class FrmLotStatus : Inherits DevExpress.XtraEditors.XtraForm

    Private DB As DBSql
    Private dbFpics As DBSql

    Private EnuActionForm As ActionForm = ActionForm.FormLoad

    Enum ActionForm
        None = 0
        FormLoad = 1
        AddNew = 2
        Back = 3
        Export = 4
        ShowAll = 5
        Import = 6
        Delete = 9
        ViewLot = 7
        ViewDebit = 8
        ViewExcess = 10
    End Enum

    Private AddNewRight As Boolean = False
    Private BackRight As Boolean = False
    Private ExportRight As Boolean = False
    Private ShowAllRight As Boolean = False
    Private ImportRight As Boolean = False
    Private DeleteRight As Boolean = False
    Private ViewLotRight As Boolean = False
    Private ViewDebitRight As Boolean = False
    Private ViewExcessRight As Boolean = False

    ReadOnly Property GetFormEvents As ActionForm
        Get
            Return EnuActionForm
        End Get
    End Property

    WriteOnly Property SetFormEvents As ActionForm
        Set(ByVal value As ActionForm)

            EnuActionForm = value

            gridOutput.ReadOnly = True
            gridOutput.AllowUserToAddRows = False

            dtpFromDate.Enabled = False
            dtpToDate.Enabled = False

            cboPeriod.Enabled = True

            Try
                Select Case value
                    Case ActionForm.AddNew
                        cboPeriod.Enabled = False
                        PerformStatusActionForm(ActionForm.AddNew)
                    Case ActionForm.Import, ActionForm.FormLoad, ActionForm.Back, ActionForm.Delete
                        LoadDataCombo()
                        PerformStatusActionForm(ActionForm.FormLoad)
                    Case ActionForm.ShowAll
                        LoadAll()
                        PerformStatusActionForm(ActionForm.FormLoad)
                End Select
            Catch ex As Exception
                ShowError(ex, "SetFormEvents", Me.Name)
            End Try
        End Set
    End Property

#Region "User Function"

    Private Sub PerformStatusActionForm(ByVal enuActionForm As ActionForm)

        mnuAddNew.Enabled = AddNewRight
        mnuBack.Enabled = BackRight
        mnuExport.Enabled = ExportRight
        mnuShowAll.Enabled = ShowAllRight
        mnuImport.Enabled = ImportRight
        mnuDelete.Enabled = DeleteRight
        mnuView.Enabled = ViewLotRight
        mnuViewDebit.Enabled = ViewDebitRight
        mnuViewExcess.Enabled = ViewExcessRight

        If (enuActionForm = ActionForm.FormLoad) Then
            mnuImport.Enabled = False
            mnuBack.Enabled = False
        End If

        If (enuActionForm = ActionForm.AddNew) Then
            mnuAddNew.Enabled = False
            mnuShowAll.Enabled = False
            mnuDelete.Enabled = False
            mnuView.Enabled = False
            mnuViewDebit.Enabled = False
            mnuViewExcess.Enabled = False
        End If

    End Sub

    Private Sub GetPeriodCode()
        Dim sDay As String = dtpFromDate.Value.Day.ToString().PadLeft(2, CType("0", Char))
        Dim sMonth As String = dtpFromDate.Value.Month.ToString().PadLeft(2, CType("0", Char))
        Dim sYear As String = dtpFromDate.Value.Year.ToString()
        cboPeriod.Text = String.Format("WK{0}.{1}.{2}", sDay, sMonth, sYear)
    End Sub

    Private Function ExistPeriodCode() As Boolean
        Dim sDay As String = dtpFromDate.Value.Day.ToString().PadLeft(2, CType("0", Char))
        Dim sMonth As String = dtpFromDate.Value.Month.ToString().PadLeft(2, CType("0", Char))
        Dim sYear As String = dtpFromDate.Value.Year.ToString()

        Dim sPeriodCode As String = String.Format("WK{0}.{1}.{2}", sDay, sMonth, sYear)
        Dim tbl As DataTable = DB.FillDataTable(String.Format("SELECT * FROM PD_LotStatusHead WHERE PeriodCode='{0}'", sPeriodCode))

        Return If(tbl.Rows.Count = 0, False, True)
    End Function

    Private Sub LoadAll()

        If tblOutput IsNot Nothing Then
            tblOutput.Rows.Clear()
            gridOutput.DataSource = Nothing
        End If

        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "LoadAll")
        para(1) = New SqlClient.SqlParameter("@PeriodCode", cboPeriod.Text)

        Dim tbl As DataTable = DB.ExecuteStoreProcedureTB("sp_PD_LotStatusHead", para)

        AddDayColumns()
        CreateDailyOutput(tbl)

        gridOutput.AutoGenerateColumns = False

        bsOutput.DataSource = tblOutput
        gridOutput.DataSource = bsOutput
        bnOutput.BindingSource = bsOutput

        SetGridColor()

    End Sub

    Private bComboLoading As Boolean = False

    Private Sub LoadDataCombo()
        Dim tbl As DataTable = DB.FillDataTable(" SELECT PeriodCode FROM dbo.PD_LotStatusHead GROUP BY PeriodCode " +
                                                " ORDER BY CAST( RIGHT(PeriodCode,4) + '-' + SUBSTRING(PeriodCode,6,2) + '-' + SUBSTRING(PeriodCode,3,2) AS DATETIME) DESC ")
        tbl.Rows.InsertAt(tbl.NewRow(), 0)

        bComboLoading = True

        cboPeriod.ValueMember = "PeriodCode"
        cboPeriod.DisplayMember = "PeriodCode"
        cboPeriod.DataSource = tbl

        bComboLoading = False
    End Sub

    Private Sub SetGridColor()
        For Each r As DataGridViewRow In gridOutput.Rows
            For Each c As DataGridViewColumn In gridOutput.Columns
                If c.DataPropertyName = "PeriodCode" _
                    Or c.DataPropertyName = "FromDate" _
                    Or c.DataPropertyName = "ToDate" _
                    Or c.DataPropertyName = "Idx" _
                    Or c.DataPropertyName = "ProductCode" _
                    Or c.DataPropertyName = "StartLot" _
                    Or c.DataPropertyName = "CreateUser" _
                    Or c.DataPropertyName = "CreateDate" Then
                    Continue For
                End If
                If r.Cells(c.Name).Value IsNot DBNull.Value Then
                    r.Cells(c.Name).Style.BackColor = Drawing.Color.LightBlue
                    r.Cells(c.Name).Style.SelectionBackColor = Drawing.Color.LightBlue
                End If
            Next
        Next
    End Sub

    Private Sub AddDayColumns()
        Dim lst As New List(Of String)

        'Remove trên bảng
        For Each c As DataColumn In tblOutput.Columns
            If c.ColumnName <> "PeriodCode" _
                And c.ColumnName <> "FromDate" _
                And c.ColumnName <> "ToDate" _
                And c.ColumnName <> "Idx" _
                And c.ColumnName <> "ProductCode" _
                And c.ColumnName <> "StartLot" _
                And c.ColumnName <> "CreateUser" _
                And c.ColumnName <> "CreateDate" Then
                lst.Add(c.ColumnName)
            End If
        Next

        For Each item In lst
            tblOutput.Columns.Remove(item)
            gridOutput.Columns.Remove(item)
        Next

        'Add lại các cột ngày dựa trên FromDate -> ToDate
        Dim fromDate As DateTime = dtpFromDate.Value.Date
        Dim toDate As DateTime = dtpToDate.Value.Date

        While fromDate <= toDate
            Dim c As New DataColumn(fromDate.ToString("dd-MMM-yy"), Type.GetType("System.String"))
            If Not tblOutput.Columns.Contains(c.ColumnName) Then
                tblOutput.Columns.Add(c)
                Dim cg As New DataGridViewTextBoxColumn
                cg.DataPropertyName = c.ColumnName
                cg.Name = c.ColumnName
                cg.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                cg.SortMode = DataGridViewColumnSortMode.NotSortable
                If Not gridOutput.Columns.Contains(cg.Name) Then
                    gridOutput.Columns.Add(cg)
                End If
            End If
            fromDate = fromDate.AddDays(1)
        End While
    End Sub

    Private Sub CreateDailyOutput(ByVal tbl As DataTable)

        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "LoadDetail")
        para(1) = New SqlClient.SqlParameter("@FromDate", dtpFromDate.Value.Date)
        para(2) = New SqlClient.SqlParameter("@ToDate", dtpToDate.Value.Date)

        Dim tblDetail As DataTable = DB.ExecuteStoreProcedureTB("sp_PD_LotStatusHead", para)

        For Each r As DataRow In tbl.Rows
            Dim rAdd As DataRow = tblOutput.NewRow()
            Dim rs() As DataRow = Nothing

            rAdd("ProductCode") = r("ProductCode")
            rAdd("StartLot") = r("StartLot")
            rAdd("Idx") = r("Idx")

            For Each c As DataColumn In tblOutput.Columns
                If c.ColumnName = "PeriodCode" _
                    Or c.ColumnName = "FromDate" _
                    Or c.ColumnName = "ToDate" _
                    Or c.ColumnName = "Idx" _
                    Or c.ColumnName = "ProductCode" _
                    Or c.ColumnName = "StartLot" _
                    Or c.ColumnName = "CreateUser" _
                    Or c.ColumnName = "CreateDate" Then
                    Continue For
                End If

                Dim sProductCode As String = r("ProductCode")
                Dim SStartLot As String = r("StartLot")
                Dim planningDate As DateTime = DateTime.ParseExact(c.ColumnName, "dd-MMM-yy", CultureInfo.InvariantCulture)

                rs = tblDetail.Select(String.Format("ProductCode='{0}' And StartLot='{1}' And PlanningDate='{2}'", sProductCode, SStartLot, planningDate.ToString("yyyy-MM-dd")))

                If rs.Length > 0 Then
                    rAdd(c.ColumnName) = If(rs(0)("Quantity") = 0, DBNull.Value, rs(0)("Quantity"))
                End If
            Next

            tblOutput.Rows.Add(rAdd)
        Next
    End Sub

#End Region

#Region "Form Function"

    Private Sub FrmDailyOutputPlanning_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

        AddNewRight = mnuAddNew.Enabled
        BackRight = mnuBack.Enabled
        ExportRight = mnuExport.Enabled
        ShowAllRight = mnuShowAll.Enabled
        ImportRight = mnuImport.Enabled
        DeleteRight = mnuDelete.Enabled
        ViewLotRight = mnuView.Enabled
        ViewDebitRight = mnuViewDebit.Enabled
        ViewExcessRight = mnuViewExcess.Enabled

        DB = New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        dbFpics = New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)

        SetFormEvents = ActionForm.FormLoad
    End Sub

    Private Sub FrmDailyOutputPlanning_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 And mnuShowAll.Enabled Then
            mnuShowAll.PerformClick()
        End If
    End Sub

    Private Sub mnuAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddNew.Click
        SetFormEvents = ActionForm.AddNew
    End Sub

    Private Sub mnuShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAll.Click
        If cboPeriod.Text = String.Empty Then
            MessageBox.Show("<Period> can not be empty", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPeriod.Focus()
            Exit Sub
        End If
        SetFormEvents = ActionForm.ShowAll
    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        If tbMain.SelectedTab Is tpgOutput Then
            If gridOutput.Rows.Count > 0 Then
                ExportEXCEL(gridOutput, True)
            End If
        ElseIf tbMain.SelectedTab Is tpgLotStatus Then
            If gridLotStatus.Rows.Count > 0 Then
                ExportEXCEL(gridLotStatus, True)
            End If
        ElseIf tbMain.SelectedTab Is tpgLotDebit Then
            If gridDebit.Rows.Count > 0 Then
                ExportEXCEL(gridDebit, True)
            End If
        ElseIf tbMain.SelectedTab Is tpgExcess Then
            If gridExcess.Rows.Count > 0 Then
                ExportEXCEL(gridExcess, True)
            End If
        End If
    End Sub

    Private Sub mnuImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImport.Click
        Try
            Dim arrSheet(0) As String
            arrSheet(0) = "output"

            Dim dataset As DataSet = ImportEXCEL(arrSheet)

            If dataset.Tables.Count = 0 Then
                Exit Sub
            End If

            Dim tbl As DataTable = dataset.Tables(0).Copy()

            Me.Cursor = Cursors.WaitCursor

            DB.BeginTransaction()

            'Lấy dữ liệu trên file excel đọc vào
            dtpFromDate.Value = DateTime.ParseExact(tbl.Columns(2).ColumnName, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            dtpToDate.Value = DateTime.ParseExact(tbl.Columns(tbl.Columns.Count - 1).ColumnName, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            GetPeriodCode()

            'Xóa dữ liệu theo period
            Dim para(3) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Action", "DeleteByPeriod")
            para(1) = New SqlClient.SqlParameter("@PeriodCode", cboPeriod.Text)
            para(2) = New SqlClient.SqlParameter("@FromDate", dtpFromDate.Value.Date)
            para(3) = New SqlClient.SqlParameter("@ToDate", dtpToDate.Value.Date)

            DB.ExecuteStoreProcedure("sp_PD_LotStatusHead", para)

            'Thêm vào bảng head
            Dim iIdx As Int32 = 1
            For Each r As DataRow In tbl.Rows

                Dim sProductCode As String = If(r("ProductCode") Is DBNull.Value, String.Empty, r("ProductCode").ToString().PadLeft(5, "0"))
                If String.IsNullOrEmpty(sProductCode) Then Continue For

                Dim obj As New PD_LotStatusHead

                obj.PeriodCode_K = cboPeriod.Text
                obj.FromDate = dtpFromDate.Value.Date
                obj.ToDate = dtpToDate.Value.Date
                obj.ProductCode_K = sProductCode
                obj.StartLot_K = If(r("StartLot") Is DBNull.Value, String.Empty, r("StartLot"))
                obj.Idx = iIdx
                obj.CreateDate = DateTime.Now
                obj.CreateUser = CurrentUser.UserID

                DB.Insert(obj)
                iIdx += 1
            Next

            'Thêm vào bảng detail
            For Each r As DataRow In tbl.Rows

                Dim sProductCode As String = If(r("ProductCode") Is DBNull.Value, String.Empty, r("ProductCode").ToString().PadLeft(5, "0"))
                If String.IsNullOrEmpty(sProductCode) Then Continue For

                For i As Int32 = 2 To tbl.Columns.Count - 1
                    Dim obj As New PD_LotStatusDetail
                    obj.ProductCode_K = sProductCode
                    obj.StartLot_K = If(r("StartLot") Is DBNull.Value, String.Empty, r("StartLot"))
                    obj.PlanningDate_K = DateTime.ParseExact(tbl.Columns(i).ColumnName, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    obj.Quantity = IIf(r(tbl.Columns(i)) Is DBNull.Value, 0, r(tbl.Columns(i)))
                    DB.Insert(obj)
                Next
            Next

            DB.Commit()

            Me.Cursor = Cursors.Arrow

            MessageBox.Show("Import data successfully", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information)

            SetFormEvents = ActionForm.Import
            SetFormEvents = ActionForm.ShowAll

        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            DB.RollBack()
            ShowError(ex, mnuImport.Text, Me.Name)
        End Try
    End Sub

    Private Sub mnuView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuView.Click
        Try
            mnuShowAll.PerformClick()

            tbMain.SelectedTab = tpgLotStatus

            If tblLotStatus IsNot Nothing Then tblLotStatus.Rows.Clear()

            Me.Cursor = Cursors.WaitCursor

            Dim tbl As DataTable = tblLotStatus.Copy()

            Dim sql = String.Format(
                                   "SELECT T.ProductCode " +
                                       ",T.RevisionCode " +
                                       ",T.ComponentCode " +
                                       ",T.LotNumber " +
                                       ",T.ProcessNumber " +
                                       ",T.ProcessCode " +
                                       ",Quantity = T.PieceQuantity " +
                                       ",ProcessName = CASE WHEN T.ProcessNumber='00' THEN 'Wait First' " +
                                                     " WHEN T.ProcessNumber='99' THEN 'Complete Last' ELSE M.ProcessNameE END " +
                                       ",P.StandardLotSize " +
                                       ",ToCompareQty = CASE WHEN T.ProcessNumber='00' or T.ProcessNumber='01' THEN T.PieceQuantity ELSE R.Quantity END " +
                                   "From " +
                                   "dbo.t_Progress T " +
                                   "LEFT JOIN dbo.m_Process M ON T.ProcessCode=M.ProcessCode " +
                                   "LEFT JOIN dbo.m_Product P ON T.ProductCode = P.ProductCode AND T.RevisionCode = P.RevisionCode " +
                                   "LEFT JOIN " +
                                       "(select " +
                                        "T.ProductCode, " +
                                        "T.RevisionCode, " +
                                        "T.ComponentCode, " +
                                        "T.ProcessNumber, " +
                                        "T.LotNumber, " +
                                        "Quantity = T.Quantity * C.ConversionValue1 " +
                                        "from " +
                                            "t_ProcessResult T " +
                                             "LEFT JOIN m_ComponentProcess C " +
                                              "ON T.ProductCode = C.ProductCode " +
                                              "AND T.RevisionCode = C.RevisionCode " +
                                              "AND T.ComponentCode = C.ComponentCode " +
                                              "AND T.ProcessNumber = C.ProcessNumber " +
                                        "where T.ProcessNumber = '01' AND T.ComponentCode = 'B00' " +
                                        ") R " +
                                        "on T.ProductCode = R.ProductCode AND T.RevisionCode = R.RevisionCode AND T.ComponentCode = R.ComponentCode AND T.LotNumber = R.LotNumber " +
                                    "WHERE T.ComponentCode = 'B00'")

            sql = String.Format("select *, Standard = cast(case when isnull(StandardLotSize,0) = isnull(ToCompareQty,0) then 1 else 0 end as bit)  from ({0}) A", sql)
            Dim tblFpic As DataTable = dbFpics.FillDataTable(sql)

            For Each r As DataRow In tblOutput.Rows

                If r("StartLot") Is DBNull.Value Then Continue For
                If r("StartLot") = String.Empty Then Continue For

                Dim startLot As Int32 = CType(r("StartLot"), Int32)
                Dim pdCode As String = r("ProductCode")
                Dim idx As Int32 = r("Idx")

                For Each c As DataColumn In tblOutput.Columns
                    If c.ColumnName = "PeriodCode" _
                        Or c.ColumnName = "FromDate" _
                        Or c.ColumnName = "ToDate" _
                        Or c.ColumnName = "Idx" _
                        Or c.ColumnName = "ProductCode" _
                        Or c.ColumnName = "StartLot" _
                        Or c.ColumnName = "CreateUser" _
                        Or c.ColumnName = "CreateDate" Then
                        Continue For
                    End If

                    If r(c.ColumnName) Is DBNull.Value Then Continue For

                    'Phát sinh lô và tìm trong t_Progress (FPICs)
                    Dim planningDate As DateTime = DateTime.ParseExact(c.ColumnName, "dd-MMM-yy", CultureInfo.InvariantCulture)
                    Dim iQty As Int32 = r(c.ColumnName)

                    For i As Int32 = 0 To iQty - 1
                        Dim sLotNumber As String = (startLot + i).ToString().PadLeft(5, "0")

                        Dim rNew As DataRow = tbl.NewRow()

                        rNew("PlanningDate") = planningDate
                        rNew("Idx") = idx
                        rNew("ProductCode") = pdCode
                        rNew("LotNumber") = sLotNumber

                        'Lấy dữ liệu từ Fpics
                        Dim rsFpic() As DataRow = tblFpic.Select(String.Format("ProductCode='{0}' AND LotNumber='{1}'", pdCode, sLotNumber))

                        If rsFpic.Length > 0 Then
                            rNew("RevisionCode") = rsFpic(0)("RevisionCode")
                            rNew("ComponentCode") = rsFpic(0)("ComponentCode")
                            rNew("ProcessNumber") = rsFpic(0)("ProcessNumber")
                            rNew("ProcessCode") = rsFpic(0)("ProcessCode")
                            rNew("ProcessName") = rsFpic(0)("ProcessName")
                            rNew("Quantity") = rsFpic(0)("Quantity")
                            rNew("Standard") = rsFpic(0)("Standard")
                        End If
                        tbl.Rows.Add(rNew)
                    Next

                    'Cập nhật lại startLot
                    startLot += iQty
                Next
            Next

            Dim rs() As DataRow = tbl.Select(String.Empty, "PlanningDate, Idx, ProductCode, LotNumber")

            If rs.Length > 0 Then
                tblLotStatus = rs.CopyToDataTable()
            End If

            gridLotStatus.AutoGenerateColumns = False

            bsLotStatus.DataSource = tblLotStatus
            gridLotStatus.DataSource = bsLotStatus
            bnLotStatus.BindingSource = bsLotStatus

            'Tô màu dòng có dữ liệu
            For Each r As DataGridViewRow In gridLotStatus.Rows
                If r.Cells("ProcessNumber").Value IsNot DBNull.Value Then
                    r.DefaultCellStyle.BackColor = Drawing.Color.LightGreen
                    r.DefaultCellStyle.SelectionBackColor = Drawing.Color.LightGreen
                End If
            Next

            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            ShowError(ex, mnuView.Text, Me.Name)
        End Try
    End Sub

    Private Sub mnuBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBack.Click
        If (MessageBox.Show("Do you want to back", "Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            SetFormEvents = ActionForm.Back
        End If
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        Try
            If cboPeriod.Text = String.Empty Then Exit Sub

            If (ShowQuestionDelete() = DialogResult.Yes) Then
                DB.BeginTransaction()

                Dim para(3) As SqlClient.SqlParameter
                para(0) = New SqlClient.SqlParameter("@Action", "DeleteByPeriod")
                para(1) = New SqlClient.SqlParameter("@PeriodCode", cboPeriod.Text)
                para(2) = New SqlClient.SqlParameter("@FromDate", dtpFromDate.Value.Date)
                para(3) = New SqlClient.SqlParameter("@ToDate", dtpToDate.Value.Date)

                DB.ExecuteStoreProcedure("sp_PD_LotStatusHead", para)
            End If

            DB.Commit()
            SetFormEvents = ActionForm.Delete
            SetFormEvents = ActionForm.ShowAll
        Catch ex As Exception
            DB.RollBack()
            ShowError(ex, mnuDelete.Text, Me.Name)
        End Try
    End Sub

    Private Sub mnuViewDebit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewDebit.Click
        Try
            mnuShowAll.PerformClick()

            tbMain.SelectedTab = tpgLotDebit

            If tblDebit IsNot Nothing Then tblDebit.Rows.Clear()

            Me.Cursor = Cursors.WaitCursor

            Dim tbl As DataTable = tblDebit.Copy()

            'Lấy dữ liệu từ Fpics
            Dim sql As String = String.Format(
                    " SELECT T.ProductCode " +
                    " ,T.RevisionCode " +
                    " ,T.ComponentCode " +
                    " ,T.LotNumber " +
                    " ,T.ProcessNumber " +
                    " ,T.ProcessCode " +
                    " FROM " +
                    " dbo.t_ProcessResult T " +
                    " INNER JOIN dbo.m_Product P " +
                    " ON T.ProductCode=P.ProductCode " +
                    " AND T.RevisionCode=P.RevisionCode " +
                    " WHERE ComponentCode = 'B00' AND EndDate >= @FromDate AND EndDate <= @ToDate AND T.ProcessCode = '9053' " +
                    " ORDER BY T.ProductCode,T.LotNumber,T.RevisionCode,T.ComponentCode,T.ProcessNumber,T.ProcessCode ")

            Dim fromDate As DateTime = New DateTime(dtpFromDate.Value.AddMonths(-1).Year, dtpFromDate.Value.AddMonths(-1).Month, dtpFromDate.Value.AddMonths(-1).Day, 6, 1, 1)
            Dim toDate As DateTime = New DateTime(dtpToDate.Value.AddDays(1).Year, dtpToDate.Value.AddDays(1).Month, dtpToDate.Value.AddDays(1).Day, 6, 1, 1)

            Dim para(1) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@FromDate", fromDate)
            para(1) = New SqlClient.SqlParameter("@ToDate", toDate)

            Dim tblFpic As DataTable = dbFpics.FillDataTable(sql, para)

            For Each r As DataRow In tblOutput.Rows

                If r("StartLot") Is DBNull.Value Then Continue For
                If r("StartLot") = String.Empty Then Continue For

                Dim startLot As Int32 = CType(r("StartLot"), Int32)
                Dim pdCode As String = r("ProductCode")
                Dim idx As Int32 = r("Idx")

                For Each c As DataColumn In tblOutput.Columns
                    If c.ColumnName = "PeriodCode" _
                        Or c.ColumnName = "FromDate" _
                        Or c.ColumnName = "ToDate" _
                        Or c.ColumnName = "Idx" _
                        Or c.ColumnName = "ProductCode" _
                        Or c.ColumnName = "StartLot" _
                        Or c.ColumnName = "CreateUser" _
                        Or c.ColumnName = "CreateDate" Then
                        Continue For
                    End If

                    If r(c.ColumnName) Is DBNull.Value Then Continue For

                    'Phát sinh lô và tìm trong t_ProcessResult (FPICs)
                    Dim iQty As Int32 = r(c.ColumnName)

                    For i As Int32 = 0 To iQty - 1
                        Dim sLotNumber As String = (startLot + i).ToString().PadLeft(5, "0")

                        Dim rNew As DataRow = tbl.NewRow()

                        rNew("Idx") = idx
                        rNew("ProductCode") = pdCode
                        rNew("LotNumber") = sLotNumber

                        'Lấy dữ liệu từ Fpics
                        Dim rsFpic() As DataRow = tblFpic.Select(String.Format("ProductCode='{0}' AND LotNumber='{1}'", pdCode, sLotNumber))

                        If rsFpic.Length = 0 Then
                            sql = String.Format(
                                   "SELECT T.ProductCode " +
                                       ",T.RevisionCode " +
                                       ",T.ComponentCode " +
                                       ",T.LotNumber " +
                                       ",T.ProcessNumber " +
                                       ",T.ProcessCode " +
                                       ",Quantity = T.PieceQuantity" +
                                       ",ProcessName = CASE WHEN T.ProcessNumber='00' THEN 'Wait First' " +
                                                     " WHEN T.ProcessNumber='99' THEN 'Complete Last' " +
                                                     " ELSE M.ProcessNameE END " +
                                       ",P.StandardLotSize " +
                                       ",ToCompareQty = CASE WHEN T.ProcessNumber='00' or T.ProcessNumber='01' THEN T.PieceQuantity ELSE R.Quantity END " +
                                   "From " +
                                   "dbo.t_Progress T " +
                                   "LEFT JOIN dbo.m_Process M ON T.ProcessCode=M.ProcessCode " +
                                   "LEFT JOIN dbo.m_Product P ON T.ProductCode = P.ProductCode AND T.RevisionCode = P.RevisionCode " +
                                   "LEFT JOIN " +
                                       "(select " +
                                        "T.ProductCode, " +
                                        "T.RevisionCode, " +
                                        "T.ComponentCode, " +
                                        "T.ProcessNumber, " +
                                        "T.LotNumber, " +
                                        "Quantity = T.Quantity * C.ConversionValue1 " +
                                        "from " +
                                            "t_ProcessResult T " +
                                             "LEFT JOIN m_ComponentProcess C " +
                                              "ON T.ProductCode = C.ProductCode " +
                                              "AND T.RevisionCode = C.RevisionCode " +
                                              "AND T.ComponentCode = C.ComponentCode " +
                                              "AND T.ProcessNumber = C.ProcessNumber " +
                                        "where T.ProcessNumber = '01' AND T.ComponentCode = 'B00' " +
                                        ") R " +
                                        "on T.ProductCode = R.ProductCode AND T.RevisionCode = R.RevisionCode AND T.ComponentCode = R.ComponentCode AND T.LotNumber = R.LotNumber " +
                                   "WHERE T.ComponentCode = 'B00' AND T.ProductCode='{0}' AND T.LotNumber='{1}'", pdCode, sLotNumber)

                            sql = String.Format("select *, Standard = cast(case when isnull(StandardLotSize,0) = isnull(ToCompareQty,0) then 1 else 0 end as bit)  from ({0}) A", sql)

                            Dim tbTemp As DataTable = dbFpics.FillDataTable(sql)

                            If tbTemp.Rows.Count > 0 Then
                                rNew("RevisionCode") = tbTemp.Rows(0)("RevisionCode")
                                rNew("ComponentCode") = tbTemp.Rows(0)("ComponentCode")
                                rNew("ProcessNumber") = tbTemp.Rows(0)("ProcessNumber")
                                rNew("ProcessCode") = tbTemp.Rows(0)("ProcessCode")
                                rNew("ProcessName") = tbTemp.Rows(0)("ProcessName")
                                rNew("Quantity") = tbTemp.Rows(0)("Quantity")
                                rNew("Standard") = tbTemp.Rows(0)("Standard")
                            End If

                            tbl.Rows.Add(rNew)
                        End If
                    Next

                    'Cập nhật lại startLot
                    startLot += iQty
                Next
            Next

            Dim rs() As DataRow = tbl.Select(String.Empty, "Idx, ProductCode, LotNumber")

            If rs.Length > 0 Then
                tblDebit = rs.CopyToDataTable()
            End If

            gridLotStatus.AutoGenerateColumns = False

            bsDebit.DataSource = tblDebit
            gridDebit.DataSource = bsDebit
            bnDebit.BindingSource = bsDebit

            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            ShowError(ex, mnuViewDebit.Text, Me.Name)
        End Try
    End Sub

    Private Sub mnuViewExcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewExcess.Click
        Try
            mnuShowAll.PerformClick()

            tbMain.SelectedTab = tpgExcess

            If tblExcess IsNot Nothing Then tblExcess.Rows.Clear()

            Me.Cursor = Cursors.WaitCursor

            Dim tbl As DataTable = tblExcess.Copy()

            'Lấy dữ liệu từ Fpics
            Dim sql As String = String.Format(
                    " SELECT T.ProductCode " +
                    " ,T.RevisionCode " +
                    " ,T.ComponentCode " +
                    " ,T.LotNumber " +
                    " ,T.ProcessNumber " +
                    " ,T.ProcessCode " +
                    " ,T.EndDate " +
                    " ,Quantity = T.Quantity * C.ConversionValue1 " +
                    " ,Standard = cast(case when isnull(P.StandardLotSize,0) = isnull(R.ToCompareQty,0) then 1 else 0 end as bit) " +
                    " FROM " +
                    " dbo.t_ProcessResult T " +
                    " INNER JOIN dbo.m_Product P " +
                        " ON T.ProductCode=P.ProductCode " +
                        " AND T.RevisionCode=P.RevisionCode " +
                    " LEFT JOIN m_ComponentProcess C " +
                        " ON T.ProductCode = C.ProductCode " +
                        " AND T.RevisionCode = C.RevisionCode " +
                        " AND T.ComponentCode = C.ComponentCode " +
                        " AND T.ProcessNumber = C.ProcessNumber " +
                    " LEFT JOIN " +
                        "(select " +
                        "T.ProductCode, " +
                        "T.RevisionCode, " +
                        "T.ComponentCode, " +
                        "T.ProcessNumber, " +
                        "T.LotNumber, " +
                        "ToCompareQty = T.Quantity * C.ConversionValue1 " +
                        "from " +
                            "t_ProcessResult T " +
                                "LEFT JOIN m_ComponentProcess C " +
                                "ON T.ProductCode = C.ProductCode " +
                                "AND T.RevisionCode = C.RevisionCode " +
                                "AND T.ComponentCode = C.ComponentCode " +
                                "AND T.ProcessNumber = C.ProcessNumber " +
                        "where T.ProcessNumber = '01' AND T.ComponentCode = 'B00' " +
                        ") R " +
                        "on T.ProductCode = R.ProductCode AND T.RevisionCode = R.RevisionCode AND T.ComponentCode = R.ComponentCode AND T.LotNumber = R.LotNumber " +
                    " WHERE T.ComponentCode = 'B00' AND T.EndDate >= @FromDate AND T.EndDate <= @ToDate AND T.ProcessCode = '9053' " +
                    " ORDER BY T.ProductCode,T.LotNumber,T.RevisionCode,T.ComponentCode,T.ProcessNumber,T.ProcessCode ")

            Dim fromDate As DateTime = New DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 6, 0, 1)
            Dim toDate As DateTime = New DateTime(dtpToDate.Value.AddDays(1).Year, dtpToDate.Value.AddDays(1).Month, dtpToDate.Value.AddDays(1).Day, 6, 0, 59)

            Dim para(1) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@FromDate", fromDate)
            para(1) = New SqlClient.SqlParameter("@ToDate", toDate)

            Dim tblFpic As DataTable = dbFpics.FillDataTable(sql, para)

            Dim idx As Int32 = 0

            For Each r As DataRow In tblOutput.Rows

                If r("StartLot") Is DBNull.Value Then Continue For
                If r("StartLot") = String.Empty Then Continue For

                Dim startLot As Int32 = CType(r("StartLot"), Int32)
                Dim pdCode As String = r("ProductCode")
                idx = r("Idx")

                For Each c As DataColumn In tblOutput.Columns
                    If c.ColumnName = "PeriodCode" _
                        Or c.ColumnName = "FromDate" _
                        Or c.ColumnName = "ToDate" _
                        Or c.ColumnName = "Idx" _
                        Or c.ColumnName = "ProductCode" _
                        Or c.ColumnName = "StartLot" _
                        Or c.ColumnName = "CreateUser" _
                        Or c.ColumnName = "CreateDate" Then
                        Continue For
                    End If

                    If r(c.ColumnName) Is DBNull.Value Then Continue For

                    'Phát sinh lô và tìm trong t_ProcessResult (FPICs)
                    Dim iQty As Int32 = r(c.ColumnName)

                    'Cập nhật lại startLot
                    startLot += iQty
                Next

                Dim sLotNumber As String = startLot.ToString().PadLeft(5, "0")

                'Lấy dữ liệu từ Fpics
                Dim rsFpic() As DataRow = tblFpic.Select(String.Format("ProductCode='{0}' AND LotNumber>='{1}'", pdCode, sLotNumber))

                If rsFpic.Length > 0 Then
                    For Each radd In rsFpic
                        Dim rNew As DataRow = tbl.NewRow()
                        rNew("Idx") = idx
                        rNew("ProductCode") = radd("ProductCode")
                        rNew("LotNumber") = radd("LotNumber")
                        rNew("Quantity") = radd("Quantity")
                        rNew("Standard") = radd("Standard")
                        tbl.Rows.Add(rNew)
                    Next
                End If
            Next

            idx += 1

            'Tìm mã lô không có trong kế hoạch nhưng có gia công thực tế
            fromDate = New DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 6, 0, 0)
            Dim rsNotInPlan() As DataRow = tblFpic.Select(String.Format("EndDate >= '{0}'", fromDate.ToString("yyyy-MM-dd HH:mm:ss")))

            tblFpic = rsNotInPlan.CopyToDataTable()

            Dim tv As New DataView(tblFpic)
            Dim tblPrdCode As DataTable = tv.ToTable(True, "ProductCode")
            For Each r As DataRow In tblPrdCode.Rows
                Dim rsPd() As DataRow = tblOutput.Select(String.Format("ProductCode='{0}'", r("ProductCode")))
                If rsPd.Length = 0 Then
                    Dim rsAdd() As DataRow = tblFpic.Select(String.Format("ProductCode='{0}'", r("ProductCode")))
                    For Each rAdd In rsAdd
                        If rAdd("ProductCode").ToString().Substring(0, 1) <> "7" Then
                            Dim rNew As DataRow = tbl.NewRow()
                            rNew("Idx") = idx
                            rNew("ProductCode") = rAdd("ProductCode")
                            rNew("LotNumber") = rAdd("LotNumber")
                            rNew("Quantity") = rAdd("Quantity")
                            rNew("Standard") = rAdd("Standard")
                            rNew("IsOutside") = True
                            tbl.Rows.Add(rNew)
                            idx += 1
                        End If
                    Next
                End If
            Next

            Dim rs() As DataRow = tbl.Select(String.Empty, "Idx, ProductCode, LotNumber")

            If rs.Length > 0 Then
                tblExcess = rs.CopyToDataTable()
            End If

            gridExcess.AutoGenerateColumns = False

            bsExcess.DataSource = tblExcess
            gridExcess.DataSource = bsExcess
            bnExcess.BindingSource = bsExcess

            'Tô màu dòng có ProductCode không nằm trong kế hoạch sản xuất
            For Each r As DataGridViewRow In gridExcess.Rows
                Dim bIsOut As Boolean = If(r.Cells("IsOutside").Value Is DBNull.Value, False, r.Cells("IsOutside").Value)
                If bIsOut Then
                    r.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                    r.DefaultCellStyle.SelectionBackColor = Drawing.Color.Yellow
                End If
            Next

            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            ShowError(ex, mnuViewExcess.Text, Me.Name)
        End Try
    End Sub

#End Region

    Private Sub cboPeriod_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPeriod.SelectedValueChanged
        Try
            Dim tbl As DataTable = DB.FillDataTable(String.Format("SELECT TOP 1 FromDate, ToDate FROM dbo.PD_LotStatusHead WHERE PeriodCode = '{0}'", cboPeriod.Text))
            If tbl.Rows.Count > 0 Then
                dtpFromDate.Value = tbl.Rows(0)("FromDate")
                dtpToDate.Value = tbl.Rows(0)("ToDate")
            End If
            If Not bComboLoading Then LoadAll()
        Catch ex As Exception
            ShowError(ex, "cboPeriod_SelectedValueChanged", Me.Name)
        End Try
    End Sub

    Private Sub gridLotStatus_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles gridLotStatus.DataBindingComplete
        'Tô màu dòng có dữ liệu
        For Each r As DataGridViewRow In gridLotStatus.Rows
            If r.Cells("ProcessNumber").Value IsNot DBNull.Value Then
                r.DefaultCellStyle.BackColor = Drawing.Color.LightGreen
                r.DefaultCellStyle.SelectionBackColor = Drawing.Color.LightGreen
                r.DefaultCellStyle.SelectionForeColor = Drawing.Color.White
            End If
        Next
    End Sub

    Private Sub txtProductCode1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProductCode1.TextChanged
        If gridOutput.DataSource Is Nothing Then Exit Sub
        Dim sFilter As String = String.Empty
        If txtProductCode1.Text <> "" Then
            sFilter += String.Format("ProductCode like '%{0}%'", txtProductCode1.Text)
        End If
        CType(CType(gridOutput.DataSource, BindingSource).DataSource, DataTable).DefaultView.RowFilter = sFilter
    End Sub

    Private Sub txtProductCode2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProductCode2.TextChanged
        If gridLotStatus.DataSource Is Nothing Then Exit Sub
        Dim sFilter As String = String.Empty
        If txtProductCode2.Text <> "" Then
            sFilter += String.Format("ProductCode like '%{0}%'", txtProductCode2.Text)
        End If
        CType(CType(gridLotStatus.DataSource, BindingSource).DataSource, DataTable).DefaultView.RowFilter = sFilter
    End Sub

    Private Sub txtProductCode3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductCode3.TextChanged
        If gridDebit.DataSource Is Nothing Then Exit Sub
        Dim sFilter As String = String.Empty
        If txtProductCode3.Text <> "" Then
            sFilter += String.Format("ProductCode like '%{0}%'", txtProductCode3.Text)
        End If
        CType(CType(gridDebit.DataSource, BindingSource).DataSource, DataTable).DefaultView.RowFilter = sFilter
    End Sub

    Private Sub txtProductCode4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductCode4.TextChanged
        If gridExcess.DataSource Is Nothing Then Exit Sub
        Dim sFilter As String = String.Empty
        If txtProductCode4.Text <> "" Then
            sFilter += String.Format("ProductCode like '%{0}%'", txtProductCode4.Text)
        End If
        CType(CType(gridExcess.DataSource, BindingSource).DataSource, DataTable).DefaultView.RowFilter = sFilter
    End Sub

End Class