Imports CommonDB
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports PublicUtility
Public Class FrmNhapWorkingHour
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmWorkingHour_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grcProgressBar.Visible = False
        dteNgay.EditValue = Date.Now.Date
        btnNew.PerformClick()
        'Dim obj As New Main_UserRight
        'obj.UserID_K = CurrentUser.UserID
        'obj.FormID_K = Tag
        '_db.GetObject(obj)
        'If obj.IsEdit = False And obj.IsAdmin = False Then
        '    ViewAccess()
        'End If
    End Sub
    Sub ViewAccess()

    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Date", dteNgay.DateTime)
        GridControl1.DataSource = _db.FillDataTable("
            SELECT h.WorkDate, h.ProductCode, h.RevisionCode, h.ComponentCode, h.ProcessNumber, h.ProcessCode,
                d.ProcessNameE, h.LotNumber, h.Qty, h.TotalMinute, h.Note, h.CreatedUser, h.CreatedDate
            FROM CIS_Work_WorkingHour AS h
            LEFT JOIN CIS_BOM_MsProcess AS d
            ON h.ProcessCode = d.ProcessCode
            WHERE WorkDate = @Date", para)
        GridControlSetFormat(GridView1, 4)

        GridControlReadOnly(GridView1, True)
        GridView1.Columns("ProcessNumber").OptionsColumn.ReadOnly = False
        GridView1.Columns("LotNumber").OptionsColumn.ReadOnly = False
        GridView1.Columns("Qty").OptionsColumn.ReadOnly = False
        GridView1.Columns("TotalMinute").OptionsColumn.ReadOnly = False
        GridView1.Columns("Note").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

        slueMaster.DataSource = _db.FillDataTable("
            SELECT h.ProductCode, h.RevisionCode, h.ComponentCode, h.ProcessNumber, h.ProcessCode, d.ProcessNameE
            FROM CIS_BOM_ComponentProcess AS h
            LEFT JOIN CIS_BOM_MsProcess AS d
            ON h.ProcessCode = d.ProcessCode")
        slueMaster.DisplayMember = "ProcessNumber"
        slueMaster.ValueMember = "ProcessNumber"
        GridView1.Columns("ProcessNumber").ColumnEdit = slueMaster
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            For Each r As Integer In GridView1.GetSelectedRows
                Dim obj As New CIS_Work_WorkingHour
                obj.WorkDate_K = GridView1.GetRowCellValue(r, "WorkDate")
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
                If IsDBNull(r("Work Date")) Or IsDBNull(r("Product Code")) Then Continue For
                Dim obj As New CIS_Work_WorkingHour
                obj.WorkDate_K = r("Work Date")
                obj.ProductCode_K = r("Product Code")
                obj.RevisionCode_K = r("Revision Code")
                obj.ComponentCode_K = r("Component Code")
                obj.ProcessNumber_K = r("Process Number")
                obj.LotNumber_K = r("Lot Number").ToString.PadLeft(5, "0")
                obj.ProcessCode = r("Process Code")
                If IsNumeric(r("Qty")) Then
                    obj.Qty = r("Qty")
                End If
                If IsNumeric(r("Total Minute")) Then
                    obj.TotalMinute = r("Total Minute")
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

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable = True And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If IsDBNull(GridView1.GetFocusedRowCellValue("WorkDate")) Then
                    If IsDBNull(GridView1.GetFocusedRowCellValue("ProductCode")) Or
                    IsDBNull(GridView1.GetFocusedRowCellValue("RevisionCode")) Or
                    IsDBNull(GridView1.GetFocusedRowCellValue("ComponentCode")) Or
                    IsDBNull(GridView1.GetFocusedRowCellValue("ProcessNumber")) Or
                    IsDBNull(GridView1.GetFocusedRowCellValue("LotNumber")) Or
                    IsDBNull(GridView1.GetFocusedRowCellValue("ProcessCode")) Then
                        Exit Sub
                    Else
                        Dim obj As New CIS_Work_WorkingHour
                        obj.WorkDate_K = dteNgay.DateTime
                        obj.ProductCode_K = GridView1.GetFocusedRowCellValue("ProductCode")
                        obj.RevisionCode_K = GridView1.GetFocusedRowCellValue("RevisionCode")
                        obj.ComponentCode_K = GridView1.GetFocusedRowCellValue("ComponentCode")
                        obj.ProcessNumber_K = GridView1.GetFocusedRowCellValue("ProcessNumber")
                        obj.LotNumber_K = GridView1.GetFocusedRowCellValue("LotNumber").ToString.PadLeft(5, "0")
                        obj.ProcessCode = GridView1.GetFocusedRowCellValue("ProcessCode")
                        obj.CreatedUser = CurrentUser.UserID
                        obj.CreatedDate = Date.Now
                        If Not _db.ExistObject(obj) Then
                            _db.Insert(obj)
                            GridView1.SetFocusedRowCellValue("WorkDate", obj.WorkDate_K)
                        Else
                            ShowWarning("Bộ dữ liệu đã được tạo hôm nay, không thể tạo lần 2!")
                            ReturnOldValue(GridView1)
                        End If
                    End If
                Else
                    If e.Column.FieldName = "ProcessNumber" Or e.Column.FieldName = "LotNumber" Then
                        GoTo SửaKhóa
                    End If
                End If
            End If
            If Not IsDBNull(GridView1.GetFocusedRowCellValue("WorkDate")) And
            (e.Column.FieldName = "ProcessNumber" Or e.Column.FieldName = "LotNumber") Then
SửaKhóa:
                Dim paraD(0) As SqlClient.SqlParameter
                paraD(0) = New SqlClient.SqlParameter("@Date", GridView1.GetFocusedRowCellValue("WorkDate"))
                If e.Column.FieldName = "ProcessNumber" Then
                    _db.ExecuteNonQuery(String.Format("UPDATE CIS_Work_WorkingHour
                                                    SET ProductCode = '{0}',
                                                    RevisionCode = '{1}',
                                                    ComponentCode = '{2}',
                                                    ProcessNumber = '{3}',
                                                    ProcessCode = '{4}'
                                                    WHERE WorkDate = @Date
                                                    AND ProductCode = '{5}'
                                                    AND RevisionCode = '{6}'
                                                    AND ComponentCode = '{7}'
                                                    AND ProcessNumber = '{8}'
                                                    AND LotNumber = '{9}'",
                                                    GridView1.GetFocusedRowCellValue("ProductCode"),
                                                    GridView1.GetFocusedRowCellValue("RevisionCode"),
                                                    GridView1.GetFocusedRowCellValue("ComponentCode"),
                                                    GridView1.GetFocusedRowCellValue("ProcessNumber"),
                                                    GridView1.GetFocusedRowCellValue("ProcessCode"),
                                                    _OldPdCode, _OldRevisionCode, _OldComponentCode, _OldProcessNumber,
                                                    GridView1.GetFocusedRowCellValue("LotNumber")), paraD)
                ElseIf e.Column.FieldName = "LotNumber" Then
                    _db.ExecuteNonQuery(String.Format("UPDATE CIS_Work_WorkingHour
                                                    SET LotNumber = '{0}'
                                                    WHERE WorkDate = @Date
                                                    AND ProductCode = '{1}'
                                                    AND RevisionCode = '{2}'
                                                    AND ComponentCode = '{3}'
                                                    AND ProcessNumber = '{4}'
                                                    AND LotNumber = '{5}'",
                                                    GridView1.GetFocusedRowCellValue("LotNumber").ToString.PadLeft(5, "0"),
                                                    GridView1.GetFocusedRowCellValue("ProductCode"),
                                                    GridView1.GetFocusedRowCellValue("RevisionCode"),
                                                    GridView1.GetFocusedRowCellValue("ComponentCode"),
                                                    GridView1.GetFocusedRowCellValue("ProcessNumber"),
                                                    GridView1.ActiveEditor.OldEditValue), paraD)
                End If
                Exit Sub
            End If
            Dim paraH(1) As SqlClient.SqlParameter
            paraH(0) = New SqlClient.SqlParameter("@Value", e.Value)
            paraH(1) = New SqlClient.SqlParameter("@Date", GridView1.GetFocusedRowCellValue("WorkDate"))
            _db.ExecuteNonQuery(String.Format("UPDATE CIS_Work_WorkingHour
                                            SET {0} = @Value
                                            WHERE WorkDate = @Date
                                            AND ProductCode = '{1}'
                                            AND RevisionCode = '{2}'
                                            AND ComponentCode = '{3}'
                                            AND ProcessNumber = '{4}'
                                            AND LotNumber = '{5}'",
                                            e.Column.FieldName,
                                            GridView1.GetFocusedRowCellValue("ProductCode"),
                                            GridView1.GetFocusedRowCellValue("RevisionCode"),
                                            GridView1.GetFocusedRowCellValue("ComponentCode"),
                                            GridView1.GetFocusedRowCellValue("ProcessNumber"),
                                            GridView1.GetFocusedRowCellValue("LotNumber")), paraH)

        End If
    End Sub

    Dim _OldPdCode As Object
    Dim _OldRevisionCode As Object
    Dim _OldComponentCode As Object
    Dim _OldProcessNumber As Object
    'Dim _OldProcessCode As String = ""
    Private Sub slueMaster_EditValueChanged(sender As Object, e As EventArgs) Handles slueMaster.EditValueChanged
        Dim lc As SearchLookUpEdit = CType(sender, SearchLookUpEdit)
        GridView1.SetFocusedRowCellValue("ProductCode", lc.Properties.View.GetFocusedRowCellValue("ProductCode"))
        GridView1.SetFocusedRowCellValue("RevisionCode", lc.Properties.View.GetFocusedRowCellValue("RevisionCode"))
        GridView1.SetFocusedRowCellValue("ComponentCode", lc.Properties.View.GetFocusedRowCellValue("ComponentCode"))
        GridView1.SetFocusedRowCellValue("ProcessCode", lc.Properties.View.GetFocusedRowCellValue("ProcessCode"))
        GridView1.SetFocusedRowCellValue("ProcessNameE", lc.Properties.View.GetFocusedRowCellValue("ProcessNameE"))
    End Sub

    Private Sub slueMaster_BeforePopup(sender As Object, e As EventArgs) Handles slueMaster.BeforePopup
        _OldPdCode = GridView1.GetFocusedRowCellValue("ProductCode")
        _OldRevisionCode = GridView1.GetFocusedRowCellValue("RevisionCode")
        _OldComponentCode = GridView1.GetFocusedRowCellValue("ComponentCode")
        _OldProcessNumber = GridView1.GetFocusedRowCellValue("ProcessNumber")
    End Sub
    Sub ReturnOldValue(gridV As GridView)
        Dim oldVal As Object = gridV.ActiveEditor.OldEditValue
        gridV.Columns(gridV.FocusedColumn.FieldName).OptionsColumn.ReadOnly = True
        gridV.SetFocusedRowCellValue(gridV.FocusedColumn.FieldName, oldVal)
        gridV.Columns(gridV.FocusedColumn.FieldName).OptionsColumn.ReadOnly = False
    End Sub
End Class