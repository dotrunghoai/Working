Imports CommonDB
Imports PublicUtility
Public Class FrmShowInMonth
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmShowInMonth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteMonth.EditValue = Date.Now
        btnShow.PerformClick()
    End Sub
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(3) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDayOfMonth(dteMonth.DateTime))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDayOfMonth(dteMonth.DateTime))
        para(2) = New SqlClient.SqlParameter("@Action", "GetEmployeeInMonth")
        If rdoInPhieu.Checked Then
            para(3) = New SqlClient.SqlParameter("@TypeShowInMonth", "InPhieu")
        Else
            para(3) = New SqlClient.SqlParameter("@TypeShowInMonth", DBNull.Value)
        End If
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_GA_CT_ReviewContract", para)
        GridControlSetFormat(GridView1, 1)
        GridView1.Columns("EName").Width = 200
        GridView1.OptionsView.ShowFooter = False
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub
End Class