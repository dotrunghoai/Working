Imports System.IO
Imports CommonDB
Imports DevExpress.XtraReports.UI
Imports PublicUtility
Public Class FrmChemicalReport
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim myPath As String = CurrentUser.TempFolder & "LO_ChemicalLicence\"
    Dim _isEdit As Boolean = True

    Private Sub FrmChemicalReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dteIssueDate.EditValue = DateTime.Now
        dteExpiryDate.EditValue = DateTime.Now
        dteCDFrom.EditValue = DateTime.Now
        dteCDTo.EditValue = DateTime.Now
        lueChemicalLicence.Properties.DataSource = _db.FillDataTable("SELECT DISTINCT ChemicalLicence 
                                                                        FROM LO_CL_ChemicalLicence 
                                                                        WHERE ChemicalLicence IS NOT NULL
                                                                        ORDER BY ChemicalLicence")
        lueChemicalLicence.Properties.DisplayMember = "ChemicalLicence"
        lueChemicalLicence.Properties.ValueMember = "ChemicalLicence"
        Dim obj As New Main_UserRight
        obj.UserID_K = CurrentUser.UserID
        obj.FormID_K = Tag
        _db.GetObject(obj)
        If obj.IsEdit = False Then
            _isEdit = False
        End If
    End Sub

    Private Sub dteIssueDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteIssueDate.EditValueChanged
        If dteIssueDate.DateTime > dteExpiryDate.DateTime Then
            dteExpiryDate.EditValue = dteIssueDate.DateTime
        End If
    End Sub

    Private Sub dteExpiryDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteExpiryDate.EditValueChanged
        If dteExpiryDate.DateTime < dteIssueDate.DateTime Then
            dteIssueDate.EditValue = dteExpiryDate.DateTime
        End If
    End Sub

    Private Sub dteCDFrom_EditValueChanged(sender As Object, e As EventArgs) Handles dteCDFrom.EditValueChanged
        If dteCDFrom.DateTime > dteCDTo.DateTime Then
            dteCDTo.EditValue = dteCDFrom.DateTime
        End If
    End Sub

    Private Sub dteCDTo_EditValueChanged(sender As Object, e As EventArgs) Handles dteCDTo.EditValueChanged
        If dteCDTo.DateTime < dteCDFrom.DateTime Then
            dteCDFrom.EditValue = dteCDTo.DateTime
        End If
    End Sub

    Private Sub btnRun_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRun.ItemClick
        GridView1.Columns.Clear()
        Dim para(3) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "ShowReport")
        para(1) = New SqlClient.SqlParameter("@ChemicalLicence", lueChemicalLicence.Text)
        para(2) = New SqlClient.SqlParameter("@CDFrom", dteCDFrom.DateTime.Date)
        para(3) = New SqlClient.SqlParameter("@CDTo", dteCDTo.DateTime.Date)
        Dim dt As DataTable = _db.ExecuteStoreProcedureTB("sp_LO_CL_ChemicalLicence", para)
        If dt.Rows.Count > 0 Then
            GridControl1.DataSource = dt
            GridControlSetFormat(GridView1, 1)
            GridControlSetFormatPercentage(GridView1, "Content", 2)
            GridView1.Columns("TradeName").Width = 200
        Else
            ShowWarning("Không có dữ liệu !")
        End If
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        If GridView1.Columns("NK") Is Nothing Then
            If Not IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "RemainQty")) Then
                If GridView1.GetRowCellValue(e.RowHandle, "RemainQty") < 0 Then
                    e.Appearance.BackColor = Color.Red
                ElseIf GridView1.GetRowCellValue(e.RowHandle, "RemainQty") < 0.25 * GridView1.GetRowCellValue(e.RowHandle, "LicenceQty") Then
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        End If
    End Sub

    Private Sub lueChemicalLicence_EditValueChanged(sender As Object, e As EventArgs) Handles lueChemicalLicence.EditValueChanged
        If lueChemicalLicence.Text <> "" Then
            Dim dt As DataTable = _db.FillDataTable(String.Format("SELECT IssueDate, ExpiryDate, CDFrom, CDTo
                                                     FROM LO_CL_ChemicalLicence
                                                     WHERE ChemicalLicence = '{0}'", lueChemicalLicence.Text))
            dteIssueDate.EditValue = dt.Rows(0)("IssueDate")
            dteExpiryDate.EditValue = dt.Rows(0)("ExpiryDate")
            dteCDFrom.EditValue = dt.Rows(0)("CDFrom")
            dteCDTo.EditValue = dt.Rows(0)("CDTo")
            'Load AttachFile
            Dim dtFile As DataTable = _db.FillDataTable(String.Format("SELECT TOP 1 AttachFile, AttachFileLink
                                                                  FROM LO_CL_ChemicalLicence
                                                                  WHERE ChemicalLicence = '{0}'", lueChemicalLicence.Text))
            If Not IsDBNull(dtFile.Rows(0)("AttachFile")) Then
                If dtFile.Rows(0)("AttachFile") <> "" Then
                    linkLabelAttachFile.Text = dtFile.Rows(0)("AttachFile")
                    linkLabelAttachFile.Tag = dtFile.Rows(0)("AttachFileLink")
                Else
                    linkLabelAttachFile.Text = ""
                End If
            Else
                linkLabelAttachFile.Text = ""
            End If
        End If
    End Sub

    Private Sub btnReport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnReport.ItemClick
        GridView1.Columns.Clear()
        Dim para(3) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Action", "ShowReportDetail")
        para(1) = New SqlClient.SqlParameter("@ChemicalLicence", lueChemicalLicence.Text)
        para(2) = New SqlClient.SqlParameter("@CDFrom", dteCDFrom.DateTime.Date)
        para(3) = New SqlClient.SqlParameter("@CDTo", dteCDTo.DateTime.Date)
        Dim dtDetail As DataTable = _db.ExecuteStoreProcedureTB("sp_LO_CL_ChemicalLicence", para)
        para(0) = New SqlClient.SqlParameter("@Action", "ShowReport")
        Dim dtHead As DataTable = _db.ExecuteStoreProcedureTB("sp_LO_CL_ChemicalLicence", para)
        If dtDetail.Rows.Count > 0 Then
            Dim stt = 1
            Dim start = 0
            For Each rH As DataRow In dtHead.Rows
                Dim LicenceQty = rH("LicenceQty")
                For rD = 0 To dtDetail.Rows.Count - 1
                    If rH("PurCode") = dtDetail.Rows(rD)("PurCode") Then
                        dtDetail.Rows(rD)("STT") = stt
                        start += 1
                        If Not IsDBNull(dtDetail.Rows(rD)("ImportQty")) Then
                            dtDetail.Rows(rD)("RemainQty") = LicenceQty - dtDetail.Rows(rD)("ImportQty")
                            LicenceQty = dtDetail.Rows(rD)("RemainQty")
                        Else
                            GoTo Label3
                        End If
                        If rD = dtDetail.Rows.Count - 1 And rD <> 0 Then
                            GoTo Label
                        ElseIf rD = dtDetail.Rows.Count - 1 And rD = 0 Then
                            dtDetail.Rows(rD)("LicenceQty") = rH("LicenceQty")
                            Dim dtRow As DataRow
                            dtRow = dtDetail.NewRow
                            dtRow("XKNĐ") = "Tổng cộng:"
                            dtRow("LicenceQty") = rH("LicenceQty")
                            dtRow("ImportQty") = rH("ImportQty")
                            dtRow("RemainQty") = rH("RemainQty")
                            dtRow("PurCode") = ""
                            dtDetail.Rows.InsertAt(dtRow, (rD + 1))
                            GoTo Label2
                        End If
                        If start > 1 Then
                            If dtDetail.Rows(rD)("PurCode") <> dtDetail.Rows(rD + 1)("PurCode") Then
                                start = 0
                                stt += 1
Label:
                                Dim dtRow As DataRow
                                dtRow = dtDetail.NewRow
                                dtRow("XKNĐ") = "Tổng cộng:"
                                dtRow("LicenceQty") = rH("LicenceQty")
                                dtRow("ImportQty") = rH("ImportQty")
                                dtRow("RemainQty") = rH("RemainQty")
                                dtRow("PurCode") = ""
                                dtDetail.Rows.InsertAt(dtRow, (rD + 1))
                            End If
                            dtDetail.Rows(rD)("STT") = ""
                            dtDetail.Rows(rD)("PurCode") = ""
                            dtDetail.Rows(rD)("Tên thương mại") = ""
                            dtDetail.Rows(rD)("Tên HC") = ""
                            dtDetail.Rows(rD)("CTPT") = ""
                            dtDetail.Rows(rD)("Mã số CAS") = ""
                            dtDetail.Rows(rD)("Hàm lượng") = DBNull.Value
                            dtDetail.Rows(rD)("Đơn vị tính") = ""
                            'dtDetail.Rows(rD)("LicenceQty") = DBNull.Value
                        ElseIf start = 1 And dtDetail.Rows(rD)("PurCode") <> dtDetail.Rows(rD + 1)("PurCode") Then
Label3:
                            start = 0
                            stt += 1
                            Dim dtRow As DataRow
                            dtRow = dtDetail.NewRow
                            dtRow("XKNĐ") = "Tổng cộng:"
                            dtRow("LicenceQty") = rH("LicenceQty")
                            dtRow("ImportQty") = rH("ImportQty")
                            dtRow("RemainQty") = rH("RemainQty")
                            dtRow("PurCode") = ""
                            dtDetail.Rows.InsertAt(dtRow, (rD + 1))
                            'dtDetail.Rows(rD)("XKNĐ") = "Tổng cộng:"
                            'dtDetail.Rows(rD)("LicenceQty") = rH("LicenceQty")
                        End If
                    End If
                Next
            Next
Label2:
            GridControl1.DataSource = dtDetail
            GridControlSetFormat(GridView1, 1)
            GridControlSetFormatPercentage(GridView1, "Hàm lượng", 2)

            GridView1.Columns("Tên thương mại").Width = 150
            GridView1.Columns("Tờ khai hải quan").Width = 200

            'Report
            'Dim data As DataTable = dtDetail
            'data.TableName = "Report_Chemical_Licence"
            'data.WriteXmlSchema("Report_Chemical_Licence.xsd")
            Dim report As New RpChemicalLicenceReport
            report.DataSource = dtDetail
            report.DataMember = ""
            report.Parameters("paraSoGP").Value = lueChemicalLicence.Text + " (" + dteIssueDate.DateTime.ToString("dd/MM/yyyy") + " - " + dteExpiryDate.DateTime.ToString("dd/MM/yyyy") + ")"
            report.Parameters("paraSoGP").Visible = False
            Dim RePrTool As New ReportPrintTool(report)
            RePrTool.ShowPreview()
        Else
            ShowWarning("Không có dữ liệu !")
        End If
    End Sub

    Private Sub btnAddFile_Click(sender As Object, e As EventArgs) Handles btnAddFile.Click
        If lueChemicalLicence.Text <> "" Then
            Dim frm As New OpenFileDialog
            frm.ShowDialog()
            If frm.FileName <> "" Then
                Dim AttachFile = frm.SafeFileName
                Dim AttachFileLink = myPath & dteIssueDate.DateTime.ToString("dd-MM-yyyy") & "_" & lueChemicalLicence.Text.Replace("/", "_") & "_LO_CL_" & frm.SafeFileName
                File.Copy(frm.FileName, AttachFileLink, True)

                _db.ExecuteNonQuery(String.Format("UPDATE LO_CL_ChemicalLicence
                                                    SET AttachFile = N'{0}',
                                                        AttachFileLink = N'{1}'
                                                    WHERE ChemicalLicence = '{2}'",
                                                    AttachFile,
                                                    AttachFileLink,
                                                    lueChemicalLicence.Text))
                linkLabelAttachFile.Text = AttachFile
                linkLabelAttachFile.Tag = AttachFileLink
            End If
            frm.Dispose()
        End If
    End Sub

    Private Sub btnDeleteFile_Click(sender As Object, e As EventArgs) Handles btnDeleteFile.Click
        If File.Exists(linkLabelAttachFile.Tag) Then
            File.Delete(linkLabelAttachFile.Tag)
            _db.ExecuteNonQuery(String.Format("UPDATE LO_CL_ChemicalLicence
                                                   SET AttachFile = '',
                                                   AttachFileLink = ''
                                                   WHERE ChemicalLicence = '{0}'",
                                                   lueChemicalLicence.Text))
            linkLabelAttachFile.Text = ""
            linkLabelAttachFile.Tag = ""
        End If
    End Sub

    Private Sub linkLabelAttachFile_Click(sender As Object, e As EventArgs) Handles linkLabelAttachFile.Click
        If File.Exists(linkLabelAttachFile.Tag) Then
            Process.Start(linkLabelAttachFile.Tag)
        End If
    End Sub
    Sub SendMailWarning()
        If _isEdit Then
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
        End If
    End Sub
End Class