Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports DataGridViewAutoFilter

Imports System.Windows.Forms
Imports System.Text
Imports vb = Microsoft.VisualBasic
Imports System.Globalization

Public Class FrmCheckLotOld
    'Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim nvd As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    'Dim dbAS As New DBFunction(PublicConst.EnumServers.NDV_DB2_AS400)
    Public Shared _JCode As String = ""
    Public Shared _ECode As String = ""
    Public Shared _SubPrcName As String = ""
    Public Shared _PdCode As String = ""
    Dim param(1) As SqlClient.SqlParameter
    Dim dtAll As DataTable

    Private Sub FrmCheckLotOld_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim EndDate As String = DateTime.Now.ToString("yyyyMMdd")

        Dim Day As DateTime = New DateTime(DateTime.Now.AddDays(-10).Year, DateTime.Now.AddDays(-10).Month, DateTime.Now.AddDays(-10).Day)

        Dim StartDate As String = Day.ToString("yyyyMMdd")

        param(0) = New SqlClient.SqlParameter("@startDate", StartDate)
        param(1) = New SqlClient.SqlParameter("@endDate", EndDate)
        Dim sql As String = String.Format("select YMD, ECode, JCode, SubPrcName, PdCode, PrcName, LotS1, LotE1, LotS2, LotE2, AdjustLot " +
        "from {0} " +
        "where YMD between @startDate and @endDate " +
        "and JCode = '{1}' " +
         "and PdCode = '{2}' " +
        "order by YMD desc", PublicTable.Table_PCM_TrayU00, _JCode, _PdCode)
        Dim bd As New BindingSource
        bd.DataSource = nvd.FillDataTable(sql, param)
        gridD.DataSource = bd
    End Sub

    Private Sub txtPdCode_PreviewKeyDown(sender As System.Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtPdCode.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            Dim sql As String = String.Format("SELECT TOP 20 " +
            "YMD, " +
            "ECode, " +
            "JCode, " +
            "SubPrcName, " +
            "PdCode, " +
            "PrcName, " +
            "LotS1, " +
            "LotE1, " +
            "LotS2, " +
            "LotE2, " +
            "AdjustLot " +
            "FROM {0} " +
            "WHERE   PdCode = '{1}' " +
            "ORDER BY YMD DESC , " +
            "JCode", PublicTable.Table_PCM_TrayU00, Trim(txtPdCode.Text))
            dtAll = nvd.FillDataTable(sql)
            Dim bd As New BindingSource
            bd.DataSource = dtAll
            gridD.DataSource = bd
        End If
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