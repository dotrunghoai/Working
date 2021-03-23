Imports PublicUtility
Imports CommonDB
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Columns
Imports System.Drawing

Public Class FrmLaserPlasmaBH
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _idGlobal As String = ""
    Private Sub FrmLaserPlasmaBH_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.KeyCode = Keys.N Then
            blbiNew.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            blbiSave.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Right Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.Left Then
            SendKeys.Send("+{Tab}")
        ElseIf e.KeyCode = Keys.F5 Then
            blbiShow.PerformClick()
        End If
    End Sub
    Private Sub FrmLaserPlasmaBH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        blbiNew.PerformClick()
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
    End Sub

    Private Sub blbiShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles blbiShow.ItemClick
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dteNgay.DateTime))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dteNgay.DateTime))
        GridControl2.DataSource = _db.FillDataTable("SELECT * FROM 
                                                     KQQC_LaserPlasmaBH 
                                                     WHERE Ngay BETWEEN @StartDate AND @EndDate 
                                                     ORDER BY ID DESC", para)
        GridControlSetFormat(GridView2, 1)
    End Sub
    Function CreateID() As String
        Dim val As Object = _db.ExecuteScalar(String.Format("SELECT Right(MAX(ID), 4)
                                                             FROM KQQC_LaserPlasmaBH
                                                             WHERE ID LIKE '{0}%'",
                                                             Date.Now.ToString("yyMMdd")))
        If Not IsDBNull(val) Then
            val = (Integer.Parse(val) + 1).ToString.PadLeft(4, "0")
            Return Date.Now.ToString("yyMMdd") + val
        Else
            Return Date.Now.ToString("yyMMdd") + "0001"
        End If
    End Function
    Private Sub teMSSP_Leave(sender As Object, e As EventArgs) Handles teMSSP.Leave
        teMSSP.Text = teMSSP.Text.PadLeft(5, "0")
    End Sub
    Function CheckSoLuong() As Boolean
        If IsNumeric(teSoLuongKiem.Text) And IsNumeric(txtSoTam.Text) Then
            If Integer.TryParse((teSoLuongKiem.Text / txtSoTam.Text), True) And txtSoTam.Text <= 3 And
                teSoLuongKiem.Text > 0 And teSoLuongKiem.Text / txtSoTam.Text <= 50 Then
                Return True
            End If
        End If
        ShowWarning("Không xác định được Số lượng kiểm trên mỗi tấm !")
        Return False
    End Function
    Private Sub meGhiChu_Leave(sender As Object, e As EventArgs) Handles meGhiChu.Leave
        blbiSave.PerformClick()
    End Sub

    Private Sub blbiSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles blbiSave.ItemClick
        If CheckSoLuong() Then
            Dim obj As New KQQC_LaserPlasmaBH
            If _idGlobal = "" Then
                _idGlobal = CreateID()
                obj.ID_K = _idGlobal
                teID.Text = _idGlobal
            Else
                obj.ID_K = _idGlobal
                _db.GetObject(obj)
            End If

            obj.Ngay = dteNgay.DateTime
            obj.SoTo = txtSoTo.Text
            obj.MSSP = teMSSP.Text

            Dim objProd As New WT_Product
            objProd.ProductCode_K = teMSSP.Text
            If _db.ExistObject(objProd) Then
                _db.GetObject(objProd)
                obj.KhachHang = objProd.CustomerName
                obj.Method = objProd.Method
            End If

            obj.Lot = teLot.Text
            obj.SoLanTest = txtSoLanTest.Text
            obj.CongDoan = cbbCongDoan.EditValue
            obj.TanSo = cbbTanSo.EditValue
            obj.SoMayGC = cbbSoMayGC.EditValue
            obj.SoLuongKiem = teSoLuongKiem.Text
            obj.SoTam = txtSoTam.Text
            obj.ThoiGianKiem = teThoiGianKiem.Text
            obj.NhanVienKiem = teNhanVienKiem.Text
            obj.GhiChu = meGhiChu.Text
            obj.CreateUser = CurrentUser.UserID
            obj.CreateDate = DateTime.Now
            obj.DanhGiaSauCung = lcDanhGia.Text

            If _db.ExistObject(obj) Then
                _db.Update(obj)
            Else
                _db.Insert(obj)

                GridView1.Columns.Clear()
                GridControl1.DataSource = CreateNewCav(obj.SoLuongKiem, obj.SoTam)
                GridControlSetFormat(GridView1, 0)
                GridControlReadOnly(GridView1, False)
                GridView1.Columns("Số tấm").OptionsColumn.ReadOnly = True
                GridControlSetColorEdit(GridView1)
                GridControlSetWidth(GridView1, 50)

                InsertNewCav()
                blbiShow.PerformClick()
            End If
        End If
    End Sub
    Function CreateNewCav(soLuongKiem As Integer, soTam As Integer) As DataTable
        Dim soLuongKiemTren1Tam As Integer = soLuongKiem / soTam
        Dim dtSLKiem As New DataTable
        dtSLKiem.Columns.Add("Số tấm")
        For i = 1 To soLuongKiemTren1Tam
            dtSLKiem.Columns.Add("Cav" + CStr(i))
        Next

        For r = 0 To soTam - 1
            dtSLKiem.Rows.Add()
            dtSLKiem.Rows(r)(0) = "Tấm " + CStr(r + 1)
        Next

        For r = 0 To dtSLKiem.Rows.Count - 1
            For c = 1 To dtSLKiem.Columns.Count - 1
                dtSLKiem.Rows(r)(c) = "OK"
            Next
        Next

        dtSLKiem.Rows.Add("Y", "OK")
        dtSLKiem.Rows.Add("Z", "OK")

        Return dtSLKiem
    End Function

    Private Sub blbiDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles blbiDelete.ItemClick
        If ShowQuestionDelete() = DialogResult.Yes Then
            Dim obj As New KQQC_LaserPlasmaBH
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

    Private Sub blbiNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles blbiNew.ItemClick
        _idGlobal = ""
        teID.Text = ""
        txtSoTo.Text = ""
        teMSSP.Text = ""
        teLot.Text = ""
        txtSoLanTest.Text = 0
        teSoLuongKiem.Text = 0
        txtSoTam.Text = 0
        teThoiGianKiem.Text = 0
        teNhanVienKiem.Text = ""
        meGhiChu.Text = ""
        lcDanhGia.Text = "OK"
        GridView1.Columns.Clear()
        dteNgay.Select()
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

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            If e.Column.FieldName >= "Cav2" And
                (GridView1.GetFocusedRowCellValue("Số tấm") = "Y" Or GridView1.GetFocusedRowCellValue("Số tấm") = "Z") Then
                ShowWarning("Cột không hợp lệ !")
            Else
                Dim val = e.Value.ToString.ToUpper
                If GridView1.GetFocusedRowCellValue("Số tấm").ToString.Contains("T") Then
                    Dim colGrid = GridView1.GetFocusedRowCellValue("Số tấm").ToString
                    Dim col = "T" + colGrid.Substring(colGrid.Length - 1, 1) + e.Column.FieldName
                    _db.ExecuteNonQuery(String.Format("UPDATE KQQC_LaserPlasmaBH
                                                       SET {0} = '{1}'
                                                       WHERE ID = '{2}'",
                                                       col, val, _idGlobal))
                Else
                    _db.ExecuteNonQuery(String.Format("UPDATE KQQC_LaserPlasmaBH
                                                       SET {0} = '{1}'
                                                       WHERE ID = '{2}'",
                                                       GridView1.GetFocusedRowCellValue("Số tấm"),
                                                       val, _idGlobal))
                End If
                DanhGia()

                Dim rowHandle As Integer = GridView2.LocateByValue("ID", _idGlobal)
                GridView2.SetRowCellValue(rowHandle, "DanhGiaSauCung", lcDanhGia.Text)
                Dim colChange As String = ""
                If GridView1.FocusedRowHandle < GridView1.RowCount - 2 Then
                    Dim soTam As String = GridView1.GetFocusedRowCellValue("Số tấm")
                    soTam = soTam.Substring(soTam.Length - 1)
                    colChange = "T" + soTam + e.Column.FieldName
                Else
                    colChange = GridView1.GetFocusedRowCellValue("Số tấm")
                End If
                GridView2.SetRowCellValue(rowHandle, colChange, e.Value.ToString.ToUpper)
            End If
        End If
    End Sub

    Private Sub GridView2_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView2.RowClick
        GridView1.Columns.Clear()
        Dim obj As New KQQC_LaserPlasmaBH
        obj.ID_K = GridView2.GetFocusedRowCellValue("ID")
        _db.GetObject(obj)
        _idGlobal = obj.ID_K
        teID.Text = obj.ID_K
        dteNgay.DateTime = obj.Ngay
        txtSoTo.Text = obj.SoTo
        teMSSP.Text = obj.MSSP
        teLot.Text = obj.Lot
        txtSoLanTest.Text = obj.SoLanTest
        cbbCongDoan.EditValue = obj.CongDoan
        cbbTanSo.EditValue = obj.TanSo
        cbbSoMayGC.EditValue = obj.SoMayGC
        teSoLuongKiem.Text = obj.SoLuongKiem
        txtSoTam.Text = obj.SoTam
        teThoiGianKiem.Text = obj.ThoiGianKiem
        teNhanVienKiem.Text = obj.NhanVienKiem
        meGhiChu.Text = obj.GhiChu

        If obj.DanhGiaSauCung = "OK" Then
            lcDanhGia.BackColor = Color.LawnGreen
            lcDanhGia.Text = "OK"
        Else
            lcDanhGia.BackColor = Color.Red
            lcDanhGia.Text = "NG"
        End If

        Dim dtCav As DataTable = CreateTableCavNull(obj.SoLuongKiem, obj.SoTam)
        For r = 0 To dtCav.Rows.Count - 3
            For c = 1 To dtCav.Columns.Count - 1
                dtCav.Rows(r)(c) = GridView2.GetFocusedRowCellValue("T" + CStr(r + 1) + "Cav" + CStr(c))
            Next
        Next
        'Ké cột Cav1 để lấy giá trị cho Y/Z
        dtCav.Rows(dtCav.Rows.Count - 2)("Cav1") = GridView2.GetFocusedRowCellValue("Y")
        dtCav.Rows(dtCav.Rows.Count - 1)("Cav1") = GridView2.GetFocusedRowCellValue("Z")

        GridControl1.DataSource = dtCav
        GridControlSetFormat(GridView1, 0)
        GridControlReadOnly(GridView1, False)
        GridView1.Columns("Số tấm").OptionsColumn.ReadOnly = True
        GridControlSetColorEdit(GridView1)
        GridControlSetWidth(GridView1, 50)
    End Sub
    Sub InsertNewCav()
        Dim dtCav As DataTable = ResultCav()
        For r = 0 To dtCav.Rows.Count - 3
            For c = 1 To dtCav.Columns.Count - 1
                Dim col As String = "T" + CStr(r + 1) + "Cav" + CStr(c)
                _db.ExecuteNonQuery(String.Format("UPDATE KQQC_LaserPlasmaBH 
                                                   SET {0} = 'OK' 
                                                   WHERE ID = '{1}'",
                                                   col,
                                                   _idGlobal))
            Next
        Next

        Dim obj As New KQQC_LaserPlasmaBH
        obj.ID_K = _idGlobal
        _db.GetObject(obj)
        obj.Y = "OK"
        obj.Z = "OK"
        _db.Update(obj)
    End Sub

    Public Sub DanhGia()
        Dim dtCav As DataTable = ResultCav()
        Dim isErr As Boolean = False

        For r = 0 To dtCav.Rows.Count - 3
            For c = 1 To dtCav.Columns.Count - 1
                If dtCav.Rows(r)(c).ToString.ToUpper <> "OK" Then
                    isErr = True
                    GoTo Result
                End If
            Next
        Next
        'Ké cột Cav1 để lấy giá trị cho Y/Z
        If dtCav.Rows(dtCav.Rows.Count - 2)("Cav1").ToString.ToUpper <> "OK" Then
            isErr = True
            GoTo Result
        End If
        If dtCav.Rows(dtCav.Rows.Count - 1)("Cav1").ToString.ToUpper <> "OK" Then
            isErr = True
        End If
Result:
        If isErr Then
            lcDanhGia.BackColor = System.Drawing.Color.Red
            lcDanhGia.Text = "NG"
        Else
            lcDanhGia.BackColor = System.Drawing.Color.LawnGreen
            lcDanhGia.Text = "OK"
        End If

        Dim obj As New KQQC_LaserPlasmaBH
        obj.ID_K = _idGlobal
        _db.GetObject(obj)
        obj.DanhGiaSauCung = lcDanhGia.Text
        _db.Update(obj)
    End Sub

    Private Sub blbiExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles blbiExport.ItemClick
        GridControlExportExcel(GridView2)
    End Sub

    Function CreateTableCavNull(soLuongKiem As Integer, soTam As Integer) As DataTable
        Dim soLuongKiemTren1Tam As Integer = soLuongKiem / soTam
        Dim dt As New DataTable
        dt.Columns.Add("Số tấm")
        For i = 1 To soLuongKiemTren1Tam
            dt.Columns.Add("Cav" + CStr(i))
        Next
        For r = 0 To soTam - 1
            dt.Rows.Add()
            dt.Rows(r)(0) = "Tấm " + CStr(r + 1)
        Next
        dt.Rows.Add("Y")
        dt.Rows.Add("Z")
        Return dt
    End Function

    Private Sub GridView2_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView2.RowStyle
        If GridView2.GetRowCellValue(e.RowHandle, "DanhGiaSauCung") = "NG" Then
            e.Appearance.BackColor = Color.Red
            e.Appearance.ForeColor = Color.White
        End If
        'If Not IsDBNull(GridView2.GetRowCellValue(e.RowHandle, "DanhGiaSauCung")) Then
        'End If
    End Sub
End Class