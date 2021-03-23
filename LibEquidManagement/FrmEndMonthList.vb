Imports CommonDB
Imports PublicUtility
Public Class FrmEndMonthList
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim isEdit As Boolean = True
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

    Private Sub FrmEndMonthList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteStartDate.EditValue = GetStartDayOfMonth(DateTime.Now)
        dteEndDate.EditValue = GetEndDayOfMonth(DateTime.Now)
        btnShow.PerformClick()
        Dim obj As New Main_UserRight
        obj.FormID_K = Tag
        obj.UserID_K = CurrentUser.UserID
        _db.GetObject(obj)
        If obj.IsEdit = False Then
            isEdit = False
            ViewAccess()
        End If
    End Sub
    Sub ViewAccess()
        btnDelete.Enabled = False
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridView1.Columns.Clear()
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dteStartDate.DateTime))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dteEndDate.DateTime))
        If isEdit Then
            If rdoFinish.Checked Then
                GridControl1.DataSource = _db.FillDataTable("select * into #TempTable from QAE_EndMonth where DateCheckedQA <> '' and NgayKiemTra between @StartDate and @EndDate 
                                                        alter table #TempTable drop column Flag, FlagSave, CreateUser, CreateDate 
                                                        select * from #TempTable 
                                                        drop table #TempTable", para)
            Else
                GridControl1.DataSource = _db.FillDataTable("select * into #TempTable from QAE_EndMonth where CurrentID <> '' 
                                                        alter table #TempTable drop column Flag, FlagSave, CreateUser, CreateDate 
                                                        select * from #TempTable 
                                                        drop table #TempTable", para)
            End If
            GridControlSetFormat(GridView1)
        Else
            GridControl1.DataSource = _db.FillDataTable(String.Format("select * into #TempTable from QAE_EndMonth where CurrentID = '{0}' 
                                                        alter table #TempTable drop column Flag, FlagSave, CreateUser, CreateDate 
                                                        select * from #TempTable 
                                                        drop table #TempTable", CurrentUser.Mail))
            GridControlSetFormat(GridView1)
        End If
    End Sub

    Private Sub btnConfirm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnConfirm.ItemClick
        Dim frm As New FrmEndMonthRequest
        frm._myID = GridView1.GetFocusedRowCellValue("ID")
        frm.Show()
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        Dim frm As New FrmEndMonthRequest
        frm.Show()
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu ?") = DialogResult.Yes Then
            _db.ExecuteNonQuery(String.Format("delete QAE_EndMonth where ID = '{0}'", GridView1.GetFocusedRowCellValue("ID")))
            _db.ExecuteNonQuery(String.Format("delete QAE_EndMonthDetail where ID = '{0}'", GridView1.GetFocusedRowCellValue("ID")))
            GridView1.DeleteSelectedRows()
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        btnConfirm.PerformClick()
    End Sub
End Class