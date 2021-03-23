Imports DevExpress.Utils
Imports DevExpress.XtraCharts
Public Class FrmChart
    Public _dt As DataTable
    Public _title As String
    Public Sub ChartSum()
        ChartControl1.Series.Clear()

        Dim srNameLot As String = "Tổng số lot phát hiện"
        ChartControl1.Series.Add(srNameLot, ViewType.Bar)
        For Each r As DataRow In _dt.Rows
            ChartControl1.Series(srNameLot).Points.AddPoint(r("CongDoan"), r("TongSoLotPhatHien"))
        Next
        ChartControl1.Series(srNameLot).LabelsVisibility = DefaultBoolean.True
        Dim labelLot As BarSeriesLabel = TryCast(ChartControl1.Series(srNameLot).Label, BarSeriesLabel)
        labelLot.Position = BarSeriesLabelPosition.Top

        Dim srNameLoi As String = "Tổng số lượng lỗi"
        ChartControl1.Series.Add(srNameLoi, ViewType.Bar)
        For Each r As DataRow In _dt.Rows
            ChartControl1.Series(srNameLoi).Points.AddPoint(r("CongDoan"), r("TongSoLuongLoi"))
        Next
        ChartControl1.Series(srNameLoi).LabelsVisibility = DefaultBoolean.True
        Dim labelLoi As BarSeriesLabel = TryCast(ChartControl1.Series(srNameLoi).Label, BarSeriesLabel)
        labelLoi.Position = BarSeriesLabelPosition.Top

        'Title
        Dim chartTitles As New ChartTitle
        chartTitles.Text = _title
        chartTitles.Alignment = StringAlignment.Center
        ChartControl1.Titles.Clear()
        ChartControl1.Titles.Add(chartTitles)
    End Sub
End Class