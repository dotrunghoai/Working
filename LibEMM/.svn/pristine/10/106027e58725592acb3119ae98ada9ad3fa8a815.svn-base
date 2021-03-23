Public Class FrmSetJCode

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If rdoU00.Checked Then
            FrmDLVRList.searchJCode = "A"
        ElseIf rdoChemical.Checked Then
            FrmDLVRList.searchJCode = "B"
        ElseIf rdoNylon.Checked Then
            FrmDLVRList.searchJCode = "C"
        ElseIf rdoCarton.Checked Then
            FrmDLVRList.searchJCode = "D"
        ElseIf rdoWhitePet.Checked Then
            FrmDLVRList.searchJCode = "E"
        End If

        Me.Close()
    End Sub

    Private Sub FrmSetJCode_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        lblThongBao.Text = FrmDLVRList.searchJCode + " thuộc nhóm nào bên dưới đây?"
        FrmDLVRList.searchJCode = ""
    End Sub
End Class