
Imports CommonDB
Imports LibEntity
Imports System.Windows.Forms
Imports PublicUtility
Imports System.IO

Public Class FrmDSProduct

    Dim db As DBSql
    Dim enuActionForm As ActionForm

    Dim NewRight As Boolean = False
    Dim DelRight As Boolean = False
    Dim ShowRight As Boolean = False

    Enum ActionForm
        Add = 1
        Delete = 2
        ShowAll = 3
        FormLoad = 4
        None = 0
    End Enum

    ReadOnly Property GetFormEvents As ActionForm
        Get
            Return enuActionForm
        End Get
    End Property

    WriteOnly Property SetFormEvents As ActionForm
        Set(ByVal value As ActionForm)
            enuActionForm = value

            gridDSProduct.AllowUserToAddRows = False
            gridDSProduct.AllowUserToDeleteRows = False
            gridDSProduct.ReadOnly = True

            Select Case value
                Case ActionForm.Add
                    gridDSProduct.AllowUserToAddRows = True
                    gridDSProduct.ReadOnly = False
                    '
                    PerformStatusActionForm(ActionForm.Add)
                Case ActionForm.FormLoad, ActionForm.ShowAll
                    gridDSProduct.AllowUserToAddRows = False
                    gridDSProduct.ReadOnly = True

                    LoadAll(PublicConst.ConditionDefault)

                    PerformStatusActionForm(ActionForm.FormLoad)
            End Select
        End Set
    End Property

#Region "user function"

    Sub PerformStatusActionForm(ByVal enuActionForm As ActionForm)

        mnuNew.Enabled = NewRight
        mnuDelete.Enabled = DelRight
        mnuShowAll.Enabled = ShowRight

        If (enuActionForm = ActionForm.Add) Then
            mnuNew.Enabled = False
        End If

    End Sub

    Sub LoadAll(ByVal condition As String)
        Try
            If tblDSProduct IsNot Nothing Then tblDSProduct.Rows.Clear()
            '
            tblDSProduct = db.FillDataTable(String.Format("SELECT Product, Product_K = Product FROM {0}",
                                                          PublicTable.Table_PD_DoubleSideProduct))
            '
            gridDSProduct.AutoGenerateColumns = False
            gridDSProduct.DataSource = bsDSProduct
            bsDSProduct.DataSource = tblDSProduct
        Catch ex As Exception
            ShowError(ex, "LoadAll", Me.Name)
        End Try
    End Sub

#End Region

#Region "Form Function"

    Private Sub FrmDSProduct_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        NewRight = mnuNew.Enabled
        DelRight = mnuDelete.Enabled
        ShowRight = mnuShowAll.Enabled
        db = New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        SetFormEvents = ActionForm.FormLoad
    End Sub

    Private Sub FrmDSProduct_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If

        If e.KeyCode = Keys.N And e.Control And mnuNew.Enabled Then
            mnuNew.PerformClick()
        End If

        If e.KeyCode = Keys.D And e.Control And mnuDelete.Enabled Then
            mnuNew.PerformClick()
        End If

        If e.KeyCode = Keys.F5 And mnuShowAll.Enabled Then
            mnuShowAll.PerformClick()
        End If
    End Sub


    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        SetFormEvents = ActionForm.Add
    End Sub

    Private Sub mnuShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAll.Click
        If Not mnuNew.Enabled Then
            mnuNew.Enabled = True
            gridDSProduct.ReadOnly = True
            gridDSProduct.AllowUserToAddRows = False
        End If
        Dim sCondition As String = " 1=1 "
        LoadAll(sCondition)
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        Try
            If gridDSProduct.SelectedRows().Count = 0 Then Exit Sub
            If (MessageBox.Show("Do you want to delete this records", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                db.BeginTransaction()
                For Each r As DataGridViewRow In gridDSProduct.SelectedRows()
                    Dim obj As New PD_DoubleSideProduct
                    obj.Product_K = If(r.Cells("Product").Value Is DBNull.Value, String.Empty, r.Cells("Product").Value.ToString())
                    db.Delete(obj)
                    gridDSProduct.Rows.Remove(r)
                Next
                db.Commit()
            End If
        Catch ex As Exception
            db.RollBack()
            ShowError(ex, "mnuDelete_Click", Me.Name)
        End Try
    End Sub

#End Region

    Private Sub gridDSProduct_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridDSProduct.CellValueChanged
        Try
            If GetFormEvents <> ActionForm.Add Then Exit Sub
            If e.ColumnIndex = Product_K.Index Then Exit Sub
            If gridDSProduct.CurrentRow Is Nothing Then Exit Sub

            'Commit
            bsDSProduct.EndEdit()

            'Variance
            Dim r As DataGridViewRow = gridDSProduct.CurrentRow
            If r.Cells("Product").Value Is DBNull.Value Then Exit Sub

            'Check exist
            Dim obj As New PD_DoubleSideProduct
            obj.Product_K = If(r.Cells("Product_K").Value Is DBNull.Value, String.Empty, r.Cells("Product_K").Value.ToString())
            db.GetObject(obj)

            'Save
            If obj.Product_K IsNot Nothing Then
                obj.Product_K = gridDSProduct.Item("Product", e.RowIndex).Value.ToString()
                db.Update(obj, String.Format("Product='{0}'", gridDSProduct.Item("Product_K", e.RowIndex).Value))
            Else
                obj.Product_K = gridDSProduct.Item("Product", e.RowIndex).Value.ToString()
                db.Insert(obj)
            End If
            r.Cells("Product_K").Value = obj.Product_K
        Catch ex As Exception
            ShowError(ex, "gridDSProduct_CellValueChanged", Me.Name)
        End Try
    End Sub

    Private Sub FrmDSProduct_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class