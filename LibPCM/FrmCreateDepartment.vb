Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports System.Windows.Forms

Public Class FrmCreateDepartment : Inherits DevExpress.XtraEditors.XtraForm
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _dbFpics As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim param(1) As SqlClient.SqlParameter
    Dim _cellClick As Integer = 0
    Private Sub FrmCreateDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt = _dbFpics.FillDataTable(
            "SELECT (LTrim(RTrim(ProcessNameE)) + '_' + LTrim(RTrim(ProcessCode))) AS SubPrc 
            FROM m_Process")
        For Each r As DataRow In dt.Rows
            cbbSubPrcName.Properties.Items.Add(r("SubPrc"))
        Next
        btnShow.PerformClick()
    End Sub
    Private Sub FrmCreateDepartment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.S And e.Control And btnSave.Enabled Then
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowClick
        _cellClick = 1
        txtDeptCode.Text = IIf(GridView1.GetFocusedRowCellValue("DeptCode") Is DBNull.Value, "", GridView1.GetFocusedRowCellValue("DeptCode"))
        txtDeptName.Text = IIf(GridView1.GetFocusedRowCellValue("DeptName") Is DBNull.Value, "", GridView1.GetFocusedRowCellValue("DeptName"))
        txtPrcName.Text = IIf(GridView1.GetFocusedRowCellValue("PrcName") Is DBNull.Value, "", GridView1.GetFocusedRowCellValue("PrcName"))
        cbbSubPrcName.Text = IIf(IsDBNull(GridView1.GetFocusedRowCellValue("SubPrcName")), "", GridView1.GetFocusedRowCellValue("SubPrcName"))
        txtECode.Text = IIf(GridView1.GetFocusedRowCellValue("ECode") Is DBNull.Value, "", GridView1.GetFocusedRowCellValue("ECode"))
        txtNote.Text = IIf(GridView1.GetFocusedRowCellValue("Note") Is DBNull.Value, "", GridView1.GetFocusedRowCellValue("Note"))
    End Sub
    Private Sub btnNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNew.ItemClick
        _cellClick = 0
        txtDeptCode.Text = ""
        txtDeptName.Text = ""
        txtPrcName.Text = ""
        cbbSubPrcName.SelectedIndex = -1
        txtECode.Text = ""
        txtNote.Text = ""
        txtDeptCode.Select()
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.FillDataTable(
            "SELECT h.DeptCode, h.DeptName, h.PrcName, h.SubPrcName, h.ECode, d.EName, h.Note 
            FROM PCM_Dept AS h
            LEFT JOIN HRM_Emloyee AS d
            ON h.ECode = d.ECode
            WHERE h.Old = 'False' 
            ORDER BY h.ECode, h.SubPrcName")
        GridControlSetFormat(GridView1, 3)
        GridView1.Columns("SubPrcName").Width = 200
        GridView1.Columns("EName").Width = 150
        GridView1.Columns("Note").Width = 200
    End Sub
    Function CheckField() As Boolean
        If txtDeptCode.Text = "" Then
            ShowWarning("Input DeptCode !")
            txtDeptCode.Select()
            Return False
        End If
        If txtDeptName.Text = "" Then
            ShowWarning("Input DeptName !")
            txtDeptName.Select()
            Return False
        End If
        If txtPrcName.Text = "" Then
            ShowWarning("Input Process Name !")
            txtPrcName.Select()
            Return False
        End If
        If cbbSubPrcName.Text = "" Then
            ShowWarning("Input Sub Process Name !")
            cbbSubPrcName.Select()
            Return False
        End If
        If txtECode.Text = "" Then
            ShowWarning("Input ECode !")
            txtECode.Select()
            Return False
        End If
        Return True
    End Function
    Private Sub btnSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSave.ItemClick
        If CheckField() Then
            Try
                _db.BeginTransaction()
                Dim obj As New PCM_Dept
                obj.DeptCode = Trim(txtDeptCode.Text)
                obj.DeptName = Trim(txtDeptName.Text)
                obj.PrcName = Trim(txtPrcName.Text)
                obj.SubPrcName_K = cbbSubPrcName.Text
                obj.ECode_K = Trim(txtECode.Text)
                obj.Note = Trim(txtNote.Text)
                obj.Old = False

                'Dim sql As String = String.Format("select UserID, FullName from {0} where UserID = '{1}'", PublicTable.Table_Main_User, txtECode.Text)
                'Dim dt As DataTable = _db.FillDataTable(sql)
                'If dt.Rows.Count <> 0 Then
                '    obj.EName = Trim(dt.Rows(0).Item("FullName"))
                'End If

                If _cellClick = 1 Then
                    Dim objDept As New PCM_Dept
                    objDept.SubPrcName_K = GridView1.GetFocusedRowCellValue("SubPrcName")
                    objDept.ECode_K = GridView1.GetFocusedRowCellValue("ECode")

                    Dim frmMterJCode As New FrmMaterialAndSubMaterial
                    frmMterJCode.UpdateAll(objDept.ECode_K, objDept.SubPrcName_K, obj.PrcName, obj.ECode_K, obj.SubPrcName_K)

                    Dim frmMterTrayU00 As New FrmTrayAndU00
                    frmMterTrayU00.UpdateAll(objDept.ECode_K, objDept.SubPrcName_K, obj.PrcName, obj.ECode_K, obj.SubPrcName_K)

                    _db.Delete(objDept)
                End If

                If _db.ExistObject(obj) Then
                    obj.UpdateDate = DateTime.Now
                    obj.UpdateUser = CurrentUser.UserID
                    ' Them tam chep du lieu xong rui xoa
                    obj.Old = False
                    _db.Update(obj)
                    MsgBox("Update successfully.", MsgBoxStyle.OkOnly, "Update")
                Else
                    obj.CreateDate = DateTime.Now
                    obj.CreateUser = CurrentUser.UserID
                    _db.Insert(obj)
                    MsgBox("Save successfully.", MsgBoxStyle.OkOnly, "Save")
                End If

                _db.Commit()
                btnShow.PerformClick()
                btnNew.PerformClick()
                txtDeptCode.Select()
            Catch ex As Exception
                _db.RollBack()
                ShowWarning(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If GridView1.RowCount = 0 Then Exit Sub

        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            Try

                _db.BeginTransaction()
                For Each r As Integer In GridView1.GetSelectedRows
                    Dim objDept As New PCM_Dept
                    objDept.ECode_K = GridView1.GetRowCellValue(r, "ECode")
                    objDept.SubPrcName_K = GridView1.GetRowCellValue(r, "SubPrcName")
                    _db.Delete(objDept)
                    Dim sql As String = String.Format("Delete from {0} where ECode = '{1}' and SubPrcName = '{2}' ",
                                                      PublicTable.Table_PCM_MterNotJCode, objDept.ECode_K, objDept.SubPrcName_K)
                    _db.ExecuteNonQuery(sql)
                    sql = String.Format("Delete from {0} where ECode = '{1}' and SubPrcName = '{2}' ",
                                                      PublicTable.Table_PCM_TrayU00, objDept.ECode_K, objDept.SubPrcName_K)
                    _db.ExecuteNonQuery(sql)
                Next
                _db.Commit()
                btnShow.PerformClick()
            Catch ex As Exception
                _db.RollBack()
                ShowWarning(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub btnRightSet_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRightSet.ItemClick
        Dim frmSetRight As New FrmPCMUserRight()
        frmSetRight.Show()
    End Sub
End Class