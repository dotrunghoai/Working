Imports CommonDB

Imports LibEntity
Imports PublicUtility

Public Class FrmUserInfo : Inherits DevExpress.XtraEditors.XtraForm
#Region "Variable"
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
#End Region

#Region "User function"

#End Region

#Region "Form function"

    Private Sub bttCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttExit.Click
        Me.Close()
    End Sub

    Private Sub FrmChangePassword_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
        If e.KeyCode = Keys.S And e.Control Then
            bttSave.PerformClick()
        End If
    End Sub

    Private Sub ckoVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckoVisible.CheckedChanged
        txtCurrentPass.UseSystemPasswordChar = Not ckoVisible.Checked
        txtNewPass.UseSystemPasswordChar = Not ckoVisible.Checked
    End Sub

    Private Sub bttOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttSave.Click
        If txtCurrentPass.Text <> CurrentUser.Password Then
            ShowWarningNotCorrect("Mật khẩu mới phải khác mật khẩu hiện tại ! (Don't input current passsword)")
            txtCurrentPass.Focus()
            Return
        End If

        Try

            Dim obj As New Main_User()
            obj.UserID_K = CurrentUser.UserID
            _db.GetObject(obj)
            If txtNewPass.Text <> "" Then
                obj.Password = EncryptPassword(txtNewPass.Text)
            End If
            obj.PCNoOriginal = txtPCNo.Text
            obj.GlobalID = txtGlobalID.Text
            obj.GlobalPass = txtGlobalPass.Text
            obj.Note = txtPhoneNumber.Text
            CurrentUser.GlobalPass = obj.GlobalPass
            CurrentUser.GlobalID = obj.GlobalID

            If _db.Update(obj) > 0 Then
                ShowSuccess()
                Me.Close()
            End If

        Catch ex As Exception
            ShowError(ex, "bttOK_Click", Me.Name)
        End Try
    End Sub

    Private Sub txtCurrent_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCurrentPass.Enter, txtNewPass.Enter
        SetColorEnter(sender)
    End Sub
    Private Sub txtCurrent_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCurrentPass.Leave, txtNewPass.Leave
        SetColorLeave(sender)
    End Sub

    Private Sub FrmUserInfo_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim obj As New Main_User
        obj.UserID_K = CurrentUser.UserID
        _db.GetObject(obj)
        txtHoTen.Text = obj.FullName
        txtPhong.Text = obj.Section
        txtPhoneNumber.Text = obj.Note
        txtGlobalID.Text = obj.GlobalID
        txtGlobalPass.Text = obj.GlobalPass
        txtPCNo.Text = obj.PCNoOriginal
        txtCurrentPass.Text = DecryptPassword(obj.Password)
        txtUserName.Text = obj.UserName
    End Sub

#End Region

End Class