Imports System.Windows.Forms
Imports CommonDB
Imports PublicUtility
'Imports LibEntity

Public Class FrmMsJCode : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Sub LoadAll()
        _db.ExecuteStoreProcedure("sp_EMM_UpdateJCodeName")
        Dim sql As String = String.Format("Select * from {0} order by JCode",
                                          PublicTable.Table_EMM_MasterJCode)

        GridControl1.DataSource = _db.FillDataTable(sql)
        GridControlSetFormat(GridView1, 4)
        GridControlSetColorReadonly(GridView1)
    End Sub

    Private Sub FrmMasterJCode_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        If GridView1.SelectedRowsCount = 0 Then Exit Sub

        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            Dim objDelete As New EMM_MasterJCode
            objDelete.JCode_K = GridView1.GetFocusedRowCellValue("JCode")
            _db.Delete(objDelete)
        End If
    End Sub

    Private Sub mnuShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAll.Click
        LoadAll()
    End Sub

    Private Sub mnuImport_Click(sender As System.Object, e As System.EventArgs) Handles mnuImport.Click
        Dim arrSheet(0) As String
        arrSheet(0) = "MasterJCodeImport"
        Dim iCount As Integer = 0
        Dim dataset As DataSet = ImportEXCEL(arrSheet)
        If dataset IsNot Nothing And dataset.Tables.Count > 0 Then
            Try
                _db.BeginTransaction()
                Dim counterr As Integer = 1
                For Each row As DataRow In dataset.Tables("MasterJCodeImport").Rows
                    counterr += 1
                    Dim obj As New EMM_MasterJCode
                    If row("JCode") IsNot DBNull.Value And row("JCode") IsNot Nothing Then
                        obj.JCode_K = row("JCode")
                        _db.GetObjectNotReset(obj)
                    Else
                        Continue For
                    End If

                    obj.FirstSpecCode = IIf(row("FirstSpecCode") Is DBNull.Value, "", row("FirstSpecCode"))
                    obj.LastSpecCode = IIf(row("LastSpecCode") Is DBNull.Value, "", row("LastSpecCode"))
                    obj.Rank = IIf(row("Rank") Is DBNull.Value, "", row("Rank"))
                    obj.JName = IIf(row("JName") Is DBNull.Value, "", row("JName"))
                    obj.SupplierCode = IIf(row("SupplierCode") Is DBNull.Value, "", row("SupplierCode"))
                    obj.SupplierName = IIf(row("SupplierName") Is DBNull.Value, "", row("SupplierName"))
                    obj.MakerCode = IIf(row("MakerCode") Is DBNull.Value, "", row("MakerCode"))
                    obj.MakerName = IIf(row("MakerName") Is DBNull.Value, "", row("MakerName"))
                    obj.CheckingMethod = IIf(row("CheckingMethod") Is DBNull.Value, "", row("CheckingMethod"))
                    obj.JCodeGroup = IIf(row("JCodeGroup") Is DBNull.Value, "", row("JCodeGroup"))
                    obj.ExpiryDescription = IIf(row("ExpiryDescription") Is DBNull.Value, 0, row("ExpiryDescription"))
                    obj.ExpiryProduction = IIf(Not IsNumeric(row("ExpiryProduction")), 0, row("ExpiryProduction"))
                    obj.ExpiryDelivery = IIf(Not IsNumeric(row("ExpiryDelivery")), 0, row("ExpiryDelivery"))

                    obj.WinThinProduction = IIf(Not IsNumeric(row("WinThinProduction")), 0, row("WinThinProduction"))
                    obj.SampleLotNo = IIf(row("SampleLotNo") Is DBNull.Value, "", row("SampleLotNo"))
                    obj.DescriptionLotNo = IIf(row("DescriptionLotNo") Is DBNull.Value, "", row("DescriptionLotNo"))
                    obj.StorageCondition = IIf(row("StorageCondition") Is DBNull.Value, "", row("StorageCondition"))
                    obj.UpdateDate = IIf(row("UpdateDate") Is DBNull.Value, DateTime.MinValue, row("UpdateDate"))
                    obj.Packing = IIf(row("Packing") Is DBNull.Value, "", row("Packing"))
                    obj.UnitCodeAS400 = IIf(row("UnitCodeAS400") Is DBNull.Value, "", row("UnitCodeAS400"))
                    obj.UnitCodeIQC = IIf(row("UnitCodeIQC") Is DBNull.Value, "", row("UnitCodeIQC"))
                    obj.QtyOfCartonIQC = IIf(Not IsNumeric(row("QtyOfCartonIQC")), 0, row("QtyOfCartonIQC"))
                    obj.UnitCarton = IIf(row("UnitCarton") Is DBNull.Value, "", row("UnitCarton"))
                    obj.SpecPurCode = IIf(row("SpecPurCode") Is DBNull.Value, "", row("SpecPurCode"))
                    obj.Purpose = IIf(row("Purpose") Is DBNull.Value, "", row("Purpose"))
                    obj.UseSec = IIf(row("UseSec") Is DBNull.Value, "", row("UseSec"))
                    obj.KiemDauVao = IIf(row("KiemDauVao") Is DBNull.Value, "", row("KiemDauVao"))
                    obj.KhoLuu = IIf(row("KhoLuu") Is DBNull.Value, "", row("KhoLuu"))
                    obj.IsCarton = IIf(row("IsCarton") Is DBNull.Value, False, row("IsCarton"))
                    obj.CustomerName = IIf(row("CustomerName") Is DBNull.Value, "", row("CustomerName"))
                    If UCase(obj.DescriptionLotNo) = "THEO NGÀY NHẬP" Then
                        obj.InIncommingDate = 1
                    End If
                    If _db.ExistObject(obj) Then
                        _db.Update(obj)
                    Else
                        _db.Insert(obj)
                    End If

                    iCount += 1
                    Application.DoEvents()
                Next
                _db.Commit()
                ShowSuccess(iCount)
            Catch ex As Exception
                _db.RollBack()
                ShowWarning(ex.Message)
            End Try
        Else
            ShowWarning("Không có dữ liệu để import !")
        End If
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub mnuImportKho_Click(sender As System.Object, e As System.EventArgs) Handles mnuImportKho.Click
        Dim dtItem As DataTable = ImportEXCEL(True)
        If dtItem.Rows.Count > 0 Then
            Try
                _db.BeginTransaction()
                For Each r As DataRow In dtItem.Rows
                    If r("JCode") Is DBNull.Value Then Continue For
                    Dim obj As New EMM_MasterJCode
                    obj.JCode_K = r("JCode")
                    _db.GetObject(obj)
                    If r("TenKho") IsNot DBNull.Value Then
                        obj.KhoLuu = r("TenKho")
                    Else
                        obj.KhoLuu = ""
                    End If
                    _db.Update(obj)
                Next
                _db.Commit()
                ShowSuccess()
            Catch ex As Exception
                _db.RollBack()
                ShowWarning(ex.Message)
            End Try
        Else
            ShowWarning("Không có dữ liệu để import !")
        End If
    End Sub

    Private Sub mnuEdit_Click(sender As Object, e As EventArgs) Handles mnuEdit.Click
        GridControlReadOnly(GridView1, False)
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.ReadOnly = False And GridView1.Editable Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            Dim sql As String = String.Format(" update [EMM_MasterJCode]" +
                                              " set {0}=@Value " +
                                              " where JCode='{1}'",
                                              e.Column.FieldName,
                                              GridView1.GetFocusedRowCellValue("JCode"))
            _db.ExecuteNonQuery(sql, para)
        End If
    End Sub
End Class