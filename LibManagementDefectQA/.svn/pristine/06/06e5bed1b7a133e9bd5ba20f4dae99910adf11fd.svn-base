Imports CommonDB
Imports LibEntity
Imports PublicUtility
Imports System.Windows.Forms


Public Class FrmBaoCaoKaifa : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)


    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        Dim lst As New List(Of DataGridView)
        lst.Add(gridD)
        lst.Add(gridDe)
        lst.Add(gridPDI)
        ExportEXCEL(lst)
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim startDate As DateTime = GetStartDate(dtpStart.Value)
        Dim endDate As DateTime = GetStartDate(dtpEnd.Value)
        Dim para(1) As SqlClient.SqlParameter

        gridD.RowCount = 3
        gridD.ColumnCount = 1

        gridDe.RowCount = 0
        gridDe.ColumnCount = 3

        gridPDI.RowCount = 0
        gridPDI.ColumnCount = 3

        gridD.Rows(0).Cells("Ngay").Value = "Sampling Qty (pcs)"
        gridD.Rows(1).Cells("Ngay").Value = "Defects Qty (pcs)"
        gridD.Rows(2).Cells("Ngay").Value = "DPPM (K)"

        'While startDate <= endDate
        Dim sqlM As String = String.Format("SELECT " +
                                          " sum(d.SL)  AQL" +
                                          " ,sum(d.DefectQty) as DefectQty " +
                                          " FROM [MDQA_KTPL] h " +
                                          " inner join MDQA_KTPL_Detail d on h.ID=d.ID " +
                                          " where Ngay between @StartDate and @EndDate and CuDiemXuat='KAIFA' and  [Customer]='SEAGATE' " +
                                          "  ")
        para(0) = New SqlClient.SqlParameter("@StartDate", startDate)
        para(1) = New SqlClient.SqlParameter("@EndDate", endDate)

        Dim dtM As DataTable = _db.FillDataTable(sqlM, para)
        Dim S As String = "S" & startDate.ToString("ddMMyy")
        gridD.Columns.Add(S, startDate.ToString("dd") & "-" & endDate.ToString("dd-MMM-yy"))
        gridD.Columns(S).Width = 90
        gridD.Columns(S).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridD.Rows(0).Cells(S).Value = dtM.Compute("sum(AQL)", "")
        gridD.Rows(1).Cells(S).Value = dtM.Compute("sum(DefectQty)", "")
        If gridD.Rows(0).Cells(S).Value IsNot DBNull.Value And gridD.Rows(1).Cells(S).Value IsNot DBNull.Value Then
            gridD.Rows(2).Cells(S).Value = CType((gridD.Rows(1).Cells(S).Value * 1.0) / gridD.Rows(0).Cells(S).Value, Decimal).ToString("N2")
        Else

        End If
        'startDate = startDate.AddDays(6 + 1)
        'End While
        startDate = GetStartDate(dtpStart.Value)
        endDate = GetStartDate(dtpEnd.Value)
        para(0) = New SqlClient.SqlParameter("@StartDate", startDate)
        para(1) = New SqlClient.SqlParameter("@EndDate", endDate)
        Dim dtCode As DataTable = _db.FillDataTable(" SELECT  d.[DefectCode],c.DefectNameE, sum(d.[DefectQty]) as qty, sum(d.[SL]) as AQL " +
                                                     " FROM  [MDQA_KTPL] h" +
                                                     " inner join [dbo].[MDQA_KTPL_Detail] d" +
                                                     " on h.ID=d.ID" +
                                                     " left join [dbo].[MDQA_DefectCode] c" +
                                                     " on c.DefectCode=d.DefectCode" +
                                                     " where Ngay between @StartDate and @EndDate and CuDiemXuat='KAIFA' " +
                                                     " and  [Customer]='SEAGATE'   " +
                                                     " group by  d.[DefectCode],c.DefectNameE" +
                                                     " order by qty desc  ", para)
        Dim sumDefect As Decimal = IIf(dtCode.Compute("sum(qty)", "") Is DBNull.Value, 0, dtCode.Compute("sum(qty)", ""))
        Dim sumAQL As Decimal = IIf(dtCode.Compute("sum(AQL)", "") Is DBNull.Value, 0, dtCode.Compute("sum(AQL)", ""))
        For Each r As DataRow In dtCode.Rows
            gridDe.Rows.Add(1)
            gridDe.Rows(gridDe.RowCount - 1).Cells("Deffect").Tag = r("DefectCode")
            gridDe.Rows(gridDe.RowCount - 1).Cells("Deffect").Value = r("DefectNameE")
            gridDe.Rows(gridDe.RowCount - 1).Cells("Qty").Value = r("qty")
            gridDe.Rows(gridDe.RowCount - 1).Cells("Dppmk").Value = gridDe.Rows(gridDe.RowCount - 1).Cells("Qty").Value * 1000.0 / sumAQL
        Next
        gridDe.Rows.Add(1)
        gridDe.Rows(gridDe.RowCount - 1).Cells("Deffect").Value = "Defects Qty (pcs)"
        gridDe.Rows(gridDe.RowCount - 1).Cells("Qty").Value = sumDefect
        If sumAQL > 0 Then
            gridDe.Rows(gridDe.RowCount - 1).Cells("Dppmk").Value = sumDefect / sumAQL
        End If

        gridDe.Rows.Add(1)
        gridDe.Rows(gridDe.RowCount - 1).Cells("Deffect").Value = "Sampling Qty (pcs)"
        gridDe.Rows(gridDe.RowCount - 1).Cells("Qty").Value = sumAQL

        Dim dtPDI As DataTable = _db.ExecuteStoreProcedureTB("sp_MDQA_BaoCaoKaifaPDI", para)
        Dim sumDefectP As Decimal = IIf(dtPDI.Compute("sum(qty)", "") Is DBNull.Value, 0, dtPDI.Compute("sum(qty)", ""))
        Dim objAQL As Object = _db.ExecuteScalarSP("[sp_MDQA_BaoCaoKaifaPDI_TotalAQL]", para)
        Dim sumAQLP As Decimal = 1
        If IsNumeric(objAQL) Then
            sumAQLP = objAQL
        End If
        For Each r As DataRow In dtPDI.Rows
            gridPDI.Rows.Add(1)
            gridPDI.Rows(gridPDI.RowCount - 1).Cells("DeffectP").Tag = ""
            gridPDI.Rows(gridPDI.RowCount - 1).Cells("DeffectP").Value = r("DefectNameE")
            gridPDI.Rows(gridPDI.RowCount - 1).Cells("QtyP").Value = r("qty")
            gridPDI.Rows(gridPDI.RowCount - 1).Cells("DppmkP").Value = gridPDI.Rows(gridPDI.RowCount - 1).Cells("QtyP").Value * 1000.0 / sumAQLP
        Next
        gridPDI.Rows.Add(1)
        gridPDI.Rows(gridPDI.RowCount - 1).Cells("DeffectP").Value = "Defects Qty (pcs)"
        gridPDI.Rows(gridPDI.RowCount - 1).Cells("QtyP").Value = sumDefectP
        If sumAQL > 0 Then
            gridPDI.Rows(gridPDI.RowCount - 1).Cells("DppmkP").Value = sumDefectP / sumAQLP
        End If

        gridPDI.Rows.Add(1)
        gridPDI.Rows(gridPDI.RowCount - 1).Cells("DeffectP").Value = "Sampling Qty (pcs)"
        gridPDI.Rows(gridPDI.RowCount - 1).Cells("QtyP").Value = sumAQLP

        'Load ProductCode,Lotnumber
        gridLot.DataSource = _db.ExecuteStoreProcedureTB("[sp_MDQA_BaoCaoKaifaPDI_LotNo]", para)

    End Sub
End Class