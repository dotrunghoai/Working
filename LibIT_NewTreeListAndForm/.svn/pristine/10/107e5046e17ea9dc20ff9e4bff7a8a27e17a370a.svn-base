Imports System.Windows.Forms
Imports CommonDB
Imports DevExpress.XtraGrid.Columns
Imports PublicUtility

Public Class FrmGroupOfUserSPC

#Region "Variable"
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Public _uID As String = ""
#End Region

#Region "User function"
    Sub LoadAll()
        Dim obj As New DCS_User
        obj.UserID_K = _uID
        If Not _db.ExistObject(obj) Then
            _db.Insert(obj)
        End If
        Dim sql As String = String.Format("select * from DCS_User where UserID='{0}' ",
                                           _uID)
        GridControl1.DataSource = _db.FillDataTable(sql)
        GridControlSetFormat(GridView1, 3)
        GridControlSetWidth(GridView1, 50)
    End Sub
#End Region

#Region "Form function"

    Private Sub FrmGroupOfUser_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        LoadAll()
    End Sub

    Private Sub mnuCheckall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheckall.Click
        For Each col As GridColumn In GridView1.Columns
            If col.FieldName <> "UserID" Then
                GridView1.SetFocusedRowCellValue(col, True)
            End If
        Next
    End Sub

    Private Sub mnuUncheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUncheck.Click
        For Each col As GridColumn In GridView1.Columns
            If col.FieldName <> "UserID" Then
                GridView1.SetFocusedRowCellValue(col, False)
            End If
        Next
    End Sub

    Private Sub FrmGroupOfUser_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub


#End Region

    Private Sub FrmGroupOfUserSPC_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Dim obj As New DCS_User
        obj.UserID_K = _uID
        _db.GetObject(obj)
        obj.QA = GridView1.GetFocusedRowCellValue("QA")
        obj.IQC = GridView1.GetFocusedRowCellValue("IQC")
        obj.QC_Gate_PR1 = GridView1.GetFocusedRowCellValue("QC_Gate_PR1")
        obj.QC_Gate_PR2 = GridView1.GetFocusedRowCellValue("QC_Gate_PR2")
        obj.PR1 = GridView1.GetFocusedRowCellValue("PR1")
        obj.TE = GridView1.GetFocusedRowCellValue("TE")
        obj.AE = GridView1.GetFocusedRowCellValue("AE")

        obj.QAEdit = GridView1.GetFocusedRowCellValue("QAEdit")
        obj.IQCEdit = GridView1.GetFocusedRowCellValue("IQCEdit")
        obj.QC_Gate_PR1_Edit = GridView1.GetFocusedRowCellValue("QC_Gate_PR1_Edit")
        obj.QC_Gate_PR2_Edit = GridView1.GetFocusedRowCellValue("QC_Gate_PR2_Edit")
        obj.PR1Edit = GridView1.GetFocusedRowCellValue("PR1Edit")
        obj.TEEdit = GridView1.GetFocusedRowCellValue("TEEdit")
        obj.AEEdit = GridView1.GetFocusedRowCellValue("AEEdit")

        _db.Update(obj)
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridView1.RowCellClick
        If e.Column.FieldName <> "UserID" Then
            If e.CellValue Then
                GridView1.SetFocusedRowCellValue(e.Column, False)
            Else
                GridView1.SetFocusedRowCellValue(e.Column, True)
            End If
        End If
    End Sub
End Class