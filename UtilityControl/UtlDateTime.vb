Public Class UtlDateTime

    Enum EnumDateEnglish
        Custom
        Today
        Yesterday
        This_Week
        This_Month
        This_Year
        Before_Week
        Before_Month
        Before_Year
    End Enum


    Public Property StartDate As DateTime
        Set(ByVal value As DateTime)
            dtpStartDateTime.Value = value
        End Set
        Get
            Return dtpStartDateTime.Value
        End Get
    End Property

    Public Property EndDate As DateTime
        Set(ByVal value As DateTime)
            dtpEndDateTime.Value = value
        End Set
        Get
            Return dtpEndDateTime.Value
        End Get
    End Property
    Public Property EnableControl As Boolean
        Set(ByVal value As Boolean)
            ckbUse.Checked = value
        End Set
        Get
            Return ckbUse.Checked
        End Get
    End Property

    Private Sub ckbUse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbUse.CheckedChanged
        dtpEndDateTime.Enabled = ckbUse.Checked
        dtpStartDateTime.Enabled = ckbUse.Checked
        cboDate.Enabled = ckbUse.Checked
    End Sub


    Private Sub UtlDateTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboDate.Items.Add(EnumDateEnglish.Custom)
        cboDate.Items.Add(EnumDateEnglish.Today)
        cboDate.Items.Add(EnumDateEnglish.Yesterday)
        cboDate.Items.Add(EnumDateEnglish.This_Week)
        cboDate.Items.Add(EnumDateEnglish.This_Month)
        cboDate.Items.Add(EnumDateEnglish.This_Year)
        cboDate.Items.Add(EnumDateEnglish.Before_Week)
        cboDate.Items.Add(EnumDateEnglish.Before_Month)
        cboDate.Items.Add(EnumDateEnglish.Before_Year)

        'set default value Today
        cboDate.SelectedIndex = EnumDateEnglish.Today
        dtpStartDateTime.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)

    End Sub

    Private Sub cboDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDate.SelectedIndexChanged
        Select Case cboDate.SelectedIndex
            Case EnumDateEnglish.Today
                dtpStartDateTime.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)
                dtpEndDateTime.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59)
            Case EnumDateEnglish.Yesterday
                dtpStartDateTime.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(-1)
                dtpEndDateTime.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59).AddDays(-1)
            Case EnumDateEnglish.This_Week
                dtpStartDateTime.Value = GetBeginDayOfWeek(New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0))
                dtpEndDateTime.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59)
            Case EnumDateEnglish.This_Month
                dtpStartDateTime.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0)
                dtpEndDateTime.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59)
            Case EnumDateEnglish.This_Year
                dtpStartDateTime.Value = New DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0)
                dtpEndDateTime.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59)
            Case EnumDateEnglish.Before_Week
                dtpStartDateTime.Value = GetBeginDayOfBeforeWeek(New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0))
                dtpEndDateTime.Value = GetEndDayOfBeforeWeek(New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59))
            Case EnumDateEnglish.Before_Month
                dtpStartDateTime.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0).AddMonths(-1)
                dtpEndDateTime.Value = GetEndDayOfMonth(DateTime.Now.AddMonths(-1))
            Case EnumDateEnglish.Before_Year
                dtpStartDateTime.Value = New DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0).AddYears(-1)
                dtpEndDateTime.Value = New DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59).AddYears(-1)
            Case EnumDateEnglish.Custom
                dtpStartDateTime.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)
                dtpEndDateTime.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59)
        End Select
    End Sub

    Function GetBeginDayOfWeek(ByVal datetime As DateTime) As DateTime
        Select Case datetime.DayOfWeek
            Case DayOfWeek.Monday
                Return datetime
            Case DayOfWeek.Tuesday
                Return datetime.AddDays(-1)
            Case DayOfWeek.Wednesday
                Return datetime.AddDays(-2)
            Case DayOfWeek.Thursday
                Return datetime.AddDays(-3)
            Case DayOfWeek.Friday
                Return datetime.AddDays(-4)
            Case DayOfWeek.Saturday
                Return datetime.AddDays(-5)
            Case DayOfWeek.Sunday
                Return datetime.AddDays(-6)
        End Select
        Return datetime
    End Function

    Function GetBeginDayOfBeforeWeek(ByVal datetime As DateTime) As DateTime
        Select Case datetime.DayOfWeek
            Case DayOfWeek.Monday
                Return datetime.AddDays(-7)
            Case DayOfWeek.Tuesday
                Return datetime.AddDays(-8)
            Case DayOfWeek.Wednesday
                Return datetime.AddDays(-9)
            Case DayOfWeek.Thursday
                Return datetime.AddDays(-10)
            Case DayOfWeek.Friday
                Return datetime.AddDays(-11)
            Case DayOfWeek.Saturday
                Return datetime.AddDays(-12)
            Case DayOfWeek.Sunday
                Return datetime.AddDays(-13)
        End Select
        Return datetime
    End Function
    Function GetEndDayOfBeforeWeek(ByVal datetime As DateTime) As DateTime
        Select Case datetime.DayOfWeek
            Case DayOfWeek.Monday
                Return datetime.AddDays(-1)
            Case DayOfWeek.Tuesday
                Return datetime.AddDays(-2)
            Case DayOfWeek.Wednesday
                Return datetime.AddDays(-3)
            Case DayOfWeek.Thursday
                Return datetime.AddDays(-4)
            Case DayOfWeek.Friday
                Return datetime.AddDays(-5)
            Case DayOfWeek.Saturday
                Return datetime.AddDays(-6)
            Case DayOfWeek.Sunday
                Return datetime.AddDays(-7)
        End Select
        Return datetime
    End Function

    Function GetEndDayOfMonth(ByVal datetime As DateTime) As DateTime
        Select Case datetime.Month
            Case 1, 3, 5, 7, 8, 10, 12
                Return New DateTime(datetime.Year, datetime.Month, 31, 23, 59, 59)
            Case 2
                If datetime.Year Mod 4 = 0 Then
                    Return New DateTime(datetime.Year, datetime.Month, 29, 23, 59, 59)
                Else
                    Return New DateTime(datetime.Year, datetime.Month, 28, 23, 59, 59)
                End If
            Case 2, 4, 6, 9, 11
                Return New DateTime(datetime.Year, datetime.Month, 30, 23, 59, 59)
        End Select

        Return datetime
    End Function
End Class
