Imports System.Windows.Forms
Imports CommonDB
Imports PublicUtility
'Imports LibEntity
Imports DataGridViewAutoFilter


Public Class FrmMasterSoLoU00
	Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)


	Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
		If ShowQuestionSave() = DialogResult.Yes Then
			For Each r As DataGridViewRow In grid.Rows
				Dim obj As New EMM_MasterSoLotU00
				If r.Cells(JCode.Name).Value IsNot DBNull.Value Then
					obj.JCode_K = r.Cells(JCode.Name).Value
				Else
					Continue For
				End If
				If r.Cells(JName.Name).Value IsNot DBNull.Value Then
					obj.Jname = r.Cells(JName.Name).Value
				End If
				If r.Cells(SLTrenLo.Name).Value IsNot DBNull.Value Then
					obj.SLTrenLo = r.Cells(SLTrenLo.Name).Value
				Else
					obj.SLTrenLo = 0
				End If
				If r.Cells(SLTrenXap.Name).Value IsNot DBNull.Value Then
					obj.SLTrenXap = r.Cells(SLTrenXap.Name).Value
				Else
					obj.SLTrenLo = 0
				End If
				If r.Cells(SoXap.Name).Value IsNot DBNull.Value Then
					obj.SoXap = r.Cells(SoXap.Name).Value
				Else
					obj.SoXap = 0
				End If
				If _db.ExistObject(obj) Then
					_db.Update(obj)
				Else
					_db.Insert(obj)
				End If
			Next
			ShowSuccess()
			mnuShowAll.PerformClick()
		End If
	End Sub
	Private Sub grid_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellValueChanged
		If e.RowIndex >= 0 Then
			Dim obj As New EMM_MasterSoLotU00
			If grid.CurrentRow.Cells(JCode.Name).Value IsNot DBNull.Value Then
				obj.JCode_K = grid.CurrentRow.Cells(JCode.Name).Value
			Else
				Return
			End If
			If grid.CurrentRow.Cells(JName.Name).Value IsNot DBNull.Value Then
				obj.Jname = grid.CurrentRow.Cells(JName.Name).Value
			End If
			If grid.CurrentRow.Cells(SLTrenLo.Name).Value IsNot DBNull.Value Then
				obj.SLTrenLo = grid.CurrentRow.Cells(SLTrenLo.Name).Value
			Else
				obj.SLTrenLo = 0
			End If
			If grid.CurrentRow.Cells(SLTrenXap.Name).Value IsNot DBNull.Value Then
				obj.SLTrenXap = grid.CurrentRow.Cells(SLTrenXap.Name).Value
			Else
				obj.SLTrenLo = 0
			End If
			If grid.CurrentRow.Cells(SoXap.Name).Value IsNot DBNull.Value Then
				obj.SoXap = grid.CurrentRow.Cells(SoXap.Name).Value
			Else
				obj.SoXap = 0
			End If
			If _db.ExistObject(obj) Then
				_db.Update(obj)
			Else
				_db.Insert(obj)
			End If
		End If
	End Sub

	Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
		If ShowQuestionDelete() = DialogResult.Yes Then
			Dim obj As New EMM_MasterSoLotU00
			If grid.CurrentRow.Cells(JCode.Name).Value IsNot DBNull.Value Then
				obj.JCode_K = grid.CurrentRow.Cells(JCode.Name).Value
			End If
			_db.Delete(obj)
			grid.Rows.Remove(grid.CurrentRow)
		End If
	End Sub

	Private Sub mnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
		Dim bd As New BindingSource
		Dim dtAll As DataTable = _db.ExecuteStoreProcedureTB("sp_EMM_MasterSoLotU00")
		bd.DataSource = dtAll
		grid.DataSource = bd
		bdn.BindingSource = bd
	End Sub

	Private Sub mnuExport_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
		ExportEXCEL(grid)
	End Sub
End Class