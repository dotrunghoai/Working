Imports CommonDB
Imports PublicUtility
Public Class FrmListMailWarning
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub ListMailWarning_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShow.PerformClick()
        Dim obj As New Main_UserRight
        obj.UserID_K = CurrentUser.UserID
        obj.FormID_K = Tag
        _db.GetObject(obj)
        If obj.IsEdit = False Then
            ViewAccess()
        End If
    End Sub
    Sub ViewAccess()
        btnDelete.Enabled = False
        btnNew.Enabled = False
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.FillDataTable("SELECT Mail FROM QA_SSW_EmailWarning")
        GridControlSetFormat(GridView1)
        GridView1.Columns("Mail").Width = 200
        Dim dtMail = _db.FillDataTable("SELECT EmpID, Mail FROM OT_Mail")
        GridView1.Columns("Mail").ColumnEdit = GridControlLoadLookUpEdit(dtMail, "Mail", "Mail")
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("Mail").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            Dim obj As New QA_SSW_EmailWarning
            obj.Mail_K = GridView1.GetFocusedRowCellValue("Mail")
            _db.Delete(obj)
            GridView1.DeleteSelectedRows()
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            Dim obj As New QA_SSW_EmailWarning
            obj.Mail_K = GridView1.GetFocusedRowCellValue("Mail")
            If _db.ExistObject(obj) Then
                _db.Update(obj)
            Else
                _db.Insert(obj)
            End If
        End If
    End Sub
End Class