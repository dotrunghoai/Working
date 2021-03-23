Imports CommonDB
Imports PublicUtility
Imports System.Windows.Forms

Public Class FrmSumINV
    'Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim nvd As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim dtAll As DataTable
    Dim param(1) As SqlClient.SqlParameter


    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(gridSearch)
    End Sub

    Private Sub mnuSearch_Click(sender As System.Object, e As System.EventArgs) Handles mnuSearch.Click
        If Trim(txtInvoiceID.Text) = "" Then
            MessageBox.Show("Input Invoice", "Search Invoice")
            txtInvoiceID.Focus()
            Exit Sub
        End If

        param(0) = New SqlClient.SqlParameter("@Invoice", Trim(txtInvoiceID.Text))
        param(1) = New SqlClient.SqlParameter("@Action", "Search")

        dtAll = nvd.ExecuteStoreProcedureTB("sp_GSR_SumINV", param)
        Dim bd As New BindingSource
        bd.DataSource = dtAll
        gridSearch.DataSource = bd
        bnGrid.BindingSource = bd
    End Sub

    Private Sub mnuSumINV_Click(sender As System.Object, e As System.EventArgs) Handles mnuSumINV.Click
        If Trim(txtInvoiceID.Text) = "" Then
            MessageBox.Show("Input Invoice", "Search Invoice")
            Exit Sub
        End If

        param(0) = New SqlClient.SqlParameter("@Invoice", Trim(txtInvoiceID.Text))
        param(1) = New SqlClient.SqlParameter("@Action", "Sum")

        dtAll = nvd.ExecuteStoreProcedureTB("sp_GSR_SumINV", param)
        Dim bd As New BindingSource
        bd.DataSource = dtAll
        gridSearch.DataSource = bd
        bnGrid.BindingSource = bd
        txtSum.Text = dtAll.Compute("Sum(TotalAmount)", "")
    End Sub
End Class