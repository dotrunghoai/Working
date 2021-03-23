Imports System.Windows.Forms
Imports CommonDB
Imports PublicUtility

Public Class FrmGroupOfUserSiteStock

#Region "Variable"
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Public _uID As String = ""
#End Region

#Region "User function"
    Sub LoadAll()
        Dim sql As String = String.Format("select g.GroupCode,g.GroupName, " +
                                          "  cast(iif( u.GroupCode is null,0,1) as bit) as 'Check'" +
                                          "  ,u.CreateUser,u.CreateDate " +
                                          "  from Sst_Group AS g " +
                                          "  left join Sst_GroupOfUser AS u " +
                                          "  on g.groupCode=u.groupCode " +
                                          " and u.UserCode='{0}' ",
                                          _uID)
        GridControl1.DataSource = _db.FillDataTable(sql)
        GridControlSetFormat(GridView1, 3)
    End Sub
#End Region

#Region "Form function"

    Private Sub FrmGroupOfUser_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        LoadAll()
    End Sub

    Private Sub mnuCheckall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheckall.Click
        For row As Integer = 0 To GridView1.RowCount - 1
            GridView1.SetRowCellValue(row, "Check", True)
            Dim obj As New Sst_GroupOfUser
            obj.CreateDate = DateTime.Now
            obj.CreateUser = CurrentUser.UserID
            obj.GroupCode_K = GridView1.GetRowCellValue(row, "GroupCode")
            obj.UserCode_K = _uID
            If Not _db.ExistObject(obj) Then
                _db.Insert(obj)
            End If
        Next
    End Sub

    Private Sub mnuUncheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUncheck.Click
        For row As Integer = 0 To GridView1.RowCount - 1
            GridView1.SetRowCellValue(row, "Check", False)
            Dim obj As New Sst_GroupOfUser
            obj.GroupCode_K = GridView1.GetRowCellValue(row, "GroupCode")
            obj.UserCode_K = _uID
            _db.Delete(obj)
        Next
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridView1.RowCellClick
        If e.Column.FieldName = "Check" Then
            If GridView1.GetFocusedRowCellValue("Check") IsNot DBNull.Value Then
                If GridView1.GetFocusedRowCellValue("Check") Then
                    GridView1.SetFocusedRowCellValue("Check", False)
                Else
                    GridView1.SetFocusedRowCellValue("Check", True)
                End If
            Else
                GridView1.SetFocusedRowCellValue("Check", True)
            End If

            Dim cko As Boolean = GridView1.GetFocusedRowCellValue("Check")
            Dim obj As New Sst_GroupOfUser
            obj.CreateDate = DateTime.Now
            obj.CreateUser = CurrentUser.UserID
            obj.GroupCode_K = GridView1.GetFocusedRowCellValue("GroupCode")
            obj.UserCode_K = _uID
            If cko Then
                If Not _db.ExistObject(obj) Then
                    _db.Insert(obj)
                End If
            Else
                _db.Delete(obj)
            End If

        End If
    End Sub

    Private Sub FrmGroupOfUser_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub


#End Region

End Class