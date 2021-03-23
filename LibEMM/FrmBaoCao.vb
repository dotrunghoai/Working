Imports System.Windows.Forms
Imports CommonDB
Imports PublicUtility


Public Class FrmBaoCao : Inherits DevExpress.XtraEditors.XtraForm
	Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)


    Private Sub mnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
		Dim sql As String = String.Format("sp_EMM_BaoCao")
		Dim para(3) As SqlClient.SqlParameter
		para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dtpStart.Value.Date))
		para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dtpEnd.Value.Date))

		If rdoInComingDate.Checked Then
			para(2) = New SqlClient.SqlParameter("@Date", "IN")
		Else
			para(2) = New SqlClient.SqlParameter("@Date", "INS")
		End If
		If rdoB00.Checked Then
			para(3) = New SqlClient.SqlParameter("@Type", "B00")
		ElseIf rdoU00.Checked Then
			para(3) = New SqlClient.SqlParameter("@Type", "U00")
		ElseIf rdoHC.Checked Then
			para(3) = New SqlClient.SqlParameter("@Type", "HC")
		End If

		Dim bd As New BindingSource
		Dim dtAll As DataTable = _db.ExecuteStoreProcedureTB(sql, para)
		bd.DataSource = dtAll
		grid.DataSource = bd
		bdn.BindingSource = bd

		If rdoHC.Checked Then
			grid.Columns(Supplier.Name).Visible = True
		Else
			grid.Columns(Supplier.Name).Visible = False
		End If
	End Sub

	Private Sub mnuExport_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
		ExportEXCEL(grid)
	End Sub
End Class