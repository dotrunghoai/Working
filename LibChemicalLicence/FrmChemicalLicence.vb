Imports System.IO
Imports CommonDB
Imports PublicUtility
Public Class FrmChemicalLicence
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim myPath As String = CurrentUser.TempFolder & "LO_ChemicalLicence\"
    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "ShowNew")
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_LO_CL_ChemicalLicence", para)
        GridControlSetFormat(GridView1, 1)
        GridControlReadOnly(GridView1, False)
        GridView1.Columns("AttachFile").OptionsColumn.ReadOnly = True
        GridControlSetColorEdit(GridView1)
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridView1.Columns("AttachFile").ColumnEdit = GridControlLinkEdit()
        GridView1.Columns("TradeName").Width = 200
        GridView1.Columns("ChemicalLicence").Width = 100
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable = True And e.Column.ReadOnly = False Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            If e.RowHandle < 0 Then
                If GridView1.GetFocusedRowCellValue("IssueDate") Is DBNull.Value Then
                    ShowWarning("Bạn phải nhập Issue Date và PurCode trước !")
                    Return
                ElseIf GridView1.GetFocusedRowCellValue("PurCode") Is DBNull.Value Then
                    Return
                End If
                Dim obj As New LO_CL_ChemicalLicence
                obj.IssueDate_K = GridView1.GetFocusedRowCellValue("IssueDate")
                obj.PurCode_K = GridView1.GetFocusedRowCellValue("PurCode")
                If Not _db.ExistObject(obj) Then
                    _db.Insert(obj)
                End If
            Else
                Dim paraOld(1) As SqlClient.SqlParameter
                paraOld(0) = New SqlClient.SqlParameter("@Value", e.Value)
                If e.Column.FieldName = "IssueDate" Then
                    paraOld(1) = New SqlClient.SqlParameter("@IssueDate", GridView1.ActiveEditor.OldEditValue)
                    _db.ExecuteNonQuery(String.Format("UPDATE LO_CL_ChemicalLicence
                                                        SET IssueDate = @Value
                                                        WHERE IssueDate = @IssueDate
                                                        AND PurCode = '{0}'",
                                                        GridView1.GetFocusedRowCellValue("PurCode")), paraOld)
                ElseIf e.Column.FieldName = "PurCode" Then
                    paraOld(1) = New SqlClient.SqlParameter("@IssueDate", GridView1.GetFocusedRowCellValue("IssueDate"))
                    _db.ExecuteNonQuery(String.Format("UPDATE LO_CL_ChemicalLicence
                                                        SET PurCode = '{0}'
                                                        WHERE IssueDate = @IssueDate
                                                        AND PurCode = '{1}'",
                                                        GridView1.GetFocusedRowCellValue("PurCode"),
                                                        GridView1.ActiveEditor.OldEditValue), para)
                End If
            End If

            Dim sqlUpdate As String = String.Format("UPDATE LO_CL_ChemicalLicence
                                                     SET {0} = @Value
                                                     WHERE IssueDate = '{1}'
                                                     AND PurCode = '{2}'",
                                                     e.Column.FieldName,
                                                     GridView1.GetFocusedRowCellValue("IssueDate"),
                                                     GridView1.GetFocusedRowCellValue("PurCode"))
            _db.ExecuteNonQuery(sqlUpdate, para)
        End If
    End Sub

    Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
        Dim dt As DataTable = ImportEXCEL(True)
        Dim count As Integer = 0
        For Each r As DataRow In dt.Rows
            Dim obj As New LO_CL_ChemicalLicence
            obj.IssueDate_K = r("Issue Date")
            obj.PurCode_K = r("Pur Code")
            obj.ChemicalLicence = r("Chemical Licence")
            obj.ExpiryDate = r("Expiry Date")
            obj.CDFrom = r("CD From")
            obj.CDTo = r("CDTo")
            obj.TradeName = r("Trade Name")
            obj.IUPAC = r("IUPAC")
            obj.Formula = r("Formula")
            obj.CAS = r("CAS")
            obj.Content = r("Content")
            obj.Quantity = r("Quantity")
            obj.Unit = r("Unit")
            If _db.ExistObject(obj) Then
                _db.Update(obj)
            Else
                _db.Insert(obj)
                count += 1
            End If
        Next
        ShowSuccess(String.Format("Import thành công {0} dữ liệu !", count))
        btnShow.PerformClick()
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "ShowAll")
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_LO_CL_ChemicalLicence", para)
        GridControlSetFormat(GridView1, 1)
        GridView1.Columns("TradeName").Width = 200
        GridView1.Columns("ChemicalLicence").Width = 100
        GridView1.Columns("AttachFile").ColumnEdit = GridControlLinkEdit()
        GridControlSetFormatPercentage(GridView1, "Content", 2)
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        If GridControl1.DataSource IsNot Nothing Then
            GridControlExportExcel(GridView1)
        End If
    End Sub

    Private Sub btnAddFile_Click(sender As Object, e As EventArgs) Handles btnAddFile.Click
        Dim frm As New OpenFileDialog
        frm.ShowDialog()
        If frm.FileName <> "" Then
            Dim IssueDate As DateTime = GridView1.GetFocusedRowCellValue("IssueDate")
            Dim AttachFile = frm.SafeFileName
            Dim AttachFileLink = myPath & IssueDate.ToString("dd-MM-yyyy") & "_" & GridView1.GetFocusedRowCellValue("ChemicalLicence").ToString.Replace("/", "_") & "_LO_CL_" & frm.SafeFileName
            File.Copy(frm.FileName, AttachFileLink, True)

            _db.ExecuteNonQuery(String.Format("UPDATE LO_CL_ChemicalLicence
                                                SET AttachFile = N'{0}',
                                                    AttachFileLink = N'{1}'
                                                WHERE ChemicalLicence = '{2}'",
                                                AttachFile,
                                                AttachFileLink,
                                                GridView1.GetFocusedRowCellValue("ChemicalLicence")))
            For r = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(r, "ChemicalLicence") = GridView1.GetFocusedRowCellValue("ChemicalLicence") Then
                    GridView1.SetRowCellValue(r, "AttachFile", AttachFile)
                    GridView1.SetRowCellValue(r, "AttachFileLink", AttachFileLink)
                End If
            Next
        End If
        frm.Dispose()
    End Sub

    Private Sub btnDeleteFile_Click(sender As Object, e As EventArgs) Handles btnDeleteFile.Click
        If Not IsDBNull(GridView1.GetFocusedRowCellValue("AttachFile")) Then
            If GridView1.GetFocusedRowCellValue("AttachFile") <> "" Then
                Dim obj As New LO_CL_ChemicalLicence
                obj.IssueDate_K = GridView1.GetFocusedRowCellValue("IssueDate")
                obj.PurCode_K = GridView1.GetFocusedRowCellValue("PurCode")
                _db.GetObject(obj)
                File.Delete(obj.AttachFileLink)
                _db.ExecuteNonQuery(String.Format("UPDATE LO_CL_ChemicalLicence
                                                   SET AttachFile = '',
                                                   AttachFileLink = ''
                                                   WHERE ChemicalLicence = '{0}'",
                                                   GridView1.GetFocusedRowCellValue("ChemicalLicence")))
                For r = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(r, "ChemicalLicence") = GridView1.GetFocusedRowCellValue("ChemicalLicence") Then
                        GridView1.SetRowCellValue(r, "AttachFile", "")
                        GridView1.SetRowCellValue(r, "AttachFileLink", "")
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowClick
        If GridView1.FocusedColumn.FieldName = "AttachFile" Then
            Dim obj As New LO_CL_ChemicalLicence
            obj.IssueDate_K = GridView1.GetFocusedRowCellValue("IssueDate")
            obj.PurCode_K = GridView1.GetFocusedRowCellValue("PurCode")
            _db.GetObject(obj)
            If Not IsDBNull(obj.AttachFile) Then
                If obj.AttachFile <> "" Then
                    Process.Start(OpenfileTemp(obj.AttachFileLink))
                End If
            End If
        End If
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        If GridView1.RowCount > 0 Then
            GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            GridControlReadOnly(GridView1, False)
            GridView1.Columns("IssueDate").OptionsColumn.ReadOnly = True
            GridView1.Columns("PurCode").OptionsColumn.ReadOnly = True
            GridView1.Columns("AttachFile").OptionsColumn.ReadOnly = True
            GridControlSetColorEdit(GridView1)
        End If
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu ?") = DialogResult.Yes Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@IssueDate", GridView1.GetFocusedRowCellValue("IssueDate"))
            _db.ExecuteNonQuery(String.Format("DELETE LO_CL_ChemicalLicence
                                 WHERE IssueDate = @IssueDate
                                 AND PurCode = '{0}'", GridView1.GetFocusedRowCellValue("PurCode")), para)
            GridView1.DeleteSelectedRows()
        End If
    End Sub
End Class