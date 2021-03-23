Imports LibEntity
Imports PublicUtility

Public Class FrmModuleGroup : Inherits DevExpress.XtraEditors.XtraForm
    Dim db As DBSql


    Private Sub txtGroupID_Enter(sender As System.Object, e As System.EventArgs) Handles txtGroupID.Enter
        SetColorEnter(txtGroupID)
    End Sub
    Private Sub txtGroupID_Leave(sender As System.Object, e As System.EventArgs) Handles txtGroupID.Leave
        SetColorLeave(txtGroupID)
    End Sub

    Private Sub txtgroupE_Enter(sender As System.Object, e As System.EventArgs) Handles txtgroupE.Enter
        SetColorEnter(txtgroupE)
    End Sub
    Private Sub txtgroupE_Leave(sender As System.Object, e As System.EventArgs) Handles txtgroupE.Leave
        SetColorLeave(txtgroupE)
    End Sub

    Private Sub txtGroupV_Enter(sender As System.Object, e As System.EventArgs) Handles txtGroupV.Enter
        SetColorEnter(txtGroupV)
    End Sub
    Private Sub txtGroupV_Leave(sender As System.Object, e As System.EventArgs) Handles txtGroupV.Leave
        SetColorLeave(txtGroupV)
    End Sub

    Private Sub txtgroupJ_Enter(sender As System.Object, e As System.EventArgs) Handles txtgroupJ.Enter
        SetColorEnter(txtgroupJ)
    End Sub
    Private Sub txtgroupJ_Leave(sender As System.Object, e As System.EventArgs) Handles txtgroupJ.Leave
        SetColorLeave(txtgroupJ)
    End Sub

    Private Sub txtGroupC_Enter(sender As System.Object, e As System.EventArgs) Handles txtGroupC.Enter
        SetColorEnter(txtGroupC)
    End Sub
    Private Sub txtGroupC_Leave(sender As System.Object, e As System.EventArgs) Handles txtGroupC.Leave
        SetColorLeave(txtGroupC)
    End Sub

    Private Sub mnuNew_Click(sender As System.Object, e As System.EventArgs) Handles mnuNew.Click
        txtGroupC.Text = ""
        txtgroupE.Text = ""
        txtGroupID.Text = ""
        txtgroupJ.Text = ""
        txtGroupV.Text = ""
        txtGroupID.Focus()
    End Sub

    Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click
        If txtGroupID.Text = "" Then
            MessageBox.Show("GroupID is not null.", "Info")
            txtGroupID.Focus()
            Return
        End If
        Try
            Dim obj As New Main_ModuleGroup
            obj.GroupID_K = txtGroupID.Text
            obj.GroupNameC = txtGroupC.Text
            obj.GroupNameE = txtgroupE.Text
            obj.GroupNameJ = txtgroupJ.Text
            obj.GroupNameV = txtGroupV.Text
            db.Insert(obj)

            MessageBox.Show("Successfully.", "Save")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save ModuleGroup")
        End Try
    End Sub

    Private Sub FrmModuleGroup_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        db = New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    End Sub

    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click
        Dim datarow As DataGridViewSelectedRowCollection = grid.SelectedRows
        If datarow.Count > 0 Then
            Try
                If ShowQuestionDelete() = Windows.Forms.DialogResult.No Then Return

                db.BeginTransaction()
                Dim count As Integer = 0
                For row As Integer = 0 To datarow.Count - 1
                    Dim obj As New Main_ModuleGroup
                    obj.GroupID_K = datarow.Item(row).Cells("GroupID").Value
                    count += db.Delete(obj)
                Next

                MessageBox.Show("Successfully. " & count & " records.", "Delete")
                db.Commit()

            Catch ex As Exception
                db.RollBack()

            End Try
        End If
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim condition As String = " 1=1 "
        If txtGroupID.Text <> "" Then condition += String.Format(" and GroupID ='{0}' ", txtGroupID.Text)
        If txtGroupC.Text <> "" Then condition += String.Format(" and GroupNameC like '%{0}%' ", txtGroupC.Text)
        If txtgroupE.Text <> "" Then condition += String.Format(" and GroupNameE like '%{0}%' ", txtgroupE.Text)
        If txtgroupJ.Text <> "" Then condition += String.Format(" and GroupNameJ like '%{0}%' ", txtgroupJ.Text)
        If txtGroupV.Text <> "" Then condition += String.Format(" and GroupNameV like '%{0}%' ", txtGroupV.Text)

        Dim sql As String = String.Format("select * from {0} where {1} ",
                                          PublicTable.Table_Main_ModuleGroup,
                                          condition)

        Dim bdsource As New BindingSource
        bdsource.DataSource = db.FillDataTable(sql)
        grid.DataSource = bdsource

    End Sub

    Private Sub FrmModuleGroup_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{Tab}")
        If e.KeyCode = Keys.N And e.Control Then
            mnuNew.PerformClick()
        End If
        If e.KeyCode = Keys.S And e.Control Then
            mnuSave.PerformClick()
        End If
        If e.KeyCode = Keys.D And e.Control Then
            mnuDelete.PerformClick()
        End If
        If e.KeyCode = Keys.F5 Then
            mnuShowAll.PerformClick()
        End If
    End Sub

    Private Sub grid_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellEnter
        grid.BeginEdit(True)
    End Sub

    Private Sub grid_CellLeave(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellLeave
        grid.EndEdit(True)
    End Sub

    Private Sub grid_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellValueChanged
        If grid.CurrentRow IsNot Nothing Then
            If e.ColumnIndex <> grid.Columns("No").Index And e.RowIndex >= 0 Then
                Dim obj As New Main_ModuleGroup
                obj.GroupID_K = grid.Item("GroupID", e.RowIndex).Value
                If grid.Item("GroupNameC", e.RowIndex).Value IsNot DBNull.Value Then obj.GroupNameC = grid.Item("GroupNameC", e.RowIndex).Value
                If grid.Item("GroupNamE", e.RowIndex).Value IsNot DBNull.Value Then obj.GroupNameE = grid.Item("GroupNamE", e.RowIndex).Value
                If grid.Item("GroupNameJ", e.RowIndex).Value IsNot DBNull.Value Then obj.GroupNameJ = grid.Item("GroupNameJ", e.RowIndex).Value
                If grid.Item("GroupNameV", e.RowIndex).Value IsNot DBNull.Value Then obj.GroupNameV = grid.Item("GroupNameV", e.RowIndex).Value
                If grid.Item("Note", e.RowIndex).Value IsNot DBNull.Value Then obj.Note = grid.Item("Note", e.RowIndex).Value
                db.Update(obj)
            End If
        End If
    End Sub
End Class