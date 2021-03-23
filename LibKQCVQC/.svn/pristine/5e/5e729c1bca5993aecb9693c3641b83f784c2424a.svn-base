Imports System.Windows.Forms
Imports CommonDB
Imports PublicUtility
Imports System.Drawing
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO

Public Class FrmSummaryNew : Inherits DevExpress.XtraEditors.XtraForm

	Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
	Dim serialW1 As String = ""
	Dim serialW2 As String = ""
	Dim mySide As String = "All"

	Private Sub ChartbyLot()

		ChartLot.ChartAreas.Clear()
		ChartLot.Titles.Clear()
		ChartLot.Series.Clear()
		ChartLot.Legends.Clear()

		ChartLot.Titles.Add(String.Format("Kết quả TEST FPI tại công đoạn ETCHING ({0})", mySide))
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
			If r.Cells(ItemNameFPI.Name).Tag <> "" Then
				seriesName = r.Cells(ItemNameFPI.Name).Tag
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
					If IsNumeric(r.Cells(AllLotNo.Name).Value) Then
						YVal1 = r.Cells(AllLotNo.Name).Value
					End If
					If IsNumeric(r.Cells(AllLotNo.Name).Tag) Then
						YVal2 = r.Cells(AllLotNo.Name).Tag
					End If

					If YVal2 > 0 Or YVal1 > 0 Then
						If YVal2 > 0 Then
							ChartLot.Series(seriesName).Points.AddXY(serialW2, YVal2)
						Else
							ChartLot.Series(seriesName).Points.AddXY(serialW2, 0)
						End If

						If YVal1 > 0 Then
							ChartLot.Series(seriesName).Points.AddXY(serialW1, YVal1)
						Else
							ChartLot.Series(seriesName).Points.AddXY(serialW1, 0)
						End If
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
					If IsNumeric(r.Cells(AllLotNo.Name).Value) Then
						YVal1 = r.Cells(AllLotNo.Name).Value
					End If
					If IsNumeric(r.Cells(AllLotNo.Name).Tag) Then
						YVal2 = r.Cells(AllLotNo.Name).Tag
					End If


					If YVal2 > 0 Then
						ChartLot.Series(seriesName).Points.AddXY(serialW2, YVal2)
					Else
						ChartLot.Series(seriesName).Points.AddXY(serialW2, Double.NaN)
					End If

					If YVal1 > 0 Then
						ChartLot.Series(seriesName).Points.AddXY(serialW1, YVal1)
					Else
						ChartLot.Series(seriesName).Points.AddXY(serialW1, Double.NaN)
					End If
				End If

			End If
		Next
	End Sub

	Private Sub ChartModeLoi()

		ChartQty.ChartAreas.Clear()
		ChartQty.Titles.Clear()
		ChartQty.Series.Clear()
		ChartQty.Legends.Clear()

		ChartQty.Titles.Add(String.Format("Số lượng lỗi phát hiện tại Photo ({0})", mySide))
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

		Dim seriesName2 As String = serialW2 & " (2)"
		ChartQty.Series.Add(seriesName2)
		ChartQty.Series(seriesName2).ChartType = SeriesChartType.Column
		ChartQty.Series(seriesName2).BorderWidth = 2
		ChartQty.Series(seriesName2).IsXValueIndexed = True
		ChartQty.Series(seriesName2).IsValueShownAsLabel = True
		ChartQty.Series(seriesName2).LabelFormat = "N0"
		ChartQty.Series(seriesName2).Color = Color.DeepSkyBlue

		Dim seriesName1 As String = serialW1 & " (1)"
		ChartQty.Series.Add(seriesName1)
		ChartQty.Series(seriesName1).ChartType = SeriesChartType.Column
		ChartQty.Series(seriesName1).BorderWidth = 2
		ChartQty.Series(seriesName1).IsXValueIndexed = True
		ChartQty.Series(seriesName1).IsValueShownAsLabel = True
		ChartQty.Series(seriesName1).LabelFormat = "N0"
		ChartQty.Series(seriesName1).Color = Color.Orange



		For Each c As DataGridViewColumn In gridQty.Columns
			If rdoSingle.Checked Then
				If c.Name = "Q001" Or c.Name = "Q002" Or
					c.Name = "Q003" Or c.Name = "Q004" Or
					c.Name = "Q005" Or c.Name = "Q006" Or
					c.Name = "Q007" Or c.Name = "Q009" Or
					c.Name = "Q012" Or c.Name = "Q024" Then
					Dim YVal1 As Decimal = 0
					Dim YVal2 As Decimal = 0
					If IsNumeric(gridQty.Rows(0).Cells(c.Name).Value) Then
						YVal1 = gridQty.Rows(0).Cells(c.Name).Value
					End If
					If IsNumeric(gridQty.Rows(0).Cells(c.Name).Tag) Then
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
			Else
				If c.Name <> ModeLoi.Name Then
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
			End If
		Next
	End Sub

	Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
		If rdoSingle.Checked Then
			mySide = rdoSingle.Text
		End If
		If rdoDoubleSide.Checked Then
			mySide = rdoDoubleSide.Text
		End If

		gridLot.RowCount = 0
		gridLot.RowCount = 9
		Dim num As Integer = gridLot.Rows.Count
		gridLot.Rows(0).Cells("ItemNameFPI").Value = "Số lô kiểm tra (LẦN 1)"
		gridLot.Rows(1).Cells("ItemNameFPI").Value = "Số lô NG (LẦN 1)"
		gridLot.Rows(2).Cells("ItemNameFPI").Value = "Tỉ lệ NG"
		gridLot.Rows(3).Cells("ItemNameFPI").Value = "FPI lần 2"
		gridLot.Rows(4).Cells("ItemNameFPI").Value = "FPI lần 3"
		gridLot.Rows(5).Cells("ItemNameFPI").Value = "FPI lần 4"
		gridLot.Rows(6).Cells("ItemNameFPI").Value = "FPI lần 5"
		gridLot.Rows(7).Cells("ItemNameFPI").Value = "Tỷ lệ tái FPI"
		gridLot.Rows(8).Cells("ItemNameFPI").Value = "Bao nhiêu cuộn CNĐB"

		gridLot.Rows(0).Cells("ItemNameFPI").Tag = "Số cuộn test FPI"
		gridLot.Rows(1).Cells("ItemNameFPI").Tag = ""
		gridLot.Rows(2).Cells("ItemNameFPI").Tag = ""
		gridLot.Rows(3).Cells("ItemNameFPI").Tag = "Lần 1"
		gridLot.Rows(4).Cells("ItemNameFPI").Tag = "Lần 2"
		gridLot.Rows(5).Cells("ItemNameFPI").Tag = "Lần 3"
		gridLot.Rows(6).Cells("ItemNameFPI").Tag = "Lần 4"
		gridLot.Rows(7).Cells("ItemNameFPI").Tag = "Tỷ lệ tái FPI"
		gridLot.Rows(8).Cells("ItemNameFPI").Tag = ""

		gridQty.RowCount = 0
		gridQty.RowCount = 6
		gridQty.Rows(0).Cells(ModeLoi.Name).Value = "SG"
		gridQty.Rows(1).Cells(ModeLoi.Name).Value = "TSB"
		gridQty.Rows(2).Cells(ModeLoi.Name).Value = "HGST"
		gridQty.Rows(3).Cells(ModeLoi.Name).Value = "WD"
		gridQty.Rows(4).Cells(ModeLoi.Name).Value = "OTHER"
		gridQty.Rows(5).Cells(ModeLoi.Name).Value = "All"

		Dim para(2) As SqlClient.SqlParameter
		If rdoWeek.Checked Then
			para(0) = New SqlClient.SqlParameter("@StartDate", dtpDateS.Value.Date)
			para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dtpDateE.Value.Date))
		Else
			para(0) = New SqlClient.SqlParameter("@StartDate", dtpDateE.Value.Date)
			para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dtpDateE.Value.Date))
		End If
		para(2) = New SqlClient.SqlParameter("@Type", "All")
		If rdoDoubleSide.Checked Then
			para(2) = New SqlClient.SqlParameter("@Type", rdoDoubleSide.Text)
		ElseIf rdoSingle.Checked Then
			para(2) = New SqlClient.SqlParameter("@Type", rdoSingle.Text)
		End If

		Dim para2(2) As SqlClient.SqlParameter
		If rdoWeek.Checked Then
			para2(0) = New SqlClient.SqlParameter("@StartDate", dtpDateS.Value.Date.AddDays(-7))
			para2(1) = New SqlClient.SqlParameter("@EndDate", dtpDateS.Value.Date.AddDays(-1))
		Else
			para2(0) = New SqlClient.SqlParameter("@StartDate", dtpDateS.Value.Date)
			para2(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dtpDateS.Value.Date))
		End If
		para2(2) = New SqlClient.SqlParameter("@Type", "All")
		If rdoDoubleSide.Checked Then
			para2(2) = New SqlClient.SqlParameter("@Type", rdoDoubleSide.Text)
		ElseIf rdoSingle.Checked Then
			para2(2) = New SqlClient.SqlParameter("@Type", rdoSingle.Text)
		End If
		If rdoWeek.Checked Then
			serialW1 = dtpDateS.Value.Date.ToString("dd/MM") & "~" & dtpDateE.Value.Date.ToString("dd/MM")
			serialW2 = dtpDateS.Value.Date.AddDays(-7).ToString("dd/MM") & "~" & dtpDateS.Value.Date.AddDays(-1).ToString("dd/MM")

		Else
			serialW1 = dtpDateE.Value.Date.ToString("dd/MM")
			serialW2 = dtpDateS.Value.Date.ToString("dd/MM")
		End If
		Dim dtSumLotNo As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_SummaryLotnoN", para)
		Dim dtSumLotNo2 As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_SummaryLotnoN", para2)
		Dim dtSumQtyW1 As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_SummaryQtyN", para)
		Dim dtSumQtyW2 As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_SummaryQtyN", para2)

		''''SG----------------------------

		For Each c As DataGridViewColumn In gridLot.Columns
			If c.Index = 0 Then
				Continue For
			End If
			Dim mCS As String = c.HeaderText.Split(" ")(0)

			If c.HeaderText.Contains("LotNo") Then
				gridLot.Rows(0).Cells(c.Name).Value = dtSumLotNo.Compute("sum(TotalLotNo)", String.Format("CongDoan='TotalLotNo'  and Customer='{0}'", mCS))
				gridLot.Rows(1).Cells(c.Name).Value = dtSumLotNo.Compute("sum(TotalLotNo)", String.Format("CongDoan='TotalLotNG'  and Customer='{0}'", mCS))
				If IsNumeric(gridLot.Rows(1).Cells(c.Name).Value) Then
					gridLot.Rows(2).Cells(c.Name).Value = CType(gridLot.Rows(1).Cells(c.Name).Value * 100.0 /
																gridLot.Rows(0).Cells(c.Name).Value,
																Decimal).ToString("N2")
				Else
					gridLot.Rows(2).Cells(c.Name).Value = DBNull.Value
				End If
				gridLot.Rows(3).Cells(c.Name).Value = dtSumLotNo.Compute("sum(TotalLotNo)", String.Format("CongDoan='FPI2' and Customer='{0}'", mCS))
				gridLot.Rows(4).Cells(c.Name).Value = dtSumLotNo.Compute("sum(TotalLotNo)", String.Format("CongDoan='FPI3' and Customer='{0}'", mCS))
				gridLot.Rows(5).Cells(c.Name).Value = dtSumLotNo.Compute("sum(TotalLotNo)", String.Format("CongDoan='FPI4' and Customer='{0}'", mCS))
				gridLot.Rows(6).Cells(c.Name).Value = dtSumLotNo.Compute("sum(TotalLotNo)", String.Format("CongDoan='FPI5' and Customer='{0}'", mCS))
				gridLot.Rows(8).Cells(c.Name).Value = dtSumLotNo.Compute("sum(TotalLotNo)", String.Format("CongDoan='CNDB' and Customer='{0}'", mCS))
				If gridLot.Rows(0).Cells(c.Name).Value IsNot DBNull.Value Then
					gridLot.Rows(7).Cells(c.Name).Value = CType((
										IIf(IsDBNull(gridLot.Rows(3).Cells(c.Name).Value), 0, gridLot.Rows(3).Cells(c.Name).Value) +
										 IIf(IsDBNull(gridLot.Rows(4).Cells(c.Name).Value), 0, gridLot.Rows(4).Cells(c.Name).Value) +
										 IIf(IsDBNull(gridLot.Rows(5).Cells(c.Name).Value), 0, gridLot.Rows(5).Cells(c.Name).Value) +
										 IIf(IsDBNull(gridLot.Rows(6).Cells(c.Name).Value), 0, gridLot.Rows(6).Cells(c.Name).Value)) * 100.0 /
										 gridLot.Rows(0).Cells(c.Name).Value,
										 Decimal).ToString("N2")
				End If
			Else
				gridLot.Rows(0).Cells(c.Name).Value = dtSumLotNo.Compute("sum(TG)", String.Format("CongDoan='TotalLotNo' and Customer='{0}'", mCS))
				gridLot.Rows(1).Cells(c.Name).Value = dtSumLotNo.Compute("sum(TG)", String.Format("CongDoan='TotalLotNG' and Customer='{0}'", mCS))
				gridLot.Rows(2).Cells(c.Name).Value = DBNull.Value
				gridLot.Rows(3).Cells(c.Name).Value = dtSumLotNo.Compute("sum(TG)", String.Format("CongDoan='FPI2' and Customer='{0}'", mCS))
				gridLot.Rows(4).Cells(c.Name).Value = dtSumLotNo.Compute("sum(TG)", String.Format("CongDoan='FPI3' and Customer='{0}'", mCS))
				gridLot.Rows(5).Cells(c.Name).Value = dtSumLotNo.Compute("sum(TG)", String.Format("CongDoan='FPI4' and Customer='{0}'", mCS))
				gridLot.Rows(6).Cells(c.Name).Value = dtSumLotNo.Compute("sum(TG)", String.Format("CongDoan='FPI5' and Customer='{0}'", mCS))
				gridLot.Rows(8).Cells(c.Name).Value = dtSumLotNo.Compute("sum(TG)", String.Format("CongDoan='CNDB' and Customer='{0}'", mCS))
			End If

		Next

		If dtSumLotNo2.Rows.Count > 0 Then
			For Each c As DataGridViewColumn In gridLot.Columns
				If c.Index = 0 Then
					Continue For
				End If
				Dim mCS As String = c.HeaderText.Split(" ")(0)

				If c.HeaderText.Contains("LotNo") Then
					gridLot.Rows(0).Cells(c.Name).Tag = dtSumLotNo2.Compute("sum(TotalLotNo)", String.Format("CongDoan='TotalLotNo'  and Customer='{0}'", mCS))
					gridLot.Rows(1).Cells(c.Name).Tag = dtSumLotNo2.Compute("sum(TotalLotNo)", String.Format("CongDoan='TotalLotNG'  and Customer='{0}'", mCS))
					If IsNumeric(gridLot.Rows(1).Cells(c.Name).Tag) Then
						gridLot.Rows(2).Cells(c.Name).Tag = CType(gridLot.Rows(1).Cells(c.Name).Tag * 100.0 /
							gridLot.Rows(0).Cells(c.Name).Tag, Decimal).ToString("N2")
					Else
						gridLot.Rows(2).Cells(c.Name).Tag = DBNull.Value
					End If
					gridLot.Rows(3).Cells(c.Name).Tag = dtSumLotNo2.Compute("sum(TotalLotNo)", String.Format("CongDoan='FPI2' and Customer='{0}'", mCS))
					gridLot.Rows(4).Cells(c.Name).Tag = dtSumLotNo2.Compute("sum(TotalLotNo)", String.Format("CongDoan='FPI3' and Customer='{0}'", mCS))
					gridLot.Rows(5).Cells(c.Name).Tag = dtSumLotNo2.Compute("sum(TotalLotNo)", String.Format("CongDoan='FPI4' and Customer='{0}'", mCS))
					gridLot.Rows(6).Cells(c.Name).Tag = dtSumLotNo2.Compute("sum(TotalLotNo)", String.Format("CongDoan='FPI5' and Customer='{0}'", mCS))
					gridLot.Rows(8).Cells(c.Name).Tag = dtSumLotNo2.Compute("sum(TotalLotNo)", String.Format("CongDoan='CNDB' and Customer='{0}'", mCS))
					If gridLot.Rows(0).Cells(c.Name).Tag IsNot DBNull.Value Then
						gridLot.Rows(7).Cells(c.Name).Tag = CType((
										IIf(IsDBNull(gridLot.Rows(3).Cells(c.Name).Tag), 0, gridLot.Rows(3).Cells(c.Name).Tag) +
										 IIf(IsDBNull(gridLot.Rows(4).Cells(c.Name).Tag), 0, gridLot.Rows(4).Cells(c.Name).Tag) +
										 IIf(IsDBNull(gridLot.Rows(5).Cells(c.Name).Tag), 0, gridLot.Rows(5).Cells(c.Name).Tag) +
										 IIf(IsDBNull(gridLot.Rows(6).Cells(c.Name).Tag), 0, gridLot.Rows(5).Cells(c.Name).Tag)) * 100.0 /
										 gridLot.Rows(0).Cells(c.Name).Tag,
										 Decimal).ToString("N2")
					End If
				Else
					gridLot.Rows(0).Cells(c.Name).Tag = dtSumLotNo2.Compute("sum(TG)", String.Format("CongDoan='TotalLotNo' and Customer='{0}'", mCS))
					gridLot.Rows(1).Cells(c.Name).Tag = dtSumLotNo2.Compute("sum(TG)", String.Format("CongDoan='TotalLotNG' and Customer='{0}'", mCS))
					gridLot.Rows(2).Cells(c.Name).Tag = DBNull.Value
					gridLot.Rows(3).Cells(c.Name).Tag = dtSumLotNo2.Compute("sum(TG)", String.Format("CongDoan='FPI2' and Customer='{0}'", mCS))
					gridLot.Rows(4).Cells(c.Name).Tag = dtSumLotNo2.Compute("sum(TG)", String.Format("CongDoan='FPI3' and Customer='{0}'", mCS))
					gridLot.Rows(5).Cells(c.Name).Tag = dtSumLotNo2.Compute("sum(TG)", String.Format("CongDoan='FPI4' and Customer='{0}'", mCS))
					gridLot.Rows(6).Cells(c.Name).Tag = dtSumLotNo2.Compute("sum(TG)", String.Format("CongDoan='FPI5' and Customer='{0}'", mCS))
					gridLot.Rows(8).Cells(c.Name).Tag = dtSumLotNo2.Compute("sum(TG)", String.Format("CongDoan='CNDB' and Customer='{0}'", mCS))
				End If

			Next

		End If

		For Each r As DataGridViewRow In gridQty.Rows
			For Each c As DataGridViewColumn In gridQty.Columns
				If c.Index = 0 Then
					Continue For
				End If

				r.Cells(c.Name).Value = dtSumQtyW1.Compute("sum(Qty)", String.Format("Customer='{0}' and DefectCode='{1}'",
																					 r.Cells(ModeLoi.Name).Value,
																					 c.Name.Replace("Q", "")))
				'gridQty.Rows(0).Cells("Q002").Value = dtSumQtyW1.Compute("sum(Q002)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
				'gridQty.Rows(0).Cells("Q003").Value = dtSumQtyW1.Compute("sum(Q003)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
				'gridQty.Rows(0).Cells("Q004").Value = dtSumQtyW1.Compute("sum(Q004)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
				'gridQty.Rows(0).Cells("Q005").Value = dtSumQtyW1.Compute("sum(Q005)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
				'gridQty.Rows(0).Cells("Q006").Value = dtSumQtyW1.Compute("sum(Q006)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
				'gridQty.Rows(0).Cells("Q007").Value = dtSumQtyW1.Compute("sum(Q007)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))

				'gridQty.Rows(0).Cells("Q009").Value = dtSumQtyW1.Compute("sum(Q009)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
				'gridQty.Rows(0).Cells("Q012").Value = dtSumQtyW1.Compute("sum(Q012)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
				'gridQty.Rows(0).Cells("Q024").Value = dtSumQtyW1.Compute("sum(Q024)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
				'gridQty.Rows(0).Cells("Q025").Value = dtSumQtyW1.Compute("sum(Q025)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))

				'gridQty.Rows(0).Cells("Q627").Value = dtSumQtyW1.Compute("sum(Q627)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
				'gridQty.Rows(0).Cells("Q639").Value = dtSumQtyW1.Compute("sum(Q639)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))

				'gridQty.Rows(1).Cells("Q001").Value = CType(dtSumQtyW1.Compute("sum(R001)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
				'gridQty.Rows(1).Cells("Q002").Value = CType(dtSumQtyW1.Compute("sum(R002)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
				'gridQty.Rows(1).Cells("Q003").Value = CType(dtSumQtyW1.Compute("sum(R003)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
				'gridQty.Rows(1).Cells("Q004").Value = CType(dtSumQtyW1.Compute("sum(R004)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
				'gridQty.Rows(1).Cells("Q005").Value = CType(dtSumQtyW1.Compute("sum(R005)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
				'gridQty.Rows(1).Cells("Q006").Value = CType(dtSumQtyW1.Compute("sum(R006)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
				'gridQty.Rows(1).Cells("Q007").Value = CType(dtSumQtyW1.Compute("sum(R007)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")

				'gridQty.Rows(1).Cells("Q009").Value = CType(dtSumQtyW1.Compute("sum(R009)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
				'gridQty.Rows(1).Cells("Q012").Value = CType(dtSumQtyW1.Compute("sum(R012)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
				'gridQty.Rows(1).Cells("Q024").Value = CType(dtSumQtyW1.Compute("sum(R024)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
				'gridQty.Rows(1).Cells("Q025").Value = CType(dtSumQtyW1.Compute("sum(R025)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")

				'gridQty.Rows(1).Cells("Q627").Value = CType(dtSumQtyW1.Compute("sum(R627)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
				'gridQty.Rows(1).Cells("Q639").Value = CType(dtSumQtyW1.Compute("sum(R639)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")

				If dtSumQtyW2.Rows.Count > 0 Then
					r.Cells(c.Name).Tag = dtSumQtyW2.Compute("sum(Qty)", String.Format("Customer='{0}' and DefectCode='{1}'",
																					 r.Cells(ModeLoi.Name).Value,
																					 c.Name.Replace("Q", "")))
					'gridQty.Rows(0).Cells("Q002").Tag = dtSumQtyW2.Compute("sum(Q002)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
					'gridQty.Rows(0).Cells("Q003").Tag = dtSumQtyW2.Compute("sum(Q003)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
					'gridQty.Rows(0).Cells("Q004").Tag = dtSumQtyW2.Compute("sum(Q004)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
					'gridQty.Rows(0).Cells("Q005").Tag = dtSumQtyW2.Compute("sum(Q005)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
					'gridQty.Rows(0).Cells("Q006").Tag = dtSumQtyW2.Compute("sum(Q006)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
					'gridQty.Rows(0).Cells("Q007").Tag = dtSumQtyW2.Compute("sum(Q007)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))

					'gridQty.Rows(0).Cells("Q009").Tag = dtSumQtyW2.Compute("sum(Q009)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
					'gridQty.Rows(0).Cells("Q012").Tag = dtSumQtyW2.Compute("sum(Q012)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
					'gridQty.Rows(0).Cells("Q024").Tag = dtSumQtyW2.Compute("sum(Q024)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
					'gridQty.Rows(0).Cells("Q025").Tag = dtSumQtyW2.Compute("sum(Q025)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))

					'gridQty.Rows(0).Cells("Q627").Tag = dtSumQtyW2.Compute("sum(Q627)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))
					'gridQty.Rows(0).Cells("Q639").Tag = dtSumQtyW2.Compute("sum(Q639)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value))

					'gridQty.Rows(1).Cells("Q001").Tag = CType(dtSumQtyW2.Compute("sum(R001)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
					'gridQty.Rows(1).Cells("Q002").Tag = CType(dtSumQtyW2.Compute("sum(R002)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
					'gridQty.Rows(1).Cells("Q003").Tag = CType(dtSumQtyW2.Compute("sum(R003)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
					'gridQty.Rows(1).Cells("Q004").Tag = CType(dtSumQtyW2.Compute("sum(R004)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
					'gridQty.Rows(1).Cells("Q005").Tag = CType(dtSumQtyW2.Compute("sum(R005)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
					'gridQty.Rows(1).Cells("Q006").Tag = CType(dtSumQtyW2.Compute("sum(R006)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
					'gridQty.Rows(1).Cells("Q007").Tag = CType(dtSumQtyW2.Compute("sum(R007)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")

					'gridQty.Rows(1).Cells("Q009").Tag = CType(dtSumQtyW2.Compute("sum(R009)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
					'gridQty.Rows(1).Cells("Q012").Tag = CType(dtSumQtyW2.Compute("sum(R012)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
					'gridQty.Rows(1).Cells("Q024").Tag = CType(dtSumQtyW2.Compute("sum(R024)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
					'gridQty.Rows(1).Cells("Q025").Tag = CType(dtSumQtyW2.Compute("sum(R025)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")

					'gridQty.Rows(1).Cells("Q627").Tag = CType(dtSumQtyW2.Compute("sum(R627)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
					'gridQty.Rows(1).Cells("Q639").Tag = CType(dtSumQtyW2.Compute("sum(R639)", String.Format("Customer='{0}'", r.Cells(ModeLoi.Name).Value)), Decimal).ToString("N2")
				End If
			Next
		Next

		ChartModeLoi()
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