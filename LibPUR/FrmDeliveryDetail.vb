Imports CommonDB
Imports PublicUtility
Imports System.Windows.Forms

Public Class FrmDeliveryDetail : Inherits DevExpress.XtraEditors.XtraForm
    Dim nvd As DBSql
    Public idDLVR As String
    Public jcodeDLVR As String
    Public orderDLVR As Integer
    Public obj As FrmGSRFollowETA


    Private Sub FrmDeliveryDetail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmDeliveryDetail_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        nvd = New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        Dim sql As String = String.Format("select * from GSR_GoodsDetail where ID = '{0}' and JCode = '{1}' and OrderID = '{2}' order by OrderNo", idDLVR, jcodeDLVR, orderDLVR)
        Dim bd As New BindingSource()
        bd.DataSource = nvd.FillDataTable(sql)
        gridDLRV.DataSource = bd
        gridDLRV.AutoResizeColumns()
    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        Dim sql As String = String.Format("select * from GSR_GoodsDetail where ID = '{0}' and JCode = '{1}' and OrderID = '{2}' order by OrderNo", idDLVR, jcodeDLVR, orderDLVR)
        Dim dt As DataTable = nvd.FillDataTable(sql)
        ExportEXCEL(dt)
    End Sub
End Class