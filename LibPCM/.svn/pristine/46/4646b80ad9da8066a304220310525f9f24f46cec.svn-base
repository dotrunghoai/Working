Imports System.Windows.Forms
Imports CommonDB
Imports DevExpress.XtraEditors
Imports PublicUtility
Public Class FrmOutTrayAndU00_2
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim orderDate As String
    Dim isEdit As Boolean = True

    Dim EcodeOld As String
    Dim PdCodeOld As String
    Dim JCodeOld As String
    Dim SubPrcNameOld As String
    Private Sub FrmOutTrayAndU00_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub dteOrderDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteOrderDate.EditValueChanged
        orderDate = dteOrderDate.DateTime.ToString("yyyyMMdd")
    End Sub
    Sub ViewAccess()
        chbLockedTime1.ReadOnly = True
        chbLockedTime2.ReadOnly = True
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
            objlock.DirectLocked = True
            objlock.OutWSLocked = True
            _db.Insert(objlock)
        End If

        chbLockedTime1.Checked = objlock.TrayLocked1
        chbLockedTime2.Checked = objlock.TrayLocked2

        Dim day As String = orderDate
        Dim M1 As DateTime = New DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, DateTime.Now.AddMonths(-1).Day)
        Dim M3 As DateTime = New DateTime(DateTime.Now.AddMonths(-3).Year, DateTime.Now.AddMonths(-3).Month, DateTime.Now.AddMonths(-3).Day)

        Dim para(4) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@M1", M1.ToString("yyyyMM"))
        para(1) = New SqlClient.SqlParameter("@M3", M3.ToString("yyyyMM"))
        para(2) = New SqlClient.SqlParameter("@day", day)
        para(3) = New SqlClient.SqlParameter("@Action", "ShowNew")
        If isEdit Then
            para(4) = New SqlClient.SqlParameter("@ECode", DBNull.Value)
        Else
            para(4) = New SqlClient.SqlParameter("@ECode", CurrentUser.UserID)
        End If

        Dim dt = _db.ExecuteStoreProcedureTB("sp_PCM_OutTrayAndU00_PR", para)
        GridControl1.DataSource = dt
        GridControlSetFormat(GridView1, 4)
        GridView1.Columns("LotS1").Caption = "Start Lot 1"
        GridView1.Columns("LotE1").Caption = "End Lot 1"
        GridView1.Columns("Bal1").Caption = "Bal Qty 1"
        GridView1.Columns("LotS2").Caption = "Start Lot 2"
        GridView1.Columns("LotE2").Caption = "End Lot 2"
        GridView1.Columns("Bal2").Caption = "Bal Qty 2"

        Dim dtJCode = _db.FillDataTable("SELECT h.ECode, h.PdCode, h.JCode, h.JVName, h.JEName, 
                                        h.SubPrcName, h.PrcName, h.Unit, h.UnitLot, h.MinQty,
                                        ISNULL(d.Qty + d.HeldQty, 0) AS [Tồn hiện tại]
                                        FROM PCM_MterTrayU00 AS h
                                        LEFT JOIN PCM_Stock AS d
                                        ON h.JCode = d.JCode
                                        WHERE (@ECode IS NULL OR ECode = @ECode)", para)
        slueJCode.DataSource = dtJCode
        slueJCode.DisplayMember = "JCode"
        slueJCode.ValueMember = "JCode"
        slueJCode.NullText = Nothing
        GridView1.Columns("JCode").ColumnEdit = slueJCode

        If dt.Rows.Count > 0 Then
            txtTotal1.Text = dt.Compute("SUM(MatQty1)", "")
            txtTotal2.Text = dt.Compute("SUM(MatQty2)", "")
        End If
    End Sub
    Sub ColReadOnly()
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("JCode").OptionsColumn.ReadOnly = False
        GridView1.Columns("Note").OptionsColumn.ReadOnly = False
        GridView1.Columns("AdjustLot").OptionsColumn.ReadOnly = False
        GridView1.Columns("AdjustQty").OptionsColumn.ReadOnly = False
        GridView1.Columns("ActReceive").OptionsColumn.ReadOnly = False
        GridView1.Columns("RequestQty").OptionsColumn.ReadOnly = False
        If isEdit Or Not chbLockedTime1.Checked Then
            GridView1.Columns("LotS1").OptionsColumn.ReadOnly = False
            GridView1.Columns("LotE1").OptionsColumn.ReadOnly = False
            GridView1.Columns("Bal1").OptionsColumn.ReadOnly = False
            GridView1.Columns("MatQty1").OptionsColumn.ReadOnly = False
        End If
        If isEdit Or Not chbLockedTime2.Checked Then
            GridView1.Columns("LotS2").OptionsColumn.ReadOnly = False
            GridView1.Columns("LotE2").OptionsColumn.ReadOnly = False
            GridView1.Columns("Bal2").OptionsColumn.ReadOnly = False
            GridView1.Columns("MatQty2").OptionsColumn.ReadOnly = False
        End If
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        If GridControl1.DataSource Is Nothing Then
            btnShow.PerformClick()
        End If
        If isEdit Or Not chbLockedTime1.Checked Or Not chbLockedTime2.Checked Then
            GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            ColReadOnly()
        Else
            ShowWarning("Locked !")
        End If
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        If isEdit Or Not chbLockedTime1.Checked Or Not chbLockedTime2.Checked Then
            GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            GridControlSetColorReadonly(GridView1)
            ColReadOnly()
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
                    'sửa JCode
                    _db.ExecuteNonQuery(String.Format("UPDATE PCM_TrayU00
                                                   SET ECode = '{0}', 
                                                   PdCode = '{1}', 
                                                   JCode = '{2}', 
                                                   SubPrcName = N'{3}',
                                                   PrcName = '{4}',
                                                   JEName = '{5}',
                                                   JVName = '{6}',
                                                   Unit = '{7}',
                                                   UnitLot = {8},
                                                   MinQty = {9}
                                                   WHERE YMD = '{10}'
                                                   AND ECode = '{11}'
                                                   AND PdCode = '{12}'
                                                   AND JCode = '{13}'
                                                   AND SubPrcName = N'{14}'",
                                                   GridView1.GetFocusedRowCellValue("ECode"),
                                                   GridView1.GetFocusedRowCellValue("PdCode"),
                                                   GridView1.GetFocusedRowCellValue("JCode"),
                                                   GridView1.GetFocusedRowCellValue("SubPrcName"),
                                                   GridView1.GetFocusedRowCellValue("PrcName"),
                                                   GridView1.GetFocusedRowCellValue("JEName"),
                                                   GridView1.GetFocusedRowCellValue("JVName"),
                                                   GridView1.GetFocusedRowCellValue("Unit"),
                                                   GridView1.GetFocusedRowCellValue("UnitLot"),
                                                   GridView1.GetFocusedRowCellValue("MinQty"),
                                                   GridView1.GetFocusedRowCellValue("YMD"),
                                                   EcodeOld, PdCodeOld, JCodeOld, SubPrcNameOld))
                    Return
                End If
                If e.RowHandle < 0 Then
                    If IsDBNull(GridView1.GetFocusedRowCellValue("YMD")) Then
                        Dim obj As New PCM_TrayU00
                        obj.YMD_K = orderDate
                        obj.ECode_K = GridView1.GetFocusedRowCellValue("ECode")
                        obj.PdCode_K = GridView1.GetFocusedRowCellValue("PdCode")
                        obj.JCode_K = GridView1.GetFocusedRowCellValue("JCode")
                        obj.SubPrcName_K = GridView1.GetFocusedRowCellValue("SubPrcName")
                        If _db.ExistObject(obj) Then
                            ShowWarning("JCode đã được tạo trong hôm nay, bạn không thể tạo lần 2 !")
                            Return
                        Else
                            Dim objD As New PCM_Dept
                            objD.ECode_K = GridView1.GetFocusedRowCellValue("ECode")
                            objD.SubPrcName_K = GridView1.GetFocusedRowCellValue("SubPrcName")
                            _db.GetObject(objD)
                            Dim dept As Object = objD.DeptName
                            obj.DeptName = IIf(IsDBNull(dept), "", dept)
                            obj.JVName = GridView1.GetFocusedRowCellValue("JVName")
                            obj.JEName = GridView1.GetFocusedRowCellValue("JEName")
                            obj.PrcName = GridView1.GetFocusedRowCellValue("PrcName")
                            obj.Unit = GridView1.GetFocusedRowCellValue("Unit")
                            obj.UnitLot = GridView1.GetFocusedRowCellValue("UnitLot")
                            obj.MinQty = GridView1.GetFocusedRowCellValue("MinQty")
                            obj.CreateUser = CurrentUser.UserID
                            obj.CreateDate = DateTime.Now
                            _db.Insert(obj)
                            GridView1.SetFocusedRowCellValue("YMD", obj.YMD_K)
                            GridView1.SetFocusedRowCellValue("DeptName", obj.DeptName)
                        End If
                    End If
                End If


                Dim para(0) As SqlClient.SqlParameter
                para(0) = New SqlClient.SqlParameter("@Value", e.Value)
                _db.ExecuteNonQuery(String.Format("UPDATE PCM_TrayU00
                                               SET {0} = @Value,
                                               UpdateUser = '{1}',
                                               UpdateDate = '{2}'
                                               WHERE YMD = '{3}'
                                               AND ECode = '{4}'
                                               AND PdCode = '{5}'
                                               AND JCode = '{6}'
                                               AND SubPrcName = N'{7}'",
                                               e.Column.FieldName,
                                               CurrentUser.UserID,
                                               DateTime.Now,
                                               GridView1.GetFocusedRowCellValue("YMD"),
                                               GridView1.GetFocusedRowCellValue("ECode"),
                                               GridView1.GetFocusedRowCellValue("PdCode"),
                                               GridView1.GetFocusedRowCellValue("JCode"),
                                               GridView1.GetFocusedRowCellValue("SubPrcName")), para)
                If e.Column.FieldName = "LotS1" Or e.Column.FieldName = "LotE1" Or
                e.Column.FieldName = "Bal1" Or e.Column.FieldName = "MatQty1" Then
                    UpdateSubVal("Time1Date")
                    If CheckStock(GridView1.GetFocusedRowCellValue("MatQty1")) = False Then
                        _db.RollBack()
                    End If
                ElseIf e.Column.FieldName = "LotS2" Or e.Column.FieldName = "LotE2" Or
                e.Column.FieldName = "Bal2" Or e.Column.FieldName = "MatQty2" Then
                    UpdateSubVal("Time2Date")
                    If CheckStock(GridView1.GetFocusedRowCellValue("MatQty2")) = False Then
                        _db.RollBack()
                    End If
                End If
                _db.Commit()
            Catch ex As Exception
                _db.RollBack()
                ShowWarning(ex.Message)
            End Try
        End If
    End Sub

    Function CheckStock(valNhap) As Boolean
        Dim tonHienTai = GridView1.GetFocusedRowCellValue("Tồn hiện tại")
        If valNhap > tonHienTai Then
            ShowWarning("Vượt tồn hiện tại !")
            Return False
        End If

        Dim valInDay As Object = _db.ExecuteScalar(String.Format("SELECT ISNULL(SUM(MatQty1) + SUM(MatQty2), 0)
                                                                FROM PCM_TrayU00
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
        Return True
    End Function
    Sub UpdateSubVal(col As String)
        Dim obj As New PCM_TrayU00
        obj.YMD_K = GridView1.GetFocusedRowCellValue("YMD")
        obj.ECode_K = GridView1.GetFocusedRowCellValue("ECode")
        obj.PdCode_K = GridView1.GetFocusedRowCellValue("PdCode")
        obj.JCode_K = GridView1.GetFocusedRowCellValue("JCode")
        obj.SubPrcName_K = GridView1.GetFocusedRowCellValue("SubPrcName")
        _db.GetObject(obj)

        If GridView1.FocusedColumn.FieldName = "LotS1" Or GridView1.FocusedColumn.FieldName = "LotE1" Or
            GridView1.FocusedColumn.FieldName = "Bal1" Then
            Dim LotS1 As Object = GridView1.GetFocusedRowCellValue("LotS1")
            Dim LotE1 As Object = GridView1.GetFocusedRowCellValue("LotE1")
            Dim Bal1 As Object = GridView1.GetFocusedRowCellValue("Bal1")
            Dim UnitLot As Object = GridView1.GetFocusedRowCellValue("UnitLot")
            LotS1 = IIf(IsNumeric(LotS1), LotS1, 0)
            LotE1 = IIf(IsNumeric(LotE1), LotE1, 0)
            Bal1 = IIf(IsNumeric(Bal1), Bal1, 0)
            UnitLot = IIf(IsNumeric(UnitLot), UnitLot, 0)
            Dim MatQty1 = (LotE1 - LotS1 + 1) * UnitLot - Bal1
            MatQty1 = IIf(MatQty1 < 0, 0, MatQty1)
            GridView1.Columns("MatQty1").OptionsColumn.ReadOnly = True
            GridView1.SetFocusedRowCellValue("MatQty1", MatQty1)
            GridView1.Columns("MatQty1").OptionsColumn.ReadOnly = False
            obj.MatQty1 = MatQty1
        ElseIf GridView1.FocusedColumn.FieldName = "LotS2" Or GridView1.FocusedColumn.FieldName = "LotE2" Or
            GridView1.FocusedColumn.FieldName = "Bal2" Then
            Dim LotS2 As Object = GridView1.GetFocusedRowCellValue("LotS2")
            Dim LotE2 As Object = GridView1.GetFocusedRowCellValue("LotE2")
            Dim Bal2 As Object = GridView1.GetFocusedRowCellValue("Bal2")
            Dim UnitLot As Object = GridView1.GetFocusedRowCellValue("UnitLot")
            LotS2 = IIf(IsNumeric(LotS2), LotS2, 0)
            LotE2 = IIf(IsNumeric(LotE2), LotE2, 0)
            Bal2 = IIf(IsNumeric(Bal2), Bal2, 0)
            UnitLot = IIf(IsNumeric(UnitLot), UnitLot, 0)
            Dim MatQty2 = (LotE2 - LotS2 + 1) * UnitLot - Bal2
            MatQty2 = IIf(MatQty2 < 0, 0, MatQty2)
            GridView1.Columns("MatQty2").OptionsColumn.ReadOnly = True
            GridView1.SetFocusedRowCellValue("MatQty2", MatQty2)
            GridView1.Columns("MatQty2").OptionsColumn.ReadOnly = False
            obj.MatQty2 = MatQty2
        End If

        If col = "Time1Date" Then
            obj.Time1Date = DateTime.Now
        ElseIf col = "Time2Date" Then
            obj.Time2Date = DateTime.Now
        End If
        _db.Update(obj)
    End Sub

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
        GridView1.SetFocusedRowCellValue("ECode", lc.Properties.View.GetFocusedRowCellValue("ECode"))
        GridView1.SetFocusedRowCellValue("PdCode", lc.Properties.View.GetFocusedRowCellValue("PdCode"))
        GridView1.SetFocusedRowCellValue("JVName", lc.Properties.View.GetFocusedRowCellValue("JVName"))
        GridView1.SetFocusedRowCellValue("JEName", lc.Properties.View.GetFocusedRowCellValue("JEName"))
        GridView1.SetFocusedRowCellValue("SubPrcName", lc.Properties.View.GetFocusedRowCellValue("SubPrcName"))
        GridView1.SetFocusedRowCellValue("PrcName", lc.Properties.View.GetFocusedRowCellValue("PrcName"))
        GridView1.SetFocusedRowCellValue("Unit", lc.Properties.View.GetFocusedRowCellValue("Unit"))
        GridView1.SetFocusedRowCellValue("UnitLot", lc.Properties.View.GetFocusedRowCellValue("UnitLot"))
        GridView1.SetFocusedRowCellValue("MinQty", lc.Properties.View.GetFocusedRowCellValue("MinQty"))
        GridView1.SetFocusedRowCellValue("Tồn hiện tại", lc.Properties.View.GetFocusedRowCellValue("Tồn hiện tại"))
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If isEdit Or Not chbLockedTime1.Checked Or Not chbLockedTime2.Checked Then
            If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu ?") = Windows.Forms.DialogResult.Yes Then
                _db.ExecuteNonQuery(String.Format("DELETE PCM_TrayU00
                                               WHERE YMD = '{0}'
                                               AND ECode = '{1}'
                                               AND PdCode = '{2}'
                                               AND JCode = '{3}'
                                               AND SubPrcName = N'{4}'",
                                               GridView1.GetFocusedRowCellValue("YMD"),
                                               GridView1.GetFocusedRowCellValue("ECode"),
                                               GridView1.GetFocusedRowCellValue("PdCode"),
                                               GridView1.GetFocusedRowCellValue("JCode"),
                                               GridView1.GetFocusedRowCellValue("SubPrcName")))
                GridView1.DeleteSelectedRows()
            End If
        Else
            ShowWarning("Locked !")
        End If
    End Sub

    Private Sub slueJCode_BeforePopup(sender As Object, e As EventArgs) Handles slueJCode.BeforePopup
        If Not IsDBNull(GridView1.GetFocusedRowCellValue("ECode")) Then
            EcodeOld = GridView1.GetFocusedRowCellValue("ECode")
        End If
        If Not IsDBNull(GridView1.GetFocusedRowCellValue("PdCode")) Then
            PdCodeOld = GridView1.GetFocusedRowCellValue("PdCode")
        End If
        If Not IsDBNull(GridView1.GetFocusedRowCellValue("JCode")) Then
            JCodeOld = GridView1.GetFocusedRowCellValue("JCode")
        End If
        If Not IsDBNull(GridView1.GetFocusedRowCellValue("SubPrcName")) Then
            SubPrcNameOld = GridView1.GetFocusedRowCellValue("SubPrcName")
        End If
    End Sub

    Private Sub chbLockedTime1_CheckedChanged(sender As Object, e As EventArgs) Handles chbLockedTime1.CheckedChanged
        Dim obj As New PCM_LockDay
        obj.YMD_K = orderDate
        If _db.ExistObject(obj) Then
            _db.GetObject(obj)
            If chbLockedTime1.Checked Then
                obj.TrayLocked1 = True
            Else
                obj.TrayLocked1 = False
            End If
            _db.Update(obj)
        Else
            obj.JCodeLocked1 = True
            obj.JCodeLocked2 = True
            obj.JCodeLocked3 = True
            If chbLockedTime1.Checked Then
                obj.TrayLocked1 = True
            Else
                obj.TrayLocked1 = False
            End If
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
                obj.TrayLocked2 = True
            Else
                obj.TrayLocked2 = False
            End If
            _db.Update(obj)
        Else
            obj.JCodeLocked1 = True
            obj.JCodeLocked2 = True
            obj.JCodeLocked3 = True
            obj.TrayLocked1 = True
            If chbLockedTime2.Checked Then
                obj.TrayLocked2 = True
            Else
                obj.TrayLocked2 = False
            End If
            obj.DirectLocked = True
            obj.OutWSLocked = True
            _db.Insert(obj)
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub btnCheckLot_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCheckLot.ItemClick
        If GridView1.GetFocusedRowCellValue("JCode") IsNot Nothing Then
            FrmCheckLotOld._ECode = GridView1.GetFocusedRowCellValue("ECode")
            FrmCheckLotOld._JCode = GridView1.GetFocusedRowCellValue("JCode")
            FrmCheckLotOld._PdCode = GridView1.GetFocusedRowCellValue("PdCode")
            FrmCheckLotOld._SubPrcName = GridView1.GetFocusedRowCellValue("SubPrcName")
        End If
        Dim frm As New FrmCheckLotOld()
        frm.Show()
    End Sub

    Private Sub btnExportSum_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportSum.ItemClick
        Dim sfDlg As New SaveFileDialog()
        sfDlg.Filter = "Excel 2007|*.xlsx|Excel 2003|*.xls"
        sfDlg.FileName = String.Format("Số lượng xuất kho lần 1 ({0})- Khay và miếng tăng cứng.xlsx",
                                               DateTime.Now.ToString("dd.MM.yyyy"))
        sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\1.Xuat kho Nippon\XUAT KHO {0}\XKHO NL T{1} \Lần 1\",
                                               DateTime.Now.Year,
                                               DateTime.Now.ToString("MM.yyyy"))

        If sfDlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
        Dim para(0) As SqlClient.SqlParameter
        If isEdit Then
            para(0) = New SqlClient.SqlParameter("@ECode", DBNull.Value)
        Else
            para(0) = New SqlClient.SqlParameter("@ECode", CurrentUser.UserID)
        End If

        Dim sql As String = String.Format(" SELECT YMD, DeptName, JCode, PrcName, JEName, JVName, Unit,
                                            SUM(MatQty1) MatQty1, SUM(MatQty2) MatQty2, Note = ISNULL(Note,'')
                                            FROM PCM_TrayU00
                                            WHERE YMD = '{0}' AND 
                                            (@ECode IS NULL OR ECode = @ECode)
                                            GROUP BY YMD, DeptName, JCode, PrcName, JEName, JVName, Unit, ISNULL(Note,'')
                                            ORDER BY DeptName, PrcName, JCode",
                                            dteOrderDate.DateTime.ToString("yyyyMMdd"))
        ExportEXCEL(_db.FillDataTable(sql, para), sfDlg.FileName)
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowClick
        If Not IsDBNull(GridView1.GetFocusedRowCellValue("JCode")) Then
            Dim JCode As String = GridView1.GetFocusedRowCellValue("JCode")
            Dim stock As Decimal = 0
            Dim avalQty As Decimal = 0
            Dim heldQty As Decimal = 0
            Dim dt As DataTable = _db.FillDataTable(String.Format(" SELECT Qty, HeldQty 
                                                                FROM PCM_Stock 
                                                                WHERE JCode = '{0}'", JCode))
            If dt.Rows.Count = 0 Then
                Dim para(0) As SqlClient.SqlParameter
                para(0) = New SqlClient.SqlParameter("@Date", Date.Now.AddDays(-1))
                dt = _db.FillDataTable(String.Format("  SELECT GoodQty as Qty, HeldQty 
                                                    FROM LOS_StockDaily 
                                                    WHERE JCode = '{0}' 
                                                    AND EntryDate = @Date",
                                                    JCode),
                                                    para)
            End If
            If dt.Rows.Count > 0 Then
                avalQty = dt.Rows(0)("Qty")
                heldQty = dt.Rows(0)("HeldQty")
                stock = avalQty + heldQty
            End If
            txtStock.Text = stock
            txtInsStock.Text = avalQty
            txtNonInsStock.Text = heldQty
        End If
    End Sub
End Class