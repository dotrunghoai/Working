﻿Imports CommonDB
Imports PublicUtility
Public Class FrmStockFG
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmStockFG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShow.PerformClick()
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.FillDataTable("SELECT * 
                                                     FROM PLM_ProductStock_FG 
                                                     ORDER BY TuanImport DESC, ProductCode, RevisionCode, LotNumber")
        GridControlSetFormat(GridView1, 1)
    End Sub

End Class