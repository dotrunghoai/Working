Imports CommonDB
'Imports LibEntity

Public Class FrmBPCoreSupplier

    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub mnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click

        Dim startDate As DateTime = GetStartDayOfYear(dtpYear.DateTime)
        Dim para(12) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@YYMM1", startDate.ToString("yyyyMM"))
        para(1) = New SqlClient.SqlParameter("@YYMM2", startDate.AddMonths(1).ToString("yyyyMM"))
        para(2) = New SqlClient.SqlParameter("@YYMM3", startDate.AddMonths(2).ToString("yyyyMM"))
        para(3) = New SqlClient.SqlParameter("@YYMM4", startDate.AddMonths(3).ToString("yyyyMM"))
        para(4) = New SqlClient.SqlParameter("@YYMM5", startDate.AddMonths(4).ToString("yyyyMM"))
        para(5) = New SqlClient.SqlParameter("@YYMM6", startDate.AddMonths(5).ToString("yyyyMM"))
        para(6) = New SqlClient.SqlParameter("@YYMM7", startDate.AddMonths(6).ToString("yyyyMM"))
        para(7) = New SqlClient.SqlParameter("@YYMM8", startDate.AddMonths(7).ToString("yyyyMM"))
        para(8) = New SqlClient.SqlParameter("@YYMM9", startDate.AddMonths(8).ToString("yyyyMM"))
        para(9) = New SqlClient.SqlParameter("@YYMM10", startDate.AddMonths(9).ToString("yyyyMM"))
        para(10) = New SqlClient.SqlParameter("@YYMM11", startDate.AddMonths(10).ToString("yyyyMM"))
        para(11) = New SqlClient.SqlParameter("@YYMM12", startDate.AddMonths(11).ToString("yyyyMM"))
        para(12) = New SqlClient.SqlParameter("@Type", "Year")

        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_EMM_LoadBPCoreSupplier", para)
        GridControlSetFormat(BandedGridView1, 2)
        GridControlSetColorReadonly(BandedGridView1)

        GridControlSetWidth(BandedGridView1, 50)
        BandedGridView1.Columns("Supplier").Width = 100
        BandedGridView1.Columns("Maker").Width = 100

        BandedGridView1.Columns("APRMinor").Tag = startDate.ToString("yyyyMM")
        BandedGridView1.Columns("MAYMinor").Tag = startDate.AddMonths(1).ToString("yyyyMM")
        BandedGridView1.Columns("JUNMinor").Tag = startDate.AddMonths(2).ToString("yyyyMM")
        BandedGridView1.Columns("JULMinor").Tag = startDate.AddMonths(3).ToString("yyyyMM")
        BandedGridView1.Columns("AUGMinor").Tag = startDate.AddMonths(4).ToString("yyyyMM")
        BandedGridView1.Columns("SEPMinor").Tag = startDate.AddMonths(5).ToString("yyyyMM")
        BandedGridView1.Columns("OCTMinor").Tag = startDate.AddMonths(6).ToString("yyyyMM")
        BandedGridView1.Columns("NOVMinor").Tag = startDate.AddMonths(7).ToString("yyyyMM")
        BandedGridView1.Columns("DECMinor").Tag = startDate.AddMonths(8).ToString("yyyyMM")
        BandedGridView1.Columns("JANMinor").Tag = startDate.AddMonths(9).ToString("yyyyMM")
        BandedGridView1.Columns("FEBMinor").Tag = startDate.AddMonths(10).ToString("yyyyMM")
        BandedGridView1.Columns("MARMinor").Tag = startDate.AddMonths(11).ToString("yyyyMM")
    End Sub

    Private Sub mnuExport_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
        GridControlExportExcel(BandedGridView1)
    End Sub

    Private Sub mnuEdit_Click(sender As Object, e As EventArgs) Handles mnuEdit.Click
        GridControlReadOnly(BandedGridView1, True)
        BandedGridView1.Columns("APRMinor").OptionsColumn.ReadOnly = False
        BandedGridView1.Columns("MAYMinor").OptionsColumn.ReadOnly = False
        BandedGridView1.Columns("JUNMinor").OptionsColumn.ReadOnly = False
        BandedGridView1.Columns("JULMinor").OptionsColumn.ReadOnly = False
        BandedGridView1.Columns("AUGMinor").OptionsColumn.ReadOnly = False
        BandedGridView1.Columns("SEPMinor").OptionsColumn.ReadOnly = False
        BandedGridView1.Columns("OCTMinor").OptionsColumn.ReadOnly = False
        BandedGridView1.Columns("NOVMinor").OptionsColumn.ReadOnly = False
        BandedGridView1.Columns("DECMinor").OptionsColumn.ReadOnly = False
        BandedGridView1.Columns("JANMinor").OptionsColumn.ReadOnly = False
        BandedGridView1.Columns("FEBMinor").OptionsColumn.ReadOnly = False
        BandedGridView1.Columns("MARMinor").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(BandedGridView1)
    End Sub

    Private Sub mnuCalcPoint_Click(sender As Object, e As EventArgs) Handles mnuCalcPoint.Click
        Dim startDate As DateTime = dtpMonth.DateTime
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@YYMM1", startDate.ToString("yyyyMM"))
        para(1) = New SqlClient.SqlParameter("@Type", "Month")

        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_EMM_LoadBPCoreSupplier", para)
        ShowSuccess()
        mnuShowAll.PerformClick()
    End Sub

    Private Sub FrmBPCoreSupplier_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        dtpYear.DateTime = GetStartDayOfYear(Date.Now)
        dtpMonth.DateTime = Date.Now
    End Sub

    Private Sub BandedGridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BandedGridView1.CellValueChanged
        If e.Column.ReadOnly = False And BandedGridView1.Editable Then
            Dim obj As New EMM_BPCore_Supplier
            obj.Supplier_K = BandedGridView1.GetFocusedRowCellValue("Supplier")
            Dim mMonth As String = Microsoft.VisualBasic.Left(e.Column.FieldName, 3)
            If mMonth = "APR" Then
                obj.YYMM_K = dtpYear.DateTime.Year & "04"
            ElseIf mMonth = "MAY" Then
                obj.YYMM_K = dtpYear.DateTime.Year & "05"
            ElseIf mMonth = "JUN" Then
                obj.YYMM_K = dtpYear.DateTime.Year & "06"
            ElseIf mMonth = "JUL" Then
                obj.YYMM_K = dtpYear.DateTime.Year & "07"
            ElseIf mMonth = "AUG" Then
                obj.YYMM_K = dtpYear.DateTime.Year & "08"
            ElseIf mMonth = "SEP" Then
                obj.YYMM_K = dtpYear.DateTime.Year & "09"
            ElseIf mMonth = "OCT" Then
                obj.YYMM_K = dtpYear.DateTime.Year & "10"
            ElseIf mMonth = "NOV" Then
                obj.YYMM_K = dtpYear.DateTime.Year & "11"
            ElseIf mMonth = "DEC" Then
                obj.YYMM_K = dtpYear.DateTime.Year & "12"
            ElseIf mMonth = "JAN" Then
                obj.YYMM_K = dtpYear.DateTime.Year + 1 & "01"
            ElseIf mMonth = "FEB" Then
                obj.YYMM_K = dtpYear.DateTime.Year + 1 & "02"
            ElseIf mMonth = "MAR" Then
                obj.YYMM_K = dtpYear.DateTime.Year + 1 & "03"
            End If
            _db.GetObject(obj)
            If IsNumeric(e.Value) Then
                obj.MinorPoint = e.Value
            Else
                obj.MinorPoint = 0
            End If
            obj.Total = obj.MinorPoint + obj.PlusPoint
            _db.Update(obj)
        End If
    End Sub
End Class