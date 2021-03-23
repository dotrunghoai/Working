Imports System.Globalization
Imports System.Windows.Forms
Imports System.IO
Imports System.Reflection
Imports CommonDB
Imports PublicUtility
Imports LibEntity

Public Class clsUtil

    Public Shared FileTmp As String = Application.StartupPath + "\Template Excel\Template PP\PlanningDetail\"
    Public Shared FileExp As String = Application.StartupPath + "\Template Excel\Template PP\Export\PlanningDetail\"

    Shared Function GetRestDate(ByVal db As DBSql) As List(Of DataRow)
        Return db.FillDataTable(String.Format("SELECT [HolidayDate] as RestDate FROM [FPICS_HolidayDate]")).AsEnumerable().ToList()
    End Function

    Function CheckDate(ByVal p_dateString As String) As Boolean
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Dim receivedDate As DateTime = DateTime.ParseExact(Mid(p_dateString, 1, 2) & "/" & Mid(p_dateString, 4, 2) & "/" & Mid(p_dateString, 7, 4), "dd/MM/yyyy", provider)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Function HasValueDate(ByVal p_dateString As String) As Boolean
        Dim sDay As String = String.Empty
        Dim sMonth As String = String.Empty
        Dim sYear As String = String.Empty
        Try
            sDay = Mid(p_dateString, 1, 2).Trim()
            sMonth = Mid(p_dateString, 4, 2).Trim()
            sYear = Mid(p_dateString, 7, 4).Trim()
            If String.IsNullOrEmpty(sDay) And String.IsNullOrEmpty(sMonth) And String.IsNullOrEmpty(sYear) Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function ConvertDate(ByVal p_dateString As String) As DateTime
        If p_dateString.Length < 10 Then
            Return DateTime.MinValue
        End If
        Dim provider As CultureInfo = CultureInfo.InvariantCulture
        Return DateTime.ParseExact(Mid(p_dateString, 1, 2) & "/" & Mid(p_dateString, 4, 2) & "/" & Mid(p_dateString, 7, 4), "dd/MM/yyyy", provider)
    End Function

    Public Shared Sub UpLoadFile(ByVal SourceFileName As String, ByVal DestFileName As String, ByVal Override As Boolean)
        Try
            If (File.Exists(SourceFileName)) Then
                If (File.Exists(DestFileName)) Then
                    File.SetAttributes(DestFileName, FileAttributes.Archive)
                End If
                File.Copy(SourceFileName, DestFileName, Override)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub OpenFile(ByVal sFileName As String)
        Dim process As System.Diagnostics.ProcessStartInfo
        Try
            If (sFileName <> String.Empty) Then

                If (Not File.Exists(sFileName)) Then
                    MessageBox.Show("File: " + sFileName + "not exist on server", "File")
                    Return
                Else
                    process = New System.Diagnostics.ProcessStartInfo(sFileName)
                    process.Verb = "open"

                    Dim sprocess = New System.Diagnostics.Process()
                    sprocess.StartInfo = process
                    sprocess.Start()
                End If
            Else
                MessageBox.Show("File not exist", "File")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Shared Sub SetObjValue(Of T)(ByRef obj As T, ByVal row As DataRow)
        Try
            If row Is Nothing Then Exit Sub
            obj = Activator.CreateInstance(Of T)()

            Dim type As Type
            type = obj.GetType()
            Dim fields() As FieldInfo = type.GetFields()

            For index As Integer = 0 To fields.Length - 1
                If Not row.Table.Columns.Contains(fields(index).Name.Replace(PublicConst.Key, "")) Then
                    fields(index).SetValue(obj, Nothing)
                    Continue For
                End If

                Dim value As Object = row(fields(index).Name.Replace(PublicConst.Key, ""))
                If value IsNot DBNull.Value Then
                    If value.GetType() Is System.Type.GetType("System.Double") Then
                        fields(index).SetValue(obj, Convert.ToDecimal(value))
                    Else
                        fields(index).SetValue(obj, value)
                    End If
                Else
                    fields(index).SetValue(obj, Nothing)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub SetObjValue(Of T)(ByRef obj As T, ByVal cols() As String, ByVal row As DataRow, ByVal bIgnore As Boolean)
        Try
            If cols Is Nothing Then Exit Sub
            If cols.Length = 0 Then Exit Sub

            Dim type As Type
            type = obj.GetType()
            Dim fields() As FieldInfo = type.GetFields()

            For index As Integer = 0 To fields.Length - 1

                If Not row.Table.Columns.Contains(fields(index).Name.Replace(PublicConst.Key, "")) Then
                    Continue For
                End If

                Dim idx As Int16 = Array.IndexOf(cols, fields(index).Name.Replace(PublicConst.Key, ""))

                If Not bIgnore Then
                    If idx <> -1 Then
                        Dim value As Object = row(fields(index).Name.Replace(PublicConst.Key, ""))
                        If value IsNot DBNull.Value Then
                            If value.GetType() Is System.Type.GetType("System.Double") Then
                                fields(index).SetValue(obj, Convert.ToDecimal(value))
                            Else
                                fields(index).SetValue(obj, value)
                            End If
                        Else
                            fields(index).SetValue(obj, Nothing)
                        End If
                    End If
                Else
                    If idx = -1 Then
                        Dim value As Object = row(fields(index).Name.Replace(PublicConst.Key, ""))
                        If value IsNot DBNull.Value Then
                            If value.GetType() Is System.Type.GetType("System.Double") Then
                                fields(index).SetValue(obj, Convert.ToDecimal(value))
                            Else
                                fields(index).SetValue(obj, value)
                            End If
                        Else
                            fields(index).SetValue(obj, Nothing)
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function CheckNullRow(ByVal r As DataRow) As Boolean
        For Each col As DataColumn In r.Table.Columns
            If r(col.ColumnName) IsNot DBNull.Value Then Return False
        Next
        Return True
    End Function

    Public Shared Function CheckNullRow(ByVal r As DataGridViewRow) As Boolean
        For Each col As DataGridViewColumn In r.DataGridView.Columns
            If r.Cells(col.Name) IsNot DBNull.Value Then Return False
        Next
        Return True
    End Function

    Public Shared Function Number2String(ByVal number As Integer, ByVal isCaps As Boolean) As String
        Dim number1 As Integer = number \ 27
        Dim number2 As Integer = number - (number1 * 26)
        If number2 > 26 Then
            number1 = number1 + 1
            number2 = number - (number1 * 26)
        End If
        Dim a As Char = ChrW(If(isCaps, 65, 97) + (number1 - 1))
        Dim b As Char = ChrW(If(isCaps, 65, 97) + (number2 - 1))
        Dim c As Char = ChrW(If(isCaps, 65, 97) + (number - 1))
        Dim d As String = String.Concat(a, b)
        If number <= 26 Then
            Return c.ToString()
        Else
            Return d
        End If
    End Function

    Public Shared Function CopyToDataTable(Of T)(ByVal source As IEnumerable(Of T)) As DataTable
        Return New ObjectShredder(Of T)().Shred(source, Nothing, Nothing)
    End Function

    Public Shared Function CopyToDataTable(Of T)(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options As LoadOption?) As DataTable
        Return New ObjectShredder(Of T)().Shred(source, table, options)
    End Function

End Class
