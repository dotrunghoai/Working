Imports CommonDB
Imports PublicUtility
Imports LibEntity
Public Class TestLoadForm
    Dim csdl As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim LotNo As String = txtNhapDuLieu.Text
        Dim yyyy As Integer
        Dim MM As Integer
        Dim dd As Integer
        Dim y As String = LotNo.Substring(3, 1)
        Dim chuoi As String = ""
        Select Case y
            Case "2"
                chuoi = "5"
                Exit Select
            Case "6"
                chuoi = "6"
                Exit Select
            Case "8"
                chuoi = "7"
                Exit Select
            Case "0"
                chuoi = "8"
                Exit Select
            Case "4"
                chuoi = "9"
                Exit Select
        End Select
        yyyy = Integer.Parse("201" + chuoi)
        MM = LotNo.Substring(4, 2) / 3
        dd = LotNo.Substring(6, 2) - 30
        lblTest.Text = New DateTime(yyyy, MM, dd)
    End Sub
End Class