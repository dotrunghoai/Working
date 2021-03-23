Imports CommonDB
Imports PublicUtility
Public Class FrmRandomSample
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dteStart.DateTime))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dteEnd.DateTime))
        GridControl1.DataSource = _db.FillDataTable("select ri.Ngay, ri.ProductCode, ri.LotNumber, pr.CustomerName, pr.Method,
                                                    ri.Quantity, ps.M2PerPcs, (ri.Quantity * ps.M2PerPcs) as SQMGood, ScrapQuantity, Note
                                                    from RI_RandomSample as ri
                                                    left join PS_ProductM2 as ps 
                                                    on ri.ProductCode = ps.ProductCode and ri.RevisionCode = ps.RevisionCode
                                                    left join WT_Product as pr on ri.ProductCode = pr.ProductCode
                                                    where Ngay between @StartDate and @EndDate", para)
        GridControlSetFormat(GridView1)
        GridControlSetFormatNumber(GridView1, "M2PerPcs", 8)
        GridView1.Columns("Note").Width = 150
    End Sub

    Private Sub FrmRandomSample_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteStart.EditValue = DateTime.Now.AddDays(-1)
        dteEnd.EditValue = DateTime.Now.AddDays(-1)
        dteStartGetData.EditValue = DateTime.Now
        dteEndGetData.EditValue = DateTime.Now
    End Sub

    Private Sub dteStart_EditValueChanged(sender As Object, e As EventArgs) Handles dteStart.EditValueChanged
        If dteStart.DateTime > dteEnd.DateTime Then
            dteEnd.EditValue = dteStart.DateTime
        End If
    End Sub

    Private Sub dteEnd_EditValueChanged(sender As Object, e As EventArgs) Handles dteEnd.EditValueChanged
        If dteEnd.DateTime < dteStart.DateTime Then
            dteStart.EditValue = dteEnd.DateTime
        End If
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("Ngay").OptionsColumn.ReadOnly = False
        GridView1.Columns("Quantity").OptionsColumn.ReadOnly = False
        GridView1.Columns("ScrapQuantity").OptionsColumn.ReadOnly = False
        GridView1.Columns("Note").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.ReadOnly = False And GridView1.Editable = True Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(String.Format("update RI_RandomSample 
                                               set {0} = @Value 
                                               where ProductCode = '{1}' 
                                               and LotNumber = '{2}'",
                                               e.Column.FieldName,
                                               GridView1.GetFocusedRowCellValue("ProductCode"),
                                               GridView1.GetFocusedRowCellValue("LotNumber")), para)
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        If GridView1.RowCount > 0 Then
            GridControlExportExcel(GridView1)
        End If
    End Sub

    Private Sub dteStartGetData_EditValueChanged(sender As Object, e As EventArgs) Handles dteStartGetData.EditValueChanged
        If dteStartGetData.DateTime > dteEndGetData.DateTime Then
            dteEndGetData.EditValue = dteStartGetData.DateTime
        End If
    End Sub

    Private Sub dteEndGetData_EditValueChanged(sender As Object, e As EventArgs) Handles dteEndGetData.EditValueChanged
        If dteEndGetData.DateTime < dteStartGetData.DateTime Then
            dteStartGetData.EditValue = dteEndGetData.DateTime
        End If
    End Sub

    Private Sub btnLayDuLieu_Click(sender As Object, e As EventArgs) Handles btnLayDuLieu.Click
        Dim startDay As DateTime = GetStartDate(dteStartGetData.DateTime)
        Dim endDay As DateTime = GetStartDate(dteEndGetData.DateTime)
        While startDay <= endDay
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Today", startDay)
            _db.ExecuteStoreProcedure("sp_RI_GetAutoDay_2_RandomSample", para)
            startDay = startDay.AddDays(1)
        End While
        ShowSuccess()
    End Sub
End Class