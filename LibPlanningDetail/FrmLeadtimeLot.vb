Imports System.Globalization
Imports System.Windows.Forms
Imports System.IO
Imports System.Runtime.InteropServices

Imports CommonDB
Imports LibEntity
Imports PublicUtility

Public Class FrmLeadtimeLot : Inherits DevExpress.XtraEditors.XtraForm

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

            gridLeadtimeLot.ReadOnly = True
            gridLeadtimeLot.AllowUserToAddRows = False
            Me.Cursor = Cursors.WaitCursor
            Try
                Select Case value
                    Case ActionForm.Edit
                        gridLeadtimeLot.ReadOnly = False
                        gridLeadtimeLot.AllowUserToAddRows = True
                    Case ActionForm.ShowAll, ActionForm.Delete, ActionForm.FormLoad
                        LoadAll()
                End Select
                Me.Cursor = Cursors.Arrow
            Catch ex As Exception
                Me.Cursor = Cursors.Arrow
                ShowError(ex, "SetFormEvents", Me.Name)
            End Try
        End Set
    End Property

#Region "User Function"

    Private Sub LoadAll()
        Try
            Dim sql As String = "select ProductCode, RevisionCode = max(RevisionCode) " +
                            "into #T " +
                            "from INV_ProductTemp " +
                            "group by ProductCode " +
                            "select ProductCode, RevisionCode, CustomerNameE " +
                            "into #T1 " +
                            "from INV_ProductTemp " +
                            "group by ProductCode, RevisionCode, CustomerNameE " +
                            "select A.ProductCode, B.CustomerNameE " +
                            "into #T2 " +
                            "from " +
                            "#T AS A " +
                            "inner join " +
                            "#T1 B " +
                            "on A.ProductCode = B.ProductCode and A.RevisionCode = B.RevisionCode "
            sql = String.Format(" {1} " +
                                " Select A.*, CustomerNameE = B.CustomerNameE, ProductCode_K = A.ProductCode " +
                                " From {0} A left join " +
                                " #T2 B On A.ProductCode = B.ProductCode Order by B.CustomerNameE, A.ProductCode ", PublicTable.Table_PD_LeadtimeLot, sql)
            Dim tbl As DataTable = DB.FillDataTable(sql)
            gridLeadtimeLot.AutoGenerateColumns = False
            bs = New BindingSource
            bs.DataSource = tbl
            gridLeadtimeLot.DataSource = bs
            bnCompleteProcess.BindingSource = bs
        Catch ex As Exception

            Throw ex
        End Try
    End Sub

#End Region

#Region "Form Function"

    Private Sub FrmLeadtimeLot_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        DB = New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        SetFormEvents = ActionForm.FormLoad
    End Sub

    Private Sub FrmLeadtimeLot_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 And mnuShowAll.Enabled Then
            mnuShowAll.PerformClick()
        End If
        If e.KeyCode = Keys.E And e.Control And mnuEdit.Enabled Then
            mnuEdit.PerformClick()
        End If
    End Sub


    Private Sub mnuShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAll.Click
        SetFormEvents = ActionForm.ShowAll
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        mnuShowAll.PerformClick()
        SetFormEvents = ActionForm.Edit
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If gridLeadtimeLot.Rows.Count = 0 Then Exit Sub
        If gridLeadtimeLot.SelectedRows Is Nothing Then Exit Sub
        If ShowQuestionDelete() = DialogResult.No Then Exit Sub
        Try
            DB.BeginTransaction()
            For Each r As DataGridViewRow In gridLeadtimeLot.SelectedRows
                Dim obj As New PD_LeadtimeLot
                obj.ProductCode_K = If(r.Cells("ProductCode_K").Value Is DBNull.Value, String.Empty, r.Cells("ProductCode_K").Value)
                DB.Delete(obj)
                gridLeadtimeLot.Rows.Remove(r)
            Next
            DB.Commit()
        Catch ex As Exception
            DB.RollBack()
            ShowError(ex, "mnuDelete_Click", Me.Name)
        End Try
    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        If gridLeadtimeLot.Rows.Count > 0 Then
            ExportEXCEL(gridLeadtimeLot, True)
        End If
    End Sub

#End Region

    Private Sub gridLeadtimeLot_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridLeadtimeLot.CellValueChanged
        Try
            If GetFormEvents <> ActionForm.Edit Then Exit Sub
            If gridLeadtimeLot.CurrentRow Is Nothing Then Exit Sub

            If e.ColumnIndex = ProductCode_K.Index Then
                Exit Sub
            End If

            bs.EndEdit()

            Dim r As DataGridViewRow = gridLeadtimeLot.CurrentRow

            If r.Cells("ProductCode").Value Is DBNull.Value Then Exit Sub

            Dim sProductCode_K As String = If(r.Cells("ProductCode_K").Value Is DBNull.Value, String.Empty, r.Cells("ProductCode_K").Value)
            Dim obj As New PD_LeadtimeLot

            obj.ProductCode_K = sProductCode_K

            DB.GetObject(obj)

            If obj.ProductCode_K Is Nothing Then
                SetValues(obj, r)
                obj.ProductCode_K = sProductCode_K
                DB.Insert(obj)
            Else
                Dim sCondition As String = String.Format("ProductCode='{0}'", ProductCode_K)
                obj.ProductCode_K = sProductCode_K
                SetValues(obj, r)
                DB.Update(obj, sCondition)
            End If

            r.Cells("ProductCode_K").Value = obj.ProductCode_K

        Catch ex As Exception
            ShowError(ex, "gridCompleteProcess_CellValueChanged", Me.Name)
        End Try
    End Sub

    Private Sub SetValues(ByRef obj As PD_LeadtimeLot, ByVal r As DataGridViewRow)
        obj.roisang1 = If(r.Cells("roisang1").Value Is DBNull.Value, 0D, r.Cells("roisang1").Value)
        obj.roisang2 = If(r.Cells("roisang2").Value Is DBNull.Value, 0D, r.Cells("roisang2").Value)
        obj.inmuc = If(r.Cells("inmuc").Value Is DBNull.Value, 0D, r.Cells("inmuc").Value)
        obj.etching1 = If(r.Cells("etching1").Value Is DBNull.Value, 0D, r.Cells("etching1").Value)
        obj.etching2 = If(r.Cells("etching2").Value Is DBNull.Value, 0D, r.Cells("etching2").Value)
        obj.plasma = If(r.Cells("plasma").Value Is DBNull.Value, 0D, r.Cells("plasma").Value)
        obj.laser = If(r.Cells("laser").Value Is DBNull.Value, 0D, r.Cells("laser").Value)
        obj.pth = If(r.Cells("pth").Value Is DBNull.Value, 0D, r.Cells("pth").Value)
        obj.dotlo = If(r.Cells("dotlo").Value Is DBNull.Value, 0D, r.Cells("dotlo").Value)
        obj.xulyuv = If(r.Cells("xulyuv").Value Is DBNull.Value, 0D, r.Cells("xulyuv").Value)
        obj.thumach1 = If(r.Cells("thumach1").Value Is DBNull.Value, 0D, r.Cells("thumach1").Value)
        obj.preset = If(r.Cells("preset").Value Is DBNull.Value, 0D, r.Cells("preset").Value)
        obj.say = If(r.Cells("say").Value Is DBNull.Value, 0D, r.Cells("say").Value)
        obj.entek = If(r.Cells("entek").Value Is DBNull.Value, 0D, r.Cells("entek").Value)
        obj.niau = If(r.Cells("niau").Value Is DBNull.Value, 0D, r.Cells("niau").Value)
        obj.tafue = If(r.Cells("tafue").Value Is DBNull.Value, 0D, r.Cells("tafue").Value)
        obj.cls00 = If(r.Cells("cls00").Value Is DBNull.Value, 0D, r.Cells("cls00").Value)
        obj.cls01 = If(r.Cells("cls01").Value Is DBNull.Value, 0D, r.Cells("cls01").Value)
        obj.kiem1 = If(r.Cells("kiem1").Value Is DBNull.Value, 0D, r.Cells("kiem1").Value)
        obj.clu00 = If(r.Cells("clu00").Value Is DBNull.Value, 0D, r.Cells("clu00").Value)
        obj.dot3 = If(r.Cells("dot3").Value Is DBNull.Value, 0D, r.Cells("dot3").Value)
        obj.giaap = If(r.Cells("giaap").Value Is DBNull.Value, 0D, r.Cells("giaap").Value)
        obj.phanloai = If(r.Cells("phanloai").Value Is DBNull.Value, 0D, r.Cells("phanloai").Value)
        obj.catS00 = If(r.Cells("catS00").Value Is DBNull.Value, 0D, r.Cells("catS00").Value)
        obj.catC00 = If(r.Cells("catC00").Value Is DBNull.Value, 0D, r.Cells("catC00").Value)
        obj.lami = If(r.Cells("lami").Value Is DBNull.Value, 0D, r.Cells("lami").Value)
        obj.developresist = If(r.Cells("developresist").Value Is DBNull.Value, 0D, r.Cells("developresist").Value)
        obj.ssexposurefirst = If(r.Cells("ssexposurefirst").Value Is DBNull.Value, 0D, r.Cells("ssexposurefirst").Value)
        obj.tapemask = If(r.Cells("tapemask").Value Is DBNull.Value, 0D, r.Cells("tapemask").Value)
        obj.softet1 = If(r.Cells("softet1").Value Is DBNull.Value, 0D, r.Cells("softet1").Value)
        obj.softet2 = If(r.Cells("softet2").Value Is DBNull.Value, 0D, r.Cells("softet2").Value)
        obj.softet3 = If(r.Cells("softet3").Value Is DBNull.Value, 0D, r.Cells("softet3").Value)
        obj.kiemdangtam = If(r.Cells("kiemdangtam").Value Is DBNull.Value, 0D, r.Cells("kiemdangtam").Value)
        obj.randomsample = If(r.Cells("randomsample").Value Is DBNull.Value, 0D, r.Cells("randomsample").Value)
        obj.laserdirect = If(r.Cells("laserdirect").Value Is DBNull.Value, 0D, r.Cells("laserdirect").Value)
    End Sub

    Private Sub SetValues(ByRef obj As PD_LeadtimeLot, ByVal r As DataRow)
        obj.ProductCode_K = r("ProductCode")
        obj.roisang1 = If(r("roisang1") Is DBNull.Value, 0D, r("roisang1"))
        obj.roisang2 = If(r("roisang2") Is DBNull.Value, 0D, r("roisang2"))
        obj.inmuc = If(r("inmuc") Is DBNull.Value, 0D, r("inmuc"))
        obj.etching1 = If(r("etching1") Is DBNull.Value, 0D, r("etching1"))
        obj.etching2 = If(r("etching2") Is DBNull.Value, 0D, r("etching2"))
        obj.plasma = If(r("plasma") Is DBNull.Value, 0D, r("plasma"))
        obj.laser = If(r("laser") Is DBNull.Value, 0D, r("laser"))
        obj.pth = If(r("pth") Is DBNull.Value, 0D, r("pth"))
        obj.dotlo = If(r("dotlo") Is DBNull.Value, 0D, r("dotlo"))
        obj.xulyuv = If(r("xulyuv") Is DBNull.Value, 0D, r("xulyuv"))
        obj.thumach1 = If(r("thumach1") Is DBNull.Value, 0D, r("thumach1"))
        obj.preset = If(r("preset") Is DBNull.Value, 0D, r("preset"))
        obj.say = If(r("say") Is DBNull.Value, 0D, r("say"))
        obj.entek = If(r("entek") Is DBNull.Value, 0D, r("entek"))
        obj.niau = If(r("niau") Is DBNull.Value, 0D, r("niau"))
        obj.tafue = If(r("tafue") Is DBNull.Value, 0D, r("tafue"))
        obj.cls00 = If(r("cls00") Is DBNull.Value, 0D, r("cls00"))
        obj.cls01 = If(r("cls01") Is DBNull.Value, 0D, r("cls01"))
        obj.kiem1 = If(r("kiem1") Is DBNull.Value, 0D, r("kiem1"))
        obj.clu00 = If(r("clu00") Is DBNull.Value, 0D, r("clu00"))
        obj.dot3 = If(r("dot3") Is DBNull.Value, 0D, r("dot3"))
        obj.giaap = If(r("giaap") Is DBNull.Value, 0D, r("giaap"))
        obj.phanloai = If(r("phanloai") Is DBNull.Value, 0D, r("phanloai"))
        obj.catS00 = If(r("catS00") Is DBNull.Value, 0D, r("catS00"))
        obj.catC00 = If(r("catC00") Is DBNull.Value, 0D, r("catC00"))
        obj.lami = If(r("lami") Is DBNull.Value, 0D, r("lami"))
        obj.developresist = If(r("developresist") Is DBNull.Value, 0D, r("developresist"))
        obj.ssexposurefirst = If(r("ssexposurefirst") Is DBNull.Value, 0D, r("ssexposurefirst"))
        obj.tapemask = If(r("tapemask") Is DBNull.Value, 0D, r("tapemask"))
        obj.softet1 = If(r("softet1") Is DBNull.Value, 0D, r("softet1"))
        obj.softet2 = If(r("softet2") Is DBNull.Value, 0D, r("softet2"))
        obj.softet3 = If(r("softet3") Is DBNull.Value, 0D, r("softet3"))
        obj.kiemdangtam = If(r("kiemdangtam") Is DBNull.Value, 0D, r("kiemdangtam"))
        obj.randomsample = If(r("randomsample") Is DBNull.Value, 0D, r("randomsample"))
        obj.laserdirect = If(r("laserdirect") Is DBNull.Value, 0D, r("laserdirect"))
    End Sub

    Private Sub txtProductCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProductCode.TextChanged, txtCustomerNameE.TextChanged
        If gridLeadtimeLot.DataSource Is Nothing Then Exit Sub
        Dim sFilter As String = String.Empty
        If txtProductCode.Text <> "" Then
            sFilter += String.Format("ProductCode like '%{0}%'", txtProductCode.Text)
        End If
        If txtCustomerNameE.Text <> "" Then
            If sFilter <> "" Then sFilter += " And "
            sFilter += String.Format("CustomerNameE like '{0}%'", txtCustomerNameE.Text)
        End If
        CType(CType(gridLeadtimeLot.DataSource, BindingSource).DataSource, DataTable).DefaultView.RowFilter = sFilter
    End Sub

    Private Sub mnuImport_Click(sender As System.Object, e As System.EventArgs) Handles mnuImport.Click
        Try
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
                    Dim sProductCode As String = If(r("ProductCode") Is DBNull.Value, String.Empty, r("ProductCode"))
                    If _
                        sProductCode = String.Empty Then Continue For
                    Dim obj As New PD_LeadtimeLot
                    obj.ProductCode_K = sProductCode
                    DB.GetObject(obj)
                    If _
                        obj.ProductCode_K Is Nothing Then
                        Me.SetValues(obj, r)
                        DB.Insert(obj)
                    Else
                        Me.SetValues(obj, r)
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

End Class