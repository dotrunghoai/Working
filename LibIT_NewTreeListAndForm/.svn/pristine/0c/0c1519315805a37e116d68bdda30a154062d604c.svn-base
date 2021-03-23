Imports CommonDB
Imports PublicUtility
Public Class FrmAuthorizationControl
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmAuthorizationControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteStart.EditValue = Date.Now.AddMonths(-1)
        dteEnd.EditValue = Date.Now
        btnShow.PerformClick()
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", dteStart.DateTime)
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dteEnd.DateTime))
        GridControl1.DataSource = _db.FillDataTable("
            SELECT h.UserID, ISNULL(g.EName, k.FullName) AS EName, g.Section, g.Observation, h.FormID, m.TextVietNam AS ModuleName, 
                d.TextVietNam AS FormName, h.IsEdit, h.IsAdmin, h.CreateUser, h.CreateDate, h.CreateMachine
            FROM Main_UserRight AS h
            LEFT JOIN Main_FormRight AS d
            ON h.FormID = d.FormID
			LEFT JOIN Main_FormRight AS m
			ON d.ParentID = m.FormID
            LEFT JOIN HRM_Emloyee AS g
            ON h.UserID = g.ECode
            LEFT JOIN Main_User AS k
            ON h.UserID = k.UserID
            WHERE h.CreateDate BETWEEN @StartDate AND @EndDate
            ORDER BY h.CreateDate DESC", para)
        GridControlSetFormat(GridView1, 1)
        GridView1.Columns("EName").Width = 150
        GridView1.Columns("Section").Width = 100
        GridView1.Columns("ModuleName").Width = 170
        GridView1.Columns("FormName").Width = 170
        GridView1.Columns("CreateDate").Width = 120
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub
End Class