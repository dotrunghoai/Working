Imports PublicUtility
Imports CommonDB
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Columns

Public Class FrmNgoaiQuan
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _idGlobal As String = ""

    Function CreateID() As String
        Dim val As Object = _db.ExecuteScalar(String.Format("SELECT Right(MAX(ID), 4)
                                                             FROM KQQC_NgoaiQuan
                                                             WHERE ID LIKE '{0}%'",
                                                             Date.Now.ToString("yyMMdd")))
        If Not IsDBNull(val) Then
            val = (Integer.Parse(val) + 1).ToString.PadLeft(4, "0")
            Return Date.Now.ToString("yyMMdd") + val
        Else
            Return Date.Now.ToString("yyMMdd") + "0001"
        End If
    End Function
    Private Sub FrmNgoaiQuan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteNgay.DateTime = DateTime.Now
        Dim dtMethod As DataTable = _db.FillDataTable("SELECT PhuongPhap 
                                                       FROM KQCV_PhuongPhap 
                                                       ORDER BY PhuongPhap")
        For Each r As DataRow In dtMethod.Rows
            cbbPhuongPhap.Properties.Items.Add(r("PhuongPhap"))
        Next
        cbbPhuongPhap.SelectedIndex = 0
        btnNew.PerformClick()

        Dim obj As New Main_UserRight
        obj.FormID_K = Tag
        obj.UserID_K = CurrentUser.UserID
        _db.GetObject(obj)
        If obj.IsEdit = False Then
            ViewAccess()
        End If
    End Sub
    Private Sub teMSSP_Leave(sender As Object, e As EventArgs) Handles teMSSP.Leave
        teMSSP.Text = teMSSP.Text.PadLeft(5, "0")
    End Sub
    Private Sub meGhiChu_Leave(sender As Object, e As EventArgs) Handles meGhiChu.Leave
        btnSave2.PerformClick()
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView2)
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        _idGlobal = ""
        teID.Text = ""
        teSTT.Text = 0
        teMSSP.Text = ""
        teLot.Text = ""
        teCongDoan.Text = "PHOTO-ETC"
        teSoLanTest.Text = 0
        teSoLuongKiem.Text = 0
        teSoLuongLoi.Text = 0
        teTyLe.Text = 0
        teDanhGiaLoiNgoaiQuan.Text = ""
        teDanhGiaKichThuocDuongMach.Text = ""
        teDanhGiaLoHang.Text = ""
        teSoMayRoi.Text = ""
        teQuangLuong.Text = ""
        teTocDo.Text = 0
        teApLuc.Text = ""

        GridControl1.DataSource = ErrorDataTable()
        GridControlSetFormat(GridView1, 0)
        GridControlReadOnly(GridView1, False)
        GridView1.Columns("SoTam").OptionsColumn.ReadOnly = True
        GridControlSetColorEdit(GridView1)

        dteNgay.Select()
    End Sub

    Private Sub teSoLuongKiem_EditValueChanged(sender As Object, e As EventArgs) Handles teSoLuongKiem.EditValueChanged
        If IsNumeric(teSoLuongLoi.Text) And IsNumeric(teSoLuongKiem.Text) Then
            If teSoLuongKiem.Text <> 0 Then
                teTyLe.Text = (Decimal.Parse(teSoLuongLoi.Text) / Decimal.Parse(teSoLuongKiem.Text)) * 100
                Return
            End If
        End If
        teTyLe.Text = 0
    End Sub

    Private Sub teSoLuongLoi_EditValueChanged(sender As Object, e As EventArgs) Handles teSoLuongLoi.EditValueChanged
        If IsNumeric(teSoLuongLoi.Text) And IsNumeric(teSoLuongKiem.Text) Then
            If teSoLuongKiem.Text <> 0 Then
                teTyLe.Text = (Decimal.Parse(teSoLuongLoi.Text) / Decimal.Parse(teSoLuongKiem.Text)) * 100
                Return
            End If
        End If
        teTyLe.Text = 0
    End Sub

    Private Sub teDanhGiaLoiNgoaiQuan_EditValueChanged(sender As Object, e As EventArgs) Handles teDanhGiaLoiNgoaiQuan.EditValueChanged
        If teDanhGiaLoiNgoaiQuan.Text.ToUpper = "OK" And teDanhGiaKichThuocDuongMach.Text.ToUpper = "OK" Then
            teDanhGiaLoHang.Text = "OK"
        Else
            teDanhGiaLoHang.Text = "NG"
        End If
    End Sub

    Private Sub teDanhGiaKichThuocDuongMach_EditValueChanged(sender As Object, e As EventArgs) Handles teDanhGiaKichThuocDuongMach.EditValueChanged
        If teDanhGiaLoiNgoaiQuan.Text.ToUpper = "OK" And teDanhGiaKichThuocDuongMach.Text.ToUpper = "OK" Then
            teDanhGiaLoHang.Text = "OK"
        Else
            teDanhGiaLoHang.Text = "NG"
        End If
    End Sub
    Private Sub btnShow2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow2.ItemClick
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dteNgay.DateTime))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dteNgay.DateTime))
        Dim dtNQ As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_LoadKQQCNgoaiQuan", para)
        GridControl2.DataSource = dtNQ
        GridControlSetFormat(GridView2, 1)
        GridControlSetColorReadonly(GridView2)
    End Sub
    Private Sub btnDelete2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete2.ItemClick
        If ShowQuestionDelete() = DialogResult.Yes Then
            Dim obj As New KQQC_NgoaiQuan
            obj.ID_K = GridView2.GetFocusedRowCellValue("ID")
            _db.Delete(obj)
            GridView2.DeleteSelectedRows()
            GridView1.Columns.Clear()
            GridView1.SelectAll()
            GridView1.DeleteSelectedRows()
            _idGlobal = ""
            teID.Text = ""
        End If
    End Sub


    Private Sub btnSave2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSave2.ItemClick
        Dim obj As New KQQC_NgoaiQuan
        If _idGlobal = "" Then
            _idGlobal = CreateID()
            obj.ID_K = _idGlobal
            teID.Text = _idGlobal
        Else
            obj.ID_K = _idGlobal
            _db.GetObject(obj)
        End If

        obj.Ngay = dteNgay.DateTime
        obj.STT = teSTT.Text
        obj.MSSP = teMSSP.Text
        obj.Lot = teLot.Text

        Dim objProd As New WT_Product
        objProd.ProductCode_K = teMSSP.Text
        If _db.ExistObject(objProd) Then
            _db.GetObject(objProd)
            obj.KhachHang = objProd.CustomerName
            obj.Method = objProd.Method
        End If

        obj.CongDoan = teCongDoan.Text
        obj.SoLanTest = teSoLanTest.Text
        obj.SoLuongKiem = teSoLuongKiem.Text
        obj.SoLuongLoi = teSoLuongLoi.Text
        obj.TyLe = teTyLe.Text
        obj.DanhGiaLoiNgoaiQuan = teDanhGiaLoiNgoaiQuan.Text
        obj.DanhGiaKichThuocDuongMach = teDanhGiaKichThuocDuongMach.Text
        obj.DanhGiaLoHang = teDanhGiaLoHang.Text
        obj.SoMayRoi = teSoMayRoi.Text
        obj.QuangLuong = teQuangLuong.Text
        obj.TocDo = teTocDo.Text
        obj.ApLuc = teApLuc.Text
        obj.PhuongPhapXuLy = cbbPhuongPhap.EditValue
        obj.GhiChu = meGhiChu.Text
        obj.CreateUser = CurrentUser.UserID
        obj.CreateDate = DateTime.Now

        If _db.ExistObject(obj) Then
            _db.Update(obj)
        Else
            _db.Insert(obj)
        End If

        UpdateError()
        btnShow2.PerformClick()
    End Sub

    Private Sub FrmNgoaiQuan_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            btnSave2.PerformClick()
        ElseIf e.KeyCode = Keys.N And e.Control Then
            btnNew.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Right Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.Left Then
            SendKeys.Send("+{Tab}")
        End If
    End Sub

    Public Sub ViewAccess()
        btnNew.Enabled = False
        btnSave2.Enabled = False
        btnEdit.Enabled = False
        btnDelete2.Enabled = False
    End Sub


    Private Sub GridView2_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView2.RowClick
        Dim obj As New KQQC_NgoaiQuan
        obj.ID_K = GridView2.GetFocusedRowCellValue("ID")
        _db.GetObject(obj)
        teID.Text = obj.ID_K
        _idGlobal = obj.ID_K
        dteNgay.DateTime = obj.Ngay
        teSTT.Text = obj.STT
        teMSSP.Text = obj.MSSP
        teLot.Text = obj.Lot
        teCongDoan.Text = obj.CongDoan
        teSoLanTest.Text = obj.SoLanTest
        teSoLuongKiem.Text = obj.SoLuongKiem
        teSoLuongLoi.Text = obj.SoLuongLoi
        teTyLe.Text = obj.TyLe
        teDanhGiaLoiNgoaiQuan.Text = obj.DanhGiaLoiNgoaiQuan
        teDanhGiaKichThuocDuongMach.Text = obj.DanhGiaKichThuocDuongMach
        teDanhGiaLoHang.Text = obj.DanhGiaLoHang
        teSoMayRoi.Text = obj.SoMayRoi
        teQuangLuong.Text = obj.QuangLuong
        teTocDo.Text = obj.TocDo
        teApLuc.Text = obj.ApLuc
        cbbPhuongPhap.EditValue = obj.PhuongPhapXuLy
        meGhiChu.Text = obj.GhiChu

        Dim dtError As DataTable = ErrorDataTable()

        'Load Error vào GridView
        dtError.Rows(0)(1) = GridView2.GetFocusedRowCellValue("Error001_01")
        dtError.Rows(0)(2) = GridView2.GetFocusedRowCellValue("Error002_01")
        dtError.Rows(0)(3) = GridView2.GetFocusedRowCellValue("Error003_01")
        dtError.Rows(0)(4) = GridView2.GetFocusedRowCellValue("Error004_01")
        dtError.Rows(0)(5) = GridView2.GetFocusedRowCellValue("Error005_01")
        dtError.Rows(0)(6) = GridView2.GetFocusedRowCellValue("Error006_01")
        dtError.Rows(0)(7) = GridView2.GetFocusedRowCellValue("Error007_01")
        dtError.Rows(0)(8) = GridView2.GetFocusedRowCellValue("Error009_01")
        dtError.Rows(0)(9) = GridView2.GetFocusedRowCellValue("Error012_01")
        dtError.Rows(0)(10) = GridView2.GetFocusedRowCellValue("Error016_01")
        dtError.Rows(0)(11) = GridView2.GetFocusedRowCellValue("Error018_01")
        dtError.Rows(0)(12) = GridView2.GetFocusedRowCellValue("Error024_01")
        dtError.Rows(0)(13) = GridView2.GetFocusedRowCellValue("Error025_01")
        dtError.Rows(0)(14) = GridView2.GetFocusedRowCellValue("Error627_01")
        dtError.Rows(0)(15) = GridView2.GetFocusedRowCellValue("Error639_01")
        dtError.Rows(0)(16) = GridView2.GetFocusedRowCellValue("ThoiGian_01")
        dtError.Rows(0)(17) = GridView2.GetFocusedRowCellValue("MSNV_01")

        dtError.Rows(1)(1) = GridView2.GetFocusedRowCellValue("Error001_02")
        dtError.Rows(1)(2) = GridView2.GetFocusedRowCellValue("Error002_02")
        dtError.Rows(1)(3) = GridView2.GetFocusedRowCellValue("Error003_02")
        dtError.Rows(1)(4) = GridView2.GetFocusedRowCellValue("Error004_02")
        dtError.Rows(1)(5) = GridView2.GetFocusedRowCellValue("Error005_02")
        dtError.Rows(1)(6) = GridView2.GetFocusedRowCellValue("Error006_02")
        dtError.Rows(1)(7) = GridView2.GetFocusedRowCellValue("Error007_02")
        dtError.Rows(1)(8) = GridView2.GetFocusedRowCellValue("Error009_02")
        dtError.Rows(1)(9) = GridView2.GetFocusedRowCellValue("Error012_02")
        dtError.Rows(1)(10) = GridView2.GetFocusedRowCellValue("Error016_02")
        dtError.Rows(1)(11) = GridView2.GetFocusedRowCellValue("Error018_02")
        dtError.Rows(1)(12) = GridView2.GetFocusedRowCellValue("Error024_02")
        dtError.Rows(1)(13) = GridView2.GetFocusedRowCellValue("Error025_02")
        dtError.Rows(1)(14) = GridView2.GetFocusedRowCellValue("Error627_02")
        dtError.Rows(1)(15) = GridView2.GetFocusedRowCellValue("Error639_02")
        dtError.Rows(1)(16) = GridView2.GetFocusedRowCellValue("ThoiGian_02")
        dtError.Rows(1)(17) = GridView2.GetFocusedRowCellValue("MSNV_02")

        dtError.Rows(2)(1) = GridView2.GetFocusedRowCellValue("Error001_03")
        dtError.Rows(2)(2) = GridView2.GetFocusedRowCellValue("Error002_03")
        dtError.Rows(2)(3) = GridView2.GetFocusedRowCellValue("Error003_03")
        dtError.Rows(2)(4) = GridView2.GetFocusedRowCellValue("Error004_03")
        dtError.Rows(2)(5) = GridView2.GetFocusedRowCellValue("Error005_03")
        dtError.Rows(2)(6) = GridView2.GetFocusedRowCellValue("Error006_03")
        dtError.Rows(2)(7) = GridView2.GetFocusedRowCellValue("Error007_03")
        dtError.Rows(2)(8) = GridView2.GetFocusedRowCellValue("Error009_03")
        dtError.Rows(2)(9) = GridView2.GetFocusedRowCellValue("Error012_03")
        dtError.Rows(2)(10) = GridView2.GetFocusedRowCellValue("Error016_03")
        dtError.Rows(2)(11) = GridView2.GetFocusedRowCellValue("Error018_03")
        dtError.Rows(2)(12) = GridView2.GetFocusedRowCellValue("Error024_03")
        dtError.Rows(2)(13) = GridView2.GetFocusedRowCellValue("Error025_03")
        dtError.Rows(2)(14) = GridView2.GetFocusedRowCellValue("Error627_03")
        dtError.Rows(2)(15) = GridView2.GetFocusedRowCellValue("Error639_03")
        dtError.Rows(2)(16) = GridView2.GetFocusedRowCellValue("ThoiGian_03")
        dtError.Rows(2)(17) = GridView2.GetFocusedRowCellValue("MSNV_03")

        dtError.Rows(3)(1) = GridView2.GetFocusedRowCellValue("Error001_04")
        dtError.Rows(3)(2) = GridView2.GetFocusedRowCellValue("Error002_04")
        dtError.Rows(3)(3) = GridView2.GetFocusedRowCellValue("Error003_04")
        dtError.Rows(3)(4) = GridView2.GetFocusedRowCellValue("Error004_04")
        dtError.Rows(3)(5) = GridView2.GetFocusedRowCellValue("Error005_04")
        dtError.Rows(3)(6) = GridView2.GetFocusedRowCellValue("Error006_04")
        dtError.Rows(3)(7) = GridView2.GetFocusedRowCellValue("Error007_04")
        dtError.Rows(3)(8) = GridView2.GetFocusedRowCellValue("Error009_04")
        dtError.Rows(3)(9) = GridView2.GetFocusedRowCellValue("Error012_04")
        dtError.Rows(3)(10) = GridView2.GetFocusedRowCellValue("Error016_04")
        dtError.Rows(3)(11) = GridView2.GetFocusedRowCellValue("Error018_04")
        dtError.Rows(3)(12) = GridView2.GetFocusedRowCellValue("Error024_04")
        dtError.Rows(3)(13) = GridView2.GetFocusedRowCellValue("Error025_04")
        dtError.Rows(3)(14) = GridView2.GetFocusedRowCellValue("Error627_04")
        dtError.Rows(3)(15) = GridView2.GetFocusedRowCellValue("Error639_04")
        dtError.Rows(3)(16) = GridView2.GetFocusedRowCellValue("ThoiGian_04")
        dtError.Rows(3)(17) = GridView2.GetFocusedRowCellValue("MSNV_04")

        dtError.Rows(4)(1) = GridView2.GetFocusedRowCellValue("Error001_Cavity")
        dtError.Rows(4)(2) = GridView2.GetFocusedRowCellValue("Error002_Cavity")
        dtError.Rows(4)(3) = GridView2.GetFocusedRowCellValue("Error003_Cavity")
        dtError.Rows(4)(4) = GridView2.GetFocusedRowCellValue("Error004_Cavity")
        dtError.Rows(4)(5) = GridView2.GetFocusedRowCellValue("Error005_Cavity")
        dtError.Rows(4)(6) = GridView2.GetFocusedRowCellValue("Error006_Cavity")
        dtError.Rows(4)(7) = GridView2.GetFocusedRowCellValue("Error007_Cavity")
        dtError.Rows(4)(8) = GridView2.GetFocusedRowCellValue("Error009_Cavity")
        dtError.Rows(4)(9) = GridView2.GetFocusedRowCellValue("Error012_Cavity")
        dtError.Rows(4)(10) = GridView2.GetFocusedRowCellValue("Error016_Cavity")
        dtError.Rows(4)(11) = GridView2.GetFocusedRowCellValue("Error018_Cavity")
        dtError.Rows(4)(12) = GridView2.GetFocusedRowCellValue("Error024_Cavity")
        dtError.Rows(4)(13) = GridView2.GetFocusedRowCellValue("Error025_Cavity")
        dtError.Rows(4)(14) = GridView2.GetFocusedRowCellValue("Error627_Cavity")
        dtError.Rows(4)(15) = GridView2.GetFocusedRowCellValue("Error639_Cavity")
        dtError.Rows(4)(16) = GridView2.GetFocusedRowCellValue("ThoiGian_Cavity")
        dtError.Rows(4)(17) = GridView2.GetFocusedRowCellValue("MSNV_Cavity")

        GridControl1.DataSource = dtError
        GridControlSetFormat(GridView1, 0)
        GridControlReadOnly(GridView1, False)
        GridView1.Columns("SoTam").OptionsColumn.ReadOnly = True
        GridControlSetColorEdit(GridView1)
    End Sub
    Private Function ErrorDataTable() As DataTable
        Dim tbError As New DataTable
        tbError.Columns.Add("SoTam", GetType(String))
        tbError.Columns.Add("Error001", GetType(String))
        tbError.Columns.Add("Error002", GetType(String))
        tbError.Columns.Add("Error003", GetType(String))
        tbError.Columns.Add("Error004", GetType(String))
        tbError.Columns.Add("Error005", GetType(String))
        tbError.Columns.Add("Error006", GetType(String))
        tbError.Columns.Add("Error007", GetType(String))
        tbError.Columns.Add("Error009", GetType(String))
        tbError.Columns.Add("Error012", GetType(String))
        tbError.Columns.Add("Error016", GetType(String))
        tbError.Columns.Add("Error018", GetType(String))
        tbError.Columns.Add("Error024", GetType(String))
        tbError.Columns.Add("Error025", GetType(String))
        tbError.Columns.Add("Error627", GetType(String))
        tbError.Columns.Add("Error639", GetType(String))
        tbError.Columns.Add("ThoiGianKiem", GetType(String))
        tbError.Columns.Add("NhanVienKiem", GetType(String))

        tbError.Rows.Add()
        tbError.Rows(0)(0) = "Tấm 1"
        tbError.Rows.Add()
        tbError.Rows(1)(0) = "Tấm 2"
        tbError.Rows.Add()
        tbError.Rows(2)(0) = "Tấm 3"
        tbError.Rows.Add()
        tbError.Rows(3)(0) = "Tấm 4"
        tbError.Rows.Add()
        tbError.Rows(4)(0) = "Cavity"

        For i = 0 To 4
            For j = 1 To 17
                tbError.Rows(i)(j) = ""
            Next
        Next
        Return tbError
    End Function

    Private Function ResultError() As DataTable
        Dim dt As New DataTable()
        For Each column As GridColumn In GridView1.VisibleColumns
            dt.Columns.Add(column.FieldName, column.ColumnType)
        Next column
        For i As Integer = 0 To GridView1.DataRowCount - 1
            Dim row As DataRow = dt.NewRow()
            For Each column As GridColumn In GridView1.VisibleColumns
                row(column.FieldName) = GridView1.GetRowCellValue(i, column)
            Next column
            dt.Rows.Add(row)
        Next i
        Return dt
    End Function
    Sub UpdateError()
        Dim dtError As DataTable = ResultError()

        Dim obj As New KQQC_NgoaiQuan
        obj.ID_K = teID.Text
        _db.GetObject(obj)

        obj.Error001_01 = If(dtError.Rows(0)(1) = "", 0, dtError.Rows(0)(1))
        obj.Error002_01 = If(dtError.Rows(0)(2) = "", 0, dtError.Rows(0)(2))
        obj.Error003_01 = If(dtError.Rows(0)(3) = "", 0, dtError.Rows(0)(3))
        obj.Error004_01 = If(dtError.Rows(0)(4) = "", 0, dtError.Rows(0)(4))
        obj.Error005_01 = If(dtError.Rows(0)(5) = "", 0, dtError.Rows(0)(5))
        obj.Error006_01 = If(dtError.Rows(0)(6) = "", 0, dtError.Rows(0)(6))
        obj.Error007_01 = If(dtError.Rows(0)(7) = "", 0, dtError.Rows(0)(7))
        obj.Error009_01 = If(dtError.Rows(0)(8) = "", 0, dtError.Rows(0)(8))
        obj.Error012_01 = If(dtError.Rows(0)(9) = "", 0, dtError.Rows(0)(9))
        obj.Error016_01 = If(dtError.Rows(0)(10) = "", 0, dtError.Rows(0)(10))
        obj.Error018_01 = If(dtError.Rows(0)(11) = "", 0, dtError.Rows(0)(11))
        obj.Error024_01 = If(dtError.Rows(0)(12) = "", 0, dtError.Rows(0)(12))
        obj.Error025_01 = If(dtError.Rows(0)(13) = "", 0, dtError.Rows(0)(13))
        obj.Error627_01 = If(dtError.Rows(0)(14) = "", 0, dtError.Rows(0)(14))
        obj.Error639_01 = If(dtError.Rows(0)(15) = "", 0, dtError.Rows(0)(15))
        obj.ThoiGian_01 = If(dtError.Rows(0)(16) = "", 0, dtError.Rows(0)(16))
        obj.MSNV_01 = dtError.Rows(0)(17)

        obj.Error001_02 = If(dtError.Rows(1)(1) = "", 0, dtError.Rows(1)(1))
        obj.Error002_02 = If(dtError.Rows(1)(2) = "", 0, dtError.Rows(1)(2))
        obj.Error003_02 = If(dtError.Rows(1)(3) = "", 0, dtError.Rows(1)(3))
        obj.Error004_02 = If(dtError.Rows(1)(4) = "", 0, dtError.Rows(1)(4))
        obj.Error005_02 = If(dtError.Rows(1)(5) = "", 0, dtError.Rows(1)(5))
        obj.Error006_02 = If(dtError.Rows(1)(6) = "", 0, dtError.Rows(1)(6))
        obj.Error007_02 = If(dtError.Rows(1)(7) = "", 0, dtError.Rows(1)(7))
        obj.Error009_02 = If(dtError.Rows(1)(8) = "", 0, dtError.Rows(1)(8))
        obj.Error012_02 = If(dtError.Rows(1)(9) = "", 0, dtError.Rows(1)(9))
        obj.Error016_02 = If(dtError.Rows(1)(10) = "", 0, dtError.Rows(1)(10))
        obj.Error018_02 = If(dtError.Rows(1)(11) = "", 0, dtError.Rows(1)(11))
        obj.Error024_02 = If(dtError.Rows(1)(12) = "", 0, dtError.Rows(1)(12))
        obj.Error025_02 = If(dtError.Rows(1)(13) = "", 0, dtError.Rows(1)(13))
        obj.Error627_02 = If(dtError.Rows(1)(14) = "", 0, dtError.Rows(1)(14))
        obj.Error639_02 = If(dtError.Rows(1)(15) = "", 0, dtError.Rows(1)(15))
        obj.ThoiGian_02 = If(dtError.Rows(1)(16) = "", 0, dtError.Rows(1)(16))
        obj.MSNV_02 = dtError.Rows(1)(17)

        obj.Error001_03 = If(dtError.Rows(2)(1) = "", 0, dtError.Rows(2)(1))
        obj.Error002_03 = If(dtError.Rows(2)(2) = "", 0, dtError.Rows(2)(2))
        obj.Error003_03 = If(dtError.Rows(2)(3) = "", 0, dtError.Rows(2)(3))
        obj.Error004_03 = If(dtError.Rows(2)(4) = "", 0, dtError.Rows(2)(4))
        obj.Error005_03 = If(dtError.Rows(2)(5) = "", 0, dtError.Rows(2)(5))
        obj.Error006_03 = If(dtError.Rows(2)(6) = "", 0, dtError.Rows(2)(6))
        obj.Error007_03 = If(dtError.Rows(2)(7) = "", 0, dtError.Rows(2)(7))
        obj.Error009_03 = If(dtError.Rows(2)(8) = "", 0, dtError.Rows(2)(8))
        obj.Error012_03 = If(dtError.Rows(2)(9) = "", 0, dtError.Rows(2)(9))
        obj.Error016_03 = If(dtError.Rows(2)(10) = "", 0, dtError.Rows(2)(10))
        obj.Error018_03 = If(dtError.Rows(2)(11) = "", 0, dtError.Rows(2)(11))
        obj.Error024_03 = If(dtError.Rows(2)(12) = "", 0, dtError.Rows(2)(12))
        obj.Error025_03 = If(dtError.Rows(2)(13) = "", 0, dtError.Rows(2)(13))
        obj.Error627_03 = If(dtError.Rows(2)(14) = "", 0, dtError.Rows(2)(14))
        obj.Error639_03 = If(dtError.Rows(2)(15) = "", 0, dtError.Rows(2)(15))
        obj.ThoiGian_03 = If(dtError.Rows(2)(16) = "", 0, dtError.Rows(2)(16))
        obj.MSNV_03 = dtError.Rows(2)(17)

        obj.Error001_04 = If(dtError.Rows(3)(1) = "", 0, dtError.Rows(3)(1))
        obj.Error002_04 = If(dtError.Rows(3)(2) = "", 0, dtError.Rows(3)(2))
        obj.Error003_04 = If(dtError.Rows(3)(3) = "", 0, dtError.Rows(3)(3))
        obj.Error004_04 = If(dtError.Rows(3)(4) = "", 0, dtError.Rows(3)(4))
        obj.Error005_04 = If(dtError.Rows(3)(5) = "", 0, dtError.Rows(3)(5))
        obj.Error006_04 = If(dtError.Rows(3)(6) = "", 0, dtError.Rows(3)(6))
        obj.Error007_04 = If(dtError.Rows(3)(7) = "", 0, dtError.Rows(3)(7))
        obj.Error009_04 = If(dtError.Rows(3)(8) = "", 0, dtError.Rows(3)(8))
        obj.Error012_04 = If(dtError.Rows(3)(9) = "", 0, dtError.Rows(3)(9))
        obj.Error016_04 = If(dtError.Rows(3)(10) = "", 0, dtError.Rows(3)(10))
        obj.Error018_04 = If(dtError.Rows(3)(11) = "", 0, dtError.Rows(3)(11))
        obj.Error024_04 = If(dtError.Rows(3)(12) = "", 0, dtError.Rows(3)(12))
        obj.Error025_04 = If(dtError.Rows(3)(13) = "", 0, dtError.Rows(3)(13))
        obj.Error627_04 = If(dtError.Rows(3)(14) = "", 0, dtError.Rows(3)(14))
        obj.Error639_04 = If(dtError.Rows(3)(15) = "", 0, dtError.Rows(3)(15))
        obj.ThoiGian_04 = If(dtError.Rows(3)(16) = "", 0, dtError.Rows(3)(16))
        obj.MSNV_04 = dtError.Rows(3)(17)

        obj.Error001_Cavity = dtError.Rows(4)(1)
        obj.Error002_Cavity = dtError.Rows(4)(2)
        obj.Error003_Cavity = dtError.Rows(4)(3)
        obj.Error004_Cavity = dtError.Rows(4)(4)
        obj.Error005_Cavity = dtError.Rows(4)(5)
        obj.Error006_Cavity = dtError.Rows(4)(6)
        obj.Error007_Cavity = dtError.Rows(4)(7)
        obj.Error009_Cavity = dtError.Rows(4)(8)
        obj.Error012_Cavity = dtError.Rows(4)(9)
        obj.Error016_Cavity = dtError.Rows(4)(10)
        obj.Error018_Cavity = dtError.Rows(4)(11)
        obj.Error024_Cavity = dtError.Rows(4)(12)
        obj.Error025_Cavity = dtError.Rows(4)(13)
        obj.Error627_Cavity = dtError.Rows(4)(14)
        obj.Error639_Cavity = dtError.Rows(4)(15)
        obj.ThoiGian_Cavity = If(dtError.Rows(4)(16) = "", 0, dtError.Rows(4)(16))
        obj.MSNV_Cavity = dtError.Rows(4)(17)

        _db.Update(obj)
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        UpdateError()
        btnShow2.PerformClick()
    End Sub
End Class