Imports CommonDB
Imports System.IO
Imports PublicUtility

Public Class FrmConfig

    Dim config As New ConfigNDV()


    Private Sub FrmConfig_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt And e.KeyCode = Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
     

    Private Sub rdoOption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoOption.CheckedChanged

        txtConstring.Enabled = Not rdoOption.Checked
        txtDatabase.Enabled = rdoOption.Checked
        txtPassword.Enabled = rdoOption.Checked
        txtServer.Enabled = rdoOption.Checked
        txtUserName.Enabled = rdoOption.Checked

    End Sub

    Private Sub rdoString_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoString.CheckedChanged
        txtConstring.Enabled = rdoString.Checked
        txtDatabase.Enabled = Not rdoString.Checked
        txtPassword.Enabled = Not rdoString.Checked
        txtServer.Enabled = Not rdoString.Checked
        txtUserName.Enabled = Not rdoString.Checked
    End Sub

    Private Sub txtConstring_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUserName.Enter, txtServer.Enter, txtPassword.Enter, txtDatabase.Enter, txtConstring.Enter
        SetColorEnter(txtConstring)
    End Sub
    Private Sub txtConstring_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUserName.Leave, txtServer.Leave, txtPassword.Leave, txtDatabase.Leave, txtConstring.Leave
        SetColorLeave(txtConstring)
    End Sub


    Private Sub bttSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttSave.Click
        Dim connection As String = String.Format("Server={0} ; Database={1} ; User ID={2} ; Password={3} ; Connection Timeout=0 ;",
                                   txtServer.Text,
                                   txtDatabase.Text,
                                   txtUserName.Text,
                                   txtPassword.Text)


        If rdoString.Checked Then connection = txtConstring.Text



        Try
            Dim db As IDBFunction
            If cboConnect.Text = "NDV_DB2_AS400" Then
                db = New DBFunction(connection)
            Else
                db = New DBSql(connection)
            End If
            If db.CheckConnection() Then
                MessageBox.Show("Successfully", "Info")
                Select Case cboConnect.Text
                    Case "NDV_DB2_AS400"
                        config.DB2_AS400 = EncryptPassword(connection)
                    Case "NDV_SQL_ERP_NDV"
                        config.SQL_ERP_NDV = EncryptPassword(connection)
                    Case "NDV_SQL_Factory"
                        config.SQL_Factory = EncryptPassword(connection)
                    Case "NDV_SQL_Fpics"
                        config.SQL_FPICS = EncryptPassword(connection)
                    Case "NDV_SQL_ThaiSon"
                        config.SQL_ThaiSon = EncryptPassword(connection)
                End Select

                BinarySerialize(Application.StartupPath + PublicConst.CONFIG, config)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboConnect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboConnect.SelectedIndexChanged
        If cboConnect.SelectedIndex >= 0 Then
            Select Case cboConnect.Text
                Case "NDV_SQL_ERP_NDV"
                    txtConstring.Text = DecryptPassword(config.SQL_ERP_NDV)
                Case "NDV_SQL_Factory"
                    txtConstring.Text = DecryptPassword(config.SQL_Factory)
                Case "NDV_DB2_AS400"
                    txtConstring.Text = DecryptPassword(config.DB2_AS400)
                Case "NDV_SQL_Fpics"
                    txtConstring.Text = DecryptPassword(config.SQL_FPICS)
                Case "NDV_SQL_ThaiSon"
                    txtConstring.Text = DecryptPassword(config.SQL_ThaiSon)
            End Select
        End If
    End Sub

    Private Sub bttSaveCommon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttSaveCommon.Click


        If cboCurrency.SelectedIndex >= 0 Then
            config.FORMAT_CURRENCY = cboCurrency.Text
        End If
        If cboDateShort.SelectedIndex >= 0 Then
            config.FORMAT_DATE_SHORT = cboDateShort.Text
        End If
        If cboDateTime.SelectedIndex >= 0 Then
            config.FORMAT_DATETIME = cboDateTime.Text
        End If
        If cboNormal.SelectedIndex >= 0 Then
            config.FORMAT_NORMAL = cboNormal.Text
        End If
        If cboPrice.SelectedIndex >= 0 Then
            config.FORMAT_PRICE = cboPrice.Text
        End If
        If cboQuantity.SelectedIndex >= 0 Then
            config.FORMAT_QUANTITY = cboQuantity.Text
        End If

        BinarySerialize(Application.StartupPath + PublicConst.CONFIG, config)
    End Sub

    Private Sub FrmConfig_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        Dim frm As New FrmInputPass
        frm.ShowDialog()
        If Not frm.isOK Then
            Close()
        End If

        cboConnect.Items.Clear()

        cboConnect.Items.Add(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        cboConnect.Items.Add(PublicConst.EnumServers.NDV_SQL_Factory)
        cboConnect.Items.Add(PublicConst.EnumServers.NDV_SQL_Fpics)
        cboConnect.Items.Add(PublicConst.EnumServers.NDV_SQL_ThaiSon)
        cboConnect.Items.Add(PublicConst.EnumServers.NDV_DB2_AS400)

        If File.Exists(Application.StartupPath + PublicConst.CONFIG) Then
            config = BinaryDeserialize(Application.StartupPath + PublicConst.CONFIG)
        End If

    End Sub

End Class