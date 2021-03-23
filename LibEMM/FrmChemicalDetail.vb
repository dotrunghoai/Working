Imports CommonDB
Imports PublicUtility
Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.Office.Interop
Imports Microsoft.Reporting.WinForms

Public Class FrmChemicalDetail
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim FileTmp As String = Application.StartupPath + "\Template Excel\Template EMM\"
    Dim FileExp As String = Application.StartupPath + "\Template Excel\Template EMM\Export EMM\"
    Private Sub FrmChemicalDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        deStartDate.DateTime = DateTime.Now
        deEndDate.DateTime = DateTime.Now
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
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
        para(0) = New SqlClient.SqlParameter("Action", "Chemical")
        para(1) = New SqlClient.SqlParameter("@StartDate", StartDate)
        para(2) = New SqlClient.SqlParameter("@EndDate", EndDate)
        para(3) = New SqlClient.SqlParameter("@ActionDate", ActionDate)

        Dim dtChemical As DataTable = _db.ExecuteStoreProcedureTB("sp_emm_ShowAll", para)
        GridControl1.DataSource = dtChemical
        GridControlSetFormat(GridView1, 4, "Start""Finish")
        GridControlSetColorReadonly(GridView1)
        GridView1.Columns("Start").ColumnEdit = GridControlTimeEdit()
        GridView1.Columns("Finish").ColumnEdit = GridControlTimeEdit()
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridControlReadOnly(GridView1, False)
        GridView1.Columns("Code").OptionsColumn.ReadOnly = True
        GridView1.Columns("Unit").OptionsColumn.ReadOnly = True
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        Dim result As DialogResult = MessageBox.Show("Bạn có muốn xóa Code: " + GridView1.GetFocusedRowCellValue("Code") + " không ?", "Cảnh báo", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            MessageBox.Show("Dữ liệu chưa được xóa", "Thông báo")
        ElseIf result = DialogResult.Yes Then
            Try
                Dim objDelete As String = String.Format("Delete from {0} where Code = '{1}'",
                                                        PublicTable.Table_EMM_ChemicalDetail,
                                                        GridView1.GetFocusedRowCellValue("Code"))
                _db.ExecuteNonQuery(objDelete)
                GridView1.DeleteSelectedRows()
            Catch ex As Exception
                MessageBox.Show(ex.Message, PublicConst.Message_Caption_Error)
            End Try
            MessageBox.Show("Bạn đã xóa thành công", "Thông báo")
        End If
    End Sub

    Private Sub btnExportGrid_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportGrid.ItemClick
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub btnExportExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportExcel.ItemClick
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
        para(0) = New SqlClient.SqlParameter("@Action", "Chemical")
        para(1) = New SqlClient.SqlParameter("@StartDate", StartDate)
        para(2) = New SqlClient.SqlParameter("@EndDate", EndDate)
        para(3) = New SqlClient.SqlParameter("@ActionDate", ActionDate)

        Dim dtChemical As DataTable = _db.ExecuteStoreProcedureTB("sp_EMM_ShowAll", para)
        ExportEXCEL(dtChemical)
    End Sub

    Private Sub btnExportTemp_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportTemp.ItemClick
        If ceIsTray.Checked Then
            ExportTray()
        Else
            ExportChemical()
        End If
    End Sub

    Sub ExportTray()
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        'Copy template
        UpLoadFile(FileTmp + "Tray.xlsx", FileExp + "Tray.xlsx", True)
        'Variance
        Dim app As New Excel.Application
        Dim workBook As Excel.Workbook
        Dim workSheet As Excel.Worksheet
        Dim workRange As Excel.Range

        'Open file
        If (File.Exists(FileExp + "Tray.xlsx")) Then
            workBook = app.Workbooks.Open(FileExp + "Tray.xlsx", Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing)
        Else
            workBook = app.Workbooks.Add(Type.Missing)
        End If

        workSheet = CType(workBook.Sheets(1), Excel.Worksheet)
        app.Visible = False

        'If gridChemical.Rows.Count = 0 Then Exit Sub

        'Dim distinctGV() As String = (From row As DataGridViewRow In gridChemical.Rows.Cast(Of DataGridViewRow)() _
        '             Where (row.Cells("JNameChem").Value.ToString.ToUpper.Contains("TRAY")) _
        '             Select CStr(row.Cells("JCodeChem").Value)).Distinct.ToArray

        Dim iRow As Integer = 7
        Dim No As Integer = 1
        For i As Integer = 0 To GridView1.RowCount - 1
            'If gridChemical.Rows(i).Cells("JNameChem").Value.ToString.ToUpper.IndexOf("FPC TRAY") < 0 Then Continue For

            If No > 24 Then
                workRange = workSheet.Range(workSheet.Cells(iRow, 1), workSheet.Cells(iRow, 19))
                workRange.Rows.RowHeight = 24.75
                workRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
            End If

            workSheet.Cells(iRow, 1) = No
            workSheet.Cells(iRow, 2) = GridView1.GetRowCellValue(i, "IncomingDate")
            workSheet.Cells(iRow, 3) = GridView1.GetRowCellValue(i, "InspectionDate")
            workSheet.Cells(iRow, 4) = GridView1.GetRowCellValue(i, "JCode")
            workSheet.Cells(iRow, 5) = GridView1.GetRowCellValue(i, "JName")
            workSheet.Cells(iRow, 6) = GridView1.GetRowCellValue(i, "CartonQuantity")
            workSheet.Cells(iRow, 7) = GridView1.GetRowCellValue(i, "Unit")
            workSheet.Cells(iRow, 8) = GridView1.GetRowCellValue(i, "QuantityOfCarton")
            workSheet.Cells(iRow, 9) = GridView1.GetRowCellValue(i, "MaterialLotNo")
            workSheet.Cells(iRow, 10) = GridView1.GetRowCellValue(i, "ExpiryDate")

            No += 1
            iRow += 1
        Next
        If No > 24 Then
            workRange = workSheet.Range(workSheet.Cells(7, 1), workSheet.Cells(iRow - 1, 19))
            workRange.Borders.LineStyle = 1
        End If
        ''Delete dòng thừa
        If No < 24 Then
            workRange = workSheet.Range(workSheet.Cells(iRow, 1), workSheet.Cells(30, 19))
            workRange.Delete()
        End If
        'workRange = workSheet.Range(workSheet.Cells(7, 1), workSheet.Cells(No + 5, 19))
        ''workRange.Rows.AutoFit()
        'workRange.Rows.RowHeight = 27

        'workRange = workSheet.Range(workSheet.Cells(No + 6, 1), workSheet.Cells(No + 9, 19))
        'workRange.Rows.RowHeight = 20

        'workBook.Save()
        'workBook.Close()
        'app.Quit()
        MessageBox.Show("Export successfully!", "Export Excel")
        app.Visible = True
        app.Workbooks.Open(FileExp + "Tray.xlsx")

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
    End Sub

    Sub ExportChemical()
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        'Copy template
        UpLoadFile(FileTmp + "MaterialAndChemical.xlsx", FileExp + "MaterialAndChemical.xlsx", True)
        'Variance
        Dim app As New Excel.Application
        Dim workBook As Excel.Workbook
        Dim workSheet As Excel.Worksheet
        Dim workRange As Excel.Range

        'Open file
        If (File.Exists(FileExp + "MaterialAndChemical.xlsx")) Then
            workBook = app.Workbooks.Open(FileExp + "MaterialAndChemical.xlsx", Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing)
        Else
            workBook = app.Workbooks.Add(Type.Missing)
        End If

        workSheet = CType(workBook.Sheets(1), Excel.Worksheet)
        workSheet.Name = "QC-F-037"
        app.Visible = False


        'bnChemical.BindingSource.Sort = " Kho asc,IncomingDate asc "

        'Dim distinctGV() As String = (From row As DataGridViewRow In gridChemical.Rows.Cast(Of DataGridViewRow)()
        '                              Order By row.Cells("Kho").Value Ascending
        '                              Select CStr(row.Cells("Kho").Value)).Distinct.ToArray

        'For i As Integer = 0 To distinctGV.Count - 1
        '    Dim countWorkSheet As Integer = workBook.Worksheets.Count
        '    'Dim newWorksheet As Excel.Worksheet = DirectCast(workBook.Worksheets.Add(Missing.Value, workBook.Sheets(countWorkSheet), 1, Missing.Value), Excel.Worksheet)
        '    Dim newWorksheet As Excel.Worksheet = DirectCast(workBook.Sheets(countWorkSheet), Excel.Worksheet)

        '    newWorksheet.Name = distinctGV(i)
        '    If i < (distinctGV.Count - 1) Then
        '        workSheet.Copy(Missing.Value, newWorksheet)
        '    End If
        'Next

        Dim myrow As Integer = 0
        'For k As Integer = 0 To distinctGV.Count - 1
        'workSheet = CType(workBook.Sheets(k + 1), Excel.Worksheet)
        Dim iRow As Integer = 7
        Dim No As Integer = 1
        Dim SetData As Boolean = False
        For i As Integer = myrow To GridView1.RowCount - 1
            'If workSheet.Name <> GridView1.GetRowCellValue(i, "Kho") Then
            '    myrow = i
            '    Exit For
            'End If

            workSheet.Cells(2, 18) = GridView1.GetRowCellValue(i, "IncomingDate")
            If No > 20 Then
                workRange = workSheet.Range(workSheet.Cells(iRow, 1), workSheet.Cells(iRow, 21))
                workRange.Rows.RowHeight = 24.75
                workRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
            End If

            workSheet.Cells(iRow, 1) = No
            workSheet.Cells(iRow, 2) = GridView1.GetRowCellValue(i, "InspectionDate")
            workSheet.Cells(iRow, 3) = GridView1.GetRowCellValue(i, "JCode")
            workSheet.Cells(iRow, 4) = GridView1.GetRowCellValue(i, "JName")
            workSheet.Cells(iRow, 5) = GridView1.GetRowCellValue(i, "CartonQuantity")
            workSheet.Cells(iRow, 6) = GridView1.GetRowCellValue(i, "Unit")
            workSheet.Cells(iRow, 7) = GridView1.GetRowCellValue(i, "QuantityOfCarton")
            workSheet.Cells(iRow, 8) = GridView1.GetRowCellValue(i, "MaterialLotNo")
            workSheet.Cells(iRow, 9) = GridView1.GetRowCellValue(i, "ExpiryDate")
            'KQCV
            'workSheet.Cells(iRow, 17) = ":"
            'workSheet.Cells(iRow, 18) = ":"
            No += 1
            iRow += 1
            SetData = True
        Next
        'workSheet.Cells(iRow, 1) = "Ghi chú (Note):"
        'workSheet.Cells(iRow, 3).Value = " 'O' : ĐẠT (OK) "
        'workSheet.Cells(iRow, 5).Value = "'X' : KHÔNG ĐẠT (NG)"

        'workSheet.Cells(iRow + 2, 1).Value = "REV: 00 (17/09/2015)"

        'workSheet.Cells(iRow + 1, 10).Value = "Người có trách nhiệm phải kiểm tra xác nhận mỗi ngày (Superior must be confirm everyday)"
        'workSheet.Cells(iRow + 1, 3).Value = "' - ' : Không kiểm hoặc không có thông tin (No inspection or no inform)"

        'workSheet.Cells(iRow + 2, 20).Value = "QC-F-037"

        If No > 20 Then
            workRange = workSheet.Range(workSheet.Cells(7, 1), workSheet.Cells(iRow - 1, 19))
            workRange.Borders.LineStyle = 1
        End If
        If No < 20 Then
            workRange = workSheet.Range(workSheet.Cells(iRow, 1), workSheet.Cells(26, 19))
            workRange.Delete()
        End If
        'Next
        'workBook.Save()
        'workBook.Close()
        'app.Quit()
        app.Visible = True
        app.Workbooks.Open(FileExp + "MaterialAndChemical.xlsx")

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
    End Sub

    Private Sub btnPrintChemical_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrintChemical.ItemClick
        If GridView1.RowCount = 0 Then
            Return
        End If
        Dim frm = New FrmReportNet
        frm.rptViewer.LocalReport.DataSources.Clear()
        frm.rptViewer.LocalReport.ReportPath = Application.StartupPath + "\Reports\QC\rptChemicalDetail.rdlc"
        frm.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("ChemicalDetail", GridControl1.DataSource))
        frm.rptViewer.SetDisplayMode(DisplayMode.PrintLayout)
        frm.rptViewer.ZoomMode = ZoomMode.PageWidth
        frm.rptViewer.RefreshReport()
        frm.Show()
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)

            If GridView1.FocusedColumn.FieldName = "DeliveryTime" Or
                GridView1.FocusedColumn.FieldName = "Packing" Or
                GridView1.FocusedColumn.FieldName = "TestReport" Or
                GridView1.FocusedColumn.FieldName = "GeneralEvaluation" Or
                GridView1.FocusedColumn.FieldName = "Remark" Then
                Dim objEditChemical As String = String.Format("Update EMM_ChemicalDetail set {0} = @Value where Code = '{1}'",
                                                              e.Column.FieldName, GridView1.GetFocusedRowCellValue("Code"))
                _db.ExecuteNonQuery(objEditChemical, para)
                'ElseIf GridView1.FocusedColumn.FieldName = "Unit" Then
                '    Dim objEditMasterJCode As String = String.Format("Update EMM_MasterJCode set UnitCarton = @Value where JCode = '{0}'",
                '                                                     GridView1.GetFocusedRowCellValue("JCode"))
                '    _db.ExecuteNonQuery(objEditMasterJCode, para)
            Else
                Dim objEditDLVR As String = String.Format("Update EMM_DLVRList set {0} = @Value where Code = '{1}'",
                                                          e.Column.FieldName, GridView1.GetFocusedRowCellValue("Code"))
                _db.ExecuteNonQuery(objEditDLVR, para)
            End If
        End If
    End Sub

    Private Sub ceIsTray_CheckedChanged(sender As Object, e As EventArgs) Handles ceIsTray.CheckedChanged
        If GridControl1.DataSource IsNot Nothing Then
            If ceIsTray.Checked Then
                GridView1.Columns("JName").FilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo("JName like '%FPC TRAY%' ")
            Else
                GridView1.Columns("JName").FilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo("JName not like '%FPC TRAY%'")
            End If
        End If
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
End Class