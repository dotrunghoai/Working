Imports CommonDB
Imports DevExpress.XtraGrid.Views.Grid
Imports PublicUtility
Public Class FrmReportList_2
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim DocNoID As String = ""

    Private Sub FrmReportList_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShow.PerformClick()
    End Sub
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.FillDataTable("SELECT DocNo, DocName 
                                                     FROM HRR_ReportList")
        GridControlSetFormat(GridView1)
        GridView1.Columns("DocName").Width = 200
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowClick
        GridControl2.DataSource = _db.FillDataTable(String.Format("SELECT DocNo, Email
                                                                   FROM HRR_ReportList_Detail
                                                                   WHERE DocNo = '{0}'",
                                                                   GridView1.GetFocusedRowCellValue("DocNo")))
        GridControlSetFormat(GridView2)
        GridView2.Columns("Email").Width = 200
        DocNoID = GridView1.GetFocusedRowCellValue("DocNo")
        Dim dt As DataTable = _db.FillDataTable("SELECT h.EmpID, d.SectionSort, d.Observation, Mail
                                                 FROM OT_Mail AS h
                                                 LEFT JOIN OT_Employee AS d
                                                 ON h.EmpID = d.EmpID
                                                 ORDER BY Mail ")
        slueMail.DataSource = dt
        slueMail.DisplayMember = "Mail"
        slueMail.ValueMember = "Mail"
        slueMail.NullText = Nothing
        GridView2.Columns("Email").ColumnEdit = slueMail
        slueMail.PopulateViewColumns()
        slueMail.View.Columns("Mail").Width = 200
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("DocName").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("DocName").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu !") = Windows.Forms.DialogResult.Yes Then
            _db.ExecuteNonQuery(String.Format("DELETE HRR_ReportList
                                               WHERE DocNo = '{0}'",
                                               GridView1.GetFocusedRowCellValue("DocNo")))
            GridView1.DeleteSelectedRows()
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        Dim listGrid As New List(Of GridView)
        Dim isContent As Boolean = False
        If GridView1.RowCount > 0 Then
            listGrid.Add(GridView1)
            isContent = True
        End If
        If GridView2.RowCount > 0 Then
            listGrid.Add(GridView2)
            isContent = True
        End If
        If isContent Then
            GridControlExportExcels(listGrid, True, , , True)
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And Not e.Column.ReadOnly Then
            If e.RowHandle < 0 Then
                If IsDBNull(GridView1.GetFocusedRowCellValue("DocNo")) Then
                    Dim id As String = GetID()
                    Dim obj As New HRR_ReportList
                    obj.DocNo_K = id
                    obj.CreateUser = CurrentUser.UserID
                    obj.CreateDate = DateTime.Now
                    _db.Insert(obj)
                    GridView1.SetFocusedRowCellValue("DocNo", id)
                End If
            End If
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(String.Format("UPDATE HRR_ReportList
                                               SET {0} = @Value
                                               WHERE DocNo = '{1}'",
                                               e.Column.FieldName,
                                               GridView1.GetFocusedRowCellValue("DocNo")), para)
        End If
    End Sub
    Function GetID() As String
        Dim myID As String = ""
        Dim stt As String = ""
        Dim yyMM As String = DateTime.Now.ToString("yyMM")
        Dim val As Object = _db.ExecuteScalar(String.Format("SELECT RIGHT(MAX(DocNo), 3) 
                                                             FROM HRR_ReportList
                                                             WHERE DocNo LIKE '%{0}%'", yyMM))
        If Not IsDBNull(val) And val IsNot Nothing Then
            val = Integer.Parse(val) + 1
            stt = val.ToString.PadLeft(3, "0")
            myID = "LM" + yyMM + "-" + stt
        Else
            myID = "LM" + yyMM + "-" + "001"
        End If
        Return myID
    End Function

    Private Sub btnAddMail_Click(sender As Object, e As EventArgs) Handles btnAddMail.Click
        If DocNoID <> "" Then
            GridView2.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
            GridControlReadOnly(GridView2, True)
            GridView2.Columns("Email").OptionsColumn.ReadOnly = False
            GridControlSetColorEdit(GridView2)
        End If
    End Sub

    Private Sub btnEditMail_Click(sender As Object, e As EventArgs) Handles btnEditMail.Click
        If DocNoID <> "" Then
            GridView2.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            GridControlReadOnly(GridView2, True)
            GridView2.Columns("Email").OptionsColumn.ReadOnly = False
            GridControlSetColorEdit(GridView2)
        End If
    End Sub

    Private Sub btnDeleteMail_Click(sender As Object, e As EventArgs) Handles btnDeleteMail.Click
        If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu !") = Windows.Forms.DialogResult.Yes Then
            _db.ExecuteNonQuery(String.Format("DELETE HRR_ReportList_Detail
                                               WHERE DocNo = '{0}'
                                               AND Email = '{1}'",
                                               GridView2.GetFocusedRowCellValue("DocNo"),
                                               GridView2.GetFocusedRowCellValue("Email")))
            GridView2.DeleteSelectedRows()
        End If
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        If GridView2.Editable And Not e.Column.ReadOnly Then
            If e.RowHandle < 0 Then
                If IsDBNull(GridView2.GetFocusedRowCellValue("DocNo")) Then
                    Dim obj As New HRR_ReportList_Detail
                    obj.DocNo_K = DocNoID
                    obj.Email_K = e.Value
                    If Not _db.ExistObject(obj) Then
                        obj.CreateUser = CurrentUser.UserID
                        obj.CreateDate = DateTime.Now
                        _db.Insert(obj)
                    End If
                    GridView2.SetFocusedRowCellValue("DocNo", DocNoID)
                End If
            End If
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(String.Format("UPDATE HRR_ReportList_Detail
                                               SET {0} = @Value
                                               WHERE DocNo = '{1}'
                                               AND Email = '{2}'",
                                               e.Column.FieldName,
                                               GridView2.GetFocusedRowCellValue("DocNo"),
                                               GridView2.ActiveEditor.OldEditValue), para)
        End If
    End Sub
End Class