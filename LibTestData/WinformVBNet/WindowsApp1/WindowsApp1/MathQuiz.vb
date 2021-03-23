Public Class MathQuiz
    Inherits Form
    Private randomizer As Random = New Random()

    Dim addend1 As Integer
    Dim addend2 As Integer

    Dim minuend As Integer
    Dim subtrahend As Integer

    Dim multiplicand As Integer
    Dim multiplier As Integer

    Dim dividend As Integer
    Dim divisor As Integer

    Dim timeLeft As Integer

    Public Sub StartTheQuiz()
        'Phep cong
        addend1 = randomizer.Next(50)
        addend2 = randomizer.Next(51)
        plusLeftLabel.Text = addend1.ToString()
        plusRightLabel.Text = addend2.ToString()
        sum.Value = 0

        'Phep tru
        minuend = randomizer.Next(1, 101)
        subtrahend = randomizer.Next(1, minuend)
        minusLeftLabel.Text = minuend.ToString()
        minusRightLabel.Text = subtrahend.ToString()
        difference.Value = 0

        'Phep nhan
        multiplicand = randomizer.Next(2, 11)
        multiplier = randomizer.Next(2, 11)
        timesLeftLabel.Text = multiplicand.ToString()
        timesRightLabel.Text = multiplier.ToString()
        product.Value = 0

        'Phep chia
        divisor = randomizer.Next(2, 11)
        Dim temporaryQuotient As Integer = randomizer.Next(2, 11)
        dividend = divisor * temporaryQuotient
        dividedLeftLabel.Text = dividend.ToString()
        dividedRightLabel.Text = divisor.ToString()
        quotient.Value = 0

        timeLeft = 30
        timeLabel.Text = "30 seconds"
        Timer1.Start()
    End Sub

    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        StartTheQuiz()
        sum.Value = 0
        difference.Value = 0
        product.Value = 0
        quotient.Value = 0
        startButton.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If checkTheAnswer() Then
            Timer1.Stop()
            MessageBox.Show("You got all the answers right!", "Congratulation!")
            startButton.Enabled = True
        ElseIf timeLeft > 0 Then
            timeLeft = timeLeft - 1
            timeLabel.Text = timeLeft & " seconds"
        Else
            Timer1.[Stop]()
            timeLabel.Text = "Time is up!"
            MessageBox.Show("You didn't finish im time.", "Sorry!")
            sum.Value = addend1 + addend2
            difference.Value = minuend - subtrahend
            product.Value = multiplicand * multiplier
            quotient.Value = dividend / divisor
            startButton.Enabled = True
        End If
    End Sub


    Private Function checkTheAnswer() As Boolean
        If (addend1 + addend2 = sum.Value) AndAlso (minuend - subtrahend = difference.Value) AndAlso (multiplicand * multiplier = product.Value) AndAlso (dividend / divisor = quotient.Value) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub answer_Enter(sender As Object, e As EventArgs) Handles sum.Enter, quotient.Enter, product.Enter, difference.Enter
        Dim answerBox As NumericUpDown = TryCast(sender, NumericUpDown)
        If answerBox IsNot Nothing Then
            Dim lengthOfAnswer As Integer = answerBox.Value.ToString().Length
            answerBox.Select(0, lengthOfAnswer)
        End If
    End Sub

End Class