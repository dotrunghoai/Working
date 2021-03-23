
Imports CommonDB
Imports LibEntity
Imports PublicUtility
Imports System.Windows.Forms

Public Class FrmSumDataKTPL : Inherits DevExpress.XtraEditors.XtraForm
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)


    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Start", GetStartDate(dtpStart.Value))
        para(1) = New SqlClient.SqlParameter("@End", GetStartDate(dtpEnd.Value))
        Dim sql As String = String.Format("[sp_MDQA_LoadKTPL]")
        Dim bd As New BindingSource
        Dim dt = _db.ExecuteStoreProcedureTB(sql, para)
        For r = 0 To dt.Rows.Count - 1
            If r < dt.Rows.Count - 1 Then
                If dt.Rows(r)("ProductCode") = dt.Rows(r + 1)("ProductCode") And
                    dt.Rows(r)("LotNo") = dt.Rows(r + 1)("LotNo") And
                    dt.Rows(r)("GhiChu") = dt.Rows(r + 1)("GhiChu") Then
                    dt.Rows(r + 1)("LotQty") = DBNull.Value
                    dt.Rows(r + 1)("AQL") = DBNull.Value
                    dt.Rows(r + 1)("TotalAQL") = DBNull.Value
                    dt.Rows(r + 1)("TotalDefect") = DBNull.Value
                End If
            End If
        Next
        bd.DataSource = dt
        bdn.BindingSource = bd
        grid.DataSource = bd
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub
    Private Sub txtPdCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPdCode.TextChanged
        If bdn.BindingSource IsNot Nothing Then
            If txtPdCode.Text = "" Then
                bdn.BindingSource.Filter = ""
            Else
                bdn.BindingSource.Filter = String.Format("ProductCode like '%{0}%'", txtPdCode.Text)
            End If
        End If
    End Sub

    Private Sub txtLotNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLotNo.TextChanged
        If bdn.BindingSource IsNot Nothing Then
            If txtLotNo.Text = "" Then
                bdn.BindingSource.Filter = ""
            Else
                bdn.BindingSource.Filter = String.Format("LotNo like '%{0}%'", txtLotNo.Text)
            End If
        End If
    End Sub
End Class