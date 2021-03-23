Imports CommonDB
Imports LibEntity
Imports PublicUtility

Public Class FrmForm : Inherits DevExpress.XtraEditors.XtraForm
#Region "Variable"
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
#End Region

#Region "User function"

    Sub LoadModuleGroup()
        Dim sql As String = String.Format("select * from {0} order by ModuleNameV", PublicTable.Table_Main_Module)
        cboModuleName.DataSource = _db.FillDataTable(sql)
        cboModuleName.ValueMember = "ModuleID"

        Select Case PublicConst.Language
            Case PublicConst.EnumLanguage.China
                cboModuleName.DisplayMember = "ModuleNameC"
            Case PublicConst.EnumLanguage.English
                cboModuleName.DisplayMember = "ModuleNameE"
            Case PublicConst.EnumLanguage.Japan
                cboModuleName.DisplayMember = "ModuleNameJ"
            Case PublicConst.EnumLanguage.VietNam
                cboModuleName.DisplayMember = "ModuleNameV"
        End Select
    End Sub

#End Region

#Region "Form function"

    Private Sub mnuNew_Click(sender As System.Object, e As System.EventArgs) Handles mnuNew.Click
        'txtFormNameC.Text = ""
        'txtFormNameE.Text = ""
        'txtFormID.Text = ""
        'txtFormNameJ.Text = ""
        'txtFormNameV.Text = ""
        'txtFormName.Text = ""
        'cboModuleName.Focus()

        GridControlReadOnly(GridView1, False)
        GridView1.Columns("FormID").OptionsColumn.ReadOnly = True
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub FrmModule_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        LoadModuleGroup()
    End Sub

    Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click

        If txtModuleID.Text = "" Then
            ShowWarningNotNull("ModuleID")
            txtFormID.Focus()
            Return
        End If
        If cboModuleName.SelectedIndex < 0 Then
            ShowWarningNotNull("ModuleName")
            txtModuleID.Focus()
            Return
        End If
        If txtFormID.Text = "" Then
            ShowWarningNotNull("FormID")
            txtFormID.Focus()
            Return
        End If
        If txtFormName.Text = "" Then
            ShowWarningNotNull("FormName")
            txtFormName.Focus()
            Return
        End If

        If ShowQuestionSave() = Windows.Forms.DialogResult.No Then Exit Sub

        Try
            Dim obj As New Main_FormRight
            obj.ModuleID = txtModuleID.Text
            obj.FormID_K = txtFormID.Text
            obj.FormName = txtFormName.Text
            obj.TextChina = txtFormNameC.Text
            obj.TextJapan = txtFormNameJ.Text
            obj.TextVietNam = txtFormNameV.Text
            obj.TextEnglish = txtFormNameE.Text
            obj.SubModule = 0

            If _db.ExistObject(obj) Then
                _db.Update(obj)
            Else
                _db.Insert(obj)
            End If

            mnuShowAll.PerformClick()
        Catch ex As Exception
            ShowError(ex, "mnuSave_Click", Me.Name)
        End Try
    End Sub

    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click

        If GridView1.GetSelectedRows.Count > 0 Then
            Try
                If ShowQuestionDelete() = Windows.Forms.DialogResult.No Then Return

                _db.BeginTransaction()

                Dim para(0) As SqlClient.SqlParameter
                Dim obj As New Main_FormRight
                obj.FormID_K = GridView1.GetFocusedRowCellValue("FormID")
                obj.ModuleID = GridView1.GetFocusedRowCellValue("ModuleID")
                _db.Delete(obj)
                _db.Commit()
                mnuShowAll.PerformClick()

                ShowSuccess()
            Catch ex As Exception
                _db.RollBack()
                ShowError(ex, "mnuDelete_Click", Me.Name)
            End Try
        End If
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim condition As String = " 1=1 "
        If txtModuleID.Text <> "" Then condition += String.Format(" and ModuleID ='{0}' ", txtModuleID.Text)
        Dim sql As String = String.Format(" select * from {0}  where {1} order by SubModule,ChildForm ",
                                          PublicTable.Table_Main_FormRight,
                                          condition)
        GridControl1.DataSource = _db.FillDataTable(sql)
        GridControlSetFormat(GridView1, 4)
        GridControlSetBestfit(GridView1, 100)
    End Sub

    Private Sub FrmForm_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{Tab}")

        If e.KeyCode = Keys.N And e.Control Then
            mnuNew.PerformClick()
        End If
        If e.KeyCode = Keys.S And e.Control Then
            mnuSave.PerformClick()
        End If
        If e.KeyCode = Keys.D And e.Control Then
            mnuDelete.PerformClick()
        End If
        If e.KeyCode = Keys.F5 Then
            mnuShowAll.PerformClick()
        End If
    End Sub

    Private Sub cpoModuleName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboModuleName.SelectedIndexChanged
        If cboModuleName.SelectedIndex >= 0 And cboModuleName.DisplayMember <> "" And cboModuleName.ValueMember <> "" Then
            txtModuleID.Text = cboModuleName.SelectedValue
        End If
    End Sub

    Private Sub txtModuleID_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtModuleID.TextChanged
        If cboModuleName.DisplayMember <> "" And cboModuleName.ValueMember <> "" Then
            cboModuleName.SelectedValue = txtModuleID.Text
        End If
    End Sub


    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.ReadOnly = False And GridView1.Editable Then
            Dim obj As New Main_FormRight With {
                .FormID_K = GridView1.GetFocusedRowCellValue("FormID")
            }
            If GridView1.GetFocusedRowCellValue("FormName") IsNot DBNull.Value Then obj.FormName = GridView1.GetFocusedRowCellValue("FormName")
            If GridView1.GetFocusedRowCellValue("ModuleID") IsNot DBNull.Value Then obj.ModuleID = GridView1.GetFocusedRowCellValue("ModuleID")
            If GridView1.GetFocusedRowCellValue("Order") IsNot DBNull.Value Then obj.Order = GridView1.GetFocusedRowCellValue("Order")
            If GridView1.GetFocusedRowCellValue("TextChina") IsNot DBNull.Value Then obj.TextChina = GridView1.GetFocusedRowCellValue("TextChina")
            If GridView1.GetFocusedRowCellValue("TextEnglish") IsNot DBNull.Value Then obj.TextEnglish = GridView1.GetFocusedRowCellValue("TextEnglish")
            If GridView1.GetFocusedRowCellValue("TextJapan") IsNot DBNull.Value Then obj.TextJapan = GridView1.GetFocusedRowCellValue("TextJapan")
            If GridView1.GetFocusedRowCellValue("TextVietNam") IsNot DBNull.Value Then obj.TextVietNam = GridView1.GetFocusedRowCellValue("TextVietNam")
            If GridView1.GetFocusedRowCellValue("AssemblyName") IsNot DBNull.Value Then obj.AssemblyName = GridView1.GetFocusedRowCellValue("AssemblyName")
            If GridView1.GetFocusedRowCellValue("SubModule") IsNot DBNull.Value Then obj.SubModule = GridView1.GetFocusedRowCellValue("SubModule")
            If GridView1.GetFocusedRowCellValue("ChildForm") IsNot DBNull.Value Then obj.ChildForm = GridView1.GetFocusedRowCellValue("ChildForm")
            If GridView1.GetFocusedRowCellValue("Translate") IsNot DBNull.Value Then obj.Translate = GridView1.GetFocusedRowCellValue("Translate")
            If _db.ExistObject(obj) Then
                _db.Update(obj)
            Else
                _db.Insert(obj)
            End If

        End If
    End Sub
#End Region

End Class