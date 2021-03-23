Imports CommonDB
Imports PublicUtility

Public Class FrmTargeCode
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click

        Dim sql As String = String.Format(" select * from DF_TargetCodeAll " +
                                          " where yyyy like '%{0}%'" +
                                          " order by Customer,DefectCode",
                                          dtpYear.Value.Year)

        GridControl1.DataSource = _db.FillDataTable(sql)
        GridControlSetFormat(GridView1)
        GridControlSetColorReadonly(GridView1)
    End Sub

    Private Sub mnuEdit_Click(sender As System.Object, e As System.EventArgs) Handles mnuEdit.Click
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("Rate").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub FrmTargetCode_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub


    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click
        If GridView1.SelectedRowsCount > 0 Then
            For Each r As Integer In GridView1.GetSelectedRows
                Dim obj As New DF_TargetCodeAll
                obj.YYYY_K = GridView1.GetRowCellValue(r, "YYYY")
                obj.Customer_K = GridView1.GetRowCellValue(r, "Customer")
                obj.DefectCode_K = GridView1.GetRowCellValue(r, "DefectCode")
                _db.Delete(obj)
            Next
            mnuShowAll.PerformClick()
        End If
    End Sub

    Private Sub mnuImport_Click(sender As System.Object, e As System.EventArgs) Handles mnuImport.Click
        Dim dtCode As DataTable = ImportEXCEL(True)
        If dtCode.Rows.Count > 0 Then
            For Each r As DataRow In dtCode.Rows
                Dim obj As New DF_TargetCodeAll
                obj.YYYY_K = r("YYYY")
                obj.Customer_K = r("Customer")
                obj.DefectCode_K = r("DefectCode")
                If IsNumeric(r("Rate")) Then
                    obj.Rate = r("Rate")
                End If
                If _db.ExistObject(obj) Then
                    _db.Update(obj)
                Else
                    _db.Insert(obj)
                End If
            Next
            ShowSuccess()
            mnuShowAll.PerformClick()
        Else
            ShowWarning("Không có dữ liệu để Import !")
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.ReadOnly = False And GridView1.Editable Then
            Dim obj As New DF_TargetCodeAll
            obj.YYYY_K = dtpYear.Value.Year
            obj.Customer_K = GridView1.GetFocusedRowCellValue("Customer")
            obj.DefectCode_K = GridView1.GetFocusedRowCellValue("DefectCode")
            obj.Rate = GridView1.GetFocusedRowCellValue("Rate")
            If Not _db.ExistObject(obj) Then
                _db.Insert(obj)
            Else
                _db.Update(obj)
            End If
        End If
    End Sub
End Class