﻿Imports CommonDB
Imports PublicUtility
Public Class FrmBomMaster
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmBomMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShow.PerformClick()
    End Sub
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_PLM_LoadBomMaster")
        GridControlSetFormat(GridView1)
        GridControlSetFormatNumber(GridView1, "Std_StdQtyP", 8)
        GridControlSetFormatNumber(GridView1, "Adjust", 8)
        GridControlSetFormatPercentage(GridView1, "Percentage", 2)
        GridView1.Columns("NameMatCode").Width = 150
    End Sub

    Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
        Dim dt = ImportEXCEL(True)
        If dt.Rows.Count > 0 Then
            Try
                Dim succ As Integer = 0
                _db.BeginTransaction()
                For Each r As DataRow In dt.Rows
                    If IsDBNull(r("Std_Pd Code")) Then Continue For
                    Dim obj As New PLM_Bom_B0
                    obj.TuanImport_K = r("Tuan Import")
                    obj.Std_PdCode_K = r("Std_Pd Code")
                    obj.Std_Rc_K = r("Std_Rc")
                    obj.Std_Cc_K = r("Std_Cc")
                    obj.Std_Pn_K = r("Std_Pn")
                    obj.Std_MatCode_K = r("Std_Mat Code")

                    'Kiểm tra JCode mới
                    Dim objJCode As New PLM_MaterialMaster
                    objJCode.JCode_K = obj.Std_MatCode_K
                    If Not _db.ExistObject(objJCode) Then
                        objJCode.LTPoNDV = 0
                        objJCode.LTUseNDV = 0
                        objJCode.MOQNDV = 1
                        objJCode.LTPoBWH = 0
                        objJCode.LTUseBWH = 0
                        objJCode.MOQBWH = 1
                        _db.Insert(objJCode)
                    End If

                    obj.Std_PrcCode = r("Std_Prc Code")
                    obj.Std_StdQtyP = r("Std_Std Qty P")
                    obj.Adjust = r("Adjust")
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
                ShowWarning(ex.Message)
            End Try
        Else
            ShowWarning("Không có dữ liệu !")
        End If
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("Adjust").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            Dim para(1) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            para(1) = New SqlClient.SqlParameter("@UpdateDate", DateTime.Now)
            _db.ExecuteNonQuery(String.Format(" UPDATE PLM_Bom_B0
                                                SET {0} = @Value,
                                                UpdateUser = '{1}',
                                                UpdateDate = @UpdateDate
                                                WHERE TuanImport = '{2}'
                                                AND Std_PdCode = '{3}'
                                                AND Std_Rc = '{4}'
                                                AND Std_Cc = '{5}'
                                                AND Std_Pn = '{6}'
                                                AND Std_MatCode = '{7}'",
                                                e.Column.FieldName,
                                                CurrentUser.UserID,
                                                GridView1.GetFocusedRowCellValue("TuanImport"),
                                                GridView1.GetFocusedRowCellValue("Std_PdCode"),
                                                GridView1.GetFocusedRowCellValue("Std_Rc"),
                                                GridView1.GetFocusedRowCellValue("Std_Cc"),
                                                GridView1.GetFocusedRowCellValue("Std_Pn"),
                                                GridView1.GetFocusedRowCellValue("Std_MatCode")), para)
        End If
    End Sub
End Class