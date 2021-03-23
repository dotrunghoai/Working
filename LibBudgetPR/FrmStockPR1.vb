Imports System.IO
Imports CommonDB
Imports PublicUtility
Imports DevExpress.XtraEditors.XtraForm
Imports DevExpress.XtraGrid.Views.Grid

Public Class FrmStockPR1
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim myPath As String = CurrentUser.TempFolder & "PR1_Budget\"
    Private Sub FrmStockPR1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShow.PerformClick()
    End Sub
    Private Sub FrmStockPR1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Right Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.FillDataTable("select * from PCM_PR1_Budget where len (ItemCode) <> 6 order by ItemCode asc")
        GridControlSetFormat(BandedGridView1, 1)
        GridControlSetColorReadonly(BandedGridView1)
        GridControlSetFormatNumber(BandedGridView1, "TonCuoi", 1)
        BandedGridView1.Columns("Picture").ColumnEdit = GridControlLinkEdit()
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        GridControlReadOnly(BandedGridView1, False)
        BandedGridView1.Columns("ItemCode").OptionsColumn.ReadOnly = True
        BandedGridView1.Columns("TonCuoi").OptionsColumn.ReadOnly = True
        BandedGridView1.Columns("Picture").OptionsColumn.ReadOnly = True
        GridControlSetColorEdit(BandedGridView1)
    End Sub

    Private Sub BandedGridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles BandedGridView1.RowClick
        If BandedGridView1.FocusedColumn.FieldName = "Picture" Then
            Dim objPic As New PCM_PR1_Budget
            objPic.ItemCode_K = BandedGridView1.GetFocusedRowCellValue("ItemCode")
            _db.GetObject(objPic)
            If objPic.Picture <> "" Then
                Process.Start(OpenfileTemp(objPic.PictureLink))
            End If
        Else
            txtJCode.Text = BandedGridView1.GetFocusedRowCellValue("ItemCode")
            Dim obj As New PCM_PR1_Budget
            obj.ItemCode_K = BandedGridView1.GetFocusedRowCellValue("ItemCode")
            _db.GetObject(obj)
            If obj.ItemNameV <> "" Then
                txtNameV.Text = BandedGridView1.GetFocusedRowCellValue("ItemNameV")
            End If
            If IsNumeric(obj.TonDau) Then
                txtTonDau.Text = obj.TonDau
            Else
                txtTonDau.Text = 0
            End If

            Dim para(3) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@StartDate", "20200401")
            para(1) = New SqlClient.SqlParameter("@EndDate", DateTime.Now.ToString("yyyyMMdd"))
            para(2) = New SqlClient.SqlParameter("@JCode", BandedGridView1.GetFocusedRowCellValue("ItemCode"))
            para(3) = New SqlClient.SqlParameter("@Action", "")
            GridControl2.DataSource = _db.ExecuteStoreProcedureTB("sp_PCM_PR1_NhapXuat", para)
            GridControlSetFormat(BandedGridView2)
            GridControlSetFormatNumber(BandedGridView2, "QTY", 1)

            GridControl3.DataSource = _db.FillDataTable(String.Format("select * from PCM_PR1_NhapXuat 
                                                                    where ItemCode = '{0}' 
                                                                    order by NgayXuat desc",
                                                                    BandedGridView1.GetFocusedRowCellValue("ItemCode")))
            GridControlSetFormat(BandedGridView3)
            GridControlSetColorReadonly(BandedGridView3)

            para(3) = New SqlClient.SqlParameter("@Action", "LaySum")
            Dim SoNhap As Decimal = IIf(IsDBNull(_db.ExecuteStoreProcedureTB("sp_PCM_PR1_NhapXuat", para).Rows(0)(0)), 0,
                                                _db.ExecuteStoreProcedureTB("sp_PCM_PR1_NhapXuat", para).Rows(0)(0))
            Dim SoXuat As Decimal = IIf(IsDBNull(_db.FillDataTable(String.Format("SELECT SUM(SoLuongXuat) 
                                                    FROM PCM_PR1_NhapXuat
                                                    WHERE ItemCode = '{0}'",
                                                    BandedGridView1.GetFocusedRowCellValue("ItemCode"))).Rows(0)(0)), 0,
                                                    _db.FillDataTable(String.Format("SELECT SUM(SoLuongXuat) 
                                                    FROM PCM_PR1_NhapXuat
                                                    WHERE ItemCode = '{0}'",
                                                    BandedGridView1.GetFocusedRowCellValue("ItemCode"))).Rows(0)(0))
            _db.GetObject(obj)
            obj.TonCuoi = IIf(IsNumeric(obj.TonDau), obj.TonDau, 0) + SoNhap - SoXuat
            _db.Update(obj)
            txtTonCuoi.Text = Math.Round((IIf(IsNumeric(obj.TonDau), obj.TonDau, 0) + SoNhap - SoXuat), 1)
            'mmeTonCuoi.Text = IIf(IsNumeric(obj.TonCuoi), obj.TonCuoi, 0)
        End If
    End Sub

    Private Sub btnXuat_Click(sender As Object, e As EventArgs) Handles btnXuat.Click
        If txtJCode.Text <> "" Then
            GridControlReadOnly(BandedGridView3, False)
            GridControlSetColorEdit(BandedGridView3)
            BandedGridView3.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        End If
    End Sub

    Private Sub BandedGridView3_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BandedGridView3.CellValueChanged
        If e.RowHandle < 0 Then
            If e.Column.FieldName = "NgayXuat" Then
                Dim obj As New PCM_PR1_NhapXuat
                obj.ItemCode_K = txtJCode.Text
                If IsDBNull(BandedGridView3.GetFocusedRowCellValue("NgayXuat")) = False Then
                    obj.NgayXuat_K = BandedGridView3.GetFocusedRowCellValue("NgayXuat")
                Else
                    Return
                End If
                obj.SoLuongXuat = IIf(IsDBNull(BandedGridView3.GetFocusedRowCellValue("SoLuongXuat")), 0, BandedGridView3.GetFocusedRowCellValue("SoLuongXuat"))
                If _db.ExistObject(obj) Then
                    _db.Update(obj)
                Else
                    _db.Insert(obj)
                End If

                CapNhatTonCuoi()
            Else
                If IsDBNull(BandedGridView3.GetFocusedRowCellValue("NgayXuat")) Then
                    ShowWarning("Bạn phải nhập ngày trước !")
                    GridControl3.DataSource = _db.FillDataTable(String.Format("select * from PCM_PR1_NhapXuat 
                                                                    where ItemCode = '{0}' 
                                                                    order by NgayXuat desc",
                                                                BandedGridView1.GetFocusedRowCellValue("ItemCode")))
                    Return
                Else
                    CellGridChanged()
                End If
            End If
        Else
            CellGridChanged()
        End If
    End Sub

    Sub CellGridChanged()
        If txtJCode.Text <> "" Then
            Dim obj As New PCM_PR1_NhapXuat
            obj.ItemCode_K = txtJCode.Text
            If IsDBNull(BandedGridView3.GetFocusedRowCellValue("NgayXuat")) = False Then
                obj.NgayXuat_K = BandedGridView3.GetFocusedRowCellValue("NgayXuat")
            Else
                Return
            End If
            obj.SoLuongXuat = IIf(IsDBNull(BandedGridView3.GetFocusedRowCellValue("SoLuongXuat")), 0, BandedGridView3.GetFocusedRowCellValue("SoLuongXuat"))
            obj.Process = IIf(IsDBNull(BandedGridView3.GetFocusedRowCellValue("Process")), "", BandedGridView3.GetFocusedRowCellValue("Process"))
            obj.TenNhanVien = IIf(IsDBNull(BandedGridView3.GetFocusedRowCellValue("TenNhanVien")), "", BandedGridView3.GetFocusedRowCellValue("TenNhanVien"))
            If _db.ExistObject(obj) Then
                _db.Update(obj)
            Else
                _db.Insert(obj)
            End If

            GridControl3.DataSource = _db.FillDataTable(String.Format("select * from PCM_PR1_NhapXuat 
                                                                    where ItemCode = '{0}' 
                                                                    order by NgayXuat desc",
                                                                BandedGridView1.GetFocusedRowCellValue("ItemCode")))
            CapNhatTonCuoi()
        End If
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        If txtJCode.Text <> "" And BandedGridView3.RowCount > 0 Then
            GridControlReadOnly(BandedGridView3, False)
            GridControlSetColorEdit(BandedGridView3)
        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If Not IsDBNull(BandedGridView3.GetFocusedRowCellValue("NgayXuat")) Then
            If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu ?") = DialogResult.Yes Then
                _db.ExecuteNonQuery(String.Format("delete PCM_PR1_NhapXuat where ItemCode = '{0}' and NgayXuat = '{1}'",
                                                txtJCode.Text, BandedGridView3.GetFocusedRowCellValue("NgayXuat")))
                BandedGridView3.DeleteSelectedRows()
                CapNhatTonCuoi()
            End If
        End If
    End Sub

    Sub CapNhatTonCuoi()
        Dim objHead As New PCM_PR1_Budget
        objHead.ItemCode_K = txtJCode.Text
        _db.GetObject(objHead)

        Dim objDetail As New PCM_PR1_NhapXuat
        objDetail.ItemCode_K = txtJCode.Text
        _db.GetObject(objDetail)

        Dim para(3) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", "20200401")
        para(1) = New SqlClient.SqlParameter("@EndDate", DateTime.Now.ToString("yyyyMMdd"))
        para(2) = New SqlClient.SqlParameter("@JCode", BandedGridView1.GetFocusedRowCellValue("ItemCode"))
        para(3) = New SqlClient.SqlParameter("@Action", "LaySum")

        Dim SoNhap As Decimal = IIf(IsDBNull(_db.ExecuteStoreProcedureTB("sp_PCM_PR1_NhapXuat", para).Rows(0)(0)), 0,
                                                _db.ExecuteStoreProcedureTB("sp_PCM_PR1_NhapXuat", para).Rows(0)(0))
        Dim SoXuat As Decimal = IIf(IsDBNull(_db.FillDataTable(String.Format("SELECT SUM(SoLuongXuat) 
                                                    FROM PCM_PR1_NhapXuat
                                                    WHERE ItemCode = '{0}'",
                                                    BandedGridView1.GetFocusedRowCellValue("ItemCode"))).Rows(0)(0)), 0,
                                                    _db.FillDataTable(String.Format("SELECT SUM(SoLuongXuat) 
                                                    FROM PCM_PR1_NhapXuat
                                                    WHERE ItemCode = '{0}'",
                                                    BandedGridView1.GetFocusedRowCellValue("ItemCode"))).Rows(0)(0))
        objHead.TonCuoi = IIf(IsNumeric(objHead.TonDau), objHead.TonDau, 0) + SoNhap - SoXuat
        _db.Update(objHead)
        txtTonCuoi.Text = Math.Round(objHead.TonCuoi, 1)
    End Sub

    Private Sub txtTonDau_Leave(sender As Object, e As EventArgs) Handles txtTonDau.Leave
        If IsNumeric(txtTonDau.Text.Trim) And txtJCode.Text <> "" Then
            Dim obj As New PCM_PR1_Budget
            obj.ItemCode_K = txtJCode.Text
            _db.GetObject(obj)
            obj.TonDau = txtTonDau.Text.Trim
            _db.Update(obj)
            CapNhatTonCuoi()
        End If
    End Sub

    Private Sub BandedGridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BandedGridView1.CellValueChanged
        If BandedGridView1.Editable = True And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If e.Column.FieldName = "ItemCode" Then
                    Dim obj As New PCM_PR1_Budget
                    obj.ItemCode_K = e.Value
                    If _db.ExistObject(obj) Then
                        _db.Update(obj)
                    Else
                        _db.Insert(obj)
                    End If
                Else
                    If IsDBNull(BandedGridView1.GetFocusedRowCellValue("ItemCode")) Then
                        ShowWarning("Bạn phải nhập mã code trước !")
                        Return
                    Else
                        Dim para(0) As SqlClient.SqlParameter
                        para(0) = New SqlClient.SqlParameter("@Value", e.Value)
                        Dim sql As String = String.Format("update PCM_PR1_Budget set {0} = @Value where ItemCode = '{1}'", e.Column.FieldName, BandedGridView1.GetFocusedRowCellValue("ItemCode"))
                        _db.ExecuteNonQuery(sql, para)
                    End If
                End If
            Else
                If e.Column.FieldName = "ItemCode" Then
                    _db.ExecuteNonQuery(String.Format("update PCM_PR1_Budget set ItemCode = '{0}' 
                                                        where ItemCode = '{1}'", e.Value, BandedGridView1.ActiveEditor.OldEditValue))
                Else
                    Dim para(0) As SqlClient.SqlParameter
                    para(0) = New SqlClient.SqlParameter("@Value", e.Value)
                    Dim sql As String = String.Format("update PCM_PR1_Budget set {0} = @Value where ItemCode = '{1}'", e.Column.FieldName, BandedGridView1.GetFocusedRowCellValue("ItemCode"))
                    _db.ExecuteNonQuery(sql, para)
                End If
            End If
        End If
    End Sub

    Private Sub AddFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddFileToolStripMenuItem.Click
        Dim frm As New OpenFileDialog
        frm.ShowDialog()
        If frm.FileName <> "" Then
            Dim obj As New PCM_PR1_Budget
            obj.ItemCode_K = BandedGridView1.GetFocusedRowCellValue("ItemCode")
            _db.GetObject(obj)
            obj.Picture = frm.SafeFileName
            obj.PictureLink = myPath & obj.ItemCode_K & "_PR1_Budget_" & frm.SafeFileName
            File.Copy(frm.FileName, obj.PictureLink, True)
            BandedGridView1.SetFocusedRowCellValue("Picture", frm.SafeFileName)
            BandedGridView1.SetFocusedRowCellValue("PictureLink", obj.PictureLink)
            _db.Update(obj)
        End If
        frm.Dispose()
    End Sub

    Private Sub DeleteFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteFileToolStripMenuItem.Click
        If BandedGridView1.GetFocusedRowCellValue("Picture") <> "" Then
            BandedGridView1.SetFocusedRowCellValue("Picture", "")
            Dim obj As New PCM_PR1_Budget
            obj.ItemCode_K = BandedGridView1.GetFocusedRowCellValue("ItemCode")
            _db.GetObject(obj)
            File.Delete(obj.PictureLink)
            obj.Picture = ""
            obj.PictureLink = ""
            _db.Update(obj)
        End If
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        BandedGridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridControlReadOnly(BandedGridView1, False)
        BandedGridView1.Columns("Picture").OptionsColumn.ReadOnly = True
        BandedGridView1.Columns("TonCuoi").OptionsColumn.ReadOnly = True
        GridControlSetColorEdit(BandedGridView1)
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu ?") = DialogResult.Yes Then
            _db.ExecuteNonQuery(String.Format("delete PCM_PR1_Budget where ItemCode = '{0}'", BandedGridView1.GetFocusedRowCellValue("ItemCode")))
            BandedGridView1.DeleteSelectedRows()
        End If
    End Sub
    Public Sub ViewAccess()
        btnEdit.Enabled = False
        btnNew.Enabled = False
        btnDelete.Enabled = False
        btnXuat.Enabled = False
        btnSua.Enabled = False
        btnXoa.Enabled = False
        txtTonDau.ReadOnly = True
        AddFileToolStripMenuItem.Enabled = False
        DeleteFileToolStripMenuItem.Enabled = False
    End Sub
    Private Sub FrmStockPR1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim MainUser As New Main_UserRight
        MainUser.FormID_K = Tag
        MainUser.UserID_K = CurrentUser.UserID
        _db.GetObject(MainUser)
        If MainUser.IsEdit <> "1" Then
            ViewAccess()
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        Dim listGrid As New List(Of GridView)
        listGrid.Add(BandedGridView1)
        If BandedGridView2.RowCount > 0 Then
            listGrid.Add(BandedGridView2)
        End If
        If BandedGridView3.RowCount > 0 Then
            listGrid.Add(BandedGridView3)
        End If
        GridControlExportExcels(listGrid)
    End Sub
End Class