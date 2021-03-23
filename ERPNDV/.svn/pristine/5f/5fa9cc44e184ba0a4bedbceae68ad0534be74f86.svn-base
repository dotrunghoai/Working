Imports CommonDB
Imports LibEntity
Imports PublicUtility

Public Class FrmGroupOfUserTrain

#Region "Variable"
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Public _uID As String = ""
    Public _depts As String = ""
#End Region

#Region "User function"
    Sub LoadAll()
        Dim sql As String = String.Format("select g.Dept,g.ProcessCode,g.ProcessName, " +
                                          "  cast(iif( u.ProcessCode is null , 0 , 1) as bit) as [Check] " +
                                          "   from {0} g " +
                                          "  left join {1} u " +
                                          "  on g.ProcessCode=u.ProcessCode " +
                                          " and u.EmpID='{2}' ",
                                          PublicTable.Table_DOC_ProcessList,
                                          "DOC_EmpRight",
                                          _uID)

        GridControl1.DataSource = _db.FillDataTable(sql)
        GridControlSetFormat(GridView1)
        GridView1.FindFilterText = _depts
    End Sub
#End Region

#Region "Form function"

    Private Sub FrmGroupOfUser_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        LoadAll()
    End Sub

    Private Sub mnuCheckall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheckall.Click
        For row As Integer = 0 To GridView1.RowCount - 1
            GridView1.SetRowCellValue(row, "Check", True)
            Dim obj As New DOC_EmpRight
            obj.ProcessCode_K = GridView1.GetRowCellValue(row, "ProcessCode")
            obj.EmpID_K = _uID
            If Not _db.ExistObject(obj) Then
                _db.Insert(obj)
            End If

        Next
    End Sub

    Private Sub mnuUncheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUncheck.Click
        For row As Integer = 0 To GridView1.RowCount - 1
            GridView1.SetRowCellValue(row, "Check", False)
            Dim obj As New DOC_EmpRight
            obj.ProcessCode_K = GridView1.GetRowCellValue(row, "ProcessCode")
            obj.EmpID_K = _uID
            _db.Delete(obj)

        Next
    End Sub

    Private Sub FrmGroupOfUser_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub


#End Region

    Private Sub ckoAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckoAll.CheckedChanged

        If ckoAll.Checked Then
            GridView1.FindFilterText = ""
        Else
            GridView1.FindFilterText = _depts
        End If
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
                Dim obj As New DOC_EmpRight
                obj.ProcessCode_K = GridView1.GetFocusedRowCellValue("ProcessCode")
                obj.EmpID_K = _uID
                If cko Then
                    If Not _db.ExistObject(obj) Then
                        _db.Insert(obj)
                    End If
                Else
                    _db.Delete(obj)
                End If

            End If
    End Sub
End Class