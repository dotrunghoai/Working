Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Runtime.InteropServices

Public Class FrmOutMaterialAndSubMaterial : Inherits DevExpress.XtraEditors.XtraForm
    'Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim nvd As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    'Dim dbAS As New DBFunction(PublicConst.EnumServers.NDV_DB2_AS400)
    Dim cls As New clsApplication
    Dim lock As Integer
    Dim dtAll As DataTable
    Dim dtSearch As DataTable
    Dim frmclosing As Integer = 1
    Dim IsView As Boolean = False
    Dim Edit As Boolean = False
    Dim showJCode As String = ""
    Dim avalQty As Decimal
    Dim heldQty As Decimal
    Dim ColQty As String = "Qty1"


    Function condiUser() As String
        If cls.checkUser() Then
            Return ""
        Else
            Return CurrentUser.UserID
        End If
    End Function

    Private Sub mnuShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAll.Click
        'Try
        lock = 0

        Dim param(6) As SqlClient.SqlParameter

        Dim day As String = dtpOrderDate.Value.ToString("yyyyMMdd")
        Dim M1 As DateTime = DateTime.Now.AddMonths(-1)
        Dim M3 As DateTime = DateTime.Now.AddMonths(-3)
        Dim Day1 As DateTime = GetStartDayOfMonth(DateTime.Now.Date)
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

        gridD.Columns("Qty1").ReadOnly = objlock.JCodeLocked1
        chkLocked1.Checked = objlock.JCodeLocked1

        gridD.Columns("Qty2").ReadOnly = objlock.JCodeLocked2
        chkLocked2.Checked = objlock.JCodeLocked2

        gridD.Columns("Qty3").ReadOnly = objlock.JCodeLocked3
        chkLocked3.Checked = objlock.JCodeLocked3

        param(0) = New SqlClient.SqlParameter("@M1", M1.ToString("yyyyMM"))
        param(1) = New SqlClient.SqlParameter("@M3", M3.ToString("yyyyMM"))
        param(2) = New SqlClient.SqlParameter("@Day1", Day1.ToString("yyyyMMdd"))
        param(3) = New SqlClient.SqlParameter("@DayNow", DayNow.ToString("yyyyMMdd"))
        param(4) = New SqlClient.SqlParameter("@day", day)
        param(5) = New SqlClient.SqlParameter("@condiUser", condiUser)
        param(6) = New SqlClient.SqlParameter("@showJCode", Trim(cboShowJCode.Text))

        Dim bd As New BindingSource
        dtAll = nvd.ExecuteStoreProcedureTB("sp_PCM_OutMaterial", param)
        bd.DataSource = dtAll

        If dtAll.Rows.Count <> 0 Then
            If IsNumeric(dtAll.Rows(0).Item("ReviseQty")) Then
                txtOutputNumber.Text = dtAll.Rows(0).Item("ReviseQty")
            Else
                txtOutputNumber.Text = ""
            End If
        Else
            txtOutputNumber.Text = ""
        End If

        Dim dtCombo As DataTable
        Dim rowCombo As DataRow

        Dim JCode As DataGridViewComboBoxColumn = DirectCast(gridD.Columns("JCode"), DataGridViewComboBoxColumn)
        JCode.DataPropertyName = "JCode"
        JCode.ValueMember = "JCode"
        JCode.DisplayMember = "JCode"
        Dim sqlJCode As String = String.Format("select JCode " +
                                                    "from {0} Where ECode like '%{2}%'" +
                                                    "union select JCode from {1} " +
                                                    "Where ECode like '%{2}%'",
                                                   PublicTable.Table_PCM_MterNotJCode,
                                                   PublicTable.Table_PCM_NotJCode,
                                                   condiUser)

        dtCombo = nvd.FillDataTable(sqlJCode)
        rowCombo = dtCombo.NewRow
        dtCombo.Rows.InsertAt(rowCombo, 0)
        JCode.DataSource = dtCombo
        JCode.SortMode = DataGridViewColumnSortMode.Automatic

        Dim SubPrcName As DataGridViewComboBoxColumn = DirectCast(gridD.Columns("SubPrcName"), DataGridViewComboBoxColumn)
        SubPrcName.DataPropertyName = "SubPrcName"
        SubPrcName.ValueMember = "SubPrcName"
        SubPrcName.DisplayMember = "SubPrcName"
        Dim sqlSubPrcName As String = String.Format("select SubPrcName from {0} " +
                                                        "Where ECode like '%{2}%' " +
                                                        "union select SubPrcName from {1} " +
                                                        "Where ECode like '%{2}%'",
                                                        PublicTable.Table_PCM_MterNotJCode,
                                                        PublicTable.Table_PCM_NotJCode,
                                                        condiUser)
        dtCombo = nvd.FillDataTable(sqlSubPrcName)
        rowCombo = dtCombo.NewRow
        dtCombo.Rows.InsertAt(rowCombo, 0)
        SubPrcName.DataSource = dtCombo
        SubPrcName.SortMode = DataGridViewColumnSortMode.Automatic

        Dim dtFilter As DataTable
        Dim rowFilter As DataRow

        Dim sqlFilter As String = String.Format("Select distinct JCode from {0} Where YMD = '{1}' and ECode like '%{2}%'",
                                                    PublicTable.Table_PCM_NotJCode, day, condiUser)
        dtFilter = nvd.FillDataTable(sqlFilter)
        rowFilter = dtFilter.NewRow()
        dtFilter.Rows.InsertAt(rowFilter, 0)
        cboJCodeFilter.DisplayMember = "JCode"
        cboJCodeFilter.ValueMember = "JCode"
        cboJCodeFilter.DataSource = dtFilter
        cboJCodeFilter.SelectedValue = DBNull.Value

        sqlFilter = String.Format("Select distinct SubPrcName from {0} Where YMD = '{1}' and ECode like '%{2}%'",
                                      PublicTable.Table_PCM_NotJCode, day, condiUser)
        dtFilter = nvd.FillDataTable(sqlFilter)
        rowFilter = dtFilter.NewRow()
        dtFilter.Rows.InsertAt(rowFilter, 0)
        cboSubPrcNameFilter.DisplayMember = "SubPrcName"
        cboSubPrcNameFilter.ValueMember = "SubPrcName"
        cboSubPrcNameFilter.DataSource = dtFilter
        cboSubPrcNameFilter.SelectedValue = DBNull.Value

        sqlFilter = String.Format("Select distinct ECode from {0} Where YMD = '{1}' and ECode like '%{2}%'",
                                      PublicTable.Table_PCM_NotJCode, day, condiUser)
        dtFilter = nvd.FillDataTable(sqlFilter)
        rowFilter = dtFilter.NewRow()
        dtFilter.Rows.InsertAt(rowFilter, 0)
        cboECodeFilter.DisplayMember = "ECode"
        cboECodeFilter.ValueMember = "ECode"
        cboECodeFilter.DataSource = dtFilter
        cboECodeFilter.SelectedValue = DBNull.Value

        gridD.DataSource = bd
        bnGrid.BindingSource = bd

        If chkLocked1.Checked = True And chkLocked2.Checked = True And chkLocked3.Checked = True Then
            LockColums(False)
        Else
            LockColums(True)
        End If

        If dtAll.Rows.Count <> 0 Then
            tsTotal1.Text = dtAll.Compute("sum(Qty1)", "")
            tsTotal2.Text = dtAll.Compute("sum(Qty2)", "")
            tsTotal3.Text = dtAll.Compute("sum(Qty3)", "")
        End If

        lock = 1
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "mnuShowAll_Click")
        'End Try
    End Sub

    Private Sub dtpOrderDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpOrderDate.ValueChanged
        grpGrid.Enabled = True
        'If dtpOrderDate.Value > DateTime.Now Then
        '    MessageBox.Show("Date > Current Date", "Date")
        '    dtpOrderDate.Value = DateTime.Now
        '    Exit Sub
        'Else
        mnuShowAll.PerformClick()
        'End If
    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        Dim sfDlg As New SaveFileDialog()
        sfDlg.DefaultExt = ".xlsx"
        sfDlg.Filter = "Excel 2007 file(.xlsx)|*.xlsx| Excel 2003 file(.xls)|*.xls"
        sfDlg.FileName = String.Format("Số lượng xuất kho lần 1 ({0})- nguyên liệu.xlsx",
                                       DateTime.Now.ToString("dd.MM.yyyy"))
        sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\1.Xuat kho Nippon\XUAT KHO {0}\XKHO NL T{1}\Lần 1\",
                                               DateTime.Now.Year,
                                               DateTime.Now.ToString("MM.yyyy"))
        If rdoEx2.Checked Then
            sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\1.Xuat kho Nippon\XUAT KHO {0}\XKHO NL T{1}\Lần 2\",
                                               DateTime.Now.Year,
                                               DateTime.Now.ToString("MM.yyyy"))
        ElseIf rdoEx3.Checked Then
            sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\1.Xuat kho Nippon\XUAT KHO {0}\XKHO NL T{1}\Lần 3\",
                                               DateTime.Now.Year,
                                               DateTime.Now.ToString("MM.yyyy"))
        End If

        If sfDlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        If cboShowJCode.Text = "All" Then
            Dim sql As String = String.Format("select YMD, DeptName, ECode, JCode, PrcName, JEName, JVName, Unit, Qty1, Qty2+Adjust as Qty2, Qty3, Note, " +
                                        " DeptGSR = CASE WHEN B.CodePP IS NULL THEN A.DeptName ELSE 'PP' END " +
                                        " from {0} A " +
                                        " left join PCM_ImportCodePP B on A.JCode = B.CodePP " +
                                        " where " +
                                        " YMD = '{1}' and ECode like '%{2}%'" +
                                        " order by ECode,PrcName, JCode",
                                        PublicTable.Table_PCM_NotJCode,
                                        dtpOrderDate.Value.ToString("yyyyMMdd"),
                                        condiUser)
            ExportEXCEL(nvd.FillDataTable(sql))
        ElseIf cboShowJCode.Text = "NotJCode" Then
            Dim sql As String = String.Format("select YMD, DeptName, ECode, JCode, PrcName, JEName, JVName, Unit, Qty1, Qty2+Adjust as Qty2, Qty3, Note, " +
                                        " DeptGSR = CASE WHEN B.CodePP IS NULL THEN A.DeptName ELSE 'PP' END " +
                                        " from {0} A " +
                                        " left join PCM_ImportCodePP B on A.JCode = B.CodePP " +
                                        " where " +
                                        " YMD = '{1}' and ECode like '%{2}%' and A.JCode not like 'J%' " +
                                        " order by ECode,PrcName, JCode",
                                        PublicTable.Table_PCM_NotJCode,
                                        dtpOrderDate.Value.ToString("yyyyMMdd"),
                                        condiUser,
                                        Trim(cboShowJCode.Text))
            ExportEXCEL(nvd.FillDataTable(sql))
        ElseIf cboShowJCode.Text = "JCodeChemical" Then
            Dim sql As String = String.Format("select YMD, DeptName, ECode, JCode, PrcName, JEName, JVName, Unit, Qty1, Qty2+Adjust as Qty2, Qty3, Note, " +
                                        " DeptGSR = CASE WHEN B.CodePP IS NULL THEN A.DeptName ELSE 'PP' END " +
                                        " from {0} A " +
                                        " left join PCM_ImportCodePP B on A.JCode = B.CodePP " +
                                        " inner join (select distinct ItemCode from [dbo].[LOS_ItemChemical])c " +
                                           " on A.JCode=c.ItemCode " +
                                        " where " +
                                        " YMD = '{1}' and ECode like '%{2}%' and A.JCode like 'J%'" +
                                        " order by ECode,PrcName, JCode",
                                        PublicTable.Table_PCM_NotJCode,
                                        dtpOrderDate.Value.ToString("yyyyMMdd"),
                                        condiUser,
                                        Trim(cboShowJCode.Text))
            ExportEXCEL(nvd.FillDataTable(sql))
        ElseIf cboShowJCode.Text = "JCodeExcludeChemical" Then
            Dim sql As String = String.Format(" select YMD, DeptName, ECode, JCode, PrcName, JEName, JVName, Unit, Qty1, Qty2+Adjust as Qty2, Qty3, Note, " +
                                        " DeptGSR = CASE WHEN B.CodePP IS NULL THEN A.DeptName ELSE 'PP' END " +
                                        " from {0} A " +
                                        " left join PCM_ImportCodePP B on A.JCode = B.CodePP " +
                                        " left join (select distinct ItemCode from [dbo].[LOS_ItemChemical] )c " +
                                           " on A.JCode=c.ItemCode " +
                                        " where " +
                                        " YMD = '{1}' and ECode like '%{2}%' and A.JCode  like 'J%' " +
                                        " and c.ItemCode is null" +
                                        " order by ECode,PrcName, JCode",
                                        PublicTable.Table_PCM_NotJCode,
                                        dtpOrderDate.Value.ToString("yyyyMMdd"),
                                        condiUser,
                                        Trim(cboShowJCode.Text))
            ExportEXCEL(nvd.FillDataTable(sql))
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
                    If cboJCode IsNot Nothing Then
                        RemoveHandler cboJCode.Validating, AddressOf cboJCode_Validating
                        cboJCode = Nothing
                    End If

                    If cbobox IsNot Nothing Then
                        RemoveHandler cbobox.Validating, AddressOf cbobox_Validating
                        cbobox = Nothing
                    End If

                    Dim obj As New PCM_NotJCode
                    obj.YMD_K = IIf(IsDBNull(datarow.Item(row).Cells("YMD").Value), "", datarow.Item(row).Cells("YMD").Value)
                    obj.JCode_K = IIf(IsDBNull(datarow.Item(row).Cells("JCode").Value), "", datarow.Item(row).Cells("JCode").Value)
                    obj.SubPrcName_K = IIf(IsDBNull(datarow.Item(row).Cells("SubPrcName").Value), "", datarow.Item(row).Cells("SubPrcName").Value)
                    obj.ECode_K = IIf(IsDBNull(datarow.Item(row).Cells("ECode").Value), "", datarow.Item(row).Cells("ECode").Value)
                    If nvd.ExistObject(obj) Then
                        nvd.GetObject(obj)
                        Dim objLock As New PCM_LockDay
                        objLock.YMD_K = obj.YMD_K
                        nvd.GetObject(objLock)
                        If objLock.JCodeLocked1 = True And cls.checkUser = False Then
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

    Function CurrUser() As String
        If gridD.CurrentRow.Cells("ECode").Value IsNot DBNull.Value And
            gridD.CurrentRow.Cells("ECode").Value IsNot Nothing Then
            Return gridD.CurrentRow.Cells("ECode").Value
        End If
        Return CurrentUser.UserID
    End Function

    Private cboJCode As DataGridViewComboBoxEditingControl = Nothing
    Private cbobox As DataGridViewComboBoxEditingControl = Nothing
    Private txtQty As DataGridViewTextBoxEditingControl = Nothing

    Private Sub gridD_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles gridD.EditingControlShowing
        If chkLocked1.Checked = True And chkLocked2.Checked = True And chkLocked3.Checked = True And Edit = False Then Exit Sub
        If IsView Then Exit Sub

        'Try
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
                Dim sqlJCode As String = String.Format("select distinct JCode, JEName, JVName " +
                "from {0} " +
                "Where ECode = '{1}' and Old = 'False'", PublicTable.Table_PCM_MterNotJCode, CurrUser)
                dt = nvd.FillDataTable(sqlJCode)
                row = dt.NewRow
                dt.Rows.InsertAt(row, 0)
                cboJCode.DataSource = dt
                If gridD.CurrentRow.Cells("JCode").Value IsNot DBNull.Value And gridD.CurrentRow.Cells("JCode").Value IsNot Nothing Then
                    cboJCode.SelectedValue = gridD.CurrentRow.Cells("JCode").Value
                End If
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
                Dim sqlSubPrcName As String = String.Format(" select distinct SubPrcName " +
                                                            " from {0} " +
                                                            " Where ECode = '{1}' and JCode = '{2}' and Old = 'False'",
                                                                PublicTable.Table_PCM_MterNotJCode,
                                                                CurrUser,
                                                                gridD.CurrentRow.Cells("JCode").Value)
                dt = nvd.FillDataTable(sqlSubPrcName)
                Dim i As Integer = dt.Rows.Count
                row = dt.NewRow
                dt.Rows.InsertAt(row, 0)
                cbobox.DataSource = dt
                If gridD.CurrentRow.Cells("SubPrcName").Value IsNot DBNull.Value And gridD.CurrentRow.Cells("SubPrcName").Value IsNot Nothing Then
                    cbobox.SelectedValue = gridD.CurrentRow.Cells("SubPrcName").Value
                End If
                cbobox.AutoCompleteMode = AutoCompleteMode.Append
                If cbobox IsNot Nothing Then
                    'Add an EventHandler to the first temporary control  
                    AddHandler cbobox.Validating, AddressOf cbobox_Validating
                End If
            End If
        End If

        If gridD.CurrentCell.ColumnIndex = gridD.Columns("Qty1").Index _
            Or gridD.CurrentCell.ColumnIndex = gridD.Columns("Qty2").Index _
            Or gridD.CurrentCell.ColumnIndex = gridD.Columns("Qty3").Index Then
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

        'Catch ex As Exception
        '    ShowError(ex, "gridD_EditingControlShowing", Me.Name)
        'End Try

    End Sub

    Private Sub gridD_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellEndEdit
        If chkLocked1.Checked = True And chkLocked2.Checked = True And chkLocked3.Checked = True And Edit = False Then Exit Sub
        If IsView Then Exit Sub

        If cboJCode IsNot Nothing Then
            RemoveHandler cboJCode.Validating, AddressOf cboJCode_Validating
            cboJCode = Nothing
        End If

        If cbobox IsNot Nothing Then
            RemoveHandler cbobox.Validating, AddressOf cbobox_Validating
            cbobox = Nothing
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

        Dim reset As Boolean = False

        If chkLocked1.Checked <> lockTime.JCodeLocked1 Then
            chkLocked1.Checked = lockTime.JCodeLocked1
            reset = True
        End If
        If chkLocked2.Checked <> lockTime.JCodeLocked2 Then
            chkLocked2.Checked = lockTime.JCodeLocked2
            reset = True
        End If

        If chkLocked3.Checked <> lockTime.JCodeLocked3 Then
            chkLocked3.Checked = lockTime.JCodeLocked3
            reset = True
        End If

    End Sub

    Private Sub cboJCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If IsView Then Exit Sub

        Try
            Dim JCode As String = IIf(IsDBNull(cboJCode.SelectedValue), "", cboJCode.SelectedValue)
            Dim SubPrcName As String = Trim(gridD.CurrentRow.Cells("SubPrcName").FormattedValue.ToString)

            Dim JCodeTemp As String = Trim(gridD.CurrentRow.Cells("JCodeTemp").FormattedValue.ToString)
            Dim SubPrcNameTemp As String = Trim(gridD.CurrentRow.Cells("SubPrcNameTemp").FormattedValue.ToString)

            If JCode = JCodeTemp And SubPrcName = SubPrcNameTemp Then Exit Sub

            If JCodeTemp <> "" Then
                Dim lockTime As New PCM_LockDay
                lockTime.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
                nvd.GetObject(lockTime)

                If lockTime.JCodeLocked1 And cls.checkUser = False Then
                    MessageBox.Show("Time 1 is Locked", "Lock")
                    gridD.CurrentRow.Cells("JCode").Value = JCodeTemp
                    cboJCode.SelectedValue = JCodeTemp
                    gridD.CurrentRow.Cells("SubPrcName").Value = SubPrcNameTemp
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

            gridD.CurrentRow.Cells("JCode").Value = JCode
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub cbobox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If IsView Then Exit Sub

        Dim JCode As String = Trim(gridD.CurrentRow.Cells("JCode").FormattedValue.ToString)
        Dim SubPrcName As String = IIf(IsDBNull(cbobox.SelectedValue), "", cbobox.SelectedValue)

        Dim JCodeTemp As String = Trim(gridD.CurrentRow.Cells("JCodeTemp").FormattedValue.ToString)
        Dim SubPrcNameTemp As String = Trim(gridD.CurrentRow.Cells("SubPrcNameTemp").FormattedValue.ToString)

        If JCode = JCodeTemp And SubPrcName = SubPrcNameTemp Then Exit Sub

        If JCodeTemp <> "" Then
            Dim lockTime As New PCM_LockDay
            lockTime.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
            nvd.GetObject(lockTime)

            If lockTime.JCodeLocked1 And cls.checkUser = False Then
                MessageBox.Show("Time 1 is Locked", "Lock")
                gridD.CurrentRow.Cells("JCode").Value = JCodeTemp
                gridD.CurrentRow.Cells("SubPrcName").Value = SubPrcNameTemp
                cbobox.SelectedValue = SubPrcNameTemp
                Exit Sub
            End If

            If SubPrcName = "" Then
                gridD.CurrentRow.Cells("SubPrcName").Value = SubPrcNameTemp
                cbobox.SelectedValue = SubPrcNameTemp
                Exit Sub
            End If

        End If

        For i As Integer = 0 To gridD.Rows.Count - 2
            If gridD.CurrentRow.Index <> gridD.Rows(i).Index AndAlso
                JCode = Trim(gridD.Rows(i).Cells("JCode").FormattedValue.ToString()) AndAlso
                SubPrcName = Trim(gridD.Rows(i).Cells("SubPrcName").FormattedValue.ToString()) AndAlso
                gridD.Rows(i).Cells("ECode").Value = CurrUser() Then
                MessageBox.Show("JCode is the same", "Check JCode")
                cbobox.SelectedValue = DBNull.Value
                gridD.CurrentCell.Value = DBNull.Value
                Exit Sub
            End If
        Next
        Dim sql As String = String.Format("select A.ECode, A.JCode, A.PrcName, A.SubPrcName, A.JEName, A.JVName, A.Unit, A.MinQty, A.StdDtbtQty, A.AddDtbtQty, A.NormWeek, B.DeptName " +
                                        "from {0} A " +
                                        "left join PCM_Dept B on A.ECode = B.ECode and A.SubPrcName = B.SubPrcName " +
                                        "where A.ECode = '{1}' and A.JCode = '{2}' and A.SubPrcName = '{3}' ",
                                          PublicTable.Table_PCM_MterNotJCode, CurrUser,
                                          JCode, SubPrcName)
        Dim dt As DataTable = nvd.FillDataTable(sql)
        If dt.Rows.Count <> 0 Then
            gridD.CurrentRow.Cells("YMD").Value = dtpOrderDate.Value.ToString("yyyyMMdd")
            gridD.CurrentRow.Cells("ECode").Value = CurrUser()
            gridD.CurrentRow.Cells("DeptName").Value = dt.Rows(0).Item("DeptName").ToString
            gridD.CurrentRow.Cells("PrcName").Value = dt.Rows(0).Item("PrcName").ToString
            gridD.CurrentRow.Cells("JEName").Value = dt.Rows(0).Item("JEName").ToString
            gridD.CurrentRow.Cells("JVName").Value = dt.Rows(0).Item("JVName").ToString
            gridD.CurrentRow.Cells("Unit").Value = dt.Rows(0).Item("Unit").ToString
            gridD.CurrentRow.Cells("MinQty").Value = dt.Rows(0).Item("MinQty")
            gridD.CurrentRow.Cells("StdDtbtQty").Value = IIf(dt.Rows(0).Item("StdDtbtQty") Is DBNull.Value, 0, dt.Rows(0).Item("StdDtbtQty"))
            gridD.CurrentRow.Cells("NormWeekJ").Value = IIf(dt.Rows(0).Item("NormWeek") Is DBNull.Value, 0, dt.Rows(0).Item("NormWeek"))
            Dim AddDtbQty As Integer
            If dt.Rows(0).Item("AddDtbtQty") Is DBNull.Value Then
                AddDtbQty = 1
            ElseIf dt.Rows(0).Item("AddDtbtQty") < 1 Then
                AddDtbQty = 1
            Else
                AddDtbQty = dt.Rows(0).Item("AddDtbtQty")
            End If

            gridD.CurrentRow.Cells("UseDay").Value = AddDtbQty

            Dim sqlRevise As String = String.Format("select top 1 ReviseQty from {0} where YMD = '{1}'",
            PublicTable.Table_PCM_NotJCode, dtpOrderDate.Value.ToString("yyyyMMdd"))
            Dim dtRevise As DataTable = nvd.FillDataTable(sqlRevise)
            Dim _ReviseQty As Integer
            If dtRevise.Rows.Count = 0 Then
                _ReviseQty = 1
            Else
                _ReviseQty = IIf(dtRevise.Rows(0).Item("ReviseQty") Is DBNull.Value, 1, dtRevise.Rows(0).Item("ReviseQty"))
            End If

            gridD.CurrentRow.Cells("ReviseQty").Value = _ReviseQty

            If gridD.CurrentRow.Cells("UseDay").Value > gridD.CurrentRow.Cells("ReviseQty").Value Then
                gridD.CurrentRow.Cells("TotalDtbtQty").Value = gridD.CurrentRow.Cells("StdDtbtQty").Value * gridD.CurrentRow.Cells("UseDay").Value
            Else
                gridD.CurrentRow.Cells("TotalDtbtQty").Value = gridD.CurrentRow.Cells("StdDtbtQty").Value * gridD.CurrentRow.Cells("ReviseQty").Value
            End If

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

            Dim sql3M As String = String.Format("select JCode, round((sum(Qty1) + sum(Qty2) + sum(Qty3) + sum(Adjust))/ 3, 2) as AVGUsing " +
            "from {0} " +
            "where left(YMD,6) between @M3 and @M1 and JCode = '{1}' " +
            "Group by JCode", PublicTable.Table_PCM_NotJCode, JCode)
            Dim dt3M As DataTable = nvd.FillDataTable(sql3M, param)
            If dt3M.Rows.Count <> 0 Then
                gridD.CurrentRow.Cells("AVGUsing").Value = dt3M.Rows(0).Item("AVGUsing")
            End If

            Dim sql0131 As String = String.Format("select JCode, round((sum(Qty1) + sum(Qty2) + sum(Qty3) + sum(Adjust)), 2) as Total0131 " +
            "from {0} " +
            "where YMD between @Day1 and @DayNow and JCode = '{1}' " +
            "Group by JCode", PublicTable.Table_PCM_NotJCode, JCode)
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

            Dim obj As New PCM_NotJCode()
            obj.YMD_K = Trim(gridD.CurrentRow.Cells("YMD").FormattedValue.ToString)
            obj.ECode_K = Trim(gridD.CurrentRow.Cells("ECode").FormattedValue.ToString)
            obj.JCode_K = JCodeTemp
            obj.SubPrcName_K = SubPrcNameTemp
            nvd.GetObject(obj)
            obj.DeptName = IIf(gridD.CurrentRow.Cells("DeptName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("DeptName").Value)
            obj.PrcName = IIf(gridD.CurrentRow.Cells("PrcName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("PrcName").Value)
            obj.JEName = IIf(gridD.CurrentRow.Cells("JEName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("JEName").Value)
            obj.JVName = IIf(gridD.CurrentRow.Cells("JVName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("JVName").Value)
            obj.Unit = IIf(gridD.CurrentRow.Cells("Unit").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("Unit").Value)
            obj.MinQty = IIf(gridD.CurrentRow.Cells("MinQty").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("MinQty").Value)
            obj.StdDtbtQty = IIf(gridD.CurrentRow.Cells("StdDtbtQty").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("StdDtbtQty").Value)
            obj.NormWeek = IIf(gridD.CurrentRow.Cells("NormWeekJ").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("NormWeekJ").Value)
            obj.ReviseQty = IIf(gridD.CurrentRow.Cells("ReviseQty").Value Is DBNull.Value, 1, gridD.CurrentRow.Cells("ReviseQty").Value)
            obj.AddDtbtQty = IIf(gridD.CurrentRow.Cells("UseDay").Value Is DBNull.Value, 1, gridD.CurrentRow.Cells("UseDay").Value)
            obj.RequestQty = IIf(gridD.CurrentRow.Cells("RequestQty").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("RequestQty").Value)
            obj.RequestDate = IIf(gridD.CurrentRow.Cells("RequestDate").Value Is DBNull.Value, DateTime.Now, gridD.CurrentRow.Cells("RequestDate").Value)

            If nvd.ExistObject(obj) Then
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = JCode
                obj.SubPrcName_K = SubPrcName

                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                nvd.Update(obj, String.Format("YMD = '{0}' and ECode = '{1}' and JCode = '{2}' and SubPrcName = '{3}'",
                Trim(gridD.CurrentRow.Cells("YMD").FormattedValue.ToString),
                Trim(gridD.CurrentRow.Cells("ECode").FormattedValue.ToString),
                JCodeTemp, SubPrcNameTemp))
                gridD.CurrentRow.Cells("JCodeTemp").Value = JCode
                gridD.CurrentRow.Cells("SubPrcNameTemp").Value = SubPrcName
            Else
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = JCode
                obj.SubPrcName_K = SubPrcName

                obj.Lock1 = chkLocked1.Checked
                obj.Lock2 = chkLocked2.Checked
                obj.Lock3 = chkLocked3.Checked
                obj.CreateUser = CurrentUser.UserID
                obj.CreateDate = DateTime.Now
                obj.PCNo = Environment.MachineName()
                nvd.Insert(obj)
                gridD.CurrentRow.Cells("JCodeTemp").Value = JCode
                gridD.CurrentRow.Cells("SubPrcNameTemp").Value = SubPrcName
            End If
        End If

        gridD.CurrentRow.Cells("SubPrcName").Value = SubPrcName
    End Sub

    Private Sub FrmOutMaterialAndSubMaterial_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        gridD.AutoGenerateColumns = False

        If cls.checkUser() And cls.checkUserIsView() = False Then
            lblOutputNumber.Enabled = True
            txtOutputNumber.Enabled = True
            chkLocked1.Enabled = True
            chkLocked2.Enabled = True
            chkLocked3.Enabled = True
            gridD.Columns("ECode").Visible = True
            gridD.Columns("Adjust").Visible = True
            gridD.Columns("ActReceive").Visible = True
            gridD.Columns("AVGUsing").Visible = True
            gridD.Columns("Total0131").Visible = True
            gridD.Columns("DeptName").Visible = True
            lblFilterECode.Visible = True
            cboECodeFilter.Visible = True
        ElseIf cls.checkUser() And cls.checkUserIsView() Then
            gridD.Columns("ECode").Visible = True
            gridD.Columns("Adjust").Visible = True
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
        gridD.Columns("TotalDtbtQty").DefaultCellStyle.BackColor = Drawing.Color.Khaki
        gridD.Columns("TotalDtbtQty").HeaderCell.Style.BackColor = Drawing.Color.Khaki

        gridD.Columns("AVGUsing").DefaultCellStyle.BackColor = Drawing.Color.LightGray
        gridD.Columns("AVGUsing").HeaderCell.Style.BackColor = Drawing.Color.LightGray

        gridD.Columns("Total0131").DefaultCellStyle.BackColor = Drawing.Color.LightPink
        gridD.Columns("Total0131").HeaderCell.Style.BackColor = Drawing.Color.LightPink

        gridD.Columns("Qty1").DefaultCellStyle.BackColor = Drawing.Color.LightCyan
        gridD.Columns("Qty1").HeaderCell.Style.BackColor = Drawing.Color.LightCyan

        gridD.Columns("Qty2").DefaultCellStyle.BackColor = Drawing.Color.Plum
        gridD.Columns("Qty2").HeaderCell.Style.BackColor = Drawing.Color.Plum

        gridD.Columns("Qty3").DefaultCellStyle.BackColor = Drawing.Color.LightGreen
        gridD.Columns("Qty3").HeaderCell.Style.BackColor = Drawing.Color.LightGreen

        cboShowJCode.Items.Add("All")
        cboShowJCode.Items.Add("NotJCode")
        cboShowJCode.Items.Add("JCodeChemical")
        cboShowJCode.Items.Add("JCodeExcludeChemical")
        cboShowJCode.SelectedIndex = 0

        mnuShowAll.PerformClick()
    End Sub

    Sub LockColums(ByVal lock As Boolean)
        gridD.Columns("JCode").ReadOnly = Not lock
        gridD.Columns("SubPrcName").ReadOnly = Not lock
        gridD.Columns("ECode").ReadOnly = Not lock
    End Sub

    Private Sub txtOutputNumber_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtOutputNumber.PreviewKeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Dim sql As String = String.Format("update {0} " +
            "set ReviseQty = {1} " +
            "from {0} " +
            "where YMD = '{2}'", PublicTable.Table_PCM_NotJCode, Convert.ToInt32(txtOutputNumber.Text), dtpOrderDate.Value.ToString("yyyyMMdd"))
            nvd.ExecuteNonQuery(sql)
            MessageBox.Show("Output Number is updated!", "Update")
            mnuShowAll.PerformClick()
        End If
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

        Dim lockJCode As New PCM_LockDay
        lockJCode.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")

        If nvd.ExistObject(lockJCode) Then
            nvd.GetObject(lockJCode)
            lockJCode.JCodeLocked1 = chkLocked1.Checked
            nvd.Update(lockJCode)
        Else
            lockJCode.JCodeLocked1 = chkLocked1.Checked
            nvd.Insert(lockJCode)
        End If

        If chkLocked1.Checked Then
            nvd.GetObject(lockJCode)

            If cls.checkUser() Then
                lockJCode.UserJCode1 = CurrentUser.UserID
                lockJCode.DateJCode1 = DateTime.Now
            End If

            nvd.Update(lockJCode)

            gridD.Columns("Qty1").ReadOnly = True
            If chkLocked1.Checked = True And chkLocked2.Checked = True And chkLocked3.Checked = True Then
                LockColums(False)
            End If
            MessageBox.Show("Time 1 is locked", "Lock")
        Else
            nvd.GetObject(lockJCode)

            If cls.checkUser() Then
                lockJCode.UserUnlockJCode1 = CurrentUser.UserID
                lockJCode.DateUnlockJCode1 = DateTime.Now
            End If

            nvd.Update(lockJCode)

            gridD.Columns("Qty1").ReadOnly = False
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

        Dim lockJCode As New PCM_LockDay
        lockJCode.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")

        If nvd.ExistObject(lockJCode) Then
            nvd.GetObject(lockJCode)
            lockJCode.JCodeLocked2 = chkLocked2.Checked
            nvd.Update(lockJCode)
        Else
            lockJCode.JCodeLocked2 = chkLocked2.Checked
            nvd.Insert(lockJCode)
        End If

        If chkLocked2.Checked Then
            nvd.GetObject(lockJCode)

            If cls.checkUser() Then
                lockJCode.UserJCode2 = CurrentUser.UserID
                lockJCode.DateJCode2 = DateTime.Now
            End If

            nvd.Update(lockJCode)

            gridD.Columns("Qty2").ReadOnly = True
            If chkLocked1.Checked = True And chkLocked2.Checked = True And chkLocked3.Checked = True Then
                LockColums(False)
            End If
            MessageBox.Show("Time 2 is locked", "Lock")
        Else
            nvd.GetObject(lockJCode)

            If cls.checkUser() Then
                lockJCode.UserUnlockJCode2 = CurrentUser.UserID
                lockJCode.DateUnlockJCode2 = DateTime.Now
            End If

            nvd.Update(lockJCode)

            gridD.Columns("Qty2").ReadOnly = False
            LockColums(True)
            MessageBox.Show("Time 2 is unlocked", "Lock")
        End If
    End Sub

    Private Sub chkLocked3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLocked3.CheckedChanged
        If lock = 0 Then Exit Sub

        If cls.checkImportStock() = False Then
            If MessageBox.Show("Bạn chưa Import tồn hôm nay. Bạn có muốn tiếp tục", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                mnuShowAll.PerformClick()
                Exit Sub
            End If
        End If

        Dim lockJCode As New PCM_LockDay
        lockJCode.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")

        If nvd.ExistObject(lockJCode) Then
            nvd.GetObject(lockJCode)
            lockJCode.JCodeLocked3 = chkLocked3.Checked
            nvd.Update(lockJCode)
        Else
            lockJCode.JCodeLocked3 = chkLocked3.Checked
            nvd.Insert(lockJCode)
        End If

        If chkLocked3.Checked Then
            nvd.GetObject(lockJCode)

            If cls.checkUser() Then
                lockJCode.UserJCode3 = CurrentUser.UserID
                lockJCode.DateJCode3 = DateTime.Now
            End If

            nvd.Update(lockJCode)

            gridD.Columns("Qty3").ReadOnly = True
            If chkLocked1.Checked = True And chkLocked2.Checked = True And chkLocked3.Checked = True Then
                LockColums(False)
            End If
            MessageBox.Show("Time 3 is locked", "Lock")
        Else
            nvd.GetObject(lockJCode)

            If cls.checkUser() Then
                lockJCode.UserUnlockJCode3 = CurrentUser.UserID
                lockJCode.DateUnlockJCode3 = DateTime.Now
            End If

            nvd.Update(lockJCode)

            gridD.Columns("Qty3").ReadOnly = False
            LockColums(True)
            MessageBox.Show("Time 3 is unlocked", "Lock")
        End If
    End Sub

    Function stock(ByVal JCode As String) As Decimal
        Dim sql As String = String.Format("select Qty, HeldQty from {0} where JCode = '{1}'", PublicTable.Table_PCM_Stock, JCode)
        Dim dt As DataTable = nvd.FillDataTable(sql)
        If dt.Rows.Count = 0 Then
            Return 0
        Else
            avalQty = dt.Rows(0).Item("Qty")
            heldQty = dt.Rows(0).Item("HeldQty")
            Return dt.Rows(0).Item("Qty") + dt.Rows(0).Item("HeldQty")
        End If
    End Function

    Function sumOut(ByVal YMD As String, ByVal ECode As String, ByVal JCode As String, ByVal SubPrcName As String) As Decimal
        Dim strKey As String = YMD & ECode & JCode & SubPrcName
        Dim sql As String = String.Format("select ID = YMD +ECode+JCode+SubPrcName, Qty1, Qty2, Qty3, Adjust " +
        "into #T " +
        "from {0} where YMD = '{1}' and JCode = '{2}' " +
        "select Qty1, Qty2, Qty3, Adjust from #T  T where T.ID NOT IN ('{3}')",
        PublicTable.Table_PCM_NotJCode, YMD, JCode, strKey)
        Dim dt As DataTable = nvd.FillDataTable(sql)
        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Compute("Sum(Qty1)", "") + dt.Compute("Sum(Qty2)", "") + dt.Compute("Sum(Qty3)", "") + dt.Compute("Sum(Adjust)", "")
        End If
    End Function

    Private Sub gridD_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles gridD.DataError
        If chkLocked1.Checked = True And chkLocked2.Checked = True And chkLocked3.Checked = True Then Exit Sub

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

    End Sub

    Private Sub gridD_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellEnter
        If IsView Then Exit Sub

        Dim lockTime As New PCM_LockDay
        lockTime.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
        nvd.GetObject(lockTime)

        If chkLocked1.Checked <> lockTime.JCodeLocked1 Then
            chkLocked1.Checked = lockTime.JCodeLocked1
        End If
        If chkLocked2.Checked <> lockTime.JCodeLocked2 Then
            chkLocked2.Checked = lockTime.JCodeLocked2
        End If

        If chkLocked3.Checked <> lockTime.JCodeLocked3 Then
            chkLocked3.Checked = lockTime.JCodeLocked3
        End If

        If chkLocked1.Checked = True And chkLocked2.Checked = True And chkLocked3.Checked = True And Edit = False Then Exit Sub
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

    Function NormWeek(ByVal JCode As String, ByVal ECode As String, ByVal SubPrcName As String) As Decimal
        Dim sql As String = String.Format("SELECT " +
                                        " SumQuantity = SUM(Qty1) + SUM(Qty2) + SUM(Qty3) + SUM(Adjust) " +
                                        " FROM {0} " +
                                        " WHERE   JCode = '{1}' " +
                                        " AND ECode = '{2}' " +
                                        " AND SubPrcName = '{3}' " +
                                        " AND YMD BETWEEN '{4}' AND '{5}' ",
        PublicTable.Table_PCM_NotJCode, JCode, ECode, SubPrcName,
        DateTime.Now.AddDays(-DateTime.Now.DayOfWeek + 1).ToString("yyyyMMdd"),
        DateTime.Now.ToString("yyyyMMdd"))

        Dim dt As DataTable = nvd.FillDataTable(sql)
        If dt.Rows.Count <> 0 Then
            Return dt.Rows(0).Item("SumQuantity")
        End If
        Return 0
    End Function

    Function MonthStd(ByVal JCode As String, ByVal ECode As String, ByVal SubPrcName As String) As Decimal
        Dim sql As String = String.Format("SELECT " +
                                        " SumQuantity = SUM(Qty1) + SUM(Qty2) + SUM(Qty3) + SUM(Adjust) " +
                                        " FROM {0} " +
                                        " WHERE   JCode = '{1}' " +
                                        " AND ECode = '{2}' " +
                                        " AND SubPrcName = '{3}' " +
                                        " AND YMD BETWEEN '{4}' AND '{5}' ",
        PublicTable.Table_PCM_NotJCode, JCode, ECode, SubPrcName,
        GetStartDayOfMonth(DateTime.Now).ToString("yyyyMMdd"),
       GetEndDayOfMonth(DateTime.Now).ToString("yyyyMMdd"))

        Dim dt As DataTable = nvd.FillDataTable(sql)
        If dt.Rows.Count <> 0 Then
            Return dt.Rows(0).Item("SumQuantity")
        End If
        Return 0
    End Function
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

    Private Sub gridSearch_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridSearch.CellClick
        If gridD.CurrentRow Is Nothing Then Exit Sub
        If gridSearch Is Nothing Then Exit Sub

        If gridD.CurrentCell.ColumnIndex = gridD.Columns("JCode").Index Then

            If stock(gridSearch.CurrentRow.Cells("JCodeSearch").Value) = 0 Then
                MessageBox.Show("Stock = 0.", "Stock")
                Exit Sub
            Else
                gridD.CurrentCell.Value = gridSearch.CurrentRow.Cells("JCodeSearch").Value
                gridD.CurrentCell = gridD.Item(gridD.CurrentCell.ColumnIndex + 1, gridD.CurrentCell.RowIndex)
                tsStock.Text = stock(gridSearch.CurrentRow.Cells("JCodeSearch").Value)
                tsInsStockD.Text = avalQty
                tsNonInsStockD.Text = heldQty
            End If
            gridD.Focus()
        End If
    End Sub

    Private Sub gridD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridD.Click
        If gridD.CurrentRow Is Nothing Then Exit Sub
        Dim JCode As String = Trim(gridD.CurrentRow.Cells("JCode").FormattedValue.ToString)
        tsStock.Text = stock(JCode)
        tsInsStockD.Text = avalQty
        tsNonInsStockD.Text = heldQty
    End Sub

    Private Sub btnCheckLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckLock.Click
        Dim frm As New FrmCheckLock
        frm.Show()
    End Sub

    Private Sub mnuCheckQty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheckQty.Click
        Try
            Dim err As Integer = 0
            For i As Integer = 0 To gridD.RowCount - 1
                Application.DoEvents()

                If gridD.CurrentRow.Index = gridD.Rows.Count - 1 Then
                    gridD.CurrentCell = gridD(1, 0)
                Else
                    gridD.CurrentCell = gridD(1, gridD.Rows(i).Index)
                End If

                Dim Total As Decimal = IIf(IsDBNull(gridD.Rows(i).Cells("TotalDtbtQty").Value), 0, gridD.Rows(i).Cells("TotalDtbtQty").Value)
                Dim Qty1 As Decimal = IIf(IsDBNull(gridD.Rows(i).Cells("Qty1").Value), 0, gridD.Rows(i).Cells("Qty1").Value)
                Dim Qty2 As Decimal = IIf(IsDBNull(gridD.Rows(i).Cells("Qty2").Value), 0, gridD.Rows(i).Cells("Qty2").Value)
                Dim Qty3 As Decimal = IIf(IsDBNull(gridD.Rows(i).Cells("Qty3").Value), 0, gridD.Rows(i).Cells("Qty3").Value)

                If Total < (Qty1 + Qty2 + Qty3) Then
                    gridD.Rows(i).DefaultCellStyle.BackColor = Drawing.Color.Red
                    err += 1
                Else
                    gridD.Rows(i).DefaultCellStyle.BackColor = Drawing.Color.SkyBlue
                End If
            Next

            MessageBox.Show("Finish checking. Error Line Numbers: " & err, "Warning")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
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
    '            If objlock.JCodeLocked1 = False Or objlock.JCodeLocked2 = False Or objlock.JCodeLocked3 = False Then
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
    '            If objUpdate.OutMter = True Then
    '                MessageBox.Show("Already exists", "Insert StockWS")
    '            Else
    '                cls.InsertStock(dtpOrderDate.Value.ToString("yyyyMMdd"), "OutMter")
    '                objUpdate.OutMter = True
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
    '            cls.InsertStock(dtpOrderDate.Value.ToString("yyyyMMdd"), "OutMter")
    '            objUpdate.OutMter = True
    '            nvd.Update(objUpdate)
    '            MessageBox.Show("Insert successful", "Insert StockWS")
    '            mnuInsertStock.Enabled = False
    '        End If
    '        nvd.Commit()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Insert OutMter")
    '        nvd.RollBack()
    '    End Try
    'End Sub

    Private Sub mnuEdit_Click(sender As System.Object, e As System.EventArgs) Handles mnuEdit.Click
        If cls.checkUser Then
            Edit = True
            gridD.Columns("ECode").ReadOnly = False
            gridD.Columns("JCode").ReadOnly = False
            gridD.Columns("SubPrcName").ReadOnly = False
            gridD.Columns("Qty1").ReadOnly = False
            gridD.Columns("Qty2").ReadOnly = False
            gridD.Columns("Qty3").ReadOnly = False
            gridD.Columns("Adjust").ReadOnly = False
        End If
    End Sub

    Private Sub mnuNJCStock_Click(sender As System.Object, e As System.EventArgs) Handles mnuNJCStock.Click
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@day", dtpOrderDate.Value.ToString("yyyyMMdd"))
        ExportEXCEL(nvd.ExecuteStoreProcedureTB("sp_PCM_NJCStock", para))
    End Sub

    Private Sub mnuExportSum_Click(sender As System.Object, e As System.EventArgs) Handles mnuExportSum.Click
        Dim sfDlg As New SaveFileDialog()
        sfDlg.DefaultExt = ".xlsx"
        sfDlg.Filter = "Excel 2007 file(.xlsx)|*.xlsx"
        sfDlg.FileName = String.Format("PhieuSoanHang lần 1 ({0}).xlsx", DateTime.Now.ToString("dd.MM.yyyy"))

        sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\6.KIỂM SOÁT NHẬP XUẤT TỒN KHO HÀNG VẬT TƯ\4. Phieu soan hang moi\THÁNG {0}\{1}\",
                                               DateTime.Now.ToString("MM"),
                                               DateTime.Now.ToString("dd.MM.yyyy"))
        If rdoEx2.Checked Then
            sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\6.KIỂM SOÁT NHẬP XUẤT TỒN KHO HÀNG VẬT TƯ\4. Phieu soan hang moi\THÁNG {0}\{1}\PhieuSoanHang lần 2 ({1})\",
                                               DateTime.Now.ToString("MM"),
                                               DateTime.Now.ToString("dd.MM.yyyy"))
            sfDlg.FileName = String.Format("PhieuSoanHang lần 2 ({0}).xlsx", DateTime.Now.ToString("dd.MM.yyyy"))
        ElseIf rdoEx3.Checked Then
            sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\6.KIỂM SOÁT NHẬP XUẤT TỒN KHO HÀNG VẬT TƯ\4. Phieu soan hang moi\THÁNG {0}\{1}\PhieuSoanHang lần 3 ({1})\",
                                               DateTime.Now.ToString("MM"),
                                               DateTime.Now.ToString("dd.MM.yyyy"))
            sfDlg.FileName = String.Format("PhieuSoanHang lần 3 ({0}).xlsx", DateTime.Now.ToString("dd.MM.yyyy"))
        End If

        If sfDlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@day", dtpOrderDate.Value.ToString("yyyyMMdd"))
        para(1) = New SqlClient.SqlParameter("@condiUser", condiUser)
        para(2) = New SqlClient.SqlParameter("@MatCode", Trim(cboShowJCode.Text))

        Dim tbl As DataTable = nvd.ExecuteStoreProcedureTB("sp_PCM_ExportSumMter", para)


        Dim sqlSum As String = String.Format(" select m.JCode,max(m.[JEName]) as JEName ,max(m.[JVName]) as JVName, " +
                                             " Sum(isnull(m.Qty1,0)) Qty1, Sum(isnull(m.Qty2,0)+isnull(m.Adjust,0)) Qty2," +
                                             " Sum(isnull(m.Qty3,0)) Qty3,max(i.Position) as Position " +
                                            " from {0} m " +
                                            " left join LOC_ItemCode i on i.ItemCode =m.JCode " +
                                            " where " +
                                            " m.YMD = '{1}'  " +
                                            " AND m.JCode NOT LIKE 'J%'   " +
                                            " group by m.JCode  " +
                                            " order by m.JCode",
                                             PublicTable.Table_PCM_NotJCode,
                                            dtpOrderDate.Value.ToString("yyyyMMdd"),
                                            condiUser, Trim(cboShowJCode.Text))

        Dim tblSum As DataTable = nvd.FillDataTable(sqlSum)

        If Trim(cboShowJCode.Text) <> "NotJCode" Then
            ExportEXCEL(gridD)
            Exit Sub
        End If

        Dim lan As Integer = 0
        Dim SumTotal As Integer = 0

        If rdoEx1.Checked = True Then
            Dim column As String() = {"YMD", "DeptName", "PrcName", "JCode", "JEName", "JVName", "Unit", "Qty1", "Empty1", "Empty2", "Empty3", "DeptGSR"}
            tbl = tbl.DefaultView.ToTable(False, column)

            Dim columnSum As String() = {"JCode", "JEName", "JVName", "Qty1", "Position"}
            tblSum = tblSum.DefaultView.ToTable(False, columnSum)

            lan = 1
            SumTotal = tblSum.Compute("Sum(Qty1)", "")
        ElseIf rdoEx2.Checked = True Then
            Dim column As String() = {"YMD", "DeptName", "PrcName", "JCode", "JEName", "JVName", "Unit", "Qty2", "Empty1", "Empty2", "Empty3", "DeptGSR"}
            tbl = tbl.DefaultView.ToTable(False, column)

            Dim columnSum As String() = {"JCode", "JEName", "JVName", "Qty2", "Position"}
            tblSum = tblSum.DefaultView.ToTable(False, columnSum)

            lan = 2
            SumTotal = tblSum.Compute("Sum(Qty2)", "")
        ElseIf rdoEx3.Checked = True Then
            Dim column As String() = {"YMD", "DeptName", "PrcName", "JCode", "JEName", "JVName", "Unit", "Qty3", "Empty1", "Empty2", "Empty3", "DeptGSR"}
            tbl = tbl.DefaultView.ToTable(False, column)

            Dim columnSum As String() = {"JCode", "JEName", "JVName", "Qty3", "Position"}
            tblSum = tblSum.DefaultView.ToTable(False, columnSum)

            lan = 3
            SumTotal = tblSum.Compute("Sum(Qty3)", "")
        Else
            MessageBox.Show("Chọn lần xuất kho")
            Exit Sub
        End If

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        'Copy template
        clsApplication.UpLoadFile(clsApplication.FileTmp + "PhieuSoanHang.xlsx", sfDlg.FileName, True)

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim wRange As Excel.Range

        'Open file
        'app.DisplayAlerts = False
        myExcel.Visible = True

        If (File.Exists(sfDlg.FileName)) Then
            wbook = myExcel.Workbooks.Open(sfDlg.FileName)
        Else
            ShowWarning("Thiếu template export !")
            Return
        End If

        wSheet = CType(wbook.Sheets("PhieuSoanHang"), Excel.Worksheet)
        wSheet.Activate()
        'myExcel.StandardFont = "Times New Roman"
        'myExcel.StandardFontSize = 9

        wSheet.Cells(5, 1) = "PHIẾU SOẠN HÀNG LẦN " & lan

        'Detail
        Dim i, j As Integer
        Dim rows As Integer = tbl.Rows.Count - 1
        Dim cols As Integer = tbl.Columns.Count - 1
        Dim iRow As Integer = 0

        Dim DataArray(rows, cols) As Object
        For i = 0 To rows
            For j = 0 To cols
                If tbl.Rows(i).Item(j) Is System.DBNull.Value Then Continue For
                If String.IsNullOrEmpty(tbl.Rows(i).Item(j)) Then
                Else
                    If tbl.Rows(i).Item(j).GetType().Name = "String" Then
                        DataArray(i, j) = "'" + tbl.Rows(i).Item(j).ToString()
                    Else
                        DataArray(i, j) = tbl.Rows(i).Item(j)
                    End If
                End If
            Next
            wRange = wSheet.Range(wSheet.Cells(i + 11, 1), wSheet.Cells(i + 11, 12))
            wRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
            iRow = i + 10
        Next

        If DataArray IsNot Nothing Then
            myExcel.Range("A10").Resize(rows + 1, cols + 1).Value = DataArray
        End If

        'Delete dòng thừa
        wRange = wSheet.Range(wSheet.Cells(iRow + 1, 1), wSheet.Cells(iRow + 2, 12))
        wRange.Delete()
        'End Detail

        'sheet tổng
        wSheet = CType(wbook.Sheets("Sum"), Excel.Worksheet)
        wSheet.Activate()
        'myExcel.StandardFont = "Times New Roman"
        'myExcel.StandardFontSize = 9

        'Detail
        i = 0
        j = 0
        rows = tblSum.Rows.Count - 1
        cols = tblSum.Columns.Count - 1
        iRow = 0

        Dim DataArraySum(rows, cols) As Object
        For i = 0 To rows
            For j = 0 To cols
                If tblSum.Rows(i).Item(j) Is System.DBNull.Value Then Continue For
                If String.IsNullOrEmpty(tblSum.Rows(i).Item(j)) Then
                Else
                    If tblSum.Rows(i).Item(j).GetType().Name = "String" Then
                        DataArraySum(i, j) = "'" + tblSum.Rows(i).Item(j).ToString()
                    Else
                        DataArraySum(i, j) = tblSum.Rows(i).Item(j)
                    End If
                End If
            Next
            wRange = wSheet.Range(wSheet.Cells(i + 4, 1), wSheet.Cells(i + 4, 12))
            wRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
            iRow = i + 3
        Next

        If DataArray IsNot Nothing Then
            myExcel.Range("A3").Resize(rows + 1, cols + 1).Value = DataArraySum
        End If

        'Delete dòng thừa
        wRange = wSheet.Range(wSheet.Cells(iRow + 1, 1), wSheet.Cells(iRow + 2, 12))
        wRange.Delete()

        CType(wSheet.Cells(iRow + 1, 4), Excel.Range).Formula = String.Format("=sum(D3:D{0})", iRow)
        'End Detail

        wbook.Save()

        ShowSuccess()

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
    End Sub

    Private Sub gridD_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellValueChanged
        If IsView Then Exit Sub
        If e.RowIndex = -1 Then Return
        Try
            Dim lockTime As New PCM_LockDay
            lockTime.YMD_K = dtpOrderDate.Value.ToString("yyyyMMdd")
            nvd.GetObject(lockTime)

            If chkLocked1.Checked <> lockTime.JCodeLocked1 Then
                chkLocked1.Checked = lockTime.JCodeLocked1
            End If
            If chkLocked2.Checked <> lockTime.JCodeLocked2 Then
                chkLocked2.Checked = lockTime.JCodeLocked2
            End If

            If chkLocked3.Checked <> lockTime.JCodeLocked3 Then
                chkLocked3.Checked = lockTime.JCodeLocked3
            End If

            If chkLocked1.Checked = True And
                chkLocked2.Checked = True And
                chkLocked3.Checked = True And Edit = False Then Exit Sub

            If e.ColumnIndex = gridD.Columns("JCode").Index _
            Or e.ColumnIndex = gridD.Columns("ECode").Index _
            Or e.ColumnIndex = gridD.Columns("SubPrcName").Index Then
                Exit Sub
            End If

            If gridD.CurrentRow.Cells(e.ColumnIndex).[ReadOnly] Then Exit Sub

            If e.ColumnIndex = gridD.Columns("Qty1").Index Or
                e.ColumnIndex = gridD.Columns("Qty2").Index Or
                e.ColumnIndex = gridD.Columns("Qty3").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) Or
                    IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) Then
                    ShowWarning("Vui lòng nhập JCode & SubPrcName")
                    Exit Sub
                End If
                Dim Qty1 As Decimal = IIf(gridD.CurrentRow.Cells("Qty1").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("Qty1").Value)
                Dim Qty2 As Decimal = IIf(gridD.CurrentRow.Cells("Qty2").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("Qty2").Value)
                Dim Qty3 As Decimal = IIf(gridD.CurrentRow.Cells("Qty3").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("Qty3").Value)
                Dim QtyNow As Decimal = IIf(gridD.CurrentRow.Cells(e.ColumnIndex).Value Is DBNull.Value, 0, gridD.CurrentRow.Cells(e.ColumnIndex).Value)

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim MinQty As Decimal = gridD.CurrentRow.Cells("MinQty").Value
                If (QtyNow Mod MinQty) <> 0 Then
                    ShowWarning("Số lượng đặt phải là bội số của MinQty")
                    Exit Sub
                End If

                Dim obj As New PCM_NotJCode()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                nvd.GetObject(obj)

                'NormWeek
                Dim Total As Decimal
                Dim objMaster As New PCM_MterNotJCode
                objMaster.ECode_K = obj.ECode_K
                objMaster.JCode_K = obj.JCode_K
                objMaster.SubPrcName_K = obj.SubPrcName_K
                nvd.GetObject(objMaster)
                If objMaster.NormWeek = 0 Then
                    ShowWarning("Nguyên liệu này không có định mức đế xuất.")
                    Return
                End If
                Dim sumQuantity As Decimal = NormWeek(obj.JCode_K, obj.ECode_K, obj.SubPrcName_K)
                Dim sumQuantityMonth As Decimal = MonthStd(obj.JCode_K, obj.ECode_K, obj.SubPrcName_K)
                If objMaster.NormWeek > 0 Then
                    If (sumQuantity + QtyNow) > objMaster.NormWeek Then
                        If CurrentUser.SortSection <> "LO" Then
                            ShowWarning("Tuần này đã xuất kho " & sumQuantity & " thêm " & QtyNow & " là vượt định mức tuần " & objMaster.NormWeek)
                        End If
                        Exit Sub
                    End If
                    If (sumQuantityMonth + QtyNow) > objMaster.MonthStd And objMaster.MonthStd > 0 Then
                        If CurrentUser.SortSection <> "LO" Then
                            ShowWarning("Tháng này đã xuất kho " & sumQuantityMonth & " thêm " & QtyNow & " là vượt định mức tuần " & objMaster.NormWeek)
                        End If
                        Exit Sub
                    End If
                End If
                Dim TotalStd = IIf(gridD.CurrentRow.Cells("TotalDtbtQty").Value Is DBNull.Value, 0,
                                   gridD.CurrentRow.Cells("TotalDtbtQty").Value)
                Total = Qty1 + Qty2 + Qty3
                If Total > TotalStd Then
                    ShowWarning("(Qty1 + Qty2 + Qty3) > TotalDtbtQty")
                    Exit Sub
                End If

                Dim StockRemain As Decimal = stock(obj.JCode_K) - sumOut(obj.YMD_K, obj.ECode_K, obj.JCode_K, obj.SubPrcName_K)
                If StockRemain < Total Then
                    ShowWarning("Số lượng xuất lớn hơn tồn hiện tại Stock = " & StockRemain & ", (Qty1 + Qty2 + Qty3) = " & (Qty1 + Qty2 + Qty3))
                    Exit Sub
                End If

                If avalQty < Total Then
                    MessageBox.Show("Yêu cầu xuất kho bao gồm cả nguyên liệu chưa kiểm đầu vào, nếu kết quả kiểm đầu vào của nguyên liệu chưa kiểm đầu vào NG thì sẽ không đủ lượng xuất kho theo yêu cầu", "Input Qty1")
                End If

                obj.Qty1 = Qty1
                obj.Qty2 = Qty2
                obj.Qty3 = Qty3
                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                obj.Time1Date = DateTime.Now

                nvd.Update(obj)
                Dim Adjust = IIf(gridD.CurrentRow.Cells("Adjust").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("Adjust").Value)
                gridD.CurrentRow.Cells("TotalQty").Value = Total + Adjust
            End If


            If e.ColumnIndex = gridD.Columns("Adjust").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) Then
                    ShowWarning("Bạn chưa nhập JCode & SubPrcName")
                    Exit Sub
                End If
                Dim _Adjust As Decimal
                If gridD.CurrentRow.Cells("Adjust").Value Is DBNull.Value Then
                    _Adjust = 0
                Else
                    _Adjust = gridD.CurrentRow.Cells("Adjust").Value
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim MinQty As Decimal = 0
                If IsNumeric(gridD.CurrentRow.Cells("MinQty").Value) Then
                    MinQty = gridD.CurrentRow.Cells("MinQty").Value
                End If
                If MinQty > 0 Then
                    If (_Adjust Mod MinQty) <> 0 Then
                        ShowWarning("Số lượng phải là bội số của MinQty")
                        Exit Sub
                    End If
                End If

                Dim obj As New PCM_NotJCode()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                nvd.GetObject(obj)
                Dim FirstAdjustQty As Decimal = obj.Adjust
                obj.Adjust = _Adjust
                nvd.Update(obj)
                gridD.CurrentRow.Cells("TotalQty").Value = IIf(gridD.CurrentRow.Cells("Qty1").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("Qty1").Value) _
                + IIf(gridD.CurrentRow.Cells("Qty2").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("Qty2").Value) _
                + IIf(gridD.CurrentRow.Cells("Qty3").Value Is DBNull.Value, 0, gridD.CurrentRow.Cells("Qty3").Value) + obj.Adjust
                gridD.CurrentRow.Cells("Adjust").Value = _Adjust

            End If

            If e.ColumnIndex = gridD.Columns("ActReceive").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) Then
                    MessageBox.Show("Bạn chưa nhập JCode & SubPrcName", "Input ActReceive")
                    Exit Sub
                End If
                Dim _ActReceive As Decimal
                If gridD.CurrentRow.Cells("ActReceive").Value Is DBNull.Value Then
                    _ActReceive = 0
                Else
                    _ActReceive = gridD.CurrentRow.Cells("ActReceive").Value
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_NotJCode()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                nvd.GetObject(obj)
                obj.ActReceive = _ActReceive

                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                nvd.Update(obj)
            End If

            If e.ColumnIndex = gridD.Columns("Note").Index Or
                e.ColumnIndex = gridD.Columns("NgaySuDung").Index Then
                If IsDBNull(gridD.CurrentRow.Cells("JCode").Value) Or IsDBNull(gridD.CurrentRow.Cells("SubPrcName").Value) Then
                    MessageBox.Show("Input JCode and SubPrcName", "Input Note")
                    Exit Sub
                End If

                If gridD.CurrentRow.Cells("YMD").Value Is DBNull.Value Then Exit Sub

                Dim obj As New PCM_NotJCode()
                obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                nvd.GetObject(obj)
                If gridD.CurrentRow.Cells("Note").Value IsNot DBNull.Value Then
                    obj.Note = gridD.CurrentRow.Cells("Note").Value
                Else
                    obj.Note = ""
                End If
                If gridD.CurrentRow.Cells("NgaySuDung").Value IsNot DBNull.Value Then
                    obj.NgaySuDung = gridD.CurrentRow.Cells("NgaySuDung").Value
                Else
                    obj.NgaySuDung = Nothing
                End If
                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                nvd.Update(obj)
            End If
        Catch ex As Exception
            ShowError(ex, "CellValueChanged", Name)
        End Try
    End Sub

    Private Sub mnuTLImportLemon_Click(sender As System.Object, e As System.EventArgs) Handles mnuTLImportLemon.Click
        If txtSoPhieu.Text = "" Then
            ShowWarning("Bạn chưa nhập số phiếu !")
            Return
        End If
        Dim sfDlg As New SaveFileDialog()
        sfDlg.DefaultExt = ".xls"
        sfDlg.Filter = "Excel 2007 file(.xlsx)|*.xlsx| Excel 2003 file(.xls)|*.xls"
        sfDlg.FileName = "Template Import Lemon.xls"
        sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\6.KIỂM SOÁT NHẬP XUẤT TỒN KHO HÀNG VẬT TƯ\5. Templet Lemon\NĂM {0}\Tháng {1}\{2}\",
                                               Today.Year,
                                               Today.ToString("MM"),
                                               Today.ToString("dd.MM.yyyy"))
        If sfDlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub


        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")


        'Copy template
        clsApplication.UpLoadFile(clsApplication.FileTmp + "TemplateImportLemon.xls",
                                   sfDlg.FileName, True)
        'Variance
        Dim app As New Excel.Application
        Dim workBook As Excel.Workbook
        Dim workSheet As Excel.Worksheet
        Dim workRange As Excel.Range
        'Open file
        If (File.Exists(sfDlg.FileName)) Then
            workBook = app.Workbooks.Open(sfDlg.FileName)
        Else
            workBook = app.Workbooks.Add(Type.Missing)
        End If
        workSheet = CType(workBook.Sheets(1), Excel.Worksheet)
        workSheet.Name = "TemplateImportLemon"
        app.Visible = True
        'Write data 
        'Detail
        Dim iRow As Integer = 13
        workSheet.Cells(iRow, 3) = String.Format("X/{0}/{1}/{2}",
                                                 DateTime.Now.ToString("MM"),
                                                 DateTime.Now.ToString("yy"),
                                                 txtSoPhieu.Text)
        If rdoEx2.Checked Then
            For Each r As DataGridViewRow In gridD.Rows
                If r.IsNewRow Then Continue For
                If (r.Cells(ColQty).Value > 0 Or r.Cells("Adjust").Value > 0) And Not r.Cells("JCode").Value.ToString.Contains("J") Then
                    workSheet.Cells(iRow, 1) = ""
                    workSheet.Cells(iRow, 2) = "X"
                    workSheet.Cells(iRow, 4) = dtpOrderDate.Value.Date
                    workSheet.Cells(iRow, 5) = r.Cells("PrcName").Value
                    workSheet.Cells(iRow, 8) = "USD"
                    workSheet.Cells(iRow, 9) = 1
                    workSheet.Cells(iRow, 10) = "PB"
                    workSheet.Cells(iRow, 11) = r.Cells("DeptName").Value
                    workSheet.Cells(iRow, 12) = "LO0006"
                    workSheet.Cells(iRow, 13) = "K.NDV"
                    workSheet.Cells(iRow, 14) = ""
                    workSheet.Cells(iRow, 15) = "'" & r.Cells("JCode").Value
                    workSheet.Cells(iRow, 16) = ""
                    workSheet.Cells(iRow, 17) = ""
                    workSheet.Cells(iRow, 18) = ""
                    workSheet.Cells(iRow, 19) = r.Cells(ColQty).Value + r.Cells("Adjust").Value

                    workSheet.Cells(iRow, 33) = r.Cells("DeptGSR").Value
                    iRow += 1
                End If
            Next
        Else
            For Each r As DataGridViewRow In gridD.Rows
                If r.IsNewRow Then Continue For
                If r.Cells(ColQty).Value > 0 And Not r.Cells("JCode").Value.ToString.Contains("J") Then
                    workSheet.Cells(iRow, 1) = ""
                    workSheet.Cells(iRow, 2) = "X"
                    workSheet.Cells(iRow, 4) = dtpOrderDate.Value.Date
                    workSheet.Cells(iRow, 5) = r.Cells("PrcName").Value
                    workSheet.Cells(iRow, 8) = "USD"
                    workSheet.Cells(iRow, 9) = 1
                    workSheet.Cells(iRow, 10) = "PB"
                    workSheet.Cells(iRow, 11) = r.Cells("DeptName").Value
                    workSheet.Cells(iRow, 12) = "LO0006"
                    workSheet.Cells(iRow, 13) = "K.NDV"
                    workSheet.Cells(iRow, 14) = ""
                    workSheet.Cells(iRow, 15) = "'" & r.Cells("JCode").Value
                    workSheet.Cells(iRow, 16) = ""
                    workSheet.Cells(iRow, 17) = ""
                    workSheet.Cells(iRow, 18) = ""
                    workSheet.Cells(iRow, 19) = r.Cells(ColQty).Value
                    workSheet.Cells(iRow, 33) = r.Cells("DeptGSR").Value
                    iRow += 1
                End If
            Next
        End If
        'Footer

        'workRange = workSheet.Range(workSheet.Cells(iRow + 2, 6), workSheet.Cells(iRow + 3, 6))
        'workRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'workRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        'Set format
        workRange = workSheet.Range(workSheet.Cells(12, 1), workSheet.Cells(iRow - 1, 33))
        workRange.Borders.Color = ColorTranslator.ToWin32(Color.Black)
        workRange.Borders.Weight = Excel.XlBorderWeight.xlThin
        'Detail 
        'Save file
        app.DisplayAlerts = False
        workBook.Save()

        'Release all objects
        GC.Collect()
        GC.WaitForPendingFinalizers()
        Marshal.FinalReleaseComObject(workRange)
        Marshal.FinalReleaseComObject(workSheet)
        Marshal.FinalReleaseComObject(workBook)
        Marshal.FinalReleaseComObject(app)

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
    End Sub

    Private Sub rdoEx1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoEx1.CheckedChanged
        If rdoEx1.Checked Then
            ColQty = "Qty1"
        End If
    End Sub

    Private Sub rdoEx2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoEx2.CheckedChanged
        If rdoEx2.Checked Then
            ColQty = "Qty2"
        End If
    End Sub

    Private Sub rdoEx3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoEx3.CheckedChanged
        If rdoEx3.Checked Then
            ColQty = "Qty3"
        End If
    End Sub

    Private Sub gridD_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles gridD.DataBindingComplete
        Dim mQty1 As Decimal = 0
        Dim mQty2 As Decimal = 0
        Dim mQty3 As Decimal = 0
        Dim mQtyAd As Decimal = 0

        For Each r As DataGridViewRow In gridD.Rows
            If IsNumeric(r.Cells(Qty1.Name).Value) Then
                mQty1 += r.Cells(Qty1.Name).Value
            End If
            If IsNumeric(r.Cells(Qty2.Name).Value) Then
                mQty2 += r.Cells(Qty2.Name).Value
            End If
            If IsNumeric(r.Cells(Qty3.Name).Value) Then
                mQty3 += r.Cells(Qty3.Name).Value
            End If
            If IsNumeric(r.Cells(Adjust.Name).Value) Then
                mQtyAd += r.Cells(Adjust.Name).Value
            End If
        Next

        tsTotal1.Text = mQty1.ToString("N0")
        tsTotal2.Text = mQty2.ToString("N0")
        tsTotal3.Text = mQty3.ToString("N0")

    End Sub
End Class