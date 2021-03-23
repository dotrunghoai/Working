Imports CommonDB
Imports PublicUtility
Public Class FrmStockWIP
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmStockWIP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShow.PerformClick()
    End Sub
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.FillDataTable("SELECT *
                                                     FROM PLM_ProductStock_WIP
                                                     ORDER BY TuanImport desc, ProductCode, RevisionCode, ComponentCode, ProcessNumber, ProcessCode")
        GridControlSetFormat(GridView1, 1)
    End Sub


    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub
End Class