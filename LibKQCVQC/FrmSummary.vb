Imports System.Windows.Forms
Imports CommonDB
Imports PublicUtility
Imports System.Drawing
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO

Public Class FrmSummary : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim serialW1 As String = ""
    Dim serialW2 As String = ""


    Private Sub Chart()
        ChartQty.ChartAreas.Clear()
        ChartQty.Titles.Clear()
        ChartQty.Series.Clear() 
        ChartQty.Legends.Clear()

        ChartQty.Titles.Add("Số lượng lỗi  (001-006) phát hiện tại Photo")
        ChartQty.Titles(0).ForeColor = Drawing.Color.Black
        ChartQty.Titles(0).Font = New Drawing.Font("Arial", 12, Drawing.FontStyle.Bold)
        ChartQty.Titles(0).Alignment = ContentAlignment.BottomCenter

        ChartQty.Legends.Add(1)
        ChartQty.Legends(0).Docking = Docking.Bottom
        ChartQty.Legends(0).Alignment = StringAlignment.Center
        ChartQty.Legends(0).LegendStyle = LegendStyle.Row
        ChartQty.Legends(0).TableStyle = LegendTableStyle.Auto

        ChartQty.ChartAreas.Add("ChartArea1")
        ChartQty.ChartAreas("ChartArea1").AxisX.Interval = 1
        ChartQty.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
        'ChartQty.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -90
        ChartQty.ChartAreas("ChartArea1").AxisY.LabelStyle.Format = "N0"
        ChartQty.ChartAreas("ChartArea1").AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot
        ChartQty.ChartAreas("ChartArea1").AxisY.TitleAlignment = StringAlignment.Far
        ChartQty.ChartAreas("ChartArea1").AxisX.TitleAlignment = StringAlignment.Far
        ChartQty.ChartAreas("ChartArea1").AxisY.Title = "Qty"
        'ChartQty.ChartAreas("ChartArea1").AxisX.Title = "Defect Mode"
        ChartQty.ChartAreas("ChartArea1").AxisY.TextOrientation = TextOrientation.Horizontal
        ChartQty.ChartAreas("ChartArea1").BackColor = Color.White
        ChartQty.BackColor = Color.WhiteSmoke

        Dim seriesName1 As String = serialW1
        ChartQty.Series.Add(seriesName1)
        ChartQty.Series(seriesName1).ChartType = SeriesChartType.Column
        ChartQty.Series(seriesName1).BorderWidth = 2
        ChartQty.Series(seriesName1).IsXValueIndexed = True
        ChartQty.Series(seriesName1).IsValueShownAsLabel = True
        ChartQty.Series(seriesName1).LabelFormat = "N0"
        ChartQty.Series(seriesName1).Color = Color.Orange

        Dim seriesName2 As String = serialW2
        ChartQty.Series.Add(seriesName2)
        ChartQty.Series(seriesName2).ChartType = SeriesChartType.Column
        ChartQty.Series(seriesName2).BorderWidth = 2
        ChartQty.Series(seriesName2).IsXValueIndexed = True
        ChartQty.Series(seriesName2).IsValueShownAsLabel = True
        ChartQty.Series(seriesName2).LabelFormat = "N0"
        ChartQty.Series(seriesName2).Color = Color.DeepSkyBlue
        For Each c As DataGridViewColumn In gridQty.Columns
            If c.Name = "Q001" Or c.Name = "Q002" Or c.Name = "Q003" Or c.Name = "Q004" Or c.Name = "Q005" Or c.Name = "Q006" Then
                Dim YVal1 As Decimal = 0
                Dim YVal2 As Decimal = 0
                If gridQty.Rows(0).Cells(c.Name).Value IsNot DBNull.Value Then
                    YVal1 = gridQty.Rows(0).Cells(c.Name).Value
                End If
                If gridQty.Rows(0).Cells(c.Name).Tag IsNot DBNull.Value Then
                    YVal2 = gridQty.Rows(0).Cells(c.Name).Tag
                End If
                Dim LotNo As String = c.Name
                If YVal1 > 0 Then
                    ChartQty.Series(seriesName1).Points.AddXY(LotNo, YVal1)
                Else
                    ChartQty.Series(seriesName1).Points.AddXY(LotNo, Double.NaN)
                End If
                If YVal2 > 0 Then
                    ChartQty.Series(seriesName2).Points.AddXY(LotNo, YVal2)
                Else
                    ChartQty.Series(seriesName2).Points.AddXY(LotNo, Double.NaN)
                End If
            End If
        Next
    End Sub

    Private Sub ChartbyLot()

        ChartLot.ChartAreas.Clear()
        ChartLot.Titles.Clear()
        ChartLot.Series.Clear()
        ChartLot.Legends.Clear()

        ChartLot.Titles.Add("Kết quả TEST FPI tại công đoạn ETCHING")
        ChartLot.Titles(0).ForeColor = Drawing.Color.Black
        ChartLot.Titles(0).Font = New Drawing.Font("Arial", 12, Drawing.FontStyle.Bold)
        ChartLot.Titles(0).Alignment = ContentAlignment.BottomCenter

        ChartLot.Legends.Add(1)
        ChartLot.Legends(0).Docking = Docking.Bottom
        ChartLot.Legends(0).Alignment = StringAlignment.Center
        ChartLot.Legends(0).LegendStyle = LegendStyle.Row
        ChartLot.Legends(0).TableStyle = LegendTableStyle.Auto

        ChartLot.ChartAreas.Add("ChartArea1")
        ChartLot.ChartAreas("ChartArea1").AxisX.Interval = 1
        ChartLot.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
        'ChartLot.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -90
        ChartLot.ChartAreas("ChartArea1").AxisY.LabelStyle.Format = "N0"
        ChartLot.ChartAreas("ChartArea1").AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot
        ChartLot.ChartAreas("ChartArea1").AxisY2.MajorGrid.LineDashStyle = ChartDashStyle.NotSet
        ChartLot.ChartAreas("ChartArea1").AxisY.TitleAlignment = StringAlignment.Far
        ChartLot.ChartAreas("ChartArea1").AxisY2.TitleAlignment = StringAlignment.Near
        ChartLot.ChartAreas("ChartArea1").AxisY.Title = "Số cuộn"
        ChartLot.ChartAreas("ChartArea1").AxisY2.Title = "%"
        ChartLot.ChartAreas("ChartArea1").AxisY2.Maximum = 100
        ChartLot.ChartAreas("ChartArea1").AxisY.TextOrientation = TextOrientation.Horizontal
        ChartLot.ChartAreas("ChartArea1").BackColor = Color.White
        ChartLot.BackColor = Color.WhiteSmoke

        Dim seriesName As String = ""

        For Each r As DataGridViewRow In gridLot.Rows
            If r.Cells("CongDoan2").Tag <> "" Then
                seriesName = r.Cells("CongDoan2").Tag
                If seriesName.Contains("Tỷ lệ") Then
                    ChartLot.Series.Add(seriesName)
                    ChartLot.Series(seriesName).ChartType = SeriesChartType.Line
                    ChartLot.Series(seriesName).BorderWidth = 3
                    ChartLot.Series(seriesName).IsXValueIndexed = True
                    ChartLot.Series(seriesName).IsValueShownAsLabel = True
                    ChartLot.Series(seriesName).LabelFormat = "N1"
                    ChartLot.Series(seriesName).Color = Color.Red
                    ChartLot.Series(seriesName).YAxisType = AxisType.Secondary

                    Dim YVal1 As Decimal = 0
                    Dim YVal2 As Decimal = 0
                    If r.Cells("LotNo").Value IsNot DBNull.Value Then
                        YVal1 = r.Cells("LotNo").Value
                    End If
                    If r.Cells("LotNo").Tag IsNot DBNull.Value Then
                        YVal2 = r.Cells("LotNo").Tag
                    End If

                    If YVal1 > 0 Then
                        ChartLot.Series(seriesName).Points.AddXY(serialW1, YVal1)
                    Else
                        ChartLot.Series(seriesName).Points.AddXY(serialW1, Double.NaN)
                    End If

                    If YVal2 > 0 Then
                        ChartLot.Series(seriesName).Points.AddXY(serialW2, YVal2)
                    Else
                        ChartLot.Series(seriesName).Points.AddXY(serialW2, Double.NaN)
                    End If
                Else
                    ChartLot.Series.Add(seriesName)
                    ChartLot.Series(seriesName).ChartType = SeriesChartType.Column
                    ChartLot.Series(seriesName).BorderWidth = 2
                    ChartLot.Series(seriesName).IsXValueIndexed = True
                    ChartLot.Series(seriesName).IsValueShownAsLabel = True
                    ChartLot.Series(seriesName).LabelFormat = "N0"

                    Dim YVal1 As Decimal = 0
                    Dim YVal2 As Decimal = 0
                    If r.Cells("LotNo").Value IsNot DBNull.Value Then
                        YVal1 = r.Cells("LotNo").Value
                    End If
                    If r.Cells("LotNo").Tag IsNot DBNull.Value Then
                        YVal2 = r.Cells("LotNo").Tag
                    End If

                    If YVal1 > 0 Then
                        ChartLot.Series(seriesName).Points.AddXY(serialW1, YVal1)
                    Else
                        ChartLot.Series(seriesName).Points.AddXY(serialW1, Double.NaN)
                    End If

                    If YVal2 > 0 Then
                        ChartLot.Series(seriesName).Points.AddXY(serialW2, YVal2)
                    Else
                        ChartLot.Series(seriesName).Points.AddXY(serialW2, Double.NaN)
                    End If
                End If
                
            End If
        Next
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        gridLot.RowCount = 0
        gridLot.RowCount = 9
        gridLot.Rows(0).Cells("CongDoan2").Value = "Số lô kiểm tra"
        gridLot.Rows(1).Cells("CongDoan2").Value = "Số lô NG"
        gridLot.Rows(2).Cells("CongDoan2").Value = "Tỉ lệ NG"
        gridLot.Rows(3).Cells("CongDoan2").Value = "Tái FPI lần 2"
        gridLot.Rows(4).Cells("CongDoan2").Value = "Tái FPI lần 3"
        gridLot.Rows(5).Cells("CongDoan2").Value = "Tái FPI lần 4"
        gridLot.Rows(6).Cells("CongDoan2").Value = "Tái FPI lần 5"
        gridLot.Rows(7).Cells("CongDoan2").Value = "Tỷ lệ tái FPI"
        gridLot.Rows(8).Cells("CongDoan2").Value = "Bao nhiêu cuộn CNĐB"

        gridLot.Rows(0).Cells("CongDoan2").Tag = "Số cuộn test FPI"
        gridLot.Rows(1).Cells("CongDoan2").Tag = ""
        gridLot.Rows(2).Cells("CongDoan2").Tag = ""
        gridLot.Rows(3).Cells("CongDoan2").Tag = "Lần 1"
        gridLot.Rows(4).Cells("CongDoan2").Tag = "Lần 2"
        gridLot.Rows(5).Cells("CongDoan2").Tag = "Lần 3"
        gridLot.Rows(6).Cells("CongDoan2").Tag = "Lần 4"
        gridLot.Rows(7).Cells("CongDoan2").Tag = "Tỷ lệ tái FPI"
        gridLot.Rows(8).Cells("CongDoan2").Tag = ""

        gridQty.RowCount = 0
        gridQty.RowCount = 2
        gridQty.Rows(0).Cells("CongDoan").Value = "W1"
        gridQty.Rows(1).Cells("CongDoan").Value = "% Defect"

        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", dtpDateS.Value.Date)
        para(1) = New SqlClient.SqlParameter("@EndDate", dtpDateE.Value.Date)

        Dim para2(1) As SqlClient.SqlParameter
        para2(0) = New SqlClient.SqlParameter("@StartDate", dtpDateS.Value.Date.AddDays(-7))
        para2(1) = New SqlClient.SqlParameter("@EndDate", dtpDateS.Value.Date.AddDays(-1))

        serialW1 = dtpDateS.Value.Date.ToString("dd/MM") & "~" & dtpDateE.Value.Date.ToString("dd/MM")
        serialW2 = dtpDateS.Value.Date.AddDays(-7).ToString("dd/MM") & "~" & dtpDateS.Value.Date.AddDays(-1).ToString("dd/MM")

        Dim dtSumLotNo As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_SummaryLotno", para)
        Dim dtSumLotNo2 As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_SummaryLotno", para2)
        Dim dtSumQtyW1 As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_SummaryQty", para)
        Dim dtSumQtyW2 As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_SummaryQty", para2)

        gridLot.Rows(0).Cells("LotNo").Value = dtSumLotNo.Compute("sum(TotalLotNo)", "CongDoan='TotalLotNo'")
        gridLot.Rows(1).Cells("LotNo").Value = dtSumLotNo.Compute("sum(TotalLotNo)", "CongDoan='TotalLotNG'")
        If IsNumeric(gridLot.Rows(1).Cells("LotNo").Value) Then
            gridLot.Rows(2).Cells("LotNo").Value = CType(gridLot.Rows(1).Cells("LotNo").Value * 100.0 / gridLot.Rows(0).Cells("LotNo").Value, Decimal).ToString("N2")
        Else
            gridLot.Rows(2).Cells("LotNo").Value = DBNull.Value
        End If
        gridLot.Rows(3).Cells("LotNo").Value = dtSumLotNo.Compute("sum(TotalLotNo)", "CongDoan='FPI2'")
        gridLot.Rows(4).Cells("LotNo").Value = dtSumLotNo.Compute("sum(TotalLotNo)", "CongDoan='FPI3'")
        gridLot.Rows(5).Cells("LotNo").Value = dtSumLotNo.Compute("sum(TotalLotNo)", "CongDoan='FPI4'")
        gridLot.Rows(6).Cells("LotNo").Value = dtSumLotNo.Compute("sum(TotalLotNo)", "CongDoan='FPI5'")
        gridLot.Rows(8).Cells("LotNo").Value = dtSumLotNo.Compute("sum(TotalLotNo)", "CongDoan='CNDB'")

        gridLot.Rows(0).Cells("TG").Value = dtSumLotNo.Compute("sum(TG)", "CongDoan='TotalLotNo'")
        gridLot.Rows(1).Cells("TG").Value = dtSumLotNo.Compute("sum(TG)", "CongDoan='TotalLotNG'")
        gridLot.Rows(2).Cells("TG").Value = DBNull.Value
        gridLot.Rows(3).Cells("TG").Value = dtSumLotNo.Compute("sum(TG)", "CongDoan='FPI2'")
        gridLot.Rows(4).Cells("TG").Value = dtSumLotNo.Compute("sum(TG)", "CongDoan='FPI3'")
        gridLot.Rows(5).Cells("TG").Value = dtSumLotNo.Compute("sum(TG)", "CongDoan='FPI4'")
        gridLot.Rows(6).Cells("TG").Value = dtSumLotNo.Compute("sum(TG)", "CongDoan='FPI5'")
        gridLot.Rows(8).Cells("TG").Value = dtSumLotNo.Compute("sum(TG)", "CongDoan='CNDB'")

        gridLot.Rows(7).Cells("LotNo").Value = CType((gridLot.Rows(3).Cells("LotNo").Value + gridLot.Rows(4).Cells("LotNo").Value +
                                     gridLot.Rows(5).Cells("LotNo").Value + gridLot.Rows(6).Cells("LotNo").Value) * 100.0 / gridLot.Rows(0).Cells("LotNo").Value, Decimal).ToString("N2")

        If dtSumLotNo2.Rows.Count > 0 Then
            gridLot.Rows(0).Cells("LotNo").Tag = dtSumLotNo2.Compute("sum(TotalLotNo)", "CongDoan='TotalLotNo'")
            gridLot.Rows(1).Cells("LotNo").Tag = dtSumLotNo2.Compute("sum(TotalLotNo)", "CongDoan='TotalLotNG'")
            If IsNumeric(gridLot.Rows(1).Cells("LotNo").Tag) Then
                gridLot.Rows(2).Cells("LotNo").Tag = CType(gridLot.Rows(1).Cells("LotNo").Tag * 100.0 / gridLot.Rows(0).Cells("LotNo").Tag, Decimal).ToString("N2")
            Else
                gridLot.Rows(2).Cells("LotNo").Tag = DBNull.Value
            End If
            gridLot.Rows(3).Cells("LotNo").Tag = dtSumLotNo2.Compute("sum(TotalLotNo)", "CongDoan='FPI2'")
            gridLot.Rows(4).Cells("LotNo").Tag = dtSumLotNo2.Compute("sum(TotalLotNo)", "CongDoan='FPI3'")
            gridLot.Rows(5).Cells("LotNo").Tag = dtSumLotNo2.Compute("sum(TotalLotNo)", "CongDoan='FPI4'")
            gridLot.Rows(6).Cells("LotNo").Tag = dtSumLotNo2.Compute("sum(TotalLotNo)", "CongDoan='FPI5'")
            gridLot.Rows(8).Cells("LotNo").Tag = dtSumLotNo2.Compute("sum(TotalLotNo)", "CongDoan='CNDB'")

            gridLot.Rows(0).Cells("TG").Tag = dtSumLotNo2.Compute("sum(TG)", "CongDoan='TotalLotNo'")
            gridLot.Rows(1).Cells("TG").Tag = dtSumLotNo2.Compute("sum(TG)", "CongDoan='TotalLotNG'")
            gridLot.Rows(2).Cells("TG").Tag = DBNull.Value
            gridLot.Rows(3).Cells("TG").Tag = dtSumLotNo2.Compute("sum(TG)", "CongDoan='FPI2'")
            gridLot.Rows(4).Cells("TG").Tag = dtSumLotNo2.Compute("sum(TG)", "CongDoan='FPI3'")
            gridLot.Rows(5).Cells("TG").Tag = dtSumLotNo2.Compute("sum(TG)", "CongDoan='FPI4'")
            gridLot.Rows(6).Cells("TG").Tag = dtSumLotNo2.Compute("sum(TG)", "CongDoan='FPI5'")
            gridLot.Rows(8).Cells("TG").Tag = dtSumLotNo2.Compute("sum(TG)", "CongDoan='CNDB'")

            gridLot.Rows(7).Cells("LotNo").Tag = (gridLot.Rows(3).Cells("LotNo").Tag + gridLot.Rows(4).Cells("LotNo").Tag +
                                                 gridLot.Rows(5).Cells("LotNo").Tag + gridLot.Rows(6).Cells("LotNo").Tag) * 100.0 / gridLot.Rows(0).Cells("LotNo").Tag

        End If

        gridQty.Rows(0).Cells("Q001").Value = dtSumQtyW1.Compute("sum(Q001)", "")
        gridQty.Rows(0).Cells("Q002").Value = dtSumQtyW1.Compute("sum(Q002)", "")
        gridQty.Rows(0).Cells("Q003").Value = dtSumQtyW1.Compute("sum(Q003)", "")
        gridQty.Rows(0).Cells("Q004").Value = dtSumQtyW1.Compute("sum(Q004)", "")
        gridQty.Rows(0).Cells("Q005").Value = dtSumQtyW1.Compute("sum(Q005)", "")
        gridQty.Rows(0).Cells("Q006").Value = dtSumQtyW1.Compute("sum(Q006)", "")
        gridQty.Rows(0).Cells("Q007").Value = dtSumQtyW1.Compute("sum(Q007)", "")
        gridQty.Rows(0).Cells("Q627").Value = dtSumQtyW1.Compute("sum(Q627)", "")
        gridQty.Rows(0).Cells("Q639").Value = dtSumQtyW1.Compute("sum(Q639)", "")

        gridQty.Rows(1).Cells("Q001").Value = CType(dtSumQtyW1.Compute("sum(R001)", ""), Decimal).ToString("N2")
        gridQty.Rows(1).Cells("Q002").Value = CType(dtSumQtyW1.Compute("sum(R002)", ""), Decimal).ToString("N2")
        gridQty.Rows(1).Cells("Q003").Value = CType(dtSumQtyW1.Compute("sum(R003)", ""), Decimal).ToString("N2")
        gridQty.Rows(1).Cells("Q004").Value = CType(dtSumQtyW1.Compute("sum(R004)", ""), Decimal).ToString("N2")
        gridQty.Rows(1).Cells("Q005").Value = CType(dtSumQtyW1.Compute("sum(R005)", ""), Decimal).ToString("N2")
        gridQty.Rows(1).Cells("Q006").Value = CType(dtSumQtyW1.Compute("sum(R006)", ""), Decimal).ToString("N2")
        gridQty.Rows(1).Cells("Q007").Value = CType(dtSumQtyW1.Compute("sum(R007)", ""), Decimal).ToString("N2")
        gridQty.Rows(1).Cells("Q627").Value = CType(dtSumQtyW1.Compute("sum(R627)", ""), Decimal).ToString("N2")
        gridQty.Rows(1).Cells("Q639").Value = CType(dtSumQtyW1.Compute("sum(R639)", ""), Decimal).ToString("N2")

        If dtSumQtyW2.Rows.Count > 0 Then
            gridQty.Rows(0).Cells("Q001").Tag = dtSumQtyW2.Compute("sum(Q001)", "")
            gridQty.Rows(0).Cells("Q002").Tag = dtSumQtyW2.Compute("sum(Q002)", "")
            gridQty.Rows(0).Cells("Q003").Tag = dtSumQtyW2.Compute("sum(Q003)", "")
            gridQty.Rows(0).Cells("Q004").Tag = dtSumQtyW2.Compute("sum(Q004)", "")
            gridQty.Rows(0).Cells("Q005").Tag = dtSumQtyW2.Compute("sum(Q005)", "")
            gridQty.Rows(0).Cells("Q006").Tag = dtSumQtyW2.Compute("sum(Q006)", "")
            gridQty.Rows(0).Cells("Q007").Tag = dtSumQtyW2.Compute("sum(Q007)", "")
            gridQty.Rows(0).Cells("Q627").Tag = dtSumQtyW2.Compute("sum(Q627)", "")
            gridQty.Rows(0).Cells("Q639").Tag = dtSumQtyW2.Compute("sum(Q639)", "")

            gridQty.Rows(1).Cells("Q001").Tag = CType(dtSumQtyW2.Compute("sum(R001)", ""), Decimal).ToString("N2")
            gridQty.Rows(1).Cells("Q002").Tag = CType(dtSumQtyW2.Compute("sum(R002)", ""), Decimal).ToString("N2")
            gridQty.Rows(1).Cells("Q003").Tag = CType(dtSumQtyW2.Compute("sum(R003)", ""), Decimal).ToString("N2")
            gridQty.Rows(1).Cells("Q004").Tag = CType(dtSumQtyW2.Compute("sum(R004)", ""), Decimal).ToString("N2")
            gridQty.Rows(1).Cells("Q005").Tag = CType(dtSumQtyW2.Compute("sum(R005)", ""), Decimal).ToString("N2")
            gridQty.Rows(1).Cells("Q006").Tag = CType(dtSumQtyW2.Compute("sum(R006)", ""), Decimal).ToString("N2")
            gridQty.Rows(1).Cells("Q007").Tag = CType(dtSumQtyW2.Compute("sum(R007)", ""), Decimal).ToString("N2")
            gridQty.Rows(1).Cells("Q627").Tag = CType(dtSumQtyW2.Compute("sum(R627)", ""), Decimal).ToString("N2")
            gridQty.Rows(1).Cells("Q639").Tag = CType(dtSumQtyW2.Compute("sum(R639)", ""), Decimal).ToString("N2")
        End If

        Chart()
        ChartbyLot()
    End Sub

    Private Sub FrmSummary_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        dtpDateS.Value = GetFirstDayOfWeek(DateTime.Now)
        dtpDateE.Value = dtpDateS.Value.AddDays(6)
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        Dim lst As New List(Of DataGridView)
        lst.Add(gridQty)
        lst.Add(gridLot)
        ExportEXCEL(lst)
    End Sub

    Private Sub mnuSaveImage_Click(sender As System.Object, e As System.EventArgs) Handles mnuSaveImage.Click
        Dim path As String = ""
        Dim frm As New SaveFileDialog
        frm.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|All files (*.*)|*.*"
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            ChartQty.SaveImage(frm.FileName, Imaging.ImageFormat.Jpeg)
            If File.Exists(frm.FileName) Then
                Process.Start(frm.FileName)
            End If
        End If
    End Sub

    Private Sub mnuSaveImageLotno_Click(sender As System.Object, e As System.EventArgs) Handles mnuSaveImageLotno.Click
        Dim path As String = ""
        Dim frm As New SaveFileDialog
        frm.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|All files (*.*)|*.*"
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            ChartLot.SaveImage(frm.FileName, Imaging.ImageFormat.Jpeg)
            If File.Exists(frm.FileName) Then
                Process.Start(frm.FileName)
            End If
        End If
    End Sub
End Class