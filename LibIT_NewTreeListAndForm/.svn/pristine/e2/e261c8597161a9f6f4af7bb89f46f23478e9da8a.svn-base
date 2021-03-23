Imports System.Drawing
Imports CommonDB
Imports PublicUtility

Public Class FrmShowAuthorizedUser
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmTreeListShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowTreeList()
    End Sub
    Sub ShowTreeList()
        TreeList1.DataSource = _db.FillDataTable(
            String.Format("SELECT h.FormID AS ID, d.ParentID, d.AssemblyName, d.FormName,
                            d.TextVietNam, d.TextEnglish, d.TextJapan, d.TextChina
                            FROM Main_UserRight AS h
                            LEFT JOIN Main_FormRight AS d
                            ON h.FormID = d.FormID
                            WHERE h.UserID = '{0}'
                            Order By TextVietNam",
                            CurrentUser.UserID))
        TreeList1.CollapseAll()
        TreeList1.ExpandToLevel(0)
        TreeList1.StateImageList = ImageCollection1
        Select Case PublicConst.Language
            Case PublicConst.EnumLanguage.VietNam
                TreeList1.Columns("TextVietNam").Visible = True
                TreeList1.Columns("TextEnglish").Visible = False
                TreeList1.Columns("TextJapan").Visible = False
                TreeList1.Columns("TextChina").Visible = False
            Case PublicConst.EnumLanguage.English
                TreeList1.Columns("TextEnglish").Visible = True
                TreeList1.Columns("TextVietNam").Visible = False
                TreeList1.Columns("TextJapan").Visible = False
                TreeList1.Columns("TextChina").Visible = False
            Case PublicConst.EnumLanguage.Japan
                TreeList1.Columns("TextJapan").Visible = True
                TreeList1.Columns("TextVietNam").Visible = False
                TreeList1.Columns("TextEnglish").Visible = False
                TreeList1.Columns("TextChina").Visible = False
            Case PublicConst.EnumLanguage.China
                TreeList1.Columns("TextChina").Visible = True
                TreeList1.Columns("TextVietNam").Visible = False
                TreeList1.Columns("TextEnglish").Visible = False
                TreeList1.Columns("TextJapan").Visible = False
        End Select
        TreeList1.Columns("AssemblyName").Visible = False
        TreeList1.Columns("FormName").Visible = False
        If TreeList1.FindNodeByKeyID("0000000003") IsNot Nothing Then
            TreeList1.FindNodeByKeyID("0000000003").Expanded = True
        End If
    End Sub

    Private Sub TreeList1_GetStateImage(sender As Object, e As DevExpress.XtraTreeList.GetStateImageEventArgs) Handles TreeList1.GetStateImage
        If e.Node.Focused Then
            e.NodeImageIndex = 3
        ElseIf e.Node.ParentNode Is Nothing Then
            e.NodeImageIndex = 0
        ElseIf e.Node.HasChildren Then
            e.NodeImageIndex = 1
        Else
            e.NodeImageIndex = 2
        End If
    End Sub

    Private Sub TreeList1_DoubleClick(sender As Object, e As EventArgs) Handles TreeList1.DoubleClick
        If TreeList1.FocusedNode.HasChildren = False And
               Not IsDBNull(TreeList1.FocusedNode.GetValue("AssemblyName")) And
               Not IsDBNull(TreeList1.FocusedNode.GetValue("FormName")) Then
            ShowNewForm(TreeList1.FocusedNode.GetValue("ID"), "")
        End If
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs)
        ShowTreeList()
    End Sub

    Private Sub btnSetting_Click(sender As Object, e As EventArgs)
        'Dim dtEmp = _db.FillDataTable("SELECT UserID
        '                                FROM Main_User")
        'For Each j As DataRow In dtEmp.Rows
        '    Dim userID = j("UserID")
        '    Dim dtForm = _db.FillDataTable(
        '    String.Format("SELECT FormID
        '                    FROM Main_UserRight
        '                    WHERE UserID = '{0}'",
        '                    userID))
        '    For Each r As DataRow In dtForm.Rows
        '        'Loop1
        '        Dim parent1 = SearchParent(r("FormID"))
        '        If Not IsDBNull(parent1) Then
        '            ThemQuyenParent(userID, parent1)
        '            'Loop2
        '            Dim parent2 = SearchParent(parent1)
        '            If Not IsDBNull(parent2) Then
        '                ThemQuyenParent(userID, parent2)
        '                'Loop3
        '                Dim parent3 = SearchParent(parent2)
        '                If Not IsDBNull(parent3) Then
        '                    ThemQuyenParent(userID, parent3)
        '                    'Loop4
        '                    Dim parent4 = SearchParent(parent3)
        '                    If Not IsDBNull(parent4) Then
        '                        ThemQuyenParent(userID, parent4)
        '                        'Loop5
        '                        '----------
        '                    End If
        '                End If
        '            End If
        '        End If
        '    Next
        'Next
        'ShowSuccess()
    End Sub
    Function SearchParent(formID)
        Return _db.ExecuteScalar(
            String.Format("SELECT TOP 1 ParentID
                            FROM Main_FormRight
                            WHERE FormID = '{0}'", formID))
    End Function
    Sub ThemQuyenParent(userID, formID)
        Dim obj As New Main_UserRight
        obj.UserID_K = userID
        obj.FormID_K = formID
        obj.CreateUser = CurrentUser.UserID
        obj.CreateDate = DateTime.Now
        If Not _db.ExistObject(obj) Then
            _db.Insert(obj)
        End If
    End Sub

    Private Sub TreeList1_NodeCellStyle(sender As Object, e As DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs) Handles TreeList1.NodeCellStyle
        If e.Node.Focused Then
            e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            'e.Appearance.BackColor = ColorTranslator.FromHtml("#3993F5")
            'e.Appearance.ForeColor = Color.White
        End If
    End Sub
End Class