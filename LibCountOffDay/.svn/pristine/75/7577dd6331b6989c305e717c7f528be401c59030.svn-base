Imports System.Drawing
Imports CommonDB
Imports PublicUtility

Public Class FrmShowOffDay
    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmShowOffDay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt = _db.FillDataTable("SELECT DISTINCT Section
                                    FROM OT_Employee
                                    ORDER BY Section")
        For Each r As DataRow In dt.Rows
            cbbSection.Items.Add(r("Section"))
        Next
        SectionHead.EditValue = CurrentUser.Section
        dteMonth.EditValue = Date.Now
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridView1.Columns.Clear()

        Dim startD As Date = _db.ExecuteScalar(String.Format("SELECT TOP 1 h.RollcallDate
                                                FROM WT_Rollcall AS h
                                                INNER JOIN OT_Employee AS d
                                                ON h.EmployeeID = d.EmpID
                                                WHERE d.Section = '{0}'
                                                AND RollcallDate >= DATEADD(MONTH, -1, CAST(GETDATE() AS DATE))
                                                AND (WD + OT) = 0
                                                ORDER BY RollcallDate", SectionHead.EditValue))
        Dim dateCopy = startD
        Dim colDay As String = ""
        While startD <= Date.Now.AddDays(7)
            colDay += startD.ToString("[dd-MMM]") + ","
            startD = startD.AddDays(1)
        End While
        colDay = colDay.Substring(0, colDay.Length - 1)

        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", dateCopy)
        para(1) = New SqlClient.SqlParameter("@Section", SectionHead.EditValue)
        para(2) = New SqlClient.SqlParameter("@DayCol", colDay)
        Dim dt = _db.ExecuteStoreProcedureTB("sp_WT_CountOffDay", para)

        'Check > 6
        For Each r As DataRow In dt.Rows
            Dim ind = 1
            For Each c As DataColumn In dt.Columns
                If dt.Columns.IndexOf(c.ColumnName) > dt.Columns.IndexOf("EmployeeName") Then
                    If Not IsDBNull(r(c)) Then
                        If r(c) = "x" Then
                            r(c) = ind
                            ind += 1
                        ElseIf r(c) = "off" Then
                            ind = 1
                        End If
                    End If
                    'If c.ColumnName = Date.Now.ToString("dd-MMM") Then
                    '    If IsNumeric(r(c)) Then
                    '        Dim a As Integer = c.Table.Columns.IndexOf(c.ColumnName) + (7 - r(c))
                    '        If a > c.Table.Columns.IndexOf(c.ColumnName) Then
                    '            r(a) = "X"
                    '        End If
                    '    ElseIf Not IsDBNull(r(c)) Then
                    '        If r(c) = "off" Then
                    '            Dim b As Integer = c.Table.Columns.IndexOf(c.ColumnName) + 7
                    '            r(b) = "X"
                    '        End If
                    '    End If
                    '    'Exit For
                    'End If
                End If
            Next
        Next

        For Each r As DataRow In dt.Rows
            For c = dt.Columns.Count - 1 To 0 Step -1
                If Not IsDBNull(r(c)) Then
                    If IsNumeric(r(c)) Then
                        If r(c) >= 6 And c < dt.Columns.Count - 1 Then
                            r(c + 1) = "X"
                        ElseIf r(c) < 6 Then
                            Dim a As Integer = dt.Columns.IndexOf(dt.Columns(c).ColumnName) + (7 - r(c))
                            If a < dt.Columns.Count Then
                                r(a) = "X"
                            End If
                        End If
                    ElseIf r(c) = "off" Then
                        Dim a As Integer = dt.Columns.IndexOf(dt.Columns(c).ColumnName) + 7
                        If a < dt.Columns.Count Then
                            r(a) = "X"
                        End If
                    End If
                    Exit For
                End If
            Next
        Next

        GridControl1.DataSource = dt
        GridControlSetFormat(GridView1, 4)
        GridView1.Columns("EmployeeName").Width = 150
        GridView1.BestFitColumns()

        'Tô vàng ngày nghỉ
        Dim dtHoli = _db.FillDataTable("SELECT FORMAT(HolidayDate, 'dd-MMM') AS HolidayDate
                                        FROM FPICS_HolidayDate
                                        WHERE HolidayDate BETWEEN @StartDate AND DATEADD(DAY, 7, GETDATE())",
                                        para)
        For Each r As DataRow In dtHoli.Rows
            GridView1.Columns(r("HolidayDate").ToString).AppearanceHeader.BackColor = Color.Yellow
        Next
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If Not IsDBNull(e.CellValue) Then
            If e.CellValue = "X" Then
                e.Appearance.ForeColor = Color.White
                e.Appearance.BackColor = Color.Red
            ElseIf IsNumeric(e.CellValue) And e.Column.FieldName <> "EmployeeID" And e.Column.FieldName <> "GroupID" Then
                If e.CellValue >= 7 Then
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub
End Class