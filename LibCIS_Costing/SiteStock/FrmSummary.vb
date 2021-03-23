Imports CommonDB
Imports PublicUtility
Public Class FrmSummary
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteMonth.EditValue = Date.Now
        btnShow.PerformClick()
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@YM", dteMonth.DateTime.ToString("yyyyMM"))
        para(1) = New SqlClient.SqlParameter("@PreYM", dteMonth.DateTime.AddMonths(-1).ToString("yyyyMM"))
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_CIS_SiteStock_MaterialSummary", para)
        GridControlSetFormat(GridView1, 2)
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub
End Class