Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports DataGridViewAutoFilter

Imports System.Windows.Forms
Imports System.Text
Imports vb = Microsoft.VisualBasic
Imports System.Globalization
Imports System.Drawing

Public Class FrmTrayAndU00 : Inherits DevExpress.XtraEditors.XtraForm
    Dim dbFpics As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim param(1) As SqlClient.SqlParameter
    Dim _cellClick As Integer = 0
    Dim ECodeChanged As String = ""
    Dim PdCodeChanged As String = ""
    Dim getPd As Boolean = False
    Dim clickSearck As Boolean = False


    Sub CheckJCode()
        Dim sqlCheck As String = String.Format("SELECT [ECode],[PdCode],CC,count([JCode]) as SL " +
                                             " FROM [PCM_MterTrayU00] " +
                                             " where XuatKho='1'" +
                                             " group by [ECode],[PdCode],CC" +
                                             " having count([JCode])>1 ")
        Dim dtCheck As DataTable = _db.FillDataTable(sqlCheck)
        If dtCheck.Rows.Count = 0 Then
            lblStatusJCode.Text = "OK"
        Else
            lblStatusJCode.Text = dtCheck.Rows(0).Item("ECode") & " - " & dtCheck.Rows(0).Item("PdCode")
        End If
    End Sub

    Private Sub FrmCreateDepartment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If

        If e.KeyCode = Keys.S And e.Control And mnuSave.Enabled Then
            mnuSave.PerformClick()
        End If
    End Sub

#Region "Form event"

    Private Sub txtECode_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtECode.Enter
        PanelSearch.Visible = True
        ECodeChanged = Trim(txtECode.Text)
        SetColorEnter(txtECode)
    End Sub
    Private Sub txtECode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtECode.Leave
        txtPrcName.Text = ""
        PanelSearch.Visible = False
        SetColorLeave(txtECode)
    End Sub

    Private Sub cboSubPrc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubPrc.Enter
        SetColorEnter(cboSubPrc)
    End Sub
    Private Sub cboSubPrc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubPrc.Leave
        SetColorLeave(cboSubPrc)
    End Sub

    Private Sub txtPdCode_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPdCode.Enter
        PdCodeChanged = Trim(txtPdCode.Text)
        SetColorEnter(txtPdCode)
    End Sub
    Private Sub txtPdCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPdCode.Leave
        SetColorLeave(txtPdCode)
    End Sub

    Private Sub txtJCode_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJCode.Enter
        SetColorEnter(txtJCode)
    End Sub
    Private Sub txtJCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJCode.Leave
        SetColorLeave(txtJCode)
    End Sub

    Private Sub txtJEName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJEName.Enter
        SetColorEnter(txtJEName)
    End Sub
    Private Sub txtJEName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJEName.Leave
        SetColorLeave(txtJEName)
    End Sub

    Private Sub txtJVName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJVName.Enter
        SetColorEnter(txtJVName)
    End Sub
    Private Sub txtJVName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJVName.Leave
        SetColorLeave(txtJVName)
    End Sub

    Private Sub txtUnitLot_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitLot.Enter
        SetColorEnter(txtUnitLot)
    End Sub
    Private Sub txtUnitLot_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitLot.Leave
        SetColorLeave(txtUnitLot)
    End Sub

    Private Sub txtUnit_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnit.Enter
        SetColorEnter(txtUnit)
    End Sub
    Private Sub txtUnit_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnit.Leave
        SetColorLeave(txtUnit)
    End Sub

    Private Sub txtMinQty_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMinQty.Enter
        SetColorEnter(txtMinQty)
    End Sub
    Private Sub txtMinQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMinQty.Leave
        SetColorLeave(txtMinQty)
    End Sub

    Private Sub txtStdDtbtQty_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStdDtbtQty.Enter
        SetColorEnter(txtStdDtbtQty)
    End Sub
    Private Sub txtStdDtbtQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStdDtbtQty.Leave
        SetColorLeave(txtStdDtbtQty)
    End Sub

    Private Sub txtAddDtbtQty_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddDtbtQty.Enter
        SetColorEnter(txtAddDtbtQty)
    End Sub
    Private Sub txtAddDtbtQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddDtbtQty.Leave
        SetColorLeave(txtAddDtbtQty)
    End Sub
#End Region

    Dim dtAll As DataTable
    Dim dtSearch As DataTable
    Private Sub mnuShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAll.Click
        Dim sql As String = String.Format(" select GroupCode, ECode, PdCode, Cc, JCode, PrcName, SubPrcName, " +
                                          " JEName, JVName, UnitLot,XuatKho,Note, Unit, MinQty, StdDtbtQty," +
                                          " AddDtbtQty,[CreateDate],[CreateUser] " +
                                          " from {0} order by Old, ECode ",
                                          PublicTable.Table_PCM_MterTrayU00)
        dtAll = _db.FillDataTable(sql)
        Dim bd As New BindingSource
        bd.DataSource = dtAll
        gridD.DataSource = bd
        bnGrid.BindingSource = bd

        Dim sqlSearch As String = String.Format("SELECT  DISTINCT " +
        "PrcName, " +
        "ECode, " +
        "EName " +
        "FROM {0} " +
        "ORDER BY PrcName , " +
        "ECode", PublicTable.Table_PCM_Dept)

        dtSearch = _db.FillDataTable(sqlSearch)
        Dim bdSearch As New BindingSource
        bdSearch.DataSource = dtSearch
        gridSearch.DataSource = bdSearch

        txtJCode.Focus()

        CheckJCode()

        getPd = False
    End Sub

    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        txtECode.Text = ""
        cboSubPrc.Text = ""
        cboSubPrc.DataSource = Nothing
        txtPdCode.Text = ""
        cboCc.DataSource = Nothing
        txtJCode.Text = ""
        txtJEName.Text = ""
        txtJVName.Text = ""
        txtUnitLot.Text = ""
        txtUnit.Text = ""
        txtMinQty.Text = ""
        txtStdDtbtQty.Text = ""
        txtAddDtbtQty.Text = ""
        txtXuatKho.Text = "1"
        txtJCode.Focus()
        _cellClick = 0
        mnuEdit.Enabled = True
    End Sub

    Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
        Try
            _db.BeginTransaction()
            Dim bs As New BindingSource()
            bs = gridD.DataSource

            Dim obj As New PCM_MterTrayU00()
            If Trim(txtECode.Text) = "" Then
                MessageBox.Show("Input Employee Code!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                obj.ECode_K = Trim(txtECode.Text)
            End If

            If IsDBNull(cboSubPrc.SelectedValue) Then
                MessageBox.Show("Input Sub Process!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf String.IsNullOrEmpty(cboSubPrc.SelectedValue) Then
                MessageBox.Show("Input Sub Process!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                obj.SubPrcName_K = cboSubPrc.SelectedValue
            End If

            If Trim(txtPdCode.Text) = "" Then
                MessageBox.Show("Input PdCode!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                obj.PdCode_K = Trim(txtPdCode.Text)
            End If

            If IsDBNull(cboSubPrc.SelectedValue) Then
                MessageBox.Show("Input Cc!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _db.CloseConnect()
                Exit Sub
            ElseIf String.IsNullOrEmpty(cboSubPrc.SelectedValue) Then
                MessageBox.Show("Input Cc!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _db.CloseConnect()
                Exit Sub
            Else
                obj.Cc_K = cboCc.SelectedValue
            End If

            If Trim(txtJCode.Text) = "" Then
                MessageBox.Show("Input JCode!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _db.CloseConnect()
                Exit Sub
            Else
                obj.JCode_K = UCase(Trim(txtJCode.Text))
            End If

            obj.JEName = Trim(txtJEName.Text)
            obj.JVName = Trim(txtJVName.Text)
            If IsNumeric(Trim(txtUnitLot.Text)) Then
                obj.UnitLot = Trim(txtUnitLot.Text)
            End If
            obj.Unit = Trim(txtUnit.Text)
            If IsNumeric(Trim(txtMinQty.Text)) Then
                obj.MinQty = Trim(txtMinQty.Text)
            End If

            If IsNumeric(Trim(txtStdDtbtQty.Text)) Then
                obj.StdDtbtQty = Trim(txtStdDtbtQty.Text)
            End If

            If IsNumeric(Trim(txtAddDtbtQty.Text)) Then
                obj.AddDtbtQty = Trim(txtAddDtbtQty.Text)
            End If
            obj.XuatKho = txtXuatKho.Text
            obj.Note = txtNote.Text

            Dim sqlPrcName As String = String.Format("select DeptCode, PrcName from {0} where ECode = '{1}' and SubPrcName = '{2}'", PublicTable.Table_PCM_Dept, obj.ECode_K, obj.SubPrcName_K)
            Dim dt As DataTable = _db.FillDataTable(sqlPrcName)
            If dt.Rows.Count <> 0 Then
                obj.PrcName = dt.Rows(0).Item("PrcName")
                obj.GroupCode = vb.Left(dt.Rows(0).Item("DeptCode"), 2) + "1"
            End If

            If _db.ExistObject(obj) Then
                If ShowQuestionUpdate() = DialogResult.No Then
                    _db.CloseConnect()
                    Return
                End If

                obj.UpdateDate = DateTime.Now
                obj.UpdateUser = CurrentUser.UserID
                _db.Update(obj)
                MsgBox("Update successfully.", MsgBoxStyle.OkOnly, "Update")

                Dim row As DataRowView = DirectCast(bs.Current, DataRowView)
                row("GroupCode") = obj.GroupCode
                row("ECode") = obj.ECode_K
                row("PdCode") = obj.PdCode_K
                row("Cc") = obj.Cc_K
                row("JCode") = obj.JCode_K
                row("PrcName") = obj.PrcName
                row("SubPrcName") = obj.SubPrcName_K
                row("JEName") = obj.JEName
                row("JVName") = obj.JVName
                row("UnitLot") = obj.UnitLot
                row("Unit") = obj.Unit
                row("MinQty") = obj.MinQty
                row("StdDtbtQty") = obj.StdDtbtQty
                row("AddDtbtQty") = obj.AddDtbtQty
                bs.ResetCurrentItem()
            Else
                If ShowQuestionSave() = DialogResult.No Then
                    _db.CloseConnect()
                    Return
                End If
                obj.XuatKho = "1"
                obj.CreateDate = DateTime.Now
                obj.CreateUser = CurrentUser.UserID
                _db.Insert(obj)
                ShowSuccess()

                If getPd Then
                    Dim row As DataRowView = DirectCast(bs.Current, DataRowView)
                    row("GroupCode") = obj.GroupCode
                    row("ECode") = obj.ECode_K
                    row("PdCode") = obj.PdCode_K
                    row("Cc") = obj.Cc_K
                    row("JCode") = obj.JCode_K
                    row("PrcName") = obj.PrcName
                    row("SubPrcName") = obj.SubPrcName_K
                    row("JEName") = obj.JEName
                    row("JVName") = obj.JVName
                    row("UnitLot") = obj.UnitLot
                    row("Unit") = obj.Unit
                    row("MinQty") = obj.MinQty
                    row("StdDtbtQty") = obj.StdDtbtQty
                    row("AddDtbtQty") = obj.AddDtbtQty
                    bs.ResetCurrentItem()
                Else
                    Dim dtTemp As DataTable = DirectCast(bs.DataSource, DataTable)
                    Dim row As DataRow = dtTemp.NewRow()
                    row("GroupCode") = obj.GroupCode
                    row("ECode") = obj.ECode_K
                    row("PdCode") = obj.PdCode_K
                    row("Cc") = obj.Cc_K
                    row("JCode") = obj.JCode_K
                    row("PrcName") = obj.PrcName
                    row("SubPrcName") = obj.SubPrcName_K
                    row("JEName") = obj.JEName
                    row("JVName") = obj.JVName
                    row("UnitLot") = obj.UnitLot
                    row("Unit") = obj.Unit
                    row("MinQty") = obj.MinQty
                    row("StdDtbtQty") = obj.StdDtbtQty
                    row("AddDtbtQty") = obj.AddDtbtQty
                    dtTemp.Rows.Add(row)
                End If

            End If

            mnuNew.PerformClick()
            txtJCode.Focus()

            Dim sqlUpdate As String = String.Format("update  [PCM_MterTrayU00] " +
                                                    " Set JEName = [ItemName]" +
                                                    " from  [10.153.1.30].[FPiCS-B03].[dbo].[t_ASMaterialItem] it " +
                                                    " where  it.ItemCode collate database_default=[PCM_MterTrayU00].JCode collate database_default ")
            _db.ExecuteNonQuery(sqlUpdate)
            _db.Commit()
            CheckJCode()
        Catch ex As Exception
            _db.RollBack()
            _db.CloseConnect()
            MessageBox.Show(ex.Message, "insert/update")
        End Try
    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        If gridD.RowCount > 0 Then
            ExportEXCELColumnName(gridD)
        End If
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        If gridD.Rows.Count = 0 Then Exit Sub

        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            For Each r As DataGridViewRow In gridD.SelectedRows
                Dim _obj As New PCM_MterTrayU00
                _obj.ECode_K = r.Cells("ECode").Value
                _obj.SubPrcName_K = r.Cells("SubPrcName").Value
                _obj.PdCode_K = r.Cells("PdCode").Value
                _obj.JCode_K = r.Cells("JCode").Value
                _obj.Cc_K = r.Cells("Cc").Value
                _db.Delete(_obj)
            Next
            mnuShowAll.PerformClick()
        End If
    End Sub

    Private Sub mnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSearch.Click
        Dim sql As String = String.Format(" select GroupCode, ECode, PdCode, Cc, JCode, PrcName, SubPrcName, JEName," +
                                          " JVName, UnitLot,XuatKho,Note, Unit, MinQty, StdDtbtQty, AddDtbtQty from {0} " +
                                          " Where ECode like '%{1}%' and PdCode like '%{2}%' and JCode like '%{3}%'",
                                          PublicTable.Table_PCM_MterTrayU00, Trim(txtECode.Text),
                                          Trim(txtPdCode.Text), Trim(txtJCode.Text))
        Dim bd As New BindingSource
        bd.DataSource = _db.FillDataTable(sql)
        gridD.DataSource = bd
    End Sub

    Private Sub gridD_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellClick
        If gridD.CurrentRow IsNot Nothing Then
            If _cellClick = 0 Then Exit Sub
            txtECode.Text = IIf(gridD.CurrentRow.Cells("ECode").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("ECode").Value)

            Dim ECode As String = Trim(txtECode.Text)
            Dim sql As String = String.Format("select SubPrcName from {0} where ECode = '{1}'", PublicTable.Table_PCM_Dept, ECode)
            Dim dt As DataTable = _db.FillDataTable(sql)
            cboSubPrc.DataSource = dt
            cboSubPrc.DisplayMember = "SubPrcName"
            cboSubPrc.ValueMember = "SubPrcName"
            cboSubPrc.SelectedValue = IIf(gridD.CurrentRow.Cells("SubPrcName").Value Is DBNull.Value, DBNull.Value, gridD.CurrentRow.Cells("SubPrcName").Value)

            Dim PdCode As String = IIf(gridD.CurrentRow.Cells("PdCode").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("PdCode").Value)
            txtPdCode.Text = PdCode

            Dim sqlCc As String = String.Format("SELECT  Distinct ComponentCode " +
            "FROM m_Component " +
            "WHERE   ProductCode = '{0}'", PdCode)
            Dim dtCc As DataTable = dbFpics.FillDataTable(sqlCc)
            cboCc.DataSource = dtCc
            cboCc.DisplayMember = "ComponentCode"
            cboCc.ValueMember = "ComponentCode"
            cboCc.SelectedValue = IIf(gridD.CurrentRow.Cells("Cc").Value Is DBNull.Value, -1, gridD.CurrentRow.Cells("Cc").Value)

            txtJCode.Text = IIf(gridD.CurrentRow.Cells("JCode").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("JCode").Value)
            txtJEName.Text = IIf(gridD.CurrentRow.Cells("JEName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("JEName").Value)
            txtJVName.Text = IIf(gridD.CurrentRow.Cells("JVName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("JVName").Value)
            txtUnitLot.Text = IIf(gridD.CurrentRow.Cells("UnitLot").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("UnitLot").Value)
            txtUnit.Text = IIf(gridD.CurrentRow.Cells("Unit").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("Unit").Value)
            txtMinQty.Text = IIf(gridD.CurrentRow.Cells("MinQty").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("MinQty").Value)
            txtStdDtbtQty.Text = IIf(gridD.CurrentRow.Cells("StdDtbtQty").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("StdDtbtQty").Value)
            txtAddDtbtQty.Text = IIf(gridD.CurrentRow.Cells("AddDtbtQty").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("AddDtbtQty").Value)
            txtXuatKho.Text = IIf(gridD.CurrentRow.Cells("XuatKho").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("XuatKho").Value)
            txtNote.Text = IIf(gridD.CurrentRow.Cells("Note").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("Note").Value)
        End If
    End Sub

    Private Sub FrmTrayAndU00_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'Dim sql As String = String.Format("select ECode, PdCode, JCode, PrcName, SubPrcName, JEName, JVName, UnitLot, Unit, MinQty, StdDtbtQty, AddDtbtQty " +
        '                                "from {0} where ECode = ''", PublicTable.Table_PCM_MterTrayU00)
        'Dim bd As New BindingSource
        'bd.DataSource = _db.FillDataTable(sql)
        'gridD.DataSource = bd
        mnuShowAll.PerformClick()
    End Sub

    Private Sub txtECode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtECode.Validating
        Dim ECode As String = Trim(txtECode.Text)
        If ECode = ECodeChanged Then
            If Not clickSearck Then
                Exit Sub
            End If
        End If
       
        Dim sql As String = String.Format("select SubPrcName from {0} where ECode = '{1}' and Old = 'False'", PublicTable.Table_PCM_Dept, ECode)
        Dim dt As DataTable = _db.FillDataTable(sql)
        cboSubPrc.DataSource = dt
        cboSubPrc.DisplayMember = "SubPrcName"
        cboSubPrc.ValueMember = "SubPrcName"

        clickSearck = False
    End Sub

   

    'Private Sub mnuUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUpdate.Click
    '    If _cellClick <> 1 Then Exit Sub
    '    Try
    '        Dim _ECodeOld As String
    '        Dim _SubPrcNameOld As String
    '        _ECodeOld = gridD.CurrentRow.Cells("ECode").Value
    '        _SubPrcNameOld = gridD.CurrentRow.Cells("SubPrcName").Value
    '        Dim _PrcName As String
    '        Dim sqlPrcName As String = String.Format("select PrcName from {0} where ECode = '{1}' and SubPrcName = '{2}'", PublicTable.Table_PCM_Dept, Trim(txtECode.Text), cboSubPrc.SelectedValue)
    '        Dim dt As DataTable = _db.FillDataTable(sqlPrcName)
    '        If dt.Rows.Count <> 0 Then
    '            _PrcName = dt.Rows(0).Item("PrcName")
    '        Else
    '            MessageBox.Show("ECode and SubPrcName do not exist", "ECode, SubPrcName")
    '            Exit Sub
    '        End If

    '        UpdateAll(_ECodeOld, _SubPrcNameOld, _PrcName, Trim(txtECode.Text), cboSubPrc.SelectedValue)
    '        MsgBox("Save successfully.", MsgBoxStyle.OkOnly, "Save")
    '        mnuNew.PerformClick()
    '        txtECode.Focus()
    '        mnuShowAll.PerformClick()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "insert/update")
    '    End Try
    'End Sub

    Sub UpdateAll(ByVal _ECodeOld As String, ByVal _SubPrcNameOld As String, ByVal _PrcName As String, ByVal _ECodeNew As String, ByVal _SubPrcNameNew As String)
        Dim sqlMterNotJCode As String = String.Format("Select ECode, SubPrcName, JCode, PdCode, Cc from {0} where ECode = '{1}' and SubPrcName = '{2}'", PublicTable.Table_PCM_MterTrayU00, _ECodeOld, _SubPrcNameOld)
        Dim dtMterNotJCode As DataTable = _db.FillDataTable(sqlMterNotJCode)
        If dtMterNotJCode.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To dtMterNotJCode.Rows.Count - 1
            Try
                _db.BeginTransaction()
                Dim obj As New PCM_MterTrayU00()
                obj.ECode_K = dtMterNotJCode.Rows(i).Item("ECode")
                obj.SubPrcName_K = dtMterNotJCode.Rows(i).Item("SubPrcName")
                obj.JCode_K = dtMterNotJCode.Rows(i).Item("JCode")
                obj.PdCode_K = dtMterNotJCode.Rows(i).Item("PdCode")
                obj.Cc_K = dtMterNotJCode.Rows(i).Item("Cc")
                _db.GetObject(obj)
                _db.Delete(obj)
                obj.ECode_K = _ECodeNew
                obj.SubPrcName_K = _SubPrcNameNew
                obj.Old = False
                obj.PrcName = _PrcName
                If _db.ExistObject(obj) Then
                    _db.Update(obj)
                Else
                    _db.Insert(obj)
                End If
                _db.Commit()
            Catch ex As Exception
                _db.RollBack()
                _db.CloseConnect()
                MessageBox.Show(ex.Message, "Update MterJCode")
            End Try
        Next
    End Sub

    Private Sub txtPdCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPdCode.TextChanged
        'If _cellClick = 1 Then Exit Sub
        'If dtAll Is Nothing Then
        '    Return
        'Else
        '    Dim dv As DataView = New DataView(dtAll)
        '    dv.RowFilter = "[PdCode] LIKE '%" + Trim(txtPdCode.Text) + "%'"
        '    Dim bd As New BindingSource()
        '    bd.DataSource = dv
        '    gridD.DataSource = bd
        '    bnGrid.BindingSource = bd
        'End If
    End Sub

    Private Sub txtJCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJCode.TextChanged
        'If _cellClick = 1 Then Exit Sub
        'If dtAll Is Nothing Then
        '    Return
        'Else
        '    Dim dv As DataView = New DataView(dtAll)
        '    dv.RowFilter = "[JCode] LIKE '%" + Trim(txtJCode.Text) + "%'"
        '    Dim bd As New BindingSource()
        '    bd.DataSource = dv
        '    gridD.DataSource = bd
        '    bnGrid.BindingSource = bd
        'End If
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        _cellClick = 1
        mnuEdit.Enabled = False
        gridD.Columns("XuatKho").ReadOnly = Not gridD.Columns("XuatKho").ReadOnly
        gridD.Columns("Note").ReadOnly = Not gridD.Columns("Note").ReadOnly
    End Sub

    Private Sub txtPdCode_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles txtPdCode.Validating
        Dim PdCode As String = Trim(txtPdCode.Text)
        If PdCode = PdCodeChanged Then Return
        Dim sql As String = String.Format("SELECT  Distinct ComponentCode " +
        "FROM m_Component " +
        "WHERE   ProductCode = '{0}'", PdCode)
        Dim dt As DataTable = dbFpics.FillDataTable(sql)
        cboCc.DataSource = dt
        cboCc.DisplayMember = "ComponentCode"
        cboCc.ValueMember = "ComponentCode"
    End Sub

    Private Sub nmuGetPd_Click(sender As System.Object, e As System.EventArgs) Handles nmuGetPd.Click
        Try
            txtECode.Text = ""
            txtPdCode.Text = "Clear"
            txtJCode.Text = ""
            mnuSearch.PerformClick()
            txtPdCode.Text = ""

            Dim StartDate As String = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd")
            Dim EndDate As String = DateTime.Now.ToString("yyyy-MM-dd")

            Dim sqlNewPdCode As String = String.Format("SELECT DISTINCT " +
            "ProductCode " +
            "FROM m_ComponentProcessFactory " +
            "WHERE LEFT(ProductCode, 1) != '7' " +
            "AND EntryDate >= '" & StartDate & "' " +
            "AND EntryDate <= '" & EndDate & "' " +
            "AND FactoryCode = '03' " +
            "ORDER BY ProductCode", PublicTable_FPICS.Table_m_Component)
            Dim dtNewPdCode As DataTable = dbFpics.FillDataTable(sqlNewPdCode)
            If dtNewPdCode.Rows.Count <> 0 Then
                Me.Cursor = Cursors.WaitCursor
                Dim bs As New BindingSource()
                bs = gridD.DataSource
                Dim dtTemp As DataTable = DirectCast(bs.DataSource, DataTable)

                For p As Integer = 0 To dtNewPdCode.Rows.Count - 1
                    Application.DoEvents()
                    'Start Check PdCode
                    Dim sqlck As String = String.Format("Select Top 1 PdCode from {0} where PdCode = '{1}'", _
                        PublicTable.Table_PCM_MterTrayU00, dtNewPdCode.Rows(p)("ProductCode"))
                    Dim dtck As DataTable = _db.FillDataTable(sqlck)
                    If dtck.Rows.Count <> 0 Then Continue For

                    Dim sqlCom As String = String.Format("SELECT  A.ProductCode , " +
                    "A.RevisionCode, " +
                    "A.ComponentCode, " +
                    "B.MaxRc, " +
                    "A.SpecialNote1 " +
                    "FROM {0} A " +
                    "INNER JOIN ( SELECT MAX(RevisionCode) MaxRc " +
                    "FROM {0} " +
                    "WHERE  ProductCode = '{1}' " +
                    ") B ON A.RevisionCode = B.MaxRc " +
                    "WHERE   A.ProductCode = '{1}' " +
                    "AND A.ComponentCode != 'U00' " +
                    "AND A.ComponentCode != 'U01' " +
                    "Order By A.ComponentCode", PublicTable_FPICS.Table_m_Component, dtNewPdCode.Rows(p)("ProductCode"))
                    Dim dtCom As DataTable = dbFpics.FillDataTable(sqlCom)

                    If dtCom.Rows.Count <> 0 Then
                        For i As Integer = 0 To dtCom.Rows.Count - 1
                            Dim row As DataRow = dtTemp.NewRow()

                            row("PdCode") = dtNewPdCode.Rows(p)("ProductCode")
                            row("Cc") = dtCom.Rows(i)("ComponentCode")
                            row("JEName") = dtCom.Rows(i)("SpecialNote1")

                            dtTemp.Rows.Add(row)
                        Next

                        'U00
                        Dim dtU00 As DataTable = GetCcName(dtCom.Rows(0)("ProductCode"), dtCom.Rows(0)("RevisionCode"), "U00", "9094")
                        If dtU00.Rows.Count <> 0 Then
                            Dim row As DataRow = dtTemp.NewRow()
                            row("PdCode") = dtCom.Rows(0)("ProductCode")
                            row("Cc") = "U00"

                            If dtU00.Rows.Count > 1 Then
                                row("JEName") = dtU00.Rows(1)("OperationInstruction")
                            Else
                                row("JEName") = dtU00.Rows(0)("OperationInstruction")
                            End If

                            dtTemp.Rows.Add(row)
                        End If

                        'U01
                        Dim dtU01 As DataTable = GetCcName(dtCom.Rows(0)("ProductCode"), dtCom.Rows(0)("RevisionCode"), "U01", "9094")
                        If dtU01.Rows.Count <> 0 Then
                            Dim row As DataRow = dtTemp.NewRow()
                            row("PdCode") = dtCom.Rows(0)("ProductCode")
                            row("Cc") = "U01"
                            If dtU01.Rows.Count > 1 Then
                                row("JEName") = dtU01.Rows(1)("OperationInstruction")
                            Else
                                row("JEName") = dtU01.Rows(0)("OperationInstruction")
                            End If

                            dtTemp.Rows.Add(row)
                        End If

                        'Get Khay
                        Dim dtKhay As DataTable = GetCcName(dtCom.Rows(0)("ProductCode"), dtCom.Rows(0)("RevisionCode"), "B00", "9051")
                        If dtKhay.Rows.Count <> 0 Then
                            Dim row As DataRow = dtTemp.NewRow()
                            row("PdCode") = dtCom.Rows(0)("ProductCode")
                            row("Cc") = "B00"
                            row("JEName") = dtKhay.Rows(0)("OperationInstruction")

                            dtTemp.Rows.Add(row)
                        End If

                        'Get Recist
                        Dim dtRecist As DataTable = GetCcName(dtCom.Rows(0)("ProductCode"), dtCom.Rows(0)("RevisionCode"), "B00", "2022")
                        If dtRecist.Rows.Count <> 0 Then
                            Dim row As DataRow = dtTemp.NewRow()
                            row("PdCode") = dtCom.Rows(0)("ProductCode")
                            row("Cc") = "B00"
                            row("JEName") = dtRecist.Rows(0)("OperationInstruction")

                            dtTemp.Rows.Add(row)
                        End If


                    End If

                Next

                bs.DataSource = dtTemp
                gridD.DataSource = bs
                bnGrid.BindingSource = bs

                getPd = True
                Me.Cursor = Cursors.Arrow
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Get Pd")
        End Try

    End Sub

    Function GetCcName(ByVal PdCode As String, ByVal Rc As String, ByVal Cc As String, ByVal Prc As String) As DataTable
        Dim sql As String = String.Format("SELECT  B.OperationInstruction " +
        "FROM    m_ComponentProcess A " +
        "INNER JOIN dbo.m_OperationInstruction B ON A.ProductCode = B.ProductCode " +
                                                   "AND A.RevisionCode = B.RevisionCode " +
                                                   "AND A.ComponentCode = B.ComponentCode " +
                                                   "AND A.ProcessNumber = B.ProcessNumber " +
        "WHERE   A.ProductCode = '{0}' " +
        "AND A.RevisionCode = '{1}' " +
        "AND A.ComponentCode = '{2}' " +
        "AND A.ProcessCode = '{3}' " +
        "ORDER BY SortNumber", PdCode, Rc, Cc, Prc)

        Return dbFpics.FillDataTable(sql)
    End Function

    Private Sub PanelSearch_Leave(sender As System.Object, e As System.EventArgs) Handles PanelSearch.Leave
        PanelSearch.Visible = False
    End Sub

    Private Sub PanelSearch_Enter(sender As System.Object, e As System.EventArgs) Handles PanelSearch.Enter
        PanelSearch.Visible = True
    End Sub

    Private Sub gridSearch_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridSearch.CellClick
        If gridSearch.CurrentRow Is Nothing Then Exit Sub

        txtECode.Text = IIf(gridSearch.CurrentRow.Cells("ECodeSearch").Value Is DBNull.Value, "", gridSearch.CurrentRow.Cells("ECodeSearch").Value)
        txtECode.Focus()
        clickSearck = True
        
    End Sub

    Private Sub txtPrcName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPrcName.TextChanged
        If dtSearch Is Nothing Then
            Return
        Else
            Dim dv As DataView = New DataView(dtSearch)
            dv.RowFilter = "[PrcName] LIKE '%" + Trim(txtPrcName.Text) + "%'"
            Dim bd As New BindingSource()
            bd.DataSource = dv
            gridSearch.DataSource = bd
        End If
    End Sub

    Private Sub mnuUpdateEmpID_Click(sender As System.Object, e As System.EventArgs) Handles mnuUpdateEmpID.Click
        If gridD.CurrentRow IsNot Nothing And _cellClick = 1 Then
            If ShowQuestionUpdate("Bạn muốn cập nhật ECode không ?") = Windows.Forms.DialogResult.Yes Then
                Dim sql As String = String.Format(" update  [PCM_MterTrayU00] " +
                                                  " set ECode='{0}' " +
                                                  " where ECode='{1}' and JCode='{2}' and SubPrcName='{3}' and Cc='{4}' and pdCode='{5}' ",
                                                  txtNewID.Text, txtOldID.Text,
                                                  txtJCode.Text, cboSubPrc.Text, cboCc.Text, txtPdCode.Text)
                _db.ExecuteNonQuery(sql)
                mnuShowAll.PerformClick()
                ShowSuccess()
            End If
        End If
    End Sub

    Private Sub mnuImport_Click(sender As System.Object, e As System.EventArgs) Handles mnuImport.Click
        Dim dtData As DataTable = ImportEXCEL(True)
        If dtData.Rows.Count > 0 Then
            If ShowQuestion("Bạn có muốn xóa hết và import master mới không ? Hãy backup ra file excel.") = Windows.Forms.DialogResult.No Then
                Return
            End If
            Try
                _db.BeginTransaction()
                Dim sql As String = String.Format("delete from PCM_MterTrayU00")
                _db.ExecuteNonQuery(sql)

                For Each r As DataRow In dtData.Rows
                    If r(ECode.Name) IsNot DBNull.Value Then
                        Dim obj As New PCM_MterTrayU00
                        obj.ECode_K = r(ECode.Name)
                        If r(Cc.Name) IsNot DBNull.Value Then
                            obj.Cc_K = r(Cc.Name)
                        End If
                        If r(JCode.Name) IsNot DBNull.Value Then
                            obj.JCode_K = r(JCode.Name)
                        End If
                        If r(PdCode.Name) IsNot DBNull.Value Then
                            obj.PdCode_K = r(PdCode.Name)
                        End If
                        If r(PrcName.Name) IsNot DBNull.Value Then
                            obj.PrcName = r(PrcName.Name)
                        End If
                        If r(SubPrcName.Name) IsNot DBNull.Value Then
                            obj.SubPrcName_K = r(SubPrcName.Name)
                        End If
                        If r(GroupCode.Name) IsNot DBNull.Value Then
                            obj.GroupCode = r(GroupCode.Name)
                        End If
                        If r(XuatKho.Name) IsNot DBNull.Value Then
                            obj.XuatKho = r(XuatKho.Name)
                        End If
                        If r(JEName.Name) IsNot DBNull.Value Then
                            obj.JEName = r(JEName.Name)
                        End If
                        If r(JVName.Name) IsNot DBNull.Value Then
                            obj.JVName = r(JVName.Name)
                        End If
                        If r(MinQty.Name) IsNot DBNull.Value Then
                            obj.MinQty = r(MinQty.Name)
                        End If

                        obj.Old = False
                        If r(Unit.Name) IsNot DBNull.Value Then
                            obj.Unit = r(Unit.Name)
                        End If
                        If r(UnitLot.Name) IsNot DBNull.Value Then
                            obj.UnitLot = r(UnitLot.Name)
                        End If
                        obj.CreateDate = DateTime.Now
                        obj.CreateUser = CurrentUser.UserID
                        If _db.ExistObject(obj) Then
                            _db.Update(obj)
                        Else
                            _db.Insert(obj)
                        End If
                    End If
                Next
                _db.Commit()
                ShowSuccess()
                mnuShowAll.PerformClick()
            Catch ex As Exception
                _db.RollBack()
                ShowError(ex, "Import", Name)
            End Try
        Else
            ShowWarning("Không có dữ liệu. Vui lòng kiểm tra lại.")
        End If
    End Sub

    Private Sub txtJCode_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtJCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim JCode As String = Trim(txtJCode.Text)
            Dim sql As String = String.Format("select JEName, JVName, Unit, UnitLot, MinQty, StdDtbtQty, AddDtbtQty from {0} where JCode = '{1}'",
                                              PublicTable.Table_PCM_MterTrayU00, JCode)
            Dim dt As DataTable = _db.FillDataTable(sql)
            If dt.Rows.Count <> 0 Then

                txtJEName.Text = IIf(dt.Rows(0).Item("JEName") Is DBNull.Value, "", dt.Rows(0).Item("JEName"))
                txtJVName.Text = IIf(dt.Rows(0).Item("JVName") Is DBNull.Value, "", dt.Rows(0).Item("JVName"))
                txtUnit.Text = IIf(dt.Rows(0).Item("Unit") Is DBNull.Value, "", dt.Rows(0).Item("Unit"))
                txtUnitLot.Text = IIf(dt.Rows(0).Item("UnitLot") Is DBNull.Value, "", dt.Rows(0).Item("UnitLot"))
                txtMinQty.Text = IIf(dt.Rows(0).Item("MinQty") Is DBNull.Value, "", dt.Rows(0).Item("MinQty"))
                txtStdDtbtQty.Text = IIf(dt.Rows(0).Item("StdDtbtQty") Is DBNull.Value, "", dt.Rows(0).Item("StdDtbtQty"))
                txtAddDtbtQty.Text = IIf(dt.Rows(0).Item("AddDtbtQty") Is DBNull.Value, "", dt.Rows(0).Item("AddDtbtQty"))

                Dim sqlItem As String = String.Format(" SELECT [ItemName] FROM [t_ASMaterialItem] where ItemCode='{0}' ", JCode)
                Dim dtItem As DataTable = dbFpics.FillDataTable(sqlItem)
                If dtItem.Rows.Count > 0 Then
                    txtJEName.Text = IIf(dtItem.Rows(0).Item("ItemName") Is DBNull.Value, "", dtItem.Rows(0).Item("ItemName"))
                    txtJEName.Text = txtJEName.Text.Trim
                End If
            Else
                Dim sqlItem As String = String.Format(" SELECT [ItemCode],[ItemName] FROM [t_ASMaterialItem] where ItemCode='{0}' ", JCode)
                Dim dtItem As DataTable = dbFpics.FillDataTable(sqlItem)
                If dtItem.Rows.Count > 0 Then
                    txtJEName.Text = IIf(dtItem.Rows(0).Item("ItemName") Is DBNull.Value, "", dtItem.Rows(0).Item("ItemName"))
                    txtJVName.Text = txtJEName.Text.Trim
                    txtJEName.Text = txtJEName.Text.Trim
                End If
            End If
        End If
    End Sub

    Private Sub gridD_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellValueChanged
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = gridD.Columns("XuatKho").Index Or e.ColumnIndex = gridD.Columns("Note").Index Then
                Dim obj As New PCM_MterTrayU00()
                obj.Cc_K = gridD.CurrentRow.Cells("CC").Value
                obj.ECode_K = gridD.CurrentRow.Cells("ECode").Value
                obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
                obj.PdCode_K = gridD.CurrentRow.Cells("PdCode").Value
                obj.SubPrcName_K = gridD.CurrentRow.Cells("SubPrcName").Value
                _db.GetObject(obj)
                If gridD.CurrentRow.Cells("XuatKho").Value IsNot DBNull.Value Then
                    obj.XuatKho = gridD.CurrentRow.Cells("XuatKho").Value
                Else
                    obj.XuatKho = ""
                End If
                If gridD.CurrentRow.Cells("Note").Value IsNot DBNull.Value Then
                    obj.Note = gridD.CurrentRow.Cells("Note").Value
                Else
                    obj.Note = ""
                End If
                _db.Update(obj)

                CheckJCode()
            End If
        End If
    End Sub

    Private Sub lblXem_Click(sender As System.Object, e As System.EventArgs)

    End Sub
End Class