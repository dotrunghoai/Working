Imports CommonDB
Imports PublicUtility
Public Class FrmWIPInventory
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmWIPInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_CIS_WIP_LoadInventory", para)
        GridControlSetFormat(GridView1, 1)

        slueGroupCode.DataSource = _db.FillDataTable(String.Format("
            SELECT GroupCode, GroupName, Note
            FROM CIS_WIP_GroupName
            UNION
            SELECT h.GroupCode, 'X', 'X'
            FROM CIS_WIP_Inventory AS h
            LEFT JOIN CIS_WIP_GroupName AS d
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
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("ProductCode").OptionsColumn.ReadOnly = False
        GridView1.Columns("RevisionCode").OptionsColumn.ReadOnly = False
        GridView1.Columns("ComponentCode").OptionsColumn.ReadOnly = False
        GridView1.Columns("ProcessNumber").OptionsColumn.ReadOnly = False
        GridView1.Columns("LotNumber").OptionsColumn.ReadOnly = False
        GridView1.Columns("ProcessCode").OptionsColumn.ReadOnly = False
        GridView1.Columns("GroupCode").OptionsColumn.ReadOnly = False
        GridView1.Columns("SysQty").OptionsColumn.ReadOnly = False
        GridView1.Columns("ActQty").OptionsColumn.ReadOnly = False
        GridView1.Columns("Note").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridControlReadOnly(GridView1, True)
        GridControlSetColorReadonly(GridView1)
        GridView1.Columns("SysQty").OptionsColumn.ReadOnly = False
        GridView1.Columns("ActQty").OptionsColumn.ReadOnly = False
        GridView1.Columns("Note").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            For Each r As Integer In GridView1.GetSelectedRows
                Dim obj As New CIS_WIP_Inventory
                obj.YYMM_K = GridView1.GetRowCellValue(r, "YYMM")
                obj.ProductCode_K = GridView1.GetRowCellValue(r, "ProductCode")
                obj.RevisionCode_K = GridView1.GetRowCellValue(r, "RevisionCode")
                obj.ComponentCode_K = GridView1.GetRowCellValue(r, "ComponentCode")
                obj.ProcessNumber_K = GridView1.GetRowCellValue(r, "ProcessNumber")
                obj.LotNumber_K = GridView1.GetRowCellValue(r, "LotNumber")
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
                If IsDBNull(r("ProductCode")) Then Continue For
                Dim obj As New CIS_WIP_Inventory
                obj.YYMM_K = r("YYMM")
                obj.ProductCode_K = r("Product Code")
                obj.RevisionCode_K = r("Revision Code")
                obj.ComponentCode_K = r("Component Code")
                obj.ProcessNumber_K = r("Process Number")
                obj.LotNumber_K = r("Lot Number")
                obj.ProcessCode = r("Process Code")
                obj.GroupCode = r("Group Code")
                If IsNumeric(r("Sys Qty")) Then
                    obj.SysQty = r("Sys Qty")
                End If
                If IsNumeric(r("Act Qty")) Then
                    obj.ActQty = r("Act Qty")
                End If
                If Not IsDBNull(r("Note")) Then
                    obj.Note = r("Note")
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

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If IsDBNull(GridView1.GetFocusedRowCellValue("YYMM")) Then
                    If IsDBNull(GridView1.GetFocusedRowCellValue("ProductCode")) Or
                        IsDBNull(GridView1.GetFocusedRowCellValue("RevisionCode")) Or
                        IsDBNull(GridView1.GetFocusedRowCellValue("ComponentCode")) Or
                        IsDBNull(GridView1.GetFocusedRowCellValue("ProcessNumber")) Or
                        IsDBNull(GridView1.GetFocusedRowCellValue("LotNumber")) Then
                        Exit Sub
                    Else
                        Dim obj As New CIS_WIP_Inventory
                        obj.YYMM_K = dteMonth.DateTime.ToString("yyyyMM")
                        obj.ProductCode_K = GridView1.GetFocusedRowCellValue("ProductCode")
                        obj.RevisionCode_K = GridView1.GetFocusedRowCellValue("RevisionCode")
                        obj.ComponentCode_K = GridView1.GetFocusedRowCellValue("ComponentCode")
                        obj.ProcessNumber_K = GridView1.GetFocusedRowCellValue("ProcessNumber")
                        obj.LotNumber_K = GridView1.GetFocusedRowCellValue("LotNumber")
                        'obj.ProcessCode = r("Process Code")
                        'obj.GroupCode = r("Group Code")
                        'obj.SysQty = r("Sys Qty")
                        'obj.ActQty = r("Act Qty")
                        'obj.Note = r("Note")
                        obj.CreatedUser = CurrentUser.UserID
                        obj.CreatedDate = Date.Now
                        If Not _db.ExistObject(obj) Then
                            _db.Insert(obj)
                            GridView1.SetFocusedRowCellValue("YYMM", obj.YYMM_K)
                        End If
                    End If
                Else
                    If e.Column.FieldName = "ProductCode" Or e.Column.FieldName = "RevisionCode" Or
                        e.Column.FieldName = "ComponentCode" Or e.Column.FieldName = "ProcessNumber" Or
                        e.Column.FieldName = "LotNumber" Then
                        GoTo SửaKhóa
                    End If
                End If
            End If
            If Not IsDBNull(GridView1.GetFocusedRowCellValue("YYMM")) And (e.Column.FieldName = "ProductCode" Or
                        e.Column.FieldName = "RevisionCode" Or e.Column.FieldName = "ComponentCode" Or
                        e.Column.FieldName = "ProcessNumber" Or e.Column.FieldName = "LotNumber") Then
SửaKhóa:
                If e.Column.FieldName = "ProductCode" Then
                    _db.ExecuteNonQuery(String.Format("UPDATE CIS_WIP_Inventory
                                                        SET ProductCode = '{0}'
                                                        WHERE YYMM = '{1}'
                                                        AND ProductCode = '{2}'
                                                        AND RevisionCode = '{3}'
                                                        AND ComponentCode = '{4}'
                                                        AND ProcessNumber = '{5}'
                                                        AND LotNumber = '{6}'",
                                                        GridView1.GetFocusedRowCellValue("ProductCode"),
                                                        GridView1.GetFocusedRowCellValue("YYMM"),
                                                        GridView1.ActiveEditor.OldEditValue,
                                                        GridView1.GetFocusedRowCellValue("RevisionCode"),
                                                        GridView1.GetFocusedRowCellValue("ComponentCode"),
                                                        GridView1.GetFocusedRowCellValue("ProcessNumber"),
                                                        GridView1.GetFocusedRowCellValue("LotNumber")))
                ElseIf e.Column.FieldName = "RevisionCode" Then
                    _db.ExecuteNonQuery(String.Format("UPDATE CIS_WIP_Inventory
                                                        SET RevisionCode = '{0}'
                                                        WHERE YYMM = '{1}'
                                                        AND ProductCode = '{2}'
                                                        AND RevisionCode = '{3}'
                                                        AND ComponentCode = '{4}'
                                                        AND ProcessNumber = '{5}'
                                                        AND LotNumber = '{6}'",
                                                        GridView1.GetFocusedRowCellValue("RevisionCode"),
                                                        GridView1.GetFocusedRowCellValue("YYMM"),
                                                        GridView1.GetFocusedRowCellValue("ProductCode"),
                                                        GridView1.ActiveEditor.OldEditValue,
                                                        GridView1.GetFocusedRowCellValue("ComponentCode"),
                                                        GridView1.GetFocusedRowCellValue("ProcessNumber"),
                                                        GridView1.GetFocusedRowCellValue("LotNumber")))
                ElseIf e.Column.FieldName = "ComponentCode" Then
                    _db.ExecuteNonQuery(String.Format("UPDATE CIS_WIP_Inventory
                                                        SET ComponentCode = '{0}'
                                                        WHERE YYMM = '{1}'
                                                        AND ProductCode = '{2}'
                                                        AND RevisionCode = '{3}'
                                                        AND ComponentCode = '{4}'
                                                        AND ProcessNumber = '{5}'
                                                        AND LotNumber = '{6}'",
                                                        GridView1.GetFocusedRowCellValue("ComponentCode"),
                                                        GridView1.GetFocusedRowCellValue("YYMM"),
                                                        GridView1.GetFocusedRowCellValue("ProductCode"),
                                                        GridView1.GetFocusedRowCellValue("RevisionCode"),
                                                        GridView1.ActiveEditor.OldEditValue,
                                                        GridView1.GetFocusedRowCellValue("ProcessNumber"),
                                                        GridView1.GetFocusedRowCellValue("LotNumber")))
                ElseIf e.Column.FieldName = "ProcessNumber" Then
                    _db.ExecuteNonQuery(String.Format("UPDATE CIS_WIP_Inventory
                                                        SET ProcessNumber = '{0}'
                                                        WHERE YYMM = '{1}'
                                                        AND ProductCode = '{2}'
                                                        AND RevisionCode = '{3}'
                                                        AND ComponentCode = '{4}'
                                                        AND ProcessNumber = '{5}'
                                                        AND LotNumber = '{6}'",
                                                        GridView1.GetFocusedRowCellValue("ProcessNumber"),
                                                        GridView1.GetFocusedRowCellValue("YYMM"),
                                                        GridView1.GetFocusedRowCellValue("ProductCode"),
                                                        GridView1.GetFocusedRowCellValue("RevisionCode"),
                                                        GridView1.GetFocusedRowCellValue("ComponentCode"),
                                                        GridView1.ActiveEditor.OldEditValue,
                                                        GridView1.GetFocusedRowCellValue("LotNumber")))
                ElseIf e.Column.FieldName = "LotNumber" Then
                    _db.ExecuteNonQuery(String.Format("UPDATE CIS_WIP_Inventory
                                                        SET LotNumber = '{0}'
                                                        WHERE YYMM = '{1}'
                                                        AND ProductCode = '{2}'
                                                        AND RevisionCode = '{3}'
                                                        AND ComponentCode = '{4}'
                                                        AND ProcessNumber = '{5}'
                                                        AND LotNumber = '{6}'",
                                                        GridView1.GetFocusedRowCellValue("LotNumber"),
                                                        GridView1.GetFocusedRowCellValue("YYMM"),
                                                        GridView1.GetFocusedRowCellValue("ProductCode"),
                                                        GridView1.GetFocusedRowCellValue("RevisionCode"),
                                                        GridView1.GetFocusedRowCellValue("ComponentCode"),
                                                        GridView1.GetFocusedRowCellValue("ProcessNumber"),
                                                        GridView1.ActiveEditor.OldEditValue))
                End If
                Exit Sub
            End If
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("Then@Value", e.Value)
            _db.ExecuteNonQuery(String.Format("UPDATE CIS_WIP_Inventory
                                                SET {0} = @Value
                                                WHERE YYMM = '{1}'
                                                And ProductCode = '{2}'
                                                And RevisionCode = '{3}'
                                                And ComponentCode = '{4}'
                                                And ProcessNumber = '{5}'
                                                And LotNumber = '{6}'",
                                                e.Column.FieldName,
                                                GridView1.GetFocusedRowCellValue("YYMM"),
                                                GridView1.GetFocusedRowCellValue("ProductCode"),
                                                GridView1.GetFocusedRowCellValue("RevisionCode"),
                                                GridView1.GetFocusedRowCellValue("ComponentCode"),
                                                GridView1.GetFocusedRowCellValue("ProcessNumber"),
                                                GridView1.GetFocusedRowCellValue("LotNumber")),
                                                para)
            If e.Column.FieldName = "SysQty" Or e.Column.FieldName = "ActQty" Then
                Dim ActQty = IIf(IsNumeric(GridView1.GetFocusedRowCellValue("ActQty")),
                                    GridView1.GetFocusedRowCellValue("ActQty"), 0)
                Dim SysQty = IIf(IsNumeric(GridView1.GetFocusedRowCellValue("SysQty")),
                                    GridView1.GetFocusedRowCellValue("SysQty"), 0)
                GridView1.SetFocusedRowCellValue("Diff", ActQty - SysQty)
            End If
        End If
    End Sub
End Class