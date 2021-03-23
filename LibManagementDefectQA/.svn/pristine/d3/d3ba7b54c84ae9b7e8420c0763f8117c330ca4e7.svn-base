
Imports CommonDB
Imports LibEntity
Imports PublicUtility
Imports System.Windows.Forms


Public Class FrmDataSSI : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _dbFpics As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim sql As String = String.Format("select ProductCode from MDQA_SSI")
        Dim bd As New BindingSource
        bd.DataSource = _db.FillDataTable(sql)
        bdn.BindingSource = bd
        grid.DataSource = bd
    End Sub

    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click
        If grid.CurrentRow IsNot Nothing Then
            If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
                Dim obj As New MDQA_SSI
                obj.ProductCode_K = grid.CurrentRow.Cells("ProductCode").Value
                _db.Delete(obj)
                grid.Rows.Remove(grid.CurrentRow)
            End If
        End If
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub

    Private Sub txtMSP_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMSP.TextChanged
        If bdn.BindingSource IsNot Nothing Then
            If txtMSP.Text = "" Then
                bdn.BindingSource.Filter = ""
            Else
                bdn.BindingSource.Filter = String.Format("ProductCode like '%{0}%' ", txtMSP.Text)
            End If
        End If
    End Sub

    Private Sub txtMSP_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMSP.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtMSP.Text <> "" Then
                txtMSP.Text = txtMSP.Text.PadLeft(5, "0")
                Dim objp As New m_Product
                objp.ProductCode_K = txtMSP.Text
                objp.RevisionCode_K = "01"
                If Not _dbFpics.ExistObject(objp) Then
                    ShowWarning("Mã sản phẩm này không tồn tại. Vui lòng nhập mã khác.")
                End If

            End If
        End If
    End Sub

    Private Sub FrmDataSSI_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub
     
    Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click
        If txtMSP.Text <> "" Then
            Dim obj As New MDQA_SSI
            obj.ProductCode_K = txtMSP.Text
            If Not _db.ExistObject(obj) Then
                _db.Insert(obj)
            End If
            mnuShowAll.PerformClick()
            txtMSP.SelectAll()
        End If
    End Sub
End Class