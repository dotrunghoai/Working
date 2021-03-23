﻿Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports System.Windows.Forms
Imports vb = Microsoft.VisualBasic
Imports System.Drawing

Public Class FrmWorkshopOut : Inherits DevExpress.XtraEditors.XtraForm
    Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim nvd As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    'Dim dbAS As New DBFunction(PublicConst.EnumServers.NDV_DB2_AS400)
    Dim dbAcc As DBSql = New DBSql(PublicConst.EnumServers.NDV_SQL_Factory)
    Dim cls As New clsApplication
    'Dim param(1) As SqlClient.SqlParameter
    Dim lock As Integer
    Dim dtSearch As DataTable
    Dim IsView As Boolean = False


    Private cboJCode As DataGridViewComboBoxEditingControl = Nothing
    Private cboSubPrcName As DataGridViewComboBoxEditingControl = Nothing

    Private Sub gridD_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles gridD.EditingControlShowing
        If IsView Then Exit Sub

        Dim dt As DataTable
        Dim row As DataRow
        If gridD.CurrentCell.ColumnIndex = gridD.Columns("JCode").Index Then
            'If the current cell is of the type "ComboBox" 
            If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                'Cast the current cell to the temporary control  
                cboJCode = DirectCast(e.Control, DataGridViewComboBoxEditingControl)
                cboJCode.DropDownStyle = ComboBoxStyle.DropDown
                cboJCode.DisplayMember = "JCode"
                cboJCode.ValueMember = "JCode"

                Dim sqlJCode = String.Format("Select distinct A.JCode, A.JEName, A.JVName, A.Unit from (Select JCode, JEName, JVName, Unit from {0} " +
                  "Where left(JCode,1) = 'J' and ECode like '%{2}%' " +
                  "union all Select JCode, JEName, JVName, Unit from {1} " +
                  "Where left(JCode,1) = 'J' and ECode like '%{2}%') A",
                                             PublicTable.Table_PCM_MterNotJCode,
                                             PublicTable.Table_PCM_MterTrayU00,
                                             condiUser)
                dt = nvd.FillDataTable(sqlJCode)
                row = dt.NewRow
                dt.Rows.InsertAt(row, 0)
                cboJCode.DataSource = dt
                cboJCode.SelectedValue = gridD.CurrentRow.Cells("JCode").Value
                cboJCode.AutoCompleteMode = AutoCompleteMode.Append
                If cboJCode IsNot Nothing Then
                    'Add an EventHandler to the first temporary control  
                    AddHandler cboJCode.Validating, AddressOf cboJCode_Validating
                End If

                dtSearch = nvd.FillDataTable(sqlJCode)
                gridSearch.DataSource = dtSearch

            End If
        End If

        If gridD.CurrentCell.ColumnIndex = gridD.Columns("SubPrcName").Index Then
            'If the current cell is of the type "ComboBox" 
            If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                'Cast the current cell to the temporary control  
                cboSubPrcName = DirectCast(e.Control, DataGridViewComboBoxEditingControl)
                cboSubPrcName.DropDownStyle = ComboBoxStyle.DropDown
                cboSubPrcName.DisplayMember = "SubPrcName"
                cboSubPrcName.ValueMember = "SubPrcName"

                Dim sqlSubPrcName = String.Format("Select distinct A.SubPrcName from (Select SubPrcName from {0} " +
                  "Where JCode = '{2}' and ECode like '%{3}%' " +
                  "union all Select SubPrcName from {1} " +
                  "Where JCode = '{2}' and ECode like '%{3}%') A",
                                                  PublicTable.Table_PCM_MterNotJCode,
                                                  PublicTable.Table_PCM_MterTrayU00,
                                                  gridD.CurrentRow.Cells("JCode").Value,
                                                  condiUser)
                dt = nvd.FillDataTable(sqlSubPrcName)
                row = dt.NewRow
                dt.Rows.InsertAt(row, 0)
                cboSubPrcName.DataSource = dt
                cboSubPrcName.SelectedValue = gridD.CurrentRow.Cells("SubPrcName").Value
                cboSubPrcName.AutoCompleteMode = AutoCompleteMode.Append
                If cboSubPrcName IsNot Nothing Then
                    'Add an EventHandler to the first temporary control  
                    AddHandler cboSubPrcName.Validating, AddressOf cboSubPrcName_Validating
                End If
            End If
        End If
    End Sub

    Function CreateID() As String
        Dim ID As String = ""
        Dim stt As String = ""
        Dim o As Object = Nothing
        Dim yyyyMMdd As String = dtpOrderDate.Value.ToString("yyyyMMdd")
        Dim sql As String = String.Format(" select Max(right(YMD, 3)) FROM {0} " +
                                          " where left(YMD, 8) = '{1}' ", PublicTable.Table_PCM_WorkshopOut, yyyyMMdd)
        o = nvd.ExecuteScalar(sql)
        If o IsNot DBNull.Value And o IsNot Nothing Then
            o = Convert.ToInt32(o) + 1
            stt = o.ToString.PadLeft(3, "0")
            ID = yyyyMMdd + stt
        Else
            ID = yyyyMMdd + "001"
        End If
        Return ID
    End Function

    Private Sub cboJCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If IsView Then Exit Sub

        If IsDBNull(cboJCode.SelectedValue) Then Exit Sub

        Dim JCode As String = cboJCode.SelectedValue
        Dim JCodeTemp As String = Trim(gridD.CurrentRow.Cells("JCodeTemp").FormattedValue.ToString)
        If JCode = JCodeTemp Then Exit Sub

        Dim sql = String.Format("Select distinct A.JCode, A.JEName, A.JVName, A.Unit from (Select JCode, JEName, JVName, Unit from {0} " +
                  "Where JCode = '{2}' and ECode = '{3}' " +
                  "union all Select JCode, JEName, JVName, Unit from {1} " +
                  "Where JCode = '{2}' and ECode = '{3}') A", PublicTable.Table_PCM_MterNotJCode, PublicTable.Table_PCM_MterTrayU00, gridD.CurrentRow.Cells("JCode").Value,
                  IIf(gridD.CurrentRow.Cells("ECode").Value Is DBNull.Value, CurrentUser.UserID, gridD.CurrentRow.Cells("ECode").Value))

        Dim dt As DataTable = nvd.FillDataTable(sql)
        If dt.Rows.Count <> 0 Then
            gridD.CurrentRow.Cells("JEName").Value = IIf(dt.Rows(0).Item("JEName") Is DBNull.Value, "", dt.Rows(0).Item("JEName"))
            gridD.CurrentRow.Cells("JVName").Value = IIf(dt.Rows(0).Item("JVName") Is DBNull.Value, "", dt.Rows(0).Item("JVName"))
            gridD.CurrentRow.Cells("Unit").Value = IIf(dt.Rows(0).Item("Unit") Is DBNull.Value, "", dt.Rows(0).Item("Unit"))
        End If

        gridD.CurrentRow.Cells("JCode").Value = JCode
    End Sub

    Private Sub cboSubPrcName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If IsView Then Exit Sub

        If IsDBNull(cboSubPrcName.SelectedValue) Then Exit Sub
        If gridD.CurrentRow.Cells("JCode").Value Is DBNull.Value Then
            MessageBox.Show("Input JCode", "JCode")
            cboSubPrcName.SelectedValue = DBNull.Value
            gridD.CurrentCell.Value = DBNull.Value
            Exit Sub
        End If

        'Try
        Dim JCode As String = Trim(gridD.CurrentRow.Cells("JCode").FormattedValue.ToString)
            Dim SubPrcName As String = IIf(IsDBNull(cboSubPrcName.SelectedValue), "", cboSubPrcName.SelectedValue)
            Dim JCodeTemp As String = Trim(gridD.CurrentRow.Cells("JCodeTemp").FormattedValue.ToString)
            Dim SubPrcNameTemp As String = Trim(gridD.CurrentRow.Cells("SubPrcNameTemp").FormattedValue.ToString)
            If JCode = JCodeTemp And SubPrcName = SubPrcNameTemp Then Exit Sub

        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@SubPrcName", SubPrcName)
        Dim sql As String = String.Format("select PrcName " +
                                            "from {0} where SubPrcName = @SubPrcName and ECode = '{1}'",
                                              PublicTable.Table_PCM_Dept,
                                            IIf(gridD.CurrentRow.Cells("ECode").Value Is DBNull.Value,
                                                CurrentUser.UserID, gridD.CurrentRow.Cells("ECode").Value))
        Dim dt As DataTable = nvd.FillDataTable(sql, para)
        If dt.Rows.Count <> 0 Then
                gridD.CurrentRow.Cells("PrcName").Value = IIf(dt.Rows(0).Item("PrcName") Is DBNull.Value, "", dt.Rows(0).Item("PrcName"))
            End If

            Dim obj As New PCM_WorkshopOut
            obj.YMD_K = IIf(gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value, CreateID(), gridD.CurrentRow.Cells("YMD").Value)
            obj.SubPrcName_K = SubPrcNameTemp
            obj.JCode_K = JCodeTemp
            obj.PrcName_K = IIf(gridD.CurrentRow.Cells("PrcName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("PrcName").Value)
            nvd.GetObject(obj)
            obj.ECode = IIf(gridD.CurrentRow.Cells("ECode").Value Is DBNull.Value, CurrentUser.UserID, gridD.CurrentRow.Cells("ECode").Value)
            obj.JEName = IIf(gridD.CurrentRow.Cells("JEName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("JEName").Value)
            obj.JVName = IIf(gridD.CurrentRow.Cells("JVName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("JVName").Value)
            obj.Unit = IIf(gridD.CurrentRow.Cells("Unit").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("Unit").Value)
            obj.CreateDate = DateTime.Now

            If nvd.ExistObject(obj) Then
                obj.YMD_K = IIf(gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value, CreateID(), gridD.CurrentRow.Cells("YMD").Value)
                obj.JCode_K = Trim(gridD.CurrentRow.Cells("JCode").FormattedValue)
                obj.PrcName_K = IIf(gridD.CurrentRow.Cells("PrcName").Value Is DBNull.Value, Nothing, gridD.CurrentRow.Cells("PrcName").Value)
                obj.SubPrcName_K = cboSubPrcName.SelectedValue
                nvd.Update(obj, String.Format("YMD = '{0}' and PrcName = '{1}' and JCode = '{2}' and SubPrcName = '{3}'",
                                              obj.YMD_K, obj.PrcName_K, JCodeTemp, SubPrcNameTemp))
                gridD.CurrentRow.Cells("JCodeTemp").Value = JCode
                gridD.CurrentRow.Cells("SubPrcNameTemp").Value = SubPrcName
            Else
                obj.YMD_K = IIf(gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value, CreateID(), gridD.CurrentRow.Cells("YMD").Value)
                obj.JCode_K = Trim(gridD.CurrentRow.Cells("JCode").FormattedValue)
                obj.PrcName_K = IIf(gridD.CurrentRow.Cells("PrcName").Value Is DBNull.Value, Nothing, gridD.CurrentRow.Cells("PrcName").Value)
                obj.SubPrcName_K = SubPrcName
                nvd.Insert(obj)
                gridD.CurrentRow.Cells("JCodeTemp").Value = JCode
                gridD.CurrentRow.Cells("SubPrcNameTemp").Value = SubPrcName

                gridD.CurrentRow.Cells("YMD").Value = obj.YMD_K
                gridD.CurrentRow.Cells("ECode").Value = obj.ECode
            End If

            gridD.CurrentRow.Cells("SubPrcName").Value = SubPrcName
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "SubPrcName")
        'End Try

    End Sub

    Private Sub gridD_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellEndEdit
        If IsView Then Exit Sub

        If cboJCode IsNot Nothing Then
            RemoveHandler cboJCode.Validating, AddressOf cboJCode_Validating
            cboJCode = Nothing
        End If

        If cboSubPrcName IsNot Nothing Then
            RemoveHandler cboSubPrcName.Validating, AddressOf cboSubPrcName_Validating
            cboSubPrcName = Nothing
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

    Function condiUser() As String
        If cls.checkUser() Then
            Return ""
        Else
            Return CurrentUser.UserID
        End If
    End Function

    Dim dtAll As DataTable

    Private Sub mnuShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAll.Click
        'Try
        lock = 0
            Dim day As String = dtpOrderDate.Value.ToString("yyyyMMdd")

            Dim dtCombo As DataTable
            Dim rowCombo As DataRow

            Dim JCode As DataGridViewComboBoxColumn = DirectCast(gridD.Columns("JCode"), DataGridViewComboBoxColumn)
            JCode.DataPropertyName = "JCode"
            JCode.ValueMember = "JCode"
            JCode.DisplayMember = "JCode"
            Dim sqlJCode As String = String.Format(" select distinct A.JCode from (Select JCode from {0}" +
                                                   " where ECode like '%{2}%' and left(JCode, 1) = 'J' " +
                                                   " union all select JCode from {1} where ECode like '%{2}%' and left(JCode, 1) = 'J' " +
                                                   " union all Select JCode from PCM_WorkshopOut where left(YMD,8) = '{3}') A" _
                                                    , PublicTable.Table_PCM_MterNotJCode, PublicTable.Table_PCM_MterTrayU00,
                                                    condiUser, dtpOrderDate.Value.ToString("yyyyMMdd"))
            dtCombo = nvd.FillDataTable(sqlJCode)
            rowCombo = dtCombo.NewRow
            dtCombo.Rows.InsertAt(rowCombo, 0)
            JCode.DataSource = dtCombo
            JCode.SortMode = DataGridViewColumnSortMode.Automatic

            Dim SubPrcName As DataGridViewComboBoxColumn = DirectCast(gridD.Columns("SubPrcName"), DataGridViewComboBoxColumn)
            SubPrcName.DataPropertyName = "SubPrcName"
            SubPrcName.ValueMember = "SubPrcName"
            SubPrcName.DisplayMember = "SubPrcName"
            Dim sqlSubPrcName As String = String.Format("select distinct SubPrcName " +
                                                        "from {0} " +
                                                        "Where ECode like '%{1}%'", PublicTable.Table_PCM_Dept, condiUser)
            dtCombo = nvd.FillDataTable(sqlSubPrcName)
            rowCombo = dtCombo.NewRow
            dtCombo.Rows.InsertAt(rowCombo, 0)
            SubPrcName.DataSource = dtCombo
            SubPrcName.SortMode = DataGridViewColumnSortMode.Automatic

            Dim sql As String = String.Format(" select YMD, ECode, JCode, SubPrcName, JCodeTemp = JCode, SubPrcNameTemp = SubPrcName, " +
                                              " PrcName, JEName, JVName, PdCode, StartLot, EndLot, " +
                                              " Width, QtyRestore, ConvertedQtyRestore, QtyOut, Unit, Remark " +
                                              " from {0} where left(YMD, 8) = '{1}' and ECode like '%{2}%' " +
                                              " order by PrcName, ECode, PdCode, JCode",
                                              PublicTable.Table_PCM_WorkshopOut, day, condiUser)
            dtAll = nvd.FillDataTable(sql)
            Dim bd As New BindingSource
            bd.DataSource = dtAll
            gridD.DataSource = bd
            bnGrid.BindingSource = bd

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

            chkLocked.Checked = objlock.OutWSLocked
            LockColumn(objlock.OutWSLocked)

            'draw color
            If gridD.CurrentRow IsNot Nothing Then
                For i = 0 To gridD.RowCount - 2
                    If gridD.Rows(i).Cells("QtyOut").Value < 0 Then
                        gridD.Rows(i).DefaultCellStyle.BackColor = Color.Pink
                    End If
                Next
            End If

            Dim dtFilter As DataTable
            Dim rowFilter As DataRow

            Dim sqlFilter As String = String.Format("Select distinct JCode from {0} Where left(YMD, 8) = '{1}' and ECode like '%{2}%'",
                                                    PublicTable.Table_PCM_WorkshopOut, day, condiUser)
            dtFilter = nvd.FillDataTable(sqlFilter)
            rowFilter = dtFilter.NewRow()
            dtFilter.Rows.InsertAt(rowFilter, 0)
            cboJCodeFilter.DisplayMember = "JCode"
            cboJCodeFilter.ValueMember = "JCode"
            cboJCodeFilter.DataSource = dtFilter
            cboJCodeFilter.SelectedValue = DBNull.Value

            sqlFilter = String.Format("Select distinct SubPrcName from {0} Where left(YMD, 8) = '{1}' and ECode like '%{2}%'",
                                      PublicTable.Table_PCM_WorkshopOut, day, condiUser)
            dtFilter = nvd.FillDataTable(sqlFilter)
            rowFilter = dtFilter.NewRow()
            dtFilter.Rows.InsertAt(rowFilter, 0)
            cboSubPrcNameFilter.DisplayMember = "SubPrcName"
            cboSubPrcNameFilter.ValueMember = "SubPrcName"
            cboSubPrcNameFilter.DataSource = dtFilter
            cboSubPrcNameFilter.SelectedValue = DBNull.Value

            lock = 1
        'Catch ex As Exception
        '    nvd.CloseConnect()
        '    MessageBox.Show(ex.Message, "ShowAll")
        'End Try
    End Sub

    Private Sub FrmWorkshopOut_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        If cls.checkUser() And cls.checkUserIsView = False Then
            gridD.Columns("ECode").Visible = True
            chkLocked.Enabled = True
        ElseIf cls.checkUser() And cls.checkUserIsView Then
            gridD.Columns("ECode").Visible = True

            gridD.ReadOnly = True
            IsView = True
        End If
        mnuShowAll.PerformClick()

    End Sub

    Private Sub gridD_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles gridD.DataError

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
        If (e.Context =
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

    Private Sub gridD_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellEnter
        'Try
        If IsView Then Exit Sub
            If lock = 0 Then Exit Sub
            If chkLocked.Checked = True Then Exit Sub

            If gridD.CurrentRow.Cells(e.ColumnIndex).[ReadOnly] Then
                SendKeys.Send("{Tab}")
                If e.ColumnIndex = gridD.Columns("JCode").Index Then
                    PanelSearch.Visible = True
                End If
            End If

            Dim lockTime As New PCM_LockDay
            lockTime.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
            nvd.GetObject(lockTime)

            If chkLocked.Checked <> lockTime.OutWSLocked Then
                chkLocked.Checked = lockTime.OutWSLocked
                Exit Sub
            End If

            If e.ColumnIndex = gridD.Columns("JCode").Index Then
                Dim x As Integer = gridD.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location.X
                Dim y As Integer = gridD.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location.Y
                PanelSearch.Location = New Point(x + 40, y + 40)
                PanelSearch.Visible = True

                'If gridD.CurrentCell.Value IsNot DBNull.Value And gridD.CurrentCell.Value IsNot Nothing Then
                '    txtSearch.Text = gridD.CurrentCell.Value
                'Else
                '    txtSearch.Text = ""
                'End If
            Else
                PanelSearch.Visible = False
            End If
        'Catch ex As Exception
        '    nvd.CloseConnect()
        '    MessageBox.Show(ex.Message, "Cell enter")
        'End Try
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
                    If gridD.CurrentRow Is Nothing Then
                        Continue For
                    End If
                    If cboJCode IsNot Nothing Then
                        RemoveHandler cboJCode.Validating, AddressOf cboJCode_Validating
                        cboJCode = Nothing
                    End If

                    If cboSubPrcName IsNot Nothing Then
                        RemoveHandler cboSubPrcName.Validating, AddressOf cboSubPrcName_Validating
                        cboSubPrcName = Nothing
                    End If

                    Dim obj As New PCM_WorkshopOut
                    obj.YMD_K = IIf(IsDBNull(datarow.Item(row).Cells("YMD").Value), "", datarow.Item(row).Cells("YMD").Value)
                    obj.JCode_K = IIf(IsDBNull(datarow.Item(row).Cells("JCode").Value), "", datarow.Item(row).Cells("JCode").Value)
                    obj.SubPrcName_K = IIf(IsDBNull(datarow.Item(row).Cells("SubPrcName").Value), "", datarow.Item(row).Cells("SubPrcName").Value)
                    obj.PrcName_K = IIf(IsDBNull(datarow.Item(row).Cells("PrcName").Value), "", datarow.Item(row).Cells("PrcName").Value)
                    If nvd.ExistObject(obj) Then
                        nvd.GetObject(obj)

                        nvd.Delete(obj)
                    End If
                Next

                For row As Integer = 0 To datarow.Count - 1
                    If gridD.CurrentRow Is Nothing Then
                        Continue For
                    End If
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
                nvd.CloseConnect()
                MessageBox.Show(ex.Message, "Delete")
            End Try
        End If
    End Sub

    Private Sub gridD_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridD.CellValidating
        'Try
        If IsView Then Exit Sub

            Dim lockTime As New PCM_LockDay
            lockTime.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
            nvd.GetObject(lockTime)

            If chkLocked.Checked <> lockTime.OutWSLocked Then
                chkLocked.Checked = lockTime.OutWSLocked
                Exit Sub
            End If

            If chkLocked.Checked = True Then Exit Sub

            If e.ColumnIndex = gridD.Columns("JCode").Index _
            Or e.ColumnIndex = gridD.Columns("SubPrcName").Index Then
                Exit Sub
            End If

            If e.ColumnIndex = gridD.Columns("Width").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) Then
                    If Trim(e.FormattedValue.ToString) <> "" Then
                        MessageBox.Show("Input JCode and SubPrcName", "Input Width")
                        e.Cancel = True
                        Exit Sub
                    Else
                        Exit Sub
                    End If
                End If

                Dim Width As Decimal

                If Trim(e.FormattedValue.ToString) = "" Then
                    Width = 0
                ElseIf Not IsNumeric(Trim(e.FormattedValue.ToString)) Then
                    MessageBox.Show("Width must be Numeric", "Input Width")
                    e.Cancel = True
                    Exit Sub
                Else
                    Width = Trim(e.FormattedValue.ToString)
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_WorkshopOut
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.PrcName_K = IIf(gridD.CurrentRow.Cells("PrcName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("PrcName").Value)
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                nvd.GetObject(obj)

                obj.Width = Width
                obj.UpdateDate = DateTime.Now
                obj.UpdateUser = CurrentUser.UserID
                nvd.Update(obj)

                gridD.CurrentRow.Cells("Width").Value = Width
            End If

            If e.ColumnIndex = gridD.Columns("QtyRestore").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) Then
                    If Trim(e.FormattedValue.ToString) <> "" Then
                        MessageBox.Show("Input JCode and SubPrcName", "Input QtyRestore")
                        e.Cancel = True
                        Exit Sub
                    Else
                        Exit Sub
                    End If
                End If

                Dim QtyRestore As Decimal
                If Trim(e.FormattedValue.ToString) = "" Then
                    QtyRestore = 0
                ElseIf Not IsNumeric(Trim(e.FormattedValue.ToString)) Then
                    MessageBox.Show("QtyRestore must be Numeric", "Input QtyRestore")
                    e.Cancel = True
                    Exit Sub
                Else
                    QtyRestore = Trim(e.FormattedValue.ToString)
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub
                Dim obj As New PCM_WorkshopOut
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.PrcName_K = gridD.CurrentRow.Cells("PrcName").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                nvd.GetObject(obj)

                Dim ConvertedQtyRestore As Decimal = 0

                Dim Width As Decimal = IIf(gridD.CurrentRow.Cells("Width").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("Width").Value)
                If Width <> 0 Then
                    Dim sql As String = String.Format("Select SW_Width from Bom_StandardWidth where SW_JCode = '{0}'", obj.JCode_K)
                    Dim dt As DataTable = dbAcc.FillDataTable(sql)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("JCode does not have StandardWidth", "JCode")
                        Exit Sub
                    End If

                    ConvertedQtyRestore = Math.Abs(QtyRestore / (dt.Rows(0).Item("SW_Width") / Width))

                Else
                    ConvertedQtyRestore = Math.Abs(QtyRestore)
                End If

                obj.QtyRestore = QtyRestore
                obj.ConvertedQtyRestore = ConvertedQtyRestore

                'Check OutQty
                Dim QtyIn As Decimal = 0
                Dim FirstStock As Decimal = 0
                Dim sqlmaxday As String = String.Format("select max(YMD) YMD from {0} ",
                    PublicTable.Table_PCM_WorkshopStock)
                Dim dtmaxday As DataTable = nvd.FillDataTable(sqlmaxday)

                'If dtmaxday.Rows(0)("YMD").ToString() = "" Then

                'End If
                If dtpOrderDate.Value.ToString("yyyyMMdd") <= dtmaxday.Rows(0)("YMD").ToString() Then
                    MessageBox.Show("Input Stock Date is wrong", "Input Stock")
                    Exit Sub
                End If

                Dim sqlFirstStock As String = String.Format("Select ConvertedQtyRestore = (ConvertedQtyRestore + Adjust) from {0} " +
                                                            " where YMD = '{1}' and JCode = '{2}' and PrcName = '{3}'",
                                                              PublicTable.Table_PCM_WorkshopStock,
                                                              dtmaxday.Rows(0)("YMD").ToString(),
                                                              gridD.CurrentRow.Cells("JCode").Value,
                                                              gridD.CurrentRow.Cells("PrcName").Value)

                Dim dtFirstStock As DataTable = nvd.FillDataTable(sqlFirstStock)
                If dtFirstStock.Rows.Count <> 0 Then
                    FirstStock = dtFirstStock.Rows(0).Item("ConvertedQtyRestore")
                End If

                'QtyIn
                Dim paQtyIn(3) As SqlClient.SqlParameter
                paQtyIn(0) = New SqlClient.SqlParameter("@StartDate", dtmaxday.Rows(0)("YMD"))
                paQtyIn(1) = New SqlClient.SqlParameter("@EndDate", obj.YMD_K)
                paQtyIn(2) = New SqlClient.SqlParameter("@JCode", obj.JCode_K)
                paQtyIn(3) = New SqlClient.SqlParameter("@PrcName", obj.PrcName_K)
                Dim dtQtyIn As DataTable = nvd.ExecuteStoreProcedureTB("sp_PCM_InsertQtyIn", paQtyIn)
                If dtQtyIn.Rows.Count <> 0 Then
                    QtyIn = dtQtyIn.Compute("Sum(NDVQty)", "")
                End If

                '..........

                obj.QtyOut = (FirstStock + QtyIn) - ConvertedQtyRestore
                If obj.QtyOut < 0 Then
                    MessageBox.Show("Có thể lượng tồn nhập bị sai. Bạn vui lòng kiểm tra lại.", "Input Stock")
                    gridD.CurrentRow.DefaultCellStyle.BackColor = Color.Pink
                End If

                obj.UpdateDate = DateTime.Now
                obj.UpdateUser = CurrentUser.UserID
                nvd.Update(obj)
                gridD.CurrentRow.Cells("QtyRestore").Value = obj.QtyRestore
                gridD.CurrentRow.Cells("ConvertedQtyRestore").Value = obj.ConvertedQtyRestore
                gridD.CurrentRow.Cells("QtyOut").Value = obj.QtyOut
            End If

            If e.ColumnIndex = gridD.Columns("QtyOut").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) Then
                    If Trim(e.FormattedValue.ToString) <> "" Then
                        MessageBox.Show("Input JCode and SubPrcName", "Input QtyUse")
                        e.Cancel = True
                        Exit Sub
                    Else
                        Exit Sub
                    End If
                End If

                Dim _QtyOut As Decimal
                If Trim(e.FormattedValue.ToString) = "" Then
                    _QtyOut = 0
                ElseIf Not IsNumeric(Trim(e.FormattedValue.ToString)) Then
                    MessageBox.Show("QtyOut must be Numeric", "Input QtyOut")
                    e.Cancel = True
                    Exit Sub
                Else
                    _QtyOut = Trim(e.FormattedValue.ToString)
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_WorkshopOut
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.PrcName_K = gridD.CurrentRow.Cells("PrcName").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                nvd.GetObject(obj)
                obj.QtyOut = _QtyOut

                obj.UpdateDate = DateTime.Now
                obj.UpdateUser = CurrentUser.UserID
                nvd.Update(obj)

                gridD.CurrentRow.Cells("QtyOut").Value = _QtyOut
            End If

            If e.ColumnIndex = gridD.Columns("Remark").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) Then
                    If Trim(e.FormattedValue.ToString) <> "" Then
                        MessageBox.Show("Input JCode and SubPrcName", "Input Remark")
                        e.Cancel = True
                        Exit Sub
                    Else
                        Exit Sub
                    End If
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_WorkshopOut
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.PrcName_K = gridD.CurrentRow.Cells("PrcName").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                nvd.GetObject(obj)
                obj.Remark = e.FormattedValue.ToString()

                obj.UpdateDate = DateTime.Now
                obj.UpdateUser = CurrentUser.UserID
                nvd.Update(obj)

                gridD.CurrentRow.Cells("Remark").Value = e.FormattedValue.ToString()
            End If

        'Catch ex As Exception
        '    nvd.CloseConnect()
        '    MessageBox.Show(ex.Message, "gridD_CellValidating")
        'End Try
    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(gridD, True)
    End Sub

    Private Sub gridSearch_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridSearch.CellClick
        If gridD.CurrentRow Is Nothing Then Exit Sub
        If gridSearch Is Nothing Then Exit Sub

        If gridD.CurrentCell.ColumnIndex = gridD.Columns("JCode").Index Then
            gridD.CurrentCell.Value = gridSearch.CurrentRow.Cells("JCodeSearch").Value

            Dim sql = String.Format(" Select distinct A.JCode, A.JEName, A.JVName, A.Unit " +
                                    " from (Select JCode, JEName, JVName, Unit from {0} " +
                                    " Where JCode = '{2}' " +
                                    " union all " +
                                    " Select JCode, JEName, JVName, Unit from {1} " +
                                    " Where JCode = '{2}') A ",
                                    PublicTable.Table_PCM_MterNotJCode,
                                    PublicTable.Table_PCM_MterTrayU00,
                                    gridD.CurrentRow.Cells("JCode").Value)

            Dim dt As DataTable = nvd.FillDataTable(sql)
            If dt.Rows.Count <> 0 Then
                gridD.CurrentRow.Cells("JEName").Value = IIf(dt.Rows(0).Item("JEName") Is DBNull.Value, "", dt.Rows(0).Item("JEName"))
                gridD.CurrentRow.Cells("JVName").Value = IIf(dt.Rows(0).Item("JVName") Is DBNull.Value, "", dt.Rows(0).Item("JVName"))
                gridD.CurrentRow.Cells("Unit").Value = IIf(dt.Rows(0).Item("Unit") Is DBNull.Value, "", dt.Rows(0).Item("Unit"))
            End If

            gridD.CurrentCell = gridD.Item(gridD.CurrentCell.ColumnIndex + 1, gridD.CurrentCell.RowIndex)
            gridD.Focus()
        End If
    End Sub

    Private Sub cboJCodeFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboJCodeFilter.SelectedIndexChanged
        If lock = 0 Then Exit Sub
        If dtAll Is Nothing Then
            Return
        Else
            Dim dv As DataView = New DataView(dtAll)
            dv.RowFilter = "[JCode] LIKE '%" + cboJCodeFilter.SelectedValue + "%'"
            Dim bd As New BindingSource()
            bd.DataSource = dv
            gridD.DataSource = bd
            bnGrid.BindingSource = bd
        End If
    End Sub

    Private Sub cboSubPrcNameFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubPrcNameFilter.SelectedIndexChanged
        If lock = 0 Then Exit Sub
        If dtAll Is Nothing Then
            Return
        Else
            Dim dv As DataView = New DataView(dtAll)
            dv.RowFilter = "[SubPrcName] LIKE '%" + cboSubPrcNameFilter.SelectedValue + "%'"
            Dim bd As New BindingSource()
            bd.DataSource = dv
            gridD.DataSource = bd
            bnGrid.BindingSource = bd
        End If
    End Sub

    Private Sub txtJCodeSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtJCodeSearch.TextChanged
        If dtSearch Is Nothing Then
            Return
        Else
            Dim dv As DataView = New DataView(dtSearch)
            dv.RowFilter = "[JCode] LIKE '%" + txtJCodeSearch.Text + "%'"
            Dim bd As New BindingSource()
            bd.DataSource = dv
            gridSearch.DataSource = bd
            bnGrid.BindingSource = bd
        End If
    End Sub

    Private Sub txtJENameSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtJENameSearch.TextChanged
        If dtSearch Is Nothing Then
            Return
        Else
            Dim dv As DataView = New DataView(dtSearch)
            dv.RowFilter = "[JEName] LIKE '%" + txtJENameSearch.Text + "%'"
            Dim bd As New BindingSource()
            bd.DataSource = dv
            gridSearch.DataSource = bd
            bnGrid.BindingSource = bd
        End If
    End Sub

    Private Sub txtJVNameSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtJVNameSearch.TextChanged
        If dtSearch Is Nothing Then
            Return
        Else
            Dim dv As DataView = New DataView(dtSearch)
            dv.RowFilter = "[JVName] LIKE '%" + txtJVNameSearch.Text + "%'"
            Dim bd As New BindingSource()
            bd.DataSource = dv
            gridSearch.DataSource = bd
            bnGrid.BindingSource = bd
        End If
    End Sub

    Private Sub mnuInsertStock_Click(sender As System.Object, e As System.EventArgs) Handles mnuInsertStock.Click
        Try
            Dim Question As DialogResult = MessageBox.Show("Are you sure?",
                               "Insert Workshop Stock", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Question = DialogResult.No Then
                Exit Sub
            End If

            Dim objlock As New PCM_LockDay
            objlock.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
            If nvd.ExistObject(objlock) Then
                nvd.GetObject(objlock)
                If objlock.OutWSLocked = False Then
                    MessageBox.Show("This Form is not locked", "Insert Stock")
                    Exit Sub
                End If
            Else
                MessageBox.Show("This Form is not data", "Insert Stock")
                Exit Sub
            End If

            nvd.BeginTransaction()
            Dim objUpdate As New PCM_WorkshopInsertStock

            objUpdate.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")

            If nvd.ExistObject(objUpdate) Then
                MessageBox.Show("Already exists", "Insert StockWS")
            Else
                ''Check
                'If cls.CheckInsert(dtpOrderDate.Value.ToString("yyyyMMdd")) = False Then
                '    nvd.CloseConnect()
                '    Exit Sub
                'End If

                'Copy
                cls.CopyStockWS(dtpOrderDate.Value.ToString("yyyyMMdd"))
                objUpdate.CopyStockWS = True
                nvd.Insert(objUpdate)

                'Insert
                cls.InsertStockFromOutWS(dtpOrderDate.Value.ToString("yyyyMMdd"), "OutWS")
                objUpdate.OutWS = True
                nvd.Update(objUpdate)
                MessageBox.Show("Insert successful", "Insert StockWS")
            End If
            nvd.Commit()
        Catch ex As Exception
            nvd.RollBack()
            nvd.CloseConnect()
            MessageBox.Show(ex.Message, "Insert OutWS")
        End Try
    End Sub

    Private Sub chkLocked_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkLocked.CheckedChanged
        Try
            If lock = 0 Then Exit Sub
            Dim lockOutWS As New PCM_LockDay
            lockOutWS.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")

            If nvd.ExistObject(lockOutWS) Then
                nvd.GetObject(lockOutWS)
                lockOutWS.OutWSLocked = chkLocked.Checked
                nvd.Update(lockOutWS)
            Else
                lockOutWS.OutWSLocked = chkLocked.Checked
                nvd.Insert(lockOutWS)
            End If

            If chkLocked.Checked Then
                LockColumn(True)
                MessageBox.Show("Locked", "Lock")
            Else
                LockColumn(False)
                MessageBox.Show("Unlocked", "Lock")
            End If
        Catch ex As Exception
            nvd.CloseConnect()
            MessageBox.Show(ex.Message, "chkLocked")
        End Try

    End Sub

    Sub LockColumn(lock As Boolean)
        gridD.Columns("ECode").ReadOnly = lock
        gridD.Columns("JCode").ReadOnly = lock
        gridD.Columns("SubPrcName").ReadOnly = lock
        gridD.Columns("Width").ReadOnly = lock
        gridD.Columns("QtyRestore").ReadOnly = lock
        gridD.Columns("Remark").ReadOnly = lock
    End Sub

    Private Sub mnuReportStock_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportStock.Click
        Dim frm As New FrmReportStock
        frm.day = dtpOrderDate.Value
        frm.Show()
    End Sub

    Private Sub mnuClearStock_Click(sender As System.Object, e As System.EventArgs) Handles mnuClearStock.Click
        Dim sqlmaxday As String = String.Format("select max(YMD) YMD from {0}", PublicTable.Table_PCM_WorkshopStock)
        Dim dtmaxday As DataTable = nvd.FillDataTable(sqlmaxday)

        If dtmaxday.Rows(0)("YMD").ToString() = "" Then Exit Sub
        Dim YMD As String = dtpOrderDate.Value.ToString("yyyyMMdd")
        If YMD <> dtmaxday.Rows(0)("YMD").ToString() Then Exit Sub

        Try
            nvd.BeginTransaction()
            Dim DeleteStock As String = String.Format("Delete from {0} where YMD = {1}", PublicTable.Table_PCM_WorkshopStock, YMD)
            nvd.ExecuteNonQuery(DeleteStock)
            Dim DeleteInsert As String = String.Format("Delete from {0} where YMD = {1}", PublicTable.Table_PCM_WorkshopInsertStock, YMD)
            nvd.ExecuteNonQuery(DeleteInsert)
            MessageBox.Show("Clear Successfully", "Clear Stock")
            nvd.Commit()
        Catch ex As Exception
            nvd.RollBack()
            nvd.CloseConnect()
            MessageBox.Show(ex.Message, "Clear Stock")
        End Try

    End Sub

    Private Sub mnuImport_Click(sender As System.Object, e As System.EventArgs) Handles mnuImport.Click
        Dim arrSheet(0) As String
        arrSheet(0) = "GetEndLot"
        Dim dataset As DataSet = ImportEXCEL(arrSheet)
        Dim dt As DataTable = dataset.Tables("GetEndLot")

        If dt.Rows.Count <> 0 Then
            For setQty As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(setQty).Item("JCode") Is DBNull.Value Then
                    Continue For
                End If
                If Not IsNumeric(dt.Rows(setQty)("StockWS")) Then
                    dt.Rows(setQty)("StockWS") = 0
                End If
            Next
        End If


        Dim iCount As Integer = 0
        Dim rowError = 0

        Try
            If dt.Rows.Count <> 0 Then

                nvd.BeginTransaction()
                For i As Integer = 0 To dt.Rows.Count - 1
                    rowError = i + 2
                    Dim obj As New PCM_WorkshopOut

                    If dt.Rows(i).Item("JCode") Is DBNull.Value Then
                        Continue For
                    Else
                        obj.JCode_K = Trim(dt.Rows(i).Item("JCode"))
                    End If

                    If dt.Rows(i).Item("SubPrcName") IsNot DBNull.Value Then
                        obj.SubPrcName_K = Trim(dt.Rows(i).Item("SubPrcName"))
                    End If

                    If dt.Rows(i).Item("PrcName") IsNot DBNull.Value Then
                        obj.PrcName_K = Trim(dt.Rows(i).Item("PrcName"))
                    End If

                    If i > 0 Then
                        If Trim(dt.Rows(i).Item("JCode")) = Trim(dt.Rows(i - 1).Item("JCode")) _
                            And Trim(dt.Rows(i).Item("SubPrcName")) = Trim(dt.Rows(i - 1).Item("SubPrcName")) _
                            And Trim(dt.Rows(i).Item("PrcName")) = Trim(dt.Rows(i - 1).Item("PrcName")) Then
                            Continue For
                        End If
                    End If

                    Dim PdCode As String = "0" & vb.Right(Trim(dt.Rows(i).Item("PdCode")).ToString, 4)

                    obj.YMD_K = CreateID()

                    Dim QtyTemp As Decimal = IIf(IsNumeric(dt.Rows(i).Item("StockWS")), dt.Rows(i).Item("StockWS"), 0)
                    Dim QtyRestore As Decimal = dt.Compute("sum(StockWS)", "JCode = '" & dt.Rows(i).Item("JCode") & "' " +
                                                         "AND SubPrcName = '" & dt.Rows(i).Item("SubPrcName") & "' " +
                                                         "AND PrcName = '" & dt.Rows(i).Item("PrcName") & "'")
                    obj.QtyRestore = QtyRestore
                    obj.ConvertedQtyRestore = QtyRestore

                    Dim sqlGetData As String = String.Format("SELECT  ECode, PrcName, JEName, JVName, Unit " +
                    "FROM {0} " +
                    "WHERE   JCode = '{1}' " +
                    "AND SubPrcName = '{2}' " +
                    "AND PdCode = '{3}' " +
                    "AND PrcName = '{4}'", _
                    PublicTable.Table_PCM_MterTrayU00, Trim(dt.Rows(i).Item("JCode")), Trim(dt.Rows(i).Item("SubPrcName")), PdCode, Trim(dt.Rows(i).Item("PrcName")))
                    Dim dtGetData As DataTable = nvd.FillDataTable(sqlGetData)
                    If dtGetData.Rows.Count <> 0 Then
                        obj.ECode = Trim(dtGetData.Rows(0).Item("ECode"))
                        obj.PrcName_K = Trim(dtGetData.Rows(0).Item("PrcName"))
                        obj.JEName = Trim(dtGetData.Rows(0).Item("JEName"))
                        obj.JVName = Trim(dtGetData.Rows(0).Item("JVName"))
                        obj.Unit = Trim(dtGetData.Rows(0).Item("Unit"))
                    Else
                        MessageBox.Show("Row " & (i + 2) & " doesn't exist in DB", "Import Khay/U00")
                        nvd.RollBack()
                        Exit Sub
                    End If

                    'Start OutQty
                    Dim QtyIn As Decimal = 0
                    Dim FirstStock As Decimal = 0
                    Dim sqlmaxday As String = String.Format("select max(YMD) YMD from {0} where JCode = '{1}' and PrcName = '{2}'", _
                        PublicTable.Table_PCM_WorkshopStock, obj.JCode_K, obj.PrcName_K)
                    Dim dtmaxday As DataTable = nvd.FillDataTable(sqlmaxday)

                    If dtpOrderDate.Value.ToString("yyyyMMdd") <= dtmaxday.Rows(0)("YMD").ToString() Then
                        MessageBox.Show("Input Stock Date is wrong", "Input Stock")
                        Exit Sub
                    End If

                    Dim sqlFirstStock As String = String.Format("Select ConvertedQtyRestore = (ConvertedQtyRestore + Adjust) from {0} where YMD = '{1}' and JCode = '{2}' and PrcName = '{3}'", _
                    PublicTable.Table_PCM_WorkshopStock, dtmaxday.Rows(0)("YMD").ToString(), obj.JCode_K, obj.PrcName_K)

                    Dim dtFirstStock As DataTable = nvd.FillDataTable(sqlFirstStock)
                    If dtFirstStock.Rows.Count <> 0 Then
                        FirstStock = dtFirstStock.Rows(0).Item("ConvertedQtyRestore")
                    End If

                    Dim paQtyIn(3) As SqlClient.SqlParameter
                    paQtyIn(0) = New SqlClient.SqlParameter("@StartDate", dtmaxday.Rows(0)("YMD"))
                    paQtyIn(1) = New SqlClient.SqlParameter("@EndDate", obj.YMD_K)
                    paQtyIn(2) = New SqlClient.SqlParameter("@JCode", obj.JCode_K)
                    paQtyIn(3) = New SqlClient.SqlParameter("@PrcName", obj.PrcName_K)
                    Dim dtQtyIn As DataTable = nvd.ExecuteStoreProcedureTB("sp_PCM_InsertQtyIn", paQtyIn)
                    If dtQtyIn.Rows.Count <> 0 Then
                        QtyIn = dtQtyIn.Compute("Sum(NDVQty)", "")
                    End If

                    obj.QtyOut = (FirstStock + QtyIn) - obj.ConvertedQtyRestore
                    'End OutQty
                    If obj.QtyOut < 0 Then
                        ShowWarning(String.Format("Tồn bị âm {0} - ", obj.QtyOut, obj.JCode_K))
                    End If
                    obj.CreateDate = DateTime.Now

                    'Update if...
                    Dim sqlCheckUpdate As String = String.Format("SELECT  YMD " +
                    "FROM {0} " +
                    "WHERE   left(YMD, 8) = '{1}' " +
                    "AND JCode = '{2}' " +
                    "AND SubPrcName = '{3}' " +
                    "AND PrcName = '{4}'", _
                    PublicTable.Table_PCM_WorkshopOut, dtpOrderDate.Value.ToString("yyyyMMdd"), dt.Rows(i).Item("JCode"), dt.Rows(i).Item("SubPrcName"), dt.Rows(i).Item("PrcName"))
                    Dim dtCheckUpdate As DataTable = nvd.FillDataTable(sqlCheckUpdate)
                    If dtCheckUpdate.Rows.Count <> 0 Then
                        obj.YMD_K = dtCheckUpdate.Rows(0)("YMD")
                        nvd.Update(obj)
                    Else
                        nvd.Insert(obj)
                    End If

                    iCount += 1
                Next

                nvd.Commit()

                If (iCount > 0) Then
                    MessageBox.Show(String.Format("Imported successfully!"), "Import Khay/U00")
                End If

            End If
        Catch ex As Exception
            nvd.RollBack()
            nvd.CloseConnect()
            MessageBox.Show(String.Format(ex.Message + " Error, Row {0}.", rowError), "Import Khay/U00")
        End Try
    End Sub
End Class