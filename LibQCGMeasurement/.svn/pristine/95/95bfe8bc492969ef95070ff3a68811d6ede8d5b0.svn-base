Imports LibEntity
Imports CommonDB
Imports PublicUtility
Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmDataDetail : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Public isNew As Boolean = False
    Public _pdCode As String = ""
    Public _mCongDoan As String = ""
    Public _mLotNo As String = ""
    Public _mLantest As Integer = 0


    Private Sub MnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
        Dim d As Integer = 1
        While d <= 32
            grid.Columns("D" & d).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grid.Columns("D" & d).DefaultCellStyle.Format = "N3"
            d += 1
        End While

        Dim obj As New QCS_DataHead
        obj.ProductCode_K = _pdCode
        obj.Process_K = _mCongDoan
        obj.LotNo_K = _mLotNo
        obj.SoLanTest_K = _mLantest
        _db.GetObject(obj)

        txtPdCode.Text = obj.ProductCode_K
        cboProcess.Text = obj.Process_K
        txtCustomer.Text = obj.CustomerName
        txtMethod.Text = obj.Method
        cboMayDo.Text = obj.MayDo

        If obj.NgayDo > DateTime.MinValue Then
            dtpNgayDo.Value = obj.NgayDo
        End If
        txtLotNo.Text = obj.LotNo_K
        txtMSNV.Text = obj.MSNV
        If obj.TGBatDau > DateTime.MinValue Then
            dtpTGStart.Value = obj.TGBatDau
        End If
        If obj.TGKetThuc > DateTime.MinValue Then
            dtpTGEnd.Value = obj.TGKetThuc
        End If

        txtTocDo.Text = obj.TocDo
        txtQuanLuong.Text = obj.QuangLuong
        txtMayRoiSang.Text = obj.MayGiaCong
        txtApLuc.Text = obj.ApLuc
        txtMaPhim.Text = obj.MaPhim

        txtSoLanTest.Text = obj.SoLanTest_K
        txtNoiDungKhongDat.Text = obj.NoiDungKhongDat
        txtDanhGiaSauCung.Text = obj.DanhGiaSauCung

        If txtDanhGiaSauCung.Text = "NG" Then
            txtDanhGiaSauCung.ForeColor = Color.Red
        Else
            txtDanhGiaSauCung.ForeColor = Color.Blue
        End If
        Dim para(3) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@PdCode", txtPdCode.Text)
        para(1) = New SqlClient.SqlParameter("@Process", cboProcess.Text)
        para(2) = New SqlClient.SqlParameter("@LotNo", txtLotNo.Text)
        para(3) = New SqlClient.SqlParameter("@SoLan", txtSoLanTest.Text)

        Dim sql As String = String.Format("sp_QCS_LoadHeadDetail")
        Dim bdsource As New BindingSource
        bdsource.DataSource = _db.ExecuteStoreProcedureTB(sql, para)
        bdn.BindingSource = bdsource
        grid.DataSource = bdsource
        grid.AutoGenerateColumns = False

        For Each c As DataGridViewColumn In grid.Columns
            c.DefaultCellStyle.Format = "N4"
        Next
    End Sub

    Private Sub MnuExport_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub

    Private Sub MnuImport_Click(sender As Object, e As EventArgs) Handles mnuImprt.Click
        Dim objH As New QCS_DataHead
        objH.ProductCode_K = txtPdCode.Text.PadLeft(5, "0")
        objH.Process_K = cboProcess.Text
        objH.LotNo_K = txtLotNo.Text
        objH.SoLanTest_K = txtSoLanTest.Text

        If Not _db.ExistObject(objH) Then
            ShowWarning("Bạn phải lưu trước khi import !")
            Return
        End If

        Dim dtData As DataTable = ImportEXCEL(True)
        If dtData.Rows.Count > 0 Then

            For Each r As DataRow In dtData.Rows
                If r(Item.Name) IsNot DBNull.Value Then
                    Dim obj As New QCS_DataDetail
                    obj.ProductCode_K = txtPdCode.Text
                    obj.Process_K = cboProcess.Text
                    obj.LotNo_K = txtLotNo.Text
                    obj.SoLanTest_K = txtSoLanTest.Text
                    obj.Item_K = r(Item.Name)

                    If IsNumeric(r(D1.Name)) Then
                        obj.D1 = r(D1.Name)
                    End If
                    If IsNumeric(r(D2.Name)) Then
                        obj.D2 = r(D2.Name)
                    End If
                    If IsNumeric(r(D3.Name)) Then
                        obj.D3 = r(D3.Name)
                    End If
                    If IsNumeric(r(D4.Name)) Then
                        obj.D4 = r(D4.Name)
                    End If
                    If IsNumeric(r(D5.Name)) Then
                        obj.D5 = r(D5.Name)
                    End If
                    If IsNumeric(r(D6.Name)) Then
                        obj.D6 = r(D6.Name)
                    End If
                    If IsNumeric(r(D7.Name)) Then
                        obj.D7 = r(D7.Name)
                    End If
                    If IsNumeric(r(D8.Name)) Then
                        obj.D8 = r(D8.Name)
                    End If
                    If IsNumeric(r(D9.Name)) Then
                        obj.D9 = r(D9.Name)
                    End If
                    If IsNumeric(r(D10.Name)) Then
                        obj.D10 = r(D10.Name)
                    End If
                    If IsNumeric(r(D11.Name)) Then
                        obj.D11 = r(D11.Name)
                    End If
                    If IsNumeric(r(D12.Name)) Then
                        obj.D12 = r(D12.Name)
                    End If
                    If IsNumeric(r(D13.Name)) Then
                        obj.D13 = r(D13.Name)
                    End If
                    If IsNumeric(r(D14.Name)) Then
                        obj.D14 = r(D14.Name)
                    End If
                    If IsNumeric(r(D15.Name)) Then
                        obj.D15 = r(D15.Name)
                    End If
                    If IsNumeric(r(D16.Name)) Then
                        obj.D16 = r(D16.Name)
                    End If
                    If IsNumeric(r(D17.Name)) Then
                        obj.D17 = r(D17.Name)
                    End If
                    If IsNumeric(r(D18.Name)) Then
                        obj.D18 = r(D18.Name)
                    End If
                    If IsNumeric(r(D19.Name)) Then
                        obj.D19 = r(D19.Name)
                    End If
                    If IsNumeric(r(D20.Name)) Then
                        obj.D20 = r(D20.Name)
                    End If
                    If IsNumeric(r(D21.Name)) Then
                        obj.D21 = r(D21.Name)
                    End If
                    If IsNumeric(r(D22.Name)) Then
                        obj.D22 = r(D22.Name)
                    End If
                    If IsNumeric(r(D23.Name)) Then
                        obj.D23 = r(D23.Name)
                    End If
                    If IsNumeric(r(D24.Name)) Then
                        obj.D24 = r(D24.Name)
                    End If
                    If IsNumeric(r(D25.Name)) Then
                        obj.D25 = r(D25.Name)
                    End If
                    If IsNumeric(r(D26.Name)) Then
                        obj.D26 = r(D26.Name)
                    End If
                    If IsNumeric(r(D27.Name)) Then
                        obj.D27 = r(D27.Name)
                    End If
                    If IsNumeric(r(D28.Name)) Then
                        obj.D28 = r(D28.Name)
                    End If
                    If IsNumeric(r(D29.Name)) Then
                        obj.D29 = r(D29.Name)
                    End If
                    If IsNumeric(r(D30.Name)) Then
                        obj.D30 = r(D30.Name)
                    End If
                    If IsNumeric(r(D31.Name)) Then
                        obj.D31 = r(D31.Name)
                    End If
                    If IsNumeric(r(D32.Name)) Then
                        obj.D32 = r(D32.Name)
                    End If

                    If _db.ExistObject(obj) Then
                        _db.Update(obj)
                    Else
                        _db.Insert(obj)
                    End If

                End If
            Next
            mnuSave.PerformClick()
        Else
            ShowWarningNotDataImport()
        End If
    End Sub

    Private Sub MnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
        If Not IsNumeric(txtSoLanTest.Text) And txtSoLanTest.Text = "0" Then
            ShowWarning("Số lần test phải là số >0 !")
            Return
        End If
        If dtpTGStart.Checked = False Or dtpTGEnd.Checked = False Then
            ShowWarning("Bạn chưa nhập thời gian bắt đầu và kết thúc !")
            Return
        End If
        If txtLotNo.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập Lotno !")
            Return
        End If
        If cboProcess.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập công đoạn !")
            Return
        End If

        Dim obj As New QCS_DataHead
        obj.ProductCode_K = txtPdCode.Text.PadLeft(5, "0")
        obj.Process_K = cboProcess.Text
        obj.LotNo_K = txtLotNo.Text
        obj.SoLanTest_K = txtSoLanTest.Text

        obj.CustomerName = txtCustomer.Text
        obj.Method = txtMethod.Text
        obj.MayDo = cboMayDo.Text

        obj.NgayDo = dtpNgayDo.Value
        obj.LotNo_K = txtLotNo.Text
        obj.MSNV = txtMSNV.Text
        obj.TGBatDau = dtpTGStart.Value
        obj.TGKetThuc = dtpTGEnd.Value

        obj.TocDo = txtTocDo.Text
        obj.QuangLuong = txtQuanLuong.Text
        obj.MayGiaCong = txtMayRoiSang.Text
        obj.ApLuc = txtApLuc.Text
        obj.MaPhim = txtMaPhim.Text

        obj.SoLanTest_K = txtSoLanTest.Text
        obj.NoiDungKhongDat = txtNoiDungKhongDat.Text
        obj.DanhGiaSauCung = txtDanhGiaSauCung.Text

        obj.CreateDate = DateTime.Now
        obj.CreateUser = CurrentUser.UserID
        If _db.ExistObject(obj) Then
            _db.Update(obj)

            Dim para(3) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@PdCode", txtPdCode.Text)
            para(1) = New SqlClient.SqlParameter("@Process", cboProcess.Text)
            para(2) = New SqlClient.SqlParameter("@LotNo", txtLotNo.Text)
            para(3) = New SqlClient.SqlParameter("@SoLan", txtSoLanTest.Text)

            Dim sql As String = String.Format("sp_QCS_LoadHeadDetailRun")
            Dim bdsource As New BindingSource
            _db.ExecuteStoreProcedureTB(sql, para)

            ''Đánh giá
            Dim dgMC As String = "MCC không đạt: " & vbCrLf
            Dim dgCPK As String = "CPK không đạt: " & vbCrLf
            For Each r As DataGridViewRow In grid.Rows
                If r.Cells(DanhGiaMC.Name).Value = "NG" Then
                    dgMC += r.Cells(Item.Name).Value & ","
                End If
                If r.Cells(CPK.Name).Value IsNot DBNull.Value And r.Cells(CPKD.Name).Value IsNot DBNull.Value Then
                    If r.Cells(CPK.Name).Value > r.Cells(CPKD.Name).Value Then
                        dgCPK += r.Cells(Item.Name).Value & ","
                    End If
                End If
            Next
            dgMC = dgMC.Substring(0, dgMC.Length - 1)
            dgCPK = dgCPK.Substring(0, dgCPK.Length - 1)

            txtNoiDungKhongDat.Text = dgMC & vbCrLf & vbCrLf & dgCPK
            obj.NoiDungKhongDat = txtNoiDungKhongDat.Text
            _db.Update(obj)
        Else
            _db.Insert(obj)
        End If


        mnuShowAll.PerformClick()

        ShowSuccess()
    End Sub

    Private Sub FrmDataDetail_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub

    Private Sub CboCongDoan_TextChanged(sender As Object, e As EventArgs) Handles cboProcess.TextChanged
        Dim objN As Object = _db.ExecuteScalar(String.Format(" select max(N) as N from QCS_Define " +
                                                           " where ProductCode='{0}' " +
                                                           " and Process='{1}' ",
                                                             txtPdCode.Text, cboProcess.Text))
        If objN IsNot DBNull.Value Then
            txtSoMau.Text = objN
        Else
            txtSoMau.Text = ""
        End If
    End Sub

    Private Sub TxtSoMau_TextChanged(sender As Object, e As EventArgs) Handles txtSoMau.TextChanged
        If IsNumeric(txtSoMau.Text) Then
            Dim d As Integer = 1
            Dim somau As Integer = txtSoMau.Text
            While d <= 32
                If somau >= d Then
                    grid.Columns("D" & d).Visible = True
                Else
                    grid.Columns("D" & d).Visible = False
                End If
                d += 1
            End While
        End If
    End Sub

    Private Sub TxtPdCode_TextChanged(sender As Object, e As EventArgs) Handles txtPdCode.TextChanged
        Dim obj As New WT_Product
        obj.ProductCode_K = txtPdCode.Text
        _db.GetObject(obj)
        txtCustomer.Text = obj.CustomerName
        txtMethod.Text = obj.Method

        cboProcess.DataSource = _db.FillDataTable(String.Format(" select distinct Process " +
                                                   " from QCS_Define " +
                                                   " where ProductCode='{0}'", txtPdCode.Text))
        cboProcess.ValueMember = "Process"
        cboProcess.DisplayMember = "Process"
        cboProcess.SelectedIndex = -1
    End Sub

    Private Sub TxtPdCode_Leave(sender As Object, e As EventArgs) Handles txtPdCode.Leave
        txtPdCode.Text = txtPdCode.Text.PadLeft(5, "0")
    End Sub

    Private Sub FrmDataDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub MnuChart_Click(sender As Object, e As EventArgs) Handles mnuChart.Click
        Dim frm As New FrmCharts
        frm._title = "BIỂU ĐỒ THEO DÕI BIẾN ĐỘNG DỮ LIỆU ĐO (" & txtPdCode.Text & "-" & cboProcess.Text & ")"
        frm.grid = grid
        frm.Show()
    End Sub

    Private Sub MnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        If grid.CurrentRow IsNot Nothing Then
            If ShowQuestion("Bạn muốn xóa dòng đang chọn ?") = DialogResult.Yes Then
                For Each r As DataGridViewRow In grid.SelectedRows
                    Dim obj As New QCS_DataDetail
                    obj.ProductCode_K = txtPdCode.Text
                    obj.Process_K = cboProcess.Text
                    obj.LotNo_K = txtLotNo.Text
                    obj.SoLanTest_K = txtSoLanTest.Text
                    obj.Item_K = r.Cells(Item.Name).Value
                    _db.Delete(obj)
                Next
                mnuShowAll.PerformClick()
            End If
        End If
    End Sub

    Private Sub MnuEdit_Click(sender As Object, e As EventArgs) Handles mnuEdit.Click
        grid.ReadOnly = False
        For Each c As DataGridViewColumn In grid.Columns
            If Microsoft.VisualBasic.Left(c.HeaderText, 1) = "D" Then
                c.ReadOnly = False
            Else
                c.ReadOnly = True
            End If
        Next
    End Sub

    Private Sub Grid_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellValueChanged
        If e.RowIndex >= 0 Then
            If grid.Columns(e.ColumnIndex).ReadOnly = False Then
                Dim para(0) As SqlClient.SqlParameter
                para(0) = New SqlClient.SqlParameter("@Value", grid.CurrentRow.Cells(e.ColumnIndex).Value)
                _db.ExecuteNonQuery(String.Format(" update QCS_DataDetail " +
                                                  " set {0}=@Value " +
                                                  " where ProductCode='{1}' and Process='{2}' " +
                                                  " and LotNo='{3}' and Lan={4} and Item='{5}' ",
                                                  grid.Columns(e.ColumnIndex).Name,
                                                   txtPdCode.Text,
                                                   cboProcess.Text,
                                                   txtLotNo.Text,
                                                   txtSoLanTest.Text,
                                                   grid.CurrentRow.Cells(Item.Name).Value), para)

            End If
        End If
    End Sub

    Private Sub Grid_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles grid.DataBindingComplete
        For Each r As DataGridViewRow In grid.Rows
            If r.Cells(DanhGiaMC.Name).Value = "NG" Then
                r.Cells(DanhGiaMC.Name).Style.ForeColor = Color.Red
                r.Cells(DanhGiaMC.Name).Style.BackColor = Color.Yellow
            End If
            If r.Cells(KetQua.Name).Value = "NG" Then
                r.Cells(KetQua.Name).Style.ForeColor = Color.Red
                r.Cells(KetQua.Name).Style.BackColor = Color.Yellow
            End If
            If IsNumeric(r.Cells(CPKD.Name).Value) Then
                If r.Cells(CPK.Name).Value > r.Cells(CPKD.Name).Value Then
                    r.Cells(CPK.Name).Style.ForeColor = Color.Red
                    r.Cells(CPK.Name).Style.BackColor = Color.Yellow
                End If
            End If
            If IsNumeric(r.Cells(CPMD.Name).Value) Then
                If r.Cells(CPM.Name).Value > r.Cells(CPMD.Name).Value Then
                    r.Cells(CPM.Name).Style.ForeColor = Color.Red
                    r.Cells(CPM.Name).Style.BackColor = Color.Yellow
                End If
            End If
        Next
    End Sub
End Class