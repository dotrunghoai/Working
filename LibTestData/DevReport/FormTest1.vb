Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraCharts
Imports DevExpress.Utils
Imports DevExpress.XtraEditors

Public Class FormTest1

    Dim csdl As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        'Dim para(2) As SqlClient.SqlParameter
        'para(0) = New SqlClient.SqlParameter("@Action", "Progress")
        'para(1) = New SqlClient.SqlParameter("@YM", "202002")
        'para(2) = New SqlClient.SqlParameter("GroupCode", "01")

        'Dim dt As DataTable = csdl.ExecuteStoreProcedureTB("sp_INV_Rpt_Progress", para)

        Dim data As DataTable = csdl.ExecuteStoreProcedureTB("sp_Test_LoadQLNhanVien")
        'GridControl1.DataSource = data
        GridControl2.DataSource = data
        GridControlSetFormat(BandedGridView1, 2)
        'GridControlSetFormat(GridView1, 2)
        GridControlSetColorReadonly(GridView1)
        'data.TableName = "Test_Load_Report"
        'data.WriteXmlSchema("Test_Load_Report.xsd")

        'GridControl1.ForceInitialize()
        'Dim riEditor As New RepositoryItemMemoEdit()
        'riEditor.Items.AddRange(New String() {"OK", "A", "B1", "B2", "B3", "B4", "B5", "C", "D1", "D2", "E", "F1", "F2", "F3", "G1", "G2", "H", "I1", "I2"})
        'GridControl1.RepositoryItems.Add(riEditor)
        'GridView1.Columns(1).ColumnEdit = riEditor

        'GridControl1.DataSource = csdl.FillDataTable("select * from PS_ProductM2")
        'GridControlSetFormat(GridView1)

        Dim dtN As New DataTable
        dtN.Columns.Add("ECode")
        dtN.Columns.Add("JCode")
        dtN.Columns.Add("Định mức ngày")
        'dtN.Columns.Add("Định mức tuần")
        'dtN.Columns.Add("Định mức tháng")
        dtN.Columns.Add("Qty1")
        dtN.Columns.Add("Qty2")
        dtN.Columns.Add("Qty3")
        dtN.Rows.Add("21500", "J00001", 5, 5, 0, 0)
        dtN.Rows.Add("21612", "J00052", 10, 2, 0, 0)
        dtN.Rows.Add("21612", "J00078", 20, 40, 0, 0)
        dtN.Rows.Add()
        GridControl1.DataSource = dtN
        GridControlSetFormat(GridView1)
        DataGridView1.DataSource = dtN

        'Dim val = GridView1.GetFocusedRowCellValue("ECode")

        ''Kiểm tra có chứa kí tự đặc biệt hay không
        'If val.ToString.Contains("'") Then
        '    val.ToString.Replace("'", "-")
        'End If

        ''Update khi đã có dữ liệu hợp lệ
        'csdl.ExecuteNonQuery("UPDATE PCM_OutDirect
        '                      SET ECode = '{0}'
        '                      WHERE JCode = 'J02398'",
        '                      val)
    End Sub
    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Try
            csdl.BeginTransaction()
            Dim dt = csdl.FillDataTable("   SELECT h.Ngay, h.ProductCode, h.LotNumber
                                        FROM RI_KQH_Day_2 AS h
                                        LEFT JOIN RI_DefectCode_Day_2 AS d
                                        ON h.ProductCode = d.ProductCode
                                        AND h.LotNumber = d.LotNumber
                                        WHERE d.ProductCode IS NULL")
            For Each r As DataRow In dt.Rows
                Dim para(2) As SqlClient.SqlParameter
                para(0) = New SqlClient.SqlParameter("@TodayAdd", r("Ngay"))
                para(1) = New SqlClient.SqlParameter("@ProductCode", r("ProductCode"))
                para(2) = New SqlClient.SqlParameter("@LotNumber", r("LotNumber"))
                'csdl.ExecuteNonQuery("declare @Today as datetime = @TodayAdd
                '                declare @start as datetime
                '                declare @End as datetime

                '                set @start= DATETIMEFROMPARTS (year(@Today), month(@Today),day(@Today), 6, 1, 0,0)
                '                set @End=dateadd(day, 1, @start)  
                '                set @End = DATETIMEFROMPARTS (year(@End) ,month(@End ),day(@End ), 6, 0, 59,0)

                '                SELECT  @Today as Ngay, i.ProductCode, i.LotNumber, pr.RevisionCode
                '                      ,([DefectClassCode] +[DefectCode]) as code  
                '                   ,p.[ProcessMethodCode] AS Method
                '                   ,p.PieceCount as size
                '                   ,sum(i3.Quantity) as Qty INTO #RI_DefectCode_Day_2_Tam
                '                FROM [10.153.1.30].[FPiCS-B03].dbo.[t_InspectionResult] as i
                '                inner join (
                '                select  ProductCode,LotNumber, RevisionCode, ComponentCode
                '                from [10.153.1.30].[FPiCS-B03].[dbo].[t_ProcessResult]
                '                where ProcessCode='9053'
                '                 ) as pr
                '                on i.ProductCode=pr.ProductCode
                '                and i.LotNumber=pr.LotNumber
                '                inner join [10.153.1.30].[FPiCS-B03].[dbo].[t_InspectionResult3] i3
                '                on i.ProductCode=i3.ProductCode
                '                and i.LotNumber=i3.LotNumber
                '                left join [10.153.1.30].[FPiCS-B03].[dbo].m_Product p
                '                on p.ProductCode=i.ProductCode
                '                and p.RevisionCode=i.RevisionCode
                '                left join [10.153.1.30].[FPiCS-B03].[dbo].m_Customer c
                '                on p.CustomerCode=c.CustomerCode
                '                WHERE i.DisableFlag='F' 
                '                AND pr.ComponentCode = 'B00'
                '                AND i.ProductCode = @ProductCode
                '                AND i.LotNumber = @LotNumber
                '                group by i.ProductCode, i.LotNumber, pr.RevisionCode, ([DefectClassCode]+[DefectCode]) ,p.[ProcessMethodCode] ,p.PieceCount

                '                INSERT INTO RI_DefectCode_Day_2(Ngay, ProductCode, LotNumber, RevisionCode, Code, Method, Size, Qty)
                '                SELECT H.Ngay, H.ProductCode, H.LotNumber, H.RevisionCode, H.Code, H.Method, H.Size, H.Qty
                '                FROM #RI_DefectCode_Day_2_Tam AS H
                '                LEFT JOIN RI_DefectCode_Day_2 AS RI
                '                ON H.ProductCode collate database_default = RI.ProductCode collate database_default
                '                AND H.LotNumber collate database_default = RI.LotNumber collate database_default
                '                WHERE RI.ProductCode IS NULL

                '                ----
                '                 SELECT  @Today as Ngay,i.ProductCode, i.LotNumber, pr.RevisionCode
                '                      ,([DefectClassCode] +[DefectCode]) as code  
                '                   ,sum(i3.Quantity) as Qty INTO #RI_DefectCode_Pd_2_Tam
                '                FROM [10.153.1.30].[FPiCS-B03].dbo.[t_InspectionResult] i
                '                inner join (
                '                select  ProductCode,LotNumber, RevisionCode, ComponentCode
                '                from [10.153.1.30].[FPiCS-B03].[dbo].[t_ProcessResult]
                '                where ProcessCode='9053'
                '                 ) as pr
                '                on i.ProductCode=pr.ProductCode
                '                and i.LotNumber=pr.LotNumber 
                '                inner join [10.153.1.30].[FPiCS-B03].[dbo].[t_InspectionResult3] i3
                '                on i.ProductCode=i3.ProductCode
                '                and i.LotNumber=i3.LotNumber
                '                where i.DisableFlag='F' 
                '                AND pr.ComponentCode = 'B00'
                '                AND i.ProductCode = @ProductCode
                '                AND i.LotNumber = @LotNumber
                '                group by i.ProductCode, i.LotNumber, pr.RevisionCode, ([DefectClassCode]+[DefectCode]) 

                '                INSERT INTO RI_DefectCode_Pd_2(Ngay, ProductCode, LotNumber, RevisionCode, Code, Qty)
                '                SELECT H.Ngay, H.ProductCode, H.LotNumber, H.RevisionCode, H.Code, H.Qty 
                '                FROM #RI_DefectCode_Pd_2_Tam AS H
                '                LEFT JOIN RI_DefectCode_Pd_2 AS RI
                '                ON H.ProductCode collate database_default = RI.ProductCode collate database_default
                '                AND H.LotNumber collate database_default = RI.LotNumber collate database_default
                '                WHERE RI.ProductCode IS NULL", para)
            Next
            csdl.Commit()
            ShowSuccess()
        Catch ex As Exception
            ShowWarning(ex.Message)
            csdl.RollBack()
        End Try


        txtMaNV.Text = ""
        toolstrip.Text = ""
        dateNamSinh.Text = Now
        dateNgayVao.Text = False
        dateNgayVao.Text = Now
        txtSoGioLam.Text = ""
        txtSoGioLam.Text = ""
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim result As DialogResult = MessageBox.Show("Bạn có muốn xóa " + GridView1.GetFocusedRowCellValue("MaNV") + " không ?", "Cảnh báo", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            MessageBox.Show("Dữ liệu chưa được xóa", "Thông báo")
        ElseIf result = DialogResult.Yes Then
            Try
                'Dim data As New Test_QLNhanVien()
                'data.MaNV_K = GridView1.GetFocusedRowCellValue("MaNV")
                'csdl.Delete(data)

                Dim objDelete As String = String.Format("Delete from Test_QLNhanVien where MaNV = '{0}'", GridView1.GetFocusedRowCellValue("MaNV"))
                csdl.ExecuteNonQuery(objDelete)
                GridView1.DeleteSelectedRows()

            Catch ex As Exception
                MessageBox.Show(ex.Message, PublicConst.Message_Caption_Error)
            End Try
            MessageBox.Show("Bạn đã xóa thành công", "Thông báo")
        End If
    End Sub

    Private Sub btnLuu_Click(sender As Object, e As EventArgs) Handles btnLuu.Click
        Dim data As New Test

        If ShowQuestionSave() = DialogResult.No Then
            Exit Sub
        End If

        Try
            data.MaNV_K = txtMaNV.Text
            data.TenNV = txtTenNV.Text
            data.NamSinh = Now
            data.GioiTinh = False
            data.NgayVao = Now
            data.SoNgayLam = txtSoGioLam.Text
            data.SoGioLam = txtSoGioLam.Text

            csdl.Insert(data)

            ShowSuccess()
            btnLoad.PerformClick()
        Catch ex As Exception
            ShowError(ex, "Save", Name)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        'cho tất cả các trường rỗng
        txtMaNV.Text = ""
        toolstrip.Text = ""
        dateNamSinh.Text = Now
        dateNgayVao.Text = True
        dateNgayVao.Text = Now
        txtSoGioLam.Text = ""
        txtSoGioLam.Text = ""

        'xác nhận cột nào được chỉnh sửa
        GridControlReadOnly(GridView1, False)
        'GridView1.Columns("MaNV").OptionsColumn.ReadOnly = False
        'GridView1.Columns("TenNV").OptionsColumn.ReadOnly = False
        'GridView1.Columns("NamSinh").OptionsColumn.ReadOnly = False
        'GridView1.Columns("GioiTinh").OptionsColumn.ReadOnly = False
        'GridView1.Columns("NgayVao").OptionsColumn.ReadOnly = False
        'GridView1.Columns("SoNgayLam").OptionsColumn.ReadOnly = False
        'GridView1.Columns("SoGioLam").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)

    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub btnLoadReport_Click(sender As Object, e As EventArgs) Handles btnLoadReport.Click
        Dim report As New FormLoadReport
        report.DataSource = csdl.ExecuteStoreProcedureTB("sp_Test_LoadQLNhanVien")
        report.DataMember = ""
        Dim RePrTool As New ReportPrintTool(report)
        RePrTool.ShowPreview()
    End Sub

    Function CreateID() As String
        Dim ID As String = ""
        Dim stt As String = ""
        Dim o As Object = Nothing

        'chuỗi yyMMdd gán bằng ngày/tháng/năm hiện tại
        Dim yyMMdd As String = DateTime.Now.ToString("yyMMdd")

        'chuỗi sql để lấy chuỗi 4 giá trị cuối của ID có cấu trúc: 'yyMMdd****' mà '****' có giá trị lớn nhất
        Dim sql As String = String.Format(" select right(Max(MaNV), 4) FROM {0} " +
                                          " where MaNV like '{1}%' ", PublicTable.Table_Test_QLNhanVien, yyMMdd)
        '---Chú ý: kiểu dữ liệu của MaNV phải có giới hạn đúng với lệnh select right(MaNV) - 4 kí tự -> phải chuẩn 10 ký tự
        'ExecuteScalar để trả về 1 giá trị là cột đầu tiên của hàng đầu tiên
        o = csdl.ExecuteScalar(sql)

        If o IsNot DBNull.Value And o IsNot Nothing Then
            o = Convert.ToInt32(o) + 1
            stt = o.ToString.PadLeft(4, "0")
            ID = yyMMdd + stt
        Else
            ID = yyMMdd + "0001"
        End If
        Return ID
    End Function

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.RowHandle < 0 Then
            If GridView1.GetFocusedRowCellValue("MaNV") IsNot DBNull.Value Then
                'Dim myid As String = CreateID()
                Dim myid As String = GridView1.GetFocusedRowCellValue("MaNV")
                'GridView1.SetFocusedRowCellValue("MaNV", myid)
                Dim obj As New Test
                obj.MaNV_K = myid
                csdl.Insert(obj)
            End If
        End If

        'If e.RowHandle < 0 Then
        '    If GridView1.GetFocusedRowCellValue("MaNV") Is DBNull.Value Then
        '        GridView1.SetFocusedRowCellValue("TenNV", "TestTen")
        '    End If
        'End If

        If GridView1.Editable And e.Column.ReadOnly = False Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            Dim objEdit As String = String.Format("Update Test_QLNhanVien set {0} = @Value where MaNV = '{1}'", e.Column.FieldName,
            GridView1.GetFocusedRowCellValue("MaNV"))
            csdl.ExecuteNonQuery(objEdit, para)
        End If
    End Sub

    <Obsolete>
    Private Sub btnChart_Click(sender As Object, e As EventArgs) Handles btnChart.Click
        'CHART
        ChartControl1.Series.Clear()

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
        ChartControl1.Series.Add(seriesBar)
        ChartControl1.Series.Add(seriesBar2)
        ChartControl1.Series.Add(seriesBar3)
        ChartControl1.Series.Add(seriesLine)
        ChartControl1.Series.Add(seriesLineRight)

        'Thêm Diagram cho seriesLineRight vào bên phải Chart
        Dim seconY As New SecondaryAxisY()
        CType(ChartControl1.Diagram, XYDiagram).SecondaryAxesY.Clear()
        CType(ChartControl1.Diagram, XYDiagram).SecondaryAxesY.Add(seconY)
        CType(seriesLineRight.View, LineSeriesView).AxisY = seconY

        'Thêm Title và customize Title/Diagram/Label cho seriesBar/seriesLine
        Dim diagram As XYDiagram = CType(ChartControl1.Diagram, XYDiagram)
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

        ChartControl1.Dock = DockStyle.Fill
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        GridControl1.DataSource = csdl.FillDataTable("SELECT  i.ItemCode ,
                            i.ItemNameV ,
                            i.ItemNameE ,
                            i.Manufacturer ,
                            i.MachineModelSerial ,
                            i.SparePartModel ,
                            i.Origin ,
                            i.TechnicalSpecification ,
                            i.SafetyRequirement ,
                            i.ColorMatetial ,
                            i.ShapeDemention ,
                            i.UsingPurpose ,
                            i.SupplierCode ,
                            i.SupplierName ,
                            i.PackingType ,
                            i.Unit , 
                            i.UnitPrice ,
                            i.PriceValid ,
                            i.MOQ ,
                            i.LeadTime ,
                            i.Currency ,
                            i.DeliveryTerm ,
                            i.BudgetCode ,
							BudgetCategory = V.ItemNameE   ,
                            i.PaymentTerm ,
                            i.PaymentTermDescription ,
                            i.RingiNo ,
                            i.ItemImageFile ,
                            i.ItemImageFileServer ,
                            i.AttachFile ,
                            i.AttachFileServer , 
                            iif(i.DichVu=0,'6111021',iif(b.MCSA = 'MC',v.MC627,v.SA642)) as  ExportAccountDebit ,
                            '3310012' as ExportAccountCredit ,
                            i.DestructionProperty ,
                            i.Description ,
                            i.CreateUser ,
                            i.CreateDate ,
                            i.ApproveUser ,
                            i.ApproveDate ,
                            i.EditUser ,
                            i.EditDate ,
                            i.EditApproveUser ,
                            i.EditApproveDate ,
                            ImportItem = ISNULL(i.ItemNameE, '') + '//'
                            + ISNULL(i.ItemNameV, '') + '\\'
                            + ISNULL(i.MachineModelSerial, '') + ' '
                            + ISNULL(i.SparePartModel, '') + ' '
                            + ISNULL(i.TechnicalSpecification, '') + ' '
                            + ISNULL(i.ColorMatetial, '') + ' '
                            + ISNULL(i.ShapeDemention, '') + ' '
                            + ISNULL(i.SafetyRequirement, '') + ' '
                            + ISNULL(i.Origin, '') + ' '
                            + ISNULL(i.Manufacturer, ''),
                            Dept ,
                            ReasonDisable,
							I.ItemGroup,
							I.VAT
							,i.DichVu
							FROM    dbo.ASP_ItemList I
					        left join LOA_BudgetCode b
							on b.SectionCode=i.Dept
							left join LOA_GeneralLedgerAccount V on i.BudgetCode = V.ID
							LEFT JOIN [dbo].[ASP_RequestCodeDetail] d
							on i.ItemCode=d.ItemCode
							left join [dbo].[ASP_RequestCodeHead] h
							on d.GSRNo=h.GSRNo
							
                    ORDER BY  i.CreateDate desc    ")
        GridControlSetFormat(GridView1)
    End Sub
End Class