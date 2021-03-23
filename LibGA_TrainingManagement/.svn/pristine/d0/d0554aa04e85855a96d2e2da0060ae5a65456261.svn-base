Imports CommonDB
Imports PublicUtility
Public Class FrmProgramMasterForNewComers
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _isEdit As Boolean = True

    Private Sub FrmProgramMasterForNewComers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShow.PerformClick()
        btnShowDetail.PerformClick()
        Dim obj As New Main_UserRight
        obj.UserID_K = CurrentUser.UserID
        obj.FormID_K = Tag
        _db.GetObject(obj)
        If obj.IsEdit = False Then
            ViewAccess()
            _isEdit = False
        End If
    End Sub
    Sub ViewAccess()
        btnEdit.Enabled = False
        btnImport.Enabled = False
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.FillDataTable("SELECT Section, TrainingCode, TrainingProgram
                                                    FROM GA_TRM_ProgramMaster
                                                    WHERE TrainingCode LIKE 'N%'
                                                    ORDER BY Section, TrainingCode")
        GridControlSetFormat(GridView1, 1)
        GridView1.Columns("Section").Width = 100
        GridView1.Columns("TrainingProgram").Width = 300
    End Sub

    Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
        grcProgress.Visible = True
        Dim dtImp = ImportEXCEL(True)
        If dtImp.Rows.Count > 0 Then
            Dim row = 0
            Try
                _db.BeginTransaction()
                Dim succ = 0
                ProgressBarControl1.Properties.Step = 1
                ProgressBarControl1.Properties.PercentView = True
                ProgressBarControl1.Properties.Maximum = dtImp.Rows.Count
                ProgressBarControl1.Properties.Minimum = 0
                ProgressBarControl1.Properties.ShowTitle = True
                For Each r As DataRow In dtImp.Rows
                    row += 1
                    If IsDBNull(r("Section")) Or IsDBNull(r("Training Code")) Then Continue For
                    Dim obj As New GA_TRM_ProgramMaster
                    obj.Section = r("Section")
                    obj.TrainingCode_K = r("Training Code")
                    obj.TrainingProgram = r("Training Program")
                    obj.CreateUser = CurrentUser.UserID
                    obj.CreateDate = DateTime.Now
                    If Not _db.ExistObject(obj) Then
                        _db.Insert(obj)
                        succ += 1
                    End If
                    ProgressBarControl1.PerformStep()
                    ProgressBarControl1.Update()
                Next
                ProgressBarControl1.EditValue = 0
                _db.Commit()
                ShowSuccess(succ)
            Catch ex As Exception
                _db.RollBack()
                ShowWarning(ex.Message + " - Row " + row.ToString)
            End Try
        End If
        grcProgress.Visible = False
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        Dim file1 As String = ""
        Dim file2 As String = ""
        Dim listFile As New List(Of String)
        GridControlExportExcel(GridView1, "List", False, file1)
        listFile.Add(file1)
        GridControlExportExcel(GridView2, "Detail", False, file2)
        listFile.Add(file2)
        MergeXlsxFilesDevExpress("", listFile.ToArray, True)
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("TrainingProgram").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(String.Format("UPDATE GA_TRM_ProgramMaster
                                                SET {0} = @Value
                                                WHERE TrainingCode = '{1}'",
                                                e.Column.FieldName,
                                                GridView1.GetFocusedRowCellValue("TrainingCode")),
                                                para)
        End If
    End Sub

    Private Sub btnShowDetail_Click(sender As Object, e As EventArgs) Handles btnShowDetail.Click
        ShowDetail(DBNull.Value)
    End Sub
    Sub ShowDetail(trainingCode)
        Dim para(0) As SqlClient.SqlParameter
        If trainingCode IsNot Nothing Then
            para(0) = New SqlClient.SqlParameter("@TrainingCode", trainingCode)
        Else
            para(0) = New SqlClient.SqlParameter("@TrainingCode", DBNull.Value)
        End If
        GridControl2.DataSource = _db.FillDataTable("SELECT TrainingCode, TrainingCodeDetail, TrainingProgramDetail
                                                    FROM GA_TRM_ProgramMaster_Detail
                                                    WHERE (@TrainingCode IS NULL OR TrainingCode = @TrainingCode)
                                                    ORDER BY TrainingCode, TrainingCodeDetail",
                                                    para)
        GridControlSetFormat(GridView2, 1)
        GridView2.Columns("TrainingProgramDetail").Width = 300
        GridView2.Columns("TrainingProgramDetail").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
    End Sub

    Private Sub btnEditDetail_Click(sender As Object, e As EventArgs) Handles btnEditDetail.Click
        GridControlReadOnly(GridView2, True)
        GridView2.Columns("TrainingProgramDetail").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView2)
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        If GridView2.Editable And e.Column.ReadOnly = False Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(String.Format("UPDATE GA_TRM_ProgramMaster_Detail
                                                SET {0} = @Value
                                                WHERE TrainingCode = '{1}'
                                                AND TrainingCodeDetail = '{2}'",
                                                e.Column.FieldName,
                                                GridView2.GetFocusedRowCellValue("TrainingCode"),
                                                GridView2.GetFocusedRowCellValue("TrainingCodeDetail")),
                                                para)
        End If
    End Sub

    Private Sub btnImportDetail_Click(sender As Object, e As EventArgs) Handles btnImportDetail.Click
        grcProgress.Visible = True
        Dim dtImp = ImportEXCEL(True)
        If dtImp.Rows.Count > 0 Then
            Dim row = 0
            Try
                _db.BeginTransaction()
                Dim succ = 0
                ProgressBarControl1.Properties.Step = 1
                ProgressBarControl1.Properties.PercentView = True
                ProgressBarControl1.Properties.Maximum = dtImp.Rows.Count
                ProgressBarControl1.Properties.Minimum = 0
                ProgressBarControl1.Properties.ShowTitle = True
                For Each r As DataRow In dtImp.Rows
                    row += 1
                    If IsDBNull(r("Training Code")) Or IsDBNull(r("Training Code Detail")) Then Continue For
                    Dim obj As New GA_TRM_ProgramMaster_Detail
                    obj.TrainingCode_K = r("Training Code")
                    obj.TrainingCodeDetail_K = r("Training Code Detail")
                    obj.TrainingProgramDetail = r("Training Program Detail")
                    obj.CreateUser = CurrentUser.UserID
                    obj.CreateDate = DateTime.Now
                    If Not _db.ExistObject(obj) Then
                        _db.Insert(obj)
                        succ += 1
                    End If
                    ProgressBarControl1.PerformStep()
                    ProgressBarControl1.Update()
                Next
                ProgressBarControl1.EditValue = 0
                _db.Commit()
                ShowSuccess(succ)
            Catch ex As Exception
                _db.RollBack()
                ShowWarning(ex.Message + " - Row " + row.ToString)
            End Try
        End If
        grcProgress.Visible = False
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowClick
        ShowDetail(GridView1.GetFocusedRowCellValue("TrainingCode"))
    End Sub
End Class