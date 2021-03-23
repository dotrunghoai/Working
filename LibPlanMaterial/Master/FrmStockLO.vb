Imports CommonDB
Imports PublicUtility
Public Class FrmStockLO
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmStockLO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteDate.EditValue = Date.Now
        btnShow.PerformClick()
    End Sub
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.FillDataTable("SELECT TuanImport, Stock, EntryDate, JCode, JName, UnitCode, 
                                                    TotalQty, GoodQty, Picked, DamagedQty, HeldQty, GroupName
                                                    FROM PLM_StockLO 
                                                    ORDER BY TuanImport DESC, JCode")
        GridControlSetFormat(GridView1, 3)
    End Sub

    Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
        Dim dt As DataTable = ImportEXCEL(True)
        If dt.Rows.Count > 0 Then
            Try
                _db.BeginTransaction()
                Dim succ As Integer = 0
                Dim tuanImp As String = "W" + CType(dteDate.EditValue, Date).ToString("yyyyMMdd")
                For Each r As DataRow In dt.Rows
                    If IsDBNull(r("JCode")) Then Continue For
                    Dim obj As New PLM_StockLO
                    obj.TuanImport_K = tuanImp
                    obj.JCode_K = r("JCode")
                    obj.EntryDate = r("Entry Date")
                    obj.JName = r("JName")
                    obj.UnitCode = r("Unit Code")
                    obj.TotalQty = r("Total Qty")
                    obj.GoodQty = r("Good Qty")
                    obj.Picked = r("Picked")
                    obj.DamagedQty = r("Damaged Qty")
                    obj.HeldQty = r("Held Qty")
                    obj.GroupName = r("Group Name")
                    obj.Stock = r("Good Qty") + r("Damaged Qty") + r("Held Qty")
                    obj.CreateUser = CurrentUser.UserID
                    obj.CreateDate = DateTime.Now
                    If _db.ExistObject(obj) Then
                        _db.Update(obj)
                    Else
                        _db.Insert(obj)
                        succ += 1
                    End If
                Next
                ShowSuccess(succ)
                _db.Commit()
            Catch ex As Exception
                _db.RollBack()
                ShowWarning(ex.Message)
            End Try
        Else
            ShowWarning("Không có dữ liệu import !")
        End If
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("GroupName").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(String.Format("UPDATE PLM_StockLO
                                               SET {0} = @Value
                                               WHERE TuanImport = '{1}'
                                               AND JCode = '{2}'",
                                               e.Column.FieldName,
                                               GridView1.GetFocusedRowCellValue("TuanImport"),
                                               GridView1.GetFocusedRowCellValue("JCode")), para)
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub
End Class