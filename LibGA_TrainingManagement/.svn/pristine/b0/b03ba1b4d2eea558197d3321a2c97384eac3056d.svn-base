Imports CommonDB
Imports PublicUtility
Public Class FrmRegisterList
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmRegisterList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        btnDelete.Enabled = False
        btnNew.Enabled = False
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(3) As SqlClient.SqlParameter
        If rdoUnfinished.Checked Then
            para(0) = New SqlClient.SqlParameter("@Type", rdoUnfinished.Text)
        ElseIf rdoReverse.Checked Then
            para(0) = New SqlClient.SqlParameter("@Type", rdoReverse.Text)
        Else
            para(0) = New SqlClient.SqlParameter("@Type", DBNull.Value)
        End If
        para(1) = New SqlClient.SqlParameter("@StartDate", dteStartDate.DateTime.Date)
        para(2) = New SqlClient.SqlParameter("@EndDate", dteEndDate.DateTime.Date)
        If rdoYearly.Checked Then
            para(3) = New SqlClient.SqlParameter("@TypeTraining", "Yearly")
        Else
            para(3) = New SqlClient.SqlParameter("@TypeTraining", "NewComer")
        End If
        Dim dtShow = _db.FillDataTable("IF @TypeTraining = 'Yearly'
                                            IF @Type = 'Unfinished'
		                                        SELECT *
		                                        FROM GA_TRM_RegisterPlanned
		                                        WHERE CurrentMail <> ''
                                            ELSE IF @Type = 'Reverse'
                                                SELECT *
		                                        FROM GA_TRM_RegisterPlanned
		                                        WHERE CurrentMail = ''
                                                AND Method = 'Reverse'
	                                        ELSE
		                                        SELECT *
		                                        FROM GA_TRM_RegisterPlanned
		                                        WHERE DateApproveKQ IS NOT NULL
		                                        AND DateSave BETWEEN @StartDate AND @EndDate
                                        ELSE
                                            IF @Type = 'Unfinished'
		                                        SELECT *
		                                        FROM GA_TRM_RegisterPlannedNewComer
		                                        WHERE CurrentMail <> ''
	                                        ELSE
		                                        SELECT *
		                                        FROM GA_TRM_RegisterPlannedNewComer
		                                        WHERE DateApproveKQ IS NOT NULL
		                                        AND DateSave BETWEEN @StartDate AND @EndDate", para)
        GridControl1.DataSource = dtShow
        GridControlSetFormat(GridView1, 2)
    End Sub

    Private Sub btnDetail_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDetail.ItemClick
        If GridView1.GetFocusedRowCellValue("ID") IsNot Nothing Then
            If rdoYearly.Checked Then
                Dim frm As New FrmRegisterPlannedYearly
                frm._id = GridView1.GetFocusedRowCellValue("ID")
                frm.Show()
            Else
                Dim frm As New FrmRegisterPlannedForNewComers
                frm._id = GridView1.GetFocusedRowCellValue("ID")
                frm.Show()
            End If
        End If
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            If rdoYearly.Checked Then
                Dim obj As New GA_TRM_RegisterPlanned
                obj.ID_K = GridView1.GetFocusedRowCellValue("ID")
                _db.Delete(obj)
            Else
                Dim obj As New GA_TRM_RegisterPlannedNewComer
                obj.ID_K = GridView1.GetFocusedRowCellValue("ID")
                _db.Delete(obj)
            End If
            GridView1.DeleteSelectedRows()
        End If
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        If rdoYearly.Checked Then
            Dim frm As New FrmRegisterPlannedYearly
            frm.Show()
        Else
            Dim frm As New FrmRegisterPlannedForNewComers
            frm.Show()
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        btnDetail.PerformClick()
    End Sub

    Private Sub dteStartDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteStartDate.EditValueChanged
        If dteStartDate.DateTime > dteEndDate.DateTime Then
            dteEndDate.EditValue = dteStartDate.DateTime
        End If
    End Sub

    Private Sub dteEndDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteEndDate.EditValueChanged
        If dteEndDate.DateTime < dteStartDate.DateTime Then
            dteStartDate.EditValue = dteEndDate.DateTime
        End If
    End Sub

    Private Sub rdoNewComers_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNewComers.CheckedChanged
        If rdoNewComers.Checked Then
            rdoReverse.Enabled = False
        Else
            rdoReverse.Enabled = True
        End If
    End Sub
End Class