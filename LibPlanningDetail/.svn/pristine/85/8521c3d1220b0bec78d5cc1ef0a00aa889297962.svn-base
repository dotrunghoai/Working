Imports System.Globalization
Imports System.Windows.Forms
Imports System.IO
Imports System.Runtime.InteropServices

Imports CommonDB
Imports LibEntity
Imports PublicUtility

Public Class FrmProcessHour : Inherits DevExpress.XtraEditors.XtraForm

    Private DB As DBSql
    Private bs As BindingSource

    Private EnuActionForm As ActionForm = ActionForm.FormLoad

    Enum ActionForm
        None = 0
        FormLoad = 1
        Edit = 2
        Export = 3
        ShowAll = 4
        Delete = 5
    End Enum

    Private EditRight As Boolean = False
    Private ExportRight As Boolean = False
    Private ShowAllRight As Boolean = False
    Private DeleteRight As Boolean = False

    ReadOnly Property GetFormEvents As ActionForm
        Get
            Return EnuActionForm
        End Get
    End Property

    WriteOnly Property SetFormEvents As ActionForm
        Set(ByVal value As ActionForm)
            EnuActionForm = value
            gridProcessHour.ReadOnly = True
            gridProcessHour.AllowUserToAddRows = False
            Me.Cursor = Cursors.WaitCursor
            Try
                Select Case value
                    Case ActionForm.Edit
                        gridProcessHour.ReadOnly = False
                        gridProcessHour.Columns(ProcessNumber.Name).ReadOnly = True
                        gridProcessHour.Columns(ProcessName.Name).ReadOnly = True
                        gridProcessHour.Columns(CreateDate.Name).ReadOnly = True
                        gridProcessHour.Columns(CreateUser.Name).ReadOnly = True
                    Case ActionForm.ShowAll, ActionForm.Delete
                        LoadAll()
                    Case ActionForm.FormLoad
                        LoadCombox()
                End Select
                Me.Cursor = Cursors.Arrow
            Catch ex As Exception
                Me.Cursor = Cursors.Arrow
                ShowError(ex, "SetFormEvents", Me.Name)
            End Try
        End Set
    End Property

#Region "User Function"

    Private Sub LoadCombox()
        Dim sql As String = "select NULL as Product union all select Product from PD_DoubleSideProduct"
        Dim tbl As DataTable = DB.FillDataTable(sql)
        cboProduct.ValueMember = "Product"
        cboProduct.DisplayMember = "Product"
        cboProduct.DataSource = tbl
    End Sub

    Private Sub LoadAll()
        Try
            Dim sProduct As String = cboProduct.Text
            Dim sql As String = String.Format(" SELECT [Product],[ProcessNumber],[ProcessName],[Leadtime],LeadtimeSub,Remark,[Leadtime2]," +
                                              " [CreateUser], [CreateDate],[UpdateUser], [UpdateDate], [ProcessNumber_K] = [ProcessNumber] " +
                                              " FROM [dbo].[PD_ProcessHour] " +
                                              " WHERE Product='{0}'", sProduct)
            Dim tbl As DataTable = DB.FillDataTable(sql)
            gridProcessHour.AutoGenerateColumns = False
            bs = New BindingSource
            bs.DataSource = tbl
            gridProcessHour.DataSource = bs
            bnProcessHour.BindingSource = bs
            gridProcessHour.AutoResizeColumns()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Form Function"

    Private Sub FrmProcessHour_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        DB = New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        SetFormEvents = ActionForm.FormLoad
    End Sub

    Private Sub FrmProcessHour_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 And mnuShowAll.Enabled Then
            mnuShowAll.PerformClick()
        End If
        If e.KeyCode = Keys.E And e.Control And mnuEdit.Enabled Then
            mnuEdit.PerformClick()
        End If
        If e.KeyCode = Keys.D And e.Control And mnuDelete.Enabled Then
            mnuDelete.PerformClick()
        End If
    End Sub

    Private Sub mnuShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAll.Click
        SetFormEvents = ActionForm.ShowAll

        Dim ltime1 As Decimal = 0
        Dim ltime2 As Decimal = 0
        For Each r As DataGridViewRow In gridProcessHour.Rows
            If r.Cells("Leadtime").Value IsNot DBNull.Value Then
                ltime1 += r.Cells("Leadtime").Value
            End If
            If r.Cells("Leadtime2").Value IsNot DBNull.Value Then
                ltime2 += r.Cells("Leadtime2").Value
            End If
        Next
        txtLeadtime.Text = Math.Round(ltime1 / 24.0, 2)
        txtLeadtime2.Text = Math.Round(ltime2 / 24.0, 2)

        Dim sql As String = String.Format("select * from [PD_CustomerHour]")
        gridCS.DataSource = DB.FillDataTable(sql)
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        mnuShowAll.PerformClick()
        SetFormEvents = ActionForm.Edit
    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        If gridProcessHour.Rows.Count > 0 Then
            ExportEXCEL(gridProcessHour, True)
        End If
    End Sub

#End Region

    Private Sub gridProcessHour_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridProcessHour.CellValueChanged
        Try
            If GetFormEvents <> ActionForm.Edit Then Exit Sub
            If gridProcessHour.CurrentRow Is Nothing Then Exit Sub

            If e.ColumnIndex = ProcessNumber_K.Index Then
                Exit Sub
            End If

            bs.EndEdit()

            Dim r As DataGridViewRow = gridProcessHour.CurrentRow

            If r.Cells("ProcessNumber").Value Is DBNull.Value Then Exit Sub

            Dim sProcessNumber_K As String = If(r.Cells("ProcessNumber_K").Value Is DBNull.Value,
                                                String.Empty, r.Cells("ProcessNumber_K").Value)
            Dim obj As New PD_ProcessHour

            obj.Product_K = cboProduct.Text
            obj.ProcessNumber_K = sProcessNumber_K

            DB.GetObject(obj)

            If obj.ProcessNumber_K Is Nothing Then
                SetValues(obj, r)
                obj.CreateUser = CurrentUser.UserID
                obj.CreateDate = DateTime.Now
                DB.Insert(obj)
            Else
                Dim sCondition As String = String.Format("Product = '{0}' AND ProcessNumber = '{1}'",
                                                         cboProduct.Text, sProcessNumber_K)
                SetValues(obj, r)
                obj.UpdateUser = CurrentUser.UserID
                obj.UpdateDate = DateTime.Now
                DB.Update(obj)
            End If

            r.Cells("ProcessNumber_K").Value = obj.ProcessNumber_K

        Catch ex As Exception
            ShowError(ex, "gridProcessHour_CellValueChanged", Me.Name)
        End Try
    End Sub

    Private Sub SetValues(ByRef obj As PD_ProcessHour, ByVal r As DataGridViewRow)
        obj.Product_K = cboProduct.Text
        obj.ProcessNumber_K = If(r.Cells("ProcessNumber").Value Is DBNull.Value, String.Empty, r.Cells("ProcessNumber").Value)
        obj.ProcessName = If(r.Cells("ProcessName").Value Is DBNull.Value, String.Empty, r.Cells("ProcessName").Value)
        obj.Leadtime = If(r.Cells("Leadtime").Value Is DBNull.Value, 0, r.Cells("Leadtime").Value)
        obj.LeadtimeSub = If(r.Cells("LeadtimeSub").Value Is DBNull.Value, 0, r.Cells("LeadtimeSub").Value)
        obj.Remark = If(r.Cells("Remark").Value Is DBNull.Value, "", r.Cells("Remark").Value)
        obj.Leadtime2 = If(r.Cells("Leadtime2").Value Is DBNull.Value, 0, r.Cells("Leadtime2").Value)
    End Sub

    Private Sub SetValues(ByRef obj As PD_ProcessHour, ByVal r As DataRow)
        obj.Product_K = cboProduct.Text
        obj.ProcessNumber_K = If(r("ProcessNumber") Is DBNull.Value, String.Empty, r("ProcessNumber"))
        obj.ProcessName = If(r("ProcessName") Is DBNull.Value, String.Empty, r("ProcessName"))
        obj.Leadtime = If(r("Leadtime") Is DBNull.Value, 0, r("Leadtime"))
        obj.Leadtime2 = If(r("Leadtime2") Is DBNull.Value, 0, r("Leadtime2"))
        obj.Remark = If(r("Remark") Is DBNull.Value, 0, r("Remark"))
        obj.LeadtimeSub = If(r("LeadtimeSub") Is DBNull.Value, 0, r("LeadtimeSub"))
    End Sub

    Private Sub mnuImport_Click(sender As System.Object, e As System.EventArgs) Handles mnuImport.Click
        Try
            If cboProduct.Text = String.Empty Then
                MessageBox.Show("Bạn phải chọn product trước", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboProduct.Focus()
                Exit Sub
            End If
            Dim tbl As DataTable = ImportEXCEL("import")
            If _
                tbl.Rows.Count = 0 Then
                MessageBox.Show("Không có dữ liệu để import", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            DB.BeginTransaction()
            Try
                For Each r As DataRow In tbl.Rows
                    Dim sProcessNumber As String = If(r("ProcessNumber") Is DBNull.Value, String.Empty, r("ProcessNumber"))
                    If _
                        sProcessNumber = String.Empty Then Continue For
                    Dim obj As New PD_ProcessHour
                    obj.Product_K = cboProduct.Text.PadLeft(5, "0")
                    obj.ProcessNumber_K = r("ProcessNumber").ToString().PadLeft(2, "0")
                    DB.GetObject(obj)
                    If _
                        obj.ProcessNumber_K Is Nothing Then
                        Me.SetValues(obj, r)
                        obj.UpdateUser = CurrentUser.UserID
                        obj.UpdateDate = DateTime.Now
                        DB.Insert(obj)
                    Else
                        Me.SetValues(obj, r)
                        obj.UpdateUser = CurrentUser.UserID
                        obj.UpdateDate = DateTime.Now
                        DB.Update(obj)
                    End If
                Next
                DB.Commit()
            Catch ex As Exception
                DB.RollBack()
                Throw ex
            End Try
            Me.Cursor = Cursors.Arrow
            MessageBox.Show("Import dữ liệu thành công", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            ShowError(ex, mnuImport.Text, Me.Name)
        End Try
    End Sub

    Private Sub cboProduct_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cboProduct.SelectedValueChanged
        mnuShowAll.PerformClick()

        Dim sql As String = String.Format(" select c.LTStart,c.LTend from WT_product p " +
                                         " inner join [PD_CustomerHour] c" +
                                         " on p.CustomerName=c.customer and p.Method=c.method" +
                                         " where p.ProductCode='{0}' ", cboProduct.Text)
        Dim dtData As DataTable = DB.FillDataTable(sql)
        txtLT1.Text = 0
        txtLT2.Text = 0
        txtLeadtime.BackColor = Color.Khaki
        txtLeadtime2.BackColor = Color.Khaki
        If dtData.Rows.Count > 0 Then
            txtLT1.Text = dtData.Rows(0).Item("LTStart")
            txtLT2.Text = dtData.Rows(0).Item("LTend")
            If CType(txtLeadtime.Text, Decimal) > CType(txtLT1.Text, Decimal) Then
                txtLeadtime.BackColor = Color.Red
            End If
            If CType(txtLeadtime2.Text, Decimal) > CType(txtLT2.Text, Decimal) Then
                txtLeadtime2.BackColor = Color.Red
            End If
        End If
    End Sub

    Private Sub mnuProduct_Click(sender As System.Object, e As System.EventArgs) Handles mnuProduct.Click
        Dim frm As New FrmDSProduct
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadCombox()
        End If
    End Sub

    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click

        If String.IsNullOrEmpty(cboProduct.Text) Then
            MessageBox.Show("Bạn chưa chọn product", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboProduct.Focus()
            Exit Sub
        End If

        If gridProcessHour.Rows.Count = 0 Then Exit Sub
        If gridProcessHour.SelectedRows Is Nothing Then Exit Sub

        If ShowQuestionDelete() = DialogResult.No Then Exit Sub

        DB.BeginTransaction()

        Try
            For Each r As DataGridViewRow In gridProcessHour.SelectedRows
                Dim obj As New PD_ProcessHour
                obj.Product_K = cboProduct.Text
                obj.ProcessNumber_K = r.Cells("ProcessNumber").Value
                DB.Delete(obj)
            Next
            DB.Commit()
            SetFormEvents = ActionForm.Delete
        Catch ex As Exception
            DB.RollBack()
            ShowError(ex, mnuDelete.Text, Me.Name)
        End Try
    End Sub
     
    Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click

        For Each r As DataGridViewRow In gridCS.Rows
            If r.IsNewRow Then Continue For
            If r.Cells("Customer").Value Is DBNull.Value Or r.Cells("Method").Value Is DBNull.Value Then
                ShowWarning("Bạn chưa nhập đầy đủ thông tin !")
                Return
            End If
            Dim obj As New PD_CustomerHour
            obj.Customer_K = r.Cells("Customer").Value
            obj.Method_K = r.Cells("Method").Value
            obj.Leadtime = r.Cells("LeadtimeCS").Value
            obj.CanDuoi = r.Cells("CanDuoi").Value
            obj.CanTren = r.Cells("CanTren").Value
            obj.LTStart = obj.Leadtime - obj.CanDuoi
            obj.LTEnd = obj.Leadtime + obj.CanTren
            If DB.ExistObject(obj) Then
                DB.Update(obj)
            Else
                DB.Insert(obj)
            End If
        Next
        ShowSuccess()
    End Sub

    Private Sub mnuDeelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDeelete.Click
        If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
            If gridCS.CurrentRow.Cells("Customer").Value IsNot DBNull.Value And gridCS.CurrentRow.Cells("Method").Value IsNot DBNull.Value Then
                Dim obj As New PD_CustomerHour
                obj.Customer_K = gridCS.CurrentRow.Cells("Customer").Value
                obj.Method_K = gridCS.CurrentRow.Cells("Method").Value
                DB.Delete(obj)
                gridCS.Rows.Remove(gridCS.CurrentRow)
            End If
        End If
    End Sub

    Private Sub gridCS_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridCS.CellValueChanged
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = gridCS.Columns("LeadtimeCS").Index Or
               e.ColumnIndex = gridCS.Columns("CanDuoi").Index Or
               e.ColumnIndex = gridCS.Columns("CanTren").Index Then
                gridCS.CurrentRow.Cells("LTStart").Value = IIf(gridCS.CurrentRow.Cells("LeadtimeCS").Value IsNot DBNull.Value, gridCS.CurrentRow.Cells("LeadtimeCS").Value, 0) -
                                                           IIf(gridCS.CurrentRow.Cells("CanDuoi").Value IsNot DBNull.Value, gridCS.CurrentRow.Cells("CanDuoi").Value, 0)

                gridCS.CurrentRow.Cells("LTEnd").Value = IIf(gridCS.CurrentRow.Cells("LeadtimeCS").Value IsNot DBNull.Value, gridCS.CurrentRow.Cells("LeadtimeCS").Value, 0) +
                                                       IIf(gridCS.CurrentRow.Cells("CanTren").Value IsNot DBNull.Value, gridCS.CurrentRow.Cells("CanTren").Value, 0)
            End If
        End If
    End Sub
End Class