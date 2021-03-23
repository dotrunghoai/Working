
Imports CommonDB
Imports LibEntity
Imports System.Windows.Forms
Imports PublicUtility
Imports System.IO

Public Class FrmAdjustWT

    Private db As DBSql

#Region "user function"

#End Region

#Region "Form Function"

    Private Sub FrmAdjustWT_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        db = New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        Dim obj As New PD_ConfigWT
        obj.ID_K = "1"
        db.GetObject(obj)
        txtWorkingDay.Text = obj.WorkingDay.ToString()
        txtRestDay.Text = obj.RestDay.ToString()
    End Sub

#End Region

    Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click
        '************
        If txtWorkingDay.Text = String.Empty Then
            MessageBox.Show("Bạn chưa nhập thời gian làm việc ngày thường", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtWorkingDay.Focus()
            Exit Sub
        End If
        If Not Microsoft.VisualBasic.IsNumeric(txtWorkingDay.Text) Then
            MessageBox.Show("Thời gian làm việc ngày thường phải là chữ số", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtWorkingDay.Focus()
            Exit Sub
        End If
        '************

        '************
        If txtRestDay.Text = String.Empty Then
            MessageBox.Show("Bạn chưa nhập thời gian làm việc ngày nghỉ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRestDay.Focus()
            Exit Sub
        End If
        If Not Microsoft.VisualBasic.IsNumeric(txtRestDay.Text) Then
            MessageBox.Show("Thời gian làm việc ngày nghỉ phải là chữ số", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRestDay.Focus()
            Exit Sub
        End If
        '************

        '************
        Dim iwd As Int32 = CType(txtWorkingDay.Text, Int32)
        If iwd <= 0 Then
            MessageBox.Show("Thời gian làm việc phải lớn hơn 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtWorkingDay.Focus()
            Exit Sub
        End If
        If iwd > 24 Then
            MessageBox.Show("Thời gian làm việc phải nhỏ hơn 24", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtWorkingDay.Focus()
            Exit Sub
        End If
        If (iwd Mod 4) <> 0 Then
            MessageBox.Show("Thời gian làm việc phải chia hết cho 4", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtWorkingDay.Focus()
            Exit Sub
        End If
        '*************

        '************
        Dim ird As Int32 = CType(txtRestDay.Text, Int32)
        If ird <= 0 Then
            MessageBox.Show("Thời gian làm việc ngày nghỉ phải lớn hơn 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRestDay.Focus()
            Exit Sub
        End If
        If ird > 24 Then
            MessageBox.Show("Thời gian làm việc ngày nghỉ phải nhỏ hơn 24", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRestDay.Focus()
            Exit Sub
        End If
        If (ird Mod 4) <> 0 Then
            MessageBox.Show("Thời gian làm việc ngày nghỉ phải chia hết cho 4", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRestDay.Focus()
            Exit Sub
        End If
        '*************

        db.BeginTransaction()
        Try
            Dim obj As New PD_ConfigWT
            obj.ID_K = "1"
            db.GetObject(obj)
            obj.WorkingDay = CType(txtWorkingDay.Text, Int32)
            obj.RestDay = CType(txtRestDay.Text, Int32)
            If obj.ID_K Is Nothing Then
                obj.ID_K = "1"
                db.Insert(obj)
            Else
                db.Update(obj)
            End If
            db.Commit()
            MessageBox.Show("Cập nhật thời gian làm việc thành công", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            db.RollBack()
            ShowError(ex, mnuSave.Text, Me.Text)
        End Try
    End Sub

End Class