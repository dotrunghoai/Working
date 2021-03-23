Imports System.Drawing
Imports System.Windows.Forms
Imports CommonDB
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports PublicUtility
Public Class FrmPTH
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _id As String = ""
    Private Sub FrmPTH_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.KeyCode = Keys.N Then
            blbiNew.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            blbiSave.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Right Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.Left Then
            SendKeys.Send("+{Tab}")
        ElseIf e.KeyCode = Keys.F5 Then
            btnShow.PerformClick()
        End If
    End Sub
    Private Sub FrmPTH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteNgay.DateTime = DateTime.Now
        Dim obj As New Main_UserRight
        obj.FormID_K = Tag
        obj.UserID_K = CurrentUser.UserID
        _db.GetObject(obj)
        If obj.IsEdit = False Then
            ViewAccess()
        End If
    End Sub
    Public Sub ViewAccess()
        blbiNew.Enabled = False
        blbiSave.Enabled = False
        blbiDelete.Enabled = False
        btnEdit.Enabled = False
    End Sub
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dteNgay.DateTime))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dteNgay.DateTime))
        para(2) = New SqlClient.SqlParameter("@PTH", "PTH")
        Dim dtPTH As DataTable = _db.ExecuteStoreProcedureTB("sp_KQQC_LoadLaserPlasmaBH", para)
        GridControl2.DataSource = dtPTH
        GridControlSetFormat(GridView2, 2)
    End Sub
    Private Sub blbiNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles blbiNew.ItemClick
        GridView1.Columns.Clear()
        EditData()
        teID.Text = ""
        _id = ""
        txtSoTo.Text = ""
        teMSSP.Text = ""
        teLot.Text = ""
        teCongDoan.Text = "PTH"
        teSoLuongKiem.Text = 0
        teThoiGianKiem.Text = 0
        teNhanVienKiem.Text = ""
        meGhiChu.Text = ""
        lcDanhGia.Text = "OK"
        teKQCross.Text = "OK"
        lcDanhGiaLoHang.Text = "OK"
    End Sub
    Function CreateID() As String
        Dim ID As String = ""
        Dim stt As String = ""
        Dim o As Object = Nothing

        Dim yyMMdd As String = Date.Now.ToString("yyMMdd")

        Dim sql As String = String.Format("SELECT RIGHT(Max(ID), 4) 
                                           FROM KQQC_PTH  
                                           WHERE ID LIKE '{0}%' ", yyMMdd)
        o = _db.ExecuteScalar(sql)

        If o IsNot DBNull.Value And o IsNot Nothing Then
            o = Convert.ToInt32(o) + 1
            stt = o.ToString.PadLeft(4, "0")
            ID = yyMMdd + stt
        Else
            ID = yyMMdd + "0001"
        End If
        Return ID
    End Function
    Function CheckSLKiem(slKiem) As Boolean
        If IsNumeric(slKiem) Then
            If slKiem > 0 And slKiem <= 50 Then
                Return True
            End If
        End If
        ShowWarning("Số lượng kiểm không hợp lệ !")
        teSoLuongKiem.Select()
        Return False
    End Function
    Private Sub teMSSP_Leave(sender As Object, e As EventArgs) Handles teMSSP.Leave
        teMSSP.Text = teMSSP.Text.PadLeft(5, "0")
    End Sub
    Private Sub meGhiChu_Leave(sender As Object, e As EventArgs) Handles meGhiChu.Leave
        blbiSave.PerformClick()
    End Sub
    Private Sub blbiSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles blbiSave.ItemClick
        If CheckSLKiem(teSoLuongKiem.Text) Then
            Dim obj As New KQQC_PTH
            If _id = "" Then
                _id = CreateID()
                obj.ID_K = _id
                teID.Text = _id
            Else
                obj.ID_K = _id
                _db.GetObject(obj)
            End If

            Dim objWT As New WT_Product
            objWT.ProductCode_K = teMSSP.Text.PadLeft(5, "0")
            If _db.ExistObject(objWT) Then
                _db.GetObject(objWT)
                obj.KhachHang = objWT.CustomerName
                obj.Method = objWT.Method
            End If

            obj.Ngay = dteNgay.DateTime
            obj.MSSP = teMSSP.Text
            obj.SoTo = txtSoTo.Text
            obj.Lot = teLot.Text
            obj.CongDoan = teCongDoan.EditValue
            obj.TanSo = cbbTanSo.EditValue
            obj.SoChuyenGC = cbbSoChuyenGC.EditValue
            obj.SoLuongKiem = teSoLuongKiem.Text
            obj.ThoiGianKiem = teThoiGianKiem.Text
            obj.NhanVienKiem = teNhanVienKiem.Text
            obj.GhiChu = meGhiChu.Text
            obj.CreateUser = CurrentUser.UserID
            obj.CreateDate = DateTime.Now
            obj.DanhGia = lcDanhGia.Text
            obj.KQCross = teKQCross.Text
            obj.DanhGiaLoHang = lcDanhGiaLoHang.Text

            If _db.ExistObject(obj) Then
                _db.Update(obj)
            Else
                _db.Insert(obj)
                CreateNewCavity(obj.SoLuongKiem)
                UpdateCav()
                btnShow.PerformClick()
            End If
        End If
    End Sub
    Sub CreateNewCavity(slKiem)
        GridView1.Columns.Clear()
        Dim dtCav As New DataTable
        dtCav.Columns.Add("Cav", GetType(String))
        dtCav.Columns.Add("Mã lỗi", GetType(String))
        dtCav.Columns.Add("Số lượng", GetType(Integer))
        For i = 0 To slKiem - 1
            dtCav.Rows.Add()
            dtCav.Rows(i)("Cav") = "Cav" + CStr(i + 1)
            dtCav.Rows(i)("Mã lỗi") = "OK"
        Next
        GridControl1.DataSource = dtCav
        GridControlSetFormat(GridView1)
        GridControlSetWidth(GridView1, 100)
        GridControlReadOnly(GridView1, False)
        GridView1.Columns("Cav").OptionsColumn.ReadOnly = True
        GridControlSetColorEdit(GridView1)
        GridView1.OptionsView.ShowFooter = False

        'Tạo combobox
        Dim riErr As New RepositoryItemComboBox
        riErr.Items.AddRange({"OK", "A", "B1", "B2", "B3", "B4", "B5", "C", "D1", "D2", "E", "F1", "F2", "F3", "G1", "G2", "H", "I1", "I2"})
        riErr.DropDownRows = 20
        GridView1.Columns("Mã lỗi").ColumnEdit = riErr
    End Sub

    Private Sub UpdateCav()
        Dim dtCav As DataTable = ResultCav()
        For i = 0 To dtCav.Rows.Count - 1
            If dtCav.Rows(i)("Mã lỗi").ToString.ToUpper = "OK" Then
                _db.ExecuteNonQuery(String.Format("UPDATE KQQC_PTH 
                                                   SET MaLoiCav{0} = 'OK' 
                                                   WHERE ID = '{1}'",
                                                   (i + 1),
                                                   _id))
            Else
                _db.ExecuteNonQuery(String.Format("UPDATE KQQC_PTH 
                                                   SET MaLoiCav{0} = '{1}' 
                                                   WHERE ID = '{2}'",
                                                   (i + 1),
                                                   dtCav.Rows(i)("Mã lỗi"),
                                                   _id))
            End If

            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", dtCav.Rows(i)("Số lượng"))
            _db.ExecuteNonQuery(String.Format("UPDATE KQQC_PTH
                                               SET SoLuongLoiCav{0} = @Value 
                                               WHERE ID = '{1}'",
                                               (i + 1),
                                               _id), para)
        Next
    End Sub
    Private Function ResultCav() As DataTable
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
    Public Sub DanhGiaErr()
        Dim dtCav As DataTable = ResultCav()
        Dim isErr As Boolean = False
        For Each r As DataRow In dtCav.Rows
            If r("Mã lỗi").ToString.ToUpper <> "OK" Then
                isErr = True
                Exit For
            End If
        Next

        Dim obj As New KQQC_PTH
        obj.ID_K = _id
        _db.GetObject(obj)
        If isErr Then
            lcDanhGia.BackColor = Color.Red
            lcDanhGia.Text = "NG"
            obj.DanhGia = "NG"
        Else
            lcDanhGia.BackColor = Color.LawnGreen
            lcDanhGia.Text = "OK"
            obj.DanhGia = "OK"
        End If
        _db.Update(obj)

    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        UpdateCav()
        DanhGiaErr()
        DanhGiaTong()
        Dim rowHandle As Integer = GridView2.LocateByValue("ID", _id)
        If GridView1.FocusedColumn.FieldName = "Mã lỗi" Then
            GridView2.SetRowCellValue(rowHandle, "MaLoiCav" + CStr(e.RowHandle + 1), e.Value)
        ElseIf GridView1.FocusedColumn.FieldName = "Số lượng" Then
            GridView2.SetRowCellValue(rowHandle, "SoLuongLoiCav" + CStr(e.RowHandle + 1), e.Value)
        End If
        SetGridViewColumnDanhGia()
    End Sub

    Private Sub blbiDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles blbiDelete.ItemClick
        If ShowQuestionDelete() = DialogResult.Yes Then
            Dim obj As New KQQC_PTH
            obj.ID_K = GridView2.GetFocusedRowCellValue("ID")
            _db.Delete(obj)
            GridView2.DeleteSelectedRows()
            GridView1.Columns.Clear()
            teID.Text = ""
            _id = ""
        End If
    End Sub


    Private Sub GridView2_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView2.RowClick
        GridView1.Columns.Clear()
        _id = GridView2.GetFocusedRowCellValue("ID")
        teID.Text = _id
        Dim obj As New KQQC_PTH
        obj.ID_K = _id
        _db.GetObject(obj)
        dteNgay.EditValue = obj.Ngay
        teMSSP.Text = obj.MSSP
        txtSoTo.Text = obj.SoTo
        teLot.Text = obj.Lot
        teCongDoan.EditValue = obj.CongDoan
        cbbTanSo.EditValue = obj.TanSo
        cbbSoChuyenGC.EditValue = obj.SoChuyenGC
        teSoLuongKiem.Text = obj.SoLuongKiem
        teThoiGianKiem.Text = obj.ThoiGianKiem
        teNhanVienKiem.Text = obj.NhanVienKiem
        meGhiChu.Text = obj.GhiChu
        lcDanhGia.Text = obj.DanhGia
        teKQCross.Text = obj.KQCross
        lcDanhGiaLoHang.Text = obj.DanhGiaLoHang

        Dim dtCav As New DataTable
        dtCav.Columns.Add("Cav", GetType(String))
        dtCav.Columns.Add("Mã lỗi", GetType(String))
        dtCav.Columns.Add("Số lượng", GetType(Integer))
        For i = 0 To obj.SoLuongKiem - 1
            dtCav.Rows.Add()
            dtCav.Rows(i)("Cav") = "Cav" + CStr(i + 1)
            dtCav.Rows(i)("Mã lỗi") = GridView2.GetFocusedRowCellValue("MaLoiCav" + CStr(i + 1))
            dtCav.Rows(i)("Số lượng") = GridView2.GetFocusedRowCellValue("SoLuongLoiCav" + CStr(i + 1))
        Next
        GridControl1.DataSource = dtCav
        GridControlSetFormat(GridView1, 0)
        GridControlSetWidth(GridView1, 100)
        GridView1.OptionsView.ShowFooter = False

        Dim riErr As New RepositoryItemComboBox()
        riErr.Items.AddRange({"OK", "A", "B1", "B2", "B3", "B4", "B5", "C", "D1", "D2", "E", "F1", "F2", "F3", "G1", "G2", "H", "I1", "I2"})
        riErr.DropDownRows = 20
        GridView1.Columns(1).ColumnEdit = riErr

        If lcDanhGia.Text = "OK" Then
            lcDanhGia.BackColor = Color.LawnGreen
        Else
            lcDanhGia.BackColor = Color.Red
        End If

        If teKQCross.Text.ToUpper = "OK" Then
            teKQCross.BackColor = Color.LawnGreen
        ElseIf teKQCross.Text = "-" Then
            teKQCross.BackColor = Color.White
        Else
            teKQCross.BackColor = Color.Red
        End If

        If lcDanhGiaLoHang.Text = "OK" Then
            lcDanhGiaLoHang.BackColor = Color.LawnGreen
        Else
            lcDanhGiaLoHang.BackColor = Color.Red
        End If

        ReadOnlyData()
    End Sub

    Private Sub blbiExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles blbiExport.ItemClick
        GridControlExportExcel(GridView2)
    End Sub
    Private Sub teKQCross_EditValueChanged(sender As Object, e As EventArgs) Handles teKQCross.EditValueChanged
        DanhGiaTong()
        SetGridViewColumnDanhGia()
    End Sub
    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        EditData()
    End Sub
    Sub ReadOnlyData()
        dteNgay.ReadOnly = True
        txtSoTo.ReadOnly = True
        teMSSP.ReadOnly = True
        teLot.ReadOnly = True
        cbbTanSo.ReadOnly = True
        cbbSoChuyenGC.ReadOnly = True
        teSoLuongKiem.ReadOnly = True
        teThoiGianKiem.ReadOnly = True
        teNhanVienKiem.ReadOnly = True
        meGhiChu.ReadOnly = True
        teKQCross.ReadOnly = True
        If GridView1.RowCount > 0 Then
            GridControlReadOnly(GridView1, True)
            GridControlSetColorReadonly(GridView1)
            GridView1.OptionsView.ShowFooter = False
        End If
    End Sub
    Sub EditData()
        dteNgay.ReadOnly = False
        txtSoTo.ReadOnly = False
        teMSSP.ReadOnly = False
        teLot.ReadOnly = False
        cbbTanSo.ReadOnly = False
        cbbSoChuyenGC.ReadOnly = False
        teSoLuongKiem.ReadOnly = False
        teThoiGianKiem.ReadOnly = False
        teNhanVienKiem.ReadOnly = False
        meGhiChu.ReadOnly = False
        teKQCross.ReadOnly = False
        If GridView1.Columns("Cav") IsNot Nothing Then
            GridControlReadOnly(GridView1, False)
            GridView1.Columns("Cav").OptionsColumn.ReadOnly = True
            GridControlSetColorEdit(GridView1)
            GridView1.OptionsView.ShowFooter = False
        End If
    End Sub
    Sub DanhGiaTong()
        Dim obj As New KQQC_PTH
        obj.ID_K = _id
        _db.GetObject(obj)

        If lcDanhGia.Text = "OK" Then
            obj.DanhGia = "OK"
            lcDanhGia.BackColor = Color.LawnGreen
        Else
            obj.DanhGia = "NG"
            lcDanhGia.BackColor = Color.Red
        End If

        If teKQCross.Text.ToUpper = "OK" Then
            obj.KQCross = "OK"
            teKQCross.BackColor = Color.LawnGreen
        ElseIf teKQCross.Text = "-" Then
            obj.KQCross = "-"
            teKQCross.BackColor = Color.White
        Else
            obj.KQCross = "NG"
            teKQCross.BackColor = Color.Red
        End If

        If lcDanhGia.Text = "OK" And (teKQCross.Text.ToUpper = "OK" Or teKQCross.Text = "-") Then
            obj.DanhGiaLoHang = "OK"
            lcDanhGiaLoHang.Text = "OK"
            lcDanhGiaLoHang.BackColor = Color.LawnGreen
        Else
            obj.DanhGiaLoHang = "NG"
            lcDanhGiaLoHang.Text = "NG"
            lcDanhGiaLoHang.BackColor = Color.Red
        End If
        _db.Update(obj)
    End Sub
    Sub SetGridViewColumnDanhGia()
        Dim row As Integer = GridView2.LocateByValue("ID", _id)
        GridView2.SetRowCellValue(row, "DanhGia", lcDanhGia.Text)
        GridView2.SetRowCellValue(row, "KQCross", teKQCross.Text.ToUpper)
        GridView2.SetRowCellValue(row, "DanhGiaLoHang", lcDanhGiaLoHang.Text)
    End Sub

    Private Sub GridView2_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView2.RowStyle
        If GridView2.GetRowCellValue(e.RowHandle, "DanhGiaLoHang") = "NG" Then
            e.Appearance.BackColor = Color.Red
            e.Appearance.ForeColor = Color.White
        End If
    End Sub
End Class