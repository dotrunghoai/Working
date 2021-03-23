Imports System.Windows.Forms
Imports System.Windows.Forms.Form
Imports LibEntity

Imports PublicUtility
Imports CommonDB
Imports DevExpress.Skins
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars.Docking2010.Views
''' <summary>
''' Author: Truong Minh Tam (IT-Nitto Denko)
''' Date: 25-Aug-2011
''' </summary>
''' <remarks></remarks>

Public Class MultiLanguage
    Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _frm As Form

    Sub AddControl(ByVal controlName As String, ByVal controlTex As String, ByVal parent As String, ByVal controlType As String)
        If controlName <> "" And _frm.Tag <> "" And
            controlTex <> "" And controlType <> "TextBox" And controlType <> "RichTextBox" And
            controlType <> "DateTimePicker" And controlType <> "ComboBox" Then
            Dim obj As New Main_Language
            obj.ControlName_K = controlName
            obj.FormName = _frm.Name
            obj.FormID_K = _frm.Tag

            obj.IsTranslate = True
            obj.Parent = parent
            obj.TextChina = controlTex
            obj.TextEnglish = controlTex
            obj.TextJapan = controlTex
            obj.TextVietNam = controlTex
            If Not db.ExistObject(obj) Then
                db.Insert(obj)
            End If

        End If
    End Sub

    Sub AddControlPermission(ByVal controlName As String, ByVal controlText As String)
        If controlName <> "" And _frm.Tag <> "" Then
            Dim obj As New Main_ControlRight
            obj.ControlName_K = controlName
            obj.ControlText = controlText
            obj.FormID_K = _frm.Tag
            If Not db.ExistObject(obj) Then
                db.Insert(obj)
            End If
        End If
    End Sub

    Sub SetPermissionControl(ByRef control As ToolStripItem)
        If CurrentUser.UserName = "admin" Then Return

        Dim obj As New Main_UserRightDetail
        obj.ControlName_K = control.Name
        obj.FormID_K = _frm.Tag
        obj.UserID_K = CurrentUser.UserID
        db.GetObject(obj)
        If obj.CreateUser <> "" Then
            'control.Visible = True
            control.Enabled = True
        Else
            'control.Visible = False
            control.Enabled = False
        End If
    End Sub

    'Sub SetLanguage(ByRef control As Control)
    '    Dim obj As New Main_Language
    '    obj.ControlName_K = control.Name
    '    obj.FormID_K = _frm.Tag
    '    db.GetObject(obj)
    '    If obj.IsTranslate Then
    '        Select Case PublicConst.Language
    '            Case PublicConst.EnumLanguage.China
    '                control.Text = obj.TextChina
    '            Case PublicConst.EnumLanguage.English
    '                control.Text = obj.TextEnglish
    '            Case PublicConst.EnumLanguage.Japan
    '                control.Text = obj.TextJapan
    '            Case PublicConst.EnumLanguage.VietNam
    '                control.Text = obj.TextVietNam
    '        End Select
    '    End If
    'End Sub

    'Sub SetLanguage(ByRef control As ToolStripItem)
    '    Dim obj As New Main_Language
    '    obj.ControlName_K = control.Name
    '    obj.FormID_K = _frm.Tag
    '    db.GetObject(obj)
    '    If obj.IsTranslate Then
    '        Select Case PublicConst.Language
    '            Case PublicConst.EnumLanguage.China
    '                control.Text = obj.TextChina
    '            Case PublicConst.EnumLanguage.English
    '                control.Text = obj.TextEnglish
    '            Case PublicConst.EnumLanguage.Japan
    '                control.Text = obj.TextJapan
    '            Case PublicConst.EnumLanguage.VietNam
    '                control.Text = obj.TextVietNam
    '        End Select
    '    End If
    'End Sub

    'Sub SetLanguage(ByRef control As ToolStripMenuItem)
    '    Dim obj As New Main_Language
    '    obj.ControlName_K = control.Name
    '    obj.FormID_K = _frm.Tag
    '    db.GetObject(obj)
    '    If obj.IsTranslate Then
    '        Select Case PublicConst.Language
    '            Case PublicConst.EnumLanguage.China
    '                control.Text = obj.TextChina
    '            Case PublicConst.EnumLanguage.English
    '                control.Text = obj.TextEnglish
    '            Case PublicConst.EnumLanguage.Japan
    '                control.Text = obj.TextJapan
    '            Case PublicConst.EnumLanguage.VietNam
    '                control.Text = obj.TextVietNam
    '        End Select
    '    End If
    'End Sub

    'Sub SetLanguage(ByRef control As DataGridViewColumn)
    '    Dim obj As New Main_Language
    '    obj.ControlName_K = control.Name
    '    obj.FormID_K = _frm.Tag
    '    db.GetObject(obj)
    '    If obj.IsTranslate Then
    '        Select Case PublicConst.Language
    '            Case PublicConst.EnumLanguage.China
    '                control.HeaderText = obj.TextChina
    '            Case PublicConst.EnumLanguage.English
    '                control.HeaderText = obj.TextEnglish
    '            Case PublicConst.EnumLanguage.Japan
    '                control.HeaderText = obj.TextJapan
    '            Case PublicConst.EnumLanguage.VietNam
    '                control.HeaderText = obj.TextVietNam
    '        End Select
    '    End If
    'End Sub

    Sub SetLanguage(ByRef frm As DevExpress.XtraEditors.XtraForm)
        Dim obj As New Main_FormRight
        obj = db.GetObject(Of Main_FormRight)(String.Format("select top 1 * from {0} where FormID='{1}' ",
                                   PublicTable.Table_Main_FormRight, frm.Tag))
        Select Case PublicConst.Language
            Case PublicConst.EnumLanguage.China
                frm.Text = obj.TextChina
            Case PublicConst.EnumLanguage.English
                frm.Text = obj.TextEnglish
            Case PublicConst.EnumLanguage.Japan
                frm.Text = obj.TextJapan
            Case PublicConst.EnumLanguage.VietNam
                frm.Text = obj.TextVietNam
        End Select

    End Sub

    Public Sub ShowLanguage(ByRef frm As XtraForm, ByVal frmID As String)
        _frm = frm
        SetLanguage(frm)
        For Each ctrl As Control In frm.Controls
            If ctrl.GetType().Name = "ToolStrip" Then
                AddControl(ctrl.Name, ctrl.Text, ctrl.Parent.Name, ctrl.GetType().Name)
                'SetLanguage(ctrl)
                FindToolStrip(ctrl)
                'ElseIf ctrl.GetType().Name = "MenuStrip" Then
                '    FindMenuStrip(ctrl)
                'ElseIf ctrl.GetType().Name = "DataGridView" Then
                '    FindGridColumn(ctrl)
                'ElseIf ctrl.GetType().Name = "StatusStrip" Then
                '    FindStatusStrip(ctrl)
                'Else
                '    FindControl(ctrl)
            End If

        Next


    End Sub

    Public Sub ShowLanguage(ByRef frm As BaseDocumentCollection)
        For Each f As BaseDocument In frm
            ShowLanguage(f.Form, f.Tag)
        Next
    End Sub

    Sub FindControl(ByRef control As Control)
        For Each ctrl As Control In control.Controls
            AddControl(ctrl.Name, ctrl.Text, control.Name, ctrl.GetType().Name)
            'SetLanguage(ctrl)
            If ctrl.GetType().Name = "ToolStrip" Then
                FindToolStrip(ctrl)
                'ElseIf ctrl.GetType().Name = "MenuStrip" Then
                '    FindMenuStrip(ctrl)
                'ElseIf ctrl.GetType().Name = "DataGridView" Or ctrl.GetType().Name = "CustomDataGridView" Then
                '    FindGridColumn(ctrl)
                'ElseIf ctrl.GetType().Name = "StatusStrip" Then
                '    FindStatusStrip(ctrl)
                'Else
                '    FindControl(ctrl)
            End If
        Next
    End Sub

    Sub FindStatusStrip(ByRef statusStrip As StatusStrip)
        For Each ctrl As ToolStripItem In statusStrip.Items
            AddControl(ctrl.Name, ctrl.Text, statusStrip.Name, ctrl.GetType().Name)
            'SetLanguage(ctrl)
        Next

    End Sub

    Sub FindToolStrip(ByRef tlstrip As ToolStrip)
        For Each ctrl As ToolStripItem In tlstrip.Items
            AddControl(ctrl.Name, ctrl.Text, tlstrip.Name, ctrl.GetType().Name)
            AddControlPermission(ctrl.Name, ctrl.Text)
            'SetLanguage(ctrl)
            SetPermissionControl(ctrl)
        Next

    End Sub

    Sub FindMenuStrip(ByRef mnuStrip As MenuStrip)
        For Each ctrl As ToolStripMenuItem In mnuStrip.Items
            AddControl(ctrl.Name, ctrl.Text, mnuStrip.Name, ctrl.GetType().Name)
            'SetLanguage(ctrl)
            FindChildMenuTrip(ctrl)
        Next
    End Sub

    Sub FindChildMenuTrip(ByRef childMenu As ToolStripMenuItem)
        For Each ctrl As ToolStripItem In childMenu.DropDownItems
            AddControl(ctrl.Name, ctrl.Text, childMenu.Name, ctrl.GetType().Name)
            'SetLanguage(ctrl)
            If ctrl.GetType().Name = "ToolStripMenuItem" Then
                FindChildMenuTrip(ctrl)
            End If
        Next
    End Sub

    Sub FindGridColumn(ByRef grid As DataGridView)
        'For Each ctrl As DataGridViewColumn In grid.Columns
        '    AddControl(ctrl.Name, ctrl.HeaderText, grid.Name, ctrl.GetType().Name)
        '    'SetLanguage(ctrl)
        'Next
    End Sub

End Class
