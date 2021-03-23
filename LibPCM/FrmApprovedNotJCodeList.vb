Imports CommonDB
Imports LibEntity

Public Class FrmApprovedNotJCodeList
    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            Dim obj As New PCM_ApprovedNoJCode
            obj.ID_K = GridView1.GetFocusedRowCellValue("ID")
            _db.Delete(obj)
            GridView1.DeleteSelectedRows()
        End If
    End Sub

    Private Sub mnuConfirm_Click(sender As Object, e As EventArgs) Handles mnuConfirm.Click
        Dim frm As New FrmApprovedNotJCodeDetail
        frm._myID = GridView1.GetFocusedRowCellValue("ID")
        frm.YMD_K = GridView1.GetFocusedRowCellValue("YMD")
        frm.DeptName_K = GridView1.GetFocusedRowCellValue("DeptName")
        frm.Lan_K = GridView1.GetFocusedRowCellValue("Lan")
        frm.Show()
    End Sub

    Private Sub mnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
        Dim sql As String = String.Format("sp_PCM_LoadApprovedNotJCodeList")
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", dtpStartDate.Value.Date)
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dtpEndDate.Value.Date))
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB(sql, para)
        GridControlSetFormat(GridView1, 3)
        GridView1.Columns("YMD").BestFit()
        GridView1.Columns("ID").BestFit()
        GridView1.Columns("Lan").BestFit()
        GridView1.Columns("DeptName").BestFit()
    End Sub

    Private Sub mnuExport_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub FrmApprovedNotJCodeList_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        mnuConfirm.PerformClick()
    End Sub

End Class