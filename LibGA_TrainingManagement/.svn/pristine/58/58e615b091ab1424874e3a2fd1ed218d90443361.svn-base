Imports CommonDB
Imports PublicUtility
Public Class FrmFollowHistory
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmFollowHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShow.PerformClick()
        Dim obj As New Main_UserRight
        obj.UserID_K = CurrentUser.UserID
        obj.FormID_K = Tag
        _db.GetObject(obj)
        If obj.IsEdit = False And obj.IsAdmin = False Then
            ViewAccess()
        End If
    End Sub
    Sub ViewAccess()
        btnSendMail.Enabled = False
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridView1.Columns.Clear()
        If rdoHistory.Checked Then
            GridControl1.DataSource = _db.FillDataTable("
            SELECT h.Section, h.ID, d.IDTrainingCode, d.TrainingProgram, m.EmpID, k.EName, d.TrainingMan, 
	            d.FromDate, d.ToDate, d.FromTime, d.ToTime, d.Duration,
	            m.Level1ReactionEvaluate, m.Level2LearningPoint, m.Level2LearningEvaluate, 
	            m.Level3TransferEvaluate, m.ConfirmedBy, g.Cost, m.Remark
            FROM GA_TRM_RegisterPlanned AS h
            LEFT JOIN GA_TRM_RegisterPlanned_Detail AS d
            ON h.ID = d.ID
            LEFT JOIN GA_TRM_RegisterPlanned_Detail_Content AS g
            ON d.ID = g.ID
            AND d.IDTrainingCode = g.IDTrainingCode
            LEFT JOIN GA_TRM_RegisterPlanned_Detail_Employee AS m
            ON d.ID = m.ID
            AND d.IDTrainingCode = m.IDTrainingCode
            LEFT JOIN HRM_Emloyee AS k
            ON m.EmpID = k.ECode
            WHERE (h.Method IS NULL OR h.Method = 'ReverseButEdit' OR h.Method = '')
            AND g.Status = 'Plan'")
        Else
            Dim para(0) As SqlClient.SqlParameter
            If chbWarning.Checked Then
                para(0) = New SqlClient.SqlParameter("@warning", "warning")
            Else
                para(0) = New SqlClient.SqlParameter("@warning", DBNull.Value)
            End If
            GridControl1.DataSource = _db.FillDataTable("
                SELECT h.Section, h.ID, d.IDTrainingCode, d.TrainingProgram, d.TrainingMan, 
	                d.FromDate, d.ToDate, DATEADD(MONTH, 6, d.ToDate) AS EvaluationDate, 
	                DATEDIFF(DAY, CAST(GETDATE() AS DATE), DATEADD(MONTH, 6, d.ToDate)) AS RemainDate,
                    m.EmpID, m.Level3TransferEvaluate
                FROM GA_TRM_RegisterPlanned AS h
                LEFT JOIN GA_TRM_RegisterPlanned_Detail AS d
                ON h.ID = d.ID
                LEFT JOIN GA_TRM_RegisterPlanned_Detail_Employee AS m
                ON d.ID = m.ID
                AND d.IDTrainingCode = m.IDTrainingCode
                WHERE (h.Method = '' 
                OR h.Method = 'ReverseButEdit' 
                OR h.Method IS NULL)
                AND d.IDTrainingCode LIKE 'D%'
                AND (
                    @warning IS NULL OR 
                    (DATEADD(MONTH, 6, d.ToDate) <= GETDATE() AND 
                    (m.Level3TransferEvaluate = '' OR m.Level3TransferEvaluate IS NULL))
                )
                ORDER BY h.Section, h.ID, d.IDTrainingCode", para)
        End If
        GridControlSetFormat(GridView1, 3)
        GridView1.Columns("Section").Width = 150
        GridView1.Columns("ID").Width = 100
        GridView1.Columns("TrainingProgram").Width = 200
        GridView1.Columns("TrainingMan").Width = 150
        If rdoHistory.Checked Then
            GridView1.Columns("EName").Width = 150
            GridView1.Columns("Level1ReactionEvaluate").Width = 95
            GridView1.Columns("Level2LearningPoint").Width = 90
            GridView1.Columns("Level2LearningEvaluate").Width = 90
            GridView1.Columns("Level3TransferEvaluate").Width = 90
            GridView1.Columns("ConfirmedBy").Width = 170
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub btnSendMail_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSendMail.ItemClick
        Dim dtWarning = _db.FillDataTable("
            SELECT h.ID, h.CurrentMail, h.Section
            FROM GA_TRM_RegisterPlanned AS h
            LEFT JOIN GA_TRM_RegisterPlanned_Detail AS d
            ON h.ID = d.ID
            LEFT JOIN GA_TRM_RegisterPlanned_Detail_Employee AS m
            ON d.ID = m.ID
            AND d.IDTrainingCode = m.IDTrainingCode
            WHERE (h.Method = '' 
                    OR h.Method = 'ReverseButEdit' 
                    OR h.Method IS NULL)
            AND d.IDTrainingCode LIKE 'D%'
            AND DATEADD(MONTH, 6, d.ToDate) <= GETDATE() 
            AND (m.Level3TransferEvaluate = '' OR m.Level3TransferEvaluate IS NULL)
            GROUP BY h.ID, h.CurrentMail, h.Section
            ORDER BY h.ID")
        If dtWarning.Rows.Count > 0 Then
            For Each r As DataRow In dtWarning.Rows
                Dim titleMail = "Training Evaluation Yearly - " + r("Section")
                Dim listTo As New List(Of String)
                listTo.Add(r("CurrentMail"))
                SendMailOutlook(titleMail, Nothing, Submit.Confirm, listTo, Nothing, Nothing, Nothing, "0255TRM02", r("ID"))
            Next
            ShowSuccess()
        Else
            ShowWarning("Không có phiếu nào đến hạn cần đánh giá kết quả !")
        End If
    End Sub
End Class