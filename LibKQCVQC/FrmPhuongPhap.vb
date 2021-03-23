Imports CommonDB
Imports System.Windows.Forms
Imports PublicUtility
Imports LibEntity

Public Class FrmPhuongPhap
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)


    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim sql As String = String.Format("select ID,PhuongPhap from KQCV_PhuongPhap")
        Dim bdsource As New BindingSource
        bdsource.DataSource = _db.FillDataTable(sql)
        bdn.BindingSource = bdsource
        grid.DataSource = bdsource
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub

    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click
        If grid.CurrentRow IsNot Nothing Then
            If grid.CurrentRow.Cells("ID").Value IsNot DBNull.Value Then
                If ShowQuestionDelete(grid.CurrentRow.Cells("ID").Value) = Windows.Forms.DialogResult.Yes Then
                    Dim obj As New KQCV_PhuongPhap
                    obj.ID_K = grid.CurrentRow.Cells("ID").Value
                    _db.Delete(obj)
                    grid.Rows.Remove(grid.CurrentRow)
                End If
            End If
        End If
    End Sub

    Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click
        If txtID.Text = "" Then
            ShowWarning("Bạn chưa nhập ID")
            txtID.Focus()
            Return
        End If
        If txtPhuongPhap.Text = "" Then
            ShowWarning("Bạn chưa nhập tên phương pháp")
            txtPhuongPhap.Focus()
            Return
        End If
        If ShowQuestionSave() = Windows.Forms.DialogResult.Yes Then
            Dim obj As New KQCV_PhuongPhap
            obj.ID_K = txtID.Text
            obj.PhuongPhap = txtPhuongPhap.Text
            If _db.ExistObject(obj) Then
                _db.Update(obj)
            Else
                _db.Insert(obj)
            End If
        End If
        mnuShowAll.PerformClick()
    End Sub
     

    Private Sub FrmEmployee_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub

    Private Sub FrmEmployee_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub grid_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellClick
        If grid.CurrentRow IsNot Nothing Then
            txtID.Text = grid.CurrentRow.Cells("ID").Value
            txtPhuongPhap.Text = grid.CurrentRow.Cells("PhuongPhap").Value
        End If
    End Sub
End Class