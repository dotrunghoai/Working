Imports System.Windows.Forms
Imports CommonDB
Imports PublicUtility

Imports LibEntity

Public Class FrmDefine : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)


    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If bdn.BindingSource IsNot Nothing Then
            If txtSearch.Text = "" Then
                bdn.BindingSource.Filter = ""
            Else
                bdn.BindingSource.Filter = String.Format(" ProductCode like '%{0}%' or Process like '%{0}%'   ", txtSearch.Text)
            End If
        End If
    End Sub

    Private Sub MnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
        Dim sql As String = String.Format("sp_QCS_LoadDefine")
        Dim bdsource As New BindingSource
        bdsource.DataSource = _db.ExecuteStoreProcedureTB(sql)
        bdn.BindingSource = bdsource
        grid.DataSource = bdsource
        grid.AutoGenerateColumns = False
    End Sub

    Private Sub MnuExport_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub

    Private Sub MnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        If grid.CurrentRow IsNot Nothing Then
            If ShowQuestionDelete() = DialogResult.Yes Then

                For Each r As DataGridViewRow In grid.SelectedRows
                    _db.ExecuteNonQuery(String.Format(" delete from QCS_Define " +
                                                  " where ProductCode='{0}' or Process='{1}' ",
                grid.CurrentRow.Cells(ProductCode.Name).Value,
                                                     grid.CurrentRow.Cells(Process.Name).Value
                                                    ))

                Next
                ShowSuccess()
                mnuShowAll.PerformClick()
            End If
        End If
    End Sub

    Private Sub MnuSave_Click(sender As Object, e As EventArgs) Handles mnuImport.Click
        Dim dtData As DataTable = ImportEXCEL(True)
        If dtData.Rows.Count > 0 Then
            Dim stt As Integer = 0
            For Each r As DataRow In dtData.Rows
                If r(ProductCode.Name) IsNot DBNull.Value Then
                    Dim obj As New QCS_Define
                    obj.Process_K = r(Process.Name)
                    obj.ProductCode_K = r(ProductCode.Name)
                    obj.Item_K = r("Item")
                    obj.N = r("N")
                    obj.Spec = r("Spec")
                    obj.UTL = r("UTL")
                    obj.LTL = r("LTL")
                    obj.USL = r("USL")
                    obj.LSL = r("LSL")
                    obj.UTLMC = r("UTLMC")
                    obj.LTLMC = r("LTLMC")
                    obj.UMC = r("UMC")
                    obj.LMC = r("LMC")
                    If IsNumeric(r("CPK")) Then
                        obj.CPK = r("CPK")
                    End If
                    If IsNumeric(r("CPM")) Then
                        obj.CPM = r("CPM")
                    End If
                    obj.CreateDate = DateTime.Now
                    obj.CreateUser = CurrentUser.UserID
                    If _db.ExistObject(obj) Then
                        _db.Update(obj)
                    Else
                        _db.Insert(obj)
                    End If
                    stt += 1
                End If
            Next
            ShowSuccess(stt)
        Else
            ShowWarningNotDataImport()
        End If
    End Sub

    Private Sub FrmDefine_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub

    Private Sub MnuView_Click(sender As Object, e As EventArgs) Handles mnuView.Click
        If grid.CurrentRow IsNot Nothing Then
            Dim frm As New FrmDefineDetail
            frm._mPdCode = grid.CurrentRow.Cells(ProductCode.Name).Value
            frm._mProcess = grid.CurrentRow.Cells(Process.Name).Value
            frm.Show()
        End If
    End Sub

    Private Sub Grid_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grid.CellMouseDoubleClick
        mnuView.PerformClick()
    End Sub
End Class