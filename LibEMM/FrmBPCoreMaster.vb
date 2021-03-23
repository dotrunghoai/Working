Imports CommonDB
Public Class FrmBPCoreMaster
    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub mnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_LoadBPCoreMaster")
        GridControlSetFormat(GridView1, 2)
    End Sub

    Private Sub mnuExport_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub FrmBPCoreMaster_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub
End Class