Imports System.Globalization
Imports System.Windows.Forms
Imports System.IO
Imports System.Runtime.InteropServices

Imports CommonDB
Imports LibEntity
Imports PublicUtility

Public Class FrmProcessLeadTime : Inherits DevExpress.XtraEditors.XtraForm

    Private DB As DBSql

    Private bComboBoxLoading As Boolean = False

    Private EnuActionForm As ActionForm = ActionForm.FormLoad

    Enum ActionForm
        None = 0
        FormLoad = 1
        Edit = 2
        Back = 3
        Export = 4
        ShowAll = 5
        Delete = 6
    End Enum

    Private EditRight As Boolean = False
    Private BackRight As Boolean = False
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

            gridProductLeadTime.ReadOnly = True
            gridProductLeadTime.AllowUserToAddRows = False

            cboLeadTime.Enabled = True

            Try
                Select Case value
                    Case ActionForm.Edit
                        cboLeadTime.Enabled = False

                        gridProductLeadTime.ReadOnly = False
                        gridProductLeadTime.AllowUserToAddRows = True

                        gridProductLeadTime.Columns("UpdateDate").ReadOnly = True
                        gridProductLeadTime.Columns("UpdateUser").ReadOnly = True

                        PerformStatusActionForm(ActionForm.Edit)
                    Case ActionForm.ShowAll, ActionForm.Delete, ActionForm.Back
                        LoadAll()
                        PerformStatusActionForm(ActionForm.FormLoad)
                    Case ActionForm.FormLoad
                        LoadComboBox()
                        PerformStatusActionForm(ActionForm.FormLoad)
                End Select

            Catch ex As Exception
                ShowError(ex, "SetFormEvents", Me.Name)
            End Try
        End Set
    End Property

#Region "User Function"

    Private Sub PerformStatusActionForm(ByVal enuActionForm As ActionForm)
        mnuEdit.Enabled = EditRight
        mnuBack.Enabled = BackRight
        mnuExport.Enabled = ExportRight
        mnuShowAll.Enabled = ShowAllRight
        mnuDelete.Enabled = DeleteRight

        If (enuActionForm = ActionForm.FormLoad _
            Or enuActionForm = ActionForm.Back _
            Or enuActionForm = ActionForm.Delete) Then
            mnuBack.Enabled = False
        End If

        If (enuActionForm = ActionForm.Edit) Then
            mnuEdit.Enabled = False
            mnuShowAll.Enabled = False
        End If
    End Sub

    Private Sub LoadComboBox()
        bComboBoxLoading = True
        Dim sql As String = String.Format("SELECT ID, LeadTimeName FROM {0} ORDER BY LeadTimeName",
                                          PublicTable.Table_PD_MsLeadTime)
        Dim tbl As DataTable = DB.FillDataTable(sql)
        tbl.Rows.InsertAt(tbl.NewRow(), 0)
        cboLeadTime.DisplayMember = "LeadTimeName"
        cboLeadTime.ValueMember = "ID"
        cboLeadTime.DataSource = tbl
        bComboBoxLoading = False
        'Group
        tbl = DB.FillDataTable(String.Format("SELECT ReportGroupCode, ReportGroupName FROM {0} ORDER BY Idx",
                                             PublicTable.Table_PD_MsReportGroup))
        tbl.Rows.InsertAt(tbl.NewRow(), 0)
        ReportGroupCode.ValueMember = "ReportGroupCode"
        ReportGroupCode.DisplayMember = "ReportGroupName"
        ReportGroupCode.DataSource = tbl
    End Sub

    Private Sub LoadAll()
        If tblProductLeadTime IsNot Nothing Then tblProductLeadTime.Clear()

        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "LoadAll")
        para(1) = New SqlClient.SqlParameter("@LeadTimeID", cboLeadTime.SelectedValue)

        tblProductLeadTime = DB.ExecuteStoreProcedureTB("sp_PD_ProcessLeadTime", para)

        bsProductLeadTime.DataSource = tblProductLeadTime
        gridProductLeadTime.DataSource = bsProductLeadTime
        bnProductLeadTime.BindingSource = bsProductLeadTime

        'gridProductLeadTime.AutoResizeColumns()
    End Sub

    Private Function CheckDataBeforeSave() As Boolean
        Return True
    End Function

    Private Function GetID() As String
        Dim sql As String = String.Format("SELECT RIGHT('0000' + CAST(ISNULL(MAX(CAST(ID AS INT)),0) + 1 AS VARCHAR(4)),4) FROM {0}", PublicTable.Table_PD_ProcessLeadTime)
        Return CType(DB.ExecuteScalar(sql), String)
    End Function

    Private Function IsTheSameCellValue(ByVal dgv As DataGridView, ByVal arrCols() As Int16, ByVal row As Int16) As Boolean

        Dim sValue As String = String.Empty
        Dim sValueBf As String = String.Empty

        For Each column As Int16 In arrCols
            Dim cell As DataGridViewCell = dgv(column, row)
            If cell IsNot Nothing Then
                If cell.Value IsNot DBNull.Value Then sValue += cell.Value.ToString()
            End If

            Dim cellBf As DataGridViewCell = dgv(column, row - 1)
            If cellBf IsNot Nothing Then
                If cellBf.Value IsNot DBNull.Value Then sValueBf += cellBf.Value.ToString()
            End If
        Next

        If sValue = sValueBf Then : Return True
        Else : Return False
        End If

    End Function

#End Region

#Region "Form Function"

    Private Sub FrmProductLeadTime_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        EditRight = mnuEdit.Enabled
        BackRight = mnuBack.Enabled
        ExportRight = mnuExport.Enabled
        ShowAllRight = mnuShowAll.Enabled
        DeleteRight = mnuDelete.Enabled

        DB = New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

        SetFormEvents = ActionForm.FormLoad
    End Sub

    Private Sub FrmProductLeadTime_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

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
        If String.IsNullOrEmpty(cboLeadTime.Text) Then
            MessageBox.Show("<LeadTime> can not be empty", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLeadTime.Focus()
            Exit Sub
        End If
        SetFormEvents = ActionForm.ShowAll
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        If String.IsNullOrEmpty(cboLeadTime.Text) Then
            MessageBox.Show("<LeadTime> can not be empty", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLeadTime.Focus()
            Exit Sub
        End If
        mnuShowAll.PerformClick()
        SetFormEvents = ActionForm.Edit
    End Sub

    Private Sub mnuBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBack.Click
        If (MessageBox.Show("Do you want to back", "Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            SetFormEvents = ActionForm.Back
        End If
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        If String.IsNullOrEmpty(cboLeadTime.Text) Then
            MessageBox.Show("<LeadTime> can not be empty", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLeadTime.Focus()
            Exit Sub
        End If
        If gridProductLeadTime.Rows.Count = 0 Then Exit Sub
        If gridProductLeadTime.SelectedRows Is Nothing Then Exit Sub

        If ShowQuestionDelete() = DialogResult.No Then Exit Sub
        Try
            DB.BeginTransaction()
            For Each r As DataGridViewRow In gridProductLeadTime.SelectedRows
                Dim obj As New PD_ProcessLeadTime
                obj.ID_K = IIf(r.Cells("ID_K").Value Is DBNull.Value, String.Empty, r.Cells("ID_K").Value)
                DB.Delete(obj)
                gridProductLeadTime.Rows.Remove(r)
            Next
            DB.Commit()
        Catch ex As Exception
            DB.RollBack()

            ShowError(ex, mnuDelete.Text, Me.Name)
        End Try
    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        If gridProductLeadTime.Rows.Count > 0 Then
            ExportEXCEL(gridProductLeadTime, True)
        End If
    End Sub

#End Region

    Private Sub gridProductLeadTime_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridProductLeadTime.CellValueChanged, gridProductLeadTime.CellValueChanged
        Try
            If GetFormEvents <> ActionForm.Edit Then Exit Sub
            If gridProductLeadTime.CurrentRow Is Nothing Then Exit Sub

            If e.ColumnIndex = ID_K.Index Then
                Exit Sub
            End If

            bsProductLeadTime.EndEdit()

            Dim r As DataGridViewRow = gridProductLeadTime.CurrentRow

            If e.ColumnIndex = ProcessCode.Index Then
                Dim sql As String = String.Format("Select ProcessNameE From {0} Where ProcessCode = '{1}'", PublicTable.Table_INV_ProcessTemp, r.Cells("ProcessCode").Value)
                Dim tbl As DataTable = DB.FillDataTable(sql)
                If tbl.Rows.Count <> 0 Then
                    r.Cells("ProcessName").Value = tbl.Rows(0)("ProcessNameE")
                End If
            End If

            Dim sID_K As String = IIf(r.Cells("ID_K").Value Is DBNull.Value, GetID(), r.Cells("ID_K").Value)
            Dim obj As New PD_ProcessLeadTime

            obj.ID_K = sID_K

            DB.GetObject(obj)

            If obj.ID_K Is Nothing Then
                SetValues(obj, r)
                obj.ID_K = sID_K
                DB.Insert(obj)
            Else
                Dim sCondition As String = String.Format("ID='{0}'", sID_K)
                obj.ID_K = sID_K
                SetValues(obj, r)
                obj.UpdateDate = DateTime.Now
                obj.UpdateUser = CurrentUser.UserID
                DB.Update(obj, sCondition)
            End If

            r.Cells("ID_K").Value = obj.ID_K

        Catch ex As Exception
            ShowError(ex, "gridProductLeadTime_CellValueChanged", Me.Name)
        End Try
    End Sub

    Private Sub SetValues(ByRef obj As PD_ProcessLeadTime, ByVal r As DataGridViewRow)
        obj.LeadTimeID = CType(cboLeadTime.SelectedValue, String)
        obj.ProcessCode = If(r.Cells("ProcessCode").Value Is DBNull.Value, String.Empty, r.Cells("ProcessCode").Value.ToString())
        obj.ProcessName = If(r.Cells("ProcessName").Value Is DBNull.Value, String.Empty, r.Cells("ProcessName").Value.ToString())
        obj.ProcessNumber = If(r.Cells("ProcessNumber").Value Is DBNull.Value, String.Empty, r.Cells("ProcessNumber").Value.ToString())
        obj.ProcessNumberParent = If(r.Cells("ProcessNumberParent").Value Is DBNull.Value, String.Empty, r.Cells("ProcessNumberParent").Value.ToString())
        obj.Description = If(r.Cells("Description").Value Is DBNull.Value, String.Empty, r.Cells("Description").Value.ToString())
        obj.LeadTime = If(r.Cells("LeadTime").Value Is DBNull.Value, 0, CType(r.Cells("LeadTime").Value, Int32))
        obj.LeadTimePn = If(r.Cells("LeadTimePn").Value Is DBNull.Value, String.Empty, r.Cells("LeadTimePn").Value.ToString())
        obj.ReportGroupCode = If(r.Cells("ReportGroupCode").Value Is DBNull.Value, String.Empty, r.Cells("ReportGroupCode").Value.ToString())
        obj.ProcessGroup = If(r.Cells("ProcessGroup").Value Is DBNull.Value, 0, CType(r.Cells("ProcessGroup").Value, Int32))
        obj.Idx = If(r.Cells("Idx").Value Is DBNull.Value, 0, CType(r.Cells("Idx").Value, Int32))
        obj.CreateDate = DateTime.Now
        obj.CreateUser = CurrentUser.UserID
    End Sub

    Private Sub cboLeadTime_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeadTime.SelectedValueChanged
        If Not bComboBoxLoading Then mnuShowAll.PerformClick()
    End Sub

    Private Sub gridProductLeadTime_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles gridProductLeadTime.DataError
        e.Cancel = True
    End Sub
End Class