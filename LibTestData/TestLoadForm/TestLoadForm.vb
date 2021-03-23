Public Class TestLoadForm
    Private Sub ckoPass_CheckedChanged(sender As Object, e As EventArgs) Handles ckoPass.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not ckoPass.Checked
    End Sub
End Class