﻿Imports CommonDB
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils.Layout
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports PublicUtility
Public Class FrmPlanHourCIS
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _dtRest As New DataTable
    '--- Vẽ nét liền 2 bảng ---
    Private Sub TablePanel1_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles TablePanel1.Paint
        Dim panel As TablePanel = CType(sender, TablePanel)
        Dim viewInfo As TablePanelObjectInfoArgs = panel.GetViewInfo()
        Using cache As GraphicsCache = New GraphicsCache(e.Graphics)
            Dim gridPen As Pen = cache.GetPen(Color.Gray, 1)
            cache.DrawRectangle(gridPen, viewInfo.DisplayRect)
            DrawHorzGridLines(cache, viewInfo.Layout.Grid, gridPen)
            DrawVertGridLines(cache, viewInfo.Layout.Grid, gridPen)
        End Using
    End Sub
    Private Sub DrawHorzGridLines(ByVal cache As GraphicsCache, ByVal grid As TablePanelGrid, ByVal gridPen As Pen)
        Dim horzLines As TablePanelHorzGridLine() = grid.HorzLines
        For n As Integer = 0 To horzLines.Length - 1
            cache.DrawLine(gridPen, horzLines(n).Start, horzLines(n).[End])
        Next
    End Sub
    Private Sub DrawVertGridLines(ByVal cache As GraphicsCache, ByVal grid As TablePanelGrid, ByVal gridPen As Pen)
        Dim vertLines As TablePanelVertGridLine() = grid.VertLines
        For n As Integer = 0 To vertLines.Length - 1
            cache.DrawLine(gridPen, vertLines(n).Start, vertLines(n).[End])
        Next
    End Sub
    '--- Kết thúc vẽ ---
    Private Sub FrmPlanHourCIS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteNgay.EditValue = Date.Now.Date
        grcProgressBar.Visible = False
        Dim obj As New Main_UserRight
        obj.UserID_K = CurrentUser.UserID
        obj.FormID_K = Tag
        _db.GetObject(obj)
        If obj.IsEdit = False And obj.IsAdmin = False Then
            ViewAccess()
        End If
    End Sub
    Sub ViewAccess()
        btnSavePlan.Enabled = False
    End Sub

    Private Sub btnAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAdd.ItemClick
        GridView1.Columns.Clear()
        If CheckTextLot() = False Then
            txtFromLot.Select()
            Return
        End If
        Dim dtPlan = _db.FillDataTable("
            SELECT ProductCode, RevisionCode, ProcessNumber, ProcessCode, ProcessName, Note, TGGC
            FROM PD_ProcessHourCIS
            ORDER BY ProductCode, RevisionCode DESC, ProcessNumber")
        For r = Integer.Parse(txtFromLot.Text) To Integer.Parse(txtToLot.Text)
            dtPlan.Columns.Add(r.ToString.PadLeft(5, "0"))
        Next
        GridControl1.DataSource = dtPlan
        SetFormatGridView()
    End Sub
    Function CheckTextLot() As Boolean
        If txtFromLot.Text = "" Or txtToLot.Text = "" Then
            ShowWarning("From Lot or To Lot is empty !")
            Return False
        End If
        If Integer.Parse(txtFromLot.Text) > Integer.Parse(txtToLot.Text) Then
            ShowWarning("Invalid Lot !")
            Return False
        End If
        Return True
    End Function

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridControlReadOnly(GridView1, True)
        For Each c As GridColumn In GridView1.Columns
            If c.VisibleIndex > GridView1.Columns("TGGC").VisibleIndex Then
                GridView1.Columns(c.FieldName).OptionsColumn.ReadOnly = False
            End If
        Next
        'If GridView1.Columns("TGGC") IsNot Nothing Then 'Test
        '    GridView1.Columns("TGGC").OptionsColumn.ReadOnly = False 'Test
        'End If 'Test
        GridControlSetColorEdit(GridView1)
    End Sub

    Dim _isEdit As Boolean = True
    Dim _valNhap As Date = Date.MinValue
    Dim _colName As String = ""
    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If _isEdit And GridView1.Editable And e.Column.ReadOnly = False And e.Column.FieldName <> "TGGC" Then
            CalEndTime()
        End If
    End Sub
    Sub CalEndTime()
        _isEdit = False
        For Each c As GridColumn In GridView1.VisibleColumns
            If c.VisibleIndex > GridView1.Columns("TGGC").VisibleIndex Then
                For r = 0 To GridView1.RowCount - 1
                    If IsDate(GetR(r, c)) Then
                        If r = 0 Then
                            _valNhap = GetR(r, c)
                        Else
                            _valNhap = Date.Parse(GetR(r, c)).AddHours(-((r + 1) * 4 + 48))
                            'Mỗi công đoạn tốn trung bình 4 giờ + 2 ngày chờ Khô Khuôn của công đoạn 101
                        End If
                        GoTo NextLine
                    End If
                Next
            End If
        Next
        If _valNhap = Date.MinValue Then
            Return
        End If
NextLine:
        _valNhap = _valNhap.AddDays(-1) 'Lùi 1 ngày cho chắc ăn
        _valNhap = New Date(_valNhap.Year, _valNhap.Month, _valNhap.Day, 10, 0, 0)
        'Setup 10h sáng để dễ so sánh với 2 ca (6:00 -> 22:00) và ca HC (7:30 -> 16:00)
        _colName = GridView1.GetVisibleColumn(GridView1.Columns("TGGC").VisibleIndex + 1).FieldName

        If rdoOffDayOff.Checked And rdo3Ca.Checked Then
            OffDayOff_3Ca()
        ElseIf rdoOffDayOff.Checked And rdo2Ca.Checked Then
            OffDayOff_2Ca()
        ElseIf rdoOffDayOff.Checked And rdoHC.Checked Then
            OffDayOff_HC()
        ElseIf rdoWorkOffDayOffHoliday.Checked And rdo3Ca.Checked Then
            WorkOffDayOffHoliday_3Ca()
        ElseIf rdoWorkOffDayOffHoliday.Checked And rdo2Ca.Checked Then
            WorkOffDayOffHoliday_2Ca()
        ElseIf rdoWorkOffDayOffHoliday.Checked And rdoHC.Checked Then
            WorkOffDayOffHoliday_HC()
        ElseIf rdoWorkFull.Checked And rdo3Ca.Checked Then
            WorkFull_3Ca()
        ElseIf rdoWorkFull.Checked And rdo2Ca.Checked Then
            WorkFull_2Ca()
        ElseIf rdoWorkFull.Checked And rdoHC.Checked Then
            WorkFull_HC()
        End If

        'Tính hàng dọc
        Dim dtDebug = GridControl1.DataSource
        For Each c As GridColumn In GridView1.VisibleColumns
            If c.VisibleIndex > GridView1.Columns("TGGC").VisibleIndex Then
                For r = 0 To GridView1.RowCount - 2
                    'START
                    If Not IsDate(GetR(r, c)) Then Continue For
                    'Tính hàng ngang -> Set cho ô kế bên phải
                    Dim currentVal As Date = GetR(r, c)
                    If r = 0 Then
                        currentVal = GetHandleVal(currentVal, GridView1.GetRowCellValue(r, "TGGC"))
                        SetR(r, GridView1.GetVisibleColumn(c.VisibleIndex + 1), currentVal)
                    Else
                        If Not IsDate(GetR(r - 1, c)) Then
                            currentVal = GetHandleVal(currentVal, GridView1.GetRowCellValue(r, "TGGC"))
                            SetR(r, GridView1.GetVisibleColumn(c.VisibleIndex + 1), currentVal)
                        End If
                    End If
                    dtDebug = GridControl1.DataSource
                    '---------------

                    Dim tggc = GridView1.GetRowCellValue(r + 1, "TGGC")
                    Dim handleVal As Date = GetR(r, c)
                    If GridView1.GetRowCellValue(r, "ProcessCode") = "101" Then
                        handleVal = handleVal.AddDays(2)
                        handleVal = GetHandleVal(handleVal, tggc)
                        handleVal = GetCorrectVal(handleVal, tggc, r + 1, c)
                        SetR(r + 1, c, handleVal)
                        dtDebug = GridControl1.DataSource
                    ElseIf (GridView1.GetRowCellValue(r, "ProcessCode") = "105" Or
                        GridView1.GetRowCellValue(r, "ProcessCode") = "405" Or
                        GridView1.GetRowCellValue(r, "ProcessCode") = "414") And
                            IsDate(GetR(r, GridView1.GetVisibleColumn(c.VisibleIndex - 1))) Then
                        If (GetRD(r, c) - GetRD(r, GridView1.GetVisibleColumn(c.VisibleIndex - 1))).TotalHours <= 6 Then
                            If IsDate(GetR(r + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 1))) And
                                    IsDate(GetR(r + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 2))) Then
                                If GetR(r + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 1)) <>
                                        GetR(r + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 2)) Then
                                    handleVal = GetHandleVal(handleVal, tggc)
                                    SetR(r + 1, c, handleVal)
                                    SetR(r + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 1), handleVal)
                                    GoTo Flag
                                Else
                                    handleVal = GetHandleVal(handleVal, tggc)
                                    handleVal = GetCorrectVal(handleVal, tggc, r + 1, c)
                                    SetR(r + 1, c, handleVal)
                                End If
                            Else
                                handleVal = GetHandleVal(handleVal, tggc)
                                SetR(r + 1, c, handleVal)
                                SetR(r + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 1), handleVal)
                                GoTo Flag
                            End If
                            If False Then
                                dtDebug = GridControl1.DataSource
Flag:
                                For r2 = r + 1 To GridView1.RowCount - 2
                                    Dim tggc2 = GridView1.GetRowCellValue(r2 + 1, "TGGC")
                                    Dim handleVal2 As Date = GetR(r2, GridView1.GetVisibleColumn(c.VisibleIndex - 1))
                                    handleVal2 = GetHandleVal(handleVal2, tggc2)
                                    '------------
                                    If GridView1.GetRowCellValue(r2, "ProcessCode") <> "405" And
                                            GridView1.GetRowCellValue(r2, "ProcessCode") <> "414" Then
                                        handleVal2 = GetCorrectVal(handleVal2, tggc2, r2 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 1))
                                    End If
                                    '------------
                                    SetR(r2 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 1), handleVal2)
                                    'Loop2
                                    If GridView1.GetRowCellValue(r2, "ProcessCode") = "405" Or
                                        GridView1.GetRowCellValue(r2, "ProcessCode") = "414" Then
                                        If IsDate(GetR(r2, GridView1.GetVisibleColumn(c.VisibleIndex - 1))) And
                                                IsDate(GetR(r2, GridView1.GetVisibleColumn(c.VisibleIndex - 2))) Then
                                            If (GetRD(r2, GridView1.GetVisibleColumn(c.VisibleIndex - 1)) -
                                                    GetRD(r2, GridView1.GetVisibleColumn(c.VisibleIndex - 2))).TotalHours <= 6 Then
                                                SetR(r2 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 2), handleVal2)
                                                For r3 = r2 + 1 To GridView1.RowCount - 2
                                                    Dim tggc3 = GridView1.GetRowCellValue(r3 + 1, "TGGC")
                                                    Dim handleVal3 As Date = GetR(r3, GridView1.GetVisibleColumn(c.VisibleIndex - 2))
                                                    handleVal3 = GetHandleVal(handleVal3, tggc3)
                                                    If GridView1.GetRowCellValue(r3, "ProcessCode") <> "414" Then
                                                        handleVal3 = GetCorrectVal(handleVal3, tggc3, r3 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 2))
                                                    End If
                                                    SetR(r3 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 2), handleVal3)
                                                    'Loop3
                                                    If GridView1.GetRowCellValue(r3, "ProcessCode") = "414" Then
                                                        If IsDate(GetR(r3, GridView1.GetVisibleColumn(c.VisibleIndex - 2))) And
                                                                IsDate(GetR(r3, GridView1.GetVisibleColumn(c.VisibleIndex - 3))) Then
                                                            If (GetRD(r3, GridView1.GetVisibleColumn(c.VisibleIndex - 2)) -
                                                                    GetRD(r3, GridView1.GetVisibleColumn(c.VisibleIndex - 3))).TotalHours <= 6 Then
                                                                SetR(r3 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 3), handleVal3)
                                                                For r4 = r3 + 1 To GridView1.RowCount - 2
                                                                    Dim tggc4 = GridView1.GetRowCellValue(r4 + 1, "TGGC")
                                                                    Dim handleVal4 As Date = GetR(r4, GridView1.GetVisibleColumn(c.VisibleIndex - 3))
                                                                    handleVal4 = GetHandleVal(handleVal4, tggc4)
                                                                    handleVal4 = GetCorrectVal(handleVal4, tggc4, r4 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 3))
                                                                    SetR(r4 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 3), handleVal4)
                                                                    'Loop4
                                                                    '---------------
                                                                Next
                                                                SetR(r3 + 2, GridView1.GetVisibleColumn(c.VisibleIndex - 2),
                                                                     GetRD(r3 + 2, GridView1.GetVisibleColumn(c.VisibleIndex - 3)).
                                                                        AddHours(GridView1.GetRowCellValue(r3 + 2, "TGGC")))
                                                                r3 += 1
                                                            Else 'Nếu trừ 2 giá trị > 6h -> Check điều kiện phải lớn hơn ô bên trái
                                                                handleVal3 = GetCorrectVal(handleVal3, tggc3, r3 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 2))
                                                                SetR(r3 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 2), handleVal3)
                                                            End If
                                                        Else 'Nếu cột trước đó không phải là ngày -> Check điều kiện phải lớn hơn ô bên trái
                                                            handleVal3 = GetCorrectVal(handleVal3, tggc3, r3 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 2))
                                                            SetR(r3 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 2), handleVal3)
                                                        End If
                                                    End If
                                                    '----------
                                                    dtDebug = GridControl1.DataSource
                                                Next
                                                SetR(r2 + 2, GridView1.GetVisibleColumn(c.VisibleIndex - 1),
                                                    GetRD(r2 + 2, GridView1.GetVisibleColumn(c.VisibleIndex - 2)).
                                                        AddHours(GridView1.GetRowCellValue(r2 + 2, "TGGC")))
                                                r2 += 1
                                            Else 'Nếu trừ 2 giá trị > 6h -> Check điều kiện phải lớn hơn ô bên trái
                                                handleVal2 = GetCorrectVal(handleVal2, tggc2, r2 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 1))
                                                SetR(r2 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 1), handleVal2)
                                            End If
                                        Else 'Nếu cột trước đó không phải là ngày -> Check điều kiện phải lớn hơn ô bên trái
                                            handleVal2 = GetCorrectVal(handleVal2, tggc2, r2 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 1))
                                            SetR(r2 + 1, GridView1.GetVisibleColumn(c.VisibleIndex - 1), handleVal2)
                                        End If
                                    End If
                                    '----------------
                                Next
                                SetR(r + 2, c, GetRD(r + 2, GridView1.GetVisibleColumn(c.VisibleIndex - 1)).
                                        AddHours(GridView1.GetRowCellValue(r + 2, "TGGC")))
                                r += 1
                                dtDebug = GridControl1.DataSource
                            End If
                        Else 'Trừ 2 giá trị lớn hơn 6h
                            handleVal = GetHandleVal(handleVal, tggc)
                            handleVal = GetCorrectVal(handleVal, tggc, r + 1, c)
                            SetR(r + 1, c, handleVal)
                        End If
                    Else 'Không thuộc 101, 106, 406, 415
                        handleVal = GetHandleVal(handleVal, tggc)
                        handleVal = GetCorrectVal(handleVal, tggc, r + 1, c)
                        SetR(r + 1, c, handleVal)
                    End If
                    dtDebug = GridControl1.DataSource
                Next
            End If
        Next
        _isEdit = True
        SetFormatGridView()

        If rdoWorkOffDayOffHoliday.Checked Or rdoWorkFull.Checked Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@StartDate", _valNhap)
            _dtHoliday = _db.FillDataTable("
                SELECT DATEADD(MINUTE, -1, StartDate) AS StartDate, DATEADD(MINUTE, -1, EndDate) AS EndDate
                FROM FPICS_HolidayDate	
                WHERE HolidayDate >= @StartDate
                AND HolidayDate <= DATEADD(MONTH, 2, @StartDate)", para)
        End If
    End Sub
    Function GetCorrectVal(handleVal As Date, tggc As Double, r As Integer, c As GridColumn) As Date
        If c.VisibleIndex > GridView1.Columns("TGGC").VisibleIndex + 1 Then
            If IsDate(GetR(r, GridView1.GetVisibleColumn(c.VisibleIndex - 1))) Then
                Dim preVal As Date = GetR(r, GridView1.GetVisibleColumn(c.VisibleIndex - 1))
                If handleVal < preVal.AddHours(tggc) Then
                    preVal = preVal.AddHours(tggc)
                    For Each r1 As DataRow In _dtRest.Rows
                        If preVal > r1("StartDate") And preVal <= r1("EndDate") Then
                            Dim timeAdd = (preVal - Date.Parse(r1("StartDate"))).TotalHours
                            preVal = Date.Parse(r1("EndDate")).AddHours(timeAdd)
                        End If
                    Next
                    Return preVal
                End If
            End If
        End If
        Return handleVal
    End Function
    Function GetHandleVal(handleVal As Date, tggc As Double) As Date
        For Each r1 As DataRow In _dtRest.Rows
            If handleVal > r1("StartDate") And handleVal <= r1("EndDate") Then
                handleVal = r1("EndDate")
            End If
        Next
        handleVal = handleVal.AddHours(tggc)
        For Each r1 As DataRow In _dtRest.Rows
            If handleVal > r1("StartDate") And handleVal <= r1("EndDate") Then
                Dim timeAdd = (handleVal - Date.Parse(r1("StartDate"))).TotalHours
                handleVal = Date.Parse(r1("EndDate")).AddHours(timeAdd)
            End If
        Next

        Return handleVal
    End Function
    Private Sub btnRun_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRun.ItemClick
        CalEndTime()
    End Sub
    Sub OffDayOff_3Ca()
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", _valNhap)
        _dtRest = _db.FillDataTable("
                SELECT DATEADD(MINUTE, -1, StartDate) AS StartDate, DATEADD(MINUTE, -1, EndDate) AS EndDate
                FROM FPICS_HolidayDate	
                WHERE HolidayDate >= @StartDate
                AND HolidayDate <= DATEADD(MONTH, 2, @StartDate)", para)
    End Sub
    Sub OffDayOff_2Ca()
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", _valNhap)
        _dtRest = _db.FillDataTable("
            SELECT DATEADD(MINUTE, -1, StartDate) AS StartDate, DATEADD(MINUTE, -1, EndDate) AS EndDate
            FROM FPICS_HolidayDate	
            WHERE HolidayDate >= @StartDate
            AND HolidayDate <= DATEADD(MONTH, 2, @StartDate)", para)
        Dim startDate = _valNhap
        Dim endDate = _valNhap.AddMonths(2)
        While startDate <= endDate
            Dim isHad As Boolean = True
            For Each r As DataRow In _dtRest.Rows
                If startDate < r("StartDate") Or startDate > r("EndDate") Then
                    isHad = False
                Else
                    isHad = True
                    Exit For
                End If
            Next
            If isHad = False Then
                Dim startD = New Date(startDate.Year, startDate.Month, startDate.Day, 22, 0, 0)
                Dim endD = New Date(startDate.AddDays(1).Year, startDate.AddDays(1).Month, startDate.AddDays(1).Day, 6, 0, 0)
                _dtRest.Rows.Add(startD, endD)
            End If
            startDate = startDate.AddDays(1)
        End While
        Dim dtView = _dtRest.DefaultView
        dtView.Sort = "StartDate"
        _dtRest = dtView.ToTable
    End Sub
    Sub OffDayOff_HC()
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", _valNhap)
        _dtRest = _db.FillDataTable("
            SELECT DATEADD(MINUTE, -1, StartDate) AS StartDate, DATEADD(MINUTE, -1, EndDate) AS EndDate
            FROM FPICS_HolidayDate	
            WHERE HolidayDate >= @StartDate
            AND HolidayDate <= DATEADD(MONTH, 2, @StartDate)", para)
        Dim startDate = _valNhap
        Dim endDate = _valNhap.AddMonths(2)
        While startDate <= endDate
            Dim isHad As Boolean = True
            For Each r As DataRow In _dtRest.Rows
                If startDate < r("StartDate") Or startDate > r("EndDate") Then
                    isHad = False
                Else
                    isHad = True
                    Exit For
                End If
            Next
            If isHad = False Then
                Dim startD = New Date(startDate.Year, startDate.Month, startDate.Day, 16, 0, 0)
                Dim endD = New Date(startDate.AddDays(1).Year, startDate.AddDays(1).Month, startDate.AddDays(1).Day, 7, 30, 0)
                _dtRest.Rows.Add(startD, endD)
            End If
            startDate = startDate.AddDays(1)
        End While
        Dim dtView = _dtRest.DefaultView
        dtView.Sort = "StartDate"
        _dtRest = dtView.ToTable
    End Sub
    Sub WorkOffDayOffHoliday_3Ca()
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", _valNhap)
        _dtRest = _db.FillDataTable("
            SELECT DATEADD(MINUTE, -1, StartDate) AS StartDate, DATEADD(MINUTE, -1, EndDate) AS EndDate
            FROM FPICS_HolidayDate	
            WHERE HolidayDate >= @StartDate
            AND HolidayDate <= DATEADD(MONTH, 2, @StartDate)
            AND IsHoliday = 'TRUE'", para)
    End Sub
    Sub WorkOffDayOffHoliday_2Ca()
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", _valNhap)
        _dtRest = _db.FillDataTable("
            SELECT DATEADD(MINUTE, -1, StartDate) AS StartDate, DATEADD(MINUTE, -1, EndDate) AS EndDate
            FROM FPICS_HolidayDate	
            WHERE HolidayDate >= @StartDate
            AND HolidayDate <= DATEADD(MONTH, 2, @StartDate)
            AND IsHoliday = 'TRUE'", para)
        Dim startDate = _valNhap
        Dim endDate = _valNhap.AddMonths(2)
        While startDate <= endDate
            Dim isHad As Boolean = True
            For Each r As DataRow In _dtRest.Rows
                If startDate < r("StartDate") Or startDate > r("EndDate") Then
                    isHad = False
                Else
                    isHad = True
                    Exit For
                End If
            Next
            If isHad = False Then
                Dim startD = New Date(startDate.Year, startDate.Month, startDate.Day, 22, 0, 0)
                Dim endD = New Date(startDate.AddDays(1).Year, startDate.AddDays(1).Month, startDate.AddDays(1).Day, 6, 0, 0)
                _dtRest.Rows.Add(startD, endD)
            End If
            startDate = startDate.AddDays(1)
        End While
        Dim dtView = _dtRest.DefaultView
        dtView.Sort = "StartDate"
        _dtRest = dtView.ToTable
    End Sub
    Sub WorkOffDayOffHoliday_HC()
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", _valNhap)
        _dtRest = _db.FillDataTable("
            SELECT DATEADD(MINUTE, -1, StartDate) AS StartDate, DATEADD(MINUTE, -1, EndDate) AS EndDate
            FROM FPICS_HolidayDate	
            WHERE HolidayDate >= @StartDate
            AND HolidayDate <= DATEADD(MONTH, 2, @StartDate)
            AND IsHoliday = 'TRUE'", para)
        Dim startDate = _valNhap
        Dim endDate = _valNhap.AddMonths(2)
        While startDate <= endDate
            Dim isHad As Boolean = True
            For Each r As DataRow In _dtRest.Rows
                If startDate < r("StartDate") Or startDate > r("EndDate") Then
                    isHad = False
                Else
                    isHad = True
                    Exit For
                End If
            Next
            If isHad = False Then
                Dim startD = New Date(startDate.Year, startDate.Month, startDate.Day, 16, 0, 0)
                Dim endD = New Date(startDate.AddDays(1).Year, startDate.AddDays(1).Month, startDate.AddDays(1).Day, 7, 30, 0)
                _dtRest.Rows.Add(startD, endD)
            End If
            startDate = startDate.AddDays(1)
        End While
        Dim dtView = _dtRest.DefaultView
        dtView.Sort = "StartDate"
        _dtRest = dtView.ToTable
    End Sub
    Sub WorkFull_3Ca()
        _dtRest = New DataTable
    End Sub
    Sub WorkFull_2Ca()
        _dtRest = New DataTable
        _dtRest.Columns.Add("StartDate")
        _dtRest.Columns.Add("EndDate")
        Dim startDate = _valNhap
        Dim endDate = _valNhap.AddMonths(2)
        While startDate <= endDate
            Dim startD = New Date(startDate.Year, startDate.Month, startDate.Day, 22, 0, 0)
            Dim endD = New Date(startDate.AddDays(1).Year, startDate.AddDays(1).Month, startDate.AddDays(1).Day, 6, 0, 0)
            _dtRest.Rows.Add(startD, endD)
            startDate = startDate.AddDays(1)
        End While
    End Sub
    Sub WorkFull_HC()
        _dtRest = New DataTable
        _dtRest.Columns.Add("StartDate")
        _dtRest.Columns.Add("EndDate")
        Dim startDate = _valNhap
        Dim endDate = _valNhap.AddMonths(2)
        While startDate <= endDate
            Dim startD = New Date(startDate.Year, startDate.Month, startDate.Day, 16, 0, 0)
            Dim endD = New Date(startDate.AddDays(1).Year, startDate.AddDays(1).Month, startDate.AddDays(1).Day, 7, 30, 0)
            _dtRest.Rows.Add(startD, endD)
            startDate = startDate.AddDays(1)
        End While
    End Sub
    Function GetR(r As Integer, c As GridColumn) As Object
        Return GridView1.GetRowCellValue(r, c)
    End Function
    Function GetF(c As GridColumn) As Object
        Return GridView1.GetFocusedRowCellValue(c)
    End Function
    Sub SetF(c As GridColumn, value As Object)
        GridView1.SetFocusedRowCellValue(c, value)
    End Sub
    Sub SetR(r As Integer, c As GridColumn, value As Object)
        GridView1.SetRowCellValue(r, c, value)
    End Sub
    Function GetRD(r As Integer, c As GridColumn) As Date
        Return Date.Parse(GridView1.GetRowCellValue(r, c))
    End Function
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridView1.Columns.Clear()
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@PlanDate", dteNgay.DateTime)
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_PD_LoadProcessHourCIS", para)
        SetFormatGridView()
        For Each c As GridColumn In GridView1.VisibleColumns
            If c.VisibleIndex > GridView1.Columns("TGGC").VisibleIndex Then
                For r = 0 To GridView1.RowCount - 1
                    If IsDate(GetR(r, c)) Then
                        If r = 0 Then
                            _valNhap = GetR(r, c)
                        Else
                            _valNhap = Date.Parse(GetR(r, c)).AddHours(-((r + 1) * 4 + 48))
                        End If
                        _valNhap = _valNhap.AddDays(-1)
                        _valNhap = New Date(_valNhap.Year, _valNhap.Month, _valNhap.Day, 10, 0, 0)
                        Dim paraS(0) As SqlClient.SqlParameter
                        paraS(0) = New SqlClient.SqlParameter("@StartDate", _valNhap)
                        _dtHoliday = _db.FillDataTable("
                            SELECT DATEADD(MINUTE, -1, StartDate) AS StartDate, DATEADD(MINUTE, -1, EndDate) AS EndDate
                            FROM FPICS_HolidayDate	
                            WHERE HolidayDate >= @StartDate
                            AND HolidayDate <= DATEADD(MONTH, 2, @StartDate)", paraS)
                        Exit Sub
                    End If
                Next
            End If
        Next
    End Sub
    Sub SetFormatGridView()
        GridControlSetFormat(GridView1, 6)
        For Each c As GridColumn In GridView1.Columns
            If c.VisibleIndex > GridView1.Columns("TGGC").VisibleIndex Then
                GridView1.Columns(c.FieldName).Width = 90
                Dim editDate As New RepositoryItemDateEdit
                editDate.EditMask = "HH:mm dd-MMM"
                editDate.Mask.UseMaskAsDisplayFormat = True
                For Each d As String In c.FieldName.Split(",")
                    With GridView1.Columns(d)
                        .ColumnEdit = editDate
                    End With
                Next
            End If
        Next
    End Sub

    Private Sub btnSavePlan_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSavePlan.ItemClick
        Try
            Dim succ = 0
            _db.BeginTransaction()
            _db.ExecuteNonQuery(String.Format("DELETE PD_PlanHourCIS
                                                WHERE PlanDate = '{0}'",
                                                dteNgay.DateTime.ToString("yyyyMMdd")))
            For Each c As GridColumn In GridView1.VisibleColumns
                If c.VisibleIndex > GridView1.Columns("TGGC").VisibleIndex Then
                    For r = 0 To GridView1.RowCount - 1
                        Dim obj As New PD_PlanHourCIS
                        obj.PlanDate_K = dteNgay.DateTime
                        obj.ProductCode_K = GridView1.GetRowCellValue(r, "ProductCode")
                        obj.RevisionCode_K = "01"
                        obj.ProcessNumber_K = GridView1.GetRowCellValue(r, "ProcessNumber")
                        obj.ProcessCode = GridView1.GetRowCellValue(r, "ProcessCode")
                        obj.LotNumber_K = c.FieldName
                        If IsDate(GetR(r, c)) Then
                            obj.EndTime = GetR(r, c)
                        End If
                        obj.CreateUser = CurrentUser.UserID
                        obj.CreateDate = DateTime.Now
                        If obj.EndTime > Date.MinValue Then
                            If _db.ExistObject(obj) Then
                                _db.Update(obj)
                            Else
                                _db.Insert(obj)
                                succ += 1
                            End If
                        Else
                            _db.Delete(obj)
                        End If
                    Next
                End If
            Next
            _db.Commit()
            ShowSuccess(succ)
        Catch ex As Exception
            _db.RollBack()
            ShowWarning(ex.Message)
        End Try
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
        Dim dtImp = ImportEXCEL(True)
        If dtImp.Rows.Count > 0 Then
            GridView1.Columns.Clear()
            grcProgressBar.Visible = True
            Dim dtPlan = _db.FillDataTable("
            SELECT ProductCode, RevisionCode, ProcessNumber, ProcessCode, ProcessName, Note, TGGC
            FROM PD_ProcessHourCIS
            ORDER BY ProductCode, RevisionCode DESC, ProcessNumber")

            ProgressBarControl1.Properties.Step = 1
            ProgressBarControl1.Properties.PercentView = True
            ProgressBarControl1.Properties.Maximum = dtImp.Rows.Count
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Properties.ShowTitle = True
            For Each c As DataColumn In dtImp.Columns
                If dtImp.Columns.IndexOf(c.ColumnName) > dtImp.Columns.IndexOf("TGGC") Then
                    dtPlan.Columns.Add(c.ColumnName.ToString.PadLeft(5, "0"))
                End If
                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()
            Next
            ProgressBarControl1.EditValue = 0

            GridControl1.DataSource = dtPlan
            GridControlSetFormat(GridView1, 6)
            SetFormatGridView()
            grcProgressBar.Visible = False
        End If
    End Sub

    Private Sub btnDeleteRow_Click(sender As Object, e As EventArgs) Handles btnDeleteRow.Click
        For Each r As Integer In GridView1.GetSelectedRows
            For Each c As GridColumn In GridView1.GetSelectedCells(r)
                GridView1.SetRowCellValue(r, c, DBNull.Value)
            Next
        Next
    End Sub

    Dim _dtHoliday As New DataTable
    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If _valNhap > Date.MinValue Then
            If e.Column.VisibleIndex > GridView1.Columns("TGGC").VisibleIndex Then
                If IsDate(e.CellValue) Then
                    For Each r As DataRow In _dtHoliday.Rows
                        If e.CellValue > r("StartDate") And e.CellValue <= r("EndDate") Then
                            e.Appearance.BackColor = Color.Orange
                            e.Appearance.ForeColor = Color.White
                        End If
                    Next
                End If
            End If
        End If
    End Sub
End Class