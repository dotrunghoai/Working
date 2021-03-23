Imports CommonDB
Imports PublicUtility
Public Class FrmProcessHourCIS
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmPlanHourCIS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShow.PerformClick()
        grcProgressBar.Visible = False
        Dim obj As New Main_UserRight
        obj.UserID_K = CurrentUser.UserID
        obj.FormID_K = Tag
        _db.GetObject(obj)
        If obj.IsEdit = False And obj.IsAdmin = False Then
            ViewAccess()
        End If
    End Sub
    Sub ViewAccess()
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnImport.Enabled = False
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.FillDataTable("
            SELECT ProductCode, RevisionCode, ProcessNumber, ProcessCode, ProcessName, Sheet, LotSize,
                TGGC, Note, CreateUser, CreateDate
            FROM PD_ProcessHourCIS
            ORDER BY ProductCode, ProcessNumber")
        GridControlSetFormat(GridView1, 4)
        GridView1.Columns("ProcessName").Width = 200
        GridView1.Columns("Note").Width = 200
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
        Dim dtImp = ImportEXCEL(True)
        If dtImp.Rows.Count > 0 Then
            grcProgressBar.Visible = True
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
                    If IsDBNull(r("Process Name")) Or IsDBNull(r("TGGC")) Then Continue For
                    Dim obj As New PD_ProcessHourCIS
                    obj.ProductCode_K = "CIS"
                    obj.RevisionCode_K = "01"
                    obj.ProcessNumber_K = GetNewProcessNumber()
                    obj.ProcessCode = r("Process Name").ToString.Substring(0, 3)
                    obj.ProcessName = r("Process Name")
                    obj.TGGC = r("TGGC")
                    If Not IsDBNull(r("Note")) Then
                        obj.Note = r("Note")
                    End If
                    obj.CreateUser = CurrentUser.UserID
                    obj.CreateDate = DateTime.Now
                    If _db.ExistObject(obj) Then
                        _db.Update(obj)
                    Else
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
                ShowWarning(ex.Message + " - Dòng " + row.ToString)
            End Try
        End If
        grcProgressBar.Visible = False
    End Sub
    Function GetNewProcessNumber() As String
        Dim valMax = _db.ExecuteScalar("SELECT ISNULL(MAX(ProcessNumber), 0)
                                        FROM PD_ProcessHourCIS")
        Return (Integer.Parse(valMax) + 1).ToString.PadLeft(2, "0")
    End Function
End Class