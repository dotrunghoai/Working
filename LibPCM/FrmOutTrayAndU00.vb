﻿Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmOutTrayAndU00 : Inherits DevExpress.XtraEditors.XtraForm
    'Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim nvd As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    'Dim dbAS As New DBFunction(PublicConst.EnumServers.NDV_DB2_AS400)
    Dim cls As New clsApplication
    Dim param(1) As SqlClient.SqlParameter
    Dim lock As Integer
    Dim dtSearch As DataTable
    Dim IsView As Boolean = False
    Dim Edit As Boolean = False
    Dim avalQty As Decimal
    Dim heldQty As Decimal


    Function condiUser() As String
        If cls.checkUser() Then
            Return ""
        Else
            Return CurrentUser.UserID
        End If
    End Function

    Dim dtAll As DataTable
    Private Sub mnuShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAll.Click
        Try
            lock = 0

            Dim param(5) As SqlClient.SqlParameter
            Dim day As String = dtpOrderDate.Value.ToString("yyyyMMdd")
            Dim M1 As DateTime = New DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, DateTime.Now.AddMonths(-1).Day)
            Dim M3 As DateTime = New DateTime(DateTime.Now.AddMonths(-3).Year, DateTime.Now.AddMonths(-3).Month, DateTime.Now.AddMonths(-3).Day)
            Dim Day1 As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            Dim DayNow As DateTime = DateTime.Now

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

            gridD.Columns("LotS1").ReadOnly = objlock.TrayLocked1
            gridD.Columns("LotE1").ReadOnly = objlock.TrayLocked1
            gridD.Columns("Bal1").ReadOnly = objlock.TrayLocked1
            chkLocked1.Checked = objlock.TrayLocked1

            gridD.Columns("LotS2").ReadOnly = objlock.TrayLocked2
            gridD.Columns("LotE2").ReadOnly = objlock.TrayLocked2
            gridD.Columns("Bal2").ReadOnly = objlock.TrayLocked2
            chkLocked2.Checked = objlock.TrayLocked2

            'If cls.checkUser() Then
            gridD.Columns("MatQty1").ReadOnly = objlock.TrayLocked1
            gridD.Columns("MatQty2").ReadOnly = objlock.TrayLocked2
            'Else
            '    gridD.Columns("MatQty1").ReadOnly = True
            '    gridD.Columns("MatQty2").ReadOnly = True
            'End If

            param(0) = New SqlClient.SqlParameter("@M1", M1.ToString("yyyyMM"))
            param(1) = New SqlClient.SqlParameter("@M3", M3.ToString("yyyyMM"))
            param(2) = New SqlClient.SqlParameter("@Day1", Day1.ToString("yyyyMMdd"))
            param(3) = New SqlClient.SqlParameter("@DayNow", DayNow.ToString("yyyyMMdd"))
            param(4) = New SqlClient.SqlParameter("@day", day)
            param(5) = New SqlClient.SqlParameter("@condiUser", condiUser)

            Dim bd As New BindingSource
            dtAll = nvd.ExecuteStoreProcedureTB("sp_PCM_OutTrayAndU00", param)
            bd.DataSource = dtAll

            Dim dtCombo As DataTable
            Dim rowCombo As DataRow

            Dim JCode As DataGridViewComboBoxColumn = DirectCast(gridD.Columns("JCode"), DataGridViewComboBoxColumn)
            JCode.DataPropertyName = "JCode"
            JCode.ValueMember = "JCode"
            JCode.DisplayMember = "JCode"
            Dim sqlJCode As String = String.Format("Select JCode " +
            "from {0} Where ECode like '%{2}%' " +
            "union select JCode from {1} " +
            "Where ECode like '%{2}%'", PublicTable.Table_PCM_MterTrayU00, PublicTable.Table_PCM_TrayU00, condiUser)
            dtCombo = nvd.FillDataTable(sqlJCode)
            rowCombo = dtCombo.NewRow
            dtCombo.Rows.InsertAt(rowCombo, 0)
            JCode.DataSource = dtCombo
            JCode.SortMode = DataGridViewColumnSortMode.Automatic

            Dim SubPrcName As DataGridViewComboBoxColumn = DirectCast(gridD.Columns("SubPrcName"), DataGridViewComboBoxColumn)
            SubPrcName.DataPropertyName = "SubPrcName"
            SubPrcName.ValueMember = "SubPrcName"
            SubPrcName.DisplayMember = "SubPrcName"
            Dim sqlSubPrcName As String = String.Format("Select SubPrcName from {0} " +
            "Where ECode like '%{2}%' " +
            "union select SubPrcName from {1} " +
            "Where ECode like '%{2}%'", PublicTable.Table_PCM_MterTrayU00, PublicTable.Table_PCM_TrayU00, condiUser)
            dtCombo = nvd.FillDataTable(sqlSubPrcName)
            rowCombo = dtCombo.NewRow
            dtCombo.Rows.InsertAt(rowCombo, 0)
            SubPrcName.DataSource = dtCombo
            SubPrcName.SortMode = DataGridViewColumnSortMode.Automatic

            Dim PdCode As DataGridViewComboBoxColumn = DirectCast(gridD.Columns("PdCode"), DataGridViewComboBoxColumn)
            PdCode.DataPropertyName = "PdCode"
            PdCode.ValueMember = "PdCode"
            PdCode.DisplayMember = "PdCode"
            Dim sqlPdCode As String = String.Format("Select PdCode from {0} " +
            "Where ECode like '%{2}%' " +
            "union select PdCode from {1} " +
            "Where ECode like '%{2}%'", PublicTable.Table_PCM_MterTrayU00, PublicTable.Table_PCM_TrayU00, condiUser)
            dtCombo = nvd.FillDataTable(sqlPdCode)
            rowCombo = dtCombo.NewRow
            dtCombo.Rows.InsertAt(rowCombo, 0)
            PdCode.DataSource = dtCombo
            PdCode.SortMode = DataGridViewColumnSortMode.Automatic

            Dim dtFilter As DataTable
            Dim rowFilter As DataRow

            Dim sqlFilter As String = String.Format("Select distinct JCode from {0} Where YMD = '{1}' and ECode like '%{2}%'", PublicTable.Table_PCM_TrayU00, day, condiUser)
            dtFilter = nvd.FillDataTable(sqlFilter)
            rowFilter = dtFilter.NewRow()
            dtFilter.Rows.InsertAt(rowFilter, 0)
            cboJCodeFilter.DisplayMember = "JCode"
            cboJCodeFilter.ValueMember = "JCode"
            cboJCodeFilter.DataSource = dtFilter
            cboJCodeFilter.SelectedValue = DBNull.Value

            sqlFilter = String.Format("Select distinct SubPrcName from {0} Where YMD = '{1}' and ECode like '%{2}%'", PublicTable.Table_PCM_TrayU00, day, condiUser)
            dtFilter = nvd.FillDataTable(sqlFilter)
            rowFilter = dtFilter.NewRow()
            dtFilter.Rows.InsertAt(rowFilter, 0)
            cboSubPrcNameFilter.DisplayMember = "SubPrcName"
            cboSubPrcNameFilter.ValueMember = "SubPrcName"
            cboSubPrcNameFilter.DataSource = dtFilter
            cboSubPrcNameFilter.SelectedValue = DBNull.Value

            sqlFilter = String.Format("Select distinct ECode from {0} Where YMD = '{1}' and ECode like '%{2}%'", PublicTable.Table_PCM_TrayU00, day, condiUser)
            dtFilter = nvd.FillDataTable(sqlFilter)
            rowFilter = dtFilter.NewRow()
            dtFilter.Rows.InsertAt(rowFilter, 0)
            cboECodeFilter.DisplayMember = "ECode"
            cboECodeFilter.ValueMember = "ECode"
            cboECodeFilter.DataSource = dtFilter
            cboECodeFilter.SelectedValue = DBNull.Value

            sqlFilter = String.Format("Select distinct PdCode from {0} Where YMD = '{1}' and ECode like '%{2}%'", PublicTable.Table_PCM_TrayU00, day, condiUser)
            dtFilter = nvd.FillDataTable(sqlFilter)
            rowFilter = dtFilter.NewRow()
            dtFilter.Rows.InsertAt(rowFilter, 0)
            cboPdCodeFilter.DisplayMember = "PdCode"
            cboPdCodeFilter.ValueMember = "PdCode"
            cboPdCodeFilter.DataSource = dtFilter
            cboPdCodeFilter.SelectedValue = DBNull.Value

            If chkLocked1.Checked = True And chkLocked2.Checked = True Then
                LockColums(False)
            Else
                LockColums(True)
            End If

            gridD.DataSource = bd
            bnGrid.BindingSource = bd

            If dtAll.Rows.Count <> 0 Then
                tsTotal1.Text = dtAll.Compute("sum(MatQty1)", "")
                tsTotal2.Text = dtAll.Compute("sum(MatQty2)", "")
            End If

            lock = 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "mnuShowAll_Click")
        End Try
    End Sub

    Function CurrUser() As String
        If gridD.CurrentRow.Cells("ECode").Value IsNot DBNull.Value Then
            Return gridD.CurrentRow.Cells("ECode").Value
        End If
        Return CurrentUser.UserID
    End Function

    Private cboJCode As DataGridViewComboBoxEditingControl = Nothing
    Private cbobox As DataGridViewComboBoxEditingControl = Nothing
    Private cboPdCode As DataGridViewComboBoxEditingControl = Nothing
    Private txtQty As DataGridViewTextBoxEditingControl = Nothing

    Private Sub gridD_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles gridD.EditingControlShowing
        If chkLocked1.Checked = True And chkLocked2.Checked = True And Edit = False Then Exit Sub
        If IsView Then Exit Sub

        Try
            Dim dt As New DataTable
            Dim row As DataRow
            If gridD.CurrentCell.ColumnIndex = gridD.Columns("JCode").Index Then
                'If the current cell is of the type "ComboBox" 
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    'Cast the current cell to the temporary control  
                    cboJCode = DirectCast(e.Control, DataGridViewComboBoxEditingControl)
                    cboJCode.DropDownStyle = ComboBoxStyle.DropDown
                    cboJCode.DisplayMember = "JCode"
                    cboJCode.ValueMember = "JCode"
                    Dim sqlJCode As String = String.Format("select distinct JCode, JEName, JVName " +
                    "from {0} " +
                    "Where ECode = '{1}' and Old = 'False'", PublicTable.Table_PCM_MterTrayU00, CurrUser)
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
                    cbobox = DirectCast(e.Control, DataGridViewComboBoxEditingControl)
                    cbobox.DropDownStyle = ComboBoxStyle.DropDown
                    cbobox.DisplayMember = "SubPrcName"
                    cbobox.ValueMember = "SubPrcName"
                    Dim sqlSubPrcName As String = String.Format("select distinct SubPrcName " +
                    "from {0} " +
                    "Where ECode = '{1}' and JCode = '{2}' and Old = 'False'", PublicTable.Table_PCM_MterTrayU00, CurrUser, gridD.CurrentRow.Cells("JCode").Value)
                    dt = nvd.FillDataTable(sqlSubPrcName)
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

            If gridD.CurrentCell.ColumnIndex = gridD.Columns("PdCode").Index Then
                'If the current cell is of the type "ComboBox" 
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    'Cast the current cell to the temporary control  
                    cboPdCode = DirectCast(e.Control, DataGridViewComboBoxEditingControl)
                    cboPdCode.DropDownStyle = ComboBoxStyle.DropDown
                    cboPdCode.DisplayMember = "PdCode"
                    cboPdCode.ValueMember = "PdCode"
                    Dim sqlPdCode As String = String.Format("select distinct PdCode " +
                    "from {0} " +
                    "Where ECode = '{1}' and JCode = '{2}' and SubPrcName = '{3}' and Old = 'False'", PublicTable.Table_PCM_MterTrayU00,
                    CurrUser, gridD.CurrentRow.Cells("JCode").Value, gridD.CurrentRow.Cells("SubPrcName").Value)
                    dt = nvd.FillDataTable(sqlPdCode)
                    row = dt.NewRow
                    dt.Rows.InsertAt(row, 0)
                    cboPdCode.DataSource = dt
                    cboPdCode.SelectedValue = gridD.CurrentRow.Cells("PdCode").Value
                    cboPdCode.AutoCompleteMode = AutoCompleteMode.Append
                    If cboPdCode IsNot Nothing Then
                        'Add an EventHandler to the first temporary control  
                        AddHandler cboPdCode.Validating, AddressOf cboPdCode_Validating
                    End If
                End If
            End If

            If gridD.CurrentCell.ColumnIndex = gridD.Columns("LotS1").Index _
                Or gridD.CurrentCell.ColumnIndex = gridD.Columns("LotE1").Index _
                Or gridD.CurrentCell.ColumnIndex = gridD.Columns("Bal1").Index _
                Or gridD.CurrentCell.ColumnIndex = gridD.Columns("MatQty1").Index _
                Or gridD.CurrentCell.ColumnIndex = gridD.Columns("LotS2").Index _
                Or gridD.CurrentCell.ColumnIndex = gridD.Columns("LotE2").Index _
                Or gridD.CurrentCell.ColumnIndex = gridD.Columns("Bal2").Index _
                Or gridD.CurrentCell.ColumnIndex = gridD.Columns("MatQty2").Index Then
                'If the current cell is of the type "TextBox" 
                If TypeOf (e.Control) Is DataGridViewTextBoxEditingControl Then
                    'Cast the current cell to the temporary control  
                    txtQty = DirectCast(e.Control, DataGridViewTextBoxEditingControl)

                    If txtQty IsNot Nothing Then
                        'Add an EventHandler to the first temporary control  
                        AddHandler txtQty.KeyPress, AddressOf txtQty_KeyPress
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub gridD_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellEndEdit
        If chkLocked1.Checked = True And chkLocked2.Checked = True And Edit = False Then Exit Sub
        If IsView Then Exit Sub

        If cboJCode IsNot Nothing Then
            RemoveHandler cboJCode.Validating, AddressOf cboJCode_Validating
            cboJCode = Nothing
        End If

        If cbobox IsNot Nothing Then
            RemoveHandler cbobox.Validating, AddressOf cbobox_Validating
            cbobox = Nothing
        End If

        If cboPdCode IsNot Nothing Then
            RemoveHandler cboPdCode.Validating, AddressOf cboPdCode_Validating
            cboPdCode = Nothing
        End If

        If txtQty IsNot Nothing Then
            RemoveHandler txtQty.KeyPress, AddressOf txtQty_KeyPress
            txtQty = Nothing
        End If
    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If IsView Then Exit Sub

        Dim lockTime As New PCM_LockDay
        lockTime.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
        nvd.GetObject(lockTime)

        If chkLocked1.Checked <> lockTime.TrayLocked1 Then
            chkLocked1.Checked = lockTime.TrayLocked1
        End If
        If chkLocked2.Checked <> lockTime.TrayLocked2 Then
            chkLocked2.Checked = lockTime.TrayLocked2
        End If

    End Sub

    Private Sub cboJCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If IsView Then Exit Sub

        Dim JCode As String = IIf(IsDBNull(cboJCode.SelectedValue), "", cboJCode.SelectedValue)
        Dim SubPrcName As String = Trim(gridD.CurrentRow.Cells("SubPrcName").FormattedValue.ToString)
        Dim PdCode As String = Trim(gridD.CurrentRow.Cells("PdCode").FormattedValue.ToString)

        Dim JCodeTemp As String = Trim(gridD.CurrentRow.Cells("JCodeTemp").FormattedValue.ToString)
        Dim SubPrcNameTemp As String = Trim(gridD.CurrentRow.Cells("SubPrcNameTemp").FormattedValue.ToString)
        Dim PdCodeTemp As String = Trim(gridD.CurrentRow.Cells("PdCodeTemp").FormattedValue.ToString)

        If JCode = JCodeTemp And SubPrcName = SubPrcNameTemp And PdCode = PdCodeTemp Then Exit Sub

        If JCodeTemp <> "" Then
            Dim lockTime As New PCM_LockDay
            lockTime.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
            nvd.GetObject(lockTime)

            If lockTime.TrayLocked1 And cls.checkUser = False Then
                MessageBox.Show("Time 1 is Locked", "Lock")
                gridD.CurrentRow.Cells("JCode").Value = JCodeTemp
                cboJCode.SelectedValue = JCodeTemp
                gridD.CurrentRow.Cells("SubPrcName").Value = SubPrcNameTemp
                gridD.CurrentRow.Cells("PdCode").Value = PdCodeTemp
                Exit Sub
            End If

            If JCode = "" Then
                gridD.CurrentRow.Cells("JCode").Value = JCodeTemp
                cboJCode.SelectedValue = JCodeTemp
                Exit Sub
            End If

            If stock(JCode) = 0 Then
                tsStock.Text = 0
                tsInsStockD.Text = 0
                tsNonInsStockD.Text = 0
                cboJCode.SelectedValue = JCodeTemp
                gridD.CurrentCell.Value = JCodeTemp
                MessageBox.Show("Stock = 0.", "Stock")
                Exit Sub
            Else
                tsStock.Text = stock(JCode)
                tsInsStockD.Text = avalQty
                tsNonInsStockD.Text = heldQty
            End If

        Else
            If stock(JCode) = 0 Then
                tsStock.Text = 0
                tsInsStockD.Text = 0
                tsNonInsStockD.Text = 0
                cboJCode.SelectedValue = DBNull.Value
                gridD.CurrentCell.Value = DBNull.Value
                MessageBox.Show("Stock = 0.", "Stock")
                Exit Sub
            Else
                tsStock.Text = stock(JCode)
                tsInsStockD.Text = avalQty
                tsNonInsStockD.Text = heldQty
            End If
        End If

        Dim sql As String = String.Format("select JCode, JEName, JVName " +
                                        "from {0} where JCode = '{1}'", PublicTable.Table_PCM_MterTrayU00, JCode)
        Dim dt As DataTable = nvd.FillDataTable(sql)
        If dt.Rows.Count <> 0 Then
            gridD.CurrentRow.Cells("JEName").Value = dt.Rows(0).Item("JEName")
            gridD.CurrentRow.Cells("JVName").Value = dt.Rows(0).Item("JVName")
        End If

        gridD.CurrentRow.Cells("JCode").Value = JCode
    End Sub

    Private Sub cbobox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If IsView Then Exit Sub

        Dim JCode As String = Trim(gridD.CurrentRow.Cells("JCode").FormattedValue.ToString)
        Dim SubPrcName As String = IIf(IsDBNull(cbobox.SelectedValue), "", cbobox.SelectedValue)
        Dim PdCode As String = Trim(gridD.CurrentRow.Cells("PdCode").FormattedValue.ToString)

        Dim JCodeTemp As String = Trim(gridD.CurrentRow.Cells("JCodeTemp").FormattedValue.ToString)
        Dim SubPrcNameTemp As String = Trim(gridD.CurrentRow.Cells("SubPrcNameTemp").FormattedValue.ToString)
        Dim PdCodeTemp As String = Trim(gridD.CurrentRow.Cells("PdCodeTemp").FormattedValue.ToString)

        If JCode = JCodeTemp And SubPrcName = SubPrcNameTemp And PdCode = PdCodeTemp Then Exit Sub

        If JCodeTemp <> "" Then
            Dim lockTime As New PCM_LockDay
            lockTime.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
            nvd.GetObject(lockTime)

            If lockTime.TrayLocked1 And cls.checkUser = False Then
                MessageBox.Show("Time 1 is Locked", "Lock")
                gridD.CurrentRow.Cells("JCode").Value = JCodeTemp
                gridD.CurrentRow.Cells("SubPrcName").Value = SubPrcNameTemp
                cbobox.SelectedValue = SubPrcNameTemp
                gridD.CurrentRow.Cells("PdCode").Value = PdCodeTemp
                Exit Sub
            End If

            If SubPrcName = "" Then
                gridD.CurrentRow.Cells("SubPrcName").Value = SubPrcNameTemp
                cbobox.SelectedValue = SubPrcNameTemp
                Exit Sub
            End If
        End If

        gridD.CurrentRow.Cells("SubPrcName").Value = SubPrcName
    End Sub

    Private Sub cboPdCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If IsView Then Exit Sub

        Dim JCode As String = Trim(gridD.CurrentRow.Cells("JCode").FormattedValue.ToString)
        Dim SubPrcName As String = Trim(gridD.CurrentRow.Cells("SubPrcName").FormattedValue.ToString)
        Dim PdCode As String = IIf(IsDBNull(cboPdCode.SelectedValue), "", cboPdCode.SelectedValue)

        Dim JCodeTemp As String = Trim(gridD.CurrentRow.Cells("JCodeTemp").FormattedValue.ToString)
        Dim SubPrcNameTemp As String = Trim(gridD.CurrentRow.Cells("SubPrcNameTemp").FormattedValue.ToString)
        Dim PdCodeTemp As String = Trim(gridD.CurrentRow.Cells("PdCodeTemp").FormattedValue.ToString)

        If JCode = JCodeTemp And SubPrcName = SubPrcNameTemp And PdCode = PdCodeTemp Then Exit Sub

        If JCodeTemp <> "" Then
            Dim lockTime As New PCM_LockDay
            lockTime.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
            nvd.GetObject(lockTime)

            If lockTime.TrayLocked1 And cls.checkUser = False Then
                MessageBox.Show("Time 1 is Locked", "Lock")
                gridD.CurrentRow.Cells("JCode").Value = JCodeTemp
                gridD.CurrentRow.Cells("SubPrcName").Value = SubPrcNameTemp
                gridD.CurrentRow.Cells("PdCode").Value = PdCodeTemp
                cboPdCode.SelectedValue = PdCodeTemp
                Exit Sub
            End If

            If PdCode = "" Then
                gridD.CurrentRow.Cells("PdCode").Value = PdCodeTemp
                cboPdCode.SelectedValue = PdCodeTemp
                Exit Sub
            End If
        End If

        For i As Integer = 0 To gridD.Rows.Count - 2
            If gridD.CurrentRow.Index <> gridD.Rows(i).Index AndAlso
                JCode = Trim(gridD.Rows(i).Cells("JCode").FormattedValue.ToString()) AndAlso
                SubPrcName = Trim(gridD.Rows(i).Cells("SubPrcName").FormattedValue.ToString()) AndAlso
                PdCode = Trim(gridD.Rows(i).Cells("PdCode").FormattedValue.ToString()) AndAlso
                gridD.Rows(i).Cells("ECode").Value = CurrUser() Then
                cboPdCode.SelectedValue = DBNull.Value
                gridD.CurrentCell.Value = DBNull.Value
                MessageBox.Show("JCode is the same", "Check JCode")
                Exit Sub
            End If
        Next
        Dim sql As String = String.Format("select A.ECode, A.JCode, A.PdCode, A.PrcName, A.SubPrcName, A.UnitLot, A.Unit, A.MinQty, B.DeptName " +
                                        "from {0} A " +
                                        "left join PCM_Dept B on A.ECode = B.ECode and A.SubPrcName = B.SubPrcName " +
                                        "where A.ECode = '{1}' and A.JCode = '{2}' and A.SubPrcName = '{3}' and A.PdCode = '{4}'", PublicTable.Table_PCM_MterTrayU00, CurrUser, JCode, SubPrcName, PdCode)
        Dim dt As DataTable = nvd.FillDataTable(sql)
        If dt.Rows.Count <> 0 Then
            gridD.CurrentRow.Cells("YMD").Value = dtpOrderDate.Value.ToString("yyyyMMdd")
            gridD.CurrentRow.Cells("ECode").Value = CurrUser()
            gridD.CurrentRow.Cells("DeptName").Value = dt.Rows(0).Item("DeptName")
            gridD.CurrentRow.Cells("PrcName").Value = dt.Rows(0).Item("PrcName")
            gridD.CurrentRow.Cells("UnitLot").Value = dt.Rows(0).Item("UnitLot")
            gridD.CurrentRow.Cells("Unit").Value = dt.Rows(0).Item("Unit")
            gridD.CurrentRow.Cells("MinQty").Value = dt.Rows(0).Item("MinQty")

            Dim day As String = dtpOrderDate.Value.ToString("yyyyMMdd")
            Dim param(3) As SqlClient.SqlParameter
            Dim M1 As DateTime = New DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, DateTime.Now.AddMonths(-1).Day)
            Dim M3 As DateTime = New DateTime(DateTime.Now.AddMonths(-3).Year, DateTime.Now.AddMonths(-3).Month, DateTime.Now.AddMonths(-3).Day)
            Dim Day1 As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            Dim DayNow As DateTime = DateTime.Now
            param(0) = New SqlClient.SqlParameter("@M1", M1.ToString("yyyyMM"))
            param(1) = New SqlClient.SqlParameter("@M3", M3.ToString("yyyyMM"))
            param(2) = New SqlClient.SqlParameter("@Day1", Day1.ToString("yyyyMMdd"))
            param(3) = New SqlClient.SqlParameter("@DayNow", DayNow.ToString("yyyyMMdd"))

            Dim sql3M As String = String.Format("select JCode, PdCode, round((sum(MatQty1) + sum(MatQty2))/ 3, 2) as AVGUsing " +
            "from {0} " +
            "where left(YMD,6) between @M3 and @M1 and JCode = '{1}' and PdCode = '{2}' " +
            "Group by JCode, PdCode", PublicTable.Table_PCM_TrayU00, JCode, PdCode)
            Dim dt3M As DataTable = nvd.FillDataTable(sql3M, param)
            If dt3M.Rows.Count <> 0 Then
                gridD.CurrentRow.Cells("AVGUsing").Value = dt3M.Rows(0).Item("AVGUsing")
            End If

            Dim sql0131 As String = String.Format("select JCode, PdCode, round((sum(MatQty1) + sum(MatQty2)), 2) as Total0131 " +
            "from {0} " +
            "where YMD between @Day1 and @DayNow and JCode = '{1}' and PdCode = '{2}' " +
            "Group by JCode, PdCode", PublicTable.Table_PCM_TrayU00, JCode, PdCode)
            Dim dt0131 As DataTable = nvd.FillDataTable(sql0131, param)
            If dt0131.Rows.Count <> 0 Then
                gridD.CurrentRow.Cells("Total0131").Value = dt0131.Rows(0).Item("Total0131")
            End If

            Dim sqlGSR As String = String.Format("select (Quantity - ReceivedQty) as Qty, DeliveryDate from {0} " +
                                                 "where JCode = '{1}' and (Quantity - ReceivedQty) > 0", PublicTable.Table_GSR_GoodsOrderDetail, JCode)
            Dim dtGSR As DataTable = nvd.FillDataTable(sqlGSR)
            If dtGSR.Rows.Count = 0 Then
                gridD.CurrentRow.Cells("RequestQty").Value = 0
                gridD.CurrentRow.Cells("RequestDate").Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            Else
                gridD.CurrentRow.Cells("RequestQty").Value = dtGSR.Rows(dtGSR.Rows.Count - 1).Item("Qty")
                gridD.CurrentRow.Cells("RequestDate").Value = dtGSR.Rows(dtGSR.Rows.Count - 1).Item("DeliveryDate")
            End If

            Dim obj As New PCM_TrayU00()
            obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
            obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
            obj.JCode_K = JCodeTemp
            obj.SubPrcName_K = SubPrcNameTemp
            obj.PdCode_K = PdCodeTemp
            nvd.GetObject(obj)


            obj.DeptName = IIf(gridD.CurrentRow.Cells("DeptName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("DeptName").Value)
            obj.PrcName = IIf(gridD.CurrentRow.Cells("PrcName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("PrcName").Value)
            obj.JEName = IIf(gridD.CurrentRow.Cells("JEName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("JEName").Value)
            obj.JVName = IIf(gridD.CurrentRow.Cells("JVName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("JVName").Value)
            obj.UnitLot = IIf(gridD.CurrentRow.Cells("UnitLot").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("UnitLot").Value)
            obj.Unit = IIf(gridD.CurrentRow.Cells("Unit").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("Unit").Value)
            obj.MinQty = IIf(gridD.CurrentRow.Cells("MinQty").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("MinQty").Value)
            obj.RequestQty = IIf(gridD.CurrentRow.Cells("RequestQty").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("RequestQty").Value)
            obj.RequestDate = IIf(gridD.CurrentRow.Cells("RequestDate").Value Is DBNull.Value, DateTime.Now, gridD.CurrentRow.Cells("RequestDate").Value)
            obj.LotS1 = IIf(gridD.CurrentRow.Cells("LotS1").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("LotS1").Value)

            If nvd.ExistObject(obj) Then
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = JCode
                obj.SubPrcName_K = SubPrcName
                obj.PdCode_K = PdCode
                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now

                nvd.Update(obj, String.Format("YMD = '{0}' and ECode = '{1}' and JCode = '{2}' and SubPrcName = '{3}' and PdCode = '{4}'",
                                              Trim(gridD.CurrentRow.Cells("YMD").FormattedValue.ToString),
                                              Trim(gridD.CurrentRow.Cells("ECode").FormattedValue.ToString),
                                              JCodeTemp, SubPrcNameTemp, PdCodeTemp))
                gridD.CurrentRow.Cells("JCodeTemp").Value = JCode
                gridD.CurrentRow.Cells("SubPrcNameTemp").Value = SubPrcName
                gridD.CurrentRow.Cells("PdCodeTemp").Value = PdCode
            Else
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = JCode
                obj.SubPrcName_K = SubPrcName
                obj.PdCode_K = PdCode
                obj.CreateUser = CurrentUser.UserID
                obj.CreateDate = DateTime.Now
                obj.Lock1 = chkLocked1.Checked
                obj.Lock2 = chkLocked2.Checked
                obj.PCNo = Environment.MachineName

                nvd.Insert(obj)
                gridD.CurrentRow.Cells("JCodeTemp").Value = JCode
                gridD.CurrentRow.Cells("SubPrcNameTemp").Value = SubPrcName
                gridD.CurrentRow.Cells("PdCodeTemp").Value = PdCode

                gridD.CurrentRow.Cells("PdCode").Value = PdCode
            End If

            'Tu dong nhay S1

            Dim objLock As New PCM_LockDay
            objLock.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
            nvd.GetObject(objLock)

            Dim _LastLot = LastLot(obj.JCode_K, obj.SubPrcName_K, obj.PdCode_K)


            If Edit = False Then
                If objLock.TrayLocked1 = False Then
                    gridD.CurrentRow.Cells("LotS1").Value = _LastLot + 1
                    obj.LotS1 = _LastLot + 1
                    nvd.Update(obj)
                End If
                If objLock.TrayLocked1 And objLock.TrayLocked2 = False Then
                    gridD.CurrentRow.Cells("LotS2").Value = _LastLot + 1
                    obj.LotS2 = _LastLot + 1
                    nvd.Update(obj)
                End If
            Else
                gridD.CurrentRow.Cells("LotS1").Value = _LastLot + 1
                obj.LotS1 = _LastLot + 1
                nvd.Update(obj)
            End If


        End If
    End Sub

    Function LastLot(JCode As String, SubPrcName As String, PdCode As String) As Integer
        Dim sql As String = String.Format("Select top 2 LotE1, LotE2, AdjustLot from {0} " +
            "where JCode = '{1}' and PdCode = '{2}' order by YMD desc",
            PublicTable.Table_PCM_TrayU00, JCode, PdCode)
        Dim dt As DataTable = nvd.FillDataTable(sql)

        Dim _LastLot As Integer
        If dt.Rows.Count = 2 Then
            Dim _LastEndLot As Integer = IIf(dt.Rows(1).Item("LotE1") < dt.Rows(1).Item("LotE2"), dt.Rows(1).Item("LotE2"), dt.Rows(1).Item("LotE1"))
            _LastLot = IIf(dt.Rows(1).Item("AdjustLot") <> 0, dt.Rows(1).Item("AdjustLot"), _LastEndLot)
        Else
            _LastLot = 0
        End If
        Return _LastLot
    End Function

    Private Sub dtpOrderDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpOrderDate.ValueChanged
        'If dtpOrderDate.Value > DateTime.Now Then
        '    MessageBox.Show("Date > Current Date", "Date")
        '    dtpOrderDate.Value = DateTime.Now
        '    Exit Sub
        'Else
        mnuShowAll.PerformClick()
        'End If
    End Sub

    Function stock(ByVal JCode As String) As Decimal
        If JCode.Length = 6 Then
            Dim sql As String = String.Format("select Qty, HeldQty from {0} where JCode = '{1}'", PublicTable.Table_PCM_Stock, JCode)
            Dim dt As DataTable = nvd.FillDataTable(sql)
            If dt.Rows.Count = 0 Then
                Dim para(0) As SqlClient.SqlParameter
                para(0) = New SqlClient.SqlParameter("@Date", GetStartDate(DateTime.Now.AddDays(-1)))
                sql = String.Format("select [GoodQty] as Qty, [HeldQty] from {0} where JCode = '{1}' and [EntryDate]=@Date",
                                    PublicTable.Table_LOS_StockDaily, JCode)
                dt = nvd.FillDataTable(sql, para)
            End If
            If dt.Rows.Count = 0 Then
                Return 0
            Else
                avalQty = dt.Rows(0).Item("Qty")
                heldQty = dt.Rows(0).Item("HeldQty")
                Return dt.Rows(0).Item("Qty") + dt.Rows(0).Item("HeldQty")
            End If
        End If
        Return 0
    End Function

    Function sumOut(ByVal YMD As String, ByVal ECode As String, ByVal PdCode As String, ByVal JCode As String, ByVal SubPrcName As String) As Decimal
        Dim strKey As String = YMD & ECode & PdCode & JCode & SubPrcName
        Dim sql As String = String.Format("select ID = YMD +ECode+PdCode+JCode+SubPrcName, MatQty1, MatQty2, AdjustQty " +
        "into #T " +
        "from {0} where YMD = '{1}' and JCode = '{2}' " +
        "select MatQty1, MatQty2, AdjustQty from #T  T where T.ID NOT IN ('{3}')",
        PublicTable.Table_PCM_TrayU00, YMD, JCode, strKey)
        Dim dt As DataTable = nvd.FillDataTable(sql)
        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Compute("Sum(MatQty1)", "") + dt.Compute("Sum(MatQty2)", "") + dt.Compute("Sum(AdjustQty)", "")
        End If
    End Function

    Private Sub gridD_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles gridD.DataError
        If chkLocked1.Checked = True And chkLocked2.Checked = True Then Exit Sub

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

        If e.ColumnIndex = gridD.Columns("JCode").Index Then
            cboJCode.SelectedValue = DBNull.Value
        End If

        If e.ColumnIndex = gridD.Columns("SubPrcName").Index Then
            cbobox.SelectedValue = DBNull.Value
        End If

        If e.ColumnIndex = gridD.Columns("PdCode").Index Then
            cboPdCode.SelectedValue = DBNull.Value
        End If
    End Sub

    Private Sub FrmOutTrayAndU00_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If cls.checkUser() And cls.checkUserIsView = False Then
            chkLocked1.Enabled = True
            chkLocked2.Enabled = True
            gridD.Columns("ECode").Visible = True
            gridD.Columns("AdjustLot").Visible = True
            gridD.Columns("AdjustQty").Visible = True
            gridD.Columns("ActReceive").Visible = True
            gridD.Columns("AVGUsing").Visible = True
            gridD.Columns("Total0131").Visible = True
            gridD.Columns("MatQty1").ReadOnly = False
            gridD.Columns("MatQty2").ReadOnly = False
            gridD.Columns("DeptName").Visible = True
            lblFilterECode.Visible = True
            cboECodeFilter.Visible = True
        ElseIf cls.checkUser() And cls.checkUserIsView Then
            gridD.Columns("ECode").Visible = True
            gridD.Columns("AdjustLot").Visible = True
            gridD.Columns("AdjustQty").Visible = True
            gridD.Columns("ActReceive").Visible = True
            gridD.Columns("AVGUsing").Visible = True
            gridD.Columns("Total0131").Visible = True
            gridD.Columns("DeptName").Visible = True
            lblFilterECode.Visible = True
            cboECodeFilter.Visible = True

            gridD.ReadOnly = True
            IsView = True
        End If

        mnuShowAll.PerformClick()

        gridD.Columns("AVGUsing").DefaultCellStyle.BackColor = Drawing.Color.Gold
        gridD.Columns("AVGUsing").HeaderCell.Style.BackColor = Drawing.Color.Gold

        gridD.Columns("Total0131").DefaultCellStyle.BackColor = Drawing.Color.LightPink
        gridD.Columns("Total0131").HeaderCell.Style.BackColor = Drawing.Color.LightPink

        gridD.Columns("LotS1").DefaultCellStyle.BackColor = Drawing.Color.LightCyan
        gridD.Columns("LotS1").HeaderCell.Style.BackColor = Drawing.Color.LightCyan

        gridD.Columns("LotE1").DefaultCellStyle.BackColor = Drawing.Color.Plum
        gridD.Columns("LotE1").HeaderCell.Style.BackColor = Drawing.Color.Plum

        gridD.Columns("MatQty1").DefaultCellStyle.BackColor = Drawing.Color.LightGreen
        gridD.Columns("MatQty1").HeaderCell.Style.BackColor = Drawing.Color.LightGreen

        gridD.Columns("LotS2").DefaultCellStyle.BackColor = Drawing.Color.LightCyan
        gridD.Columns("LotS2").HeaderCell.Style.BackColor = Drawing.Color.LightCyan

        gridD.Columns("LotE2").DefaultCellStyle.BackColor = Drawing.Color.Plum
        gridD.Columns("LotE2").HeaderCell.Style.BackColor = Drawing.Color.Plum

        gridD.Columns("MatQty2").DefaultCellStyle.BackColor = Drawing.Color.LightGreen
        gridD.Columns("MatQty2").HeaderCell.Style.BackColor = Drawing.Color.LightGreen

        gridD.Columns("AdjustQty").DefaultCellStyle.BackColor = Drawing.Color.DeepSkyBlue
        gridD.Columns("AdjustQty").HeaderCell.Style.BackColor = Drawing.Color.DeepSkyBlue

        gridD.Columns("TotalQty").DefaultCellStyle.BackColor = Drawing.Color.LightSalmon
        gridD.Columns("TotalQty").HeaderCell.Style.BackColor = Drawing.Color.LightSalmon
    End Sub

    Sub LockColums(ByVal lock As Boolean)
        gridD.Columns("JCode").ReadOnly = Not lock
        gridD.Columns("SubPrcName").ReadOnly = Not lock
        gridD.Columns("PdCode").ReadOnly = Not lock
        gridD.Columns("ECode").ReadOnly = Not lock
    End Sub

    Private Sub chkLocked1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLocked1.CheckedChanged
        If lock = 0 Then Exit Sub

        If cls.checkImportStock() Then
            If MessageBox.Show("Bạn chưa Import tồn hôm nay. Bạn có muốn tiếp tục", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                mnuShowAll.PerformClick()
                Exit Sub
            End If
        End If

        Dim lockTray As New PCM_LockDay
        lockTray.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")

        If nvd.ExistObject(lockTray) Then
            nvd.GetObject(lockTray)
            lockTray.TrayLocked1 = chkLocked1.Checked
            nvd.Update(lockTray)
        Else
            lockTray.TrayLocked1 = chkLocked1.Checked
            nvd.Insert(lockTray)
        End If

        If chkLocked1.Checked Then
            nvd.GetObject(lockTray)

            If cls.checkUser() Then
                lockTray.UserTray1 = CurrentUser.UserID
                lockTray.DateTray1 = DateTime.Now
            End If

            nvd.Update(lockTray)

            gridD.Columns("LotS1").ReadOnly = True
            gridD.Columns("LotE1").ReadOnly = True
            gridD.Columns("Bal1").ReadOnly = True
            gridD.Columns("MatQty1").ReadOnly = True
            If chkLocked1.Checked = True And chkLocked2.Checked = True Then
                LockColums(False)
            End If
            MessageBox.Show("Time 1 is locked", "Lock")
        Else
            nvd.GetObject(lockTray)

            If cls.checkUser() Then
                lockTray.UserUnlockTray1 = CurrentUser.UserID
                lockTray.DateUnlockTray1 = DateTime.Now
            End If

            nvd.Update(lockTray)

            gridD.Columns("LotS1").ReadOnly = False
            gridD.Columns("LotE1").ReadOnly = False
            gridD.Columns("Bal1").ReadOnly = False
            If cls.checkUser() Then
                gridD.Columns("MatQty1").ReadOnly = False
            Else
                gridD.Columns("MatQty1").ReadOnly = True
            End If

            LockColums(True)
            MessageBox.Show("Time 1 is unlocked", "Lock")
        End If
    End Sub

    Private Sub chkLocked2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLocked2.CheckedChanged
        If lock = 0 Then Exit Sub

        If cls.checkImportStock() Then
            If MessageBox.Show("Bạn chưa Import tồn hôm nay. Bạn có muốn tiếp tục", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                mnuShowAll.PerformClick()
                Exit Sub
            End If
        End If

        Dim lockTray As New PCM_LockDay
        lockTray.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")

        If nvd.ExistObject(lockTray) Then
            nvd.GetObject(lockTray)
            lockTray.TrayLocked2 = chkLocked2.Checked
            nvd.Update(lockTray)
        Else
            lockTray.TrayLocked2 = chkLocked2.Checked
            nvd.Insert(lockTray)
        End If

        If chkLocked2.Checked Then
            nvd.GetObject(lockTray)

            If cls.checkUser() Then
                lockTray.UserTray2 = CurrentUser.UserID
                lockTray.DateTray2 = DateTime.Now
            End If

            nvd.Update(lockTray)

            gridD.Columns("LotS2").ReadOnly = True
            gridD.Columns("LotE2").ReadOnly = True
            gridD.Columns("Bal2").ReadOnly = True
            gridD.Columns("MatQty2").ReadOnly = True
            If chkLocked1.Checked = True And chkLocked2.Checked = True Then
                LockColums(False)
            End If
            MessageBox.Show("Time 2 is locked", "Lock")
        Else
            nvd.GetObject(lockTray)

            If cls.checkUser() Then
                lockTray.UserUnlockTray2 = CurrentUser.UserID
                lockTray.DateUnlockTray2 = DateTime.Now
            End If

            nvd.Update(lockTray)

            gridD.Columns("LotS2").ReadOnly = False
            gridD.Columns("LotE2").ReadOnly = False
            gridD.Columns("Bal2").ReadOnly = False
            If cls.checkUser() Then
                gridD.Columns("MatQty2").ReadOnly = False
            Else
                gridD.Columns("MatQty2").ReadOnly = True
            End If
            LockColums(True)
            MessageBox.Show("Time 2 is unlocked", "Lock")
        End If
    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        Dim sql As String = String.Format("select YMD, DeptName, ECode, JCode, PrcName, PdCode, JEName, JVName, Unit, UnitLot, LotS1, LotE1, MatQty1, LotS2, LotE2, MatQty2, Note " +
        "from {0} " +
        "where YMD = '{1}' and ECode like '%{2}%'" +
        "order by ECode, JCode", PublicTable.Table_PCM_TrayU00, dtpOrderDate.Value.ToString("yyyyMMdd"), condiUser)
        ExportEXCEL(nvd.FillDataTable(sql))
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
                    If cboJCode IsNot Nothing Then
                        RemoveHandler cboJCode.Validating, AddressOf cboJCode_Validating
                        cboJCode = Nothing
                    End If

                    If cbobox IsNot Nothing Then
                        RemoveHandler cbobox.Validating, AddressOf cbobox_Validating
                        cbobox = Nothing
                    End If

                    If cboPdCode IsNot Nothing Then
                        RemoveHandler cboPdCode.Validating, AddressOf cboPdCode_Validating
                        cboPdCode = Nothing
                    End If
                    Dim obj As New PCM_TrayU00
                    obj.YMD_K = IIf(IsDBNull(datarow.Item(row).Cells("YMD").Value), "", datarow.Item(row).Cells("YMD").Value)
                    obj.JCode_K = IIf(IsDBNull(datarow.Item(row).Cells("JCode").Value), "", datarow.Item(row).Cells("JCode").Value)
                    obj.SubPrcName_K = IIf(IsDBNull(datarow.Item(row).Cells("SubPrcName").Value), "", datarow.Item(row).Cells("SubPrcName").Value)
                    obj.ECode_K = IIf(IsDBNull(datarow.Item(row).Cells("ECode").Value), "", datarow.Item(row).Cells("ECode").Value)
                    obj.PdCode_K = IIf(IsDBNull(datarow.Item(row).Cells("PdCode").Value), "", datarow.Item(row).Cells("PdCode").Value)
                    If nvd.ExistObject(obj) Then
                        nvd.GetObject(obj)
                        Dim objLock As New PCM_LockDay
                        objLock.YMD_K = obj.YMD_K
                        nvd.GetObject(objLock)
                        If objLock.TrayLocked1 = True And cls.checkUser = False Then
                            MessageBox.Show("Locked", "Delete")
                            nvd.RollBack()
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

    Private Sub gridD_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellEnter
        If IsView Then Exit Sub

        Dim lockTime As New PCM_LockDay
        lockTime.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
        nvd.GetObject(lockTime)

        If chkLocked1.Checked <> lockTime.TrayLocked1 Then
            chkLocked1.Checked = lockTime.TrayLocked1
        End If
        If chkLocked2.Checked <> lockTime.TrayLocked2 Then
            chkLocked2.Checked = lockTime.TrayLocked2
        End If

        If chkLocked1.Checked = True And chkLocked2.Checked = True And Edit = False Then Exit Sub
        If lock = 0 Then Exit Sub
        If gridD.CurrentRow.Cells(e.ColumnIndex).[ReadOnly] Then
            SendKeys.Send("{Tab}")
            If e.ColumnIndex = gridD.Columns("JCode").Index Then
                PanelSearch.Visible = True
            End If
        End If

        Try
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Cell enter")
        End Try
    End Sub

    Private Sub gridD_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridD.CellValidating

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

    Private Sub cboPdCodeFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPdCodeFilter.SelectedIndexChanged
        If lock = 0 Then Exit Sub
        If dtAll Is Nothing Then
            Return
        Else
            Dim dv As DataView = New DataView(dtAll)
            dv.RowFilter = "[PdCode] LIKE '%" + cboPdCodeFilter.SelectedValue + "%'"
            Dim bd As New BindingSource()
            bd.DataSource = dv
            gridD.DataSource = bd
            bnGrid.BindingSource = bd
        End If
    End Sub

    Private Sub cboECodeFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboECodeFilter.SelectedIndexChanged
        If lock = 0 Then Exit Sub
        If dtAll Is Nothing Then
            Return
        Else
            Dim dv As DataView = New DataView(dtAll)
            dv.RowFilter = "[ECode] LIKE '%" + cboECodeFilter.SelectedValue + "%'"
            Dim bd As New BindingSource()
            bd.DataSource = dv
            gridD.DataSource = bd
            bnGrid.BindingSource = bd
        End If
    End Sub

    Private Sub gridSearch_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridSearch.CellClick
        If IsView Then Exit Sub

        If gridD.CurrentRow Is Nothing Then Exit Sub
        If gridSearch Is Nothing Then Exit Sub

        If gridD.CurrentCell.ColumnIndex = gridD.Columns("JCode").Index Then

            If stock(gridSearch.CurrentRow.Cells("JCodeSearch").Value) = 0 Then
                MessageBox.Show("Stock = 0.", "Stock")
                Exit Sub
            Else
                gridD.CurrentCell.Value = gridSearch.CurrentRow.Cells("JCodeSearch").Value
                Dim sql As String = String.Format("select JCode, JEName, JVName " +
                                        "from {0} where JCode = '{1}'", PublicTable.Table_PCM_MterTrayU00, gridSearch.CurrentRow.Cells("JCodeSearch").Value)
                Dim dt As DataTable = nvd.FillDataTable(sql)
                If dt.Rows.Count <> 0 Then
                    gridD.CurrentRow.Cells("JEName").Value = dt.Rows(0).Item("JEName")
                    gridD.CurrentRow.Cells("JVName").Value = dt.Rows(0).Item("JVName")
                End If

                gridD.CurrentCell = gridD.Item(gridD.CurrentCell.ColumnIndex + 3, gridD.CurrentCell.RowIndex)
                tsStock.Text = stock(gridSearch.CurrentRow.Cells("JCodeSearch").Value)
                tsInsStockD.Text = avalQty
                tsNonInsStockD.Text = heldQty

            End If
            gridD.Focus()
        End If
    End Sub

    Private Sub txtJCodeSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJCodeSearch.TextChanged
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

    Private Sub txtJENameSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJENameSearch.TextChanged
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

    Private Sub txtJVNameSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJVNameSearch.TextChanged
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

    Private Sub gridD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridD.Click
        If gridD.CurrentRow Is Nothing Then Exit Sub
        Dim JCode As String = Trim(gridD.CurrentRow.Cells("JCode").FormattedValue.ToString)
        tsStock.Text = stock(JCode)
        tsInsStockD.Text = avalQty
        tsNonInsStockD.Text = heldQty
    End Sub

    Private Sub mnuCheckLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheckLot.Click
        If gridD.CurrentRow IsNot Nothing Then
            FrmCheckLotOld._ECode = gridD.CurrentRow.Cells("ECode").FormattedValue.ToString
            FrmCheckLotOld._JCode = gridD.CurrentRow.Cells("JCode").FormattedValue.ToString
            FrmCheckLotOld._PdCode = gridD.CurrentRow.Cells("PdCode").FormattedValue.ToString
            FrmCheckLotOld._SubPrcName = gridD.CurrentRow.Cells("SubPrcName").FormattedValue.ToString
        End If
        Dim frm As New FrmCheckLotOld()
        frm.Show()
    End Sub

    Private Sub gridD_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellLeave
        If IsView Then Exit Sub

        If e.ColumnIndex = gridD.Columns("JCode").Index Then
            PanelSearch.Visible = False
        End If
    End Sub

    Private Sub PanelSearch_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelSearch.Enter
        PanelSearch.Visible = True
    End Sub

    Private Sub PanelSearch_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelSearch.Leave
        PanelSearch.Visible = False
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
    '            If objlock.TrayLocked1 = False Or objlock.TrayLocked2 = False Then
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
    '            If objUpdate.OutTray = True Then
    '                MessageBox.Show("Already exists", "Insert StockWS")
    '            Else
    '                cls.InsertStock(dtpOrderDate.Value.ToString("yyyyMMdd"), "OutTray")
    '                objUpdate.OutTray = True
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
    '            cls.InsertStock(dtpOrderDate.Value.ToString("yyyyMMdd"), "OutTray")
    '            objUpdate.OutTray = True
    '            nvd.Update(objUpdate)
    '            MessageBox.Show("Insert successful", "Insert StockWS")
    '            mnuInsertStock.Enabled = False
    '        End If
    '        nvd.Commit()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Insert OutTray")
    '        nvd.RollBack()
    '    End Try
    'End Sub

    Private Sub mnuEdit_Click(sender As System.Object, e As System.EventArgs) Handles mnuEdit.Click
        If cls.checkUser Then
            Edit = True
            gridD.Columns("ECode").ReadOnly = False
            gridD.Columns("JCode").ReadOnly = False
            gridD.Columns("SubPrcName").ReadOnly = False
            gridD.Columns("PdCode").ReadOnly = False
            gridD.Columns("LotS1").ReadOnly = False
            gridD.Columns("LotE1").ReadOnly = False
            gridD.Columns("Bal1").ReadOnly = False
            gridD.Columns("MatQty1").ReadOnly = False
            gridD.Columns("LotS2").ReadOnly = False
            gridD.Columns("LotE2").ReadOnly = False
            gridD.Columns("Bal2").ReadOnly = False
            gridD.Columns("MatQty2").ReadOnly = False
            gridD.Columns("Note").ReadOnly = False
            gridD.Columns("AdjustLot").ReadOnly = False
            gridD.Columns("AdjustQty").ReadOnly = False
        End If
    End Sub

    Private Sub mnuExportSum_Click(sender As System.Object, e As System.EventArgs) Handles mnuExportSum.Click
        Dim sfDlg As New SaveFileDialog()
        sfDlg.Filter = "Excel 2007|*.xlsx|Excel 2003|*.xls"
        sfDlg.FileName = String.Format("Số lượng xuất kho lần 1 ({0})- Khay và miếng tăng cứng.xlsx",
                                               DateTime.Now.ToString("dd.MM.yyyy"))
        sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\1.Xuat kho Nippon\XUAT KHO {0}\XKHO NL T{1} \Lần 1\",
                                               DateTime.Now.Year,
                                               DateTime.Now.ToString("MM.yyyy"))

        If sfDlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        Dim sql As String = String.Format(" select YMD, DeptName, JCode, PrcName, JEName, JVName, Unit," +
                                          " Sum(MatQty1) MatQty1, Sum(MatQty2) MatQty2, Note = ISNULL(Note,'') " +
                                            "from {0} " +
                                            "where YMD = '{1}' and ECode like '%{2}%'" +
                                            "group by YMD, DeptName, JCode, PrcName, JEName, JVName, Unit, ISNULL(Note,'') " +
                                            "order by DeptName, PrcName, JCode",
                                            PublicTable.Table_PCM_TrayU00,
                                            dtpOrderDate.Value.ToString("yyyyMMdd"),
                                            condiUser)
        ExportEXCEL(nvd.FillDataTable(sql), sfDlg.FileName)
    End Sub

    Private Sub gridD_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellValueChanged
        If IsView Then Exit Sub
        If e.RowIndex = -1 Then Return
        Try
            Dim lockTime As New PCM_LockDay
            lockTime.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
            nvd.GetObject(lockTime)

            If chkLocked1.Checked <> lockTime.TrayLocked1 Then
                chkLocked1.Checked = lockTime.TrayLocked1
            End If
            If chkLocked2.Checked <> lockTime.TrayLocked2 Then
                chkLocked2.Checked = lockTime.TrayLocked2
            End If

            If chkLocked1.Checked = True And chkLocked2.Checked = True And Edit = False Then Exit Sub

            If e.ColumnIndex = gridD.Columns("JCode").Index _
            Or e.ColumnIndex = gridD.Columns("SubPrcName").Index _
            Or e.ColumnIndex = gridD.Columns("ECode").Index _
            Or e.ColumnIndex = gridD.Columns("PdCode").Index Then
                Exit Sub
            End If

            If gridD.CurrentRow.Cells(e.ColumnIndex).[ReadOnly] Then Exit Sub

            If e.ColumnIndex = gridD.Columns("LotS1").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("PdCode").Value) Then
                    ShowWarning("Bạn chưa nhập SubPrcName & PdCode")
                    Exit Sub
                End If
                Dim _LotS1 As Integer
                If gridD.CurrentRow.Cells("LotS1").Value Is DBNull.Value Then
                    _LotS1 = 0
                Else
                    _LotS1 = gridD.CurrentRow.Cells("LotS1").Value
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_TrayU00()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                obj.PdCode_K = gridD.CurrentRow.Cells("PdCode").Value
                nvd.GetObject(obj)

                'Last Lot

                Dim _LastLot As Integer = LastLot(obj.JCode_K, obj.SubPrcName_K, obj.PdCode_K)
                If _LotS1 <> (_LastLot + 1) And (_LastLot + 1) <> 1 Then
                    MessageBox.Show("Input LotS1 = " & (_LastLot + 1), "LotS1")
                    Exit Sub
                End If

                obj.LotS1 = _LotS1

                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                nvd.Update(obj)
            End If

            If e.ColumnIndex = gridD.Columns("LotE1").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("PdCode").Value) Then
                    ShowWarning("Bạn chưa nhập pdCode, JCode, SubPrcName")
                    Exit Sub
                End If
                Dim _LotE1 As Integer
                If gridD.CurrentRow.Cells("LotE1").Value Is DBNull.Value Then
                    _LotE1 = 0
                Else
                    _LotE1 = gridD.CurrentRow.Cells("LotE1").Value
                End If
                Dim _LotS1 As Integer = IIf(IsDBNull(gridD.CurrentRow.Cells("LotS1").Value), 0, gridD.CurrentRow.Cells("LotS1").Value)
                Dim _UnitLot As Decimal = IIf(IsDBNull(gridD.CurrentRow.Cells("UnitLot").Value), 0, gridD.CurrentRow.Cells("UnitLot").Value)
                Dim _Bal1 As Decimal = IIf(IsDBNull(gridD.CurrentRow.Cells("Bal1").Value), 0, gridD.CurrentRow.Cells("Bal1").Value)
                Dim _LotS2 As Integer = IIf(IsDBNull(gridD.CurrentRow.Cells("LotS2").Value), 0, gridD.CurrentRow.Cells("LotS2").Value)

                If _LotE1 < _LotS1 And _LotE1 <> 0 Then
                    MessageBox.Show("Input LotE1 >= LotS1", "Input LostE1")
                    Exit Sub
                End If

                If _LotE1 >= _LotS2 And _LotS2 <> 0 Then
                    MessageBox.Show("Input LotE1 < LotS2", "Input LostE1")
                    Exit Sub
                End If

                Dim MatQty1 As Decimal
                If _LotS1 <> 0 Then
                    MatQty1 = IIf(((_LotE1 - _LotS1 + 1) * _UnitLot - _Bal1) < 0, 0, (_LotE1 - _LotS1 + 1) * _UnitLot - _Bal1)
                Else
                    MatQty1 = 0
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_TrayU00()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                obj.PdCode_K = gridD.CurrentRow.Cells("PdCode").Value
                nvd.GetObject(obj)
                obj.LotE1 = _LotE1
                obj.MatQty1 = MatQty1

                Dim MatQty2 = IIf(gridD.CurrentRow.Cells("MatQty2").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("MatQty2").Value)
                Dim AdjustQty = IIf(gridD.CurrentRow.Cells("AdjustQty").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("AdjustQty").Value)

                Dim stockRemain As Decimal = stock(obj.JCode_K) - sumOut(obj.YMD_K, obj.ECode_K, obj.PdCode_K, obj.JCode_K, obj.SubPrcName_K)

                If stockRemain < (obj.MatQty1 + MatQty2 + AdjustQty) Then
                    MessageBox.Show("StockRemain = " & stockRemain & " < MatQty1 + MatQty2 + AdjustQty = " & (obj.MatQty1 + MatQty2 + AdjustQty), "Input LotE1")
                    Exit Sub
                End If

                If avalQty < (obj.MatQty1 + MatQty2 + AdjustQty) Then
                    MessageBox.Show("Yêu cầu xuất kho bao gồm cả nguyên liệu chưa kiểm đầu vào, nếu kết quả kiểm đầu vào của nguyên liệu chưa kiểm đầu vào NG thì sẽ không đủ lượng xuất kho theo yêu cầu", "Input Qty")
                End If

                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                obj.Time1Date = DateTime.Now

                nvd.Update(obj)
                gridD.CurrentRow.Cells("MatQty1").Value = MatQty1
                gridD.CurrentRow.Cells("LotE1").Value = _LotE1
                gridD.CurrentRow.Cells("TotalQty").Value = obj.MatQty1 + MatQty2 + AdjustQty
            End If

            If e.ColumnIndex = gridD.Columns("Bal1").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("PdCode").Value) Then
                    MessageBox.Show("Input JCode, SubPrcName, PdCode", "Input Bal1")
                    Exit Sub
                End If
                Dim _Bal1 As Decimal
                If gridD.CurrentRow.Cells("Bal1").Value Is DBNull.Value Then
                    _Bal1 = 0
                Else
                    _Bal1 = gridD.CurrentRow.Cells("Bal1").Value
                End If
                Dim _LotS1 As Integer = IIf(IsDBNull(gridD.CurrentRow.Cells("LotS1").Value), 0, gridD.CurrentRow.Cells("LotS1").Value)
                Dim _LotE1 As Integer = IIf(IsDBNull(gridD.CurrentRow.Cells("LotE1").Value), 0, gridD.CurrentRow.Cells("LotE1").Value)
                Dim _UnitLot As Decimal = IIf(IsDBNull(gridD.CurrentRow.Cells("UnitLot").Value), 0, gridD.CurrentRow.Cells("UnitLot").Value)

                Dim MatQty1 As Decimal
                If _LotS1 <> 0 Then
                    MatQty1 = IIf(((_LotE1 - _LotS1 + 1) * _UnitLot - _Bal1) < 0, 0, (_LotE1 - _LotS1 + 1) * _UnitLot - _Bal1)
                Else
                    MatQty1 = 0
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_TrayU00()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                obj.PdCode_K = gridD.CurrentRow.Cells("PdCode").Value
                nvd.GetObject(obj)
                obj.Bal1 = _Bal1
                obj.MatQty1 = MatQty1

                Dim MatQty2 = IIf(gridD.CurrentRow.Cells("MatQty2").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("MatQty2").Value)
                Dim AdjustQty = IIf(gridD.CurrentRow.Cells("AdjustQty").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("AdjustQty").Value)

                Dim stockRemain As Decimal = stock(obj.JCode_K) - sumOut(obj.YMD_K, obj.ECode_K, obj.PdCode_K, obj.JCode_K, obj.SubPrcName_K)

                If stockRemain < (obj.MatQty1 + MatQty2 + AdjustQty) Then
                    MessageBox.Show("StockRemain = " & stockRemain & " < MatQty1 + MatQty2 + AdjustQty = " & (obj.MatQty1 + MatQty2 + AdjustQty), "Input Bal1")
                    Exit Sub
                End If

                If avalQty < (obj.MatQty1 + MatQty2 + AdjustQty) Then
                    MessageBox.Show("Yêu cầu xuất kho bao gồm cả nguyên liệu chưa kiểm đầu vào, nếu kết quả kiểm đầu vào của nguyên liệu chưa kiểm đầu vào NG thì sẽ không đủ lượng xuất kho theo yêu cầu", "Input Qty")
                End If

                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                nvd.Update(obj)
                gridD.CurrentRow.Cells("MatQty1").Value = MatQty1
                gridD.CurrentRow.Cells("Bal1").Value = _Bal1
                gridD.CurrentRow.Cells("TotalQty").Value = MatQty1 + MatQty2 + AdjustQty
            End If

            If e.ColumnIndex = gridD.Columns("MatQty1").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("PdCode").Value) Then
                    MessageBox.Show("Input JCode, SubPrcName, PdCode", "Input MatQty1")
                    Exit Sub
                End If
                Dim _MatQty1 As Decimal
                If gridD.CurrentRow.Cells("MatQty1").Value Is DBNull.Value Then
                    _MatQty1 = 0
                Else
                    _MatQty1 = gridD.CurrentRow.Cells("MatQty1").Value
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_TrayU00()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                obj.PdCode_K = gridD.CurrentRow.Cells("PdCode").Value
                nvd.GetObject(obj)
                obj.MatQty1 = _MatQty1

                Dim MatQty2 = IIf(gridD.CurrentRow.Cells("MatQty2").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("MatQty2").Value)
                Dim AdjustQty = IIf(gridD.CurrentRow.Cells("AdjustQty").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("AdjustQty").Value)

                Dim stockRemain As Decimal = stock(obj.JCode_K) - sumOut(obj.YMD_K, obj.ECode_K, obj.PdCode_K, obj.JCode_K, obj.SubPrcName_K)

                If stockRemain < (obj.MatQty1 + MatQty2 + AdjustQty) Then
                    MessageBox.Show("StockRemain = " & stockRemain & " < MatQty1 + MatQty2 + AdjustQty = " & (obj.MatQty1 + MatQty2 + AdjustQty), "Input LotE1")
                    Exit Sub
                End If

                If avalQty < (obj.MatQty1 + MatQty2 + AdjustQty) Then
                    MessageBox.Show("Yêu cầu xuất kho bao gồm cả nguyên liệu chưa kiểm đầu vào, nếu kết quả kiểm đầu vào của nguyên liệu chưa kiểm đầu vào NG thì sẽ không đủ lượng xuất kho theo yêu cầu", "Input Qty")
                End If

                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                nvd.Update(obj)
                gridD.CurrentRow.Cells("MatQty1").Value = _MatQty1
            End If

            If e.ColumnIndex = gridD.Columns("LotS2").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("PdCode").Value) Then
                    MessageBox.Show("Input JCode, SubPrcName, PdCode", "Input LotS2")
                    Exit Sub
                End If
                Dim _LotS2 As Integer
                If gridD.CurrentRow.Cells("LotS2").Value Is DBNull.Value Then
                    _LotS2 = 0
                Else
                    _LotS2 = gridD.CurrentRow.Cells("LotS2").Value
                End If

                Dim _LotS1 As Integer = IIf(IsDBNull(gridD.CurrentRow.Cells("LotS1").Value), 0, gridD.CurrentRow.Cells("LotS1").Value)
                Dim _LotE1 As Integer = IIf(IsDBNull(gridD.CurrentRow.Cells("LotE1").Value), 0, gridD.CurrentRow.Cells("LotE1").Value)

                If _LotS2 <> (_LotE1 + 1) And _LotS2 <> 0 And _LotE1 <> 0 Then
                    MessageBox.Show("Input LotS2 = (LotE1 + 1)", "Input LotS2")
                    Exit Sub
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_TrayU00()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                obj.PdCode_K = gridD.CurrentRow.Cells("PdCode").Value

                'Last Lot
                If _LotE1 = 0 Then
                    Dim _LastLot As Integer = LastLot(obj.JCode_K, obj.SubPrcName_K, obj.PdCode_K)
                    If _LotS2 <> (_LastLot + 1) And (_LastLot + 1) <> 1 And _LotS1 = 0 Then
                        MessageBox.Show("Input LotS2 = " & (_LastLot + 1), "LotS2")
                        Exit Sub
                    End If
                End If

                nvd.GetObject(obj)
                obj.LotS2 = _LotS2
                If _LotS2 = 0 Then
                    obj.LotE2 = 0
                    obj.MatQty2 = 0
                    gridD.CurrentRow.Cells("LotE2").Value = 0
                    gridD.CurrentRow.Cells("MatQty2").Value = 0
                End If

                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                nvd.Update(obj)
                gridD.CurrentRow.Cells("LotS2").Value = _LotS2
            End If

            If e.ColumnIndex = gridD.Columns("LotE2").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("PdCode").Value) Then
                    MessageBox.Show("Input JCode, SubPrcName, PdCode", "Input LotE2")
                    Exit Sub
                End If
                Dim _LotE2 As Integer
                If gridD.CurrentRow.Cells("LotE2").Value Is DBNull.Value Then
                    _LotE2 = 0
                Else
                    _LotE2 = gridD.CurrentRow.Cells("LotE2").Value
                End If
                Dim _LotS2 As Integer = IIf(IsDBNull(gridD.CurrentRow.Cells("LotS2").Value), 0, gridD.CurrentRow.Cells("LotS2").Value)
                Dim _UnitLot As Decimal = IIf(IsDBNull(gridD.CurrentRow.Cells("UnitLot").Value), 0, gridD.CurrentRow.Cells("UnitLot").Value)
                Dim _Bal2 As Decimal = IIf(IsDBNull(gridD.CurrentRow.Cells("Bal2").Value), 0, gridD.CurrentRow.Cells("Bal2").Value)
                If _LotE2 < _LotS2 And _LotE2 <> 0 Then
                    MessageBox.Show("Iput LotE2 >= LotS2", "Input LostE2")
                    Exit Sub
                End If

                If _LotE2 <> 0 And _LotS2 = 0 Then
                    MessageBox.Show("LotS2 = 0. LotE2 = 0, too", "Input LostE2")
                    Exit Sub
                End If

                Dim MatQty2 As Decimal
                If _LotS2 <> 0 Then
                    MatQty2 = IIf(((_LotE2 - _LotS2 + 1) * _UnitLot - _Bal2) < 0, 0, (_LotE2 - _LotS2 + 1) * _UnitLot - _Bal2)
                Else
                    MatQty2 = 0
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_TrayU00()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                obj.PdCode_K = gridD.CurrentRow.Cells("PdCode").Value
                nvd.GetObject(obj)
                obj.LotE2 = _LotE2
                obj.MatQty2 = MatQty2

                Dim MatQty1 = IIf(gridD.CurrentRow.Cells("MatQty1").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("MatQty1").Value)
                Dim AdjustQty = IIf(gridD.CurrentRow.Cells("AdjustQty").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("AdjustQty").Value)

                Dim stockRemain As Decimal = stock(obj.JCode_K) - sumOut(obj.YMD_K, obj.ECode_K, obj.PdCode_K, obj.JCode_K, obj.SubPrcName_K)

                If stockRemain < (MatQty1 + obj.MatQty2 + AdjustQty) Then
                    MessageBox.Show("StockRemain = " & stockRemain & " < MatQty1 + MatQty2 + AdjustQty = " & (MatQty1 + obj.MatQty2 + AdjustQty), "Input LotE2")
                    Exit Sub
                End If

                If avalQty < (MatQty1 + obj.MatQty2 + AdjustQty) Then
                    MessageBox.Show("Yêu cầu xuất kho bao gồm cả nguyên liệu chưa kiểm đầu vào, nếu kết quả kiểm đầu vào của nguyên liệu chưa kiểm đầu vào NG thì sẽ không đủ lượng xuất kho theo yêu cầu", "Input Qty")
                End If

                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                obj.Time2Date = DateTime.Now

                nvd.Update(obj)
                gridD.CurrentRow.Cells("MatQty2").Value = MatQty2
                gridD.CurrentRow.Cells("TotalQty").Value = MatQty1 + obj.MatQty2 + AdjustQty
            End If

            If e.ColumnIndex = gridD.Columns("Bal2").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("PdCode").Value) Then
                    MessageBox.Show("Input JCode, SubPrcName, PdCode", "Input Bal2")
                    Exit Sub
                End If
                Dim _Bal2 As Decimal
                If gridD.CurrentRow.Cells("Bal2").Value Is DBNull.Value Then
                    _Bal2 = 0
                Else
                    _Bal2 = gridD.CurrentRow.Cells("Bal2").Value
                End If
                Dim _LotS2 As Integer = IIf(IsDBNull(gridD.CurrentRow.Cells("LotS2").Value), 0, gridD.CurrentRow.Cells("LotS2").Value)
                Dim _LotE2 As Integer = IIf(IsDBNull(gridD.CurrentRow.Cells("LotE2").Value), 0, gridD.CurrentRow.Cells("LotE2").Value)
                Dim _UnitLot As Decimal = IIf(IsDBNull(gridD.CurrentRow.Cells("UnitLot").Value), 0, gridD.CurrentRow.Cells("UnitLot").Value)

                'If _LotE2 < _LotS2 And _LotE2 <> 0 Then
                '    MessageBox.Show("Iput LotE2 >= LotS2", "Input LostE2")
                '    e.Cancel = True
                '    Exit Sub
                'End If

                Dim MatQty2 As Decimal
                If _LotS2 <> 0 Then
                    MatQty2 = IIf(((_LotE2 - _LotS2 + 1) * _UnitLot - _Bal2) < 0, 0, (_LotE2 - _LotS2 + 1) * _UnitLot - _Bal2)
                Else
                    MatQty2 = 0
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_TrayU00()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                obj.PdCode_K = gridD.CurrentRow.Cells("PdCode").Value
                nvd.GetObject(obj)
                obj.Bal2 = _Bal2
                obj.MatQty2 = MatQty2

                Dim MatQty1 = IIf(gridD.CurrentRow.Cells("MatQty1").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("MatQty1").Value)
                Dim AdjustQty = IIf(gridD.CurrentRow.Cells("AdjustQty").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("AdjustQty").Value)

                Dim stockRemain As Decimal = stock(obj.JCode_K) - sumOut(obj.YMD_K, obj.ECode_K, obj.PdCode_K, obj.JCode_K, obj.SubPrcName_K)

                If stockRemain < (MatQty1 + obj.MatQty2 + AdjustQty) Then
                    MessageBox.Show("StockRemain = " & stockRemain & " < MatQty1 + MatQty2 + AdjustQty = " & (MatQty1 + obj.MatQty2 + AdjustQty), "Input Bal2")
                    Exit Sub
                End If

                If avalQty < (MatQty1 + obj.MatQty2 + AdjustQty) Then
                    MessageBox.Show("Yêu cầu xuất kho bao gồm cả nguyên liệu chưa kiểm đầu vào, nếu kết quả kiểm đầu vào của nguyên liệu chưa kiểm đầu vào NG thì sẽ không đủ lượng xuất kho theo yêu cầu", "Input Qty")
                End If

                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                nvd.Update(obj)
                gridD.CurrentRow.Cells("MatQty2").Value = MatQty2
            End If

            If e.ColumnIndex = gridD.Columns("MatQty2").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("PdCode").Value) Then
                    MessageBox.Show("Input JCode, SubPrcName, PdCode", "Input MatQty2")
                    Exit Sub
                End If

                Dim _MatQty2 As Decimal
                If gridD.CurrentRow.Cells("MatQty2").Value Is DBNull.Value Then
                    _MatQty2 = 0
                Else
                    _MatQty2 = gridD.CurrentRow.Cells("MatQty2").Value
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_TrayU00()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                obj.PdCode_K = gridD.CurrentRow.Cells("PdCode").Value
                nvd.GetObject(obj)
                obj.MatQty2 = _MatQty2

                Dim MatQty1 = IIf(gridD.CurrentRow.Cells("MatQty1").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("MatQty1").Value)
                Dim AdjustQty = IIf(gridD.CurrentRow.Cells("AdjustQty").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("AdjustQty").Value)

                Dim stockRemain As Decimal = stock(obj.JCode_K) - sumOut(obj.YMD_K, obj.ECode_K, obj.PdCode_K, obj.JCode_K, obj.SubPrcName_K)

                If stockRemain < (MatQty1 + obj.MatQty2 + AdjustQty) Then
                    MessageBox.Show("StockRemain = " & stockRemain & " < MatQty1 + MatQty2 + AdjustQty = " & (MatQty1 + obj.MatQty2 + AdjustQty), "Input MatQty2")
                    Exit Sub
                End If

                If avalQty < (MatQty1 + obj.MatQty2 + AdjustQty) Then
                    MessageBox.Show("Yêu cầu xuất kho bao gồm cả nguyên liệu chưa kiểm đầu vào, nếu kết quả kiểm đầu vào của nguyên liệu chưa kiểm đầu vào NG thì sẽ không đủ lượng xuất kho theo yêu cầu", "Input Qty")
                End If

                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                nvd.Update(obj)

                gridD.CurrentRow.Cells("TotalQty").Value = MatQty1 + _MatQty2 + AdjustQty
            End If

            If e.ColumnIndex = gridD.Columns("AdjustLot").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("PdCode").Value) Then
                    MessageBox.Show("Input JCode, SubPrcName, PdCode", "Input AdjustLot")
                    Exit Sub
                End If
                Dim _AdjustLot As Integer
                If gridD.CurrentRow.Cells("AdjustLot").Value Is DBNull.Value Then
                    _AdjustLot = 0
                Else
                    _AdjustLot = gridD.CurrentRow.Cells("AdjustLot").Value
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_TrayU00()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                obj.PdCode_K = gridD.CurrentRow.Cells("PdCode").Value
                nvd.GetObject(obj)
                obj.AdjustLot = _AdjustLot

                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                nvd.Update(obj)
            End If

            If e.ColumnIndex = gridD.Columns("AdjustQty").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("PdCode").Value) Then
                    MessageBox.Show("Input JCode, SubPrcName, PdCode", "Input AdjustQty")
                    Exit Sub
                End If
                Dim _AdjustQty As Decimal
                If gridD.CurrentRow.Cells("AdjustQty").Value Is DBNull.Value Then
                    _AdjustQty = 0
                Else
                    _AdjustQty = gridD.CurrentRow.Cells("AdjustQty").Value
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_TrayU00()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                obj.PdCode_K = gridD.CurrentRow.Cells("PdCode").Value
                nvd.GetObject(obj)
                Dim FirstAdjustQty As Decimal = obj.AdjustQty
                obj.AdjustQty = _AdjustQty

                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                nvd.Update(obj)
                gridD.CurrentRow.Cells("AdjustQty").Value = _AdjustQty

                Dim MatQty1 = IIf(gridD.CurrentRow.Cells("MatQty1").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("MatQty1").Value)
                Dim MatQty2 = IIf(gridD.CurrentRow.Cells("MatQty2").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("MatQty2").Value)
                gridD.CurrentRow.Cells("TotalQty").Value = MatQty1 + MatQty2 + _AdjustQty

                'Begin: AdjustQty Out -> AdjustQty Stock
                'Dim sqlmaxday As String = String.Format("select max(YMD) YMD from {0}", PublicTable.Table_PCM_WorkshopStock)
                'Dim dtmaxday As DataTable = nvd.FillDataTable(sqlmaxday)

                'If dtmaxday.Rows(0)("YMD").ToString() = "" Then Exit Sub
                'If gridD.CurrentRow.Cells("YMD").Value < dtmaxday.Rows(0)("YMD").ToString() Then
                '    Dim objStock As New PCM_WorkshopStock
                '    objStock.YMD_K = dtmaxday.Rows(0)("YMD").ToString()
                '    objStock.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                '    objStock.PrcName_K = gridD.CurrentRow.Cells("PrcName").Value
                '    nvd.GetObject(objStock)
                '    objStock.Adjust = objStock.Adjust + (_AdjustQty - FirstAdjustQty)
                '    If nvd.ExistObject(objStock) Then
                '        nvd.Update(objStock)
                '    End If
                'End If
                'End: AdjustQty Out -> AdjustQty Stock
            End If

            If e.ColumnIndex = gridD.Columns("ActReceive").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("PdCode").Value) Then
                    MessageBox.Show("Input JCode, SubPrcName, PdCode", "Input ActReceive")
                    Exit Sub
                End If
                Dim _ActReceive As Decimal
                If gridD.CurrentRow.Cells("ActReceive").Value Is DBNull.Value Then
                    _ActReceive = 0
                Else
                    _ActReceive = gridD.CurrentRow.Cells("ActReceive").Value
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_TrayU00()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                obj.PdCode_K = gridD.CurrentRow.Cells("PdCode").Value
                nvd.GetObject(obj)
                obj.ActReceive = _ActReceive

                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                nvd.Update(obj)
            End If

            If e.ColumnIndex = gridD.Columns("Note").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) _
                    Or IsDBNull(gridD.CurrentRow.Cells("PdCode").Value) Then
                    MessageBox.Show("Input JCode, SubPrcName, PdCode", "Input Note")
                    Exit Sub
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_TrayU00()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                obj.PdCode_K = gridD.CurrentRow.Cells("PdCode").Value
                nvd.GetObject(obj)
                If gridD.CurrentRow.Cells("Note").Value IsNot DBNull.Value Then
                    obj.Note = gridD.CurrentRow.Cells("Note").Value
                Else
                    obj.Note = ""
                End If
                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                nvd.Update(obj)
            End If
        Catch ex As Exception
            ShowError(ex, "CellValueChanged", Name)
        End Try
    End Sub
End Class