﻿Imports System.Drawing
Imports System.Windows.Forms
Imports CommonDB
Imports DevExpress
Imports DevExpress.Utils
Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class FrmChartsNew
    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Public _tb As DataTable
    Public _title As String = ""
    Public _target As Decimal = 0
    Public _tbNot0641 As DataTable
    Public _LoaiChart As String = ""
    Public _dtSort As DataTable

    <Obsolete>
    Public Sub LoadChartTLCP(dt As DataTable)
        _LoaiChart = "LoadChartTLCP"
        'CHART
        ChartControl1.Series.Clear()

        'Tạo mới Series
        Dim seriesLine As New Series("TLCP", ViewType.Line)
        For index = 0 To dt.Rows.Count - 1
            seriesLine.Points.AddPoint(dt.Rows(index)("Customer"), Decimal.Round(dt.Rows(index)("TLCP"), 2))
        Next

        'Them series vao chartcontrol
        ChartControl1.Series.Add(seriesLine)

        Dim chartTitles As New ChartTitle
        chartTitles.Text = _title
        chartTitles.Alignment = StringAlignment.Center
        ChartControl1.Titles.Clear()
        ChartControl1.Titles.Add(chartTitles)

        seriesLine.View.Color = Color.Red

        Dim diagram As XYDiagram = CType(ChartControl1.Diagram, XYDiagram)
        diagram.AxisY.Title.Text = "[%]"
        diagram.AxisY.Title.Visible = True
        diagram.AxisY.Title.Alignment = StringAlignment.Far
        diagram.AxisY.WholeRange.SideMarginsValue = 0
        diagram.AxisY.WholeRange.SetMinMaxValues(70, 100)

        'diagram.AxisX.Label.Font = New Font(diagram.AxisX.Label.Font.FontFamily, 16)
        diagram.AxisX.QualitativeScaleOptions.AutoGrid = False

        seriesLine.LabelsVisibility = DefaultBoolean.True
        seriesLine.Label.Border.Color = Color.Black
        seriesLine.Label.TextColor = Color.Black

        CType(seriesLine.View, LineSeriesView).MarkerVisibility = DefaultBoolean.True
    End Sub

    <Obsolete>
    Public Sub LoadChartDefectDay(ByVal _target As Decimal, dt As DataTable)
        _LoaiChart = "LoadChartDefectDay"
        ChartControl1.Series.Clear()
        'Chart Bar
        Dim index As Integer = 1
        For Each c As DataColumn In dt.Columns
            If dt.Columns.IndexOf(c.ColumnName) > dt.Columns.IndexOf("TLCP") Then
                If index <= 40 Then
                    Dim seriesName As String = c.ColumnName
                    ChartControl1.Series.Add(seriesName, ViewType.StackedBar)
                    For Each r As DataRow In dt.Rows
                        Dim YVal As Decimal = 0
                        If r(c.ColumnName) IsNot DBNull.Value Then
                            YVal = r(c.ColumnName)
                        Else
                            YVal = 0
                        End If
                        Dim str As String = CType(r("Thang"), String)
                        ChartControl1.Series(seriesName).Points.Add(New SeriesPoint(str, CType(YVal, Integer)))
                        ChartControl1.Series(seriesName).LabelsVisibility = Utils.DefaultBoolean.True
                    Next
                End If
                index += 1
            End If
        Next

        'Chart Target
        Dim seriesTarget As New Series("Target", ViewType.Line)
        For r = 0 To _tb.Rows.Count - 1
            seriesTarget.Points.AddPoint(_tb.Rows(r)(1), _target)
        Next
        ChartControl1.Series.Add(seriesTarget)

        'Thêm Diagram cho seriesLineRight vào bên phải Chart
        Dim seconY As New SecondaryAxisY()
        CType(ChartControl1.Diagram, XYDiagram).SecondaryAxesY.Clear()
        CType(ChartControl1.Diagram, XYDiagram).SecondaryAxesY.Add(seconY)
        seconY.WholeRange.SideMarginsValue = 0
        seconY.WholeRange.SetMinMaxValues(80, 100)
        CType(seriesTarget.View, LineSeriesView).AxisY = seconY
        seriesTarget.LabelsVisibility = DefaultBoolean.True
        seriesTarget.View.Color = Color.Red

        seconY.Title.Text = "[% OK]"
        seconY.Title.Visible = True
        seconY.Title.Alignment = StringAlignment.Center
        Dim diagram As XYDiagram = CType(ChartControl1.Diagram, XYDiagram)
        diagram.AxisY.Title.Text = "[% NG]"
        diagram.AxisY.Title.Visible = True
        diagram.AxisY.Title.Alignment = StringAlignment.Center

        'diagram.AxisX.Label.Font = New Font(diagram.AxisX.Label.Font.FontFamily, 16)
        diagram.AxisX.QualitativeScaleOptions.AutoGrid = False

        'Chart Complete Yield
        Dim seriesYield As New Series("Complete Yield", ViewType.Line)
        For r = 0 To _tb.Rows.Count - 1
            seriesYield.Points.AddPoint(_tb.Rows(r)(1), _tb.Rows(r)("TLCP"))
        Next
        ChartControl1.Series.Add(seriesYield)
        CType(seriesYield.View, LineSeriesView).AxisY = seconY
        seriesYield.LabelsVisibility = DefaultBoolean.True
        seriesYield.View.Color = Color.Blue

        'Title
        Dim chartTitles As New ChartTitle
        chartTitles.Text = _title
        chartTitles.Alignment = StringAlignment.Center
        ChartControl1.Titles.Clear()
        ChartControl1.Titles.Add(chartTitles)
    End Sub

    Private Sub FrmChartsNew_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    <Obsolete>
    Public Sub LoadChartDefectQuy(dt As DataTable)
        _LoaiChart = "LoadChartDefectQuy"
        ChartControl1.Series.Clear()
        If dt.Rows(0)(0) = "Target" Then
            For r = 1 To dt.Rows.Count - 1
                Dim max As Integer = 1
                If dt.Rows(r)(0).ToString.Contains("Q") Then
                    Dim seriesName As String = CType(dt.Rows(r)(0), String)
                    ChartControl1.Series.Add(seriesName, ViewType.Bar)
                    For Each c As DataColumn In dt.Columns
                        If dt.Columns.IndexOf(c.ColumnName) > dt.Columns.IndexOf("TLCP") Then
                            If max <= 40 Then
                                Dim YVal As Decimal = 0
                                If dt.Rows(r)(c) IsNot DBNull.Value Then
                                    YVal = dt.Rows(r)(c)
                                End If
                                Dim str As String = "'" + c.ColumnName.ToString
                                ChartControl1.Series(seriesName).Points.AddPoint(str, YVal)
                            End If
                            max += 1
                        End If
                    Next
                    'ChartControl1.Series(seriesName).LabelsVisibility = Utils.DefaultBoolean.True
                    'Dim label As BarSeriesLabel = TryCast(ChartControl1.Series(seriesName).Label, BarSeriesLabel)
                    'label.Position = BarSeriesLabelPosition.Top

                End If
            Next
            'Them line
            Dim maxLine As Integer = 1
            Dim seriesNameLine As String = "Target"
            ChartControl1.Series.Add(seriesNameLine, ViewType.Line)
            For Each c As DataColumn In dt.Columns
                If dt.Columns.IndexOf(c.ColumnName) > dt.Columns.IndexOf("TLCP") Then
                    If maxLine <= 40 Then
                        Dim YVal As Decimal = 0
                        If dt.Rows(0)(c) IsNot DBNull.Value Then
                            YVal = dt.Rows(0)(c)
                        End If
                        Dim str As String = "'" + c.ColumnName.ToString
                        ChartControl1.Series(seriesNameLine).Points.AddPoint(str, YVal)
                    End If
                    maxLine += 1
                End If
            Next
            ChartControl1.Series(seriesNameLine).View.Color = Color.Blue
            '----------------------
        Else
            For r = 0 To dt.Rows.Count - 1
                Dim max As Integer = 1
                If dt.Rows(r)(0).ToString.Contains("Q") Then
                    Dim seriesName As String = CType(dt.Rows(r)(0), String)
                    ChartControl1.Series.Add(seriesName, ViewType.Bar)
                    For Each c As DataColumn In dt.Columns
                        If dt.Columns.IndexOf(c.ColumnName) > dt.Columns.IndexOf("TLCP") Then
                            If max <= 40 Then
                                Dim YVal As Decimal = 0
                                If dt.Rows(r)(c) IsNot DBNull.Value Then
                                    YVal = dt.Rows(r)(c)
                                End If
                                Dim str As String = "'" + c.ColumnName.ToString
                                ChartControl1.Series(seriesName).Points.AddPoint(str, YVal)
                            End If
                            max += 1
                        End If
                    Next
                    'ChartControl1.Series(seriesName).LabelsVisibility = Utils.DefaultBoolean.True
                    'Dim label As BarSeriesLabel = TryCast(ChartControl1.Series(seriesName).Label, BarSeriesLabel)
                    'label.Position = BarSeriesLabelPosition.Top

                End If
            Next
        End If

        Dim diagram As XYDiagram = CType(ChartControl1.Diagram, XYDiagram)
        diagram.AxisY.Title.Text = "[% NG]"
        diagram.AxisY.Title.Visible = True
        diagram.AxisY.Title.Alignment = StringAlignment.Center

        'diagram.AxisX.Label.Font = New Font(diagram.AxisX.Label.Font.FontFamily, 16)
        diagram.AxisX.QualitativeScaleOptions.AutoGrid = False

        Dim chartTitles As New ChartTitle
        chartTitles.Text = _title
        chartTitles.Alignment = StringAlignment.Center
        ChartControl1.Titles.Clear()
        ChartControl1.Titles.Add(chartTitles)
    End Sub

    <Obsolete>
    Public Sub LoadChartDefectTuanThang(dt As DataTable)
        _LoaiChart = "LoadChartDefectTuanThang"
        ChartControl1.Series.Clear()
        If dt.Rows(0)(0) = "Target" Then
            For r = 1 To dt.Rows.Count - 1
                Dim max As Integer = 1
                Dim seriesName As String = CType(dt.Rows(r)(0), String)
                ChartControl1.Series.Add(seriesName, ViewType.Bar)

                For Each c As DataColumn In dt.Columns
                    If dt.Columns.IndexOf(c.ColumnName) > dt.Columns.IndexOf("TLCP") Then
                        If max <= 40 Then
                            Dim YVal As Decimal = 0
                            If dt.Rows(r)(c) IsNot DBNull.Value Then
                                YVal = dt.Rows(r)(c)
                            End If
                            Dim str As String = "'" + c.ColumnName.ToString
                            ChartControl1.Series(seriesName).Points.AddPoint(str, YVal)
                        End If
                        max += 1
                    End If
                Next
                'ChartControl1.Series(seriesName).LabelsVisibility = Utils.DefaultBoolean.True
                'Dim label As BarSeriesLabel = TryCast(ChartControl1.Series(seriesName).Label, BarSeriesLabel)
                'label.Position = BarSeriesLabelPosition.Top
            Next
            'Them line
            Dim maxLine As Integer = 1
            Dim seriesNameLine As String = "Target"
            ChartControl1.Series.Add(seriesNameLine, ViewType.Line)
            For Each c As DataColumn In dt.Columns
                If dt.Columns.IndexOf(c.ColumnName) > dt.Columns.IndexOf("TLCP") Then
                    If maxLine <= 40 Then
                        Dim YVal As Decimal = 0
                        If dt.Rows(0)(c) IsNot DBNull.Value Then
                            YVal = dt.Rows(0)(c)
                        End If
                        Dim str As String = "'" + c.ColumnName.ToString
                        ChartControl1.Series(seriesNameLine).Points.AddPoint(str, YVal)
                    End If
                    maxLine += 1
                End If
            Next
            ChartControl1.Series(seriesNameLine).View.Color = Color.Blue
            '----------------------
        Else
            For r = 0 To dt.Rows.Count - 1
                Dim max As Integer = 1
                Dim seriesName As String = CType(dt.Rows(r)(0), String)
                ChartControl1.Series.Add(seriesName, ViewType.Bar)
                For Each c As DataColumn In dt.Columns
                    If dt.Columns.IndexOf(c.ColumnName) > dt.Columns.IndexOf("TLCP") Then
                        If max <= 40 Then
                            Dim YVal As Decimal = 0
                            If dt.Rows(r)(c) IsNot DBNull.Value Then
                                YVal = dt.Rows(r)(c)
                            End If
                            Dim str As String = "'" + c.ColumnName.ToString
                            ChartControl1.Series(seriesName).Points.AddPoint(str, YVal)
                        End If
                        max += 1
                    End If
                Next
                'ChartControl1.Series(seriesName).LabelsVisibility = Utils.DefaultBoolean.True
                'Dim label As BarSeriesLabel = TryCast(ChartControl1.Series(seriesName).Label, BarSeriesLabel)
                'label.Position = BarSeriesLabelPosition.Top
            Next
        End If

        Dim diagram As XYDiagram = CType(ChartControl1.Diagram, XYDiagram)
        diagram.AxisY.Title.Text = "[% NG]"
        diagram.AxisY.Title.Visible = True
        diagram.AxisY.Title.Alignment = StringAlignment.Center

        'diagram.AxisX.Label.Font = New Font(diagram.AxisX.Label.Font.FontFamily, 16)
        diagram.AxisX.QualitativeScaleOptions.AutoGrid = False

        Dim chartTitles As New ChartTitle
        chartTitles.Text = _title
        chartTitles.Alignment = StringAlignment.Center
        ChartControl1.Titles.Clear()
        ChartControl1.Titles.Add(chartTitles)
    End Sub

    <Obsolete>
    Public Sub ChartDongHang(dt As DataTable)
        _LoaiChart = "LoadChartDongHang"
        ChartControl1.Series.Clear()

        'Chart StackedBar
        Dim index As Integer = 1
        For Each c As DataColumn In dt.Columns
            If dt.Columns.IndexOf(c.ColumnName) > dt.Columns.IndexOf("TLCP") Then
                If index <= 40 Then
                    Dim seriesName As String = c.ColumnName
                    ChartControl1.Series.Add(seriesName, ViewType.StackedBar)
                    For Each r As DataRow In dt.Rows
                        Dim YVal As Decimal = 0
                        If IsNumeric(r(c.ColumnName)) Then
                            If r(c.ColumnName) > 0.05 Then
                                YVal = r(c.ColumnName)
                            Else
                                Continue For
                            End If
                        Else
                            Continue For
                        End If
                        Dim str As String = CType(r("DongHang"), String)
                        ChartControl1.Series(seriesName).Points.Add(New SeriesPoint(str, CType(YVal, Decimal)))
                        'ChartControl1.Series(seriesName).LabelsVisibility = Utils.DefaultBoolean.True
                    Next
                End If
                index += 1
            End If
        Next

        'ChartLine
        Dim seriesLot As New Series("Số Lot", ViewType.Line)
        For Each r As DataRow In dt.Rows
            seriesLot.Points.AddPoint(r(0), r(1))
        Next
        ChartControl1.Series.Add(seriesLot)

        Dim seconY As New SecondaryAxisY()
        CType(ChartControl1.Diagram, XYDiagram).SecondaryAxesY.Clear()
        CType(ChartControl1.Diagram, XYDiagram).SecondaryAxesY.Add(seconY)
        seconY.WholeRange.SideMarginsValue = 0
        CType(seriesLot.View, LineSeriesView).AxisY = seconY
        seriesLot.LabelsVisibility = DefaultBoolean.True
        seriesLot.View.Color = Color.Blue

        seconY.Title.Text = "[Số Lot]"
        seconY.Title.Visible = True
        seconY.Title.Alignment = StringAlignment.Center
        seconY.Title.TextColor = Color.Blue

        Dim diagram As XYDiagram = CType(ChartControl1.Diagram, XYDiagram)
        diagram.AxisY.Title.Text = "[% NG]"
        diagram.AxisY.Title.Visible = True
        diagram.AxisY.Title.Alignment = StringAlignment.Center
        diagram.AxisY.Title.TextColor = Color.Red

        'diagram.AxisX.Label.Font = New Font(diagram.AxisX.Label.Font.FontFamily, 16)
        diagram.AxisX.QualitativeScaleOptions.AutoGrid = False

        'Title
        Dim chartTitles As New ChartTitle
        chartTitles.Text = _title
        chartTitles.Alignment = StringAlignment.Center
        ChartControl1.Titles.Clear()
        ChartControl1.Titles.Add(chartTitles)
    End Sub

    <Obsolete>
    Public Sub ChartDongHangDetail(dt As DataTable)
        _LoaiChart = "LoadChartDongHangDetail"
        ChartControl1.Series.Clear()

        'Chart StackedBar
        Dim index As Integer = 1
        For Each c As DataColumn In dt.Columns
            If dt.Columns.IndexOf(c.ColumnName) > dt.Columns.IndexOf("TLCP") Then
                If index <= 40 Then
                    Dim seriesName As String = c.ColumnName
                    ChartControl1.Series.Add(seriesName, ViewType.StackedBar)
                    For Each r As DataRow In dt.Rows
                        Dim YVal As Decimal = 0
                        If IsNumeric(r(c.ColumnName)) Then
                            If r(c.ColumnName) > 0.05 Then
                                YVal = r(c.ColumnName)
                            Else
                                Continue For
                            End If
                        Else
                            Continue For
                        End If
                        Dim str As String = "'" + CType(r("ProductCode"), String)
                        ChartControl1.Series(seriesName).Points.Add(New SeriesPoint(str, CType(YVal, Decimal)))
                    Next
                End If
                index += 1
            End If
        Next

        'ChartLine
        Dim seriesLot As New Series("Số Lot", ViewType.Line)
        For Each r As DataRow In dt.Rows
            seriesLot.Points.AddPoint(CStr("'" + r(1)), r(2))
        Next
        ChartControl1.Series.Add(seriesLot)

        Dim seconY As New SecondaryAxisY()
        CType(ChartControl1.Diagram, XYDiagram).SecondaryAxesY.Clear()
        CType(ChartControl1.Diagram, XYDiagram).SecondaryAxesY.Add(seconY)
        seconY.WholeRange.SideMarginsValue = 0
        CType(seriesLot.View, LineSeriesView).AxisY = seconY
        seriesLot.LabelsVisibility = DefaultBoolean.True
        seriesLot.View.Color = Color.Blue

        seconY.Title.Text = "[Số Lot]"
        seconY.Title.Visible = True
        seconY.Title.Alignment = StringAlignment.Center
        seconY.Title.TextColor = Color.Blue

        Dim diagram As XYDiagram = CType(ChartControl1.Diagram, XYDiagram)
        diagram.AxisY.Title.Text = "[% NG]"
        diagram.AxisY.Title.Visible = True
        diagram.AxisY.Title.Alignment = StringAlignment.Center
        diagram.AxisY.Title.TextColor = Color.Red

        'diagram.AxisX.Label.Font = New Font(diagram.AxisX.Label.Font.FontFamily, 16)
        diagram.AxisX.QualitativeScaleOptions.AutoGrid = False

        ChartControl1.SeriesSorting = SortingMode.Descending
        ChartControl1.SeriesTemplate.SeriesPointsSorting = SortingMode.Descending

        'Title
        Dim chartTitles As New ChartTitle
        chartTitles.Text = _title
        chartTitles.Alignment = StringAlignment.Center
        ChartControl1.Titles.Clear()
        ChartControl1.Titles.Add(chartTitles)
    End Sub

    <Obsolete>
    Public Sub ChartDefectDongHang(dt As DataTable)
        _LoaiChart = "LoadChartDefectDongHang"
        ChartControl1.Series.Clear()

        For r = 0 To dt.Rows.Count - 1
            Dim max As Integer = 1
            Dim seriesName As String = CType(dt.Rows(r)("ProductCode"), String)
            ChartControl1.Series.Add(seriesName, ViewType.Bar)
            For Each c As DataColumn In dt.Columns
                If dt.Columns.IndexOf(c.ColumnName) > dt.Columns.IndexOf("TLCP") Then
                    If max <= 40 Then
                        Dim YVal As Decimal = 0
                        If dt.Rows(r)(c) IsNot DBNull.Value Then
                            YVal = dt.Rows(r)(c)
                        End If
                        Dim str As String = "'" + c.ColumnName.ToString
                        ChartControl1.Series(seriesName).Points.AddPoint(str, YVal)
                    End If
                    max += 1
                End If
            Next
        Next

        Dim diagram As XYDiagram = CType(ChartControl1.Diagram, XYDiagram)
        diagram.AxisY.Title.Text = "[% NG]"
        diagram.AxisY.Title.Visible = True
        diagram.AxisY.Title.Alignment = StringAlignment.Center

        'diagram.AxisX.Label.Font = New Font(diagram.AxisX.Label.Font.FontFamily, 16)
        diagram.AxisX.QualitativeScaleOptions.AutoGrid = False

        Dim chartTitles As New ChartTitle
        chartTitles.Text = _title
        chartTitles.Alignment = StringAlignment.Center
        ChartControl1.Titles.Clear()
        ChartControl1.Titles.Add(chartTitles)
    End Sub

    <Obsolete>
    Private Sub chbError0641_CheckedChanged(sender As Object, e As EventArgs) Handles chbError0641.CheckedChanged
        If chbError0641.Checked Then
            _tbNot0641 = _tb.Copy
            If _tbNot0641.Columns.Contains("0641") Then
                _tbNot0641.Columns.Remove("0641")
                If _LoaiChart = "LoadChartTLCP" Then
                    LoadChartTLCP(_tbNot0641)
                ElseIf _LoaiChart = "LoadChartDefectDay" Then
                    LoadChartDefectDay(_target, _tbNot0641)
                ElseIf _LoaiChart = "LoadChartDefectQuy" Then
                    LoadChartDefectQuy(_tbNot0641)
                ElseIf _LoaiChart = "LoadChartDefectTuanThang" Then
                    LoadChartDefectTuanThang(_tbNot0641)
                ElseIf _LoaiChart = "LoadChartDongHang" Then
                    ChartDongHang(_tbNot0641)
                ElseIf _LoaiChart = "LoadChartDongHangDetail" Then
                    ChartDongHangDetail(_tbNot0641)
                ElseIf _LoaiChart = "LoadChartDefectDongHang" Then
                    ChartDefectDongHang(_tbNot0641)
                End If
            Else
                ShowWarning("Không có lỗi 0641 !")
            End If
        Else
            If _LoaiChart = "LoadChartTLCP" Then
                LoadChartTLCP(_tb)
            ElseIf _LoaiChart = "LoadChartDefectDay" Then
                LoadChartDefectDay(_target, _tb)
            ElseIf _LoaiChart = "LoadChartDefectQuy" Then
                LoadChartDefectQuy(_tb)
            ElseIf _LoaiChart = "LoadChartDefectTuanThang" Then
                LoadChartDefectTuanThang(_tb)
            ElseIf _LoaiChart = "LoadChartDongHang" Then
                ChartDongHang(_tb)
            ElseIf _LoaiChart = "LoadChartDongHangDetail" Then
                ChartDongHangDetail(_tb)
            ElseIf _LoaiChart = "LoadChartDefectDongHang" Then
                ChartDefectDongHang(_tb)
            End If
        End If
    End Sub

    Private Sub FrmChartsNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim listColumn As New List(Of String)
        If _tb.Rows.Count > 0 Then
            For Each c As DataColumn In _tb.Columns
                If _tb.Columns.IndexOf(c.ColumnName) > _tb.Columns.IndexOf("TLCP") Then
                    listColumn.Add(c.ColumnName)
                End If
            Next
        End If
        listColumn.Sort()
        listColumn.Reverse()
        For Each value In listColumn
            ccbbError.Properties.Items.Add(value, False)
        Next
    End Sub

    <Obsolete>
    Private Sub ccbbError_EditValueChanged(sender As Object, e As EventArgs) Handles ccbbError.EditValueChanged
        If _tb IsNot Nothing Then
            _dtSort = _tb.Copy
            If ccbbError.Text <> "" Then
                For Each item As CheckedListBoxItem In ccbbError.Properties.Items
                    If item.CheckState = CheckState.Unchecked Then
                        _dtSort.Columns.Remove(item.Value.ToString)
                    End If
                Next
                '------------------
                If _LoaiChart = "LoadChartTLCP" Then
                    LoadChartTLCP(_dtSort)
                ElseIf _LoaiChart = "LoadChartDefectDay" Then
                    LoadChartDefectDay(_target, _dtSort)
                ElseIf _LoaiChart = "LoadChartDefectQuy" Then
                    LoadChartDefectQuy(_dtSort)
                ElseIf _LoaiChart = "LoadChartDefectTuanThang" Then
                    LoadChartDefectTuanThang(_dtSort)
                ElseIf _LoaiChart = "LoadChartDongHang" Then
                    ChartDongHang(_dtSort)
                ElseIf _LoaiChart = "LoadChartDongHangDetail" Then
                    ChartDongHangDetail(_dtSort)
                ElseIf _LoaiChart = "LoadChartDefectDongHang" Then
                    ChartDefectDongHang(_dtSort)
                End If
            End If
        End If
    End Sub
End Class