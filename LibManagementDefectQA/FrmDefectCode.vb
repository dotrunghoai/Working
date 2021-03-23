Imports CommonDB
Imports LibEntity
Imports PublicUtility
Imports System.Windows.Forms

Public Class FrmDefectCode : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim sql As String = String.Format("select * from MDQA_DefectCode ")
        Dim bd As New BindingSource
        bd.DataSource = _db.FillDataTable(sql)
        bdn.BindingSource = bd
        grid.DataSource = bd
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub

    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click
        If grid.CurrentRow IsNot Nothing Then
            If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
                Dim obj As New MDQA_DefectCode
                obj.DefectCode_K = grid.CurrentRow.Cells("DefectCode").Value
                _db.Delete(obj)
                grid.Rows.Remove(grid.CurrentRow)
            End If
        End If
    End Sub

    Private Sub FrmDefectCode_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub

    Private Sub grid_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellClick
        txtDefectCode.Text = grid.CurrentRow.Cells("DefectCode").Value
        txtDefectNameV.Text = grid.CurrentRow.Cells("DefectNameV").Value
        txtDefectNameE.Text = grid.CurrentRow.Cells("DefectNameE").Value
    End Sub

    Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click
        If txtDefectCode.Text = "" Then
            ShowWarning("DefectCode không được để trống")
            txtDefectCode.Focus()
            Return
        End If
        If txtDefectNameE.Text = "" Then
            ShowWarning("DefectNameE không được để trống")
            txtDefectNameE.Focus()
            Return
        End If
        If txtDefectNameV.Text = "" Then
            ShowWarning("DefectNameV không được để trống")
            txtDefectNameV.Focus()
            Return
        End If
        Dim obj As New MDQA_DefectCode
        obj.DefectCode_K = txtDefectCode.Text
        obj.DefectNameE = txtDefectNameE.Text
        obj.DefectNameV = txtDefectNameV.Text
        If _db.ExistObject(obj) Then
            _db.Update(obj)
        Else
            _db.Insert(obj)
        End If
    End Sub
End Class