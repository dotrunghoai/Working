Imports CommonDB
Imports DevExpress.XtraGrid.Views.Grid
'Imports LibEntity
Imports PublicUtility

Public Class FrmEquipList
    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Public _isID As String = ""
    Public _isName As String = ""
    Public _isOption As Boolean = False

    Private Sub mnuExport_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub mnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
        'Dim para(0) As SqlClient.SqlParameter
        'para(0) = New SqlClient.SqlParameter("@Type", "All")
        Dim sql As String = "sp_QAE_LoadEquipList"
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB(sql)
        GridControlSetFormat(GridView1, 3)
        GridControlReadOnly(GridView1, True)
        GridControlSetColorReadonly(GridView1)

        'Change BackColor
    End Sub

    Private Sub FrmEquidList_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        If _isOption Then
            _isID = GridView1.GetFocusedRowCellValue("EquipCode")
            Close()
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        GridControlReadOnly(GridView1, True)
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        GridView1.Columns("EquipCode").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable = True And e.Column.ReadOnly = False Then
            If e.RowHandle < 0 Then
                If GridView1.GetFocusedRowCellValue("EquipCode") IsNot DBNull.Value Then
                    Dim objEquipList As New QAE_EquidList
                    objEquipList.EquipCode_K = GridView1.GetFocusedRowCellValue("EquipCode")
                    objEquipList.CreateDate = DateTime.Now
                    objEquipList.CreateUser = CurrentUser.UserID
                    If _db.ExistObject(objEquipList) Then
                        Dim para(0) As SqlClient.SqlParameter
                        para(0) = New SqlClient.SqlParameter("@Value", e.Value)
                        Dim sqlEdit As String = String.Format("update QAE_EquidList set {0} = @Value 
                        where EquipCode = '{1}'", e.Column.FieldName, GridView1.GetFocusedRowCellValue("EquipCode"))
                        _db.ExecuteNonQuery(sqlEdit, para)
                    Else
                        _db.Insert(objEquipList)
                    End If
                    GridControlReadOnly(GridView1, False)
                    GridView1.Columns("EquipCode").OptionsColumn.ReadOnly = True
                    GridControlSetColorReadonly(GridView1)
                    GridControlSetColorEdit(GridView1)
                End If
            Else
                Dim para(0) As SqlClient.SqlParameter
                para(0) = New SqlClient.SqlParameter("@Value", e.Value)
                Dim sqlEdit As String = String.Format("update QAE_EquidList set {0} = @Value 
                where EquipCode = '{1}'", e.Column.FieldName, GridView1.GetFocusedRowCellValue("EquipCode"))
                _db.ExecuteNonQuery(sqlEdit, para)
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        GridControlReadOnly(GridView1, False)
        GridView1.Columns("EquipCode").OptionsColumn.ReadOnly = True
        GridControlSetColorEdit(GridView1)
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Dim views As GridView = TryCast(sender, GridView)
        If e.RowHandle >= 0 Then
            If IsDate(views.GetRowCellValue(e.RowHandle, views.Columns("NextCalibDate"))) Then
                Dim dateT As DateTime = views.GetRowCellValue(e.RowHandle, views.Columns("NextCalibDate"))
                Dim monthNow As Integer = Integer.Parse(DateTime.Now.ToString("MM"))
                Dim monthDateT As Integer = Integer.Parse(dateT.ToString("MM"))
                Dim yearNow As Integer = Integer.Parse(DateTime.Now.ToString("yyyy"))
                Dim yearDateT As Integer = Integer.Parse(dateT.ToString("yyyy"))
                If dateT < DateTime.Now Then
                    e.Appearance.BackColor = Color.Red
                ElseIf monthDateT = monthNow And yearDateT = yearNow Then
                    e.Appearance.BackColor = Color.Orange
                ElseIf monthDateT >= 2 And monthDateT <= 12 Then
                    If (monthNow = (monthDateT - 1)) And (yearNow = yearDateT) Then
                        e.Appearance.BackColor = Color.Yellow
                    End If
                ElseIf monthDateT = 1 Then
                    If monthNow = 12 And yearNow = (yearDateT - 1) Then
                        e.Appearance.BackColor = Color.Yellow
                    End If
                End If
            End If

            If views.GetRowCellDisplayText(e.RowHandle, views.Columns("Status")) = "Hủy bỏ" Then
                e.Appearance.BackColor = Color.Black
                e.Appearance.ForeColor = Color.White
            ElseIf views.GetRowCellDisplayText(e.RowHandle, views.Columns("Status")) = "Lưu kho" Then
                e.Appearance.BackColor = Color.Purple
                'e.Appearance.ForeColor = Color.White
            ElseIf views.GetRowCellDisplayText(e.RowHandle, views.Columns("Status")) = "Sự cố" Then
                e.Appearance.BackColor = Color.Pink
            End If
        End If
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        'Import EquipList
        Dim dtEquipList As DataTable = ImportEXCEL(True)
        Dim soDong = 0
        If dtEquipList.Rows.Count > 0 Then
            For r = 0 To dtEquipList.Rows.Count - 1
                Dim c As Integer = 0
                Dim obj As New QAE_EquidList
                'obj.EquipCode_K = dtEquipList.Rows(r)(c).ToString.PadLeft(4, "0")
                obj.EquipCode_K = dtEquipList.Rows(r)(c)
                obj.EquipNameV = IIf(IsDBNull(dtEquipList.Rows(r)(c + 1)), Nothing, dtEquipList.Rows(r)(c + 1))
                obj.EquipNameE = IIf(IsDBNull(dtEquipList.Rows(r)(c + 2)), Nothing, dtEquipList.Rows(r)(c + 2))
                obj.Model = IIf(IsDBNull(dtEquipList.Rows(r)(c + 3)), Nothing, dtEquipList.Rows(r)(c + 3))
                obj.SerialNo = IIf(IsDBNull(dtEquipList.Rows(r)(c + 4)), Nothing, dtEquipList.Rows(r)(c + 4))
                obj.Manufacture = IIf(IsDBNull(dtEquipList.Rows(r)(c + 5)), Nothing, dtEquipList.Rows(r)(c + 5))
                obj.GroupName = IIf(IsDBNull(dtEquipList.Rows(r)(c + 6)), Nothing, dtEquipList.Rows(r)(c + 6))
                obj.PurchaseDate = IIf(IsDate(dtEquipList.Rows(r)(c + 7)), dtEquipList.Rows(r)(c + 7), Nothing)
                obj.CalibCycle = IIf(IsDBNull(dtEquipList.Rows(r)(c + 8)), Nothing, dtEquipList.Rows(r)(c + 8))
                obj.CurrentCalibDate = IIf(IsDate(dtEquipList.Rows(r)(c + 9)), dtEquipList.Rows(r)(c + 9), Nothing)
                obj.NextCalibDate = IIf(IsDate(dtEquipList.Rows(r)(c + 10)), dtEquipList.Rows(r)(c + 10), Nothing)
                obj.AbnorOccDate = IIf(IsDate(dtEquipList.Rows(r)(c + 11)), dtEquipList.Rows(r)(c + 11), Nothing)
                obj.DealingDate = IIf(IsDate(dtEquipList.Rows(r)(c + 12)), dtEquipList.Rows(r)(c + 12), Nothing)
                obj.Status = IIf(IsDBNull(dtEquipList.Rows(r)(c + 13)), Nothing, dtEquipList.Rows(r)(c + 13))
                obj.Accessories = IIf(IsDBNull(dtEquipList.Rows(r)(c + 14)), Nothing, dtEquipList.Rows(r)(c + 14))
                obj.TypeOfCal = IIf(IsDBNull(dtEquipList.Rows(r)(c + 15)), Nothing, dtEquipList.Rows(r)(c + 15))
                obj.Remark = IIf(IsDBNull(dtEquipList.Rows(r)(c + 16)), Nothing, dtEquipList.Rows(r)(c + 16))
                obj.NhomLuuTru = IIf(IsDBNull(dtEquipList.Rows(r)(c + 17)), Nothing, dtEquipList.Rows(r)(c + 17))

                If _db.ExistObject(obj) Then
                    _db.Update(obj)
                Else
                    _db.Insert(obj)
                    soDong += 1
                End If
            Next
            ShowSuccess(soDong)
            mnuShowAll.PerformClick()
        Else
            ShowWarning("File Excel không có dữ liệu")
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If ShowQuestion("Bạn có chắc chắn muốn xóa dữ liệu ?") = DialogResult.Yes Then
            _db.ExecuteNonQuery(String.Format("delete QAE_EquidList where EquipCode = '{0}'", GridView1.GetFocusedRowCellValue("EquipCode")))
            GridView1.DeleteSelectedRows()
        End If
    End Sub
End Class