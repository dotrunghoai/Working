Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports System.Windows.Forms

Public Class FrmSummary : Inherits DevExpress.XtraEditors.XtraForm
    'Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    'Dim dbAS As New DBFunction(PublicConst.EnumServers.NDV_DB2_AS400)
    Dim param(1) As SqlClient.SqlParameter
    Dim dtbCrossTablePC As New DataTable


    Private Sub mnuShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAll.Click
        Me.Cursor = Cursors.WaitCursor
        If rdoHorizontal.Checked = True Then
            If rdoMatCodeProcess.Checked = True Then
                If rdoDaily.Checked = True Then
                    sumJCodeProcess()
                Else
                    sumJCodeProcessM()
                End If
            Else
                If rdoDaily.Checked = True Then
                    sumJCode()
                Else
                    sumJCodeM()
                End If
            End If
        Else
            sumJCodeProcessV()
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Sub sumJCode()
        dtbCrossTablePC = New DataTable

        Dim col As DataColumn

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "JCode"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "JEName"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "JVName"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "Unit"
        dtbCrossTablePC.Columns.Add(col)

        Dim param(3) As SqlClient.SqlParameter
        Dim StartDate As DateTime = New DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day)
        Dim EndDate As DateTime = New DateTime(dtpEndDate.Value.Year, dtpEndDate.Value.Month, dtpEndDate.Value.Day)
        param(0) = New SqlClient.SqlParameter("@StartDate", StartDate.ToString("yyyyMMdd"))
        param(1) = New SqlClient.SqlParameter("@EndDate", EndDate.ToString("yyyyMMdd"))

        param(2) = New SqlClient.SqlParameter("@JCode", DBNull.Value)
        param(3) = New SqlClient.SqlParameter("@Action", "YMD")

        Dim dt As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodeByDay", param)

        If dt.Rows.Count <> 0 Then
            For Each row As DataRow In dt.Rows
                col = New DataColumn
                col.DataType = GetType(Decimal)
                col.ColumnName = row("YMD")
                dtbCrossTablePC.Columns.Add(col)
            Next
        End If

        param(3) = New SqlClient.SqlParameter("@Action", "Qty")

        Dim dtbPara As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodeByDay", param)

        param(3) = New SqlClient.SqlParameter("@Action", "JCode")

        Dim dtJCode As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodeByDay", param)

        Dim drwnew As DataRow
        For Each drJCode As DataRow In dtJCode.Rows

            Dim rs() As DataRow = dtbCrossTablePC.Select(String.Format("JCode='{0}'", drJCode("JCode")))
            If rs.Length <> 0 Then
                Continue For
            End If

            drwnew = dtbCrossTablePC.NewRow()
            For i As Integer = 0 To dtbCrossTablePC.Columns.Count - 1
                If dtbCrossTablePC.Columns(i).ColumnName = "JCode" Then
                    drwnew("JCode") = drJCode("JCode")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "JEName" Then
                    drwnew("JEName") = drJCode("JEName")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "JVName" Then
                    drwnew("JVName") = drJCode("JVName")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "Unit" Then
                    drwnew("Unit") = drJCode("Unit")
                End If

                For Each drow As DataRow In dtbPara.Rows
                    If dtbCrossTablePC.Columns(i).ColumnName = drow("YMD") And drJCode("JCode") = drow("JCode") Then
                        drwnew(dtbCrossTablePC.Columns(i).ColumnName) = drow("NDVQty")
                        Exit For
                    End If
                Next
            Next
            dtbCrossTablePC.Rows.Add(drwnew)
        Next
        GridView1.Columns.Clear()
        GridControl1.DataSource = dtbCrossTablePC
        GridControlSetFormat(GridView1, 4)
        FilterJCode()
    End Sub

    Sub sumJCodeProcess()
        dtbCrossTablePC = New DataTable

        Dim col As DataColumn

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "JCode"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "PrcName"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "SubPrcName"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "JEName"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "JVName"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "Unit"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "DeptName"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "DeptGSR"
        dtbCrossTablePC.Columns.Add(col)

        Dim param(3) As SqlClient.SqlParameter
        Dim StartDate As DateTime = dtpStartDate.Value.Date
        Dim EndDate As DateTime = dtpEndDate.Value.Date
        param(0) = New SqlClient.SqlParameter("@StartDate", StartDate.ToString("yyyyMMdd"))
        param(1) = New SqlClient.SqlParameter("@EndDate", EndDate.ToString("yyyyMMdd"))

        param(2) = New SqlClient.SqlParameter("@JCode", DBNull.Value)

        param(3) = New SqlClient.SqlParameter("@Action", "YMD")

        Dim dt As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodePrcByDay", param)

        If dt.Rows.Count <> 0 Then
            For Each row As DataRow In dt.Rows
                col = New DataColumn
                col.DataType = GetType(Decimal)
                col.ColumnName = row("YMD")
                dtbCrossTablePC.Columns.Add(col)
            Next
        End If

        param(3) = New SqlClient.SqlParameter("@Action", "Qty")

        Dim dtbPara As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodePrcByDay", param)

        param(3) = New SqlClient.SqlParameter("@Action", "JCode")

        Dim dtJCode As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodePrcByDay", param)

        Dim drwnew As DataRow
        For Each drJCode As DataRow In dtJCode.Rows

            Dim rs() As DataRow = dtbCrossTablePC.Select(String.Format("JCode='{0}' and PrcName = '{1}' and SubPrcName = '{2}'", drJCode("JCode"), drJCode("PrcName"), drJCode("SubPrcName")))
            If rs.Length <> 0 Then
                Continue For
            End If

            drwnew = dtbCrossTablePC.NewRow()
            For i As Integer = 0 To dtbCrossTablePC.Columns.Count - 1
                If dtbCrossTablePC.Columns(i).ColumnName = "JCode" Then
                    drwnew("JCode") = drJCode("JCode")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "PrcName" Then
                    drwnew("PrcName") = drJCode("PrcName")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "SubPrcName" Then
                    drwnew("SubPrcName") = drJCode("SubPrcName")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "JEName" Then
                    drwnew("JEName") = drJCode("JEName")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "JVName" Then
                    drwnew("JVName") = drJCode("JVName")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "Unit" Then
                    drwnew("Unit") = drJCode("Unit")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "DeptName" Then
                    drwnew("DeptName") = drJCode("DeptName")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "DeptGSR" Then
                    drwnew("DeptGSR") = drJCode("DeptGSR")
                End If

                For Each drow As DataRow In dtbPara.Rows
                    If dtbCrossTablePC.Columns(i).ColumnName = drow("YMD") And drJCode("JCode") = drow("JCode") And drJCode("PrcName") = drow("PrcName") And drJCode("SubPrcName") = drow("SubPrcName") Then
                        drwnew(dtbCrossTablePC.Columns(i).ColumnName) = drow("NDVQty")
                        Exit For
                    End If
                Next
            Next
            dtbCrossTablePC.Rows.Add(drwnew)
        Next


        GridView1.Columns.Clear()
        GridControl1.DataSource = dtbCrossTablePC
        GridControlSetFormat(GridView1, 4)
        FilterJCode()
    End Sub

    Sub sumJCodeM()
        dtbCrossTablePC = New DataTable

        Dim col As DataColumn

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "JCode"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "JEName"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "JVName"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "Unit"
        dtbCrossTablePC.Columns.Add(col)

        Dim param(3) As SqlClient.SqlParameter
        Dim StartDate As DateTime = dtpStartDate.Value.Date
        Dim EndDate As DateTime = dtpEndDate.Value.Date
        param(0) = New SqlClient.SqlParameter("@StartDate", StartDate.ToString("yyyyMMdd"))
        param(1) = New SqlClient.SqlParameter("@EndDate", EndDate.ToString("yyyyMMdd"))

        param(2) = New SqlClient.SqlParameter("@JCode", DBNull.Value)
        param(3) = New SqlClient.SqlParameter("@Action", "YM")

        Dim dt As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodeByMonth", param)

        If dt.Rows.Count <> 0 Then
            For Each row As DataRow In dt.Rows
                col = New DataColumn
                col.DataType = GetType(Decimal)
                col.ColumnName = row("YM")
                dtbCrossTablePC.Columns.Add(col)
            Next
        End If

        param(3) = New SqlClient.SqlParameter("@Action", "Qty")

        Dim dtbPara As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodeByMonth", param)

        param(3) = New SqlClient.SqlParameter("@Action", "JCode")

        Dim dtJCode As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodeByMonth", param)

        Dim drwnew As DataRow
        For Each drJCode As DataRow In dtJCode.Rows

            Dim rs() As DataRow = dtbCrossTablePC.Select(String.Format("JCode='{0}'", drJCode("JCode")))
            If rs.Length <> 0 Then
                Continue For
            End If

            drwnew = dtbCrossTablePC.NewRow()
            For i As Integer = 0 To dtbCrossTablePC.Columns.Count - 1
                If dtbCrossTablePC.Columns(i).ColumnName = "JCode" Then
                    drwnew("JCode") = drJCode("JCode")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "JEName" Then
                    drwnew("JEName") = drJCode("JEName")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "JVName" Then
                    drwnew("JVName") = drJCode("JVName")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "Unit" Then
                    drwnew("Unit") = drJCode("Unit")
                End If

                For Each drow As DataRow In dtbPara.Rows
                    If dtbCrossTablePC.Columns(i).ColumnName = drow("YM") And drJCode("JCode") = drow("JCode") Then
                        drwnew(dtbCrossTablePC.Columns(i).ColumnName) = drow("NDVQty")
                        Exit For
                    End If
                Next
            Next
            dtbCrossTablePC.Rows.Add(drwnew)
        Next
        GridView1.Columns.Clear()
        GridControl1.DataSource = dtbCrossTablePC
        GridControlSetFormat(GridView1, 4)
        FilterJCode()
    End Sub

    Sub sumJCodeProcessM()
        dtbCrossTablePC = New DataTable

        Dim col As DataColumn

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "JCode"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "PrcName"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "SubPrcName"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "JEName"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "JVName"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "Unit"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "DeptName"
        dtbCrossTablePC.Columns.Add(col)

        col = New DataColumn
        col.DataType = GetType(String)
        col.ColumnName = "DeptGSR"
        dtbCrossTablePC.Columns.Add(col)

        Dim param(3) As SqlClient.SqlParameter
        Dim StartDate As DateTime = dtpStartDate.Value.Date
        Dim EndDate As DateTime = dtpEndDate.Value.Date
        param(0) = New SqlClient.SqlParameter("@StartDate", StartDate.ToString("yyyyMMdd"))
        param(1) = New SqlClient.SqlParameter("@EndDate", EndDate.ToString("yyyyMMdd"))

        param(2) = New SqlClient.SqlParameter("@JCode", DBNull.Value)
        param(3) = New SqlClient.SqlParameter("@Action", "YM")

        Dim dt As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodePrcByMonth", param)

        If dt.Rows.Count <> 0 Then
            For Each row As DataRow In dt.Rows
                col = New DataColumn
                col.DataType = GetType(Decimal)
                col.ColumnName = row("YM")
                dtbCrossTablePC.Columns.Add(col)
            Next
        End If

        param(3) = New SqlClient.SqlParameter("@Action", "Qty")

        Dim dtbPara As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodePrcByMonth", param)

        param(3) = New SqlClient.SqlParameter("@Action", "JCode")

        Dim dtJCode As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_SummaryJCodePrcByMonth", param)

        Dim drwnew As DataRow
        For Each drJCode As DataRow In dtJCode.Rows

            Dim rs() As DataRow = dtbCrossTablePC.Select(String.Format("JCode='{0}' and PrcName = '{1}' and SubPrcName = '{2}'", drJCode("JCode"), drJCode("PrcName"), drJCode("SubPrcName")))
            If rs.Length <> 0 Then
                Continue For
            End If

            drwnew = dtbCrossTablePC.NewRow()
            For i As Integer = 0 To dtbCrossTablePC.Columns.Count - 1
                If dtbCrossTablePC.Columns(i).ColumnName = "JCode" Then
                    drwnew("JCode") = drJCode("JCode")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "PrcName" Then
                    drwnew("PrcName") = drJCode("PrcName")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "SubPrcName" Then
                    drwnew("SubPrcName") = drJCode("SubPrcName")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "JEName" Then
                    drwnew("JEName") = drJCode("JEName")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "JVName" Then
                    drwnew("JVName") = drJCode("JVName")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "Unit" Then
                    drwnew("Unit") = drJCode("Unit")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "DeptName" Then
                    drwnew("DeptName") = drJCode("DeptName")
                End If

                If dtbCrossTablePC.Columns(i).ColumnName = "DeptGSR" Then
                    drwnew("DeptGSR") = drJCode("DeptGSR")
                End If

                For Each drow As DataRow In dtbPara.Rows
                    If dtbCrossTablePC.Columns(i).ColumnName = drow("YM") And drJCode("JCode") = drow("JCode") And drJCode("PrcName") = drow("PrcName") And drJCode("SubPrcName") = drow("SubPrcName") Then
                        drwnew(dtbCrossTablePC.Columns(i).ColumnName) = drow("NDVQty")
                        Exit For
                    End If
                Next
            Next
            dtbCrossTablePC.Rows.Add(drwnew)
        Next
        GridView1.Columns.Clear()
        GridControl1.DataSource = dtbCrossTablePC
        GridControlSetFormat(GridView1, 4)
        FilterJCode()
    End Sub

    Sub sumJCodeProcessV()

        Dim param(2) As SqlClient.SqlParameter
        Dim StartDate As DateTime = dtpStartDate.Value.Date
        Dim EndDate As DateTime = dtpEndDate.Value.Date
        param(0) = New SqlClient.SqlParameter("@StartDate", StartDate.ToString("yyyyMMdd"))
        param(1) = New SqlClient.SqlParameter("@EndDate", EndDate.ToString("yyyyMMdd"))

        param(2) = New SqlClient.SqlParameter("@JCode", DBNull.Value)

        dtbCrossTablePC = New DataTable
        dtbCrossTablePC = _db.ExecuteStoreProcedureTB("sp_PCM_VerticalSummary", param)
        GridView1.Columns.Clear()
        GridControl1.DataSource = dtbCrossTablePC
        GridControlSetFormat(GridView1, 4)
        GridControlSetFormatNumber(GridView1, "ExchangeRate", 8)
        FilterJCode()
    End Sub

    Sub FilterJCode()
        If rdoItemCode.Checked Then
            GridView1.ActiveFilterString = "JCode not like '%J%'"
        ElseIf rdoJCode.Checked Then
            GridView1.ActiveFilterString = "JCode like '%J%'"
        End If
    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        GridControlExportExcel(GridView1)
    End Sub


    Private Sub dtpStartDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpStartDate.ValueChanged
        dtpEndDate.Value = dtpStartDate.Value
    End Sub

    Private Sub FrmSummary_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown

        Dim startdate As DateTime = GetStartDate(DateTime.Now.AddDays(-1))
        Dim obj As New FPICS_HolidayDate
        obj.HolidayDate_K = startdate
        While _db.ExistObject(obj)
            obj.HolidayDate_K = obj.HolidayDate_K.AddDays(-1)
        End While
        dtpStartDate.Value = obj.HolidayDate_K
        If AccessibleName <> "" Then
            If AccessibleName = "ItemCode" Then
                rdoItemCode.Checked = True
            ElseIf AccessibleName = "JCode" Then
                rdoJCode.Checked = True
            Else
                rdoAll.Checked = True
            End If
        End If
        mnuShowAll.PerformClick()
    End Sub
End Class