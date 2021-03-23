Imports System.Drawing
Imports System.Windows.Forms
Imports CommonDB
Imports DevExpress.XtraGrid.Columns
'Imports LibEntity
Imports PublicUtility

Public Class FrmBPCoreItem
    ReadOnly _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    ReadOnly dbAS As New DBFunction(PublicConst.EnumServers.NDV_DB2_AS400)

    Private Sub FrmBPCoreItem_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        dtpYear.DateTime = GetStartDayOfYear(Date.Now)
        dtpMonth.DateTime = Date.Now
    End Sub

    Private Sub mnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
        Dim startDate As DateTime = GetStartDayOfYear(dtpYear.DateTime)
        Dim para(11) As SqlClient.SqlParameter
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

        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_EMM_LoadBPCoreItem", para)
        GridControlSetFormat(GridView1, 2)
        GridControlSetColorReadonly(GridView1)

        GridView1.Columns("APR").Tag = startDate.ToString("yyyyMM")
        GridView1.Columns("MAY").Tag = startDate.AddMonths(1).ToString("yyyyMM")
        GridView1.Columns("JUN").Tag = startDate.AddMonths(2).ToString("yyyyMM")
        GridView1.Columns("JUL").Tag = startDate.AddMonths(3).ToString("yyyyMM")
        GridView1.Columns("AUG").Tag = startDate.AddMonths(4).ToString("yyyyMM")
        GridView1.Columns("SEP").Tag = startDate.AddMonths(5).ToString("yyyyMM")
        GridView1.Columns("OCT").Tag = startDate.AddMonths(6).ToString("yyyyMM")
        GridView1.Columns("NOV").Tag = startDate.AddMonths(7).ToString("yyyyMM")
        GridView1.Columns("DEC").Tag = startDate.AddMonths(8).ToString("yyyyMM")
        GridView1.Columns("JAN").Tag = startDate.AddMonths(9).ToString("yyyyMM")
        GridView1.Columns("FEB").Tag = startDate.AddMonths(10).ToString("yyyyMM")
        GridView1.Columns("MAR").Tag = startDate.AddMonths(11).ToString("yyyyMM")
    End Sub

    Private Sub mnuExport_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub mnuGetAS400_Click(sender As Object, e As EventArgs) Handles mnuGetAS400.Click
        Dim StartDate As DateTime = GetStartDayOfMonth(dtpMonth.DateTime)
        Dim EndDate As DateTime = GetEndDayOfMonth(dtpMonth.DateTime)

        Dim strStartDate As String = StartDate.ToString("yyyyMMdd")
        Dim strEndDate As String = EndDate.ToString("yyyyMMdd")

        Dim strDate As String
        strDate = "and F.TPPUDT >= '" + strStartDate + "' " +
                  "And F.TPPUDT <= '" + strEndDate + "' "

        Dim sql As String = String.Format(" Select distinct  TEITCD JCODE,left(F.TPPUDT,6) as YYMM" +
                                        " from NDVDTA.MTDPOHP A " +
                                        " left join NDVDTA.MTEPOLP B on A.TDPONB=B.TEPONB " +
                                        " left join NDVDTA.MTPTRNP F on A.TDPONB=F.TPPONB " +
                                        " where A.TDCNDT = 0 and TPTRTY Like '110' " + strDate)

        Dim dtAS = dbAS.FillDataTable(sql)
        For Each r As DataRow In dtAS.Rows
            Dim obj As New EMM_BPCore_DanhGia
            obj.ItemCode_K = r.Item("JCODE")
            obj.YYMM_K = r.Item("YYMM")
            obj.DanhGia = "O"
            If Not _db.ExistObject(obj) Then
                _db.Insert(obj)
            End If
        Next
        ShowSuccess()
        mnuShowAll.PerformClick()
    End Sub

    Private Sub mnuEdit_Click(sender As Object, e As EventArgs) Handles mnuEdit.Click
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("APR").OptionsColumn.ReadOnly = False
        GridView1.Columns("MAY").OptionsColumn.ReadOnly = False
        GridView1.Columns("JUN").OptionsColumn.ReadOnly = False
        GridView1.Columns("JUL").OptionsColumn.ReadOnly = False
        GridView1.Columns("AUG").OptionsColumn.ReadOnly = False
        GridView1.Columns("SEP").OptionsColumn.ReadOnly = False
        GridView1.Columns("OCT").OptionsColumn.ReadOnly = False
        GridView1.Columns("NOV").OptionsColumn.ReadOnly = False
        GridView1.Columns("DEC").OptionsColumn.ReadOnly = False
        GridView1.Columns("JAN").OptionsColumn.ReadOnly = False
        GridView1.Columns("FEB").OptionsColumn.ReadOnly = False
        GridView1.Columns("MAR").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.ReadOnly = False And GridView1.Editable Then
            Dim obj As New EMM_BPCore_DanhGia
            obj.ItemCode_K = GridView1.GetFocusedRowCellValue("ItemCode")
            obj.YYMM_K = e.Column.Tag
            If e.Value IsNot DBNull.Value Then
                obj.DanhGia = e.Value
            End If
            obj.PlusPoint = 0
            If obj.DanhGia = "-" Then
                _db.Delete(obj)
            Else
                _db.Update(obj)
            End If
        End If
    End Sub

    Private Sub mnuCalcPoint_Click(sender As Object, e As EventArgs) Handles mnuCalcPoint.Click
        Cursor = Cursors.AppStarting
        For r As Integer = 0 To GridView1.RowCount - 1
            Dim mCount As Integer = 0
            For Each c As GridColumn In GridView1.Columns
                If IsNumeric(c.Tag) Then
                    If GridView1.GetRowCellValue(r, c) = "O" Or
                        GridView1.GetRowCellValue(r, c) = "10" Then
                        mCount += 1
                    Else
                        mCount = 0
                    End If
                    If mCount = 3 Then
                        Dim obj As New EMM_BPCore_DanhGia
                        obj.ItemCode_K = GridView1.GetRowCellValue(r, "ItemCode")
                        obj.YYMM_K = c.Tag
                        obj.DanhGia = "O"
                        obj.PlusPoint = 10
                        _db.Update(obj)
                        mCount = 0
                    Else
                        Dim obj As New EMM_BPCore_DanhGia
                        obj.ItemCode_K = GridView1.GetRowCellValue(r, "ItemCode")
                        obj.YYMM_K = c.Tag
                        obj.DanhGia = GridView1.GetRowCellValue(r, c)
                        If obj.DanhGia = "10" Then
                            obj.DanhGia = "O"
                        End If
                        obj.PlusPoint = 0
                        _db.Update(obj)
                    End If
                End If
            Next
        Next
        mnuShowAll.PerformClick()
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If IsNumeric(e.Column.Tag) Then
            If e.CellValue = "10" Then
                e.Appearance.BackColor = Color.YellowGreen
            ElseIf e.CellValue = "X" Then
                e.Appearance.BackColor = Color.Yellow
            End If
        End If
    End Sub
End Class