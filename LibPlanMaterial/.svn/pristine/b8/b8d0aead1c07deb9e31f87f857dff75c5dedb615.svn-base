Imports CommonDB
Imports LibEntity
Imports PublicUtility

Public Class FrmPO

    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub mnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
        Dim sql As String = String.Format("sp_PLM_LoadPO")
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Tuan", dtpTuan.Value.Date)
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB(sql, para)
        GridControlSetFormat(GridView1, 3)
        GridControlSetColorReadonly(GridView1)
    End Sub

    Private Sub mnuExport_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub FrmPO_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        dtpTuan.Value = GetFirstDayOfWeek(Date.Now)
        mnuShowAll.PerformClick()
    End Sub

    Private Sub mnuImport_Click(sender As Object, e As EventArgs) Handles mnuImport.Click
        Dim dtImport As DataTable = ImportEXCEL(True)
        If dtImport.Rows.Count = 0 Then
            ShowWarning("Không có dữ liệu import !")
            Return
        End If
        For Each r As DataRow In dtImport.Rows
            Dim obj As New PLM_PO
            obj.Tuan_K = dtpTuan.Value.Date
            obj.ProductCode_K = r("ProductCode")
            If IsNumeric(r("Qty")) Then
                obj.Qty = r("Qty")
            End If
            If IsNumeric(r("Adjust")) Then
                obj.Adjust = r("Adjust")
            End If
            obj.CreateDate = Date.Now
            obj.CreateUser = CurrentUser.UserID
            If _db.ExistObject(obj) Then
                _db.Update(obj)
            Else
                _db.Insert(obj)
            End If
        Next
        ShowSuccess()
        mnuShowAll.PerformClick()
    End Sub

    Private Sub mnuEdit_Click(sender As Object, e As EventArgs) Handles mnuEdit.Click
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("Adjust").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub


    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            Dim obj As New PLM_PO
            obj.Tuan_K = GridView1.GetFocusedRowCellValue("Tuan")
            obj.ProductCode_K = GridView1.GetFocusedRowCellValue("ProductCode")
            _db.GetObject(obj)
            If IsNumeric(GridView1.GetFocusedRowCellValue("Adjust")) Then
                obj.Adjust = GridView1.GetFocusedRowCellValue("Adjust")
            Else
                obj.Adjust = 0
            End If
            obj.CreateDate = Date.Now
            obj.CreateUser = CurrentUser.UserID
            _db.Update(obj)
        End If
    End Sub
End Class