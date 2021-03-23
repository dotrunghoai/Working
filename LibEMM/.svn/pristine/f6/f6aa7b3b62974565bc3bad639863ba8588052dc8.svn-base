
Imports CommonDB
'Imports LibEntity

Imports System.Windows
Imports System.Windows.Forms

Public Class FrmProductMaterialU00 : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _dbFpic As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_Fpics)


    Private Sub FrmProductMaterialU00_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub GetDate(ByVal pdCode As String, ByVal lotNo As String)
        Dim sql As String = String.Format(" SELECT [EndDate] FROM [t_ProcessResult] " +
                                          " where ProductCode='{0}' and LotNumber='{1}'  and ComponentCode='{2}' and ProcessCode='{3}' ",
                                          pdCode, lotNo, "B00", "9046")
        Dim obj As Object = _dbFpic.ExecuteScalar(sql)
        If obj Is Nothing Then
            Return
        Else
            obj = Convert.ToDateTime(obj).ToString("dd-MMM-yyyy")
        End If
        txtNgayGiaCong.Text = obj
    End Sub

    Private Sub mnuAdd_Click(sender As System.Object, e As System.EventArgs) Handles mnuAdd.Click
        If txtProductCode.Text = "" Then
            ShowWarning("Mã sản phẩm không được để trống.")
            txtProductCode.Focus()
            Return
        End If
        If txtLotB00.Text = "" Then
            ShowWarning("Lot B00 không được để trống.")
            txtLotB00.Focus()
            Return
        End If
        If txtLotTPX.Text = "" Then
            ShowWarning("Lot TPX không được để trống.")
            txtLotTPX.Focus()
            Return
        End If
        If txtNgayGiaCong.Text = "" Then
            ShowWarning("LotNo này chưa gia công hoặc không tồn tại.")
            Return
        End If
        Dim obj As New EMM_ProductU00
        obj.Code_K = grid.CurrentRow.Cells("Code").Value
        obj.LotB00_K = txtLotB00.Text
        obj.LotTPX = txtLotTPX.Text
        obj.ProductCode_K = txtProductCode.Text
        obj.StartDate = Convert.ToDateTime(txtNgayGiaCong.Text)
        If Not _db.ExistObject(obj) Then
            _db.Insert(obj)
        End If

        txtProductCode.Text = ""
        txtLotB00.Text = ""
        txtLotTPX.Text = ""
        txtNgayGiaCong.Text = ""
        txtProductCode.Focus()
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dtpStart.Value))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dtpEnd.Value))
        Dim para2(2) As SqlClient.SqlParameter
        para2(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dtpStart.Value))
        para2(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(dtpEnd.Value))
        para2(2) = New SqlClient.SqlParameter("@Code", DBNull.Value)
        If rdoInCome.Checked Then
            para(2) = New SqlClient.SqlParameter("@Type", "InComingDate")
        Else
            para(2) = New SqlClient.SqlParameter("@Type", "InspectionDate")
        End If
        Dim bdsource As New BindingSource
        bdsource.DataSource = _db.ExecuteStoreProcedureTB("[sp_EMM_LoadMaterialU00]", para)
        bdn.BindingSource = bdsource
        grid.DataSource = bdsource

        Dim bdsource2 As New BindingSource
        bdsource2.DataSource = _db.ExecuteStoreProcedureTB("[sp_EMM_LoadProductMaterialU00]", para2)
        gridProduct.DataSource = bdsource2
    End Sub

    Private Sub grid_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellClick
        Dim para2(2) As SqlClient.SqlParameter
        para2(0) = New SqlClient.SqlParameter("@StartDate", DBNull.Value)
        para2(1) = New SqlClient.SqlParameter("@EndDate", DBNull.Value)
        para2(2) = New SqlClient.SqlParameter("@Code", grid.CurrentRow.Cells("Code").Value)

        Dim bdsource2 As New BindingSource
        bdsource2.DataSource = _db.ExecuteStoreProcedureTB("[sp_EMM_LoadProductMaterialU00]", para2)
        gridProduct.DataSource = bdsource2
    End Sub

    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click
        If gridProduct.CurrentRow IsNot Nothing Then
            If ShowQuestionDelete() = Forms.DialogResult.Yes Then
                Dim obj As New EMM_ProductU00
                obj.Code_K = gridProduct.CurrentRow.Cells("CodeP").Value
                obj.LotB00_K = gridProduct.CurrentRow.Cells("LotB00").Value
                obj.ProductCode_K = gridProduct.CurrentRow.Cells("ProductCode").Value
                _db.Delete(obj)

                Dim para2(2) As SqlClient.SqlParameter
                para2(0) = New SqlClient.SqlParameter("@StartDate", DBNull.Value)
                para2(1) = New SqlClient.SqlParameter("@EndDate", DBNull.Value)
                para2(2) = New SqlClient.SqlParameter("@Code", grid.CurrentRow.Cells("Code").Value)

                Dim bdsource2 As New BindingSource
                bdsource2.DataSource = _db.ExecuteStoreProcedureTB("[sp_EMM_LoadProductMaterialU00]", para2)
                gridProduct.DataSource = bdsource2
            End If
        End If
    End Sub

    Private Sub txtLotB00_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLotB00.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtLotB00.Text <> "" Then
                txtLotB00.Text = txtLotB00.Text.PadLeft(5, "0")
                GetDate(txtProductCode.Text, txtLotB00.Text)
            End If
        End If
    End Sub

    Private Sub txtProductCode_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtProductCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtProductCode.Text <> "" Then
                txtProductCode.Text = txtProductCode.Text.PadLeft(5, "0")
            End If
        End If
    End Sub

    Private Sub txtJCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtJCode.TextChanged
        If bdn.BindingSource IsNot Nothing Then
            If txtJCode.Text <> "" Then
                bdn.BindingSource.Filter = String.Format(" JCode like '%{0}%'", txtJCode.Text)
            Else
                bdn.BindingSource.Filter = ""
            End If
        End If
    End Sub

    Private Sub txtMaterialLotNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMaterialLotNo.TextChanged
        If bdn.BindingSource IsNot Nothing Then
            If txtMaterialLotNo.Text <> "" Then
                bdn.BindingSource.Filter = String.Format(" MaterialLotNo like '%{0}%'", txtMaterialLotNo.Text)
            Else
                bdn.BindingSource.Filter = ""
            End If
        End If
    End Sub

    Private Sub txtLotTPX_Click(sender As System.Object, e As System.EventArgs) Handles txtLotTPX.Click
        Dim bdsource As New BindingSource
        bdsource = gridProduct.DataSource
        If bdsource IsNot Nothing Then
            If txtLotTPX.Text <> "" Then
                bdsource.Filter = String.Format(" LotTPx like '%{0}%'", txtLotTPX.Text)
            Else
                bdsource.Filter = ""
            End If
        End If
    End Sub

    Private Sub txtLotB00_Click(sender As System.Object, e As System.EventArgs) Handles txtLotB00.Click
        Dim bdsource As New BindingSource
        bdsource = gridProduct.DataSource
        If bdsource IsNot Nothing Then
            If txtLotB00.Text <> "" Then
                bdsource.Filter = String.Format(" LotB00 like '%{0}%'", txtLotB00.Text)
            Else
                bdsource.Filter = ""
            End If
        End If
    End Sub

    Private Sub txtProductCode_Click(sender As System.Object, e As System.EventArgs) Handles txtProductCode.Click
        Dim bdsource As New BindingSource
        bdsource = gridProduct.DataSource
        If bdsource IsNot Nothing Then
            If txtProductCode.Text <> "" Then
                bdsource.Filter = String.Format(" ProductCode like '%{0}%'", txtProductCode.Text)
            Else
                bdsource.Filter = ""
            End If
        End If
    End Sub

    Private Sub mnuExportPdCode_Click(sender As System.Object, e As System.EventArgs) Handles mnuExportPdCode.Click
        ExportEXCEL(gridProduct)
    End Sub
End Class