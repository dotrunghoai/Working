Imports CommonDB
Imports LibEntity
Imports PublicUtility
Imports PublicUtility.PublicConst

Public Class FrmModule : Inherits DevExpress.XtraEditors.XtraForm
    Dim db As DBSql
    Sub LoadModuleGroup()
        Dim sql As String = String.Format("select * from {0} ", PublicTable.Table_Main_ModuleGroup)
        cboGropName.DataSource = db.FillDataTable(sql)
        cboGropName.ValueMember = "GroupID"

        Select Case PublicConst.Language
            Case PublicConst.EnumLanguage.China
                cboGropName.DisplayMember = "GroupNameC"
            Case PublicConst.EnumLanguage.English
                cboGropName.DisplayMember = "GroupNameE"
            Case PublicConst.EnumLanguage.Japan
                cboGropName.DisplayMember = "GroupNameJ"
            Case PublicConst.EnumLanguage.VietNam
                cboGropName.DisplayMember = "GroupNameV"
        End Select

        txtMaxModuleID.Text = db.ExecuteScalar(" select max(moduleid) from [dbo].[Main_Module]")
    End Sub


    Private Sub mnuNew_Click(sender As System.Object, e As System.EventArgs) Handles mnuNew.Click
        txtModuleC.Text = ""
        txtModuleE.Text = ""
        txtModuleID.Text = ""
        txtModuleJ.Text = ""
        txtModuleV.Text = ""
        cboGropName.Focus()

    End Sub

    Private Sub FrmModule_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        db = New DBSql(EnumServers.NDV_SQL_ERP_NDV)
        LoadModuleGroup()
    End Sub

    Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click

        If cboGropName.SelectedIndex < 0 Then
            MessageBox.Show("GroupID is not null.", "Info")
            txtgropID.Focus()
            Return
        End If

        If txtModuleID.Text = "" Then
            MessageBox.Show("ModuleID is not null.", "Info")
            txtModuleID.Focus()
            Return
        End If

        Try
            Dim obj As New Main_Module
            obj.GroupID = txtgropID.Text
            obj.ModuleID_K = txtModuleID.Text
            obj.ModuleNameC = txtModuleC.Text
            obj.ModuleNameE = txtModuleE.Text
            obj.ModuleNameJ = txtModuleJ.Text
            obj.ModuleNameV = txtModuleV.Text

            If db.ExistObject(obj) Then
                db.Update(obj)
            Else
                db.Insert(obj)
            End If

            MessageBox.Show("Successfully.", " Save module")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save module")
        End Try
    End Sub

    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click
        Try
            If ShowQuestionDelete() = Windows.Forms.DialogResult.No Then Return

            db.BeginTransaction()
            Dim count As Integer = 0
            For Each row As Integer In GridView1.GetSelectedRows
                Dim obj As New Main_Module
                obj.ModuleID_K = GridView1.GetRowCellValue(row, "ModuleID")
                Dim sql As String = String.Format("delete FROM  [Main_FormRight] where [ModuleID]='{0}'",
                                                  obj.ModuleID_K)
                db.ExecuteNonQuery(sql)
                count += db.Delete(obj)
            Next
            db.Commit()
            mnuShowAll.PerformClick()
            ShowSuccess()
        Catch ex As Exception
            db.RollBack()
            ShowError(ex, "mnuDelete_Click", Name)
        End Try
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim condition As String = " 1=1 "
        If txtgropID.Text <> "" Then condition += String.Format(" and GroupID ='{0}' ", txtgropID.Text)
        If txtModuleID.Text <> "" Then condition += String.Format(" and ModuleID ='{0}' ", txtModuleID.Text)
        If txtModuleC.Text <> "" Then condition += String.Format(" and ModuleNameC like '%{0}%' ", txtModuleC.Text)
        If txtModuleE.Text <> "" Then condition += String.Format(" and ModuleNameE like '%{0}%' ", txtModuleE.Text)
        If txtModuleV.Text <> "" Then condition += String.Format(" and ModuleNameV like '%{0}%' ", txtModuleV.Text)
        If txtModuleJ.Text <> "" Then condition += String.Format(" and ModuleNameJ like '%{0}%' ", txtModuleJ.Text)

        Dim sql As String = String.Format(" select * from {0}  where {1} ",
                                          PublicTable.Table_Main_Module,
                                          condition)

        GridControl1.DataSource = db.FillDataTable(sql)
        GridControlSetFormat(GridView1, 3)
        GridControlSetColorReadonly(GridView1)
    End Sub

    Private Sub FrmModule_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub cpoGropName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGropName.SelectedIndexChanged
        If cboGropName.DisplayMember <> "" And cboGropName.ValueMember <> "" And cboGropName.SelectedIndex >= 0 Then
            txtgropID.Text = cboGropName.SelectedValue
        End If
    End Sub

    Private Sub txtgropID_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtgropID.TextChanged
        cboGropName.SelectedValue = txtgropID.Text
    End Sub

    Private Sub txtgropID_Enter(sender As System.Object, e As System.EventArgs) Handles txtgropID.Enter
        SetColorEnter(txtgropID)
    End Sub
    Private Sub txtgropID_Leave(sender As System.Object, e As System.EventArgs) Handles txtgropID.Leave
        SetColorLeave(txtgropID)
    End Sub

    Private Sub cpoGropName_Enter(sender As System.Object, e As System.EventArgs) Handles cboGropName.Enter
        SetColorEnter(cboGropName)
    End Sub
    Private Sub cpoGropName_Leave(sender As System.Object, e As System.EventArgs) Handles cboGropName.Leave
        SetColorLeave(cboGropName)
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.ReadOnly = False And GridView1.Editable Then
            Dim obj As New Main_Module With {
            .GroupID = GridView1.GetFocusedRowCellValue("GroupID"),
            .ModuleID_K = GridView1.GetFocusedRowCellValue("ModuleID")
            }

            If GridView1.GetFocusedRowCellValue("ModuleNameC") IsNot DBNull.Value Then obj.ModuleNameC = GridView1.GetFocusedRowCellValue("ModuleNameC")
            If GridView1.GetFocusedRowCellValue("ModuleNameE") IsNot DBNull.Value Then obj.ModuleNameE = GridView1.GetFocusedRowCellValue("ModuleNameE")
            If GridView1.GetFocusedRowCellValue("ModuleNameV") IsNot DBNull.Value Then obj.ModuleNameV = GridView1.GetFocusedRowCellValue("ModuleNameV")
            If GridView1.GetFocusedRowCellValue("ModuleNameJ") IsNot DBNull.Value Then obj.ModuleNameJ = GridView1.GetFocusedRowCellValue("ModuleNameJ")

            If GridView1.GetFocusedRowCellValue("Note") IsNot DBNull.Value Then
                obj.Note = GridView1.GetFocusedRowCellValue("Note")
            End If
            If GridView1.GetFocusedRowCellValue("Idx") IsNot DBNull.Value Then
                obj.Idx = GridView1.GetFocusedRowCellValue("Idx")
            End If

            db.Update(obj)
        End If
    End Sub
End Class