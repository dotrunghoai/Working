Imports CommonDB
Imports PublicUtility
Public Class FrmStockDetail
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmStockDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteMonth.EditValue = Date.Now
        btnShow.PerformClick()
        grcProgressBar.Visible = False
        Dim obj As New Main_UserRight
        obj.UserID_K = CurrentUser.UserID
        obj.FormID_K = Tag
        _db.GetObject(obj)
        If obj.IsEdit = False And obj.IsAdmin = False Then
            ViewAccess()
        End If
    End Sub
    Sub ViewAccess()
        btnImport.Enabled = False
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@YYMM", dteMonth.DateTime.ToString("yyyyMM"))
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_CIS_SiteStock_LoadStockDetail", para)
        GridControlSetFormat(GridView1, 2)
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
        Dim dtImp = ImportEXCEL(True)
        If dtImp.Rows.Count = 0 Then Exit Sub
        grcProgressBar.Visible = True
        Try
            _db.BeginTransaction()
            Dim succ = 0
            ProgressBarControl1.Properties.Step = 1
            ProgressBarControl1.Properties.PercentView = True
            ProgressBarControl1.Properties.Maximum = dtImp.Rows.Count
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Properties.ShowTitle = True
            For Each r As DataRow In dtImp.Rows
                If IsDBNull(r("JCode")) Or IsDBNull(r("PONo")) Then Continue For
                Dim obj As New CIS_SiteStock_StockDetail
                obj.ID_K = Guid.NewGuid.ToString()
                obj.YYMM = r("YYMM")
                obj.JCode = r("JCode")
                obj.PONO = r("PONo")
                If Not IsDBNull(r("Warehouse")) Then
                    obj.Warehouse = r("Warehouse")
                End If
                If IsNumeric(r("Qty")) Then
                    obj.Qty = r("Qty")
                End If
                obj.CreatedUser = CurrentUser.UserID
                obj.CreatedDate = Date.Now
                _db.Insert(obj)
                succ += 1
                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()
            Next
            ProgressBarControl1.EditValue = 0
            _db.Commit()
            ShowSuccess(succ)
        Catch ex As Exception
            _db.RollBack()
            ShowWarning(ex.Message)
        End Try
        grcProgressBar.Visible = False
    End Sub
End Class