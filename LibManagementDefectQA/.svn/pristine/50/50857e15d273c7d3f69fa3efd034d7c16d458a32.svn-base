
Imports CommonDB
Imports LibEntity
Imports PublicUtility
Imports System.Windows.Forms

Public Class FrmBaoCaoSeagate : Inherits DevExpress.XtraEditors.XtraForm
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)


    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim startDate As DateTime = GetStartDate(dtpStart.Value)
        Dim endDate As DateTime = GetEndDate(dtpEnd.Value)
        Dim sqlW As String = "sp_MDQA_BaoCaoSeagate"
        Dim sum1 As Decimal = 0 
        Dim sumTotal As Decimal = 0
        Dim loaiHang As String = ""

        Dim para(2) As SqlClient.SqlParameter

        gridM.RowCount = 0
        gridM.RowCount = 8
        gridM.ColumnCount = 1
        gridD.RowCount = 0
        gridD.ColumnCount = 1
        gridD.RowCount = 0

        gridM.Rows(0).Cells("W").Value = "Lot Inspected  (lot)"
        gridM.Rows(1).Cells("W").Value = "Lot Accepted (lot)"
        gridM.Rows(2).Cells("W").Value = "%LAR"
        gridM.Rows(3).Cells("W").Value = "In put Qty (pcs)"
        gridM.Rows(4).Cells("W").Value = "Sampling Qty  (pcs)"
        gridM.Rows(5).Cells("W").Value = "Defects Qty (pcs)"
        gridM.Rows(6).Cells("W").Value = "DPPM(QA)"
        gridM.Rows(7).Cells("W").Value = "DPPM(Target)"
        '==========Dữ liệu tuần============================

        'While startDate <= endDate
        para(0) = New SqlClient.SqlParameter("@StartDate", startDate) 
        para(1) = New SqlClient.SqlParameter("@EndDate", endDate) 

        If rdoKiemLai.Checked Then
            para(2) = New SqlClient.SqlParameter("@LoaiHang", "KIEM-LAI")
            loaiHang = "KIEM-LAI"
        ElseIf rdoThuNghiem.Checked Then
            para(2) = New SqlClient.SqlParameter("@LoaiHang", "THU-NGHIEM")
            loaiHang = "THU-NGHIEM"
        ElseIf rdoHangThuong.Checked Then
            para(2) = New SqlClient.SqlParameter("@LoaiHang", "HANG-THUONG")
            loaiHang = "HANG-THUONG"
        Else
            para(2) = New SqlClient.SqlParameter("@LoaiHang", "")
            loaiHang = ""
        End If

        Dim dtW As DataTable = _db.ExecuteStoreProcedureTB(sqlW, para)
        Dim W As String = "S" & startDate.ToString("ddMMyy")
        gridM.Columns.Add(W, dtpStart.Value.ToString("dd/MM") & "-" & dtpEnd.Value.ToString("dd/MM"))
        gridM.Columns(W).Width = 80
        'gridM.Columns(W).DefaultCellStyle.Format = "N2"
        gridM.Columns(W).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        gridM.Rows(0).Cells(W).Value = dtW.Compute("sum(LotCount)", "")
        gridM.Rows(1).Cells(W).Value = dtW.Compute("sum(LotCountOK)", "")
        If gridM.Rows(1).Cells(W).Value IsNot DBNull.Value And gridM.Rows(0).Cells(W).Value IsNot DBNull.Value Then
            gridM.Rows(2).Cells(W).Value = CType(gridM.Rows(1).Cells(W).Value * 100.0 / gridM.Rows(0).Cells(W).Value, Decimal).ToString("N2")
        Else
            gridM.Rows(2).Cells(W).Value = DBNull.Value
        End If
        If IsNumeric(gridM.Rows(0).Cells(W).Value) Then
            gridM.Rows(3).Cells(W).Value = CType(dtW.Compute("sum(LotQty)", " "), Decimal).ToString("N0")
            gridM.Rows(4).Cells(W).Value = CType(dtW.Compute("sum(AQL)", ""), Decimal).ToString("N0")
            gridM.Rows(5).Cells(W).Value = CType(dtW.Compute("sum(DefectQty)", ""), Decimal).ToString("N0")
            If gridM.Rows(4).Cells(W).Value IsNot DBNull.Value And gridM.Rows(5).Cells(W).Value IsNot DBNull.Value Then
                gridM.Rows(6).Cells(W).Value = CType(gridM.Rows(5).Cells(W).Value / gridM.Rows(4).Cells(W).Value * 1000000, Decimal).ToString("N0")
            End If
        End If
        '==========Dữ liệu chi tiết lỗi theo tuần============================
        startDate = GetStartDate(dtpStart.Value)
        endDate = GetEndDate(dtpEnd.Value)
        para(0) = New SqlClient.SqlParameter("@StartDate", startDate)
        para(1) = New SqlClient.SqlParameter("@EndDate", endDate)
        Dim dtCode As New DataTable
        If loaiHang = "" Then
            dtCode = _db.FillDataTable(String.Format(" SELECT  d.[DefectCode],c.DefectNameE, sum(d.[DefectQty]) as qty " +
                                                     " FROM  [MDQA_KTPL] h" +
                                                     " left join [dbo].[MDQA_KTPL_Detail] d" +
                                                     " on h.ID=d.ID" +
                                                     " inner join [dbo].[MDQA_DefectCode] c" +
                                                     " on c.DefectCode=d.DefectCode" +
                                                     " where Ngay between @StartDate and @EndDate and  [Customer]='SEAGATE'  " +
                                                     " group by  d.[DefectCode],c.DefectNameE" +
                                                     " order by qty desc  "), para)
        ElseIf loaiHang = "HANG-THUONG" Then
            dtCode = _db.FillDataTable(String.Format(" SELECT  d.[DefectCode],c.DefectNameE, sum(d.[DefectQty]) as qty " +
                                                    " FROM  [MDQA_KTPL] h" +
                                                    " left join [dbo].[MDQA_KTPL_Detail] d" +
                                                    " on h.ID=d.ID" +
                                                    " inner join [dbo].[MDQA_DefectCode] c" +
                                                    " on c.DefectCode=d.DefectCode" +
                                                    " where Ngay between @StartDate and @EndDate and  [Customer]='SEAGATE' and (h.LoaiHang='{0}' or LoaiHang='TACH-LO')" +
                                                    " group by  d.[DefectCode],c.DefectNameE" +
                                                    " order by qty desc  ", loaiHang), para)
        Else
            dtCode = _db.FillDataTable(String.Format(" SELECT  d.[DefectCode],c.DefectNameE, sum(d.[DefectQty]) as qty " +
                                                     " FROM  [MDQA_KTPL] h" +
                                                     " left join [dbo].[MDQA_KTPL_Detail] d" +
                                                     " on h.ID=d.ID" +
                                                     " inner join [dbo].[MDQA_DefectCode] c" +
                                                     " on c.DefectCode=d.DefectCode" +
                                                     " where Ngay between @StartDate and @EndDate and  [Customer]='SEAGATE' and h.LoaiHang='{0}' " +
                                                     " group by  d.[DefectCode],c.DefectNameE" +
                                                     " order by qty desc  ", loaiHang), para)
        End If
        para(0) = New SqlClient.SqlParameter("@StartDate", startDate)
        para(1) = New SqlClient.SqlParameter("@EndDate", endDate)

        Dim dtQty1 As New DataTable
        If loaiHang = "" Then
            dtQty1 = _db.FillDataTable(String.Format(" SELECT  d.[DefectCode], sum(d.[DefectQty]) as qty " +
                                                 " FROM  [MDQA_KTPL] h" +
                                                 " left join [dbo].[MDQA_KTPL_Detail] d" +
                                                 " on h.ID=d.ID" +
                                                 " where Ngay between @StartDate and @EndDate and  [Customer]='SEAGATE'  " +
                                                 " group by  d.[DefectCode]" +
                                                 " order by qty desc  "), para)
        Else
            If loaiHang = "HANG-THUONG" Then
                dtQty1 = _db.FillDataTable(String.Format(" SELECT  d.[DefectCode], sum(d.[DefectQty]) as qty " +
                                                       " FROM  [MDQA_KTPL] h" +
                                                       " left join [dbo].[MDQA_KTPL_Detail] d" +
                                                       " on h.ID=d.ID" +
                                                       " where Ngay between @StartDate and @EndDate " +
                                                       " and  [Customer]='SEAGATE' and (h.LoaiHang='{0}' or  h.LoaiHang='TACH-LO')" +
                                                       " group by  d.[DefectCode]" +
                                                       " order by qty desc  ", loaiHang), para)
            Else
                dtQty1 = _db.FillDataTable(String.Format(" SELECT  d.[DefectCode], sum(d.[DefectQty]) as qty " +
                                                     " FROM  [MDQA_KTPL] h" +
                                                     " left join [dbo].[MDQA_KTPL_Detail] d" +
                                                     " on h.ID=d.ID" +
                                                     " where Ngay between @StartDate and @EndDate and  [Customer]='SEAGATE' and h.LoaiHang='{0}' " +
                                                     " group by  d.[DefectCode]" +
                                                     " order by qty desc  ", loaiHang), para)
            End If
        End If

        gridD.Columns.Add(startDate.ToString("ddMMyy"), dtpStart.Value.ToString("dd/MM") & "-" & dtpEnd.Value.ToString("dd/MM"))
        gridD.Columns(startDate.ToString("ddMMyy")).DefaultCellStyle.Format = "N0"
        gridD.Columns(startDate.ToString("ddMMyy")).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        For Each r As DataRow In dtCode.Rows
            gridD.Rows.Add(1)
            gridD.Rows(gridD.RowCount - 1).Cells("Defect").Value = r("DefectNameE")

            gridD.Rows(gridD.RowCount - 1).Cells(1).Value = dtQty1.Compute("sum(qty)", String.Format("DefectCode='{0}'", r("DefectCode")))
            If gridD.Rows(gridD.RowCount - 1).Cells(1).Value IsNot DBNull.Value Then
                sum1 += gridD.Rows(gridD.RowCount - 1).Cells(1).Value
            End If
        Next

        gridD.Rows.Add(1)
        gridD.Rows(gridD.RowCount - 1).Cells("Defect").Value = "Total:"
        gridD.Rows(gridD.RowCount - 1).Cells(1).Value = sum1
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        Dim lst As New List(Of DataGridView)
        lst.Add(gridM)
        lst.Add(gridD)
        ExportEXCEL(lst)
    End Sub
End Class