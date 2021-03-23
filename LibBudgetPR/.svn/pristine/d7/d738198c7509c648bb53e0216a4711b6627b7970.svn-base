Imports CommonDB
Imports PublicUtility
'Imports LibEntity
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports System.IO

Public Class FrmBudgetControl
    Dim myPath As String = CurrentUser.TempFolder & "PR1_Budget\"
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridView1.Columns.Clear()
        If rdoHorizontal.Checked Then
            If rdoMatCodeProcess.Checked Then
                If rdoDaily.Checked Then
                    processDailyHori()
                ElseIf rdoMonthly.Checked Then
                    processMonthlyHori()
                Else
                    processYearlyHori()
                End If
            Else
                If rdoDaily.Checked = True Then
                    dailyHori()
                ElseIf rdoMonthly.Checked Then
                    monthlyHori()
                Else
                    yearlyHori()
                End If
            End If
        Else
            vertical()
        End If
        GridControlSetFormat(GridView1, 3)
        GridView1.Columns("Picture").ColumnEdit = GridControlLinkEdit()
        GridView1.Columns("PictureLink").ColumnEdit = GridControlLinkEdit()
    End Sub

    Private Sub yearlyHori()
        Dim dtSum As New DataTable
        dtSum.Columns.Add("JCode")
        dtSum.Columns.Add("BudgetCategory")
        'dtSum.Columns.Add("PrcName")
        'dtSum.Columns.Add("SubPrcName")
        dtSum.Columns.Add("JEName")
        dtSum.Columns.Add("JVName")
        dtSum.Columns.Add("ImportItem")
        dtSum.Columns.Add("Unit")
        dtSum.Columns.Add("PackingType")
        dtSum.Columns.Add("LeadTime")
        dtSum.Columns.Add("Process")
        'dtSum.Columns.Add("BoPhan")
        dtSum.Columns.Add("UsingPurpose")
        dtSum.Columns.Add("MachineLineAssetCode")
        dtSum.Columns.Add("Picture")
        dtSum.Columns.Add("PictureLink")
        dtSum.Columns.Add("PositionUse")
        dtSum.Columns.Add("NumberPositionUse")
        dtSum.Columns.Add("Reason")
        dtSum.Columns.Add("DinhMuc")
        dtSum.Columns.Add("TonQuyDinh")
        dtSum.Columns.Add("Supplier")
        dtSum.Columns.Add("GiaTien")
        dtSum.Columns.Add("TienTe")
        dtSum.Columns.Add("PriceUSD")
        dtSum.Columns.Add("TonCuoi")

        Dim startDayOfYear = New DateTime(dteStartDate.DateTime.Year, 1, 1)
        Dim endDayOfYear = New DateTime(dteEndDate.DateTime.Year, 12, 31)
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", startDayOfYear.ToString("yyyyMMdd"))
        para(1) = New SqlClient.SqlParameter("@EndDate", endDayOfYear.ToString("yyyyMMdd"))
        para(2) = New SqlClient.SqlParameter("@Action", "YM")
        Dim dtYM As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodeByYear", para)

        If dtYM.Rows.Count > 0 Then
            For Each r As DataRow In dtYM.Rows
                dtSum.Columns.Add(r("YM"))
            Next
        End If

        para(2) = New SqlClient.SqlParameter("@Action", "Qty")
        Dim dtQty As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodeByYear", para)

        para(2) = New SqlClient.SqlParameter("@Action", "JCode")
        Dim dtJcode As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodeByYear", para)

        Dim dataRow As DataRow
        For Each drJcode As DataRow In dtJcode.Rows
            Dim rs() As DataRow = dtSum.Select(String.Format("JCode='{0}'", drJcode("JCode")))
            If rs.Length <> 0 Then
                Continue For
            End If
            dataRow = dtSum.NewRow
            For c = 0 To dtSum.Columns.Count - 1
                If dtSum.Columns(c).ColumnName = "JCode" Then
                    dataRow("JCode") = drJcode("JCode")
                End If
                If dtSum.Columns(c).ColumnName = "BudgetCategory" Then
                    dataRow("BudgetCategory") = drJcode("BudgetCategory")
                End If
                'If dtSum.Columns(c).ColumnName = "PrcName" Then
                '    dataRow("PrcName") = drJcode("PrcName")
                'End If
                'If dtSum.Columns(c).ColumnName = "SubPrcName" Then
                '    dataRow("SubPrcName") = drJcode("SubPrcName")
                'End If
                If dtSum.Columns(c).ColumnName = "JEName" Then
                    dataRow("JEName") = drJcode("JEName")
                End If
                If dtSum.Columns(c).ColumnName = "JVName" Then
                    dataRow("JVName") = drJcode("JVName")
                End If
                If dtSum.Columns(c).ColumnName = "ImportItem" Then
                    dataRow("ImportItem") = drJcode("ImportItem")
                End If
                If dtSum.Columns(c).ColumnName = "Unit" Then
                    dataRow("Unit") = drJcode("Unit")
                End If
                If dtSum.Columns(c).ColumnName = "PackingType" Then
                    dataRow("PackingType") = drJcode("PackingType")
                End If
                If dtSum.Columns(c).ColumnName = "LeadTime" Then
                    dataRow("LeadTime") = drJcode("LeadTime")
                End If
                If dtSum.Columns(c).ColumnName = "Process" Then
                    dataRow("Process") = drJcode("Process")
                End If
                'If dtSum.Columns(c).ColumnName = "BoPhan" Then
                '    dataRow("BoPhan") = drJcode("BoPhan")
                'End If
                If dtSum.Columns(c).ColumnName = "UsingPurpose" Then
                    dataRow("UsingPurpose") = drJcode("UsingPurpose")
                End If
                If dtSum.Columns(c).ColumnName = "MachineLineAssetCode" Then
                    dataRow("MachineLineAssetCode") = drJcode("MachineLineAssetCode")
                End If
                If dtSum.Columns(c).ColumnName = "Picture" Then
                    dataRow("Picture") = drJcode("Picture")
                End If
                If dtSum.Columns(c).ColumnName = "PictureLink" Then
                    dataRow("PictureLink") = drJcode("PictureLink")
                End If
                If dtSum.Columns(c).ColumnName = "PositionUse" Then
                    dataRow("PositionUse") = drJcode("PositionUse")
                End If
                If dtSum.Columns(c).ColumnName = "NumberPositionUse" Then
                    dataRow("NumberPositionUse") = drJcode("NumberPositionUse")
                End If
                If dtSum.Columns(c).ColumnName = "Reason" Then
                    dataRow("Reason") = drJcode("Reason")
                End If
                If dtSum.Columns(c).ColumnName = "DinhMuc" Then
                    dataRow("DinhMuc") = drJcode("DinhMuc")
                End If
                If dtSum.Columns(c).ColumnName = "TonQuyDinh" Then
                    dataRow("TonQuyDinh") = drJcode("TonQuyDinh")
                End If
                If dtSum.Columns(c).ColumnName = "Supplier" Then
                    dataRow("Supplier") = drJcode("Supplier")
                End If
                If dtSum.Columns(c).ColumnName = "GiaTien" Then
                    dataRow("GiaTien") = drJcode("GiaTien")
                End If
                If dtSum.Columns(c).ColumnName = "TienTe" Then
                    dataRow("TienTe") = drJcode("TienTe")
                End If
                If dtSum.Columns(c).ColumnName = "PriceUSD" Then
                    dataRow("PriceUSD") = drJcode("PriceUSD")
                End If
                If dtSum.Columns(c).ColumnName = "TonCuoi" Then
                    dataRow("TonCuoi") = drJcode("TonCuoi")
                End If
                For Each drQty As DataRow In dtQty.Rows
                    If dtSum.Columns(c).ColumnName = drQty("YM") And drJcode("JCode") = drQty("JCode") Then
                        dataRow(dtSum.Columns(c).ColumnName) = drQty("NDVQty")
                        Exit For
                    End If
                Next
            Next
            dtSum.Rows.Add(dataRow)
        Next
        GridControl1.DataSource = dtSum
    End Sub

    Private Sub processYearlyHori()
        Dim dtSum As New DataTable
        dtSum.Columns.Add("JCode")
        dtSum.Columns.Add("BudgetCategory")
        'dtSum.Columns.Add("PrcName")
        'dtSum.Columns.Add("SubPrcName")
        dtSum.Columns.Add("JEName")
        dtSum.Columns.Add("JVName")
        dtSum.Columns.Add("ImportItem")
        dtSum.Columns.Add("Unit")
        dtSum.Columns.Add("PackingType")
        dtSum.Columns.Add("LeadTime")
        dtSum.Columns.Add("Process")
        'dtSum.Columns.Add("BoPhan")
        dtSum.Columns.Add("UsingPurpose")
        dtSum.Columns.Add("MachineLineAssetCode")
        dtSum.Columns.Add("Picture")
        dtSum.Columns.Add("PictureLink")
        dtSum.Columns.Add("PositionUse")
        dtSum.Columns.Add("NumberPositionUse")
        dtSum.Columns.Add("Reason")
        dtSum.Columns.Add("DinhMuc")
        dtSum.Columns.Add("TonQuyDinh")
        dtSum.Columns.Add("Supplier")
        dtSum.Columns.Add("GiaTien")
        dtSum.Columns.Add("TienTe")
        dtSum.Columns.Add("PriceUSD")
        dtSum.Columns.Add("DeptName")
        dtSum.Columns.Add("DeptGSR")
        dtSum.Columns.Add("TonCuoi")

        Dim startDayOfYear = New DateTime(dteStartDate.DateTime.Year, 1, 1)
        Dim endDayOfYear = New DateTime(dteEndDate.DateTime.Year, 12, 31)
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", startDayOfYear.ToString("yyyyMMdd"))
        para(1) = New SqlClient.SqlParameter("@EndDate", endDayOfYear.ToString("yyyyMMdd"))
        para(2) = New SqlClient.SqlParameter("@Action", "YM")
        Dim dtYM As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodePrcByYear", para)

        If dtYM.Rows.Count > 0 Then
            For Each r As DataRow In dtYM.Rows
                dtSum.Columns.Add(r("YM"))
            Next
        End If

        para(2) = New SqlClient.SqlParameter("@Action", "Qty")
        Dim dtQty As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodePrcByYear", para)

        para(2) = New SqlClient.SqlParameter("@Action", "JCode")
        Dim dtJCode As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodePrcByYear", para)

        Dim dataRow As DataRow
        For Each drJcode As DataRow In dtJCode.Rows
            Dim rs() As DataRow = dtSum.Select(String.Format("JCode='{0}'", drJcode("JCode")))
            If rs.Length > 0 Then
                Continue For
            End If

            dataRow = dtSum.NewRow
            For c = 0 To dtSum.Columns.Count - 1
                If dtSum.Columns(c).ColumnName = "JCode" Then
                    dataRow("JCode") = drJcode("JCode")
                End If
                If dtSum.Columns(c).ColumnName = "BudgetCategory" Then
                    dataRow("BudgetCategory") = drJcode("BudgetCategory")
                End If
                'If dtSum.Columns(c).ColumnName = "PrcName" Then
                '    dataRow("PrcName") = drJcode("PrcName")
                'End If
                'If dtSum.Columns(c).ColumnName = "SubPrcName" Then
                '    dataRow("SubPrcName") = drJcode("SubPrcName")
                'End If
                If dtSum.Columns(c).ColumnName = "JEName" Then
                    dataRow("JEName") = drJcode("JEName")
                End If
                If dtSum.Columns(c).ColumnName = "JVName" Then
                    dataRow("JVName") = drJcode("JVName")
                End If
                If dtSum.Columns(c).ColumnName = "ImportItem" Then
                    dataRow("ImportItem") = drJcode("ImportItem")
                End If
                If dtSum.Columns(c).ColumnName = "Unit" Then
                    dataRow("Unit") = drJcode("Unit")
                End If
                If dtSum.Columns(c).ColumnName = "PackingType" Then
                    dataRow("PackingType") = drJcode("PackingType")
                End If
                If dtSum.Columns(c).ColumnName = "LeadTime" Then
                    dataRow("LeadTime") = drJcode("LeadTime")
                End If
                If dtSum.Columns(c).ColumnName = "Process" Then
                    dataRow("Process") = drJcode("Process")
                End If
                'If dtSum.Columns(c).ColumnName = "BoPhan" Then
                '    dataRow("BoPhan") = drJcode("BoPhan")
                'End If
                If dtSum.Columns(c).ColumnName = "UsingPurpose" Then
                    dataRow("UsingPurpose") = drJcode("UsingPurpose")
                End If
                If dtSum.Columns(c).ColumnName = "MachineLineAssetCode" Then
                    dataRow("MachineLineAssetCode") = drJcode("MachineLineAssetCode")
                End If
                If dtSum.Columns(c).ColumnName = "Picture" Then
                    dataRow("Picture") = drJcode("Picture")
                End If
                If dtSum.Columns(c).ColumnName = "PictureLink" Then
                    dataRow("PictureLink") = drJcode("PictureLink")
                End If
                If dtSum.Columns(c).ColumnName = "PositionUse" Then
                    dataRow("PositionUse") = drJcode("PositionUse")
                End If
                If dtSum.Columns(c).ColumnName = "NumberPositionUse" Then
                    dataRow("NumberPositionUse") = drJcode("NumberPositionUse")
                End If
                If dtSum.Columns(c).ColumnName = "Reason" Then
                    dataRow("Reason") = drJcode("Reason")
                End If
                If dtSum.Columns(c).ColumnName = "DinhMuc" Then
                    dataRow("DinhMuc") = drJcode("DinhMuc")
                End If
                If dtSum.Columns(c).ColumnName = "TonQuyDinh" Then
                    dataRow("TonQuyDinh") = drJcode("TonQuyDinh")
                End If
                If dtSum.Columns(c).ColumnName = "Supplier" Then
                    dataRow("Supplier") = drJcode("Supplier")
                End If
                If dtSum.Columns(c).ColumnName = "GiaTien" Then
                    dataRow("GiaTien") = drJcode("GiaTien")
                End If
                If dtSum.Columns(c).ColumnName = "TienTe" Then
                    dataRow("TienTe") = drJcode("TienTe")
                End If
                If dtSum.Columns(c).ColumnName = "PriceUSD" Then
                    dataRow("PriceUSD") = drJcode("PriceUSD")
                End If
                If dtSum.Columns(c).ColumnName = "DeptName" Then
                    dataRow("DeptName") = drJcode("DeptName")
                End If
                If dtSum.Columns(c).ColumnName = "DeptGSR" Then
                    dataRow("DeptGSR") = drJcode("DeptGSR")
                End If
                If dtSum.Columns(c).ColumnName = "TonCuoi" Then
                    dataRow("TonCuoi") = drJcode("TonCuoi")
                End If

                For Each drQty As DataRow In dtQty.Rows
                    If dtSum.Columns(c).ColumnName = drQty("YM") And drJcode("JCode") = drQty("JCode") Then
                        dataRow(dtSum.Columns(c).ColumnName) = drQty("NDVQty")
                        Exit For
                    End If
                Next
            Next
            dtSum.Rows.Add(dataRow)
        Next
        GridControl1.DataSource = dtSum
    End Sub

    Private Sub vertical()
        Dim param(1) As SqlClient.SqlParameter
        Dim StartDate As DateTime = New DateTime(dteStartDate.DateTime.Year, dteStartDate.DateTime.Month, dteStartDate.DateTime.Day)
        Dim EndDate As DateTime = New DateTime(dteEndDate.DateTime.Year, dteEndDate.DateTime.Month, dteEndDate.DateTime.Day)
        param(0) = New SqlClient.SqlParameter("@StartDate", StartDate.ToString("yyyyMMdd"))
        param(1) = New SqlClient.SqlParameter("@EndDate", EndDate.ToString("yyyyMMdd"))
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_PCM_VerticalSummary_PR1", param)
        'GridControlSetFormatNumber(GridView1, "ExchangeRate", 8)
        GridControlSetWidth(GridView1, "BudgetCategory", 40)
        GridControlSetWidth(GridView1, "Unit", 40)
        GridControlSetWidth(GridView1, "LeadTime", 40)
        GridControlSetWidth(GridView1, "Process", 40)
        GridControlSetWidth(GridView1, "TonQuyDinh", 40)
        GridControlSetWidth(GridView1, "TienTe", 40)
        GridControlSetWidth(GridView1, "DeptName", 40)
        GridControlSetWidth(GridView1, "Ex-warehouse Qty", 40)
        GridControlSetWidth(GridView1, "PriceUSD", 40)
        GridControlSetWidth(GridView1, "TonCuoi", 40)
        GridControlSetWidth(GridView1, "Currency", 40)
    End Sub

    Private Sub monthlyHori()
        Dim dtSum As New DataTable
        dtSum.Columns.Add("JCode")
        dtSum.Columns.Add("BudgetCategory")
        'dtSum.Columns.Add("PrcName")
        'dtSum.Columns.Add("SubPrcName")
        dtSum.Columns.Add("JEName")
        dtSum.Columns.Add("JVName")
        dtSum.Columns.Add("ImportItem")
        dtSum.Columns.Add("Unit")
        dtSum.Columns.Add("PackingType")
        dtSum.Columns.Add("LeadTime")
        dtSum.Columns.Add("Process")
        'dtSum.Columns.Add("BoPhan")
        dtSum.Columns.Add("UsingPurpose")
        dtSum.Columns.Add("MachineLineAssetCode")
        dtSum.Columns.Add("Picture")
        dtSum.Columns.Add("PictureLink")
        dtSum.Columns.Add("PositionUse")
        dtSum.Columns.Add("NumberPositionUse")
        dtSum.Columns.Add("Reason")
        dtSum.Columns.Add("DinhMuc")
        dtSum.Columns.Add("TonQuyDinh")
        dtSum.Columns.Add("Supplier")
        dtSum.Columns.Add("GiaTien")
        dtSum.Columns.Add("TienTe")
        dtSum.Columns.Add("PriceUSD")
        dtSum.Columns.Add("TonCuoi")

        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", dteStartDate.DateTime.ToString("yyyyMMdd"))
        para(1) = New SqlClient.SqlParameter("@EndDate", dteEndDate.DateTime.ToString("yyyyMMdd"))
        para(2) = New SqlClient.SqlParameter("@Action", "YM")
        Dim dtYM As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodeByMonth_PR1", para)

        If dtYM.Rows.Count > 0 Then
            For Each r As DataRow In dtYM.Rows
                dtSum.Columns.Add(r("YM"))
            Next
        End If

        para(2) = New SqlClient.SqlParameter("@Action", "Qty")
        Dim dtQty As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodeByMonth_PR1", para)

        para(2) = New SqlClient.SqlParameter("@Action", "JCode")
        Dim dtJcode As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodeByMonth_PR1", para)

        Dim dataRow As DataRow
        For Each drJcode As DataRow In dtJcode.Rows
            Dim rs() As DataRow = dtSum.Select(String.Format("JCode='{0}'", drJcode("JCode")))
            If rs.Length <> 0 Then
                Continue For
            End If
            dataRow = dtSum.NewRow
            For c = 0 To dtSum.Columns.Count - 1
                If dtSum.Columns(c).ColumnName = "JCode" Then
                    dataRow("JCode") = drJcode("JCode")
                End If
                If dtSum.Columns(c).ColumnName = "BudgetCategory" Then
                    dataRow("BudgetCategory") = drJcode("BudgetCategory")
                End If
                'If dtSum.Columns(c).ColumnName = "PrcName" Then
                '    dataRow("PrcName") = drJcode("PrcName")
                'End If
                'If dtSum.Columns(c).ColumnName = "SubPrcName" Then
                '    dataRow("SubPrcName") = drJcode("SubPrcName")
                'End If
                If dtSum.Columns(c).ColumnName = "JEName" Then
                    dataRow("JEName") = drJcode("JEName")
                End If
                If dtSum.Columns(c).ColumnName = "JVName" Then
                    dataRow("JVName") = drJcode("JVName")
                End If
                If dtSum.Columns(c).ColumnName = "ImportItem" Then
                    dataRow("ImportItem") = drJcode("ImportItem")
                End If
                If dtSum.Columns(c).ColumnName = "Unit" Then
                    dataRow("Unit") = drJcode("Unit")
                End If
                If dtSum.Columns(c).ColumnName = "PackingType" Then
                    dataRow("PackingType") = drJcode("PackingType")
                End If
                If dtSum.Columns(c).ColumnName = "LeadTime" Then
                    dataRow("LeadTime") = drJcode("LeadTime")
                End If
                If dtSum.Columns(c).ColumnName = "Process" Then
                    dataRow("Process") = drJcode("Process")
                End If
                'If dtSum.Columns(c).ColumnName = "BoPhan" Then
                '    dataRow("BoPhan") = drJcode("BoPhan")
                'End If
                If dtSum.Columns(c).ColumnName = "UsingPurpose" Then
                    dataRow("UsingPurpose") = drJcode("UsingPurpose")
                End If
                If dtSum.Columns(c).ColumnName = "MachineLineAssetCode" Then
                    dataRow("MachineLineAssetCode") = drJcode("MachineLineAssetCode")
                End If
                If dtSum.Columns(c).ColumnName = "Picture" Then
                    dataRow("Picture") = drJcode("Picture")
                End If
                If dtSum.Columns(c).ColumnName = "PictureLink" Then
                    dataRow("PictureLink") = drJcode("PictureLink")
                End If
                If dtSum.Columns(c).ColumnName = "PositionUse" Then
                    dataRow("PositionUse") = drJcode("PositionUse")
                End If
                If dtSum.Columns(c).ColumnName = "NumberPositionUse" Then
                    dataRow("NumberPositionUse") = drJcode("NumberPositionUse")
                End If
                If dtSum.Columns(c).ColumnName = "Reason" Then
                    dataRow("Reason") = drJcode("Reason")
                End If
                If dtSum.Columns(c).ColumnName = "DinhMuc" Then
                    dataRow("DinhMuc") = drJcode("DinhMuc")
                End If
                If dtSum.Columns(c).ColumnName = "TonQuyDinh" Then
                    dataRow("TonQuyDinh") = drJcode("TonQuyDinh")
                End If
                If dtSum.Columns(c).ColumnName = "Supplier" Then
                    dataRow("Supplier") = drJcode("Supplier")
                End If
                If dtSum.Columns(c).ColumnName = "GiaTien" Then
                    dataRow("GiaTien") = drJcode("GiaTien")
                End If
                If dtSum.Columns(c).ColumnName = "TienTe" Then
                    dataRow("TienTe") = drJcode("TienTe")
                End If
                If dtSum.Columns(c).ColumnName = "PriceUSD" Then
                    dataRow("PriceUSD") = drJcode("PriceUSD")
                End If
                If dtSum.Columns(c).ColumnName = "TonCuoi" Then
                    dataRow("TonCuoi") = drJcode("TonCuoi")
                End If
                For Each drQty As DataRow In dtQty.Rows
                    If dtSum.Columns(c).ColumnName = drQty("YM") And drJcode("JCode") = drQty("JCode") Then
                        dataRow(dtSum.Columns(c).ColumnName) = drQty("NDVQty")
                        Exit For
                    End If
                Next
            Next
            dtSum.Rows.Add(dataRow)
        Next
        GridControl1.DataSource = dtSum
    End Sub

    Private Sub dailyHori()
        Dim dtSum As New DataTable
        dtSum.Columns.Add("JCode")
        dtSum.Columns.Add("BudgetCategory")
        'dtSum.Columns.Add("PrcName")
        'dtSum.Columns.Add("SubPrcName")
        dtSum.Columns.Add("JEName")
        dtSum.Columns.Add("JVName")
        dtSum.Columns.Add("ImportItem")
        dtSum.Columns.Add("Unit")
        dtSum.Columns.Add("PackingType")
        dtSum.Columns.Add("LeadTime")
        dtSum.Columns.Add("Process")
        'dtSum.Columns.Add("BoPhan")
        dtSum.Columns.Add("UsingPurpose")
        dtSum.Columns.Add("MachineLineAssetCode")
        dtSum.Columns.Add("Picture")
        dtSum.Columns.Add("PictureLink")
        dtSum.Columns.Add("PositionUse")
        dtSum.Columns.Add("NumberPositionUse")
        dtSum.Columns.Add("Reason")
        dtSum.Columns.Add("DinhMuc")
        dtSum.Columns.Add("TonQuyDinh")
        dtSum.Columns.Add("Supplier")
        dtSum.Columns.Add("GiaTien")
        dtSum.Columns.Add("TienTe")
        dtSum.Columns.Add("PriceUSD")
        dtSum.Columns.Add("TonCuoi")

        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", dteStartDate.DateTime.ToString("yyyyMMdd"))
        para(1) = New SqlClient.SqlParameter("@EndDate", dteEndDate.DateTime.ToString("yyyyMMdd"))
        para(2) = New SqlClient.SqlParameter("@Action", "YMD")
        Dim dtYMD As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodeByDay_PR1", para)

        If dtYMD.Rows.Count > 0 Then
            For Each r As DataRow In dtYMD.Rows
                dtSum.Columns.Add(r("YMD"))
            Next
        End If

        para(2) = New SqlClient.SqlParameter("@Action", "Qty")
        Dim dtQty As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodeByDay_PR1", para)

        para(2) = New SqlClient.SqlParameter("@Action", "JCode")
        Dim dtJcode As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodeByDay_PR1", para)

        Dim dataRow As DataRow
        For Each drJcode As DataRow In dtJcode.Rows
            Dim rs() As DataRow = dtSum.Select(String.Format("JCode='{0}'", drJcode("JCode")))
            If rs.Length <> 0 Then
                Continue For
            End If
            dataRow = dtSum.NewRow
            For c = 0 To dtSum.Columns.Count - 1
                If dtSum.Columns(c).ColumnName = "JCode" Then
                    dataRow("JCode") = drJcode("JCode")
                End If
                If dtSum.Columns(c).ColumnName = "BudgetCategory" Then
                    dataRow("BudgetCategory") = drJcode("BudgetCategory")
                End If
                'If dtSum.Columns(c).ColumnName = "PrcName" Then
                '    dataRow("PrcName") = drJcode("PrcName")
                'End If
                'If dtSum.Columns(c).ColumnName = "SubPrcName" Then
                '    dataRow("SubPrcName") = drJcode("SubPrcName")
                'End If
                If dtSum.Columns(c).ColumnName = "JEName" Then
                    dataRow("JEName") = drJcode("JEName")
                End If
                If dtSum.Columns(c).ColumnName = "JVName" Then
                    dataRow("JVName") = drJcode("JVName")
                End If
                If dtSum.Columns(c).ColumnName = "ImportItem" Then
                    dataRow("ImportItem") = drJcode("ImportItem")
                End If
                If dtSum.Columns(c).ColumnName = "Unit" Then
                    dataRow("Unit") = drJcode("Unit")
                End If
                If dtSum.Columns(c).ColumnName = "PackingType" Then
                    dataRow("PackingType") = drJcode("PackingType")
                End If
                If dtSum.Columns(c).ColumnName = "LeadTime" Then
                    dataRow("LeadTime") = drJcode("LeadTime")
                End If
                If dtSum.Columns(c).ColumnName = "Process" Then
                    dataRow("Process") = drJcode("Process")
                End If
                'If dtSum.Columns(c).ColumnName = "BoPhan" Then
                '    dataRow("BoPhan") = drJcode("BoPhan")
                'End If
                If dtSum.Columns(c).ColumnName = "UsingPurpose" Then
                    dataRow("UsingPurpose") = drJcode("UsingPurpose")
                End If
                If dtSum.Columns(c).ColumnName = "MachineLineAssetCode" Then
                    dataRow("MachineLineAssetCode") = drJcode("MachineLineAssetCode")
                End If
                If dtSum.Columns(c).ColumnName = "Picture" Then
                    dataRow("Picture") = drJcode("Picture")
                End If
                If dtSum.Columns(c).ColumnName = "PictureLink" Then
                    dataRow("PictureLink") = drJcode("PictureLink")
                End If
                If dtSum.Columns(c).ColumnName = "PositionUse" Then
                    dataRow("PositionUse") = drJcode("PositionUse")
                End If
                If dtSum.Columns(c).ColumnName = "NumberPositionUse" Then
                    dataRow("NumberPositionUse") = drJcode("NumberPositionUse")
                End If
                If dtSum.Columns(c).ColumnName = "Reason" Then
                    dataRow("Reason") = drJcode("Reason")
                End If
                If dtSum.Columns(c).ColumnName = "DinhMuc" Then
                    dataRow("DinhMuc") = drJcode("DinhMuc")
                End If
                If dtSum.Columns(c).ColumnName = "TonQuyDinh" Then
                    dataRow("TonQuyDinh") = drJcode("TonQuyDinh")
                End If
                If dtSum.Columns(c).ColumnName = "Supplier" Then
                    dataRow("Supplier") = drJcode("Supplier")
                End If
                If dtSum.Columns(c).ColumnName = "GiaTien" Then
                    dataRow("GiaTien") = drJcode("GiaTien")
                End If
                If dtSum.Columns(c).ColumnName = "TienTe" Then
                    dataRow("TienTe") = drJcode("TienTe")
                End If
                If dtSum.Columns(c).ColumnName = "PriceUSD" Then
                    dataRow("PriceUSD") = drJcode("PriceUSD")
                End If
                If dtSum.Columns(c).ColumnName = "TonCuoi" Then
                    dataRow("TonCuoi") = drJcode("TonCuoi")
                End If
                For Each drQty As DataRow In dtQty.Rows
                    If dtSum.Columns(c).ColumnName = drQty("YMD") And drJcode("JCode") = drQty("JCode") Then
                        dataRow(dtSum.Columns(c).ColumnName) = drQty("NDVQty")
                        Exit For
                    End If
                Next
            Next
            dtSum.Rows.Add(dataRow)
        Next
        GridControl1.DataSource = dtSum
    End Sub

    Private Sub processMonthlyHori()
        Dim dtSum As New DataTable
        dtSum.Columns.Add("JCode")
        dtSum.Columns.Add("BudgetCategory")
        'dtSum.Columns.Add("PrcName")
        'dtSum.Columns.Add("SubPrcName")
        dtSum.Columns.Add("JEName")
        dtSum.Columns.Add("JVName")
        dtSum.Columns.Add("ImportItem")
        dtSum.Columns.Add("Unit")
        dtSum.Columns.Add("PackingType")
        dtSum.Columns.Add("LeadTime")
        dtSum.Columns.Add("Process")
        'dtSum.Columns.Add("BoPhan")
        dtSum.Columns.Add("UsingPurpose")
        dtSum.Columns.Add("MachineLineAssetCode")
        dtSum.Columns.Add("Picture")
        dtSum.Columns.Add("PictureLink")
        dtSum.Columns.Add("PositionUse")
        dtSum.Columns.Add("NumberPositionUse")
        dtSum.Columns.Add("Reason")
        dtSum.Columns.Add("DinhMuc")
        dtSum.Columns.Add("TonQuyDinh")
        dtSum.Columns.Add("Supplier")
        dtSum.Columns.Add("GiaTien")
        dtSum.Columns.Add("TienTe")
        dtSum.Columns.Add("PriceUSD")
        dtSum.Columns.Add("DeptName")
        dtSum.Columns.Add("DeptGSR")
        dtSum.Columns.Add("TonCuoi")

        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", dteStartDate.DateTime.ToString("yyyyMMdd"))
        para(1) = New SqlClient.SqlParameter("@EndDate", dteEndDate.DateTime.ToString("yyyyMMdd"))
        para(2) = New SqlClient.SqlParameter("@Action", "YM")
        Dim dtYM As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodePrcByMonth_PR1", para)

        If dtYM.Rows.Count > 0 Then
            For Each r As DataRow In dtYM.Rows
                dtSum.Columns.Add(r("YM"))
            Next
        End If

        para(2) = New SqlClient.SqlParameter("@Action", "Qty")
        Dim dtQty As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodePrcByMonth_PR1", para)

        para(2) = New SqlClient.SqlParameter("@Action", "JCode")
        Dim dtJCode As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodePrcByMonth_PR1", para)

        Dim dataRow As DataRow
        For Each drJcode As DataRow In dtJCode.Rows
            Dim rs() As DataRow = dtSum.Select(String.Format("JCode='{0}'", drJcode("JCode")))
            If rs.Length > 0 Then
                Continue For
            End If

            dataRow = dtSum.NewRow
            For c = 0 To dtSum.Columns.Count - 1
                If dtSum.Columns(c).ColumnName = "JCode" Then
                    dataRow("JCode") = drJcode("JCode")
                End If
                If dtSum.Columns(c).ColumnName = "BudgetCategory" Then
                    dataRow("BudgetCategory") = drJcode("BudgetCategory")
                End If
                'If dtSum.Columns(c).ColumnName = "PrcName" Then
                '    dataRow("PrcName") = drJcode("PrcName")
                'End If
                'If dtSum.Columns(c).ColumnName = "SubPrcName" Then
                '    dataRow("SubPrcName") = drJcode("SubPrcName")
                'End If
                If dtSum.Columns(c).ColumnName = "JEName" Then
                    dataRow("JEName") = drJcode("JEName")
                End If
                If dtSum.Columns(c).ColumnName = "JVName" Then
                    dataRow("JVName") = drJcode("JVName")
                End If
                If dtSum.Columns(c).ColumnName = "ImportItem" Then
                    dataRow("ImportItem") = drJcode("ImportItem")
                End If
                If dtSum.Columns(c).ColumnName = "Unit" Then
                    dataRow("Unit") = drJcode("Unit")
                End If
                If dtSum.Columns(c).ColumnName = "PackingType" Then
                    dataRow("PackingType") = drJcode("PackingType")
                End If
                If dtSum.Columns(c).ColumnName = "LeadTime" Then
                    dataRow("LeadTime") = drJcode("LeadTime")
                End If
                If dtSum.Columns(c).ColumnName = "Process" Then
                    dataRow("Process") = drJcode("Process")
                End If
                'If dtSum.Columns(c).ColumnName = "BoPhan" Then
                '    dataRow("BoPhan") = drJcode("BoPhan")
                'End If
                If dtSum.Columns(c).ColumnName = "UsingPurpose" Then
                    dataRow("UsingPurpose") = drJcode("UsingPurpose")
                End If
                If dtSum.Columns(c).ColumnName = "MachineLineAssetCode" Then
                    dataRow("MachineLineAssetCode") = drJcode("MachineLineAssetCode")
                End If
                If dtSum.Columns(c).ColumnName = "Picture" Then
                    dataRow("Picture") = drJcode("Picture")
                End If
                If dtSum.Columns(c).ColumnName = "PictureLink" Then
                    dataRow("PictureLink") = drJcode("PictureLink")
                End If
                If dtSum.Columns(c).ColumnName = "PositionUse" Then
                    dataRow("PositionUse") = drJcode("PositionUse")
                End If
                If dtSum.Columns(c).ColumnName = "NumberPositionUse" Then
                    dataRow("NumberPositionUse") = drJcode("NumberPositionUse")
                End If
                If dtSum.Columns(c).ColumnName = "Reason" Then
                    dataRow("Reason") = drJcode("Reason")
                End If
                If dtSum.Columns(c).ColumnName = "DinhMuc" Then
                    dataRow("DinhMuc") = drJcode("DinhMuc")
                End If
                If dtSum.Columns(c).ColumnName = "TonQuyDinh" Then
                    dataRow("TonQuyDinh") = drJcode("TonQuyDinh")
                End If
                If dtSum.Columns(c).ColumnName = "Supplier" Then
                    dataRow("Supplier") = drJcode("Supplier")
                End If
                If dtSum.Columns(c).ColumnName = "GiaTien" Then
                    dataRow("GiaTien") = drJcode("GiaTien")
                End If
                If dtSum.Columns(c).ColumnName = "TienTe" Then
                    dataRow("TienTe") = drJcode("TienTe")
                End If
                If dtSum.Columns(c).ColumnName = "PriceUSD" Then
                    dataRow("PriceUSD") = drJcode("PriceUSD")
                End If
                If dtSum.Columns(c).ColumnName = "DeptName" Then
                    dataRow("DeptName") = drJcode("DeptName")
                End If
                If dtSum.Columns(c).ColumnName = "DeptGSR" Then
                    dataRow("DeptGSR") = drJcode("DeptGSR")
                End If
                If dtSum.Columns(c).ColumnName = "TonCuoi" Then
                    dataRow("TonCuoi") = drJcode("TonCuoi")
                End If

                For Each drQty As DataRow In dtQty.Rows
                    If dtSum.Columns(c).ColumnName = drQty("YM") And drJcode("JCode") = drQty("JCode") Then
                        dataRow(dtSum.Columns(c).ColumnName) = drQty("NDVQty")
                        Exit For
                    End If
                Next
            Next
            dtSum.Rows.Add(dataRow)
        Next
        GridControl1.DataSource = dtSum
    End Sub

    Private Sub processDailyHori()
        Dim dtSum As New DataTable
        dtSum.Columns.Add("JCode")
        dtSum.Columns.Add("BudgetCategory")
        'dtSum.Columns.Add("PrcName")
        'dtSum.Columns.Add("SubPrcName")
        dtSum.Columns.Add("JEName")
        dtSum.Columns.Add("JVName")
        dtSum.Columns.Add("ImportItem")
        dtSum.Columns.Add("Unit")
        dtSum.Columns.Add("PackingType")
        dtSum.Columns.Add("LeadTime")
        dtSum.Columns.Add("Process")
        'dtSum.Columns.Add("BoPhan")
        dtSum.Columns.Add("UsingPurpose")
        dtSum.Columns.Add("MachineLineAssetCode")
        dtSum.Columns.Add("Picture")
        dtSum.Columns.Add("PictureLink")
        dtSum.Columns.Add("PositionUse")
        dtSum.Columns.Add("NumberPositionUse")
        dtSum.Columns.Add("Reason")
        dtSum.Columns.Add("DinhMuc")
        dtSum.Columns.Add("TonQuyDinh")
        dtSum.Columns.Add("Supplier")
        dtSum.Columns.Add("GiaTien")
        dtSum.Columns.Add("TienTe")
        dtSum.Columns.Add("PriceUSD")
        dtSum.Columns.Add("DeptName")
        dtSum.Columns.Add("DeptGSR")
        dtSum.Columns.Add("TonCuoi")

        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", dteStartDate.DateTime.ToString("yyyyMMdd"))
        para(1) = New SqlClient.SqlParameter("@EndDate", dteEndDate.DateTime.ToString("yyyyMMdd"))
        para(2) = New SqlClient.SqlParameter("@Action", "YMD")
        Dim dtYMD As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodePrcByDay_PR1", para)

        If dtYMD.Rows.Count > 0 Then
            For Each r As DataRow In dtYMD.Rows
                dtSum.Columns.Add(r("YMD"))
            Next
        End If

        para(2) = New SqlClient.SqlParameter("@Action", "Qty")
        Dim dtQty As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodePrcByDay_PR1", para)

        para(2) = New SqlClient.SqlParameter("@Action", "JCode")
        Dim dtJcode As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodePrcByDay_PR1", para)

        Dim dataRow As DataRow
        For Each drJcode As DataRow In dtJcode.Rows
            Dim rs() As DataRow = dtSum.Select(String.Format("JCode='{0}'", drJcode("JCode")))
            If rs.Length <> 0 Then
                Continue For
            End If
            dataRow = dtSum.NewRow()
            For c = 0 To dtSum.Columns.Count - 1
                If dtSum.Columns(c).ColumnName = "JCode" Then
                    dataRow("JCode") = drJcode("JCode")
                End If
                If dtSum.Columns(c).ColumnName = "BudgetCategory" Then
                    dataRow("BudgetCategory") = drJcode("BudgetCategory")
                End If
                'If dtSum.Columns(c).ColumnName = "PrcName" Then
                '    dataRow("PrcName") = drJcode("PrcName")
                'End If
                'If dtSum.Columns(c).ColumnName = "SubPrcName" Then
                '    dataRow("SubPrcName") = drJcode("SubPrcName")
                'End If
                If dtSum.Columns(c).ColumnName = "JEName" Then
                    dataRow("JEName") = drJcode("JEName")
                End If
                If dtSum.Columns(c).ColumnName = "JVName" Then
                    dataRow("JVName") = drJcode("JVName")
                End If
                If dtSum.Columns(c).ColumnName = "ImportItem" Then
                    dataRow("ImportItem") = drJcode("ImportItem")
                End If
                If dtSum.Columns(c).ColumnName = "Unit" Then
                    dataRow("Unit") = drJcode("Unit")
                End If
                If dtSum.Columns(c).ColumnName = "PackingType" Then
                    dataRow("PackingType") = drJcode("PackingType")
                End If
                If dtSum.Columns(c).ColumnName = "LeadTime" Then
                    dataRow("LeadTime") = drJcode("LeadTime")
                End If
                If dtSum.Columns(c).ColumnName = "Process" Then
                    dataRow("Process") = drJcode("Process")
                End If
                'If dtSum.Columns(c).ColumnName = "BoPhan" Then
                '    dataRow("BoPhan") = drJcode("BoPhan")
                'End If
                If dtSum.Columns(c).ColumnName = "UsingPurpose" Then
                    dataRow("UsingPurpose") = drJcode("UsingPurpose")
                End If
                If dtSum.Columns(c).ColumnName = "MachineLineAssetCode" Then
                    dataRow("MachineLineAssetCode") = drJcode("MachineLineAssetCode")
                End If
                If dtSum.Columns(c).ColumnName = "Picture" Then
                    dataRow("Picture") = drJcode("Picture")
                End If
                If dtSum.Columns(c).ColumnName = "PictureLink" Then
                    dataRow("PictureLink") = drJcode("PictureLink")
                End If
                If dtSum.Columns(c).ColumnName = "PositionUse" Then
                    dataRow("PositionUse") = drJcode("PositionUse")
                End If
                If dtSum.Columns(c).ColumnName = "NumberPositionUse" Then
                    dataRow("NumberPositionUse") = drJcode("NumberPositionUse")
                End If
                If dtSum.Columns(c).ColumnName = "Reason" Then
                    dataRow("Reason") = drJcode("Reason")
                End If
                If dtSum.Columns(c).ColumnName = "DinhMuc" Then
                    dataRow("DinhMuc") = drJcode("DinhMuc")
                End If
                If dtSum.Columns(c).ColumnName = "TonQuyDinh" Then
                    dataRow("TonQuyDinh") = drJcode("TonQuyDinh")
                End If
                If dtSum.Columns(c).ColumnName = "Supplier" Then
                    dataRow("Supplier") = drJcode("Supplier")
                End If
                If dtSum.Columns(c).ColumnName = "GiaTien" Then
                    dataRow("GiaTien") = drJcode("GiaTien")
                End If
                If dtSum.Columns(c).ColumnName = "TienTe" Then
                    dataRow("TienTe") = drJcode("TienTe")
                End If
                If dtSum.Columns(c).ColumnName = "PriceUSD" Then
                    dataRow("PriceUSD") = drJcode("PriceUSD")
                End If
                If dtSum.Columns(c).ColumnName = "DeptName" Then
                    dataRow("DeptName") = drJcode("DeptName")
                End If
                If dtSum.Columns(c).ColumnName = "DeptGSR" Then
                    dataRow("DeptGSR") = drJcode("DeptGSR")
                End If
                If dtSum.Columns(c).ColumnName = "TonCuoi" Then
                    dataRow("TonCuoi") = drJcode("TonCuoi")
                End If

                For Each dataRowQty As DataRow In dtQty.Rows
                    If dtSum.Columns(c).ColumnName = dataRowQty("YMD") And drJcode("JCode") = dataRowQty("JCode") Then
                        dataRow(dtSum.Columns(c).ColumnName) = dataRowQty("NDVQty")
                        Exit For
                    End If
                Next
            Next
            dtSum.Rows.Add(dataRow)
        Next
        GridControl1.DataSource = dtSum
    End Sub

    Private Sub FrmBudgetControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteStartDate.EditValue = DateTime.Now
        dteEndDate.EditValue = DateTime.Now
        btnShow.PerformClick()
    End Sub

    Private Sub dteStartDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteStartDate.EditValueChanged
        If dteStartDate.DateTime > dteEndDate.DateTime Then
            dteEndDate.EditValue = dteStartDate.DateTime
        End If
    End Sub
    Private Sub dteEndDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteEndDate.EditValueChanged
        If dteEndDate.DateTime < dteStartDate.DateTime Then
            dteStartDate.EditValue = dteEndDate.DateTime
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        If GridView1.RowCount > 0 Then
            GridControlExportExcel(GridView1)
        End If
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        'Import File Budget
        'Dim dt As DataTable = ImportEXCEL(True)
        'Dim dtTong As DataTable = ImportEXCEL(True)
        'For Each r As DataRow In dt.Rows
        '    'If r("ItemCode") = "ItemCode" Then
        '    '    Continue For
        '    'End If
        '    If IsDBNull(r("ItemCode")) Then
        '        Continue For
        '    End If
        '    Dim obj As New PCM_PR1_Budget
        '    obj.ItemCode_K = r("ItemCode")
        '    _db.GetObject(obj)
        '    'If IsDBNull(obj.ItemNameV) Then
        '    For Each rTong As DataRow In dtTong.Rows
        '        If rTong("Item Code") = r("ItemCode") Then
        '            If IsDBNull(rTong("Item Name V")) Then
        '                Exit For
        '            End If
        '            obj.ItemNameV = rTong("Item Name V")
        '            Exit For
        '        End If
        '    Next
        '    'End If
        '    'If IsDBNull(obj.ItemNameE) Then
        '    For Each rTong As DataRow In dtTong.Rows
        '        If rTong("Item Code") = r("ItemCode") Then
        '            If IsDBNull(rTong("Item Name E")) Then
        '                Exit For
        '            End If
        '            obj.ItemNameE = rTong("Item Name E")
        '                Exit For
        '            End If
        '        Next
        '    'End If
        '    'If IsDBNull(obj.BudgetCategory) Then
        '    For Each rTong As DataRow In dtTong.Rows
        '        If rTong("Item Code") = r("ItemCode") Then
        '            If IsDBNull(rTong("Budget Category")) Then
        '                Exit For
        '            End If
        '            obj.BudgetCategory = rTong("Budget Category")
        '                Exit For
        '            End If
        '        Next
        '    'End If
        '    'If IsDBNull(obj.ImportItem) Then
        '    For Each rTong As DataRow In dtTong.Rows
        '        If rTong("Item Code") = r("ItemCode") Then
        '            If IsDBNull(rTong("Import Item")) Then
        '                Exit For
        '            End If
        '            obj.ImportItem = rTong("Import Item")
        '            Exit For
        '        End If
        '    Next
        '    'End If
        '    'If IsDBNull(obj.Unit) Then
        '    For Each rTong As DataRow In dtTong.Rows
        '        If rTong("Item Code") = r("ItemCode") Then
        '            If IsDBNull(rTong("Unit")) Then
        '                Exit For
        '            End If
        '            obj.Unit = rTong("Unit")
        '            Exit For
        '        End If
        '    Next
        '    'End If
        '    'If IsDBNull(obj.PackingType) Then
        '    For Each rTong As DataRow In dtTong.Rows
        '        If rTong("Item Code") = r("ItemCode") Then
        '            If IsDBNull(rTong("Packing Type")) Then
        '                Exit For
        '            End If
        '            obj.PackingType = rTong("Packing Type")
        '            Exit For
        '        End If
        '    Next
        '    'End If
        '    'If IsDBNull(obj.LeadTime) Then
        '    For Each rTong As DataRow In dtTong.Rows
        '        If rTong("Item Code") = r("ItemCode") Then
        '            If IsDBNull(rTong("Lead Time")) Then
        '                Exit For
        '            End If
        '            obj.LeadTime = rTong("Lead Time")
        '            Exit For
        '        End If
        '    Next
        '    ' End If
        '    'If IsDBNull(obj.UsingPurpose) Then
        '    For Each rTong As DataRow In dtTong.Rows
        '        If rTong("Item Code") = r("ItemCode") Then
        '            If IsDBNull(rTong("Using Purpose")) Then
        '                Exit For
        '            End If
        '            obj.UsingPurpose = rTong("Using Purpose")
        '            Exit For
        '        End If
        '    Next
        '    'End If
        '    'If IsDBNull(obj.Supplier) Then
        '    For Each rTong As DataRow In dtTong.Rows
        '        If rTong("Item Code") = r("ItemCode") Then
        '            If IsDBNull(rTong("Supplier Name")) Then
        '                Exit For
        '            End If
        '            obj.Supplier = rTong("Supplier Name")
        '            Exit For
        '        End If
        '    Next
        '    'End If
        '    'If IsDBNull(obj.GiaTien) Then
        '    For Each rTong As DataRow In dtTong.Rows
        '        If rTong("Item Code") = r("ItemCode") Then
        '            If IsDBNull(rTong("Unit Price")) Then
        '                Exit For
        '            End If
        '            obj.GiaTien = rTong("Unit Price")
        '            Exit For
        '        End If
        '    Next
        '    'End If
        '    'If IsDBNull(obj.TienTe) Then
        '    For Each rTong As DataRow In dtTong.Rows
        '        If rTong("Item Code") = r("ItemCode") Then
        '            If IsDBNull(rTong("Currency")) Then
        '                Exit For
        '            End If
        '            obj.TienTe = rTong("Currency")
        '            Exit For
        '        End If
        '    Next
        '    'End If
        '    'If IsDBNull(obj.LeadTime) Then
        '    For Each rTong As DataRow In dtTong.Rows
        '        If rTong("Item Code") = r("ItemCode") Then
        '            If IsDBNull(rTong("Lead Time")) Then
        '                Exit For
        '            End If
        '            obj.LeadTime = rTong("Lead Time")
        '            Exit For
        '        End If
        '    Next
        '    'End If
        '    'If IsDBNull(obj.Description) Then
        '    For Each rTong As DataRow In dtTong.Rows
        '        If rTong("Item Code") = r("ItemCode") Then
        '            If IsDBNull(rTong("Description")) Then
        '                Exit For
        '            End If
        '            obj.Description = rTong("Description")
        '            Exit For
        '        End If
        '    Next
        '    'End If
        '    'If IsDBNull(obj.Reason) Then
        '    For Each rTong As DataRow In dtTong.Rows
        '        If rTong("Item Code") = r("ItemCode") Then
        '            If IsDBNull(rTong("Reason Disable")) Then
        '                Exit For
        '            End If
        '            obj.Reason = rTong("Reason Disable")
        '            Exit For
        '        End If
        '    Next
        '    'End If
        '    _db.Update(obj)
        'Next


        'For Each r As DataRow In dt.Rows
        '    Dim obj As New PCM_PR1_Budget
        '    obj.ItemCode_K = r(0)
        '    _db.GetObject(obj)
        '    obj.Packing = r(1)

        '    If _db.ExistObject(obj) Then
        '        _db.Update(obj)
        '    Else
        '        _db.Insert(obj)
        '    End If
        'Next

        If rdoMatCode.Checked And rdoYearly.Checked And rdoHorizontal.Checked Then
            GridControlReadOnly(GridView1, True)
            GridView1.Columns("DinhMuc").OptionsColumn.ReadOnly = False
            GridControlSetColorEdit(GridView1)
            Return
        End If

        GridView1.Columns.Clear()
        GridControl1.DataSource = _db.FillDataTable("SELECT * INTO #TempTable 
                                                    FROM PCM_PR1_Budget
                                                    WHERE LEN(ItemCode) <> 6
                                                    ALTER TABLE #TempTable DROP COLUMN Description, TonDau, TonQuyDinh, 
                                                    BoPhan, CreateUser, CreateDate 
                                                    SELECT * FROM #TempTable ORDER BY ItemCode")
        GridControlSetFormat(GridView1, 2)
        GridControlSetColumnEdit(GridView1)
        GridView1.Columns("ItemCode").OptionsColumn.ReadOnly = True
        GridView1.Columns("Picture").OptionsColumn.ReadOnly = True
        GridView1.Columns("PictureLink").OptionsColumn.ReadOnly = True
        GridView1.Columns("TonCuoi").OptionsColumn.ReadOnly = True
        GridView1.Columns("LeadTime").Width = 60
        GridView1.Columns("Unit").Width = 50
        GridView1.Columns("Process").Width = 50
        GridView1.Columns("Min").Width = 40
        GridView1.Columns("Max").Width = 40
        GridView1.Columns("TonCuoi").Width = 40
        GridControlSetFormatNumber(GridView1, "TonCuoi", 1)
        GridView1.Columns("Picture").ColumnEdit = GridControlLinkEdit()
        GridView1.Columns("PictureLink").ColumnEdit = GridControlLinkEdit()
        GridControlSetColorEdit(GridView1)

        'Dim btnPicture As New RepositoryItemButtonEdit
        'GridControl2.RepositoryItems.Add(btnPicture)
        'GridView2.Columns("Picture").ColumnEdit = btnPicture

        'Dim attF As New RepositoryItemHyperLinkEdit
        'attF.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        'GridControl2.RepositoryItems.Add(attF)
        'GridView2.Columns("Picture").ColumnEdit = GridControlLinkEdit()
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable = True And e.Column.ReadOnly = False Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            If GridView1.Columns("ItemCode") IsNot Nothing Then
                _db.ExecuteNonQuery(String.Format(" update PCM_PR1_Budget 
                                                    set {0} = @Value 
                                                    where ItemCode = '{1}'",
                                                    e.Column.FieldName,
                                                    GridView1.GetFocusedRowCellValue("ItemCode")), para)
            Else
                _db.ExecuteNonQuery(String.Format(" update PCM_PR1_Budget 
                                                    set {0} = @Value 
                                                    where ItemCode = '{1}'",
                                                    e.Column.FieldName,
                                                    GridView1.GetFocusedRowCellValue("JCode")), para)
            End If
        End If
    End Sub

    Private Sub AddFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddFileToolStripMenuItem.Click
        If GridView1.Columns(0).FieldName = "ItemCode" Then
            Dim frm As New OpenFileDialog
            frm.ShowDialog()
            If frm.FileName <> "" Then
                Dim obj As New PCM_PR1_Budget
                obj.ItemCode_K = GridView1.GetFocusedRowCellValue("ItemCode")
                _db.GetObject(obj)
                obj.Picture = frm.SafeFileName
                obj.PictureLink = myPath & obj.ItemCode_K & "_PR1_Budget_" & frm.SafeFileName
                File.Copy(frm.FileName, obj.PictureLink, True)
                GridView1.SetFocusedRowCellValue("Picture", frm.SafeFileName)
                GridView1.SetFocusedRowCellValue("PictureLink", obj.PictureLink)
                _db.Update(obj)
            End If
            frm.Dispose()
        Else
            Dim frm As New OpenFileDialog
            frm.ShowDialog()
            If frm.FileName <> "" Then
                Dim obj As New PCM_PR1_Budget
                obj.ItemCode_K = GridView1.GetFocusedRowCellValue("JCode")
                _db.GetObject(obj)
                obj.Picture = frm.SafeFileName
                obj.PictureLink = myPath & obj.ItemCode_K & "_PR1_Budget_" & frm.SafeFileName
                File.Copy(frm.FileName, obj.PictureLink, True)
                GridView1.SetFocusedRowCellValue("Picture", frm.SafeFileName)
                GridView1.SetFocusedRowCellValue("PictureLink", obj.PictureLink)
                _db.Update(obj)
            End If
            frm.Dispose()
        End If
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView1.RowClick
        If GridView1.FocusedColumn.FieldName = "Picture" Then
            If GridView1.Columns(0).FieldName = "ItemCode" Then
                Dim obj As New PCM_PR1_Budget
                obj.ItemCode_K = GridView1.GetFocusedRowCellValue("ItemCode")
                _db.GetObject(obj)
                If obj.Picture <> "" Then
                    Process.Start(OpenfileTemp(obj.PictureLink))
                End If
            Else
                Dim obj As New PCM_PR1_Budget
                obj.ItemCode_K = GridView1.GetFocusedRowCellValue("JCode")
                _db.GetObject(obj)
                If obj.Picture <> "" Then
                    Process.Start(OpenfileTemp(obj.PictureLink))
                End If
            End If
        End If
    End Sub

    Private Sub DeleteFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteFileToolStripMenuItem.Click
        If GridView1.GetFocusedRowCellValue("Picture") <> "" Then
            If GridView1.Columns(0).FieldName = "ItemCode" Then
                GridView1.SetFocusedRowCellValue("Picture", "")
                Dim obj As New PCM_PR1_Budget
                obj.ItemCode_K = GridView1.GetFocusedRowCellValue("ItemCode")
                _db.GetObject(obj)
                File.Delete(obj.PictureLink)
                obj.Picture = ""
                obj.PictureLink = ""
                _db.Update(obj)
            Else
                GridView1.SetFocusedRowCellValue("Picture", "")
                Dim obj As New PCM_PR1_Budget
                obj.ItemCode_K = GridView1.GetFocusedRowCellValue("JCode")
                _db.GetObject(obj)
                File.Delete(obj.PictureLink)
                obj.Picture = ""
                obj.PictureLink = ""
                _db.Update(obj)
            End If
        End If
    End Sub
    Sub CapNhatTonCuoi()
        Dim dtItemCode As DataTable = _db.FillDataTable("select ItemCode from PCM_PR1_Budget where len (ItemCode) <> 6")
        For Each r As DataRow In dtItemCode.Rows
            Dim objHead As New PCM_PR1_Budget
            objHead.ItemCode_K = r("ItemCode")
            _db.GetObject(objHead)

            Dim para(3) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@StartDate", "20200401")
            para(1) = New SqlClient.SqlParameter("@EndDate", DateTime.Now.ToString("yyyyMMdd"))
            para(2) = New SqlClient.SqlParameter("@JCode", r("ItemCode"))
            para(3) = New SqlClient.SqlParameter("@Action", "LaySum")

            Dim soLuongNhap = _db.ExecuteScalarSP("sp_PCM_PR1_NhapXuat", para)
            Dim soLuongXuat = _db.ExecuteScalar(String.Format("SELECT SUM(SoLuongXuat) 
                                                    FROM PCM_PR1_NhapXuat
                                                    WHERE ItemCode = '{0}'",
                                                    r("ItemCode")))

            Dim SoNhap As Decimal = IIf(IsDBNull(soLuongNhap), 0, soLuongNhap)
            Dim SoXuat As Decimal = IIf(IsDBNull(soLuongXuat), 0, soLuongXuat)
            objHead.TonCuoi = IIf(IsNumeric(objHead.TonDau), objHead.TonDau, 0) + SoNhap - SoXuat
            _db.Update(objHead)
        Next
    End Sub

    Private Sub btnCapNhatTonCuoi_Click(sender As Object, e As EventArgs) Handles btnCapNhatTonCuoi.Click
        CapNhatTonCuoi()
        ShowSuccess()
    End Sub
End Class