Imports CommonDB
Imports PublicUtility
Public Class FrmBomB0
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmBomB0_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteStartDate.EditValue = Date.Now.AddDays(-15)
        dteEndDate.EditValue = Date.Parse(dteStartDate.EditValue).AddMonths(9)
        Dim dtTuanImp = _db.FillDataTable(" SELECT DISTINCT TuanImport
                                            FROM PLM_FC_Boo
                                            ORDER BY TuanImport DESC")
        For Each r As DataRow In dtTuanImp.Rows
            cbbTuanImport.Properties.Items.Add(r("TuanImport"))
        Next
        cbbTuanImport.SelectedIndex = 0
    End Sub
    'Private Sub dteStartDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteStartDate.EditValueChanged
    '    If dteStartDate.EditValue > dteEndDate.EditValue Then
    '        dteEndDate.EditValue = dteStartDate.EditValue
    '    End If
    'End Sub
    'Private Sub dteEndDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteEndDate.EditValueChanged
    '    If dteEndDate.EditValue < dteStartDate.EditValue Then
    '        dteStartDate.EditValue = dteEndDate.EditValue
    '    End If
    'End Sub
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        If cbbTuanImport.Text <> "" Then
            GridView1.Columns.Clear()
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@TuanImport", cbbTuanImport.Text)
            Try
                GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_PLM_LoadBomB0", para)
                If GridView1.RowCount > 0 Then
                    GridControlSetFormat(GridView1, 5)
                    GridControlSetFormatNumber(GridView1, "Std_StdQtyP", 8)
                    GridControlSetFormatNumber(GridView1, "Adjust", 8)
                    GridControlSetFormatPercentage(GridView1, "TLCP", 3)
                    GridControlSetFormatPercentage(GridView1, "TLSX", 2)
                    GridView1.OptionsView.ShowFooter = False
                    GridView1.BestFitColumns()
                End If
            Catch ex As Exception
                ShowWarning(ex.Message)
            End Try
        Else
            ShowWarning("Bạn chưa chọn Tuần Import !")
            cbbTuanImport.Select()
        End If
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("Adjust").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(String.Format(" UPDATE PLM_Bom_B0
                                                SET {0} = @Value
                                                WHERE TuanImport = '{1}'
                                                AND Std_PdCode = '{2}'
                                                AND Std_Rc = '{3}'
                                                AND Std_Cc = '{4}'
                                                AND Std_Pn = '{5}'
                                                AND Std_MatCode = '{6}'",
                                                e.Column.FieldName,
                                                GridView1.GetFocusedRowCellValue("TuanImport"),
                                                GridView1.GetFocusedRowCellValue("ProductCode"),
                                                GridView1.GetFocusedRowCellValue("Std_Rc"),
                                                GridView1.GetFocusedRowCellValue("Std_Cc"),
                                                GridView1.GetFocusedRowCellValue("Std_Pn"),
                                                GridView1.GetFocusedRowCellValue("Std_MatCode")), para)
        End If
    End Sub

    Private Sub cbbTuanImport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbTuanImport.SelectedIndexChanged
        dteStartDate.EditValue = _db.ExecuteScalar(String.Format("  SELECT TOP 1 Tuan
                                                                    FROM PLM_FC_Boo
                                                                    WHERE TuanImport = '{0}'
                                                                    ORDER BY Tuan",
                                                                    cbbTuanImport.Text))
        dteEndDate.EditValue = _db.ExecuteScalar(String.Format("SELECT TOP 1 Tuan
                                                                FROM PLM_FC_Boo
                                                                WHERE TuanImport = '{0}'
                                                                ORDER BY Tuan DESC",
                                                                cbbTuanImport.Text))
    End Sub
End Class