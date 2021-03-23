Imports CommonDB
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports PublicUtility
Public Class FrmOutDirectMaterial_2
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim orderDate As String = ""
    Dim isEdit As Boolean = True
    Dim _subPrcName As String = ""

    Private Sub FrmOutDirectMaterial_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New Main_UserRight
        obj.FormID_K = Tag
        obj.UserID_K = CurrentUser.UserID
        _db.GetObject(obj)
        If Not obj.IsEdit Then
            ViewAccess()
            isEdit = False
        End If
        dteOrderDate.EditValue = DateTime.Now
        orderDate = dteOrderDate.DateTime.ToString("yyyyMMdd")
    End Sub
    Sub ViewAccess()
        btnLock.Enabled = False
    End Sub
    Private Sub dteOrderDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteOrderDate.EditValueChanged
        orderDate = dteOrderDate.DateTime.ToString("yyyyMMdd")
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(0) As SqlClient.SqlParameter
        If isEdit Then
            para(0) = New SqlClient.SqlParameter("@ECode", DBNull.Value)
        Else
            para(0) = New SqlClient.SqlParameter("@ECode", CurrentUser.UserID)
        End If
        Dim sql As String = String.Format(" SELECT OutYMD, ECode, DeptName, SubPrcName, PrcName,
                                            JCode, JEName, JVName, Unit, MinQty, IssuingQty,
                                            UsePurpose, Remarks
                                            FROM PCM_OutDirect 
                                            WHERE OutYMD = '{0}'
                                            AND (@ECode IS NULL OR ECode = @ECode)",
                                            dteOrderDate.DateTime.ToString("yyyyMMdd"))
        GridControl1.DataSource = _db.FillDataTable(sql, para)
        GridControlSetFormat(GridView1, 3)
        GridView1.Columns("JCode").Width = 100
        GridView1.Columns("SubPrcName").Width = 150
        GridView1.Columns("JEName").Width = 200

        Dim objlock As New PCM_LockDay
        objlock.YMD_K = dteOrderDate.DateTime.ToString("yyyyMMdd")
        If _db.ExistObject(objlock) Then
            _db.GetObject(objlock)
        Else
            objlock.YMD_K = dteOrderDate.DateTime.ToString("yyyyMMdd")
            objlock.JCodeLocked1 = True
            objlock.JCodeLocked2 = True
            objlock.JCodeLocked3 = True
            objlock.TrayLocked1 = True
            objlock.TrayLocked2 = True
            objlock.DirectLocked = True
            objlock.OutWSLocked = True
            _db.Insert(objlock)
        End If
        chbLocked.Checked = objlock.DirectLocked

        Dim dtECode = _db.FillDataTable("SELECT ECode, DeptName, SubPrcName, PrcName
                                        FROM PCM_Dept
                                        WHERE (@ECode IS NULL OR ECode = @ECode)
                                        ORDER BY ECode, SubPrcName", para)
        slueECode.DataSource = dtECode
        slueECode.DisplayMember = "ECode"
        slueECode.ValueMember = "ECode"
        slueECode.NullText = Nothing
        slueECode.PopulateViewColumns()
        GridECode.Columns("ECode").Width = 55
        GridECode.Columns("DeptName").Width = 55
        GridECode.Columns("SubPrcName").Width = 150
        GridECode.Columns("PrcName").Width = 55
        GridView1.Columns("ECode").ColumnEdit = slueECode
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        If GridControl1.DataSource Is Nothing Then
            btnShow.PerformClick()
        End If
        If isEdit Or Not chbLocked.Checked Then
            GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            GridControlReadOnly(GridView1, True)
            GridView1.Columns("ECode").OptionsColumn.ReadOnly = False
            GridView1.Columns("JCode").OptionsColumn.ReadOnly = False
            GridView1.Columns("IssuingQty").OptionsColumn.ReadOnly = False
            GridView1.Columns("UsePurpose").OptionsColumn.ReadOnly = False
            GridView1.Columns("Remarks").OptionsColumn.ReadOnly = False
            GridControlSetColorEdit(GridView1)
        Else
            ShowWarning("Locked !")
        End If
    End Sub
    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        If isEdit Or Not chbLocked.Checked Then
            GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            GridControlSetColorReadonly(GridView1)
            GridControlReadOnly(GridView1, True)
            GridView1.Columns("IssuingQty").OptionsColumn.ReadOnly = False
            GridView1.Columns("UsePurpose").OptionsColumn.ReadOnly = False
            GridView1.Columns("Remarks").OptionsColumn.ReadOnly = False
            GridControlSetColorEdit(GridView1)
        Else
            ShowWarning("Locked !")
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        If GridView1.RowCount > 0 Then
            GridControlExportExcel(GridView1)
        End If
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If isEdit Or Not chbLocked.Checked Then
            If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
                For Each r As Integer In GridView1.GetSelectedRows
                    Dim obj As New PCM_OutDirect
                    obj.OutYMD_K = GridView1.GetRowCellValue(r, "OutYMD")
                    obj.ECode_K = GridView1.GetRowCellValue(r, "ECode")
                    obj.JCode_K = GridView1.GetRowCellValue(r, "JCode")
                    obj.SubPrcName_K = GridView1.GetRowCellValue(r, "SubPrcName")
                    _db.Delete(obj)
                Next
                GridView1.DeleteSelectedRows()
            End If
        Else
            ShowWarning("Locked !")
        End If
    End Sub

    Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
        If isEdit Or Not chbLocked.Checked Then
            Dim dt As DataTable = ImportEXCEL("OutDirect")
            If dt.Rows.Count > 0 Then
                Try
                    _db.BeginTransaction()
                    Dim count = 0
                    Dim succ = 0
                    For Each r As DataRow In dt.Rows
                        count += 1
                        If IsDBNull(r("ECode")) Or IsDBNull(r("ItemCodeTemp")) Then
                            Continue For
                        End If

                        Dim obj As New PCM_OutDirect
                        obj.OutYMD_K = dteOrderDate.DateTime.ToString("yyyyMMdd")

                        Dim dtSubPrcName = _db.FillDataTable(String.Format("SELECT TOP 1 SubPrcName, PrcName 
                                                                             FROM PCM_Dept 
                                                                             WHERE ECode = '{0}' 
                                                                             AND DeptName = '{1}'",
                                                                             r("ECode"),
                                                                             r("Dept")))
                        If dtSubPrcName.Rows.Count > 0 Then
                            obj.SubPrcName_K = dtSubPrcName.Rows(0)("SubPrcName")
                            obj.PrcName = dtSubPrcName.Rows(0)("PrcName")
                        Else
                            dtSubPrcName = _db.FillDataTable(String.Format("SELECT TOP 1 SubPrcName, PrcName 
                                                                             FROM PCM_Dept 
                                                                             WHERE ECode = '{0}'",
                                                                             r("ECode")))
                            If dtSubPrcName.Rows.Count > 0 Then
                                obj.SubPrcName_K = dtSubPrcName.Rows(0)("SubPrcName")
                                obj.PrcName = dtSubPrcName.Rows(0)("PrcName")
                            Else
                                _db.RollBack()
                                ShowWarning("Row " + count + " - " + r("ECode") + ": ECode doesn't exist !")
                                Return
                            End If
                        End If

                        obj.ECode_K = r("ECode")
                        obj.JCode_K = r("ItemCodeTemp")
                        obj.JEName = r("ItemName")
                        obj.Unit = r("Unit")
                        obj.MinQty = IIf(IsDBNull(r("MinQty")), 0, r("MinQty"))
                        obj.IssuingQty = IIf(IsDBNull(r("Qty")), 0, r("Qty"))
                        obj.DeptName = r("Dept")

                        Dim valueUpdate = obj.IssuingQty
                        If _db.ExistObject(obj) Then
                            _db.GetObject(obj)
                            obj.IssuingQty = obj.IssuingQty + valueUpdate
                            obj.UpdateUser = CurrentUser.UserID
                            obj.UpdateDate = DateTime.Now
                            _db.Update(obj)
                        Else
                            obj.CreateUser = CurrentUser.UserID
                            obj.CreateDate = DateTime.Now
                            _db.Insert(obj)
                            succ += 1
                        End If
                    Next
                    _db.Commit()
                    Dim str = String.Format("Import thành công {0} dữ liệu.", succ)
                    ShowSuccess(str)
                    btnShow.PerformClick()
                Catch ex As Exception
                    _db.RollBack()
                    ShowWarning(ex.Message)
                End Try
            Else
                ShowWarning("Không có dữ liệu !")
            End If
        Else
            ShowWarning("Locked !")
        End If
    End Sub
    Private Sub btnLock_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnLock.ItemClick
        Dim obj As New PCM_LockDay
        obj.YMD_K = dteOrderDate.DateTime.ToString("yyyyMMdd")
        If _db.ExistObject(obj) Then
            _db.GetObject(obj)
            obj.DirectLocked = Not obj.DirectLocked
            _db.Update(obj)
        Else
            obj.YMD_K = dteOrderDate.DateTime.ToString("yyyyMMdd")
            obj.JCodeLocked1 = True
            obj.JCodeLocked2 = True
            obj.JCodeLocked3 = True
            obj.TrayLocked1 = True
            obj.TrayLocked2 = True
            obj.DirectLocked = True
            obj.OutWSLocked = True
            _db.Insert(obj)
        End If
        chbLocked.Checked = obj.DirectLocked
        If obj.DirectLocked Then
            GridControlReadOnly(GridView1, True)
            GridControlSetColorReadonly(GridView1)
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And Not e.Column.ReadOnly Then
            If e.RowHandle < 0 Then
                If IsDBNull(GridView1.GetFocusedRowCellValue("ECode")) Then
                    ShowWarning("Bạn phải nhập ECode và JCode trước !")
                    Return
                ElseIf e.Column.FieldName = "JCode" And IsDBNull(GridView1.GetFocusedRowCellValue("OutYMD")) Then
                    'Tạo mới
                    Dim obj As New PCM_OutDirect
                    obj.OutYMD_K = orderDate
                    obj.ECode_K = GridView1.GetFocusedRowCellValue("ECode")
                    obj.SubPrcName_K = GridView1.GetFocusedRowCellValue("SubPrcName")
                    obj.DeptName = GridView1.GetFocusedRowCellValue("DeptName")
                    obj.PrcName = GridView1.GetFocusedRowCellValue("PrcName")
                    obj.JCode_K = GridView1.GetFocusedRowCellValue("JCode")
                    obj.JEName = GridView1.GetFocusedRowCellValue("JEName")
                    obj.JVName = GridView1.GetFocusedRowCellValue("JVName")
                    obj.Unit = GridView1.GetFocusedRowCellValue("Unit")
                    obj.MinQty = GridView1.GetFocusedRowCellValue("MinQty")
                    obj.CreateUser = CurrentUser.UserID
                    obj.CreateDate = DateTime.Now
                    If Not _db.ExistObject(obj) Then
                        _db.Insert(obj)
                        GridView1.SetFocusedRowCellValue("OutYMD", obj.OutYMD_K)
                    End If
                    Return
                End If
            End If

            If e.Column.FieldName = "IssuingQty" Then
                If e.Value < GridView1.GetFocusedRowCellValue("MinQty") Then
                    ShowWarning("< Min Qty !")
                    Return
                End If
            End If

            Dim para(1) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            para(1) = New SqlClient.SqlParameter("@DateUpdate", DateTime.Now)
            _db.ExecuteNonQuery(String.Format("UPDATE PCM_OutDirect
                                                SET {0} = @Value,
                                                UpdateUser = '{1}',
                                                UpdateDate = @DateUpdate
                                                WHERE OutYMD = '{2}'
                                                AND ECode = '{3}'
                                                AND JCode = '{4}'
                                                AND SubPrcName = N'{5}'",
                                                e.Column.FieldName,
                                                CurrentUser.UserID,
                                                GridView1.GetFocusedRowCellValue("OutYMD"),
                                                GridView1.GetFocusedRowCellValue("ECode"),
                                                GridView1.GetFocusedRowCellValue("JCode"),
                                                GridView1.GetFocusedRowCellValue("SubPrcName")), para)
        End If
    End Sub
    Sub BindingDataToSlueJCode(valECode As String, valSubPrcName As String)
        Dim sql = String.Format("SELECT JCode, JEName, JVName, Unit, MinQty INTO #Temp
                                FROM PCM_MterNotJCode
                                WHERE ECode = '{0}' AND SubPrcName = N'{1}'
                                UNION
                                SELECT JCode, JEName, JVName, Unit, MinQty
                                FROM PCM_MterTrayU00
                                WHERE ECode = '{0}' AND SubPrcName = N'{1}'
                                UNION
                                SELECT ItemCode COLLATE DATABASE_DEFAULT AS JCode, ItemNumberName COLLATE DATABASE_DEFAULT AS JEName, 
                                 StandardName COLLATE DATABASE_DEFAULT AS JVName, UnitCode COLLATE DATABASE_DEFAULT AS Unit, 
                                    BuyingMinimumQuantity AS MinQty
                                FROM [10.153.1.30].[FPiCS-B03].[dbo].t_ASMaterialItem
                                
                                SELECT *
                                FROM #Temp
                                UNION
                                SELECT JCode, NULL, NULL, NULL, NULL
                                FROM PCM_OutDirect
                                WHERE OutYMD = '{2}'
                                AND JCode NOT IN (
	                                SELECT JCode
                                    FROM #Temp
                                )",
                                valECode,
                                valSubPrcName,
                                orderDate)
        slueJCode.DataSource = _db.FillDataTable(sql)
        slueJCode.DisplayMember = "JCode"
        slueJCode.ValueMember = "JCode"
        slueJCode.NullText = Nothing
        slueJCode.PopulateViewColumns()
        GridJCode.Columns("JCode").Width = 80
        GridJCode.Columns("JEName").Width = 200
        GridJCode.Columns("JVName").Width = 200
        GridJCode.Columns("Unit").Width = 60
        GridJCode.Columns("MinQty").Width = 60
        GridView1.Columns("JCode").ColumnEdit = slueJCode
    End Sub

    Private Sub slueECode_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles slueECode.Closed
        Dim lc As SearchLookUpEdit = CType(sender, SearchLookUpEdit)
        GridView1.SetFocusedRowCellValue("DeptName", lc.Properties.View.GetFocusedRowCellValue("DeptName"))
        GridView1.SetFocusedRowCellValue("SubPrcName", lc.Properties.View.GetFocusedRowCellValue("SubPrcName"))
        GridView1.SetFocusedRowCellValue("PrcName", lc.Properties.View.GetFocusedRowCellValue("PrcName"))
        Dim valECode As String = lc.Properties.View.GetFocusedRowCellValue("ECode")
        Dim valSubPrcName As String = lc.Properties.View.GetFocusedRowCellValue("SubPrcName")
        Dim oldVal As Object = GridView1.ActiveEditor.OldEditValue
        GridView1.Columns("ECode").OptionsColumn.ReadOnly = True
        GridView1.SetFocusedRowCellValue("ECode", valECode)
        GridView1.Columns("ECode").OptionsColumn.ReadOnly = False
        BindingDataToSlueJCode(valECode, valSubPrcName)

        If Not IsDBNull(GridView1.GetFocusedRowCellValue("OutYMD")) Then
            _db.ExecuteNonQuery(String.Format(" UPDATE PCM_OutDirect
                                                SET ECode = '{0}',
                                                DeptName = N'{1}',
                                                SubPrcName = N'{2}',
                                                PrcName = N'{3}'
                                                WHERE OutYMD = '{4}'
                                                AND ECode = '{5}'
                                                AND SubPrcName = '{6}'
                                                AND JCode = '{7}'",
                                                valECode,
                                                lc.Properties.View.GetFocusedRowCellValue("DeptName"),
                                                lc.Properties.View.GetFocusedRowCellValue("SubPrcName"),
                                                lc.Properties.View.GetFocusedRowCellValue("PrcName"),
                                                GridView1.GetFocusedRowCellValue("OutYMD"),
                                                oldVal,
                                                _subPrcName,
                                                GridView1.GetFocusedRowCellValue("JCode")))
        End If
    End Sub

    Private Sub slueJCode_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles slueJCode.Closed
        Dim lc As SearchLookUpEdit = CType(sender, SearchLookUpEdit)
        Dim obj As New PCM_OutDirect
        obj.OutYMD_K = orderDate
        obj.ECode_K = GridView1.GetFocusedRowCellValue("ECode")
        obj.SubPrcName_K = GridView1.GetFocusedRowCellValue("SubPrcName")
        obj.JCode_K = lc.Properties.View.GetFocusedRowCellValue("JCode")
        If _db.ExistObject(obj) Then
            Dim oldVal = GridView1.ActiveEditor.OldEditValue
            GridView1.Columns("JCode").OptionsColumn.ReadOnly = True
            GridView1.SetFocusedRowCellValue("JCode", oldVal)
            GridView1.Columns("JCode").OptionsColumn.ReadOnly = False
            ShowWarning("JCode đã được tạo trong hôm nay, bạn không thể tạo lần 2 !")
            Return
        End If
        GridView1.SetFocusedRowCellValue("JEName", lc.Properties.View.GetFocusedRowCellValue("JEName"))
        GridView1.SetFocusedRowCellValue("JVName", lc.Properties.View.GetFocusedRowCellValue("JVName"))
        GridView1.SetFocusedRowCellValue("Unit", lc.Properties.View.GetFocusedRowCellValue("Unit"))
        GridView1.SetFocusedRowCellValue("MinQty", lc.Properties.View.GetFocusedRowCellValue("MinQty"))

        If Not IsDBNull(GridView1.GetFocusedRowCellValue("OutYMD")) Then
            _db.ExecuteNonQuery(String.Format(" UPDATE PCM_OutDirect
                                                SET JCode = '{0}',
                                                JEName = N'{1}',
                                                JVName = N'{2}',
                                                Unit = N'{3}',
                                                MinQty = {4}
                                                WHERE OutYMD = '{5}'
                                                AND ECode = '{6}'
                                                AND SubPrcName = '{7}'
                                                AND JCode = '{8}'",
                                                lc.Properties.View.GetFocusedRowCellValue("JCode"),
                                                lc.Properties.View.GetFocusedRowCellValue("JEName"),
                                                lc.Properties.View.GetFocusedRowCellValue("JVName"),
                                                lc.Properties.View.GetFocusedRowCellValue("Unit"),
                                                lc.Properties.View.GetFocusedRowCellValue("MinQty"),
                                                GridView1.GetFocusedRowCellValue("OutYMD"),
                                                GridView1.GetFocusedRowCellValue("ECode"),
                                                GridView1.GetFocusedRowCellValue("SubPrcName"),
                                                GridView1.ActiveEditor.OldEditValue))
        End If
    End Sub

    Private Sub slueECode_BeforePopup(sender As Object, e As EventArgs) Handles slueECode.BeforePopup
        If Not IsDBNull(GridView1.GetFocusedRowCellValue("SubPrcName")) Then
            _subPrcName = GridView1.GetFocusedRowCellValue("SubPrcName")
        End If
    End Sub
End Class