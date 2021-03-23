Imports System.Drawing
Imports CommonDB
Imports PublicUtility
Public Class FrmFCMatCode
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmFCMatCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteStartDate.EditValue = Date.Now.AddDays(-15)
        dteEndDate.EditValue = Date.Parse(dteStartDate.EditValue).AddMonths(9)
        Dim dtTuanImp = _db.FillDataTable(" SELECT DISTINCT TuanImport
                                            FROM PLM_FC_Boo
                                            ORDER BY TuanImport DESC")
        For Each r As DataRow In dtTuanImp.Rows
            cbbTuanImport.Properties.Items.Add(r("TuanImport"))
        Next
        cbbTuanImport.SelectedIndex = 0
    End Sub

    'Private Sub dteStartDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteStartDate.EditValueChanged
    '    If dteStartDate.EditValue > dteEndDate.EditValue Then
    '        dteEndDate.EditValue = dteStartDate.EditValue
    '    End If
    'End Sub

    'Private Sub dteEndDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteEndDate.EditValueChanged
    '    If dteEndDate.EditValue < dteStartDate.EditValue Then
    '        dteStartDate.EditValue = dteEndDate.EditValue
    '    End If
    'End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        If cbbTuanImport.Text <> "" Then
            GridControl1.DataSource = Nothing
            'SplashScreenManager1.ShowWaitForm()
            Dim para(3) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@TuanImport", cbbTuanImport.Text)
            para(1) = New SqlClient.SqlParameter("@subCol", DBNull.Value)
            para(2) = New SqlClient.SqlParameter("@mainCol", DBNull.Value)
            If rdoNDV.Checked Then
                para(3) = New SqlClient.SqlParameter("@Type", rdoNDV.Text)
            Else
                para(3) = New SqlClient.SqlParameter("@Type", rdoBWH.Text)
            End If

            Dim dtDay = _db.FillDataTable(" SELECT DISTINCT Tuan
                                        FROM PLM_FC_Boo
                                        WHERE TuanImport = @TuanImport
                                        ORDER BY Tuan", para)
            Dim subCol As String = ""
            For r = 0 To dtDay.Rows.Count - 1
                Dim subColSum As String = ""
                For j = 0 To r
                    subColSum += CType(dtDay.Rows(j)("Tuan"), Date).ToString("[dd-MMM]") + "+"
                Next
                subColSum = subColSum.Substring(0, subColSum.Length - 1)
                subCol += "(" + subColSum + ")AS" + CType(dtDay.Rows(r)("Tuan"), Date).ToString("[dd-MMM]") + ","
            Next
            subCol = subCol.Substring(0, subCol.Length - 1)
            Dim a = subCol.Length
            para(1) = New SqlClient.SqlParameter("@subCol", subCol)

            Dim mainCol As String = ""
            For Each r As DataRow In dtDay.Rows
                Dim tuan As String = Date.Parse(r("Tuan")).ToString("[dd-MMM]")
                mainCol += "((" + tuan + "-ISNULL(FG,0))/ISNULL(TLCP,1)-ISNULL(WIP,0))AS" + tuan + ","
            Next
            mainCol = mainCol.Substring(0, mainCol.Length - 1)
            Dim b = mainCol.Length
            para(2) = New SqlClient.SqlParameter("@mainCol", mainCol)

            Dim count = 0
            Dim dt = _db.ExecuteStoreProcedureTB("sp_PLM_LoadFCMatCode", para)
            If dt.Rows.Count > 0 Then
                'Lấy đơn hàng
                For Each r As DataRow In dt.Rows
                    count += 1
                    If IsNumeric(r("PO")) Then
                        If r("PO") < 0 Then
                            r("PO") = 0
                        End If
                    End If
                    For Each c As DataColumn In dt.Columns
                        If dt.Columns.IndexOf(c) > dt.Columns.IndexOf("TTLStock") Then
                            If IsNumeric(r(c)) Then
                                If r(c) > 0 Then
                                    Dim valSum As Decimal = 0.0
                                    For Each cSub As DataColumn In dt.Columns
                                        If dt.Columns.IndexOf(cSub) > dt.Columns.IndexOf("TTLStock") And
                                        dt.Columns.IndexOf(cSub) < dt.Columns.IndexOf(c) Then
                                            valSum += r(cSub)
                                        End If
                                    Next
                                    r(c) = r(c) * r("TLSX") - valSum
                                Else
                                    r(c) = 0
                                End If
                            End If
                        End If
                    Next
                Next

                'Đơn hàng * Std_StdQtyP
                count = 0
                For Each r As DataRow In dt.Rows
                    count += 1
                    For Each c As DataColumn In dt.Columns
                        If dt.Columns.IndexOf(c) > dt.Columns.IndexOf("TTLStock") Then
                            If IsNumeric(r(c)) Then
                                r(c) = r(c) * r("Std_StdQtyP") * (1 + r("HaoPhiGSR"))
                            End If
                        End If
                    Next
                Next

                'Sum theo JCode -> Ra nhu cầu
                count = 0
                For r = 0 To dt.Rows.Count - 1
                    count += 1
                    If r < dt.Rows.Count - 1 Then
                        If dt.Rows(r)("Std_MatCode") = dt.Rows(r + 1)("Std_MatCode") Then
                            For Each c As DataColumn In dt.Columns
                                If dt.Columns.IndexOf(c.ColumnName) > dt.Columns.IndexOf("TTLStock") Then
                                    dt.Rows(r)(c.ColumnName) += dt.Rows(r + 1)(c.ColumnName)
                                End If
                            Next
                            dt.Rows(r)("PO") = IIf(IsNumeric(dt.Rows(r)("PO")), dt.Rows(r)("PO"), 0) + IIf(IsNumeric(dt.Rows(r + 1)("PO")), dt.Rows(r + 1)("PO"), 0)
                            dt.Rows.RemoveAt(r + 1)
                            If r > 0 Then
                                r -= 1
                            End If
                        End If
                    End If
                Next

                Dim dtCopy = dt.Copy

                'Lấy dữ liệu hàng chưa về
                Dim dtGSR As New DataTable
                If rdoNDV.Checked Then
                    dtGSR = _db.ExecuteStoreProcedureTB("sp_PLM_LoadStockGSR_NDV", para)
                Else
                    dtGSR = _db.ExecuteStoreProcedureTB("sp_PLM_LoadStockGSR_BWH", para)
                End If

                'Lấy dữ liệu FIX
                Dim dtFix = _db.ExecuteStoreProcedureTB("sp_PLM_LoadFIXData", para)
                'Cộng Nhu cầu với FIX
                For Each r As DataRow In dt.Rows
                    For Each c As DataColumn In dt.Columns
                        If dt.Columns.IndexOf(c.ColumnName) > dt.Columns.IndexOf("TTLStock") Then
                            For Each j As DataRow In dtFix.Rows
                                If r("Std_MatCode") = j("JCode") Then
                                    For Each m As DataColumn In dtFix.Columns
                                        If c.ColumnName = m.ColumnName Then
                                            r(c) = r(c) + IIf(IsNumeric(j(m)), j(m), 0)
                                            GoTo NextColSub
                                        End If
                                    Next
                                End If
                            Next
                        End If
NextColSub:
                    Next
                Next

                If chbExportExcels.Checked Then
                    'Export ra excel để test dữ liệu
                    dtCopy.Columns.Remove("Std_StdQtyP")
                    dtCopy.Columns.Remove("TLSX")
                    Dim file1 As String = ""
                    Dim file2 As String = ""
                    Dim file3 As String = ""
                    Dim listFile As New List(Of String)
                    If dtCopy.Rows.Count > 0 Then
                        GridControlExportExcel(GridControlConvertToGridview(dtCopy), "Nhu cầu", False, file1)
                        listFile.Add(file1)
                    End If
                    If dtGSR.Rows.Count > 0 Then
                        GridControlExportExcel(GridControlConvertToGridview(dtGSR), "Hàng chưa về", False, file2)
                        listFile.Add(file2)
                    End If
                    If dtFix.Rows.Count > 0 Then
                        GridControlExportExcel(GridControlConvertToGridview(dtFix), "FIX", False, file3)
                        listFile.Add(file3)
                    End If
                    MergeXlsxFilesDevExpress("", listFile.ToArray, True)
                    '---------------------------------
                End If

                'Suy ra dữ liệu tồn/thiếu
                For r = 0 To dt.Rows.Count - 1
                    Dim sumDauCuoi As Integer = 0
                    For Each c As DataColumn In dt.Columns
                        If dt.Columns.IndexOf(c) > dt.Columns.IndexOf("TTLStock") Then
                            For Each j As DataRow In dtGSR.Rows
                                If dt.Rows(r)("Std_MatCode") = j("JCode") Then
                                    sumDauCuoi = j("SumDauCuoi")
                                    For Each m As DataColumn In dtGSR.Columns
                                        If c.ColumnName = m.ColumnName Then
                                            If IsNumeric(dt.Rows(r)(dt.Columns.IndexOf(c) - 1)) Then
                                                If dt.Rows(r)(dt.Columns.IndexOf(c) - 1) < 0 Then
                                                    dt.Rows(r)(c) = IIf(IsNumeric(j(m)), j(m), 0) - IIf(IsNumeric(dt.Rows(r)(c)), dt.Rows(r)(c), 0)
                                                Else
                                                    dt.Rows(r)(c) = dt.Rows(r)(dt.Columns.IndexOf(c) - 1) + IIf(IsNumeric(j(m)), j(m), 0) - IIf(IsNumeric(dt.Rows(r)(c)), dt.Rows(r)(c), 0)
                                                End If
                                            Else
                                                dt.Rows(r)(c) = IIf(IsNumeric(j(m)), j(m), 0) - IIf(IsNumeric(dt.Rows(r)(c)), dt.Rows(r)(c), 0)
                                            End If
                                            GoTo NextCol
                                        End If
                                    Next
                                End If
                            Next
                        End If
NextCol:
                    Next
                    dt.Rows(r)("PO") = IIf(IsNumeric(dt.Rows(r)("TTLStock")), dt.Rows(r)("TTLStock"), 0) + sumDauCuoi - IIf(IsNumeric(dt.Rows(r)("PO")), dt.Rows(r)("PO"), 0)
                Next

                If rdoNDV.Checked Then
                    Dim indTTLStock As Integer = dt.Columns.IndexOf("TTLStock") + 1
                    For Each r As DataRow In dt.Rows
                        If Not IsDBNull(r("Kind")) Then
                            If r("Kind") = "U00" Or r("Kind") = "Tray" Then
                                r("GSRBT") = IIf(r("PO") < 0, r("PO"), 0) - r("GSRGap")
                            End If
                        ElseIf IsNumeric(r("LTPoNDV")) And IsNumeric(r("LTUseNDV")) Then
                            If r("LTPoNDV") = 3 And r("LTUseNDV") = 7 Then
                                For c = indTTLStock To indTTLStock + 3
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoNDV") = 7 And r("LTUseNDV") = 7 Then
                                For c = indTTLStock To indTTLStock + 4
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoNDV") = 7 And r("LTUseNDV") = 14 Then
                                For c = indTTLStock To indTTLStock + 5
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoNDV") = 10 And r("LTUseNDV") = 14 Then
                                For c = indTTLStock To indTTLStock + 6
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoNDV") = 10 And r("LTUseNDV") = 30 Then
                                For c = indTTLStock To indTTLStock + 8
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoNDV") = 10 And r("LTUseNDV") = 60 Then
                                For c = indTTLStock To indTTLStock + 12
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoNDV") = 30 And r("LTUseNDV") = 30 Then
                                For c = indTTLStock To indTTLStock + 12
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoNDV") = 60 And r("LTUseNDV") = 30 Then
                                For c = indTTLStock To indTTLStock + 16
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoNDV") = 90 And r("LTUseNDV") = 30 Then
                                For c = indTTLStock To indTTLStock + 22
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            End If
                        Else
                            For c = indTTLStock To indTTLStock + 4
                                r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                            Next
                        End If

                        If IsNumeric(r("GSRBT")) And IsNumeric(r("MOQNDV")) Then
                            If r("MOQNDV") <> 0 Then
                                r("GSRBT") = RoundUp(r("GSRBT") / r("MOQNDV"), 0) * r("MOQNDV")
                            End If
                        End If

                        If IsNumeric(r("LTPoNDV")) Then
                            If r("LTPoNDV") = 3 And r(indTTLStock + 3) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(0)("Tuan"), Date).AddDays(4)
                            ElseIf r("LTPoNDV") = 7 And r(indTTLStock + 4) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(1)("Tuan"), Date).AddDays(4)
                            ElseIf r("LTPoNDV") = 10 And r(indTTLStock + 4) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(1)("Tuan"), Date).AddDays(4)
                            ElseIf r("LTPoNDV") = 11 And r(indTTLStock + 4) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(2)("Tuan"), Date).AddDays(4)
                            ElseIf r("LTPoNDV") = 21 And r(indTTLStock + 6) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(3)("Tuan"), Date).AddDays(4)
                            ElseIf r("LTPoNDV") = 30 And r(indTTLStock + 7) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(4)("Tuan"), Date).AddDays(4)
                            ElseIf r("LTPoNDV") = 60 And r(indTTLStock + 11) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(8)("Tuan"), Date).AddDays(4)
                            ElseIf r("LTPoNDV") = 90 And r(indTTLStock + 15) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(12)("Tuan"), Date).AddDays(4)
                            End If
                        End If
                    Next

                    dt.Columns.Remove("LTPoBWH")
                    dt.Columns.Remove("LTUseBWH")
                    dt.Columns.Remove("MOQBWH")
                Else
                    Dim indTTLStock As Integer = dt.Columns.IndexOf("TTLStock") + 1
                    For Each r As DataRow In dt.Rows
                        If Not IsDBNull(r("Kind")) Then
                            If r("Kind") = "U00" Or r("Kind") = "Tray" Then
                                r("GSRBT") = IIf(r("PO") < 0, r("PO"), 0) - r("GSRGap")
                            End If
                        ElseIf IsNumeric(r("LTPoBWH")) And IsNumeric(r("LTUseBWH")) Then
                            If r("LTPoBWH") = 3 And r("LTUseBWH") = 7 Then
                                For c = indTTLStock To indTTLStock + 3
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoBWH") = 7 And r("LTUseBWH") = 7 Then
                                For c = indTTLStock To indTTLStock + 4
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoBWH") = 7 And r("LTUseBWH") = 14 Then
                                For c = indTTLStock To indTTLStock + 5
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoBWH") = 10 And r("LTUseBWH") = 14 Then
                                For c = indTTLStock To indTTLStock + 6
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoBWH") = 10 And r("LTUseBWH") = 30 Then
                                For c = indTTLStock To indTTLStock + 8
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoBWH") = 10 And r("LTUseBWH") = 60 Then
                                For c = indTTLStock To indTTLStock + 12
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoBWH") = 30 And r("LTUseBWH") = 30 Then
                                For c = indTTLStock To indTTLStock + 12
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoBWH") = 60 And r("LTUseBWH") = 30 Then
                                For c = indTTLStock To indTTLStock + 16
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            ElseIf r("LTPoBWH") = 90 And r("LTUseBWH") = 30 Then
                                For c = indTTLStock To indTTLStock + 22
                                    r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                                Next
                            End If
                        Else
                            For c = indTTLStock To indTTLStock + 4
                                r("GSRBT") += IIf(r(c) < 0, r(c), 0)
                            Next
                        End If

                        If IsNumeric(r("GSRBT")) And IsNumeric(r("MOQBWH")) Then
                            If r("MOQBWH") <> 0 Then
                                r("GSRBT") = RoundUp(r("GSRBT") / r("MOQBWH"), 0) * r("MOQBWH")
                            End If
                        End If

                        If IsNumeric(r("LTPoBWH")) Then
                            If r("LTPoBWH") = 3 And r(indTTLStock + 3) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(0)("Tuan"), Date).AddDays(4)
                            ElseIf r("LTPoBWH") = 7 And r(indTTLStock + 4) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(1)("Tuan"), Date).AddDays(4)
                            ElseIf r("LTPoBWH") = 10 And r(indTTLStock + 4) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(1)("Tuan"), Date).AddDays(4)
                            ElseIf r("LTPoBWH") = 11 And r(indTTLStock + 4) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(2)("Tuan"), Date).AddDays(4)
                            ElseIf r("LTPoBWH") = 21 And r(indTTLStock + 6) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(3)("Tuan"), Date).AddDays(4)
                            ElseIf r("LTPoBWH") = 30 And r(indTTLStock + 7) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(4)("Tuan"), Date).AddDays(4)
                            ElseIf r("LTPoBWH") = 60 And r(indTTLStock + 11) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(8)("Tuan"), Date).AddDays(4)
                            ElseIf r("LTPoBWH") = 90 And r(indTTLStock + 15) < 0 Then
                                r("DateBT") = CType(dtDay.Rows(12)("Tuan"), Date).AddDays(4)
                            End If
                        End If
                    Next
                    dt.Columns.Remove("LTPoNDV")
                    dt.Columns.Remove("LTUseNDV")
                    dt.Columns.Remove("MOQNDV")
                End If

                dt.Columns.Remove("Std_StdQtyP")
                GridControl1.DataSource = dt
                GridControlSetFormat(GridView1, 2)
                GridControlSetFormatPercentage(GridView1, "TLSX", 2)
                GridView1.Columns("TLSX").Visible = False
                GridView1.BestFitColumns()
                GridView1.OptionsView.ShowFooter = False
            End If
            Try
            Catch ex As Exception
                ShowWarning(ex.Message + " - Row " + count.ToString)
            End Try
            'SplashScreenManager1.CloseWaitForm()
        Else
            ShowWarning("Bạn chưa chọn Tuần Import !")
            cbbTuanImport.Select()
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If IsNumeric(e.Column.FieldName.ToString.Substring(0, 1)) Then
            If e.CellValue < 0 Then
                e.Appearance.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub cbbTuanImport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbTuanImport.SelectedIndexChanged
        dteStartDate.EditValue = _db.ExecuteScalar(String.Format("  SELECT TOP 1 Tuan
                                                                    FROM PLM_FC_Boo
                                                                    WHERE TuanImport = '{0}'
                                                                    ORDER BY Tuan",
                                                                    cbbTuanImport.Text))
        dteEndDate.EditValue = _db.ExecuteScalar(String.Format("SELECT TOP 1 Tuan
                                                                FROM PLM_FC_Boo
                                                                WHERE TuanImport = '{0}'
                                                                ORDER BY Tuan DESC",
                                                                cbbTuanImport.Text))
    End Sub
End Class


