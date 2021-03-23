Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmDataHead : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dteStart.DateTime))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dteEnd.DateTime))
        If txtProductCode.Text.Trim <> "" Then
            para(2) = New SqlClient.SqlParameter("@ProductCode", txtProductCode.Text.Trim.PadLeft(5, "0"))
        Else
            para(2) = New SqlClient.SqlParameter("@ProductCode", Nothing)
        End If
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_QCS_LoadHeadData", para)
        GridControlSetFormat(GridView1)
    End Sub

    Private Sub btnView_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnView.ItemClick
        If GridView1.GetFocusedRowCellValue("ProductCode") IsNot Nothing Then
            Dim frm As New FrmDataDetail_2
            frm._ProductCode = GridView1.GetFocusedRowCellValue("ProductCode")
            frm._LotNo = GridView1.GetFocusedRowCellValue("LotNo")
            frm._CongDoan = GridView1.GetFocusedRowCellValue("Process")
            frm._LotNo = GridView1.GetFocusedRowCellValue("LotNo")
            frm._SoLantest = GridView1.GetFocusedRowCellValue("SoLanTest")
            frm.Show()
        End If
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        Dim frm As New FrmDataDetail_2
        frm.Show()
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        btnView.PerformClick()
    End Sub

    Private Sub FrmDataHead_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteStart.EditValue = DateTime.Now
        dteEnd.EditValue = DateTime.Now
    End Sub

    Private Sub dteStart_EditValueChanged(sender As Object, e As EventArgs) Handles dteStart.EditValueChanged
        If dteStart.DateTime > dteEnd.DateTime Then
            dteEnd.EditValue = dteStart.DateTime
        End If
    End Sub

    Private Sub dteEnd_EditValueChanged(sender As Object, e As EventArgs) Handles dteEnd.EditValueChanged
        If dteEnd.DateTime < dteStart.DateTime Then
            dteStart.EditValue = dteEnd.DateTime
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        If GridView1.RowCount > 0 Then
            GridControlExportExcel(GridView1)
        End If
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If GridView1.RowCount > 0 Then
            If ShowQuestion("Bạn có chắc muốn xóa dữ liệu ?") = DialogResult.Yes Then
                Dim para(3) As SqlClient.SqlParameter
                para(0) = New SqlClient.SqlParameter("@ProductCode", GridView1.GetFocusedRowCellValue("ProductCode"))
                para(1) = New SqlClient.SqlParameter("@Process", GridView1.GetFocusedRowCellValue("Process"))
                para(2) = New SqlClient.SqlParameter("@LotNo", GridView1.GetFocusedRowCellValue("LotNo"))
                para(3) = New SqlClient.SqlParameter("@SoLanTest", GridView1.GetFocusedRowCellValue("SoLanTest"))
                _db.ExecuteNonQuery("delete QCS_DataHead where ProductCode = @ProductCode and Process = @Process and LotNo = @LotNo and SoLanTest = @SoLanTest", para)
                '_db.ExecuteNonQuery("delete QCS_DataDetail where ProductCode = @ProductCode and Process = @Process and LotNo = @LotNo and SoLanTest = @SoLanTest", para)
                GridView1.DeleteSelectedRows()
            End If
        End If
    End Sub
End Class