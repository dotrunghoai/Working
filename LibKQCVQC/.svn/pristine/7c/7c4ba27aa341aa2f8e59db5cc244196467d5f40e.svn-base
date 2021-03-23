Imports CommonDB
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports PublicUtility
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmXemKQCVNew : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmKQCV_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        dtpDate.Value = DateTime.Now.AddDays(-7)
        mnuShowAll.PerformClick()

        'Load combobox Công Đoạn
        cbbCongDoan.Properties.Items.Add("Normal")
        cbbCongDoan.Properties.Items.Add("Photo-ETC")
        cbbCongDoan.Properties.Items.Add("Laser")
        cbbCongDoan.Properties.Items.Add("Plasma")
        cbbCongDoan.Properties.Items.Add("BH")
        cbbCongDoan.Properties.Items.Add("PTH")
        cbbCongDoan.EditValue = "Normal"

        LaserPlasmaBHHide()
        PTHHide()
    End Sub

    Private Sub FrmKQCV_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        LaserPlasmaBHHide()
        PTHHide()
        GridView1.Columns.Clear()
        GridView2.Columns.Clear()
        GridView3.Columns.Clear()
        If cbbCongDoan.EditValue = "Photo-ETC" Then
            Dim para(2) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dtpDate.Value))
            para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dtpDateTo.Value))
            para(2) = New SqlClient.SqlParameter("MaxID", "ShowSum")
            Dim dtNQ As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_LoadKQQCNgoaiQuan", para)
            GridControl1.DataSource = dtNQ
            GridControlSetFormat(GridView1, 1)
            GridControlSetColorReadonly(GridView1)
        ElseIf cbbCongDoan.EditValue = "Laser" Then
            Dim para(2) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dtpDate.Value))
            para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dtpDateTo.Value))
            para(2) = New SqlClient.SqlParameter("@PTH", "Laser")
            Dim dtLaser As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_LoadLaserPlasmaBH", para)
            GridControl1.DataSource = dtLaser
            GridControlSetFormat(GridView1, 1)
            GridControlSetColorReadonly(GridView1)
        ElseIf cbbCongDoan.EditValue = "Plasma" Then
            Dim para(2) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dtpDate.Value))
            para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dtpDateTo.Value))
            para(2) = New SqlClient.SqlParameter("PTH", "Plasma")
            Dim dtPlasma As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_LoadLaserPlasmaBH", para)
            GridControl1.DataSource = dtPlasma
            GridControlSetFormat(GridView1, 1)
            GridControlSetColorReadonly(GridView1)
        ElseIf cbbCongDoan.EditValue = "BH" Then
            Dim para(2) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dtpDate.Value))
            para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dtpDateTo.Value))
            para(2) = New SqlClient.SqlParameter("PTH", "BH")
            Dim dtBH As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_LoadLaserPlasmaBH", para)
            GridControl1.DataSource = dtBH
            GridControlSetFormat(GridView1, 1)
            GridControlSetColorReadonly(GridView1)
        ElseIf cbbCongDoan.EditValue = "PTH" Then
            Dim para(2) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dtpDate.Value))
            para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dtpDateTo.Value))
            para(2) = New SqlClient.SqlParameter("@PTH", "PTH")
            Dim dtPTH As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_LoadLaserPlasmaBH", para)
            GridControl1.DataSource = dtPTH
            GridControlSetFormat(GridView1, 1)
            GridControlSetColorReadonly(GridView1)
        Else
            Dim para(1) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@StartDate", dtpDate.Value.Date)
            para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dtpDateTo.Value.Date))
            Dim sql As String = String.Format("sp_KQQC_LoadKQQCNew")
            GridControl1.DataSource = _db.ExecuteStoreProcedureTB(sql, para)
            GridControlSetFormat(GridView1, 3)
            GridControlSetWidth(GridView1, 50)
        End If
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub mnuEmpCode_Click(sender As Object, e As EventArgs) Handles mnuEmpCode.Click
        Dim frm As New FrmEmpCode
        frm.Show()
    End Sub

    Private Sub mnuExportExcel_Click(sender As Object, e As EventArgs) Handles mnuExportExcel.Click
        GridControlExportExcel(GridView2)
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowClick
        GridView2.Columns.Clear()
        GridView3.Columns.Clear()
        If cbbCongDoan.EditValue = "Photo-ETC" Then
            LaserPlasmaBHHide()
            PTHHide()
            'Load Error
            Dim tbError As New DataTable
            ErrorDataTable(tbError)
            GridControl2.DataSource = tbError
            GridControlReadOnly(GridView2, True)
            GridControlSetFormat(GridView2)
            GridControlSetWidth(GridView2, 50)
            GridView2.ColumnPanelRowHeight = 35
            LoadMSNV()

        ElseIf cbbCongDoan.EditValue = "Laser" Or cbbCongDoan.EditValue = "Plasma" Or cbbCongDoan.EditValue = "BH" Then
            PTHHide()

            Dim soLuongKiem As Integer = GridView1.GetFocusedRowCellValue("SoLuongKiem")
            Dim soTam As Integer = GridView1.GetFocusedRowCellValue("SoTam")

            Dim dt As DataTable = CreateTableCavNull(soLuongKiem, soTam)
            For r = 0 To dt.Rows.Count - 3
                For c = 1 To dt.Columns.Count - 1
                    dt.Rows(r)(c) = GridView1.GetFocusedRowCellValue("T" + CStr(r + 1) + "Cav" + CStr(c))
                Next
            Next
            dt.Rows(dt.Rows.Count - 2)(1) = GridView1.GetFocusedRowCellValue("Y")
            dt.Rows(dt.Rows.Count - 1)(1) = GridView1.GetFocusedRowCellValue("Z")

            GridControl2.DataSource = dt
            GridControlReadOnly(GridView2, True)
            GridControlSetWidth(GridView2, 50)
            GridView2.ColumnPanelRowHeight = 35

            'DanhGia
            If Not IsDBNull(GridView1.GetFocusedRowCellValue("DanhGiaSauCung")) Then
                If GridView1.GetFocusedRowCellValue("DanhGiaSauCung").ToString.ToUpper = "OK" Then
                    lcDanhGia.BackColor = System.Drawing.Color.LawnGreen
                    lcDanhGia.Text = "OK"
                Else
                    lcDanhGia.BackColor = System.Drawing.Color.Red
                    lcDanhGia.Text = "NG"
                End If
            End If
            LaserPlasmaBHAppera()

            'Load MSNV
            LoadNhanVienKiem()

        ElseIf cbbCongDoan.EditValue = "PTH" Then
            LaserPlasmaBHHide()
            Dim soLuongKiem As Integer = GridView1.GetFocusedRowCellValue("SoLuongKiem")
            Dim dtSoLuongKiem As New DataTable
            dtSoLuongKiem.Columns.Add("Cav", GetType(String))
            dtSoLuongKiem.Columns.Add("Mã lỗi", GetType(String))
            dtSoLuongKiem.Columns.Add("Số lượng", GetType(Integer))
            For i = 0 To soLuongKiem - 1
                dtSoLuongKiem.Rows.Add()
                dtSoLuongKiem.Rows(i)("Cav") = "Cav" + CStr(i + 1)
                dtSoLuongKiem.Rows(i)("Mã lỗi") = GridView1.GetFocusedRowCellValue("MaLoiCav" + CStr(i + 1))
                dtSoLuongKiem.Rows(i)("Số lượng") = GridView1.GetFocusedRowCellValue("SoLuongLoiCav" + CStr(i + 1))
            Next
            GridControl2.DataSource = dtSoLuongKiem
            GridControlSetWidth(GridView2, 100)
            GridControlReadOnly(GridView2, True)
            GridView2.ColumnPanelRowHeight = 35
            lcKQCross.Text = GridView1.GetFocusedRowCellValue("KQCross")

            'DanhGiaPTH
            Dim obj As New KQQC_PTH
            obj.ID_K = GridView1.GetFocusedRowCellValue("ID")
            _db.GetObject(obj)

            If obj.DanhGia.ToUpper = "OK" Then
                lcDanhGiaPTH.BackColor = System.Drawing.Color.LawnGreen
                lcDanhGiaPTH.Text = "OK"
            Else
                lcDanhGiaPTH.BackColor = System.Drawing.Color.Red
                lcDanhGiaPTH.Text = "NG"
            End If

            If obj.KQCross.ToUpper = "OK" Then
                lcKQCross.Text = "OK"
                lcKQCross.BackColor = System.Drawing.Color.LawnGreen
            ElseIf obj.KQCross = "-" Then
                lcKQCross.Text = "-"
                lcKQCross.BackColor = System.Drawing.Color.White
            Else
                lcKQCross.Text = "NG"
                lcKQCross.BackColor = System.Drawing.Color.Red
            End If

            If (obj.DanhGia.ToUpper = "OK") And (obj.DanhGia.ToUpper = "OK" Or obj.KQCross = "-") Then
                lcDanhGiaLohang.Text = "OK"
                lcDanhGiaLohang.BackColor = System.Drawing.Color.LawnGreen
            Else
                lcDanhGiaLohang.Text = "NG"
                lcDanhGiaLohang.BackColor = System.Drawing.Color.Red
            End If

            PTHAppera()

            'Load MSNV
            LoadNhanVienKiem()
        Else
            LaserPlasmaBHHide()
            PTHHide()
            Dim sql As String = String.Format("sp_KQQC_LoadDetail")
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@ID", GridView1.GetFocusedRowCellValue("ID"))

            GridControl2.DataSource = _db.ExecuteStoreProcedureTB(sql, para)
            GridControlSetFormat(GridView2, 3)
            GridControlSetWidth(GridView2, 50)
            GridView2.Columns("EmpName").BestFit()
            GridView2.Columns("BatDau").BestFit()
            GridView2.Columns("KetThuc").BestFit()
        End If
    End Sub

    Private Sub txtPdCode_TextChanged(sender As Object, e As EventArgs) Handles txtPdCode.TextChanged
        GridView1.FindFilterText = txtPdCode.Text
    End Sub

    Private Sub ErrorDataTable(ByVal tbError As DataTable)
        tbError.Columns.Add("Số Tấm", GetType(String))
        tbError.Columns.Add("Mã lỗi 001", GetType(String))
        tbError.Columns.Add("Mã lỗi 002", GetType(String))
        tbError.Columns.Add("Mã lỗi 003", GetType(String))
        tbError.Columns.Add("Mã lỗi 004", GetType(String))
        tbError.Columns.Add("Mã lỗi 005", GetType(String))
        tbError.Columns.Add("Mã lỗi 006", GetType(String))
        tbError.Columns.Add("Mã lỗi 007", GetType(String))
        tbError.Columns.Add("Mã lỗi 009", GetType(String))
        tbError.Columns.Add("Mã lỗi 012", GetType(String))
        tbError.Columns.Add("Mã lỗi 016", GetType(String))
        tbError.Columns.Add("Mã lỗi 018", GetType(String))
        tbError.Columns.Add("Mã lỗi 024", GetType(String))
        tbError.Columns.Add("Mã lỗi 025", GetType(String))
        tbError.Columns.Add("Mã lỗi 627", GetType(String))
        tbError.Columns.Add("Mã lỗi 639", GetType(String))
        tbError.Columns.Add("Thời gian", GetType(String))
        tbError.Columns.Add("MSNV", GetType(String))

        Dim objNgoaiQuan As New KQQC_NgoaiQuan
        objNgoaiQuan.ID_K = GridView1.GetFocusedRowCellValue("ID")
        _db.GetObject(objNgoaiQuan)

        tbError.Rows.Add()
        tbError.Rows(0)(0) = "Tấm 1"
        tbError.Rows(0)("Mã lỗi 001") = objNgoaiQuan.Error001_01
        tbError.Rows(0)("Mã lỗi 002") = objNgoaiQuan.Error002_01
        tbError.Rows(0)("Mã lỗi 003") = objNgoaiQuan.Error003_01
        tbError.Rows(0)("Mã lỗi 004") = objNgoaiQuan.Error004_01
        tbError.Rows(0)("Mã lỗi 005") = objNgoaiQuan.Error005_01
        tbError.Rows(0)("Mã lỗi 006") = objNgoaiQuan.Error006_01
        tbError.Rows(0)("Mã lỗi 007") = objNgoaiQuan.Error007_01
        tbError.Rows(0)("Mã lỗi 009") = objNgoaiQuan.Error009_01
        tbError.Rows(0)("Mã lỗi 012") = objNgoaiQuan.Error012_01
        tbError.Rows(0)("Mã lỗi 016") = objNgoaiQuan.Error016_01
        tbError.Rows(0)("Mã lỗi 018") = objNgoaiQuan.Error018_01
        tbError.Rows(0)("Mã lỗi 024") = objNgoaiQuan.Error024_01
        tbError.Rows(0)("Mã lỗi 025") = objNgoaiQuan.Error025_01
        tbError.Rows(0)("Mã lỗi 627") = objNgoaiQuan.Error627_01
        tbError.Rows(0)("Mã lỗi 639") = objNgoaiQuan.Error639_01
        tbError.Rows(0)("Thời gian") = objNgoaiQuan.ThoiGian_01
        tbError.Rows(0)("MSNV") = objNgoaiQuan.MSNV_01

        tbError.Rows.Add()
        tbError.Rows(1)(0) = "Tấm 2"
        tbError.Rows(1)("Mã lỗi 001") = objNgoaiQuan.Error001_02
        tbError.Rows(1)("Mã lỗi 002") = objNgoaiQuan.Error002_02
        tbError.Rows(1)("Mã lỗi 003") = objNgoaiQuan.Error003_02
        tbError.Rows(1)("Mã lỗi 004") = objNgoaiQuan.Error004_02
        tbError.Rows(1)("Mã lỗi 005") = objNgoaiQuan.Error005_02
        tbError.Rows(1)("Mã lỗi 006") = objNgoaiQuan.Error006_02
        tbError.Rows(1)("Mã lỗi 007") = objNgoaiQuan.Error007_02
        tbError.Rows(1)("Mã lỗi 009") = objNgoaiQuan.Error009_02
        tbError.Rows(1)("Mã lỗi 012") = objNgoaiQuan.Error012_02
        tbError.Rows(1)("Mã lỗi 016") = objNgoaiQuan.Error016_02
        tbError.Rows(1)("Mã lỗi 018") = objNgoaiQuan.Error018_02
        tbError.Rows(1)("Mã lỗi 024") = objNgoaiQuan.Error024_02
        tbError.Rows(1)("Mã lỗi 025") = objNgoaiQuan.Error025_02
        tbError.Rows(1)("Mã lỗi 627") = objNgoaiQuan.Error627_02
        tbError.Rows(1)("Mã lỗi 639") = objNgoaiQuan.Error639_02
        tbError.Rows(1)("Thời gian") = objNgoaiQuan.ThoiGian_02
        tbError.Rows(1)("MSNV") = objNgoaiQuan.MSNV_02

        tbError.Rows.Add()
        tbError.Rows(2)(0) = "Tấm 3"
        tbError.Rows(2)("Mã lỗi 001") = objNgoaiQuan.Error001_03
        tbError.Rows(2)("Mã lỗi 002") = objNgoaiQuan.Error002_03
        tbError.Rows(2)("Mã lỗi 003") = objNgoaiQuan.Error003_03
        tbError.Rows(2)("Mã lỗi 004") = objNgoaiQuan.Error004_03
        tbError.Rows(2)("Mã lỗi 005") = objNgoaiQuan.Error005_03
        tbError.Rows(2)("Mã lỗi 006") = objNgoaiQuan.Error006_03
        tbError.Rows(2)("Mã lỗi 007") = objNgoaiQuan.Error007_03
        tbError.Rows(2)("Mã lỗi 009") = objNgoaiQuan.Error009_03
        tbError.Rows(2)("Mã lỗi 012") = objNgoaiQuan.Error012_03
        tbError.Rows(2)("Mã lỗi 016") = objNgoaiQuan.Error016_03
        tbError.Rows(2)("Mã lỗi 018") = objNgoaiQuan.Error018_03
        tbError.Rows(2)("Mã lỗi 024") = objNgoaiQuan.Error024_03
        tbError.Rows(2)("Mã lỗi 025") = objNgoaiQuan.Error025_03
        tbError.Rows(2)("Mã lỗi 627") = objNgoaiQuan.Error627_03
        tbError.Rows(2)("Mã lỗi 639") = objNgoaiQuan.Error639_03
        tbError.Rows(2)("Thời gian") = objNgoaiQuan.ThoiGian_03
        tbError.Rows(2)("MSNV") = objNgoaiQuan.MSNV_03

        tbError.Rows.Add()
        tbError.Rows(3)(0) = "Tấm 4"
        tbError.Rows(3)("Mã lỗi 001") = objNgoaiQuan.Error001_04
        tbError.Rows(3)("Mã lỗi 002") = objNgoaiQuan.Error002_04
        tbError.Rows(3)("Mã lỗi 003") = objNgoaiQuan.Error003_04
        tbError.Rows(3)("Mã lỗi 004") = objNgoaiQuan.Error004_04
        tbError.Rows(3)("Mã lỗi 005") = objNgoaiQuan.Error005_04
        tbError.Rows(3)("Mã lỗi 006") = objNgoaiQuan.Error006_04
        tbError.Rows(3)("Mã lỗi 007") = objNgoaiQuan.Error007_04
        tbError.Rows(3)("Mã lỗi 009") = objNgoaiQuan.Error009_04
        tbError.Rows(3)("Mã lỗi 012") = objNgoaiQuan.Error012_04
        tbError.Rows(3)("Mã lỗi 016") = objNgoaiQuan.Error016_04
        tbError.Rows(3)("Mã lỗi 018") = objNgoaiQuan.Error018_04
        tbError.Rows(3)("Mã lỗi 024") = objNgoaiQuan.Error024_04
        tbError.Rows(3)("Mã lỗi 025") = objNgoaiQuan.Error025_04
        tbError.Rows(3)("Mã lỗi 627") = objNgoaiQuan.Error627_04
        tbError.Rows(3)("Mã lỗi 639") = objNgoaiQuan.Error639_04
        tbError.Rows(3)("Thời gian") = objNgoaiQuan.ThoiGian_04
        tbError.Rows(3)("MSNV") = objNgoaiQuan.MSNV_04

        tbError.Rows.Add()
        tbError.Rows(4)(0) = "Cavity"
        tbError.Rows(4)("Mã lỗi 001") = objNgoaiQuan.Error001_Cavity
        tbError.Rows(4)("Mã lỗi 002") = objNgoaiQuan.Error002_Cavity
        tbError.Rows(4)("Mã lỗi 003") = objNgoaiQuan.Error003_Cavity
        tbError.Rows(4)("Mã lỗi 004") = objNgoaiQuan.Error004_Cavity
        tbError.Rows(4)("Mã lỗi 005") = objNgoaiQuan.Error005_Cavity
        tbError.Rows(4)("Mã lỗi 006") = objNgoaiQuan.Error006_Cavity
        tbError.Rows(4)("Mã lỗi 007") = objNgoaiQuan.Error007_Cavity
        tbError.Rows(4)("Mã lỗi 009") = objNgoaiQuan.Error009_Cavity
        tbError.Rows(4)("Mã lỗi 012") = objNgoaiQuan.Error012_Cavity
        tbError.Rows(4)("Mã lỗi 016") = objNgoaiQuan.Error016_Cavity
        tbError.Rows(4)("Mã lỗi 018") = objNgoaiQuan.Error018_Cavity
        tbError.Rows(4)("Mã lỗi 024") = objNgoaiQuan.Error024_Cavity
        tbError.Rows(4)("Mã lỗi 025") = objNgoaiQuan.Error025_Cavity
        tbError.Rows(4)("Mã lỗi 627") = objNgoaiQuan.Error627_Cavity
        tbError.Rows(4)("Mã lỗi 639") = objNgoaiQuan.Error639_Cavity
        tbError.Rows(4)("Thời gian") = objNgoaiQuan.ThoiGian_Cavity
        tbError.Rows(4)("MSNV") = objNgoaiQuan.MSNV_Cavity
    End Sub
    Private Function ResultCav() As DataTable
        Dim dt As New DataTable()
        For Each column As GridColumn In GridView2.VisibleColumns
            dt.Columns.Add(column.FieldName, column.ColumnType)
        Next column
        For i As Integer = 0 To GridView2.DataRowCount - 1
            Dim row As DataRow = dt.NewRow()
            For Each column As GridColumn In GridView2.VisibleColumns
                row(column.FieldName) = GridView2.GetRowCellValue(i, column)
            Next column
            dt.Rows.Add(row)
        Next i
        Return dt
    End Function
    Public Sub DanhGia()
        Dim dt As DataTable = ResultCav()
        Dim soDem As Integer = 0
        For i = 0 To dt.Columns.Count - 1
            If dt.Rows(0)(i) = "ok" Or dt.Rows(0)(i) = "OK" Then
                soDem += 1
            End If
        Next
        If soDem = dt.Columns.Count Then
            lcDanhGia.BackColor = System.Drawing.Color.LawnGreen
            lcDanhGia.Text = "OK"
        Else
            lcDanhGia.BackColor = System.Drawing.Color.Red
            lcDanhGia.Text = "NG"
        End If
    End Sub

    Private Sub LoadMSNV()
        'Load MSNV
        Dim dtCodeMSNV As DataTable = _db.FillDataTable("select Code, EmpName from KQQC_Code")
        If IsDBNull(GridView1.GetFocusedRowCellValue("MSNV")) Then
            Return
        End If
        Dim msnv As String = GridView1.GetFocusedRowCellValue("MSNV")
        msnv = msnv + " "

        Dim table As New DataTable
        table.Columns.Add("Code", GetType(String))
        table.Columns.Add("Name", GetType(String))

        Dim n As Integer = 0
        Dim lenChar As Integer = 0
        For index = n To msnv.Length - 1
            If msnv(index) >= "0" And msnv(index) <= "z" Then
                lenChar += 1
            ElseIf msnv(index) = " " Then
                Dim msnvNew As String = msnv.Substring(index - lenChar, lenChar)
                If msnvNew Is Nothing Or msnvNew = " " Or msnvNew = "" Then
                    Continue For
                Else
                    For i = 0 To dtCodeMSNV.Rows.Count - 1
                        If dtCodeMSNV.Rows(i).Item("Code") = msnvNew Then
                            table.Rows.Add(msnvNew, dtCodeMSNV.Rows(i).Item("EmpName"))
                            lenChar = 0
                        End If
                    Next
                End If
            End If
            n += 1
        Next

        GridControl3.DataSource = table
        GridControlSetWidth(GridView3, "Code", 50)
        GridControlSetWidth(GridView3, "Name", 150)
        GridControlSetFormat(GridView3)
        GridView3.ColumnPanelRowHeight = 35
    End Sub
    Private Sub LoadNhanVienKiem()
        'Load NhanVienKiem
        Dim dtCodeMSNV As DataTable = _db.FillDataTable("select Code, EmpName from KQQC_Code")
        If IsDBNull(GridView1.GetFocusedRowCellValue("NhanVienKiem")) Then
            Return
        End If
        Dim msnv As String = GridView1.GetFocusedRowCellValue("NhanVienKiem")
        msnv = msnv + " "

        Dim table As New DataTable
        table.Columns.Add("Code", GetType(String))
        table.Columns.Add("Name", GetType(String))

        Dim n As Integer = 0
        Dim lenChar As Integer = 0
        For index = n To msnv.Length - 1
            If msnv(index) >= "0" And msnv(index) <= "z" Then
                lenChar += 1
            ElseIf msnv(index) = " " Then
                Dim msnvNew As String = msnv.Substring(index - lenChar, lenChar)
                If msnvNew Is Nothing Or msnvNew = " " Or msnvNew = "" Then
                    Continue For
                Else
                    For i = 0 To dtCodeMSNV.Rows.Count - 1
                        If dtCodeMSNV.Rows(i).Item("Code") = msnvNew Then
                            table.Rows.Add(msnvNew, dtCodeMSNV.Rows(i).Item("EmpName"))
                            lenChar = 0
                        End If
                    Next
                End If
            End If
            n += 1
        Next

        GridControl3.DataSource = table
        GridControlSetWidth(GridView3, "Code", 50)
        GridControlSetWidth(GridView3, "Name", 150)
        GridControlSetFormat(GridView3)
        GridView3.ColumnPanelRowHeight = 35
    End Sub

    Sub LaserPlasmaBHAppera()
        lcNhanDanhGia.Visible = True
        lcDanhGia.Visible = True
    End Sub
    Sub LaserPlasmaBHHide()
        lcNhanDanhGia.Visible = False
        lcDanhGia.Visible = False
    End Sub
    Sub PTHAppera()
        lcNhanDanhGiaPTH.Visible = True
        lcDanhGiaPTH.Visible = True
        lcNhanKQCross.Visible = True
        lcKQCross.Visible = True
        lcNhanDanhGiaLoHang.Visible = True
        lcDanhGiaLohang.Visible = True
    End Sub
    Sub PTHHide()
        lcNhanDanhGiaPTH.Visible = False
        lcDanhGiaPTH.Visible = False
        lcNhanKQCross.Visible = False
        lcKQCross.Visible = False
        lcNhanDanhGiaLoHang.Visible = False
        lcDanhGiaLohang.Visible = False
    End Sub

    Public Sub DanhGiaPTH()
        Dim dt As DataTable = ResultCav()
        Dim soDem As Integer = 0
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i)(1).ToString.ToUpper = "OK" Then
                soDem += 1
            End If
        Next
        If soDem = dt.Rows.Count Then
            lcDanhGiaPTH.BackColor = System.Drawing.Color.LawnGreen
            lcDanhGiaPTH.Text = "OK"
        Else
            lcDanhGiaPTH.BackColor = System.Drawing.Color.Red
            lcDanhGiaPTH.Text = "NG"
        End If

        If lcKQCross.Text = "OK" Or lcKQCross.Text = "ok" Then
            lcKQCross.Text = "OK"
            lcKQCross.BackColor = System.Drawing.Color.LawnGreen
        ElseIf lcKQCross.Text = "-" Then
            lcKQCross.BackColor = System.Drawing.Color.White
        Else
            lcKQCross.Text = "NG"
            lcKQCross.BackColor = System.Drawing.Color.Red
        End If

        If (lcDanhGiaPTH.Text = "OK" Or lcDanhGiaPTH.Text = "ok") And (lcKQCross.Text = "OK" Or lcKQCross.Text = "ok" Or lcKQCross.Text = "-") Then
            lcDanhGiaLohang.Text = "OK"
            lcDanhGiaLohang.BackColor = System.Drawing.Color.LawnGreen
        Else
            lcDanhGiaLohang.Text = "NG"
            lcDanhGiaLohang.BackColor = System.Drawing.Color.Red
        End If
    End Sub
    Function CreateTableCavNull(soLuongKiem As Integer, soTam As Integer) As DataTable
        Dim soLuongKiemTren1Tam As Integer = soLuongKiem / soTam
        Dim dt As New DataTable
        dt.Columns.Add("Số tấm")
        For i = 1 To soLuongKiemTren1Tam
            dt.Columns.Add(("Cav" + CStr(i)), GetType(String))
        Next

        For r = 0 To soTam - 1
            dt.Rows.Add()
            dt.Rows(r)(0) = "Tấm " + (r + 1).ToString
        Next

        dt.Rows.Add("Y")
        dt.Rows.Add("Z")

        Return dt
    End Function

    Private Sub GridView1_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        If cbbCongDoan.EditValue = "Laser" Or cbbCongDoan.EditValue = "Plasma" Or cbbCongDoan.EditValue = "BH" Then
            If Not IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "DanhGiaSauCung")) Then
                If GridView1.GetRowCellValue(e.RowHandle, "DanhGiaSauCung") = "NG" Then
                    e.Appearance.BackColor = Color.FromArgb(255, 204, 255)
                    'e.Appearance.ForeColor = Color.White
                End If
            End If
        ElseIf cbbCongDoan.EditValue = "PTH" Or cbbCongDoan.EditValue = "Photo-ETC" Then
            If Not IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "DanhGiaLoHang")) Then
                If GridView1.GetRowCellValue(e.RowHandle, "DanhGiaLoHang") = "NG" Then
                    e.Appearance.BackColor = Color.FromArgb(255, 204, 255)
                    'e.Appearance.ForeColor = Color.White
                End If
            End If
        End If
    End Sub

    Private Sub GridView2_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        If cbbCongDoan.EditValue = "Laser" Or cbbCongDoan.EditValue = "Plasma" Or cbbCongDoan.EditValue = "BH" Then
            If Not IsDBNull(e.CellValue) Then
                If e.CellValue = "NG" Then
                    e.Appearance.BackColor = Color.FromArgb(255, 204, 255)
                End If
            End If
        ElseIf cbbCongDoan.EditValue = "PTH" Then
            If e.Column.FieldName = "Mã lỗi" Then
                If Not IsDBNull(e.CellValue) Then
                    If e.CellValue.ToString.ToUpper <> "OK" Then
                        e.Appearance.BackColor = Color.FromArgb(255, 204, 255)
                    End If
                End If
            End If
        End If
    End Sub
End Class