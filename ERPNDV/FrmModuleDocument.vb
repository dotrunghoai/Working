
Imports CommonDB

Imports LibEntity
Imports PublicUtility
Imports System.IO

Public Class FrmModuleDocument : Inherits DevExpress.XtraEditors.XtraForm
    Public _idModule As String = ""
    Public _ModuleName As String = ""

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmModuleDocument_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        Dim obj As New Main_ModuleDocument
        obj.ModuleID_K = _idModule
        _db.GetObject(obj)
        txtFlowchart.Text = obj.Flowchart
        txtHDSD.Text = obj.HDSD
        txtMTCN.Text = obj.MoTaChucNang
        txtYCVCT.Text = obj.YeuCau

        If CurrentUser.SortSection = "IT" Then
            bttAddFlowchart.Visible = True
            bttAddHDSD.Visible = True
            bttAddMTCN.Visible = True
            bttAddYCVCT.Visible = True
            bttSave.Visible = True
        Else
            bttAddFlowchart.Visible = False
            bttAddHDSD.Visible = False
            bttAddMTCN.Visible = False
            bttAddYCVCT.Visible = False
            bttSave.Visible = False
        End If
    End Sub

    Private Sub bttOpenHDSD_Click(sender As System.Object, e As System.EventArgs) Handles bttOpenHDSD.Click
        If File.Exists(txtHDSD.Text) Then
            Process.Start(txtHDSD.Text)
        End If
    End Sub

    Private Sub bttOpenYCVCT_Click(sender As System.Object, e As System.EventArgs) Handles bttOpenYCVCT.Click
        If File.Exists(txtYCVCT.Text) Then
            Process.Start(txtYCVCT.Text)
        End If
    End Sub

    Private Sub bttOpenMTCN_Click(sender As System.Object, e As System.EventArgs) Handles bttOpenMTCN.Click
        If File.Exists(txtMTCN.Text) Then
            Process.Start(txtMTCN.Text)
        End If
    End Sub

    Private Sub bttOpenFlowchart_Click(sender As System.Object, e As System.EventArgs) Handles bttOpenFlowchart.Click
        If File.Exists(txtFlowchart.Text) Then
            Process.Start(txtFlowchart.Text)
        End If
    End Sub

    Private Sub bttSave_Click(sender As System.Object, e As System.EventArgs) Handles bttSave.Click
        Dim obj As New Main_ModuleDocument
        obj.ModuleID_K = _idModule
        _db.GetObjectNotReset(obj)
        obj.Flowchart = txtFlowchart.Text
        obj.HDSD = txtHDSD.Text
        obj.MoTaChucNang = txtMTCN.Text
        obj.YeuCau = txtYCVCT.Text
        If _db.ExistObject(obj) Then
            _db.Update(obj)
        Else
            _db.Insert(obj)
        End If
        ShowSuccess()
    End Sub

    Private Sub bttAddHDSD_Click(sender As System.Object, e As System.EventArgs) Handles bttAddHDSD.Click
        Dim open As New OpenFileDialog
        If open.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtHDSD.Text = open.FileName
        End If
    End Sub

    Private Sub bttAddYCVCT_Click(sender As System.Object, e As System.EventArgs) Handles bttAddYCVCT.Click
        Dim open As New OpenFileDialog
        If open.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtYCVCT.Text = open.FileName
        End If
    End Sub

    Private Sub bttAddMTCN_Click(sender As System.Object, e As System.EventArgs) Handles bttAddMTCN.Click
        Dim open As New OpenFileDialog
        If open.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtMTCN.Text = open.FileName
        End If
    End Sub

    Private Sub bttAddFlowchart_Click(sender As System.Object, e As System.EventArgs) Handles bttAddFlowchart.Click
        Dim open As New OpenFileDialog
        If open.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtFlowchart.Text = open.FileName
        End If
    End Sub
End Class