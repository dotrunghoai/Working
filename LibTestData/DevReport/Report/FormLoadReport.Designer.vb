<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class FormLoadReport
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SelectQuery1 As DevExpress.DataAccess.Sql.SelectQuery = New DevExpress.DataAccess.Sql.SelectQuery()
        Dim Column1 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression1 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Table1 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim Column2 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression2 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column3 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression3 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column4 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression4 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column5 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression5 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column6 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression6 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column7 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression7 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLoadReport))
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim PieSeriesView1 As DevExpress.XtraCharts.PieSeriesView = New DevExpress.XtraCharts.PieSeriesView()
        Dim XyDiagram2 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series3 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Me.SqlDataSource1 = New DevExpress.DataAccess.Sql.SqlDataSource(Me.components)
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.XrControlStyle2 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.GroupHeader2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrChart1 = New DevExpress.XtraReports.UI.XRChart()
        Me.TimeSpanChartRangeControlClient1 = New DevExpress.XtraEditors.TimeSpanChartRangeControlClient()
        Me.TimeSpanChartRangeControlClient2 = New DevExpress.XtraEditors.TimeSpanChartRangeControlClient()
        Me.TimeSpanChartRangeControlClient3 = New DevExpress.XtraEditors.TimeSpanChartRangeControlClient()
        Me.GroupHeader3 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrChart2 = New DevExpress.XtraReports.UI.XRChart()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupHeader4 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrChart3 = New DevExpress.XtraReports.UI.XRChart()
        Me.XrControlStyle3 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.lbcGio = New DevExpress.XtraReports.UI.XRTableCell()
        Me.lbcNgay = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrChart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeSpanChartRangeControlClient1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeSpanChartRangeControlClient2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeSpanChartRangeControlClient3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrChart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PieSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrChart3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionName = "Test_Load_Report"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        ColumnExpression1.ColumnName = "MaNV"
        Table1.Name = "Test_Load_Report"
        ColumnExpression1.Table = Table1
        Column1.Expression = ColumnExpression1
        ColumnExpression2.ColumnName = "TenNV"
        ColumnExpression2.Table = Table1
        Column2.Expression = ColumnExpression2
        ColumnExpression3.ColumnName = "NamSinh"
        ColumnExpression3.Table = Table1
        Column3.Expression = ColumnExpression3
        ColumnExpression4.ColumnName = "NgayVao"
        ColumnExpression4.Table = Table1
        Column4.Expression = ColumnExpression4
        ColumnExpression5.ColumnName = "SoNgayLam"
        ColumnExpression5.Table = Table1
        Column5.Expression = ColumnExpression5
        ColumnExpression6.ColumnName = "GioiTinh"
        ColumnExpression6.Table = Table1
        Column6.Expression = ColumnExpression6
        ColumnExpression7.ColumnName = "SoGioLam"
        ColumnExpression7.Table = Table1
        Column7.Expression = ColumnExpression7
        SelectQuery1.Columns.Add(Column1)
        SelectQuery1.Columns.Add(Column2)
        SelectQuery1.Columns.Add(Column3)
        SelectQuery1.Columns.Add(Column4)
        SelectQuery1.Columns.Add(Column5)
        SelectQuery1.Columns.Add(Column6)
        SelectQuery1.Columns.Add(Column7)
        SelectQuery1.Name = "Test_Load_Report"
        SelectQuery1.Tables.Add(Table1)
        Me.SqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {SelectQuery1})
        Me.SqlDataSource1.ResultSchemaSerializable = resources.GetString("SqlDataSource1.ResultSchemaSerializable")
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox1, Me.XrLabel1})
        Me.TopMargin.HeightF = 125.0!
        Me.TopMargin.Name = "TopMargin"
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.ImageSource = New DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("XrPictureBox1.ImageSource"))
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(531.6666!, 10.00001!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(108.3333!, 79.99998!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabel1
        '
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(246.875!, 49.95832!)
        Me.XrLabel1.Multiline = True
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(131.4195!, 23.0!)
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Danh Sách Report"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel5, Me.XrLabel4, Me.XrPageInfo2, Me.XrPageInfo1})
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.StyleName = "XrControlStyle1"
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.BackColor = System.Drawing.Color.Transparent
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(0.9999911!, 0!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(183.4597!, 23.0!)
        Me.XrPageInfo2.StylePriority.UseBackColor = False
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.BackColor = System.Drawing.Color.Transparent
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrPageInfo1.StylePriority.UseBackColor = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrPageInfo1.TextFormatString = "{0} of {1}"
        '
        'XrTable2
        '
        Me.XrTable2.BackColor = System.Drawing.Color.DodgerBlue
        Me.XrTable2.BorderColor = System.Drawing.Color.White
        Me.XrTable2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTable2.ForeColor = System.Drawing.Color.White
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0.9999911!, 0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(650.0!, 25.0!)
        Me.XrTable2.StylePriority.UseBackColor = False
        Me.XrTable2.StylePriority.UseBorderColor = False
        Me.XrTable2.StylePriority.UseBorders = False
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UseForeColor = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell8, Me.XrTableCell9, Me.XrTableCell10, Me.XrTableCell11, Me.XrTableCell12, Me.XrTableCell13, Me.XrTableCell14})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Multiline = True
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.Text = "Mã NV"
        Me.XrTableCell8.Weight = 0.50200846356977891R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Multiline = True
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.Text = "Tên NV"
        Me.XrTableCell9.Weight = 1.3678920343378096R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Multiline = True
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.Text = "GT"
        Me.XrTableCell10.Weight = 0.48088830130189292R
        '
        'XrTableCell11
        '
        Me.XrTableCell11.Multiline = True
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.Text = "Năm Sinh"
        Me.XrTableCell11.Weight = 1.4840480609343003R
        '
        'XrTableCell12
        '
        Me.XrTableCell12.Multiline = True
        Me.XrTableCell12.Name = "XrTableCell12"
        Me.XrTableCell12.Text = "Ngày Vào"
        Me.XrTableCell12.Weight = 1.7406090514831569R
        '
        'XrTableCell13
        '
        Me.XrTableCell13.Multiline = True
        Me.XrTableCell13.Name = "XrTableCell13"
        Me.XrTableCell13.Text = "Ngày"
        Me.XrTableCell13.Weight = 0.46916660334299581R
        '
        'XrTableCell14
        '
        Me.XrTableCell14.Multiline = True
        Me.XrTableCell14.Name = "XrTableCell14"
        Me.XrTableCell14.Text = "Giờ"
        Me.XrTableCell14.Weight = 0.544549995122672R
        '
        'XrControlStyle1
        '
        Me.XrControlStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.XrControlStyle1.Name = "XrControlStyle1"
        Me.XrControlStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        '
        'XrControlStyle2
        '
        Me.XrControlStyle2.BackColor = System.Drawing.Color.Olive
        Me.XrControlStyle2.Name = "XrControlStyle2"
        Me.XrControlStyle2.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2})
        Me.GroupHeader1.HeightF = 25.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel2, Me.XrChart1})
        Me.GroupHeader2.HeightF = 136.875!
        Me.GroupHeader2.Level = 1
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel2.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel2.Multiline = True
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(49.52154!, 79.16666!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Biểu Đồ"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrChart1
        '
        Me.XrChart1.AppearanceNameSerializable = "Chameleon"
        Me.XrChart1.BorderColor = System.Drawing.Color.Black
        Me.XrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None
        XyDiagram1.AxisX.Tickmarks.MinorVisible = False
        XyDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        XyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.[False]
        XyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.[False]
        XyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.[False]
        XyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.[False]
        Me.XrChart1.Diagram = XyDiagram1
        Me.XrChart1.Legend.MarkerSize = New System.Drawing.Size(10, 16)
        Me.XrChart1.Legend.Name = "Default Legend"
        Me.XrChart1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.XrChart1.LocationFloat = New DevExpress.Utils.PointFloat(59.52164!, 10.00001!)
        Me.XrChart1.Name = "XrChart1"
        Me.XrChart1.PaletteName = "Blue"
        Series1.ArgumentDataMember = "Test_Load_Report.MaNV"
        Series1.Name = "NL"
        Series1.ValueDataMembersSerializable = "Test_Load_Report.SoGioLam"
        Me.XrChart1.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1}
        Me.XrChart1.SeriesTemplate.ArgumentDataMember = "Test_Load_Report.MaNV"
        Me.XrChart1.SeriesTemplate.ValueDataMembersSerializable = "Test_Load_Report.SoNgayLam"
        Me.XrChart1.SizeF = New System.Drawing.SizeF(581.4783!, 118.5417!)
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrChart2, Me.XrLabel3})
        Me.GroupHeader3.HeightF = 180.2083!
        Me.GroupHeader3.Level = 2
        Me.GroupHeader3.Name = "GroupHeader3"
        '
        'XrChart2
        '
        Me.XrChart2.BorderColor = System.Drawing.Color.Black
        Me.XrChart2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrChart2.Legend.Name = "Default Legend"
        Me.XrChart2.LocationFloat = New DevExpress.Utils.PointFloat(59.52164!, 0!)
        Me.XrChart2.Name = "XrChart2"
        Series2.ArgumentDataMember = "Test_Load_Report.TenNV"
        Series2.Name = "Series 1"
        Series2.ValueDataMembersSerializable = "Test_Load_Report.SoNgayLam"
        Series2.View = PieSeriesView1
        Me.XrChart2.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series2}
        Me.XrChart2.SizeF = New System.Drawing.SizeF(580.4782!, 171.875!)
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel3.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel3.Multiline = True
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(49.52154!, 79.16666!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Biểu Đồ"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'GroupHeader4
        '
        Me.GroupHeader4.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable3, Me.XrChart3})
        Me.GroupHeader4.HeightF = 200.0!
        Me.GroupHeader4.Level = 3
        Me.GroupHeader4.Name = "GroupHeader4"
        '
        'XrTable3
        '
        Me.XrTable3.LocationFloat = New DevExpress.Utils.PointFloat(604.5416!, 73.95834!)
        Me.XrTable3.Name = "XrTable3"
        Me.XrTable3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.XrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow3})
        Me.XrTable3.SizeF = New System.Drawing.SizeF(36.45834!, 25.0!)
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell15})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'XrTableCell15
        '
        Me.XrTableCell15.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SoGioLam]")})
        Me.XrTableCell15.Multiline = True
        Me.XrTableCell15.Name = "XrTableCell15"
        Me.XrTableCell15.Text = "XrTableCell15"
        Me.XrTableCell15.Weight = 1.0R
        '
        'XrChart3
        '
        Me.XrChart3.BorderColor = System.Drawing.Color.Black
        Me.XrChart3.Borders = DevExpress.XtraPrinting.BorderSide.None
        XyDiagram2.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram2.AxisY.VisibleInPanesSerializable = "-1"
        XyDiagram2.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.[False]
        XyDiagram2.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.[False]
        XyDiagram2.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.[False]
        XyDiagram2.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.[False]
        Me.XrChart3.Diagram = XyDiagram2
        Me.XrChart3.Legend.Name = "Default Legend"
        Me.XrChart3.LocationFloat = New DevExpress.Utils.PointFloat(59.52164!, 0!)
        Me.XrChart3.Name = "XrChart3"
        Series3.ArgumentDataMember = "Test_Load_Report.TenNV"
        Series3.Name = "Series 1"
        Series3.ValueDataMembersSerializable = "Test_Load_Report.SoNgayLam"
        Me.XrChart3.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series3}
        Me.XrChart3.SizeF = New System.Drawing.SizeF(536.76!, 190.0!)
        '
        'XrControlStyle3
        '
        Me.XrControlStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XrControlStyle3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrControlStyle3.ForeColor = System.Drawing.Color.Red
        Me.XrControlStyle3.Name = "XrControlStyle3"
        '
        'lbcGio
        '
        Me.lbcGio.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SoGioLam]")})
        Me.lbcGio.Multiline = True
        Me.lbcGio.Name = "lbcGio"
        Me.lbcGio.Text = "lbcGio"
        Me.lbcGio.Weight = 0.53976428618797878R
        '
        'lbcNgay
        '
        Me.lbcNgay.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SoNgayLam]")})
        Me.lbcNgay.Multiline = True
        Me.lbcNgay.Name = "lbcNgay"
        Me.lbcNgay.Text = "lbcNgay"
        Me.lbcNgay.Weight = 0.46504305986257705R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[NgayVao]")})
        Me.XrTableCell5.Multiline = True
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Text = "XrTableCell5"
        Me.XrTableCell5.Weight = 1.7253104341947116R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[NamSinh]")})
        Me.XrTableCell4.Multiline = True
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Text = "XrTableCell4"
        Me.XrTableCell4.Weight = 1.4710046790196345R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.XrTableCell3.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[GioiTinh]")})
        Me.XrTableCell3.Multiline = True
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.StylePriority.UseBackColor = False
        Me.XrTableCell3.Text = "XrTableCell3"
        Me.XrTableCell3.Weight = 0.476661791434655R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TenNV]")})
        Me.XrTableCell2.Multiline = True
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Text = "XrTableCell2"
        Me.XrTableCell2.Weight = 1.3558694804631746R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MaNV]")})
        Me.XrTableCell1.Multiline = True
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Text = "XrTableCell1"
        Me.XrTableCell1.Weight = 0.49759626883726848R
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell2, Me.XrTableCell3, Me.XrTableCell4, Me.XrTableCell5, Me.lbcNgay, Me.lbcGio})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTable1
        '
        Me.XrTable1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.BorderWidth = 1.0!
        Me.XrTable1.EvenStyleName = "XrControlStyle1"
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(650.0!, 46.875!)
        Me.XrTable1.StylePriority.UseBorders = False
        Me.XrTable1.StylePriority.UseBorderWidth = False
        Me.XrTable1.StylePriority.UseTextAlignment = False
        Me.XrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'Detail
        '
        Me.Detail.BackColor = System.Drawing.Color.Transparent
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.Detail.EvenStyleName = "XrControlStyle1"
        Me.Detail.HeightF = 46.875!
        Me.Detail.Name = "Detail"
        Me.Detail.StylePriority.UseBackColor = False
        '
        'XrLabel4
        '
        Me.XrLabel4.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Sum([SoNgayLam])")})
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(306.2083!, 30.79166!)
        Me.XrLabel4.Multiline = True
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        '
        'XrLabel5
        '
        Me.XrLabel5.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Sum([SoGioLam])")})
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(451.0001!, 30.79166!)
        Me.XrLabel5.Multiline = True
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        '
        'FormLoadReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.GroupHeader1, Me.GroupHeader2, Me.GroupHeader3, Me.GroupHeader4})
        Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.SqlDataSource1})
        Me.DataMember = "Test_Load_Report"
        Me.DataSource = Me.SqlDataSource1
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Margins = New System.Drawing.Printing.Margins(99, 100, 125, 100)
        Me.PageColor = System.Drawing.Color.Transparent
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyle1, Me.XrControlStyle2, Me.XrControlStyle3})
        Me.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.Version = "20.1"
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrChart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeSpanChartRangeControlClient1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeSpanChartRangeControlClient2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeSpanChartRangeControlClient3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PieSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrChart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrChart3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents SqlDataSource1 As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents XrControlStyle2 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents GroupHeader2 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents TimeSpanChartRangeControlClient1 As DevExpress.XtraEditors.TimeSpanChartRangeControlClient
    Friend WithEvents TimeSpanChartRangeControlClient2 As DevExpress.XtraEditors.TimeSpanChartRangeControlClient
    Friend WithEvents TimeSpanChartRangeControlClient3 As DevExpress.XtraEditors.TimeSpanChartRangeControlClient
    Friend WithEvents XrChart1 As DevExpress.XtraReports.UI.XRChart
    Friend WithEvents GroupHeader3 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrChart2 As DevExpress.XtraReports.UI.XRChart
    Friend WithEvents GroupHeader4 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrControlStyle3 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrChart3 As DevExpress.XtraReports.UI.XRChart
    Friend WithEvents XrTable3 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents lbcGio As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents lbcNgay As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
End Class
