Public Class PictureViewer
    Private Sub showButton_Click(sender As Object, e As EventArgs) Handles showButton.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Load(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub clearimageButton_Click(sender As Object, e As EventArgs) Handles clearimageButton.Click
        PictureBox1.Image = Nothing
    End Sub

    Private Sub backgroupButton_Click(sender As Object, e As EventArgs) Handles backgroupButton.Click
        If ColorDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub clearbackcolorButton_Click(sender As Object, e As EventArgs) Handles clearbackcolorButton.Click
        PictureBox1.BackColor = Nothing
    End Sub

    Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf PictureBox1.SizeMode = PictureBoxSizeMode.Normal Then
        End If
    End Sub
End Class