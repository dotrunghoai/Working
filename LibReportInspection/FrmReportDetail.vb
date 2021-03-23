Imports CommonDB
'Imports LibEntity
Imports System.Windows.Forms
Imports DataGridViewAutoFilter
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress

Public Class FrmReportDetail : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _dbFpics As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim tb As DataTable
    Dim isFirst As Boolean = True

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Cursor = Cursors.AppStarting

        txtProduct.Text = ""

        tb = New DataTable
        Dim myCustomer As Object = DBNull.Value
        Dim mySize As Object = DBNull.Value
        Dim myMethod As Object = DBNull.Value
        Dim sql As String = ""
        Dim para(4) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dteStart.DateTime))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dteEnd.DateTime))
        If cboSize.Text <> "" And cboSize.Text <> "All" Then
            mySize = cboSize.Text
        End If
        If cboLoai.Text = "All" Or cboLoai.Text = "" Then
            para(2) = New SqlClient.SqlParameter("@Method", DBNull.Value)
            myMethod = DBNull.Value
        ElseIf cboLoai.Text = "Single Side" Then
            para(2) = New SqlClient.SqlParameter("@Method", "01")
            myMethod = "01"
        ElseIf cboLoai.Text = "Double Side" Then
            para(2) = New SqlClient.SqlParameter("@Method", "02")
            myMethod = "02"
        End If
        If cboKH.Text <> "" And cboKH.Text <> "All" Then
            If cboKH.Text <> "Other" Then
                para(3) = New SqlClient.SqlParameter("@Customer", cboKH.Text.Trim)
                myCustomer = cboKH.Text
            Else
                para(3) = New SqlClient.SqlParameter("@Customer", "CANON")
                myCustomer = "CANON"
            End If
        Else
            para(3) = New SqlClient.SqlParameter("@Customer", DBNull.Value)
        End If
        If cboSize.Text <> "" And cboSize.Text <> "All" Then
            para(4) = New SqlClient.SqlParameter("@Size", cboSize.Text.Trim)
        Else
            para(4) = New SqlClient.SqlParameter("@Size", DBNull.Value)
        End If

        Dim bdsource As New BindingSource
        If rdoCS.Checked Then
            gridCSD.DataSource = Nothing
            gridCSD.ColumnCount = 0

            Dim col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "NgayCSD"
            col.DataPropertyName = "Ngay"
            col.HeaderText = "Ngay"
            col.Width = 80
            gridCSD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "CustomerCSD"
            col.DataPropertyName = "Customer"
            col.HeaderText = "Customer"
            col.Width = 60
            gridCSD.Columns.Add(col)


            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "LotQtyCSD"
            col.DataPropertyName = "LotQty"
            col.HeaderText = "LotQty"
            col.Width = 60
            col.DefaultCellStyle.Format = "N0"
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridCSD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "StartQtyCSD"
            col.DataPropertyName = "StartQty"
            col.HeaderText = "StartQty"
            col.Width = 60
            col.Visible = False
            col.DefaultCellStyle.Format = "N0"
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridCSD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "InsQtyCSD"
            col.DataPropertyName = "InsQty"
            col.HeaderText = "InsQty"
            col.Width = 60
            col.DefaultCellStyle.Format = "N0"
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridCSD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "OKQtyCSD"
            col.DataPropertyName = "OKQty"
            col.HeaderText = "OKQty"
            col.Width = 60
            col.DefaultCellStyle.Format = "N0"
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridCSD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "NGQtyCSD"
            col.DataPropertyName = "NGQty"
            col.HeaderText = "NGQty"
            col.Width = 60
            col.DefaultCellStyle.Format = "N0"
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridCSD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "RateCSD"
            col.DataPropertyName = "Rate"
            col.HeaderText = "Rate"
            col.Width = 60
            col.DefaultCellStyle.Format = "N2"
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridCSD.Columns.Add(col)

            sql = "sp_RI_GetbyCustomer"
            If Not rdoNgay.Checked Then
                sql = "sp_RI_GetbyCustomer_Sum"
            End If
            gridCSD.Visible = True
            gridCD.Visible = False
            tb = _db.ExecuteStoreProcedureTB(sql, para)
            'HGST -> WDC
            For r = 0 To tb.Rows.Count - 1
                If tb.Rows(r)("Customer") = "HGST" Then
                    tb.Rows(r)("Customer") = "WDC"
                End If
            Next
            If tb IsNot Nothing Then
                If tb.Rows.Count > 0 Then
                    bdsource.DataSource = tb
                    bdn.BindingSource = bdsource
                    gridCSD.DataSource = bdsource
                    For Each c As DataGridViewColumn In gridCSD.Columns
                        If c.Index > gridCSD.Columns("RateCSD").Index Then
                            c.Width = 50
                            c.DefaultCellStyle.Format = "N0"
                            If rdoTL.Checked Then
                                If ckoTL.Checked Then
                                    c.DefaultCellStyle.Format = "N2"
                                    For Each r As DataGridViewRow In gridCSD.Rows
                                        If r.Cells(c.Index).Value IsNot DBNull.Value Then
                                            r.Cells(c.Index).Value = r.Cells(c.Index).Value / r.Cells("StartQtyCSD").Value
                                        End If
                                    Next
                                Else
                                    c.DefaultCellStyle.Format = "N2"
                                    For Each r As DataGridViewRow In gridCSD.Rows
                                        If r.Cells(c.Index).Value IsNot DBNull.Value Then
                                            r.Cells(c.Index).Value = r.Cells(c.Index).Value * 100.0 / r.Cells("StartQtyCSD").Value
                                        End If
                                    Next
                                End If
                            End If
                        ElseIf c.Index = gridCSD.Columns("RateCSD").Index Then
                            If ckoTL.Checked Then
                                For Each r As DataGridViewRow In gridCSD.Rows
                                    r.Cells("RateCSD").Value = r.Cells("RateCSD").Value / 100.0
                                Next
                            End If
                        End If
                    Next
                Else
                    ShowWarning("Không có dữ liệu.")
                    Return
                End If
            End If
        Else

            gridCD.DataSource = Nothing
            gridCD.ColumnCount = 0
            Dim col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "NgayCD"
            col.DataPropertyName = "Ngay"
            col.HeaderText = "Ngay"
            col.Width = 80
            gridCD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "SizeCD"
            col.DataPropertyName = "Size"
            col.HeaderText = "Size"
            col.Width = 40
            col.ValueType = GetType(String)
            gridCD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "ProductCodeCD"
            col.DataPropertyName = "ProductCode"
            col.HeaderText = "ProductCode"
            col.Width = 50
            gridCD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "CustomerCD"
            col.DataPropertyName = "Customer"
            col.HeaderText = "Customer"
            col.Width = 60
            gridCD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "MethodCD"
            col.DataPropertyName = "Method"
            col.HeaderText = "Method"
            col.Width = 60
            gridCD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "LotQtyCD"
            col.DataPropertyName = "LotQty"
            col.HeaderText = "LotQty"
            col.Width = 60
            col.DefaultCellStyle.Format = "N0"
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridCD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "StartQtyCD"
            col.DataPropertyName = "StartQty"
            col.HeaderText = "StartQty"
            col.Width = 60
            col.Visible = False
            col.DefaultCellStyle.Format = "N0"
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridCD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "InsQtyCD"
            col.DataPropertyName = "InsQty"
            col.HeaderText = "InsQty"
            col.Width = 60
            col.DefaultCellStyle.Format = "N0"
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridCD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "OKQtyCD"
            col.DataPropertyName = "OKQty"
            col.HeaderText = "OKQty"
            col.Width = 60
            col.DefaultCellStyle.Format = "N0"
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridCD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "NGQtyCD"
            col.DataPropertyName = "NGQty"
            col.HeaderText = "NGQty"
            col.Width = 60
            col.DefaultCellStyle.Format = "N0"
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridCD.Columns.Add(col)

            col = New DataGridViewAutoFilterTextBoxColumn()
            col.Name = "RateCD"
            col.DataPropertyName = "Rate"
            col.HeaderText = "Rate"
            col.Width = 60
            col.DefaultCellStyle.Format = "N2"
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridCD.Columns.Add(col)

            sql = "sp_RI_GetbyProductDay"
            If rdoNgay.Checked = False Then
                sql = "sp_RI_GetbyProductSum"
            End If
            If cboSize.Text <> "" And cboSize.Text <> "All" Then
                para(4) = New SqlClient.SqlParameter("@Size", cboSize.Text.Trim)
            Else
                para(4) = New SqlClient.SqlParameter("@Size", DBNull.Value)
            End If
            If cboLoai.Text = "All" Or cboLoai.Text = "" Then
                para(2) = New SqlClient.SqlParameter("@Method", DBNull.Value)
            Else
                para(2) = New SqlClient.SqlParameter("@Method", cboLoai.Text)
            End If
            gridCSD.Visible = False
            gridCD.Visible = True
            tb = _db.ExecuteStoreProcedureTB(sql, para)
            'HGST -> WDC
            For r = 0 To tb.Rows.Count - 1
                If tb.Rows(r)("Customer") = "HGST" Then
                    tb.Rows(r)("Customer") = "WDC"
                End If
            Next
            If tb IsNot Nothing Then
                If tb.Rows.Count > 0 Then
                    bdsource.DataSource = tb
                    bdn.BindingSource = bdsource
                    gridCD.DataSource = bdsource
                    For Each r As DataGridViewRow In gridCD.Rows
                        If r.Cells("SizeCD").Value = "1" Then
                            r.Cells("SizeCD").Value = "Pcs"
                        End If
                    Next
                    For Each c As DataGridViewColumn In gridCD.Columns
                        If c.Index > gridCD.Columns("RateCD").Index Then
                            c.Width = 50
                            c.DefaultCellStyle.Format = "N0"
                            If rdoTL.Checked Then
                                If ckoTL.Checked Then
                                    c.DefaultCellStyle.Format = "N2"
                                    For Each r As DataGridViewRow In gridCD.Rows
                                        If r.Cells(c.Index).Value IsNot DBNull.Value Then
                                            r.Cells(c.Index).Value = r.Cells(c.Index).Value / r.Cells("InsQtyCD").Value
                                        End If
                                    Next
                                Else
                                    c.DefaultCellStyle.Format = "N2"
                                    For Each r As DataGridViewRow In gridCD.Rows
                                        If r.Cells(c.Index).Value IsNot DBNull.Value Then
                                            r.Cells(c.Index).Value = r.Cells(c.Index).Value * 100.0 / r.Cells("InsQtyCD").Value
                                        End If
                                    Next
                                End If
                            End If
                        ElseIf c.Index = gridCD.Columns("RateCD").Index Then
                            If ckoTL.Checked Then
                                For Each r As DataGridViewRow In gridCD.Rows
                                    r.Cells("RateCD").Value = r.Cells("RateCD").Value / 100.0
                                Next
                            End If
                        End If
                    Next
                Else
                    ShowWarning("Không có dữ liệu.")
                    Return
                End If
            End If
        End If


        gridQ.DataSource = Nothing
        gridQ.ColumnCount = 8
        gridQ.Columns(0).Name = "IDQ"
        gridQ.Columns(0).HeaderText = "ID"
        gridQ.Columns(0).DataPropertyName = "ID"
        gridQ.Columns(0).Width = 50
        gridQ.Columns(0).Visible = False

        gridQ.Columns(1).Name = "ThangQ"
        gridQ.Columns(1).HeaderText = "Thang"
        gridQ.Columns(1).DataPropertyName = "Thang"
        gridQ.Columns(1).Width = 50

        gridQ.Columns(2).Name = "LotQTyQ"
        gridQ.Columns(2).HeaderText = "LotQTy"
        gridQ.Columns(2).DataPropertyName = "LotQTy"
        gridQ.Columns(2).Width = 50
        gridQ.Columns(2).DefaultCellStyle.Format = "N0"
        gridQ.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridQ.Columns(3).Name = "StartQTyQ"
        gridQ.Columns(3).HeaderText = "StartQTy"
        gridQ.Columns(3).DataPropertyName = "StartQTy"
        gridQ.Columns(3).Width = 70
        gridQ.Columns(3).Visible = False
        gridQ.Columns(3).DefaultCellStyle.Format = "N0"
        gridQ.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridQ.Columns(4).Name = "InsQTyQ"
        gridQ.Columns(4).HeaderText = "InsQTy"
        gridQ.Columns(4).DataPropertyName = "InsQTy"
        gridQ.Columns(4).Width = 70
        gridQ.Columns(4).DefaultCellStyle.Format = "N0"
        gridQ.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridQ.Columns(5).Name = "OKQtyQ"
        gridQ.Columns(5).HeaderText = "OKQty"
        gridQ.Columns(5).DataPropertyName = "OKQty"
        gridQ.Columns(5).Width = 70
        gridQ.Columns(5).DefaultCellStyle.Format = "N0"
        gridQ.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridQ.Columns(6).Name = "NGQtyQ"
        gridQ.Columns(6).HeaderText = "NGQty"
        gridQ.Columns(6).DataPropertyName = "NGQty"
        gridQ.Columns(6).Width = 70
        gridQ.Columns(6).DefaultCellStyle.Format = "N0"
        gridQ.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridQ.Columns(7).Name = "RateQ"
        gridQ.Columns(7).HeaderText = "Rate"
        gridQ.Columns(7).DataPropertyName = "Rate"
        gridQ.Columns(7).Width = 50
        gridQ.Columns(7).DefaultCellStyle.Format = "N2"
        gridQ.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Dim myCustomerT As String = ""
        Dim myMethodT As String = ""
        If cboKH.Text = "SEAGATE" Then
            myCustomerT = "SEA"
        ElseIf cboKH.Text = "TOSHIBA" Then
            myCustomerT = "TSB"
        ElseIf cboKH.Text = "HGST" Then
            myCustomerT = "WDC"
        ElseIf cboKH.Text = "WESTERN DIGITAL" Then
            myCustomerT = "WD"
        ElseIf cboKH.Text = "OTHER" Then
            myCustomerT = "OTHER"
        End If
        If cboLoai.Text <> "All" Then
            myMethodT = Microsoft.VisualBasic.Left(cboLoai.Text, 1)
        ElseIf cboLoai.Text = "All" Then
            myMethodT = "All"
        End If

        If rdoNgay.Checked Then
            Dim paraS(10) As SqlClient.SqlParameter
            paraS(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dteStart.DateTime))
            paraS(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dteEnd.DateTime))
            paraS(2) = New SqlClient.SqlParameter("@StartLT", GetStartDayOfMonth(dteStart.DateTime))
            paraS(3) = New SqlClient.SqlParameter("@EndLT", GetEndDate(dteEnd.DateTime))
            paraS(4) = New SqlClient.SqlParameter("@StartM", GetStartDayOfMonth(dteStart.DateTime.AddMonths(-1)))
            paraS(5) = New SqlClient.SqlParameter("@EndM", GetEndDayOfMonth(dteStart.DateTime.AddMonths(-1)))
            paraS(6) = New SqlClient.SqlParameter("@Customer", myCustomer)
            paraS(7) = New SqlClient.SqlParameter("@Size", mySize)
            paraS(8) = New SqlClient.SqlParameter("@Method", myMethod)
            paraS(9) = New SqlClient.SqlParameter("@YYYY", GetQuaterByFinancial(dteStart.DateTime))
            paraS(10) = New SqlClient.SqlParameter("@CustomerTarget", myCustomerT & myMethodT)

            gridQ.DataSource = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyDay]", paraS)

            Dim dtTarget As DataTable = _db.FillDataTable(String.Format("select  * from DF_TargetCodeAll " +
                                                                        " where YYYY='{0}' and Customer='{1}'",
                                                         GetQuaterByFinancial(dteStart.DateTime),
                                                          myCustomerT & myMethodT))
            GridControl1.DataSource = gridQ.DataSource
            GridControlSetFormat(GridView1)
            GridView1.BestFitColumns()
            GridView1.Columns("ID").Visible = False

            Dim paraT(1) As SqlClient.SqlParameter
            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(dteStart.DateTime))
            paraT(1) = New SqlClient.SqlParameter("@End", GetEndDate(dteEnd.DateTime))

            Dim dtSumCus As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyCustomer]", paraT)
            'HGST -> WDC
            For r = 0 To dtSumCus.Rows.Count - 1
                If dtSumCus.Rows(r)("Customer") = "HGST (D)" Then
                    dtSumCus.Rows(r)("Customer") = "WDC"
                End If
            Next
            gridCS.DataSource = dtSumCus
            For c As Integer = gridCS.Columns("RateT").Index + 1 To gridCS.ColumnCount - 1
                gridCS.Columns(c).Width = 50
                gridCS.Columns(c).DefaultCellStyle.Format = "N0"
                If rdoTL.Checked Then
                    gridCS.Columns(c).DefaultCellStyle.Format = "N2"
                    If ckoTL.Checked Then
                        For Each r As DataGridViewRow In gridCS.Rows
                            If r.Cells(c).Value IsNot DBNull.Value Then
                                r.Cells(c).Value = r.Cells(c).Value / r.Cells("InsQtyT").Value
                            End If
                        Next
                    Else
                        For Each r As DataGridViewRow In gridCS.Rows
                            If r.Cells(c).Value IsNot DBNull.Value Then
                                r.Cells(c).Value = r.Cells(c).Value / r.Cells("InsQtyT").Value * 100.0
                            End If
                        Next
                    End If
                End If
            Next
        End If
        If rdoTuan.Checked Then
            Dim paraS(10) As SqlClient.SqlParameter
            paraS(0) = New SqlClient.SqlParameter("@StartT", GetStartDate(dteStart.DateTime))
            paraS(1) = New SqlClient.SqlParameter("@EndT", GetEndDate(dteEnd.DateTime))
            paraS(2) = New SqlClient.SqlParameter("@StartT1", GetStartDate(dteStart.DateTime.AddDays(-7)))
            paraS(3) = New SqlClient.SqlParameter("@EndT1", GetEndDate(dteEnd.DateTime.AddDays(-7)))
            paraS(4) = New SqlClient.SqlParameter("@StartT2", GetStartDate(dteStart.DateTime.AddDays(-14)))
            paraS(5) = New SqlClient.SqlParameter("@EndT2", GetEndDate(dteEnd.DateTime.AddDays(-14)))
            paraS(6) = New SqlClient.SqlParameter("@Customer", myCustomer)
            paraS(7) = New SqlClient.SqlParameter("@Size", mySize)
            paraS(8) = New SqlClient.SqlParameter("@Method", myMethod)
            paraS(9) = New SqlClient.SqlParameter("@YYYY", GetQuaterByFinancial(dteStart.DateTime))
            paraS(10) = New SqlClient.SqlParameter("@CustomerTarget", myCustomerT & myMethodT)

            gridQ.DataSource = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyTuan]", paraS)

            Dim dtTarget As DataTable = _db.FillDataTable(String.Format("select  * from DF_TargetCodeAll " +
                                                                        " where YYYY='{0}' and Customer='{1}'",
                                                         GetQuaterByFinancial(dteStart.DateTime),
                                                          myCustomerT & myMethodT))
            GridControl1.DataSource = gridQ.DataSource
            GridControlSetFormat(GridView1)
            GridView1.BestFitColumns()
            GridView1.Columns("ID").Visible = False

            Dim paraT(1) As SqlClient.SqlParameter
            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(dteStart.DateTime))
            paraT(1) = New SqlClient.SqlParameter("@End", GetEndDate(dteEnd.DateTime))

            Dim dtSumCus As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyCustomer]", paraT)
            'HGST -> WDC
            For r = 0 To dtSumCus.Rows.Count - 1
                If dtSumCus.Rows(r)("Customer") = "HGST (D)" Then
                    dtSumCus.Rows(r)("Customer") = "WDC"
                End If
            Next
            gridCS.DataSource = dtSumCus
            For c As Integer = gridCS.Columns("RateT").Index + 1 To gridCS.ColumnCount - 1
                gridCS.Columns(c).Width = 50
                gridCS.Columns(c).DefaultCellStyle.Format = "N0"
                If rdoTL.Checked Then
                    gridCS.Columns(c).DefaultCellStyle.Format = "N2"
                    If ckoTL.Checked Then
                        For Each r As DataGridViewRow In gridCS.Rows
                            If r.Cells(c).Value IsNot DBNull.Value Then
                                r.Cells(c).Value = r.Cells(c).Value / r.Cells("InsQtyT").Value
                            End If
                        Next
                    Else
                        For Each r As DataGridViewRow In gridCS.Rows
                            If r.Cells(c).Value IsNot DBNull.Value Then
                                r.Cells(c).Value = r.Cells(c).Value / r.Cells("InsQtyT").Value * 100.0
                            End If
                        Next
                    End If
                End If
            Next
        End If
        If rdoThang.Checked Then
            Dim paraS(10) As SqlClient.SqlParameter
            paraS(0) = New SqlClient.SqlParameter("@StartT", GetStartDate(dteStart.DateTime))
            paraS(1) = New SqlClient.SqlParameter("@EndT", GetEndDate(dteEnd.DateTime))
            paraS(2) = New SqlClient.SqlParameter("@StartT1", GetStartDayOfMonth(dteStart.DateTime.AddMonths(-1)))
            paraS(3) = New SqlClient.SqlParameter("@EndT1", GetEndDayOfMonth(dteStart.DateTime.AddMonths(-1)))
            paraS(4) = New SqlClient.SqlParameter("@StartT2", GetStartDayOfMonth(dteStart.DateTime.AddMonths(-2)))
            paraS(5) = New SqlClient.SqlParameter("@EndT2", GetEndDayOfMonth(dteStart.DateTime.AddMonths(-2)))
            paraS(6) = New SqlClient.SqlParameter("@Customer", myCustomer)
            paraS(7) = New SqlClient.SqlParameter("@Size", mySize)
            paraS(8) = New SqlClient.SqlParameter("@Method", myMethod)
            paraS(9) = New SqlClient.SqlParameter("@YYYY", GetQuaterByFinancial(dteStart.DateTime))
            paraS(10) = New SqlClient.SqlParameter("@CustomerTarget", myCustomerT & myMethodT)

            gridQ.DataSource = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyThang]", paraS)
            Dim dtTarget As DataTable = _db.FillDataTable(String.Format("select  * from DF_TargetCodeAll " +
                                                                        " where YYYY='{0}' and Customer='{1}'",
                                                         GetQuaterByFinancial(dteStart.DateTime),
                                                          myCustomerT & myMethodT))
            GridControl1.DataSource = gridQ.DataSource
            GridControlSetFormat(GridView1)
            GridView1.BestFitColumns()
            GridView1.Columns("ID").Visible = False

            Dim paraT(1) As SqlClient.SqlParameter
            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(dteStart.DateTime))
            paraT(1) = New SqlClient.SqlParameter("@End", GetEndDate(dteEnd.DateTime))

            Dim dtSumCus As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyCustomer]", paraT)
            'HGST -> WDC
            For r = 0 To dtSumCus.Rows.Count - 1
                If dtSumCus.Rows(r)("Customer") = "HGST (D)" Then
                    dtSumCus.Rows(r)("Customer") = "WDC"
                End If
            Next
            gridCS.DataSource = dtSumCus
            For c As Integer = gridCS.Columns("RateT").Index + 1 To gridCS.ColumnCount - 1
                gridCS.Columns(c).Width = 50
                gridCS.Columns(c).DefaultCellStyle.Format = "N0"
                If rdoTL.Checked Then
                    gridCS.Columns(c).DefaultCellStyle.Format = "N2"
                    If ckoTL.Checked Then
                        For Each r As DataGridViewRow In gridCS.Rows
                            If r.Cells(c).Value IsNot DBNull.Value Then
                                r.Cells(c).Value = r.Cells(c).Value / r.Cells("InsQtyT").Value
                            End If
                        Next
                    Else
                        For Each r As DataGridViewRow In gridCS.Rows
                            If r.Cells(c).Value IsNot DBNull.Value Then
                                r.Cells(c).Value = r.Cells(c).Value / r.Cells("InsQtyT").Value * 100.0
                            End If
                        Next
                    End If
                End If
            Next
        End If
        If rdoQuy.Checked Then
            Dim paraS(14) As SqlClient.SqlParameter
            paraS(0) = New SqlClient.SqlParameter("@StartQ", GetStartDate(dteStart.DateTime))
            paraS(1) = New SqlClient.SqlParameter("@EndQ", GetEndDate(dteEnd.DateTime))
            paraS(2) = New SqlClient.SqlParameter("@StartQ1", GetStartDayOfQuarter(dteStart.DateTime.AddMonths(-3)))
            paraS(3) = New SqlClient.SqlParameter("@EndQ1", GetEndDayOfQuarter(dteStart.DateTime.AddMonths(-3)))

            paraS(4) = New SqlClient.SqlParameter("@StartT1", GetStartDayOfMonth(dteStart.DateTime))
            paraS(5) = New SqlClient.SqlParameter("@EndT1", GetEndDayOfMonth(dteStart.DateTime))
            paraS(6) = New SqlClient.SqlParameter("@StartT2", GetStartDayOfMonth(dteStart.DateTime.AddMonths(1)))
            paraS(7) = New SqlClient.SqlParameter("@EndT2", GetEndDayOfMonth(dteStart.DateTime.AddMonths(1)))
            paraS(8) = New SqlClient.SqlParameter("@StartT3", GetStartDayOfMonth(dteStart.DateTime.AddMonths(2)))
            paraS(9) = New SqlClient.SqlParameter("@EndT3", GetEndDayOfMonth(dteStart.DateTime.AddMonths(2)))
            paraS(10) = New SqlClient.SqlParameter("@Customer", myCustomer)
            paraS(11) = New SqlClient.SqlParameter("@Size", mySize)
            paraS(12) = New SqlClient.SqlParameter("@Method", myMethod)
            paraS(13) = New SqlClient.SqlParameter("@YYYY", GetQuaterByFinancial(dteStart.DateTime))
            paraS(14) = New SqlClient.SqlParameter("@CustomerTarget", myCustomerT & myMethodT)

            gridQ.DataSource = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyQuy]", paraS)
            Dim dtTarget As DataTable = _db.FillDataTable(String.Format("select  * from DF_TargetCodePR1 " +
                                                                        " where YYYY='{0}' and Customer='{1}'",
                                                          GetQuaterByFinancial(dteStart.DateTime),
                                                          myCustomerT & myMethodT))
            GridControl1.DataSource = gridQ.DataSource
            GridControlSetFormat(GridView1)
            GridView1.BestFitColumns()
            GridView1.Columns("ID").Visible = False

            For Each r As DataGridViewRow In gridQ.Rows
                If r.Cells("ThangQ").Value = "Q1" Then
                    r.Cells("ThangQ").Value = GetQuaterByFinancialXX(dteStart.DateTime.AddMonths(-3))
                ElseIf r.Cells("ThangQ").Value = "Q" Then
                    r.Cells("ThangQ").Value = GetQuaterByFinancialXX(dteStart.DateTime)
                End If
            Next


            Dim paraT(1) As SqlClient.SqlParameter
            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(dteStart.DateTime))
            paraT(1) = New SqlClient.SqlParameter("@End", GetEndDate(dteEnd.DateTime))

            Dim dtSumCus As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyCustomer]", paraT)
            'HGST -> WDC
            For r = 0 To dtSumCus.Rows.Count - 1
                If dtSumCus.Rows(r)("Customer") = "HGST (D)" Then
                    dtSumCus.Rows(r)("Customer") = "WDC"
                End If
            Next
            gridCS.DataSource = dtSumCus
            For c As Integer = gridCS.Columns("RateT").Index + 1 To gridCS.ColumnCount - 1
                gridCS.Columns(c).Width = 50
                gridCS.Columns(c).DefaultCellStyle.Format = "N0"
                If rdoTL.Checked Then
                    gridCS.Columns(c).DefaultCellStyle.Format = "N2"
                    If ckoTL.Checked Then
                        For Each r As DataGridViewRow In gridCS.Rows
                            If r.Cells(c).Value IsNot DBNull.Value Then
                                r.Cells(c).Value = r.Cells(c).Value / r.Cells("InsQtyT").Value
                            End If
                        Next
                    Else
                        For Each r As DataGridViewRow In gridCS.Rows
                            If r.Cells(c).Value IsNot DBNull.Value Then
                                r.Cells(c).Value = r.Cells(c).Value / r.Cells("InsQtyT").Value * 100.0
                            End If
                        Next
                    End If
                End If
            Next
        End If

        If rdoYear.Checked Then
            Dim paraS(28) As SqlClient.SqlParameter
            paraS(0) = New SqlClient.SqlParameter("@StartT1", GetStartDayOfMonth(dteStart.DateTime))
            paraS(1) = New SqlClient.SqlParameter("@EndT1", GetEndDayOfMonth(dteStart.DateTime))
            paraS(2) = New SqlClient.SqlParameter("@StartT2", GetStartDayOfMonth(dteStart.DateTime.AddMonths(1)))
            paraS(3) = New SqlClient.SqlParameter("@EndT2", GetEndDayOfMonth(dteStart.DateTime.AddMonths(1)))
            paraS(4) = New SqlClient.SqlParameter("@StartT3", GetStartDayOfMonth(dteStart.DateTime.AddMonths(2)))
            paraS(5) = New SqlClient.SqlParameter("@EndT3", GetEndDayOfMonth(dteStart.DateTime.AddMonths(2)))
            paraS(6) = New SqlClient.SqlParameter("@StartT4", GetStartDayOfMonth(dteStart.DateTime.AddMonths(3)))
            paraS(7) = New SqlClient.SqlParameter("@EndT4", GetEndDayOfMonth(dteStart.DateTime.AddMonths(3)))
            paraS(8) = New SqlClient.SqlParameter("@StartT5", GetStartDayOfMonth(dteStart.DateTime.AddMonths(4)))
            paraS(9) = New SqlClient.SqlParameter("@EndT5", GetEndDayOfMonth(dteStart.DateTime.AddMonths(4)))
            paraS(10) = New SqlClient.SqlParameter("@StartT6", GetStartDayOfMonth(dteStart.DateTime.AddMonths(5)))
            paraS(11) = New SqlClient.SqlParameter("@EndT6", GetEndDayOfMonth(dteStart.DateTime.AddMonths(5)))
            paraS(12) = New SqlClient.SqlParameter("@StartT7", GetStartDayOfMonth(dteStart.DateTime.AddMonths(6)))
            paraS(13) = New SqlClient.SqlParameter("@EndT7", GetEndDayOfMonth(dteStart.DateTime.AddMonths(6)))
            paraS(14) = New SqlClient.SqlParameter("@StartT8", GetStartDayOfMonth(dteStart.DateTime.AddMonths(7)))
            paraS(15) = New SqlClient.SqlParameter("@EndT8", GetEndDayOfMonth(dteStart.DateTime.AddMonths(7)))
            paraS(16) = New SqlClient.SqlParameter("@StartT9", GetStartDayOfMonth(dteStart.DateTime.AddMonths(8)))
            paraS(17) = New SqlClient.SqlParameter("@EndT9", GetEndDayOfMonth(dteStart.DateTime.AddMonths(8)))
            paraS(18) = New SqlClient.SqlParameter("@StartT10", GetStartDayOfMonth(dteStart.DateTime.AddMonths(9)))
            paraS(19) = New SqlClient.SqlParameter("@EndT10", GetEndDayOfMonth(dteStart.DateTime.AddMonths(9)))
            paraS(20) = New SqlClient.SqlParameter("@StartT11", GetStartDayOfMonth(dteStart.DateTime.AddMonths(10)))
            paraS(21) = New SqlClient.SqlParameter("@EndT11", GetEndDayOfMonth(dteStart.DateTime.AddMonths(10)))
            paraS(22) = New SqlClient.SqlParameter("@StartT12", GetStartDayOfMonth(dteStart.DateTime.AddMonths(11)))
            paraS(23) = New SqlClient.SqlParameter("@EndT12", GetEndDayOfMonth(dteStart.DateTime.AddMonths(11)))
            paraS(24) = New SqlClient.SqlParameter("@Customer", myCustomer)
            paraS(25) = New SqlClient.SqlParameter("@Size", mySize)
            paraS(26) = New SqlClient.SqlParameter("@Method", myMethod)
            paraS(27) = New SqlClient.SqlParameter("@YYYY", GetQuaterByFinancial(dteStart.DateTime))
            paraS(28) = New SqlClient.SqlParameter("@CustomerTarget", myCustomerT & myMethodT)

            gridQ.DataSource = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyNam]", paraS)

            Dim dtTarget As DataTable = _db.FillDataTable(String.Format("select  * from DF_TargetCodePR1 " +
                                                                        " where YYYY='{0}' and Customer='{1}'",
                                                          GetQuaterByFinancial(dteStart.DateTime),
                                                          myCustomerT & myMethodT))
            GridControl1.DataSource = gridQ.DataSource
            GridControlSetFormat(GridView1)
            GridView1.BestFitColumns()
            GridView1.Columns("ID").Visible = False

            Dim paraT(1) As SqlClient.SqlParameter
            paraT(0) = New SqlClient.SqlParameter("@Start", GetStartDate(dteStart.DateTime))
            paraT(1) = New SqlClient.SqlParameter("@End", GetEndDate(dteEnd.DateTime))

            Dim dtSumCus As DataTable = _db.ExecuteStoreProcedureTB("[sp_RI_GetSumbyCustomer]", paraT)
            'HGST -> WDC
            For r = 0 To dtSumCus.Rows.Count - 1
                If dtSumCus.Rows(r)("Customer") = "HGST (D)" Then
                    dtSumCus.Rows(r)("Customer") = "WDC"
                End If
            Next
            gridCS.DataSource = dtSumCus
            For c As Integer = gridCS.Columns("RateT").Index + 1 To gridCS.ColumnCount - 1
                gridCS.Columns(c).Width = 50
                gridCS.Columns(c).DefaultCellStyle.Format = "N0"
                If rdoTL.Checked Then
                    gridCS.Columns(c).DefaultCellStyle.Format = "N2"
                    If ckoTL.Checked Then
                        For Each r As DataGridViewRow In gridCS.Rows
                            If r.Cells(c).Value IsNot DBNull.Value Then
                                r.Cells(c).Value = r.Cells(c).Value / r.Cells("InsQtyT").Value
                            End If
                        Next
                    Else
                        For Each r As DataGridViewRow In gridCS.Rows
                            If r.Cells(c).Value IsNot DBNull.Value Then
                                r.Cells(c).Value = r.Cells(c).Value / r.Cells("InsQtyT").Value * 100.0
                            End If
                        Next
                    End If
                End If
            Next
        End If


        For Each c As DataGridViewColumn In gridQ.Columns
            If c.Index > gridQ.Columns("RateQ").Index Then
                c.Width = 50
                c.DefaultCellStyle.Format = "N0"
                If rdoTL.Checked Then
                    If ckoTL.Checked Then
                        c.DefaultCellStyle.Format = "N2"
                        For Each r As DataGridViewRow In gridQ.Rows
                            If r.Index > 0 Then
                                If r.Cells(c.Index).Value IsNot DBNull.Value Then
                                    r.Cells(c.Index).Value = r.Cells(c.Index).Value / r.Cells("InsQtyQ").Value
                                End If
                            End If
                        Next
                    Else
                        c.DefaultCellStyle.Format = "N2"
                        For Each r As DataGridViewRow In gridQ.Rows
                            If r.Index > 0 Then
                                If r.Cells(c.Index).Value IsNot DBNull.Value Then
                                    r.Cells(c.Index).Value = r.Cells(c.Index).Value * 100.0 / r.Cells("InsQtyQ").Value
                                End If
                            End If
                        Next
                    End If
                End If
            ElseIf c.Index = gridQ.Columns("RateQ").Index Then
                If ckoTL.Checked Then
                    For Each r As DataGridViewRow In gridQ.Rows
                        If r.Index > 0 Then
                            r.Cells("RateQ").Value = r.Cells("RateQ").Value / 100.0
                        End If
                    Next
                End If
            End If
        Next


        If ckoTL.Checked Then
            If gridCS.Rows.Count > 0 Then
                For Each r As DataGridViewRow In gridCS.Rows
                    r.Cells("RateT").Value = r.Cells("RateT").Value / 100.0
                Next
            End If
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        Dim lst As New List(Of DataGridView)
        If gridCSD.Visible Then
            lst.Add(gridCSD)
        End If
        If gridCD.Visible Then
            lst.Add(gridCD)
        End If
        If gridCS.RowCount > 0 Then
            lst.Add(gridCS)
        End If
        ExportEXCEL_ColumnVisible(lst)
    End Sub
    Private Sub gridCD_DataBindingComplete(sender As System.Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles gridCD.DataBindingComplete
        If tb IsNot Nothing Then
            If tb.Rows.Count > 0 Then
                txtLotQty.Text = CType(tb.Compute("sum(LotQTy)", bdn.BindingSource.Filter), Integer).ToString("N0")
                txtStartQty.Text = CType(tb.Compute("sum(StartQty)", bdn.BindingSource.Filter), Integer).ToString("N0")
                txtinsQty.Text = CType(tb.Compute("sum(insqty)", bdn.BindingSource.Filter), Integer).ToString("N0")
                txtOKQty.Text = CType(tb.Compute("sum(OKQty)", bdn.BindingSource.Filter), Integer).ToString("N0")
                txtNgQty.Text = CType(tb.Compute("sum(NgQty)", bdn.BindingSource.Filter), Integer).ToString("N0")
                txtRate.Text = CType(tb.Compute("sum(OKQty)*100.0/sum(StartQty)", bdn.BindingSource.Filter), Decimal).ToString("N0")

            End If
        End If
    End Sub

    Private Sub gridCSD_DataBindingComplete(sender As System.Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles gridCSD.DataBindingComplete
        If tb IsNot Nothing Then
            If tb.Rows.Count > 0 Then
                txtLotQty.Text = CType(tb.Compute("sum(LotQTy)", bdn.BindingSource.Filter), Integer).ToString("N0")
                txtStartQty.Text = CType(tb.Compute("sum(StartQty)", bdn.BindingSource.Filter), Integer).ToString("N0")
                txtinsQty.Text = CType(tb.Compute("sum(insqty)", bdn.BindingSource.Filter), Integer).ToString("N0")
                txtOKQty.Text = CType(tb.Compute("sum(OKQty)", bdn.BindingSource.Filter), Integer).ToString("N0")
                txtNgQty.Text = CType(tb.Compute("sum(NgQty)", bdn.BindingSource.Filter), Integer).ToString("N0")
                txtRate.Text = CType(tb.Compute("sum(OKQty)*100.0/sum(StartQty)", bdn.BindingSource.Filter), Decimal).ToString("N0")

            End If
        End If
    End Sub

    Private Sub mnuChartTLCP_Click(sender As System.Object, e As System.EventArgs) Handles mnuChartTLCP.Click
        If gridCS.RowCount > 0 Then
            Dim frm As New FrmCharts
            frm.grid = gridCS
            frm._title = "TLCP" + " <" + IIf(cboKH.Text = "", "All", cboKH.Text) + " - " + IIf(cboLoai.Text = "", "All Side", cboLoai.Text) + "> ( " + dteStart.DateTime.ToString("dd.MM") + " ~ " + dteEnd.DateTime.ToString("dd.MM") + " )"
            frm.LoadChartTLCP()
            frm.Show()
        End If
    End Sub

    Private Sub mnuChartDF_Click(sender As System.Object, e As System.EventArgs) Handles mnuChartDF.Click
        If rdoNgay.Checked Or rdoYear.Checked Then
            If gridQ.RowCount > 0 Then
                Dim target As Decimal = 0
                Dim obj As New PS_Target
                obj.ID_K = GetQuaterByFinancial(dteStart.DateTime)
                _db.GetObject(obj)

                Dim frm As New FrmCharts
                frm.grid = gridQ
                frm._title = IIf(cboKH.Text = "", "All", cboKH.Text) + " ( " + IIf(cboLoai.Text = "", "All", cboLoai.Text) + " - " + IIf(txtProduct.Text = "", "All Product", txtProduct.Text) + " ) "

                If cboLoai.Text = "Single Side" Then
                    If cboKH.Text = "SEAGATE" Then
                        target = obj.SEAS
                    ElseIf cboKH.Text = "TOSHIBA" Then
                        target = obj.TSBS
                    ElseIf cboKH.Text = "HGST" Then
                        target = obj.HGSTS
                    ElseIf cboKH.Text = "WESTERN DIGITAL" Then
                        target = obj.WD
                    Else
                        target = obj.TotalS
                    End If
                ElseIf cboLoai.Text = "Double Side" Then
                    If cboKH.Text = "SEAGATE" Then
                        target = obj.SEAD
                    ElseIf cboKH.Text = "TOSHIBA" Then
                        target = obj.TSBD
                    ElseIf cboKH.Text = "HGST" Then
                        target = obj.HGSTD
                    ElseIf cboKH.Text = "WESTERN DIGITAL" Then
                        target = obj.WD
                    Else
                        target = obj.TotalD
                    End If
                Else
                    If cboKH.Text = "SEAGATE" Then
                        target = obj.SEAS
                    ElseIf cboKH.Text = "TOSHIBA" Then
                        target = obj.TotalS
                    ElseIf cboKH.Text = "HGST" Then
                        target = obj.HGSTS
                    ElseIf cboKH.Text = "WESTERN DIGITAL" Then
                        target = obj.WD
                    Else
                        target = obj.Total
                    End If
                End If

                frm.LoadChartDefectDay(target)
                frm.Show()
            End If
        ElseIf rdoQuy.Checked Then
            If gridQ.RowCount > 0 Then
                Dim frm As New FrmCharts
                frm.grid = gridQ
                frm._title = "Top defect mode of " + "(" + IIf(cboKH.Text = "", "All", cboKH.Text) + " - " + IIf(cboLoai.Text = "", "All Side", cboLoai.Text) + " - " + IIf(txtProduct.Text = "", "All Product", txtProduct.Text) + ") product"
                frm.LoadChartDefectQuy()
                frm.Show()
            End If
        Else
            If gridQ.RowCount > 0 Then
                Dim frm As New FrmCharts
                frm.grid = gridQ
                frm._title = "Top defect mode of " + "(" + IIf(cboKH.Text = "", "All", cboKH.Text) + " - " + IIf(cboLoai.Text = "", "All Side", cboLoai.Text) + " - " + IIf(txtProduct.Text = "", "All Product", txtProduct.Text) + ") product"
                frm.LoadChartDefectTuanThang()
                frm.Show()
            End If
        End If
    End Sub

    Private Sub mnuExportQ_Click_1(sender As Object, e As EventArgs) Handles mnuExportQ.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub mnuTarget_Click(sender As Object, e As EventArgs) Handles mnuTarget.Click
        Dim frm As New FrmTargeCode
        frm.Show()
    End Sub

    Private Sub dteStart_EditValueChanged(sender As Object, e As EventArgs) Handles dteStart.EditValueChanged
        dteEnd.EditValue = dteStart.DateTime
    End Sub

    Private Sub FrmReportDetail_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        dteStart.EditValue = DateTime.Now.AddDays(-1)
    End Sub

    Private Sub rdoNgay_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNgay.CheckedChanged
        If rdoNgay.Checked Then
            dteStart.DateTime = DateTime.Now.AddDays(-1)
            dteEnd.DateTime = dteStart.DateTime
        End If
    End Sub

    Private Sub rdoTuan_CheckedChanged(sender As Object, e As EventArgs) Handles rdoTuan.CheckedChanged
        If rdoTuan.Checked Then
            dteStart.DateTime = DateTime.Now.AddDays(-1)
            dteStart.DateTime = GetFirstDayOfWeek(dteStart.DateTime)
            dteEnd.DateTime = LastDayOfWeek(dteStart.DateTime)
        End If
    End Sub

    Private Sub rdoThang_CheckedChanged(sender As Object, e As EventArgs) Handles rdoThang.CheckedChanged
        If rdoThang.Checked Then
            dteStart.DateTime = DateTime.Now.AddDays(-1)
            dteStart.DateTime = GetStartDayOfMonth(dteStart.DateTime)
            dteEnd.DateTime = GetEndDayOfMonth(dteStart.DateTime)
        End If
    End Sub

    Private Sub rdoQuy_CheckedChanged(sender As Object, e As EventArgs) Handles rdoQuy.CheckedChanged
        If rdoQuy.Checked Then
            dteStart.DateTime = DateTime.Now.AddDays(-1)
            dteStart.DateTime = GetStartDayOfQuarter(dteStart.DateTime)
            dteEnd.DateTime = GetEndDayOfQuarter(dteStart.DateTime)
        End If
    End Sub

    Private Sub rdoYear_CheckedChanged(sender As Object, e As EventArgs) Handles rdoYear.CheckedChanged
        If rdoQuy.Checked Then
            dteStart.DateTime = DateTime.Now.AddDays(-1)
            dteStart.DateTime = GetStartDayOfYear(dteStart.DateTime)
            dteEnd.DateTime = GetEndDayOfYear(dteStart.DateTime)
        End If
    End Sub

    Private Sub gridCD_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridCD.CellClick
        If gridCD.CurrentCell.Value IsNot Nothing And gridCD.CurrentCell.RowIndex >= 0 And gridCD.CurrentCell IsNot Nothing Then
            Dim product As String = gridCD.Item("ProductCodeCD", gridCD.CurrentCell.RowIndex).Value
            txtProduct.Text = product

            Dim myCustomer As Object = DBNull.Value
            Dim mySize As Object = DBNull.Value
            Dim myMethod As Object = DBNull.Value
            Dim myCustomerT As String = ""
            Dim myMethodT As String = ""

            If cboSize.Text <> "" And cboSize.Text <> "All" Then
                mySize = cboSize.Text
            End If
            If cboLoai.Text = "All" Or cboLoai.Text = "" Then
                myMethod = DBNull.Value
            ElseIf cboLoai.Text = "Single Side" Then
                myMethod = "01"
            ElseIf cboLoai.Text = "Double Side" Then
                myMethod = "02"
            End If
            If cboKH.Text <> "" And cboKH.Text <> "All" Then
                If cboKH.Text <> "Other" Then
                    myCustomer = cboKH.Text
                Else
                    myCustomer = "CANON"
                End If
            End If

            If cboKH.Text = "SEAGATE" Then
                myCustomerT = "SEA"
            ElseIf cboKH.Text = "TOSHIBA" Then
                myCustomerT = "TSB"
            ElseIf cboKH.Text = "HGST" Then
                myCustomerT = "WDC"
            ElseIf cboKH.Text = "WESTERN DIGITAL" Then
                myCustomerT = "WD"
            ElseIf cboKH.Text = "OTHER" Then
                myCustomerT = "OTHER"
            End If
            If cboLoai.Text <> "All" Then
                myMethodT = Microsoft.VisualBasic.Left(cboLoai.Text, 1)
            ElseIf cboLoai.Text = "All" Then
                myMethodT = "All"
            End If

            GridView1.Columns.Clear()
            If rdoNgay.Checked Then
                Dim paraS(11) As SqlClient.SqlParameter
                paraS(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dteStart.DateTime))
                paraS(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dteEnd.DateTime))
                paraS(2) = New SqlClient.SqlParameter("@StartLT", GetStartDayOfMonth(dteStart.DateTime))
                paraS(3) = New SqlClient.SqlParameter("@EndLT", GetEndDate(dteEnd.DateTime))
                paraS(4) = New SqlClient.SqlParameter("@StartM", GetStartDayOfMonth(dteStart.DateTime.AddMonths(-1)))
                paraS(5) = New SqlClient.SqlParameter("@EndM", GetEndDayOfMonth(dteStart.DateTime.AddMonths(-1)))
                paraS(6) = New SqlClient.SqlParameter("@Customer", myCustomer)
                paraS(7) = New SqlClient.SqlParameter("@Size", mySize)
                paraS(8) = New SqlClient.SqlParameter("@Method", myMethod)
                paraS(9) = New SqlClient.SqlParameter("@YYYY", GetQuaterByFinancial(dteStart.DateTime))
                paraS(10) = New SqlClient.SqlParameter("@CustomerTarget", myCustomerT & myMethodT)
                paraS(11) = New SqlClient.SqlParameter("@Product", product)

                Dim dtNgay As DataTable = _db.ExecuteStoreProcedureTB("sp_RI_GetSumbyDay_Product", paraS)
                If dtNgay.Rows.Count > 0 Then
                    GridControl1.DataSource = dtNgay
                    GridView1.Columns("ID").Visible = False
                    gridQ.DataSource = dtNgay
                End If
            ElseIf rdoTuan.Checked Then
                Dim paraS(11) As SqlClient.SqlParameter
                paraS(0) = New SqlClient.SqlParameter("@StartT", GetStartDate(dteStart.DateTime))
                paraS(1) = New SqlClient.SqlParameter("@EndT", GetEndDate(dteEnd.DateTime))
                paraS(2) = New SqlClient.SqlParameter("@StartT1", GetStartDate(dteStart.DateTime.AddDays(-7)))
                paraS(3) = New SqlClient.SqlParameter("@EndT1", GetEndDate(dteEnd.DateTime.AddDays(-7)))
                paraS(4) = New SqlClient.SqlParameter("@StartT2", GetStartDate(dteStart.DateTime.AddDays(-14)))
                paraS(5) = New SqlClient.SqlParameter("@EndT2", GetEndDate(dteEnd.DateTime.AddDays(-14)))
                paraS(6) = New SqlClient.SqlParameter("@Customer", myCustomer)
                paraS(7) = New SqlClient.SqlParameter("@Size", mySize)
                paraS(8) = New SqlClient.SqlParameter("@Method", myMethod)
                paraS(9) = New SqlClient.SqlParameter("@YYYY", GetQuaterByFinancial(dteStart.DateTime))
                paraS(10) = New SqlClient.SqlParameter("@CustomerTarget", myCustomerT & myMethodT)
                paraS(11) = New SqlClient.SqlParameter("@Product", product)

                Dim dtTuan As DataTable = _db.ExecuteStoreProcedureTB("sp_RI_GetSumbyTuan_Product", paraS)
                If dtTuan.Rows.Count > 0 Then
                    GridControl1.DataSource = dtTuan
                    GridView1.Columns("ID").Visible = False
                    gridQ.DataSource = dtTuan
                End If
            ElseIf rdoThang.Checked Then
                Dim paraS(11) As SqlClient.SqlParameter
                paraS(0) = New SqlClient.SqlParameter("@StartT", GetStartDate(dteStart.DateTime))
                paraS(1) = New SqlClient.SqlParameter("@EndT", GetEndDate(dteEnd.DateTime))
                paraS(2) = New SqlClient.SqlParameter("@StartT1", GetStartDayOfMonth(dteStart.DateTime.AddMonths(-1)))
                paraS(3) = New SqlClient.SqlParameter("@EndT1", GetEndDayOfMonth(dteStart.DateTime.AddMonths(-1)))
                paraS(4) = New SqlClient.SqlParameter("@StartT2", GetStartDayOfMonth(dteStart.DateTime.AddMonths(-2)))
                paraS(5) = New SqlClient.SqlParameter("@EndT2", GetEndDayOfMonth(dteStart.DateTime.AddMonths(-2)))
                paraS(6) = New SqlClient.SqlParameter("@Customer", myCustomer)
                paraS(7) = New SqlClient.SqlParameter("@Size", mySize)
                paraS(8) = New SqlClient.SqlParameter("@Method", myMethod)
                paraS(9) = New SqlClient.SqlParameter("@YYYY", GetQuaterByFinancial(dteStart.DateTime))
                paraS(10) = New SqlClient.SqlParameter("@CustomerTarget", myCustomerT & myMethodT)
                paraS(11) = New SqlClient.SqlParameter("@Product", product)

                Dim dtThang As DataTable = _db.ExecuteStoreProcedureTB("sp_RI_GetSumbyThang_Product", paraS)
                If dtThang.Rows.Count > 0 Then
                    GridControl1.DataSource = dtThang
                    GridView1.Columns("ID").Visible = False
                    gridQ.DataSource = dtThang
                End If
            ElseIf rdoQuy.Checked Then
                Dim paraS(15) As SqlClient.SqlParameter
                paraS(0) = New SqlClient.SqlParameter("@StartQ", GetStartDate(dteStart.DateTime))
                paraS(1) = New SqlClient.SqlParameter("@EndQ", GetEndDate(dteEnd.DateTime))
                paraS(2) = New SqlClient.SqlParameter("@StartQ1", GetStartDayOfQuarter(dteStart.DateTime.AddMonths(-3)))
                paraS(3) = New SqlClient.SqlParameter("@EndQ1", GetEndDayOfQuarter(dteStart.DateTime.AddMonths(-3)))

                paraS(4) = New SqlClient.SqlParameter("@StartT1", GetStartDayOfMonth(dteStart.DateTime))
                paraS(5) = New SqlClient.SqlParameter("@EndT1", GetEndDayOfMonth(dteStart.DateTime))
                paraS(6) = New SqlClient.SqlParameter("@StartT2", GetStartDayOfMonth(dteStart.DateTime.AddMonths(1)))
                paraS(7) = New SqlClient.SqlParameter("@EndT2", GetEndDayOfMonth(dteStart.DateTime.AddMonths(1)))
                paraS(8) = New SqlClient.SqlParameter("@StartT3", GetStartDayOfMonth(dteStart.DateTime.AddMonths(2)))
                paraS(9) = New SqlClient.SqlParameter("@EndT3", GetEndDayOfMonth(dteStart.DateTime.AddMonths(2)))
                paraS(10) = New SqlClient.SqlParameter("@Customer", myCustomer)
                paraS(11) = New SqlClient.SqlParameter("@Size", mySize)
                paraS(12) = New SqlClient.SqlParameter("@Method", myMethod)
                paraS(13) = New SqlClient.SqlParameter("@YYYY", GetQuaterByFinancial(dteStart.DateTime))
                paraS(14) = New SqlClient.SqlParameter("@CustomerTarget", myCustomerT & myMethodT)
                paraS(15) = New SqlClient.SqlParameter("@Product", product)

                Dim dtQuy As DataTable = _db.ExecuteStoreProcedureTB("sp_RI_GetSumbyQuy_Product", paraS)
                If dtQuy.Rows.Count > 0 Then
                    GridControl1.DataSource = dtQuy
                    GridView1.Columns("ID").Visible = False
                    gridQ.DataSource = dtQuy
                End If
            ElseIf rdoYear.Checked Then
                Dim paraS(29) As SqlClient.SqlParameter
                paraS(0) = New SqlClient.SqlParameter("@StartT1", GetStartDayOfMonth(dteStart.DateTime))
                paraS(1) = New SqlClient.SqlParameter("@EndT1", GetEndDayOfMonth(dteStart.DateTime))
                paraS(2) = New SqlClient.SqlParameter("@StartT2", GetStartDayOfMonth(dteStart.DateTime.AddMonths(1)))
                paraS(3) = New SqlClient.SqlParameter("@EndT2", GetEndDayOfMonth(dteStart.DateTime.AddMonths(1)))
                paraS(4) = New SqlClient.SqlParameter("@StartT3", GetStartDayOfMonth(dteStart.DateTime.AddMonths(2)))
                paraS(5) = New SqlClient.SqlParameter("@EndT3", GetEndDayOfMonth(dteStart.DateTime.AddMonths(2)))
                paraS(6) = New SqlClient.SqlParameter("@StartT4", GetStartDayOfMonth(dteStart.DateTime.AddMonths(3)))
                paraS(7) = New SqlClient.SqlParameter("@EndT4", GetEndDayOfMonth(dteStart.DateTime.AddMonths(3)))
                paraS(8) = New SqlClient.SqlParameter("@StartT5", GetStartDayOfMonth(dteStart.DateTime.AddMonths(4)))
                paraS(9) = New SqlClient.SqlParameter("@EndT5", GetEndDayOfMonth(dteStart.DateTime.AddMonths(4)))
                paraS(10) = New SqlClient.SqlParameter("@StartT6", GetStartDayOfMonth(dteStart.DateTime.AddMonths(5)))
                paraS(11) = New SqlClient.SqlParameter("@EndT6", GetEndDayOfMonth(dteStart.DateTime.AddMonths(5)))
                paraS(12) = New SqlClient.SqlParameter("@StartT7", GetStartDayOfMonth(dteStart.DateTime.AddMonths(6)))
                paraS(13) = New SqlClient.SqlParameter("@EndT7", GetEndDayOfMonth(dteStart.DateTime.AddMonths(6)))
                paraS(14) = New SqlClient.SqlParameter("@StartT8", GetStartDayOfMonth(dteStart.DateTime.AddMonths(7)))
                paraS(15) = New SqlClient.SqlParameter("@EndT8", GetEndDayOfMonth(dteStart.DateTime.AddMonths(7)))
                paraS(16) = New SqlClient.SqlParameter("@StartT9", GetStartDayOfMonth(dteStart.DateTime.AddMonths(8)))
                paraS(17) = New SqlClient.SqlParameter("@EndT9", GetEndDayOfMonth(dteStart.DateTime.AddMonths(8)))
                paraS(18) = New SqlClient.SqlParameter("@StartT10", GetStartDayOfMonth(dteStart.DateTime.AddMonths(9)))
                paraS(19) = New SqlClient.SqlParameter("@EndT10", GetEndDayOfMonth(dteStart.DateTime.AddMonths(9)))
                paraS(20) = New SqlClient.SqlParameter("@StartT11", GetStartDayOfMonth(dteStart.DateTime.AddMonths(10)))
                paraS(21) = New SqlClient.SqlParameter("@EndT11", GetEndDayOfMonth(dteStart.DateTime.AddMonths(10)))
                paraS(22) = New SqlClient.SqlParameter("@StartT12", GetStartDayOfMonth(dteStart.DateTime.AddMonths(11)))
                paraS(23) = New SqlClient.SqlParameter("@EndT12", GetEndDayOfMonth(dteStart.DateTime.AddMonths(11)))
                paraS(24) = New SqlClient.SqlParameter("@Customer", myCustomer)
                paraS(25) = New SqlClient.SqlParameter("@Size", mySize)
                paraS(26) = New SqlClient.SqlParameter("@Method", myMethod)
                paraS(27) = New SqlClient.SqlParameter("@YYYY", GetQuaterByFinancial(dteStart.DateTime))
                paraS(28) = New SqlClient.SqlParameter("@CustomerTarget", myCustomerT & myMethodT)
                paraS(29) = New SqlClient.SqlParameter("@Product", product)

                Dim dtNam As DataTable = _db.ExecuteStoreProcedureTB("sp_RI_GetSumbyNam_Product", paraS)
                If dtNam.Rows.Count > 0 Then
                    GridControl1.DataSource = dtNam
                    GridView1.Columns("ID").Visible = False
                    gridQ.DataSource = dtNam
                End If
            End If

            If GridView1.RowCount > 0 Then
                Dim c As GridColumn = GridView1.Columns("TLCP")
                c.DisplayFormat.FormatType = Utils.FormatType.Numeric
                c.DisplayFormat.FormatString = "n2"
                If rdoTL.Checked Then
                    For Each column As GridColumn In GridView1.Columns
                        If column.VisibleIndex > GridView1.Columns("TLCP").VisibleIndex Then
                            For r As Integer = 0 To GridView1.DataRowCount - 1
                                If GridView1.GetRowCellValue(r, column) IsNot DBNull.Value And GridView1.GetRowCellValue(r, "InsQty") IsNot DBNull.Value Then
                                    GridView1.SetRowCellValue(r, column, Math.Round(((GridView1.GetRowCellValue(r, column) * 100) / GridView1.GetRowCellValue(r, "InsQty")), 2))
                                End If
                            Next
                        End If
                    Next
                End If
            End If
        End If
    End Sub
End Class