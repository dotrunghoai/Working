
Imports CommonDB
Imports LibEntity
Imports PublicUtility
Imports System.Windows.Forms

Public Class FrmBaoCaoTuan : Inherits DevExpress.XtraEditors.XtraForm
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim startDate As DateTime = GetStartDate(dtpStart.Value)
        Dim endDate As DateTime = GetStartDate(dtpEnd.Value)
        Dim sumS As Double = 0
        Dim sumSK As Double = 0
        Dim sumT As Double = 0
        Dim sumH As Double = 0
        Dim sumW As Double = 0
        Dim sumWC As Double = 0
        Dim sumC As Double = 0
        Dim tb_Head As String = "MDQA_KTPL"
        Dim tb_Detail As String = "MDQA_KTPL_Detail"
        If rdoKT1.Checked Then
            tb_Head = "MDQA_KT1"
            tb_Detail = "MDQA_KT1_Detail"
        End If

        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", startDate)
        para(1) = New SqlClient.SqlParameter("@EndDate", endDate)
        para(2) = New SqlClient.SqlParameter("@LoaiHang", "")
        gridL.RowCount = 0
        gridM.RowCount = 0
        gridM.RowCount = 8

        gridM.Rows(0).Cells("Monthly").Value = "Lot Inspected  (lot)"
        gridM.Rows(1).Cells("Monthly").Value = "Lot Accepted (lot)"
        gridM.Rows(2).Cells("Monthly").Value = "%LAR"
        gridM.Rows(3).Cells("Monthly").Value = "In put Qty (pcs)"
        gridM.Rows(4).Cells("Monthly").Value = "Sampling Qty  (pcs)"
        gridM.Rows(5).Cells("Monthly").Value = "Defects Qty (pcs)"
        gridM.Rows(6).Cells("Monthly").Value = "DPPM"
        gridM.Rows(7).Cells("Monthly").Value = "TotalTime"

        Dim sqlM As String = String.Format("sp_MDQA_BaoCaoTuan")
        If rdoKT1.Checked Then
            sqlM = String.Format("sp_MDQA_BaoCaoTuan_KT1")
        End If
        If rdoKiemLai.Checked Then
            para(2) = New SqlClient.SqlParameter("@LoaiHang", "KIEM-LAI")
        ElseIf rdoThuNghiem.Checked Then
            para(2) = New SqlClient.SqlParameter("@LoaiHang", "THU-NGHIEM")
        ElseIf rdoHangThuong.Checked Then
            para(2) = New SqlClient.SqlParameter("@LoaiHang", "HANG-THUONG")
        End If
     

        Dim dtM As DataTable = _db.ExecuteStoreProcedureTB(sqlM, para)

        gridM.Rows(0).Cells("SG").Value = dtM.Compute("sum(LotCount)", "Customer = 'SEAGATE' ")
        gridM.Rows(1).Cells("SG").Value = dtM.Compute("sum(LotCountOK)", "Customer = 'SEAGATE'  ")
        If gridM.Rows(0).Cells("SG").Value IsNot DBNull.Value And gridM.Rows(1).Cells("SG").Value IsNot DBNull.Value Then
            gridM.Rows(2).Cells("SG").Value = CType(gridM.Rows(1).Cells("SG").Value * 100.0 / gridM.Rows(0).Cells("SG").Value, Decimal).ToString("N2")
        Else
            gridM.Rows(2).Cells("SG").Value = DBNull.Value
        End If
        If IsNumeric(gridM.Rows(0).Cells("SG").Value) Then
            gridM.Rows(3).Cells("SG").Value = CType(dtM.Compute("sum(LotQty)", "Customer = 'SEAGATE'"), Decimal).ToString("N0")
            gridM.Rows(4).Cells("SG").Value = CType(dtM.Compute("sum(AQL)", "Customer = 'SEAGATE'"), Decimal).ToString("N0")
            gridM.Rows(5).Cells("SG").Value = CType(dtM.Compute("sum(DefectQty)", "Customer = 'SEAGATE'"), Decimal).ToString("N0")
            If gridM.Rows(4).Cells("SG").Value IsNot DBNull.Value And gridM.Rows(5).Cells("SG").Value IsNot DBNull.Value Then
                gridM.Rows(6).Cells("SG").Value = CType(gridM.Rows(5).Cells("SG").Value / gridM.Rows(4).Cells("SG").Value * 1000000, Decimal).ToString("N0")
            End If
            gridM.Rows(7).Cells("SG").Value = CType(dtM.Compute("sum(TotalTime)", "Customer = 'SEAGATE'"), Decimal).ToString("N0")
        End If

        gridM.Rows(0).Cells("SGK").Value = dtM.Compute("sum(LotCount)", "Customer = 'SEAGATE(KDC)'  ")
        If IsNumeric(dtM.Compute("sum(LotCountOK)", "Customer = 'SEAGATE(KDC)' ")) Then
            gridM.Rows(1).Cells("SGK").Value = CType(dtM.Compute("sum(LotCountOK)", "Customer = 'SEAGATE(KDC)' "), Decimal).ToString("N0")
        End If
        If gridM.Rows(0).Cells("SGK").Value IsNot DBNull.Value And gridM.Rows(1).Cells("SGK").Value IsNot DBNull.Value Then
            gridM.Rows(2).Cells("SGK").Value = CType(gridM.Rows(1).Cells("SGK").Value * 100.0 / gridM.Rows(0).Cells("SGK").Value, Decimal).ToString("N2")
        Else
            gridM.Rows(2).Cells("SGK").Value = DBNull.Value
        End If
        If IsNumeric(gridM.Rows(0).Cells("SGK").Value) Then
            gridM.Rows(3).Cells("SGK").Value = CType(dtM.Compute("sum(LotQty)", "Customer = 'SEAGATE(KDC)'"), Decimal).ToString("N0")
            gridM.Rows(4).Cells("SGK").Value = CType(dtM.Compute("sum(AQL)", "Customer = 'SEAGATE(KDC)'"), Decimal).ToString("N0")
            gridM.Rows(5).Cells("SGK").Value = CType(dtM.Compute("sum(DefectQty)", "Customer = 'SEAGATE(KDC)'"), Decimal).ToString("N0")
            If gridM.Rows(4).Cells("SGK").Value IsNot DBNull.Value And gridM.Rows(5).Cells("SGK").Value IsNot DBNull.Value Then
                gridM.Rows(6).Cells("SGK").Value = CType(gridM.Rows(5).Cells("SGK").Value / gridM.Rows(4).Cells("SGK").Value * 1000000, Decimal).ToString("N0")
            End If
            gridM.Rows(7).Cells("SGK").Value = CType(dtM.Compute("sum(TotalTime)", "Customer = 'SEAGATE(KDC)'"), Decimal).ToString("N0")
        End If

        gridM.Rows(0).Cells("TSB").Value = dtM.Compute("sum(LotCount)", "Customer ='TOSHIBA' ")
        If IsNumeric(dtM.Compute("sum(LotCountOK)", "Customer ='TOSHIBA'")) Then
            gridM.Rows(1).Cells("TSB").Value = CType(dtM.Compute("sum(LotCountOK)", "Customer ='TOSHIBA'"), Decimal).ToString("N0")
        End If
        If gridM.Rows(0).Cells("TSB").Value IsNot DBNull.Value And gridM.Rows(1).Cells("TSB").Value IsNot DBNull.Value Then
            gridM.Rows(2).Cells("TSB").Value = CType(gridM.Rows(1).Cells("TSB").Value * 100.0 / gridM.Rows(0).Cells("TSB").Value, Decimal).ToString("N2")
        Else
            gridM.Rows(2).Cells("TSB").Value = DBNull.Value
        End If
        If IsNumeric(gridM.Rows(0).Cells("TSB").Value) Then
            gridM.Rows(3).Cells("TSB").Value = CType(dtM.Compute("sum(LotQty)", "Customer ='TOSHIBA'"), Decimal).ToString("N0")
            gridM.Rows(4).Cells("TSB").Value = CType(dtM.Compute("sum(AQL)", "Customer ='TOSHIBA'"), Decimal).ToString("N0")
            gridM.Rows(5).Cells("TSB").Value = CType(dtM.Compute("sum(DefectQty)", "Customer ='TOSHIBA'"), Decimal).ToString("N0")
            If gridM.Rows(4).Cells("TSB").Value IsNot DBNull.Value And gridM.Rows(5).Cells("TSB").Value IsNot DBNull.Value Then
                gridM.Rows(6).Cells("TSB").Value = CType(gridM.Rows(5).Cells("TSB").Value / gridM.Rows(4).Cells("TSB").Value * 1000000, Decimal).ToString("N0")
            End If
            gridM.Rows(7).Cells("TSB").Value = CType(dtM.Compute("sum(TotalTime)", "Customer = 'TOSHIBA'"), Decimal).ToString("N0")
        End If

        gridM.Rows(0).Cells("HGST").Value = dtM.Compute("sum(LotCount)", "Customer ='HGST'  ")
        If IsNumeric(dtM.Compute("sum(LotCountOK)", "Customer ='HGST'  ")) Then
            gridM.Rows(1).Cells("HGST").Value = CType(dtM.Compute("sum(LotCountOK)", "Customer ='HGST'  "), Decimal).ToString("N0")
        End If
        If gridM.Rows(0).Cells("HGST").Value IsNot DBNull.Value And gridM.Rows(1).Cells("HGST").Value IsNot DBNull.Value Then
            gridM.Rows(2).Cells("HGST").Value = CType(gridM.Rows(1).Cells("HGST").Value * 100.0 / gridM.Rows(0).Cells("HGST").Value, Decimal).ToString("N2")
        Else
            gridM.Rows(2).Cells("HGST").Value = DBNull.Value
        End If
        If IsNumeric(gridM.Rows(0).Cells("HGST").Value) Then
            gridM.Rows(3).Cells("HGST").Value = CType(dtM.Compute("sum(LotQty)", "Customer ='HGST'"), Decimal).ToString("N0")
            gridM.Rows(4).Cells("HGST").Value = CType(dtM.Compute("sum(AQL)", "Customer ='HGST'"), Decimal).ToString("N0")
            gridM.Rows(5).Cells("HGST").Value = CType(dtM.Compute("sum(DefectQty)", "Customer ='HGST'"), Decimal).ToString("N0")
            If gridM.Rows(4).Cells("HGST").Value IsNot DBNull.Value And gridM.Rows(5).Cells("HGST").Value IsNot DBNull.Value Then
                gridM.Rows(6).Cells("HGST").Value = CType(gridM.Rows(5).Cells("HGST").Value / gridM.Rows(4).Cells("HGST").Value * 1000000, Decimal).ToString("N0")
            End If
            gridM.Rows(7).Cells("HGST").Value = CType(dtM.Compute("sum(TotalTime)", "Customer = 'HGST'"), Decimal).ToString("N0")
        End If

        gridM.Rows(0).Cells("WD").Value = dtM.Compute("sum(LotCount)", "Customer = 'WESTERN DIGITAL' ")
        gridM.Rows(1).Cells("WD").Value = dtM.Compute("sum(LotCountOK)", "Customer = 'WESTERN DIGITAL' ")
        If gridM.Rows(0).Cells("WD").Value IsNot DBNull.Value And gridM.Rows(1).Cells("WD").Value IsNot DBNull.Value Then
            gridM.Rows(2).Cells("WD").Value = CType(gridM.Rows(1).Cells("WD").Value * 100.0 / gridM.Rows(0).Cells("WD").Value, Decimal).ToString("N2")
        Else
            gridM.Rows(2).Cells("WD").Value = DBNull.Value
        End If
        If IsNumeric(gridM.Rows(0).Cells("WD").Value) Then
            gridM.Rows(3).Cells("WD").Value = dtM.Compute("sum(LotQty)", "Customer = 'WESTERN DIGITAL'")
            gridM.Rows(4).Cells("WD").Value = dtM.Compute("sum(AQL)", "Customer = 'WESTERN DIGITAL'")
            gridM.Rows(5).Cells("WD").Value = CType(dtM.Compute("sum(DefectQty)", "Customer = 'WESTERN DIGITAL'"), Decimal).ToString("N0")
            If gridM.Rows(4).Cells("WD").Value IsNot DBNull.Value And gridM.Rows(5).Cells("WD").Value IsNot DBNull.Value Then
                gridM.Rows(6).Cells("WD").Value = CType(gridM.Rows(5).Cells("WD").Value / gridM.Rows(4).Cells("WD").Value * 1000000, Decimal).ToString("N0")
            End If
            gridM.Rows(7).Cells("WD").Value = CType(dtM.Compute("sum(TotalTime)", "Customer = 'WESTERN DIGITAL'"), Decimal).ToString("N0")
        End If

        gridM.Rows(0).Cells("WDC").Value = dtM.Compute("sum(LotCount)", "Customer = 'WDC' ")
        gridM.Rows(1).Cells("WDC").Value = dtM.Compute("sum(LotCountOK)", "Customer = 'WDC' ")
        If gridM.Rows(0).Cells("WDC").Value IsNot DBNull.Value And gridM.Rows(1).Cells("WDC").Value IsNot DBNull.Value Then
            gridM.Rows(2).Cells("WDC").Value = CType(gridM.Rows(1).Cells("WDC").Value * 100.0 / gridM.Rows(0).Cells("WDC").Value, Decimal).ToString("N2")
        Else
            gridM.Rows(2).Cells("WDC").Value = DBNull.Value
        End If
        If IsNumeric(gridM.Rows(0).Cells("WDC").Value) Then
            gridM.Rows(3).Cells("WDC").Value = dtM.Compute("sum(LotQty)", "Customer = 'WDC'")
            gridM.Rows(4).Cells("WDC").Value = dtM.Compute("sum(AQL)", "Customer = 'WDC'")
            gridM.Rows(5).Cells("WDC").Value = CType(dtM.Compute("sum(DefectQty)", "Customer = 'WDC'"), Decimal).ToString("N0")
            If gridM.Rows(4).Cells("WDC").Value IsNot DBNull.Value And gridM.Rows(5).Cells("WD").Value IsNot DBNull.Value Then
                gridM.Rows(6).Cells("WDC").Value = CType(gridM.Rows(5).Cells("WDC").Value / gridM.Rows(4).Cells("WDC").Value * 1000000, Decimal).ToString("N0")
            End If
            gridM.Rows(7).Cells("WDC").Value = CType(dtM.Compute("sum(TotalTime)", "Customer = 'WDC'"), Decimal).ToString("N0")
        End If

        gridM.Rows(0).Cells("OT").Value = dtM.Compute("sum(LotCount)", "Customer = 'CANON' ")
        gridM.Rows(1).Cells("OT").Value = dtM.Compute("sum(LotCountOK)", "Customer = 'CANON'  ")
        If gridM.Rows(0).Cells("OT").Value IsNot DBNull.Value And gridM.Rows(1).Cells("WD").Value IsNot DBNull.Value Then
            gridM.Rows(2).Cells("OT").Value = CType(gridM.Rows(1).Cells("OT").Value * 100.0 / gridM.Rows(0).Cells("OT").Value, Decimal).ToString("N2")
        Else
            gridM.Rows(2).Cells("OT").Value = DBNull.Value
        End If
        If IsNumeric(gridM.Rows(0).Cells("OT").Value) Then
            gridM.Rows(3).Cells("OT").Value = CType(dtM.Compute("sum(LotQty)", "Customer = 'CANON'"), Decimal).ToString("N0")
            gridM.Rows(4).Cells("OT").Value = CType(dtM.Compute("sum(AQL)", "Customer = 'CANON'"), Decimal).ToString("N0")
            gridM.Rows(5).Cells("OT").Value = CType(dtM.Compute("sum(DefectQty)", "Customer = 'CANON'"), Decimal).ToString("N0")
            If gridM.Rows(4).Cells("OT").Value IsNot DBNull.Value And gridM.Rows(5).Cells("OT").Value IsNot DBNull.Value Then
                gridM.Rows(6).Cells("OT").Value = CType(gridM.Rows(5).Cells("OT").Value / gridM.Rows(4).Cells("OT").Value * 1000000, Decimal).ToString("N2")
            End If
            gridM.Rows(7).Cells("OT").Value = CType(dtM.Compute("sum(TotalTime)", "Customer = 'CANON'"), Decimal).ToString("N0")
        End If

        startDate = GetStartDate(dtpStart.Value)
        endDate = GetStartDate(dtpEnd.Value)
        para(0) = New SqlClient.SqlParameter("@StartDate", startDate)
        para(1) = New SqlClient.SqlParameter("@EndDate", endDate)

        Dim dtCode As DataTable = _db.FillDataTable(String.Format(" SELECT  d.[DefectCode],c.DefectNameV, sum(d.[DefectQty]) as qty " +
                                                     " FROM  [{0}] h" +
                                                     " left join [dbo].[{1}] d" +
                                                     " on h.ID=d.ID" +
                                                     " inner join [dbo].[MDQA_DefectCode] c" +
                                                     " on c.DefectCode=d.DefectCode" +
                                                     " where Ngay between @StartDate and @EndDate and (LoaiHang='HANG-THUONG' or LoaiHang='TACH-LO') " +
                                                     " group by  d.[DefectCode],c.DefectNameV" +
                                                     " order by qty desc  ", tb_Head, tb_Detail), para)

        Dim dtQty As DataTable = _db.FillDataTable(String.Format(" SELECT  d.[DefectCode],h.Customer, sum(d.[DefectQty]) as qty,sum(d.SL) as AQL " +
                                                   " FROM  [{0}] h" +
                                                   " left join [dbo].[{1}] d" +
                                                   " on h.ID=d.ID" +
                                                   " where Ngay between @StartDate and @EndDate and (LoaiHang='HANG-THUONG' or LoaiHang='TACH-LO') " +
                                                   " group by  d.[DefectCode],h.Customer" +
                                                   " order by qty desc  ", tb_Head, tb_Detail), para)
        If rdoKiemLai.Checked Then
            dtCode = _db.FillDataTable(String.Format(" SELECT  d.[DefectCode],c.DefectNameV, sum(d.[DefectQty]) as qty " +
                                                     " FROM  [{0}] h" +
                                                     " left join [dbo].[{1}] d" +
                                                     " on h.ID=d.ID" +
                                                     " inner join [dbo].[MDQA_DefectCode] c" +
                                                     " on c.DefectCode=d.DefectCode" +
                                                     " where Ngay between @StartDate and @EndDate and LoaiHang='KIEM-LAI' " +
                                                     " group by  d.[DefectCode],c.DefectNameV" +
                                                     " order by qty desc  ", tb_Head, tb_Detail), para)
            dtQty = _db.FillDataTable(String.Format(" SELECT  d.[DefectCode],h.Customer, sum(d.[DefectQty]) as qty,sum(d.SL) as AQL " +
                                                   " FROM  [{0}] h" +
                                                   " left join [dbo].[{1}] d" +
                                                   " on h.ID=d.ID" +
                                                   " where Ngay between @StartDate and @EndDate and LoaiHang='KIEM-LAI' " +
                                                   " group by  d.[DefectCode],h.Customer" +
                                                   " order by qty desc  ", tb_Head, tb_Detail), para)
        ElseIf rdoAll.Checked Then
            dtCode = _db.FillDataTable(String.Format(" SELECT  d.[DefectCode],c.DefectNameV, sum(d.[DefectQty]) as qty " +
                                                     " FROM  [{0}] h" +
                                                     " left join [dbo].[{1}] d" +
                                                     " on h.ID=d.ID" +
                                                     " inner join [dbo].[MDQA_DefectCode] c" +
                                                     " on c.DefectCode=d.DefectCode" +
                                                     " where Ngay between @StartDate and @EndDate   " +
                                                     " group by  d.[DefectCode],c.DefectNameV" +
                                                     " order by qty desc  ", tb_Head, tb_Detail), para)
            dtQty = _db.FillDataTable(String.Format(" SELECT  d.[DefectCode],h.Customer, sum(d.[DefectQty]) as qty,sum(d.SL) as AQL " +
                                                   " FROM  [{0}] h" +
                                                   " left join [dbo].[{1}] d" +
                                                   " on h.ID=d.ID" +
                                                   " where Ngay between @StartDate and @EndDate   " +
                                                   " group by  d.[DefectCode],h.Customer" +
                                                   " order by qty desc  ", tb_Head, tb_Detail), para)
        ElseIf rdoThuNghiem.Checked Then
            dtCode = _db.FillDataTable(String.Format(" SELECT  d.[DefectCode],c.DefectNameV, sum(d.[DefectQty]) as qty " +
                                                    " FROM  [{0}] h" +
                                                    " left join [dbo].[{1}] d" +
                                                    " on h.ID=d.ID" +
                                                    " inner join [dbo].[MDQA_DefectCode] c" +
                                                    " on c.DefectCode=d.DefectCode" +
                                                    " where Ngay between @StartDate and @EndDate and ProductCode like '7%' " +
                                                    " group by  d.[DefectCode],c.DefectNameV" +
                                                    " order by qty desc  ", tb_Head, tb_Detail), para)
            dtQty = _db.FillDataTable(String.Format(" SELECT  d.[DefectCode],h.Customer, sum(d.[DefectQty]) as qty,sum(d.SL) as AQL " +
                                                   " FROM  [{0}] h" +
                                                   " left join [dbo].[{1}] d" +
                                                   " on h.ID=d.ID" +
                                                   " where Ngay between @StartDate and @EndDate and ProductCode like '7%'  " +
                                                   " group by  d.[DefectCode],h.Customer" +
                                                   " order by qty desc  ", tb_Head, tb_Detail), para)

        End If



        For Each r As DataRow In dtCode.Rows
            gridL.Rows.Add(1)
            gridL.Rows(gridL.RowCount - 1).Cells("MaLoi").Value = r("DefectCode")
            gridL.Rows(gridL.RowCount - 1).Cells("TenLoi").Value = r("DefectNameV")

            gridL.Rows(gridL.RowCount - 1).Cells("SGL").Value = dtQty.Compute("sum(qty)", String.Format("Customer = 'SEAGATE' and DefectCode='{0}'", r("DefectCode")))
            gridL.Rows(gridL.RowCount - 1).Cells("SGKL").Value = dtQty.Compute("sum(qty)", String.Format("Customer = 'SEAGATE(KDC)' and DefectCode='{0}'", r("DefectCode")))
            gridL.Rows(gridL.RowCount - 1).Cells("TSBL").Value = dtQty.Compute("sum(qty)", String.Format("Customer = 'TOSHIBA' and DefectCode='{0}'", r("DefectCode")))
            gridL.Rows(gridL.RowCount - 1).Cells("HGSTL").Value = dtQty.Compute("sum(qty)", String.Format("Customer = 'HGST' and DefectCode='{0}'", r("DefectCode")))
            gridL.Rows(gridL.RowCount - 1).Cells("WDL").Value = dtQty.Compute("sum(qty)", String.Format("Customer = 'WESTERN DIGITAL' and DefectCode='{0}'", r("DefectCode")))
            gridL.Rows(gridL.RowCount - 1).Cells("WDCL").Value = dtQty.Compute("sum(qty)", String.Format("Customer = 'WDC' and DefectCode='{0}'", r("DefectCode")))
            gridL.Rows(gridL.RowCount - 1).Cells("OTL").Value = dtQty.Compute("sum(qty)", String.Format("Customer = 'CANON' and DefectCode='{0}'", r("DefectCode")))
            If gridL.Rows(gridL.RowCount - 1).Cells("SGL").Value IsNot DBNull.Value And
                gridM.Rows(4).Cells("SG").Value IsNot DBNull.Value Then
                gridL.Rows(gridL.RowCount - 1).Cells("SGP").Value = gridL.Rows(gridL.RowCount - 1).Cells("SGL").Value / gridM.Rows(4).Cells("SG").Value * 1000
            End If
            If gridL.Rows(gridL.RowCount - 1).Cells("SGKL").Value IsNot DBNull.Value And
                gridM.Rows(4).Cells("SGK").Value IsNot DBNull.Value Then
                gridL.Rows(gridL.RowCount - 1).Cells("SGKP").Value = gridL.Rows(gridL.RowCount - 1).Cells("SGKL").Value / gridM.Rows(4).Cells("SGK").Value * 1000
            End If
            If gridL.Rows(gridL.RowCount - 1).Cells("TSBL").Value IsNot DBNull.Value And
                gridM.Rows(4).Cells("TSB").Value IsNot DBNull.Value Then
                gridL.Rows(gridL.RowCount - 1).Cells("TSBP").Value = gridL.Rows(gridL.RowCount - 1).Cells("TSBL").Value / gridM.Rows(4).Cells("TSB").Value * 1000
            End If
            If gridL.Rows(gridL.RowCount - 1).Cells("HGSTL").Value IsNot DBNull.Value And
                gridM.Rows(4).Cells("HGST").Value IsNot DBNull.Value Then
                gridL.Rows(gridL.RowCount - 1).Cells("HGSTP").Value = gridL.Rows(gridL.RowCount - 1).Cells("HGSTL").Value / gridM.Rows(4).Cells("HGST").Value * 1000
            End If
            If gridL.Rows(gridL.RowCount - 1).Cells(6).Value IsNot DBNull.Value And
                gridM.Rows(4).Cells("WD").Value IsNot DBNull.Value Then
                gridL.Rows(gridL.RowCount - 1).Cells("WDP").Value = gridL.Rows(gridL.RowCount - 1).Cells("WDL").Value / gridM.Rows(4).Cells("WD").Value * 1000
            End If
            If gridL.Rows(gridL.RowCount - 1).Cells("WDCL").Value IsNot DBNull.Value And
                gridM.Rows(4).Cells("WDC").Value IsNot DBNull.Value Then
                gridL.Rows(gridL.RowCount - 1).Cells("WDCP").Value = gridL.Rows(gridL.RowCount - 1).Cells("WDCL").Value / gridM.Rows(4).Cells("WDC").Value * 1000
            End If
            If gridL.Rows(gridL.RowCount - 1).Cells("OTL").Value IsNot DBNull.Value And
                gridM.Rows(4).Cells("OT").Value IsNot DBNull.Value Then
                gridL.Rows(gridL.RowCount - 1).Cells("OTP").Value = gridL.Rows(gridL.RowCount - 1).Cells("OTL").Value / gridM.Rows(4).Cells("OT").Value * 1000
            End If
            If IsNumeric(gridL.Rows(gridL.RowCount - 1).Cells("SGL").Value) Then
                sumS += gridL.Rows(gridL.RowCount - 1).Cells("SGL").Value
            End If
            If IsNumeric(gridL.Rows(gridL.RowCount - 1).Cells("SGKL").Value) Then
                sumSK += gridL.Rows(gridL.RowCount - 1).Cells("SGKL").Value
            End If
            If IsNumeric(gridL.Rows(gridL.RowCount - 1).Cells("TSBL").Value) Then
                sumT += gridL.Rows(gridL.RowCount - 1).Cells("TSBL").Value
            End If
            If IsNumeric(gridL.Rows(gridL.RowCount - 1).Cells("HGSTL").Value) Then
                sumH += gridL.Rows(gridL.RowCount - 1).Cells("HGSTL").Value
            End If
            If IsNumeric(gridL.Rows(gridL.RowCount - 1).Cells("WDL").Value) Then
                sumW += gridL.Rows(gridL.RowCount - 1).Cells("WDL").Value
            End If
            If IsNumeric(gridL.Rows(gridL.RowCount - 1).Cells("WDCL").Value) Then
                sumWC += gridL.Rows(gridL.RowCount - 1).Cells("WDCL").Value
            End If
            If IsNumeric(gridL.Rows(gridL.RowCount - 1).Cells("OTL").Value) Then
                sumC += gridL.Rows(gridL.RowCount - 1).Cells("OTL").Value
            End If
        Next

        gridL.Rows.Add(1)
        gridL.Rows(gridL.RowCount - 1).Cells("TenLoi").Value = "Defects Qty (pcs)"
        gridL.Rows(gridL.RowCount - 1).Cells("SGP").Value = dtQty.Compute("sum(qty)", String.Format("Customer = 'SEAGATE' "))
        gridL.Rows(gridL.RowCount - 1).Cells("SGKP").Value = dtQty.Compute("sum(qty)", String.Format("Customer = 'SEAGATE(KDC)' "))
        gridL.Rows(gridL.RowCount - 1).Cells("TSBP").Value = dtQty.Compute("sum(qty)", String.Format("Customer = 'TOSHIBA' "))
        gridL.Rows(gridL.RowCount - 1).Cells("HGSTP").Value = dtQty.Compute("sum(qty)", String.Format("Customer = 'HGST' "))
        gridL.Rows(gridL.RowCount - 1).Cells("WDP").Value = dtQty.Compute("sum(qty)", String.Format("Customer = 'WESTERN DIGITAL' "))
        gridL.Rows(gridL.RowCount - 1).Cells("WDCP").Value = dtQty.Compute("sum(qty)", String.Format("Customer = 'WDC' "))
        gridL.Rows(gridL.RowCount - 1).Cells("OTP").Value = dtQty.Compute("sum(qty)", String.Format("Customer = 'CANON' "))

        gridL.Rows(gridL.RowCount - 1).Cells(8).Value = sumS
        gridL.Rows(gridL.RowCount - 1).Cells(9).Value = sumSK
        gridL.Rows(gridL.RowCount - 1).Cells(10).Value = sumT
        gridL.Rows(gridL.RowCount - 1).Cells(11).Value = sumH
        gridL.Rows(gridL.RowCount - 1).Cells(12).Value = sumW
        gridL.Rows(gridL.RowCount - 1).Cells(13).Value = sumC

        gridL.Rows.Add(1)
        gridL.Rows(gridL.RowCount - 1).Cells("TenLoi").Value = "Sampling Qty"
        gridL.Rows(gridL.RowCount - 1).Cells("SGP").Value = dtQty.Compute("sum(AQL)", String.Format("Customer = 'SEAGATE' "))
        gridL.Rows(gridL.RowCount - 1).Cells("SGKP").Value = dtQty.Compute("sum(AQL)", String.Format("Customer = 'SEAGATE(KDC)' "))
        gridL.Rows(gridL.RowCount - 1).Cells("TSBP").Value = dtQty.Compute("sum(AQL)", String.Format("Customer = 'TOSHIBA' "))
        gridL.Rows(gridL.RowCount - 1).Cells("HGSTP").Value = dtQty.Compute("sum(AQL)", String.Format("Customer = 'HGST' "))
        gridL.Rows(gridL.RowCount - 1).Cells("WDP").Value = dtQty.Compute("sum(AQL)", String.Format("Customer = 'WESTERN DIGITAL' "))
        gridL.Rows(gridL.RowCount - 1).Cells("WDCP").Value = dtQty.Compute("sum(AQL)", String.Format("Customer = 'WDC' "))
        gridL.Rows(gridL.RowCount - 1).Cells("OTP").Value = dtQty.Compute("sum(AQL)", String.Format("Customer = 'CANON' "))
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        Dim lst As New List(Of DataGridView)
        lst.Add(gridM)
        lst.Add(gridL)
        ExportEXCEL(lst)
    End Sub

    Private Sub rdoKT1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoKT1.CheckedChanged
        rdoKiemLai.Enabled = Not rdoKT1.Checked
    End Sub
End Class