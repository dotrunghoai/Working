Imports PublicUtility
Imports CommonDB
Imports System.IO

Public Class FrmMasterStandardTGGC
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmMasterStandardTGGC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New Main_UserRight
        obj.FormID_K = Tag
        obj.UserID_K = CurrentUser.UserID
        _db.GetObject(obj)
        If obj.IsEdit = False Then
            ViewAccess()
        End If
        btnShow.PerformClick()
    End Sub
    Sub ViewAccess()
        btnNew.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
    End Sub
    Function CreateID() As String
        Dim val As Object = _db.ExecuteScalar("SELECT Right(MAX(ID), 2)
                                               FROM PP_StandardTGGC_Master")
        If Not IsDBNull(val) Then
            val = (Integer.Parse(val) + 1).ToString.PadLeft(2, "0")
            Return "CD" + "-" + val
        Else
            Return "CD" + "-01"
        End If
    End Function
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim dtMaster = _db.FillDataTable("  SELECT h.ID, h.TenCongDoan, h.PICUser, h.MailTo, d.AttachFileName, 
                                                    d.AttachFileServerName, d.ContentReport, d.DateApproved, d.FileID
                                            FROM PP_StandardTGGC_Master AS h
                                            LEFT JOIN (
	                                            SELECT g.FileID, g.AttachFileName, g.ProcessID, 
                                                    g.AttachFileServerName, g.ContentReport, g.DateApproved
	                                            FROM PP_StandardTGGC_File AS g
	                                            INNER JOIN (
		                                            SELECT ProcessID, MAX(DateApproved) AS DateApproved
		                                            FROM PP_StandardTGGC_File
		                                            GROUP BY ProcessID
	                                            ) AS m
	                                            ON g.ProcessID = m.ProcessID
	                                            AND g.DateApproved = m.DateApproved
                                            ) AS d
                                            ON h.ID = d.ProcessID
                                            ORDER BY TenCongDoan")

        GridControl1.DataSource = dtMaster
        GridControlSetFormat(GridView1, 1)
        GridView1.Columns("TenCongDoan").Width = 100
        GridView1.Columns("MailTo").Width = 150
        GridView1.Columns("AttachFileName").Width = 225
        GridView1.Columns("ContentReport").Width = 250
        GridView1.Columns("DateApproved").Width = 125
        GridView1.Columns("AttachFileServerName").Visible = False
        GridView1.Columns("FileID").Visible = False
        GridView1.Columns("AttachFileName").ColumnEdit = GridControlLinkEdit()

        Dim dt As DataTable = _db.FillDataTable("SELECT h.EmpID, d.SectionSort, d.Observation, Mail
                                                 FROM OT_Mail AS h
                                                 LEFT JOIN OT_Employee AS d
                                                 ON h.EmpID = d.EmpID
                                                 ORDER BY Mail ")
        sluePicMail.DataSource = dt
        sluePicMail.DisplayMember = "Mail"
        sluePicMail.ValueMember = "Mail"
        sluePicMail.NullText = Nothing
        GridView1.Columns("PICUser").ColumnEdit = sluePicMail
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("TenCongDoan").OptionsColumn.ReadOnly = False
        GridView1.Columns("PICUser").OptionsColumn.ReadOnly = False
        GridView1.Columns("MailTo").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("TenCongDoan").OptionsColumn.ReadOnly = False
        GridView1.Columns("PICUser").OptionsColumn.ReadOnly = False
        GridView1.Columns("MailTo").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            Dim obj As New PP_StandardTGGC_Master
            obj.ID_K = GridView1.GetFocusedRowCellValue("ID")
            _db.Delete(obj)
            GridView1.DeleteSelectedRows()
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If IsDBNull(GridView1.GetFocusedRowCellValue("ID")) Then
                    Dim obj As New PP_StandardTGGC_Master
                    obj.ID_K = CreateID()
                    _db.Insert(obj)
                    GridView1.SetFocusedRowCellValue("ID", obj.ID_K)
                End If
            End If
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(String.Format("UPDATE PP_StandardTGGC_Master
                                               SET {0} = @Value
                                               WHERE ID = '{1}'",
                                               e.Column.FieldName,
                                               GridView1.GetFocusedRowCellValue("ID")),
                                               para)
        End If
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowClick
        If GridView1.FocusedColumn.FieldName = "AttachFileName" Then
            If Not IsDBNull(GridView1.GetFocusedRowCellValue("AttachFileServerName")) Then
                If File.Exists(GridView1.GetFocusedRowCellValue("AttachFileServerName")) Then
                    Process.Start(OpenfileTemp(GridView1.GetFocusedRowCellValue("AttachFileServerName")))
                End If
            End If
        Else
            Dim dtMasSub = _db.FillDataTable(String.Format("SELECT AttachFileName, AttachFileServerName, 
                                                                    ContentReport, DateApproved
                                                            FROM PP_StandardTGGC_File
                                                            WHERE ProcessID = '{0}'
                                                            AND FileID <> '{1}'
                                                            ORDER BY DateApproved DESC",
                                                            GridView1.GetFocusedRowCellValue("ID"),
                                                            GridView1.GetFocusedRowCellValue("FileID")))
            GridControl2.DataSource = dtMasSub
            GridControlSetFormat(GridView2, 1)
            GridView2.Columns("AttachFileName").Width = 225
            GridView2.Columns("ContentReport").Width = 200
            GridView2.Columns("DateApproved").Width = 125
            GridView2.Columns("AttachFileServerName").Visible = False
            GridView2.Columns("AttachFileName").ColumnEdit = GridControlLinkEdit()
        End If
    End Sub

    Private Sub GridView2_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView2.RowClick
        If GridView2.FocusedColumn.FieldName = "AttachFileName" Then
            If File.Exists(GridView2.GetFocusedRowCellValue("AttachFileServerName")) Then
                Process.Start(OpenfileTemp(GridView2.GetFocusedRowCellValue("AttachFileServerName")))
            End If
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub
End Class