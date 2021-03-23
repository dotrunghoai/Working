Imports CommonDB
Imports PublicUtility
Public Class FrmASStock
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmASStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        btnEdit.Enabled = False
        btnImport.Enabled = False
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@YYMM", dteMonth.DateTime.ToString("yyyyMM"))
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_CIS_SiteStock_LoadASStock", para)
        GridControlSetFormat(GridView1, 2)
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("ActQty").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(String.Format("UPDATE CIS_SiteStock_ASStock
                                                SET {0} = @Value
                                                WHERE YYMM = '{1}'
                                                AND JCode = '{2}'",
                                                e.Column.FieldName,
                                                GridView1.GetFocusedRowCellValue("YYMM"),
                                                GridView1.GetFocusedRowCellValue("JCode")),
                                                para)
            If e.Column.FieldName = "ActQty" Then
                Dim ActQty = IIf(IsNumeric(GridView1.GetFocusedRowCellValue("ActQty")),
                                            GridView1.GetFocusedRowCellValue("ActQty"), 0)
                Dim SysQty = IIf(IsNumeric(GridView1.GetFocusedRowCellValue("SysQty")),
                                            GridView1.GetFocusedRowCellValue("SysQty"), 0)
                GridView1.SetFocusedRowCellValue("Diff", ActQty - SysQty)
            End If
        End If
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
                If IsDBNull(r("JCode")) Then Continue For
                Dim obj As New CIS_SiteStock_ASStock
                obj.YYMM_K = r("YYMM")
                obj.JCode_K = r("JCode")
                If IsNumeric(r("Sys Qty")) Then
                    obj.SysQty = r("Sys Qty")
                End If
                If IsNumeric(r("Act Qty")) Then
                    obj.ActQty = r("Act Qty")
                End If
                obj.CreatedUser = CurrentUser.UserID
                obj.CreatedDate = Date.Now
                If _db.ExistObject(obj) Then
                    _db.Update(obj)
                Else
                    _db.Insert(obj)
                    succ += 1
                End If
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