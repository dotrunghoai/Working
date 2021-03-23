﻿Imports CommonDB
Imports PublicUtility
Public Class FrmListStandardTGGC
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmListStandardKQCV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New Main_UserRight
        obj.FormID_K = Tag
        obj.UserID_K = CurrentUser.UserID
        _db.GetObject(obj)
        If obj.IsEdit = False Then
            ViewAccess()
        End If
        dteStartDate.EditValue = GetStartDayOfMonth(Date.Now)
        dteEndDate.EditValue = GetEndDayOfMonth(Date.Now)
        btnShow.PerformClick()
    End Sub
    Sub ViewAccess()
        btnNew.Enabled = False
        btnDelete.Enabled = False
    End Sub
    Private Sub dteStartDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteStartDate.EditValueChanged
        If dteStartDate.EditValue > dteEndDate.EditValue Then
            dteEndDate.EditValue = dteStartDate.EditValue
        End If
    End Sub
    Private Sub dteEndDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteEndDate.EditValueChanged
        If dteEndDate.EditValue < dteStartDate.EditValue Then
            dteStartDate.EditValue = dteEndDate.EditValue
        End If
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", dteStartDate.EditValue)
        para(1) = New SqlClient.SqlParameter("@EndDate", dteEndDate.EditValue)
        para(2) = New SqlClient.SqlParameter("@Type", "Progress")
        If chbFinish.Checked Then
            para(2) = New SqlClient.SqlParameter("@Type", DBNull.Value)
        End If
        GridControl1.DataSource = _db.FillDataTable("IF @Type = 'Progress'
                                                        SELECT *
                                                        FROM PP_StandardTGGC
                                                        WHERE CurrentMail <> ''
                                                     ELSE 
                                                        SELECT *
                                                        FROM PP_StandardTGGC
                                                        WHERE ApprovedDate <> ''
                                                        AND ReportDate BETWEEN @StartDate AND @EndDate", para)
        GridControlSetFormat(GridView1)
        GridView1.Columns("AttachFileServer").Visible = False
    End Sub

    Private Sub btnConfirm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnConfirm.ItemClick
        Dim frm As New FrmStandardTGGC
        frm._id = GridView1.GetFocusedRowCellValue("ID")
        frm.Show()
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        Dim frm As New FrmStandardTGGC
        frm.Show()
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        btnConfirm.PerformClick()
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            Dim obj As New PP_StandardTGGC
            obj.ID_K = GridView1.GetFocusedRowCellValue("ID")
            _db.Delete(obj)
            GridView1.DeleteSelectedRows()
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub
End Class