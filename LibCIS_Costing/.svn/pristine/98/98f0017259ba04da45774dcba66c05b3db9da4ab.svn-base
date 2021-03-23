Imports CommonDB
Imports PublicUtility
Public Class FrmWIPGroupName
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmCreateGroupName_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShow.PerformClick()
        Dim obj As New Main_UserRight
        obj.UserID_K = CurrentUser.UserID
        obj.FormID_K = Tag
        _db.GetObject(obj)
        If obj.IsEdit = False And obj.IsAdmin = False Then
            ViewAccess()
        End If
    End Sub
    Sub ViewAccess()
        btnNew.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.FillDataTable("
            SELECT GroupCode, GroupName, Note, CreatedUser, CreatedDate
            FROM CIS_WIP_GroupName")
        GridControlSetFormat(GridView1, 1)
        GridView1.Columns("GroupName").Width = 150
        GridView1.Columns("Note").Width = 150
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("GroupName").OptionsColumn.ReadOnly = False
        GridView1.Columns("Note").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("GroupName").OptionsColumn.ReadOnly = False
        GridView1.Columns("Note").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If IsDBNull(GridView1.GetFocusedRowCellValue("GroupCode")) Then
                    Dim obj As New CIS_WIP_GroupName
                    obj.GroupCode_K = GetNewID()
                    obj.CreatedUser = CurrentUser.UserID
                    obj.CreatedDate = Date.Now
                    _db.Insert(obj)
                    GridView1.SetFocusedRowCellValue("GroupCode", obj.GroupCode_K)
                End If
            End If
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(String.Format("UPDATE CIS_WIP_GroupName
                                                SET {0} = @Value
                                                WHERE GroupCode = '{1}'",
                                                e.Column.FieldName,
                                                GridView1.GetFocusedRowCellValue("GroupCode")),
                                                para)
        End If
    End Sub
    Function GetNewID() As String
        Dim maxVal = _db.ExecuteScalar("SELECT ISNULL(MAX(GroupCode), 0)
                                        FROM CIS_WIP_GroupName")
        Return (Integer.Parse(maxVal) + 1).ToString.PadLeft(2, "0")
    End Function

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            For Each r As Integer In GridView1.GetSelectedRows
                Dim obj As New CIS_WIP_GroupName
                obj.GroupCode_K = GridView1.GetRowCellValue(r, "GroupCode")
                _db.Delete(obj)
            Next
            GridView1.DeleteSelectedRows()
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub
End Class