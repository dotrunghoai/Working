Imports System.Globalization
Imports System.Windows.Forms
Imports System.IO
Imports System.Runtime.InteropServices

Imports CommonDB
Imports LibEntity
Imports PublicUtility
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Threading

Public Class FrmLotProcessStatus : Inherits DevExpress.XtraEditors.XtraForm

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
        Delete = 7
        ViewLot = 8
    End Enum

    Private AddNewRight As Boolean = False
    Private BackRight As Boolean = False
    Private ExportRight As Boolean = False
    Private ShowAllRight As Boolean = False
    Private ImportRight As Boolean = False
    Private DeleteRight As Boolean = False
    Private ViewLotRight As Boolean = False

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

            cboProcess.Enabled = True
            cboPeriod.Enabled = True

            dtpFromDate.Enabled = False
            dtpToDate.Enabled = False

            Try
                Me.Cursor = Cursors.WaitCursor
                Select Case value
                    Case ActionForm.AddNew
                        cboProcess.Enabled = False
                        cboPeriod.Enabled = False
                        PerformStatusActionForm(ActionForm.AddNew)
                    Case ActionForm.FormLoad, ActionForm.Import, ActionForm.Back, ActionForm.Delete
                        LoadDataCombo()
                        PerformStatusActionForm(ActionForm.FormLoad)
                    Case ActionForm.ShowAll
                        LoadAll()
                        PerformStatusActionForm(ActionForm.FormLoad)
                End Select
                Me.Cursor = Cursors.Arrow
            Catch ex As Exception
                Me.Cursor = Cursors.Arrow
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

        If (enuActionForm = ActionForm.FormLoad) Then
            mnuImport.Enabled = False
            mnuBack.Enabled = False
        End If

        If (enuActionForm = ActionForm.AddNew) Then
            mnuAddNew.Enabled = False
            mnuShowAll.Enabled = False
            mnuDelete.Enabled = False
            mnuView.Enabled = False
        End If

    End Sub

    Private Sub GetPeriodCode()
        Dim sDay As String = dtpFromDate.Value.Day.ToString().PadLeft(2, "0")
        Dim sMonth As String = dtpFromDate.Value.Month.ToString().PadLeft(2, "0")
        Dim sYear As String = dtpFromDate.Value.Year.ToString()
        cboPeriod.Text = String.Format("WK{0}.{1}.{2}", sDay, sMonth, sYear)
    End Sub

    Private Function ExistPeriodCode() As Boolean

        Dim sDay As String = dtpFromDate.Value.Day.ToString().PadLeft(2, "0")
        Dim sMonth As String = dtpFromDate.Value.Month.ToString().PadLeft(2, "0")
        Dim sYear As String = dtpFromDate.Value.Year.ToString()

        Dim sPeriodCode As String = String.Format("WK{0}.{1}.{2}", sDay, sMonth, sYear)
        Dim tbl As DataTable = DB.FillDataTable(String.Format("SELECT * FROM {0} WHERE Process = N'{1}' AND PeriodCode='{2}'", _
                                                              PublicTable.Table_PD_LotProcessStatusHead, cboProcess.Text, sPeriodCode))

        Return IIf(tbl.Rows.Count = 0, False, True)

    End Function

    Private Sub LoadAll()

        If tblOutput IsNot Nothing Then
            tblOutput.Rows.Clear()
            gridOutput.DataSource = Nothing
        End If

        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "LoadAll")
        para(1) = New SqlClient.SqlParameter("@Process", cboProcess.Text)
        para(2) = New SqlClient.SqlParameter("@PeriodCode", cboPeriod.Text)

        Dim tbl As DataTable = DB.ExecuteStoreProcedureTB("sp_PD_LotProcessStatusHead", para)

        AddDayColumns()
        CreateDailyOutput(tbl)

        gridOutput.AutoGenerateColumns = False

        bsOutput.DataSource = tblOutput
        gridOutput.DataSource = bsOutput
        bnOutput.BindingSource = bsOutput

        UpdateCustomer()

        SetGridColor()

    End Sub

    Private Sub UpdateCustomer()
        For Each r As DataGridViewRow In gridOutput.Rows
            Dim sPdCode As String = If(r.Cells("ProductCode").Value Is DBNull.Value, String.Empty, r.Cells("ProductCode").Value)
            If String.IsNullOrEmpty(sPdCode) Then Continue For
            Dim sCustomer As String = If(r.Cells("Customer").Value Is DBNull.Value, String.Empty, r.Cells("Customer").Value)
            If Not String.IsNullOrEmpty(sCustomer) Then Continue For
            Dim sql As String = String.Format(" SELECT C.CustomerNameE FROM dbo.m_Product P INNER JOIN dbo.m_Customer C ON P.CustomerCode = C.CustomerCode " +
                                     " Where ProductCode = '{0}' And RevisionCode = '{1}'", _
                                     sPdCode, "01")
            Dim tbl As DataTable = dbFpics.FillDataTable(sql)
            If tbl.Rows.Count > 0 Then
                r.Cells("Customer").Value = tbl.Rows(0)("CustomerNameE")
            End If
        Next
    End Sub

    Private bComboLoading As Boolean = False

    Private Sub LoadDataCombo()

        Dim c As New DataColumn("ProcessName", Type.GetType("System.String"))
        Dim tblProcess As New DataTable
        tblProcess.Columns.Add(c)

        tblProcess.Rows.InsertAt(tblProcess.NewRow(), 0)

        Dim rRS As DataRow = tblProcess.NewRow()
        rRS("ProcessName") = "Rọi sáng"
        tblProcess.Rows.Add(rRS)

        Dim rPreset As DataRow = tblProcess.NewRow()
        rPreset("ProcessName") = "Preset"
        tblProcess.Rows.Add(rPreset)

        Dim rSay As DataRow = tblProcess.NewRow()
        rSay("ProcessName") = "Sấy"
        tblProcess.Rows.Add(rSay)

        Dim rCLS As DataRow = tblProcess.NewRow()
        rCLS("ProcessName") = "Cell Line S00"
        tblProcess.Rows.Add(rCLS)

        Dim rCLU As DataRow = tblProcess.NewRow()
        rCLU("ProcessName") = "Cell Line U00"
        tblProcess.Rows.Add(rCLU)

        Dim rD3 As DataRow = tblProcess.NewRow()
        rD3("ProcessName") = "Đột 3"
        tblProcess.Rows.Add(rD3)

        bComboLoading = True

        cboProcess.DisplayMember = "ProcessName"
        cboProcess.ValueMember = "ProcessName"
        cboProcess.DataSource = tblProcess

        bComboLoading = False
    End Sub

    Private Sub SetGridColor()
        For Each r As DataGridViewRow In gridOutput.Rows
            For Each c As DataGridViewColumn In gridOutput.Columns
                If _
                    c.DataPropertyName = "Process" _
                    Or c.DataPropertyName = "PeriodCode" _
                    Or c.DataPropertyName = "FromDate" _
                    Or c.DataPropertyName = "ToDate" _
                    Or c.DataPropertyName = "ProductCode" _
                    Or c.DataPropertyName = "Customer" _
                    Or c.DataPropertyName = "StartLot" _
                    Or c.DataPropertyName = "Idx" _
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

        For Each c As DataColumn In tblOutput.Columns
            If _
                c.ColumnName <> "Process" _
                And c.ColumnName <> "PeriodCode" _
                And c.ColumnName <> "FromDate" _
                And c.ColumnName <> "ToDate" _
                And c.ColumnName <> "ProductCode" _
                And c.ColumnName <> "Customer" _
                And c.ColumnName <> "StartLot" _
                And c.ColumnName <> "Idx" _
                And c.ColumnName <> "CreateUser" _
                And c.ColumnName <> "CreateDate" Then
                lst.Add(c.ColumnName)
            End If
        Next

        For Each item In lst
            tblOutput.Columns.Remove(item)
            gridOutput.Columns.Remove(item)
        Next

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

        Dim para(4) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "LoadDetail")
        para(1) = New SqlClient.SqlParameter("@Process", cboProcess.Text)
        para(2) = New SqlClient.SqlParameter("@PeriodCode", cboPeriod.Text)
        para(3) = New SqlClient.SqlParameter("@FromDate", dtpFromDate.Value.Date)
        para(4) = New SqlClient.SqlParameter("@ToDate", dtpToDate.Value.Date)

        Dim tblDetail As DataTable = DB.ExecuteStoreProcedureTB("sp_PD_LotProcessStatusHead", para)

        For Each r As DataRow In tbl.Rows
            Dim rAdd As DataRow = tblOutput.NewRow()
            Dim rs() As DataRow = Nothing

            rAdd("ProductCode") = r("ProductCode")
            rAdd("Customer") = r("Customer")
            rAdd("StartLot") = r("StartLot")
            rAdd("Idx") = r("Idx")

            For Each c As DataColumn In tblOutput.Columns
                If _
                    c.ColumnName = "Process" _
                    Or c.ColumnName = "PeriodCode" _
                    Or c.ColumnName = "FromDate" _
                    Or c.ColumnName = "ToDate" _
                    Or c.ColumnName = "Idx" _
                    Or c.ColumnName = "ProductCode" _
                    Or c.ColumnName = "Customer" _
                    Or c.ColumnName = "StartLot" _
                    Or c.ColumnName = "CreateUser" _
                    Or c.ColumnName = "CreateDate" Then
                    Continue For
                End If

                Dim sProductCode As String = r("ProductCode")
                Dim sStartLot As String = r("StartLot")
                Dim planDate As DateTime = DateTime.ParseExact(c.ColumnName, "dd-MMM-yy", CultureInfo.InvariantCulture)

                rs = tblDetail.Select(String.Format("ProductCode='{0}' And StartLot='{1}' And PlanDate='{2}'", sProductCode, sStartLot, planDate.ToString("yyyy-MM-dd")))

                If rs.Length > 0 Then
                    rAdd(c.ColumnName) = If(rs(0)("Quantity") = 0, DBNull.Value, rs(0)("Quantity"))
                End If
            Next

            tblOutput.Rows.Add(rAdd)
        Next
    End Sub

#End Region

#Region "Form Function"

    Private Sub FrmLotProcessStatus_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

        AddNewRight = mnuAddNew.Enabled
        BackRight = mnuBack.Enabled
        ExportRight = mnuExport.Enabled
        ShowAllRight = mnuShowAll.Enabled
        ImportRight = mnuImport.Enabled
        DeleteRight = mnuDelete.Enabled
        ViewLotRight = mnuView.Enabled

        DB = New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        dbFpics = New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)

        SetFormEvents = ActionForm.FormLoad
    End Sub

    Private Sub FrmLotProcessStatus_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 And mnuShowAll.Enabled Then
            mnuShowAll.PerformClick()
        End If
    End Sub

    Private Sub mnuAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddNew.Click
        SetFormEvents = ActionForm.AddNew
    End Sub

    Private Sub mnuShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAll.Click
        If cboProcess.Text = String.Empty Then
            MessageBox.Show("<Process> can not be empty", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboProcess.Focus()
            Exit Sub
        End If
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
        End If
    End Sub

    Private Sub mnuImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImport.Click

        Dim arrSheet() As String = {"Rọi sáng", "Preset", "Sấy", "Cell Line S00", "Cell Line U00", "Đột 3"}

        Dim dataset As DataSet = ImportEXCEL(arrSheet)

        If dataset.Tables.Count = 0 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        DB.BeginTransaction()

        Try
            For Each sSheetName As String In arrSheet

                If Not dataset.Tables.Contains(sSheetName) Then Continue For

                Dim tbl As DataTable = dataset.Tables(sSheetName).Copy()

                If tbl.Rows.Count = 0 Then Continue For

                dtpFromDate.Value = DateTime.ParseExact(tbl.Columns(2).ColumnName, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                dtpToDate.Value = DateTime.ParseExact(tbl.Columns(tbl.Columns.Count - 1).ColumnName, "dd/MM/yyyy", CultureInfo.InvariantCulture)

                GetPeriodCode()

                Dim para(4) As SqlClient.SqlParameter

                para(0) = New SqlClient.SqlParameter("@Action", "DeleteByPeriod")
                para(1) = New SqlClient.SqlParameter("@Process", sSheetName)
                para(2) = New SqlClient.SqlParameter("@PeriodCode", cboPeriod.Text)
                para(3) = New SqlClient.SqlParameter("@FromDate", dtpFromDate.Value.Date)
                para(4) = New SqlClient.SqlParameter("@ToDate", dtpToDate.Value.Date)

                DB.ExecuteStoreProcedure("sp_PD_LotProcessStatusHead", para)

                Dim iIdx As Int32 = 1

                For Each r As DataRow In tbl.Rows

                    Dim obj As New PD_LotProcessStatusHead

                    obj.Process_K = sSheetName
                    obj.PeriodCode_K = cboPeriod.Text
                    obj.FromDate = dtpFromDate.Value.Date
                    obj.ToDate = dtpToDate.Value.Date
                    obj.ProductCode_K = If(r("ProductCode") Is DBNull.Value, String.Empty, r("ProductCode").ToString().PadLeft(5, "0"))
                    obj.StartLot_K = If(r("StartLot") Is DBNull.Value, String.Empty, r("StartLot"))
                    obj.Idx = iIdx
                    obj.CreateDate = DateTime.Now
                    obj.CreateUser = CurrentUser.UserID

                    DB.Insert(obj)
                    iIdx += 1
                Next

                For Each r As DataRow In tbl.Rows
                    For i As Int32 = 2 To tbl.Columns.Count - 1
                        Dim obj As New PD_LotProcessStatusDetail
                        obj.Process_K = sSheetName
                        obj.PeriodCode_K = cboPeriod.Text
                        obj.PlanDate_K = DateTime.ParseExact(tbl.Columns(i).ColumnName, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        obj.ProductCode_K = If(r("ProductCode") Is DBNull.Value, String.Empty, r("ProductCode").ToString().PadLeft(5, "0"))
                        obj.StartLot_K = If(r("StartLot") Is DBNull.Value, String.Empty, r("StartLot"))
                        obj.Quantity = IIf(r(tbl.Columns(i)) Is DBNull.Value, 0, r(tbl.Columns(i)))
                        DB.Insert(obj)
                    Next
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
            If tblLotStatus IsNot Nothing Then tblLotStatus.Rows.Clear()

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
                                       ",ProcessName = CASE WHEN T.ProcessNumber='00' THEN 'Wait First' " +
                                       " WHEN T.ProcessNumber='99' THEN 'Complete Last' " +
                                       " ELSE M.ProcessNameE END " +
                                   "From " +
                                   "dbo.t_Progress T " +
                                   "LEFT JOIN dbo.m_Process M ON T.ProcessCode=M.ProcessCode " +
                                   "WHERE ComponentCode = 'B00'")

            Dim tblFpic As DataTable = dbFpics.FillDataTable(sql)

            For Each r As DataRow In tblOutput.Rows

                If r("StartLot") Is DBNull.Value Then Continue For
                If r("StartLot") = String.Empty Then Continue For

                Dim startLot As Int32 = CType(r("StartLot"), Int32)
                Dim pdCode As String = r("ProductCode")
                Dim customer As String = r("Customer")
                Dim idx As Int32 = r("Idx")

                For Each c As DataColumn In tblOutput.Columns
                    If _
                        c.ColumnName = "Process" _
                        Or c.ColumnName = "PeriodCode" _
                        Or c.ColumnName = "FromDate" _
                        Or c.ColumnName = "ToDate" _
                        Or c.ColumnName = "Idx" _
                        Or c.ColumnName = "ProductCode" _
                        Or c.ColumnName = "Customer" _
                        Or c.ColumnName = "StartLot" _
                        Or c.ColumnName = "CreateUser" _
                        Or c.ColumnName = "CreateDate" Then
                        Continue For
                    End If

                    If r(c.ColumnName) Is DBNull.Value Then Continue For

                    Dim planDate As DateTime = DateTime.ParseExact(c.ColumnName, "dd-MMM-yy", CultureInfo.InvariantCulture)
                    Dim iQty As Int32 = r(c.ColumnName)

                    For i As Int32 = 0 To iQty - 1
                        Dim sLotNumber As String = (startLot + i).ToString().PadLeft(5, "0")

                        Dim rNew As DataRow = tbl.NewRow()

                        rNew("PlanDate") = planDate
                        rNew("Idx") = idx
                        rNew("ProductCode") = pdCode
                        rNew("Customer") = customer
                        rNew("LotNumber") = sLotNumber

                        Dim rsFpic() As DataRow = tblFpic.Select(String.Format("ProductCode='{0}' AND LotNumber='{1}'", pdCode, sLotNumber))

                        If rsFpic.Length > 0 Then
                            rNew("RevisionCode") = rsFpic(0)("RevisionCode")
                            rNew("ComponentCode") = rsFpic(0)("ComponentCode")
                            rNew("ProcessNumber") = rsFpic(0)("ProcessNumber")
                            rNew("ProcessCode") = rsFpic(0)("ProcessCode")
                            rNew("ProcessName") = rsFpic(0)("ProcessName")
                        End If
                        tbl.Rows.Add(rNew)
                    Next

                    startLot += iQty
                Next
            Next

            Dim rs() As DataRow = tbl.Select(String.Empty, "PlanDate, Idx, ProductCode, LotNumber")

            If rs.Length > 0 Then
                tblLotStatus = rs.CopyToDataTable()
            End If

            gridLotStatus.AutoGenerateColumns = False

            bsLotStatus.DataSource = tblLotStatus
            gridLotStatus.DataSource = bsLotStatus
            bnLotStatus.BindingSource = bsLotStatus

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

        If cboPeriod.Text = String.Empty Then Exit Sub

        If (ShowQuestionDelete() = DialogResult.Yes) Then

            DB.BeginTransaction()

            Try
                Dim para(4) As SqlClient.SqlParameter

                para(0) = New SqlClient.SqlParameter("@Action", "DeleteByPeriod")
                para(1) = New SqlClient.SqlParameter("@Process", cboProcess.Text)
                para(2) = New SqlClient.SqlParameter("@PeriodCode", cboPeriod.Text)
                para(3) = New SqlClient.SqlParameter("@FromDate", dtpFromDate.Value.Date)
                para(4) = New SqlClient.SqlParameter("@ToDate", dtpToDate.Value.Date)

                DB.ExecuteStoreProcedure("sp_PD_LotProcessStatusHead", para)

                DB.Commit()

                SetFormEvents = ActionForm.Delete
                SetFormEvents = ActionForm.ShowAll

            Catch ex As Exception
                DB.RollBack()
                ShowError(ex, mnuDelete.Text, Me.Name)
            End Try

        End If
    End Sub

#End Region

    Private Sub cboPeriod_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPeriod.SelectedValueChanged
        If bComboLoading Then Exit Sub
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim tbl As DataTable = DB.FillDataTable(String.Format("SELECT TOP 1 FromDate, ToDate FROM {0} WHERE Process = N'{1}' AND PeriodCode = '{2}'", _
                                                                  PublicTable.Table_PD_LotProcessStatusHead, cboProcess.Text, cboPeriod.Text))
            If tbl.Rows.Count > 0 Then
                dtpFromDate.Value = tbl.Rows(0)("FromDate")
                dtpToDate.Value = tbl.Rows(0)("ToDate")
            End If
            If Not bComboLoading Then LoadAll()
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            ShowError(ex, "cboPeriod_SelectedValueChanged", Me.Name)
        End Try
    End Sub

    Private Sub gridLotStatus_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles gridLotStatus.DataBindingComplete
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

    Private Sub cboProcess_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cboProcess.SelectedValueChanged

        If bComboLoading Then Exit Sub

        Dim tbl As DataTable = DB.FillDataTable(String.Format(
                                                " SELECT PeriodCode FROM {0} WHERE Process = N'{1}' GROUP BY PeriodCode " +
                                                " ORDER BY CAST(RIGHT(PeriodCode,4) + '-' + SUBSTRING(PeriodCode,6,2) + '-' + SUBSTRING(PeriodCode,3,2) AS DATETIME) DESC ", _
                                                PublicTable.Table_PD_LotProcessStatusHead, cboProcess.Text))
        tbl.Rows.InsertAt(tbl.NewRow(), 0)

        cboPeriod.ValueMember = "PeriodCode"
        cboPeriod.DisplayMember = "PeriodCode"
        cboPeriod.DataSource = tbl

    End Sub

    Private Sub gridOutput_DataBindingComplete(sender As System.Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles gridOutput.DataBindingComplete
        SetGridColor()
    End Sub

End Class