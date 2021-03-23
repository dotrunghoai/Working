
Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports System.Windows.Forms

Public Class FrmImportCodePP : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim sql As String = String.Format("select * from PCM_ImportCodePP ")
        Dim bd As New BindingSource()
        bd.DataSource = _db.FillDataTable(sql)
        bdn.BindingSource = bd
        grid.DataSource = bd
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub

    Private Sub mnuImport_Click(sender As System.Object, e As System.EventArgs) Handles mnuImport.Click
        Dim dataTB As DataTable = ImportEXCEL(True)
        _db.ExecuteNonQuery("delete from PCM_ImportCodePP")
        If dataTB.Rows.Count Then
            Dim index As Integer = 0
            For Each r As DataRow In dataTB.Rows
                Dim obj As New PCM_ImportCodePP
                obj.CodePP_K = r("ItemCode")
                obj.NamePP = r("ItemName")
                obj.UnitPP = r("Unit")
                If r("Note") IsNot DBNull.Value Then
                    obj.NotePP = r("Note")
                End If
                If _db.ExistObject(obj) Then
                    _db.Update(obj)
                Else
                    _db.Insert(obj)
                End If
                index += 1
            Next
            ShowSuccess(index)
        Else
            ShowWarning("Không có dữ liệu để import.")
        End If
    End Sub

    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click
        If grid.SelectedRows.Count > 0 Then
            If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
                For Each r As DataGridViewRow In grid.SelectedRows
                    Dim obj As New PCM_ImportCodePP
                    obj.CodePP_K = r.Cells("CodePP").Value
                    _db.Delete(obj)
                Next
                mnuShowAll.PerformClick()
            End If
        End If
    End Sub

    Private Sub txtItemCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtItemCode.TextChanged
        If bdn.BindingSource IsNot Nothing Then
            If txtItemCode.Text <> "" Then
                bdn.BindingSource.Filter = String.Format(" CodePP like '%{0}%' ", txtItemCode.Text)
            Else
                bdn.BindingSource.Filter = ""
            End If
        End If
    End Sub

  
    Private Sub txtItemName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtItemName.TextChanged
        If bdn.BindingSource IsNot Nothing Then
            If txtItemName.Text <> "" Then
                bdn.BindingSource.Filter = String.Format(" CodePP like '%{0}%' ", txtItemName.Text)
            Else
                bdn.BindingSource.Filter = ""
            End If
        End If
    End Sub
End Class