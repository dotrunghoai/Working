
Imports CommonDB
Imports LibEntity
Imports PublicUtility

Imports System.Windows.Forms
Imports System.IO

Public Class FrmViewReport : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim mypath As String = Application.StartupPath & "\Temp"
    Private Sub tlsMenu_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles tlsMenu.Paint
        PublicFunction.FillControl(tlsMenu.Location.X, tlsMenu.Location.Y, tlsMenu.Width, tlsMenu.Height, e)
    End Sub

    Sub LoadViewReport()
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDayOfMonth(dtpReportDate.Value))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDayOfMonth(dtpReportDate.Value))
        If CurrentUser.SortSection = "HR" Or CurrentUser.UserID = "15180" Then
            para(2) = New SqlClient.SqlParameter("@Email", DBNull.Value)
        Else
            para(2) = New SqlClient.SqlParameter("@Email", CurrentUser.Mail)
        End If
        Dim sql As String = String.Format("sp_HRR_LoadViewReport")
        Dim bdsource As New BindingSource
        bdsource.DataSource = _db.ExecuteStoreProcedureTB(sql, para)
        grid.DataSource = bdsource
        bdn.BindingSource = bdsource
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        LoadViewReport()
    End Sub

    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs)
        If grid.CurrentRow IsNot Nothing Then
            If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
                Dim obj As New HRR_ViewReport
                obj.ReportDate_K = grid.CurrentRow.Cells("ReportDate").Value
                obj.DocNo_K = grid.CurrentRow.Cells("DocNo").Value
                _db.Delete(obj)
                mnuShowAll.PerformClick()
            End If
        End If
    End Sub

    Private Sub FrmViewReport_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub


    Private Sub grid_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellClick
        If grid.CurrentRow IsNot Nothing Then
            If grid.Columns("Xem").Index = e.ColumnIndex Then
                Dim obj As New HRR_ViewReport
                obj.ReportDate_K = grid.CurrentRow.Cells("ReportDate").Value
                obj.DocNo_K = grid.CurrentRow.Cells("DocNo").Value
                _db.GetObject(obj)

                Dim objA As New HRR_AttachFile
                objA.ReportDate_K = grid.CurrentRow.Cells("ReportDate").Value
                objA.DocNo_K = grid.CurrentRow.Cells("DocNo").Value
                _db.GetObject(objA)
                If Not Directory.Exists(mypath) Then
                    Directory.CreateDirectory(mypath)
                End If
                PublicFunction.ConvertArrayByteToFile(mypath & obj.FileName, objA.FileBinary)
                Process.Start(mypath & obj.FileName)
            End If
        End If
    End Sub

    Private Sub txtFileName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFileName.TextChanged
        If bdn.BindingSource IsNot Nothing Then
            If txtFileName.Text <> "" Then
                bdn.BindingSource.Filter = String.Format(" FileName like '%{0}%' ", txtFileName.Text)
            Else
                bdn.BindingSource.Filter = ""
            End If
        End If
    End Sub
End Class