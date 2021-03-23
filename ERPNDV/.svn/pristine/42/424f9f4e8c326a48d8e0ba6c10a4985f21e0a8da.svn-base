
Imports PublicUtility


Public Class FrmStartup : Inherits DevExpress.XtraEditors.XtraForm

#Region "Form function"
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)



#End Region

    'Private Sub linkEventClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New DevExpress.XtraEditors.XtraForm
    '    PublicFunction.ShowNewForm(frm)
    'End Sub


    Sub LoadAll()
        Try
            gbo.Visible = False

            Dim sql As String = String.Format("sp_Main_GetAllRequestApproved")
            Dim para(2) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@EmpID", CurrentUser.UserID)
            para(1) = New SqlClient.SqlParameter("@EmpName", CurrentUser.FullName)
            If CurrentUser.Mail = "" Then
                para(2) = New SqlClient.SqlParameter("@User", CurrentUser.UserID)
            Else
                para(2) = New SqlClient.SqlParameter("@User", CurrentUser.Mail)
            End If

            GridControl1.DataSource = _db.ExecuteStoreProcedureTB(sql, para, 5)
            GridControlSetFormat(GridView1)

            GridView1.Columns("Detail").ColumnEdit = GridControlLinkEdit()
            GridControlSetBestfit(GridView1, 200)

            If GridView1.RowCount > 0 Then
                gbo.Visible = True
            Else
                gbo.Visible = False
            End If

        Catch ex As Exception
            If CurrentUser.PCNO = "V00365" Then
                If Not ex.Message.Contains("network") Then
                    ShowError(ex, "ApproveList", Name)
                End If
            End If
        End Try

    End Sub

    'Sub LoadUpdateGlobalID()

    '    If (CurrentUser.GlobalID = "" Or CurrentUser.GlobalPass = "") And
    '        Not CurrentUser.UserID.Contains("J") Then
    '        linkInfor.Visible = True
    '        linkUpdateID.Visible = True
    '    Else
    '        linkInfor.Visible = False
    '        linkUpdateID.Visible = False
    '    End If
    'End Sub

    Private Sub tmrDuyet_Tick(sender As System.Object, e As System.EventArgs) Handles tmrDuyet.Tick

        LoadAll()
    End Sub

    Private Sub FrmStartup_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        tmrDuyet.Enabled = True

        'LoadUpdateGlobalID()
    End Sub

    Private Sub mnuLoadAll_Click(sender As System.Object, e As System.EventArgs)
        LoadAll()
    End Sub

    Private Sub FrmStartup_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            LoadAll()
        End If
        If e.KeyCode = Keys.E And e.Control Then
            GridControlExportExcel(GridView1)
        End If
    End Sub

    Private Sub FrmStartup_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        LoadAll()
    End Sub

    Private Sub bttSetupAlarm_Click(sender As System.Object, e As System.EventArgs)
        Dim frm As New FrmNotifySetTime
        frm.ShowDialog()
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridView1.RowCellClick
        If e.Column.FieldName = "Detail" Then
            If GridView1.GetFocusedRowCellValue("ID") IsNot DBNull.Value Then
                clsMain.fMain.ShowNewForm("", GridView1.GetFocusedRowCellValue("FormID"),
                                    GridView1.GetFocusedRowCellValue("ID"))
            End If
        End If
    End Sub

    Private Sub linkUpdateID_Click(sender As Object, e As EventArgs)
        Dim frm As New FrmUserInfo
        frm.ShowDialog()
        'LoadUpdateGlobalID()
    End Sub
End Class