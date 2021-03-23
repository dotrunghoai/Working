Imports CommonDB
Imports PublicUtility
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Parameters
Imports DevExpress

Public Class FrmInputData
    Dim csdl As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmInputData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnLabel.PerformClick()
        btnShow.PerformClick()
    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "Progress")
        para(1) = New SqlClient.SqlParameter("@YM", "202002")
        para(2) = New SqlClient.SqlParameter("GroupCode", "01")

        Dim dt As DataTable = csdl.ExecuteStoreProcedureTB("sp_INV_Rpt_Progress", para)

        GridControl1.DataSource = dt
        GridView1.OptionsBehavior.Editable = False
        GridView1.OptionsSelection.EnableAppearanceHotTrackedRow = Utils.DefaultBoolean.True

        GridControlSetFormat(GridView1)
        'dt.TableName = "Group01"
        'dt.WriteXmlSchema("Group01.xsd")

    End Sub

    Private Sub btnPrintReport_Click(sender As Object, e As EventArgs) Handles btnPrintReport.Click

        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "Progress")
        para(1) = New SqlClient.SqlParameter("@YM", "202002")
        para(2) = New SqlClient.SqlParameter("GroupCode", "01")

        Dim dt As DataTable = csdl.ExecuteStoreProcedureTB("sp_INV_Rpt_Progress", para)

        Dim FrmReport As New FrmInputDataReport()
        FrmReport.DataSource = dt
        FrmReport.DataMember = ""

        Dim paraRP As New Parameter()
        FrmReport.Parameters("paraGroupName").Value = "01/2_Photo" 'gán giá trị
        FrmReport.Parameters("paraGroupName").Visible = False 'xuất hiện bảng Parameter or not

        Dim RePrTool As New ReportPrintTool(FrmReport)
        RePrTool.ShowPreview()

    End Sub

    Private Sub btnLabel_Click(sender As Object, e As EventArgs) Handles btnLabel.Click
        Dim dt As DataTable = csdl.FillDataTable("SELECT * 
                                                    FROM Main_TestTreeList 
                                                    ORDER BY VietTextName")
        'dt.Columns.Add("ID")
        'dt.Columns.Add("ParentID")
        'dt.Columns.Add("Status", GetType(Boolean))
        'dt.Columns.Add("VName")
        'dt.Columns.Add("EName")
        'dt.Rows.Add(0, -1, True, "Tiêu đề chính 1", "First")
        'dt.Rows.Add(1, -1, True, "Tiêu đề con 1", "Second")
        'dt.Rows.Add(2, 0, True, "Tiêu đề chính 2", "Third")
        'dt.Rows.Add(3, 2, False, "Tiêu đề con 3", "Fourth")
        'dt.Rows.Add(4, 2, True, "Tiêu đề con 4", "Fifth")
        'dt.Rows.Add(5, 1, True, "Tiêu đề con 5", "Sixth")
        'dt.Rows.Add(6, -1, False, "Tiêu đề con 6", "Seventh")
        'dt.Rows.Add(7, 3, True, "Tiêu đề con 7", "Eighth")
        'dt.Rows.Add(8, 7, False, "Tiêu đề con 8", "Nineth")
        'dt.Rows.Add(9, 1, False, "Tiêu đề con 9", "Tenth")

        TreeList1.DataSource = dt
        TreeList1.Columns("Lib").Visible = False
        TreeList1.Columns("Form").Visible = False
        TreeList1.OptionsBehavior.Editable = False
        TreeList1.OptionsSelection.EnableAppearanceHotTrackedRow = Utils.DefaultBoolean.True
        TreeList1.BorderStyle = XtraEditors.Controls.BorderStyles.NoBorder
        TreeList1.CollapseAll()
        TreeList1.ExpandToLevel(0)

        TreeList1.StateImageList = ImageCollection1

        'Dim dtC As DataTable = dt.Copy
        'TreeList2.DataSource = dtC
        'TreeList2.Columns("EName").Visible = False
        'TreeList2.Columns("Status").Width = 10
        'TreeList2.OptionsBehavior.Editable = False
        'TreeList2.Columns("Status").OptionsColumn.ReadOnly = False
        'TreeList2.Columns("VName").OptionsColumn.ReadOnly = True
        'TreeList2.OptionsSelection.EnableAppearanceHotTrackedRow = Utils.DefaultBoolean.True
        'TreeList2.BorderStyle = XtraEditors.Controls.BorderStyles.NoBorder
        'TreeList2.Columns("Status").AppearanceCell.TextOptions.HAlignment = Utils.HorzAlignment.Far
    End Sub

    Private Sub TreeList1_GetStateImage(sender As Object, e As XtraTreeList.GetStateImageEventArgs) Handles TreeList1.GetStateImage
        If e.Node.ParentNode Is Nothing Then
            e.NodeImageIndex = 0
        ElseIf e.Node.HasChildren Then
            e.NodeImageIndex = 1
        Else
            e.NodeImageIndex = 2
        End If
    End Sub

    Private Sub lblGroup_Click(sender As Object, e As EventArgs) Handles lblGroup.Click
        Dim frm As New FrmPhotoETNgoaiQuan
        frm.Show()
    End Sub

    'Private Sub TreeList1_DoubleClick(sender As Object, e As EventArgs) Handles TreeList1.DoubleClick
    '    If TreeList1.FocusedNode.HasChildren = False Then
    '        ShowSuccess()
    '    End If
    'End Sub
End Class