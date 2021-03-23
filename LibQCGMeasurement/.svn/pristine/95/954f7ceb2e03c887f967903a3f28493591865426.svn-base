Imports System.Drawing
Imports System.Windows.Forms
Imports CommonDB
Imports DevExpress.XtraCharts
'Imports System
'Imports System.Collections.Generic
Imports System.Drawing.Imaging
Imports System.IO
'Imports System.Windows.Forms.DataVisualization.Charting
Imports PublicUtility
Imports System.Windows.Media.Imaging
Imports System.Windows.Media

Public Class FrmCharts_2
    Public _tb As DataTable
    Public _title As String
    Public _NgayDo As DateTime
    Public _ProductCode As String
    Public _CongDoan As String
    Public _LotNo As String
    Public Sub Chart()
        ChartControl1.Series.Clear()

        Dim seriesAveSpec As String = "Ave - Spec"
        Dim seriesMaxMin As String = "Max - min"
        Dim seriesInternalSpec As String = "Internal Spec.(Max - min)"
        ChartControl1.Series.Add(seriesAveSpec, ViewType.Bar)
        ChartControl1.Series.Add(seriesMaxMin, ViewType.Line)
        ChartControl1.Series.Add(seriesInternalSpec, ViewType.Line)
        For r = 0 To _tb.Rows.Count - 1
            ChartControl1.Series(seriesAveSpec).Points.AddPoint(_tb.Rows(r)("Item").ToString, _tb.Rows(r)("TrungBinhTruSpec"))
            ChartControl1.Series(seriesMaxMin).Points.AddPoint(_tb.Rows(r)("Item").ToString, _tb.Rows(r)("MaxTruMin"))
            ChartControl1.Series(seriesInternalSpec).Points.AddPoint(_tb.Rows(r)("Item").ToString, 0.008)
        Next
        Dim chartTitles As New ChartTitle
        chartTitles.Text = _title
        chartTitles.Alignment = StringAlignment.Center
        ChartControl1.Titles.Add(chartTitles)

        Dim diagram As XYDiagram = CType(ChartControl1.Diagram, XYDiagram)
        diagram.AxisY.Title.Text = "mm"
        diagram.AxisY.Title.Visible = True
        diagram.AxisY.Title.Alignment = StringAlignment.Center
        diagram.AxisX.QualitativeScaleOptions.AutoGrid = False

        ChartControl1.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center
        ChartControl1.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside
        ChartControl1.Legend.Direction = LegendDirection.LeftToRight
        ChartControl1.Legend.HorizontalIndent = 60
    End Sub

    Private Sub FrmCharts_2_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        ElseIf e.Control And e.KeyCode = Keys.C Then
            btnCopy.PerformClick()
        End If
    End Sub

    Private Sub btnSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSave.ItemClick
        Dim openSave As New SaveFileDialog
        openSave.FileName = String.Format("{0}.png", (_ProductCode + "-" + _CongDoan + "-" + _LotNo + "-" + _NgayDo.ToString("dd-MM-yyyy")))
        If openSave.ShowDialog = DialogResult.OK Then
            Dim str As String = ""
            ChartControl1.ExportToImage(openSave.OpenFile, ImageFormat.Png)
        End If
    End Sub

    Private Sub btnCopy_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCopy.ItemClick
        Dim ms As New MemoryStream
        ChartControl1.ExportToImage(ms, ImageFormat.Png)
        Dim bm As New Bitmap(ms)
        Clipboard.SetImage(bm)
    End Sub
End Class