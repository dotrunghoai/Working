Imports PublicUtility
Imports CommonDB
Public Class TestTiep
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub TestTiep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim dt As New DataTable
        'dt.Columns.Add("ID")
        'dt.Columns.Add("Name")
        'dt.Columns.Add("Code")
        'dt.Rows.Add("1", "2", "3")
        'dt.Rows.Add("1", 2, "6")
        'dt.Rows.Add("9", "8", "7")
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style", "Basic")
        GridControl1.DataSource = _db.FillDataTable("SELECT *
                                                    FROM GA_TRM_RegisterPlanned_Detail_Time
                                                    ORDER BY ID, IDTrainingCode, Status")
        GridControlSetFormat(GridView1)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim val = GridView1.GetFocusedRowCellValue("Code")
        ShowWarning(val)
    End Sub
End Class