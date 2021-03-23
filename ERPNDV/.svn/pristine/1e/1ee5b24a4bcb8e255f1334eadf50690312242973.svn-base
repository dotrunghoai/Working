Imports PublicUtility

Public Class FrmTotalConnections

#Region "Variable"
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Public _uID As String = ""
#End Region

#Region "User function"
    Sub LoadAll()
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_Main_TotalConnections")

    End Sub
#End Region

#Region "Form function"

    Private Sub FrmGroupOfUser_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
         
        LoadAll()
    End Sub

    Private Sub mnuCheckall_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        LoadAll()
    End Sub
      

    Private Sub FrmGroupOfUser_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub GridView1_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged

    End Sub

    Private Sub BttExportExcel_Click(sender As Object, e As EventArgs) Handles bttExportExcel.Click
        GridControl1.MainView.ExportToXlsx("Export.xlsx")
    End Sub

#End Region

End Class