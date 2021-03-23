Imports CommonDB
Imports PublicUtility
Public Class FrmBomStock
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmBomStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            GridView1.Columns.Clear()
            Dim para(2) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@TuanImport", cbbTuanImport.Text)
            para(1) = New SqlClient.SqlParameter("@subCol", DBNull.Value)
            para(2) = New SqlClient.SqlParameter("@mainCol", DBNull.Value)

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
            Try
                Dim dtShow = _db.ExecuteStoreProcedureTB("sp_PLM_LoadBomStock", para)
                If dtShow.Rows.Count > 0 Then
                    For Each r As DataRow In dtShow.Rows
                        count += 1
                        If IsNumeric(r("PO")) Then
                            If r("PO") < 0 Then
                                r("PO") = 0
                            End If
                        End If
                        For Each c As DataColumn In dtShow.Columns
                            If dtShow.Columns.IndexOf(c) > dtShow.Columns.IndexOf("TLSX") Then
                                If r(c) > 0 Then
                                    Dim valSum As Decimal = 0.0
                                    For Each cSub As DataColumn In dtShow.Columns
                                        If dtShow.Columns.IndexOf(cSub) > dtShow.Columns.IndexOf("TLSX") And
                                            dtShow.Columns.IndexOf(cSub) < dtShow.Columns.IndexOf(c) Then
                                            valSum += r(cSub)
                                        End If
                                    Next
                                    r(c) = r(c) * r("TLSX") - valSum
                                Else
                                    r(c) = 0
                                End If
                            End If
                        Next
                    Next
                    GridControl1.DataSource = dtShow
                    GridControlSetFormat(GridView1, 5)
                    GridControlSetFormatPercentage(GridView1, "TLSX", 2)
                    GridControlSetFormatNumber(GridView1, "Std_StdQtyP", 8)
                    GridView1.BestFitColumns()
                    GridView1.OptionsView.ShowFooter = False
                End If
            Catch ex As Exception
                ShowWarning(ex.Message + " - Row " + count.ToString)
            End Try
        Else
            ShowWarning("Bạn chưa chọn Tuần Import !")
            cbbTuanImport.Select()
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
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