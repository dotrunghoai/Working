Imports CommonDB
Imports PublicUtility
Public Class FrmMasterDongHang
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub btnShowDongHang_Click(sender As Object, e As EventArgs) Handles btnShowDongHang.Click
        GridControl1.DataSource = _db.FillDataTable("select * from RI_MasterDongHang")
        GridControlSetFormat(GridView1)
    End Sub

    Private Sub btnShowTargetDH_Click(sender As Object, e As EventArgs) Handles btnShowTargetDH.Click
        GridControl2.DataSource = _db.FillDataTable("select * from RI_MasterTargetDongHang")
        GridControlSetFormat(GridView2)
        GridView2.OptionsView.ShowFooter = False
    End Sub

    Private Sub FrmMasterDongHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShowDongHang.PerformClick()
        btnShowTargetDH.PerformClick()
    End Sub

    Private Sub btnImportDongHang_Click(sender As Object, e As EventArgs) Handles btnImportDongHang.Click
        Dim dt As DataTable = ImportEXCEL(True)
        Dim soDong As Integer = 0
        For Each r As DataRow In dt.Rows
            Dim obj As New RI_MasterDongHang
            obj.ProductCode_K = r("Product Code")
            obj.DongHang = r("Dòng hàng")
            If _db.ExistObject(obj) Then
                _db.Update(obj)
            Else
                _db.Insert(obj)
                soDong += 1
            End If
        Next
        ShowSuccess("Import thành công " + soDong.ToString + " Product Code")
        btnShowDongHang.PerformClick()
    End Sub

    Private Sub btnExportDongHang_Click(sender As Object, e As EventArgs) Handles btnExportDongHang.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub btnExportTargetDH_Click(sender As Object, e As EventArgs) Handles btnExportTargetDH.Click
        GridControlExportExcel(GridView2)
    End Sub

    Private Sub btnImportTargetDH_Click(sender As Object, e As EventArgs) Handles btnImportTargetDH.Click
        Dim dt As DataTable = ImportEXCEL(True)
        Dim soDong As Integer = 0
        For Each r As DataRow In dt.Rows
            Dim obj As New RI_MasterTargetDongHang
            obj.YYYY_K = r("YYYY")
            obj.DongHang_K = r("Dòng hàng")
            obj.DefectCode_K = r("Defect Code")
            obj.Rate = r("Rate")
            If _db.ExistObject(obj) Then
                _db.Update(obj)
            Else
                _db.Insert(obj)
                soDong += 1
            End If
        Next
        ShowSuccess("Import thành công " + soDong.ToString + " target dòng hàng")
        btnShowTargetDH.PerformClick()
    End Sub

    Private Sub btnNewDongHang_Click(sender As Object, e As EventArgs) Handles btnNewDongHang.Click
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridControlReadOnly(GridView1, False)
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnEditDongHang_Click(sender As Object, e As EventArgs) Handles btnEditDongHang.Click
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("DongHang").OptionsColumn.ReadOnly = False
        GridControlSetColorReadonly(GridView1)
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnDeleteDongHang_Click(sender As Object, e As EventArgs) Handles btnDeleteDongHang.Click
        If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu ?") = Windows.Forms.DialogResult.Yes Then
            _db.ExecuteNonQuery(String.Format("delete RI_MasterDongHang where ProductCode = '{0}'", GridView1.GetFocusedRowCellValue("ProductCode")))
            GridView1.DeleteSelectedRows()
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable = True And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If e.Column.FieldName = "ProductCode" Then
                    Dim obj As New RI_MasterDongHang
                    obj.ProductCode_K = GridView1.GetFocusedRowCellValue("ProductCode")
                    If _db.ExistObject(obj) Then
                        _db.GetObject(obj)
                        _db.Update(obj)
                    Else
                        _db.Insert(obj)
                    End If
                Else
                    If IsDBNull(GridView1.GetFocusedRowCellValue("ProductCode")) Then
                        ShowWarning("Bạn phải nhập Product Code trước !")
                        GridControl1.DataSource = _db.FillDataTable("select * from RI_MasterDongHang")
                        Return
                    Else
                        _db.ExecuteNonQuery(String.Format("update RI_MasterDongHang 
                                                        set DongHang = '{0}'    
                                                        where ProductCode = '{1}'",
                                                        e.Value,
                                                        GridView1.GetFocusedRowCellValue("ProductCode")))
                    End If
                End If
            Else
                If e.Column.FieldName = "DongHang" Then
                    _db.ExecuteNonQuery(String.Format("update RI_MasterDongHang 
                                                        set DongHang = '{0}'    
                                                        where ProductCode = '{1}'",
                                                        e.Value,
                                                        GridView1.GetFocusedRowCellValue("ProductCode")))
                Else
                    _db.ExecuteNonQuery(String.Format("update RI_MasterDongHang
                                                        set ProductCode = '{0}'
                                                        where ProductCode = '{1}'",
                                                        GridView1.GetFocusedRowCellValue("ProductCode"),
                                                        GridView1.ActiveEditor.OldEditValue))
                End If
            End If
        End If
    End Sub

    Private Sub btnNewTargetDH_Click(sender As Object, e As EventArgs) Handles btnNewTargetDH.Click
        GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridControlReadOnly(GridView2, False)
        GridControlSetColorEdit(GridView2)
    End Sub

    Private Sub btnEditTargetDH_Click(sender As Object, e As EventArgs) Handles btnEditTargetDH.Click
        GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        GridControlReadOnly(GridView2, True)
        GridView2.Columns("Rate").OptionsColumn.ReadOnly = False
        GridControlSetColorReadonly(GridView2)
        GridControlSetColorEdit(GridView2)
    End Sub

    Private Sub btnDeleteTargetDH_Click(sender As Object, e As EventArgs) Handles btnDeleteTargetDH.Click
        If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu ?") = Windows.Forms.DialogResult.Yes Then
            _db.ExecuteNonQuery(String.Format("delete RI_MasterTargetDongHang 
                                                where YYYY = '{0}' and DongHang = '{1}' and DefectCode = '{2}'",
                                                GridView2.GetFocusedRowCellValue("YYYY"),
                                                GridView2.GetFocusedRowCellValue("DongHang"),
                                                GridView2.GetFocusedRowCellValue("DefectCode")))
            GridView2.DeleteSelectedRows()
        End If
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        If GridView2.Editable = True And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If e.Column.FieldName = "Rate" Then
                    If IsDBNull(GridView2.GetFocusedRowCellValue("YYYY")) Then
                        ShowWarning("Bạn phải nhập YYYY trước !")
                        GridControl2.DataSource = _db.FillDataTable("select * from RI_MasterTargetDongHang")
                        Return
                    ElseIf IsDBNull(GridView2.GetFocusedRowCellValue("DongHang")) Then
                        ShowWarning("Bạn phải nhập Dòng Hàng trước !")
                        GridControl2.DataSource = _db.FillDataTable("select * from RI_MasterTargetDongHang")
                        Return
                    ElseIf IsDBNull(GridView2.GetFocusedRowCellValue("DefectCode")) Then
                        ShowWarning("Bạn phải nhập Defect Code trước !")
                        GridControl2.DataSource = _db.FillDataTable("select * from RI_MasterTargetDongHang")
                        Return
                    Else
                        _db.ExecuteNonQuery(String.Format("update RI_MasterTargetDongHang 
                                                        set Rate = '{0}'    
                                                        where YYYY = '{1}' and DongHang = '{2}' and DefectCode = '{3}'",
                                                        e.Value,
                                                        GridView2.GetFocusedRowCellValue("YYYY"),
                                                        GridView2.GetFocusedRowCellValue("DongHang"),
                                                        GridView2.GetFocusedRowCellValue("DefectCode")))
                    End If
                Else
                    If Not IsDBNull(GridView2.GetFocusedRowCellValue("YYYY")) And
                        Not IsDBNull(GridView2.GetFocusedRowCellValue("DongHang")) And
                        Not IsDBNull(GridView2.GetFocusedRowCellValue("DefectCode")) Then
                        Dim obj As New RI_MasterTargetDongHang
                        obj.YYYY_K = GridView2.GetFocusedRowCellValue("YYYY")
                        obj.DongHang_K = GridView2.GetFocusedRowCellValue("DongHang")
                        obj.DefectCode_K = GridView2.GetFocusedRowCellValue("DefectCode")
                        If _db.ExistObject(obj) Then
                            _db.GetObject(obj)
                            _db.Update(obj)
                        Else
                            _db.Insert(obj)
                        End If
                    End If
                End If
            Else
                If e.Column.FieldName = "Rate" Then
                    _db.ExecuteNonQuery(String.Format("update RI_MasterTargetDongHang 
                                                        set Rate = '{0}'    
                                                        where YYYY = '{1}' and DongHang = '{2}' and DefectCode = '{3}'",
                                                        e.Value,
                                                        GridView2.GetFocusedRowCellValue("YYYY"),
                                                        GridView2.GetFocusedRowCellValue("DongHang"),
                                                        GridView2.GetFocusedRowCellValue("DefectCode")))
                ElseIf e.Column.FieldName = "YYYY" Then
                    _db.ExecuteNonQuery(String.Format("update RI_MasterTargetDongHang
                                                        set YYYY = '{0}'
                                                        where YYYY = '{1}' and DongHang = '{2}' and DefectCode = '{3}'",
                                                        e.Value,
                                                        GridView2.ActiveEditor.OldEditValue,
                                                        GridView2.GetFocusedRowCellValue("DongHang"),
                                                        GridView2.GetFocusedRowCellValue("DefectCode")))
                ElseIf e.Column.FieldName = "DongHang" Then
                    _db.ExecuteNonQuery(String.Format("update RI_MasterTargetDongHang
                                                        set DongHang = '{0}'
                                                        where YYYY = '{1}' and DongHang = '{2}' and DefectCode = '{3}'",
                                                        e.Value,
                                                        GridView2.GetFocusedRowCellValue("YYYY"),
                                                        GridView2.ActiveEditor.OldEditValue,
                                                        GridView2.GetFocusedRowCellValue("DefectCode")))
                ElseIf e.Column.FieldName = "DefectCode" Then
                    _db.ExecuteNonQuery(String.Format("update RI_MasterTargetDongHang
                                                        set DefectCode = '{0}'
                                                        where YYYY = '{1}' and DongHang = '{2}' and DefectCode = '{3}'",
                                                        e.Value,
                                                        GridView2.GetFocusedRowCellValue("YYYY"),
                                                        GridView2.GetFocusedRowCellValue("DongHang"),
                                                        GridView2.ActiveEditor.OldEditValue))
                End If
            End If
        End If
    End Sub
End Class