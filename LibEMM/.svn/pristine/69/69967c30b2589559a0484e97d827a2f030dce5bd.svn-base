Imports System.Windows.Forms
Imports CommonDB
Imports PublicUtility
'Imports LibEntity

Public Class FrmMasterNangLucIQC
	Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)


    Private Sub mnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
		Dim bd As New BindingSource
		Dim dtAll As DataTable = _db.ExecuteStoreProcedureTB("sp_EMM_MasterNangLucIQC")
		bd.DataSource = dtAll
		grid.DataSource = bd
		bdn.BindingSource = bd
	End Sub

	Private Sub mnuExport_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
		ExportEXCEL(grid)
	End Sub

	Private Sub grid_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellValueChanged
		If e.RowIndex >= 0 Then
			Dim obj As New EMM_MasterNangLucIQC
			If grid.CurrentRow.Cells(HangMucSub.Name).Value IsNot DBNull.Value Then
				obj.HangMucSub_K = grid.CurrentRow.Cells(HangMucSub.Name).Value
			Else
				Return
			End If
			If grid.CurrentRow.Cells(HangMuc.Name).Value IsNot DBNull.Value Then
				obj.HangMuc = grid.CurrentRow.Cells(HangMuc.Name).Value
			Else
				Return
			End If
			If grid.CurrentRow.Cells(TGC.Name).Value IsNot DBNull.Value Then
				obj.TGC = grid.CurrentRow.Cells(TGC.Name).Value
			Else
				Return
			End If
			If _db.ExistObject(obj) Then
				_db.Update(obj)
			Else
				_db.Insert(obj)
			End If
		End If
	End Sub

	Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
		If ShowQuestionSave() = DialogResult.Yes Then

			For Each r As DataGridViewRow In grid.Rows
				Dim obj As New EMM_MasterNangLucIQC
				If r.Cells(HangMucSub.Name).Value IsNot DBNull.Value Then
					obj.HangMucSub_K = r.Cells(HangMucSub.Name).Value
				Else
					Continue For
				End If
				If r.Cells(HangMuc.Name).Value IsNot DBNull.Value Then
					obj.HangMuc = r.Cells(HangMuc.Name).Value
				Else
					Continue For
				End If
				If r.Cells(TGC.Name).Value IsNot DBNull.Value Then
					obj.TGC = r.Cells(TGC.Name).Value
				Else
					obj.TGC = 0
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

	Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
		If ShowQuestionDelete() = DialogResult.Yes Then
			Dim obj As New EMM_MasterNangLucIQC
			If grid.CurrentRow.Cells(HangMucSub.Name).Value IsNot DBNull.Value Then
				obj.HangMucSub_K = grid.CurrentRow.Cells(HangMucSub.Name).Value
			End If
			If grid.CurrentRow.Cells(HangMuc.Name).Value IsNot DBNull.Value Then
				obj.HangMuc = grid.CurrentRow.Cells(HangMuc.Name).Value
			End If
			_db.Delete(obj)
			grid.Rows.Remove(grid.CurrentRow)
		End If
	End Sub
End Class