Imports CommonDB
Imports PublicUtility
Public Class FrmMaterialInAll
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmMaterialInAll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteMonth.EditValue = Date.Now
        btnShow.PerformClick()
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@YYMM", dteMonth.DateTime.ToString("yyyyMM"))
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_CIS_SiteStock_LoadMaterialInAll", para)
        GridControlSetFormat(GridView1, 2)
    End Sub

    Private Sub btnGetData_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnGetData.ItemClick
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@YYMM", dteMonth.DateTime.ToString("yyyyMM"))
        _db.ExecuteStoreProcedure("sp_CIS_SiteStock_GetMaterialInAll", para)
        ShowSuccess()
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub
End Class