Imports System.Windows.Forms
Imports CommonDB
Imports LibEntity
Imports PublicUtility

Public Class FrmApprovedNotJCodeDetail

    Dim _db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Public YMD_K As String = ""
    Public DeptName_K As String = ""
    Public Lan_K As Integer
    Public _myID As String = ""

    Private Sub bttExport_Click(sender As Object, e As EventArgs) Handles bttExport.Click
        GridControlExportExcel(GridView1)
    End Sub

    Private Sub FrmApprovedNotJCodeDetail_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If _myID = "" Then
            _myID = Me.AccessibleName
        End If
        If _myID = "" Then
            Return
        End If
        LoadApproved()
    End Sub

    Sub LoadControl()
        bttSubmit.Visible = False
        bttChecked.Visible = False
        bttRejectMG.Visible = False
        bttApproved.Visible = False
        bttRejectDP.Visible = False

        lblDateSubmit.Visible = False
        lblDateChecked.Visible = False
        lblDateApproved.Visible = False

        txtCmtSubmit.ReadOnly = True
        txtCmtChecked.ReadOnly = True
        txtCmtApproved.ReadOnly = True
    End Sub

    Sub LoadApproved()
        LoadControl()

        Dim obj As New PCM_ApprovedNoJCode
        obj.ID_K = _myID
        _db.GetObject(obj)

        DeptName_K = obj.DeptName
        Lan_K = obj.Lan
        YMD_K = obj.YMD

        txtID.Text = obj.YMD
        txtSection.Text = obj.DeptName
        txtTimes.Text = obj.Lan

        txtMailSubmit.Text = obj.SubmitUser
        txtMailCheck.Text = obj.MG
        txtMailApproved.Text = obj.DP

        txtCmtSubmit.Text = obj.SubmitCmt
        txtCmtChecked.Text = obj.MGCmt
        txtCmtApproved.Text = obj.DPCmt

        If obj.SubmitDate > Date.MinValue Then
            lblDateSubmit.Text = obj.SubmitDate.ToString("dd-MM-yyyy HH:mm")
            lblDateSubmit.Visible = True
        Else
            If obj.CurrentID.Contains(CurrentUser.Mail) And obj.SubmitUser.Contains(obj.CurrentID) Then
                bttSubmit.Visible = True
                txtCmtSubmit.ReadOnly = False

                txtMailApproved.ReadOnly = False
                txtMailCheck.ReadOnly = False
            End If
        End If

        If obj.MGDate > Date.MinValue Then
            lblDateChecked.Text = obj.MGDate.ToString("dd-MM-yyyy HH:mm")
            lblDateChecked.Visible = True
        Else
            If CurrentUser.Mail = obj.CurrentID And obj.MG = obj.CurrentID Then
                bttChecked.Visible = True
                bttRejectMG.Visible = True
                txtCmtChecked.ReadOnly = False
            End If
        End If

        If obj.DPDate > Date.MinValue Then
            lblDateApproved.Text = obj.DPDate.ToString("dd-MM-yyyy HH:mm")
            lblDateApproved.Visible = True
        Else
            If CurrentUser.Mail = obj.CurrentID And obj.DP = obj.CurrentID Then
                bttApproved.Visible = True
                bttRejectDP.Visible = True
                txtCmtApproved.ReadOnly = False
            End If
        End If

        LoadData()
    End Sub

    Sub LoadData()
        Dim sql As String = String.Format("sp_PCM_LoadApprovedNotJCodeDetail")
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@YMD", YMD_K)
        para(1) = New SqlClient.SqlParameter("@DeptName", DeptName_K)
        para(2) = New SqlClient.SqlParameter("@Lan", Lan_K)

        GridView1.Columns.Clear()
        GridControl1.DataSource = _db.ExecuteStoreProcedureTB(sql, para)
        GridControlSetFormat(GridView1, 3)
        GridView1.Columns("ECode").Width = 50
        GridView1.Columns("JVName").Width = 150
        GridView1.Columns("JCode").BestFit()
        GridView1.Columns("Unit").BestFit()
        GridView1.Columns("YMD").BestFit()

    End Sub

    Private Sub bttSubmit_Click(sender As Object, e As EventArgs) Handles bttSubmit.Click
        If txtMailCheck.Text.Trim = "" Or txtMailApproved.Text.Trim = "" Then
            ShowWarning("Mail không được để trống !")
            Return
        End If

        Dim obj As New PCM_ApprovedNoJCode
        obj.ID_K = _myID
        _db.GetObject(obj)
        obj.SubmitCmt = txtCmtSubmit.Text
        obj.SubmitDate = DateTime.Now
        obj.CurrentID = ""
        obj.MG = txtMailCheck.Text
        obj.DP = txtMailApproved.Text

        Dim objM As New OT_SectionMail
        objM.Section_K = "Logistics"
        _db.GetObject(objM)

        Dim lstCC As New List(Of String)
        lstCC.Add(objM.Manager)

        ConfirmUpdateOutlook(Submit.Confirm, ConfirmAJCode.LO, obj.SubmitCmt, lstCC, obj)

    End Sub

    Private Sub bttChecked_Click(sender As Object, e As EventArgs) Handles bttChecked.Click

        Dim obj As New PCM_ApprovedNoJCode
        obj.ID_K = _myID
        _db.GetObject(obj)
        obj.MGCmt = txtCmtChecked.Text
        obj.MGDate = DateTime.Now
        obj.CurrentID = ""

        ConfirmUpdateOutlook(Submit.Confirm, ConfirmAJCode.Checked, obj.MGCmt, Nothing, obj)

    End Sub

    Private Sub bttRejectMG_Click(sender As Object, e As EventArgs) Handles bttRejectMG.Click
        If txtCmtChecked.Text.Trim() <> "" Then
            Dim obj As New PCM_ApprovedNoJCode
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.MGCmt = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtChecked.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, ConfirmAJCode.Checked, obj.MGCmt, Nothing, obj)
        Else
            ShowWarning("Bạn phải nghi chú lý do từ chối yêu cầu." + vbCrLf + "Please comment detail.")
            txtCmtChecked.Focus()
        End If
    End Sub

    Private Sub bttApproved_Click(sender As Object, e As EventArgs) Handles bttApproved.Click

        Dim obj As New PCM_ApprovedNoJCode
        obj.ID_K = _myID
        _db.GetObject(obj)
        obj.DPCmt = txtCmtApproved.Text
        obj.DPDate = DateTime.Now
        obj.CurrentID = ""

        ConfirmUpdateOutlook(Submit.Confirm, ConfirmAJCode.Approved, obj.DPCmt, Nothing, obj)

    End Sub

    Private Sub bttRejectDP_Click(sender As Object, e As EventArgs) Handles bttRejectDP.Click
        If txtCmtApproved.Text.Trim() <> "" Then
            Dim obj As New PCM_ApprovedNoJCode
            obj.ID_K = _myID
            _db.GetObject(obj)
            obj.DPCmt = String.Format("({0}) {1}", DateTime.Now().ToString("dd/MM/yyyy HH:mm"), txtCmtApproved.Text)

            obj.CurrentID = ""
            ConfirmUpdateOutlook(Submit.Reject, ConfirmAJCode.Approved, obj.DPCmt, Nothing, obj)
        Else
            ShowWarning("Bạn phải nghi chú lý do từ chối yêu cầu." + vbCrLf + "Please comment detail.")
            txtCmtApproved.Focus()
        End If
    End Sub

    Sub ConfirmUpdateOutlook(sumit As Submit, confirm As ConfirmOT, comment As String, cc As List(Of String), obj As PCM_ApprovedNoJCode)
        Try
            _db.BeginTransaction()
            Dim lstTo As New List(Of String)
            Dim lstCC As New List(Of String)
            Dim lstBCC As New List(Of String)

            Dim arrCc() As String = Nothing
            Dim title = "(" & obj.DeptName & ")" & "YÊU CẦU PHÊ DUYỆT XUẤT KHO HÀNG KINH PHÍ " & obj.SubmitDate.ToString("dd-MM-yyyy")
            If sumit = Submit.Reject Then
                Select Case confirm
                    Case ConfirmAJCode.Checked
                        obj.SubmitDate = Nothing
                        obj.MGDate = Nothing
                        obj.DPDate = Nothing
                        obj.CurrentID = obj.SubmitUser

                        lstTo.Add(obj.SubmitUser)
                        SendMailOutlook(title, Nothing, sumit, lstTo, Nothing, Nothing, Nothing, Tag, obj.ID_K)
                    Case ConfirmAJCode.Approved
                        obj.MGDate = Nothing
                        obj.DPDate = Nothing
                        obj.CurrentID = obj.MG

                        lstTo.Add(obj.MG)
                        SendMailOutlook(title, Nothing, sumit, lstTo, Nothing, Nothing, Nothing, Tag, obj.ID_K)
                End Select
            Else
                Select Case confirm
                    Case ConfirmAJCode.LO
                        If obj.MG <> "" Then
                            lstTo.Add(obj.MG)
                            SendMailOutlook(title, Nothing, sumit, lstTo, cc, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = obj.MG
                            GoTo EndConfirm
                        End If
                    Case ConfirmAJCode.Checked
                        If obj.SubmitUser <> "" Then

                            lstCC.Add(obj.DP)
                            lstTo.Add(obj.SubmitUser)

                            'Dim myFile As String = Application.StartupPath & "\" & txtID.Text & ".xlsx"
                            'Dim lstFile As New List(Of String)
                            'lstFile.Add(myFile)
                            'GridControlExportExcel(GridView1, False, myFile)

                            SendMailOutlook(title, Nothing, sumit, lstTo, lstCC, Nothing, Nothing, Tag, obj.ID_K)
                            obj.CurrentID = ""
                            GoTo EndConfirm
                        End If
                    Case ConfirmAJCode.Approved
                        If obj.SubmitUser <> "" Then
                            lstTo.Add(obj.SubmitUser)
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
                                                    PublicTable.Table_PCM_ApprovedNoJCode,
                                                    CurrentUser.Mail))
        If obj IsNot Nothing Then
            _myID = obj
        End If
        LoadApproved()
    End Sub
End Class