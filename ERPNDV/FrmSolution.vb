
Imports LibEntity
Imports PublicUtility

Public Class FrmSolution : Inherits DevExpress.XtraEditors.XtraForm

#Region "Variable"
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
#End Region

#Region "Form function"

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FrmSolution_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        LoadTreeViewMenu()

    End Sub

    Public Sub LoadTreeViewMenu()
        tvwSolution.Nodes.Clear()
        Dim group() As Main_ModuleGroup
        Dim modules() As Main_Module
        Dim frm() As Main_FormRight
        Dim frmSub() As Main_FormRight

        group = _db.GetAll(Of Main_ModuleGroup)()
        Dim index As Integer = 0
        Dim indexModule As Integer = 2
        Dim indexSubModule As Integer = 3
        Dim indexForm As Integer = 3
        Dim indexSelectedForm As Integer = 4
        Dim modulename As String = "ModuleNameV"
        For Each obj As Main_ModuleGroup In group

            Select Case PublicConst.Language
                Case PublicConst.EnumLanguage.English
                    tvwSolution.Nodes.Add(obj.GroupID_K, obj.GroupNameE, index, index).Tag = "S"
                    modulename = "ModuleNameE"
                Case PublicConst.EnumLanguage.VietNam
                    tvwSolution.Nodes.Add(obj.GroupID_K, obj.GroupNameV, index, index).Tag = "S"
                    modulename = "ModuleNameV"
            End Select
            index += 1
            If index > 1 Then index = 1
            modules = _db.GetObjects(Of Main_Module)(String.Format("  SELECT distinct m.* " +
                                                                 " FROM [Main_UserRight] u" +
                                                                 " left join dbo.Main_FormRight r" +
                                                                 " on r.FormID=u.FormID" +
                                                                 " left join dbo.Main_Module m " +
                                                                 " on m.ModuleID=r.ModuleID " +
                                                                 " where UserID='{0}' and m.GroupID='{1}' " +
                                                                 " order by m.{2}",
                                                              CurrentUser.UserID,
                                                              obj.GroupID_K,
                                                              modulename))
            If modules Is Nothing Then
                tvwSolution.Nodes(obj.GroupID_K).Remove()
                Continue For
            End If

            For Each m As Main_Module In modules
                Dim condition As String = " 1=1 "
                condition += " and UserID='" + CurrentUser.UserID + "'"
                Dim sqlForm As String = String.Format(" Select distinct r.* from {0} r left join {1} u " +
                                                                     " on r.FormID=u.FormID where ModuleID='{2}' and ((UserID='{3}' and SubModule='0') " +
                                                                     " or  ChildForm like '%00') order by r.[Order] ",
                                                                      PublicTable.Table_Main_FormRight,
                                                                      PublicTable.Table_Main_UserRight,
                                                                      m.ModuleID_K,
                                                                      CurrentUser.UserID)
                frm = _db.GetObjects(Of Main_FormRight)(sqlForm)

                Select Case PublicConst.Language
                    Case PublicConst.EnumLanguage.VietNam
                        tvwSolution.Nodes(obj.GroupID_K).Nodes.Add(m.ModuleID_K, m.ModuleNameV, indexModule, indexModule).Tag = m.ModuleID_K
                    Case PublicConst.EnumLanguage.English
                        tvwSolution.Nodes(obj.GroupID_K).Nodes.Add(m.ModuleID_K, m.ModuleNameE, indexModule, indexModule).Tag = m.ModuleID_K

                End Select

                If frm IsNot Nothing Then
                    For Each f As Main_FormRight In frm

                        Select Case PublicConst.Language
                            Case PublicConst.EnumLanguage.VietNam
                                tvwSolution.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Nodes.Add(f.FormID_K, f.TextVietNam, indexForm, indexSelectedForm).Tag = IIf(f.SubModule = "0", f.ModuleID, f.FormID_K)
                            Case PublicConst.EnumLanguage.English
                                tvwSolution.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Nodes.Add(f.FormID_K, f.TextEnglish, indexForm, indexSelectedForm).Tag = IIf(f.SubModule = "0", f.ModuleID, f.FormID_K)
                        End Select
                        If f.SubModule <> "0" Then
                            frmSub = _db.GetObjects(Of Main_FormRight)(String.Format(" Select distinct r.* from {0} r left join {1} u " +
                                                     " on r.FormID=u.FormID where ModuleID='{2}' and {3} and " +
                                                     " (ChildForm like '{4}%' and ChildForm not like '%00') order by r.ChildForm ",
                                                      PublicTable.Table_Main_FormRight,
                                                      PublicTable.Table_Main_UserRight,
                                                      m.ModuleID_K,
                                                      condition, f.SubModule))
                            If frmSub IsNot Nothing Then
                                For Each fsub As Main_FormRight In frmSub
                                    Select Case PublicConst.Language
                                        Case PublicConst.EnumLanguage.VietNam
                                            tvwSolution.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Nodes(f.FormID_K).Nodes.Add(fsub.FormID_K, fsub.TextVietNam, indexForm, indexSelectedForm).Tag = f.FormID_K
                                        Case PublicConst.EnumLanguage.English
                                            tvwSolution.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Nodes(f.FormID_K).Nodes.Add(fsub.FormID_K, fsub.TextEnglish, indexForm, indexSelectedForm).Tag = f.FormID_K
                                    End Select
                                Next
                            Else
                                If tvwSolution.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Nodes(f.FormID_K).Nodes.Count = 0 Then
                                    tvwSolution.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Nodes(f.FormID_K).Remove()
                                End If
                            End If
                        End If
                    Next
                Else
                    If tvwSolution.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Nodes.Count = 0 Then
                        tvwSolution.Nodes(obj.GroupID_K).Nodes(m.ModuleID_K).Remove()
                    End If
                End If
            Next
        Next

        tvwSolution.CollapseAll()
        If CurrentUser.SortSection = "IT" Then
            tvwSolution.Nodes(0).Expand()
            tvwSolution.Nodes(1).Expand()
        Else
            tvwSolution.Nodes(0).Expand()
        End If

        'If tvwSolution.Nodes.Count > 0 Then
        '    For Each tnode As TreeNode In tvwSolution.Nodes
        '        For Each cnode As TreeNode In tnode.Nodes
        '            cnode.Collapse()
        '        Next
        '    Next
        '    tvwSolution.SelectedNode = tvwSolution.Nodes(0)
        'End If
    End Sub


    Private Sub tvwSolution_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvwSolution.NodeMouseDoubleClick
        If e.Node.Level >= 2 And e.Node.Nodes.Count = 0 Then
            clsMain.fMain.ShowNewForm(e.Node.Tag, e.Node.Name, "")
        End If
    End Sub

    Private Sub mnuOpen_Click(sender As System.Object, e As System.EventArgs) Handles mnuOpen.Click
        Dim node As TreeNode
        If tvwSolution.SelectedNode IsNot Nothing Then
            node = tvwSolution.SelectedNode
            If node.Nodes.Count = 0 And node.Level >= 2 Then
                clsMain.fMain.ShowNewForm(node.Tag, node.Name, "")
            End If
        End If
    End Sub

#End Region


    Private Sub mnuHDSD_Click(sender As System.Object, e As System.EventArgs) Handles mnuHDSD.Click
        Dim frm As New FrmModuleDocument
        frm._idModule = tvwSolution.SelectedNode.Tag
        frm._ModuleName = ""
        frm.Show()
    End Sub
End Class