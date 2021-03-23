Public Class FrmInputPass
    Public isOK As Boolean = False
    Private Sub txtPass_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPass.Text = "P@ssw0rd" Then
                ShowSuccess()
                isOK = True
                lblinfo.Visible = False
                Close()
            Else
                txtPass.SelectAll()
                isOK = False
                lblinfo.Visible = True
            End If
        End If
    End Sub
End Class