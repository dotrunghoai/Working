Imports CommonDB
Imports PublicUtility
Public Class FrmCostingBOM
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmCostingBOM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteMonth.EditValue = Date.Now
        btnShow.PerformClick()
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@YYMM", dteMonth.DateTime.ToString("yyyyMM"))
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_CIS_CT_LoadCostingBOM", para)
        GridControlSetFormat(GridView1, 1)
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub btnGetData_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnGetData.ItemClick
        Dim paraA(0) As SqlClient.SqlParameter
        paraA(0) = New SqlClient.SqlParameter("@YYMM", dteMonth.DateTime.ToString("yyyyMM"))
        _db.ExecuteStoreProcedure("sp_CIS_CT_UpdateCostingBOM", paraA)
        _db.ExecuteStoreProcedure("sp_CIS_CT_UpdateWIPCosting", paraA)

        Dim paraB(1) As SqlClient.SqlParameter
        paraB(0) = New SqlClient.SqlParameter("@YYMM", dteMonth.DateTime.ToString("yyyyMM"))
        paraB(1) = New SqlClient.SqlParameter("@PreYM", dteMonth.DateTime.AddMonths(-1).ToString("yyyyMM"))
        _db.ExecuteStoreProcedure("sp_CIS_CT_UpdateFinalCosting", paraB)

        Dim paraC(3) As SqlClient.SqlParameter
        paraC(0) = New SqlClient.SqlParameter("@YYMM", dteMonth.DateTime.ToString("yyyyMM"))
        paraC(1) = New SqlClient.SqlParameter("@PreYM", dteMonth.DateTime.AddMonths(-1).ToString("yyyyMM"))
        paraC(2) = New SqlClient.SqlParameter("@StartDate", GetStartDayOfMonth(dteMonth.DateTime))
        paraC(3) = New SqlClient.SqlParameter("@EndDate", GetEndDayOfMonth(dteMonth.DateTime))
        _db.ExecuteStoreProcedure("sp_CIS_CT_UpdateProcessResult", paraC)
        ShowSuccess()
    End Sub
End Class