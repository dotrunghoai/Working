Imports CommonDB
Imports PublicUtility
Public Class FrmShowWorkingHour
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmShowWorkingHour_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteStart.EditValue = GetStartDayOfMonth(Date.Now.Date)
        dteEnd.EditValue = GetEndDayOfMonth(Date.Now)
        btnShow.PerformClick()
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", dteStart.DateTime)
        para(1) = New SqlClient.SqlParameter("@EndDate", dteEnd.DateTime)
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_CIS_Work_LoadWorkingHour", para)
        GridControlSetFormat(GridView1, 6)
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub
End Class