Imports CommonDB
Imports LibEntity
Imports PublicUtility

Imports System.Windows.Forms
Imports System.IO

Public Class FrmKQCV : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub tlsMenu_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles tlsMenu.Paint
        PublicFunction.FillControl(tlsMenu.Location.X, tlsMenu.Location.Y, tlsMenu.Width, tlsMenu.Height, e)
    End Sub

    Sub LoadPhuongPhap()
        Dim sql As String = String.Format("select ID,PhuongPhap from KQCV_PhuongPhap")
        cboPhuongPhap.DataSource = _db.FillDataTable(sql)
        cboPhuongPhap.ValueMember = "ID"
        cboPhuongPhap.DisplayMember = "PhuongPhap"
    End Sub

    Sub AddNewHead()
        txtPdCode.Text = ""
        txtLotNo.Text = ""
        cboPattan.Text = ""
        cboPdCodeCheck.Text = ""
        cboSoLan.Text = ""
        cboSoMay.Text = ""
        txtQty.Text = ""
        cboPhuongPhap.Text = ""
        txtXacNhan.Text = ""
        txtGhiChu.Text = ""

        Dim sql As String = String.Format("select * from KQQC_KQCV_Detail where ID='{0}'", "")
        Dim bdsource As New BindingSource
        bdsource.DataSource = _db.FillDataTable(sql)
        gridD.DataSource = bdsource

        AddNewDetail()

        txtPdCode.Focus()
        txtID.Text = ""
    End Sub

    Sub AddNewDetail()
        For Each c As Control In scont.Panel1.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            End If
        Next
        txtStart.Text = ""
        txtEnd.Text = ""
    End Sub

    Function CheckHead() As Boolean
        If txtPdCode.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập mã sản phẩm !")
            txtPdCode.Focus()
            Return False
        End If
        If txtLotNo.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập Lotno !")
            txtLotNo.Focus()
            Return False
        End If
        If txtSoTo.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập số tờ !")
            txtSoTo.Focus()
            Return False
        End If
        If cboSoMay.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập số máy !")
            cboSoMay.Focus()
            Return False
        End If
        If cboSoLan.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập số lần test !")
            cboSoLan.Focus()
            Return False
        End If
        If Not IsNumeric(txtQty.Text) Then
            ShowWarning("Bạn chưa nhập số lượng test!")
            txtQty.Focus()
            Return False
        End If
        If cboPattan.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập kết quả kiểm Pattan !")
            cboPattan.Focus()
            Return False
        End If
        If cboPhuongPhap.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập phương pháp !")
            cboPhuongPhap.Focus()
            Return False
        End If
        If txtXacNhan.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập nhân viên xác nhận !")
            txtXacNhan.Focus()
            Return False
        End If
        If cboPdCodeCheck.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập kết quả kiểm product!")
            cboPdCodeCheck.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub FrmKQCV_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
        mnuDelete.Enabled = mnuSave.Enabled
        LoadPhuongPhap()
    End Sub

    Private Sub FrmKQCV_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter And Not txtGhiChu.Focused Then
            SendKeys.Send("{Tab}")
        End If
        If e.KeyCode = Keys.N And e.Control Then
            AddNewHead()
        End If
        If e.KeyCode = Keys.S And e.Control Then
            mnuSave.PerformClick()
        End If
        If e.KeyCode = Keys.D And e.Control Then
            SaveDetail()
        End If
        If e.KeyCode = Keys.F4 Then
            txtV004.Focus()
        End If
        If e.KeyCode = Keys.F5 Then
            txtV005.Focus()
        End If
        If e.KeyCode = Keys.F6 Then
            txtV006.Focus()
        End If
        If e.KeyCode = Keys.F7 Then
            txtV007.Focus()
        End If
        If e.KeyCode = Keys.F8 Then
            txtV627.Focus()
        End If
        If e.KeyCode = Keys.F9 Then
            txtV639.Focus()
        End If
        If e.KeyCode = Keys.F10 Then
            txtVOther.Focus()
        End If
        If e.KeyCode = Keys.O And e.Control Then
            txtOp.Focus()
        End If 
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Ngay", dtpDate.Value.Date)
        Dim sql As String = String.Format("select * from [KQQC_KQCV] where Ngay=@Ngay order by [CreateDate] desc")
        Dim bdsource As New BindingSource
        bdsource.DataSource = _db.FillDataTable(sql, para)
        bdn.BindingSource = bdsource
        grid.DataSource = bdsource
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub

    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuAdd.Click
        AddNewHead() 
    End Sub

    Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click
        'Check Head
        If CheckHead() Then
            Dim obj As New KQQC_KQCV
            obj.ID_K = txtID.Text
            _db.GetObject(obj)
            If obj.ID_K = "" Then
                obj.ID_K = Guid.NewGuid.ToString()
            End If
            obj.ProductCode = txtPdCode.Text.PadLeft(5, "0")
            obj.LotNo = txtLotNo.Text
            obj.SoTo = txtSoTo.Text
            obj.SoMay = cboSoMay.Text
            obj.SoLanTest = cboSoLan.Text
            obj.Qty = txtQty.Text
            obj.Pattan = cboPattan.Text
            obj.ProductCheck = cboPdCodeCheck.Text
            obj.PhuongPhap = cboPhuongPhap.Text
            obj.XacNhan = txtXacNhan.Text
            obj.GhiChu = txtGhiChu.Text
            obj.Ngay = dtpDate.Value.Date
            obj.CreateDate = DateTime.Now
            obj.CreateUser = CurrentUser.UserID
            If _db.ExistObject(obj) Then
                _db.Update(obj)
            Else 
                _db.Insert(obj)
            End If
            txtID.Text = obj.ID_K
            mnuShowAll.PerformClick()
            scont.Focus()
        End If
        'Check Detail
    End Sub
    Sub SaveDetail()
        If Not IsNumeric(txtSheet.Text) Then
            ShowWarning("Sheet phải là số không được để trống !")
            txtSheet.Focus()
            Return
        End If
        If txtStart.Text = "" Then
            ShowWarning("Bạn chưa nhập thời gian bắt đầu.")
            txtStart.Focus()
            Return
        End If
        If txtEnd.Text = "" Then
            ShowWarning("Bạn chưa nhập thời gian kết thúc.")
            txtEnd.Focus()
            Return
        End If
        Dim SGio As Integer = 0
        Dim SPhut As Integer = 0
        Dim EGio As Integer = 0
        Dim EPhut As Integer = 0
        If txtStart.Text.Split(":")(0) <> "" Then
            SGio = txtStart.Text.Split(":")(0)
            If SGio > 23 Then
                ShowWarning("Giờ không được lớn hơn 23h")
                txtStart.Focus()
                Return
            End If
        End If
        If txtStart.Text.Split(":")(1) <> "" Then
            SPhut = txtStart.Text.Split(":")(1)
            If SPhut > 59 Then
                ShowWarning("Phút không được lớn hơn 59'")
                txtStart.Focus()
                Return
            End If
        End If
        If txtEnd.Text.Split(":")(0) <> "" Then
            EGio = txtEnd.Text.Split(":")(0)
            If EGio > 23 Then
                ShowWarning("Giờ không được lớn hơn 23h")
                txtEnd.Focus()
                Return
            End If
        End If
        If txtEnd.Text.Split(":")(1) <> "" Then
            EPhut = txtEnd.Text.Split(":")(1)
            If EPhut > 59 Then
                ShowWarning("Phút không được lớn hơn 59'")
                txtEnd.Focus()
                Return
            End If
        End If

        Dim obj As New KQQC_KQCV_Detail
        obj.ID_K = txtID.Text
        obj.Sheet_K = txtSheet.Text
        obj.BatDau = New DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day, SGio, SPhut, 0)
        obj.KetThuc = New DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day, EGio, EPhut, 0)
        If EGio < SGio Then
            obj.KetThuc = obj.KetThuc.AddDays(1)
        End If
        obj.ThoiGianKiem = (obj.KetThuc - obj.BatDau).TotalMinutes 
        obj.V001 = txtV001.Text
        obj.V002 = txtV002.Text
        obj.V003 = txtV003.Text
        obj.V004 = txtV004.Text
        obj.V005 = txtV005.Text
        obj.V006 = txtV006.Text
        obj.V007 = txtV007.Text
        obj.V627 = txtV627.Text
        obj.V639 = txtV639.Text
        obj.VOther = txtVOther.Text
        If txtQ001.Text <> "" Then
            If IsNumeric(txtQ001.Text) Then
                obj.Q001 = txtQ001.Text
            Else
                ShowWarning("Mode lỗi 001 phải nhập số !")
                txtQ001.Focus()
                Return
            End If
        End If
        If txtQ002.Text <> "" Then
            If IsNumeric(txtQ002.Text) Then
                obj.Q002 = txtQ002.Text
            Else
                ShowWarning("Mode lỗi 002 phải nhập số !")
                txtQ002.Focus()
                Return
            End If
        End If
        If txtQ003.Text <> "" Then
            If IsNumeric(txtQ003.Text) Then
                obj.Q003 = txtQ003.Text
            Else
                ShowWarning("Mode lỗi 003 phải nhập số !")
                txtQ003.Focus()
                Return
            End If
        End If
        If txtQ004.Text <> "" Then
            If IsNumeric(txtQ004.Text) Then
                obj.Q004 = txtQ004.Text
            Else
                ShowWarning("Mode lỗi 004 phải nhập số !")
                txtQ004.Focus()
                Return
            End If
        End If
        If txtQ005.Text <> "" Then
            If IsNumeric(txtQ005.Text) Then
                obj.Q005 = txtQ005.Text
            Else
                ShowWarning("Mode lỗi 005 phải nhập số !")
                txtQ005.Focus()
                Return
            End If
        End If
        If txtQ006.Text <> "" Then
            If IsNumeric(txtQ006.Text) Then
                obj.Q006 = txtQ006.Text
            Else
                ShowWarning("Mode lỗi 006 phải nhập số !")
                txtQ006.Focus()
                Return
            End If
        End If
        If txtQ007.Text <> "" Then
            If IsNumeric(txtQ007.Text) Then
                obj.Q007 = txtQ007.Text
            Else
                ShowWarning("Mode lỗi 007 phải nhập số !")
                txtQ007.Focus()
                Return
            End If
        End If
        If txtQ627.Text <> "" Then
            If IsNumeric(txtQ627.Text) Then
                obj.Q627 = txtQ627.Text
            Else
                ShowWarning("Mode lỗi 627 phải nhập số !")
                txtQ627.Focus()
                Return
            End If
        End If
        If txtQ639.Text <> "" Then
            If IsNumeric(txtQ639.Text) Then
                obj.Q639 = txtQ639.Text
            Else
                ShowWarning("Mode lỗi 639 phải nhập số !")
                txtQ639.Focus()
                Return
            End If
        End If
        If txtQOther.Text <> "" Then
            If IsNumeric(txtQOther.Text) Then
                obj.QOther = txtQOther.Text
            Else
                ShowWarning("Mode lỗi Other phải nhập số !")
                txtQOther.Focus()
                Return
            End If
        End If

        If txtM001.Text <> "" Then
            If IsNumeric(txtM001.Text) Then
                obj.M001 = txtM001.Text
            Else
                ShowWarning("Mode lỗi hàng loạt 001 phải nhập số !")
                txtM001.Focus()
                Return
            End If
        End If
        If txtM002.Text <> "" Then
            If IsNumeric(txtM002.Text) Then
                obj.M002 = txtM002.Text
            Else
                ShowWarning("Mode lỗi hàng loạt 002 phải nhập số !")
                txtM002.Focus()
                Return
            End If
        End If
        If txtM003.Text <> "" Then
            If IsNumeric(txtM003.Text) Then
                obj.M003 = txtM003.Text
            Else
                ShowWarning("Mode lỗi hàng loạt 003 phải nhập số !")
                txtM003.Focus()
                Return
            End If
        End If
        If txtM004.Text <> "" Then
            If IsNumeric(txtM004.Text) Then
                obj.M004 = txtM004.Text
            Else
                ShowWarning("Mode lỗi hàng loạt 004 phải nhập số !")
                txtM004.Focus()
                Return
            End If
        End If
        If txtM005.Text <> "" Then
            If IsNumeric(txtM005.Text) Then
                obj.M005 = txtM005.Text
            Else
                ShowWarning("Mode lỗi hàng loạt 005 phải nhập số !")
                txtM005.Focus()
                Return
            End If
        End If
        If txtM006.Text <> "" Then
            If IsNumeric(txtM006.Text) Then
                obj.M006 = txtM006.Text
            Else
                ShowWarning("Mode lỗi hàng loạt 006 phải nhập số !")
                txtM006.Focus()
                Return
            End If
        End If
        If txtM007.Text <> "" Then
            If IsNumeric(txtM007.Text) Then
                obj.M007 = txtM007.Text
            Else
                ShowWarning("Mode lỗi hàng loạt 007 phải nhập số !")
                txtM007.Focus()
                Return
            End If
        End If
        obj.ViTri = txtViTri.Text

        obj.Op = txtOp.Text
        If _db.ExistObject(obj) Then
            _db.Update(obj)
        Else
            _db.Insert(obj)
        End If

        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@ID", obj.ID_K)
        _db.ExecuteStoreProcedure("sp_KQQC_UpdateHead", para)
        mnuShowAll.PerformClick()

        Dim sql As String = String.Format("select * from KQQC_KQCV_Detail where ID='{0}'",
                                    obj.ID_K)
        Dim bdsource As New BindingSource
        bdsource.DataSource = _db.FillDataTable(sql)
        gridD.DataSource = bdsource

        AddNewDetail()
        txtGhiChu.Focus()
    End Sub

    Private Sub grid_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellClick
        If grid.CurrentRow IsNot Nothing Then
            Dim sql As String = String.Format("select * from KQQC_KQCV_Detail where ID='{0}'",
                                              grid.CurrentRow.Cells("ID").Value)
            Dim bdsource As New BindingSource
            bdsource.DataSource = _db.FillDataTable(sql)
            gridD.DataSource = bdsource

            txtID.Text = grid.CurrentRow.Cells("ID").Value
            txtPdCode.Text = grid.CurrentRow.Cells("ProductCode").Value
            txtLotNo.Text = grid.CurrentRow.Cells("LotNo").Value
            cboSoMay.Text = grid.CurrentRow.Cells("SoMay").Value
            cboSoLan.Text = grid.CurrentRow.Cells("SoLantest").Value
            txtQty.Text = grid.CurrentRow.Cells("QTy").Value
            cboPattan.Text = grid.CurrentRow.Cells("Pattan").Value
            cboPdCodeCheck.Text = grid.CurrentRow.Cells("ProductCheck").Value
            cboPhuongPhap.Text = grid.CurrentRow.Cells("PhuongPhap").Value
            txtXacNhan.Text = grid.CurrentRow.Cells("XacNhan").Value
            dtpDate.Value = grid.CurrentRow.Cells("Ngay").Value
            If grid.CurrentRow.Cells("GhiChu").Value IsNot DBNull.Value Then
                txtGhiChu.Text = grid.CurrentRow.Cells("GhiChu").Value
            Else
                txtGhiChu.Text = ""
            End If
        End If
    End Sub

    Private Sub txtViTri_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtViTri.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtID.Text <> "" Then
                SaveDetail()
            End If
        End If
    End Sub
    Function GetValueString(ByVal obj As Object) As Object
        Return IIf(obj Is DBNull.Value, "", obj)
    End Function
    Private Sub gridD_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellClick
        If gridD.CurrentRow IsNot Nothing Then
            AddNewDetail()
            txtSheet.Text = GetValueString(gridD.CurrentRow.Cells(Sheet.DataPropertyName).Value)
            txtStart.Text = CType(gridD.CurrentRow.Cells(BatDau.DataPropertyName).Value, DateTime).ToString("HH:mm")
            txtEnd.Text = CType(gridD.CurrentRow.Cells(KetThuc.DataPropertyName).Value, DateTime).ToString("HH:mm")

            txtV001.Text = GetValueString(gridD.CurrentRow.Cells(V001.DataPropertyName).Value)
            txtQ001.Text = GetValueString(gridD.CurrentRow.Cells(Q001.DataPropertyName).Value)

            txtV002.Text = GetValueString(gridD.CurrentRow.Cells(V002.DataPropertyName).Value)
            txtQ002.Text = GetValueString(gridD.CurrentRow.Cells(Q002.DataPropertyName).Value)

            txtV003.Text = GetValueString(gridD.CurrentRow.Cells(V003.DataPropertyName).Value)
            txtQ003.Text = GetValueString(gridD.CurrentRow.Cells(Q003.DataPropertyName).Value)

            txtV004.Text = GetValueString(gridD.CurrentRow.Cells(V004.DataPropertyName).Value)
            txtQ004.Text = GetValueString(gridD.CurrentRow.Cells(Q004.DataPropertyName).Value)

            txtV005.Text = GetValueString(gridD.CurrentRow.Cells(V005.DataPropertyName).Value)
            txtQ005.Text = GetValueString(gridD.CurrentRow.Cells(Q005.DataPropertyName).Value)

            txtV006.Text = GetValueString(gridD.CurrentRow.Cells(V006.DataPropertyName).Value)
            txtQ006.Text = GetValueString(gridD.CurrentRow.Cells(Q006.DataPropertyName).Value)

            txtV007.Text = GetValueString(gridD.CurrentRow.Cells(V007.DataPropertyName).Value)
            txtQ007.Text = GetValueString(gridD.CurrentRow.Cells(Q007.DataPropertyName).Value)

            txtV627.Text = GetValueString(gridD.CurrentRow.Cells(V627.DataPropertyName).Value)
            txtQ627.Text = GetValueString(gridD.CurrentRow.Cells(Q627.DataPropertyName).Value)

            txtV639.Text = GetValueString(gridD.CurrentRow.Cells(V639.DataPropertyName).Value)
            txtQ639.Text = GetValueString(gridD.CurrentRow.Cells(Q639.DataPropertyName).Value)

            txtVOther.Text = GetValueString(gridD.CurrentRow.Cells(VOther.DataPropertyName).Value)
            txtQOther.Text = GetValueString(gridD.CurrentRow.Cells(QOther.DataPropertyName).Value)

            txtM001.Text = GetValueString(gridD.CurrentRow.Cells(M001.DataPropertyName).Value)
            txtM002.Text = GetValueString(gridD.CurrentRow.Cells(M002.DataPropertyName).Value)

            txtM003.Text = GetValueString(gridD.CurrentRow.Cells(M003.DataPropertyName).Value)
            txtM004.Text = GetValueString(gridD.CurrentRow.Cells(M004.DataPropertyName).Value)

            txtM005.Text = GetValueString(gridD.CurrentRow.Cells(M005.DataPropertyName).Value)
            txtM006.Text = GetValueString(gridD.CurrentRow.Cells(M006.DataPropertyName).Value)

            txtM007.Text = GetValueString(gridD.CurrentRow.Cells(M007.DataPropertyName).Value)
            txtViTri.Text = GetValueString(gridD.CurrentRow.Cells(ViTri.DataPropertyName).Value)
            txtOp.Text = GetValueString(gridD.CurrentRow.Cells(Op.DataPropertyName).Value)

            txtID.Text = GetValueString(gridD.CurrentRow.Cells("IDD").Value)
        End If
    End Sub

    Private Sub mnuDelete_Click_1(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click
        If grid.CurrentRow IsNot Nothing Then
            If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
                Dim obj As New KQQC_KQCV
                obj.ID_K = grid.CurrentRow.Cells("ID").Value
                _db.Delete(obj)
                grid.Rows.Remove(grid.CurrentRow)
            End If
        End If
    End Sub

    Private Sub txtGhiChu_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtGhiChu.KeyDown
        If e.KeyCode = Keys.Enter Then
			mnuSave.PerformClick()
		End If
    End Sub

    Private Sub linkPP_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkPP.LinkClicked
        Dim frm As New FrmPhuongPhap
        frm.ShowDialog()
        LoadPhuongPhap()
    End Sub

	Private Sub Label35_Click(sender As Object, e As EventArgs) Handles Label35.Click

	End Sub
End Class