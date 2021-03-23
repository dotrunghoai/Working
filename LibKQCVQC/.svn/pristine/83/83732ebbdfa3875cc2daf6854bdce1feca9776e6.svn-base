Imports CommonDB
Imports LibEntity
Imports PublicUtility
Imports System.Windows.Forms

Public Class FrmKQCVNEW : Inherits DevExpress.XtraEditors.XtraForm

	Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Sub LoadPhuongPhap()
        Dim sql As String = String.Format("select ID,PhuongPhap from KQCV_PhuongPhap order by PhuongPhap")
        cboPhuongPhap.DataSource = _db.FillDataTable(sql)
		cboPhuongPhap.ValueMember = "ID"
		cboPhuongPhap.DisplayMember = "PhuongPhap"
	End Sub

	Sub AddNewHead()
		txtPdCode.Text = ""
		txtSoTo.Text = ""
		txtLotNo.Text = ""
		cboPattan.Text = ""
		cboPdCodeCheck.Text = ""
		cboQCEva.Text = ""
		cboMode.Text = ""
		cboSoLan.Text = ""
		cboSoMay.Text = ""
		txtQty.Text = ""
		cboPhuongPhap.Text = ""
		txtXacNhan.Text = ""
        txtGhiChu.Text = ""
        txtQuangLuong.Text = ""
        txtTocDoETC.Text = ""
        txtTyLe.Text = ""
        txtThoiGianKiem.Text = ""

        gridD.AllowUserToAddRows = False
		gridD.RowCount = 0
		gridD.AllowUserToAddRows = True

		txtPdCode.Focus()
		txtID.Text = ""
	End Sub

	Sub AddNewDetail()
		For Each c As Control In scont.Panel1.Controls
			If TypeOf c Is TextBox Then
				c.Text = ""
			End If
		Next
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

		If cboQCEva.Text.Trim = "" Then
			ShowWarning("Bạn chưa nhập kết quả kiểm QC!")
			cboQCEva.Focus()
			Return False
		End If

		If cboMode.Text.Trim = "" Then
			ShowWarning("Bạn chưa nhập kết quả kiểm Mode!")
			cboMode.Focus()
			Return False
		End If

		'For Each r As DataGridViewRow In gridD.Rows
		'	If r.IsNewRow Then
		'		Continue For
		'	End If
		'	If r.Cells(DefectCode.Name).Value Is Nothing Or r.Cells(Op.Name).Value Is DBNull.Value Then
		'		ShowWarning("Bạn chưa nhập Operator đầy đủ !")
		'		Return False
		'	End If
		'	'If r.Cells(Sheet.Name).Value Is Nothing Or r.Cells(Sheet.Name).Value Is DBNull.Value Then
		'	'	ShowWarning("Bạn chưa nhập Sheet đầy đủ !")
		'	'	Return False
		'	'End If
		'	'If r.Cells(BatDau.Name).Value Is Nothing Or r.Cells(BatDau.Name).Value Is DBNull.Value Then
		'	'	ShowWarning("Bạn chưa nhập BatDau đầy đủ !")
		'	'	Return False
		'	'End If
		'	'If r.Cells(KetThuc.Name).Value Is Nothing Or r.Cells(KetThuc.Name).Value Is DBNull.Value Then
		'	'	ShowWarning("Bạn chưa nhập KetThuc đầy đủ !")
		'	'	Return False
		'	'End If

		'Next
		Return True
	End Function

	Private Sub FrmKQCV_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
		mnuShowAll.PerformClick()
        bttDeleteData.Enabled = mnuSave.Enabled
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
	End Sub

	Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", dtpDate.Value.Date)
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dtpDate.Value.Date))
        Dim sql As String = String.Format("sp_KQQC_LoadKQQCNew")
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB(sql, para)
        GridControlSetFormat(GridView1, 3)
        GridControlSetWidth(GridView1, 50)
    End Sub

	Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        GridControlExportExcel(GridView1)
    End Sub

	Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuAdd.Click
		AddNewHead()
	End Sub

	Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click
		'Check Head
		If CheckHead() Then
			Try
				_db.BeginTransaction()

				Dim obj As New KQQC_KQCVNew
				obj.ID_K = txtID.Text
				_db.GetObject(obj)
				If obj.ID_K = "" Then
					obj.ID_K = Guid.NewGuid.ToString()
					txtID.Text = obj.ID_K
				End If
				obj.ProductCode = txtPdCode.Text.PadLeft(5, "0")
				obj.LotNo = txtLotNo.Text
				obj.SoTo = txtSoTo.Text
				obj.SoMay = cboSoMay.Text
				obj.SoLanTest = cboSoLan.Text
				obj.Qty = txtQty.Text
				obj.Pattan = cboPattan.Text
				obj.ProductCheck = cboPdCodeCheck.Text
				obj.ModeEvaluate = cboMode.Text
				obj.QCCheck = cboQCEva.Text
				obj.PhuongPhap = cboPhuongPhap.Text
				obj.XacNhan = txtXacNhan.Text
				obj.GhiChu = txtGhiChu.Text
                obj.Ngay = dtpDate.Value.Date
                If IsNumeric(txtQuangLuong.Text) Then
                    obj.QuangLuong = txtQuangLuong.Text
                Else
                    obj.QuangLuong = 0
                End If
                If IsNumeric(txtTocDoETC.Text) Then
                    obj.TocDoETC = txtTocDoETC.Text
                Else
                    obj.TocDoETC = 0
                End If

                obj.TyLeLoi = txtTyLe.Text
                If IsNumeric(txtThoiGianKiem.Text) Then
                    obj.ThoiGianKiem = txtThoiGianKiem.Text
                Else
                    obj.ThoiGianKiem = 0
                End If
                Dim objP As New WT_Product
				objP.ProductCode_K = obj.ProductCode
				_db.GetObject(objP)
				obj.Customer = objP.CustomerName
				obj.Method = objP.Method

				obj.CreateDate = DateTime.Now
				obj.CreateUser = CurrentUser.UserID
				If _db.ExistObject(obj) Then
					_db.Update(obj)
				Else
					_db.Insert(obj)
				End If
				txtID.Text = obj.ID_K
				SaveDetail()

				Dim para(0) As SqlClient.SqlParameter
				para(0) = New SqlClient.SqlParameter("@ID", obj.ID_K)
				_db.ExecuteStoreProcedure("[sp_KQQC_UpdateHead_New]", para)

				_db.Commit()
				mnuShowAll.PerformClick()
				scont.Focus()

			Catch ex As Exception
				_db.RollBack()
				ShowError(ex, "Save", Name)
			End Try
		End If
		'Check Detail
	End Sub
	Sub SaveDetail()
		_db.ExecuteNonQuery(String.Format("delete from KQQC_DetailNew where ID='{0}'", txtID.Text))
        'Dim SGio As Integer
        'Dim SPhut As Integer
        'Dim EGio As Integer
        'Dim EPhut As Integer

        For Each r As DataGridViewRow In gridD.Rows
			If r.IsNewRow = False Then
				Dim obj As New KQQC_DetailNew

                'If IsDate(r.Cells(BatDau.Name).Value) Then
                '	SGio = CType(r.Cells(BatDau.Name).Value, DateTime).Hour
                '	SPhut = CType(r.Cells(BatDau.Name).Value, DateTime).Minute
                '	obj.BatDau = New DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day, SGio, SPhut, 0)
                'Else
                '	SGio = 0
                '	SPhut = 0
                'End If
                'If IsDate(r.Cells(KetThuc.Name).Value) Then
                '	EGio = CType(r.Cells(KetThuc.Name).Value, DateTime).Hour
                '	EPhut = CType(r.Cells(KetThuc.Name).Value, DateTime).Minute
                '	obj.KetThuc = New DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day, EGio, EPhut, 0)
                '	If obj.KetThuc < obj.BatDau Then
                '		obj.KetThuc = obj.KetThuc.AddDays(1)
                '	End If
                'Else
                '	EGio = 0
                '	EPhut = 0
                'End If


                obj.ID_K = txtID.Text
				obj.STT_K = r.Index + 1
				If r.Cells(Sheet.Name).Value IsNot DBNull.Value Then
					obj.Sheet = r.Cells(Sheet.Name).Value
				End If
				If r.Cells(Op.Name).Value IsNot DBNull.Value Then
					obj.Op = r.Cells(Op.Name).Value
				End If

				If r.Cells(DefectCode.Name).Value IsNot DBNull.Value Then
					obj.DefectCode = r.Cells(DefectCode.Name).Value
				End If

				If r.Cells(DefectQty.Name).Value IsNot DBNull.Value Then
					obj.DefectQty = r.Cells(DefectQty.Name).Value
				End If
				If r.Cells(Vitri.Name).Value IsNot DBNull.Value Then
					obj.Vitri = r.Cells(Vitri.Name).Value
				End If
				If r.Cells(DefectCodeHL.Name).Value IsNot DBNull.Value Then
					obj.DefectCodeHL = r.Cells(DefectCodeHL.Name).Value
				End If
				If r.Cells(DefectQtyHL.Name).Value IsNot DBNull.Value Then
					obj.DefectQtyHL = r.Cells(DefectQtyHL.Name).Value
				End If
				If r.Cells(VitriHL.Name).Value IsNot DBNull.Value Then
					obj.VitriHL = r.Cells(VitriHL.Name).Value
				End If

                'If IsNumeric(r.Cells(ThoiGianKiem.Name).Value) Then
                '	obj.ThoiGianKiem = r.Cells(ThoiGianKiem.Name).Value
                'End If
                _db.Insert(obj)
			End If
		Next
	End Sub


    Private Sub grid_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub txtViTri_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If txtID.Text <> "" Then
                SaveDetail()
            End If
        End If
    End Sub

    Function GetValueString(ByVal obj As Object) As Object
        Return IIf(obj Is DBNull.Value, "", obj)
    End Function


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

	Private Sub bttDelete_Click(sender As Object, e As EventArgs) Handles bttDelete.Click
		If gridD.CurrentRow IsNot Nothing Then
			If Not gridD.CurrentRow.IsNewRow Then
				gridD.Rows.Remove(gridD.CurrentRow)
			End If
		End If
    End Sub


    Private Sub bttDeleteData_Click(sender As Object, e As EventArgs) Handles bttDeleteData.Click
        If GridView1.SelectedRowsCount > 0 Then
            If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
                Dim obj As New KQQC_KQCVNew
                obj.ID_K = GridView1.GetFocusedRowCellValue("ID")
                _db.Delete(obj)
                mnuShowAll.PerformClick()
            End If
        End If
    End Sub

    Private Sub GridView1_Click(sender As Object, e As EventArgs) Handles GridView1.Click
        If GridView1.SelectedRowsCount > 0 Then

            txtID.Text = GridView1.GetFocusedRowCellValue("ID")
            txtSoTo.Text = GridView1.GetFocusedRowCellValue("SoTo")
            txtPdCode.Text = GridView1.GetFocusedRowCellValue("ProductCode")
            txtLotNo.Text = GridView1.GetFocusedRowCellValue("LotNo")
            cboSoMay.Text = GridView1.GetFocusedRowCellValue("SoMay")
            cboSoLan.Text = GridView1.GetFocusedRowCellValue("SoLanTest")
			txtQty.Text = GridView1.GetFocusedRowCellValue("Qty")
			cboPattan.Text = GridView1.GetFocusedRowCellValue("Pattan")
			cboMode.Text = GridView1.GetFocusedRowCellValue("ModeEvaluate")
            cboQCEva.Text = GridView1.GetFocusedRowCellValue("QCCheck")
            cboPdCodeCheck.Text = GridView1.GetFocusedRowCellValue("ProductCheck")
            cboPhuongPhap.Text = GridView1.GetFocusedRowCellValue("PhuongPhap")
            txtXacNhan.Text = GridView1.GetFocusedRowCellValue("XacNhan")
            dtpDate.Value = GridView1.GetFocusedRowCellValue("Ngay")
            If GridView1.GetFocusedRowCellValue("GhiChu") IsNot DBNull.Value Then
                txtGhiChu.Text = GridView1.GetFocusedRowCellValue("GhiChu")
            Else
                txtGhiChu.Text = ""
            End If

            If GridView1.GetFocusedRowCellValue("QuangLuong") IsNot DBNull.Value Then
                txtQuangLuong.Text = GridView1.GetFocusedRowCellValue("QuangLuong")
            Else
                txtQuangLuong.Text = ""
            End If
            If GridView1.GetFocusedRowCellValue("TocDoETC") IsNot DBNull.Value Then
                txtTocDoETC.Text = GridView1.GetFocusedRowCellValue("TocDoETC")
            Else
                txtTocDoETC.Text = ""
            End If
			If GridView1.GetFocusedRowCellValue("TyLeLoi") IsNot DBNull.Value Then
				txtTyLe.Text = GridView1.GetFocusedRowCellValue("TyLeLoi")
			Else
				txtTyLe.Text = ""
            End If
            If GridView1.GetFocusedRowCellValue("ThoiGianKiem") IsNot DBNull.Value Then
                txtThoiGianKiem.Text = GridView1.GetFocusedRowCellValue("ThoiGianKiem")
            Else
                txtThoiGianKiem.Text = ""
            End If

            Dim sql As String = String.Format("select * from KQQC_DetailNew where ID='{0}'",
            GridView1.GetFocusedRowCellValue("ID"))

            Dim dtDetail As DataTable = _db.FillDataTable(sql)
            gridD.AllowUserToAddRows = False
            gridD.RowCount = 0
            gridD.RowCount = dtDetail.Rows.Count + 1
            gridD.AllowUserToAddRows = True
            Dim idx As Integer = 0
            For Each r As DataRow In dtDetail.Rows
                gridD.Rows(idx).Cells(IDD.Name).Value = r("ID")
                gridD.Rows(idx).Cells(STT.Name).Value = r("STT")
                gridD.Rows(idx).Cells(Sheet.Name).Value = r("Sheet")
                gridD.Rows(idx).Cells(Op.Name).Value = r("Op")
                'gridD.Rows(idx).Cells(BatDau.Name).Value = r("BatDau")
                'gridD.Rows(idx).Cells(KetThuc.Name).Value = r("KetThuc")
                'gridD.Rows(idx).Cells(ThoiGianKiem.Name).Value = r("ThoiGianKiem")

                If r("DefectCode") IsNot DBNull.Value Then
                    gridD.Rows(idx).Cells(DefectCode.Name).Value = r("DefectCode")
                Else
                    gridD.Rows(idx).Cells(DefectCode.Name).Value = ""
                End If
                If r("DefectQty") IsNot DBNull.Value Then
                    gridD.Rows(idx).Cells(DefectQty.Name).Value = r("DefectQty")
                Else
                    gridD.Rows(idx).Cells(DefectQty.Name).Value = DBNull.Value
                End If
                If r("Vitri") IsNot DBNull.Value Then
                    gridD.Rows(idx).Cells(Vitri.Name).Value = r("Vitri")
                End If

                If r("DefectCodeHL") IsNot DBNull.Value Then
                    gridD.Rows(idx).Cells(DefectCodeHL.Name).Value = r("DefectCodeHL")
                End If
                If r("DefectQtyHL") IsNot DBNull.Value Then
                    gridD.Rows(idx).Cells(DefectQtyHL.Name).Value = r("DefectQtyHL")
                End If
                If r("VitriHL") IsNot DBNull.Value Then
                    gridD.Rows(idx).Cells(VitriHL.Name).Value = r("VitriHL")
                End If
                idx += 1
            Next
        End If
    End Sub

End Class