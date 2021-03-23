Imports CommonDB
Imports PublicUtility
Public Class FrmShowPoHeThong
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmShowPoHeThong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShow.PerformClick()
    End Sub
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.FillDataTable("SELECT *
                                                     FROM PLM_PoHeThong
                                                     ORDER BY TuanImport DESC, OrderProductCode")
        GridControlSetFormat(GridView1)
    End Sub

End Class