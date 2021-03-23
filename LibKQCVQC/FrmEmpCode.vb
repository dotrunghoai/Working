
Imports CommonDB
Imports System.Windows.Forms
Imports PublicUtility
Imports LibEntity

Public Class FrmEmpCode
	Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)


    Private Sub grid_CellValueChanged(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellValueChanged
		If e.RowIndex >= 0 Then
			If e.ColumnIndex = grid.Columns(Code.Name).Index Then
				Dim obj As New KQQC_Code
				obj.EmpID_K = grid.CurrentRow.Cells(EmpID.Name).Value
				obj.EmpName = grid.CurrentRow.Cells(EmpName.Name).Value
				If grid.CurrentRow.Cells(Code.Name).Value IsNot DBNull.Value Then
					obj.Code = grid.CurrentRow.Cells(Code.Name).Value
				Else
					obj.Code = ""
				End If

				If _db.ExistObject(obj) Then
					_db.Update(obj)
				Else
					_db.Insert(obj)
				End If
			End If
		End If
	End Sub

	Private Sub mnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
		Dim sql As String = String.Format("sp_KQQC_GetEmpCode")
		Dim bdsource As New BindingSource
		bdsource.DataSource = _db.ExecuteStoreProcedureTB(sql)
		bdn.BindingSource = bdsource
		grid.DataSource = bdsource
	End Sub

	Private Sub mnuExport_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
		ExportEXCEL(grid)
	End Sub

	Private Sub FrmEmpCode_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
		mnuShowAll.PerformClick()
	End Sub

	Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
		If bdn.BindingSource IsNot Nothing Then
			If txtID.Text <> "" Then
				bdn.BindingSource.Filter = String.Format("EmpID like '%{0}%'", txtID.Text)
			Else
				bdn.BindingSource.Filter = ""
			End If
		End If
	End Sub
End Class