
Imports CommonDB
Imports LibEntity
Imports PublicUtility
Imports System.Windows.Forms


Public Class FrmBaoCaoSSI : Inherits DevExpress.XtraEditors.XtraForm
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Sub LoadDetail()
        Dim sql As String = String.Format(" SELECT  d.DefectCode " +
                                         " FROM  [MDQA_KTPL] kt" +
                                         " inner join [dbo].[MDQA_KTPL_Detail] d " +
                                         " on kt.ID=d.ID" +
                                         " where ngay between @Start and @End and HangSSI='SSI' " +
                                         " group by d.DefectCode ")
        Dim sqlS As String = String.Format(" SELECT kt.ProductCode,  d.DefectCode,sum(d.DefectQty) as SL " +
                                 " FROM  [MDQA_KTPL] kt" +
                                 " inner join [dbo].[MDQA_KTPL_Detail] d" +
                                 " on kt.ID=d.ID" +
                                 " where ngay between @Start and @End and HangSSI='SSI' " +
                                 " group by kt.ProductCode, d.DefectCode ")
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Start", GetStartDate(dtpStart.Value))
        para(1) = New SqlClient.SqlParameter("@End", GetEndDate(dtpEnd.Value))
        Dim dtData As DataTable = _db.FillDataTable(sql, para)
        Dim dtDataS As DataTable = _db.FillDataTable(sqlS, para)
        For Each r As DataRow In dtData.Rows
            grid.Columns.Add(r("DefectCode").ToString, r("DefectCode").ToString)
            grid.Columns(r("DefectCode").ToString).Width = 50
        Next
        For Each r As DataGridViewRow In grid.Rows
            For c As Integer = 8 To grid.ColumnCount - 1
                r.Cells(c).Value = dtDataS.Compute("sum(SL)", String.Format("ProductCode='{0}' and DefectCode='{1}' ",
                                                                           r.Cells("ProductCode").Value,
                                                                           grid.Columns(c).Name))

            Next
        Next
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        grid.ColumnCount = 8
        grid.RowCount = 0
        Dim sql As String = String.Format("sp_MDQA_BaoCaoSSI")
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dtpStart.Value))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dtpEnd.Value))

        Dim dtData As DataTable = _db.ExecuteStoreProcedureTB(sql, para)
        Dim index As Integer = 0
        For Each r As DataRow In dtData.Rows
            grid.Rows.Add(1)
            grid.Rows(index).Cells("ProductCode").Value = r("ProductCode")
            grid.Rows(index).Cells("Productname").Value = r("Productname")
            grid.Rows(index).Cells("TotalLot").Value = r("TotalLot")
            grid.Rows(index).Cells("TotalNG").Value = r("TotalNG")
            grid.Rows(index).Cells("PercentOK").Value = r("PercentOK")
            grid.Rows(index).Cells("TotalAQL").Value = r("TotalAQL")
            grid.Rows(index).Cells("TotalDefect").Value = r("TotalDefect")
            grid.Rows(index).Cells("PercentLoi").Value = r("PercentLoi")
            index += 1
        Next

        LoadDetail()
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub
End Class