Imports CommonDB
Imports DevExpress.XtraGrid.Views.Grid
Imports PublicUtility
Public Class FrmEmployeeMaster
    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub mnuShowAll_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuShowAll.ItemClick
        GridView1.Columns.Clear()
        Dim para(0) As SqlClient.SqlParameter
        If chbNghiViec.Checked Then
            para(0) = New SqlClient.SqlParameter("@Type", "Off")
        Else
            para(0) = New SqlClient.SqlParameter("@Type", DBNull.Value)
        End If
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_GA_CT_Employee", para)
        GridControlSetFormat(GridView1, 1)
        GridView1.Columns("EName").Width = 120
    End Sub

    Private Sub mnuExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuExport.ItemClick
        Dim listGrid As New List(Of GridView)
        listGrid.Add(GridView1)
        If GridControl2.DataSource IsNot Nothing Then
            listGrid.Add(GridView2)
        End If
        GridControlExportExcels(listGrid)
    End Sub

    'Private Sub mnuEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuEdit.ItemClick
    '    GridControlReadOnly(GridView1, True)
    '    GridView1.Columns("LoaiHD").OptionsColumn.ReadOnly = False
    '    GridControlSetColorEdit(GridView1)
    'End Sub

    'Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
    '    If e.Column.ReadOnly = False And GridView1.Editable Then
    '        Dim obj As New GA_CT_Employee
    '        obj.EmpID_K = GridView1.GetFocusedRowCellValue("EmpID")
    '        _db.GetObject(obj)
    '        obj.LoaiHD = GridView1.GetFocusedRowCellValue("LoaiHD")
    '        _db.Update(obj)
    '    End If
    'End Sub

    Private Sub FrmEmployeeMaster_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub

    Private Sub btnReport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnReport.ItemClick
        GridView1.Columns.Clear()
        GridView2.Columns.Clear()
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Type", "ReportSection")
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_GA_CT_Employee", para)
        GridControlSetFormat(GridView1)
        GridView1.Columns("EName").Width = 200
        GridView1.Columns("Section").Width = 150

        para(0) = New SqlClient.SqlParameter("@Type", "Report")
        GridControl2.DataSource = _db.ExecuteStoreProcedureTB("sp_GA_CT_Employee", para)
        GridControlSetFormat(GridView2)
    End Sub

    Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
        Dim dt As DataTable = ImportEXCEL(True)
        If dt.Rows.Count > 0 Then
            Try
                _db.BeginTransaction()
                For Each r As DataRow In dt.Rows
                    If IsDBNull(r("Emp ID")) Then Continue For
                    Dim obj As New GA_CT_Employee
                    obj.EmpID_K = r("Emp ID")
                    _db.GetObject(obj)
                    obj.HDHNStatus = IIf(IsDBNull(r("HDHN Status")), "", r("HDHN Status"))
                    obj.HDTVStatus = IIf(IsDBNull(r("HDTV Status")), "", r("HDTV Status"))
                    obj.HD1YearStatus = IIf(IsDBNull(r("HD1Year Status")), "", r("HD1Year Status"))
                    obj.HD3YearStatus = IIf(IsDBNull(r("HD3Year Status")), "", r("HD3Year Status"))
                    obj.HDVTHStatus = IIf(IsDBNull(r("HDVTH Status")), "", r("HDVTH Status"))
                    If Not IsDBNull(r("Suc Khoe")) Then
                        obj.SucKhoe = r("Suc Khoe")
                    End If
                    If Not IsDBNull(r("Vi Pham NQCT")) Then
                        obj.ViPhamNQCT = r("Vi Pham NQCT")
                    End If
                    _db.Update(obj)
                Next
                _db.Commit()
                ShowSuccess()
            Catch ex As Exception
                _db.RollBack()
                ShowWarning(ex.Message)
            End Try
        Else
            ShowWarning("Không có dữ liệu import !")
        End If
    End Sub
End Class