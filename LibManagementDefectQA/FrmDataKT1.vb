﻿
Imports CommonDB
Imports LibEntity
Imports PublicUtility
Imports System.Windows.Forms

Public Class FrmDataKT1 : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _dbF As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)

    Private Sub mnuEdit_Click(sender As System.Object, e As System.EventArgs) Handles mnuEdit.Click
        Dim objLock As New MDQA_Lock
        objLock.Ngay_K = GridView1.GetFocusedRowCellValue("Ngay")
        _db.GetObject(objLock)
        If objLock.Lock Then
            ShowWarning("Dữ liệu ngày này đã bị khóa không thể sửa.")
            Return
        End If

        If GridView1.SelectedRowsCount > 0 Then
            LoadDetail(GridView1.GetFocusedRowCellValue("ID"))
        End If

        GridControlReadOnly(GridView2, True)
        GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridView2.Columns("STT").OptionsColumn.ReadOnly = False
        GridView2.Columns("SL").OptionsColumn.ReadOnly = False
        GridView2.Columns("ThoiGian").OptionsColumn.ReadOnly = False
        GridView2.Columns("DefectCode").OptionsColumn.ReadOnly = False
        GridView2.Columns("DefectQty").OptionsColumn.ReadOnly = False
        GridView2.Columns("ShortNo").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView2)

        GridControlReadOnly(GridView1, True)
        GridView1.Columns("ProductCode").OptionsColumn.ReadOnly = False
        GridView1.Columns("SoTrang").OptionsColumn.ReadOnly = False
        GridView1.Columns("Phong").OptionsColumn.ReadOnly = False
        GridView1.Columns("AQL").OptionsColumn.ReadOnly = False
        GridView1.Columns("LotQty").OptionsColumn.ReadOnly = False
        GridView1.Columns("ThoiGianRM").OptionsColumn.ReadOnly = False
        GridView1.Columns("GhiChu").OptionsColumn.ReadOnly = False
        GridView1.Columns("LotNo").OptionsColumn.ReadOnly = False
        GridView1.Columns("Ngay").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)

    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim sql As String = String.Format("[sp_MDQA_LoadKT1_Head]")
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Start", GetStartDate(dtpStart.Value))
        para(1) = New SqlClient.SqlParameter("@End", GetStartDate(dtpEnd.Value))
        If txtPdCode.Text <> "" Then
            para(2) = New SqlClient.SqlParameter("@ProductCode", txtPdCode.Text)
        Else
            para(2) = New SqlClient.SqlParameter("@ProductCode", DBNull.Value)
        End If
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB(sql, para)
        GridControlSetFormat(GridView1, 4)
        GridView1.Columns("ID").Visible = False

        GridControlSetColorReadonly(GridView1)
        GridControlSetColorReadonly(GridView2)
    End Sub

    Sub LoadAll()
        Dim sql As String = String.Format("[sp_MDQA_LoadKT1_Head]")
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Start", GetStartDate(dtpStart.Value))
        para(1) = New SqlClient.SqlParameter("@End", GetStartDate(dtpEnd.Value))
        If txtPdCode.Text <> "" Then
            para(2) = New SqlClient.SqlParameter("@ProductCode", txtPdCode.Text)
        Else
            para(2) = New SqlClient.SqlParameter("@ProductCode", DBNull.Value)
        End If
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB(sql, para)
        GridControlSetFormatEdit(GridView1, 4)
        GridView1.Columns("ID").Visible = False
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub mnuXoa_Click(sender As System.Object, e As System.EventArgs) Handles mnuXoaHeader.Click
        If GridView1.SelectedRowsCount > 0 Then
            Dim objLock As New MDQA_Lock
            objLock.Ngay_K = GridView1.GetFocusedRowCellValue("Ngay")
            _db.GetObject(objLock)
            If objLock.Lock Then
                ShowWarning("Dữ liệu ngày này đã bị khóa không thể sửa.")
                Return
            End If
            If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
                For Each r As Integer In GridView1.GetSelectedRows
                    Dim obj As New MDQA_KT1
                    obj.ID_K = GridView1.GetRowCellValue(r, "ID")
                    _db.Delete(obj)
                Next
                mnuShowAll.PerformClick()
            End If
        End If
    End Sub

    Private Sub mnuXoaD_Click(sender As System.Object, e As System.EventArgs)
        If GridView1.SelectedRowsCount > 0 Then
            If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
                For Each r As Integer In GridView2.GetSelectedRows
                    Dim obj As New MDQA_KT1_Detail
                    obj.IDD_K = GridView2.GetRowCellValue(r, "ID")
                    _db.Delete(obj)
                Next
                GridView2.DeleteSelectedRows()
            End If
        End If
    End Sub

    Private Sub FrmDataKT1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter And GridView2.IsFocusedView = False Then
            If txtghichu.Focused = False Then
                SendKeys.Send("{Tab}")
            End If
        End If
        If e.Control And e.KeyCode = Keys.S Then
            mnuSave.PerformClick()
        End If
        If e.Control And e.KeyCode = Keys.Q Then
            mnuCopyHeader.PerformClick()
        End If
    End Sub

    Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click
        Dim objLock As New MDQA_Lock
        objLock.Ngay_K = GetStartDate(dtpStart.Value)
        _db.GetObject(objLock)
        If objLock.Lock Then
            ShowWarning("Dữ liệu ngày này đã bị khóa không thể sửa.")
            Return
        End If

        If txtPdCode.Text = "" Then
            ShowWarning("Bạn chưa nhập mã sản phẩm.")
            txtPdCode.Focus()
            Return
        End If
        If txtLotNo.Text = "" Then
            ShowWarning("Bạn chưa LotNo.")
            txtLotNo.Focus()
            Return
        End If
        If txtTrang.Text = "" Then
            ShowWarning("Bạn chưa nhập số trang")
            txtTrang.Focus()
            Return
        End If
        If cboPhong.Text = "" Then
            ShowWarning("Bạn chưa nhập phòng")
            cboPhong.Focus()
            Return
        End If
        If txtLotQty.Text = "" Then
            ShowWarning("Bạn chưa nhập LotQty")
            txtLotQty.Focus()
            Return
        End If
        If txtAQL.Text = "" Then
            ShowWarning("Bạn chưa nhập AQL")
            txtAQL.Focus()
            Return
        End If
        'If txtThoiGianRM.Text = "" Then
        '    ShowWarning("Bạn chưa nhập hoiGianRM")
        '    txtThoiGianRM.Focus()
        '    Return
        'End If
        If ShowQuestionSave() = Windows.Forms.DialogResult.Yes Then

            Dim obj As New MDQA_KT1
            obj.ID_K = Guid.NewGuid.ToString
            obj.ProductCode = txtPdCode.Text

            If Not txtLotNo.Text.Contains("-") Then
                obj.LotNo = GetLotNo(obj.ProductCode, txtLotNo.Text.PadLeft(5, "0"))
            Else
                obj.LotNo = GetLotNo(obj.ProductCode, txtLotNo.Text.Split("-")(0).PadLeft(5, "0"))
                obj.LotNo = obj.LotNo & "-" & txtLotNo.Text.Split("-")(1)
            End If

            obj.Ngay = GetStartDate(dtpStart.Value) 'GetDate9051(txtPdCode.Text, txtLotNo.Text)
            obj.CreateDate = DateTime.Now
            obj.ProductName = _dbF.ExecuteScalar(String.Format(" SELECT top 1 [ProductNameE] " +
                                                " FROM [m_Product] where ProductCode='{0}' " +
                                                " order by RevisionCode ",
                                                txtPdCode.Text.PadLeft(5, "0")))
            obj.Customer = _dbF.ExecuteScalar(String.Format(" SELECT top 1 [CustomerNameE] " +
                                                " FROM [m_Product] p inner join m_Customer c on c.CustomerCode=p.CustomerCode " +
                                                " where ProductCode='{0}' " +
                                                " order by RevisionCode ",
                                                txtPdCode.Text.PadLeft(5, "0")))
            obj.SoTrang = txtTrang.Text
            If cboPhong.Text = "1" Or cboPhong.Text = "2" Or cboPhong.Text = "3" Then
                obj.Phong = "INS" & cboPhong.Text
            Else
                obj.Phong = "318"
            End If
            obj.LotQty = txtLotQty.Text
            obj.AQL = txtAQL.Text
            obj.ThoiGianRM = 0
            obj.GhiChu = txtghichu.Text
            If Microsoft.VisualBasic.Left(obj.ProductCode, 1) = "7" Then
                obj.LoaiHang = "THU-NGHIEM"
            Else
                obj.LoaiHang = "HANG-THUONG"
            End If

            _db.Insert(obj)
            LoadAll()
            LoadDetail("")

            txtPdCode.Focus()
            txtPdCode.Text = ""
            txtLotNo.Text = ""
            txtTrang.Text = ""
            cboPhong.Text = ""
            txtLotQty.Text = ""
            txtAQL.Text = ""
            txtThoiGianRM.Text = ""
            txtghichu.Text = ""

        End If

    End Sub
    Function GetDate9051(ByVal pdcode As String, ByVal lotno As String) As DateTime
        Dim sql As String = String.Format("Select EndDate from t_ProcessResult where " +
                                          " ProductCode='{0}' and LotNumber='{1}' and ProcessCode='9051'",
                                          txtPdCode.Text, txtLotNo.Text)
        Dim obj As Object = _dbF.ExecuteScalar(sql)
        If obj IsNot DBNull.Value Then
            Return obj
        Else
            Return DateTime.MinValue
        End If
    End Function
    Function GetLotNo(ByVal pdcode As String, ByVal lotno As String) As String
        Dim obj As New t_ManufactureLot
        obj.ProductCode_K = pdcode
        obj.LotNumber_K = lotno
        obj.ComponentCode_K = "B00"
        _dbF.GetObject(obj)
        If obj.EntryDate > DateTime.MinValue Then
            Return lotno & Microsoft.VisualBasic.Right(obj.EntryDate.Year, 1) & obj.EntryDate.ToString("MM")
        Else
            Return lotno
        End If
    End Function

    Private Sub txtPdCode_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPdCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPdCode.Text <> "" Then
                txtPdCode.Text = txtPdCode.Text.PadLeft(5, "0")
            End If
        End If
    End Sub

    Private Sub txtLotNo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLotNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtLotNo.Text <> "" And Not txtLotNo.Text.Contains("-") Then
                txtLotNo.Text = txtLotNo.Text.PadLeft(5, "0")
            End If
        End If
    End Sub

    Private Sub FrmDataKT1_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
        mnuXoaHeader.Enabled = mnuEdit.Enabled
        mnuXoaD.Enabled = mnuEdit.Enabled
    End Sub

    Private Sub txtghichu_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtghichu.KeyDown
        If e.KeyCode = Keys.Enter Then
            mnuSave.PerformClick()
        End If
    End Sub

    Private Sub mnuCopy_Click(sender As System.Object, e As System.EventArgs) Handles mnuCopyHeader.Click
        If GridView1.SelectedRowsCount > 0 Then
            Dim objLock As New MDQA_Lock
            objLock.Ngay_K = GridView1.GetFocusedRowCellValue("Ngay")
            _db.GetObject(objLock)
            If objLock.Lock Then
                ShowWarning("Dữ liệu ngày này đã bị khóa không thể sửa.")
                Return
            End If
            If ShowQuestion(String.Format("Bạn muốn copy mã:{0} và lot:{1} ",
                                          GridView1.GetFocusedRowCellValue("ProductCode"),
                                          GridView1.GetFocusedRowCellValue("LotNo"))) = Windows.Forms.DialogResult.Yes Then
                Dim obj As New MDQA_KT1
                obj.ID_K = GridView1.GetFocusedRowCellValue("ID")
                _db.GetObject(obj)
                obj.ID_K = Guid.NewGuid.ToString()
                obj.AQL = 0
                obj.LotQty = 0
                obj.ThoiGianRM = 0
                obj.GhiChu = ""
                _db.Insert(obj)

                txtPdCode.Text = ""
                txtLotNo.Text = ""
                txtPdCode.Text = obj.ProductCode
                txtLotNo.Text = obj.LotNo

                LoadAll()
                LoadDetail("")
            End If
        End If
    End Sub

    Private Sub mnuBC_Click(sender As System.Object, e As System.EventArgs) Handles mnuBC.Click
        For Each r As Integer In GridView1.GetSelectedRows
            Dim obj As New MDQA_KTPL
            obj.ID_K = GridView1.GetRowCellValue(r, "ID")
            _db.GetObject(obj)
            obj.BaoCao = True
            _db.Update(obj)
        Next
        mnuShowAll.PerformClick()
    End Sub

    Private Sub mnuNOBC_Click(sender As System.Object, e As System.EventArgs) Handles mnuNOBC.Click
        For Each r As Integer In GridView1.GetSelectedRows
            Dim obj As New MDQA_KTPL
            obj.ID_K = GridView1.GetRowCellValue(r, "ID")
            _db.GetObject(obj)
            obj.BaoCao = False
            _db.Update(obj)
        Next
        mnuShowAll.PerformClick()
    End Sub

    Private Sub txtPdCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPdCode.TextChanged

        If txtPdCode.Text = "" Then
            GridView1.ActiveFilterString = ""
            If txtLotNo.Text = "" Then
                GridView1.ActiveFilterString = ""
            Else
                GridView1.ActiveFilterString = String.Format("LotNo like '%{0}%' ", txtLotNo.Text)
            End If
        Else
            If txtLotNo.Text = "" Then
                GridView1.ActiveFilterString = String.Format("productcode like '%{0}%'", txtPdCode.Text)
            Else
                GridView1.ActiveFilterString = String.Format("productcode like '%{0}%' and LotNo like '%{1}%' ",
                                                             txtPdCode.Text, txtLotNo.Text)
            End If
        End If
    End Sub

    Private Sub txtLotNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLotNo.TextChanged
        If txtPdCode.Text = "" Then
            GridView1.ActiveFilterString = ""
            If txtLotNo.Text = "" Then
                GridView1.ActiveFilterString = ""
            Else
                GridView1.ActiveFilterString = String.Format("LotNo like '%{0}%' ", txtLotNo.Text)
            End If
        Else
            If txtLotNo.Text = "" Then
                GridView1.ActiveFilterString = String.Format("productcode like '%{0}%'", txtPdCode.Text)
            Else
                GridView1.ActiveFilterString = String.Format("productcode like '%{0}%' and LotNo like '%{1}%' ",
                                                             txtPdCode.Text, txtLotNo.Text)
            End If
        End If
    End Sub

    Private Sub txtPdCode_Leave(sender As Object, e As EventArgs) Handles txtPdCode.Leave
        If txtPdCode.Text <> "" Then
            LoadAll()
        End If
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowClick
        LoadDetail(GridView1.GetFocusedRowCellValue("ID"))
    End Sub

    Sub LoadDetail(myID As String)
        Dim sql As String = String.Format("SELECT IDD, ID, EmpID, STT, SL, ThoiGian, DefectCode, DefectQty, ShortNo, EmpIDPr3, Shift
                                           FROM MDQA_KT1_Detail 
                                           WHERE ID = '{0}' 
                                           ORDER BY CreateDate",
                                           myID)

        GridControl2.DataSource = _db.FillDataTable(sql)
        GridControlSetFormat(GridView2)
        GridControlReadOnly(GridView2, True)
        GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridView2.Columns("STT").OptionsColumn.ReadOnly = False
        GridView2.Columns("SL").OptionsColumn.ReadOnly = False
        GridView2.Columns("ThoiGian").OptionsColumn.ReadOnly = False
        GridView2.Columns("DefectCode").OptionsColumn.ReadOnly = False
        GridView2.Columns("DefectQty").OptionsColumn.ReadOnly = False
        GridView2.Columns("ShortNo").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView2)

        GridView2.Columns("ID").Visible = False
        GridView2.Columns("IDD").Visible = False
        GridView2.BestFitColumns()
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.ReadOnly = False And GridView1.Editable And isEdit Then
            Dim objLock As New MDQA_Lock
            objLock.Ngay_K = GridView1.GetFocusedRowCellValue("Ngay")
            _db.GetObject(objLock)
            If objLock.Lock Then
                ShowWarning("Dữ liệu ngày này đã bị khóa không thể sửa.")
                Return
            End If

            Dim obj As New MDQA_KT1
            obj.ID_K = GridView1.GetFocusedRowCellValue("ID")
            _db.GetObject(obj)
            If obj.CreateDate = DateTime.MinValue Then
                obj.CreateDate = DateTime.Now
            End If
            If e.Column.FieldName = "SoTrang" Then
                If GridView1.GetFocusedRowCellValue("SoTrang") IsNot DBNull.Value Then
                    obj.SoTrang = GridView1.GetFocusedRowCellValue("SoTrang")
                Else
                    obj.SoTrang = ""
                End If
            ElseIf e.Column.FieldName = "ProductCode" Then
                If GridView1.GetFocusedRowCellValue("ProductCode") IsNot DBNull.Value Then
                    obj.ProductCode = GridView1.GetFocusedRowCellValue("ProductCode")
                Else
                    obj.ProductCode = ""
                End If


                obj.ProductName = _dbF.ExecuteScalar(String.Format(" SELECT top 1 [ProductNameE] " +
                                               " FROM [m_Product] where ProductCode='{0}' " +
                                               " order by RevisionCode ",
                                               obj.ProductCode))
                obj.Customer = _dbF.ExecuteScalar(String.Format(" SELECT top 1 [CustomerNameE] " +
                                                    " FROM [m_Product] p inner join m_Customer c on c.CustomerCode=p.CustomerCode " +
                                                    " where ProductCode='{0}' " +
                                                    " order by RevisionCode ",
                                                    obj.ProductCode))
                If GridView1.GetFocusedRowCellValue("LotNo") IsNot DBNull.Value Then
                    Dim myLot As String = GridView1.GetFocusedRowCellValue("LotNo")

                    If Not myLot.Contains("-") Then
                        obj.LotNo = GetLotNo(obj.ProductCode, myLot.PadLeft(5, "0"))
                    Else
                        obj.LotNo = GetLotNo(obj.ProductCode, myLot.Split("-")(0).PadLeft(5, "0"))
                        obj.LotNo = obj.LotNo & "-" & myLot.Split("-")(1)
                    End If
                End If
                isEdit = False
                GridView1.SetFocusedRowCellValue("ProductName", obj.ProductName)
                GridView1.SetFocusedRowCellValue("Customer", obj.Customer)
                GridView1.SetFocusedRowCellValue("LotNo", obj.LotNo)
                isEdit = True
            ElseIf e.Column.FieldName = "Phong" Then
                If GridView1.GetFocusedRowCellValue("Phong") IsNot DBNull.Value Then
                    obj.Phong = GridView1.GetFocusedRowCellValue("Phong")
                Else
                    obj.Phong = ""
                End If
            ElseIf e.Column.FieldName = "ThoiGianRM" Then
                If GridView1.GetFocusedRowCellValue("ThoiGianRM") IsNot DBNull.Value Then
                    obj.ThoiGianRM = GridView1.GetFocusedRowCellValue("ThoiGianRM")
                Else
                    obj.ThoiGianRM = ""
                End If
            ElseIf e.Column.FieldName = "LotQty" Then
                If GridView1.GetFocusedRowCellValue("LotQty") IsNot DBNull.Value Then
                    obj.LotQty = GridView1.GetFocusedRowCellValue("LotQty")
                Else
                    obj.LotQty = 0
                End If
            ElseIf e.Column.FieldName = "AQL" Then
                If GridView1.GetFocusedRowCellValue("AQL") IsNot DBNull.Value Then
                    obj.AQL = GridView1.GetFocusedRowCellValue("AQL")
                Else
                    obj.AQL = ""
                End If
            ElseIf e.Column.FieldName = "GhiChu" Then
                If GridView1.GetFocusedRowCellValue("GhiChu") IsNot DBNull.Value Then
                    obj.GhiChu = GridView1.GetFocusedRowCellValue("GhiChu")
                Else
                    obj.GhiChu = ""
                End If
            ElseIf e.Column.FieldName = "Ngay" Then
                If GridView1.GetFocusedRowCellValue("Ngay") IsNot DBNull.Value Then
                    obj.Ngay = GridView1.GetFocusedRowCellValue("Ngay")

                    If obj.Ngay < DateTime.Now.AddMonths(-2).Date Or obj.Ngay > DateTime.Now.Date Then
                        ShowWarning("Không được nhập quá 2 tháng của quá khứ hoặc lớn hơn ngày hiện tại !")
                        Return
                    End If
                Else
                    obj.Ngay = Nothing
                End If

            ElseIf e.Column.FieldName = "LotNo" Then
                If GridView1.GetFocusedRowCellValue("LotNo") IsNot DBNull.Value Then
                    Dim myLot As String = GridView1.GetFocusedRowCellValue("LotNo")

                    If Not myLot.Contains("-") Then
                        obj.LotNo = GetLotNo(obj.ProductCode, myLot.PadLeft(5, "0"))
                    Else
                        obj.LotNo = GetLotNo(obj.ProductCode, myLot.Split("-")(0).PadLeft(5, "0"))
                        obj.LotNo = obj.LotNo & "-" & myLot.Split("-")(1)
                    End If
                Else
                    obj.LotNo = ""
                End If
            End If

            _db.Update(obj)
        End If
    End Sub

    Dim isEdit As Boolean = True
    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        If e.Column.ReadOnly = False And GridView2.Editable And isEdit Then
            Dim obj As New MDQA_KT1_Detail
            obj.ID = GridView1.GetFocusedRowCellValue("ID")
            If GridView2.GetFocusedRowCellValue("IDD") IsNot DBNull.Value Then
                obj.IDD_K = GridView2.GetFocusedRowCellValue("IDD")
            Else
                obj.IDD_K = Guid.NewGuid.ToString()
                isEdit = False
                GridView2.SetFocusedRowCellValue("IDD", obj.IDD_K)
                isEdit = True
                obj.CreateDate = DateTime.Now
            End If

            If GridView2.GetFocusedRowCellValue("STT") IsNot DBNull.Value Then
                obj.STT = GridView2.GetFocusedRowCellValue("STT")
                If e.Column.FieldName = "STT" Then
                    Dim obje As MDQA_Employee = _db.GetObject(Of MDQA_Employee)(String.Format("select * from MDQA_Employee where STT={0}", obj.STT))
                    If Not _db.ExistObject(obje) Then
                        ShowWarning("Số STT viên không nằm trong danh sách.")
                        Return
                    Else
                        obj.EmpID = obje.EmpID_K
                        isEdit = False
                        GridView2.SetFocusedRowCellValue("EmpID", obje.EmpID_K)
                        isEdit = True
                    End If
                End If
            End If
            If GridView2.GetFocusedRowCellValue("EmpID") IsNot DBNull.Value Then
                obj.EmpID = GridView2.GetFocusedRowCellValue("EmpID")
            End If
            If GridView2.GetFocusedRowCellValue("SL") IsNot DBNull.Value Then
                obj.SL = GridView2.GetFocusedRowCellValue("SL")
            End If
            If GridView2.GetFocusedRowCellValue("ThoiGian") IsNot DBNull.Value Then
                obj.ThoiGian = GridView2.GetFocusedRowCellValue("ThoiGian")
            End If
            If GridView2.GetFocusedRowCellValue("DefectCode") IsNot DBNull.Value Then
                obj.DefectCode = GridView2.GetFocusedRowCellValue("DefectCode")
                obj.DefectCode = obj.DefectCode.PadLeft(3, "0")
                isEdit = False
                GridView2.SetFocusedRowCellValue("DefectCode", obj.DefectCode)
                isEdit = True
                If e.Column.FieldName = "DefectCode" Then
                    Dim obje As New MDQA_DefectCode
                    obje.DefectCode_K = obj.DefectCode
                    If Not _db.ExistObject(obje) Then
                        ShowWarning("Mã lỗi không nằm trong danh sách.")
                        Return
                    End If
                End If
            End If
            If GridView2.GetFocusedRowCellValue("DefectQty") IsNot DBNull.Value Then
                obj.DefectQty = GridView2.GetFocusedRowCellValue("DefectQty")
            End If

            If GridView2.GetFocusedRowCellValue("ShortNo") IsNot DBNull.Value Then
                obj.ShortNo = GridView2.GetFocusedRowCellValue("ShortNo")
                Dim dt = _db.FillDataTable(String.Format("SELECT Shift, h.EmpID
                                                          FROM OT_Employee AS h
                                                          LEFT JOIN  MDQA_Employee_PR3 AS d
                                                          ON h.EmpID = d.EmpID
                                                          WHERE ShortNo = '{0}'", obj.ShortNo))
                Dim empID As Object = ""
                Dim shift As Object = ""
                If dt.Rows.Count > 0 Then
                    empID = dt.Rows(0)("EmpID")
                    shift = dt.Rows(0)("Shift")
                Else
                    empID = obj.ShortNo
                    shift = obj.ShortNo
                End If
                obj.EmpIDPr3 = empID
                obj.Shift = shift
                GridView2.SetFocusedRowCellValue("EmpIDPr3", empID)
                GridView2.SetFocusedRowCellValue("Shift", shift)
            End If

            If obj.IDD_K <> "" And obj.EmpID <> "" Then
                If _db.ExistObject(obj) Then
                    _db.Update(obj)
                Else
                    _db.Insert(obj)
                End If
                If e.Column.FieldName = "ThoiGian" Or
                    e.Column.FieldName = "SL" Or
                    e.Column.FieldName = "DefectQty" Then
                    Dim slThoiGian As Decimal = 0
                    Dim slMau As Decimal = 0
                    Dim slLoi As Decimal = 0
                    For r As Integer = 0 To GridView2.RowCount - 1
                        If GridView2.GetRowCellValue(r, "ThoiGian") IsNot DBNull.Value Then
                            slThoiGian += GridView2.GetRowCellValue(r, "ThoiGian")
                        End If
                        If GridView2.GetRowCellValue(r, "SL") IsNot DBNull.Value Then
                            slMau += GridView2.GetRowCellValue(r, "SL")
                        End If
                        If GridView2.GetRowCellValue(r, "DefectQty") IsNot DBNull.Value Then
                            slLoi += GridView2.GetRowCellValue(r, "DefectQty")
                        End If
                    Next
                    isEdit = False
                    GridView1.SetFocusedRowCellValue("ThoiGianRM", slThoiGian)
                    GridView1.SetFocusedRowCellValue("TotalAQL", slMau)
                    GridView1.SetFocusedRowCellValue("TotalDefect", slLoi)
                    If slLoi > 0 Then
                        GridView1.SetFocusedRowCellValue("Evaluate", "NG")
                    End If
                    isEdit = True
                End If
            End If
        End If
    End Sub

    Private Sub GridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView2.KeyDown
        If GridView2.FocusedColumn.FieldName = "ShortNo" Then
            If GridView2.FocusedRowHandle < 0 Then
                If e.KeyCode = Keys.Enter Then
                    SendKeys.Send("{Enter}")
                    SendKeys.Send("{Enter}")
                    SendKeys.Send("{Enter}")
                End If
            Else
                'GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                GridView2.FocusedColumn = GridView2.Columns("STT")
                GridView2.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
            End If
        End If
    End Sub

    Private Sub mnuXoaD_Click_1(sender As Object, e As EventArgs) Handles mnuXoaD.Click
        If GridView1.SelectedRowsCount > 0 Then
            If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
                For Each r As Integer In GridView2.GetSelectedRows
                    Dim obj As New MDQA_KT1_Detail
                    obj.IDD_K = GridView2.GetRowCellValue(r, "IDD")
                    _db.Delete(obj)
                Next
                GridView2.DeleteSelectedRows()
            End If
        End If
    End Sub
End Class