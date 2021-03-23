Imports CommonDB

Imports LibEntity
Imports PublicUtility

Public Class FrmLanguage : Inherits DevExpress.XtraEditors.XtraForm
#Region "Variable"
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
#End Region

#Region "User function"

    Sub LoadFormName(ByVal moduleID As String)
        Dim sql As String = String.Format(" select FormID,FormName from {0} where ModuleID='{1}' order by ModuleID",
                                          PublicTable.Table_Main_FormRight, moduleID)
        cboFormName.DataSource = _db.FillDataTable(sql)
        cboFormName.DisplayMember = "FormName"
        cboFormName.ValueMember = "FormID"
    End Sub
    Sub LoadModule()
        Dim moduleName As String = ""
        Select Case PublicConst.Language
            Case PublicConst.EnumLanguage.China
                moduleName = "ModuleNameC"
            Case PublicConst.EnumLanguage.English
                moduleName = "ModuleNameE"
            Case PublicConst.EnumLanguage.Japan
                moduleName = "ModuleNameJ"
            Case PublicConst.EnumLanguage.VietNam
                moduleName = "ModuleNameV"
        End Select

        Dim sql As String = String.Format("select ModuleID,{0} as ModuleName from {1} order by ModuleName ",
                                           moduleName, PublicTable.Table_Main_Module)
        cboModule.DataSource = _db.FillDataTable(sql)
        cboModule.DisplayMember = "ModuleName"
        cboModule.ValueMember = "ModuleID"
    End Sub

#End Region

#Region "Form function"

    Private Sub mnuNew_Click(sender As System.Object, e As System.EventArgs) Handles mnuNew.Click

        cboModule.Focus()

    End Sub

    Private Sub FrmLanguage_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown

        LoadModule()
    End Sub

    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click
        Dim datarow As DataGridViewSelectedRowCollection = grid.SelectedRows
        If datarow.Count > 0 Then
            Try
                If ShowQuestionDelete() = Windows.Forms.DialogResult.No Then Return

                _db.BeginTransaction()
                Dim count As Integer = 0
                For row As Integer = 0 To datarow.Count - 1
                    Dim obj As New Main_Language
                    obj.ControlName_K = datarow.Item(row).Cells("ControlName").Value
                    obj.FormID_K = datarow.Item(row).Cells("FormID").Value
                    count += _db.Delete(obj)
                Next

                _db.Commit()
                mnuShowAll.PerformClick()
                ShowSuccess(count)
            Catch ex As Exception
                _db.RollBack()
                ShowError(ex, "mnuDelete_Click", Me.Name)
            End Try
        End If
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim condition As String = " 1=1 "
        condition += String.Format(" and FormID ='{0}' ", cboFormName.SelectedValue)

        Dim sql As String = String.Format("Select [FormID] " +
                                         " ,[FormName] " +
                                         " ,[ControlName] " +
                                         " ,[TextEnglish] " +
                                         " ,[TextVietNam] " +
                                         " ,[TextChina] " +
                                         " ,[TextJapan] " +
                                         " ,[Parent] " +
                                         " ,[IsTranslate] from {0} where {1} ",
                                          PublicTable.Table_Main_Language,
                                          condition)
        Dim bdsource As New BindingSource
        bdsource.DataSource = _db.FillDataTable(sql)
        grid.DataSource = bdsource
        BindingNavigator1.BindingSource = bdsource

        grid.AutoResizeColumns()
    End Sub


    Private Sub FrmLanguage_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{Tab}")
        If e.KeyCode = Keys.N And e.Control And mnuNew.Enabled Then
            mnuNew.PerformClick()
        End If
        'If e.KeyCode = Keys.S And e.Control Then
        '    mnuSave.PerformClick()
        'End If
        If e.KeyCode = Keys.D And e.Control And mnuDelete.Enabled Then
            mnuDelete.PerformClick()
        End If
        If e.KeyCode = Keys.F5 And mnuShowAll.Enabled Then
            mnuShowAll.PerformClick()
        End If
    End Sub

    Private Sub grid_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellValueChanged
        If grid.CurrentRow IsNot Nothing Then
            If e.RowIndex >= 0 Then
                Dim obj As New Main_Language
                obj.ControlName_K = grid.Item("ControlName", e.RowIndex).Value
                obj.FormID_K = grid.Item("FormID", e.RowIndex).Value

                If grid.Item("FormName", e.RowIndex).Value IsNot DBNull.Value Then obj.FormName = grid.Item("FormName", e.RowIndex).Value
                If grid.Item("IsTranslate", e.RowIndex).Value IsNot DBNull.Value Then obj.IsTranslate = grid.Item("IsTranslate", e.RowIndex).Value
                If grid.Item("Parent", e.RowIndex).Value IsNot DBNull.Value Then obj.Parent = grid.Item("Parent", e.RowIndex).Value
                If grid.Item("TextChina", e.RowIndex).Value IsNot DBNull.Value Then obj.TextChina = grid.Item("TextChina", e.RowIndex).Value
                If grid.Item("TextEnglish", e.RowIndex).Value IsNot DBNull.Value Then obj.TextEnglish = grid.Item("TextEnglish", e.RowIndex).Value
                If grid.Item("TextJapan", e.RowIndex).Value IsNot DBNull.Value Then obj.TextJapan = grid.Item("TextJapan", e.RowIndex).Value
                If grid.Item("TextVietNam", e.RowIndex).Value IsNot DBNull.Value Then obj.TextVietNam = grid.Item("TextVietNam", e.RowIndex).Value

                _db.Update(obj)
            End If
        End If
    End Sub

    Private Sub grid_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellClick
        If e.ColumnIndex = grid.Columns("IsTranslate").Index Then

            If grid.CurrentCell.Value Is DBNull.Value Then
                grid.CurrentCell.Value = False
            Else
                grid.CurrentCell.Value = True
            End If
        End If
    End Sub
    Private Sub cboModule_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboModule.SelectedIndexChanged
        If cboModule.SelectedIndex >= 0 And cboModule.DisplayMember <> "" And cboModule.ValueMember <> "" Then
            LoadFormName(cboModule.SelectedValue)
        End If
    End Sub
#End Region
  
End Class