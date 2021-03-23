Imports System.Globalization
Imports System.Windows.Forms
Imports System.IO
Imports vb = Microsoft.VisualBasic

Public Class clsApplication
    Function convertDateAS(ByVal stnum As String) As DateTime
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Dim strDate As String = vb.Mid(stnum, 5, 2) + "/" + vb.Right(stnum, 2) + "/" + vb.Left(stnum, 4)
            Dim receivedDate As DateTime = DateTime.ParseExact(strDate, "MM/dd/yyyy", provider)
            Return receivedDate
        Catch ex As Exception
            Return DateTime.MinValue
        End Try
    End Function

    Function checkDate(ByVal p_dateString As String) As Boolean
        Dim strDay As String = String.Empty
        Dim strMonth As String = String.Empty
        Dim strYear As String = String.Empty
        Try
            strDay = Mid(p_dateString, 1, 2)
            strMonth = Mid(p_dateString, 4, 2)
            strYear = Mid(p_dateString, 7, 4)
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Dim receivedDate As DateTime = DateTime.ParseExact(strDay & "/" & strMonth & "/" & strYear, "dd/MM/yyyy", provider)
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Function convertDate(ByVal p_dateString As String) As DateTime
        If p_dateString.Length < 10 Then
            Return DateTime.MinValue
        End If
        Dim strDay As String = String.Empty
        Dim strMonth As String = String.Empty
        Dim strYear As String = String.Empty
        strDay = Mid(p_dateString, 1, 2)
        strMonth = Mid(p_dateString, 4, 2)
        strYear = Mid(p_dateString, 7, 4)
        Dim provider As CultureInfo = CultureInfo.InvariantCulture
        Dim receivedDate As DateTime = DateTime.ParseExact(strDay & "/" & strMonth & "/" & strYear, "dd/MM/yyyy", provider)
        Return receivedDate
    End Function

    Function ReadLotNo(ByVal JCode As String, ByVal LotNo As String) As DateTime
        Dim yyyy As Integer
        Dim MM As Integer
        Dim dd As Integer
        Select Case JCode
            Case "J02191", "J02212"
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(1, 1))
                MM = LotNo.Substring(2, 2)
                dd = LotNo.Substring(4, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J00061", "J02494", "J02572"
                Dim y As String = LotNo.Substring(3, 1)
                Dim yAct As String = ""
                Select Case y
                    Case "2"
                        If DateTime.Now >= New DateTime(2040, 1, 1) Then
                            yAct = "40"
                        ElseIf DateTime.Now >= New DateTime(2035, 1, 1) Then
                            yAct = "35"
                        ElseIf DateTime.Now >= New DateTime(2030, 1, 1) Then
                            yAct = "30"
                        ElseIf DateTime.Now >= New DateTime(2025, 1, 1) Then
                            yAct = "25"
                        ElseIf DateTime.Now >= New DateTime(2020, 1, 1) Then
                            yAct = "20"
                        End If
                        Exit Select
                    Case "6"
                        If DateTime.Now >= New DateTime(2041, 1, 1) Then
                            yAct = "41"
                        ElseIf DateTime.Now >= New DateTime(2036, 1, 1) Then
                            yAct = "36"
                        ElseIf DateTime.Now >= New DateTime(2031, 1, 1) Then
                            yAct = "31"
                        ElseIf DateTime.Now >= New DateTime(2026, 1, 1) Then
                            yAct = "26"
                        ElseIf DateTime.Now >= New DateTime(2021, 1, 1) Then
                            yAct = "21"
                        End If
                        Exit Select
                    Case "8"
                        If DateTime.Now >= New DateTime(2042, 1, 1) Then
                            yAct = "42"
                        ElseIf DateTime.Now >= New DateTime(2037, 1, 1) Then
                            yAct = "37"
                        ElseIf DateTime.Now >= New DateTime(2032, 1, 1) Then
                            yAct = "32"
                        ElseIf DateTime.Now >= New DateTime(2027, 1, 1) Then
                            yAct = "27"
                        ElseIf DateTime.Now >= New DateTime(2022, 1, 1) Then
                            yAct = "22"
                        End If
                        Exit Select
                    Case "0"
                        If DateTime.Now >= New DateTime(2043, 1, 1) Then
                            yAct = "43"
                        ElseIf DateTime.Now >= New DateTime(2038, 1, 1) Then
                            yAct = "38"
                        ElseIf DateTime.Now >= New DateTime(2033, 1, 1) Then
                            yAct = "33"
                        ElseIf DateTime.Now >= New DateTime(2028, 1, 1) Then
                            yAct = "28"
                        ElseIf DateTime.Now >= New DateTime(2023, 1, 1) Then
                            yAct = "23"
                        End If
                        Exit Select
                    Case "4"
                        If DateTime.Now >= New DateTime(2044, 1, 1) Then
                            yAct = "44"
                        ElseIf DateTime.Now >= New DateTime(2039, 1, 1) Then
                            yAct = "39"
                        ElseIf DateTime.Now >= New DateTime(2034, 1, 1) Then
                            yAct = "34"
                        ElseIf DateTime.Now >= New DateTime(2029, 1, 1) Then
                            yAct = "29"
                        ElseIf DateTime.Now >= New DateTime(2024, 1, 1) Then
                            yAct = "24"
                        Else
                            yAct = "19"
                        End If
                        Exit Select
                End Select
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 2) + yAct)
                MM = LotNo.Substring(4, 2) / 3
                dd = LotNo.Substring(6, 2) - 30
                Return New DateTime(yyyy, MM, dd)
            Case "J00193"
                If LotNo.Substring(0, 2) Mod 12 <> 0 Then
					yyyy = 2018 + Math.Floor(CInt(LotNo.Substring(0, 2)) / 12)
					MM = LotNo.Substring(0, 2) Mod 12
                Else
					yyyy = 2018 + CInt(LotNo.Substring(0, 2)) / 12 - 1
					MM = 12
                End If
                
                dd = 1
                Return New DateTime(yyyy, MM, dd)
            Case "J01894"
                yyyy = DateTime.Now.ToString("yyyy").Substring(0, 2) & LotNo.Substring(0, 2)
                MM = LotNo.Substring(2, 2)
                dd = 1
                Return New DateTime(yyyy, MM, dd)
            Case "J00020", "J00021", "J00022", "J02074", "J02944"
                yyyy = DateTime.Now.ToString("yyyy").Substring(0, 2) & LotNo.Substring(0, 2)
                MM = LotNo.Substring(2, 2)
                dd = LotNo.Substring(4, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J00094", "J00005", "J00006", "J00007", "J00008", "J00047", "J00048"
                yyyy = DateTime.Now.ToString("yyyy").Substring(0, 2) & LotNo.Substring(3, 2)
                MM = LotNo.Substring(5, 2)
                dd = LotNo.Substring(7, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J00001", "J00002"
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(0, 1))
                MM = LotNo.Substring(1, 2)
                dd = 1
                Return New DateTime(yyyy, MM, dd)
            Case "J00084"
                yyyy = DateTime.Now.ToString("yyyy").Substring(0, 2) + LotNo.Substring(0, 2)
                MM = LotNo.Substring(2, 2)
                dd = LotNo.Substring(4, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J02748", "J02749", "J03047", "J00098"
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(0, 1))
                Dim m As String = LotNo.Substring(1, 1)
                Select Case m
                    Case "A"
                        MM = 1
                        Exit Select
                    Case "B"
                        MM = 2
                        Exit Select
                    Case "C"
                        MM = 3
                        Exit Select
                    Case "D"
                        MM = 4
                        Exit Select
                    Case "E"
                        MM = 5
                        Exit Select
                    Case "F"
                        MM = 6
                        Exit Select
                    Case "G"
                        MM = 7
                        Exit Select
                    Case "H"
                        MM = 8
                        Exit Select
                    Case "I"
                        MM = 9
                        Exit Select
                    Case "J"
                        MM = 10
                        Exit Select
                    Case "K"
                        MM = 11
                        Exit Select
                    Case "L"
                        MM = 12
                        Exit Select
                End Select
                dd = LotNo.Substring(2, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J00105"
                yyyy = DateTime.Now.ToString("yyyy").Substring(0, 2) & LotNo.Substring(1, 2)
                MM = LotNo.Substring(3, 2)
                dd = LotNo.Substring(5, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J00089"
                dd = LotNo.Substring(0, 2)
                MM = LotNo.Substring(2, 2)
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(5, 1))
                Return New DateTime(yyyy, MM, dd)
            Case "J00861", "J00862", "J02822", "J02939", "J03325"
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(1, 1))
                MM = LotNo.Substring(2, 2)
                dd = LotNo.Substring(4, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J03017", "J03018", "J03019", "J03020", "J03021", "J03030", "J03031", "J03045", "J03052", "J03064", "J03116", "J03117"
                dd = LotNo.Substring(2, 2)
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(4, 1))
                MM = LotNo.Substring(5, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J00079"
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(0, 1))
                MM = LotNo.Substring(2, 2)
                dd = 1
                Return New DateTime(yyyy, MM, dd)
            Case "J00097"
                yyyy = DateTime.Now.ToString("yyyy").Substring(0, 2) & LotNo.Substring(4, 2)
                MM = LotNo.Substring(6, 2)
                dd = LotNo.Substring(8, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J00044", "J00046"
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(0, 1))
                Dim m As String = LotNo.Substring(1, 1)
                Select Case m
                    Case "A"
                        MM = 1
                        Exit Select
                    Case "B"
                        MM = 2
                        Exit Select
                    Case "C"
                        MM = 3
                        Exit Select
                    Case "D"
                        MM = 4
                        Exit Select
                    Case "E"
                        MM = 5
                        Exit Select
                    Case "F"
                        MM = 6
                        Exit Select
                    Case "G"
                        MM = 7
                        Exit Select
                    Case "H"
                        MM = 8
                        Exit Select
                    Case "J"
                        MM = 9
                        Exit Select
                    Case "K"
                        MM = 10
                        Exit Select
                    Case "L"
                        MM = 11
                        Exit Select
                    Case "M"
                        MM = 12
                        Exit Select
                End Select
                dd = 1
                Return New DateTime(yyyy, MM, dd)
            Case "J00085"
                MM = LotNo.Substring(1, 2)
                dd = LotNo.Substring(3, 2)
                yyyy = DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(5, 1)
                Return New DateTime(yyyy, MM, dd)
            Case "J00075", "J00201", "J00203", "J00798", "J02636", "J02940", "J02943", "J02947", "J02956", "J02989", "J03071", "J03072", "J03073", "J03079"
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(0, 1))
                Dim m As String = LotNo.Substring(1, 1)
                Select Case m
                    Case "X"
                        MM = 10
                        Exit Select
                    Case "Y"
                        MM = 11
                        Exit Select
                    Case "Z"
                        MM = 12
                        Exit Select
                    Case Else
                        MM = m
                        Exit Select
                End Select
                dd = LotNo.Substring(2, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J00763"
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(2, 1))
                Dim m As String = LotNo.Substring(3, 1)
                Select Case m
                    Case "A"
                        MM = 1
                        Exit Select
                    Case "B"
                        MM = 2
                        Exit Select
                    Case "C"
                        MM = 3
                        Exit Select
                    Case "D"
                        MM = 4
                        Exit Select
                    Case "E"
                        MM = 5
                        Exit Select
                    Case "F"
                        MM = 6
                        Exit Select
                    Case "G"
                        MM = 7
                        Exit Select
                    Case "H"
                        MM = 8
                        Exit Select
                    Case "I"
                        MM = 9
                        Exit Select
                    Case "J"
                        MM = 10
                        Exit Select
                    Case "K"
                        MM = 11
                        Exit Select
                    Case "L"
                        MM = 12
                        Exit Select
                End Select
                dd = LotNo.Substring(4, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J00104"
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(0, 1))
                Dim m As String = LotNo.Substring(2, 1)
                Select Case m
                    Case "A"
                        MM = 10
                        Exit Select
                    Case "B"
                        MM = 11
                        Exit Select
                    Case "C"
                        MM = 12
                        Exit Select
                    Case Else
                        MM = m
                        Exit Select
                End Select
                dd = LotNo.Substring(3, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J00143"
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(0, 1))
                MM = LotNo.Substring(1, 2)
                dd = LotNo.Substring(3, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J00856", "J02884", "J03008"
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(1, 1))
                Dim m As String = LotNo.Substring(2, 1)
                Select Case m
                    Case "X"
                        MM = 10
                        Exit Select
                    Case "Y"
                        MM = 11
                        Exit Select
                    Case "Z"
                        MM = 12
                        Exit Select
                    Case Else
                        MM = m
                        Exit Select
                End Select
                dd = LotNo.Substring(3, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J01591"
                Dim LotNoTemp As String = vb.Right(LotNo, 11)
                yyyy = LotNoTemp.Substring(0, 4)
                MM = LotNoTemp.Substring(4, 2)
                dd = LotNoTemp.Substring(6, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J00056", "J00057", "J00058", "J00059", "J01999", "J02000", "J02001", "J02002"
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(3, 1))
                Dim m As String = LotNo.Substring(4, 1)
                Select Case m
                    Case "A"
                        MM = 1
                        Exit Select
                    Case "B"
                        MM = 2
                        Exit Select
                    Case "C"
                        MM = 3
                        Exit Select
                    Case "D"
                        MM = 4
                        Exit Select
                    Case "E"
                        MM = 5
                        Exit Select
                    Case "F"
                        MM = 6
                        Exit Select
                    Case "G"
                        MM = 7
                        Exit Select
                    Case "H"
                        MM = 8
                        Exit Select
                    Case "I"
                        MM = 9
                        Exit Select
                    Case "J"
                        MM = 10
                        Exit Select
                    Case "K"
                        MM = 11
                        Exit Select
                    Case "L"
                        MM = 12
                        Exit Select
                End Select
                dd = LotNo.Substring(5, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J00210", "J01201", "J01352", "J01437", "J01811"
                yyyy = Integer.Parse(DateTime.Now.ToString("yyyy").Substring(0, 3) & LotNo.Substring(1, 1))
                Dim m As String = LotNo.Substring(2, 1)
                Select Case m
                    Case "A"
                        MM = 10
                        Exit Select
                    Case "B"
                        MM = 11
                        Exit Select
                    Case "X"
                        MM = 12
                        Exit Select
                    Case Else
                        MM = m
                        Exit Select
                End Select
                If m = "X" Then
                    dd = LotNo.Substring(4, 2)
                Else
                    dd = LotNo.Substring(3, 2)
                End If
                Return New DateTime(yyyy, MM, dd)
            Case "J00076", "J00077", "J00078", "J00188"
                yyyy = DateTime.Now.ToString("yyyy").Substring(0, 2) & LotNo.Substring(1, 2)
                Dim m As String = LotNo.Substring(3, 1)
                Select Case m
                    Case "X"
                        MM = 10
                        Exit Select
                    Case "Y"
                        MM = 11
                        Exit Select
                    Case "Z"
                        MM = 12
                        Exit Select
                    Case Else
                        MM = m
                        Exit Select
                End Select
                dd = LotNo.Substring(4, 2)
                Return New DateTime(yyyy, MM, dd)
            Case "J03181"
                'MM = LotNo.Substring(4, 2)
                'dd = LotNo.Substring(6, 2)
                'yyyy = DateTime.Now.ToString("yyyy").Substring(0, 2) & LotNo.Substring(0, 2)
                'Return New DateTime(yyyy, MM, dd)
                Return DateTime.Now
            Case "J03515"
                MM = LotNo.Substring(2, 2)
                dd = LotNo.Substring(4, 2)
                yyyy = DateTime.Now.ToString("yyyy").Substring(0, 2) & LotNo.Substring(0, 2)
                Return New DateTime(yyyy, MM, dd)
            Case Else
                Return DateTime.MinValue
        End Select
        Return DateTime.MinValue
    End Function
End Class
