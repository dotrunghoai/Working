Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports System.Windows.Forms

Public Class FrmNipponStock : Inherits DevExpress.XtraEditors.XtraForm
    'Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim nvd As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    'Dim dbAS As New DBFunction(PublicConst.EnumServers.NDV_DB2_AS400)

    Dim dtAll As DataTable


    Private Sub dtpStartDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpStartDate.ValueChanged
        If dtpEndDate.Value < dtpStartDate.Value Then
            dtpEndDate.Value = dtpStartDate.Value
        End If
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpEndDate.ValueChanged
        If dtpEndDate.Value < dtpStartDate.Value Then
            dtpStartDate.Value = dtpEndDate.Value
        End If
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim sql As String = String.Format("SELECT  DDate , " +
        "JCode, " +
        "LTRIM(RTRIM(JName)) JName, " +
        "Unit, " +
        "Qty, " +
        "PickedQty " +
        "FROM {0} " +
        "WHERE DDate BETWEEN '{1}' AND '{2}' " +
        "order by DDate, JCode", _
        PublicTable.Table_PCM_StockOld, dtpStartDate.Value.ToString("yyyyMMdd"), dtpEndDate.Value.ToString("yyyyMMdd"))
        dtAll = nvd.FillDataTable(sql)
        Dim bd As New BindingSource
        bd.DataSource = dtAll
        gridD.DataSource = bd
        bnGrid.BindingSource = bd
    End Sub

    Private Sub txtJCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtJCode.TextChanged
        If dtAll Is Nothing Then
            Return
        Else
            Dim dv As DataView = New DataView(dtAll)
            dv.RowFilter = "[JCode] LIKE '%" + txtJCode.Text + "%'"
            Dim bd As New BindingSource()
            bd.DataSource = dv
            gridD.DataSource = bd
        End If
    End Sub
End Class