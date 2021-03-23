Imports CommonDB

Imports PublicUtility

Public Class FrmAbout : Inherits DevExpress.XtraEditors.XtraForm


    Private Sub FrmAbout_Click(sender As System.Object, e As System.EventArgs) Handles MyBase.Click
        For index As Integer = 100 To 0 Step -5
            Me.Opacity = index / 100
            Threading.Thread.Sleep(50)
            Application.DoEvents()
        Next

        Close()

    End Sub

    Private Sub FrmAbout_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        lblCompany.Text = String.Format("Copyright(C) 2011-{0} Nitto Denko Viet Nam", Date.Now.Year)
    End Sub
End Class