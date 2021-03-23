Imports CommonDB
Imports PublicUtility
Public Class FrmProductionCost
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmProductionCost_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShow.PerformClick()
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.FillDataTable("
            SELECT YYMM, ProductCost, OverHead, CreatedUser, CreatedDate
            FROM CIS_CT_ProductionCost
            ORDER BY YYMM DESC")
        GridControlSetFormat(GridView1, 0)
    End Sub
End Class