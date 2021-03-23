Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports DataGridViewAutoFilter

Imports System.Windows.Forms
Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmSearchJCode
    Dim db As DBSql
    Dim nvd As DBSql
    Dim dt As DataTable
    Private Sub FrmSearchJCode_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Me.Cursor = Cursors.WaitCursor
            db = New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
            nvd = New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

            Dim sql As String = String.Format("select m.ItemCode as JCode, (LTrim(Rtrim(m.ItemName)) + ' ' + RTrim(LTrim(m.Remarks))) as JName, " +
             "m.QuantityParCarton as MinQty, m.UnitCode as Unit, v.VendorCode, v.VendorName, j.MakerCode, j.MakerFactoryCode " +
             "from (select mv.ItemCode, mv.VendorCode, mv.MakerCode, mv.MakerFactoryCode from (select ItemCode, max(LastPurchaseDate) as MaxDate " +
             "from t_ASMaterialItemVendor " +
             "group by ItemCode) as temp inner join t_ASMaterialItemVendor as mv " +
             "on temp.ItemCode = mv.ItemCode and temp.MaxDate = mv.LastPurchaseDate) as j " +
             "inner join t_ASMaterialItem m " +
             "on j.ItemCode = m.ItemCode " +
             "inner join t_ASMaterialVendor v " +
             "on j.VendorCode = v.VendorCode " +
             "order by j.ItemCode")

            Dim bd As New BindingSource()
            dt = db.FillDataTable(sql)
            bd.DataSource = db.FillDataTable(sql)
            gridSearch.DataSource = bd
            bnGrid.BindingSource = bd
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            ShowError(ex, "FrmSearchJCode_Shown", Me.Name)
        End Try
    End Sub

    Private Sub txtJCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtJCode.TextChanged
        Dim dv As DataView = New DataView(dt)
        dv.RowFilter = "[JCode] LIKE '%" + txtJCode.Text + "%'"
        Dim bd As New BindingSource()
        bd.DataSource = dv
        gridSearch.DataSource = bd
    End Sub

    Private Sub txtJName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtJName.TextChanged
        Dim dv As New DataView(dt)
        dv.RowFilter = "[JName] LIKE '%" + txtJName.Text + "%'"
        Dim bd As New BindingSource()
        bd.DataSource = dv
        gridSearch.DataSource = bd
    End Sub

    Private Sub gridSearch_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridSearch.MouseDoubleClick
        If gridSearch.CurrentRow IsNot Nothing Then
            FrmGSRMaterial.searchJCode = gridSearch.CurrentRow.Cells("JCode").Value
            FrmBWH.searchJCode = gridSearch.CurrentRow.Cells("JCode").Value
        End If
        Me.Close()
    End Sub
End Class