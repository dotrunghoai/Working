Imports CommonDB
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports PublicUtility
Public Class FrmOutGoing
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dteStart.DateTime))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dteEnd.DateTime))
        para(2) = New SqlClient.SqlParameter("@Status", DBNull.Value)
        If chbValid.Checked Then
            para(2) = New SqlClient.SqlParameter("@Status", "Valid")
        ElseIf chbInvalid.Checked Then
            para(2) = New SqlClient.SqlParameter("@Status", "Invalid")
        End If
        GridControl1.DataSource = _db.FillDataTable("
            SELECT * INTO #WT_ProductTam 
            FROM WT_Product
            UPDATE #WT_ProductTam
            SET CustomerName = 'SEAGATE'
            WHERE CustomerName = 'SEAGATE(KDC)'
            UPDATE #WT_ProductTam
            SET CustomerName = 'WDC'
            WHERE CustomerName = 'HGST'

            SELECT ri.Ngay, ri.ProductCode, ri.LotNumber, pr.CustomerName, pr.Method, 
            ri.InputQty, ri.Quantity, (ri.InputQty - ri.Quantity) AS ScrapQuantity, ps.M2PerPcs, 
            (ri.InputQty * ps.M2PerPcs) AS SQMInput, (ri.Quantity * ps.M2PerPcs) as SQMGood, 
            (ri.Quantity*1.0/nullif(ri.InputQty, 0)) as TLCP, ri.Status, ri.Note INTO #Temp
            FROM RI_Outgoing AS ri
            LEFT JOIN PS_ProductM2 AS ps 
            ON ri.ProductCode = ps.ProductCode 
            AND ri.RevisionCode = ps.RevisionCode
            LEFT JOIN #WT_ProductTam AS pr 
            ON ri.ProductCode = pr.ProductCode
            WHERE Ngay between @StartDate and @EndDate
            IF @Status = 'Valid'
                SELECT *
                FROM #Temp
                WHERE Status = 1
            ELSE IF @Status = 'Invalid'
                SELECT *
                FROM #Temp
                WHERE Status = 0
            ELSE 
                SELECT *
                FROM #Temp",
            para)
        GridControlSetFormat(GridView1, 2)
        GridControlSetFormatPercentage(GridView1, "TLCP", 2)
        GridControlSetFormatNumber(GridView1, "M2PerPcs", 8)
        GridView1.Columns("Note").Width = 150
        If GridView1.RowCount > 0 Then
            Dim cGrid1 As GridColumn = GridView1.Columns("TLCP")
            cGrid1.SummaryItem.SummaryType = SummaryItemType.Custom
            cGrid1.SummaryItem.DisplayFormat = "{0:p}"
        End If
    End Sub

    Private Sub FrmOutGoing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteStart.EditValue = DateTime.Now.AddDays(-1)
        dteEnd.EditValue = DateTime.Now.AddDays(-1)
        dteStartGetData.EditValue = DateTime.Now
        dteEndGetData.EditValue = DateTime.Now
        Dim obj As New Main_UserRight
        obj.UserID_K = CurrentUser.UserID
        obj.FormID_K = Tag
        _db.GetObject(obj)
        If obj.IsEdit = False And obj.IsAdmin = False Then
            ViewAccessEdit()
        End If
        If obj.IsAdmin = False Then
            ViewAccessAdmin()
        End If
    End Sub
    Sub ViewAccessEdit()
        btnEdit.Enabled = False
        btnLayDuLieu.Enabled = False
    End Sub
    Sub ViewAccessAdmin()
        btnCancel.Enabled = False
        btnUncancel.Enabled = False
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
        GridView1.Columns("InputQty").OptionsColumn.ReadOnly = False
        GridView1.Columns("Note").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.ReadOnly = False And GridView1.Editable = True Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(String.Format("UPDATE RI_Outgoing 
                                               SET {0} = @Value 
                                               WHERE ProductCode = '{1}' 
                                               AND LotNumber = '{2}'",
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
            _db.ExecuteStoreProcedure("sp_RI_GetAutoDay_2_OutGoing", para)
            startDay = startDay.AddDays(1)
        End While
        ShowSuccess()
    End Sub

    Private Sub GridView1_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        Dim gridSum As GridSummaryItem = e.Item
        If e.IsTotalSummary Then
            Select Case e.SummaryProcess
                'calculation entry point
                Case CustomSummaryProcess.Start
                    'consequent calculations
                Case CustomSummaryProcess.Calculate
                    'final summary value
                Case CustomSummaryProcess.Finalize
                    If gridSum.FieldName = "TLCP" Then
                        e.TotalValue = GridView1.Columns("Quantity").SummaryItem.SummaryValue / GridView1.Columns("InputQty").SummaryItem.SummaryValue
                    End If
            End Select
        End If
    End Sub

    Private Sub btnCancel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCancel.ItemClick
        For Each r As Integer In GridView1.GetSelectedRows
            _db.ExecuteNonQuery(String.Format("UPDATE RI_OutGoing
                                                SET Status = 0
                                                WHERE ProductCode = '{0}'
                                                AND LotNumber = '{1}'",
                                                GridView1.GetRowCellValue(r, "ProductCode"),
                                                GridView1.GetRowCellValue(r, "LotNumber")))
            GridView1.SetRowCellValue(r, "Status", False)
        Next
    End Sub

    Private Sub btnUncancel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnUncancel.ItemClick
        For Each r As Integer In GridView1.GetSelectedRows
            _db.ExecuteNonQuery(String.Format("UPDATE RI_OutGoing
                                                SET Status = 1
                                                WHERE ProductCode = '{0}'
                                                AND LotNumber = '{1}'",
                                                GridView1.GetRowCellValue(r, "ProductCode"),
                                                GridView1.GetRowCellValue(r, "LotNumber")))
            GridView1.SetRowCellValue(r, "Status", True)
        Next
    End Sub
End Class