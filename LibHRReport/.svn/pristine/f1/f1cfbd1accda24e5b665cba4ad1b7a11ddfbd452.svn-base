Imports CommonDB
Imports PublicUtility
Public Class FrmViewReport_2
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmViewReport_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteStartDate.EditValue = GetStartDayOfMonth(DateTime.Now)
        dteEndDate.EditValue = GetEndDayOfMonth(DateTime.Now)
        btnShow.PerformClick()
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(2) As SqlClient.SqlParameter
        If rdoProgress.Checked Then
            para(0) = New SqlClient.SqlParameter("@Type", "Progress")
        Else
            para(0) = New SqlClient.SqlParameter("@Type", "Finish")
        End If
        para(1) = New SqlClient.SqlParameter("@StartDate", dteStartDate.DateTime.Date)
        para(2) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dteEndDate.DateTime))
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_HRR_LoadViewReport", para)
        GridControlSetFormat(GridView1)
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        Dim frm As New FrmHRReport_2
        frm.Show()
    End Sub

    Private Sub btnConfirm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnConfirm.ItemClick
        Dim frm As New FrmHRReport_2
        frm._myID = GridView1.GetFocusedRowCellValue("ID")
        frm.Show()
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        btnConfirm.PerformClick()
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu ?") = Windows.Forms.DialogResult.Yes Then
            Dim obj As New HRR_ViewReport
            obj.ID_K = GridView1.GetFocusedRowCellValue("ID")
            _db.GetObject(obj)
            _db.Delete(obj)
            GridView1.DeleteSelectedRows()
        End If
    End Sub
End Class