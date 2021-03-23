Imports System.Globalization
Imports System.Windows.Forms
Imports System.IO

Public Class clsApplication
    Public Shared FileUploadPath As String = "S:\\COMMON\\PU1\\14. Chung tu (quan trong)"

    'Private Sub bttUpdatePO_Click(sender As System.Object, e As System.EventArgs) Handles bttUpdatePO.Click
    '    For Each r As DataGridViewRow In gridD.Rows
    '        If gridD.CurrentRow.Cells("POID").Value Is DBNull.Value Then
    '            Dim sql As String = String.Format(" Select TFPONB  " +
    '                                               " from NDVDTA.MTDPOHP A " +
    '                                               " left join NDVDTA.MTEPOLP B on A.TDPONB=B.TEPONB " +
    '                                               " left join NDVDTA.MTFPODP C on A.TDPONB=C.TFPONB " +
    '                                               " where A.TDCNDT = 0 and TFSCDT>='{0}' and TEITCD='{1}' and TFSCQT={2} ",
    '                                              CType(r.Cells("DeliveryDate").Value, DateTime).AddDays(-2).ToString("yyyyMMdd"),
    '                                               r.Cells("JCode").Value,
    '                                               r.Cells("Quantity").Value)
    '            Dim myPO As Object = dbAS.ExecuteScalar(sql)
    '            If myPO <> "" Then
    '                Dim objD As New GSR_GoodsOrderDetail()
    '                objD.ID_K = r.Cells("ID").Value
    '                objD.OrderID_K = r.Cells("OrderID").Value
    '                nvd.GetObject(objD)
    '                objD.POID = myPO
    '                nvd.Update(objD)
    '                r.Cells("POID").Value = myPO
    '            End If
    '        End If
    '    Next
    '    ShowSuccess()
    'End Sub

    Function checkDate(ByVal p_dateString As String) As Boolean
        'Dim strSystemDateFormat As String = String.Empty
        Dim strDay As String = String.Empty
        Dim strMonth As String = String.Empty
        Dim strYear As String = String.Empty
        Try
            strDay = Mid(p_dateString, 1, 2)
            strMonth = Mid(p_dateString, 4, 2)
            strYear = Mid(p_dateString, 7, 4)
            'strSystemDateFormat = DateSerial(strYear, strMonth, strDay).Date
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Dim receivedDate As DateTime = DateTime.ParseExact(strDay & "/" & strMonth & "/" & strYear, "dd/MM/yyyy", provider)
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Function convertDate(ByVal p_dateString As String) As DateTime
        'Dim strSystemDateFormat As String = String.Empty
        Dim strDay As String = String.Empty
        Dim strMonth As String = String.Empty
        Dim strYear As String = String.Empty
        strDay = Mid(p_dateString, 1, 2)
        strMonth = Mid(p_dateString, 4, 2)
        strYear = Mid(p_dateString, 7, 4)
        'strSystemDateFormat = DateSerial(strYear, strMonth, strDay).Date
        Dim provider As CultureInfo = CultureInfo.InvariantCulture
        Dim receivedDate As DateTime = DateTime.ParseExact(strDay & "/" & strMonth & "/" & strYear, "dd/MM/yyyy", provider)
        Return receivedDate
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
End Class
