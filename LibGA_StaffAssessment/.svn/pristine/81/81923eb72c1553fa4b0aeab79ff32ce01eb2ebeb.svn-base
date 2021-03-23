Imports CommonDB
Imports DevExpress.XtraEditors
Imports PublicUtility
Public Class FrmStaffAssessment
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmStaffAssessment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnNew.PerformClick()
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        GridControl1.DataSource = _db.FillDataTable("SELECT TOP 0 CAST(NULL AS VARCHAR) AS EmpID, 
                                                            CAST(NULL AS NVARCHAR) AS EmpName,
                                                            CAST(NULL AS VARCHAR) AS MistakeID,
                                                            CAST(NULL AS NVARCHAR) AS NoiDungDanhGia,
                                                            CAST(NULL AS NVARCHAR) AS HangMucDanhGia,
                                                            CAST(NULL AS NVARCHAR) AS TieuChiDanhGia,
                                                            CAST(NULL AS INT) AS Point,
                                                            CAST(NULL AS DATETIME) AS Ngay")
        GridControlSetFormat(GridView1)
        GridView1.Columns("EmpName").Width = 150
        GridView1.Columns("NoiDungDanhGia").Width = 220
        GridView1.Columns("HangMucDanhGia").Width = 220
        GridView1.Columns("TieuChiDanhGia").Width = 300
        GridView1.Columns("Ngay").Width = 100
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("EmpID").OptionsColumn.ReadOnly = False
        GridView1.Columns("MistakeID").OptionsColumn.ReadOnly = False
        GridView1.Columns("Ngay").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)

        slueEmployee.DataSource = _db.FillDataTable(String.Format("SELECT ECode, EName, Section, Observation
                                                                    FROM HRM_Emloyee
                                                                    WHERE ResignedDate IS NULL
                                                                    AND Section = '{0}'",
                                                                    CurrentUser.Section))
        slueEmployee.DisplayMember = "ECode"
        slueEmployee.ValueMember = "ECode"
        slueEmployee.NullText = Nothing
        GridView1.Columns("EmpID").ColumnEdit = slueEmployee

        slueMistake.DataSource = _db.FillDataTable("SELECT * FROM HRA_SA_MistakeMaster")
        slueMistake.DisplayMember = "ID"
        slueMistake.ValueMember = "ID"
        slueMistake.NullText = Nothing
        GridView1.Columns("MistakeID").ColumnEdit = slueMistake
    End Sub

    Private Sub slueEmployee_EditValueChanged(sender As Object, e As EventArgs) Handles slueEmployee.EditValueChanged
        Dim lc As SearchLookUpEdit = CType(sender, SearchLookUpEdit)
        GridView1.SetFocusedRowCellValue("EmpName", lc.Properties.View.GetFocusedRowCellValue("EName"))
    End Sub

    Private Sub slueMistake_EditValueChanged(sender As Object, e As EventArgs) Handles slueMistake.EditValueChanged
        Dim lc As SearchLookUpEdit = CType(sender, SearchLookUpEdit)
        GridView1.SetFocusedRowCellValue("NoiDungDanhGia", lc.Properties.View.GetFocusedRowCellValue("NoiDungDanhGia"))
        GridView1.SetFocusedRowCellValue("HangMucDanhGia", lc.Properties.View.GetFocusedRowCellValue("HangMucDanhGia"))
        GridView1.SetFocusedRowCellValue("TieuChiDanhGia", lc.Properties.View.GetFocusedRowCellValue("TieuChiDanhGia"))
        GridView1.SetFocusedRowCellValue("Point", lc.Properties.View.GetFocusedRowCellValue("Point"))
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If e.Column.FieldName = "Ngay" Then
                    If Not IsDBNull(GridView1.GetFocusedRowCellValue("EmpID")) And
                        Not IsDBNull(GridView1.GetFocusedRowCellValue("MistakeID")) Then
                        Dim obj As New HRA_SA_StaffAssessment
                        obj.EmpID_K = GridView1.GetFocusedRowCellValue("EmpID")
                        obj.MistakeID_K = GridView1.GetFocusedRowCellValue("MistakeID")
                        obj.Ngay_K = GridView1.GetFocusedRowCellValue("Ngay")
                        If Not _db.ExistObject(obj) Then
                            _db.Insert(obj)
                        Else
                            ShowWarning("Đã được đánh giá !")
                        End If
                    Else
                        ShowWarning("Bạn chưa nhập EmpID hoặc MistakeID !")
                        GridView1.Columns("Ngay").OptionsColumn.ReadOnly = True
                        GridView1.SetFocusedRowCellValue("Ngay", DBNull.Value)
                        GridView1.Columns("Ngay").OptionsColumn.ReadOnly = False
                    End If
                End If
            End If
        End If
    End Sub
End Class