Imports CommonDB
Imports PublicUtility
Imports LibEntity
Imports DataGridViewAutoFilter

Imports System.Windows.Forms
Imports System.Text
Imports vb = Microsoft.VisualBasic
Imports System.Globalization

Public Class FrmCheckLock
    'Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
    Dim nvd As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    'Dim dbAS As New DBFunction(PublicConst.EnumServers.NDV_DB2_AS400)


    Private Sub FrmCheckLock_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim sql As String = String.Format("select YMD, JCodeLocked1, JCodeLocked2, JCodeLocked3, TrayLocked1, TrayLocked2, DirectLocked from {0} " +
        "where JCodeLocked1 = 'False' " +
        "or JCodeLocked2 = 'False' " +
        "or JCodeLocked3 = 'False' " +
        "or TrayLocked1 = 'False' " +
        "or TrayLocked2 = 'False' " +
        "or DirectLocked = 'False'", PublicTable.Table_PCM_LockDay)
        Dim bd As New BindingSource
        bd.DataSource = nvd.FillDataTable(sql)
        gridD.DataSource = bd
    End Sub
End Class