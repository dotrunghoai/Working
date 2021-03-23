﻿Imports CommonDB
Imports PublicUtility
Public Class FrmStockBWH
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmStockBWH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteDate.EditValue = Date.Now
        btnShow.PerformClick()
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.FillDataTable("SELECT TuanImport, JCode, Qty
                                                     FROM PLM_StockBWH
                                                     ORDER BY TuanImport DESC, JCode")
        GridControlSetFormat(GridView1)
    End Sub

    Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
        Dim dt As DataTable = ImportEXCEL(True)
        If dt.Rows.Count > 0 Then
            Dim succ = 0
            Dim err = 0
            Try
                _db.BeginTransaction()
                Dim tuanIp As String = "W" + GetFirstDayOfWeek(dteDate.EditValue).ToString("yyyyMMdd")
                Dim obj As New PLM_StockBWH
                obj.TuanImport_K = tuanIp
                For Each r As DataRow In dt.Rows
                    err += 1
                    obj.JCode_K = r("JCode")
                    obj.Qty = r("Qty")
                    obj.CreateUser = CurrentUser.UserID
                    obj.CreateDate = DateTime.Now
                    If _db.ExistObject(obj) Then
                        _db.Update(obj)
                    Else
                        _db.Insert(obj)
                        succ += 1
                    End If
                Next
                _db.Commit()
                ShowSuccess(succ)
            Catch ex As Exception
                _db.RollBack()
                ShowWarning(ex.Message + " - " + err.ToString)
            End Try
        Else
            ShowWarning("Không có dữ liệu import !")
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub
End Class