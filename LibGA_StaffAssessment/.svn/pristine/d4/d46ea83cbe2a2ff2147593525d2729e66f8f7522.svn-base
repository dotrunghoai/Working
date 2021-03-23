Imports CommonDB
Imports PublicUtility
Public Class FrmShowStaffAssessment
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _isEdit As Boolean = True

    Private Sub FrmShowStaffAssessment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteStartDate.EditValue = GetStartDayOfMonth(Date.Now)
        dteEndDate.EditValue = GetEndDayOfMonth(Date.Now)
        Dim dt = _db.FillDataTable("SELECT DISTINCT Section
                                    FROM OT_Employee
                                    ORDER BY Section")
        For Each r As DataRow In dt.Rows
            cbbSection.Items.Add(r("Section"))
        Next
        SectionHead.EditValue = CurrentUser.Section

        Dim obj As New Main_UserRight
        obj.UserID_K = CurrentUser.UserID
        obj.FormID_K = Tag
        _db.GetObject(obj)
        If obj.IsEdit = False Then
            _isEdit = False
            cbbSection.ReadOnly = True
        End If
        btnShow.PerformClick()
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
        GridView1.Columns.Clear()
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", dteStartDate.EditValue)
        para(1) = New SqlClient.SqlParameter("@EndDate", dteEndDate.EditValue)
        If _isEdit = False Then
            para(2) = New SqlClient.SqlParameter("@Section", CurrentUser.Section)
        Else
            para(2) = New SqlClient.SqlParameter("@Section", SectionHead.EditValue)
        End If
        Try
            GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_HRA_SA_ShowStaffAssessment", para)
            If GridView1.RowCount > 0 Then
                GridControlSetFormat(GridView1)
                GridControlSetWidth(GridView1, 85)
                GridView1.Columns("EName").Width = 150
            End If
        Catch ex As Exception
            ShowWarning(ex.Message)
        End Try
    End Sub

End Class