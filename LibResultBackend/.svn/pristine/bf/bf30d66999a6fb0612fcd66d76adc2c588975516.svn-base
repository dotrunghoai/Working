Imports CommonDB
Imports DevExpress.XtraGrid.Views.Grid
Imports PublicUtility
Public Class FrmXuatBackendResult
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmXuatBackendResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteStartDate.EditValue = DateTime.Now
        dteStartDate.EditValue = GetFirstDayOfWeek(dteStartDate.DateTime)
        dteEndDate.EditValue = LastDayOfWeek(dteStartDate.DateTime)
        Dim dtCus As DataTable = _db.FillDataTable("SELECT DISTINCT PR.CustomerName
                                                    FROM QC_KQCV_BackendResult_Detail AS H
                                                    LEFT JOIN WT_Product AS PR
                                                    ON H.ProductCode = PR.ProductCode")
        cbbCustomer.Properties.Items.Add("Normal")
        For Each r As DataRow In dtCus.Rows
            cbbCustomer.Properties.Items.Add(r("CustomerName"))
        Next
        cbbCustomer.SelectedIndex = 0
    End Sub

    Private Sub dteStartDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteStartDate.EditValueChanged
        If dteStartDate.DateTime > dteEndDate.DateTime Then
            dteEndDate.EditValue = dteStartDate.DateTime
        End If
    End Sub

    Private Sub dteEndDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteEndDate.EditValueChanged
        If dteEndDate.DateTime < dteStartDate.DateTime Then
            dteStartDate.EditValue = dteEndDate.DateTime
        End If
    End Sub

    Private Sub rdoDay_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDay.CheckedChanged
        If rdoDay.Checked Then
            dteStartDate.EditValue = DateTime.Now
            dteEndDate.EditValue = DateTime.Now
        End If
    End Sub

    Private Sub rdoWeek_CheckedChanged(sender As Object, e As EventArgs) Handles rdoWeek.CheckedChanged
        If rdoWeek.Checked Then
            dteStartDate.EditValue = DateTime.Now
            dteStartDate.EditValue = GetFirstDayOfWeek(dteStartDate.DateTime)
            dteEndDate.EditValue = LastDayOfWeek(dteStartDate.DateTime)
        End If
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(5) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", dteStartDate.DateTime.Date)
        para(1) = New SqlClient.SqlParameter("@EndDate", dteEndDate.DateTime.Date)
        If cbbCustomer.Text = "Normal" Then
            para(2) = New SqlClient.SqlParameter("@Customer", DBNull.Value)
        Else
            para(2) = New SqlClient.SqlParameter("@Customer", cbbCustomer.Text)
        End If
        If rdoAllSide.Checked Then
            para(3) = New SqlClient.SqlParameter("@Method", DBNull.Value)
        ElseIf rdoSingleSide.Checked Then
            para(3) = New SqlClient.SqlParameter("@Method", rdoSingleSide.Text)
        Else
            para(3) = New SqlClient.SqlParameter("@Method", rdoDoubleSide.Text)
        End If
        para(4) = New SqlClient.SqlParameter("@Action", "XuatBackend")
        para(5) = New SqlClient.SqlParameter("@ActionSub", "XuatDetail")
        Dim dt As DataTable = _db.ExecuteStoreProcedureTB("sp_QC_KQCV_BackendResult", para)
        If dt.Rows.Count > 0 Then
            GridControl1.DataSource = dt
            GridControlSetFormat(GridView1)
            GridView1.Columns("CongDoan").Width = 140
            GridView1.Columns("SoLotPhatHien").Width = 100
            GridView1.Columns("SoLuongLoi").Width = 80
        Else
            ShowWarning("Không có dữ liệu !")
            Return
        End If
        para(5) = New SqlClient.SqlParameter("@ActionSub", "XuatHead")
        dt = _db.ExecuteStoreProcedureTB("sp_QC_KQCV_BackendResult", para)
        GridControl2.DataSource = dt
        GridControlSetFormat(GridView2)
        GridView2.Columns("CongDoan").Width = 140
        GridView2.Columns("TongSoLotPhatHien").Width = 125
        GridView2.Columns("TongSoLuongLoi").Width = 125
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        Dim listGrid As New List(Of GridView)
        Dim isContent As Boolean = False
        If GridView1.RowCount > 0 Then
            listGrid.Add(GridView1)
            isContent = True
        End If
        If GridView2.RowCount > 0 Then
            listGrid.Add(GridView2)
            isContent = True
        End If
        If isContent Then
            GridControlExportExcels(listGrid, True, , "Backend Result", False)
        End If
    End Sub

    Private Sub btnChart_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnChart.ItemClick
        If GridView2.RowCount > 0 Then
            Dim frm As New FrmChart
            frm._title = "KẾT QUẢ KIỂM QUY TRÌNH TẠI CÔNG ĐOẠN (" + dteStartDate.DateTime.ToString("dd.MM") + " - " + dteEndDate.DateTime.ToString("dd.MM") + ")"
            frm._dt = GridControl2.DataSource
            frm.ChartSum()
            frm.Show()
        End If
    End Sub
End Class