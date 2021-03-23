Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.XtraCharts
Imports CommonDB
Imports PublicUtility

Public Class FrmSummaryNew2
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmSummaryNew2_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        dteStart.DateTime = GetFirstDayOfWeek(DateTime.Now)
        dteEnd.DateTime = dteStart.DateTime.AddDays(6)
    End Sub

    Private Sub dteStart_EditValueChanged(sender As Object, e As EventArgs) Handles dteStart.EditValueChanged
        If dteStart.DateTime > dteEnd.DateTime Then
            dteEnd.DateTime = dteStart.DateTime
        End If
    End Sub

    Private Sub dteEnd_EditValueChanged(sender As Object, e As EventArgs) Handles dteEnd.EditValueChanged
        If dteEnd.DateTime < dteStart.DateTime Then
            dteStart.DateTime = dteEnd.DateTime
        End If
    End Sub

    <Obsolete>
    Sub ChartLot()
        'CHART
        chartcLot.Series.Clear()

        'Tạo mới Series
        Dim seriesBar As New Series("Bar1", ViewType.Bar)
        seriesBar.Points.AddPoint(1, 10)
        seriesBar.Points.AddPoint(2, 30)
        seriesBar.Points.AddPoint(3, 15)
        seriesBar.Points.AddPoint(4, 55)
        seriesBar.Points.AddPoint(5, 1)

        Dim seriesBar2 As New Series("Bar2", ViewType.Bar)
        seriesBar2.Points.AddPoint(1, 15)
        seriesBar2.Points.AddPoint(2, 35)
        seriesBar2.Points.AddPoint(3, 20)
        seriesBar2.Points.AddPoint(4, 60)
        seriesBar2.Points.AddPoint(5, 2)

        Dim seriesBar3 As New Series("Bar3", ViewType.Bar)
        seriesBar3.Points.AddPoint(1, 20)
        seriesBar3.Points.AddPoint(2, 5)
        seriesBar3.Points.AddPoint(3, 45)
        seriesBar3.Points.AddPoint(4, 15)
        seriesBar3.Points.AddPoint(5, 30)

        Dim seriesLine As New Series("Line", ViewType.Line)
        seriesLine.Points.AddPoint(1, 40)
        seriesLine.Points.AddPoint(2, 5)
        seriesLine.Points.AddPoint(3, 30)
        seriesLine.Points.AddPoint(4, 20)
        seriesLine.Points.AddPoint(5, 60)

        Dim seriesLineRight As New Series("LineRight", ViewType.Line)
        seriesLineRight.Points.AddPoint(1, 15)
        seriesLineRight.Points.AddPoint(2, 20)
        seriesLineRight.Points.AddPoint(3, 55)
        seriesLineRight.Points.AddPoint(4, 5)
        seriesLineRight.Points.AddPoint(5, 35)

        'Thêm Series vào Chart Control
        chartcLot.Series.Add(seriesBar)
        chartcLot.Series.Add(seriesBar2)
        chartcLot.Series.Add(seriesBar3)
        chartcLot.Series.Add(seriesLine)
        chartcLot.Series.Add(seriesLineRight)

        'Thêm Diagram cho seriesLineRight vào bên phải Chart
        Dim seconY As New SecondaryAxisY()
        CType(chartcLot.Diagram, XYDiagram).SecondaryAxesY.Clear()
        CType(chartcLot.Diagram, XYDiagram).SecondaryAxesY.Add(seconY)
        CType(seriesLineRight.View, LineSeriesView).AxisY = seconY

        'Thêm Title và customize Title/Diagram/Label cho seriesBar/seriesLine
        Dim diagram As XYDiagram = CType(chartcLot.Diagram, XYDiagram)
        diagram.AxisY.Title.Text = "Giới hạn Bar"
        diagram.AxisY.Title.Visible = True
        diagram.AxisY.Title.Alignment = StringAlignment.Far
        diagram.AxisX.Title.Text = "Giới hạn Line"
        diagram.AxisX.Title.Visible = True
        diagram.AxisX.Title.Alignment = StringAlignment.Far

        'Thêm Title và customize Title/SecondaryDiagram/Label cho seriesLineRight
        seconY.Title.Text = "Giới hạn LineRight"
        seconY.Title.Visible = True
        seconY.Title.Alignment = StringAlignment.Far

        'Hiển thị thêm value trên mỗi cột Bar
        seriesBar.LabelsVisibility = DefaultBoolean.True
        Dim seriesLabel As BarSeriesLabel = TryCast(seriesBar.Label, BarSeriesLabel)
        seriesLabel.Position = BarSeriesLabelPosition.Top

        seriesBar2.LabelsVisibility = DefaultBoolean.True
        Dim seriesLabel2 As BarSeriesLabel = TryCast(seriesBar2.Label, BarSeriesLabel)
        seriesLabel2.Position = BarSeriesLabelPosition.Top

        seriesBar3.LabelsVisibility = DefaultBoolean.True
        Dim seriesLabel3 As BarSeriesLabel = TryCast(seriesBar3.Label, BarSeriesLabel)
        seriesLabel3.Position = BarSeriesLabelPosition.Top

        'Hiển thị thêm value trên mỗi node seriesLine
        seriesLine.LabelsVisibility = DefaultBoolean.True
        seriesLineRight.LabelsVisibility = DefaultBoolean.True
    End Sub
    <Obsolete>
    Sub ChartQty()
        'CHART
        chartcQty.Series.Clear()

        'Tạo mới Series
        Dim seriesBar As New Series("Bar1", ViewType.Bar)
        seriesBar.Points.AddPoint(1, 10)
        seriesBar.Points.AddPoint(2, 30)
        seriesBar.Points.AddPoint(3, 15)
        seriesBar.Points.AddPoint(4, 55)
        seriesBar.Points.AddPoint(5, 1)

        Dim seriesBar2 As New Series("Bar2", ViewType.Bar)
        seriesBar2.Points.AddPoint(1, 15)
        seriesBar2.Points.AddPoint(2, 35)
        seriesBar2.Points.AddPoint(3, 20)
        seriesBar2.Points.AddPoint(4, 60)
        seriesBar2.Points.AddPoint(5, 2)

        Dim seriesBar3 As New Series("Bar3", ViewType.Bar)
        seriesBar3.Points.AddPoint(1, 20)
        seriesBar3.Points.AddPoint(2, 5)
        seriesBar3.Points.AddPoint(3, 45)
        seriesBar3.Points.AddPoint(4, 15)
        seriesBar3.Points.AddPoint(5, 30)

        Dim seriesLine As New Series("Line", ViewType.Line)
        seriesLine.Points.AddPoint(1, 40)
        seriesLine.Points.AddPoint(2, 5)
        seriesLine.Points.AddPoint(3, 30)
        seriesLine.Points.AddPoint(4, 20)
        seriesLine.Points.AddPoint(5, 60)

        Dim seriesLineRight As New Series("LineRight", ViewType.Line)
        seriesLineRight.Points.AddPoint(1, 15)
        seriesLineRight.Points.AddPoint(2, 20)
        seriesLineRight.Points.AddPoint(3, 55)
        seriesLineRight.Points.AddPoint(4, 5)
        seriesLineRight.Points.AddPoint(5, 35)

        'Thêm Series vào Chart Control
        chartcQty.Series.Add(seriesBar)
        chartcQty.Series.Add(seriesBar2)
        chartcQty.Series.Add(seriesBar3)
        chartcQty.Series.Add(seriesLine)
        chartcQty.Series.Add(seriesLineRight)

        'Thêm Diagram cho seriesLineRight vào bên phải Chart
        Dim seconY As New SecondaryAxisY()
        CType(chartcQty.Diagram, XYDiagram).SecondaryAxesY.Clear()
        CType(chartcQty.Diagram, XYDiagram).SecondaryAxesY.Add(seconY)
        CType(seriesLineRight.View, LineSeriesView).AxisY = seconY

        'Thêm Title và customize Title/Diagram/Label cho seriesBar/seriesLine
        Dim diagram As XYDiagram = CType(chartcQty.Diagram, XYDiagram)
        diagram.AxisY.Title.Text = "Giới hạn Bar"
        diagram.AxisY.Title.Visible = True
        diagram.AxisY.Title.Alignment = StringAlignment.Far
        diagram.AxisX.Title.Text = "Giới hạn Line"
        diagram.AxisX.Title.Visible = True
        diagram.AxisX.Title.Alignment = StringAlignment.Far

        'Thêm Title và customize Title/SecondaryDiagram/Label cho seriesLineRight
        seconY.Title.Text = "Giới hạn LineRight"
        seconY.Title.Visible = True
        seconY.Title.Alignment = StringAlignment.Far

        'Hiển thị thêm value trên mỗi cột Bar
        seriesBar.LabelsVisibility = DefaultBoolean.True
        Dim seriesLabel As BarSeriesLabel = TryCast(seriesBar.Label, BarSeriesLabel)
        seriesLabel.Position = BarSeriesLabelPosition.Top

        seriesBar2.LabelsVisibility = DefaultBoolean.True
        Dim seriesLabel2 As BarSeriesLabel = TryCast(seriesBar2.Label, BarSeriesLabel)
        seriesLabel2.Position = BarSeriesLabelPosition.Top

        seriesBar3.LabelsVisibility = DefaultBoolean.True
        Dim seriesLabel3 As BarSeriesLabel = TryCast(seriesBar3.Label, BarSeriesLabel)
        seriesLabel3.Position = BarSeriesLabelPosition.Top

        'Hiển thị thêm value trên mỗi node seriesLine
        seriesLine.LabelsVisibility = DefaultBoolean.True
        seriesLineRight.LabelsVisibility = DefaultBoolean.True
    End Sub

    <Obsolete>
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(2) As SqlClient.SqlParameter
        If rdoDay.Checked Then
            'para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dteEnd.DateTime))
            para(0) = New SqlClient.SqlParameter("@StartDate", dteEnd.DateTime)
            para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dteEnd.DateTime))
        Else
            'para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dteStart.DateTime))
            para(0) = New SqlClient.SqlParameter("@StartDate", dteStart.DateTime)
            para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dteEnd.DateTime))
        End If
        If rdoSingleSide.Checked Then
            para(2) = New SqlClient.SqlParameter("@Type", rdoSingleSide.Text)
        ElseIf rdoDoubleSide.Checked Then
            para(2) = New SqlClient.SqlParameter("@Type", rdoDoubleSide.Text)
        Else
            para(2) = New SqlClient.SqlParameter("@Type", "All")
        End If

        Dim para_2(2) As SqlClient.SqlParameter
        If rdoDay.Checked Then
            para_2(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dteStart.DateTime))
            para_2(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dteStart.DateTime))
        Else
            para_2(0) = New SqlClient.SqlParameter("@StartDate", dteStart.DateTime.AddDays(-7))
            para_2(1) = New SqlClient.SqlParameter("@EndDate", dteStart.DateTime.AddHours(-1))
        End If
        If rdoSingleSide.Checked Then
            para_2(2) = New SqlClient.SqlParameter("@Type", rdoSingleSide.Text)
        ElseIf rdoDoubleSide.Checked Then
            para_2(2) = New SqlClient.SqlParameter("@Type", rdoDoubleSide.Text)
        Else
            para_2(2) = New SqlClient.SqlParameter("@Type", "All")
        End If

        Dim dtSumLotNo As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_SummaryLotnoN", para)
        Dim dtSumLotNo_2 As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_SummaryLotnoN", para_2)
        Dim dtSumQtyW As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_SummaryQtyN", para)
        Dim dtSumQtyW_2 As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_SummaryQtyN", para_2)

        '----------------------'
        Dim dtLot As New DataTable
        dtLot.Columns.Add("FPI")
        dtLot.Columns.Add("SG LotNo")
        dtLot.Columns.Add("SG TG")
        dtLot.Columns.Add("TSB LotNo")
        dtLot.Columns.Add("TSB TG")
        dtLot.Columns.Add("HGST LotNo")
        dtLot.Columns.Add("HGST TG")
        dtLot.Columns.Add("WD LotNo")
        dtLot.Columns.Add("WD TG")
        dtLot.Columns.Add("OTHER LotNo")
        dtLot.Columns.Add("OTHER TG")
        dtLot.Columns.Add("All LotNo")
        dtLot.Columns.Add("All TG")

        For index = 1 To 9
            dtLot.Rows.Add()
        Next
        dtLot.Rows(0)(0) = "Số lô kiểm tra (LẦN 1)"
        dtLot.Rows(1)(0) = "Số lô NG (LẦN 1)"
        dtLot.Rows(2)(0) = "Tỉ lệ NG"
        dtLot.Rows(3)(0) = "FPI lần 2"
        dtLot.Rows(4)(0) = "FPI lần 3"
        dtLot.Rows(5)(0) = "FPI lần 4"
        dtLot.Rows(6)(0) = "FPI lần 5"
        dtLot.Rows(7)(0) = "Tỷ lệ tái FPI"
        dtLot.Rows(8)(0) = "Bao nhiêu cuộn CNĐB"
        '---------------------'

        Dim HeaderFieldName As String = ""
        For c = 1 To 12
            HeaderFieldName = dtLot.Columns(c).ColumnName.Split(" ")(0)

            If dtLot.Columns(c).ColumnName.Contains("LotNo") Then
                dtLot.Rows(0)(c) = dtSumLotNo.Compute("sum(TotalLotNo)", String.Format("CongDoan='TotalLotNo'  and Customer='{0}'", HeaderFieldName))
                dtLot.Rows(1)(c) = dtSumLotNo.Compute("sum(TotalLotNo)", String.Format("CongDoan='TotalLotNo'  and Customer='{0}'", HeaderFieldName))
                If IsNumeric(dtLot.Rows(1)(c)) Then
                    dtLot.Rows(2)(c) = CType(dtLot.Rows(1)(c) * 100.0 / dtLot.Rows(0)(c), Decimal).ToString("N2")
                Else
                    dtLot.Rows(2)(c) = DBNull.Value
                End If
                dtLot.Rows(3)(c) = dtSumLotNo.Compute("sum(TotalLotNo)", String.Format("CongDoan='FPI2' and Customer='{0}'", HeaderFieldName))
                dtLot.Rows(4)(c) = dtSumLotNo.Compute("sum(TotalLotNo)", String.Format("CongDoan='FPI3' and Customer='{0}'", HeaderFieldName))
                dtLot.Rows(5)(c) = dtSumLotNo.Compute("sum(TotalLotNo)", String.Format("CongDoan='FPI4' and Customer='{0}'", HeaderFieldName))
                dtLot.Rows(6)(c) = dtSumLotNo.Compute("sum(TotalLotNo)", String.Format("CongDoan='FPI5' and Customer='{0}'", HeaderFieldName))
                dtLot.Rows(8)(c) = dtSumLotNo.Compute("sum(TotalLotNo)", String.Format("CongDoan='CNDB' and Customer='{0}'", HeaderFieldName))
                If dtLot.Rows(0)(c) IsNot DBNull.Value Then
                    dtLot.Rows(7)(c) = CType((
                                        IIf(IsDBNull(dtLot.Rows(3)(c)), 0, dtLot.Rows(3)(c)) +
                                         IIf(IsDBNull(dtLot.Rows(4)(c)), 0, dtLot.Rows(4)(c)) +
                                         IIf(IsDBNull(dtLot.Rows(5)(c)), 0, dtLot.Rows(5)(c)) +
                                         IIf(IsDBNull(dtLot.Rows(6)(c)), 0, dtLot.Rows(6)(c)) * 100.0 /
                                         dtLot.Rows(0)(c)),
                                         Decimal).ToString("N2")
                End If
            Else
                dtLot.Rows(0)(c) = dtSumLotNo.Compute("sum(TG)", String.Format("CongDoan='TotalLotNo' and Customer='{0}'", HeaderFieldName))
                dtLot.Rows(1)(c) = dtSumLotNo.Compute("sum(TG)", String.Format("CongDoan='TotalLotNG' and Customer='{0}'", HeaderFieldName))
                dtLot.Rows(2)(c) = DBNull.Value
                dtLot.Rows(3)(c) = dtSumLotNo.Compute("sum(TG)", String.Format("CongDoan='FPI2' and Customer='{0}'", HeaderFieldName))
                dtLot.Rows(4)(c) = dtSumLotNo.Compute("sum(TG)", String.Format("CongDoan='FPI3' and Customer='{0}'", HeaderFieldName))
                dtLot.Rows(5)(c) = dtSumLotNo.Compute("sum(TG)", String.Format("CongDoan='FPI4' and Customer='{0}'", HeaderFieldName))
                dtLot.Rows(6)(c) = dtSumLotNo.Compute("sum(TG)", String.Format("CongDoan='FPI5' and Customer='{0}'", HeaderFieldName))
                dtLot.Rows(8)(c) = dtSumLotNo.Compute("sum(TG)", String.Format("CongDoan='CNDB' and Customer='{0}'", HeaderFieldName))
            End If
        Next
        gridcLot.DataSource = dtLot
        GridControlSetFormat(gridvLot)

        '-----------------'
        Dim dtQty As New DataTable
        dtQty.Columns.Add(" ")
        dtQty.Columns.Add("Er001")
        dtQty.Columns.Add("Er002")
        dtQty.Columns.Add("Er003")
        dtQty.Columns.Add("Er004")
        dtQty.Columns.Add("Er005")
        dtQty.Columns.Add("Er006")
        dtQty.Columns.Add("Er007")
        dtQty.Columns.Add("Er009")
        dtQty.Columns.Add("Er012")
        dtQty.Columns.Add("Er024")
        dtQty.Columns.Add("Er025")
        dtQty.Columns.Add("Er627")
        dtQty.Columns.Add("Er639")

        For index = 1 To 6
            dtQty.Rows.Add()
        Next
        dtQty.Rows(0)(0) = "SG"
        dtQty.Rows(1)(0) = "TSB"
        dtQty.Rows(2)(0) = "HGST"
        dtQty.Rows(3)(0) = "WD"
        dtQty.Rows(4)(0) = "OTHER"
        dtQty.Rows(5)(0) = "All"

        For r = 0 To 5
            For c = 1 To 13
                dtQty.Rows(r)(c) = dtSumQtyW.Compute("sum(Qty)", String.Format("Customer='{0}' and DefectCode='{1}'",
                                                                                     dtQty.Rows(r)(0),
                                                                                     dtQty.Columns(c).ColumnName.Replace("Er", "")))
            Next
        Next

        gridcQty.DataSource = dtQty
        GridControlSetFormat(gridvQty)

        'Chart
        ChartLot()
        ChartQty()
    End Sub
End Class