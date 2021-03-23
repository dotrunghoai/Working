Imports System.Windows.Forms
Imports CommonDB
Imports PublicUtility
Imports LibEntity

Public Class FrmDefineDetail : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Public _mPdCode As String = ""
    Public _mProcess As String = ""


    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If bdn.BindingSource IsNot Nothing Then
            If txtSearch.Text = "" Then
                bdn.BindingSource.Filter = ""
            Else
                bdn.BindingSource.Filter = String.Format(" ProductCode like '%{0}%' or Process like '%{0}%'  " +
                                                         " or Item like '%{0}%'", txtSearch.Text)
            End If
        End If
    End Sub

    Private Sub MnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
        Dim sql As String = String.Format("sp_QCS_LoadDefineDetail")
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@ProductCode", _mPdCode)
        para(1) = New SqlClient.SqlParameter("@Process", _mProcess)

        Dim bdsource As New BindingSource
        bdsource.DataSource = _db.ExecuteStoreProcedureTB(sql, para)
        bdn.BindingSource = bdsource
        grid.DataSource = bdsource
        grid.AutoGenerateColumns = False
    End Sub

    Private Sub MnuExport_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub

    Private Sub MnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        If grid.CurrentRow IsNot Nothing Then
            For Each r As DataGridViewRow In grid.SelectedRows
                Dim obj As New QCS_Define
                obj.Process_K = grid.CurrentRow.Cells(Process.Name).Value
                obj.ProductCode_K = grid.CurrentRow.Cells(ProductCode.Name).Value
                obj.Item_K = grid.CurrentRow.Cells(Item.Name).Value
                _db.Delete(obj)
            Next
            ShowSuccess()
            mnuShowAll.PerformClick()
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
                    obj.Item_K = r(Item.Name)
                    obj.N = r(N.Name)
                    obj.Spec = r(Spec.Name)
                    obj.UTL = r(UTL.Name)
                    obj.LTL = r(LTL.Name)
                    obj.USL = r(USL.Name)
                    obj.LSL = r(LSL.Name)
                    obj.UTLMC = r(UTLMC.Name)
                    obj.LTLMC = r(LTLMC.Name)
                    obj.UMC = r(UMC.Name)
                    obj.LMC = r(LMC.Name)
                    If IsNumeric(r(CPK.Name)) Then
                        obj.CPK = r(CPK.Name)
                    End If
                    If IsNumeric(r(CPM.Name)) Then
                        obj.CPM = r(CPM.Name)
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

    Private Sub FrmDefineDetail_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub
End Class