Public Class FrmAutoConnect
    Public _ErrorMessage As String = ""
    Public _IsContinue As Boolean = False
    Dim _TotalTimeSec As Integer = 0
    Dim IndexSec As Integer = 30

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        IndexSec -= 1
        txtTime.Text = IndexSec
        If IndexSec = _TotalTimeSec Then
            Timer1.Enabled = False
            bttReconnect.PerformClick()
        End If
    End Sub

    Private Sub bttReconnect_Click(sender As System.Object, e As System.EventArgs) Handles bttReconnect.Click
        _IsContinue = True
        Close()
    End Sub

    Private Sub bttExit_Click(sender As System.Object, e As System.EventArgs) Handles bttExit.Click
        Environment.Exit(0)
    End Sub

    Private Sub FrmAutoConnect_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        Timer1.Enabled = True
        txtLoi.Text = _ErrorMessage
    End Sub
End Class