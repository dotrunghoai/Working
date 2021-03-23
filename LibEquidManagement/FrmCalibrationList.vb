﻿Imports CommonDB
'Imports LibEntity

Public Class FrmCalibrationList
    Public _myID As String = ""
    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click
        Dim frm As New FrmCalibrationRequest
        frm.Show()
    End Sub


    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        If ShowQuestionDelete() = DialogResult.Yes Then
            Dim obj As New QAE_Calibration
            obj.ID_K = GridView1.GetFocusedRowCellValue("ID")
            _db.Delete(obj)
            GridView1.DeleteSelectedRows()
        End If
    End Sub

    Private Sub mnuConfirm_Click(sender As Object, e As EventArgs) Handles mnuConfirm.Click
        Dim frm As New FrmCalibrationRequest
        frm._myID = GridView1.GetFocusedRowCellValue("ID")
        frm.Show()
    End Sub

    Private Sub mnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
        Dim sql As String = String.Format("sp_QAE_LoadCalibration")
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", dtpStartDate.Value.Date)
        para(1) = New SqlClient.SqlParameter("@EndDate", dtpEndDate.Value.Date)
        If rdoFinish.Checked Then
            para(2) = New SqlClient.SqlParameter("@Type", rdoFinish.Text)
        Else
            para(2) = New SqlClient.SqlParameter("@Type", rdoProgress.Text)
        End If
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB(sql, para)
        GridControlSetFormat(GridView1, 3)
        GridView1.Columns("Section").Width = 50
        GridView1.Columns("ID").BestFit()
    End Sub

    Private Sub FrmCalibrationList_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        mnuConfirm.PerformClick()
    End Sub
End Class