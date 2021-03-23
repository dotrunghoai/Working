Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing
Imports System.Windows.Forms
Imports CommonDB
Imports LibEntity

Public Class FrmCharts
    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Public _showvalue As Boolean = False
    Public grid As DataGridView
    Public _title As String = ""

    Public Sub ChartQCGate()
        Chart1.Series.Clear()
        Chart1.Legends.Clear()
        Chart1.Titles.Clear()
        'Setting Legend==============================================================
        Chart1.Legends.Add(1)
        Chart1.Legends(0).Docking = Docking.Bottom
        Chart1.Legends(0).Alignment = StringAlignment.Center
        Chart1.Legends(0).LegendStyle = LegendStyle.Row
        Chart1.Legends(0).TableStyle = LegendTableStyle.Auto
        'Chart1.Legends(0).DockedToChartArea = "ChartArea1"
        Chart1.Legends(0).BackColor = Color.WhiteSmoke
        Chart1.Legends(0).Font = New Drawing.Font("Arial", 10, Drawing.FontStyle.Regular)
        'End Legend================================================================== 
        Chart1.Titles.Add(_title)
        Chart1.Titles(0).ForeColor = Drawing.Color.Black
        Chart1.Titles(0).Font = New Drawing.Font("Arial", 14, Drawing.FontStyle.Regular)
        Chart1.Titles(0).Alignment = ContentAlignment.TopCenter

        Chart1.Padding = New Padding(0)
        Chart1.Padding = New Padding(0)

        Chart1.ChartAreas("ChartArea1").AxisX.Interval = 1
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -45
        Chart1.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas("ChartArea1").AxisY.LabelStyle.Format = "N3"
        Chart1.ChartAreas("ChartArea1").AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot
        'Chart1.ChartAreas("ChartArea1").AxisY.Maximum = 5000
        Chart1.ChartAreas("ChartArea1").AxisY.Title = "[mm]"
        Chart1.ChartAreas("ChartArea1").AxisY.TitleAlignment = StringAlignment.Far
        'Chart1.ChartAreas("ChartArea1").AxisY.Interval = 100
        Chart1.BackColor = Color.WhiteSmoke
        Dim seriesNameT As String = ""

        'Target line
        'seriesNameT = "Target"
        'Chart1.Series.Add(seriesNameT)
        'Chart1.Series(seriesNameT).ChartType = SeriesChartType.Line
        'Chart1.Series(seriesNameT).BorderWidth = 3
        'Chart1.Series(seriesNameT).IsValueShownAsLabel = False
        'Chart1.Series(seriesNameT).LabelFormat = "N0"
        'Chart1.Series(seriesNameT).Color = Color.Red

        'For Each r As DataRow In dtItemCode.Rows
        '    Dim LotNo As String = CType(r("Ngay"), DateTime).ToString("dd-MMM")
        '    Chart1.Series(seriesNameT).Points.AddXY(LotNo, obj.TargetM2RS)
        'Next

        Dim seriesName As String = "Avg-Spec"
        Chart1.Series.Add(seriesName)
        Chart1.Series(seriesName).ChartType = SeriesChartType.Column
        Chart1.Series(seriesName).BorderWidth = 2
        Chart1.Series(seriesName).IsXValueIndexed = True
        Chart1.Series(seriesName).IsValueShownAsLabel = True
        Chart1.Series(seriesName).LabelFormat = "N3"
        For Each r As DataGridViewRow In grid.Rows
            Dim YVal As Decimal = 0
            Dim mAVG As Decimal = 0
            Dim mSpec As Decimal = 0
            If r.Cells("AVG").Value IsNot DBNull.Value Then
                mAVG = r.Cells("AVG").Value
            End If
            If r.Cells("Spec").Value IsNot DBNull.Value Then
                mSpec = r.Cells("Spec").Value
            End If
            YVal = mAVG - mSpec
            Dim LotNo As String = r.Cells("Item").Value
            If YVal > 0 Then
                Chart1.Series(seriesName).Points.AddXY(LotNo, YVal)
            Else
                Chart1.Series(seriesName).Points.AddXY(LotNo, Double.NaN)
            End If
        Next


    End Sub


    Private Sub FrmCharts_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Dim mChart As New Chart

    Private Sub mnuCopy_Click(sender As System.Object, e As System.EventArgs) Handles mnuCopy.Click

        ' Create a memory stream to save the chart image    
        Dim stream As New System.IO.MemoryStream()

        ' Save the chart image to the stream    
        mChart.SaveImage(stream, System.Drawing.Imaging.ImageFormat.Bmp)

        ' Create a bitmap using the stream    
        Dim bmp As New Bitmap(stream)

        ' Save the bitmap to the clipboard    
        Clipboard.SetDataObject(bmp)
    End Sub

    Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click

        ' Create a new save file dialog
        Dim saveFileDialog1 As New SaveFileDialog()

        ' Sets the current file name filter string, which determines 
        ' the choices that appear in the "Save as file type" or 
        ' "Files of type" box in the dialog box.
        saveFileDialog1.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|EMF (*.emf)|*.emf|PNG (*.png)|*.png|GIF (*.gif)|*.gif|TIFF (*.tif)|*.tif"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        ' Set image file format
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim format As ChartImageFormat = ChartImageFormat.Bmp

            If saveFileDialog1.FileName.EndsWith("bmp") Then
                format = ChartImageFormat.Bmp
            Else
                If saveFileDialog1.FileName.EndsWith("jpg") Then
                    format = ChartImageFormat.Jpeg
                Else
                    If saveFileDialog1.FileName.EndsWith("emf") Then
                        format = ChartImageFormat.Emf
                    Else
                        If saveFileDialog1.FileName.EndsWith("gif") Then
                            format = ChartImageFormat.Gif
                        Else
                            If saveFileDialog1.FileName.EndsWith("png") Then
                                format = ChartImageFormat.Png
                            Else
                                If saveFileDialog1.FileName.EndsWith("tif") Then
                                    format = ChartImageFormat.Tiff
                                End If
                            End If ' Save image
                        End If
                    End If
                End If
            End If
            mChart.SaveImage(saveFileDialog1.FileName, format)
        End If
    End Sub

    Private Sub mnuPrint_Click(sender As System.Object, e As System.EventArgs) Handles mnuPrint.Click
        mChart.Printing.Print(True)
    End Sub

    Private Sub mnuPreview_Click(sender As System.Object, e As System.EventArgs) Handles mnuPreview.Click
        mChart.Printing.PrintPreview()
    End Sub

    Private Sub FrmCharts_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'ChartQCGate()
    End Sub
End Class