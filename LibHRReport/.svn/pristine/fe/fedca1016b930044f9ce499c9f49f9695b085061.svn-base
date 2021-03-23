Imports System.IO
Imports Microsoft.Office.Interop
Imports PublicUtility
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports CommonDB

Public Class clsApplication
    Public Shared pathfile As String = "Bat\"
    Public Const olNewline As String = "<br/>"
    Public Const olNewDoubleline As String = "<br/><br/>"
    Const olInfo As String = " Trạng thái: Thông tin/ thông báo.  " & olNewDoubleline &
                             " Xin chào, " & olNewDoubleline &
                             " Vui lòng mở file trên ERP để xem chi tiết. " & olNewline &
                             " Mở ERP: {0}" & olNewline &
                             " Nếu có bất kỳ thắc mắc hay yêu cầu nào khác, vui lòng thông tin đến chúng tôi theo địa chỉ email: lan.duonghoang@nitto.com" & olNewDoubleline &
                             " Cám ơn" & olNewline &
                             " (GA)" & olNewDoubleline &
                             " 状況：情報/通知" & olNewDoubleline &
                             " お疲れ様です。" & olNewDoubleline &
                             " 詳細を見るためのERPにファイルを開いてください。" & olNewline &
                             " ERP開け: {0}" & olNewline &
                             " 他にご質問し、ご要求が必要であれば、以下のメールアドレス通りにご連絡お願いします。lan.duonghoang@nitto.com" & olNewDoubleline &
                             " よろしくお願いします。" & olNewline &
                             " (GA)"
    Public Enum Submit
        Confirm
        Reject
        Info
        Finished
        Open
        None
    End Enum
    Shared Sub SendMailOutlook(ByVal Subject As String,
                    ByVal body As String,
                     ByVal submit As Submit,
                    ByVal listTo As List(Of String),
                    ByVal listCc As List(Of String),
                    ByVal listBcc As List(Of String),
                    ByVal listAttach As List(Of String),
                   ByVal tag As String,
                   ByVal ID As String)

        'Try
        If listTo IsNot Nothing Then
            If listTo.Count = 1 Then
                If listTo.Item(0) = "trung.doquang@nitto.com" Or
                    listTo.Item(0) = "thao.dophuong@nitto.com" Then
                    Return
                End If
            End If
        End If

        Dim ap As New Outlook.Application
        Dim myBody As String = ""
        Dim mail As Outlook.MailItem = CType(ap.CreateItem(Outlook.OlItemType.olMailItem), Outlook.MailItem)
        Dim currentUser As Outlook.AddressEntry = ap.Session.CurrentUser.AddressEntry
        CreateFileConfirm(ID, tag)

        If currentUser.Type = "EX" Then
            'Subject 
            mail.Subject = Subject
            'Body
            If ID = "" Then
                'myBody += String.Format("<br/><br/>" & "Open ERP/Mở ERP: " & String.Format("<a href=""{0}\app.bat"">Click here</a>", PublicUtility.CurrentUser.TempFolder & pathfile), tag & ID)
                myBody = String.Format(olInfo & tag & ID, String.Format("<a href=""{0}\app.bat"">Click here</a>", (PublicUtility.CurrentUser.TempFolder & pathfile)))
            Else
                'myBody += String.Format("<br/><br/>" & "Open ERP/Mở ERP: " & "<a href=""{0}\{1}.bat"">Click here</a>", PublicUtility.CurrentUser.TempFolder & pathfile, tag & ID)
                myBody = String.Format(olInfo, String.Format("<a href=""{0}\{1}.bat"">Click here</a>", (PublicUtility.CurrentUser.TempFolder & pathfile), (tag & ID)))
            End If

            mail.HTMLBody = myBody

            ' first, we remove all the recipients of the e-mail
            Dim recipients As Outlook.Recipients = mail.Recipients
            Dim Recipient As Outlook.Recipient
            While recipients.Count > 0
                recipients.Remove(1)
            End While
            'Add TO
            If listTo IsNot Nothing Then
                For Each item In listTo
                    If item <> "" Then
                        If item.Contains(",") Then
                            Dim arr() = item.Split(",")
                            For Each a In arr
                                If a.Contains("@") Then
                                    a = a.Replace(vbCrLf, "")
                                    Recipient = recipients.Add(a)
                                    Recipient.Type = Outlook.OlMailRecipientType.olTo
                                    Recipient.Resolve()
                                End If
                            Next
                        Else
                            If item.Contains("@") Then
                                item = item.Replace("& vbCrLf &", "")
                                Recipient = recipients.Add(item)
                                Recipient.Type = Outlook.OlMailRecipientType.olTo
                                Recipient.Resolve()
                            End If
                        End If
                    End If
                Next
            End If
            'Add Cc
            If listCc IsNot Nothing Then
                For Each item In listCc
                    If item <> "" Then
                        If item.Contains(",") Then
                            Dim arr() = item.Split(",")
                            For Each a In arr
                                If a.Contains("@") Then
                                    a = a.Replace(vbCrLf, "")
                                    Recipient = recipients.Add(a)
                                    Recipient.Type = Outlook.OlMailRecipientType.olCC
                                    Recipient.Resolve()
                                End If
                            Next
                        Else
                            If item.Contains("@") Then
                                item = item.Replace("& vbCrLf &", "")
                                Recipient = recipients.Add(item)
                                Recipient.Type = Outlook.OlMailRecipientType.olCC
                                Recipient.Resolve()
                            End If
                        End If
                    End If
                Next
            End If
            'Add Bcc
            If listBcc IsNot Nothing Then
                For Each item In listBcc
                    If item <> "" Then
                        If item.Contains(",") Then
                            Dim arr() = item.Split(",")
                            For Each a In arr
                                If a.Contains("@") Then
                                    a = a.Replace(vbCrLf, "")
                                    Recipient = recipients.Add(a)
                                    Recipient.Type = Outlook.OlMailRecipientType.olBCC
                                    Recipient.Resolve()
                                End If
                            Next
                        Else
                            If item.Contains("@") Then
                                item = item.Replace("& vbCrLf &", "")
                                Recipient = recipients.Add(item)
                                Recipient.Type = Outlook.OlMailRecipientType.olBCC
                                Recipient.Resolve()
                            End If
                        End If
                    End If
                Next
            End If
            'Add Attach 
            If listAttach IsNot Nothing Then
                For Each item In listAttach
                    If File.Exists(item) Then
                        mail.Attachments.Add(item, Outlook.OlAttachmentType.olByValue)
                    End If
                Next
            End If
            'Send email
            mail.Send()
        End If
        'Catch ex As Exception
        '	ShowError(ex, "SendmailOutLook", "PublicFunction")
        'End Try
    End Sub
End Class
