Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing
Imports System.Windows.Forms
Imports CommonDB

Public Class FrmCharts
    Public _showvalue As Boolean = False
    Public _myDate As DateTime = DateTime.Now
    Public grid As DataGridView 
    Public _title As String = ""
    Public _YTitle As String = ""
    Public _XTitle As String = "" 
    Public _targetY As Decimal = 0
    Public _targetP As Decimal = 0

    Public Sub LoadChartDefectDay(ByVal target As Decimal)
        Dim _showvalue As Boolean = False
        ChartP.Series.Clear()
        ChartP.Legends.Clear()
        ChartP.Titles.Clear()

        'Setting Legend==============================================================
        ChartP.Legends.Add("Title")
        ChartP.Legends(0).Docking = Docking.Right
        ChartP.Legends(0).BorderColor = Color.Black
        ChartP.Legends(0).BorderWidth = 0
        ChartP.Legends(0).BorderDashStyle = ChartDashStyle.Solid
        ChartP.Legends(0).Alignment = StringAlignment.Center
        ChartP.Legends(0).LegendStyle = LegendStyle.Table
        'End Legend==================================================================
        ChartP.BorderlineColor = Color.Green
        ChartP.BorderlineDashStyle = ChartDashStyle.Solid
        ChartP.BorderlineWidth = 1
        ChartP.Titles.Add(_title)
        ChartP.Titles(0).ForeColor = Drawing.Color.Blue
        ChartP.Titles(0).Font = New Drawing.Font("", 10, Drawing.FontStyle.Bold)

        ChartP.ChartAreas("ChartArea1").AxisX.Interval = 1
        ChartP.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -45
        ChartP.ChartAreas("ChartArea1").AxisY2.Title = "[ % OK ]"
        ChartP.ChartAreas("ChartArea1").AxisY2.Interval = 5
        ChartP.ChartAreas("ChartArea1").AxisY.Title = "[ % NG ]"
        ChartP.ChartAreas("ChartArea1").AxisY.Interval = 1
        ChartP.ChartAreas("ChartArea1").AxisY.TitleFont = New Font("Arial", 10, FontStyle.Regular)
        ChartP.ChartAreas("ChartArea1").AxisY2.LabelStyle.Format = "N0"
        ChartP.ChartAreas("ChartArea1").AxisY.LabelStyle.Format = "N0"
        ChartP.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = True
        ChartP.ChartAreas("ChartArea1").AxisY2.MajorGrid.LineDashStyle = ChartDashStyle.Dot
        ChartP.ChartAreas("ChartArea1").AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot
        ChartP.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False

        Dim seriesComplete As String = "Complete Yield"
        ChartP.Series.Add(seriesComplete)
        ChartP.Series(seriesComplete).ChartType = SeriesChartType.Line
        ChartP.Series(seriesComplete).BorderWidth = 4
        ChartP.Series(seriesComplete).IsXValueIndexed = True
        ChartP.Series(seriesComplete).YAxisType = AxisType.Secondary
        ChartP.Series(seriesComplete).IsValueShownAsLabel = True
        ChartP.Series(seriesComplete).LabelFormat = "N2"
        ChartP.Series(seriesComplete).Color = Color.Blue
        For r As Integer = 0 To grid.Rows.Count - 1
            Dim YVal As Decimal = 0
            If grid.Rows(r).Cells("RateQ").Value IsNot DBNull.Value Then
                YVal = grid.Rows(r).Cells("RateQ").Value
            End If
            Dim LotNo As String = grid.Rows(r).Cells("ThangQ").Value
            ChartP.Series(seriesComplete).Points.AddXY(LotNo, YVal.ToString("N2"))
        Next

        ChartP.Series(seriesComplete).MarkerColor = Color.IndianRed
        ChartP.Series(seriesComplete).MarkerBorderColor = Color.IndianRed
        ChartP.Series(seriesComplete).MarkerSize = 6
        ChartP.Series(seriesComplete).MarkerStyle = MarkerStyle.Circle
        ChartP.Series(seriesComplete).MarkerBorderWidth = 2

        Dim seriesTarget As String = "Target"
        ChartP.Series.Add(seriesTarget)
        ChartP.Series(seriesTarget).ChartType = SeriesChartType.Line
        ChartP.Series(seriesTarget).BorderWidth = 4
        ChartP.Series(seriesTarget).BorderDashStyle = ChartDashStyle.Dash
        ChartP.Series(seriesTarget).IsXValueIndexed = True
        ChartP.Series(seriesTarget).YAxisType = AxisType.Secondary
        ChartP.Series(seriesTarget).IsValueShownAsLabel = False
        ChartP.Series(seriesTarget).LabelFormat = "N2"
        ChartP.Series(seriesTarget).Color = Color.DarkRed
        For r As Integer = 0 To grid.Rows.Count - 1
            Dim YVal As Decimal = target
            Dim LotNo As String = grid.Rows(r).Cells("ThangQ").Value
            ChartP.Series(seriesTarget).Points.AddXY(LotNo, YVal)
        Next

        Dim startindex As Integer = 1
        For c As Integer = grid.Columns("RateQ").Index + 1 To grid.ColumnCount - 1
            If startindex <= 40 Then
                Dim seriesP As String = grid.Columns(c).HeaderText
                ChartP.Series.Add(seriesP)
                ChartP.Series(seriesP).ChartType = SeriesChartType.StackedColumn
                ChartP.Series(seriesP).BorderWidth = 2
                ChartP.Series(seriesP).IsXValueIndexed = True
                ChartP.Series(seriesP).YAxisType = AxisType.Primary
                ChartP.Series(seriesP).IsValueShownAsLabel = False
                ChartP.Series(seriesP).LabelFormat = "N4"
                For Each r As DataGridViewRow In grid.Rows
                    Dim YVal As Decimal = 0
                    If r.Cells(c).Value IsNot DBNull.Value Then
                        YVal = r.Cells(c).Value
                    End If
                    Dim LotNo As String = r.Cells("ThangQ").Value
                    ChartP.Series(seriesP).Points.AddXY(LotNo, YVal.ToString("N4"))
                Next
            End If
            startindex += 1
        Next
    End Sub

    Public Sub LoadChartDefectTuanThang()
        Dim _showvalue As Boolean = False
        ChartP.Series.Clear()
        ChartP.Legends.Clear()
        ChartP.Titles.Clear()

        'Setting Legend==============================================================
        ChartP.Legends.Add("Title")
        ChartP.Legends(0).Docking = Docking.Right
        ChartP.Legends(0).BorderColor = Color.Black
        ChartP.Legends(0).BorderWidth = 0
        ChartP.Legends(0).BorderDashStyle = ChartDashStyle.Solid
        ChartP.Legends(0).Alignment = StringAlignment.Center
        ChartP.Legends(0).LegendStyle = LegendStyle.Table
        ChartP.Legends(0).DockedToChartArea = "ChartArea1"
        'End Legend==================================================================
        ChartP.BorderlineColor = Color.Green
        ChartP.BorderlineDashStyle = ChartDashStyle.Solid
        ChartP.BorderlineWidth = 1
        ChartP.Titles.Add(_title)
        ChartP.Titles(0).ForeColor = Drawing.Color.Blue
        ChartP.Titles(0).Font = New Drawing.Font("", 10, Drawing.FontStyle.Bold)

        ChartP.ChartAreas("ChartArea1").AxisX.Interval = 1
        'ChartP.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -90 
        ChartP.ChartAreas("ChartArea1").AxisY.Title = "[ % NG ]"
        ChartP.ChartAreas("ChartArea1").AxisY.TitleFont = New Font("Arial", 10, FontStyle.Regular)
        'ChartP.ChartAreas("ChartArea1").AxisY2.LabelStyle.Format = "N0"
        ChartP.ChartAreas("ChartArea1").AxisY.LabelStyle.Format = "N2"
        ChartP.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = True
        'ChartP.ChartAreas("ChartArea1").AxisY2.MajorGrid.LineDashStyle = ChartDashStyle.NotSet
        ChartP.ChartAreas("ChartArea1").AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot
        ChartP.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False


        Dim startindex As Integer = 1
        For Each r As DataGridViewRow In grid.Rows
            If r.Index = 0 Then
                Continue For
            End If
            Dim seriesP As String = r.Cells("ThangQ").Value
            ChartP.Series.Add(seriesP)
            ChartP.Series(seriesP).ChartType = SeriesChartType.Column
            ChartP.Series(seriesP).BorderWidth = 2
            ChartP.Series(seriesP).IsXValueIndexed = True
            ChartP.Series(seriesP).YAxisType = AxisType.Primary
            ChartP.Series(seriesP).IsValueShownAsLabel = False
            ChartP.Series(seriesP).LabelFormat = "N4"
            startindex = 1
            For c As Integer = grid.Columns("RateQ").Index + 1 To grid.Columns.Count - 1
                If startindex <= 40 Then
                    Dim YVal As Decimal = 0
                    If r.Cells(c).Value IsNot DBNull.Value Then
                        YVal = r.Cells(c).Value
                    End If
                    Dim LotNo As String = grid.Columns(c).HeaderText
                    ChartP.Series(seriesP).Points.AddXY(LotNo, YVal)
                End If
                startindex += 1
            Next
        Next

        Dim seriesT = "Target"
        ChartP.Series.Add(seriesT)
        ChartP.Series(seriesT).ChartType = SeriesChartType.Line
        ChartP.Series(seriesT).BorderWidth = 3
        ChartP.Series(seriesT).IsXValueIndexed = True
        ChartP.Series(seriesT).YAxisType = AxisType.Primary
        ChartP.Series(seriesT).IsValueShownAsLabel = False
        ChartP.Series(seriesT).LabelFormat = "N4"
        ChartP.Series(seriesT).Color = Color.Red
        startindex = 1
        For c As Integer = grid.Columns("RateQ").Index + 1 To grid.Columns.Count - 1
            If startindex <= 40 Then
                Dim YVal As Decimal = 0
                If grid.Rows(0).Cells(c).Value IsNot DBNull.Value Then
                    YVal = grid.Rows(0).Cells(c).Value
                End If
                Dim LotNo As String = grid.Columns(c).HeaderText
                ChartP.Series(seriesT).Points.AddXY(LotNo, YVal)
            End If
            startindex += 1
        Next

        ChartP.Series(seriesT).MarkerBorderColor = Color.Green
        ChartP.Series(seriesT).MarkerBorderWidth = 3
        ChartP.Series(seriesT).MarkerColor = Color.Yellow
        ChartP.Series(seriesT).MarkerSize = 4
        ChartP.Series(seriesT).MarkerStyle = MarkerStyle.Square
    End Sub

    Public Sub LoadChartDefectQuy()
        Dim _showvalue As Boolean = False
        ChartP.Series.Clear()
        ChartP.Legends.Clear()
        ChartP.Titles.Clear()

        'Setting Legend==============================================================
        ChartP.Legends.Add("Title")
        ChartP.Legends(0).Docking = Docking.Right
        ChartP.Legends(0).BorderColor = Color.Black
        ChartP.Legends(0).BorderWidth = 0
        ChartP.Legends(0).BorderDashStyle = ChartDashStyle.Solid
        ChartP.Legends(0).Alignment = StringAlignment.Center
        ChartP.Legends(0).LegendStyle = LegendStyle.Table
        ChartP.Legends(0).DockedToChartArea = "ChartArea1"
        'End Legend==================================================================
        ChartP.BorderlineColor = Color.Green
        ChartP.BorderlineDashStyle = ChartDashStyle.Solid
        ChartP.BorderlineWidth = 1
        ChartP.Titles.Add(_title)
        ChartP.Titles(0).ForeColor = Drawing.Color.Blue
        ChartP.Titles(0).Font = New Drawing.Font("", 10, Drawing.FontStyle.Bold)

        ChartP.ChartAreas("ChartArea1").AxisX.Interval = 1
        'ChartP.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -90 
        ChartP.ChartAreas("ChartArea1").AxisY.Title = "[ % NG ]"
        ChartP.ChartAreas("ChartArea1").AxisY.TitleFont = New Font("Arial", 10, FontStyle.Regular)
        'ChartP.ChartAreas("ChartArea1").AxisY2.LabelStyle.Format = "N0"
        ChartP.ChartAreas("ChartArea1").AxisY.LabelStyle.Format = "N2"
        ChartP.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = True
        'ChartP.ChartAreas("ChartArea1").AxisY2.MajorGrid.LineDashStyle = ChartDashStyle.NotSet
        ChartP.ChartAreas("ChartArea1").AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot
        ChartP.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False

        Dim startindex As Integer = 1
        For Each r As DataGridViewRow In grid.Rows
            If r.Cells("ThangQ").Value.ToString.Contains("Q") Then
                Dim seriesP As String = r.Cells("ThangQ").Value
                ChartP.Series.Add(seriesP)
                ChartP.Series(seriesP).ChartType = SeriesChartType.Column
                ChartP.Series(seriesP).BorderWidth = 2
                ChartP.Series(seriesP).IsXValueIndexed = True
                ChartP.Series(seriesP).YAxisType = AxisType.Primary
                ChartP.Series(seriesP).IsValueShownAsLabel = False
                ChartP.Series(seriesP).LabelFormat = "N4"
                startindex = 1
                For c As Integer = grid.Columns("RateQ").Index + 1 To grid.Columns.Count - 1
                    If startindex <= 40 Then
                        Dim YVal As Decimal = 0
                        If r.Cells(c).Value IsNot DBNull.Value Then
                            YVal = r.Cells(c).Value
                        End If
                        Dim LotNo As String = grid.Columns(c).HeaderText
                        ChartP.Series(seriesP).Points.AddXY(LotNo, YVal)
                    End If
                    startindex += 1
                Next
            End If
        Next
    End Sub

    Public Sub LoadChartTLCP()
        Dim _showvalue As Boolean = False
        ChartP.Series.Clear()
        ChartP.Legends.Clear()
        ChartP.Titles.Clear()
        'Setting Legend==============================================================
        ChartP.Legends.Add("Title")
        ChartP.Legends(0).Docking = Docking.Right
        ChartP.Legends(0).BorderColor = Color.Black
        ChartP.Legends(0).BorderWidth = 0
        ChartP.Legends(0).BorderDashStyle = ChartDashStyle.Solid
        ChartP.Legends(0).Alignment = StringAlignment.Center
        ChartP.Legends(0).LegendStyle = LegendStyle.Table
        'End Legend==================================================================
        ChartP.BorderlineColor = Color.Green
        ChartP.BorderlineDashStyle = ChartDashStyle.Solid
        ChartP.BorderlineWidth = 1
        ChartP.Titles.Add(_title)

        ChartP.Titles(0).ForeColor = Drawing.Color.Blue
        ChartP.Titles(0).Font = New Drawing.Font("", 10, Drawing.FontStyle.Bold)

        ChartP.ChartAreas("ChartArea1").AxisX.Interval = 1
        'ChartP.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -90
        ChartP.ChartAreas("ChartArea1").AxisX.TitleFont = New Font("Arial", 10, FontStyle.Regular)
        'ChartP.ChartAreas("ChartArea1").AxisY.Interval = 10
        ChartP.ChartAreas("ChartArea1").AxisY.Minimum = 70
        ChartP.ChartAreas("ChartArea1").AxisY.Title = "[ % ]"
        ChartP.ChartAreas("ChartArea1").AxisY.TitleFont = New Font("Arial", 10, FontStyle.Regular)
        ChartP.ChartAreas("ChartArea1").AxisY.LabelStyle.Format = "N0"
        ChartP.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = True
        ChartP.ChartAreas("ChartArea1").AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot
        ChartP.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
        Dim seriesName As String = "" 
            seriesName = "TLCP"
            ChartP.Series.Add(seriesName)
            ChartP.Series(seriesName).ChartType = SeriesChartType.Line
        ChartP.Series(seriesName).BorderWidth = 4
            ChartP.Series(seriesName).IsXValueIndexed = True
            ChartP.Series(seriesName).YAxisType = AxisType.Primary
        ChartP.Series(seriesName).IsValueShownAsLabel = True
            ChartP.Series(seriesName).LabelFormat = "N2"
            ChartP.Series(seriesName).Color = Color.OrangeRed
        For r As Integer = 0 To grid.Rows.Count - 1
           
            Dim YVal As Decimal = 0
            If grid.Rows(r).Cells("RateT").Value IsNot DBNull.Value Then
                YVal = grid.Rows(r).Cells("RateT").Value
            End If
            Dim LotNo As String = grid.Rows(r).Cells("CustomerT").Value
            ChartP.Series(seriesName).Points.AddXY(LotNo, YVal.ToString("N2"))
            If grid.Rows(r).Cells("CustomerT").Value = "OTHER" Then
                Exit For
            End If
        Next

            ChartP.Series(seriesName).MarkerBorderColor = Color.IndianRed
        ChartP.Series(seriesName).MarkerBorderWidth = 4
            ChartP.Series(seriesName).MarkerColor = Color.IndianRed
        ChartP.Series(seriesName).MarkerSize = 6
        ChartP.Series(seriesName).MarkerStyle = MarkerStyle.Circle
         
    End Sub

    Private Sub FrmCharts_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub
End Class