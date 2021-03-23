Imports CommonDB
Imports LibEntity
Imports PublicUtility
Imports System.Windows.Forms

Public Class FrmEmployee : Inherits DevExpress.XtraEditors.XtraForm
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
		Dim sql As String = String.Format(" select q.empid,e.empname,e.SectionSort as Section," +
										  " e.GroupName,e.Shift as Team,e.Observation, q.Shift, q.STT " +
										  " from MDQA_Employee q " +
										  " left join OT_Employee e " +
										  " on q.EmpID=e.EmpID " +
										  " order by q.STT")
		Dim bd As New BindingSource
        bd.DataSource = _db.FillDataTable(sql)
        bdn.BindingSource = bd
        grid.DataSource = bd
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub

    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click
        If grid.CurrentRow IsNot Nothing Then
            If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
                Dim obj As New MDQA_Employee
                obj.EmpID_K = grid.CurrentRow.Cells("EmpID").Value
                _db.Delete(obj)
                grid.Rows.Remove(grid.CurrentRow)
            End If
        End If
    End Sub

    Private Sub txtEmpID_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEmpID.TextChanged

        'If bdn.BindingSource IsNot Nothing Then
        '    If txtEmpID.Text = "" Then
        '        bdn.BindingSource.Filter = ""
        '    Else
        '        bdn.BindingSource.Filter = String.Format("EmpID like '%{0}%' ", txtEmpID.Text)
        '    End If
        'End If
    End Sub

    Private Sub txtEmpID_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtEmpID.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim obje As New OT_Employee
            obje.EmpID_K = txtEmpID.Text.PadLeft(5, "0")
            _db.GetObject(obje)
            txtEmpName.Text = obje.EmpName
            txtSection.Text = obje.SectionSort
            txtGroupName.Text = obje.GroupName
            txtTeam.Text = obje.Shift
        End If
    End Sub

    Private Sub FrmEmployee_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub

    Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click
        If txtEmpID.Text <> "" And txtEmpName.Text <> "" And IsNumeric(txtSTT.Text) Then
            Dim obj As New MDQA_Employee
            obj.EmpID_K = txtEmpID.Text
            obj.EmpName = txtEmpName.Text
            obj.Section = txtSection.Text
            obj.GroupName = txtGroupName.Text
            obj.Team = txtTeam.Text
            obj.Shift = txtShift.Text
            obj.STT = txtSTT.Text
            If Not _db.ExistObject(obj) Then
                _db.Insert(obj)
            Else
                _db.Update(obj)
            End If
            mnuShowAll.PerformClick()
            txtEmpID.SelectAll()

            txtEmpID.Text = ""
            txtEmpName.Text = ""
            txtSection.Text = ""
            txtGroupName.Text = ""
            txtShift.Text = ""
            txtSTT.Text = ""
        Else
            ShowWarning("Nhân viên không tồn tại hoặc STT chưa nhập !")
        End If
    End Sub

    Private Sub grid_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellClick
		txtEmpID.Text = grid.CurrentRow.Cells("EmpID").Value
		If grid.CurrentRow.Cells("EmpName").Value IsNot DBNull.Value Then
			txtEmpName.Text = grid.CurrentRow.Cells("EmpName").Value
		Else
			txtEmpName.Text = ""
		End If
		If grid.CurrentRow.Cells("Section").Value IsNot DBNull.Value Then
			txtSection.Text = grid.CurrentRow.Cells("Section").Value
		Else
			txtSection.Text = ""
		End If
		If grid.CurrentRow.Cells("GroupName").Value IsNot DBNull.Value Then
			txtGroupName.Text = grid.CurrentRow.Cells("GroupName").Value
		Else
			txtGroupName.Text = ""
		End If
		If grid.CurrentRow.Cells("Team").Value IsNot DBNull.Value Then
			txtTeam.Text = grid.CurrentRow.Cells("Team").Value
		Else
			txtTeam.Text = ""
		End If
		If grid.CurrentRow.Cells("Shift").Value IsNot DBNull.Value Then
			txtShift.Text = grid.CurrentRow.Cells("Shift").Value
		Else
			txtShift.Text = ""
		End If
		If grid.CurrentRow.Cells("STT").Value IsNot DBNull.Value Then
			txtSTT.Text = grid.CurrentRow.Cells("STT").Value
		Else
			txtSTT.Text = ""
		End If
	End Sub

    Private Sub btnShowPR3_Click(sender As Object, e As EventArgs) Handles btnShowPR3.Click
        GridControl1.DataSource = _db.FillDataTable("SELECT d.GroupName, h.EmpID, d.EmpName, h.ShortNo, d.Shift
                                                     FROM MDQA_Employee_PR3 AS h
                                                     LEFT JOIN OT_Employee AS d
                                                     ON h.EmpID = d.EmpID
                                                     ORDER BY d.GroupName, h.EmpID")
        GridControlSetFormat(GridView1)
        GridView1.Columns("EmpName").Width = 150
    End Sub

    Private Sub btnImportPR3_Click(sender As Object, e As EventArgs) Handles btnImportPR3.Click
        Dim dt As DataTable = ImportEXCEL(True)
        If dt.Rows.Count > 0 Then
            Dim succ As Integer = 0
            For Each r As DataRow In dt.Rows
                If IsDBNull(r("EmpID")) Then Continue For
                Dim obj As New MDQA_Employee_PR3
                obj.EmpID_K = r("EmpID")
                obj.ShortNo = r("ShortNo")
                If _db.ExistObject(obj) Then
                    _db.Update(obj)
                Else
                    _db.Insert(obj)
                    succ += 1
                End If
            Next
            ShowSuccess(succ)
        End If
    End Sub

    Private Sub btnNewPR3_Click(sender As Object, e As EventArgs) Handles btnNewPR3.Click
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("EmpID").OptionsColumn.ReadOnly = False
        GridView1.Columns("ShortNo").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnEditPR3_Click(sender As Object, e As EventArgs) Handles btnEditPR3.Click
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("ShortNo").OptionsColumn.ReadOnly = False
        GridControlSetColorReadonly(GridView1)
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnDeletePR3_Click(sender As Object, e As EventArgs) Handles btnDeletePR3.Click
        If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu ?") = DialogResult.Yes Then
            Dim obj As New MDQA_Employee_PR3
            obj.EmpID_K = GridView1.GetFocusedRowCellValue("EmpID")
            _db.Delete(obj)
            GridView1.DeleteSelectedRows()
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If IsDBNull(GridView1.GetFocusedRowCellValue("EmpID")) Then
                    ShowWarning("Bạn phải nhập EmpID trước !")
                    btnNewPR3.PerformClick()
                    Return
                End If
                Dim obj As New MDQA_Employee_PR3
                obj.EmpID_K = GridView1.GetFocusedRowCellValue("EmpID")
                If _db.ExistObject(obj) = False Then
                    _db.Insert(obj)
                End If
            End If
            _db.ExecuteNonQuery(String.Format("UPDATE MDQA_Employee_PR3
                                               SET {0} = '{1}'
                                               WHERE EmpID = '{2}'",
                                               e.Column.FieldName,
                                               e.Value,
                                               GridView1.GetFocusedRowCellValue("EmpID")))
        End If
    End Sub
End Class