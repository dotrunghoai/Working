Imports CommonDB
Imports PublicUtility
Public Class FrmFIXData
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmFIXData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteStartDate.EditValue = Date.Now.AddDays(-15)
        dteEndDate.EditValue = Date.Parse(dteStartDate.EditValue).AddMonths(9)
    End Sub
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridView1.Columns.Clear()
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", dteStartDate.EditValue)
        para(1) = New SqlClient.SqlParameter("@EndDate", dteEndDate.EditValue)
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_PLM_LoadFIXData", para)
        GridControlSetFormat(GridView1, 1)
        GridView1.BestFitColumns()
    End Sub

    Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
        Dim dt As DataTable = ImportEXCEL(True)
        If dt.Rows.Count > 0 Then
            Dim err As Integer = 0
            Try
                _db.BeginTransaction()
                Dim tuanIp As String = "W" + Date.Parse(dt.Columns(dt.Columns.IndexOf("Kind") + 1).ColumnName).ToString("yyyyMMdd")
                Dim succ As Integer = 0
                For Each r As DataRow In dt.Rows
                    err += 1
                    If IsDBNull(r("JCode")) Then Continue For
                    Dim obj As New PLM_FIXData
                    obj.TuanImport_K = tuanIp
                    obj.JCode_K = r("JCode")
                    For Each c As DataColumn In dt.Columns
                        If dt.Columns.IndexOf(c.ColumnName) > dt.Columns.IndexOf("Kind") Then
                            If IsDBNull(r(c)) Then Continue For
                            obj.Tuan_K = Date.Parse(c.ColumnName)
                            obj.Qty = r(c)
                            obj.CreateUser = CurrentUser.UserID
                            obj.CreateDate = DateTime.Now
                            If _db.ExistObject(obj) Then
                                _db.Update(obj)
                            Else
                                _db.Insert(obj)
                                succ += 1
                            End If
                        End If
                    Next
                Next
                ShowSuccess(succ)
                _db.Commit()
            Catch ex As Exception
                _db.RollBack()
                ShowWarning(ex.Message + " - Row: " + err.ToString)
            End Try
        Else
            ShowWarning("Không có dữ liệu import !")
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub
End Class