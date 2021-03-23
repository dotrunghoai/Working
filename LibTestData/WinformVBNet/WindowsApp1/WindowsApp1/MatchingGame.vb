Public Class MatchingGame
    Dim firstClick As Label = Nothing
    Dim secondClick As Label = Nothing

    Private ngauNhien As Random = New Random()
    Dim bieuTuong As List(Of String) = New List(Of String)() From {
        "!",
        "!",
        "N",
        "N",
        ",",
        ",",
        "k",
        "k",
        "b",
        "b",
        "v",
        "v",
        "w",
        "w",
        "z",
        "z"
    }
    Private Sub AssignIconToSquares()
        For Each dieuKhien As Control In TableLayoutPanel1.Controls
            Dim nhanBieuTuong As Label = TryCast(dieuKhien, Label)
            If nhanBieuTuong IsNot Nothing Then
                Dim soNgauNhien As Integer = ngauNhien.Next(bieuTuong.Count)
                nhanBieuTuong.Text = bieuTuong(soNgauNhien)
                nhanBieuTuong.ForeColor = nhanBieuTuong.BackColor
                bieuTuong.RemoveAt(soNgauNhien)
            End If
        Next
    End Sub

    Private Sub MatchingGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'InitializeComponent()
        AssignIconToSquares()
    End Sub

    Private Sub label_Click(sender As Object, e As EventArgs) Handles Label9.Click, Label8.Click, Label7.Click, Label6.Click, Label5.Click, Label4.Click, Label3.Click, Label2.Click, Label16.Click, Label15.Click, Label14.Click, Label13.Click, Label12.Click, Label11.Click, Label10.Click, Label1.Click

        If Timer1.Enabled = True Then
            Return
        End If

        Dim kiemTraNhan As Label = TryCast(sender, Label)
        If kiemTraNhan IsNot Nothing Then
            If kiemTraNhan.ForeColor = Color.Black Then
                Return
            End If
            'kiemTraNhan.ForeColor = Color.Black
            If firstClick Is Nothing Then
                firstClick = kiemTraNhan
                firstClick.ForeColor = Color.Black
                Return
            End If

            If secondClick Is Nothing Then
                secondClick = kiemTraNhan
                secondClick.ForeColor = Color.Black
                Return
                CheckForWinner()
            End If



            If firstClick.Text = secondClick.Text Then
                firstClick = Nothing
                secondClick = Nothing
                Return
            End If

            Timer1.Start()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        firstClick.ForeColor = firstClick.BackColor
        secondClick.ForeColor = secondClick.BackColor
        firstClick = Nothing
        secondClick = Nothing
    End Sub
    Private Sub CheckForWinner()
        For Each control As Control In TableLayoutPanel1.Controls
            Dim iconLabel As Label = TryCast(control, Label)

            If iconLabel IsNot Nothing Then
                If iconLabel.ForeColor = iconLabel.BackColor Then Return
            End If
        Next

        MessageBox.Show("You matched all the icons!", "Congratulations")
        Close()
    End Sub
End Class