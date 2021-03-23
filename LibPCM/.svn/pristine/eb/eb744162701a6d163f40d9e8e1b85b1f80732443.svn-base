Imports System.Windows.Forms
Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports DataGridViewAutoFilter

Imports System.Text
Imports vb = Microsoft.VisualBasic
Imports System.Globalization

Public Class FrmPCMUserRight : Inherits DevExpress.XtraEditors.XtraForm 
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV) 

    Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
        Dim obj As New PCM_UserRight
        If Trim(txtUserID.Text) = "" Then
            ShowWarning("Mã NV không được để trống.")
            Exit Sub
        Else
            obj.UserID_K = txtUserID.Text.PadLeft(5, "0")
        End If

        obj.IsAll = chkIsAll.Checked
        obj.IsView = chkIsView.Checked
        obj.IsAdmin = ckoIsAdmin.Checked
        obj.CreateDate = DateTime.Now
        obj.CreateUser = CurrentUser.UserID

        Dim objN As New OT_Employee
        objN.EmpID_K = obj.UserID_K
        _db.GetObject(objN)
        obj.FullName = objN.EmpName
        If obj.FullName = "" Then
            ShowWarning("Mã NV không tồn tại. Vui lòng kiểm tra lại.")
        End If
        If _db.ExistObject(obj) Then 
            _db.Update(obj)
        Else
            _db.Insert(obj)
        End If

        LoadAll()
        txtUserID.Text = ""
        chkIsAll.Checked = False
        chkIsView.Checked = False
        ckoIsAdmin.Checked = False
        txtUserID.Focus()
    End Sub
    Sub LoadAll()
        Dim sql As String = String.Format("select UserID, FullName, IsAll, IsView,isAdmin from {0} order by UserID",
                                          PublicTable.Table_PCM_UserRight)
        Dim bd As New BindingSource
        bd.DataSource = _db.FillDataTable(sql)
        gridD.DataSource = bd
    End Sub
    Private Sub FrmUserRight_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        LoadAll()
    End Sub

    Private Sub gridD_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellClick
        If gridD.CurrentRow IsNot Nothing Then
            txtUserID.Text = IIf(gridD.CurrentRow.Cells("UserID").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("UserID").Value)
            txtTenNV.Text = IIf(gridD.CurrentRow.Cells("FullName").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("FullName").Value)
            chkIsAll.Checked = IIf(gridD.CurrentRow.Cells("IsAll").Value Is DBNull.Value, False, gridD.CurrentRow.Cells("IsAll").Value)
            chkIsView.Checked = IIf(gridD.CurrentRow.Cells("IsView").Value Is DBNull.Value, False, gridD.CurrentRow.Cells("IsView").Value)
            ckoIsAdmin.Checked = IIf(gridD.CurrentRow.Cells("IsAdmin").Value Is DBNull.Value, False, gridD.CurrentRow.Cells("IsAdmin").Value)
        End If
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        If gridD.Rows.Count = 0 Then Exit Sub

        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            Dim obj As New PCM_UserRight
            obj.UserID_K = gridD.CurrentRow.Cells("UserID").Value
            _db.Delete(obj)
            LoadAll()
        End If
    End Sub
     
    Private Sub txtUserID_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUserID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtUserID.Text <> "" Then
                txtUserID.Text = txtUserID.Text.PadLeft(5, "0")
                Dim objN As New OT_Employee
                objN.EmpID_K = txtUserID.Text
                _db.GetObject(objN)
                txtTenNV.Text = objN.EmpName
            End If
        End If
    End Sub
End Class