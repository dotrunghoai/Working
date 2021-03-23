Imports System.Windows.Forms
Imports CommonDB
Imports PublicUtility
Imports System.IO
Imports Microsoft.Office.Interop
Imports Microsoft.Reporting.WinForms
Imports System.Reflection

Public Class FrmU00Detail
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _dbFpics As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim FileTmp As String = Application.StartupPath + "\Template Excel\Template EMM\"
    Dim FileExp As String = Application.StartupPath + "\Template Excel\Template EMM\Export EMM\"
    Dim cls As New clsApplication
    Public Shared searchJCode As String = ""
    Private Sub FrmU00Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        deStartDate.DateTime = GetStartDayOfMonth(DateTime.Now)
        deEndDate.DateTime = GetEndDayOfMonth(DateTime.Now)
    End Sub

    Private Sub deStartDate_EditValueChanged(sender As Object, e As EventArgs) Handles deStartDate.EditValueChanged
        If deStartDate.DateTime > deEndDate.DateTime Then
            deEndDate.DateTime = deStartDate.DateTime
        End If
    End Sub

    Private Sub deEndDate_EditValueChanged(sender As Object, e As EventArgs) Handles deEndDate.EditValueChanged
        If deEndDate.DateTime < deStartDate.DateTime Then
            deStartDate.DateTime = deEndDate.DateTime
        End If
    End Sub
    Private Sub btnShow_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim StartDate As DateTime
        Dim EndDate As DateTime
        Dim ActionDate As String

        StartDate = GetStartDate(deStartDate.DateTime)
        EndDate = GetEndDate(deEndDate.DateTime)

        If rbInspectionDate.Checked Then
            ActionDate = "InspectionDate"
        Else
            ActionDate = "IncomingDate"
        End If

        Dim para(3) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "U00")
        para(1) = New SqlClient.SqlParameter("@StartDate", StartDate)
        para(2) = New SqlClient.SqlParameter("@EndDate", EndDate)
        para(3) = New SqlClient.SqlParameter("@ActionDate", ActionDate)

        Dim dtU00 As DataTable = _db.ExecuteStoreProcedureTB("sp_EMM_ShowAll", para)
        GridControl1.DataSource = dtU00
        GridControlSetFormat(GridView1, 6, "Start""Finish")
        GridControlSetColorReadonly(GridView1)
        GridView1.Columns("Start").ColumnEdit = GridControlTimeEdit()
        GridView1.Columns("Finish").ColumnEdit = GridControlTimeEdit()
    End Sub
    Private Sub btnEdit_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridControlReadOnly(GridView1, False)
        GridView1.Columns("Code").OptionsColumn.ReadOnly = True
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnDelete_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        Dim result As DialogResult = MessageBox.Show("Bạn có muốn xóa Code: " + GridView1.GetFocusedRowCellValue("Code") + " không ?", "Cảnh báo", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            MessageBox.Show("Dữ liệu chưa được xóa", "Thông báo")
        ElseIf result = DialogResult.Yes Then
            Try
                Dim objDelete As String = String.Format("Delete from {0} where Code = '{1}'",
                                                              PublicTable.Table_EMM_U00Detail,
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
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)

            '---------
            If GridView1.FocusedColumn.FieldName = "IncomingDate" Or
                GridView1.FocusedColumn.FieldName = "InspectionDate" Or
                GridView1.FocusedColumn.FieldName = "JCode" Or
                GridView1.FocusedColumn.FieldName = "JName" Or
                GridView1.FocusedColumn.FieldName = "NDVLotNo" Or
                GridView1.FocusedColumn.FieldName = "MaterialLotNo" Or
                GridView1.FocusedColumn.FieldName = "TotalQuantity" Or
                GridView1.FocusedColumn.FieldName = "AcceptanceQualityLimits" Or
                GridView1.FocusedColumn.FieldName = "Maker" Or
                GridView1.FocusedColumn.FieldName = "Supplier" Or
                GridView1.FocusedColumn.FieldName = "Customer" Or
                GridView1.FocusedColumn.FieldName = "Start" Or
                GridView1.FocusedColumn.FieldName = "Finish" Or
                GridView1.FocusedColumn.FieldName = "Inspector" Then
                Dim objEditU00 As String = String.Format("Update EMM_DLVRList 
                                                          set {0} = @Value 
                                                          where Code = '{1}'",
                                                          e.Column.FieldName,
                                                          GridView1.GetFocusedRowCellValue("Code"))
                _db.ExecuteNonQuery(objEditU00, para)
            Else
                Dim objEditDLVR As String = String.Format("Update EMM_U00Detail 
                                                           set {0} = @Value 
                                                           where Code = '{1}'",
                                                           e.Column.FieldName,
                                                           GridView1.GetFocusedRowCellValue("Code"))
                _db.ExecuteNonQuery(objEditDLVR, para)
            End If
        End If
    End Sub

    Sub ExportU00()
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        'Copy template
        UpLoadFile(FileTmp + "U00.xlsx", FileExp + "U00.xlsx", True)
        'Variance
        Dim app As New Excel.Application
        Dim workBook As Excel.Workbook
        Dim workSheet As Excel.Worksheet
        Dim workRange As Excel.Range

        'Open file
        If (File.Exists(FileExp + "U00.xlsx")) Then
            workBook = app.Workbooks.Open(FileExp + "U00.xlsx", Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing)
        Else
            workBook = app.Workbooks.Add(Type.Missing)
        End If
        workSheet = CType(workBook.Sheets(1), Excel.Worksheet)
        app.Visible = False

        Dim dtU00 As DataTable = GridControl1.DataSource
        Dim dtView As DataView = dtU00.DefaultView
        dtView.Sort = "JCode asc,IncomingDate asc"
        Dim dtNew As DataTable = dtView.ToTable
        Dim distinctGV() As String = (From row As DataRow In dtNew.Rows
                                      Order By row("JCode") Ascending
                                      Select CStr(row("JCode"))).Distinct.ToArray


        Dim myrow As Integer = 0
        Dim No As Integer = 1
        Dim iRow As Integer = 8
        Dim SetData As Boolean = False
        For i As Integer = myrow To GridView1.RowCount - 1

            If No > 30 Then
                workRange = workSheet.Range(workSheet.Cells(iRow, 1), workSheet.Cells(iRow, 41))
                workRange.Rows.RowHeight = 24.75
                workRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown)

            End If

            workSheet.Cells(iRow, 1) = No
            workSheet.Cells(iRow, 2) = GridView1.GetRowCellValue(i, "IncomingDate")
            workSheet.Cells(iRow, 3) = GridView1.GetRowCellValue(i, "InspectionDate")
            workSheet.Cells(iRow, 4) = GridView1.GetRowCellValue(i, "NDVLotNo")
            workSheet.Cells(iRow, 5) = GridView1.GetRowCellValue(i, "MaterialLotNo")
            workSheet.Cells(iRow, 6) = GridView1.GetRowCellValue(i, "TotalQuantity")
            workSheet.Cells(iRow, 7) = GridView1.GetRowCellValue(i, "AcceptanceQualityLimits")
            'KQCV
            workSheet.Cells(iRow, 11) = GridView1.GetRowCellValue(i, "Chamfer")
            workSheet.Cells(iRow, 12) = GridView1.GetRowCellValue(i, "F03")
            workSheet.Cells(iRow, 13) = GridView1.GetRowCellValue(i, "F04")
            workSheet.Cells(iRow, 14) = GridView1.GetRowCellValue(i, "FEvaluation")
            workSheet.Cells(iRow, 37) = ":"
            workSheet.Cells(iRow, 38) = ":"
            No += 1
            iRow += 1
        Next

        If No > 30 Then
            workRange = workSheet.Range(workSheet.Cells(8, 1), workSheet.Cells(iRow - 1, 41))
            workRange.Borders.LineStyle = 1
        End If

        workBook.Save()
        workBook.Close()
        app.Quit()
        app.Visible = True
        app.Workbooks.Open(FileExp + "U00.xlsx")

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
    End Sub

    Sub ExportU00_New()
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Cursor = Cursors.AppStarting
        'Copy template
        UpLoadFile(FileTmp + "U00-New.xlsx", FileExp + "U00-New.xlsx", True)
        'Variance
        Dim app As New Excel.Application
        Dim workBook As Excel.Workbook
        Dim workSheet As Excel.Worksheet
        Dim workRange As Excel.Range

        'Open file
        If (File.Exists(FileExp + "U00-New.xlsx")) Then
            workBook = app.Workbooks.Open(FileExp + "U00-New.xlsx", Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing)
        Else
            workBook = app.Workbooks.Add(Type.Missing)
        End If
        workSheet = CType(workBook.Sheets(1), Excel.Worksheet)
        workSheet.Name = "QC-F-011 (3)"
        app.Visible = False
        app.DisplayAlerts = False
        Dim dtU00 As DataTable = GridControl1.DataSource
        Dim dtView As DataView = dtU00.DefaultView
        dtView.Sort = "Customer, JCode asc, NDVLotNo, IncomingDate asc"
        Dim dtNew As DataTable = dtView.ToTable
        Dim distinctGV() As String = (From row As DataRow In dtNew.Rows
                                      Order By row("Customer"), row("JCode") Ascending
                                      Select CStr(row("Customer"))).Distinct.ToArray

        For i As Integer = 0 To distinctGV.Count - 1
            Dim countWorkSheet As Integer = workBook.Worksheets.Count
            Dim newWorksheet As Excel.Worksheet = DirectCast(workBook.Sheets(countWorkSheet), Excel.Worksheet)
            If distinctGV(i) <> "" Then
                newWorksheet.Name = distinctGV(i)
            Else
                newWorksheet.Name = "NoCS"
            End If
            If i < (distinctGV.Count - 1) Then
                workSheet.Copy(Missing.Value, newWorksheet)
            End If
        Next

        'For i As Integer = 0 To distinctGV.Count - 1
        '	Dim countWorkSheet As Integer = workBook.Worksheets.Count
        '	Dim newWorksheet As Excel.Worksheet = DirectCast(workBook.Sheets(countWorkSheet), Excel.Worksheet)

        '	newWorksheet.Name = distinctGV(i)
        '	If i < (distinctGV.Count - 1) Then
        '		workSheet.Copy(Missing.Value, newWorksheet)
        '	End If
        'Next

        Dim myrow As Integer = 0
        For k As Integer = 0 To distinctGV.Count - 1
            workSheet = CType(workBook.Sheets(k + 1), Excel.Worksheet)
            Dim iRow As Integer = 9
            Dim No As Integer = 1
            Dim SetData As Boolean = False
            Dim count As Integer = 1



            For i As Integer = myrow To GridView1.RowCount - 1
                If workSheet.Name <> GridView1.GetRowCellValue(i, "Customer") And
                    GridView1.GetRowCellValue(i, "Customer") <> "" Then
                    myrow = i
                    Exit For
                End If

                If iRow > 28 Then
                    workRange = workSheet.Range(workSheet.Cells(iRow, 1), workSheet.Cells(iRow, 25))
                    workRange.Rows.RowHeight = 24.75
                    workRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
                End If

                workSheet.Cells(3, 18) = GridView1.GetRowCellValue(i, "Customer")
                workSheet.Cells(3, 24) = GridView1.GetRowCellValue(i, "IncomingDate")

                If i > 0 Then
                    'Mergcell
                    If GridView1.GetRowCellValue(i, "NDVLotNo") = GridView1.GetRowCellValue(i - 1, "NDVLotNo") Then
                        workRange = workSheet.Range(workSheet.Cells(iRow, 1), workSheet.Cells(iRow - 1, 1))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 2), workSheet.Cells(iRow - 1, 2))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 3), workSheet.Cells(iRow - 1, 3))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 4), workSheet.Cells(iRow - 1, 4))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 5), workSheet.Cells(iRow - 1, 5))
                        workRange.Merge(Type.Missing)
                        workSheet.Cells(iRow, 6) = GridView1.GetRowCellValue(i, "MaterialLotNo")
                        workRange = workSheet.Range(workSheet.Cells(iRow, 7), workSheet.Cells(iRow - 1, 7))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 8), workSheet.Cells(iRow - 1, 8))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 9), workSheet.Cells(iRow - 1, 9))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 10), workSheet.Cells(iRow - 1, 10))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 11), workSheet.Cells(iRow - 1, 11))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 12), workSheet.Cells(iRow - 1, 12))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 13), workSheet.Cells(iRow - 1, 13))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 14), workSheet.Cells(iRow - 1, 14))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 15), workSheet.Cells(iRow - 1, 15))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 16), workSheet.Cells(iRow - 1, 16))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 17), workSheet.Cells(iRow - 1, 17))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 18), workSheet.Cells(iRow - 1, 18))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 19), workSheet.Cells(iRow - 1, 19))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 20), workSheet.Cells(iRow - 1, 20))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 21), workSheet.Cells(iRow - 1, 21))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 22), workSheet.Cells(iRow - 1, 22))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 23), workSheet.Cells(iRow - 1, 23))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 24), workSheet.Cells(iRow - 1, 24))
                        workRange.Merge(Type.Missing)
                        workRange = workSheet.Range(workSheet.Cells(iRow, 25), workSheet.Cells(iRow - 1, 25))
                        workRange.Merge(Type.Missing)

                    Else

                        workSheet.Cells(iRow, 1) = No
                        workSheet.Cells(iRow, 2) = GridView1.GetRowCellValue(i, "InspectionDate")

                        workSheet.Cells(iRow, 3) = GridView1.GetRowCellValue(i, "JCode")
                        workSheet.Cells(iRow, 4) = GridView1.GetRowCellValue(i, "JName")

                        workSheet.Cells(iRow, 5) = GridView1.GetRowCellValue(i, "NDVLotNo")
                        workSheet.Cells(iRow, 6) = GridView1.GetRowCellValue(i, "MaterialLotNo")
                        Dim sl As Integer = dtU00.Compute("sum(TotalQuantity)",
                                                                 String.Format("NDVLotNo='{0}' and JCode='{1}' ",
                                                                 GridView1.GetRowCellValue(i, "NDVLotNo"),
                                                                 GridView1.GetRowCellValue(i, "JCode")))

                        workSheet.Cells(iRow, 7) = sl
                        workSheet.Cells(iRow, 8) = AQL("A", sl)

                        'workSheet.Cells(iRow, 13) = ""
                        'workSheet.Cells(iRow, 14) = ""
                        'workSheet.Cells(iRow, 15) = ""

                        No += 1
                    End If
                Else
                    workSheet.Cells(iRow, 1) = No
                    workSheet.Cells(iRow, 2) = GridView1.GetRowCellValue(i, "InspectionDate")

                    workSheet.Cells(iRow, 3) = GridView1.GetRowCellValue(i, "JCode")
                    workSheet.Cells(iRow, 4) = GridView1.GetRowCellValue(i, "JName")

                    workSheet.Cells(iRow, 5) = GridView1.GetRowCellValue(i, "NDVLotNo")
                    workSheet.Cells(iRow, 6) = GridView1.GetRowCellValue(i, "MaterialLotNo")
                    Dim sl As Integer = dtU00.Compute("sum(TotalQuantity)",
                                                                 String.Format("NDVLotNo='{0}' and JCode='{1}' ",
                                                                 GridView1.GetRowCellValue(i, "NDVLotNo"),
                                                                 GridView1.GetRowCellValue(i, "JCode")))

                    workSheet.Cells(iRow, 7) = sl
                    workSheet.Cells(iRow, 8) = AQL("A", sl)

                    No += 1
                End If

                iRow += 1
            Next

            If iRow > 28 Then
                workRange = workSheet.Range(workSheet.Cells(9, 1), workSheet.Cells(iRow - 1, 25))
                workRange.Borders.LineStyle = 1
            End If
        Next

        app.Visible = True

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        Cursor = Cursors.Default
        ShowSuccess()

    End Sub

    Function AQL(ByVal JCodeGroup As String, ByVal Quantity As Decimal) As Integer
        Dim sqlAQL As String = String.Format("Select FromQuantity, ToQuantity, AcceptanceQualityLimits from {0} where JCodeGroup = '{1}'",
                                                         PublicTable.Table_EMM_MasterAQL, JCodeGroup)
        Dim dtAQL As DataTable = _db.FillDataTable(sqlAQL)
        If dtAQL.Rows.Count <> 0 Then
            For i As Integer = 0 To dtAQL.Rows.Count - 1
                If Quantity >= dtAQL.Rows(i)("FromQuantity") And Quantity <= dtAQL.Rows(i)("ToQuantity") Then
                    Return dtAQL.Rows(i)("AcceptanceQualityLimits")
                End If
            Next
        End If

        Return Quantity
    End Function



    Private Sub btnExportGrid2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportGrid2.ItemClick
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub btnExportExcel2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportExcel2.ItemClick
        Dim StartDate As DateTime
        Dim EndDate As DateTime
        Dim ActionDate As String

        StartDate = GetStartDate(deStartDate.DateTime)
        EndDate = GetEndDate(deEndDate.DateTime)

        If rbInspectionDate.Checked Then
            ActionDate = "InspectionDate"
        Else
            ActionDate = "IncomingDate"
        End If

        Dim para(3) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "U00")
        para(1) = New SqlClient.SqlParameter("@StartDate", StartDate)
        para(2) = New SqlClient.SqlParameter("@EndDate", EndDate)
        para(3) = New SqlClient.SqlParameter("@ActionDate", ActionDate)

        Dim dt As DataTable = _db.ExecuteStoreProcedureTB("sp_EMM_ShowAll", para)
        ExportEXCEL(dt)
    End Sub

    Private Sub btnExportTemp_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportTemp.ItemClick
        If ceU00.Checked Then
            ExportU00()
        Else
            ExportU00_New()
        End If
    End Sub

    Private Sub btnPrintU002_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrintU002.ItemClick
        If GridView1.RowCount = 0 Then
            Return
        End If
        Dim frm = New FrmReportNet()
        frm.rptViewer.LocalReport.DataSources.Clear()
        frm.rptViewer.LocalReport.ReportPath = Application.StartupPath + "\Reports\QC\rptU00Detail.rdlc"
        frm.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("U00Detail", GridControl1.DataSource))
        frm.rptViewer.SetDisplayMode(DisplayMode.PrintLayout)
        frm.rptViewer.ZoomMode = ZoomMode.PageWidth
        frm.rptViewer.RefreshReport()
        frm.Show()
    End Sub

    Private Sub ceU00_CheckedChanged(sender As Object, e As EventArgs) Handles ceU00.CheckedChanged
        If ceU00.Checked Then
            GridView1.Columns("Chamfer").Visible = True
            GridView1.Columns("F03").Visible = True
            GridView1.Columns("F04").Visible = True
            GridView1.Columns("FEvaluation").Visible = True
            GridView1.Columns("AdhesiveStrength").Visible = True
            GridView1.Columns("ThicknessResult").Visible = True
            GridView1.Columns("ThicknessEvaluation").Visible = True
            GridView1.Columns("Start").Visible = True
            GridView1.Columns("Finish").Visible = True
        Else
            GridView1.Columns("Chamfer").Visible = False
            GridView1.Columns("F03").Visible = False
            GridView1.Columns("F04").Visible = False
            GridView1.Columns("FEvaluation").Visible = False
            GridView1.Columns("AdhesiveStrength").Visible = False
            GridView1.Columns("ThicknessResult").Visible = False
            GridView1.Columns("ThicknessEvaluation").Visible = False
            GridView1.Columns("Start").Visible = False
            GridView1.Columns("Finish").Visible = False
        End If
    End Sub

    Private Sub btnPaste_Click(sender As Object, e As EventArgs) Handles btnPaste.Click
        Dim pasteVal = My.Computer.Clipboard.GetText
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Date", pasteVal)
        For Each r As Integer In GridView1.GetSelectedRows
            _db.ExecuteNonQuery(String.Format(" Update EMM_U00Detail 
                                                SET ShipmentDate = @Date 
                                                WHERE Code = '{0}'",
                                                GridView1.GetRowCellValue(r, "Code")),
                                                para)
            GridView1.Columns("ShipmentDate").OptionsColumn.ReadOnly = True
            GridView1.SetRowCellValue(r, "ShipmentDate", pasteVal)
            GridView1.Columns("ShipmentDate").OptionsColumn.ReadOnly = False
        Next
    End Sub

    Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
        Dim sfDlg As New OpenFileDialog()
        sfDlg.DefaultExt = ".xlsx"
        sfDlg.Filter = "Excel 2007 file(.xl)|*.xlsx"
        sfDlg.FileName = "ImportLotNoNew.xlsx"
        sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\46. Import vào ERP- Expiry\{0}\Tháng {1}\",
                                               DateTime.Now.ToString("yyyy"),
                                               DateTime.Now.ToString("MM.yyyy"))
        If sfDlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        _db.ExecuteStoreProcedure("sp_EMM_UpdateJCodeName")
        Dim arrSheet(0) As String
        arrSheet(0) = "ImportLotNo"
        Dim dataset As DataSet = ImportEXCEL(arrSheet, sfDlg.FileName)

        If dataset.Tables.Count = 0 Then
            ShowWarning("Không có dữ liệu import !")
            Exit Sub
        End If
        Dim dt As DataTable = dataset.Tables("ImportLotNo")
        Dim iCount As Integer = 0
        Dim rowError As Integer = 0
        Dim notImport As String = ""
        Dim myItemcode As String = ""

        Try
            If dt.Rows.Count > 0 Then
                Me.Cursor = Cursors.WaitCursor
                _db.BeginTransaction()
                For i As Integer = 0 To dt.Rows.Count - 1
                    rowError = i + 1
                    Dim obj As New EMM_DLVRList
                    If dt.Rows(i).Item("IncomingDate") IsNot DBNull.Value Then
                        'Dim cls As New clsApplication
                        Dim dateTemp As DateTime = dt.Rows(i).Item("IncomingDate")
                        obj.IncomingDate = New DateTime(dateTemp.Year, dateTemp.Month, dateTemp.Day)
                    Else
                        Continue For
                    End If

                    If dt.Rows(i).Item("INVNo") IsNot DBNull.Value Then
                        obj.INVNo = Trim(dt.Rows(i).Item("INVNo"))
                    End If

                    If dt.Rows(i).Item("PONo") IsNot DBNull.Value Then
                        obj.PONo = Trim(dt.Rows(i).Item("PONo"))
                    End If
                    If dt.Rows(i).Item("SoKien") IsNot DBNull.Value Then
                        obj.SoKien = Trim(dt.Rows(i).Item("SoKien"))
                    End If
                    If dt.Rows(i).Item("JCode") IsNot DBNull.Value Then
                        obj.JCode = Trim(dt.Rows(i).Item("JCode"))
                    Else
                        Continue For
                    End If

                    myItemcode = obj.JCode

                    If dt.Rows(i).Item("StockInNittsu") IsNot DBNull.Value Then
                        obj.StockInNittsu = Trim(dt.Rows(i).Item("StockInNittsu"))
                    End If

                    If dt.Rows(i).Item("NDVLotNo") IsNot DBNull.Value Then
                        obj.NDVLotNo = Trim(dt.Rows(i).Item("NDVLotNo"))
                    End If

                    If dt.Rows(i).Item("MaterialLotNo") IsNot DBNull.Value Then
                        obj.MaterialLotNo = Trim(dt.Rows(i).Item("MaterialLotNo"))
                    End If

                    If IsNumeric(dt.Rows(i).Item("CartonQuantity")) Then
                        obj.CartonQuantity = dt.Rows(i).Item("CartonQuantity")
                    End If

                    'JCodeGroup, JName, Unit...
                    Dim objJCode As New EMM_MasterJCode
                    objJCode.JCode_K = obj.JCode
                    If _db.ExistObject(objJCode) Then
                        _db.GetObject(objJCode)
                        'Start: Gán số lượng tổng nếu chưa điền số lượng carton
                        If obj.QuantityOfCarton = 0 Then
                            If objJCode.QtyOfCartonIQC = 0 Then
                                obj.QuantityOfCarton = obj.CartonQuantity
                                obj.CartonQuantity = 1
                                obj.TotalQuantity = obj.QuantityOfCarton
                            ElseIf objJCode.QtyOfCartonIQC > obj.CartonQuantity Then
                                obj.QuantityOfCarton = objJCode.QtyOfCartonIQC
                                obj.TotalQuantity = obj.CartonQuantity * obj.QuantityOfCarton
                            Else
                                obj.TotalQuantity = obj.CartonQuantity
                                obj.QuantityOfCarton = objJCode.QtyOfCartonIQC
                                obj.CartonQuantity = obj.CartonQuantity / objJCode.QtyOfCartonIQC
                            End If
                        End If

                        If obj.MaterialLotNo.Trim = "" Then
                            If MessageBox.Show("Row " & rowError & " chưa có LotNo. Bạn có muốn tiếp tục?",
                               "Warning", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                _db.RollBack()
                                Exit Sub
                            Else
                                GetExpiry(obj, objJCode, "No")
                            End If
                        Else
                            GetExpiry(obj, objJCode, "Yes")
                        End If
                    Else
                        Dim sqlFPICS As String = String.Format("SELECT  A.ItemCode , " +
                        "A.ItemName, " +
                        "A.MakerCode, " +
                        "B.UnitCode, " +
                        "C.VendorCode, " +
                        "C.VendorName " +
                        "FROM    dbo.t_ASMaterialItemVendor A " +
                        "INNER JOIN dbo.t_ASMaterialItem B ON A.ItemCode = B.ItemCode " +
                        "INNER JOIN dbo.t_ASMaterialVendor C ON A.VendorCode = C.VendorCode " +
                        "WHERE   A.ItemCode = '{0}' " +
                        "ORDER BY LastPurchaseDate DESC", obj.JCode)
                        Dim dtFPICS As DataTable = _dbFpics.FillDataTable(sqlFPICS)
                        If dtFPICS.Rows.Count > 0 Then
                            obj.JName = dtFPICS.Rows(0)("ItemName")
                            obj.UnitAS400 = dtFPICS.Rows(0)("UnitCode")
                            obj.SupplierCode = dtFPICS.Rows(0)("VendorCode")
                            obj.Supplier = dtFPICS.Rows(0)("VendorName")

                            Dim dbAS As New DBFunction(PublicConst.EnumServers.NDV_DB2_AS400)
                            obj.Maker = dbAS.ExecuteScalar(String.Format("select MIMKNM from NDVDTA.MMIMKRP where MIMKCD='{0}' ",
                                                                         dtFPICS.Rows(0)("MakerCode")))
                        Else
                            MessageBox.Show("JCode " & obj.JCode & " is not existed in MasterJCode", "Import DLVR")
                            notImport = notImport & (i + 2) & " "
                            _db.RollBack()
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        End If
                    End If

                    obj.CreateUser = CurrentUser.UserID
                    obj.CreateDate = DateTime.Now
                    Dim paraCheck(0) As SqlClient.SqlParameter
                    paraCheck(0) = New SqlClient.SqlParameter("@InComeDate", GetStartDate(obj.IncomingDate))
                    'Check Exist
                    Dim sqlExist As String = String.Format("SELECT  Code " +
                                                            "FROM {0} " +
                                                            "WHERE   Code like '{1}%' " +
                                                            "AND JCode = '{2}' " +
                                                            "AND MaterialLotNo = '{3}' " +
                                                            "AND QuantityOfCarton = '{4}' " +
                                                            "AND IncomingDate=@InComeDate ",
                                                            PublicTable.Table_EMM_DLVRList,
                                                            DateTime.Now.ToString("yyMMdd"),
                                                            obj.JCode,
                                                            obj.MaterialLotNo,
                                                            obj.QuantityOfCarton)

                    Dim dtExist As DataTable = _db.FillDataTable(sqlExist, paraCheck)
                    If dtExist.Rows.Count = 0 Then
                        obj.Code_K = CreateID()
                    Else
                        If obj.JName.ToString.ToUpper.IndexOf("FPC TRAY") < 0 Then
                            obj.Code_K = CreateID()
                        Else
                            obj.Code_K = dtExist.Rows(0)("Code")
                        End If
                    End If

                    If _db.ExistObject(obj) Then
                        Dim objExist As New EMM_DLVRList
                        objExist.Code_K = obj.Code_K
                        _db.GetObject(objExist)
                        objExist.CartonQuantity = objExist.CartonQuantity + obj.CartonQuantity
                        objExist.TotalQuantity = objExist.TotalQuantity + obj.TotalQuantity
                        _db.Update(objExist)
                    Else
                        InsertDetail(obj)
                        _db.Insert(obj)
                    End If

                    '-------------------------------------------
                    iCount += 1
                    txtStatus2.EditValue = iCount
                    Application.DoEvents()
                    '------------------------------------------
                Next

                _db.Commit()

                If (iCount > 0) Then
                    ShowSuccess(String.Format("Imported successfully: {0} rows. Not Imported Rows: {1}", iCount, notImport))
                End If
            Else
                ShowWarning("Không có dữ liệu để Import !")
            End If
        Catch ex As Exception
            _db.RollBack()
            ShowWarning(String.Format(ex.Message + " Error, Row {0}.ItemCode:{1}", rowError, myItemcode))
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub
    Sub GetExpiry(ByRef obj As EMM_DLVRList, ByRef objJCode As EMM_MasterJCode, ByVal YN As String)
        If YN = "Yes" Then
            If objJCode.InIncommingDate = 1 Then
                obj.ProductionDate = obj.IncomingDate
            Else
                obj.ProductionDate = cls.ReadLotNo(obj.JCode, obj.MaterialLotNo)
            End If

            obj.JCodeGroup = objJCode.JCodeGroup
            obj.JName = objJCode.JName
            obj.Unit = objJCode.UnitCodeIQC
            obj.UnitAS400 = objJCode.UnitCodeAS400
            obj.Maker = objJCode.MakerName
            obj.SupplierCode = objJCode.SupplierCode
            obj.Supplier = objJCode.SupplierName
            obj.ExpiryProduction = objJCode.ExpiryProduction
            obj.ExpiryDelivery = objJCode.ExpiryDelivery
            obj.WinThinProduction = objJCode.WinThinProduction
            If objJCode.ExpiryProduction <> 0 And obj.ProductionDate > DateTime.MinValue Then
                'If objJCode.JCode_K = "J00003" Then
                '    ShowWarning(objJCode.JCode_K)
                'End If
                If objJCode.ExpiryProduction Mod 1 > 0 Then
                    obj.ExpiryDate = obj.ProductionDate.AddDays(objJCode.ExpiryProduction * 30)
                Else
                    obj.ExpiryDate = obj.ProductionDate.AddMonths(objJCode.ExpiryProduction)
                End If
            ElseIf objJCode.ExpiryDelivery <> 0 Then
                If objJCode.ExpiryDelivery Mod 1 > 0 Then
                    obj.ExpiryDate = obj.IncomingDate.AddDays(objJCode.ExpiryDelivery * 30)
                Else
                    obj.ExpiryDate = obj.IncomingDate.AddMonths(objJCode.ExpiryDelivery)
                End If
            Else
                obj.ExpiryDate = DateTime.MinValue
            End If
        Else
            If objJCode.InIncommingDate = 1 Then
                obj.ProductionDate = obj.IncomingDate
            Else
                obj.ProductionDate = DateTime.MinValue
            End If
            obj.JCodeGroup = objJCode.JCodeGroup
            obj.JName = objJCode.JName
            obj.Unit = objJCode.UnitCodeIQC
            obj.UnitAS400 = objJCode.UnitCodeAS400
            obj.Maker = objJCode.MakerName
            obj.SupplierCode = objJCode.SupplierCode
            obj.Supplier = objJCode.SupplierName
            obj.ExpiryProduction = objJCode.ExpiryProduction
            obj.ExpiryDelivery = objJCode.ExpiryDelivery
            obj.WinThinProduction = objJCode.WinThinProduction

            obj.ExpiryDate = DateTime.MinValue
        End If

    End Sub
    Function CreateID() As String
        Dim ID As String = ""
        Dim stt As String = ""
        Dim o As Object = Nothing
        Dim yyMMdd As String = DateTime.Now.ToString("yyMMdd")
        Dim sql As String = String.Format(" select right(Max(Code), 4) FROM {0} " +
                                          " where Code like '{1}%' ", PublicTable.Table_EMM_DLVRList, yyMMdd)
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
    Sub InsertDetail(ByRef obj As EMM_DLVRList)
        Dim objJCode As New EMM_MasterJCode
        objJCode.JCode_K = obj.JCode
        If _db.ExistObject(objJCode) Then
            _db.GetObject(objJCode)
        End If

        If objJCode.JCodeGroup Is Nothing Then
            Dim objSetJCode As New FrmSetJCode
            searchJCode = obj.JCode
            objSetJCode.ShowDialog()

            obj.JCodeGroup = searchJCode
            objJCode.JCode_K = obj.JCode
            objJCode.JCodeGroup = searchJCode
            _db.Insert(objJCode)
            _db.ExecuteStoreProcedure("sp_EMM_UpdateJCodeName")
        End If

        If objJCode.JCodeGroup = "A" Then 'U00
            obj.AcceptanceQualityLimits = AQL(objJCode.JCodeGroup, obj.TotalQuantity)
            If obj.AcceptanceQualityLimits = 0 Then
                obj.AcceptanceQualityLimits = 1
            End If

            'Dim TestReport As String = IIf(objJCode.CheckingMethod = "TestReport", "OK", "-")
            Dim TestReport As String = "OK"
            'Dim sql As String = String.Format("Insert Into {0}(Code, OrderCode, TestReport) values('{1}',{2},'{3}')",
            '                                  PublicTable.Table_EMM_U00Detail, obj.Code_K, 1, TestReport)
            '_db.ExecuteNonQuery(sql)
            Dim objU As New EMM_U00Detail
            objU.Code_K = obj.Code_K
            objU.TestReport = TestReport
            objU.Design = "OK"
            objU.Surface = "OK"
            objU.AdhesiveStrength = "NA"
            objU.ThicknessEvaluation = "NA"
            objU.GeneralEvaluation = "OK"
            If _db.ExistObject(objU) Then
                _db.Update(objU)
            Else
                _db.Insert(objU)
            End If
        ElseIf objJCode.JCodeGroup = "B" Then 'Chemical
            obj.AcceptanceQualityLimits = 1
            Dim deliveryTime As String = "-"
            'If obj.WinThinProduction <> 0 Then
            '    If obj.ProductionDate.AddMonths(obj.WinThinProduction).ToString("yyyyMMdd") > obj.IncomingDate.ToString("yyyyMMdd") Then
            '        deliveryTime = "OK"
            '    Else
            '        deliveryTime = "X"
            '    End If
            'End If

            'Dim TestReport As String = IIf(objJCode.CheckingMethod = "TestReport", "OK", "-")
            Dim TestReport As String = "O"
            'Dim sql As String = String.Format("Insert Into {0}(Code, OrderCode, DeliveryTime, TestReport) values('{1}',{2}, '{3}', '{4}')", _
            '                                  PublicTable.Table_EMM_ChemicalDetail, obj.Code_K, 1, deliveryTime, TestReport)
            '_db.ExecuteNonQuery(sql)
            Dim objC As New EMM_ChemicalDetail
            objC.Code_K = obj.Code_K
            objC.OrderCode_K = 1
            objC.DeliveryTime = "O"
            objC.TestReport = "O"
            objC.GeneralEvaluation = "O"
            objC.Packing = "O"

            If _db.ExistObject(objC) Then
                _db.Update(objC)
            Else
                _db.Insert(objC)
            End If

        ElseIf objJCode.JCodeGroup = "C" Then 'Nylon
            'obj.AcceptanceQualityLimits = AQL(obj.JCodeGroup, obj.TotalQuantity)
            obj.AcceptanceQualityLimits = 9
            Dim orderCode As Integer = 1

            For j As Integer = 0 To obj.AcceptanceQualityLimits - 1
                'Dim sql As String = String.Format("Insert Into {0}(Code, OrderCode) values('{1}',{2})",
                '                                  PublicTable.Table_EMM_NylonDetail, obj.Code_K, orderCode)
                '_db.ExecuteNonQuery(sql)
                Dim objN As New EMM_NylonDetail
                objN.Code_K = obj.Code_K
                objN.OrderCode_K = orderCode
                If _db.ExistObject(objN) Then
                    _db.Update(objN)
                Else
                    _db.Insert(objN)
                End If
                orderCode += 1
            Next

        ElseIf objJCode.JCodeGroup = "D" Then 'Carton
            obj.AcceptanceQualityLimits = AQL(objJCode.JCodeGroup, obj.TotalQuantity)
            Dim orderCode As Integer = 1


            For j As Integer = 0 To obj.AcceptanceQualityLimits - 1
                'Dim sql As String = String.Format("Insert Into {0}(Code, OrderCode) values('{1}',{2})",
                '                                  PublicTable.Table_EMM_CartonDetail, obj.Code_K, orderCode)
                '_db.ExecuteNonQuery(sql)
                Dim objN As New EMM_CartonDetail
                objN.Code_K = obj.Code_K
                objN.OrderCode_K = orderCode
                If _db.ExistObject(objN) Then
                    _db.Update(objN)
                Else
                    _db.Insert(objN)
                End If
                orderCode += 1
            Next

        ElseIf objJCode.JCodeGroup = "E" Then 'WhitePet sat nhap chung chemical
            obj.AcceptanceQualityLimits = AQL(objJCode.JCodeGroup, obj.TotalQuantity)
            Dim orderCode As Integer = 1

            For j As Integer = 0 To obj.AcceptanceQualityLimits - 1
                'Dim sql As String = String.Format("Insert Into {0}(Code, OrderCode) values('{1}',{2})",
                '                                  PublicTable.Table_EMM_WhitePet, obj.Code_K, orderCode)
                '_db.ExecuteNonQuery(sql)
                Dim objN As New EMM_WhitePet
                objN.Code_K = obj.Code_K
                objN.OrderCode_K = orderCode
                If _db.ExistObject(objN) Then
                    _db.Update(objN)
                Else
                    _db.Insert(objN)
                End If
                orderCode += 1
            Next

        End If
    End Sub
End Class