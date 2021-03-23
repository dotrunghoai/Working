Imports System.IO
Imports LibEntity
Imports System.Reflection
Imports PublicUtility
Imports System.Configuration
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars.Docking2010.Views
Imports System.Threading
Imports LibIT_NewTreeListAndForm

Public Class FrmMain : Inherits DevExpress.XtraBars.ToolbarForm.ToolbarForm
    Dim frm As New FrmNotifyAlarm
    Dim isQuestionToClose As Boolean = True

    Friend login As Boolean = False
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _frmSolution As FrmShowAuthorizedUser
    Dim lang As New MultiLanguage

    Public Shared ERPNAME As String = "\ERPNDV.exe"
    Public Shared ERPUpdate As String = "ERPUpdate.exe"
    Public Shared CONFIGUPDATE As String = "\configupdate.ndv"
    Public Shared CONFIG As String = "\config.ndv"
    Public Shared FOLDER_TEMP As String = "\BK_Temp"

#Region "Show New Form"

    Private Sub SendMailAlarmCISChemical()
        Try
            'Nếu User đăng nhập là Linh, Chi, Trang (PU) thì gửi mail cảnh báo
            If CurrentUser.UserID = "00113" Then
                Dim dtCISChemical As DataTable = _db.FillDataTable("select STT from UDM_CISChemical
                                                               where STT is null")
                If dtCISChemical.Rows.Count > 0 Then
                    Dim arrCc() As String
                    arrCc = {"huong.huynhthixuan@nitto.com",
                             "linh.maichi@nitto.com"}
                    SendMail(CurrentUser.Mail, arrCc, "", PublicFunction.Submit.Confirm,
                             String.Format("New CIS Chemical"),
                             "Có item CIS Chemical mới chưa cập nhật !",
                             "0216WH09", "HSD", DateTime.Now.Date)
                End If
            End If
        Catch ex As Exception
            ShowError(ex, "SendMailAlarmCIS", Name)
        End Try
    End Sub

    Private Sub SendMailAlarmDocRelate()
        Try
            'Nếu User đăng nhập là Linh, Chi, Trang (PU) thì gửi mail cảnh báo
            If CurrentUser.UserID = "11911" Then
                Dim dtCISChemical As DataTable = _db.FillDataTable("SELECT distinct d.ID, d.[DocNo]   ,r.PIC 
                                                                FROM  [DOC_ApprovedDOC] d
                                                                left join [dbo].[DOC_ApprovedReplate] r
                                                                on d.ID=r.ID 
                                                                where  r.ActualDate is null and r.FinishedDate<getdate() ")
                If dtCISChemical.Rows.Count > 0 Then
                    For Each r As DataRow In dtCISChemical.Rows
                        Dim obj As New DOC_SendMail
                        obj.Email_K = r("PIC")
                        obj.Ngay_K = Date.Now.Date
                        obj.DocNo_K = r("DocNo")
                        If Not _db.ExistObject(obj) Then
                            _db.Insert(obj)
                            Dim arrCc() As String
                            arrCc = {r("PIC")}
                            SendMail(CurrentUser.Mail, arrCc, "", PublicFunction.Submit.Confirm,
                                     String.Format("Yêu cầu sửa đổi tài liệu: " & r("DocNo")),
                                     "Bạn có yêu cầu cập nhật tài liệu liên quan !",
                                     "022826", r("ID"), DateTime.Now.Date)
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            ShowError(ex, "SendMailAlarmDocRelate", Name)
        End Try

    End Sub

    Private Sub SendMailAlarmPU()
        Try
            'Nếu User đăng nhập là Linh, Chi, Trang (PU) thì gửi mail cảnh báo
            If CurrentUser.SortSection = "PU" Then
                Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
                Dim objAlarm As New ASP_AlarmExpiredItems
                objAlarm.YMD_K = DateTime.Now.ToString("yyyyMMdd")
                If Not _db.ExistObject(objAlarm) Then
                    Dim para(0) As SqlClient.SqlParameter
                    para(0) = New SqlClient.SqlParameter("@Action", "SearchExpiry")
                    Dim dtExpiry As DataTable = _db.ExecuteStoreProcedureTB("sp_ASP_ItemList", para)
                    If dtExpiry.Rows.Count > 0 Then
                        Dim arrCc() As String
                        arrCc = {"chi.tranthihong@nitto.com",
                                 "hoa.tranthingoc@nitto.com", "khanh.huynhduy@nitto.com"}
                        SendMail(CurrentUser.Mail, arrCc, "", PublicFunction.Submit.Confirm, String.Format("Expired Items"),
                                 "Danh sách những Item đã hết hiệu lực và còn hiệu lực trong vòng 15 ngày tới.",
                                 "0237IT08", "HSD", DateTime.Now.Date)
                        objAlarm.YMD_K = DateTime.Now.ToString("yyyyMMdd")
                        objAlarm.Status = True
                        _db.Insert(objAlarm)
                    End If
                End If
            End If
        Catch ex As Exception
            ShowError(ex, "SendMailAlarmPU", Name)
        End Try

    End Sub

    Sub SendEmailAlarmKeHoach()
        Dim obj As New FPICS_Alarm
        obj.Ngay_K = GetStartDate(DateTime.Now)
        If Not _db.ExistObject(obj) And CurrentUser.UserID = "06566" Then

            Dim listTo As String = "suong.ngohuyen@nitto.com, huong.lethi@nitto.com ,thao.lethimai@nitto.com, " +
                                   " thu.nguyenthikim@nitto.com, hang-a.nguyenthithuy@nitto.com " +
                                    ",tuan.nguyentran@nitto.com  "
            Dim listCc As New List(Of String)
            Dim sqlMail As String = String.Format("sp_FPICS_GetEmailDamTrachTonChuyen")
            Dim dtMail As DataTable = _db.ExecuteStoreProcedureTB(sqlMail)
            For Each r As DataRow In dtMail.Rows
                If r("Email") IsNot DBNull.Value Then
                    listCc.Add(r("Email"))
                End If
            Next

            listCc.Add("mai.hoxuan@nitto.com")
            listCc.Add("tu.hohong@nitto.com")
            Try
                SendMailBaoCao(CurrentUser.Mail, listTo.Split(","), listCc.ToArray, Submit.Info,
                     "Kiểm soát hàng tồn trên chuyền > 1 ngày",
                     "Các Group leader đảm trách trong file vui lòng theo dõi kế hoạch hoàn thành kiểm soát hàng tồn > 1 ngày." & vbCrLf &
                     "Nhóm tiến độ vui lòng xác nhận và nhập dữ liệu trước 17h00 mỗi ngày." & vbCrLf &
                     "Đường dẫn của file: mở ERPNDV/Production Status/Tồn trên chuyền lớn hơn 1 ngày", "025608", "", DateTime.Now)
                _db.Insert(obj)
            Catch ex As Exception
                ShowError(ex, "SendEmailAlarmKeHoach", Me.Name)
            End Try
            ShowSuccess("Bạn đã gởi email thông báo tồn trên chuyền thành công.")
        End If
    End Sub

    Sub SendEmailAlarmQACS()
        If CurrentUser.GroupName <> "Customer Quanlity Engineer" Then
            Return
        End If
        Try
            Dim startdate As DateTime = DateTime.Now.Date
            Dim objMail As New Main_GroupMail
            objMail.ID_K = "QIDR"
            _db.GetObject(objMail)
            If objMail.MailList = "" Or objMail.SendDate1 = Date.Now.Date Then
                Return
            End If
            objMail.SendDate1 = Date.Now.Date

            Dim para(0) As SqlClient.SqlParameter

            para(0) = New SqlClient.SqlParameter("@Action", "LoadByParamAlarm")
            Dim dtTableAll = _db.ExecuteStoreProcedureTB("sp_QIDR_QualityIssue", para)
            If dtTableAll.Rows.Count > 0 Then
                Dim title As String = "Cảnh báo chưa cập nhật Quality Issue DR"
                Dim content As String = String.Format("Xem chi tiết: Quality Management/Quality Issue and DR/Quality Issue")

                Dim myfileItemCode As String = ExportToFile(dtTableAll, "QACS_" & DateTime.Now.ToString("dd-MMM-yyyy") & ".xlsx", "")

                SendMailOutlookReport(title,
                                                                content,
                                                                GetListMail(objMail.MailList),
                                                                Nothing,
                                                                Nothing,
                                                                GetListFile(String.Format("{0}", myfileItemCode)))
                _db.Insert(objMail)
            End If
        Catch ex As Exception
            ShowError(ex, "SendMailQACS", Name)
        End Try
    End Sub

    Sub SendEmailAlarmQA()
        If CurrentUser.UserID <> "12362" Then
            Return
        End If

        Dim startdate As DateTime = DateTime.Now.Date
        Dim objMail As New DCS_AlarmEmail
        objMail.Section_K = "QA"
        _db.GetObject(objMail)
        If objMail.MailList = "" Then
            Return
        End If

        Dim content As String
        Dim title As String

        If DateTime.Now.Hour >= 9 And DateTime.Now.Hour < 13 Then
            Dim obj As New DCS_SendMailLog
            obj.Gio_K = 9
            obj.Section_K = "QA"
            obj.Ngay_K = DateTime.Now.Date
            If Not _db.ExistObject(obj) Then
                title = "Cảnh báo out chuẩn SPC (QA) [Lần 1]"
                content = String.Format("Xem chi tiết: Quality Management/Kiểm soát thống kê (QA)/Display TV")

                Dim dtTableAll As DataTable = _db.FillDataTable("select * from [DCS_KQ_Original] order by Ngay desc")

                Dim myfileItemCode As String = ExportToFile(dtTableAll, "SPC (QA) " & DateTime.Now.ToString("dd-MMM-yyyy") & ".xlsx", "")

                SendMailOutlookReport(title,
                                                        content,
                                                        GetListMail(objMail.MailList),
                                                        Nothing,
                                                        Nothing,
                                                        GetListFile(String.Format("{0}", myfileItemCode)))
                _db.Insert(obj)
            End If

        ElseIf DateTime.Now.Hour >= 13 And DateTime.Now.Hour < 15 Then
            Dim obj As New DCS_SendMailLog
            obj.Gio_K = 13
            obj.Section_K = "QA"
            obj.Ngay_K = DateTime.Now.Date
            If Not _db.ExistObject(obj) Then
                title = "Cảnh báo out chuẩn SPC (QA) [Lần 2]"
                content = String.Format("Xem chi tiết: Quality Management/Kiểm soát thống kê (QA)/Display TV")

                Dim dtTableAll As DataTable = _db.FillDataTable("select * from [DCS_KQ_Original] order by Ngay desc")

                Dim myfileItemCode As String = ExportToFile(dtTableAll, "SPC (QA) " & DateTime.Now.ToString("dd-MMM-yyyy") & ".xlsx", "")

                SendMailOutlookReport(title,
                                                        content,
                                                        GetListMail(objMail.MailList),
                                                        Nothing,
                                                        Nothing,
                                                        GetListFile(String.Format("{0}", myfileItemCode)))
                _db.Insert(obj)
            End If
        ElseIf DateTime.Now.Hour >= 15 And DateTime.Now.Hour < 17 Then
            Dim obj As New DCS_SendMailLog
            obj.Gio_K = 15
            obj.Section_K = "QA"
            obj.Ngay_K = DateTime.Now.Date
            If Not _db.ExistObject(obj) Then
                title = "Cảnh báo out chuẩn SPC (QA) [Lần 3]"
                content = String.Format("Xem chi tiết: Quality Management/Kiểm soát thống kê (QA)/Display TV")

                Dim dtTableAll As DataTable = _db.FillDataTable("select * from [DCS_KQ_Original] order by Ngay desc")

                Dim myfileItemCode As String = ExportToFile(dtTableAll, "SPC (QA) " & DateTime.Now.ToString("dd-MMM-yyyy") & ".xlsx", "")

                SendMailOutlookReport(title,
                                                        content,
                                                        GetListMail(objMail.MailList),
                                                        Nothing,
                                                        Nothing,
                                                        GetListFile(String.Format("{0}", myfileItemCode)))
                _db.Insert(obj)
            End If

        End If
    End Sub

    Sub SendEmailHoiChuan()
        'Alarm Hỏi Chuẩn
        If CurrentUser.PCNO = "V00263" Then
            Dim _mTitle As String = "(REMIND) ABNORMAL QUALITY INFORMATION "
            Dim obj As New ES_AlarmApproved
            obj.Ngay_K = Date.Now.Date
            _db.GetObjectNotReset(obj)
            obj.CreatedDate = Date.Now
            obj.CreateUser = CurrentUser.UserID

            If obj.Lan1 = False And Date.Now.Hour = 8 Then

                Dim dtRequest As DataTable = _db.ExecuteStoreProcedureTB("sp_ES_LoadCurrentIDOverTime")
                If dtRequest.Rows.Count > 0 Then

                    For Each r As DataRow In dtRequest.Rows
                        SendMail(CurrentUser.Mail, r("CurrentID"), Nothing, Submit.Confirm,
                                 "(" & r("ID") & ")" & _mTitle,
                                 "Yêu cầu đang chờ bạn duyệt/Waiting your approved: " & r("Total"),
                                 "0243ES01", r("ID"), DateTime.Now.Date)
                    Next
                    obj.Lan1 = True
                    If _db.ExistObject(obj) Then
                        _db.Update(obj)
                    Else
                        _db.Insert(obj)
                    End If
                    ShowWarning("Đã gởi email cảnh báo hỏi chuẩn lần 1!")
                End If


            ElseIf obj.Lan2 = False And Date.Now.Hour = 11 Then


                Dim dtRequest As DataTable = _db.ExecuteStoreProcedureTB("sp_ES_LoadCurrentIDOverTime")
                If dtRequest.Rows.Count > 0 Then

                    For Each r As DataRow In dtRequest.Rows
                        SendMail(CurrentUser.Mail, r("CurrentID"), Nothing, Submit.Confirm,
                                 "(" & r("ID") & ")" & _mTitle,
                                 "Yêu cầu đang chờ bạn duyệt/Waiting your approved: " & r("Total"),
                                 "0243ES01", r("ID"), DateTime.Now.Date)
                    Next
                    obj.Lan2 = True
                    If _db.ExistObject(obj) Then
                        _db.Update(obj)
                    Else
                        _db.Insert(obj)
                    End If
                    ShowWarning("Đã gởi email cảnh báo hỏi chuẩn lần 2!")
                End If
            ElseIf obj.Lan3 = False And Date.Now.Hour = 14 Then


                Dim dtRequest As DataTable = _db.ExecuteStoreProcedureTB("sp_ES_LoadCurrentIDOverTime")
                If dtRequest.Rows.Count > 0 Then

                    For Each r As DataRow In dtRequest.Rows
                        SendMail(CurrentUser.Mail, r("CurrentID"), Nothing, Submit.Confirm,
                                 "(" & r("ID") & ")" & _mTitle,
                                 "Yêu cầu đang chờ bạn duyệt/Waiting your approved: " & r("Total"),
                                 "0243ES01", r("ID"), DateTime.Now.Date)
                    Next
                    obj.Lan3 = True
                    If _db.ExistObject(obj) Then
                        _db.Update(obj)
                    Else
                        _db.Insert(obj)
                    End If
                    ShowWarning("Đã gởi email cảnh báo hỏi chuẩn lần 3!")
                End If
            End If
        End If
    End Sub

    Sub SendMailChemical()
        If CurrentUser.UserID <> "20551" Then
            Return
        End If
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "dtWarning")
        Dim dtData As DataTable = _db.ExecuteStoreProcedureTB("sp_LO_CL_ChemicalLicence", para)
        If dtData.Rows.Count > 0 Then
            Dim titleMail = "[Auto Mail] - Cảnh báo một số TCCN nhập theo GPNK sắp hết !!!"
            Dim contentMail = "Số lượng một số TCCN được phép nhập khẩu sắp hết. 
                Vui lòng mở ERP để tham khảo thông tin chi tiết! " + "<br>" +
                """Quản lý sản xuất/Xuất nhập khẩu/Customers Other Report/Chemical Report New/Run""" +
                "<style>
                    table, th, td {
                      border: 1px solid black;
                      border-collapse: collapse;
                    }
                </style>
                <br><br>
                <table>
                    <tr>
                        <th style=""width:150px"">Chemical License</th>
                        <th style=""width:100px"">Pur Code</th>
                        <th style=""width:250px"">Trade Name</th>
                        <th style=""width:100px"">License Qty</th>
                        <th style=""width:100px"">Remain Qty</th>
                    </tr>"
            For Each r As DataRow In dtData.Rows
                contentMail += String.Format("<tr>
                                                    <td>{0}</td>
                                                    <td>{1}</td>
                                                    <td>{2}</td>
                                                    <td>{3}</td>
                                                    <td>{4}</td>
                                                 </tr>",
                                                 r("ChemicalLicence"),
                                                 r("PurCode"),
                                                 r("TradeName"),
                                                 r("LicenseQty"),
                                                 r("RemainQty"))
            Next
            contentMail += "</table>"
            'Dim listTo = CurrentUser.Mail
            Dim listTo = "uyen.daokhanh@nitto.com; nu.nguyenthingoc@nitto.com; linh.maichi@nitto.com"
            SendMailBaoCaoAttach(Nothing, listTo, Nothing, Submit.Info, titleMail, contentMail, Nothing, Nothing)
        End If

    End Sub

    Public Sub ShowNewForm(ByVal frm As XtraForm, Optional ByVal translate As Boolean = True)
        Dim isExist As Boolean = False
        For Each Child As BaseDocument In TabbedView1.Documents
            If Child.Form.Tag = frm.Tag Then
                'TabbedView1.ActivateDocument(Child.Form)
                Child.Form.Close()
                isExist = True
                Exit For
            End If
        Next


        frm.TopLevel = False
        TabbedView1.AddDocument(frm)

        'Set language
        If translate Then
            lang.ShowLanguage(frm, frm.Tag)
        End If

        DockPanel1.HideSliding()
    End Sub

    Friend Sub ShowNewForm(ByVal moduleID As String, ByVal frmID As String, ByVal ID As String, Optional ByVal translate As Boolean = True)
        ' Create a new instance of the child form.
        Dim ChildForm As New XtraForm
        Dim frm As New LibEntity.Main_FormRight
        frm.FormID_K = frmID
        frm.ModuleID = moduleID
        _db.GetObject(frm)
        If frm.FormID_K = "" Or frm.AssemblyName = "" Then Return
        Try
            'Get Form from assembly
            Dim asmAssemblyContainingForm As [Assembly] = [Assembly].LoadFrom(Application.StartupPath & "\" & frm.AssemblyName)
            Dim assemblyName As String = frm.AssemblyName.Replace(".dll", "").Replace(".exe", "")
            Dim TypeToLoad As Type = asmAssemblyContainingForm.GetType(assemblyName & "." & frm.FormName)

            Dim GenericInstance As Object
            GenericInstance = Activator.CreateInstance(TypeToLoad)
            ChildForm = CType(GenericInstance, XtraForm)
        Catch ex As Exception
            ShowError(ex, "Open Form", Me.Name)
            Return
        End Try

        'Check ChildForm exist already.
        Dim isExist As Boolean = False
        For Each Child As BaseDocument In TabbedView1.Documents
            If Child.Form.Tag = ChildForm.Tag Then
                'TabbedView1.ActivateDocument(Child.Form)
                Child.Form.Close()
                isExist = True
                Exit For
            End If
        Next


        'Set ID to approved
        ChildForm.AccessibleName = ID
        ChildForm.TopLevel = False
        TabbedView1.AddDocument(ChildForm)
        TabbedView1.ActivateDocument(ChildForm)

        'Set language
        If translate And frm.Translate Then
            lang.ShowLanguage(ChildForm, ChildForm.Tag)
        End If

        DockPanel1.HideSliding()
    End Sub

#End Region

    Private Sub FrmMain_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        SplashScreenManager1.ShowWaitForm()

        Dim myPath As String = Application.StartupPath
        Dim localDisk As String = Microsoft.VisualBasic.Left(myPath, 1)
        If localDisk <> "C" And
            CurrentUser.UserID <> "15180" And
              CurrentUser.PCNO <> "V00365" Then
            ShowWarning("Bạn chỉ được phép chạy chương trình trên Local (ổ C:\Programs_NDV\ERPNDV\). Vui lòng liên hệ IT.")
            Application.ExitThread()
            Application.Exit()
        End If

        'PublicConst.DockPanel = DockPanel1
        Dim separators As String = ","
        Dim commands As String = Microsoft.VisualBasic.Command()
        Dim args() As String = commands.Split(separators.ToCharArray)


        lang = New MultiLanguage()

        Dim obj As New LibEntity.Main_User
        obj.UserID_K = CurrentUser.UserID
        _db.GetObject(obj)
        obj.PCNo = PublicFunction.GetHostName()
        obj.IP = PublicFunction.GetIP()
        obj.CreateDate = DateTime.Now
        obj.CreateUser = "00000"
        _db.Update(obj)


        clsMain.fMain = Me
        PublicConst.MyTabbedView = TabbedView1
        'Update file ERPUpdate.exe
        UpdateERPAuto()

        Me.Text = "NDV-ERP/" & CurrentUser.UserID & "/" & CurrentUser.UserName & "/" & obj.PCNo & "/" & obj.IP &
                   " | ServerIP: " & CurrentUser.ServerIP

        LoadSettingDefault()

        'Load Form Phê duyệt nếu có
        If args.Length > 1 Then
            ShowNewForm("", args(0), args(1))
        Else
            'If CurrentUser.PCNO <> "V00365" Then
            '    ShowWarning("Bạn phải mở bằng ERPUpdate để được cập nhật mới nhất. Please open ERPUpdate !")
            '    Application.ExitThread()
            '    Application.Exit()
            'End If
        End If

        Dim mThread As New Thread(AddressOf SendAlarmList)
        mThread.Start()

        SplashScreenManager1.CloseWaitForm()
    End Sub

    Sub SendAlarmList()
        SendMailAlarmPU()
        SendEmailAlarmKeHoach()
        SendEmailAlarmQA()
        SendEmailAlarmQACS()
        SendMailAlarmCISChemical()
        SendMailAlarmDocRelate()
        SendEmailHoiChuan()
        SendMailChemical()
    End Sub

    Sub UpdateERPAuto()
        Try
            Dim settings As String = ConfigurationManager.ConnectionStrings("ERPUpdate").ConnectionString

            'Kill ERPNDV
            For Each p As Process In Process.GetProcesses()
                If p.ProcessName.Contains("ERPUpdate") Then
                    'If ShowQuestion("ERP đang mở, bạn có muốn tắt ERP để cập nhật mới không ?") Then
                    p.Kill()
                    'End If
                End If
            Next
            File.Copy(settings + PublicConst.ERPUPDATENAME, Application.StartupPath + PublicConst.ERPUPDATENAME, True)
            File.Copy(settings + PublicConst.CONFIGUPDATE, Application.StartupPath + PublicConst.CONFIGUPDATE, True)
        Catch ex As Exception
            If CurrentUser.UserID = "15180" Then
                ShowWarning("Không thể cập nhật ERPUpdate: " & ex.Message)
            End If
        End Try
    End Sub

    Sub UpdateQuater()
NextInsert:
        Try
            If CurrentUser.SortSection = "LO" Then
                Dim sql As String = String.Format(" select top 1 * from {0}  order by ID desc ",
                                                  PublicTable.Table_LO_Quater)
                Dim obj As LO_Quater = _db.GetObject(Of LO_Quater)(sql)
                If obj IsNot DBNull.Value Or obj IsNot Nothing Then
                    If obj.EndDate < DateTime.Now Then
                        Dim objNew As New LO_Quater()
                        objNew.ID_K = obj.ID_K + 1
                        objNew.StartDate = obj.StartDate.AddMonths(3)
                        objNew.EndDate = GetEndDayOfMonth(obj.EndDate.AddMonths(3))
                        objNew.YM = objNew.EndDate.ToString("yyyyMM")
                        objNew.Quater = "Q" & objNew.EndDate.Month / 3 & objNew.EndDate.Year
                        _db.Insert(objNew)
                        GoTo NextInsert
                    End If
                Else
                    Dim objNew As New LO_Quater()
                    objNew.ID_K = 1
                    objNew.StartDate = New DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0)
                    objNew.EndDate = New DateTime(DateTime.Now.Year, 3, 31, 23, 59, 59)
                    objNew.YM = objNew.EndDate.ToString("yyyyMM")
                    objNew.Quater = "Q" & objNew.EndDate.Month / 3 & objNew.EndDate.Year
                    _db.Insert(objNew)
                    GoTo NextInsert
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Add quater")
        End Try
    End Sub

    Sub LoadSettingDefault()
        Try

            If _db.CheckConnection() Then

                'Dim frmS As New FrmSolution
                'frmS.TopLevel = False
                'frmS.Visible = True
                'DockPanel1.Controls.Add(frmS)
                'DockPanel1.Text = "MAIN MENU"
                'frmS.Dock = DockStyle.Fill
                '_frmSolution = frmS

                Dim frmS As New FrmShowAuthorizedUser
                frmS.TopLevel = False
                frmS.Visible = True
                DockPanel1.Controls.Add(frmS)
                DockPanel1.Text = "MAIN MENU"
                frmS.Dock = DockStyle.Fill
                _frmSolution = frmS

                Dim frmStart As New FrmStartup
                ShowNewForm(frmStart, False)

                'UpdateQuater()

                'Set language
                'lang.ShowLanguage(DockPanel1.Contents)

                'Load setup Notify Message
                Dim obj As New Main_NotifyMessageTime
                obj.UserID_K = CurrentUser.UserID
                If _db.ExistObject(obj) Then
                    _db.GetObject(obj)
                    tmrRequest.Enabled = obj.Enabled
                    tmrRequest.Interval = obj.TotalMinute * 60000

                    _db.Update(obj)
                Else
                    tmrRequest.Enabled = False
                    tmrRequest.Interval = 60 * 60000
                    obj.Enabled = False
                    obj.TotalMinute = 60
                    _db.Insert(obj)
                End If
            Else
                MessageBox.Show("Can't connect to Server. Please contact Admin IT", "Info")
            End If
        Catch ex As Exception
            MessageBox.Show("Can't connect to Server. Please contact Admin IT :" & vbCrLf & ex.Message, "Info")
        End Try
    End Sub

    Private Sub FrmMain_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'If ShowQuestion("Do you want to exit NDVERP program ?") = DialogResult.No Then
        '    e.Cancel = True
        '    Return
        'End If

        Dim oSkin As New LookAndFeelSettingsHelper
        oSkin.SaveSettings()

        TabbedView1.Documents.Clear()
        Application.ExitThread()
        Application.Exit()
    End Sub

    Private Sub tmrAlarm_Tick(sender As System.Object, e As System.EventArgs) Handles tmrRequest.Tick
        'Kiểm tra nếu có yêu cầu thì thông báo
        Try
            Dim sql As String = String.Format("sp_Main_GetAllRequestApproved ")
            Dim para(2) As SqlClient.SqlParameter

            para(0) = New SqlClient.SqlParameter("@EmpID", CurrentUser.UserID)
            para(1) = New SqlClient.SqlParameter("@EmpName", CurrentUser.FullName)
            para(2) = New SqlClient.SqlParameter("@User", CurrentUser.Mail)

            Dim tbAlarm As DataTable = _db.ExecuteStoreProcedureTB(sql, para, 5)
            If tbAlarm.Rows.Count > 0 Then
                frm.Close()
                frm = New FrmNotifyAlarm
                frm.fMain = Me
                frm.Show()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TimerQA_Tick(sender As System.Object, e As System.EventArgs) Handles TimerQA.Tick
        SendEmailAlarmQA()
    End Sub

    Private Sub TimerTTTB_Tick(sender As Object, e As EventArgs) Handles TimerTTTB.Tick
        If CurrentUser.GroupName = "Production Planning 2" Then
            Dim obj As New ID_SendLog
            obj.ID_K = DateTime.Now.ToString("YYMMddHH")
            obj.SendDate = DateTime.Now
            Dim dtCheck As DataTable = _db.FillDataTable(String.Format("SELECT ID " +
                                                         " FROM  [ID_IncidentDevice]" +
                                                         " where NgayHoanThanh is null "))
            If dtCheck.Rows.Count > 0 Then
                If Not _db.ExistObject(obj) Then
                    Dim dtMail As DataTable = _db.FillDataTable("SELECT  [MailList] FROM  [ID_MailList]")
                    Dim lstTo As New List(Of String)
                    For Each r As DataRow In dtMail.Rows
                        lstTo.Add(r(0))
                    Next
                    Dim title = "CẢNH BÁO: THÔNG TIN THIẾT BỊ SỰ CỐ !"
                    Dim content = String.Format("Xin chào, " & vbCrLf & " Có thiết bị vẫn đang Offline. Vui lòng kiểm tra !")

                    SendMailOutlookReport(title, content,
                                                        lstTo,
                                                        Nothing,
                                                        Nothing,
                                                        Nothing)

                    _db.Insert(obj)
                End If
            End If
        End If
    End Sub

    Private Sub MnuAbout_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bttAbout.ItemClick
        Dim fLock As New FrmAbout
        fLock.ShowDialog()
    End Sub

    Private Sub MnuNotify_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bttNotify.ItemClick
        Dim frm As New FrmNotifySetTime
        frm.ShowDialog()
    End Sub

    Private Sub MnuExit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bttExit.ItemClick
        Close()
    End Sub

    Private Sub MnuVN_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bttVN.ItemClick
        PublicConst.Language = PublicConst.EnumLanguage.VietNam
        lang.ShowLanguage(TabbedView1.Documents)
        If _frmSolution IsNot Nothing Then _frmSolution.ShowTreeList()
    End Sub

    Private Sub MnuEN_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bttEN.ItemClick
        PublicConst.Language = PublicConst.EnumLanguage.English
        lang.ShowLanguage(TabbedView1.Documents)
        If _frmSolution IsNot Nothing Then _frmSolution.ShowTreeList()
    End Sub

    Private Sub MnuUser_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bttUser.ItemClick
        Dim frm As New FrmUserInfo
        frm.ShowDialog()
    End Sub

    Private Sub mnuApproved_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuApproved.ItemClick
        Dim frmStart As New FrmStartup
        ShowNewForm(frmStart, False)
    End Sub

    Private Sub tmrRINGI_Tick(sender As Object, e As EventArgs) Handles tmrFPC.Tick
        SendEmailHoiChuan()
        'Alarm Ringi
        If CurrentUser.UserID = "13957" Or
            CurrentUser.UserID = "09355" Then
            Dim _mTitle As String = " REMIND [RINGI-NDV] "
            Dim obj As New ASP_RingiAlarm
            obj.Ngay_K = Date.Now.Date
            _db.GetObjectNotReset(obj)
            obj.CreatedDate = Date.Now
            obj.CreateUser = CurrentUser.UserID


            If obj.Lan1 = False And Date.Now.Hour = 8 Then
                obj.Lan1 = True
                If _db.ExistObject(obj) Then
                    _db.Update(obj)
                Else
                    _db.Insert(obj)
                End If


                Dim dtRequest As DataTable = _db.ExecuteStoreProcedureTB("sp_ASP_RingiOverTime")
                If dtRequest.Rows.Count > 0 Then
                    For Each r As DataRow In dtRequest.Rows
                        SendMail(CurrentUser.Mail, r("CurrentID"), Nothing, Submit.Reject,
                                 "(" & r("ID") & ")" & _mTitle,
                                 "Yêu cầu đang chờ bạn duyệt/Waiting your approved: " & r("Total"),
                                 "0237RG02", r("ID"), DateTime.Now.Date)
                    Next
                End If
            ElseIf obj.Lan2 = False And Date.Now.Hour = 11 Then
                obj.Lan2 = True
                If _db.ExistObject(obj) Then
                    _db.Update(obj)
                Else
                    _db.Insert(obj)
                End If

                Dim dtRequest As DataTable = _db.ExecuteStoreProcedureTB("sp_ASP_RingiOverTime")
                If dtRequest.Rows.Count > 0 Then
                    For Each r As DataRow In dtRequest.Rows
                        SendMail(CurrentUser.Mail, r("CurrentID"), Nothing, Submit.Reject,
                                 "(" & r("ID") & ")" & _mTitle,
                                 "Yêu cầu đang chờ bạn duyệt/Waiting your approved: " & r("Total"),
                                 "0237RG02", r("ID"), DateTime.Now.Date)
                    Next
                End If
            ElseIf obj.Lan3 = False And Date.Now.Hour = 14 Then
                obj.Lan3 = True
                If _db.ExistObject(obj) Then
                    _db.Update(obj)
                Else
                    _db.Insert(obj)
                End If

                Dim dtRequest As DataTable = _db.ExecuteStoreProcedureTB("sp_ASP_RingiOverTime")
                If dtRequest.Rows.Count > 0 Then
                    For Each r As DataRow In dtRequest.Rows
                        SendMail(CurrentUser.Mail, r("CurrentID"), Nothing, Submit.Reject,
                                 "(" & r("ID") & ")" & _mTitle,
                                 "Yêu cầu đang chờ bạn duyệt/Waiting your approved: " & r("Total"),
                                 "0237RG02", r("ID"), DateTime.Now.Date)
                    Next
                End If
            End If
        End If


    End Sub
End Class
