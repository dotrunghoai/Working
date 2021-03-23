Imports System.IO
Imports CommonDB
'Imports LibEntity
Imports PublicUtility

Public Class FrmAbnormalRequest
    Public _myID As String = ""
    Dim myPath As String = CurrentUser.TempFolder & "QAE\"
    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub FrmRegisterRequest_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadEmail()
        dtpRequestDate.EditValue = Date.Now
        If _myID = "" Then
            _myID = Me.AccessibleName
        End If
        LoadHead()
    End Sub

    Sub LoadEmail()
        txtMailPIC.Text = CurrentUser.Mail
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
        txtMailPICQA.Text = obj.PIC
        txtMailCheckedQA.Text = obj.Checked
        txtMailApprovedQA.Text = obj.Approved

        txtMailPreKQ.Text = txtMailPIC.Text
        txtMailCheckKQ.Text = cboChecked.Text
        txtMailAppKQ.Text = cboApproved.Text
        txtMailPicKQ.Text = txtMailPICQA.Text
        txtMailCheckQAKQ.Text = txtMailCheckedQA.Text
        txtMailAppQAKQ.Text = txtMailApprovedQA.Text

        ''Test Mail
        'txtMailPIC.Text = CurrentUser.Mail
        'cboChecked.Text = CurrentUser.Mail
        'cboApproved.Text = CurrentUser.Mail
        'txtMailPICQA.Text = CurrentUser.Mail
        'txtMailCheckedQA.Text = CurrentUser.Mail
        'txtMailApprovedQA.Text = CurrentUser.Mail

        'txtMailPreKQ.Text = CurrentUser.Mail
        'txtMailCheckKQ.Text = CurrentUser.Mail
        'txtMailAppKQ.Text = CurrentUser.Mail
        'txtMailPicKQ.Text = CurrentUser.Mail
        'txtMailCheckQAKQ.Text = CurrentUser.Mail
        'txtMailAppQAKQ.Text = CurrentUser.Mail

    End Sub

    Sub ResetControl()
        bttSubmit.Visible = False
        bttChecked.Visible = False
        bttApproved.Visible = False
        bttPICQA.Visible = False
        bttCheckedQA.Visible = False
        bttApprovedQA.Visible = False

        bttSave.Visible = False
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

        btnSubmitKQ.Visible = False
        btnSaveKQ.Visible = False
        btnCheckedKQ.Visible = False
        btnRejectCheckedKQ.Visible = False
        btnApprovedKQ.Visible = False
        btnRejectApprovedKQ.Visible = False
        btnPICQAKQ.Visible = False
        btnRejectPicKQ.Visible = False
        btnCheckedQAKQ.Visible = False
        btnRejectCheckedQAKQ.Visible = False
        btnApprovedQAKQ.Visible = False
        btnRejectApprovedQAKQ.Visible = False

        txtCmtPreKQ.ReadOnly = True
        txtCmtCheckedKQ.ReadOnly = True
        txtCmtApprovedKQ.ReadOnly = True
        txtCmtPICQAKQ.ReadOnly = True
        txtCmtCheckedQAKQ.ReadOnly = True
        txtCmtApprovedQAKQ.ReadOnly = True

        lblDatePIC.Text = ""
        lblDateChecked.Text = ""
        lblDateApproved.Text = ""
        lblDatePICQA.Text = ""
        lblDateCheckedQA.Text = ""
        lblDateApprovedQA.Text = ""

        lblPreKQ.Text = ""
        lblCheckedKQ.Text = ""
        lblApprovedKQ.Text = ""
        lblPicQAKQ.Text = ""
        lblCheckedQAKQ.Text = ""
        lblApprovedQAKQ.Text = ""

        ''Section
        cboChecked.Enabled = False
        cboApproved.Enabled = False

        dtpNgayPhatSinh.ReadOnly = True
        txtNoiDungSuCo.ReadOnly = True
        txtSanPhamDo.ReadOnly = True
        txtMucDichDo.ReadOnly = True
        txtThuocTinhDo.ReadOnly = True
        txtChuanSanPham.ReadOnly = True
        cboXacNhanSuAnhHuong.ReadOnly = True
        txtThuocTinhDo.ReadOnly = True
        txtPhamViSPKhongPhuHop.ReadOnly = True
        cboXuLyDungCu.ReadOnly = True
        txtXuLyKhac.ReadOnly = True
        dteDeadline.ReadOnly = True
        dteDealing2.ReadOnly = True
        dteDealing3.ReadOnly = True
        dteDealing4.ReadOnly = True
        dteDealing5.ReadOnly = True
        bttAddFile.Visible = False
        bttDeleteFile.Visible = False
        bttAddThietBi.Visible = False

        ''QA
        txtKQXacNhanQA.ReadOnly = True
        txtXuLySanPham.ReadOnly = True
        cboBaoCao.ReadOnly = True
        bttSaveQA.Visible = False

        'KQXL
        mmeDanhGiaNgoaiQuan.ReadOnly = True
        mmeDanhGiaChucNang.ReadOnly = True
        cbbDanhGiaTong.ReadOnly = True
        cbbXuLySauCung.ReadOnly = True
        mmeRemark.ReadOnly = True
        btnAddFileFinish.Visible = False
        btnDeleteFileFinish.Visible = False
    End Sub

    Sub EnabelSection()
        cboChecked.Enabled = True
        cboApproved.Enabled = True

        dtpNgayPhatSinh.ReadOnly = False
        txtNoiDungSuCo.ReadOnly = False
        txtSanPhamDo.ReadOnly = False
        txtMucDichDo.ReadOnly = False
        txtThuocTinhDo.ReadOnly = False
        txtChuanSanPham.ReadOnly = False
        cboXacNhanSuAnhHuong.ReadOnly = False
        txtThuocTinhDo.ReadOnly = False
        txtPhamViSPKhongPhuHop.ReadOnly = False
        cboXuLyDungCu.ReadOnly = False
        txtXuLyKhac.ReadOnly = False
        If dteDeadline.DateTime > DateTime.MinValue Then
            If dteDeadline.DateTime < DateTime.Now Then
                dteDeadline.ReadOnly = True
            Else
                dteDeadline.ReadOnly = False
                GoTo Label
            End If
        Else
            dteDeadline.ReadOnly = False
            GoTo Label
        End If

        If dteDealing2.DateTime > DateTime.MinValue Then
            If dteDealing2.DateTime < DateTime.Now Then
                dteDealing2.ReadOnly = True
            Else
                dteDealing2.ReadOnly = False
                GoTo Label
            End If
        Else
            dteDealing2.ReadOnly = False
            GoTo Label
        End If

        If dteDealing3.DateTime > DateTime.MinValue Then
            If dteDealing3.DateTime < DateTime.Now Then
                dteDealing3.ReadOnly = True
            Else
                dteDealing3.ReadOnly = False
                GoTo Label
            End If
        Else
            dteDealing3.ReadOnly = False
            GoTo Label
        End If

        If dteDealing4.DateTime > DateTime.MinValue Then
            If dteDealing4.DateTime < DateTime.Now Then
                dteDealing4.ReadOnly = True
            Else
                dteDealing4.ReadOnly = False
                GoTo Label
            End If
        Else
            dteDealing4.ReadOnly = False
            GoTo Label
        End If

        dteDealing5.ReadOnly = False
Label:
        bttAddThietBi.Visible = True
        bttAddFile.Visible = True
        bttDeleteFile.Visible = True
    End Sub

    Sub EnabelQA()
        txtKQXacNhanQA.ReadOnly = False
        txtXuLySanPham.ReadOnly = False
        cboBaoCao.ReadOnly = False
        bttSaveQA.Visible = True
    End Sub

    Sub EnableKQXL()
        mmeDanhGiaNgoaiQuan.ReadOnly = False
        mmeDanhGiaChucNang.ReadOnly = False
        cbbDanhGiaTong.ReadOnly = False
        cbbXuLySauCung.ReadOnly = False
        mmeRemark.ReadOnly = False
        btnAddFileFinish.Visible = True
        btnDeleteFileFinish.Visible = True

        'Enable Dealine
        If dteDeadline.DateTime > DateTime.MinValue Then
            If dteDeadline.DateTime < DateTime.Now Then
                dteDeadline.ReadOnly = True
            Else
                dteDeadline.ReadOnly = False
                Return
            End If
        Else
            dteDeadline.ReadOnly = False
            Return
        End If

        If dteDealing2.DateTime > DateTime.MinValue Then
            If dteDealing2.DateTime < DateTime.Now Then
                dteDealing2.ReadOnly = True
            Else
                dteDealing2.ReadOnly = False
                Return
            End If
        Else
            dteDealing2.ReadOnly = False
            Return
        End If

        If dteDealing3.DateTime > DateTime.MinValue Then
            If dteDealing3.DateTime < DateTime.Now Then
                dteDealing3.ReadOnly = True
            Else
                dteDealing3.ReadOnly = False
                Return
            End If
        Else
            dteDealing3.ReadOnly = False
            Return
        End If

        If dteDealing4.DateTime > DateTime.MinValue Then
            If dteDealing4.DateTime < DateTime.Now Then
                dteDealing4.ReadOnly = True
            Else
                dteDealing4.ReadOnly = False
                Return
            End If
        Else
            dteDealing4.ReadOnly = False
            Return
        End If

        dteDealing5.ReadOnly = False
    End Sub

    Sub LoadHead()
        ResetControl()
        If _myID = "" Then
            bttSave.Visible = True
            bttSubmit.Visible = True
            txtSection.Text = CurrentUser.SortSection
            dtpRequestDate.DateTime = Date.Now
            EnabelSection()
            Return
        End If
        Dim obj As New QAE_Abnormal
        obj.ID_K = _myID
        _db.GetObject(obj)

        txtID.Text = _myID
        txtSection.Text = obj.Section
        dtpRequestDate.EditValue = obj.RequestDate

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

        'KQ
        txtMailPreKQ.Text = obj.PreKQ
        txtMailCheckKQ.Text = obj.CheckedKQ
        txtMailAppKQ.Text = obj.ApprovedKQ
        txtMailPicKQ.Text = obj.PicQAKQ
        txtMailCheckQAKQ.Text = obj.CheckedQAKQ
        txtMailAppQAKQ.Text = obj.ApprovedQAKQ

        txtCmtPreKQ.Text = obj.PreCommentKQ
        txtCmtCheckedKQ.Text = obj.CheckedCommentKQ
        txtCmtApprovedKQ.Text = obj.ApprovedCommentKQ
        txtCmtPICQAKQ.Text = obj.PicCommentQAKQ
        txtCmtCheckedQAKQ.Text = obj.CheckedCommentQAKQ
        txtCmtApprovedQAKQ.Text = obj.ApprovedCommentQAKQ

        'Load Data Section
        txtMaThietBi.Text = obj.MaThietBi
        txtTenThietBi.Text = obj.TenThietBiDoV
        dtpNgayPhatSinh.DateTime = obj.NgayPhatSinh
        dteDeadline.EditValue = obj.DealingDate
        If obj.DealingDate2 > DateTime.MinValue Then
            dteDealing2.EditValue = obj.DealingDate2
        End If
        If obj.DealingDate3 > DateTime.MinValue Then
            dteDealing3.EditValue = obj.DealingDate3
        End If
        If obj.DealingDate4 > DateTime.MinValue Then
            dteDealing4.EditValue = obj.DealingDate4
        End If
        If obj.DealingDate5 > DateTime.MinValue Then
            dteDealing5.EditValue = obj.DealingDate5
        End If
        txtNoiDungSuCo.Text = obj.NoiDung
        txtSanPhamDo.Text = obj.SanPhamDo
        txtMucDichDo.Text = obj.MucDichDo
        txtThuocTinhDo.Text = obj.ThuocTinhDo
        txtChuanSanPham.Text = obj.ChuanSanPham
        cboXacNhanSuAnhHuong.Text = obj.XacNhanKhongAnhHuong
        txtPhamViSPKhongPhuHop.Text = obj.PhamViSanPhamKhongPhuHop
        cboXuLyDungCu.Text = obj.XuLyDungCu
        txtXuLyKhac.Text = obj.XuLyDungCuKhac

        linkAttached.Text = obj.AttachedFile
        linkAttached.Tag = obj.AttachedFileServer

        'Load Data QA
        txtKQXacNhanQA.Text = obj.KQXacNhanQA
        txtXuLySanPham.Text = obj.XuLySanPham
        cboBaoCao.Text = obj.BaoCaoKhachHang

        'Load Data KQ
        mmeDanhGiaNgoaiQuan.Text = obj.DanhGiaNgoaiQuan
        mmeDanhGiaChucNang.Text = obj.DanhGiaChucNang
        cbbDanhGiaTong.Text = obj.DanhGiaTong
        cbbXuLySauCung.Text = obj.XuLySauCung
        mmeRemark.Text = obj.Remark

        linkAttachedFinish.Text = obj.AttachedFileFinish
        linkAttachedFinish.Tag = obj.AttachedFileFinishServer

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
                txtCmtPIC.ReadOnly = False

                EnabelSection()
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

        'Load Approved KQ
        If obj.PreDateKQ > DateTime.MinValue Then
            lblPreKQ.Text = obj.PreDateKQ.ToString("dd-MM-yyyy HH:mm")
            lblPreKQ.Visible = True
            btnSaveKQ.Visible = False
            btnSubmitKQ.Visible = False
        Else
            If obj.CurrentID = CurrentUser.Mail And obj.CurrentID = obj.PIC Then
                lblPreKQ.Visible = False
                btnSaveKQ.Visible = True
                btnSubmitKQ.Visible = True
                txtCmtPreKQ.ReadOnly = False

                EnableKQXL()
                GoTo GotoDetail
            End If
        End If

        If obj.CheckedDateKQ > DateTime.MinValue Then
            lblCheckedKQ.Visible = True
            lblCheckedKQ.Text = obj.CheckedDateKQ.ToString("dd-MM-yyyy HH:mm")
        Else
            If obj.CurrentID = CurrentUser.Mail And obj.CurrentID = obj.Checked Then
                lblCheckedKQ.Visible = False
                btnCheckedKQ.Visible = True
                btnRejectCheckedKQ.Visible = True
                txtCmtCheckedKQ.ReadOnly = False

                EnableKQXL()
                GoTo GotoDetail
            End If
        End If

        If obj.ApprovedDateKQ > DateTime.MinValue Then
            lblApprovedKQ.Visible = True
            lblApprovedKQ.Text = obj.ApprovedDateKQ.ToString("dd-MM-yyyy HH:mm")
        Else
            If obj.CurrentID = CurrentUser.Mail And obj.CurrentID = obj.Approved Then
                lblApprovedKQ.Visible = False
                btnApprovedKQ.Visible = True
                btnRejectApprovedKQ.Visible = True
                txtCmtApprovedKQ.ReadOnly = False

                EnableKQXL()
                GoTo GotoDetail
            End If
        End If

        If obj.PicDateQAKQ > DateTime.MinValue Then
            lblPicQAKQ.Visible = True
            lblPicQAKQ.Text = obj.PicDateQAKQ.ToString("dd-MM-yyyy HH:mm")
        Else
            If obj.CurrentID = CurrentUser.Mail And obj.CurrentID = obj.QAPIC Then
                lblPicQAKQ.Visible = False
                btnPICQAKQ.Visible = True
                btnRejectPicKQ.Visible = True
                txtCmtPICQAKQ.ReadOnly = False

                EnableKQXL()
                GoTo GotoDetail
            End If
        End If

        If obj.CheckedDateQAKQ > DateTime.MinValue Then
            lblCheckedQAKQ.Visible = True
            lblCheckedQAKQ.Text = obj.CheckedDateQAKQ.ToString("dd-MM-yyyy HH:mm")
        Else
            If obj.CurrentID = CurrentUser.Mail And obj.CurrentID = obj.QAChecked Then
                lblCheckedQAKQ.Visible = False
                btnCheckedQAKQ.Visible = True
                btnRejectCheckedQAKQ.Visible = True
                txtCmtCheckedQAKQ.ReadOnly = False

                EnableKQXL()
                GoTo GotoDetail
            End If
        End If

        If obj.ApprovedDateQAKQ > DateTime.MinValue Then
            lblApprovedQAKQ.Visible = True
            lblApprovedQAKQ.Text = obj.ApprovedDateQAKQ.ToString("dd-MM-yyyy HH:mm")
        Else
            If obj.CurrentID = CurrentUser.Mail And obj.CurrentID = obj.QAApproved Then
                lblApprovedQAKQ.Visible = False
                btnApprovedQAKQ.Visible = True
                btnRejectApprovedQAKQ.Visible = True
                txtCmtApprovedQAKQ.ReadOnly = False

                EnableKQXL()
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

    Private Sub bttDelete_Click(sender As Object, e As EventArgs) Handles bttDeleteFile.Click
        linkAttached.Text = ""
        linkAttached.Tag = ""
    End Sub

    Sub ConfirmUpdateOutlook(sumit As Submit, confirm As ConfirmOT, comment As String, cc As List(Of String), obj As QAE_Abnormal)
        Try
            _db.BeginTransaction()
            Dim lstTo As New List(Of String)
            Dim lstCC As New List(Of String)
            Dim lstBCC As New List(Of String)

            Dim arrCc() As String = Nothing
            Dim title = "(" & obj.Section & ")" & " BÁO CÁO DỤNG CỤ ĐO KHÔNG PHÙ HỢP " & obj.RequestDate.ToString("dd-MM-yyyy")
            If sumit = Submit.Reject Then
                If obj.PreDateKQ = Nothing Then
                    obj.PICDate = Nothing
                    obj.CheckedDate = Nothing
                    obj.ApprovedDate = Nothing
                    obj.QAPICDate = Nothing
                    obj.QACheckedDate = Nothing
                    obj.QAApprovedDate = Nothing
                End If
                'KQ
                obj.PreDateKQ = Nothing
                obj.CheckedDateKQ = Nothing
                obj.ApprovedDateKQ = Nothing
                obj.PicDateQAKQ = Nothing
                obj.CheckedDateQAKQ = Nothing
                obj.ApprovedDateQAKQ = Nothing
                obj.CurrentID = obj.PIC

                lstTo.Add(obj.PIC)
                SendMailOutlook(title, Nothing, sumit, lstTo, Nothing, Nothing, Nothing, Tag, obj.ID_K)

            Else
                Select Case confirm
                    Case clsApplication.ConfirmQAE.PIC
                        lstTo.Add(obj.Checked)
                        SendMailOutlook(title, Nothing, sumit, lstTo, Nothing, Nothing, Nothing, Tag, obj.ID_K)
                        obj.CurrentID = obj.Checked
                        GoTo EndConfirm
                    Case clsApplication.ConfirmQAE.Check
                        If obj.Approved <> "" Then
                            lstTo.Add(obj.Approved)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.Approved
                            GoTo EndConfirm
                        End If
                    Case clsApplication.ConfirmQAE.Approved
                        If obj.QAPIC <> "" Then
                            lstTo.Add(obj.QAPIC)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.QAPIC
                            GoTo EndConfirm
                        End If
                    Case clsApplication.ConfirmQAE.QAPIC
                        If obj.QAChecked <> "" Then
                            lstTo.Add(obj.QAChecked)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.QAChecked
                            GoTo EndConfirm
                        End If
                    Case clsApplication.ConfirmQAE.QAChecked
                        If obj.QAApproved <> "" Then
                            lstTo.Add(obj.QAApproved)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.QAApproved
                            GoTo EndConfirm
                        End If
                    Case clsApplication.ConfirmQAE.QAApproved
                        If obj.PreKQ <> "" Then
                            lstTo.Add(obj.PreKQ)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.PreKQ
                            GoTo EndConfirm
                        End If
                    Case clsApplication.ConfirmQAE.PreKQ
                        If obj.CheckedKQ <> "" Then
                            lstTo.Add(obj.CheckedKQ)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.CheckedKQ
                            GoTo EndConfirm
                        End If
                    Case clsApplication.ConfirmQAE.CheckedKQ
                        If obj.ApprovedKQ <> "" Then
                            lstTo.Add(obj.ApprovedKQ)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.ApprovedKQ
                            GoTo EndConfirm
                        End If
                    Case clsApplication.ConfirmQAE.ApprovedKQ
                        If obj.PicQAKQ <> "" Then
                            lstTo.Add(obj.PicQAKQ)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.PicQAKQ
                            GoTo EndConfirm
                        End If
                    Case clsApplication.ConfirmQAE.PicQAKQ
                        If obj.CheckedQAKQ <> "" Then
                            lstTo.Add(obj.CheckedQAKQ)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.CheckedQAKQ
                            GoTo EndConfirm
                        End If
                    Case clsApplication.ConfirmQAE.CheckedQAKQ
                        If obj.ApprovedQAKQ <> "" Then
                            lstTo.Add(obj.ApprovedQAKQ)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.ApprovedQAKQ
                            GoTo EndConfirm
                        End If
                    Case clsApplication.ConfirmQAE.ApprovedQAKQ
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
                                                    PublicTable.Table_QAE_Abnormal,
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

        If dtpNgayPhatSinh.DateTime = Date.MinValue Then
            ShowWarning("Bạn chưa nhập ngày phát sinh !")
            Return False
        End If
        If txtNoiDungSuCo.Text = "" Then
            ShowWarning("Bạn chưa nhập nội dung sự cố !")
            Return False
        End If
        If txtSanPhamDo.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập sản phẩm đo !")
            Return False
        End If
        If txtMucDichDo.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập mục đích đo !")
            Return False
        End If
        If txtThuocTinhDo.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập thuộc tính đo !")
            Return False
        End If
        If txtChuanSanPham.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập chuẩn sản phẩm !")
            Return False
        End If
        If cboXacNhanSuAnhHuong.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập xác nhận sự ảnh hưởng !")
            Return False
        End If
        If txtPhamViSPKhongPhuHop.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập phạm vi sản phẩm không phù hợp !")
            Return False
        End If
        If cboXuLyDungCu.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập xử lý dụng cụ !")
            Return False
        End If
        If dteDeadline.DateTime = Date.MinValue Then
            ShowWarning("Bạn chưa nhập ngày hoàn thành deadline !")
            Return False
        End If
        If dteDeadline.DateTime > DateTime.MinValue And dteDeadline.DateTime < DateTime.Now Then
            If dteDealing2.DateTime = Date.MinValue Then
                ShowWarning("Bạn chưa nhập ngày hoàn thành deadline lần 2 !")
                Return False
            End If
        End If
        If dteDealing2.DateTime > DateTime.MinValue And dteDealing2.DateTime < DateTime.Now Then
            If dteDealing3.DateTime = Date.MinValue Then
                ShowWarning("Bạn chưa nhập ngày hoàn thành deadline lần 3 !")
                Return False
            End If
        End If
        If dteDealing3.DateTime > DateTime.MinValue And dteDealing3.DateTime < DateTime.Now Then
            If dteDealing4.DateTime = Date.MinValue Then
                ShowWarning("Bạn chưa nhập ngày hoàn thành deadline lần 4 !")
                Return False
            End If
        End If
        If dteDealing4.DateTime > DateTime.MinValue And dteDealing4.DateTime < DateTime.Now Then
            If dteDealing5.DateTime = Date.MinValue Then
                ShowWarning("Bạn chưa nhập ngày hoàn thành deadline lần 5 !")
                Return False
            End If
        End If
        If txtMaThietBi.Text.Trim = "" Then
            ShowWarning("Bạn chưa thêm thiết bị !")
            Return False
        End If
        Return True
    End Function

    Private Sub bttSave_Click(sender As Object, e As EventArgs) Handles bttSave.Click
        If CheckedConditionSection() Then
            SaveData(True, False, False)
            LoadHead()
            ShowSuccess()
        End If

    End Sub

    Function GetID() As String
        Dim myID As String = ""
        Dim myDate As String = "A" & Date.Today.ToString("yyMMdd") & "-"
        Dim STT As Object = _db.ExecuteScalar(String.Format(" select isnull(max(right(ID,2)),0)+1 as STT " +
                                                            " from QAE_Abnormal " +
                                                            " where ID like '{0}%'", myDate))
        If IsNumeric(STT) Then
            myID = myDate & STT.ToString().PadLeft(2, "0")
        Else
            myID = myDate & "01"
        End If
        Return myID
    End Function

    Function SaveData(isSection As Boolean, isQA As Boolean, isKQ As Boolean) As Boolean

        Dim obj As New QAE_Abnormal
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
        obj.RequestDate = dtpRequestDate.DateTime.Date

        obj.PIC = txtMailPIC.Text
        obj.Checked = cboChecked.Text
        obj.Approved = cboApproved.Text
        obj.QAPIC = txtMailPICQA.Text
        obj.QAChecked = txtMailCheckedQA.Text
        obj.QAApproved = txtMailApprovedQA.Text

        obj.PreKQ = txtMailPIC.Text
        obj.CheckedKQ = cboChecked.Text
        obj.ApprovedKQ = cboApproved.Text
        obj.PicQAKQ = txtMailPICQA.Text
        obj.CheckedQAKQ = txtMailCheckedQA.Text
        obj.ApprovedQAKQ = txtMailApprovedQA.Text

        'save Data Section
        If isSection Then
            obj.MaThietBi = txtMaThietBi.Text
            obj.TenThietBiDoV = txtTenThietBi.Text
            obj.NgayPhatSinh = dtpNgayPhatSinh.DateTime.Date
            obj.DealingDate = dteDeadline.DateTime
            obj.DealingDate2 = dteDealing2.DateTime
            obj.DealingDate3 = dteDealing3.DateTime
            obj.DealingDate4 = dteDealing4.DateTime
            obj.DealingDate5 = dteDealing5.DateTime
            obj.NoiDung = txtNoiDungSuCo.Text
            obj.SanPhamDo = txtSanPhamDo.Text
            obj.MucDichDo = txtMucDichDo.Text
            obj.ThuocTinhDo = txtThuocTinhDo.Text
            obj.ChuanSanPham = txtChuanSanPham.Text
            obj.XacNhanKhongAnhHuong = cboXacNhanSuAnhHuong.Text
            obj.PhamViSanPhamKhongPhuHop = txtPhamViSPKhongPhuHop.Text
            obj.XuLyDungCu = cboXuLyDungCu.Text
            obj.XuLyDungCuKhac = txtXuLyKhac.Text

            If linkAttached.Tag = "" Then
                obj.AttachedFile = ""
                obj.AttachedFileServer = ""
            Else
                If Not linkAttached.Tag.ToString.Contains(myPath) Then
                    obj.AttachedFile = linkAttached.Text
                    obj.AttachedFileServer = myPath & obj.ID_K & "_Section_" & linkAttached.Text
                    File.Copy(linkAttached.Tag, obj.AttachedFileServer, True)
                End If
            End If
        End If
        'save Data QA
        If isQA Then
            obj.KQXacNhanQA = txtKQXacNhanQA.Text
            obj.XuLySanPham = txtXuLySanPham.Text
            obj.BaoCaoKhachHang = cboBaoCao.Text
        End If
        'Save Data KQ
        If isKQ Then
            obj.DanhGiaNgoaiQuan = mmeDanhGiaNgoaiQuan.Text
            obj.DanhGiaChucNang = mmeDanhGiaChucNang.Text
            obj.DanhGiaTong = cbbDanhGiaTong.Text
            obj.XuLySauCung = cbbXuLySauCung.Text
            obj.Remark = mmeRemark.Text

            If linkAttachedFinish.Tag = "" Then
                obj.AttachedFileFinish = ""
                obj.AttachedFileFinishServer = ""
            Else
                If Not linkAttachedFinish.Tag.ToString.Contains(myPath) Then
                    obj.AttachedFileFinish = linkAttachedFinish.Text
                    obj.AttachedFileFinishServer = myPath & obj.ID_K & "_Finish_" & linkAttachedFinish.Text
                    File.Copy(linkAttachedFinish.Tag, obj.AttachedFileFinishServer, True)
                End If
            End If
        End If

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
            SaveData(True, False, False)
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.PICComment = txtCmtPIC.Text
            obj.PICDate = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, clsApplication.ConfirmQAE.PIC, obj.PICComment, Nothing, obj)
        End If
    End Sub

    Private Sub bttChecked_Click(sender As Object, e As EventArgs) Handles bttChecked.Click
        If CheckedConditionSection() Then
            SaveData(True, False, False)
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.CheckedComment = txtCmtChecked.Text
            obj.CheckedDate = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, clsApplication.ConfirmQAE.Check, obj.CheckedComment, Nothing, obj)
        End If
    End Sub

    Private Sub bttApproved_Click(sender As Object, e As EventArgs) Handles bttApproved.Click
        If CheckedConditionSection() Then
            SaveData(True, False, False)
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.ApprovedComment = txtCmtApproved.Text
            obj.ApprovedDate = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, clsApplication.ConfirmQAE.Approved, obj.ApprovedComment, Nothing, obj)
        End If
    End Sub

    Private Sub bttPICQA_Click(sender As Object, e As EventArgs) Handles bttPICQA.Click
        If CheckedConditionQA() Then
            SaveData(False, True, False)
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.QAPICComment = txtCmtPICQA.Text
            obj.QAPICDate = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, clsApplication.ConfirmQAE.QAPIC, obj.QAPICComment, Nothing, obj)
        End If
    End Sub

    Private Sub bttCheckedQA_Click(sender As Object, e As EventArgs) Handles bttCheckedQA.Click
        If CheckedConditionQA() Then
            SaveData(False, True, False)
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.QACheckedComment = txtCmtCheckedQA.Text
            obj.QACheckedDate = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, clsApplication.ConfirmQAE.QAChecked, obj.QACheckedComment, Nothing, obj)
        End If
    End Sub

    Private Sub bttApprovedQA_Click(sender As Object, e As EventArgs) Handles bttApprovedQA.Click
        If CheckedConditionQA() Then
            SaveData(False, True, False)
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.QAApprovedComment = txtCmtApprovedQA.Text
            obj.QAApprovedDate = DateTime.Now
            obj.CurrentID = ""

            'Load Status, Ngày phát sinh và Deadline vào form QAE_EquipList
            Dim objEquipList As New QAE_EquidList
            objEquipList.EquipCode_K = txtMaThietBi.Text
            _db.GetObject(objEquipList)
            objEquipList.AbnorOccDate = dtpNgayPhatSinh.DateTime
            If dteDeadline.DateTime > DateTime.MinValue Then
                objEquipList.DealingDate = dteDeadline.DateTime
            End If
            If dteDealing2.DateTime > DateTime.MinValue Then
                objEquipList.DealingDate = dteDealing2.DateTime
            End If
            If dteDealing3.DateTime > DateTime.MinValue Then
                objEquipList.DealingDate = dteDealing3.DateTime
            End If
            If dteDealing4.DateTime > DateTime.MinValue Then
                objEquipList.DealingDate = dteDealing4.DateTime
            End If
            If dteDealing5.DateTime > DateTime.MinValue Then
                objEquipList.DealingDate = dteDealing5.DateTime
            End If
            objEquipList.Status = "Sự cố"
            _db.Update(objEquipList)

            ConfirmUpdateOutlook(Submit.Confirm, clsApplication.ConfirmQAE.QAApproved, obj.QAApprovedComment, Nothing, obj)
        End If
    End Sub

    Private Sub bttRejectChecked_Click(sender As Object, e As EventArgs) Handles bttRejectChecked.Click
        If txtCmtChecked.Text.Trim() <> "" Then
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.CheckedComment = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtChecked.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, clsApplication.ConfirmQAE.Check, obj.CheckedComment, Nothing, obj)
        Else
            ShowWarning("Bạn phải ghi chú lý do từ chối yêu cầu." + vbCrLf + "Please comment detail.")
            txtCmtChecked.Focus()
        End If
    End Sub

    Private Sub bttRejectApproved_Click(sender As Object, e As EventArgs) Handles bttRejectApproved.Click
        If txtCmtApproved.Text.Trim() <> "" Then
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.ApprovedComment = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtApproved.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, clsApplication.ConfirmQAE.Approved, obj.ApprovedComment, Nothing, obj)
        Else
            ShowWarning("Bạn phải ghi chú lý do từ chối yêu cầu." + vbCrLf + "Please comment detail.")
            txtCmtApproved.Focus()
        End If
    End Sub

    Private Sub bttRejectPICQA_Click(sender As Object, e As EventArgs) Handles bttRejectPICQA.Click
        If txtCmtPICQA.Text.Trim() <> "" Then
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.QAPICComment = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtPICQA.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, clsApplication.ConfirmQAE.QAPIC, obj.QAPICComment, Nothing, obj)
        Else
            ShowWarning("Bạn phải ghi chú lý do từ chối yêu cầu." + vbCrLf + "Please comment detail.")
            txtCmtPICQA.Focus()
        End If
    End Sub

    Private Sub bttRejectCheckedQA_Click(sender As Object, e As EventArgs) Handles bttRejectCheckedQA.Click
        If txtCmtCheckedQA.Text.Trim() <> "" Then
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.QACheckedComment = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtCheckedQA.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, clsApplication.ConfirmQAE.QAChecked, obj.QACheckedComment, Nothing, obj)
        Else
            ShowWarning("Bạn phải ghi chú lý do từ chối yêu cầu." + vbCrLf + "Please comment detail.")
            txtCmtCheckedQA.Focus()
        End If
    End Sub

    Private Sub bttRejectApprovedQA_Click(sender As Object, e As EventArgs) Handles bttRejectApprovedQA.Click
        If txtCmtApprovedQA.Text.Trim() <> "" Then
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.QAApprovedComment = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtApprovedQA.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, clsApplication.ConfirmQAE.QAApproved, obj.QAApprovedComment, Nothing, obj)
        Else
            ShowWarning("Bạn phải ghi chú lý do từ chối yêu cầu." + vbCrLf + "Please comment detail.")
            txtCmtApprovedQA.Focus()
        End If
    End Sub

    Private Sub bttSaveQA_Click(sender As Object, e As EventArgs) Handles bttSaveQA.Click
        If CheckedConditionQA() Then
            SaveData(False, True, False)
            ShowSuccess()
        End If
    End Sub

    Function CheckedConditionQA() As Boolean
        If txtKQXacNhanQA.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập kết quả xác nhận QA !")
            Return False
        End If
        If txtXuLySanPham.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập xử lý sản phẩm !")
            Return False
        End If
        If cboBaoCao.Text.Trim = "" Then
            ShowWarning("Bạn chưa nhập có báo cáo hay không !")
            Return False
        End If
        Return True
    End Function

    Private Sub linkAttached_Click(sender As Object, e As EventArgs) Handles linkAttached.Click
        If File.Exists(linkAttached.Tag) Then
            If txtNoiDungSuCo.ReadOnly = False Then
                Process.Start(linkAttached.Tag) 'Sửa trực tiếp trên file server
            Else
                Process.Start(OpenfileTemp(linkAttached.Tag)) 'Lưu file về PC riêng, việc chỉnh sửa file này không liên quan gì đến file trên server
            End If
        End If
    End Sub


    Private Sub bttAddThietBi_Click(sender As Object, e As EventArgs) Handles bttAddThietBi.Click
        Dim frm As New FrmEquipList
        frm._isOption = True
        frm.ShowDialog()
        If frm._isID <> "" Then
            txtMaThietBi.Text = frm._isID
            Dim obj As New QAE_EquidList
            obj.EquipCode_K = frm._isID
            _db.GetObject(obj)
            txtTenThietBi.Text = obj.EquipNameV
        End If
    End Sub

    Private Sub btnAddFileFinish_Click(sender As Object, e As EventArgs) Handles btnAddFileFinish.Click
        Dim frm As New OpenFileDialog
        frm.ShowDialog()
        If frm.FileName <> "" Then
            linkAttachedFinish.Text = frm.SafeFileName
            linkAttachedFinish.Tag = frm.FileName
        End If
        frm.Dispose()
    End Sub

    Private Sub btnDeleteFileFinish_Click(sender As Object, e As EventArgs) Handles btnDeleteFileFinish.Click
        linkAttachedFinish.Text = ""
        linkAttachedFinish.Tag = ""
    End Sub

    Private Sub linkAttachedFinish_Click(sender As Object, e As EventArgs) Handles linkAttachedFinish.Click
        If File.Exists(linkAttachedFinish.Tag) Then
            Process.Start(OpenfileTemp(linkAttachedFinish.Tag))
        End If
    End Sub

    Function CheckedConditionKQ() As Boolean
        If txtMailPreKQ.Text = "" Or
                txtMailCheckKQ.Text = "" Or
                txtMailAppKQ.Text = "" Or
            txtMailPicKQ.Text = "" Or
            txtMailCheckQAKQ.Text = "" Or
            txtMailAppQAKQ.Text = "" Then
            ShowWarning("Địa chỉ mail phần Kết quả xử lý không được để trống !")
            Return False
        End If
        If mmeDanhGiaNgoaiQuan.Text.Trim = "" Then
            ShowWarning("Bạn chưa thêm đánh giá ngoại quan !")
            Return False
        End If
        If mmeDanhGiaChucNang.Text.Trim = "" Then
            ShowWarning("Bạn chưa thêm đánh giá chức năng !")
            Return False
        End If
        If cbbDanhGiaTong.Text.Trim = "" Then
            ShowWarning("Bạn chưa thêm đánh giá tổng !")
            Return False
        End If
        If cbbXuLySauCung.Text.Trim = "" Then
            ShowWarning("Bạn chưa thêm xử lý sau cùng !")
            Return False
        End If
        Return True
    End Function
    Private Sub btnSubmitKQ_Click(sender As Object, e As EventArgs) Handles btnSubmitKQ.Click
        If CheckedConditionKQ() Then
            SaveData(False, False, True)
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.PreCommentKQ = txtCmtPreKQ.Text
            obj.PreDateKQ = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, clsApplication.ConfirmQAE.PreKQ, obj.PreCommentKQ, Nothing, obj)
        End If
    End Sub
    Private Sub btnSaveKQ_Click(sender As Object, e As EventArgs) Handles btnSaveKQ.Click
        If CheckedConditionKQ() Then
            SaveData(False, False, True)
            LoadHead()
            ShowSuccess()
        End If
    End Sub

    Private Sub btnCheckedKQ_Click(sender As Object, e As EventArgs) Handles btnCheckedKQ.Click
        If CheckedConditionKQ() Then
            SaveData(False, False, True)
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.CheckedCommentKQ = txtCmtCheckedKQ.Text
            obj.CheckedDateKQ = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, clsApplication.ConfirmQAE.CheckedKQ, obj.CheckedCommentKQ, Nothing, obj)
        End If
    End Sub

    Private Sub btnRejectCheckedKQ_Click(sender As Object, e As EventArgs) Handles btnRejectCheckedKQ.Click
        If txtCmtCheckedKQ.Text.Trim() <> "" Then
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.CheckedCommentKQ = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtCheckedKQ.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, clsApplication.ConfirmQAE.CheckedKQ, obj.CheckedCommentKQ, Nothing, obj)
        Else
            ShowWarning("Bạn phải ghi chú lý do từ chối kết quả." + vbCrLf + "Please comment detail.")
            txtCmtCheckedKQ.Focus()
        End If
    End Sub

    Private Sub btnApprovedKQ_Click(sender As Object, e As EventArgs) Handles btnApprovedKQ.Click
        If CheckedConditionKQ() Then
            SaveData(False, False, True)
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.ApprovedCommentKQ = txtCmtApprovedKQ.Text
            obj.ApprovedDateKQ = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, clsApplication.ConfirmQAE.ApprovedKQ, obj.ApprovedCommentKQ, Nothing, obj)
        End If
    End Sub

    Private Sub btnRejectApprovedKQ_Click(sender As Object, e As EventArgs) Handles btnRejectApprovedKQ.Click
        If txtCmtApprovedKQ.Text.Trim() <> "" Then
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.ApprovedCommentKQ = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtApprovedKQ.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, clsApplication.ConfirmQAE.ApprovedKQ, obj.ApprovedCommentKQ, Nothing, obj)
        Else
            ShowWarning("Bạn phải ghi chú lý do từ chối kết quả." + vbCrLf + "Please comment detail.")
            txtCmtApprovedKQ.Focus()
        End If
    End Sub

    Private Sub btnPICQAKQ_Click(sender As Object, e As EventArgs) Handles btnPICQAKQ.Click
        If CheckedConditionKQ() Then
            SaveData(False, False, True)
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.PicCommentQAKQ = txtCmtPICQAKQ.Text
            obj.PicDateQAKQ = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, clsApplication.ConfirmQAE.PicQAKQ, obj.PicCommentQAKQ, Nothing, obj)
        End If
    End Sub

    Private Sub btnRejectPicKQ_Click(sender As Object, e As EventArgs) Handles btnRejectPicKQ.Click
        If txtCmtPICQAKQ.Text.Trim() <> "" Then
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.PicCommentQAKQ = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtPICQAKQ.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, clsApplication.ConfirmQAE.PicQAKQ, obj.PicCommentQAKQ, Nothing, obj)
        Else
            ShowWarning("Bạn phải ghi chú lý do từ chối kết quả." + vbCrLf + "Please comment detail.")
            txtCmtPICQAKQ.Focus()
        End If
    End Sub

    Private Sub btnCheckedQAKQ_Click(sender As Object, e As EventArgs) Handles btnCheckedQAKQ.Click
        If CheckedConditionKQ() Then
            SaveData(False, False, True)
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.CheckedCommentQAKQ = txtCmtCheckedQAKQ.Text
            obj.CheckedDateQAKQ = DateTime.Now
            obj.CurrentID = ""

            ConfirmUpdateOutlook(Submit.Confirm, clsApplication.ConfirmQAE.CheckedQAKQ, obj.CheckedCommentQAKQ, Nothing, obj)
        End If
    End Sub

    Private Sub btnRejectCheckedQAKQ_Click(sender As Object, e As EventArgs) Handles btnRejectCheckedQAKQ.Click
        If txtCmtCheckedQAKQ.Text.Trim() <> "" Then
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.CheckedCommentQAKQ = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtCheckedQAKQ.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, clsApplication.ConfirmQAE.CheckedQAKQ, obj.CheckedCommentQAKQ, Nothing, obj)
        Else
            ShowWarning("Bạn phải ghi chú lý do từ chối kết quả." + vbCrLf + "Please comment detail.")
            txtCmtCheckedQAKQ.Focus()
        End If
    End Sub

    Private Sub btnApprovedQAKQ_Click(sender As Object, e As EventArgs) Handles btnApprovedQAKQ.Click
        If CheckedConditionKQ() Then
            SaveData(False, False, True)
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.ApprovedCommentQAKQ = txtCmtApprovedQAKQ.Text
            obj.ApprovedDateQAKQ = DateTime.Now
            obj.CurrentID = ""

            'Load Status vào form QAE_EquipList
            Dim objEquipList As New QAE_EquidList
            objEquipList.EquipCode_K = txtMaThietBi.Text
            _db.GetObject(objEquipList)
            If cbbXuLySauCung.Text = "Tiếp tục sử dụng" Then
                objEquipList.AbnorOccDate = Nothing
                objEquipList.DealingDate = Nothing
                objEquipList.Status = "Đang sử dụng"
            ElseIf cbbXuLySauCung.Text = "Lưu kho" Then
                objEquipList.AbnorOccDate = dtpNgayPhatSinh.DateTime
                'objEquipList.DealingDate = dteDeadline.DateTime
                If dteDeadline.DateTime > DateTime.MinValue Then
                    objEquipList.DealingDate = dteDeadline.DateTime
                End If
                If dteDealing2.DateTime > DateTime.MinValue Then
                    objEquipList.DealingDate = dteDealing2.DateTime
                End If
                If dteDealing3.DateTime > DateTime.MinValue Then
                    objEquipList.DealingDate = dteDealing3.DateTime
                End If
                If dteDealing4.DateTime > DateTime.MinValue Then
                    objEquipList.DealingDate = dteDealing4.DateTime
                End If
                If dteDealing5.DateTime > DateTime.MinValue Then
                    objEquipList.DealingDate = dteDealing5.DateTime
                End If
                objEquipList.Status = "Lưu kho"
            Else
                objEquipList.AbnorOccDate = dtpNgayPhatSinh.DateTime
                'objEquipList.DealingDate = dteDeadline.DateTime
                If dteDeadline.DateTime > DateTime.MinValue Then
                    objEquipList.DealingDate = dteDeadline.DateTime
                End If
                If dteDealing2.DateTime > DateTime.MinValue Then
                    objEquipList.DealingDate = dteDealing2.DateTime
                End If
                If dteDealing3.DateTime > DateTime.MinValue Then
                    objEquipList.DealingDate = dteDealing3.DateTime
                End If
                If dteDealing4.DateTime > DateTime.MinValue Then
                    objEquipList.DealingDate = dteDealing4.DateTime
                End If
                If dteDealing5.DateTime > DateTime.MinValue Then
                    objEquipList.DealingDate = dteDealing5.DateTime
                End If
                objEquipList.Status = "Hủy bỏ"
            End If
            _db.Update(objEquipList)

            ConfirmUpdateOutlook(Submit.Confirm, clsApplication.ConfirmQAE.ApprovedQAKQ, obj.ApprovedCommentQAKQ, Nothing, obj)
        End If
    End Sub

    Private Sub btnRejectApprovedQAKQ_Click(sender As Object, e As EventArgs) Handles btnRejectApprovedQAKQ.Click
        If txtCmtApprovedQAKQ.Text.Trim() <> "" Then
            Dim obj As New QAE_Abnormal
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.ApprovedCommentQAKQ = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtApprovedQAKQ.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, clsApplication.ConfirmQAE.ApprovedQAKQ, obj.ApprovedCommentQAKQ, Nothing, obj)
        Else
            ShowWarning("Bạn phải ghi chú lý do từ chối yêu cầu." + vbCrLf + "Please comment detail.")
            txtCmtApprovedQAKQ.Focus()
        End If
    End Sub

    Private Sub dteDeadline_EditValueChanged(sender As Object, e As EventArgs) Handles dteDeadline.EditValueChanged
        If dteDeadline.DateTime > DateTime.MinValue Then
            If dteDeadline.DateTime < GetStartDate(DateTime.Now) Then
                If txtID.Text = "" Then
                    ShowWarning("Kì hạn Deadline không hợp lệ !")
                    dteDeadline.EditValue = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub dteDealing2_EditValueChanged(sender As Object, e As EventArgs) Handles dteDealing2.EditValueChanged
        If dteDealing2.DateTime > DateTime.MinValue Then
            If GetEndDate(dteDealing2.DateTime) < GetStartDate(dteDeadline.DateTime) Then
                ShowWarning("Deadline lần 2 phải lớn hơn Deadline lần 1 !")
                dteDealing2.EditValue = Nothing
            End If
        End If
    End Sub

    Private Sub dteDealing3_EditValueChanged(sender As Object, e As EventArgs) Handles dteDealing3.EditValueChanged
        If dteDealing3.DateTime > DateTime.MinValue Then
            If GetEndDate(dteDealing3.DateTime) < GetStartDate(dteDealing2.DateTime) Then
                ShowWarning("Deadline lần 3 phải lớn hơn Deadline lần 2 !")
                dteDealing3.EditValue = Nothing
            End If
        End If
    End Sub

    Private Sub dteDealing4_EditValueChanged(sender As Object, e As EventArgs) Handles dteDealing4.EditValueChanged
        If dteDealing4.DateTime > DateTime.MinValue Then
            If GetEndDate(dteDealing4.DateTime) < GetStartDate(dteDealing3.DateTime) Then
                ShowWarning("Deadline lần 4 phải lớn hơn Deadline lần 3 !")
                dteDealing4.EditValue = Nothing
            End If
        End If
    End Sub

    Private Sub dteDealing5_EditValueChanged(sender As Object, e As EventArgs) Handles dteDealing5.EditValueChanged
        If dteDealing5.DateTime > DateTime.MinValue Then
            If GetEndDate(dteDealing5.DateTime) < GetStartDate(dteDealing4.DateTime) Then
                ShowWarning("Deadline lần 5 phải lớn hơn Deadline lần 4 !")
                dteDealing5.EditValue = Nothing
            End If
        End If
    End Sub

    Private Sub txtMailPIC_TextChanged(sender As Object, e As EventArgs) Handles txtMailPIC.TextChanged
        txtMailPreKQ.Text = txtMailPIC.Text
    End Sub

    Private Sub cboChecked_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboChecked.SelectedIndexChanged
        txtMailCheckKQ.Text = cboChecked.Text
    End Sub

    Private Sub cboApproved_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboApproved.SelectedIndexChanged
        txtMailAppKQ.Text = cboApproved.Text
    End Sub

    Private Sub txtMailPICQA_TextChanged(sender As Object, e As EventArgs) Handles txtMailPICQA.TextChanged
        txtMailPicKQ.Text = txtMailPICQA.Text
    End Sub

    Private Sub txtMailCheckedQA_TextChanged(sender As Object, e As EventArgs) Handles txtMailCheckedQA.TextChanged
        txtMailCheckQAKQ.Text = txtMailCheckedQA.Text
    End Sub

    Private Sub txtMailApprovedQA_TextChanged(sender As Object, e As EventArgs) Handles txtMailApprovedQA.TextChanged
        txtMailAppQAKQ.Text = txtMailApprovedQA.Text
    End Sub
End Class