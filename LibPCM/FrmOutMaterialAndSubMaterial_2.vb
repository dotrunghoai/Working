﻿Imports System.Drawing
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports CommonDB
Imports DevExpress.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports Microsoft.Office.Interop
Imports PublicUtility
Public Class FrmOutMaterialAndSubMaterial_2
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim orderDate As String
    Dim isEdit As Boolean = True

    Dim cls As New clsApplication
    Dim ColQty As String = "Qty1"

    Dim _EcodeOld As Object
    Dim _JCodeOld As Object
    Dim _SubPrcNameOld As Object

    Private Sub FrmOutMaterialAndSubMaterial_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New Main_UserRight
        obj.FormID_K = Tag
        obj.UserID_K = CurrentUser.UserID
        _db.GetObject(obj)
        If Not obj.IsEdit Then
            ViewAccess()
            isEdit = False
        End If
        dteOrderDate.DateTime = DateTime.Now
    End Sub
    Sub ViewAccess()
        txtOutputNumber.ReadOnly = True
        chbLockedTime1.ReadOnly = True
        chbLockedTime2.ReadOnly = True
        chbLockedTime3.ReadOnly = True
    End Sub

    Private Sub dteOrderDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteOrderDate.EditValueChanged
        orderDate = dteOrderDate.DateTime.ToString("yyyyMMdd")
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        Dim objlock As New PCM_LockDay
        objlock.YMD_K = orderDate
        If _db.ExistObject(objlock) Then
            _db.GetObject(objlock)
        Else
            objlock.JCodeLocked1 = True
            objlock.JCodeLocked2 = True
            objlock.JCodeLocked3 = True
            objlock.TrayLocked1 = True
            objlock.TrayLocked2 = True
            objlock.TrayLocked3 = True
            objlock.DirectLocked = True
            objlock.OutWSLocked = True
            _db.Insert(objlock)
        End If
        chbLockedTime1.Checked = objlock.JCodeLocked1
        chbLockedTime2.Checked = objlock.JCodeLocked2
        chbLockedTime3.Checked = objlock.JCodeLocked3

        Dim M1 As DateTime = DateTime.Now.AddMonths(-1)
        Dim M3 As DateTime = DateTime.Now.AddMonths(-3)
        Dim Day1 As DateTime = GetStartDayOfMonth(DateTime.Now.Date)
        Dim DayNow As DateTime = DateTime.Now

        Dim para(7) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@M1", M1.ToString("yyyyMM"))
        para(1) = New SqlClient.SqlParameter("@M3", M3.ToString("yyyyMM"))
        para(2) = New SqlClient.SqlParameter("@Day1", Day1.ToString("yyyyMMdd"))
        para(3) = New SqlClient.SqlParameter("@DayNow", DayNow.ToString("yyyyMMdd"))
        para(4) = New SqlClient.SqlParameter("@day", orderDate)
        para(5) = New SqlClient.SqlParameter("@Action", "ShowNew")
        If isEdit Then
            para(6) = New SqlClient.SqlParameter("@ECode", DBNull.Value)
        Else
            para(6) = New SqlClient.SqlParameter("@ECode", CurrentUser.UserID)
        End If
        para(7) = New SqlClient.SqlParameter("@JCodeType", chbJCodeType.Text)

        GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_PCM_OutMaterial", para)
        GridControlSetFormat(GridView1, 3)
        GridView1.Columns("JCode").Width = 100

        slueJCode.DataSource = _db.FillDataTable(String.Format("  SELECT d.DeptName, h.ECode, h.JCode, h.SubPrcName, h.PrcName,
					                                h.JEName, h.JVName, h.Unit, h.MinQty, h.StdDtbtQty AS [Định mức ngày],
					                                h.NormWeek AS [Định mức tuần], h.MonthStd AS [Định mức tháng], ISNULL(s.Qty + s.HeldQty, 0) AS [Tồn hiện tại]
			                                        FROM PCM_MterNotJCode AS h
			                                        LEFT JOIN PCM_Dept AS d
			                                        ON h.ECode = d.ECode
			                                        AND h.SubPrcName = d.SubPrcName
                                                    LEFT JOIN PCM_Stock AS s
                                                    ON h.JCode = s.JCode
			                                        WHERE (@ECode IS NULL OR h.ECode = @ECode)
                                                    UNION 
                                                    SELECT NULL, 'X', g.JCode, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL
                                                    FROM PCM_NotJCode AS g
                                                    LEFT JOIN PCM_MterNotJCode AS m
                                                    ON g.JCode = m.JCode
                                                    WHERE g.YMD = '{0}'
                                                    AND m.JCode IS NULL
			                                        ORDER BY ECode, JCode", orderDate), para)
        slueJCode.DisplayMember = "JCode"
        slueJCode.ValueMember = "JCode"
        slueJCode.NullText = Nothing
        GridView1.Columns("JCode").ColumnEdit = slueJCode
    End Sub
    Sub ColReadOnly()
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("JCode").OptionsColumn.ReadOnly = False
        GridView1.Columns("Note").OptionsColumn.ReadOnly = False
        GridView1.Columns("Adjust").OptionsColumn.ReadOnly = False
        GridView1.Columns("ReviseQty").OptionsColumn.ReadOnly = False
        GridView1.Columns("AddDtbtQty").OptionsColumn.ReadOnly = False
        GridView1.Columns("ActReceive").OptionsColumn.ReadOnly = False
        GridView1.Columns("RequestQty").OptionsColumn.ReadOnly = False
        GridView1.Columns("RequestDate").OptionsColumn.ReadOnly = False
        If isEdit Or Not chbLockedTime1.Checked Then
            GridView1.Columns("Qty1").OptionsColumn.ReadOnly = False
        End If
        If isEdit Or Not chbLockedTime2.Checked Then
            GridView1.Columns("Qty2").OptionsColumn.ReadOnly = False
        End If
        If isEdit Or Not chbLockedTime3.Checked Then
            GridView1.Columns("Qty3").OptionsColumn.ReadOnly = False
        End If
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        If GridControl1.DataSource Is Nothing Then
            btnShow.PerformClick()
        End If
        If isEdit Or Not chbLockedTime1.Checked Or Not chbLockedTime2.Checked Or Not chbLockedTime3.Checked Then
            GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            ColReadOnly()
        Else
            ShowWarning("Locked !")
        End If
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        If isEdit Or Not chbLockedTime1.Checked Or Not chbLockedTime2.Checked Or Not chbLockedTime3.Checked Then
            GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            GridControlSetColorReadonly(GridView1)
            ColReadOnly()
        Else
            ShowWarning("Locked !")
        End If
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If isEdit Or Not chbLockedTime1.Checked Or Not chbLockedTime2.Checked Or Not chbLockedTime3.Checked Then
            If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu ?") = Windows.Forms.DialogResult.Yes Then
                _db.ExecuteNonQuery(String.Format("DELETE PCM_NotJCode
                                                   WHERE YMD = '{0}'
                                                   AND ECode = '{1}'
                                                   AND JCode = '{2}'
                                                   AND SubPrcName = N'{3}'",
                                                   GridView1.GetFocusedRowCellValue("YMD"),
                                                   GridView1.GetFocusedRowCellValue("ECode"),
                                                   GridView1.GetFocusedRowCellValue("JCode"),
                                                   GridView1.GetFocusedRowCellValue("SubPrcName")))
                GridView1.DeleteSelectedRows()
            End If
        Else
            ShowWarning("Locked !")
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And Not e.Column.ReadOnly Then
            Try
                _db.BeginTransaction()
                If IsDBNull(GridView1.GetFocusedRowCellValue("JCode")) Then
                    ShowWarning("Bạn phải nhập JCode trước !")
                    btnNew.PerformClick()
                    Return
                End If
                If e.Column.FieldName = "JCode" And Not IsDBNull(GridView1.GetFocusedRowCellValue("YMD")) Then
                    'Sửa JCode (Khóa chính)
                    _db.ExecuteNonQuery(String.Format("UPDATE PCM_NotJCode
                                                   SET ECode = '{0}', 
                                                   JCode = '{1}', 
                                                   SubPrcName = N'{2}', 
                                                   PrcName = '{3}', 
                                                   DeptName = '{4}', 
                                                   JEName = '{5}',
                                                   JVName = '{6}',
                                                   Unit = '{7}',
                                                   MinQty = '{8}',
                                                   StdDtbtQty = '{9}',
                                                   NormWeek = '{10}',
                                                   NormMonth = '{11}'
                                                   WHERE YMD = '{12}'
                                                   AND ECode = '{13}'
                                                   AND JCode = '{14}'
                                                   AND SubPrcName = N'{15}'",
                                                   GridView1.GetFocusedRowCellValue("ECode"),
                                                   GridView1.GetFocusedRowCellValue("JCode"),
                                                   GridView1.GetFocusedRowCellValue("SubPrcName"),
                                                   GridView1.GetFocusedRowCellValue("PrcName"),
                                                   GridView1.GetFocusedRowCellValue("DeptName"),
                                                   GridView1.GetFocusedRowCellValue("JEName"),
                                                   GridView1.GetFocusedRowCellValue("JVName"),
                                                   GridView1.GetFocusedRowCellValue("Unit"),
                                                   GridView1.GetFocusedRowCellValue("MinQty"),
                                                   GridView1.GetFocusedRowCellValue("Định mức ngày"),
                                                   GridView1.GetFocusedRowCellValue("Định mức tuần"),
                                                   GridView1.GetFocusedRowCellValue("Định mức tháng"),
                                                   GridView1.GetFocusedRowCellValue("YMD"),
                                                   _EcodeOld, _JCodeOld, _SubPrcNameOld))
                    Return
                End If
                If e.RowHandle < 0 Then
                    If IsDBNull(GridView1.GetFocusedRowCellValue("YMD")) Then
                        Dim obj As New PCM_NotJCode
                        obj.YMD_K = orderDate
                        obj.ECode_K = GridView1.GetFocusedRowCellValue("ECode")
                        obj.JCode_K = GridView1.GetFocusedRowCellValue("JCode")
                        obj.SubPrcName_K = GridView1.GetFocusedRowCellValue("SubPrcName")
                        If _db.ExistObject(obj) Then
                            ShowWarning("JCode đã được tạo trong hôm nay, bạn không thể tạo lần 2 !")
                            Return
                        Else
                            obj.PrcName = GridView1.GetFocusedRowCellValue("PrcName")
                            obj.DeptName = GridView1.GetFocusedRowCellValue("DeptName")
                            If Not IsDBNull(GridView1.GetFocusedRowCellValue("JVName")) Then
                                obj.JVName = GridView1.GetFocusedRowCellValue("JVName")
                            End If
                            obj.JEName = GridView1.GetFocusedRowCellValue("JEName")
                            obj.Unit = GridView1.GetFocusedRowCellValue("Unit")
                            obj.MinQty = GridView1.GetFocusedRowCellValue("MinQty")
                            obj.StdDtbtQty = GridView1.GetFocusedRowCellValue("Định mức ngày")
                            obj.NormWeek = GridView1.GetFocusedRowCellValue("Định mức tuần")
                            obj.NormMonth = GridView1.GetFocusedRowCellValue("Định mức tháng")
                            obj.CreateUser = CurrentUser.UserID
                            obj.CreateDate = DateTime.Now
                            obj.PCNo = Environment.MachineName()
                            _db.Insert(obj)
                            GridView1.SetFocusedRowCellValue("YMD", obj.YMD_K)
                            GridView1.SetFocusedRowCellValue("DeptName", obj.DeptName)
                        End If
                    End If
                End If

                Dim para(0) As SqlClient.SqlParameter
                para(0) = New SqlClient.SqlParameter("@Value", e.Value)
                _db.ExecuteNonQuery(String.Format("UPDATE PCM_NotJCode
                                               SET {0} = @Value,
                                               UpdateUser = '{1}',
                                               UpdateDate = '{2}'
                                               WHERE YMD = '{3}'
                                               AND ECode = '{4}'
                                               AND JCode = '{5}'
                                               AND SubPrcName = N'{6}'",
                                               e.Column.FieldName,
                                               CurrentUser.UserID,
                                               DateTime.Now,
                                               GridView1.GetFocusedRowCellValue("YMD"),
                                               GridView1.GetFocusedRowCellValue("ECode"),
                                               GridView1.GetFocusedRowCellValue("JCode"),
                                               GridView1.GetFocusedRowCellValue("SubPrcName")), para)
                If e.Column.FieldName = "Qty1" Then
                    UpdateTime("Time1Date")
                ElseIf e.Column.FieldName = "Qty2" Then
                    UpdateTime("Time2Date")
                ElseIf e.Column.FieldName = "Qty3" Then
                    UpdateTime("Time3Date")
                End If

                'Check số lượng
                If e.Column.FieldName = "Qty1" Or e.Column.FieldName = "Qty2" Or e.Column.FieldName = "Qty3" Then
                    If CheckSoLuong(e.Value) = False Then
                        _db.RollBack()
                        ReturnOldValue(GridView1)
                        Return
                    End If
                End If
                _db.Commit()
            Catch ex As Exception
                _db.RollBack()
                ShowWarning(ex.Message)
            End Try
        End If
    End Sub

    Sub UpdateTime(col As String)
        Dim objTime As New PCM_NotJCode
        objTime.YMD_K = GridView1.GetFocusedRowCellValue("YMD")
        objTime.ECode_K = GridView1.GetFocusedRowCellValue("ECode")
        objTime.JCode_K = GridView1.GetFocusedRowCellValue("JCode")
        objTime.SubPrcName_K = GridView1.GetFocusedRowCellValue("SubPrcName")
        _db.GetObject(objTime)
        If col = "Time1Date" Then
            objTime.Time1Date = DateTime.Now
        ElseIf col = "Time2Date" Then
            objTime.Time2Date = DateTime.Now
        ElseIf col = "Time3Date" Then
            objTime.Time3Date = DateTime.Now
        End If
        _db.Update(objTime)
    End Sub
    Function CheckSoLuong(valNhap) As Boolean
        Dim obj As New PCM_NotJCode
        obj.YMD_K = GridView1.GetFocusedRowCellValue("YMD")
        obj.ECode_K = GridView1.GetFocusedRowCellValue("ECode")
        obj.JCode_K = GridView1.GetFocusedRowCellValue("JCode")
        obj.SubPrcName_K = GridView1.GetFocusedRowCellValue("SubPrcName")
        _db.GetObject(obj)

        If Not IsNumeric(txtOutputNumber.Text) Then
            'Để nhập thêm cho các ngày nghỉ
            txtOutputNumber.Text = 1
        Else
            obj.NormWeek = obj.NormWeek + (obj.StdDtbtQty * (txtOutputNumber.Text - 1))
            obj.NormMonth = obj.NormMonth + (obj.StdDtbtQty * (txtOutputNumber.Text - 1))
        End If

        Dim tonHienTai = GridView1.GetFocusedRowCellValue("Tồn hiện tại")
        If (obj.Qty1 + obj.Qty2 + obj.Qty3) > tonHienTai Then
            ShowWarning("Vượt tồn hiện tại !")
            Return False
        End If

        Dim valInDay = _db.ExecuteScalar(String.Format("SELECT ISNULL(SUM(Qty1) + SUM(Qty2) + SUM(Qty3), 0)
                                                        FROM PCM_NotJCode
                                                        WHERE YMD = '{0}'
                                                        AND JCode = '{1}'",
                                                        orderDate,
                                                        GridView1.GetFocusedRowCellValue("JCode")))
        If valInDay > tonHienTai Then
            Dim mess = "Vượt định mức trong 1 ngày !" + Environment.NewLine +
                String.Format("Chỉ có thể nhập tối đa số lượng: {0}", tonHienTai - (valInDay - valNhap))
            ShowWarning(mess)
            Return False
        End If

        If valNhap < obj.MinQty Then
            ShowWarning("Phải lớn hơn Min Quantity !")
            Return False
        End If

        If (obj.Qty1 + obj.Qty2 + obj.Qty3) > obj.StdDtbtQty * txtOutputNumber.Text Then
            ShowWarning("Vượt định mức ngày !")
            Return False
        End If

        Dim provider As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture
        Dim dateConvert As Date = Date.ParseExact(GridView1.GetFocusedRowCellValue("YMD"), "yyyyMMdd", provider)
        Dim valSumWeek As Object = _db.ExecuteScalar(String.Format("SELECT SUM(Qty1) + SUM(Qty2) + SUM(Qty3)
                                                      FROM PCM_NotJCode
                                                      WHERE YMD BETWEEN '{0}' AND '{1}' 
                                                      AND ECode = '{2}'
                                                      AND JCode = '{3}'
                                                      AND SubPrcName = N'{4}'",
                                                      FirstDayOfWeek(dateConvert).ToString("yyyyMMdd"),
                                                      LastDayOfWeek(dateConvert).ToString("yyyyMMdd"),
                                                      obj.ECode_K,
                                                      obj.JCode_K,
                                                      obj.SubPrcName_K))
        If valSumWeek > obj.NormWeek Then
            ShowWarning(String.Format("Vượt định mức tuần ! - Trong tuần đã đặt: " + (valSumWeek - valNhap).ToString))
            Return False
        End If

        Dim valSumMonth As Object = _db.ExecuteScalar(String.Format("SELECT SUM(Qty1) + SUM(Qty2) + SUM(Qty3)
                                                      FROM PCM_NotJCode
                                                      WHERE YMD BETWEEN '{0}' AND '{1}'
                                                      AND ECode = '{2}'
                                                      AND JCode = '{3}'
                                                      AND SubPrcName = N'{4}'",
                                                      GetStartDayOfMonth(dateConvert).ToString("yyyyMMdd"),
                                                      GetEndDayOfMonth(dateConvert).ToString("yyyyMMdd"),
                                                      obj.ECode_K,
                                                      obj.JCode_K,
                                                      obj.SubPrcName_K))
        If valSumMonth > obj.NormMonth Then
            ShowWarning(String.Format("Vượt định mức tháng ! - Trong tháng đã đặt: " + (valSumMonth - valNhap).ToString))
            Return False
        End If

        Return True
    End Function

    Private Sub slueJCode_EditValueChanged(sender As Object, e As EventArgs) Handles slueJCode.EditValueChanged
        Dim lc As SearchLookUpEdit = CType(sender, SearchLookUpEdit)
        If lc.Properties.View.GetFocusedRowCellValue("Tồn hiện tại") = 0 Then
            Dim oldVal As Object = GridView1.ActiveEditor.OldEditValue
            GridView1.Columns("JCode").OptionsColumn.ReadOnly = True
            GridView1.SetFocusedRowCellValue("JCode", oldVal)
            GridView1.Columns("JCode").OptionsColumn.ReadOnly = False
            ShowWarning("Tồn hiện tại không còn !")
            Return
        End If
        GridView1.SetFocusedRowCellValue("DeptName", lc.Properties.View.GetFocusedRowCellValue("DeptName"))
        GridView1.SetFocusedRowCellValue("ECode", lc.Properties.View.GetFocusedRowCellValue("ECode"))
        GridView1.SetFocusedRowCellValue("SubPrcName", lc.Properties.View.GetFocusedRowCellValue("SubPrcName"))
        GridView1.SetFocusedRowCellValue("PrcName", lc.Properties.View.GetFocusedRowCellValue("PrcName"))
        GridView1.SetFocusedRowCellValue("JVName", lc.Properties.View.GetFocusedRowCellValue("JVName"))
        GridView1.SetFocusedRowCellValue("JEName", lc.Properties.View.GetFocusedRowCellValue("JEName"))
        GridView1.SetFocusedRowCellValue("Unit", lc.Properties.View.GetFocusedRowCellValue("Unit"))
        GridView1.SetFocusedRowCellValue("MinQty", lc.Properties.View.GetFocusedRowCellValue("MinQty"))
        GridView1.SetFocusedRowCellValue("Định mức ngày", lc.Properties.View.GetFocusedRowCellValue("Định mức ngày"))
        GridView1.SetFocusedRowCellValue("Định mức tuần", lc.Properties.View.GetFocusedRowCellValue("Định mức tuần"))
        GridView1.SetFocusedRowCellValue("Định mức tháng", lc.Properties.View.GetFocusedRowCellValue("Định mức tháng"))
        GridView1.SetFocusedRowCellValue("Tồn hiện tại", lc.Properties.View.GetFocusedRowCellValue("Tồn hiện tại"))
    End Sub

    Private Sub slueJCode_BeforePopup(sender As Object, e As EventArgs) Handles slueJCode.BeforePopup
        _EcodeOld = GridView1.GetFocusedRowCellValue("ECode")
        _JCodeOld = GridView1.GetFocusedRowCellValue("JCode")
        _SubPrcNameOld = GridView1.GetFocusedRowCellValue("SubPrcName")
    End Sub

    Private Sub chbLockedTime1_CheckedChanged(sender As Object, e As EventArgs) Handles chbLockedTime1.CheckedChanged
        Dim obj As New PCM_LockDay
        obj.YMD_K = orderDate
        If _db.ExistObject(obj) Then
            _db.GetObject(obj)
            If chbLockedTime1.Checked Then
                obj.JCodeLocked1 = True
            Else
                obj.JCodeLocked1 = False
            End If
            _db.Update(obj)
        Else
            If chbLockedTime1.Checked Then
                obj.JCodeLocked1 = True
            Else
                obj.JCodeLocked1 = False
            End If
            obj.JCodeLocked2 = True
            obj.JCodeLocked3 = True
            obj.TrayLocked1 = True
            obj.TrayLocked2 = True
            obj.DirectLocked = True
            obj.OutWSLocked = True
            _db.Insert(obj)
        End If
    End Sub

    Private Sub chbLockedTime2_CheckedChanged(sender As Object, e As EventArgs) Handles chbLockedTime2.CheckedChanged
        Dim obj As New PCM_LockDay
        obj.YMD_K = orderDate
        If _db.ExistObject(obj) Then
            _db.GetObject(obj)
            If chbLockedTime2.Checked Then
                obj.JCodeLocked2 = True
            Else
                obj.JCodeLocked2 = False
            End If
            _db.Update(obj)
        Else
            obj.JCodeLocked1 = True
            If chbLockedTime2.Checked Then
                obj.JCodeLocked2 = True
            Else
                obj.JCodeLocked2 = False
            End If
            obj.JCodeLocked3 = True
            obj.TrayLocked1 = True
            obj.TrayLocked2 = True
            obj.DirectLocked = True
            obj.OutWSLocked = True
            _db.Insert(obj)
        End If
    End Sub

    Private Sub chbLockedTime3_CheckedChanged(sender As Object, e As EventArgs) Handles chbLockedTime3.CheckedChanged
        Dim obj As New PCM_LockDay
        obj.YMD_K = orderDate
        If _db.ExistObject(obj) Then
            _db.GetObject(obj)
            If chbLockedTime3.Checked Then
                obj.JCodeLocked3 = True
            Else
                obj.JCodeLocked3 = False
            End If
            _db.Update(obj)
        Else
            obj.JCodeLocked1 = True
            obj.JCodeLocked2 = True
            If chbLockedTime3.Checked Then
                obj.JCodeLocked3 = True
            Else
                obj.JCodeLocked3 = False
            End If
            obj.TrayLocked1 = True
            obj.TrayLocked2 = True
            obj.DirectLocked = True
            obj.OutWSLocked = True
            _db.Insert(obj)
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        Dim sfDlg As New SaveFileDialog()
        sfDlg.DefaultExt = ".xlsx"
        sfDlg.Filter = "Excel 2007 file(.xlsx)|*.xlsx| Excel 2003 file(.xls)|*.xls"
        sfDlg.FileName = String.Format("Số lượng xuất kho lần 1 ({0})- nguyên liệu.xlsx",
                                       DateTime.Now.ToString("dd.MM.yyyy"))
        sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\1.Xuat kho Nippon\XUAT KHO {0}\XKHO NL T{1}\Lần 1\",
                                               DateTime.Now.Year,
                                               DateTime.Now.ToString("MM.yyyy"))
        If rdoEx2.Checked Then
            sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\1.Xuat kho Nippon\XUAT KHO {0}\XKHO NL T{1}\Lần 2\",
                                               DateTime.Now.Year,
                                               DateTime.Now.ToString("MM.yyyy"))
        ElseIf rdoEx3.Checked Then
            sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\1.Xuat kho Nippon\XUAT KHO {0}\XKHO NL T{1}\Lần 3\",
                                               DateTime.Now.Year,
                                               DateTime.Now.ToString("MM.yyyy"))
        End If

        If sfDlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        If chbJCodeType.Text = "Normal" Then
            Dim sql As String = String.Format("select YMD, DeptName, ECode, JCode, PrcName, JEName, JVName, Unit, Qty1, Qty2+Adjust as Qty2, Qty3, Note, " +
                                        " DeptGSR = CASE WHEN B.CodePP IS NULL THEN A.DeptName ELSE 'PP' END " +
                                        " from PCM_NotJCode A " +
                                        " left join PCM_ImportCodePP B on A.JCode = B.CodePP " +
                                        " where " +
                                        " YMD = '{0}' and ECode like '%{1}%'" +
                                        " order by ECode,PrcName, JCode",
                                        orderDate,
                                        condiUser)
            ExportEXCEL(_db.FillDataTable(sql))
        ElseIf chbJCodeType.Text = "NotJCode" Then
            Dim sql As String = String.Format("select YMD, DeptName, ECode, JCode, PrcName, JEName, JVName, Unit, Qty1, Qty2+Adjust as Qty2, Qty3, Note, " +
                                        " DeptGSR = CASE WHEN B.CodePP IS NULL THEN A.DeptName ELSE 'PP' END " +
                                        " from PCM_NotJCode A " +
                                        " left join PCM_ImportCodePP B on A.JCode = B.CodePP " +
                                        " where " +
                                        " YMD = '{0}' and ECode like '%{1}%' and A.JCode not like 'J%' " +
                                        " order by ECode,PrcName, JCode",
                                        orderDate,
                                        condiUser,
                                        Trim(chbJCodeType.Text))
            ExportEXCEL(_db.FillDataTable(sql))
        ElseIf chbJCodeType.Text = "JCodeChemical" Then
            Dim sql As String = String.Format("select YMD, DeptName, ECode, JCode, PrcName, JEName, JVName, Unit, Qty1, Qty2+Adjust as Qty2, Qty3, Note, " +
                                        " DeptGSR = CASE WHEN B.CodePP IS NULL THEN A.DeptName ELSE 'PP' END " +
                                        " from PCM_NotJCode A " +
                                        " left join PCM_ImportCodePP B on A.JCode = B.CodePP " +
                                        " inner join (select distinct ItemCode from [dbo].[LOS_ItemChemical])c " +
                                           " on A.JCode=c.ItemCode " +
                                        " where " +
                                        " YMD = '{0}' and ECode like '%{1}%' and A.JCode like 'J%'" +
                                        " order by ECode,PrcName, JCode",
                                        orderDate,
                                        condiUser,
                                        Trim(chbJCodeType.Text))
            ExportEXCEL(_db.FillDataTable(sql))
        ElseIf chbJCodeType.Text = "JCodeExcludeChemical" Then
            Dim sql As String = String.Format(" select YMD, DeptName, ECode, JCode, PrcName, JEName, JVName, Unit, Qty1, Qty2+Adjust as Qty2, Qty3, Note, " +
                                        " DeptGSR = CASE WHEN B.CodePP IS NULL THEN A.DeptName ELSE 'PP' END " +
                                        " from PCM_NotJCode A " +
                                        " left join PCM_ImportCodePP B on A.JCode = B.CodePP " +
                                        " left join (select distinct ItemCode from [dbo].[LOS_ItemChemical] )c " +
                                           " on A.JCode=c.ItemCode " +
                                        " where " +
                                        " YMD = '{0}' and ECode like '%{1}%' and A.JCode  like 'J%' " +
                                        " and c.ItemCode is null" +
                                        " order by ECode,PrcName, JCode",
                                        orderDate,
                                        condiUser,
                                        Trim(chbJCodeType.Text))
            ExportEXCEL(_db.FillDataTable(sql))
        End If
    End Sub

    Private Sub btnCheckLock_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCheckLock.ItemClick
        Dim frm As New FrmCheckLock
        frm.Show()
    End Sub

    Private Sub btnExportNJCStock_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportNJCStock.ItemClick
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@day", orderDate)
        ExportEXCEL(_db.ExecuteStoreProcedureTB("sp_PCM_NJCStock", para))
    End Sub

    Private Sub btnExportSum_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportSum.ItemClick
        Dim sfDlg As New SaveFileDialog()
        sfDlg.DefaultExt = ".xlsx"
        sfDlg.Filter = "Excel 2007 file(.xlsx)|*.xlsx"
        sfDlg.FileName = String.Format("PhieuSoanHang lần 1 ({0}).xlsx", DateTime.Now.ToString("dd.MM.yyyy"))

        sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\6.KIỂM SOÁT NHẬP XUẤT TỒN KHO HÀNG VẬT TƯ\4. Phieu soan hang moi\THÁNG {0}\{1}\",
                                               DateTime.Now.ToString("MM"),
                                               DateTime.Now.ToString("dd.MM.yyyy"))
        If rdoEx2.Checked Then
            sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\6.KIỂM SOÁT NHẬP XUẤT TỒN KHO HÀNG VẬT TƯ\4. Phieu soan hang moi\THÁNG {0}\{1}\PhieuSoanHang lần 2 ({1})\",
                                               DateTime.Now.ToString("MM"),
                                               DateTime.Now.ToString("dd.MM.yyyy"))
            sfDlg.FileName = String.Format("PhieuSoanHang lần 2 ({0}).xlsx", DateTime.Now.ToString("dd.MM.yyyy"))
        ElseIf rdoEx3.Checked Then
            sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\6.KIỂM SOÁT NHẬP XUẤT TỒN KHO HÀNG VẬT TƯ\4. Phieu soan hang moi\THÁNG {0}\{1}\PhieuSoanHang lần 3 ({1})\",
                                               DateTime.Now.ToString("MM"),
                                               DateTime.Now.ToString("dd.MM.yyyy"))
            sfDlg.FileName = String.Format("PhieuSoanHang lần 3 ({0}).xlsx", DateTime.Now.ToString("dd.MM.yyyy"))
        End If

        If sfDlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@day", orderDate)
        para(1) = New SqlClient.SqlParameter("@condiUser", condiUser)
        para(2) = New SqlClient.SqlParameter("@MatCode", Trim(chbJCodeType.Text))

        Dim tbl As DataTable = _db.ExecuteStoreProcedureTB("sp_PCM_ExportSumMter", para)


        Dim sqlSum As String = String.Format(" select m.JCode,max(m.[JEName]) as JEName ,max(m.[JVName]) as JVName, " +
                                             " Sum(isnull(m.Qty1,0)) Qty1, Sum(isnull(m.Qty2,0)+isnull(m.Adjust,0)) Qty2," +
                                             " Sum(isnull(m.Qty3,0)) Qty3,max(i.Position) as Position " +
                                            " from PCM_NotJCode m " +
                                            " left join LOC_ItemCode i on i.ItemCode =m.JCode " +
                                            " where " +
                                            " m.YMD = '{0}'  " +
                                            " AND m.JCode NOT LIKE 'J%'   " +
                                            " group by m.JCode  " +
                                            " order by m.JCode",
                                            orderDate,
                                            condiUser, Trim(chbJCodeType.Text))

        Dim tblSum As DataTable = _db.FillDataTable(sqlSum)

        If Trim(chbJCodeType.Text) <> "NotJCode" Then
            'ExportEXCEL(gridD)
            GridControlExportExcel(GridView1)
            Exit Sub
        End If

        Dim lan As Integer = 0
        Dim SumTotal As Integer = 0

        If rdoEx1.Checked = True Then
            Dim column As String() = {"YMD", "DeptName", "PrcName", "JCode", "JEName", "JVName", "Unit", "Qty1", "Empty1", "Empty2", "Empty3", "DeptGSR"}
            tbl = tbl.DefaultView.ToTable(False, column)

            Dim columnSum As String() = {"JCode", "JEName", "JVName", "Qty1", "Position"}
            tblSum = tblSum.DefaultView.ToTable(False, columnSum)

            lan = 1
            SumTotal = tblSum.Compute("Sum(Qty1)", "")
        ElseIf rdoEx2.Checked = True Then
            Dim column As String() = {"YMD", "DeptName", "PrcName", "JCode", "JEName", "JVName", "Unit", "Qty2", "Empty1", "Empty2", "Empty3", "DeptGSR"}
            tbl = tbl.DefaultView.ToTable(False, column)

            Dim columnSum As String() = {"JCode", "JEName", "JVName", "Qty2", "Position"}
            tblSum = tblSum.DefaultView.ToTable(False, columnSum)

            lan = 2
            SumTotal = tblSum.Compute("Sum(Qty2)", "")
        ElseIf rdoEx3.Checked = True Then
            Dim column As String() = {"YMD", "DeptName", "PrcName", "JCode", "JEName", "JVName", "Unit", "Qty3", "Empty1", "Empty2", "Empty3", "DeptGSR"}
            tbl = tbl.DefaultView.ToTable(False, column)

            Dim columnSum As String() = {"JCode", "JEName", "JVName", "Qty3", "Position"}
            tblSum = tblSum.DefaultView.ToTable(False, columnSum)

            lan = 3
            SumTotal = tblSum.Compute("Sum(Qty3)", "")
        Else
            MessageBox.Show("Chọn lần xuất kho")
            Exit Sub
        End If

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        'Copy template
        clsApplication.UpLoadFile(clsApplication.FileTmp + "PhieuSoanHang.xlsx", sfDlg.FileName, True)

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim wRange As Excel.Range

        'Open file
        'app.DisplayAlerts = False
        myExcel.Visible = True

        If (File.Exists(sfDlg.FileName)) Then
            wbook = myExcel.Workbooks.Open(sfDlg.FileName)
        Else
            ShowWarning("Thiếu template export !")
            Return
        End If

        wSheet = CType(wbook.Sheets("PhieuSoanHang"), Excel.Worksheet)
        wSheet.Activate()
        'myExcel.StandardFont = "Times New Roman"
        'myExcel.StandardFontSize = 9

        wSheet.Cells(5, 1) = "PHIẾU SOẠN HÀNG LẦN " & lan

        'Detail
        Dim i, j As Integer
        Dim rows As Integer = tbl.Rows.Count - 1
        Dim cols As Integer = tbl.Columns.Count - 1
        Dim iRow As Integer = 0

        Dim DataArray(rows, cols) As Object
        For i = 0 To rows
            For j = 0 To cols
                If tbl.Rows(i).Item(j) Is System.DBNull.Value Then Continue For
                If String.IsNullOrEmpty(tbl.Rows(i).Item(j)) Then
                Else
                    If tbl.Rows(i).Item(j).GetType().Name = "String" Then
                        DataArray(i, j) = "'" + tbl.Rows(i).Item(j).ToString()
                    Else
                        DataArray(i, j) = tbl.Rows(i).Item(j)
                    End If
                End If
            Next
            wRange = wSheet.Range(wSheet.Cells(i + 11, 1), wSheet.Cells(i + 11, 12))
            wRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
            iRow = i + 10
        Next

        If DataArray IsNot Nothing Then
            myExcel.Range("A10").Resize(rows + 1, cols + 1).Value = DataArray
        End If

        'Delete dòng thừa
        wRange = wSheet.Range(wSheet.Cells(iRow + 1, 1), wSheet.Cells(iRow + 2, 12))
        wRange.Delete()
        'End Detail

        'sheet tổng
        wSheet = CType(wbook.Sheets("Sum"), Excel.Worksheet)
        wSheet.Activate()
        'myExcel.StandardFont = "Times New Roman"
        'myExcel.StandardFontSize = 9

        'Detail
        i = 0
        j = 0
        rows = tblSum.Rows.Count - 1
        cols = tblSum.Columns.Count - 1
        iRow = 0

        Dim DataArraySum(rows, cols) As Object
        For i = 0 To rows
            For j = 0 To cols
                If tblSum.Rows(i).Item(j) Is System.DBNull.Value Then Continue For
                If String.IsNullOrEmpty(tblSum.Rows(i).Item(j)) Then
                Else
                    If tblSum.Rows(i).Item(j).GetType().Name = "String" Then
                        DataArraySum(i, j) = "'" + tblSum.Rows(i).Item(j).ToString()
                    Else
                        DataArraySum(i, j) = tblSum.Rows(i).Item(j)
                    End If
                End If
            Next
            wRange = wSheet.Range(wSheet.Cells(i + 4, 1), wSheet.Cells(i + 4, 12))
            wRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
            iRow = i + 3
        Next

        If DataArray IsNot Nothing Then
            myExcel.Range("A3").Resize(rows + 1, cols + 1).Value = DataArraySum
        End If

        'Delete dòng thừa
        wRange = wSheet.Range(wSheet.Cells(iRow + 1, 1), wSheet.Cells(iRow + 2, 12))
        wRange.Delete()

        CType(wSheet.Cells(iRow + 1, 4), Excel.Range).Formula = String.Format("=sum(D3:D{0})", iRow)
        'End Detail

        wbook.Save()

        ShowSuccess()

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
    End Sub
    Function condiUser() As String
        If cls.checkUser() Then
            Return ""
        Else
            Return CurrentUser.UserID
        End If
    End Function

    Private Sub btnExportTempLemon_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportTempLemon.ItemClick
        If txtSoPhieu.Text = "" Then
            ShowWarning("Bạn chưa nhập số phiếu !")
            txtSoPhieu.Select()
            Return
        End If
        Dim sfDlg As New SaveFileDialog()
        sfDlg.DefaultExt = ".xls"
        sfDlg.Filter = "Excel 2007 file(.xlsx)|*.xlsx| Excel 2003 file(.xls)|*.xls"
        sfDlg.FileName = "Template Import Lemon.xls"
        sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\6.KIỂM SOÁT NHẬP XUẤT TỒN KHO HÀNG VẬT TƯ\5. Templet Lemon\NĂM {0}\Tháng {1}\{2}\",
                                               Today.Year,
                                               Today.ToString("MM"),
                                               Today.ToString("dd.MM.yyyy"))
        If sfDlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub


        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")


        'Copy template
        clsApplication.UpLoadFile(clsApplication.FileTmp + "TemplateImportLemon.xls",
                                   sfDlg.FileName, True)
        'Variance
        Dim app As New Excel.Application
        Dim workBook As Excel.Workbook
        Dim workSheet As Excel.Worksheet
        Dim workRange As Excel.Range
        'Open file
        If (File.Exists(sfDlg.FileName)) Then
            workBook = app.Workbooks.Open(sfDlg.FileName)
        Else
            workBook = app.Workbooks.Add(Type.Missing)
        End If
        workSheet = CType(workBook.Sheets(1), Excel.Worksheet)
        workSheet.Name = "TemplateImportLemon"
        'Write data 
        'Detail
        Dim iRow As Integer = 13
        workSheet.Cells(iRow, 3) = String.Format("X/{0}/{1}/{2}",
                                                 DateTime.Now.ToString("MM"),
                                                 DateTime.Now.ToString("yy"),
                                                 txtSoPhieu.Text)

        Dim dtConvert = GridcontrolConvertToDataTable(GridView1)
        dtConvert.Columns.Add("Kho")
        dtConvert.Columns.Add("PhongBanDat")
        For Each r As DataRow In dtConvert.Rows
            If r("DeptName") = r("DeptGSR") And (r("DeptName") = "CISQA" Or r("DeptName") = "CISPR") Then
                r("Kho") = "K.CIS"
            Else
                r("Kho") = "K.NDV"
            End If
            If (r("DeptName") = "CISQA" Or r("DeptName") = "CISPR") And r("DeptGSR") = "PP" Then
                r("PhongBanDat") = r("DeptName")
            Else
                r("PhongBanDat") = r("DeptGSR")
            End If
        Next
        Dim dtView = dtConvert.DefaultView
        dtView.Sort = "Kho, DeptName, PrcName"
        Dim dtNew = dtView.ToTable

        If rdoEx2.Checked Then
            For Each r As DataRow In dtNew.Rows
                If (r(ColQty) > 0 Or r("Adjust") > 0) And
                    r("JCode").ToString.Contains("J") = False Then
                    workSheet.Cells(iRow, 1) = ""
                    workSheet.Cells(iRow, 2) = "X"
                    workSheet.Cells(iRow, 4) = dteOrderDate.DateTime.Date
                    workSheet.Cells(iRow, 8) = "USD"
                    workSheet.Cells(iRow, 9) = 1
                    workSheet.Cells(iRow, 10) = "PB"
                    workSheet.Cells(iRow, 11) = r("DeptName")
                    workSheet.Cells(iRow, 12) = "LO0006"
                    workSheet.Cells(iRow, 13) = r("Kho")
                    workSheet.Cells(iRow, 5) = r("PrcName")
                    workSheet.Cells(iRow, 14) = ""
                    workSheet.Cells(iRow, 15) = "'" & r("JCode")
                    workSheet.Cells(iRow, 16) = ""
                    workSheet.Cells(iRow, 17) = ""
                    workSheet.Cells(iRow, 18) = ""
                    workSheet.Cells(iRow, 19) = r(ColQty) + r("Adjust")
                    workSheet.Cells(iRow, 33) = r("PhongBanDat")
                    iRow += 1
                End If
            Next
        Else
            For Each r As DataRow In dtNew.Rows
                If r(ColQty) > 0 And r("JCode").ToString.Contains("J") = False Then
                    workSheet.Cells(iRow, 1) = ""
                    workSheet.Cells(iRow, 2) = "X"
                    workSheet.Cells(iRow, 4) = dteOrderDate.DateTime.Date
                    workSheet.Cells(iRow, 8) = "USD"
                    workSheet.Cells(iRow, 9) = 1
                    workSheet.Cells(iRow, 10) = "PB"
                    workSheet.Cells(iRow, 11) = r("DeptName")
                    workSheet.Cells(iRow, 12) = "LO0006"
                    workSheet.Cells(iRow, 13) = r("Kho")
                    workSheet.Cells(iRow, 5) = r("PrcName")
                    workSheet.Cells(iRow, 14) = ""
                    workSheet.Cells(iRow, 15) = "'" & r("JCode")
                    workSheet.Cells(iRow, 16) = ""
                    workSheet.Cells(iRow, 17) = ""
                    workSheet.Cells(iRow, 18) = ""
                    workSheet.Cells(iRow, 19) = r(ColQty)
                    workSheet.Cells(iRow, 33) = r("PhongBanDat")
                    iRow += 1
                End If
            Next
        End If

        'If rdoEx2.Checked Then
        '    For r = 0 To GridView1.RowCount - 1
        '        If (GridView1.GetRowCellValue(r, ColQty) > 0 Or GridView1.GetRowCellValue(r, "Adjust") > 0) And
        '            GridView1.GetRowCellValue(r, "JCode").ToString.Contains("J") = False Then
        '            workSheet.Cells(iRow, 1) = ""
        '            workSheet.Cells(iRow, 2) = "X"
        '            workSheet.Cells(iRow, 4) = dteOrderDate.DateTime.Date
        '            workSheet.Cells(iRow, 8) = "USD"
        '            workSheet.Cells(iRow, 9) = 1
        '            workSheet.Cells(iRow, 10) = "PB"
        '            workSheet.Cells(iRow, 11) = GridView1.GetRowCellValue(r, "DeptName")
        '            workSheet.Cells(iRow, 12) = "LO0006"
        '            Dim deptName As String = GridView1.GetRowCellValue(r, "DeptName")
        '            Dim deptGSR As String = GridView1.GetRowCellValue(r, "DeptGSR")
        '            Dim row13 As String = ""
        '            If deptName = deptGSR And (deptName = "CISQA" Or deptName = "CISPR") Then
        '                row13 = "K.CIS"
        '            Else
        '                row13 = "K.NDV"
        '            End If
        '            workSheet.Cells(iRow, 13) = row13
        '            workSheet.Cells(iRow, 5) = GridView1.GetRowCellValue(r, "PrcName")
        '            workSheet.Cells(iRow, 14) = ""
        '            workSheet.Cells(iRow, 15) = "'" & GridView1.GetRowCellValue(r, "JCode")
        '            workSheet.Cells(iRow, 16) = ""
        '            workSheet.Cells(iRow, 17) = ""
        '            workSheet.Cells(iRow, 18) = ""
        '            workSheet.Cells(iRow, 19) = GridView1.GetRowCellValue(r, ColQty) + GridView1.GetRowCellValue(r, "Adjust")
        '            If (deptName = "CISQA" Or deptName = "CISPR") And deptGSR = "PP" Then
        '                workSheet.Cells(iRow, 33) = deptName
        '            Else
        '                workSheet.Cells(iRow, 33) = GridView1.GetRowCellValue(r, "DeptGSR")
        '            End If
        '            iRow += 1
        '        End If
        '    Next
        'Else
        '    For r = 0 To GridView1.RowCount - 1
        '        If GridView1.GetRowCellValue(r, ColQty) > 0 And GridView1.GetRowCellValue(r, "JCode").ToString.Contains("J") = False Then
        '            workSheet.Cells(iRow, 1) = ""
        '            workSheet.Cells(iRow, 2) = "X"
        '            workSheet.Cells(iRow, 4) = dteOrderDate.DateTime.Date
        '            workSheet.Cells(iRow, 8) = "USD"
        '            workSheet.Cells(iRow, 9) = 1
        '            workSheet.Cells(iRow, 10) = "PB"
        '            workSheet.Cells(iRow, 11) = GridView1.GetRowCellValue(r, "DeptName")
        '            workSheet.Cells(iRow, 12) = "LO0006"

        '            Dim deptName As String = GridView1.GetRowCellValue(r, "DeptName")
        '            Dim deptGSR As String = GridView1.GetRowCellValue(r, "DeptGSR")
        '            Dim row13 As String = ""
        '            If deptName = deptGSR And (deptName = "CISQA" Or deptName = "CISPR") Then
        '                row13 = "K.CIS"
        '            Else
        '                row13 = "K.NDV"
        '            End If
        '            workSheet.Cells(iRow, 13) = row13
        '            workSheet.Cells(iRow, 5) = GridView1.GetRowCellValue(r, "PrcName")
        '            workSheet.Cells(iRow, 14) = ""
        '            workSheet.Cells(iRow, 15) = "'" & GridView1.GetRowCellValue(r, "JCode")
        '            workSheet.Cells(iRow, 16) = ""
        '            workSheet.Cells(iRow, 17) = ""
        '            workSheet.Cells(iRow, 18) = ""
        '            workSheet.Cells(iRow, 19) = GridView1.GetRowCellValue(r, ColQty)
        '            If (deptName = "CISQA" Or deptName = "CISPR") And deptGSR = "PP" Then
        '                workSheet.Cells(iRow, 33) = deptName
        '            Else
        '                workSheet.Cells(iRow, 33) = GridView1.GetRowCellValue(r, "DeptGSR")
        '            End If
        '            iRow += 1
        '        End If
        '    Next
        'End If
        'Footer

        'workRange = workSheet.Range(workSheet.Cells(iRow + 2, 6), workSheet.Cells(iRow + 3, 6))
        'workRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'workRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        'Set format
        workRange = workSheet.Range(workSheet.Cells(12, 1), workSheet.Cells(iRow - 1, 33))
        workRange.Borders.Color = ColorTranslator.ToWin32(Color.Black)
        workRange.Borders.Weight = Excel.XlBorderWeight.xlThin
        'Detail 
        'Save file
        app.Visible = True
        app.DisplayAlerts = False
        workBook.Save()

        'Release all objects
        GC.Collect()
        GC.WaitForPendingFinalizers()
        Marshal.FinalReleaseComObject(workRange)
        Marshal.FinalReleaseComObject(workSheet)
        Marshal.FinalReleaseComObject(workBook)
        Marshal.FinalReleaseComObject(app)

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
    End Sub

    Private Sub rdoEx1_CheckedChanged(sender As Object, e As EventArgs) Handles rdoEx1.CheckedChanged
        If rdoEx1.Checked Then
            ColQty = "Qty1"
        End If
    End Sub

    Private Sub rdoEx2_CheckedChanged(sender As Object, e As EventArgs) Handles rdoEx2.CheckedChanged
        If rdoEx2.Checked Then
            ColQty = "Qty2"
        End If
    End Sub

    Private Sub rdoEx3_CheckedChanged(sender As Object, e As EventArgs) Handles rdoEx3.CheckedChanged
        If rdoEx3.Checked Then
            ColQty = "Qty3"
        End If
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowClick
        Dim _JCode As String = ""
        Dim _Stock As Integer = 0
        Dim _Total1 As Integer = 0
        Dim _Total2 As Integer = 0
        Dim _Total3 As Integer = 0
        Dim _Ins As Integer = 0
        Dim _Non As Integer = 0

        If Not IsDBNull(GridView1.GetFocusedRowCellValue("JCode")) Then
            _JCode = GridView1.GetFocusedRowCellValue("JCode")
            Dim dt = _db.FillDataTable(String.Format("SELECT Qty, HeldQty 
                                                  FROM PCM_Stock 
                                                  WHERE JCode = '{0}'", _JCode))
            If dt.Rows.Count > 0 Then
                _Ins = dt.Rows(0)("Qty")
                _Non = dt.Rows(0)("HeldQty")
                _Stock = _Ins + _Non
            End If
            For r = 0 To GridView1.RowCount - 1
                _Total1 += IIf(IsDBNull(GridView1.GetRowCellValue(r, "Qty1")), 0, GridView1.GetRowCellValue(r, "Qty1"))
                _Total2 += IIf(IsDBNull(GridView1.GetRowCellValue(r, "Qty2")), 0, GridView1.GetRowCellValue(r, "Qty2"))
                _Total3 += IIf(IsDBNull(GridView1.GetRowCellValue(r, "Qty3")), 0, GridView1.GetRowCellValue(r, "Qty3"))
            Next
            txtStock.Text = _Stock
            txtTotal1.Text = _Total1
            txtTotal2.Text = _Total2
            txtTotal3.Text = _Total3
            txtInsStock.Text = _Ins
            txtNonInsStock.Text = _Non
        End If

        'Dim cGrid1 As GridColumn = GridView1.Columns("YMD")
        'cGrid1.SummaryItem.SummaryType = SummaryItemType.Custom
        'Dim cGrid2 As GridColumn = GridView1.Columns("DeptName")
        'cGrid2.SummaryItem.SummaryType = SummaryItemType.Custom
        'Dim cGrid3 As GridColumn = GridView1.Columns("ECode")
        'cGrid3.SummaryItem.SummaryType = SummaryItemType.Custom
        'Dim cGrid4 As GridColumn = GridView1.Columns("JCode")
        'cGrid4.SummaryItem.SummaryType = SummaryItemType.Custom
        'Dim cGrid5 As GridColumn = GridView1.Columns("SubPrcName")
        'cGrid5.SummaryItem.SummaryType = SummaryItemType.Custom
        'Dim cGrid6 As GridColumn = GridView1.Columns("PrcName")
        'cGrid6.SummaryItem.SummaryType = SummaryItemType.Custom
    End Sub

    Dim _colName As String
    Dim _valCopy As Decimal
    Private Sub btnPaste_Click(sender As Object, e As EventArgs) Handles btnPaste.Click
        If GridView1.Editable = False And GridView1.FocusedColumn.FieldName.ToString.Contains("Qty") Then
            Dim valPaste = GridView1.GetFocusedRowCellValue(GridView1.FocusedColumn.FieldName)
            _db.ExecuteNonQuery(String.Format(" UPDATE PCM_NotJCode
                                                SET {0} = {1},
                                                {2} = {3}
                                                WHERE YMD = '{4}'
                                                AND ECode = '{5}'
                                                AND JCode = '{6}'
                                                AND SubPrcName = N'{7}'",
                                                GridView1.FocusedColumn.FieldName,
                                                _valCopy, _colName, valPaste,
                                                GridView1.GetFocusedRowCellValue("YMD"),
                                                GridView1.GetFocusedRowCellValue("ECode"),
                                                GridView1.GetFocusedRowCellValue("JCode"),
                                                GridView1.GetFocusedRowCellValue("SubPrcName")))
            GridView1.SetFocusedRowCellValue(GridView1.FocusedColumn.FieldName, _valCopy)
            GridView1.SetFocusedRowCellValue(_colName, valPaste)
        End If
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        _colName = GridView1.FocusedColumn.FieldName
        _valCopy = GridView1.GetFocusedRowCellValue(GridView1.FocusedColumn.FieldName)
    End Sub

    Private Sub btnCheckQty_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCheckQty.ItemClick
        Dim err As Integer = 0
        For r = 0 To GridView1.RowCount - 1
            Dim valTotal = GridView1.GetRowCellValue(r, "Qty1") + GridView1.GetRowCellValue(r, "Qty2") + GridView1.GetRowCellValue(r, "Qty3")
            Dim valTHT As Object = GridView1.GetRowCellValue(r, "Tồn hiện tại")
            If IsDBNull(valTHT) Then
                valTHT = 0
            End If
            If valTotal > valTHT Then
                err += 1
            End If
        Next
        ShowWarning(err.ToString + " dòng vượt tồn !")
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        If isEdit And e.RowHandle > 0 Then
            Dim Qty1 = IIf(IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "Qty1")), 0, GridView1.GetRowCellValue(e.RowHandle, "Qty1"))
            Dim Qty2 = IIf(IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "Qty2")), 0, GridView1.GetRowCellValue(e.RowHandle, "Qty2"))
            Dim Qty3 = IIf(IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "Qty3")), 0, GridView1.GetRowCellValue(e.RowHandle, "Qty3"))
            Dim valTotal = Qty1 + Qty2 + Qty3
            Dim valTHT As Object = GridView1.GetRowCellValue(e.RowHandle, "Tồn hiện tại")
            If IsDBNull(valTHT) Then
                valTHT = 0
            End If
            If valTotal > valTHT Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.ForeColor = Color.White
            End If
        End If
    End Sub
    Sub ReturnOldValue(gridV As GridView)
        Dim oldVal As Object = gridV.ActiveEditor.OldEditValue
        gridV.Columns(gridV.FocusedColumn.FieldName).OptionsColumn.ReadOnly = True
        gridV.SetFocusedRowCellValue(gridV.FocusedColumn.FieldName, oldVal)
        gridV.Columns(gridV.FocusedColumn.FieldName).OptionsColumn.ReadOnly = False
    End Sub
    'Private Sub GridView1_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
    '    Dim gridSum As GridSummaryItem = e.Item
    '    If e.IsTotalSummary Then
    '        Select Case e.SummaryProcess
    '            Case CustomSummaryProcess.Start
    '            Case CustomSummaryProcess.Calculate
    '            Case CustomSummaryProcess.Finalize
    '                If gridSum.FieldName = "YMD" Then
    '                    e.TotalValue = String.Format("Stock: {0}", _Stock)
    '                End If
    '                If gridSum.FieldName = "DeptName" Then
    '                    e.TotalValue = String.Format("Total 1: {0}", _Total1)
    '                End If
    '                If gridSum.FieldName = "ECode" Then
    '                    e.TotalValue = String.Format("Total 2: {0}", _Total2)
    '                End If
    '                If gridSum.FieldName = "JCode" Then
    '                    e.TotalValue = String.Format("Total 3: {0}", _Total3)
    '                End If
    '                If gridSum.FieldName = "SubPrcName" Then
    '                    e.TotalValue = String.Format("Ins: {0}", _Ins)
    '                End If
    '                If gridSum.FieldName = "PrcName" Then
    '                    e.TotalValue = String.Format("Non: {0}", _Non)
    '                End If
    '        End Select
    '    End If
    'End Sub
End Class