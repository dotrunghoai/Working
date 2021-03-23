Imports System.Windows.Forms
Imports CommonDB
Imports PublicUtility

Public Class FrmGroupOfUser

#Region "Variable"
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Public _uID As String = ""
#End Region

#Region "User function"
    Sub LoadAll()
        Dim sql As String = String.Format("select g.FactoryCode as FactoryID,g.GroupID,g.GroupName, " +
                                          " cast( iif( u.GroupID is null , 0 , 1) as bit) as 'Check' " +
                                          "  ,u.CreateUser,u.CreateDate " +
                                          "   from WT_Group AS g " +
                                          "  left join (select * from WT_GroupOfUser where UserID='{0}' )u " +
                                          "  on g.groupID=u.GroupID " +
                                          " where  g.Active=1 " +
                                          " order by g.FactoryCode  ",
                                          _uID)

        GridControl1.DataSource = _db.FillDataTable(sql)
        GridControlSetFormat(GridView1, 2)
    End Sub
#End Region

#Region "Form function"

    Private Sub FrmGroupOfUser_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown

        LoadAll()
    End Sub

    Private Sub mnuCheckall_Click(sender As System.Object, e As System.EventArgs) Handles mnuCheckall.Click
        For row As Integer = 0 To GridView1.RowCount - 1
            GridView1.SetRowCellValue(row, "Check", True)
            Dim obj As New WT_GroupOfUser
            obj.CreateDate = DateTime.Now
            obj.CreateUser = CurrentUser.UserID
            obj.GroupID_K = GridView1.GetRowCellValue(row, "GroupID")
            obj.UserID_K = _uID
            If Not _db.ExistObject(obj) Then
                _db.Insert(obj)
            End If
        Next
    End Sub

    Private Sub mnuUncheck_Click(sender As System.Object, e As System.EventArgs) Handles mnuUncheck.Click
        For row As Integer = 0 To GridView1.RowCount - 1
            GridView1.SetRowCellValue(row, "Check", False)
            Dim obj As New WT_GroupOfUser
            obj.GroupID_K = GridView1.GetRowCellValue(row, "GroupID")
            obj.UserID_K = _uID
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
            Dim obj As New WT_GroupOfUser
            obj.CreateDate = DateTime.Now
            obj.CreateUser = CurrentUser.UserID
            obj.GroupID_K = GridView1.GetFocusedRowCellValue("GroupID")
            obj.UserID_K = _uID
            If cko Then
                If Not _db.ExistObject(obj) Then
                    _db.Insert(obj)
                End If
            Else
                _db.Delete(obj)
            End If
        End If
    End Sub

    Private Sub FrmGroupOfUser_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub


#End Region

End Class