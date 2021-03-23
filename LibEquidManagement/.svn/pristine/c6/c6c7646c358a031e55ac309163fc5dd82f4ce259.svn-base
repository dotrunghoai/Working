Imports System.IO
Imports CommonDB
'Imports LibEntity
Imports PublicUtility
Public Class FrmVerifyRequest

    Public _myID As String = ""
    Dim myPath As String = CurrentUser.TempFolder & "QAE\"
    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmVerifyRequest_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadEmail()
        dtpDate.EditValue = Date.Now

        If _myID = "" Then
            _myID = Me.AccessibleName
        End If
        LoadHead()
    End Sub

    Sub LoadEmail()
        Dim sql As String = String.Format(" select m.EmpID,m.Mail from OT_Mail m " +
                                          " inner join OT_Employee e " +
                                          " on m.EmpID=e.EmpID" +
                                          " where e.SectionSort='{0}' and m.Mail<>'' " +
                                          " order by m.Mail ",
                                          CurrentUser.SortSection)
        Dim tb As DataTable = _db.FillDataTable(sql)
        cboChecked.DataSource = _db.FillDataTable(sql)
        cboChecked.ValueMember = "EmpID"
        cboChecked.DisplayMember = "Mail"
        cboChecked.SelectedIndex = -1

        cboApproved.DataSource = tb.Copy
        cboApproved.ValueMember = "EmpID"
        cboApproved.DisplayMember = "Mail"
        cboApproved.SelectedIndex = -1

        Dim obj As New QAE_Approver
        obj.ID_K = 1
        _db.GetObject(obj)

        txtMailPIC.Text = CurrentUser.Mail
        txtMailPICQA.Text = obj.PIC
        txtMailCheckedQA.Text = obj.Checked
        txtMailApprovedQA.Text = obj.Approved

        'txtMailPIC.Text = CurrentUser.Mail
        'cboChecked.Text = CurrentUser.Mail
        'cboApproved.Text = CurrentUser.Mail
        'txtMailPICQA.Text = CurrentUser.Mail
        'txtMailCheckedQA.Text = CurrentUser.Mail
        'txtMailApprovedQA.Text = CurrentUser.Mail

    End Sub

    Sub ResetControl()
        bttSubmit.Visible = False
        bttSave.Visible = False

        bttChecked.Visible = False
        bttApproved.Visible = False
        bttPICQA.Visible = False
        bttCheckedQA.Visible = False
        bttApprovedQA.Visible = False

        bttRejectChecked.Visible = False
        bttRejectApproved.Visible = False
        bttRejectPICQA.Visible = False
        bttRejectCheckedQA.Visible = False
        bttRejectApprovedQA.Visible = False

        txtCmtPIC.ReadOnly = True
        txtCmtChecked.ReadOnly = True
        txtCmtApproved.ReadOnly = True
        txtCmtPICQA.ReadOnly = True
        txtCmtCheckedQA.ReadOnly = True
        txtCmtApprovedQA.ReadOnly = True

        lblDatePIC.Text = ""
        lblDateChecked.Text = ""
        lblDateApproved.Text = ""
        lblDatePICQA.Text = ""
        lblDateCheckedQA.Text = ""
        lblDateApprovedQA.Text = ""

        bttAddFile.Visible = False
        bttDelete.Visible = False

        txtNoiDeNghi.ReadOnly = True
        txtTenThietBi.ReadOnly = True
        txtMucDichSuDung.ReadOnly = True
        txtPhamViSuDung.ReadOnly = True
        txtGiaTriSuDung.ReadOnly = True

        txtDoPhanGiai.ReadOnly = True
        txtGiayToKhac.ReadOnly = True
        txtGhiChu.ReadOnly = True

        ckoKhac.ReadOnly = True
        ckoKhongCan.ReadOnly = True
        ckoKQKiemTra.ReadOnly = True
        ckoPhieuXacNhan.ReadOnly = True
        ckoThietBiDoKhongKiemSoat.ReadOnly = True
        ckoThietBiDoKiemSoat.ReadOnly = True

        cboChecked.Enabled = False
        cboApproved.Enabled = False

        bttSaveQA.Visible = False
    End Sub

    Sub EnabelSection()

        bttAddFile.Visible = True
        bttDelete.Visible = True
        cboChecked.Enabled = True
        cboApproved.Enabled = True

        txtNoiDeNghi.ReadOnly = False
        txtTenThietBi.ReadOnly = False
        txtMucDichSuDung.ReadOnly = False
        txtPhamViSuDung.ReadOnly = False
        txtGiaTriSuDung.ReadOnly = False
    End Sub

    Sub EnabelQA()
        txtDoPhanGiai.ReadOnly = False
        txtGiayToKhac.ReadOnly = False
        txtGhiChu.ReadOnly = False

        ckoKhac.ReadOnly = False
        ckoKhongCan.ReadOnly = False
        ckoKQKiemTra.ReadOnly = False
        ckoPhieuXacNhan.ReadOnly = False
        ckoThietBiDoKhongKiemSoat.ReadOnly = False
        ckoThietBiDoKiemSoat.ReadOnly = False

        bttSaveQA.Visible = True
    End Sub

    Sub LoadHead()
        ResetControl()
        If _myID = "" Then
            bttSave.Visible = True
            bttSubmit.Visible = True
            txtSection.Text = CurrentUser.SortSection
            dtpDate.DateTime = Date.Now

            EnabelSection()
            Return
        End If
        Dim obj As New QAE_Verify
        obj.ID_K = _myID
        _db.GetObject(obj)

        txtID.Text = _myID
        txtSection.Text = obj.Section
        dtpDate.EditValue = obj.RequestDate

        txtMailPIC.Text = obj.PIC
        cboChecked.Text = obj.Checked
        cboApproved.Text = obj.Approved
        txtMailPICQA.Text = obj.QAPIC
        txtMailCheckedQA.Text = obj.QAChecked
        txtMailApprovedQA.Text = obj.QAApproved

        txtCmtPIC.Text = obj.PICComment
        txtCmtChecked.Text = obj.CheckedComment
        txtCmtApproved.Text = obj.ApprovedComment
        txtCmtPICQA.Text = obj.QAPICComment
        txtCmtCheckedQA.Text = obj.QACheckedComment
        txtCmtApprovedQA.Text = obj.QAApprovedComment

        'Load Data Section
        txtNoiDeNghi.Text = obj.NoiDeNghi
        txtTenThietBi.Text = obj.TenThietBi
        txtMucDichSuDung.Text = obj.MucDichSuDung
        txtPhamViSuDung.Text = obj.PhamViSuDung
        txtGiaTriSuDung.Text = obj.GiaTriSuDungNhoNhat

        linkAttached.Text = obj.AttachedFile
        linkAttached.Tag = obj.AttachedFileServer
        'Load Data QA
        txtDoPhanGiai.Text = obj.DoPhanGiaiChoThietBi
        ckoThietBiDoKiemSoat.Checked = obj.ThietBiDoLuongCoKiemSoat
        ckoThietBiDoKhongKiemSoat.Checked = obj.ThietBiDoLuongKhongKiemSoat

        ckoPhieuXacNhan.Checked = obj.PhieuXacNhanChatLuong
        ckoKhac.Checked = obj.GiayToKhac
        ckoKhongCan.Checked = obj.KhongCan
        ckoKQKiemTra.Checked = obj.KetQuaKiemTraThietBiDo
        txtGhiChu.Text = obj.GhiChu
        txtGiayToKhac.Text = obj.GiayToKhac

        'Load Approved
        If obj.PICDate > DateTime.MinValue Then
            lblDatePIC.Text = obj.PICDate.ToString("dd-MM-yyyy HH:mm")
            lblDatePIC.Visible = True
            bttSave.Visible = False
            bttSubmit.Visible = False
        Else
            If CurrentUser.Mail = obj.CurrentID And obj.CurrentID = obj.PIC Then
                lblDatePIC.Visible = False
                bttSave.Visible = True
                bttSubmit.Visible = True
                EnabelSection()

                txtCmtPIC.ReadOnly = False
                GoTo GotoDetail
            End If
        End If

        If obj.CheckedDate > DateTime.MinValue Then
            lblDateChecked.Visible = True
            lblDateChecked.Text = obj.CheckedDate.ToString("dd-MM-yyyy HH:mm")
        Else
            If CurrentUser.Mail = obj.CurrentID And obj.CurrentID = obj.Checked Then
                lblDateChecked.Visible = False
                bttChecked.Visible = True
                bttRejectChecked.Visible = True
                txtCmtChecked.ReadOnly = False

                EnabelSection()
                GoTo GotoDetail
            End If
        End If

        If obj.ApprovedDate > DateTime.MinValue Then
            lblDateApproved.Visible = True
            lblDateApproved.Text = obj.ApprovedDate.ToString("dd-MM-yyyy HH:mm")
        Else
            If obj.CurrentID = CurrentUser.Mail And obj.CurrentID = obj.Approved Then
                lblDateApproved.Visible = False
                bttApproved.Visible = True
                bttRejectApproved.Visible = True
                txtCmtApproved.ReadOnly = False

                EnabelSection()
                GoTo GotoDetail
            End If
        End If

        If obj.QAPICDate > DateTime.MinValue Then
            lblDatePICQA.Visible = True
            lblDatePICQA.Text = obj.QAPICDate.ToString("dd-MM-yyyy HH:mm")
        Else
            If obj.CurrentID = CurrentUser.Mail And obj.CurrentID = obj.QAPIC Then
                lblDatePICQA.Visible = False
                bttPICQA.Visible = True
                bttRejectPICQA.Visible = True
                txtCmtPICQA.ReadOnly = False

                EnabelQA()
                GoTo GotoDetail
            End If
        End If

        If obj.QACheckedDate > DateTime.MinValue Then
            lblDateCheckedQA.Visible = True
            lblDateCheckedQA.Text = obj.QACheckedDate.ToString("dd-MM-yyyy HH:mm")
        Else
            If CurrentUser.Mail = obj.CurrentID And obj.CurrentID = obj.QAChecked Then
                lblDateCheckedQA.Visible = False
                bttCheckedQA.Visible = True
                bttRejectCheckedQA.Visible = True
                txtCmtCheckedQA.ReadOnly = False

                EnabelQA()
                GoTo GotoDetail
            End If
        End If

        If obj.QAApprovedDate > DateTime.MinValue Then
            lblDateApprovedQA.Visible = True
            lblDateApprovedQA.Text = obj.QAApprovedDate.ToString("dd-MM-yyyy HH:mm")
        Else
            If CurrentUser.Mail = obj.CurrentID And obj.CurrentID = obj.QAApproved Then
                lblDateApprovedQA.Visible = False
                bttApprovedQA.Visible = True
                bttRejectApprovedQA.Visible = True
                txtCmtApprovedQA.ReadOnly = False

                EnabelQA()
                GoTo GotoDetail
            End If
        End If

GotoDetail:
    End Sub

    Private Sub bttAddFile_Click(sender As Object, e As EventArgs) Handles bttAddFile.Click
        Dim frm As New OpenFileDialog
        frm.ShowDialog()
        If frm.FileName <> "" Then
            linkAttached.Text = frm.SafeFileName
            linkAttached.Tag = frm.FileName
        End If
        frm.Dispose()
    End Sub

    Private Sub bttDelete_Click(sender As Object, e As EventArgs) Handles bttDelete.Click
        linkAttached.Text = ""
        linkAttached.Tag = ""
    End Sub

    Sub ConfirmUpdateOutlook(sumit As Submit, confirm As ConfirmOT, comment As String, cc As List(Of String), obj As QAE_Verify)
        Try
            _db.BeginTransaction()
            Dim lstTo As New List(Of String)
            Dim lstCC As New List(Of String)
            Dim lstBCC As New List(Of String)

            Dim arrCc() As String = Nothing
            Dim title = "(" & obj.Section & ")" & " Xác nhận kết quả hiệu chuẩn " & obj.RequestDate.ToString("dd-MM-yyyy")
            If sumit = Submit.Reject Then
                obj.PICDate = Nothing
                obj.CheckedDate = Nothing
                obj.ApprovedDate = Nothing
                obj.QAPICDate = Nothing
                obj.QACheckedDate = Nothing
                obj.QAApprovedDate = Nothing
                obj.CurrentID = obj.PIC

                lstTo.Add(obj.PIC)
                SendMailOutlook(title, Nothing, sumit, lstTo, Nothing, Nothing, Nothing, Tag, obj.ID_K)

            Else
                Select Case confirm
                    Case ConfirmQAE.PIC
                        lstTo.Add(obj.Checked)
                        SendMailOutlook(title, Nothing, sumit, lstTo, Nothing, Nothing, Nothing, Tag, obj.ID_K)
                        obj.CurrentID = obj.Checked
                        GoTo EndConfirm
                    Case ConfirmQAE.Check
                        If obj.Approved <> "" Then
                            lstTo.Add(obj.Approved)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.Approved
                            GoTo EndConfirm
                        End If
                    Case ConfirmQAE.Approved
                        If obj.QAPIC <> "" Then
                            lstTo.Add(obj.QAPIC)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.QAPIC
                            GoTo EndConfirm
                        End If
                    Case ConfirmQAE.QAPIC
                        If obj.QAChecked <> "" Then
                            lstTo.Add(obj.QAChecked)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.QAChecked
                            GoTo EndConfirm
                        End If
                    Case ConfirmQAE.QACheck
                        If obj.QAApproved <> "" Then
                            lstTo.Add(obj.QAApproved)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.QAApproved
                            GoTo EndConfirm
                        End If
                    Case ConfirmQAE.QAApproved
                        If obj.PIC <> "" Then
                            lstTo.Add(obj.PIC)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = ""
                            GoTo EndConfirm
                        End If
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

    Private Sub NextRequest()
        Dim obj As Object = _db.ExecuteScalar(String.Format(" select ID from {0} " +
                                                            " where CurrentID='{1}' order by ID ",
                                                    PublicTable.Table_QAE_Verify,
                                                    CurrentUser.Mail))
        If obj IsNot Nothing Then
            _myID = obj
        End If
        LoadHead()
    End Sub

    Function CheckedConditionSection() As Boolean
        If txtMailPIC.Text = "" Or
                cboChecked.Text = "" Or
                cboApproved.Text = "" Or
            txtMailPICQA.Text = "" Or
            txtMailCheckedQA.Text = "" Or
            txtMailApprovedQA.Text = "" Then
            ShowWarning("Địa chỉ mail không được để trống !")
            Return False
        End If

        If txtNoiDeNghi.Text = "" Then
            ShowWarning("Bạn chưa nhập nơi đề nghị !")
            Return False
        End If
        If txtTenThietBi.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập tên thiết bị !")
            Return False
        End If
        If txtMucDichSuDung.Text.Trim = "" Then
            ShowWarning("Bạn nhập mục đích sử dụng !")
            Return False
        End If
        If txtPhamViSuDung.Text.Trim = "" Then
            ShowWarning("Bạn nhập phạm vi sử dụng !")
            Return False
        End If

        Return True
    End Function

    Private Sub bttSave_Click(sender As Object, e As EventArgs) Handles bttSave.Click

        If CheckedConditionSection() Then
            SaveData()
            LoadHead()
            ShowSuccess()
        End If

    End Sub

    Function GetID() As String
        Dim myID As String = ""
        Dim myDate As String = "V" & Date.Today.ToString("yyMMdd") & "-"
        Dim STT As Object = _db.ExecuteScalar(String.Format(" select isnull(max(right(ID,2)),0)+1 as STT " +
                                                            " from QAE_Verify " +
                                                            " where ID like '{0}%'", myDate))
        If IsNumeric(STT) Then
            myID = myDate & STT.ToString().PadLeft(2, "0")
        Else
            myID = myDate & "01"
        End If
        Return myID
    End Function

    Function SaveData() As Boolean
        Dim obj As New QAE_Verify
        If _myID <> "" Then
            obj.ID_K = _myID
            _db.GetObjectNotReset(obj)
        Else
            _myID = GetID()
            obj.ID_K = _myID
            txtID.Text = _myID
            obj.CurrentID = CurrentUser.Mail
        End If
        obj.Section = txtSection.Text
        obj.RequestDate = dtpDate.DateTime.Date

        obj.PIC = txtMailPIC.Text
        obj.Checked = cboChecked.Text
        obj.Approved = cboApproved.Text
        obj.QAPIC = txtMailPICQA.Text
        obj.QAChecked = txtMailCheckedQA.Text
        obj.QAApproved = txtMailApprovedQA.Text

        'save Data Section
        obj.NoiDeNghi = txtNoiDeNghi.Text
        obj.TenThietBi = txtTenThietBi.Text
        obj.MucDichSuDung = txtMucDichSuDung.Text
        obj.PhamViSuDung = txtPhamViSuDung.Text
        obj.GiaTriSuDungNhoNhat = txtGiaTriSuDung.Text

        If linkAttached.Tag = "" Then
            obj.AttachedFile = ""
            obj.AttachedFileServer = ""
        Else
            If Not linkAttached.Tag.ToString.Contains(myPath) Then
                obj.AttachedFile = linkAttached.Text
                obj.AttachedFileServer = myPath & obj.ID_K & "_" & linkAttached.Text
                File.Copy(linkAttached.Tag, obj.AttachedFileServer, True)
            End If
        End If

        'save Data QA
        obj.DoPhanGiaiChoThietBi = txtDoPhanGiai.Text
        obj.ThietBiDoLuongCoKiemSoat = ckoThietBiDoKiemSoat.Checked
        obj.ThietBiDoLuongKhongKiemSoat = ckoThietBiDoKhongKiemSoat.Checked

        obj.PhieuXacNhanChatLuong = ckoPhieuXacNhan.Checked
        obj.GiayToKhac = ckoKhac.Checked
        obj.KhongCan = ckoKhongCan.Checked
        obj.KetQuaKiemTraThietBiDo = ckoKQKiemTra.Checked
        obj.GhiChu = txtGhiChu.Text

        If _db.ExistObject(obj) Then
            _db.Update(obj)
        Else
            obj.CreatedDate = DateTime.Now
            obj.CreatedUser = CurrentUser.UserID
            _db.Insert(obj)
        End If
        Return True
    End Function

    Private Sub bttSubmit_Click(sender As Object, e As EventArgs) Handles bttSubmit.Click
        If CheckedConditionSection() Then
            SaveData()
            Dim obj As New QAE_Verify
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.PICComment = txtCmtPIC.Text
            obj.PICDate = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, ConfirmQAE.PIC, obj.PICComment, Nothing, obj)
        End If
    End Sub

    Private Sub bttChecked_Click(sender As Object, e As EventArgs) Handles bttChecked.Click
        If CheckedConditionSection() Then
            SaveData()
            Dim obj As New QAE_Verify
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.CheckedComment = txtCmtChecked.Text
            obj.CheckedDate = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, ConfirmQAE.Check, obj.CheckedComment, Nothing, obj)
        End If
    End Sub

    Private Sub bttApproved_Click(sender As Object, e As EventArgs) Handles bttApproved.Click
        If CheckedConditionSection() Then
            SaveData()
            Dim obj As New QAE_Verify
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.ApprovedComment = txtCmtApproved.Text
            obj.ApprovedDate = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, ConfirmQAE.Approved, obj.ApprovedComment, Nothing, obj)
        End If
    End Sub

    Private Sub bttPICQA_Click(sender As Object, e As EventArgs) Handles bttPICQA.Click
        If CheckedConditionQA() Then
            SaveData()
            Dim obj As New QAE_Verify
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.QAPICComment = txtCmtPICQA.Text
            obj.QAPICDate = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, ConfirmQAE.QAPIC, obj.QAPICComment, Nothing, obj)
        End If
    End Sub

    Private Sub bttCheckedQA_Click(sender As Object, e As EventArgs) Handles bttCheckedQA.Click
        If CheckedConditionQA() Then
            SaveData()
            Dim obj As New QAE_Verify
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.QACheckedComment = txtCmtCheckedQA.Text
            obj.QACheckedDate = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, ConfirmQAE.QACheck, obj.QACheckedComment, Nothing, obj)
        End If
    End Sub

    Private Sub bttApprovedQA_Click(sender As Object, e As EventArgs) Handles bttApprovedQA.Click
        If CheckedConditionQA() Then
            SaveData()
            Dim obj As New QAE_Verify
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.QAApprovedComment = txtCmtApprovedQA.Text
            obj.QAApprovedDate = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, ConfirmQAE.QAApproved, obj.QAApprovedComment, Nothing, obj)
        End If
    End Sub

    Private Sub bttRejectChecked_Click(sender As Object, e As EventArgs) Handles bttRejectChecked.Click
        If txtCmtChecked.Text.Trim() <> "" Then
            Dim obj As New QAE_Verify
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.CheckedComment = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtChecked.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, ConfirmQAE.Check, obj.CheckedComment, Nothing, obj)
        Else
            ShowWarning("Bạn phải nghi chú lý do từ chối yêu cầu." + vbCrLf + "Please comment detail.")
            txtCmtChecked.Focus()
        End If
    End Sub

    Private Sub bttRejectApproved_Click(sender As Object, e As EventArgs) Handles bttRejectApproved.Click
        If txtCmtApproved.Text.Trim() <> "" Then
            Dim obj As New QAE_Verify
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.ApprovedComment = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtApproved.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, ConfirmQAE.Approved, obj.ApprovedComment, Nothing, obj)
        Else
            ShowWarning("Bạn phải nghi chú lý do từ chối yêu cầu." + vbCrLf + "Please comment detail.")
            txtCmtApproved.Focus()
        End If
    End Sub

    Private Sub bttRejectPICQA_Click(sender As Object, e As EventArgs) Handles bttRejectPICQA.Click
        If txtCmtPICQA.Text.Trim() <> "" Then
            Dim obj As New QAE_Verify
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.QAPICComment = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtPICQA.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, ConfirmQAE.QAPIC, obj.QAPICComment, Nothing, obj)
        Else
            ShowWarning("Bạn phải nghi chú lý do từ chối yêu cầu." + vbCrLf + "Please comment detail.")
            txtCmtPICQA.Focus()
        End If
    End Sub

    Private Sub bttRejectCheckedQA_Click(sender As Object, e As EventArgs) Handles bttRejectCheckedQA.Click
        If txtCmtCheckedQA.Text.Trim() <> "" Then
            Dim obj As New QAE_Verify
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.QACheckedComment = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtCheckedQA.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, ConfirmQAE.QACheck, obj.QACheckedComment, Nothing, obj)
        Else
            ShowWarning("Bạn phải nghi chú lý do từ chối yêu cầu." + vbCrLf + "Please comment detail.")
            txtCmtCheckedQA.Focus()
        End If
    End Sub

    Private Sub bttRejectApprovedQA_Click(sender As Object, e As EventArgs) Handles bttRejectApprovedQA.Click
        If txtCmtApprovedQA.Text.Trim() <> "" Then
            Dim obj As New QAE_Verify
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.QAApprovedComment = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtApprovedQA.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, ConfirmQAE.QAApproved, obj.QAApprovedComment, Nothing, obj)
        Else
            ShowWarning("Bạn phải nghi chú lý do từ chối yêu cầu." + vbCrLf + "Please comment detail.")
            txtCmtApprovedQA.Focus()
        End If
    End Sub

    Private Sub bttSaveQA_Click(sender As Object, e As EventArgs) Handles bttSaveQA.Click
        If CheckedConditionQA() Then
            SaveData()
            ShowSuccess()
        End If
    End Sub

    Function CheckedConditionQA() As Boolean
        If txtDoPhanGiai.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập độ phân giải thiết bị !")
            Return False
        End If
        If ckoThietBiDoKiemSoat.Checked = ckoThietBiDoKhongKiemSoat.Checked Then
            ShowWarning("Bạn chưa chọn loại hình đăng lục !")
            Return False
        End If
        If ckoKhac.Checked And txtGiayToKhac.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập giấy tờ khác !")
            Return False
        End If

        If ckoKhac.Checked = False And
            ckoKhongCan.Checked = False And
            ckoKQKiemTra.Checked = False And
            ckoPhieuXacNhan.Checked = False Then
            ShowWarning("Bạn chưa chọn giấy tờ cần thiết để đăng lục !")
            Return False
        End If

        Return True
    End Function

    Private Sub linkAttached_Click(sender As Object, e As EventArgs) Handles linkAttached.Click
        If File.Exists(linkAttached.Tag) Then
            If txtNoiDeNghi.ReadOnly = False Then
                Process.Start(linkAttached.Tag)
            Else
                Process.Start(OpenfileTemp(linkAttached.Tag))
            End If
        End If
    End Sub
End Class