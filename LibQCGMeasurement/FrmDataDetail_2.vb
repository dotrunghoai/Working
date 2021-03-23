Imports System.Drawing
Imports System.Windows.Forms
Imports CommonDB
Imports DevExpress
Imports DevExpress.XtraGrid.Views.Grid
Imports PublicUtility
Public Class FrmDataDetail_2
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Public _ProductCode As String = ""
    Public _CongDoan As String = ""
    Public _LotNo As String = ""
    Public _SoLantest As Integer = 0
    Private Sub FrmDataDetail_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _ProductCode = "" Or _CongDoan = "" Or _LotNo = "" Or _SoLantest = 0 Then
            dteNgayDo.EditValue = DateTime.Now
        Else
            txtProductCode.Text = _ProductCode
            lueCongDoan.Text = _CongDoan
            txtLotNo.Text = _LotNo
            txtSoLanTest.Text = _SoLantest
            btnShow.PerformClick()
        End If
    End Sub

    Private Sub txtProductCode_EditValueChanged(sender As Object, e As EventArgs) Handles txtProductCode.EditValueChanged
        Dim obj As New WT_Product
        obj.ProductCode_K = txtProductCode.Text
        _db.GetObject(obj)
        txtKhachHang.Text = obj.CustomerName
        txtMethod.Text = obj.Method

        lueCongDoan.Properties.DataSource = _db.FillDataTable(String.Format("select distinct Process " +
                                                   " from QCS_Define " +
                                                   " where ProductCode='{0}'", txtProductCode.Text))
        lueCongDoan.Properties.DisplayMember = "Process"
    End Sub

    Private Sub txtProductCode_Leave(sender As Object, e As EventArgs) Handles txtProductCode.Leave
        txtProductCode.Text = txtProductCode.Text.PadLeft(5, "0")
    End Sub

    Private Sub FrmDataDetail_2_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Right Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.Left Then
            SendKeys.Send("+{Tab}")
        ElseIf e.Control And e.KeyCode = Keys.S Then
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim views As GridView = TryCast(sender, GridView)
        If e.Column.FieldName = "KetQua" Then
            If views.GetRowCellDisplayText(e.RowHandle, views.Columns("KetQua")).ToString.ToUpper = "NG" Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "DanhGiaMC" Then
            If views.GetRowCellDisplayText(e.RowHandle, views.Columns("DanhGiaMC")).ToString.ToUpper = "NG" Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "D1" Then
            If views.GetRowCellValue(e.RowHandle, "D1") >= views.GetRowCellValue(e.RowHandle, "USL") Or
                views.GetRowCellValue(e.RowHandle, "D1") <= views.GetRowCellValue(e.RowHandle, "LSL") Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "D2" Then
            If views.GetRowCellValue(e.RowHandle, "D2") >= views.GetRowCellValue(e.RowHandle, "USL") Or
                views.GetRowCellValue(e.RowHandle, "D2") <= views.GetRowCellValue(e.RowHandle, "LSL") Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "D3" Then
            If views.GetRowCellValue(e.RowHandle, "D3") >= views.GetRowCellValue(e.RowHandle, "USL") Or
                views.GetRowCellValue(e.RowHandle, "D3") <= views.GetRowCellValue(e.RowHandle, "LSL") Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "D4" Then
            If views.GetRowCellValue(e.RowHandle, "D4") >= views.GetRowCellValue(e.RowHandle, "USL") Or
                views.GetRowCellValue(e.RowHandle, "D4") <= views.GetRowCellValue(e.RowHandle, "LSL") Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "D5" Then
            If views.GetRowCellValue(e.RowHandle, "D5") >= views.GetRowCellValue(e.RowHandle, "USL") Or
                views.GetRowCellValue(e.RowHandle, "D5") <= views.GetRowCellValue(e.RowHandle, "LSL") Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "D6" Then
            If views.GetRowCellValue(e.RowHandle, "D6") >= views.GetRowCellValue(e.RowHandle, "USL") Or
                views.GetRowCellValue(e.RowHandle, "D6") <= views.GetRowCellValue(e.RowHandle, "LSL") Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "D7" Then
            If views.GetRowCellValue(e.RowHandle, "D7") >= views.GetRowCellValue(e.RowHandle, "USL") Or
                views.GetRowCellValue(e.RowHandle, "D7") <= views.GetRowCellValue(e.RowHandle, "LSL") Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "D8" Then
            If views.GetRowCellValue(e.RowHandle, "D8") >= views.GetRowCellValue(e.RowHandle, "USL") Or
                views.GetRowCellValue(e.RowHandle, "D8") <= views.GetRowCellValue(e.RowHandle, "LSL") Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "D9" Then
            If views.GetRowCellValue(e.RowHandle, "D9") >= views.GetRowCellValue(e.RowHandle, "USL") Or
                views.GetRowCellValue(e.RowHandle, "D9") <= views.GetRowCellValue(e.RowHandle, "LSL") Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "D10" Then
            If views.GetRowCellValue(e.RowHandle, "D10") >= views.GetRowCellValue(e.RowHandle, "USL") Or
                views.GetRowCellValue(e.RowHandle, "D10") <= views.GetRowCellValue(e.RowHandle, "LSL") Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "D11" Then
            If views.GetRowCellValue(e.RowHandle, "D11") >= views.GetRowCellValue(e.RowHandle, "USL") Or
                views.GetRowCellValue(e.RowHandle, "D11") <= views.GetRowCellValue(e.RowHandle, "LSL") Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "D12" Then
            If views.GetRowCellValue(e.RowHandle, "D12") >= views.GetRowCellValue(e.RowHandle, "USL") Or
                views.GetRowCellValue(e.RowHandle, "D12") <= views.GetRowCellValue(e.RowHandle, "LSL") Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "Average" Then
            If views.GetRowCellValue(e.RowHandle, "Average") >= views.GetRowCellValue(e.RowHandle, "USL") Or
                views.GetRowCellValue(e.RowHandle, "Average") <= views.GetRowCellValue(e.RowHandle, "LSL") Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "Min" Then
            If views.GetRowCellValue(e.RowHandle, "Min") >= views.GetRowCellValue(e.RowHandle, "USL") Or
                views.GetRowCellValue(e.RowHandle, "Min") <= views.GetRowCellValue(e.RowHandle, "LSL") Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "Max" Then
            If views.GetRowCellValue(e.RowHandle, "Max") >= views.GetRowCellValue(e.RowHandle, "USL") Or
                views.GetRowCellValue(e.RowHandle, "Max") <= views.GetRowCellValue(e.RowHandle, "LSL") Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
        If e.Column.FieldName = "CPK" Then
            If views.GetRowCellValue(e.RowHandle, "CPKDefine") > 0 And views.GetRowCellValue(e.RowHandle, "CPKDefine") <= 1 Then
                If e.CellValue < 1 Then
                    e.Appearance.BackColor = Color.Red
                End If
            ElseIf views.GetRowCellValue(e.RowHandle, "CPKDefine") > 1 Then
                If e.CellValue < 1.33 Then
                    e.Appearance.BackColor = Color.Red
                End If
            End If
        End If
        If e.Column.FieldName = "CPM" Then
            If views.GetRowCellValue(e.RowHandle, "CPMDefine") > 0 Then
                If e.CellValue < 1 Then
                    e.Appearance.BackColor = Color.Red
                End If
            End If
        End If
    End Sub

    Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
        Dim objHead As New QCS_DataHead
        If txtProductCode.Text.Trim <> "" Then
            Dim objProduct As New WT_Product
            objProduct.ProductCode_K = txtProductCode.Text.Trim
            If _db.ExistObject(objProduct) Then
                objHead.ProductCode_K = txtProductCode.Text.Trim
            Else
                ShowWarning("Product Code không hợp lệ !")
                txtProductCode.Select()
                Return
            End If
        End If
        If lueCongDoan.Text.Trim <> "" Then
            objHead.Process_K = lueCongDoan.Text.Trim
        Else
            ShowWarning("Công đoạn không được bỏ trống !")
            lueCongDoan.Select()
            Return
        End If
        If txtLotNo.Text.Trim <> "" Then
            objHead.LotNo_K = txtLotNo.Text.Trim
        Else
            ShowWarning("Lot No không được bỏ trống !")
            txtLotNo.Select()
            Return
        End If
        If txtSoLanTest.Text.Trim <> "" Then
            If IsNumeric(txtSoLanTest.Text) Then
                objHead.SoLanTest_K = txtSoLanTest.Text.Trim
            Else
                ShowWarning("Số lần test không hợp lệ !")
                txtSoLanTest.Select()
                Return
            End If
        Else
            ShowWarning("Số lần test không được bỏ trống !")
            txtSoLanTest.Select()
            Return
        End If

        objHead.MayDo = cbbMayDo.Text
        objHead.SoMau = IIf(IsNumeric(txtSoMau.Text), txtSoMau.Text, 0)
        objHead.NgayDo = dteNgayDo.DateTime
        objHead.MSNV = txtMSNV.Text
        objHead.TGBatDau = tmeTGBatDau.Time
        objHead.TGKetThuc = tmeTGKetThuc.Time
        objHead.TocDo = txtTocDo.Text
        objHead.QuangLuong = txtQuangLuong.Text
        objHead.MayGiaCong = txtMayGiaCong.Text
        objHead.ApLuc = txtApLuc.Text
        objHead.MaPhim = txtMaPhim.Text
        objHead.DanhGiaSauCung = "OK"
        objHead.NoiDungKhongDat = ""

        If _db.ExistObject(objHead) Then
            _db.Update(objHead)
        Else
            _db.Insert(objHead)
        End If

        Dim dt As DataTable = ImportEXCEL(True)
        If dt.Rows.Count > 0 Then
            Dim objDetail As New QCS_DataDetail
            objDetail.ProductCode_K = txtProductCode.Text
            objDetail.Process_K = lueCongDoan.Text
            objDetail.LotNo_K = txtLotNo.Text
            objDetail.SoLanTest_K = txtSoLanTest.Text

            'Kiểm tra số lượng mẫu
            _db.GetObject(objHead)
            Dim demMau As Integer = 0
            For c = (dt.Columns.IndexOf("Item") + 1) To (dt.Columns.IndexOf("Average") - 1)
                demMau += 1
            Next
            If demMau > 12 Then
                ShowWarning("Số lượng mẫu vượt quá số lượng giới hạn !")
                Return
            End If
            objHead.SoMau = demMau
            '---------------------

            For r = 0 To dt.Rows.Count - 1
                If dt.Rows(r)("LotNo") = txtLotNo.Text Then
                    objDetail.Item_K = dt.Rows(r)("Item")
                    If dt.Columns(2).ColumnName = "D1" Then
                        objDetail.D1 = dt.Rows(r)("D1")
                    End If
                    If dt.Columns(3).ColumnName = "D2" Then
                        objDetail.D2 = dt.Rows(r)("D2")
                    End If
                    If dt.Columns(4).ColumnName = "D3" Then
                        objDetail.D3 = dt.Rows(r)("D3")
                    End If
                    If dt.Columns(5).ColumnName = "D4" Then
                        objDetail.D4 = dt.Rows(r)("D4")
                    End If
                    If dt.Columns(6).ColumnName = "D5" Then
                        objDetail.D5 = dt.Rows(r)("D5")
                    End If
                    If dt.Columns(7).ColumnName = "D6" Then
                        objDetail.D6 = dt.Rows(r)("D6")
                    End If
                    If dt.Columns(8).ColumnName = "D7" Then
                        objDetail.D7 = dt.Rows(r)("D7")
                    End If
                    If dt.Columns(9).ColumnName = "D8" Then
                        objDetail.D8 = dt.Rows(r)("D8")
                    End If
                    If dt.Columns(10).ColumnName = "D9" Then
                        objDetail.D9 = dt.Rows(r)("D9")
                    End If
                    If dt.Columns(11).ColumnName = "D10" Then
                        objDetail.D10 = dt.Rows(r)("D10")
                    End If
                    If dt.Columns(12).ColumnName = "D11" Then
                        objDetail.D11 = dt.Rows(r)("D11")
                    End If
                    If dt.Columns(13).ColumnName = "D12" Then
                        objDetail.D12 = dt.Rows(r)("D12")
                    End If

                    Dim arrD(12) As Decimal
                    arrD(0) = objDetail.D1
                    arrD(1) = objDetail.D2
                    arrD(2) = objDetail.D3
                    arrD(3) = objDetail.D4
                    arrD(4) = objDetail.D5
                    arrD(5) = objDetail.D6
                    arrD(6) = objDetail.D7
                    arrD(7) = objDetail.D8
                    arrD(8) = objDetail.D9
                    arrD(9) = objDetail.D10
                    arrD(10) = objDetail.D11
                    arrD(11) = objDetail.D12

                    Dim minValue As Decimal = arrD(0)
                    Dim maxValue As Decimal = arrD(0)
                    Dim totalValue As Decimal = arrD(0)
                    For indexArr = 1 To demMau - 1
                        totalValue += arrD(indexArr)
                        If arrD(indexArr) < minValue Then
                            minValue = arrD(indexArr)
                        End If
                        If arrD(indexArr) > maxValue Then
                            maxValue = arrD(indexArr)
                        End If
                    Next

                    objDetail.Min = minValue
                    objDetail.Max = maxValue
                    objDetail.Average = totalValue / demMau

                    'STDEV
                    Dim totalMatrix As Decimal = 0
                    Dim matrix As Decimal = 0
                    For indexArr = 0 To demMau - 1
                        totalMatrix += Math.Pow((arrD(indexArr) - objDetail.Average), 2)
                    Next
                    matrix = totalMatrix / (demMau - 1)
                    objDetail.Stdev = Math.Sqrt(totalMatrix / (demMau - 1))
                    '------------------

                    If _db.ExistObject(objDetail) Then
                        _db.Update(objDetail)
                    Else
                        _db.Insert(objDetail)
                    End If
                End If
            Next

            Dim para(3) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@ProductCode", txtProductCode.Text)
            para(1) = New SqlClient.SqlParameter("@Process", lueCongDoan.Text)
            para(2) = New SqlClient.SqlParameter("@LotNo", txtLotNo.Text)
            para(3) = New SqlClient.SqlParameter("@SoLanTest", txtSoLanTest.Text)
            Dim dtDetail As DataTable = _db.ExecuteStoreProcedureTB("sp_QCS_LoadHeadDetail", para)
            For c = objHead.SoMau + 2 To 13
                dtDetail.Columns.RemoveAt(objHead.SoMau + 2)
            Next

            Dim isKetQua As Boolean = True
            Dim isDanhGiaMC As Boolean = True
            Dim isCPK As Boolean = True
            Dim isCPM As Boolean = True
            For r = 0 To dtDetail.Rows.Count - 1
                objDetail.Item_K = dtDetail.Rows(r)("Item")
                _db.GetObject(objDetail)
                For c = dtDetail.Columns.IndexOf("D1") To dtDetail.Columns.IndexOf("Max")
                    If dtDetail.Rows(r)(c) <= dtDetail.Rows(r)("USL") And dtDetail.Rows(r)(c) >= dtDetail.Rows(r)("LSL") Then
                        objDetail.KetQua = "OK"
                    Else
                        objDetail.KetQua = "NG"
                        objHead.DanhGiaSauCung = "NG"
                        isKetQua = False
                        'objHead.NoiDungKhongDat = "Kết quả không đạt" + Environment.NewLine
                        '_db.Update(objHead)
                        '_db.GetObject(objHead)
                        Exit For
                    End If
                Next
                If dtDetail.Rows(r)("Average") <= dtDetail.Rows(r)("UMC") And dtDetail.Rows(r)("Average") >= dtDetail.Rows(r)("LMC") Then
                    objDetail.DanhGiaMC = "OK"
                Else
                    objDetail.DanhGiaMC = "NG"
                    objHead.DanhGiaSauCung = "NG"
                    isDanhGiaMC = False
                    'objHead.NoiDungKhongDat = objHead.NoiDungKhongDat + "Đánh giá MC không đạt" + Environment.NewLine
                    '_db.Update(objHead)
                    '_db.GetObject(objHead)
                End If

                'Cpk
                Dim value1 As Decimal = (dtDetail.Rows(r)("USL") - objDetail.Average) / (3 * objDetail.Stdev)
                Dim value2 As Decimal = (objDetail.Average - dtDetail.Rows(r)("LSL")) / (3 * objDetail.Stdev)
                objDetail.CPK = Math.Min(value1, value2)
                'Cpm
                Dim valueMau As Decimal = demMau * Math.Sqrt(Math.Pow(objDetail.Stdev, 2) + Math.Pow((objDetail.Average - objDetail.Spec), 2))
                objDetail.CPM = (dtDetail.Rows(r)("USL") - dtDetail.Rows(r)("LSL")) / valueMau
                '--------------
                'Đánh giá sau cùng CPK - CPM
                If dtDetail.Rows(r)("CPKDefine") > 0 And dtDetail.Rows(r)("CPKDefine") <= 1 Then
                    If dtDetail.Rows(r)("CPK") < 1 Then
                        objHead.DanhGiaSauCung = "NG"
                        isCPK = False
                        'objHead.NoiDungKhongDat = objHead.NoiDungKhongDat + "CPK không đạt" + Environment.NewLine
                        '_db.Update(objHead)
                        '_db.GetObject(objHead)
                    End If
                ElseIf dtDetail.Rows(r)("CPKDefine") > 1 Then
                    If dtDetail.Rows(r)("CPK") < 1.33 Then
                        objHead.DanhGiaSauCung = "NG"
                        isCPK = False
                        'objHead.NoiDungKhongDat = objHead.NoiDungKhongDat + "CPK không đạt" + Environment.NewLine
                        '_db.Update(objHead)
                        '_db.GetObject(objHead)
                    End If
                End If
                If dtDetail.Rows(r)("CPMDefine") > 0 Then
                    If dtDetail.Rows(r)("CPM") < 1 Then
                        objHead.DanhGiaSauCung = "NG"
                        isCPM = False
                        'objHead.NoiDungKhongDat = objHead.NoiDungKhongDat + "CPM không đạt"
                        '_db.Update(objHead)
                        '_db.GetObject(objHead)
                    End If
                End If
                '---------------------------

                _db.Update(objDetail)
            Next

            If isKetQua = False Then
                objHead.NoiDungKhongDat = "Kết quả không đạt" + Environment.NewLine
                _db.Update(objHead)
                _db.GetObject(objHead)
            End If
            If isDanhGiaMC = False Then
                objHead.NoiDungKhongDat = objHead.NoiDungKhongDat + "Đánh giá MC không đạt" + Environment.NewLine
                _db.Update(objHead)
                _db.GetObject(objHead)
            End If
            If isCPK = False Then
                objHead.NoiDungKhongDat = objHead.NoiDungKhongDat + "CPK không đạt" + Environment.NewLine
                _db.Update(objHead)
                _db.GetObject(objHead)
            End If
            If isCPM = False Then
                objHead.NoiDungKhongDat = objHead.NoiDungKhongDat + "CPM không đạt"
                _db.Update(objHead)
                _db.GetObject(objHead)
            End If
            _db.Update(objHead)
        Else
            ShowWarning("File Excel không có dữ liệu !")
            Return
        End If
        btnShow.PerformClick()
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim objHead As New QCS_DataHead
        objHead.ProductCode_K = txtProductCode.Text
        objHead.Process_K = lueCongDoan.Text
        objHead.LotNo_K = txtLotNo.Text
        If IsNumeric(txtSoLanTest.Text) Then
            objHead.SoLanTest_K = txtSoLanTest.Text
        Else
            ShowWarning("Số lần test không hợp lệ !")
            txtSoLanTest.Select()
            Return
        End If

        If Not _db.ExistObject(objHead) Then
            ShowWarning("Không có dữ liệu")
            Return
        End If
        _db.GetObject(objHead)
        cbbMayDo.Text = objHead.MayDo
        txtSoMau.Text = objHead.SoMau
        dteNgayDo.EditValue = objHead.NgayDo
        txtMSNV.Text = objHead.MSNV
        tmeTGBatDau.Time = objHead.TGBatDau
        tmeTGKetThuc.Time = objHead.TGKetThuc
        txtTocDo.Text = objHead.TocDo
        txtQuangLuong.Text = objHead.QuangLuong
        txtMayGiaCong.Text = objHead.MayGiaCong
        txtApLuc.Text = objHead.ApLuc
        txtMaPhim.Text = objHead.MaPhim
        If objHead.DanhGiaSauCung = "OK" Then
            lblDanhGiaSauCung.Text = "OK"
            lblDanhGiaSauCung.BackColor = Color.LawnGreen
        Else
            lblDanhGiaSauCung.Text = "NG"
            lblDanhGiaSauCung.BackColor = Color.Red
        End If
        mmeNoiDungKhongDat.Text = objHead.NoiDungKhongDat

        Dim para(3) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@ProductCode", txtProductCode.Text)
        para(1) = New SqlClient.SqlParameter("@Process", lueCongDoan.Text)
        para(2) = New SqlClient.SqlParameter("@LotNo", txtLotNo.Text)
        para(3) = New SqlClient.SqlParameter("@SoLanTest", txtSoLanTest.Text)

        Dim dt As DataTable = _db.ExecuteStoreProcedureTB("sp_QCS_LoadHeadDetail", para)
        For c = objHead.SoMau + 2 To 13
            dt.Columns.RemoveAt(objHead.SoMau + 2)
        Next

        GridView1.Columns.Clear()
        GridControl1.DataSource = dt
        GridControlSetWidth(GridView1, 60)
        GridControlSetWidth(GridView1, "DanhGiaMC", 75)
        GridControlSetWidth(GridView1, "CPKDefine", 75)
        GridControlSetWidth(GridView1, "CPMDefine", 75)
        GridView1.OptionsBehavior.Editable = False
        GridView1.OptionsSelection.MultiSelect = True
        GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect
        GridView1.OptionsSelection.EnableAppearanceHotTrackedRow = Utils.DefaultBoolean.True
        GridView1.GridControl.UseEmbeddedNavigator = True

        GridControlSetFormatNumber(GridView1, "Average", 4)
        GridControlSetFormatNumber(GridView1, "Spec", 3)
        GridControlSetFormatNumber(GridView1, "USL", 3)
        GridControlSetFormatNumber(GridView1, "UMC", 3)
        GridControlSetFormatNumber(GridView1, "LMC", 3)
    End Sub

    Private Sub btnSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSave.ItemClick
        Dim objHead As New QCS_DataHead
        If txtProductCode.Text.Trim <> "" Then
            Dim objProduct As New WT_Product
            objProduct.ProductCode_K = txtProductCode.Text.Trim
            If _db.ExistObject(objProduct) Then
                objHead.ProductCode_K = txtProductCode.Text.Trim
            Else
                ShowWarning("Product Code không hợp lệ !")
                txtProductCode.Select()
                Return
            End If
        End If
        If lueCongDoan.Text.Trim <> "" Then
            objHead.Process_K = lueCongDoan.Text.Trim
        Else
            ShowWarning("Công đoạn không được bỏ trống !")
            lueCongDoan.Select()
            Return
        End If
        If txtLotNo.Text.Trim <> "" Then
            objHead.LotNo_K = txtLotNo.Text.Trim
        Else
            ShowWarning("Lot No không được bỏ trống !")
            txtLotNo.Select()
            Return
        End If
        If txtSoLanTest.Text.Trim <> "" Then
            If IsNumeric(txtSoLanTest.Text) Then
                objHead.SoLanTest_K = txtSoLanTest.Text.Trim
            Else
                ShowWarning("Số lần test không hợp lệ !")
                txtSoLanTest.Select()
                Return
            End If
        Else
            ShowWarning("Số lần test không được bỏ trống !")
            txtSoLanTest.Select()
            Return
        End If

        objHead.MayDo = cbbMayDo.Text
        objHead.SoMau = txtSoMau.Text
        objHead.NgayDo = dteNgayDo.DateTime
        objHead.MSNV = txtMSNV.Text
        objHead.TGBatDau = tmeTGBatDau.Time
        objHead.TGKetThuc = tmeTGKetThuc.Time
        objHead.TocDo = txtTocDo.Text
        objHead.QuangLuong = txtQuangLuong.Text
        objHead.MayGiaCong = txtMayGiaCong.Text
        objHead.ApLuc = txtApLuc.Text
        objHead.MaPhim = txtMaPhim.Text
        objHead.DanhGiaSauCung = lblDanhGiaSauCung.Text
        objHead.NoiDungKhongDat = mmeNoiDungKhongDat.Text

        If _db.ExistObject(objHead) Then
            _db.Update(objHead)
        Else
            _db.Insert(objHead)

            If GridView1.RowCount > 0 Then
                Dim objDetail As New QCS_DataDetail
                objDetail.ProductCode_K = txtProductCode.Text
                objDetail.Process_K = lueCongDoan.Text
                objDetail.LotNo_K = txtLotNo.Text
                objDetail.SoLanTest_K = txtSoLanTest.Text

                For r = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(r, "LotNo") = txtLotNo.Text Then
                        objDetail.Item_K = GridView1.GetRowCellValue(r, "Item")
                        If GridView1.Columns(2).FieldName = "D1" Then
                            objDetail.D1 = GridView1.GetRowCellValue(r, "D1")
                        End If
                        If GridView1.Columns(3).FieldName = "D2" Then
                            objDetail.D2 = GridView1.GetRowCellValue(r, "D2")
                        End If
                        If GridView1.Columns(4).FieldName = "D3" Then
                            objDetail.D3 = GridView1.GetRowCellValue(r, "D3")
                        End If
                        If GridView1.Columns(5).FieldName = "D4" Then
                            objDetail.D4 = GridView1.GetRowCellValue(r, "D4")
                        End If
                        If GridView1.Columns(6).FieldName = "D5" Then
                            objDetail.D5 = GridView1.GetRowCellValue(r, "D5")
                        End If
                        If GridView1.Columns(7).FieldName = "D6" Then
                            objDetail.D6 = GridView1.GetRowCellValue(r, "D6")
                        End If
                        If GridView1.Columns(8).FieldName = "D7" Then
                            objDetail.D7 = GridView1.GetRowCellValue(r, "D7")
                        End If
                        If GridView1.Columns(9).FieldName = "D8" Then
                            objDetail.D8 = GridView1.GetRowCellValue(r, "D8")
                        End If
                        If GridView1.Columns(10).FieldName = "D9" Then
                            objDetail.D9 = GridView1.GetRowCellValue(r, "D9")
                        End If
                        If GridView1.Columns(11).FieldName = "D10" Then
                            objDetail.D10 = GridView1.GetRowCellValue(r, "D10")
                        End If
                        If GridView1.Columns(12).FieldName = "D11" Then
                            objDetail.D11 = GridView1.GetRowCellValue(r, "D11")
                        End If
                        If GridView1.Columns(13).FieldName = "D12" Then
                            objDetail.D12 = GridView1.GetRowCellValue(r, "D12")
                        End If
                        objDetail.Min = GridView1.GetRowCellValue(r, "Min")
                        objDetail.Max = GridView1.GetRowCellValue(r, "Max")
                        objDetail.Average = GridView1.GetRowCellValue(r, "Average")
                        objDetail.Stdev = GridView1.GetRowCellValue(r, "Stdev")
                        objDetail.KetQua = GridView1.GetRowCellValue(r, "KetQua")
                        objDetail.DanhGiaMC = GridView1.GetRowCellValue(r, "DanhGiaMC")
                        objDetail.CPK = GridView1.GetRowCellValue(r, "CPK")
                        objDetail.CPM = GridView1.GetRowCellValue(r, "CPM")

                        _db.Insert(objDetail)
                    End If
                Next

            End If
        End If
    End Sub
    Sub ResetControl()
        txtProductCode.Text = ""
        txtKhachHang.Text = ""
        txtMethod.Text = ""
        lueCongDoan.Text = ""
        cbbMayDo.Text = ""
        txtSoMau.Text = ""
        txtLotNo.Text = ""
        txtMSNV.Text = ""
        txtTocDo.Text = ""
        txtQuangLuong.Text = ""
        txtMayGiaCong.Text = ""
        txtApLuc.Text = ""
        txtMaPhim.Text = ""
        mmeNoiDungKhongDat.Text = ""
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridControlReadOnly(GridView1, True)
        If IsNumeric(txtSoMau.Text) And GridView1.RowCount > 0 Then
            For c = 2 To GridView1.Columns("Average").VisibleIndex - 1
                GridView1.Columns(c).OptionsColumn.ReadOnly = False
            Next
            GridControlSetColorEdit(GridView1)
        End If
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If GridView1.RowCount > 0 Then
            If ShowQuestion("Bạn có chắc muốn xóa Item: " + GridView1.GetFocusedRowCellValue("Item")) = DialogResult.Yes Then
                Dim para(4) As SqlClient.SqlParameter
                para(0) = New SqlClient.SqlParameter("@ProductCode", txtProductCode.Text)
                para(1) = New SqlClient.SqlParameter("@Process", lueCongDoan.Text)
                para(2) = New SqlClient.SqlParameter("@LotNo", txtLotNo.Text)
                para(3) = New SqlClient.SqlParameter("@SoLanTest", txtSoLanTest.Text)
                para(4) = New SqlClient.SqlParameter("@Item", GridView1.GetFocusedRowCellValue("Item"))
                _db.ExecuteNonQuery("delete QCS_DataDetail where ProductCode = @ProductCode and Process = @Process and LotNo = @LotNo and SoLanTest = @SoLanTest and Item = @Item", para)
                GridView1.DeleteSelectedRows()
            End If
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable = True And e.Column.ReadOnly = False Then
            Dim para(5) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            para(1) = New SqlClient.SqlParameter("@ProductCode", txtProductCode.Text)
            para(2) = New SqlClient.SqlParameter("@Process", lueCongDoan.Text)
            para(3) = New SqlClient.SqlParameter("@LotNo", txtLotNo.Text)
            para(4) = New SqlClient.SqlParameter("@SoLanTest", txtSoLanTest.Text)
            para(5) = New SqlClient.SqlParameter("@Item", GridView1.GetFocusedRowCellValue("Item"))
            _db.ExecuteNonQuery(String.Format("update QCS_DataDetail set {0} = @Value where ProductCode = @ProductCode and Process = @Process and LotNo = @LotNo and SoLanTest = @SoLanTest and Item = @Item", e.Column.FieldName), para)

            '-----------------
            Dim objDetail As New QCS_DataDetail
            objDetail.ProductCode_K = txtProductCode.Text
            objDetail.Process_K = lueCongDoan.Text
            objDetail.LotNo_K = txtLotNo.Text
            objDetail.SoLanTest_K = txtSoLanTest.Text

            Dim objHead As New QCS_DataHead
            objHead.ProductCode_K = txtProductCode.Text
            objHead.Process_K = lueCongDoan.Text
            objHead.LotNo_K = txtLotNo.Text
            objHead.SoLanTest_K = txtSoLanTest.Text
            _db.GetObject(objHead)

            Dim paraDetail(3) As SqlClient.SqlParameter
            paraDetail(0) = New SqlClient.SqlParameter("@ProductCode", txtProductCode.Text)
            paraDetail(1) = New SqlClient.SqlParameter("@Process", lueCongDoan.Text)
            paraDetail(2) = New SqlClient.SqlParameter("@LotNo", txtLotNo.Text)
            paraDetail(3) = New SqlClient.SqlParameter("@SoLanTest", txtSoLanTest.Text)
            Dim dtDetail As DataTable = _db.ExecuteStoreProcedureTB("sp_QCS_LoadHeadDetail", paraDetail)

            For r = 0 To dtDetail.Rows.Count - 1
                objDetail.Item_K = dtDetail.Rows(r)("Item")
                _db.GetObject(objDetail)

                Dim arrD(12) As Decimal
                arrD(0) = objDetail.D1
                arrD(1) = objDetail.D2
                arrD(2) = objDetail.D3
                arrD(3) = objDetail.D4
                arrD(4) = objDetail.D5
                arrD(5) = objDetail.D6
                arrD(6) = objDetail.D7
                arrD(7) = objDetail.D8
                arrD(8) = objDetail.D9
                arrD(9) = objDetail.D10
                arrD(10) = objDetail.D11
                arrD(11) = objDetail.D12

                Dim minValue As Decimal = arrD(0)
                Dim maxValue As Decimal = arrD(0)
                Dim totalValue As Decimal = arrD(0)
                For indexArr = 1 To txtSoMau.Text - 1
                    totalValue += arrD(indexArr)
                    If arrD(indexArr) < minValue Then
                        minValue = arrD(indexArr)
                    End If
                    If arrD(indexArr) > maxValue Then
                        maxValue = arrD(indexArr)
                    End If
                Next

                objDetail.Min = minValue
                objDetail.Max = maxValue
                objDetail.Average = totalValue / txtSoMau.Text

                'STDEV
                Dim totalMatrix As Decimal = 0
                Dim matrix As Decimal = 0
                For indexArr = 0 To txtSoMau.Text - 1
                    totalMatrix += Math.Pow((arrD(indexArr) - objDetail.Average), 2)
                Next
                matrix = totalMatrix / (txtSoMau.Text - 1)
                objDetail.Stdev = Math.Sqrt(totalMatrix / (txtSoMau.Text - 1))
                '------------------

                _db.Update(objDetail)
            Next

            For c = Integer.Parse(txtSoMau.Text) + 2 To 13
                dtDetail.Columns.RemoveAt(Integer.Parse(txtSoMau.Text) + 2)
            Next

            Dim isKetQua As Boolean = True
            Dim isDanhGiaMC As Boolean = True
            Dim isCPK As Boolean = True
            Dim isCPM As Boolean = True
            For r = 0 To dtDetail.Rows.Count - 1
                objDetail.Item_K = dtDetail.Rows(r)("Item")
                _db.GetObject(objDetail)

                For c = dtDetail.Columns.IndexOf("D1") To dtDetail.Columns.IndexOf("Max")
                    If dtDetail.Rows(r)(c) <= dtDetail.Rows(r)("USL") And dtDetail.Rows(r)(c) >= dtDetail.Rows(r)("LSL") Then
                        objDetail.KetQua = "OK"
                    Else
                        objDetail.KetQua = "NG"
                        objHead.DanhGiaSauCung = "NG"
                        isKetQua = False
                        Exit For
                    End If
                Next
                If dtDetail.Rows(r)("Average") <= dtDetail.Rows(r)("UMC") And dtDetail.Rows(r)("Average") >= dtDetail.Rows(r)("LMC") Then
                    objDetail.DanhGiaMC = "OK"
                Else
                    objDetail.DanhGiaMC = "NG"
                    objHead.DanhGiaSauCung = "NG"
                    isDanhGiaMC = False
                End If

                'Cpk
                Dim value1 As Decimal = (dtDetail.Rows(r)("USL") - objDetail.Average) / (3 * objDetail.Stdev)
                Dim value2 As Decimal = (objDetail.Average - dtDetail.Rows(r)("LSL")) / (3 * objDetail.Stdev)
                objDetail.CPK = Math.Min(value1, value2)
                'Cpm
                Dim valueMau As Decimal = txtSoMau.Text * Math.Sqrt(Math.Pow(objDetail.Stdev, 2) + Math.Pow((objDetail.Average - objDetail.Spec), 2))
                objDetail.CPM = (dtDetail.Rows(r)("USL") - dtDetail.Rows(r)("LSL")) / valueMau
                '--------------
                'Đánh giá sau cùng CPK - CPM
                If dtDetail.Rows(r)("CPKDefine") > 0 And dtDetail.Rows(r)("CPKDefine") <= 1 Then
                    If dtDetail.Rows(r)("CPK") < 1 Then
                        objHead.DanhGiaSauCung = "NG"
                        isCPK = False
                    End If
                ElseIf dtDetail.Rows(r)("CPKDefine") > 1 Then
                    If dtDetail.Rows(r)("CPK") < 1.33 Then
                        objHead.DanhGiaSauCung = "NG"
                        isCPK = False
                    End If
                End If
                If dtDetail.Rows(r)("CPMDefine") > 0 Then
                    If dtDetail.Rows(r)("CPM") < 1 Then
                        objHead.DanhGiaSauCung = "NG"
                        isCPM = False
                    End If
                End If
                '---------------------------

                _db.Update(objDetail)
            Next

            If isKetQua = False Then
                objHead.NoiDungKhongDat = "Kết quả không đạt" + Environment.NewLine
                _db.Update(objHead)
                _db.GetObject(objHead)
            End If
            If isDanhGiaMC = False Then
                objHead.NoiDungKhongDat = objHead.NoiDungKhongDat + "Đánh giá MC không đạt" + Environment.NewLine
                _db.Update(objHead)
                _db.GetObject(objHead)
            End If
            If isCPK = False Then
                objHead.NoiDungKhongDat = objHead.NoiDungKhongDat + "CPK không đạt" + Environment.NewLine
                _db.Update(objHead)
                _db.GetObject(objHead)
            End If
            If isCPM = False Then
                objHead.NoiDungKhongDat = objHead.NoiDungKhongDat + "CPM không đạt"
                _db.Update(objHead)
                _db.GetObject(objHead)
            End If
            _db.Update(objHead)

            btnShow.PerformClick()
            If IsNumeric(txtSoMau.Text) And GridView1.RowCount > 0 Then
                GridControlReadOnly(GridView1, True)
                For c = 2 To GridView1.Columns("Average").VisibleIndex - 1
                    GridView1.Columns(c).OptionsColumn.ReadOnly = False
                Next
                GridControlSetColorEdit(GridView1)
            End If
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        If GridView1.RowCount > 0 Then
            GridControlExportExcel(GridView1)
        End If
    End Sub

    Private Sub btnChart_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnChart.ItemClick
        If GridView1.RowCount > 0 Then
            Dim frm As New FrmCharts_2
            Dim dt As DataTable = GridControl1.DataSource
            Dim dtCopy As DataTable = dt.Copy
            dtCopy.Columns.Add("TrungBinhTruSpec")
            dtCopy.Columns.Add("MaxTruMin")
            For r = 0 To dtCopy.Rows.Count - 1
                dtCopy.Rows(r)("TrungBinhTruSpec") = dtCopy.Rows(r)("Average") - dtCopy.Rows(r)("Spec")
                dtCopy.Rows(r)("MaxTruMin") = dtCopy.Rows(r)("Max") - dtCopy.Rows(r)("Min")
            Next
            frm._tb = dtCopy
            frm._title = "BIỂU ĐỒ THEO DÕI BIẾN ĐỘNG DỮ LIỆU ĐO (" + txtProductCode.Text + " - " + lueCongDoan.Text + " - " + txtLotNo.Text + ")"
            frm._NgayDo = dteNgayDo.DateTime
            frm._ProductCode = txtProductCode.Text
            frm._CongDoan = lueCongDoan.Text
            frm._LotNo = txtLotNo.Text
            frm.Chart()
            frm.Show()
        End If
    End Sub
End Class