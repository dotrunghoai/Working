Imports LibEntity
Imports PublicUtility

Public Class FrmNotifySetTime
    'Public frm As New FrmMain
    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub bttSave_Click(sender As System.Object, e As System.EventArgs) Handles bttSave.Click
        Dim obj As New Main_NotifyMessageTime
        obj.UserID_K = CurrentUser.UserID
        obj.TotalMinute = numr.Value
        obj.Enabled = Not ckoOff.Checked
        If _db.ExistObject(obj) Then
            _db.Update(obj)
        Else
            _db.Insert(obj)
        End If

        clsMain.fMain.tmrRequest.Enabled = obj.Enabled
        clsMain.fMain.tmrRequest.Interval = obj.TotalMinute * 60000
        ShowSuccess()
        Close()
    End Sub

    Private Sub ckoOff_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckoOff.CheckedChanged
        numr.Enabled = Not ckoOff.Checked
    End Sub

    Private Sub FrmNotifySetTime_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        Dim obj As New Main_NotifyMessageTime
        obj.UserID_K = CurrentUser.UserID
        _db.GetObject(obj)
        If obj.UserID_K <> "" Then
            numr.Value = obj.TotalMinute
            numr.Enabled = obj.Enabled
            ckoOff.Checked = Not obj.Enabled
        Else
            numr.Value = 30
            numr.Enabled = False
            ckoOff.Checked = True
        End If
    End Sub
End Class