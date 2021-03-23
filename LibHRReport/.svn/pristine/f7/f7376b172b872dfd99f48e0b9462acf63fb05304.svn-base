
Imports CommonDB
Imports LibEntity
Imports PublicUtility

Imports System.Windows.Forms
Imports System.IO

Public Class FrmHRReport : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim mypath As String = Application.StartupPath & "\Temp\"
    Private Sub tlsMenu_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles tlsMenu.Paint
        PublicFunction.FillControl(tlsMenu.Location.X, tlsMenu.Location.Y, tlsMenu.Width, tlsMenu.Height, e)
    End Sub
    Sub LoadReport()
        Dim sql As String = String.Format("select * from HRR_ReportList")
        Dim tbReport As DataTable = _db.FillDataTable(sql)
        cboReport.DataSource = _db.FillDataTable(sql)
        cboReport.ValueMember = "DocNo"
        cboReport.DisplayMember = "DocName"
    End Sub

    Sub LoadViewReport()
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDayOfMonth(dtpReportDate.Value))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetEndDayOfMonth(dtpReportDate.Value))
        Dim sql As String = String.Format("[sp_HRR_LoadReport]")
        Dim bdsource As New BindingSource
        bdsource.DataSource = _db.ExecuteStoreProcedureTB(sql, para)
        grid.DataSource = bdsource
        bdn.BindingSource = bdsource
    End Sub

    Private Sub mnuSave_Click(sender As System.Object, e As System.EventArgs) Handles mnuSave.Click
        If Not File.Exists(lblPathFile.Text) Then
            ShowWarning("Bạn chưa chọn file báo cáo.")
            bttOpenFile.Focus()
            Return
        End If
        If ShowQuestionSave() = Windows.Forms.DialogResult.Yes Then
            Dim obj As New HRR_ViewReport
            obj.DocNo_K = cboReport.SelectedValue
            obj.ReportDate_K = GetStartDate(dtpReportDate.Value)
            _db.GetObjectNotReset(obj)
            obj.Note = txtNote.Text
            obj.FileName = txtPath.Text

            obj.CreateDate = DateTime.Now
            obj.CreateUser = CurrentUser.UserID

            Dim objA As New HRR_AttachFile
            objA.DocNo_K = obj.DocNo_K
            objA.ReportDate_K = obj.ReportDate_K
            _db.GetObjectNotReset(objA)
            If File.Exists(lblPathFile.Text) Then
                objA.FileBinary = PublicFunction.ConvertFileToArrayByte(lblPathFile.Text)
            End If
            If Not _db.ExistObject(obj) Then
                _db.Insert(obj)
                _db.Insert(objA)
            Else
                _db.Update(obj)
                _db.Update(objA)
            End If
            mnuShowAll.PerformClick()
        End If
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(grid)
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        LoadViewReport()
    End Sub

    Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click
        If grid.CurrentRow IsNot Nothing Then
            If ShowQuestionDelete() = Windows.Forms.DialogResult.Yes Then
                Dim obj As New HRR_ViewReport
                obj.ReportDate_K = grid.CurrentRow.Cells("ReportDate").Value
                obj.DocNo_K = grid.CurrentRow.Cells("DocNo").Value
                _db.Delete(obj)
                mnuShowAll.PerformClick()
            End If
        End If
    End Sub

    Private Sub FrmViewReport_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        LoadReport()
        mnuShowAll.PerformClick()
    End Sub

    Private Sub dtpMonth_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpReportDate.ValueChanged
        LoadReport()
    End Sub

    Private Sub bttOpenFile_Click(sender As System.Object, e As System.EventArgs) Handles bttOpenFile.Click
        Dim openfile As New OpenFileDialog
        openfile.ShowDialog()
        txtPath.Text = openfile.SafeFileName
        lblPathFile.Text = openfile.FileName
    End Sub

    Private Sub grid_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellClick
        If grid.CurrentRow IsNot Nothing Then
            Dim obj As New HRR_ViewReport
            obj.ReportDate_K = grid.CurrentRow.Cells("ReportDate").Value
            obj.DocNo_K = grid.CurrentRow.Cells("DocNo").Value
            _db.GetObject(obj)
            cboReport.SelectedValue = obj.DocNo_K
            txtNote.Text = obj.Note
            txtPath.Text = obj.FileName
            lblPathFile.Text = mypath & obj.FileName
            dtpReportDate.Value = obj.ReportDate_K

            If Not Directory.Exists(mypath) Then
                Directory.CreateDirectory(mypath)
            End If

            If grid.Columns("Xem").Index = e.ColumnIndex Then
                Dim objA As New HRR_AttachFile
                objA.ReportDate_K = grid.CurrentRow.Cells("ReportDate").Value
                objA.DocNo_K = grid.CurrentRow.Cells("DocNo").Value
                _db.GetObject(objA)
                PublicFunction.ConvertArrayByteToFile(mypath & obj.FileName, objA.FileBinary)
                Process.Start(mypath & obj.FileName)
                Return
            ElseIf grid.CurrentRow.Cells("SendMail").ColumnIndex = e.ColumnIndex Then
                If ShowQuestion("Bạn có muốn gởi mail không ?") = Windows.Forms.DialogResult.No Then
                    Return
                End If
                If Not Directory.Exists(mypath) Then
                    Directory.CreateDirectory(mypath)
                End If
                Dim objA As New HRR_AttachFile
                objA.ReportDate_K = grid.CurrentRow.Cells("ReportDate").Value
                objA.DocNo_K = grid.CurrentRow.Cells("DocNo").Value
                _db.GetObject(objA)
                PublicFunction.ConvertArrayByteToFile(mypath & obj.FileName, obja.FileBinary)
                Dim sqlMail As String = String.Format(" SELECT  EMail " +
                                                                        " FROM [HRR_DocRight] d" +
                                                                        " where d.docno='{0}' ", obj.DocNo_K)
                Dim dtMail As DataTable = _db.FillDataTable(sqlMail)
                Dim ccEmail As New List(Of String)
                Dim toEmail As New List(Of String)
                Dim title As String = obj.FileName

                toEmail.Add("tam truongminh/nitto")
                'For Each r As DataRow In dtMail.Rows
                '    toEmail.Add(r("Mail"))
                'Next
                'ccEmail.Add("van_maihai/nitto")
                ccEmail.Add("anh phamnguyet/NITTO")

                If obj.DocNo_K = "01RHR" Then
                    title = "Báo cáo nhân sự hàng ngày - 人事関係の日次報告"
                    Dim content As String = String.Format("Dear all, " + vbCrLf + vbCrLf +
                                                            "お疲れ様です。" + vbCrLf +
                                                            "{0}月{1} の分をお送りします。" + vbCrLf +
                                                            "ご確認お願いします。" + vbCrLf + vbCrLf +
                                                            "Xin chào," + vbCrLf + vbCrLf +
                                                            "Đính kèm là báo cáo nhân sự ngày {2}." + vbCrLf +
                                                            "Xin xem chi tiết trong file đính kèm." + vbCrLf + vbCrLf +
                                                            "Cảm ơn ",
                                                            obj.ReportDate_K.Month,
                                                            obj.ReportDate_K.Day,
                                                            obj.ReportDate_K.ToString("dd/MM/yyyy"))
                    PublicFunction.SendMailInfo(CurrentUser.Mail, toEmail.ToArray, ccEmail.ToArray, title,
                                                content, Tag, "NoID",
                                                grid.CurrentRow.Cells("ReportDate").Value,
                                                mypath & obj.FileName)
                    obj.SendDate = DateTime.Now
                End If
                If obj.DocNo_K = "02RHR" Then
                    title = String.Format("(B）週次状況 - Báo cáo tuần(từ ngày {0}->{1})",
                                          obj.ReportDate_K.ToString("dd.MM"),
                                          obj.ReportDate_K.AddDays(6).ToString("dd.MM"))
                    Dim content As String = String.Format("Dear (Shinohara) san," + vbCrLf + vbCrLf +
                                                        "Đính kèm là báo cáo tuần của (B), xin xem chi tiết trong file đính kèm." + vbCrLf +
                                                        "(B）週次状況,ご確認お願いします。" + vbCrLf + vbCrLf +
                                                        "Thanks & regards.")
                    PublicFunction.SendMailInfo(CurrentUser.Mail, toEmail.ToArray, ccEmail.ToArray, title,
                                                content, Tag, "NoID",
                                                grid.CurrentRow.Cells("ReportDate").Value,
                                                mypath & obj.FileName)
                    obj.SendDate = DateTime.Now
                End If
                If obj.DocNo_K = "03RHR" Then
                    title = "Báo cáo tình hình nhân viên làm việc vượt quá thời gian quy định của luật - 法令に定めた就業時間を超えた従業員の状況の報告"
                    Dim content As String = String.Format("お疲れ様です。" + vbCrLf + vbCrLf +
                                                        "{0}年{1}月{2}日から{3}年{4}月{5}日までの労働時間集計により、労働法に決まった労働時間を超えた従業員が出てきました。" + vbCrLf +
                                                        "まとめ内容は以下の通りである。" + vbCrLf +
                                                        "1．出勤時間が1週間当たり60時間以上の総員：    {6}名 " + vbCrLf +
                                                        "2．出勤時間が1週間当たり72時間以上の総員：    {7}名" + vbCrLf +
                                                        "3．一週当たり７出勤日の総員：{8} 名" + vbCrLf +
                                                        "4．７ヵ月以上妊娠が残業した総員：{9} 名" + vbCrLf +
                                                        "5．１２ヵ月未満子供を養成ている従業員が残業した総員：{10} 名" + vbCrLf +
                                                        "詳細は添付ファイルに書いてあるのである。" + vbCrLf +
                                                        "労働法に従って残業時間を厳守し、実施してください。" + vbCrLf + vbCrLf +
                                                        "人事課" + vbCrLf + vbCrLf +
                                                        "Xin chào," + vbCrLf + vbCrLf +
                                                        "Theo số liệu thống kê thời gian làm việc của nhân viên trong tuần {11} từ {12} đến {13}," + vbCrLf +
                                                        "đã có phát sinh nhân viên có thời gian làm việc trong tuần vượt quá quy định của luật." + vbCrLf +
                                                        "Xin được tóm tắt như sau:" + vbCrLf +
                                                        "Tổng số nhân viên có thời gian làm việc trong tuần > 60 giờ:         {6} nhân viên" + vbCrLf +
                                                        "Tổng số nhân viên có thời gian làm việc trong tuần > 72 giờ:         {7} nhân viên" + vbCrLf +
                                                        "Tổng số nhân viên đi làm 7 ngày trong tuần: {8} nhân viên" + vbCrLf +
                                                        "Tổng số nhân viên mang thai từ tháng thứ 7 trong tuần làm thêm giờ : {9} nhân viên" + vbCrLf +
                                                        "Tổng số nhân viên nuôi con nhỏ trong tuần làm thêm giờ: {10} nhân viên." + vbCrLf +
                                                        "Xin gởi danh sách nhân viên và thời gian chi tiết trong file đính kèm." + vbCrLf +
                                                        "Đề nghị các phòng ban thực hiện nghiêm chỉnh quy định làm thêm giờ của luật." + vbCrLf + vbCrLf +
                                                        "Phòng nhân sự",
                                                        obj.ReportDate_K.Year, obj.ReportDate_K.Month, obj.ReportDate_K.Day,
                                                        obj.ReportDate_K.AddDays(6).Year, obj.ReportDate_K.AddDays(6).Month, obj.ReportDate_K.AddDays(6).Day,
                                                        obj.Hour60, obj.Hour72, obj.Day7, obj.ThaiSan, obj.ConNho,
                                                        GetWeekNumberOfYear(obj.ReportDate_K), obj.ReportDate_K.ToString("dd/MM/yyyy"), obj.ReportDate_K.AddDays(6).ToString("dd/MM/yyyy"))
                    PublicFunction.SendMailInfo(CurrentUser.Mail, toEmail.ToArray, ccEmail.ToArray, title,
                                                content, Tag, "NoID",
                                                grid.CurrentRow.Cells("ReportDate").Value,
                                                mypath & obj.FileName)
                    obj.SendDate = DateTime.Now
                End If
                If obj.DocNo_K = "04RHR" Then
                    title = String.Format("Statistic of working data - {0} {1}",
                                          obj.ReportDate_K.ToString("MMMM"),
                                          obj.ReportDate_K.Year)
                    Dim content As String = String.Format("Dear Shinbara san, " + vbCrLf + vbCrLf +
                                                        "We would like to send the NDV working time report in {0}  {1}. Please see attached file." + vbCrLf +
                                                        "If you need more details, please do not hesitate to contact me." + vbCrLf +
                                                        "Many thanks & Best regards," + vbCrLf + vbCrLf +
                                                        "Pham Nguyet Anh" + vbCrLf +
                                                        "(HR) ",
                                                         obj.ReportDate_K.ToString("MMMM"),
                                                         obj.ReportDate_K.Year)
                    PublicFunction.SendMailInfo(CurrentUser.Mail, toEmail.ToArray, ccEmail.ToArray, title,
                                                content, Tag, "NoID",
                                                grid.CurrentRow.Cells("ReportDate").Value,
                                                mypath & obj.FileName)

                    obj.SendDate = DateTime.Now

                End If
                grid.CurrentRow.Cells("SendDate").Value = obj.SendDate
                _db.Update(obj)
                ShowSuccess()
            End If
        End If
    End Sub

    Private Sub txtDocName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFileName.TextChanged
        If bdn.BindingSource IsNot Nothing Then
            If txtFileName.Text <> "" Then
                bdn.BindingSource.Filter = String.Format(" FileName like '%{0}%' ", txtFileName.Text)
            Else
                bdn.BindingSource.Filter = ""
            End If
        End If
    End Sub

    Private Sub tssEdit_Click(sender As System.Object, e As System.EventArgs) Handles tssEdit.Click
        grid.Columns("Hour60").ReadOnly = Not grid.Columns("Hour60").ReadOnly
        grid.Columns("Hour72").ReadOnly = Not grid.Columns("Hour72").ReadOnly
        grid.Columns("Day7").ReadOnly = Not grid.Columns("Day7").ReadOnly
        grid.Columns("Thaisan").ReadOnly = Not grid.Columns("Thaisan").ReadOnly
        grid.Columns("ConNho").ReadOnly = Not grid.Columns("ConNho").ReadOnly
        grid.Columns("FileName").ReadOnly = Not grid.Columns("FileName").ReadOnly
        grid.Columns("Note").ReadOnly = Not grid.Columns("Note").ReadOnly
    End Sub

    Private Sub grid_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellValueChanged
        If e.RowIndex >= 0 Then
            Dim obj As New HRR_ViewReport
            obj.ReportDate_K = grid.CurrentRow.Cells("ReportDate").Value
            obj.DocNo_K = grid.CurrentRow.Cells("DocNo").Value
            _db.GetObject(obj)
            If grid.CurrentRow.Cells("Hour60").Value IsNot DBNull.Value Then
                obj.Hour60 = grid.CurrentRow.Cells("Hour60").Value
            Else
                obj.Hour60 = 0
            End If
            If grid.CurrentRow.Cells("Hour72").Value IsNot DBNull.Value Then
                obj.Hour72 = grid.CurrentRow.Cells("Hour72").Value
            Else
                obj.Hour72 = 0
            End If
            If grid.CurrentRow.Cells("Day7").Value IsNot DBNull.Value Then
                obj.Day7 = grid.CurrentRow.Cells("Day7").Value
            Else
                obj.Day7 = 0
            End If
            If grid.CurrentRow.Cells("ThaiSan").Value IsNot DBNull.Value Then
                obj.ThaiSan = grid.CurrentRow.Cells("ThaiSan").Value
            Else
                obj.ThaiSan = 0
            End If
            If grid.CurrentRow.Cells("ConNho").Value IsNot DBNull.Value Then
                obj.ConNho = grid.CurrentRow.Cells("ConNho").Value
            Else
                obj.ConNho = 0
            End If
            If grid.CurrentRow.Cells("FileName").Value IsNot DBNull.Value Then
                obj.FileName = grid.CurrentRow.Cells("FileName").Value
            Else
                obj.FileName = 0
            End If
            If grid.CurrentRow.Cells("Note").Value IsNot DBNull.Value Then
                obj.Note = grid.CurrentRow.Cells("Note").Value
            Else
                obj.Note = 0
            End If
            _db.Update(obj)
        End If
    End Sub
End Class