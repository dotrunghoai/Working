Imports CommonDB
'Imports LibEntity
Imports PublicUtility
Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.Office.Interop
Imports DevExpress.XtraReports.UI
Public Class FrmB00Detail
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim FileTmp As String = Application.StartupPath + "\Template Excel\Template EMM\"
    Dim FileExp As String = Application.StartupPath + "\Template Excel\Template EMM\Export EMM\"

    Function CreateIDB00Detail() As String
        Dim ID As String = ""
        Dim stt As String = ""
        Dim o As Object = Nothing
        Dim yyMMdd As String = DateTime.Now.ToString("yyMMdd")
        Dim sql As String = String.Format(" select right(Max(Code), 4) FROM {0} " +
                                          " where Code like '{1}%' ", PublicTable.Table_EMM_B00Detail, yyMMdd)
        o = _db.ExecuteScalar(sql)
        If o IsNot DBNull.Value And o IsNot Nothing Then
            o = Convert.ToInt32(o) + 1
            stt = o.ToString.PadLeft(4, "0")
            ID = yyMMdd + stt
        Else
            ID = yyMMdd + "0001"
        End If
        Return ID
    End Function

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        GridControlReadOnly(GridView1, False)
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridView1.Columns("Code").OptionsColumn.ReadOnly = True
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim StartDate As DateTime
        Dim EndDate As DateTime
        Dim ActionDate As String

        StartDate = GetStartDate(dtpStartDate.Value)
        EndDate = GetEndDate(dtpEndDate.Value)

        If rbInspectionDate.Checked Then
            ActionDate = "InspectionDate"
        Else
            ActionDate = "IncomingDate"
        End If

        Dim para(3) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "B00")
        para(1) = New SqlClient.SqlParameter("@StartDate", StartDate)
        para(2) = New SqlClient.SqlParameter("@EndDate", EndDate)
        para(3) = New SqlClient.SqlParameter("@ActionDate", ActionDate)

        Dim dtB00 As DataTable = _db.ExecuteStoreProcedureTB("sp_EMM_ShowAll", para)
        GridControl1.DataSource = dtB00
        GridControlSetFormat(GridView1, 7, "Start""Finish")
        GridControlSetColorReadonly(GridView1)
        GridView1.Columns("Start").ColumnEdit = GridControlTimeEdit()
        GridView1.Columns("Finish").ColumnEdit = GridControlTimeEdit()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        GridControlReadOnly(GridView1, False)
        GridView1.Columns("Code").OptionsColumn.ReadOnly = True
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As DialogResult = MessageBox.Show("Bạn có muốn xóa Code: " + GridView1.GetFocusedRowCellValue("Code") + " không ?", "Cảnh báo", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            MessageBox.Show("Dữ liệu chưa được xóa", "Thông báo")
        ElseIf result = DialogResult.Yes Then
            Try
                Dim objDelete As String = String.Format("Delete from {0} where Code = '{1}'",
                                                              PublicTable.Table_EMM_B00Detail,
                                                              GridView1.GetFocusedRowCellValue("Code"))
                _db.ExecuteNonQuery(objDelete)
                GridView1.DeleteSelectedRows()
            Catch ex As Exception
                MessageBox.Show(ex.Message, PublicConst.Message_Caption_Error)
            End Try
            MessageBox.Show("Bạn đã xóa thành công", "Thông báo")
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If GridView1.GetFocusedRowCellValue("Code") Is DBNull.Value Then
                    Dim myid As String = CreateIDB00Detail()
                    GridView1.SetFocusedRowCellValue("Code", myid)
                    Dim obj As New EMM_B00Detail
                    obj.Code_K = myid
                    _db.Insert(obj)
                End If
            End If

            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(String.Format("Update EMM_B00Detail " +
                                              "set {0}=@Value,UpdateDate=getdate(),UpdateUser='{1}' " +
                                              "where Code='{2}' ",
                                              e.Column.FieldName,
                                              CurrentUser.UserID,
                                              GridView1.GetFocusedRowCellValue("Code")), para)
        End If
    End Sub

    Private Sub btnExportGrid_Click(sender As Object, e As EventArgs) Handles btnExportGrid.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        Dim StartDate As DateTime
        Dim EndDate As DateTime
        Dim ActionDate As String

        StartDate = GetStartDate(dtpStartDate.Value)
        EndDate = GetEndDate(dtpEndDate.Value)
        ActionDate = "IncomingDate"

        Dim para(3) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "B00")
        para(1) = New SqlClient.SqlParameter("@StartDate", StartDate)
        para(2) = New SqlClient.SqlParameter("@EndDate", EndDate)
        para(3) = New SqlClient.SqlParameter("@ActionDate", ActionDate)

        Dim dt As DataTable = _db.ExecuteStoreProcedureTB("sp_EMM_ShowAll", para)
        ExportEXCEL(dt)
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        'Copy template
        UpLoadFile(FileTmp + "B00.xlsx", FileExp + "B00.xlsx", True)
        'Variance
        Dim app As New Excel.Application
        Dim workBook As Excel.Workbook
        Dim workSheet As Excel.Worksheet

        'Open file
        If (File.Exists(FileExp + "B00.xlsx")) Then
            workBook = app.Workbooks.Open(FileExp + "B00.xlsx", Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing)
        Else
            workBook = app.Workbooks.Add(Type.Missing)
        End If
        workSheet = CType(workBook.Sheets(1), Excel.Worksheet)
        workSheet.Name = "NDV"

        'If gridB00.Rows.Count = 0 Then Exit Sub
        If GridView1.RowCount = 0 Then Exit Sub

        'Write data
        'Header

        'Detail
        Dim iRow As Integer = 6
        Dim No As Integer = 1
        'For i As Integer = 0 To gridB00.Rows.Count - 1
        For i As Integer = 0 To GridView1.RowCount - 1
            workSheet.Cells(iRow, 1) = i + 1
            workSheet.Cells(iRow, 2) = GridView1.GetRowCellValue(i, "IncomingDate")
            workSheet.Cells(iRow, 3) = GridView1.GetRowCellValue(i, "InspectionDate")
            workSheet.Cells(iRow, 4) = GridView1.GetRowCellValue(i, "PdCode")
            workSheet.Cells(iRow, 5) = GridView1.GetRowCellValue(i, "MaterialLotNo")
            workSheet.Cells(iRow, 6) = GridView1.GetRowCellValue(i, "ActualTotalQuantity")
            workSheet.Cells(iRow, 7) = GridView1.GetRowCellValue(i, "AcceptanceQualityLimits")
            workSheet.Cells(iRow, 8) = GridView1.GetRowCellValue(i, "CheckProcess")
            workSheet.Cells(iRow, 9) = GridView1.GetRowCellValue(i, "Error001")
            workSheet.Cells(iRow, 10) = GridView1.GetRowCellValue(i, "Error001")
            workSheet.Cells(iRow, 11) = GridView1.GetRowCellValue(i, "Error001")
            workSheet.Cells(iRow, 12) = GridView1.GetRowCellValue(i, "Error001")
            workSheet.Cells(iRow, 13) = GridView1.GetRowCellValue(i, "Error001")
            workSheet.Cells(iRow, 14) = GridView1.GetRowCellValue(i, "Error006")
            workSheet.Cells(iRow, 15) = GridView1.GetRowCellValue(i, "Error007")
            workSheet.Cells(iRow, 16) = GridView1.GetRowCellValue(i, "Error009")
            workSheet.Cells(iRow, 17) = GridView1.GetRowCellValue(i, "Error011")
            workSheet.Cells(iRow, 18) = GridView1.GetRowCellValue(i, "Error013")
            workSheet.Cells(iRow, 19) = GridView1.GetRowCellValue(i, "Error016")
            workSheet.Cells(iRow, 20) = GridView1.GetRowCellValue(i, "Error017")
            workSheet.Cells(iRow, 21) = GridView1.GetRowCellValue(i, "Error018")
            workSheet.Cells(iRow, 22) = GridView1.GetRowCellValue(i, "Error021")
            workSheet.Cells(iRow, 23) = GridView1.GetRowCellValue(i, "Error101")
            workSheet.Cells(iRow, 24) = GridView1.GetRowCellValue(i, "Error102")
            workSheet.Cells(iRow, 25) = GridView1.GetRowCellValue(i, "Error103")
            workSheet.Cells(iRow, 26) = GridView1.GetRowCellValue(i, "Error104")
            workSheet.Cells(iRow, 27) = GridView1.GetRowCellValue(i, "Error105")
            workSheet.Cells(iRow, 28) = GridView1.GetRowCellValue(i, "Error106")
            workSheet.Cells(iRow, 29) = GridView1.GetRowCellValue(i, "Error107")
            workSheet.Cells(iRow, 30) = GridView1.GetRowCellValue(i, "Error108")
            workSheet.Cells(iRow, 31) = GridView1.GetRowCellValue(i, "Error109")
            workSheet.Cells(iRow, 32) = GridView1.GetRowCellValue(i, "Error110")
            workSheet.Cells(iRow, 33) = GridView1.GetRowCellValue(i, "Error111")
            workSheet.Cells(iRow, 34) = GridView1.GetRowCellValue(i, "Error112")
            workSheet.Cells(iRow, 35) = GridView1.GetRowCellValue(i, "Error113")
            workSheet.Cells(iRow, 36) = GridView1.GetRowCellValue(i, "Error115")
            workSheet.Cells(iRow, 37) = GridView1.GetRowCellValue(i, "Error117")
            workSheet.Cells(iRow, 38) = GridView1.GetRowCellValue(i, "Error118")
            workSheet.Cells(iRow, 39) = GridView1.GetRowCellValue(i, "Error122")
            workSheet.Cells(iRow, 40) = GridView1.GetRowCellValue(i, "Error123")
            workSheet.Cells(iRow, 41) = GridView1.GetRowCellValue(i, "Error125")
            workSheet.Cells(iRow, 42) = GridView1.GetRowCellValue(i, "Error126")
            workSheet.Cells(iRow, 43) = GridView1.GetRowCellValue(i, "Error130")
            workSheet.Cells(iRow, 44) = GridView1.GetRowCellValue(i, "Error201")
            workSheet.Cells(iRow, 45) = GridView1.GetRowCellValue(i, "Error202")
            workSheet.Cells(iRow, 46) = GridView1.GetRowCellValue(i, "Error204")
            workSheet.Cells(iRow, 47) = GridView1.GetRowCellValue(i, "Error205")
            workSheet.Cells(iRow, 48) = GridView1.GetRowCellValue(i, "Error206")
            workSheet.Cells(iRow, 49) = GridView1.GetRowCellValue(i, "Error207")
            workSheet.Cells(iRow, 50) = GridView1.GetRowCellValue(i, "Error208")
            workSheet.Cells(iRow, 51) = GridView1.GetRowCellValue(i, "Error209")
            workSheet.Cells(iRow, 52) = GridView1.GetRowCellValue(i, "Error219")
            workSheet.Cells(iRow, 53) = GridView1.GetRowCellValue(i, "Error234")
            workSheet.Cells(iRow, 54) = GridView1.GetRowCellValue(i, "Error225")
            workSheet.Cells(iRow, 55) = GridView1.GetRowCellValue(i, "Error506")
            workSheet.Cells(iRow, 56) = GridView1.GetRowCellValue(i, "Error601")
            workSheet.Cells(iRow, 57) = GridView1.GetRowCellValue(i, "Error602")
            workSheet.Cells(iRow, 58) = GridView1.GetRowCellValue(i, "Error603")
            workSheet.Cells(iRow, 59) = GridView1.GetRowCellValue(i, "Error607")
            workSheet.Cells(iRow, 60) = GridView1.GetRowCellValue(i, "Error608")
            workSheet.Cells(iRow, 61) = GridView1.GetRowCellValue(i, "Error610")
            workSheet.Cells(iRow, 62) = GridView1.GetRowCellValue(i, "Error629")
            workSheet.Cells(iRow, 63) = GridView1.GetRowCellValue(i, "Error634")
            workSheet.Cells(iRow, 64) = GridView1.GetRowCellValue(i, "Error635")
            workSheet.Cells(iRow, 65) = GridView1.GetRowCellValue(i, "Error636")
            workSheet.Cells(iRow, 66) = GridView1.GetRowCellValue(i, "Error637")
            workSheet.Cells(iRow, 67) = GridView1.GetRowCellValue(i, "Percent001")
            workSheet.Cells(iRow, 68) = GridView1.GetRowCellValue(i, "Percent002")
            workSheet.Cells(iRow, 69) = GridView1.GetRowCellValue(i, "Percent003")
            workSheet.Cells(iRow, 70) = GridView1.GetRowCellValue(i, "Percent004")
            workSheet.Cells(iRow, 71) = GridView1.GetRowCellValue(i, "Percent005")
            workSheet.Cells(iRow, 72) = GridView1.GetRowCellValue(i, "Percent006")
            workSheet.Cells(iRow, 73) = GridView1.GetRowCellValue(i, "Percent007")
            workSheet.Cells(iRow, 74) = GridView1.GetRowCellValue(i, "Percent009")
            workSheet.Cells(iRow, 75) = GridView1.GetRowCellValue(i, "Percent011")
            workSheet.Cells(iRow, 76) = GridView1.GetRowCellValue(i, "Percent013")
            workSheet.Cells(iRow, 77) = GridView1.GetRowCellValue(i, "Percent016")
            workSheet.Cells(iRow, 78) = GridView1.GetRowCellValue(i, "Percent017")
            workSheet.Cells(iRow, 79) = GridView1.GetRowCellValue(i, "Percent018")
            workSheet.Cells(iRow, 80) = GridView1.GetRowCellValue(i, "Percent021")
            workSheet.Cells(iRow, 81) = GridView1.GetRowCellValue(i, "Percent101")
            workSheet.Cells(iRow, 82) = GridView1.GetRowCellValue(i, "Percent102")
            workSheet.Cells(iRow, 83) = GridView1.GetRowCellValue(i, "Percent103")
            workSheet.Cells(iRow, 84) = GridView1.GetRowCellValue(i, "Percent104")
            workSheet.Cells(iRow, 85) = GridView1.GetRowCellValue(i, "Percent105")
            workSheet.Cells(iRow, 86) = GridView1.GetRowCellValue(i, "Percent106")
            workSheet.Cells(iRow, 87) = GridView1.GetRowCellValue(i, "Percent107")
            workSheet.Cells(iRow, 88) = GridView1.GetRowCellValue(i, "Percent108")
            workSheet.Cells(iRow, 89) = GridView1.GetRowCellValue(i, "Percent109")
            workSheet.Cells(iRow, 90) = GridView1.GetRowCellValue(i, "Percent110")
            workSheet.Cells(iRow, 91) = GridView1.GetRowCellValue(i, "Percent111")
            workSheet.Cells(iRow, 92) = GridView1.GetRowCellValue(i, "Percent112")
            workSheet.Cells(iRow, 93) = GridView1.GetRowCellValue(i, "Percent113")
            workSheet.Cells(iRow, 94) = GridView1.GetRowCellValue(i, "Percent115")
            workSheet.Cells(iRow, 95) = GridView1.GetRowCellValue(i, "Percent117")
            workSheet.Cells(iRow, 96) = GridView1.GetRowCellValue(i, "Percent118")
            workSheet.Cells(iRow, 97) = GridView1.GetRowCellValue(i, "Percent122")
            workSheet.Cells(iRow, 98) = GridView1.GetRowCellValue(i, "Percent123")
            workSheet.Cells(iRow, 99) = GridView1.GetRowCellValue(i, "Percent125")
            workSheet.Cells(iRow, 100) = GridView1.GetRowCellValue(i, "Percent126")
            workSheet.Cells(iRow, 101) = GridView1.GetRowCellValue(i, "Percent130")
            workSheet.Cells(iRow, 102) = GridView1.GetRowCellValue(i, "Percent201")
            workSheet.Cells(iRow, 103) = GridView1.GetRowCellValue(i, "Percent202")
            workSheet.Cells(iRow, 104) = GridView1.GetRowCellValue(i, "Percent204")
            workSheet.Cells(iRow, 105) = GridView1.GetRowCellValue(i, "Percent205")
            workSheet.Cells(iRow, 106) = GridView1.GetRowCellValue(i, "Percent206")
            workSheet.Cells(iRow, 107) = GridView1.GetRowCellValue(i, "Percent207")
            workSheet.Cells(iRow, 108) = GridView1.GetRowCellValue(i, "Percent208")
            workSheet.Cells(iRow, 109) = GridView1.GetRowCellValue(i, "Percent209")
            workSheet.Cells(iRow, 110) = GridView1.GetRowCellValue(i, "Percent219")
            workSheet.Cells(iRow, 111) = GridView1.GetRowCellValue(i, "Percent234")
            workSheet.Cells(iRow, 112) = GridView1.GetRowCellValue(i, "Percent225")
            workSheet.Cells(iRow, 113) = GridView1.GetRowCellValue(i, "Percent506")
            workSheet.Cells(iRow, 114) = GridView1.GetRowCellValue(i, "Percent601")
            workSheet.Cells(iRow, 115) = GridView1.GetRowCellValue(i, "Percent602")
            workSheet.Cells(iRow, 116) = GridView1.GetRowCellValue(i, "Percent603")
            workSheet.Cells(iRow, 117) = GridView1.GetRowCellValue(i, "Percent607")
            workSheet.Cells(iRow, 118) = GridView1.GetRowCellValue(i, "Percent608")
            workSheet.Cells(iRow, 119) = GridView1.GetRowCellValue(i, "Percent610")
            workSheet.Cells(iRow, 120) = GridView1.GetRowCellValue(i, "Percent629")
            workSheet.Cells(iRow, 121) = GridView1.GetRowCellValue(i, "Percent634")
            workSheet.Cells(iRow, 122) = GridView1.GetRowCellValue(i, "Percent635")
            workSheet.Cells(iRow, 123) = GridView1.GetRowCellValue(i, "Percent636")
            workSheet.Cells(iRow, 124) = GridView1.GetRowCellValue(i, "Percent637")
            workSheet.Cells(iRow, 125) = GridView1.GetRowCellValue(i, "SamplingEvaluation")
            workSheet.Cells(iRow, 126) = GridView1.GetRowCellValue(i, "TestReportEvaluation")
            workSheet.Cells(iRow, 127) = GridView1.GetRowCellValue(i, "FinalEvaluation")
            workSheet.Cells(iRow, 128) = GridView1.GetRowCellValue(i, "Treatment")
            workSheet.Cells(iRow, 129) = CDate(IIf(GridView1.GetRowCellValue(i, "Start") Is DBNull.Value, DateTime.MinValue, GridView1.GetRowCellValue(i, "Start"))).ToString("HH:mm")
            workSheet.Cells(iRow, 130) = CDate(IIf(GridView1.GetRowCellValue(i, "Finish") Is DBNull.Value, DateTime.MinValue, GridView1.GetRowCellValue(i, "Finish"))).ToString("HH:mm")
            workSheet.Cells(iRow, 131) = GridView1.GetRowCellValue(i, "Inspector")
            workSheet.Cells(iRow, 132) = GridView1.GetRowCellValue(i, "Remark")

            No += 1
            iRow += 1
        Next
        app.Visible = True

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
    End Sub

    Private Sub btnPrintReport_Click(sender As Object, e As EventArgs) Handles btnPrintReport.Click
        'dtB00.TableName = "B00Detail"
        'dtB00.WriteXmlSchema("B00Detail.xsd")

        Dim StartDate As DateTime
        Dim EndDate As DateTime
        Dim ActionDate As String

        StartDate = GetStartDate(dtpStartDate.Value)
        EndDate = GetEndDate(dtpEndDate.Value)
        ActionDate = "IncomingDate"

        Dim para(3) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "B00")
        para(1) = New SqlClient.SqlParameter("@StartDate", StartDate)
        para(2) = New SqlClient.SqlParameter("@EndDate", EndDate)
        para(3) = New SqlClient.SqlParameter("@ActionDate", ActionDate)

        Dim dt As DataTable = _db.ExecuteStoreProcedureTB("sp_EMM_ShowAll", para)

        Dim FrmReport As New RpB00Detail()
        FrmReport.DataSource = dt
        FrmReport.DataMember = ""

        'Dim paraRP As New Parameter()
        'Dim obj As New EMM_DLVRList
        'obj.PdCode = GridView1.GetFocusedRowCellValue("PdCode")
        'FrmReport.Parameters("ProductCode").Value = obj.PdCode 'gán giá trị
        'FrmReport.Parameters("ProductCode").Visible = False 'Xuất hiện bảng thông báo hay không

        Dim RePrTool As New ReportPrintTool(FrmReport)
        RePrTool.ShowPreview()
    End Sub

    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        If dtpStartDate.Value > dtpEndDate.Value Then
            dtpEndDate.Value = dtpStartDate.Value
        End If
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.ValueChanged
        If dtpEndDate.Value < dtpStartDate.Value Then
            dtpStartDate.Value = dtpEndDate.Value
        End If
    End Sub
End Class