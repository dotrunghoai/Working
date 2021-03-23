Imports CommonDB
Imports PublicUtility
Imports LibEntity

Public Class FrmETAList
    Dim nvd As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim param(0) As SqlClient.SqlParameter
    Public statusShow As Integer = 0

    Private Sub FrmETAList_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ETAList(Date.Now.Date)
        If GridView1.RowCount = 0 And statusShow = 0 Then
            Me.Close()
        End If
    End Sub

    Sub ETAList(ByVal etaDate As Date)
        param(0) = New SqlClient.SqlParameter("@etadate", etaDate)

        Dim sql As String = String.Format(" select d.OrderID, d.JCode, d.JName, d.MinQty,  d.Quantity, d.Unit," +
                                          " d.POID, d.DeliveryDate, " +
                                          " d.ETADate, d.ETADate2, d.LastVendorCode, d.LastVendorName, d.UnitPrice, d.CurrencyCode " +
                                          " from {0} d " +
                                          " where d.ETADate = @etadate or d.ETADate2 = @etadate",
                                          PublicTable.Table_GSR_GoodsOrderDetail)


        GridControl1.DataSource = nvd.FillDataTable(sql, param)
        GridControlSetFormat(GridView1, 3)
    End Sub

    Private Sub dtpETADate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpETADate.TextChanged
        ETAList(dtpETADate.Value.Date)
    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        GridControlExportExcel(GridView1)
    End Sub
End Class