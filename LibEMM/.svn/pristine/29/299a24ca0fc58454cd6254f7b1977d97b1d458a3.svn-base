Imports System.Windows.Forms
Imports CommonDB
Imports PublicUtility
'Imports LibEntity
Imports DataGridViewAutoFilter


Public Class FrmMasterThoiGianIQC
	Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)



	Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
		If ShowQuestionSave() = DialogResult.Yes Then
			Dim sql As String = String.Format("delete from EMM_MasterCaIQC")
			For Each r As DataGridViewRow In grid.Rows
				Dim obj As New EMM_MasterCaIQC
				If r.Cells(Loai.Name).Value IsNot DBNull.Value Then
					obj.Loai_K = r.Cells(Loai.Name).Value
				Else
					Continue For
				End If
				If r.Cells(NhanVien.Name).Value IsNot DBNull.Value Then
					obj.NhanVien_K = r.Cells(NhanVien.Name).Value
				Else
					Continue For
				End If
				If r.Cells(TGKiem.Name).Value IsNot DBNull.Value Then
					obj.TGKiem = r.Cells(TGKiem.Name).Value
				Else
					obj.TGKiem = 0
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

	Private Sub mnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
		Dim bd As New BindingSource
		Dim dtAll As DataTable = _db.ExecuteStoreProcedureTB("sp_EMM_MasterCaIQC")
		bd.DataSource = dtAll
		grid.DataSource = bd
		bdn.BindingSource = bd
	End Sub

	Private Sub mnuExport_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
		ExportEXCEL(grid)
	End Sub

	Private Sub grid_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellValueChanged
		If e.RowIndex >= 0 Then
			Dim obj As New EMM_MasterCaIQC
			If grid.CurrentRow.Cells(Loai.Name).Value IsNot DBNull.Value Then
				obj.Loai_K = grid.CurrentRow.Cells(Loai.Name).Value
			Else
				Return
			End If
			If grid.CurrentRow.Cells(NhanVien.Name).Value IsNot DBNull.Value Then
				obj.NhanVien_K = grid.CurrentRow.Cells(NhanVien.Name).Value
			Else
				Return
			End If
			If grid.CurrentRow.Cells(TGKiem.Name).Value IsNot DBNull.Value Then
				obj.TGKiem = grid.CurrentRow.Cells(TGKiem.Name).Value
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

	Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
		If ShowQuestionDelete() = DialogResult.Yes Then
			Dim obj As New EMM_MasterCaIQC
			If grid.CurrentRow.Cells(Loai.Name).Value IsNot DBNull.Value Then
				obj.Loai_K = grid.CurrentRow.Cells(Loai.Name).Value
			End If
			If grid.CurrentRow.Cells(NhanVien.Name).Value IsNot DBNull.Value Then
				obj.NhanVien_K = grid.CurrentRow.Cells(NhanVien.Name).Value
			End If
			_db.Delete(obj)
			grid.Rows.Remove(grid.CurrentRow)
		End If
	End Sub

End Class