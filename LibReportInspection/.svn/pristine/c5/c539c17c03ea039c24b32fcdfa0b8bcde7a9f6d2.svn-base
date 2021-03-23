Imports CommonDB
'Imports LibEntity
Imports System.Windows.Forms

Public Class FrmReportSummary : Inherits DevExpress.XtraEditors.XtraForm
    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _dbFpics As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_Fpics)


    Private Sub rdoTuan_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoTuan.CheckedChanged
        If rdoTuan.Checked Then
            dtpStart.Value = DateTime.Now.AddDays(-1)
            dtpStart.Value = GetFirstDayOfWeek(dtpStart.Value)
            dtpEnd.Value = LastDayOfWeek(dtpStart.Value)
        End If
    End Sub

    Private Sub rdoThang_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoThang.CheckedChanged
        If rdoThang.Checked Then
            dtpStart.Value = DateTime.Now.AddDays(-1)
            dtpStart.Value = GetStartDayOfMonth(dtpStart.Value)
            dtpEnd.Value = GetEndDayOfMonth(dtpStart.Value)
        End If
    End Sub

    Private Sub rdoNam_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoQuy.CheckedChanged
        If rdoQuy.Checked Then
            dtpStart.Value = DateTime.Now.AddDays(-1)
            dtpStart.Value = GetStartDayOfQuarter(dtpStart.Value)
            dtpEnd.Value = GetEndDayOfQuarter(dtpStart.Value)
        End If
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim obj As New PS_Target
        obj.ID_K = GetQuaterByFinancial(dtpStart.Value)
        _db.GetObject(obj)
        grid.RowCount = 0
        If rdoTuan.Checked Then
            Dim LT As String = "01 ~ " & dtpEnd.Value.ToString("dd/MM")
            Dim tuan As String = dtpStart.Value.ToString("dd") & "~" & dtpEnd.Value.ToString("dd/MM")
            Dim tuan1 As String = dtpStart.Value.AddDays(-7).ToString("dd") & "~" & dtpEnd.Value.AddDays(-7).ToString("dd/MM")
            Dim tuan2 As String = dtpStart.Value.AddDays(-14).ToString("dd") & "~" & dtpEnd.Value.AddDays(-14).ToString("dd/MM")
            grid.RowCount = 11
            grid.Rows(0).Cells("Yield").Value = "Target"
            grid.Rows(1).Cells("Yield").Value = dtpStart.Value.AddMonths(-1).ToString("MMM.yyyy")
            grid.Rows(2).Cells("Yield").Value = dtpStart.Value.ToString("MMM.yyyy") & " (" & LT & " )"
            grid.Rows(3).Cells("Yield").Value = "% Tăng/ Giảm (" & LT & " & Target )"
            grid.Rows(4).Cells("Yield").Value = "% Tăng/ Giảm (" & LT & " & " & dtpStart.Value.AddMonths(-1).ToString("MMM.yyyy") & ")"
            grid.Rows(5).Cells("Yield").Value = tuan2
            grid.Rows(6).Cells("Yield").Value = tuan1
            grid.Rows(7).Cells("Yield").Value = tuan
            grid.Rows(8).Cells("Yield").Value = "% Tăng/ Giảm ( " & tuan & " & Target )"
            grid.Rows(9).Cells("Yield").Value = "% Tăng/ Giảm ( " & tuan & " & " & tuan2
            grid.Rows(10).Cells("Yield").Value = "% Tăng/ Giảm ( " & tuan & " & " & tuan1

            grid.Rows(3).DefaultCellStyle.BackColor = Drawing.Color.YellowGreen
            grid.Rows(4).DefaultCellStyle.BackColor = Drawing.Color.YellowGreen
            grid.Rows(8).DefaultCellStyle.BackColor = Drawing.Color.YellowGreen
            grid.Rows(9).DefaultCellStyle.BackColor = Drawing.Color.YellowGreen
            grid.Rows(10).DefaultCellStyle.BackColor = Drawing.Color.YellowGreen

            Dim paraT(1) As SqlClient.SqlParameter
            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(GetStartDayOfMonth(dtpStart.Value.AddMonths(-1))))
            paraT(1) = New SqlClient.SqlParameter("@End", GetStartDate(GetEndDayOfMonth(dtpStart.Value.AddMonths(-1))))
            Dim tbThang As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyTotal]", paraT)

            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(GetStartDayOfMonth(dtpStart.Value)))
            paraT(1) = New SqlClient.SqlParameter("@End", GetStartDate(dtpEnd.Value))
            Dim tbLT As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyTotal]", paraT)

            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(dtpStart.Value.AddDays(-14)))
            paraT(1) = New SqlClient.SqlParameter("@End", GetStartDate(dtpEnd.Value.AddDays(-14)))
            Dim tbT2 As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyTotal]", paraT)

            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(dtpStart.Value.AddDays(-7)))
            paraT(1) = New SqlClient.SqlParameter("@End", GetStartDate(dtpEnd.Value.AddDays(-7)))
            Dim tbT1 As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyTotal]", paraT)

            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(dtpStart.Value))
            paraT(1) = New SqlClient.SqlParameter("@End", GetStartDate(dtpEnd.Value))
            Dim tbT0 As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyTotal]", paraT)

            grid.Rows(0).Cells("SGS").Value = obj.SEAS
            grid.Rows(0).Cells("SGD").Value = obj.SEAD
            grid.Rows(0).Cells("TSBS").Value = obj.TSBS
            grid.Rows(0).Cells("TSBD").Value = obj.TSBD 
            grid.Rows(0).Cells("WD").Value = obj.WD
            grid.Rows(0).Cells("HGSTS").Value = obj.HGSTS
            grid.Rows(0).Cells("HGSTD").Value = obj.HGSTD
            grid.Rows(0).Cells("Other").Value = obj.OTher
            grid.Rows(0).Cells("Total").Value = obj.Total
            grid.Rows(0).Cells("TotalS").Value = obj.TotalS
            grid.Rows(0).Cells("TotalD").Value = obj.TotalD

            For Each c As DataGridViewColumn In grid.Columns
                If c.HeaderText <> "Yield (%)" Then
                    grid.Rows(1).Cells(c.Name).Value = tbThang.Compute("sum(Rate)", String.Format(" Customer='{0}'", c.ToolTipText))
                    grid.Rows(2).Cells(c.Name).Value = tbLT.Compute("sum(Rate)", String.Format(" Customer='{0}'", c.ToolTipText))
                    grid.Rows(5).Cells(c.Name).Value = tbT2.Compute("sum(Rate)", String.Format(" Customer='{0}'", c.ToolTipText))
                    grid.Rows(6).Cells(c.Name).Value = tbT1.Compute("sum(Rate)", String.Format(" Customer='{0}'", c.ToolTipText))
                    grid.Rows(7).Cells(c.Name).Value = tbT0.Compute("sum(Rate)", String.Format(" Customer='{0}'", c.ToolTipText))

                    If grid.Rows(2).Cells(c.Name).Value IsNot DBNull.Value Then
                        grid.Rows(3).Cells(c.Name).Value = grid.Rows(2).Cells(c.Name).Value - grid.Rows(0).Cells(c.Name).Value
                        If grid.Rows(1).Cells(c.Name).Value IsNot DBNull.Value Then
                            grid.Rows(4).Cells(c.Name).Value = grid.Rows(2).Cells(c.Name).Value - grid.Rows(1).Cells(c.Name).Value
                        Else
                            grid.Rows(4).Cells(c.Name).Value = "-"
                        End If
                    Else
                        grid.Rows(2).Cells(c.Name).Value = "-"
                        grid.Rows(3).Cells(c.Name).Value = "-"
                        grid.Rows(4).Cells(c.Name).Value = "-"
                    End If
                    If grid.Rows(7).Cells(c.Name).Value IsNot DBNull.Value Then
                        grid.Rows(8).Cells(c.Name).Value = grid.Rows(7).Cells(c.Name).Value - grid.Rows(0).Cells(c.Name).Value
                        If grid.Rows(5).Cells(c.Name).Value IsNot DBNull.Value Then
                            grid.Rows(9).Cells(c.Name).Value = grid.Rows(7).Cells(c.Name).Value - grid.Rows(5).Cells(c.Name).Value
                        Else
                            grid.Rows(9).Cells(c.Name).Value = "-"
                        End If
                        If grid.Rows(6).Cells(c.Name).Value IsNot DBNull.Value Then
                            grid.Rows(10).Cells(c.Name).Value = grid.Rows(7).Cells(c.Name).Value - grid.Rows(6).Cells(c.Name).Value
                        Else
                            grid.Rows(10).Cells(c.Name).Value = ""
                        End If
                    Else
                        grid.Rows(7).Cells(c.Name).Value = "-"
                        grid.Rows(8).Cells(c.Name).Value = "-"
                        grid.Rows(9).Cells(c.Name).Value = "-"
                        grid.Rows(10).Cells(c.Name).Value = "-"
                    End If
                End If
            Next


            For Each r As DataGridViewRow In grid.Rows
                If r.Index = 1 Or r.Index = 2 Or r.Index = 5 Or r.Index = 6 Or r.Index = 7 Then
                    For Each c As DataGridViewColumn In grid.Columns
                        If c.Index > 0 Then
                            If IsNumeric(r.Cells(c.Name).Value) Then
                                If r.Cells(c.Name).Value >= grid.Rows(0).Cells(c.Index).Value Then
                                    r.Cells(c.Name).Style.ForeColor = Drawing.Color.Blue
                                Else
                                    r.Cells(c.Name).Style.ForeColor = Drawing.Color.Red
                                End If 
                            End If
                        End If
                    Next
                End If
            Next
            'check not number sign = '-'
            For Each r As DataGridViewRow In grid.Rows
                For Each c As DataGridViewColumn In grid.Columns
                    If c.Index > 0 Then
                        If Not IsNumeric(r.Cells(c.Name).Value) Then
                            r.Cells(c.Name).Value = "-"
                        End If
                    End If
                Next
            Next
        ElseIf rdoThang.Checked Then
            Dim T As String = dtpStart.Value.ToString("MMM.yyyy")
            Dim T1 As String = dtpStart.Value.AddMonths(-1).ToString("MMM.yyyy")
            Dim T2 As String = dtpStart.Value.AddMonths(-2).ToString("MMM.yyyy")
            grid.RowCount = 8
            grid.Rows(0).Cells("Yield").Value = "Target"
            grid.Rows(1).Cells("Yield").Value = GetQuaterByFinancialXX(dtpStart.Value.AddMonths(-3)) & "( " &
                                                 GetStartDayOfQuarter(dtpStart.Value.AddMonths(-3)).ToString("MMM.yyyy") & " ~ " &
                                                 GetEndDayOfQuarter(dtpStart.Value.AddMonths(-3)).ToString("MMM.yyyy") & ")"
            grid.Rows(2).Cells("Yield").Value = T2
            grid.Rows(3).Cells("Yield").Value = T1
            grid.Rows(4).Cells("Yield").Value = T
            grid.Rows(5).Cells("Yield").Value = "% Tăng/ Giảm ( " & T & " & Target )"
            grid.Rows(6).Cells("Yield").Value = "% Tăng/ Giảm ( " & T & " & " & T2 & " )"
            grid.Rows(7).Cells("Yield").Value = "% Tăng/ Giảm ( " & T & " & " & T1 & " )"


            grid.Rows(5).DefaultCellStyle.BackColor = Drawing.Color.YellowGreen
            grid.Rows(6).DefaultCellStyle.BackColor = Drawing.Color.YellowGreen
            grid.Rows(7).DefaultCellStyle.BackColor = Drawing.Color.YellowGreen

            Dim paraT(1) As SqlClient.SqlParameter
            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDayOfQuarter(GetStartDayOfMonth(dtpStart.Value.AddMonths(-3))))
            paraT(1) = New SqlClient.SqlParameter("@End", GetEndDayOfQuarter(GetEndDayOfMonth(dtpStart.Value.AddMonths(-3))))
            Dim tbQ As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyTotal]", paraT)

            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(GetStartDayOfMonth(dtpStart.Value.AddMonths(-2))))
            paraT(1) = New SqlClient.SqlParameter("@End", GetStartDate(GetEndDayOfMonth(dtpEnd.Value.AddMonths(-2))))
            Dim tbT2 As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyTotal]", paraT)

            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(GetStartDayOfMonth(dtpStart.Value.AddMonths(-1))))
            paraT(1) = New SqlClient.SqlParameter("@End", GetStartDate(GetEndDayOfMonth(dtpEnd.Value.AddMonths(-1))))
            Dim tbT1 As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyTotal]", paraT)

            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(dtpStart.Value))
            paraT(1) = New SqlClient.SqlParameter("@End", GetStartDate(dtpEnd.Value))
            Dim tbT As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyTotal]", paraT)

            grid.Rows(0).Cells("SGS").Value = obj.SEAS
            grid.Rows(0).Cells("SGD").Value = obj.SEAD
            grid.Rows(0).Cells("TSBS").Value = obj.TSBS
            grid.Rows(0).Cells("TSBD").Value = obj.TSBD 
            grid.Rows(0).Cells("WD").Value = obj.WD
            grid.Rows(0).Cells("HGSTS").Value = obj.HGSTS
            grid.Rows(0).Cells("HGSTD").Value = obj.HGSTD
            grid.Rows(0).Cells("Other").Value = obj.OTher
            grid.Rows(0).Cells("Total").Value = obj.Total
            grid.Rows(0).Cells("TotalS").Value = obj.TotalS
            grid.Rows(0).Cells("TotalD").Value = obj.TotalD

            For Each c As DataGridViewColumn In grid.Columns
                If c.HeaderText <> "Yield (%)" Then
                    grid.Rows(1).Cells(c.Name).Value = tbQ.Compute("sum(Rate)", String.Format(" Customer='{0}'", c.ToolTipText))
                    grid.Rows(2).Cells(c.Name).Value = tbT2.Compute("sum(Rate)", String.Format(" Customer='{0}'", c.ToolTipText))
                    grid.Rows(3).Cells(c.Name).Value = tbT1.Compute("sum(Rate)", String.Format(" Customer='{0}'", c.ToolTipText))
                    grid.Rows(4).Cells(c.Name).Value = tbT.Compute("sum(Rate)", String.Format(" Customer='{0}'", c.ToolTipText))

                    If grid.Rows(4).Cells(c.Name).Value IsNot DBNull.Value Then
                        grid.Rows(5).Cells(c.Name).Value = grid.Rows(4).Cells(c.Name).Value - grid.Rows(0).Cells(c.Name).Value
                        If grid.Rows(2).Cells(c.Name).Value IsNot DBNull.Value Then
                            grid.Rows(6).Cells(c.Name).Value = grid.Rows(4).Cells(c.Name).Value - grid.Rows(2).Cells(c.Name).Value
                        Else
                            grid.Rows(6).Cells(c.Name).Value = "-"
                        End If
                        If grid.Rows(3).Cells(c.Name).Value IsNot DBNull.Value Then
                            grid.Rows(7).Cells(c.Name).Value = grid.Rows(4).Cells(c.Name).Value - grid.Rows(3).Cells(c.Name).Value
                        Else
                            grid.Rows(7).Cells(c.Name).Value = "-"
                        End If
                    Else
                        grid.Rows(2).Cells(c.Name).Value = "-"
                        grid.Rows(5).Cells(c.Name).Value = "-"
                        grid.Rows(6).Cells(c.Name).Value = "-"
                        grid.Rows(7).Cells(c.Name).Value = "-"
                    End If
                End If
            Next


            For Each r As DataGridViewRow In grid.Rows
                If r.Index = 1 Or r.Index = 2 Or r.Index = 3 Or r.Index = 4 Then
                    For Each c As DataGridViewColumn In grid.Columns
                        If c.Index > 0 Then
                            If IsNumeric(r.Cells(c.Name).Value) Then
                                If r.Cells(c.Name).Value >= grid.Rows(0).Cells(c.Index).Value Then
                                    r.Cells(c.Name).Style.ForeColor = Drawing.Color.Blue
                                Else
                                    r.Cells(c.Name).Style.ForeColor = Drawing.Color.Red
                                End If 
                            End If
                        End If
                    Next
                End If
            Next
            'check not number sign = '-'
            For Each r As DataGridViewRow In grid.Rows
                For Each c As DataGridViewColumn In grid.Columns
                    If c.Index > 0 Then
                        If Not IsNumeric(r.Cells(c.Name).Value) Then
                            r.Cells(c.Name).Value = "-"
                        End If
                    End If
                Next
            Next
        ElseIf rdoQuy.Checked Then
            grid.RowCount = 6
            grid.Rows(0).Cells("Yield").Value = "Target"
            grid.Rows(1).Cells("Yield").Value = "TLCP năm (" & GetStartDayOfYear(dtpStart.Value).ToString("MMM.yyyy") & " ~ " & GetEndDayOfYear(dtpStart.Value).ToString("MMM.yyyy") & " )"
            grid.Rows(2).Cells("Yield").Value = GetQuaterByFinancialXX(dtpStart.Value.AddMonths(-3))
            grid.Rows(3).Cells("Yield").Value = GetQuaterByFinancialXX(dtpStart.Value)
            grid.Rows(4).Cells("Yield").Value = "% Tăng/ Giảm ( " & GetQuaterByFinancialXX(dtpStart.Value) & " & Target )"
            grid.Rows(5).Cells("Yield").Value = "% Tăng/ Giảm ( " & GetQuaterByFinancialXX(dtpStart.Value) & " & " & GetQuaterByFinancialXX(dtpStart.Value.AddMonths(-3)) & " )"

            grid.Rows(4).DefaultCellStyle.BackColor = Drawing.Color.YellowGreen
            grid.Rows(5).DefaultCellStyle.BackColor = Drawing.Color.YellowGreen

            Dim paraT(1) As SqlClient.SqlParameter
            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(GetStartDayOfYear(dtpStart.Value)))
            paraT(1) = New SqlClient.SqlParameter("@End", GetStartDate(GetEndDayOfYear(dtpStart.Value)))
            Dim tbNam As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyTotal]", paraT)

            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(GetStartDayOfMonth(dtpStart.Value.AddMonths(-3))))
            paraT(1) = New SqlClient.SqlParameter("@End", GetStartDate(GetEndDayOfQuarter(dtpStart.Value.AddMonths(-3))))
            Dim tbQ1 As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyTotal]", paraT)

            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(dtpStart.Value))
            paraT(1) = New SqlClient.SqlParameter("@End", GetStartDate(dtpEnd.Value))
            Dim tbQ As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyTotal]", paraT)

            grid.Rows(0).Cells("SGS").Value = obj.SEAS
            grid.Rows(0).Cells("SGD").Value = obj.SEAD
            grid.Rows(0).Cells("TSBS").Value = obj.TSBS
            grid.Rows(0).Cells("TSBD").Value = obj.TSBD
            grid.Rows(0).Cells("WD").Value = obj.WD
            grid.Rows(0).Cells("HGSTS").Value = obj.HGSTS
            grid.Rows(0).Cells("HGSTD").Value = obj.HGSTD
            grid.Rows(0).Cells("Other").Value = obj.OTher
            grid.Rows(0).Cells("Total").Value = obj.Total
            grid.Rows(0).Cells("TotalS").Value = obj.TotalS
            grid.Rows(0).Cells("TotalD").Value = obj.TotalD

            For Each c As DataGridViewColumn In grid.Columns
                If c.HeaderText <> "Yield (%)" Then
                    grid.Rows(1).Cells(c.Name).Value = tbNam.Compute("sum(Rate)", String.Format(" Customer='{0}'", c.ToolTipText))
                    grid.Rows(2).Cells(c.Name).Value = tbQ1.Compute("sum(Rate)", String.Format(" Customer='{0}'", c.ToolTipText))
                    grid.Rows(3).Cells(c.Name).Value = tbQ.Compute("sum(Rate)", String.Format(" Customer='{0}'", c.ToolTipText))

                    If grid.Rows(3).Cells(c.Name).Value IsNot DBNull.Value Then
                        grid.Rows(4).Cells(c.Name).Value = grid.Rows(3).Cells(c.Name).Value - grid.Rows(0).Cells(c.Name).Value
                        If grid.Rows(2).Cells(c.Name).Value IsNot DBNull.Value Then
                            grid.Rows(5).Cells(c.Name).Value = grid.Rows(3).Cells(c.Name).Value - grid.Rows(2).Cells(c.Name).Value
                        Else
                            grid.Rows(5).Cells(c.Name).Value = "-"
                        End If
                    Else
                        grid.Rows(3).Cells(c.Name).Value = "-"
                        grid.Rows(4).Cells(c.Name).Value = "-"
                    End If
                End If
            Next


            For Each r As DataGridViewRow In grid.Rows
                If r.Index = 1 Or r.Index = 2 Or r.Index = 3 Then
                    For Each c As DataGridViewColumn In grid.Columns
                        If c.Index > 0 Then
                            If IsNumeric(r.Cells(c.Name).Value) Then
                                If r.Cells(c.Name).Value >= grid.Rows(0).Cells(c.Index).Value Then
                                    r.Cells(c.Name).Style.ForeColor = Drawing.Color.Blue
                                Else
                                    r.Cells(c.Name).Style.ForeColor = Drawing.Color.Red
                                End If 
                            End If
                        End If
                    Next
                End If
            Next
            'check not number sign = '-'
            For Each r As DataGridViewRow In grid.Rows
                For Each c As DataGridViewColumn In grid.Columns
                    If c.Index > 0 Then
                        If Not IsNumeric(r.Cells(c.Name).Value) Then
                            r.Cells(c.Name).Value = "-"
                        End If
                    End If
                Next
            Next
        End If


        If ckoTL.Checked Then
            For Each r As DataGridViewRow In grid.Rows
                For Each c As DataGridViewColumn In grid.Columns
                    If IsNumeric(r.Cells(c.Index).Value) Then
                        r.Cells(c.Index).Value = r.Cells(c.Index).Value / 100.0
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub
     
     
    Private Sub mnuGetData_Click(sender As System.Object, e As System.EventArgs) Handles mnuGetData.Click
        If ShowQuestion("Bạn muốn get dữ liệu FPICS") = Windows.Forms.DialogResult.Yes Then
            Dim startD As DateTime = GetStartDate(dtpStart.Value)
            Dim endD As DateTime = GetStartDate(dtpEnd.Value)
            While startD <= endD
                Dim paraC(0) As SqlClient.SqlParameter
                paraC(0) = New SqlClient.SqlParameter("@Today", startD)
                _db.ExecuteStoreProcedure("sp_RI_GetAutoDay", paraC)
                startD = startD.AddDays(1)
            End While
            ShowSuccess()
        End If
    End Sub
End Class