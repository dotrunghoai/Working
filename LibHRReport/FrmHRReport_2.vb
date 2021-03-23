Imports System.IO
Imports System.Windows.Forms
Imports CommonDB
Imports PublicUtility
Public Class FrmHRReport_2
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim myPath As String = CurrentUser.TempFolder & "HRR\"
    Public _myID As String = ""
    Private Sub FrmHRReport_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _myID = "" Then
            _myID = Me.AccessibleName
        End If
        dteDate.DateTime = DateTime.Now
        LoadMail()
        LoadLoaiBC()
        LoadHead()
    End Sub
    Sub LoadMail()
        txtMailPIC.Text = CurrentUser.Mail
        Dim dt As DataTable = _db.FillDataTable("SELECT h.EmpID, d.SectionSort, d.Observation, Mail
                                                 FROM OT_Mail AS h
                                                 LEFT JOIN OT_Employee AS d
                                                 ON h.EmpID = d.EmpID
                                                 ORDER BY Mail ")
        cbbMailCheck.Properties.DataSource = dt
        cbbMailCheck.Properties.DisplayMember = "Mail"
        cbbMailCheck.Properties.ValueMember = "Mail"
        cbbMailCheck.Properties.NullText = Nothing
        cbbMailCheck.Properties.PopulateViewColumns()
        cbbMailCheck.Properties.View.Columns("Mail").Width = 200
    End Sub
    Sub LoadLoaiBC()
        Dim dt As DataTable = _db.FillDataTable("SELECT DocName
                                                 FROM HRR_ReportList
                                                 ORDER BY DocName")
        For Each r As DataRow In dt.Rows
            cbbLoaiBaoCao.Properties.Items.Add(r("DocName"))
        Next
    End Sub
    Sub ResetControl()
        cbbMailCheck.ReadOnly = True

        btnSave.Visible = False
        btnSubmit.Visible = False
        btnCheck.Visible = False
        btnReject.Visible = False

        lblPICDate.Visible = False
        lblCheckDate.Visible = False

        cbbLoaiBaoCao.ReadOnly = True

        mmePic.ReadOnly = True
        mmeCheck.ReadOnly = True

        btnAddFile.Visible = False
        btnDeleteFile.Visible = False
    End Sub
    Sub LoadHead()
        ResetControl()
        If _myID = "" Then
            cbbMailCheck.ReadOnly = False
            btnSave.Visible = True
            btnSubmit.Visible = True
            mmePic.ReadOnly = False
            cbbLoaiBaoCao.ReadOnly = False
            btnAddFile.Visible = True
            btnDeleteFile.Visible = True
            dteDate.DateTime = Date.Now
            Return
        End If

        Dim obj As New HRR_ViewReport
        obj.ID_K = _myID
        _db.GetObject(obj)
        txtID.Text = obj.ID_K
        dteDate.EditValue = obj.ReportDate
        txtMailPIC.Text = obj.MailPic
        cbbMailCheck.Text = obj.MailCheck
        mmePic.Text = obj.CommentPic
        mmeCheck.Text = obj.CommentCheck

        cbbLoaiBaoCao.Text = obj.LoaiBaoCao

        GridControl3.DataSource = _db.FillDataTable(String.Format("SELECT AttachedFile, AttachedFileServer
                                                                   FROM HRR_ViewReport_DetailFile
                                                                   WHERE ID = '{0}'", _myID))
        GridControlSetFormat(GridView3)
        GridView3.Columns("AttachedFile").ColumnEdit = GridControlLinkEdit()

        GridControl2.DataSource = _db.FillDataTable(String.Format("SELECT Mail AS ListMailApproved
                                                                   FROM HRR_ViewReport_DetailMail
                                                                   WHERE ID = '{0}'", obj.ID_K))
        GridControlSetFormat(GridView2)
        GridView2.Columns("ListMailApproved").Width = 200

        If obj.DatePic > DateTime.MinValue Then
            lblPICDate.Text = obj.DatePic.ToString("dd-MM-yyyy HH:mm")
            lblPICDate.Visible = True
        Else
            If CurrentUser.Mail = obj.CurrentID And obj.CurrentID = obj.MailPic Then
                cbbMailCheck.ReadOnly = False
                btnSave.Visible = True
                btnSubmit.Visible = True
                mmePic.ReadOnly = False
                cbbLoaiBaoCao.ReadOnly = False
                btnAddFile.Visible = True
                btnDeleteFile.Visible = True
                dteDate.DateTime = Date.Now
                Return
            End If
        End If

        If obj.DateCheck > DateTime.MinValue Then
            lblCheckDate.Text = obj.DateCheck.ToString("dd-MM-yyyy HH:mm")
            lblCheckDate.Visible = True
        Else
            If CurrentUser.Mail = obj.CurrentID And obj.CurrentID = obj.MailCheck Then
                mmeCheck.ReadOnly = False
                btnCheck.Visible = True
                btnReject.Visible = True
                Return
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If CheckData() Then
            SaveData()
            LoadHead()
            ShowSuccess()
        End If
    End Sub
    Function CheckData() As Boolean
        If cbbMailCheck.Text = "" Or txtMailPIC.Text = "" Then
            ShowWarning("Địa chỉ Mail không được để trống !")
            cbbMailCheck.Select()
            Return False
        ElseIf cbbLoaiBaoCao.Text = "" Then
            ShowWarning("Bạn chưa nhập loại báo cáo !")
            cbbLoaiBaoCao.Select()
            Return False
        ElseIf GridView3.RowCount = 0 Then
            ShowWarning("Bạn chưa Attach File !")
            btnAddFile.Select()
            Return False
        End If
        Return True
    End Function
    Sub SaveData()
        Dim obj As New HRR_ViewReport
        If _myID <> "" Then
            obj.ID_K = _myID
            _db.GetObjectNotReset(obj)
        Else
            _myID = GetID()
            obj.ID_K = _myID
            txtID.Text = _myID
            obj.CurrentID = CurrentUser.Mail
        End If

        obj.ReportDate = dteDate.DateTime
        obj.MailPic = txtMailPIC.Text
        obj.MailCheck = cbbMailCheck.Text
        obj.CommentPic = mmePic.Text
        obj.CommentCheck = mmeCheck.Text
        obj.LoaiBaoCao = cbbLoaiBaoCao.Text
        If _db.ExistObject(obj) Then
            _db.Update(obj)
        Else
            _db.Insert(obj)
        End If

        For r = 0 To GridView2.RowCount - 1
            Dim objM As New HRR_ViewReport_DetailMail
            objM.ID_K = obj.ID_K
            objM.Mail_K = GridView2.GetRowCellValue(r, "ListMailApproved")
            If Not _db.ExistObject(objM) Then
                _db.Insert(objM)
            End If
        Next
    End Sub
    Function GetID() As String
        Dim myID As String = ""
        Dim stt As String = ""
        Dim yyMM As String = DateTime.Now.ToString("yyMM")
        Dim val As Object = _db.ExecuteScalar(String.Format("SELECT RIGHT(MAX(ID), 3) 
                                                             FROM HRR_ViewReport
                                                             WHERE ID LIKE '%{0}%'", yyMM))
        If Not IsDBNull(val) And val IsNot Nothing Then
            val = Integer.Parse(val) + 1
            stt = val.ToString.PadLeft(3, "0")
            myID = "HRR" + yyMM + "-" + stt
        Else
            myID = "HRR" + yyMM + "-" + "001"
        End If
        Return myID
    End Function

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If CheckData() Then
            SaveData()
            Dim obj As New HRR_ViewReport
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.DatePic = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, ConfirmHRR.PIC, obj.CommentPic, Nothing, obj)
        End If
    End Sub
    Public Enum ConfirmHRR
        PIC
        Check
    End Enum
    Sub ConfirmUpdateOutlook(sumit As Submit, confirm As ConfirmOT, comment As String, cc As List(Of String), obj As HRR_ViewReport)
        Try
            _db.BeginTransaction()
            Dim lstTo As New List(Of String)
            Dim lstCC As New List(Of String)
            Dim lstBCC As New List(Of String)
            Dim arrCc() As String = Nothing
            Dim title = "(Reject) " + cbbLoaiBaoCao.Text + " - " & obj.ReportDate.ToString("dd/MM/yyyy")

            If sumit = Submit.Reject Then
                obj.DatePic = Nothing
                obj.DateCheck = Nothing
                obj.CurrentID = obj.MailPic
                lstTo.Add(obj.MailPic)
                clsApplication.SendMailOutlook(title, Nothing, Submit.Info, lstTo, Nothing, Nothing, Nothing, Tag, obj.ID_K)
            Else
                title = cbbLoaiBaoCao.Text + " - " & obj.ReportDate.ToString("dd/MM/yyyy")
                Select Case confirm
                    Case ConfirmHRR.PIC
                        If obj.MailCheck <> "" Then
                            lstTo.Add(obj.MailCheck)
                            clsApplication.SendMailOutlook(title, Nothing, Submit.Info, lstTo, Nothing, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.MailCheck
                            GoTo EndConfirm
                        End If
                        GoTo Check
                    Case ConfirmHRR.Check
Check:
                        lstTo.Add(obj.MailPic)
                        For r = 0 To GridView2.RowCount - 1
                            lstTo.Add(GridView2.GetRowCellValue(r, "ListMailApproved"))
                        Next
                        clsApplication.SendMailOutlook(title, Nothing, Submit.Info, lstTo, lstCC, Nothing, Nothing, Tag, obj.ID_K)
                        obj.CurrentID = ""
                        GoTo EndConfirm
                End Select
            End If
EndConfirm:
            _db.Update(obj)
            _db.Commit()
            NextRequest()
        Catch ex As Exception
            _db.RollBack()
            ShowError(ex, "Confirm", Me.Name)
        End Try
    End Sub
    Sub NextRequest()
        Dim obj As Object = _db.ExecuteScalar(String.Format("SELECT ID FROM HRR_ViewReport 
                                                             WHERE CurrentID = '{0}' ORDER BY ID",
                                                             CurrentUser.Mail))
        If obj IsNot Nothing Then
            _myID = obj
        End If
        LoadHead()
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        If CheckData() Then
            SaveData()
            Dim obj As New HRR_ViewReport
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.DateCheck = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, ConfirmHRR.Check, obj.CommentCheck, Nothing, obj)
        End If
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If mmeCheck.Text.Trim() <> "" Then
            Dim obj As New HRR_ViewReport
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.CommentCheck = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), mmeCheck.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, ConfirmHRR.Check, obj.CommentCheck, Nothing, obj)
        Else
            ShowWarning("Bạn phải ghi chú lý do từ chối yêu cầu !" + vbCrLf + "Please comment detail.")
            mmeCheck.Select()
        End If
    End Sub

    Private Sub cbbLoaiBaoCao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbLoaiBaoCao.SelectedIndexChanged
        GridControl2.DataSource = _db.FillDataTable(String.Format("SELECT d.Email AS ListMailApproved
                                                                   FROM HRR_ReportList_Detail AS d
                                                                   LEFT JOIN HRR_ReportList AS h
                                                                   ON h.DocNo = d.DocNo
                                                                   WHERE DocName = N'{0}' 
                                                                   ORDER BY Email", cbbLoaiBaoCao.Text))
    End Sub

    Private Sub btnAddFile_Click(sender As Object, e As EventArgs) Handles btnAddFile.Click
        Dim frm As New OpenFileDialog
        frm.ShowDialog()
        If frm.FileName <> "" Then
            Dim AttachFile = frm.SafeFileName
            Dim AttachFileLink = myPath & dteDate.DateTime.ToString("dd-MM-yyyy") & "_" & _myID & "_HRR_" & frm.SafeFileName
            File.Copy(frm.FileName, AttachFileLink, True)

            If _myID = "" Then
                Dim objH As New HRR_ViewReport
                _myID = GetID()
                objH.ID_K = _myID
                txtID.Text = _myID
                objH.CurrentID = CurrentUser.Mail
                objH.ReportDate = dteDate.DateTime
                objH.MailPic = txtMailPIC.Text
                _db.Insert(objH)
            End If
            Dim obj As New HRR_ViewReport_DetailFile
            obj.ID_K = _myID
            obj.AttachedFile_K = AttachFile
            obj.AttachedFileServer = AttachFileLink
            If Not _db.ExistObject(obj) Then
                _db.Insert(obj)
            End If
            GridControl3.DataSource = _db.FillDataTable(String.Format("SELECT AttachedFile, AttachedFileServer
                                                                       FROM HRR_ViewReport_DetailFile
                                                                       WHERE ID = '{0}'", _myID))
            GridControlSetFormat(GridView3)
            GridView3.Columns("AttachedFile").ColumnEdit = GridControlLinkEdit()
        End If
        frm.Dispose()
    End Sub

    Private Sub btnDeleteFile_Click(sender As Object, e As EventArgs) Handles btnDeleteFile.Click
        If File.Exists(GridView3.GetFocusedRowCellValue("AttachedFileServer")) Then
            File.Delete(GridView3.GetFocusedRowCellValue("AttachedFileServer"))
            Dim obj As New HRR_ViewReport_DetailFile
            obj.ID_K = _myID
            obj.AttachedFile_K = GridView3.GetFocusedRowCellValue("AttachedFile")
            _db.Delete(obj)
            GridView3.DeleteSelectedRows()
        End If
    End Sub

    Private Sub GridView3_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView3.RowClick
        If File.Exists(GridView3.GetFocusedRowCellValue("AttachedFileServer")) Then
            Process.Start(OpenfileTemp(GridView3.GetFocusedRowCellValue("AttachedFileServer")))
        End If
    End Sub
End Class