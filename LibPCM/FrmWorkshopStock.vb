Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports System.Windows.Forms

Public Class FrmWorkshopStock : Inherits DevExpress.XtraEditors.XtraForm
    'Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim nvd As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    'Dim dbAS As New DBFunction(PublicConst.EnumServers.NDV_DB2_AS400)
    Dim param(1) As SqlClient.SqlParameter
    Dim lock As Integer
    Dim cls As New clsApplication
    Dim dtAll As DataTable
    Dim IsView As Boolean = False


    Private Sub FrmStockWorkshop_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        If cls.checkUserIsView Then
            gridD.ReadOnly = True
            IsView = True
        End If
        LoadAll()
    End Sub

    Sub LoadAll()
        Dim StartDate As String = dtpStartDate.Value.ToString("yyyyMMdd")
        Dim EndDate As String = dtpEndDate.Value.ToString("yyyyMMdd")

        Dim sql As String = String.Format(" Select YMD, JCode, PrcName, FirstStock, QtyIn," +
                                          " QtyOut = (FirstStock + QtyIn) - (ConvertedQtyRestore + Adjust), ConvertedQtyRestore, Adjust, Remark, " +
                                          " JEName, JVName, Unit from {0} " +
                                          " where YMD >= '{1}' and YMD <= '{2}' order by YMD, PrcName, JCode",
                                          PublicTable.Table_PCM_WorkshopStock, StartDate, EndDate)
        dtAll = nvd.FillDataTable(sql)
        Dim bd As New BindingSource
        bd.DataSource = dtAll
        gridD.DataSource = bd
        bnGrid.BindingSource = bd
    End Sub

    Private Sub gridStock_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellValueChanged
        If IsView Then Exit Sub
        If gridD.CurrentRow Is Nothing Then Exit Sub
        If e.ColumnIndex = gridD.Columns("Adjust").Index Then
            Dim obj As New PCM_WorkshopStock
            obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
            obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
            obj.PrcName_K = gridD.CurrentRow.Cells("PrcName").Value
            nvd.GetObject(obj)
            obj.Adjust = gridD.CurrentRow.Cells("Adjust").Value
            nvd.Update(obj)
        End If
        If e.ColumnIndex = gridD.Columns("Remark").Index Then
            Dim obj As New PCM_WorkshopStock
            obj.YMD_K = gridD.CurrentRow.Cells("YMD").Value
            obj.JCode_K = gridD.CurrentRow.Cells("JCode").Value
            obj.PrcName_K = gridD.CurrentRow.Cells("PrcName").Value
            nvd.GetObject(obj)
            obj.Remark = IIf(gridD.CurrentRow.Cells("Remark").Value Is DBNull.Value, "", gridD.CurrentRow.Cells("Remark").Value)
            nvd.Update(obj)
        End If
        
    End Sub

    Private Sub mnuShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAll.Click
        LoadAll()
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        If gridD.CurrentRow Is Nothing Then Exit Sub

        Dim datarow As DataGridViewSelectedRowCollection = gridD.SelectedRows
        If datarow.Count > 0 Then
            Try
                If ShowQuestionDelete() = Windows.Forms.DialogResult.No Then Return
                Dim count As Integer = 0

                nvd.BeginTransaction()
                For row As Integer = 0 To datarow.Count - 1
                    Dim obj As New PCM_WorkshopStock
                    obj.YMD_K = IIf(IsDBNull(datarow.Item(row).Cells("YMD").Value), "", datarow.Item(row).Cells("YMD").Value)
                    obj.JCode_K = IIf(IsDBNull(datarow.Item(row).Cells("JCode").Value), "", datarow.Item(row).Cells("JCode").Value)
                    obj.PrcName_K = IIf(IsDBNull(datarow.Item(row).Cells("PrcName").Value), "", datarow.Item(row).Cells("PrcName").Value)
                    nvd.Delete(obj)
                Next

                For row As Integer = 0 To datarow.Count - 1
                    Dim bs As New BindingSource()
                    bs = gridD.DataSource
                    Dim rowDelete As DataRowView = DirectCast(bs.Current, DataRowView)
                    rowDelete.Delete()
                    count += 1
                Next
                nvd.Commit()
                ShowSuccess(count)
            Catch ex As Exception
                nvd.RollBack()
                nvd.CloseConnect()
                MessageBox.Show(ex.Message, "Delete")
            End Try
        End If
    End Sub

    Private Sub gridD_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridD.CellClick
        Dim JCode As String = Trim(gridD.CurrentRow.Cells("JCode").FormattedValue.ToString)
        tsStock.Text = stockWH(JCode)
    End Sub

    Function stockWH(ByVal JCode As String) As Decimal
        Dim sql As String = String.Format("select Qty from {0} where JCode = '{1}'", PublicTable.Table_PCM_Stock, JCode)
        Dim dt As DataTable = nvd.FillDataTable(sql)
        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Rows(0).Item("Qty")
        End If
    End Function

    Private Sub dtpStartDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpStartDate.ValueChanged
            dtpEndDate.Value = dtpStartDate.Value
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpEndDate.ValueChanged
        If dtpEndDate.Value < dtpStartDate.Value Then
            dtpStartDate.Value = dtpEndDate.Value
        End If
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(gridD)
    End Sub

    Private Sub txtJCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtJCode.TextChanged
        If dtAll Is Nothing Then
            Return
        Else
            Dim dv As DataView = New DataView(dtAll)
            dv.RowFilter = "[JCode] LIKE '%" + txtJCode.Text + "%'"
            Dim bd As New BindingSource()
            bd.DataSource = dv
            gridD.DataSource = bd
            bnGrid.BindingSource = bd
        End If
    End Sub

    Private Sub gridD_RowPrePaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles gridD.RowPrePaint
        If gridD.Rows(e.RowIndex).Cells("QtyOut").Value < 0 Then
            gridD.Rows(e.RowIndex).DefaultCellStyle.BackColor = Drawing.Color.Pink
        End If
    End Sub
End Class