Imports CommonDB
Imports PublicUtility
Public Class FrmMistakeMaster
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmMistakeMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShow.PerformClick()
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        GridControl1.DataSource = _db.FillDataTable("SELECT * FROM HRA_SA_MistakeMaster")
        GridControlSetFormat(GridView1)
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("NoiDungDanhGia").OptionsColumn.ReadOnly = False
        GridView1.Columns("HangMucDanhGia").OptionsColumn.ReadOnly = False
        GridView1.Columns("TieuChiDanhGia").OptionsColumn.ReadOnly = False
        GridView1.Columns("Point").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
        Dim dt As DataTable = ImportEXCEL(True)
        Dim row = 0
        If dt.Rows.Count > 0 Then
            Try
                _db.BeginTransaction()
                For Each r As DataRow In dt.Rows
                    row += 1
                    Dim obj As New HRA_SA_MistakeMaster
                    obj.ID_K = GetNewID()
                    obj.NoiDungDanhGia = r("NoiDungDanhGia")
                    obj.HangMucDanhGia = r("HangMucDanhGia")
                    If Not IsDBNull(r("TieuChiDanhGia")) Then
                        obj.TieuChiDanhGia = r("TieuChiDanhGia")
                    End If
                    _db.Insert(obj)
                Next
                _db.Commit()
                ShowSuccess(row)
            Catch ex As Exception
                ShowWarning(ex.Message + " - Row " + row.ToString)
                _db.RollBack()
            End Try
        Else
            ShowWarning("Không có dữ liệu Import !")
        End If
    End Sub
    Function GetNewID() As String
        Dim val As Object = _db.ExecuteScalar("SELECT ISNULL(RIGHT(MAX(ID), 2), 0) FROM HRA_SA_MistakeMaster")
        Return "M-" + (val + 1).ToString.PadLeft(2, "0")
    End Function

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.FillDataTable("SELECT * FROM HRA_SA_MistakeMaster")
        GridControlSetFormat(GridView1)
        GridView1.Columns("NoiDungDanhGia").Width = 200
        GridView1.Columns("HangMucDanhGia").Width = 400
        GridView1.Columns("TieuChiDanhGia").Width = 400
        GridView1.OptionsView.ShowFooter = False
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If GridView1.GetFocusedRowCellValue("ID") Is DBNull.Value Then
                    Dim obj As New HRA_SA_MistakeMaster
                    obj.ID_K = GetNewID()
                    _db.Insert(obj)
                    GridView1.SetFocusedRowCellValue("ID", obj.ID_K)
                End If
            End If
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(String.Format(" UPDATE HRA_SA_MistakeMaster
                                                SET {0} = @Value
                                                WHERE ID = '{1}'",
                                                e.Column.FieldName,
                                                GridView1.GetFocusedRowCellValue("ID")),
                                                para)
        End If
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            Dim obj As New HRA_SA_MistakeMaster
            obj.ID_K = GridView1.GetFocusedRowCellValue("ID")
            _db.Delete(obj)
            GridView1.DeleteSelectedRows()
        End If
    End Sub
End Class