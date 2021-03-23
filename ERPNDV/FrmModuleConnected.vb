Imports LibEntity
Imports PublicUtility

Public Class FrmModuleConnected : Inherits DevExpress.XtraEditors.XtraForm
    Dim db As DBSql = New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)



    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click
        Try
            If ShowQuestionDelete() = Windows.Forms.DialogResult.No Then Return
            db.BeginTransaction()
            Dim count As Integer = 0
            For Each row As DataGridViewRow In grid.SelectedRows
                Dim obj As New Main_Module
                obj.ModuleID_K = row.Cells("ModuleID").Value
                count += db.Delete(obj)
            Next
            db.Commit()
            mnuShowAll.PerformClick()
        Catch ex As Exception
            db.RollBack()
            ShowError(ex, "mnuDelete_Click", Name)
        End Try
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        db.ExecuteStoreProcedure("sp_Main_InsertModuleConnected")
        Dim sql As String = String.Format(" select * from Main_ModuleConnect    ")
        Dim bdsource As New BindingSource
        bdsource.DataSource = db.FillDataTable(sql)
        grid.DataSource = bdsource
    End Sub

    Private Sub mnuAllow_Click(sender As System.Object, e As System.EventArgs) Handles mnuAllow.Click
        Try
            If ShowQuestionDelete() = Windows.Forms.DialogResult.No Then Return
            db.BeginTransaction()
            Dim count As Integer = 0
            For Each row As DataGridViewRow In grid.SelectedRows
                Dim obj As New Main_ModuleConnect
                obj.AssemblyFile_K = row.Cells("AssemblyFile").Value
                db.GetObject(obj)
                obj.Connected = True
                count += db.Update(obj)
            Next
            db.Commit()
            mnuShowAll.PerformClick()
        Catch ex As Exception
            db.RollBack()
            ShowError(ex, "mnuDelete_Click", Name)
        End Try
    End Sub

    Private Sub mnuLocked_Click(sender As System.Object, e As System.EventArgs) Handles mnuLocked.Click
        Try
            If ShowQuestionLock() = Windows.Forms.DialogResult.No Then Return
            db.BeginTransaction()
            Dim count As Integer = 0
            For Each row As DataGridViewRow In grid.SelectedRows
                Dim obj As New Main_ModuleConnect
                obj.AssemblyFile_K = row.Cells("AssemblyFile").Value
                db.GetObject(obj)
                obj.Connected = False
                count += db.Update(obj)
            Next
            db.Commit()
            mnuShowAll.PerformClick()
        Catch ex As Exception
            db.RollBack()
            ShowError(ex, "mnuDelete_Click", Name)
        End Try
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub

    Private Sub txtModuleID_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtModuleID.TextChanged
        If grid.RowCount > 0 Then
            If txtModuleID.Text <> "" Then
                bdn.BindingSource.Filter = String.Format(" Assamblyfile like ''%{0}% ", txtModuleID.Text)
            Else
                bdn.BindingSource.Filter = ""
            End If
        End If
    End Sub

    Private Sub txtModuleV_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtModuleV.TextChanged
        If grid.RowCount > 0 Then
            If txtModuleV.Text <> "" Then
                bdn.BindingSource.Filter = String.Format(" Assamblyfile like ''%{0}% ", txtModuleV.Text)
            Else
                bdn.BindingSource.Filter = ""
            End If
        End If
    End Sub

    Private Sub FrmModuleConnected_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub

    Private Sub mnuEdit_Click(sender As System.Object, e As System.EventArgs) Handles mnuEdit.Click
        grid.Columns("ModuleName").ReadOnly = Not grid.Columns("ModuleName").ReadOnly
        grid.Columns("Note").ReadOnly = Not grid.Columns("Note").ReadOnly
    End Sub

    Private Sub grid_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellValueChanged
        If e.RowIndex >= 0 Then
            Dim obj As New Main_ModuleConnect
            obj.AssemblyFile_K = grid.CurrentRow.Cells("Assemblyfile").Value
            db.GetObject(obj)
            obj.ModuleName = grid.CurrentRow.Cells("ModuleName").Value
            If grid.CurrentRow.Cells("Note").Value IsNot DBNull.Value Then
                obj.Note = grid.CurrentRow.Cells("Note").Value
            Else
                obj.Note = ""
            End If
            db.Update(obj)
        End If
    End Sub
End Class