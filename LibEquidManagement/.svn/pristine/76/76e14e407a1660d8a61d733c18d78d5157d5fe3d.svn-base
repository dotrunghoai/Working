Imports CommonDB

Public Class FrmApprover
    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Sub LoadData()
        GridControl1.DataSource = _db.FillDataTable("select * from QAE_Approver")
        GridView1.Columns("ID").Visible = False
    End Sub
    Private Sub FrmApprover_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadData()
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.FieldName <> "ID" Then
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(" Update QAE_Approver" +
                                " set {0}=@Value " +
                                " where ID=1 ")
        End If
    End Sub
End Class