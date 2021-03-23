Imports CommonDB
Imports PublicUtility
Imports System.Windows.Forms

Public Class FrmXemKQCV : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)


    Private Sub FrmKQCV_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
		dtpDateS.Value = GetDateTimeStart6h(dtpDateS.Value)
		dtpDateE.Value = GetDateTimeEnd6h(dtpDateE.Value)

		mnuShowAll.PerformClick()
	End Sub

	Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim para(1) As SqlClient.SqlParameter
		para(0) = New SqlClient.SqlParameter("@Start", dtpDateS.Value.Date)
		para(1) = New SqlClient.SqlParameter("@End", GetEndDate(dtpDateE.Value.Date))
		Dim sql As String = String.Format("sp_KQQC_GetKQCV")
        Dim bdsource As New BindingSource
        bdsource.DataSource = _db.ExecuteStoreProcedureTB(sql, para)
        bdn.BindingSource = bdsource
        grid.DataSource = bdsource
    End Sub

    Private Sub mnuPP_Click(sender As System.Object, e As System.EventArgs) Handles mnuPP.Click
        Dim frm As New FrmPhuongPhap
        frm.ShowDialog()
    End Sub

    Private Sub mnuExportPP_Click(sender As System.Object, e As System.EventArgs) Handles mnuExportPP.Click
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Start", dtpDateS.Value)
        para(1) = New SqlClient.SqlParameter("@End", dtpDateE.Value)
        para(2) = New SqlClient.SqlParameter("@Type", "Max")
        Dim sql As String = String.Format("sp_KQQC_GetKQCV")
        Dim dtExport As DataTable = _db.ExecuteStoreProcedureTB(sql, para)
        ExportEXCEL(dtExport)
    End Sub

	Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
		If bdn.BindingSource IsNot Nothing Then
			If txtSearch.Text = "" Then
				bdn.BindingSource.Filter = ""
			Else
				bdn.BindingSource.Filter = String.Format("ProductCode like '%{0}%' or LotNo like '%{0}%'", txtSearch.Text)
			End If
		End If
	End Sub
End Class