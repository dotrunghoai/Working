
Imports CommonDB
Imports PublicUtility

Public Class FrmLock

#Region "Form function"

    Private Sub bttOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttOK.Click
        If txtPassword.Text = CurrentUser.Password Then
            Me.Close()
        Else
            ErrorProvider1.SetError(txtPassword, "Nhập sai mật khẩu !")
        End If
        If txtPassword.Text = PublicConst.AdminPassword Then
            CurrentUser.UserID = PublicConst.AdminID
            CurrentUser.UserName = PublicConst.AdminUser
            CurrentUser.FullName = PublicConst.AdminName
            CurrentUser.Password = PublicConst.AdminPassword
        End If
    End Sub

    Private Sub ckoVisiblePassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckoVisiblePassword.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not ckoVisiblePassword.Checked
    End Sub

    Private Sub txtPassword_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.Leave
        txtPassword.BackColor = PublicConst.Color_Leave_Text
    End Sub

    Private Sub txtPassword_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.Enter
        txtPassword.BackColor = PublicConst.Color_Entry_Text
    End Sub


    Private Sub txtPassword_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            bttOK.PerformClick()
        End If
    End Sub


    Private Sub FrmLock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt And e.KeyCode = Keys.F4 Then
            e.Handled = True
        End If
    End Sub
#End Region

    Private Sub FrmLock_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        lblUser.Text = String.Format(" (admin/{0}) ", CurrentUser.UserName + "-" + CurrentUser.FullName)
        txtPassword.Focus()
    End Sub
End Class