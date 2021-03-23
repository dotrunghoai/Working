Imports CommonDB
Imports PublicUtility
Public Class FrmEditMaster
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmEditMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShowPhuongPhap.PerformClick()
        btnShowNhanVien.PerformClick()
        btnShowError.PerformClick()
    End Sub

    Private Sub btnShowPhuongPhap_Click(sender As Object, e As EventArgs) Handles btnShowPhuongPhap.Click
        GridControl1.DataSource = _db.FillDataTable("SELECT * FROM QC_KQCV_MasterMethod")
        GridControlSetFormat(GridView1)
        GridView1.Columns("GhiChu").Width = 200
    End Sub

    Private Sub btnNewPhuongPhap_Click(sender As Object, e As EventArgs) Handles btnNewPhuongPhap.Click
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridControlReadOnly(GridView1, False)
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnEditPhuongPhap_Click(sender As Object, e As EventArgs) Handles btnEditPhuongPhap.Click
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        GridControlReadOnly(GridView1, False)
        GridView1.Columns("KiTu").OptionsColumn.ReadOnly = True
        GridControlSetColorReadonly(GridView1)
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnDeletePhuongPhap_Click(sender As Object, e As EventArgs) Handles btnDeletePhuongPhap.Click
        If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu ?") = Windows.Forms.DialogResult.Yes Then
            _db.ExecuteNonQuery(String.Format("delete QC_KQCV_MasterMethod where KiTu = '{0}'", GridView1.GetFocusedRowCellValue("KiTu")))
            GridView1.DeleteSelectedRows()
        End If
    End Sub

    Private Sub btnExportPhuongPhap_Click(sender As Object, e As EventArgs) Handles btnExportPhuongPhap.Click
        If GridView1.RowCount > 0 Then
            GridControlExportExcel(GridView1)
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable = True And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If e.Column.FieldName = "KiTu" Then
                    Dim obj As New QC_KQCV_MasterMethod
                    obj.KiTu_K = GridView1.GetFocusedRowCellValue("KiTu")
                    If Not _db.ExistObject(obj) Then
                        _db.Insert(obj)
                    End If
                Else
                    If IsDBNull(GridView1.GetFocusedRowCellValue("KiTu")) Then
                        ShowWarning("Bạn phải nhập Kí Tự trước !")
                        GridControl1.DataSource = _db.FillDataTable("SELECT * FROM QC_KQCV_MasterMethod")
                        Return
                    Else
                        Dim para(0) As SqlClient.SqlParameter
                        para(0) = New SqlClient.SqlParameter("@Value", e.Value)
                        _db.ExecuteNonQuery(String.Format("UPDATE QC_KQCV_MasterMethod 
                                                        SET {0} = @Value    
                                                        WHERE KiTu = '{1}'",
                                                        e.Column.FieldName,
                                                        GridView1.GetFocusedRowCellValue("KiTu")), para)
                    End If
                End If
            Else
                If e.Column.FieldName = "KiTu" Then
                    _db.ExecuteNonQuery(String.Format("UPDATE QC_KQCV_MasterMethod
                                                        SET KiTu = '{0}'
                                                        WHERE KiTu = '{1}'",
                                                        GridView1.GetFocusedRowCellValue("KiTu"),
                                                        GridView1.ActiveEditor.OldEditValue))
                Else
                    Dim para(0) As SqlClient.SqlParameter
                    para(0) = New SqlClient.SqlParameter("@Value", e.Value)
                    _db.ExecuteNonQuery(String.Format("UPDATE QC_KQCV_MasterMethod 
                                                        SET {0} = @Value    
                                                        WHERE KiTu = '{1}'",
                                                        e.Column.FieldName,
                                                        GridView1.GetFocusedRowCellValue("KiTu")), para)
                End If
            End If
        End If
    End Sub

    Private Sub btnShowNhanVien_Click(sender As Object, e As EventArgs) Handles btnShowNhanVien.Click
        GridControl2.DataSource = _db.FillDataTable("SELECT * FROM QC_KQCV_MasterNhanVien")
        GridControlSetFormat(GridView2)
        GridView2.Columns("HoTen").Width = 150
    End Sub

    Private Sub btnNewNhanVien_Click(sender As Object, e As EventArgs) Handles btnNewNhanVien.Click
        GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridControlReadOnly(GridView2, False)
        GridControlSetColorEdit(GridView2)
    End Sub

    Private Sub btnEditNhanVien_Click(sender As Object, e As EventArgs) Handles btnEditNhanVien.Click
        GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        GridControlReadOnly(GridView2, False)
        GridView2.Columns("MSNV").OptionsColumn.ReadOnly = True
        GridControlSetColorReadonly(GridView2)
        GridControlSetColorEdit(GridView2)
    End Sub

    Private Sub btnDeleteNhanVien_Click(sender As Object, e As EventArgs) Handles btnDeleteNhanVien.Click
        If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu ?") = Windows.Forms.DialogResult.Yes Then
            _db.ExecuteNonQuery(String.Format("delete QC_KQCV_MasterNhanVien where MSNV = '{0}'", GridView2.GetFocusedRowCellValue("MSNV")))
            GridView2.DeleteSelectedRows()
        End If
    End Sub

    Private Sub btnExportNhanVien_Click(sender As Object, e As EventArgs) Handles btnExportNhanVien.Click
        If GridView2.RowCount > 0 Then
            GridControlExportExcel(GridView2)
        End If
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        If GridView2.Editable = True And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If e.Column.FieldName = "MSNV" Then
                    Dim obj As New QC_KQCV_MasterNhanVien
                    obj.MSNV_K = GridView2.GetFocusedRowCellValue("MSNV")
                    If Not _db.ExistObject(obj) Then
                        _db.Insert(obj)
                    End If
                Else
                    If IsDBNull(GridView2.GetFocusedRowCellValue("MSNV")) Then
                        ShowWarning("Bạn phải nhập MSNV trước !")
                        GridControl2.DataSource = _db.FillDataTable("SELECT * FROM QC_KQCV_MasterNhanVien")
                        Return
                    Else
                        Dim para(0) As SqlClient.SqlParameter
                        para(0) = New SqlClient.SqlParameter("@Value", e.Value)
                        _db.ExecuteNonQuery(String.Format("UPDATE QC_KQCV_MasterNhanVien 
                                                        SET {0} = @Value    
                                                        WHERE MSNV = '{1}'",
                                                        e.Column.FieldName,
                                                        GridView2.GetFocusedRowCellValue("MSNV")), para)
                    End If
                End If
            Else
                If e.Column.FieldName = "MSNV" Then
                    _db.ExecuteNonQuery(String.Format("UPDATE QC_KQCV_MasterNhanVien
                                                        SET MSNV = '{0}'
                                                        WHERE MSNV = '{1}'",
                                                        GridView2.GetFocusedRowCellValue("MSNV"),
                                                        GridView2.ActiveEditor.OldEditValue))
                Else
                    Dim para(0) As SqlClient.SqlParameter
                    para(0) = New SqlClient.SqlParameter("@Value", e.Value)
                    _db.ExecuteNonQuery(String.Format("UPDATE QC_KQCV_MasterNhanVien 
                                                        SET {0} = @Value    
                                                        WHERE MSNV = '{1}'",
                                                        e.Column.FieldName,
                                                        GridView2.GetFocusedRowCellValue("MSNV")), para)
                End If
            End If
        End If
    End Sub

    Private Sub btnShowError_Click(sender As Object, e As EventArgs) Handles btnShowError.Click
        GridControl3.DataSource = _db.FillDataTable("SELECT * FROM QC_KQCV_MasterError")
        GridControlSetFormat(GridView3)
        GridView3.Columns("TenLoi").Width = 100
        GridView3.Columns("NhomLoi").Width = 100
        GridView3.Columns("DinhNghia").Width = 200
    End Sub

    Private Sub btnNewError_Click(sender As Object, e As EventArgs) Handles btnNewError.Click
        GridView3.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridControlReadOnly(GridView3, False)
        GridControlSetColorEdit(GridView3)
    End Sub

    Private Sub btnEditError_Click(sender As Object, e As EventArgs) Handles btnEditError.Click
        GridView3.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        GridControlReadOnly(GridView3, False)
        GridView3.Columns("MaLoi").OptionsColumn.ReadOnly = True
        GridControlSetColorReadonly(GridView3)
        GridControlSetColorEdit(GridView3)
    End Sub

    Private Sub btnDeleteError_Click(sender As Object, e As EventArgs) Handles btnDeleteError.Click
        If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu ?") = Windows.Forms.DialogResult.Yes Then
            _db.ExecuteNonQuery(String.Format("delete QC_KQCV_MasterError where MaLoi = '{0}'", GridView3.GetFocusedRowCellValue("MaLoi")))
            GridView3.DeleteSelectedRows()
        End If
    End Sub

    Private Sub btnExportError_Click(sender As Object, e As EventArgs) Handles btnExportError.Click
        If GridView3.RowCount > 0 Then
            GridControlExportExcel(GridView3)
        End If
    End Sub

    Private Sub GridView3_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView3.CellValueChanged
        If GridView3.Editable = True And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If e.Column.FieldName = "MaLoi" Then
                    Dim obj As New QC_KQCV_MasterError
                    obj.MaLoi_K = GridView3.GetFocusedRowCellValue("MaLoi")
                    If Not _db.ExistObject(obj) Then
                        _db.Insert(obj)
                    End If
                Else
                    If IsDBNull(GridView3.GetFocusedRowCellValue("MaLoi")) Then
                        ShowWarning("Bạn phải nhập Mã Lỗi trước !")
                        GridControl3.DataSource = _db.FillDataTable("SELECT * FROM QC_KQCV_MasterError")
                        Return
                    Else
                        Dim para(0) As SqlClient.SqlParameter
                        para(0) = New SqlClient.SqlParameter("@Value", e.Value)
                        _db.ExecuteNonQuery(String.Format("UPDATE QC_KQCV_MasterError 
                                                        SET {0} = @Value    
                                                        WHERE MaLoi = '{1}'",
                                                        e.Column.FieldName,
                                                        GridView3.GetFocusedRowCellValue("MaLoi")), para)
                    End If
                End If
            Else
                If e.Column.FieldName = "MaLoi" Then
                    _db.ExecuteNonQuery(String.Format("UPDATE QC_KQCV_MasterError
                                                        SET MaLoi = '{0}'
                                                        WHERE MaLoi = '{1}'",
                                                        GridView3.GetFocusedRowCellValue("MaLoi"),
                                                        GridView3.ActiveEditor.OldEditValue))
                Else
                    Dim para(0) As SqlClient.SqlParameter
                    para(0) = New SqlClient.SqlParameter("@Value", e.Value)
                    _db.ExecuteNonQuery(String.Format("UPDATE QC_KQCV_MasterError 
                                                        SET {0} = @Value    
                                                        WHERE MaLoi = '{1}'",
                                                        e.Column.FieldName,
                                                        GridView3.GetFocusedRowCellValue("MaLoi")), para)
                End If
            End If
        End If
    End Sub
End Class