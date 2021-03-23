﻿Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports System.Windows.Forms

Public Class FrmImportStock : Inherits DevExpress.XtraEditors.XtraForm
    Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim nvd As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    'Dim dbAS As New DBFunction(PublicConst.EnumServers.NDV_DB2_AS400)
    Dim param(1) As SqlClient.SqlParameter
    Dim dtAllStock As DataTable
    Dim dtAllMter As DataTable

    Private Sub txtJCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJCode.TextChanged
        If dtAllStock Is Nothing Then
            Return
        Else
            Dim dv As DataView = New DataView(dtAllStock)
            dv.RowFilter = "[JCode] LIKE '%" + txtJCode.Text + "%'"
            Dim bd As New BindingSource()
            bd.DataSource = dv
            gridD.DataSource = bd
        End If
    End Sub

    Private Sub mnuImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImportStock.Click
        Dim sfDlg As New OpenFileDialog()
        sfDlg.DefaultExt = ".xlsx"
        sfDlg.Filter = "Excel 2007 file(.xlsx)|*.xlsx| Excel 2003 file(.xls)|*.xls"
        sfDlg.FileName = "Import.xlsx"
        sfDlg.InitialDirectory = String.Format("S:\COMMON\KHO\7. KIEM SOAT NHAP XUAT TON KHO NGUYEN LIEU1\XUAT KHO\xuất kho ERP NL\")
        If sfDlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        Try
            Dim dt As DataTable = ImportEXCEL(True, sfDlg.FileName)
            Me.Cursor = Cursors.WaitCursor

            If dt.Rows.Count = 0 Then
                ShowWarning("Không có dữ liệu để import !")
                Exit Sub
            End If

            If dt.Rows.Count <> 0 Then
                Dim slq As String = String.Format("Delete from PCM_Stock")
                nvd.ExecuteNonQuery(slq)

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim obj As New PCM_Stock()
                    'PART NO.
                    If dt.Rows(i).Item(0) IsNot DBNull.Value Then
                        obj.DDate_K = DateTime.Now
                        obj.JCode_K = Trim(dt.Rows(i).Item(0))
                    Else
                        Continue For
                    End If
                    'AVAIL QTY
                    If IsNumeric(dt.Rows(i).Item(4)) Then
                        obj.Qty = dt.Rows(i).Item(4)
                    End If
                    'PICKED QTY
                    If IsNumeric(dt.Rows(i).Item(5)) Then
                        obj.PickedQty = dt.Rows(i).Item(5)
                    End If
                    'HELD QTY
                    If IsNumeric(dt.Rows(i).Item(7)) Then
                        obj.HeldQty = dt.Rows(i).Item(7)
                    End If
                    'ACT ISSUE
                    If dt.Columns.Count >= 9 Then
                        If dt.Rows(i).Item(8) IsNot DBNull.Value Then
                            obj.ActQty = dt.Rows(i).Item(8)
                        End If
                    End If

                    Dim sqlJCode As String = String.Format("select ItemCode as JCode, ItemName as JName, " +
                    "UnitCode as Unit, BuyingMinimumQuantity as MinQty " +
                    "from t_ASMaterialItem " +
                    "Where ItemCode = '{0}'", dt.Rows(i).Item(0))
                    Dim dtJCode As DataTable = db.FillDataTable(sqlJCode)

                    Dim sqlSubCode As String = String.Format("select Code, Name, Unit from {0} " +
                    "where Code = '{1}'", PublicTable.Table_PCM_SubMter, dt.Rows(i).Item(0))
                    Dim dtSubCode As DataTable = nvd.FillDataTable(sqlSubCode)

                    If dtJCode.Rows.Count <> 0 Then
                        obj.JName = IIf(dtJCode.Rows(0).Item("JName") Is DBNull.Value, "", dtJCode.Rows(0).Item("JName"))
                        obj.Unit = IIf(dtJCode.Rows(0).Item("Unit") Is DBNull.Value, "", dtJCode.Rows(0).Item("Unit"))
                        obj.MinQty = IIf(dtJCode.Rows(0).Item("MinQty") Is DBNull.Value, 0, dtJCode.Rows(0).Item("MinQty"))
                    ElseIf dtSubCode.Rows.Count <> 0 Then
                        obj.JName = IIf(dtSubCode.Rows(0).Item("Name") Is DBNull.Value, "", dtSubCode.Rows(0).Item("Name"))
                        obj.Unit = IIf(dtSubCode.Rows(0).Item("Unit") Is DBNull.Value, "", dtSubCode.Rows(0).Item("Unit"))
                        obj.MinQty = 0
                    Else
                        obj.JName = ""
                        obj.Unit = ""
                        obj.MinQty = 0
                    End If

                    If obj.JName = "" Then
                        If dt.Rows(i).Item(1) IsNot DBNull.Value Then
                            obj.JName = Trim(dt.Rows(i).Item(1))
                        End If
                    End If

                    If nvd.ExistObject(obj) Then
                        nvd.Update(obj)
                    Else
                        nvd.Insert(obj)
                    End If
                Next
                Me.Cursor = Cursors.Arrow
                MsgBox("Import successfully.", MsgBoxStyle.OkOnly, "Import")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub mnuSubMter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSubMter.Click
        Try
            Dim dt As DataTable = ImportEXCEL(True)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Excel File must be format *.xls", "Error")
                Exit Sub
            End If

            If dt.Rows.Count <> 0 Then
                Dim slq As String = String.Format("Delete from {0}", PublicTable.Table_PCM_SubMter)
                nvd.ExecuteNonQuery(slq)

                For i As Integer = 0 To dt.Rows.Count - 1
                    Try
                        Application.DoEvents()
                        Dim obj As New PCM_SubMter()

                        If dt.Rows(i).Item(0) IsNot DBNull.Value Then
                            obj.Code_K = dt.Rows(i).Item(0)
                        Else
                            Continue For
                        End If
                        If dt.Rows(i).Item(1) IsNot DBNull.Value Then
                            obj.Name = dt.Rows(i).Item(1)
                        End If
                        If dt.Rows(i).Item(2) IsNot DBNull.Value Then
                            obj.Unit = dt.Rows(i).Item(2)
                        End If
                        'If dt.Rows(i).Item(5) IsNot DBNull.Value Then
                        '    obj.Unit = dt.Rows(i).Item(5)
                        'End If
                        'If dt.Rows(i).Item(6) IsNot DBNull.Value Then
                        '    obj.Unit = dt.Rows(i).Item(6)
                        'End If
                        'If dt.Rows(i).Item(7) IsNot DBNull.Value Then
                        '    obj.Packing = dt.Rows(i).Item(7)
                        'End If

                        'If dt.Rows(i).Item(9) IsNot DBNull.Value Then
                        '    obj.Price = dt.Rows(i).Item(9)
                        'End If
                        'If dt.Rows(i).Item(10) IsNot DBNull.Value Then
                        '    obj.Curr = dt.Rows(i).Item(10)
                        'End If

                        If nvd.ExistObject(obj) Then
                            nvd.Update(obj)
                        Else
                            nvd.Insert(obj)
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Next
                MsgBox("Import successfully.", MsgBoxStyle.OkOnly, "Import")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try

    End Sub

    Private Sub mnuShowStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowStock.Click
        dtAllStock = nvd.FillDataTable("SELECT DDate, JCode, Qty, PickedQty, ActQty, JName, Unit, MinQty, HeldQty
                                        FROM PCM_Stock")
        Dim bd As New BindingSource
        bd.DataSource = dtAllStock
        gridD.DataSource = bd
        bnGrid.BindingSource = bd
    End Sub

    Private Sub mnuShowSubMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowSubMat.Click
        Dim sqlLoad As String = String.Format("select Code, Name, Unit from {0}", PublicTable.Table_PCM_SubMter)
        dtAllMter = nvd.FillDataTable(sqlLoad)
        Dim bd As New BindingSource
        bd.DataSource = dtAllMter
        gridD.DataSource = bd
        bnGrid.BindingSource = bd
    End Sub


    Private Sub txtSubMat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubMat.TextChanged
        If dtAllMter Is Nothing Then
            Return
        Else
            Dim dv As DataView = New DataView(dtAllMter)
            dv.RowFilter = "[Code] LIKE '%" + txtSubMat.Text + "%'"
            Dim bd As New BindingSource()
            bd.DataSource = dv
            gridD.DataSource = bd
        End If
    End Sub

    Private Sub mnuImportCodePP_Click(sender As System.Object, e As System.EventArgs)
        Try
            Dim dt As DataTable = ImportEXCEL(True)
            Me.Cursor = Cursors.WaitCursor

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Excel File must be format *.xls", "Error")
                Exit Sub
            End If

            If dt.Rows.Count <> 0 Then
                'Dim slq As String = String.Format("Delete from PCM_ImportCodePP")
                'nvd.ExecuteNonQuery(slq)

                For i As Integer = 2 To dt.Rows.Count - 1
                    Dim obj As New PCM_ImportCodePP
                    'Code
                    If dt.Rows(i).Item(1) IsNot DBNull.Value Then
                        obj.CodePP_K = dt.Rows(i).Item(1)
                    Else
                        Continue For
                    End If
                    'Name
                    If dt.Rows(i).Item(2) IsNot DBNull.Value Then
                        obj.NamePP = dt.Rows(i).Item(2)
                    End If

                    'Unit
                    If dt.Rows(i).Item(3) IsNot DBNull.Value Then
                        obj.UnitPP = dt.Rows(i).Item(3)
                    End If
                    'Note
                    If dt.Rows(i).Item(4) IsNot DBNull.Value Then
                        obj.NotePP = dt.Rows(i).Item(4)
                    End If

                    If nvd.ExistObject(obj) Then
                        nvd.Update(obj)
                    Else
                        nvd.Insert(obj)
                    End If
                Next
                Me.Cursor = Cursors.Arrow
                MsgBox("Import successfully.", MsgBoxStyle.OkOnly, "Import")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub mnuShowCodePP_Click(sender As System.Object, e As System.EventArgs)
        Dim sqlLoad As String = String.Format("select * from {0} ", PublicTable.Table_PCM_ImportCodePP)
        dtAllStock = nvd.FillDataTable(sqlLoad)
        Dim bd As New BindingSource
        bd.DataSource = dtAllStock
        gridD.DataSource = bd
        bnGrid.BindingSource = bd
    End Sub
End Class