Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports System.Windows.Forms

Public Class FrmOutDirectMaterial : Inherits DevExpress.XtraEditors.XtraForm
    Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim nvd As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    'Dim dbAS As New DBFunction(PublicConst.EnumServers.NDV_DB2_AS400)
    Dim cls As New clsApplication
    Dim param(1) As SqlClient.SqlParameter
    Dim curUser As String = CurrentUser.UserID
    Dim locked As Integer
    Dim IsView As Boolean = False

    Private Sub mnuShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAll.Click
        locked = 0
        Dim day As String = dtpOrderDate.Value.ToString("yyyyMMdd")
		Dim sql As String = String.Format(" select OutYMD, DeptName, ECode, JCode, SubPrcName, " +
										  " ECodeTemp = ECode, JCodeTemp = JCode, SubPrcNameTemp = SubPrcName, " +
										  " PrcName, JEName, JVName, Unit, MinQty, IssuingQty," +
										  " UsePurpose, Remarks,UpdateDate as CreateDate,UpdateUser as CreateUser " +
										  " from {0} where OutYMD = '{1}' ",
										  PublicTable.Table_PCM_OutDirect, day)
		Dim bd As New BindingSource
        Dim dt As DataTable = nvd.FillDataTable(sql)
        bd.DataSource = dt

        Dim objlock As New PCM_LockDay
        objlock.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
        If nvd.ExistObject(objlock) Then
            nvd.GetObject(objlock)
        Else
            objlock.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
            objlock.JCodeLocked1 = True
            objlock.JCodeLocked2 = True
            objlock.JCodeLocked3 = True
            objlock.TrayLocked1 = True
            objlock.TrayLocked2 = True
            objlock.DirectLocked = True
            objlock.OutWSLocked = True
            nvd.Insert(objlock)
        End If

        Dim objInsert As New PCM_WorkshopInsertStock
        objInsert.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")

        chkLocked.Checked = objlock.DirectLocked
        LockColumn(objlock.DirectLocked)

        Dim dtCombo As DataTable
        Dim rowCombo As DataRow

        Dim SubPrcName As DataGridViewComboBoxColumn = DirectCast(gridD.Columns("SubPrcName"), DataGridViewComboBoxColumn)
        SubPrcName.DataPropertyName = "SubPrcName"
        SubPrcName.ValueMember = "SubPrcName"
        SubPrcName.DisplayMember = "SubPrcName"
        Dim sqlSubPrcName As String = String.Format("Select SubPrcName " +
                                                   "from {0} union select SubPrcName from {1}",
                                                   PublicTable.Table_PCM_Dept,
                                                   PublicTable.Table_PCM_OutDirect)
        dtCombo = nvd.FillDataTable(sqlSubPrcName)
        rowCombo = dtCombo.NewRow
        dtCombo.Rows.InsertAt(rowCombo, 0)
        SubPrcName.DataSource = dtCombo
        SubPrcName.DataSource = dtCombo
        SubPrcName.SortMode = DataGridViewColumnSortMode.Automatic

        gridD.DataSource = bd
        bnGrid.BindingSource = bd

        locked = 1
    End Sub

    Private cbobox As DataGridViewComboBoxEditingControl = Nothing
    Private txtJCode As DataGridViewTextBoxEditingControl = Nothing

    Private Sub gridD_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles gridD.EditingControlShowing
        If chkLocked.Checked = True Then Exit Sub
        If IsView Then Exit Sub

        Try
            Dim dt As New DataTable
            Dim row As DataRow
            If gridD.CurrentCell.ColumnIndex = gridD.Columns("SubPrcName").Index Then
                'If the current cell is of the type "ComboBox" 
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    'Cast the current cell to the temporary control  
                    cbobox = DirectCast(e.Control, DataGridViewComboBoxEditingControl)
                    cbobox.DropDownStyle = ComboBoxStyle.DropDown
                    cbobox.DisplayMember = "SubPrcName"
                    cbobox.ValueMember = "SubPrcName"
                    Dim sql As String = String.Format("select distinct SubPrcName from PCM_Dept " +
                                                      " where ECode = '{0}' and Old = 'False'",
                                                      gridD.CurrentRow.Cells("ECode").Value)
                    dt = nvd.FillDataTable(sql)
                    row = dt.NewRow
                    dt.Rows.InsertAt(row, 0)
                    cbobox.DataSource = dt
                    cbobox.SelectedValue = gridD.CurrentRow.Cells("SubPrcName").Value
                    cbobox.AutoCompleteMode = AutoCompleteMode.Append

                    If cbobox IsNot Nothing Then
                        'Add an EventHandler to the first temporary control  
                        AddHandler cbobox.Validating, AddressOf cbobox_Validating
                    End If
                End If
            End If

            If gridD.CurrentCell.ColumnIndex = gridD.Columns("JCode").Index Then
                'If the current cell is of the type "TextBox" 
                If TypeOf (e.Control) Is DataGridViewTextBoxEditingControl Then
                    'Cast the current cell to the temporary control  
                    txtJCode = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
                  
                    If txtJCode IsNot Nothing Then
                        'Add an EventHandler to the first temporary control  
                        AddHandler txtJCode.Validating, AddressOf cboJCode_Validating
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboJCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If IsView Then Exit Sub

        If gridD.CurrentRow.Cells("ECode").FormattedValue.ToString = "" Then
            MessageBox.Show("Input ECode", "JCode")
            txtJCode.Text = ""
            gridD.CurrentCell.Value = DBNull.Value
            Exit Sub
        End If
        Dim day As String = dtpOrderDate.Value.ToString("yyyyMMdd")
        Dim JCode As String = Trim(UCase(txtJCode.Text))
        Dim JCodeTemp As String = Trim(gridD.CurrentRow.Cells("JCodeTemp").FormattedValue.ToString)
        If JCode = JCodeTemp Then Exit Sub

        Dim sqlJCode As String = String.Format("select ItemCode as JCode, ItemNumberName as JEName, StandardName as JVName, " +
        "UnitCode as Unit, BuyingMinimumQuantity as MinQty " +
        "from t_ASMaterialItem " +
        "Where ItemCode = '{0}'", JCode)
        Dim dtJCode As DataTable = db.FillDataTable(sqlJCode)

        Dim sqlSubCode As String = String.Format("select Code, Name, Unit from {0} " +
        "where Code = '{1}'", PublicTable.Table_PCM_SubMter, JCode)
        Dim dtSubCode As DataTable = nvd.FillDataTable(sqlSubCode)

        If dtJCode.Rows.Count <> 0 Then
            gridD.CurrentRow.Cells("JEName").Value = Trim(dtJCode.Rows(0).Item("JEName"))
            gridD.CurrentRow.Cells("JVName").Value = Trim(dtJCode.Rows(0).Item("JVName"))
            gridD.CurrentRow.Cells("Unit").Value = dtJCode.Rows(0).Item("Unit")
            gridD.CurrentRow.Cells("MinQty").Value = dtJCode.Rows(0).Item("MinQty")
        ElseIf dtSubCode.Rows.Count <> 0 Then
            gridD.CurrentRow.Cells("JVName").Value = Trim(dtSubCode.Rows(0).Item("Name"))
            gridD.CurrentRow.Cells("Unit").Value = dtSubCode.Rows(0).Item("Unit")
        Else
            MessageBox.Show("JCode doesn't exist", "Input JCode")
            txtJCode.Text = ""
            Exit Sub
        End If

        gridD.CurrentRow.Cells("JCode").Value = Trim(UCase(txtJCode.Text))
    End Sub

    Private Sub cbobox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If IsView Then Exit Sub
        If IsDBNull(cbobox.SelectedValue) Then Exit Sub

        If gridD.CurrentRow.Cells("JCode").Value Is DBNull.Value Then
            MessageBox.Show("Input JCode, please", "Input SubPrcName")
            cbobox.SelectedValue = DBNull.Value
            gridD.CurrentCell.Value = DBNull.Value
            Exit Sub
        End If
        Dim day As String = dtpOrderDate.Value.ToString("yyyyMMdd")
        Dim ECode As String = Trim(gridD.CurrentRow.Cells("ECode").FormattedValue.ToString)
        Dim JCode As String = Trim(gridD.CurrentRow.Cells("JCode").FormattedValue.ToString)
        Dim SubPrcName As String = cbobox.SelectedValue
        Dim ECodeTemp As String = Trim(gridD.CurrentRow.Cells("ECodeTemp").FormattedValue.ToString)
        Dim JCodeTemp As String = Trim(gridD.CurrentRow.Cells("JCodeTemp").FormattedValue.ToString)
        Dim SubPrcNameTemp As String = Trim(gridD.CurrentRow.Cells("SubPrcNameTemp").FormattedValue.ToString)
        If ECode = ECodeTemp And JCode = JCodeTemp And SubPrcName = SubPrcNameTemp Then Exit Sub

        For i As Integer = 0 To gridD.Rows.Count - 2
            If gridD.CurrentRow.Index <> gridD.Rows(i).Index And _
                ECode = Trim(gridD.Rows(i).Cells("ECode").FormattedValue.ToString()) And _
                JCode = Trim(gridD.Rows(i).Cells("JCode").FormattedValue.ToString()) And _
                SubPrcName = Trim(gridD.Rows(i).Cells("SubPrcName").FormattedValue.ToString()) Then
                MessageBox.Show("JCode is the same", "Check JCode")
                cbobox.SelectedValue = DBNull.Value
                gridD.CurrentCell.Value = DBNull.Value
                Exit Sub
            End If
        Next
        Dim sql As String = String.Format("select DeptName, PrcName, SubPrcName " +
                                        "from {0} where SubPrcName = '{1}' and ECode = '{2}'", PublicTable.Table_PCM_Dept, SubPrcName, ECode)
        Dim dt As DataTable = nvd.FillDataTable(sql)

        If dt.Rows.Count <> 0 Then
            Dim obj As New PCM_OutDirect()
            obj.OutYMD_K = day
            obj.ECode_K = ECode
            obj.JCode_K = JCodeTemp
            obj.SubPrcName_K = SubPrcNameTemp
            nvd.GetObject(obj)
            obj.DeptName = IIf(dt.Rows(0).Item("DeptName") Is DBNull.Value, "", dt.Rows(0).Item("DeptName"))
            obj.PrcName = IIf(dt.Rows(0).Item("PrcName") Is DBNull.Value, "", dt.Rows(0).Item("PrcName"))
            obj.JEName = IIf(gridD.CurrentRow.Cells("JEName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("JEName").Value)
            obj.JVName = IIf(gridD.CurrentRow.Cells("JVName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("JVName").Value)
            obj.Unit = IIf(gridD.CurrentRow.Cells("Unit").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("Unit").Value)
            obj.MinQty = IIf(gridD.CurrentRow.Cells("MinQty").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("MinQty").Value)

            If nvd.ExistObject(obj) Then
                obj.OutYMD_K = day
                obj.JCode_K = JCode
                obj.SubPrcName_K = SubPrcName
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value

                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                nvd.Update(obj, String.Format("OutYMD = '{0}' and JCode = '{1}' and SubPrcName = '{2}' and ECode = '{3}'", day, JCodeTemp, SubPrcNameTemp, ECodeTemp))
                gridD.CurrentRow.Cells("ECodeTemp").Value = ECode
                gridD.CurrentRow.Cells("JCodeTemp").Value = JCode
                gridD.CurrentRow.Cells("SubPrcNameTemp").Value = SubPrcName
            Else
                obj.OutYMD_K = day
                obj.JCode_K = JCode
                obj.SubPrcName_K = SubPrcName
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value

                obj.CreateUser = CurrentUser.UserID
                obj.CreateDate = DateTime.Now
                nvd.Insert(obj)
                gridD.CurrentRow.Cells("ECodeTemp").Value = ECode
                gridD.CurrentRow.Cells("JCodeTemp").Value = JCode
                gridD.CurrentRow.Cells("SubPrcNameTemp").Value = SubPrcName
            End If
            gridD.CurrentRow.Cells("DeptName").Value = dt.Rows(0).Item("DeptName")
            gridD.CurrentRow.Cells("PrcName").Value = dt.Rows(0).Item("PrcName")
        End If
        'Viet Code cho nay
        gridD.CurrentRow.Cells("OutYMD").Value = day
    End Sub

    Private Sub gridD_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellEndEdit
        If chkLocked.Checked = True Then Exit Sub
        If IsView Then Exit Sub

        If cbobox IsNot Nothing Then
            RemoveHandler cbobox.Validating, AddressOf cbobox_Validating
            cbobox = Nothing
        End If

        If txtJCode IsNot Nothing Then
            RemoveHandler txtJCode.Validating, AddressOf cboJCode_Validating
            txtJCode = Nothing
        End If
    End Sub

    Private Sub gridD_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles gridD.DataError
        If chkLocked.Checked = True Then Exit Sub

        MessageBox.Show("Error happened " _
           & e.Context.ToString())

        If (e.Context = DataGridViewDataErrorContexts.Commit) _
            Then
            MessageBox.Show("Commit error")
        End If
        If (e.Context = DataGridViewDataErrorContexts _
            .CurrentCellChange) Then
            MessageBox.Show("Cell change")
        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) _
            Then
            MessageBox.Show("parsing error")
        End If
        If (e.Context = _
            DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("leave control error")
        End If

        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                .ErrorText = "an error"

            e.ThrowException = False
        End If

    End Sub

    Private Sub FrmOutDirectMaterial_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'Dim a As Decimal = Math.Round(1.785, 2, MidpointRounding.AwayFromZero)
        If cls.checkUserIsView Then
            gridD.ReadOnly = True
            IsView = True
        End If
        gridD.Columns("DeptName").Visible = True
        mnuShowAll.PerformClick()

        chkLocked.Enabled = False

        If cls.checAdmin Then
            chkLocked.Enabled = True
        End If
    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        If gridD.RowCount = 1 Then
            MessageBox.Show("Choose 'Show All' button!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ExportEXCEL(gridD, True)
        End If
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        If gridD.RowCount = 1 Then Exit Sub

        Dim datarow As DataGridViewSelectedRowCollection = gridD.SelectedRows
        If datarow.Count > 0 Then
            Try
                If ShowQuestionDelete() = Windows.Forms.DialogResult.No Then Return
                Dim count As Integer = 0
                nvd.BeginTransaction()
                For row As Integer = 0 To datarow.Count - 1
                    If txtJCode IsNot Nothing Then
                        RemoveHandler txtJCode.Validating, AddressOf cboJCode_Validating
                        txtJCode = Nothing
                    End If

                    If cbobox IsNot Nothing Then
                        RemoveHandler cbobox.Validating, AddressOf cbobox_Validating
                        cbobox = Nothing
                    End If

                    Dim obj As New PCM_OutDirect
                    obj.OutYMD_K = IIf(IsDBNull(datarow.Item(row).Cells("OutYMD").Value), "", datarow.Item(row).Cells("OutYMD").Value)
                    obj.JCode_K = IIf(IsDBNull(datarow.Item(row).Cells("JCode").Value), "", datarow.Item(row).Cells("JCode").Value)
                    obj.SubPrcName_K = IIf(IsDBNull(datarow.Item(row).Cells("SubPrcName").Value), "", datarow.Item(row).Cells("SubPrcName").Value)
                    obj.ECode_K = IIf(IsDBNull(datarow.Item(row).Cells("ECode").Value), "", datarow.Item(row).Cells("ECode").Value)
                    If nvd.ExistObject(obj) Then
                        nvd.GetObject(obj)
                        If chkLocked.Checked = True Then
                            MessageBox.Show("Locked", "Delete")
                            Exit Sub
                        End If

                        nvd.Delete(obj)
                    End If
                Next
                For row As Integer = 0 To datarow.Count - 1
                    Dim bs As New BindingSource()
                    bs = gridD.DataSource
                    Dim rowDelete As DataRowView = DirectCast(bs.Current, DataRowView)
                    rowDelete.Delete()
                    count += 1
                Next
                nvd.Commit()
                MessageBox.Show("Successlly. " & count & "  records.", "Delete language")
            Catch ex As Exception
                nvd.RollBack()
                MessageBox.Show(ex.Message, "Delete")
            End Try
        End If
    End Sub

    Private Sub dtpOrderDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpOrderDate.ValueChanged
        'If dtpOrderDate.Value > DateTime.Now Then
        '    MessageBox.Show("Date > Current Date", "Date")
        '    dtpOrderDate.Value = DateTime.Now
        '    Exit Sub
        'Else
        mnuShowAll.PerformClick()
        'End If
    End Sub

    Function dtInOut() As DataTable
        Dim sql As String = String.Format("select * from {0} where OutYMD = '{1}'",
                                          PublicTable.Table_PCM_OutDirect,
                                          dtpOrderDate.Value.ToString("yyyyMMdd"))
        Dim dt As DataTable = nvd.FillDataTable(sql)
        Return dt
    End Function

    Private Sub chkLocked_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLocked.CheckedChanged
        If locked = 0 Then Exit Sub
        Dim lockDirect As New PCM_LockDay
        lockDirect.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")

        If nvd.ExistObject(lockDirect) Then
            nvd.GetObject(lockDirect)
            lockDirect.DirectLocked = chkLocked.Checked
            nvd.Update(lockDirect)
        Else
            lockDirect.DirectLocked = chkLocked.Checked
            nvd.Insert(lockDirect)
        End If

        If chkLocked.Checked Then
            LockColumn(True)
            MessageBox.Show("Locked", "Lock")
        Else
            LockColumn(False)
            MessageBox.Show("Unlocked", "Lock")
        End If
    End Sub

    Sub LockColumn(ByVal lock As Boolean)
        gridD.Columns("IssuingQty").ReadOnly = lock
        gridD.Columns("ECode").ReadOnly = lock
        gridD.Columns("JCode").ReadOnly = lock
        gridD.Columns("SubPrcName").ReadOnly = lock
        gridD.Columns("UsePurpose").ReadOnly = lock
        gridD.Columns("Remarks").ReadOnly = lock
    End Sub

    Private Sub gridD_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellEnter
		Dim lockDirect As New PCM_LockDay
		lockDirect.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
		nvd.GetObject(lockDirect)
		LockColumn(lockDirect.DirectLocked)

		If chkLocked.Checked = True Then Exit Sub
		If IsView Then Exit Sub

        If locked = 0 Then Exit Sub
        If gridD.CurrentRow.Cells(e.ColumnIndex).[ReadOnly] Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    'Private Sub mnuInsertStock_Click(sender As System.Object, e As System.EventArgs) Handles mnuInsertStock.Click
    '    Try
    '        Dim Question As DialogResult = MessageBox.Show("Bạn chắc chắn là đã chỉnh mạng xuất kho rồi chứ?",
    '                           "Insert Workshop Stock", MessageBoxButtons.YesNo,
    '                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    '        If Question = DialogResult.No Then
    '            Exit Sub
    '        End If

    '        Dim objlock As New PCM_LockDay
    '        objlock.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
    '        If nvd.ExistObject(objlock) Then
    '            nvd.GetObject(objlock)
    '            If objlock.DirectLocked = False Then
    '                MessageBox.Show("This Form is not locked", "Insert Stock")
    '                Exit Sub
    '            End If
    '        Else
    '            MessageBox.Show("This Form is not data", "Insert Stock")
    '            Exit Sub
    '        End If

    '        nvd.BeginTransaction()
    '        Dim objUpdate As New PCM_WorkshopInsertStock

    '        objUpdate.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")

    '        If nvd.ExistObject(objUpdate) Then
    '            nvd.GetObject(objUpdate)

    '            'Insert
    '            If objUpdate.OutDirect = True Then
    '                MessageBox.Show("Already exists", "Insert StockWS")
    '            Else
    '                cls.InsertStock(dtpOrderDate.Value.ToString("yyyyMMdd"), "OutDirect")
    '                objUpdate.OutDirect = True
    '                nvd.Update(objUpdate)
    '                MessageBox.Show("Insert successful", "Insert StockWS")
    '                mnuInsertStock.Enabled = False
    '            End If
    '        Else
    '            'Check
    '            If cls.CheckInsert(dtpOrderDate.Value.ToString("yyyyMMdd")) = False Then
    '                Exit Sub
    '            End If

    '            'Copy
    '            cls.CopyStockWS(dtpOrderDate.Value.ToString("yyyyMMdd"))
    '            objUpdate.CopyStockWS = True
    '            nvd.Insert(objUpdate)

    '            'Insert
    '            cls.InsertStock(dtpOrderDate.Value.ToString("yyyyMMdd"), "OutDirect")
    '            objUpdate.OutDirect = True
    '            nvd.Update(objUpdate)
    '            MessageBox.Show("Insert successful", "Insert StockWS")
    '            mnuInsertStock.Enabled = False
    '        End If
    '        nvd.Commit()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Insert OutDirect")
    '        nvd.RollBack()
    '    End Try
    'End Sub

    Private Sub mnuImport_Click(sender As System.Object, e As System.EventArgs) Handles mnuImport.Click
        Dim sfDlg As New OpenFileDialog()
        sfDlg.DefaultExt = ".xlsx"
        sfDlg.Filter = "Excel 2007 file(.xlsx)|*.xlsx| Excel 2003 file(.xls)|*.xls"
        sfDlg.FileName = "OutDirect-Template ERP.xlsx"
        sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\6.KIỂM SOÁT NHẬP XUẤT TỒN KHO HÀNG VẬT TƯ\3.Phiếu xuất kho\")
        If sfDlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        Dim arrSheet(0) As String
        arrSheet(0) = "OutDirect"
        Dim iCount As Integer = 0

        Dim dataset As DataSet = ImportEXCEL(arrSheet, sfDlg.FileName)
        If dataset IsNot Nothing And dataset.Tables.Count > 0 Then

            Dim counterr As Integer = 1
            Try
                nvd.BeginTransaction()
                For Each row As DataRow In dataset.Tables("OutDirect").Rows
                    counterr += 1
                    Dim obj As New PCM_OutDirect
                    obj.OutYMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")

                    If row(1) IsNot DBNull.Value Then
                        obj.ECode_K = row(1)
                    Else
                        If row(6) IsNot DBNull.Value Then
                            MessageBox.Show("Row " & counterr & ". ECode is null!")
                            nvd.RollBack()
                            Exit Sub
                        Else
                            Continue For
                        End If

                    End If

                    If row(7) IsNot DBNull.Value Then
                        obj.JCode_K = row(7)
                    Else
                        If row(6) IsNot DBNull.Value Then
                            MessageBox.Show("Row " & counterr & ". ItemCode is null!")
                            nvd.RollBack()
                            Exit Sub
                        Else
                            Continue For
                        End If
                    End If

                    Dim sqlSubPrcName As String = String.Format("Select SubPrcName, PrcName from {0} where ECode = '{1}' and [DeptName]='{2}'",
                                                                PublicTable.Table_PCM_Dept, row(1), row(0))
                    Dim dtSubPrcName As DataTable = nvd.FillDataTable(sqlSubPrcName)
                    If dtSubPrcName.Rows.Count > 0 Then
                        obj.SubPrcName_K = dtSubPrcName.Rows(0)("SubPrcName")
                        obj.PrcName = dtSubPrcName.Rows(0)("PrcName")
                    Else
                        sqlSubPrcName = String.Format("Select SubPrcName, PrcName from {0} where ECode = '{1}' ",
                                                                PublicTable.Table_PCM_Dept, row(1))
                        dtSubPrcName = nvd.FillDataTable(sqlSubPrcName)
                        If dtSubPrcName.Rows.Count = 0 Then
                            MessageBox.Show("Row " & (iCount + 1) & " " & row(1) & ". ECode doesn't exist")
                            nvd.RollBack()
                            Exit Sub
                        Else
                            obj.SubPrcName_K = dtSubPrcName.Rows(0)("SubPrcName")
                            obj.PrcName = dtSubPrcName.Rows(0)("PrcName")
                        End If
                    End If

                    obj.JEName = IIf(row(3) Is DBNull.Value, "", row(3))
                    obj.Unit = IIf(row(4) Is DBNull.Value, "", row(4))
                    obj.MinQty = IIf(row(5) Is DBNull.Value, 0, row(5))
                    obj.IssuingQty = IIf(row(6) Is DBNull.Value, 0, row(6))
                    obj.DeptName = IIf(row(0) Is DBNull.Value, "", row(0))
                    If nvd.ExistObject(obj) Then
                        Dim objUpdate As New PCM_OutDirect
                        objUpdate.ECode_K = obj.ECode_K
                        objUpdate.JCode_K = obj.JCode_K
                        objUpdate.OutYMD_K = obj.OutYMD_K
                        objUpdate.SubPrcName_K = obj.SubPrcName_K
                        nvd.GetObject(objUpdate)
                        objUpdate.IssuingQty = objUpdate.IssuingQty + obj.IssuingQty
                        nvd.Update(objUpdate)
                    Else
                        nvd.Insert(obj)
                    End If

                    iCount += 1
                Next
                nvd.Commit()
                MessageBox.Show(String.Format("Successfully, {0} record.", iCount), "Import")
            Catch ex As Exception
                nvd.RollBack()
                MessageBox.Show(counterr & " " & ex.Message, "Error")
            End Try
        End If
    End Sub

    Private Sub gridD_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellValueChanged
        If chkLocked.Checked = True Then Exit Sub
        If IsView Then Exit Sub
        If e.RowIndex = -1 Then Exit Sub

        If e.ColumnIndex = gridD.Columns("JCode").Index _
        Or e.ColumnIndex = gridD.Columns("SubPrcName").Index Then
            Exit Sub
        End If

        If gridD.CurrentRow.Cells(e.ColumnIndex).[ReadOnly] Then Exit Sub

        If e.ColumnIndex = gridD.Columns("ECode").Index Then
            Dim sql As String = String.Format("select distinct SubPrcName from PCM_Dept where ECode = '{0}'",
                                              gridD.CurrentRow.Cells("ECode").Value)
            Dim dt As DataTable = nvd.FillDataTable(sql)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("ECode doesn't exist", "ECode")
                Exit Sub
            End If
        End If

        If e.ColumnIndex = gridD.Columns("JEName").Index Then
            If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) Then
                MessageBox.Show("Input JCode and SubPrcName", "JEName")
                Exit Sub
            End If

            If gridD.CurrentRow.Cells("OutYMD").Value Is DBNull.Value Then Exit Sub

            Dim obj As New PCM_OutDirect()
            obj.OutYMD_K = gridD.CurrentRow.Cells("OutYMD").Value
            obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
            obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
            obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
            nvd.GetObject(obj)
            obj.JEName = gridD.CurrentRow.Cells("JEName").Value

            obj.UpdateUser = CurrentUser.UserID
            obj.UpdateDate = DateTime.Now
            nvd.Update(obj)
        End If

        If e.ColumnIndex = gridD.Columns("JVName").Index Then
            If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) Then
                MessageBox.Show("Input JCode and SubPrcName", "JVName")
                Exit Sub
            End If

            If gridD.CurrentRow.Cells("OutYMD").Value Is DBNull.Value Then Exit Sub

            Dim obj As New PCM_OutDirect()
            obj.OutYMD_K = gridD.CurrentRow.Cells("OutYMD").Value
            obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
            obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
            obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
            nvd.GetObject(obj)
            obj.JVName = gridD.CurrentRow.Cells("JVName").Value

            obj.UpdateUser = CurrentUser.UserID
            obj.UpdateDate = DateTime.Now
            nvd.Update(obj)
        End If

        If e.ColumnIndex = gridD.Columns("IssuingQty").Index Then
            If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) Then
                MessageBox.Show("Input JCode and SubPrcName", "IssuingQty")
                Exit Sub
            End If
            Dim _IssuingQty As Decimal
            If gridD.CurrentRow.Cells("IssuingQty").Value Is DBNull.Value Then
                _IssuingQty = 0
            Else
                _IssuingQty = gridD.CurrentRow.Cells("IssuingQty").Value
            End If

            If gridD.CurrentRow.Cells("OutYMD").Value Is DBNull.Value Then Exit Sub

            Dim obj As New PCM_OutDirect()
            obj.OutYMD_K = gridD.CurrentRow.Cells("OutYMD").Value
            obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
            obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
            obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").FormattedValue.ToString()
            nvd.GetObject(obj)
            obj.IssuingQty = _IssuingQty

            obj.UpdateUser = CurrentUser.UserID
            obj.UpdateDate = DateTime.Now
            nvd.Update(obj)
        End If

        If e.ColumnIndex = gridD.Columns("UsePurpose").Index Then
            If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) Then
                MessageBox.Show("Input JCode and SubPrcName", "UsePurpose")
                Exit Sub
            End If
            If gridD.CurrentRow.Cells("OutYMD").Value Is DBNull.Value Then Exit Sub

            Dim obj As New PCM_OutDirect()
            obj.OutYMD_K = gridD.CurrentRow.Cells("OutYMD").Value
            obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
            obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
            obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
            nvd.GetObject(obj)
            If gridD.CurrentRow.Cells("UsePurpose").Value IsNot DBNull.Value Then
                obj.UsePurpose = gridD.CurrentRow.Cells("UsePurpose").Value
            Else
                obj.UsePurpose = ""
            End If
            obj.UpdateUser = CurrentUser.UserID
            obj.UpdateDate = DateTime.Now
            nvd.Update(obj)
        End If

        If e.ColumnIndex = gridD.Columns("Remarks").Index Then
            If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) Then
                MessageBox.Show("Input JCode and SubPrcName", "Remarks")
                Exit Sub
            End If
            If gridD.CurrentRow.Cells("OutYMD").Value Is DBNull.Value Then Exit Sub

            Dim obj As New PCM_OutDirect()
            obj.OutYMD_K = gridD.CurrentRow.Cells("OutYMD").Value
            obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
            obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
            obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").FormattedValue.ToString()
            nvd.GetObject(obj)
            If gridD.CurrentRow.Cells("Remarks").Value Is DBNull.Value Then
                obj.Remarks = gridD.CurrentRow.Cells("Remarks").Value
            End If

            obj.UpdateUser = CurrentUser.UserID
            obj.UpdateDate = DateTime.Now
            nvd.Update(obj)
        End If
    End Sub
End Class