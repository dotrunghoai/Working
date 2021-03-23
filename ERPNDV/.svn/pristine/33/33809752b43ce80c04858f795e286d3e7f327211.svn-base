
Imports System.Text
Imports LibEntity
Imports PublicUtility

Public Class FrmUser : Inherits DevExpress.XtraEditors.XtraForm

    Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _IsNew As Boolean
    Dim _checkAll As Boolean

#Region "Form function"

    Private Sub FrmUser_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If

        If e.KeyCode = Keys.N And e.Control And mnuNew.Enabled Then
            mnuNew.PerformClick()
        End If
        If e.KeyCode = Keys.S And e.Control And mnuSave.Enabled Then
            mnuSave.PerformClick()
        End If
        If e.KeyCode = Keys.D And e.Control And mnuDelete.Enabled Then
            mnuDelete.PerformClick()
        End If
        'If e.KeyCode = Keys.R And e.Control And mnuSetRight.Enabled Then
        '    mnuSetRight.PerformClick()
        'End If
        If e.KeyCode = Keys.F5 And mnuShowAll.Enabled Then
            mnuShowAll.PerformClick()
        End If

    End Sub

    Private Sub FrmUser_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        LoadAll()
        LoadRightTreeView()
    End Sub


    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        _IsNew = True
        ResetTextbox()

    End Sub

    Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
        Dim obj As New Main_User()
        If Not CheckCondition() Then Exit Sub

        If ShowQuestionSave() = DialogResult.No Then
            Exit Sub
        End If

        Try
            obj.UserID_K = txtUserID.Text
            db.GetObjectNotReset(obj)
            obj.CreateDate = DateTime.Now
            obj.CreateUser = CurrentUser.UserID
            obj.FullName = txtFullName.Text
            obj.Password = EncryptPassword(txtPassword.Text)
            obj.UserName = txtUserName.Text
            obj.Status = True
            obj.GlobalID = txtGlobalID.Text
            obj.GlobalPass = txtGlobalPass.Text
            obj.PCNoOriginal = txtPCNo.Text
            obj.Note = txtPhone.Text

            If db.ExistObject(obj) Then
                db.Update(obj)
            Else
                'Kiểm tra trùng tên đăng nhập
                Dim objCheck As New Main_User
                Dim sql As String = String.Format("select * from {0} where UserName='{1}'",
                                                  PublicTable.Table_Main_User, txtUserName.Text)
                objCheck = db.GetObject(Of Main_User)(sql)
                If objCheck.UserID_K Is Nothing Then
                    db.Insert(obj)
                Else
                    ShowWarning("UserName đã tồn tại, vui lòng chọn tên khác.")
                    Return
                End If
            End If

            ShowSuccess()
            mnuShowAll.PerformClick()
        Catch ex As Exception
            ShowError(ex, "Save", Name)
        End Try
    End Sub

    Private Sub mnuShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAll.Click
        LoadAll()
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click

        If ShowQuestionDelete(GridView1.GetFocusedRowCellValue("UserID")) = DialogResult.No Then
            Exit Sub
        End If

        Try
            Dim obj As New Main_User()
            obj.UserID_K = GridView1.GetFocusedRowCellValue("UserID")
            db.Delete(obj)
            mnuShowAll.PerformClick()
        Catch ex As Exception
            ShowError(ex, "Delete", Name)
        End Try

    End Sub
#End Region
    '===========================================================================================================

#Region "User function"

    Sub UpdateTreeView(ByVal userID As String)
        Dim sql As String = String.Format("select * from {0} where UserID='{1}'", PublicTable.Table_Main_UserRight, userID)
        Dim right() As Main_UserRight = db.GetObjects(Of Main_UserRight)(sql)

        'Uncheck all treeview 
        For Each node1 As TreeNode In tvwRight.Nodes 'Group level=0
            node1.Checked = False
            For Each node2 As TreeNode In node1.Nodes 'Module level=1
                node2.Checked = False
                For Each node3 As TreeNode In node2.Nodes ' Form level 2
                    node3.Checked = False
                    If node3.Nodes.Count > 0 Then
                        For Each node4 As TreeNode In node3.Nodes ' Form level 3
                            node4.Checked = False
                        Next
                    End If
                Next
            Next
        Next

        'Check right exist 
        If right Is Nothing Then Return
        'Update right on treevieew
        For Each node1 As TreeNode In tvwRight.Nodes 'Group level=0
            For Each node2 As TreeNode In node1.Nodes 'Module level=1
                node2.Checked = False
                For Each node3 As TreeNode In node2.Nodes ' Form level 2
                    node3.Checked = False
                    If node3.Nodes.Count = 0 Then
                        For Each g As Main_UserRight In right
                            If g.FormID_K = node3.Name Then
                                node3.Checked = True
                                node2.Checked = True
                                node1.Checked = True
                                Exit For
                            End If
                        Next
                    Else
                        For Each node4 As TreeNode In node3.Nodes
                            node4.Checked = False
                            For Each g As Main_UserRight In right
                                If g.FormID_K = node4.Name Then
                                    node4.Checked = True
                                    node3.Checked = True
                                    node2.Checked = True
                                    node1.Checked = True
                                    Exit For
                                End If
                            Next
                        Next
                    End If
                Next
            Next
        Next
    End Sub

    Public Sub LoadRightTreeView()
        tvwRight.Nodes.Clear()

        db = New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        Dim group() As Main_ModuleGroup
        Dim modules() As Main_Module
        Dim frm() As Main_FormRight
        Dim frmSub() As Main_FormRight

        group = db.GetAll(Of Main_ModuleGroup)()
        Dim index As Integer = 0
        Dim indexModule As Integer = 2
        Dim indexSubModule As Integer = 3
        Dim indexForm As Integer = 3
        Dim indexSelectedForm As Integer = 4
        For Each obj As Main_ModuleGroup In group
            Select Case PublicConst.Language
                Case PublicConst.EnumLanguage.English
                    tvwRight.Nodes.Add(obj.GroupID_K, obj.GroupNameE, index, index)
                Case PublicConst.EnumLanguage.VietNam
                    tvwRight.Nodes.Add(obj.GroupID_K, obj.GroupNameV, index, index)
            End Select
            index += 1
            If index > 1 Then index = 2
            modules = db.GetObjects(Of Main_Module)(String.Format("Select * from {0} where GroupID='{1}' and ModuleID!='0202' order by ModuleNameV",
                                                                  PublicTable.Table_Main_Module, obj.GroupID_K))
            For Each m As Main_Module In modules
                Dim condition As String = " 1=1 "
                'If CurrentUser.UserName <> "admin" Then condition += " and UserID='" + CurrentUser.UserID + "'"
                frm = db.GetObjects(Of Main_FormRight)(String.Format("Select distinct * from {0}  where ModuleID='{1}' " +
                                                                     " and (ChildForm is null OR ChildForm='' or ChildForm like '%00' )  order by [Order] ",
                                                                     PublicTable.Table_Main_FormRight,
                                                                      m.ModuleID_K))

                Select Case PublicConst.Language
                    Case PublicConst.EnumLanguage.English
                        tvwRight.Nodes(obj.GroupID_K).Nodes.Add(m.ModuleID_K, m.ModuleNameJ, indexModule, indexModule)
                    Case PublicConst.EnumLanguage.VietNam
                        tvwRight.Nodes(obj.GroupID_K).Nodes.Add(m.ModuleID_K, m.ModuleNameV, indexModule, indexModule)
                End Select
                If frm IsNot Nothing Then
                    For Each f As Main_FormRight In frm

                        Select Case PublicConst.Language
                            Case PublicConst.EnumLanguage.English
                                tvwRight.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Nodes.Add(f.FormID_K, f.TextEnglish, indexForm, indexSelectedForm).Tag = f.FormName
                            Case PublicConst.EnumLanguage.VietNam
                                tvwRight.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Nodes.Add(f.FormID_K, f.TextVietNam, indexForm, indexSelectedForm).Tag = f.FormName
                        End Select
                        If f.SubModule <> "0" Then
                            frmSub = db.GetObjects(Of Main_FormRight)(String.Format(" Select distinct r.* from {0} r " +
                                                                                    " where ModuleID='{1}' and {2} and " +
                                                                                     " (ChildForm like '{3}%' and  ChildForm not like '%00') order by r.ChildForm ",
                                                                                      PublicTable.Table_Main_FormRight,
                                                                                      m.ModuleID_K,
                                                                                      condition, f.SubModule))
                            If frmSub IsNot Nothing Then

                                For Each fsub As Main_FormRight In frmSub

                                    Select Case PublicConst.Language
                                        Case PublicConst.EnumLanguage.English
                                            tvwRight.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Nodes(f.FormID_K).Nodes.Add(fsub.FormID_K, fsub.TextEnglish, indexForm, indexSelectedForm).Tag = fsub.ModuleID
                                        Case PublicConst.EnumLanguage.VietNam
                                            tvwRight.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Nodes(f.FormID_K).Nodes.Add(fsub.FormID_K, fsub.TextVietNam, indexForm, indexSelectedForm).Tag = fsub.ModuleID
                                    End Select
                                Next
                            End If
                            If tvwRight.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Nodes(f.FormID_K).Nodes.Count = 0 Then
                                    tvwRight.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Nodes(f.FormID_K).Remove()
                                End If
                            End If
                    Next
                End If
                If tvwRight.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Nodes.Count = 0 Then
                    tvwRight.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Remove()
                End If
            Next
            If tvwRight.Nodes(obj.GroupID_K).Nodes.Count = 0 Then
                tvwRight.Nodes(obj.GroupID_K).Remove()
            End If
        Next

        tvwRight.CollapseAll()
        If tvwRight.Nodes.Count > 0 Then
            tvwRight.SelectedNode = tvwRight.Nodes(0)
        End If
    End Sub

    Function CheckCondition() As Boolean
        If txtFullName.Text.Trim() = "" Then
            MsgBox("Full name is not null", MsgBoxStyle.OkOnly, "Condition")
            Return False
        End If
        If txtPassword.Text.Trim() = "" Then
            MsgBox("Password is not null.", MsgBoxStyle.OkOnly, "Condition")
            Return False
        End If
        If txtUserID.Text.Trim() = "" Then
            MsgBox("UserID is not null", MsgBoxStyle.OkOnly, "Condition")
            Return False
        End If
        If txtUserName.Text.Trim() = "" Then
            MsgBox("UserName is not null.", MsgBoxStyle.OkOnly, "Condition")
            Return False
        End If
        If txtUserName.Text.ToLower() = "admin" Then
            MsgBox("UserName cann't set 'admin' .", MsgBoxStyle.OkOnly, "Condition")
            Return False
        End If
        Return True
    End Function

    Sub ResetTextbox()
        txtFullName.Text = ""
        txtPassword.Text = ""
        txtUserID.Text = ""
        txtUserName.Text = ""
        txtGlobalID.Text = ""
        txtGlobalPass.Text = ""
        txtPCNo.Text = ""
        txtPhone.Text = ""
        'set default
    End Sub

    Sub LoadAll()
        GridControl1.DataSource = db.ExecuteStoreProcedureTB("sp_Main_LoadUser")
        GridControlSetFormat(GridView1, 4)
        GridControlSetBestfit(GridView1, 100)
        GridView1.Columns("FullName").BestFit()
    End Sub

#End Region


    Private Sub tvwRight_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwRight.AfterCheck
        If _checkAll Then
            If e.Node.Level = 0 Then
                Return
            End If
            If e.Node.Level > 2 Or (e.Node.Level = 2 And e.Node.Nodes.Count = 0) Then
                Dim obj As New Main_UserRight
                obj.FormID_K = e.Node.Name
                For Each r As Integer In GridView1.GetSelectedRows
                    obj.UserID_K = GridView1.GetRowCellValue(r, "UserID")
                    If e.Node.Checked Then
                        If Not db.ExistObject(obj) Then
                            db.Insert(obj)
                        End If
                    Else
                        db.Delete(obj)
                    End If
                Next
            End If
            For Each node As TreeNode In e.Node.Nodes
                node.Checked = e.Node.Checked
                If node.Level > 3 Or (node.Level = 3 And node.Nodes.Count = 0) Then
                    Dim obj As New Main_UserRight
                    obj.FormID_K = node.Name
                    For Each r As Integer In GridView1.GetSelectedRows
                        obj.UserID_K = GridView1.GetRowCellValue(r, "UserID")
                        If node.Checked Then
                            If Not db.ExistObject(obj) Then
                                db.Insert(obj)
                            End If
                        Else
                            db.Delete(obj)
                        End If
                    Next
                End If
            Next
        End If

    End Sub

    Private Sub mnuSetRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopyRight.Click
        Cursor = Cursors.AppStarting
        If GridView1.RowCount = 0 Then Return
        'Set Right dựa vào Text UserID để có thể Copy
        Dim UserID As String = Trim(txtUserID.Text)
        Dim objUser As New Main_User
        objUser.UserID_K = UserID
        If Not db.ExistObject(objUser) Then 'Kiểm tra User này đã tạo chưa
            ShowWarning(String.Format("Nhân viên {0} chưa tạo tài khoản.", UserID))
            Return
        End If

        If GridView1.GetSelectedRows.Count = 0 Then
            ShowWarning("Bạn chọn nhân viên cần copy quyền cho nhân viên khác.")
            Return
        End If

        If ShowQuestionSave() = DialogResult.No Then
            Return
        End If
        'Try
        '    db.BeginTransaction()
        Dim obj As New Main_UserRight()
            For Each node1 As TreeNode In tvwRight.Nodes 'Group level=0
                For Each node2 As TreeNode In node1.Nodes 'Module level=1
                    For Each node3 As TreeNode In node2.Nodes ' Form level 2
                        If node3.Nodes.Count = 0 Then
                            obj.UserID_K = UserID 'Thay cho gridUsser.GetFocusedRowCellValue(""UserID").Value
                            obj.FormID_K = node3.Name
                            obj.CreateDate = DateTime.Now
                            obj.CreateUser = CurrentUser.UserID
                            If node3.Checked And Not db.ExistObject(obj) Then
                                db.Insert(obj)
                            End If
                            'If node3.Checked = False Then
                            '    db.Delete(obj)
                            'End If
                        Else
                            obj.UserID_K = UserID 'Thay cho gridUsser.GetFocusedRowCellValue(""UserID").Value
                            obj.FormID_K = node3.Name
                            obj.CreateDate = DateTime.Now
                            obj.CreateUser = CurrentUser.UserID
                            If node3.Checked And Not db.ExistObject(obj) Then
                                db.Insert(obj)
                            End If
                            'If node3.Checked = False Then
                            '    db.Delete(obj)
                            'End If
                            For Each node4 As TreeNode In node3.Nodes
                                obj.UserID_K = UserID 'Thay cho gridUsser.GetFocusedRowCellValue(""UserID").Value
                                obj.FormID_K = node4.Name
                                obj.CreateDate = DateTime.Now
                                obj.CreateUser = CurrentUser.UserID
                                If node4.Checked And Not db.ExistObject(obj) Then
                                    db.Insert(obj)
                                End If
                                'If node4.Checked = False Then
                                '    db.Delete(obj)
                                'End If
                            Next
                        End If
                    Next
                Next
            Next
        'Nếu User trên Text và trên Grid khác nhau thì thực hiện Copy
        If UserID <> GridView1.GetFocusedRowCellValue("UserID") Then
            'Copy UserRightDetail
            Dim sqlSetDetail As String = String.Format("SELECT  UserID , " +
                            "FormID, " +
                            "ControlName, " +
                            "CreateDate, " +
                            "CreateUser " +
                            "FROM {0} " +
                            "WHERE   UserID = '{1}'",
                            PublicTable.Table_Main_UserRightDetail,
                            GridView1.GetFocusedRowCellValue("UserID"))
            Dim dtSetDetail As DataTable = db.FillDataTable(sqlSetDetail)
            If dtSetDetail.Rows.Count <> 0 Then
                For i As Integer = 0 To dtSetDetail.Rows.Count - 1
                    Dim objSetDetail As New Main_UserRightDetail
                    objSetDetail.UserID_K = UserID
                    objSetDetail.FormID_K = dtSetDetail.Rows(i)("FormID")
                    objSetDetail.ControlName_K = dtSetDetail.Rows(i)("ControlName")
                    objSetDetail.CreateDate = DateTime.Now
                    objSetDetail.CreateUser = CurrentUser.UserID
                    If db.ExistObject(objSetDetail) Then
                        db.Update(objSetDetail)
                    Else
                        db.Insert(objSetDetail)
                    End If
                Next
            End If
        End If
        'db.Commit()
        ShowSuccess()
        'Catch ex As Exception
        '    db.RollBack()
        '    ShowError(ex, "SetRight", Name)
        'End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub tvwRight_NodeMouseDoubleClick(sender As System.Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvwRight.NodeMouseDoubleClick
        If GridView1.RowCount = 0 Then Return
        If e.Node.Level >= 2 And e.Node.Nodes.Count = 0 Then
            Dim frm As New FrmPermissionControl()
            frm.isGroup = False
            frm.ID = e.Node.Name
            frm._grid = GridView1
            frm.UserID = GridView1.GetFocusedRowCellValue("UserID")
            frm.ShowDialog()
        End If
    End Sub

    Private Sub txtUserID_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUserID.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadEmployeeName()
            txtPassword.Text = txtUserID.Text
        End If
    End Sub
    Sub LoadEmployeeName()
        Dim obj As New OT_Employee
        obj.EmpID_K = txtUserID.Text
        db.GetObject(obj)
        txtFullName.Text = obj.EmpName
        txtSection.Text = obj.Section
    End Sub

    Private Sub GroupOfTrainingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GroupOfTrainingToolStripMenuItem.Click
        If GridView1.SelectedRowsCount = 0 Then Return
        Dim frm As New FrmGroupOfUserTrain
        frm._uID = GridView1.GetFocusedRowCellValue("UserID")
        frm._depts = GridView1.GetFocusedRowCellValue("Section")
        frm.ShowDialog()
    End Sub

    Private Sub mnuGroupOfWT_Click(sender As System.Object, e As System.EventArgs) Handles mnuGroupOfWT.Click
        If GridView1.SelectedRowsCount = 0 Then Return
        Dim frm As New FrmGroupOfUser
        frm._uID = GridView1.GetFocusedRowCellValue("UserID")
        frm.ShowDialog()
    End Sub

    Private Sub mnuGroupOfSiteStock_Click(sender As System.Object, e As System.EventArgs) Handles mnuGroupOfSiteStock.Click
        If GridView1.SelectedRowsCount = 0 Then Return
        Dim frm As New FrmGroupOfUserSiteStock
        frm._uID = GridView1.GetFocusedRowCellValue("UserID")
        frm.ShowDialog()
    End Sub

    Private Sub mnuExportInfo_Click(sender As System.Object, e As System.EventArgs) Handles mnuExportInfo.Click
        ExportEXCEL(db.ExecuteStoreProcedureTB("[sp_Main_GetUserInfo]"))
    End Sub

    Private Sub mnuSPC_Click(sender As System.Object, e As System.EventArgs) Handles mnuSPC.Click
        If GridView1.SelectedRowsCount = 0 Then Return
        Dim frm As New FrmGroupOfUserSPC
        frm._uID = GridView1.GetFocusedRowCellValue("UserID")
        frm.ShowDialog()
    End Sub

    Private Sub ckoPass_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckoPass.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not ckoPass.Checked
    End Sub


    Private Sub mnuEdit_Click(sender As System.Object, e As System.EventArgs) Handles mnuEdit.Click
        txtUserID.Text = ""
        txtUserName.Text = ""
        txtFullName.Text = ""
        txtSection.Text = ""
        txtPassword.Text = ""
        txtGlobalID.Text = ""
        txtGlobalPass.Text = ""
        txtPCNo.Text = ""
        txtPhone.Text = ""

        GridControlReadOnly(GridView1, True)
        GridView1.Columns("Email").OptionsColumn.ReadOnly = False
        GridView1.Columns("PCNoOriginal").OptionsColumn.ReadOnly = False
        GridView1.Columns("GlobalID").OptionsColumn.ReadOnly = False
        GridView1.Columns("GlobalPass").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)

        If GridView1.GetFocusedRowCellValue("UserID") IsNot DBNull.Value Then
            txtUserID.Text = GridView1.GetFocusedRowCellValue("UserID")
        End If

        If GridView1.GetFocusedRowCellValue("UserName") IsNot DBNull.Value Then
            txtUserName.Text = GridView1.GetFocusedRowCellValue("UserName")
        End If

        If GridView1.GetFocusedRowCellValue("Password") IsNot DBNull.Value Then
            txtPassword.Text = DecryptPassword(GridView1.GetFocusedRowCellValue("Password"))
        End If

        If GridView1.GetFocusedRowCellValue("FullName") IsNot DBNull.Value Then
            txtFullName.Text = GridView1.GetFocusedRowCellValue("FullName")
        End If

        If GridView1.GetFocusedRowCellValue("PCNoOriginal") IsNot DBNull.Value Then
            txtPCNo.Text = GridView1.GetFocusedRowCellValue("PCNoOriginal")
        End If

        If GridView1.GetFocusedRowCellValue("GlobalID") IsNot DBNull.Value Then
            txtGlobalID.Text = GridView1.GetFocusedRowCellValue("GlobalPass")
        End If

        If GridView1.GetFocusedRowCellValue("GlobalPass") IsNot DBNull.Value Then
            txtGlobalPass.Text = GridView1.GetFocusedRowCellValue("GlobalPass")
        End If

        If GridView1.GetFocusedRowCellValue("Note") IsNot DBNull.Value Then
            txtPhone.Text = GridView1.GetFocusedRowCellValue("Note")
        End If

        If GridView1.GetFocusedRowCellValue("Section") IsNot DBNull.Value Then
            txtSection.Text = GridView1.GetFocusedRowCellValue("Section")
        End If

        _IsNew = False


    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowClick
        'Update treeview Right
        If GridView1.RowCount > 0 Then
            _checkAll = False
            UpdateTreeView(GridView1.GetFocusedRowCellValue("UserID"))
            _checkAll = True
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            If e.Column.FieldName = "Email" Then
                Dim obj As New OT_Mail
                obj.EmpID_K = GridView1.GetFocusedRowCellValue("UserID")
                If GridView1.GetFocusedRowCellValue("Email") IsNot DBNull.Value Then
                    obj.Mail = GridView1.GetFocusedRowCellValue("Email")
                Else
                    obj.Mail = ""
                End If
                If db.ExistObject(obj) Then
                    db.Update(obj)
                Else
                    db.Insert(obj)
                End If
            End If
            If "PCNoOriginal" = e.Column.FieldName Or
                "GlobalID" = e.Column.FieldName Or
                "GlobalPass" = e.Column.FieldName Then
                Dim obj As New Main_User
                obj.UserID_K = GridView1.GetFocusedRowCellValue("UserID")
                db.GetObject(obj)
                If GridView1.GetFocusedRowCellValue("PCNoOriginal") IsNot DBNull.Value Then
                    obj.PCNoOriginal = GridView1.GetFocusedRowCellValue("PCNoOriginal")
                Else
                    obj.PCNoOriginal = ""
                End If
                If GridView1.GetFocusedRowCellValue("GlobalID") IsNot DBNull.Value Then
                    obj.GlobalID = GridView1.GetFocusedRowCellValue("GlobalID")
                Else
                    obj.GlobalID = ""
                End If
                If GridView1.GetFocusedRowCellValue("GlobalPass") IsNot DBNull.Value Then
                    obj.GlobalPass = GridView1.GetFocusedRowCellValue("GlobalPass")
                Else
                    obj.GlobalPass = ""
                End If
                If GridView1.GetFocusedRowCellValue("Note") IsNot DBNull.Value Then
                    obj.Note = GridView1.GetFocusedRowCellValue("Note")
                Else
                    obj.Note = ""
                End If
                If db.ExistObject(obj) Then
                    db.Update(obj)
                Else
                    db.Insert(obj)
                End If
            End If
        End If
    End Sub

    Private Sub mnuKillAll_Click(sender As Object, e As EventArgs) Handles mnuKillAll.Click
        db.ExecuteStoreProcedure("sp_Admin_KillAllConnection")
        ShowSuccess()
    End Sub
End Class