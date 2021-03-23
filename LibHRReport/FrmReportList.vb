
Imports CommonDB
Imports LibEntity
Imports PublicUtility

Imports System.Windows.Forms

Public Class FrmReportList : Inherits DevExpress.XtraEditors.XtraForm
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub tlsMenu_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles tlsMenu.Paint
        PublicFunction.FillControl(tlsMenu.Location.X, tlsMenu.Location.Y, tlsMenu.Width, tlsMenu.Height, e)
    End Sub
    Sub LoadObservation()
        Dim sql As String = String.Format("select distinct Observation from OT_employee order by Observation ")
        gridR.DataSource = _db.FillDataTable(sql)
    End Sub
    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim sql As String = String.Format("select * from HRR_ReportList")
        Dim bdsource As New BindingSource
        bdsource.DataSource = _db.FillDataTable(sql)
        bdn.BindingSource = bdsource
        grid.DataSource = bdsource
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub

    Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click
        If txtDocNo.Text = "" Then
            ShowWarning("DocNo không được để trống.")
            txtDocNo.Focus()
            Return
        End If
        If txtDocName.Text = "" Then
            ShowWarning("DocName không được để trống.")
            txtDocName.Focus()
            Return
        End If
        If ShowQuestionSave() = Windows.Forms.DialogResult.Yes Then
            Dim obj As New HRR_ReportList
            obj.DocNo_K = txtDocNo.Text
            obj.DocName = txtDocName.Text
            obj.CreateDate = DateTime.Now
            obj.CreateUser = CurrentUser.UserID
            If _db.ExistObject(obj) Then
                _db.Update(obj)
            Else
                _db.Insert(obj)
            End If
            mnuShowAll.PerformClick()
        End If
    End Sub

  
    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click
        If grid.CurrentRow IsNot Nothing Then
            If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
                Dim obj As New HRR_ReportList
                obj.DocNo_K = grid.CurrentRow.Cells("DocNo").Value
                _db.Delete(obj)
                grid.Rows.Remove(grid.CurrentRow)
            End If
        End If
    End Sub

    Private Sub grid_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellClick
        If grid.CurrentRow IsNot Nothing Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@DocNo", grid.CurrentRow.Cells("DocNo").Value)
            'para(1) = New SqlClient.SqlParameter("@Observation", gridR.CurrentRow.Cells("Observation").Value)
            gridEmail.DataSource = _db.ExecuteStoreProcedureTB("sp_HRR_GetRight", para)

            txtDocNo.Text = grid.CurrentRow.Cells("DocNo").Value
            txtDocName.Text = grid.CurrentRow.Cells("DocName").Value
        End If
    End Sub

    Private Sub FrmReportList_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
        LoadObservation()
    End Sub

    Private Sub gridEmail_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridEmail.CellClick
        If gridEmail.Columns("Checked").Index = e.ColumnIndex Then
            If gridEmail.CurrentRow.Cells("Checked").Value Is DBNull.Value Then
                gridEmail.CurrentRow.Cells("Checked").Value = 0
            End If
        End If
    End Sub

    Private Sub gridEmail_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridEmail.CellValueChanged
        If gridEmail.CurrentRow IsNot Nothing Then
            If gridEmail.CurrentRow.Cells("Checked").Value Is DBNull.Value Then
                gridEmail.CurrentRow.Cells("Checked").Value = 0
            End If
            Dim obj As New HRR_DocRight
            obj.DocNo_K = grid.CurrentRow.Cells("DocNo").Value
            obj.Email_K = gridEmail.CurrentRow.Cells("Email").Value
            If gridEmail.CurrentRow.Cells("Checked").Value = "1" Then
                If Not _db.ExistObject(obj) Then
                    _db.Insert(obj)
                End If
            Else
                _db.Delete(obj)
            End If
        End If
    End Sub

    Private Sub gridR_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridR.CellClick
        If gridR.CurrentRow IsNot Nothing Then
            Dim para(1) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@DocNo", grid.CurrentRow.Cells("DocNo").Value)
            para(1) = New SqlClient.SqlParameter("@Observation", gridR.CurrentRow.Cells("Observation").Value)
            gridEmail.DataSource = _db.ExecuteStoreProcedureTB("sp_HRR_GetRightObservation", para)
        End If
    End Sub
End Class