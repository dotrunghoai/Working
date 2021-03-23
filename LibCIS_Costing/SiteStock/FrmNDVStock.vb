Imports CommonDB
Imports DevExpress.XtraGrid.Views.Grid
Imports PublicUtility
Public Class FrmNDVStock
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _dbF As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Private Sub FrmNDVStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        btnNew.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnImport.Enabled = False
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@YYMM", dteMonth.DateTime.ToString("yyyyMM"))
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_CIS_SiteStock_LoadNDVStock", para)
        GridControlSetFormat(GridView1, 3)

        slueGroupCode.DataSource = _db.FillDataTable(String.Format("
            SELECT GroupCode, GroupName, Note
            FROM CIS_SiteStock_GroupName
            UNION
            SELECT h.GroupCode, 'X', 'X'
            FROM CIS_SiteStock_NDVStock AS h
            LEFT JOIN CIS_SiteStock_GroupName AS d
            ON h.GroupCode = d.GroupCode
            WHERE h.YYMM = '{0}'
            AND d.GroupCode IS NULL", dteMonth.DateTime.ToString("yyyyMM")))
        slueGroupCode.DisplayMember = "GroupCode"
        slueGroupCode.ValueMember = "GroupCode"
        slueGroupCode.PopulateViewColumns()
        slueGroupCode.View.Columns("GroupCode").Width = 75
        slueGroupCode.View.Columns("GroupName").Width = 150
        slueGroupCode.View.Columns("Note").Width = 150
        GridView1.Columns("GroupCode").ColumnEdit = slueGroupCode

        slueJCode.DataSource = _dbF.FillDataTable("SELECT ItemCode, ItemName
                                                    FROM t_ASMaterialItem")
        slueJCode.DisplayMember = "ItemCode"
        slueJCode.ValueMember = "ItemCode"
        slueJCode.PopulateViewColumns()
        slueJCode.View.Columns("ItemCode").Width = 75
        slueJCode.View.Columns("ItemName").Width = 300
        GridView1.Columns("JCode").ColumnEdit = slueJCode
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("GroupCode").OptionsColumn.ReadOnly = False
        GridView1.Columns("JCode").OptionsColumn.ReadOnly = False
        GridView1.Columns("Qty").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridControlReadOnly(GridView1, True)
        GridControlSetColorReadonly(GridView1)
        GridView1.Columns("Qty").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    End Sub
    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If IsDBNull(GridView1.GetFocusedRowCellValue("YYMM")) Then
                    If e.Column.FieldName <> "GroupCode" And e.Column.FieldName <> "JCode" Then
                        If IsDBNull(GridView1.GetFocusedRowCellValue("GroupCode")) Or
                            IsDBNull(GridView1.GetFocusedRowCellValue("JCode")) Then
                            ShowWarning("Phải nhập GroupCode và JCode trước !")
                            ReturnOldValue(GridView1)
                            Exit Sub
                        End If
                    ElseIf e.Column.FieldName = "GroupCode" And IsDBNull(GridView1.GetFocusedRowCellValue("JCode")) Then
                        Exit Sub
                    ElseIf e.Column.FieldName = "JCode" And IsDBNull(GridView1.GetFocusedRowCellValue("GroupCode")) Then
                        ShowWarning("Phải nhập GroupCode trước !")
                        ReturnOldValue(GridView1)
                        Exit Sub
                    End If
                    Dim obj As New CIS_SiteStock_NDVStock
                    obj.YYMM_K = dteMonth.DateTime.ToString("yyyyMM")
                    obj.GroupCode_K = GridView1.GetFocusedRowCellValue("GroupCode")
                    obj.JCode_K = GridView1.GetFocusedRowCellValue("JCode")
                    obj.CreatedUser = CurrentUser.UserID
                    obj.CreatedDate = Date.Now
                    If Not _db.ExistObject(obj) Then
                        _db.Insert(obj)
                        GridView1.SetFocusedRowCellValue("YYMM", obj.YYMM_K)
                    Else
                        ShowWarning("Bộ dữ liệu đã được tạo hôm nay, không thể tạo lần 2 !")
                        ReturnOldValue(GridView1)
                        Exit Sub
                    End If
                Else
                    If e.Column.FieldName = "GroupCode" Or e.Column.FieldName = "JCode" Then
                        GoTo SửaKhóa
                    End If
                End If
            End If
            If Not IsDBNull(GridView1.GetFocusedRowCellValue("YYMM")) And
                    (e.Column.FieldName = "GroupCode" Or e.Column.FieldName = "JCode") Then
SửaKhóa:
                If e.Column.FieldName = "GroupCode" Then
                    _db.ExecuteNonQuery(String.Format("UPDATE CIS_SiteStock_NDVStock
                                                    SET GroupCode = '{0}'
                                                    WHERE YYMM = '{1}'
                                                    AND GroupCode = '{2}'
                                                    AND JCode = '{3}'",
                                                    GridView1.GetFocusedRowCellValue("GroupCode"),
                                                    GridView1.GetFocusedRowCellValue("YYMM"),
                                                    GridView1.ActiveEditor.OldEditValue,
                                                    GridView1.GetFocusedRowCellValue("JCode")))
                ElseIf e.Column.FieldName = "JCode" Then
                    _db.ExecuteNonQuery(String.Format("UPDATE CIS_SiteStock_NDVStock
                                                    SET JCode = '{0}'
                                                    WHERE YYMM = '{1}'
                                                    AND GroupCode = '{2}'
                                                    AND JCode = '{3}'",
                                                    GridView1.GetFocusedRowCellValue("JCode"),
                                                    GridView1.GetFocusedRowCellValue("YYMM"),
                                                    GridView1.GetFocusedRowCellValue("GroupCode"),
                                                    GridView1.ActiveEditor.OldEditValue))
                End If
                Exit Sub
            End If
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(String.Format("UPDATE CIS_SiteStock_NDVStock
                                                SET {0} = @Value
                                                WHERE YYMM = '{1}'
                                                AND GroupCode = '{2}'
                                                AND JCode = '{3}'",
                                                e.Column.FieldName,
                                                GridView1.GetFocusedRowCellValue("YYMM"),
                                                GridView1.GetFocusedRowCellValue("GroupCode"),
                                                GridView1.GetFocusedRowCellValue("JCode")),
                                                para)
        End If
    End Sub
    Sub ReturnOldValue(gridV As GridView)
        Dim oldVal As Object = gridV.ActiveEditor.OldEditValue
        gridV.Columns(gridV.FocusedColumn.FieldName).OptionsColumn.ReadOnly = True
        gridV.SetFocusedRowCellValue(gridV.FocusedColumn.FieldName, oldVal)
        gridV.Columns(gridV.FocusedColumn.FieldName).OptionsColumn.ReadOnly = False
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            For Each r As Integer In GridView1.GetSelectedRows
                Dim obj As New CIS_SiteStock_NDVStock
                obj.YYMM_K = GridView1.GetRowCellValue(r, "YYMM")
                obj.GroupCode_K = GridView1.GetRowCellValue(r, "GroupCode")
                obj.JCode_K = GridView1.GetRowCellValue(r, "JCode")
                _db.Delete(obj)
            Next
            GridView1.DeleteSelectedRows()
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
                If IsDBNull(r("Group Code")) Or IsDBNull(r("JCode")) Then Continue For
                Dim obj As New CIS_SiteStock_NDVStock
                obj.YYMM_K = r("YYMM")
                obj.GroupCode_K = r("Group Code")
                obj.JCode_K = r("JCode")
                If IsNumeric(r("Qty")) Then
                    obj.Qty = r("Qty")
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