

Public Class FrmBlank : Inherits DevExpress.XtraEditors.XtraForm
    Public frmClient As Form
    Private Sub FrmBlank_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        frmClient.ShowDialog()
        Close()
    End Sub

#Region "User function"



#End Region
End Class