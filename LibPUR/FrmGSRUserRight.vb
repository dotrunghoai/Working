Imports System.Windows.Forms
Imports CommonDB
Imports PublicUtility
Imports LibEntity
Public Class FrmGSRUserRight : Inherits DevExpress.XtraEditors.XtraForm
    'Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim nvd As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    'Dim dbAS As New DBFunction(PublicConst.EnumServers.NDV_DB2_AS400)

    Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
        Dim obj As New GSR_UserRight
        If Trim(txtUserID.Text) = "" Then
            MessageBox.Show("Input Code!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            nvd.CloseConnect()
            Exit Sub
        Else
            obj.UserID_K = Trim(txtUserID.Text)
        End If
        nvd.GetObject(obj)

        Dim sql As String = String.Format("select UserID, FullName from {0} where UserID = '{1}'", PublicTable.Table_Main_User, Trim(txtUserID.Text))
        Dim dt As DataTable = nvd.FillDataTable(sql)
        If dt.Rows.Count <> 0 Then
            obj.FullName = Trim(dt.Rows(0).Item("FullName"))
        Else
            MessageBox.Show("User does not exist", "Error")
            Exit Sub
        End If

        obj.IsAll = chkIsAll.Checked
        If nvd.ExistObject(obj) Then
            obj.CreateDate = DateTime.Now
            obj.CreateUser = CurrentUser.UserID
            nvd.Update(obj)
        Else
            obj.UserID_K = Trim(txtUserID.Text)
            Dim sqlIdx As String = String.Format("select Idx = case when max(Idx) is null then 0 else max(Idx) end from {0}", PublicTable.Table_GSR_UserRight)
            Dim dtIdx As DataTable = nvd.FillDataTable(sqlIdx)
            obj.Idx = dtIdx.Rows(0).Item("Idx") + 1
            obj.CreateDate = DateTime.Now
            obj.CreateUser = CurrentUser.UserID
            nvd.Insert(obj)
        End If

        Dim bs As New BindingSource()
        bs = gridD.DataSource
        Dim dtTemp As DataTable = DirectCast(bs.DataSource, DataTable)
        Dim row As DataRow = dtTemp.NewRow()
        row("UserID") = obj.UserID_K
        row("FullName") = obj.FullName
        row("IsAll") = obj.IsAll
        dtTemp.Rows.Add(row)

        gridD.AutoResizeColumns()
        MsgBox("Save successfully.", MsgBoxStyle.OkOnly, "Save")
        txtUserID.Text = ""
        chkIsAll.Checked = False
        txtUserID.Focus()
    End Sub

    Private Sub FrmUserRight_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim sql As String = String.Format("select UserID, FullName, IsAll from {0} order by Idx", PublicTable.Table_GSR_UserRight)
        Dim bd As New BindingSource
        bd.DataSource = nvd.FillDataTable(sql)
        gridD.DataSource = bd
        gridD.AutoResizeColumns()
    End Sub

    Private Sub gridD_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellClick
        If gridD.CurrentRow IsNot Nothing Then
            txtUserID.Text = IIf(gridD.CurrentRow.Cells("UserID").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("UserID").Value)
            chkIsAll.Checked = IIf(gridD.CurrentRow.Cells("IsAll").Value Is DBNull.Value, False, gridD.CurrentRow.Cells("IsAll").Value)
        End If
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        If gridD.Rows.Count = 0 Then Exit Sub

        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            Dim sql As String = String.Format("Delete from {0} where UserID = '{1}'", PublicTable.Table_GSR_UserRight, Trim(txtUserID.Text))
            nvd.ExecuteNonQuery(sql)
            Dim bs As New BindingSource()
            bs = gridD.DataSource
            Dim row As DataRowView = DirectCast(bs.Current, DataRowView)
            row.Delete()
        End If
    End Sub

    Private Sub gridD_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles gridD.RowPrePaint
        gridD.Rows(e.RowIndex).Cells("No").Value = e.RowIndex + 1
    End Sub
End Class