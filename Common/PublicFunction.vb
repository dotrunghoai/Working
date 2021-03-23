﻿Imports System.Security.Cryptography
Imports System.IO
Imports System.Xml.Serialization
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Office.Interop
Imports System.Reflection
Imports System.Data.OleDb
Imports LibEntity
Imports System.Net
Imports System.Data.Odbc
Imports PublicUtility
Imports System.Data.OracleClient
Imports System.Globalization
Imports System.ComponentModel
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Domino

Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars.Docking2010.Views
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks

''' <summary>
''' Stored many common functions 
''' Author: Truong Minh Tam
''' Date: July-2011
''' </summary>
''' <remarks></remarks>
''' 

Public Module PublicFunction
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

#Region "Variable"
    Public pathfile As String = "Bat\"
    Private ReadOnly FolderBat As String = "C:\Programs_NDV\ERPNDV\Bat"
    Const contentApproved As String = "[{0}] đã gởi yêu cầu xác nhận đến bạn (Approved request).  "
    Const contentFinished As String = "[{0}] đã gởi thông báo (Finished request).  "
    Const contentReject As String = "[{0}] đã từ chối xác nhận yêu cầu (Rejected request). "
    Const contentInfor As String = "[{0}] gởi thông báo với thông tin chi tiết bên dưới."

    Public Const olNewline As String = "<br/>"
    Public Const olNewDoubleline As String = "<br/><br/>"
    Const olHello As String = "Xin chào," & olNewline

    Const olApproved As String = " Xin chào, " & olNewDoubleline &
                                 " <b>{0}</b> " & olNewDoubleline &
                                 " Trạng thái: Yêu cầu phê duyệt.  " & olNewline &
                                 " Ghi chú: Bạn phải mở ERP để duyệt hoặc xem chi tiết yêu cầu. " & olNewDoubleline &
                                 " Dear All, " & olNewDoubleline &
                                 " Status: Approval request." & olNewline &
                                 " Note: You have to open ERP system to approve or vie..."

    Const olReject As String = " Xin chào, " & olNewDoubleline &
                               " <b>{0}</b> " & olNewDoubleline &
                               " Trạng thái: Yêu cầu đã bị từ chối.  " & olNewline &
                               " Ghi chú: Bạn phải mở ERP để duyệt hoặc xem chi tiết yêu cầu. " & olNewDoubleline &
                               " Dear All, " & olNewDoubleline &
                               " Status: Reject request." & olNewline &
                               " Note: You have to open ERP system to approve or vie..."

    Const olInfo As String = " Xin chào, " & olNewDoubleline &
                             " <b>{0}</b> " & olNewDoubleline &
                             " Trạng thái: Thông tin/ thông báo.  " & olNewline &
                             " Ghi chú: Bạn phải mở ERP để duyệt hoặc xem chi tiết yêu cầu. " & olNewDoubleline &
                             " Dear All, " & olNewDoubleline &
                             " Status: Information/ Alarm." & olNewline &
                             " Note: You have to open ERP system to approve or vie..."
    Const olFinished As String = " Xin chào, " & olNewDoubleline &
                             " <b>{0}</b> " & olNewDoubleline &
                             " Trạng thái: Đã phê duyệt.  " & olNewline &
                             " Ghi chú: Bạn phải mở ERP để duyệt hoặc xem chi tiết yêu cầu. " & olNewDoubleline &
                             " Dear All, " & olNewDoubleline &
                             " Status: Approved." & olNewline &
                             " Note: You have to open ERP system to approve or vie..."

    Const olNote As String = "Ghi chú: Bạn phải mở ERP để duyệt hoặc xem chi tiết yêu cầu. " & olNewline

    Private lang As New MultiLanguage
    Private ReadOnly _folderLog As String = Application.StartupPath + "\Log\"
    Private ReadOnly _fileLog As String = Application.StartupPath + "\Log\" & DateTime.Now.ToString("dd-MMM-yyyy") & ".txt"
    Private ReadOnly _line As String = "================================================================================================="

    ReadOnly colorOver As Color = Color.Pink
    ReadOnly colorAlready As Color = Color.LightGreen
    ReadOnly colorNoYet As Color = Color.Gold
    ReadOnly color1 As Color = Color.White
    ReadOnly color2 As Color = Color.YellowGreen


#End Region

#Region "Enum "
    Public Enum EnumMessage
        Question = 0
        Warning = 1
        [Error] = 2
    End Enum
    Public Enum EnumTimeType
        ThaoTacChinh = 1
        GioCongCoDinh = 2
        GioCongLangPhi = 3
    End Enum
    Public Enum EnumTimeCondition
        ALL = 0
        BienDong = 1
        CoDinh = 2
    End Enum
    ''' <summary>
    ''' ddmmyyyy
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum EnumDateFormat
        ddmmyyyy = 0
        mmddyyyy = 1
    End Enum

    Public Enum FormState
        AddNew = 0
        Edit = 1
        Delete = 2
        Confirm = 3
    End Enum

    Public Enum Status
        Wait
        Complete
    End Enum
    Public Enum Submit
        Confirm
        Reject
        Info
        Finished
        Open
        None
    End Enum
    Public Enum ConfirmSE
        Create
        Submit
        Ringi1
        Ringi2
        Ringi3
        Ringi4
        Ringi5
        Refer1
        Refer2
        Refer3
        Refer4
        Refer5
        Notify
        Approved
    End Enum
    Public Enum ConfirmOT
        Requester
        TeamLeader
        LineLeader
        GroupLeader
        Manager
        DManager
        GManager
        FManager
        HR
    End Enum
    Public Enum ConfirmRQ
        Prepare
        Confirm
        PIC
        IT
        VMM
        GD
    End Enum

    Public Enum ConfirmITF
        Requester
        MG
        ITLL
        ITGL
        ITMG
        GD
        BV
    End Enum

    Public Enum ConfirmBOM
        Staff
        LL
        GL
        MG
        DM
    End Enum

    Public Enum ConfirmRM
        Requester
        LL
        GL
        MG
        PPStaff
        PPMG
        PPDM
        PRStaff
        PRMG
    End Enum

    Public Enum ConfirmRN
        Requester
        LL
        GL
        MG
        DM
        PPStaff
        PPMG
        ADM
    End Enum

    Public Enum ConfirmToolLiquid
        Requester
        MG
        DM
        Confirm1
        Confirm2
        Confirm3
        PU1
        FM
        IT
        LO
        SE
        PU
    End Enum
    Public Enum ConfirmMC
        Requester
        GLChecked
        StaffRespone
        StaffDO
        GLApproved
        MGApproved
    End Enum

    Public Enum ConfirmQCI
        PIC
        LL
        GL
        MG
        LLQC
        GLQC
        MGQC
    End Enum

    Public Enum ConfirmQAE
        PIC
        Check
        Approved
        QAPIC
        QACheck
        QAApproved
    End Enum

    Public Enum ConfirmAJCode
        LO
        Checked
        Approved
    End Enum

    Public Enum ConfirmLOC
        PIC
        MG
        DP
    End Enum

    Public Enum ConfirmQCE
        PIC
        GLChecked
        StaffRespone
        LLDo
        GLDo
        MGDo
    End Enum

    Public Enum ConfirmDS
        RQ
        LL
        GL
        QAStaff
        QAGL
        Returner
        Receiver
    End Enum

    Public Enum ConfirmMFPC
        Create
        GroupC
        GroupTT
        ManagerTT
        DM1
        QA1
        PPTK
        CSTK
        GroupLD
        ManagerLD
        SCQT1
        DM
        QA
        GroupHQ
        ManagerHQ
        DMHQ
        SCQT
    End Enum
    Public Enum ConfirmGA
        RQ
        GL
        MG
        GAC
        GAA
        CF
    End Enum
    Public Enum ConfirmHRA
        Requester
        Line
        Group
        Manager
        DManager
        HRStaff
    End Enum
    Public Enum FrmName
        FrmConfirmOT = 0
    End Enum
#End Region

#Region "Fpics"

    Public Function CheckExistPdCode(ByVal pdCode As String) As Boolean
        Dim db = New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
        Dim sql As String = String.Format("select top 1 * from {0} where ProductCode='{1}'",
                                        PublicTable_FPICS.Table_m_Product, pdCode)
        Dim tbPdCode As DataTable = db.FillDataTable(sql)
        If tbPdCode.Rows.Count > 0 Then
            Return True
        End If
        db.CloseConnect()
        Return False
    End Function

    Public Function CheckExistPdCodeProcessResult(ByVal pdCode As String) As Boolean
        Dim db = New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
        Dim sql As String = String.Format("select top 1 * from {0} where ProductCode='{1}'",
                                        PublicTable_FPICS.Table_m_Product, pdCode)
        Dim tbPdCode As DataTable = db.FillDataTable(sql)
        If tbPdCode.Rows.Count > 0 Then
            Return True
        End If
        db.CloseConnect()
        Return False
    End Function

    Function GetStandardLotSize(ByVal pdCode As String, ByVal revision As String) As Integer
        Dim sql As String = String.Format(" SELECT StandardLotSize " +
                                          " FROM [m_Product] " +
                                          " where productcode='{0}' and revisioncode='{1}'",
                                          pdCode, revision)
        Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
        Dim o As Object = db.ExecuteScalar(sql)
        db.CloseConnect()
        If o Is DBNull.Value Then
            Return 0
        Else
            Return Convert.ToInt32(o)
        End If
    End Function

#End Region

#Region "Update default data"
    Sub SettingDefaultData()
        If PublicConst.Language = PublicConst.EnumLanguage.English Then
            PublicConst.Message_Question_Getdata = "Do you want to get data ?"
            PublicConst.Message_Question_Save = "Do you want to save data ?"
            PublicConst.Message_Question_Update = "Do you want to update data ?"
            PublicConst.Message_Question_Delete = "Do you want to delete data ?"
            PublicConst.Message_Question_Insert = "Do you want to insert ?"
            PublicConst.Message_Question_Import = "Do you want to import ?"
            PublicConst.Message_Question_Export = "Do you want to export ?"
            PublicConst.Message_Question_Print = "Do you want to print ?"
            PublicConst.Message_Question_Sync = "Do you want to Sync data ?"
            PublicConst.Message_Question_Exit = "Do you want to exit ?"
            PublicConst.Message_Question_Back = "Do you want to back ?"
            PublicConst.Message_Question_Lock = "Do you want to lock ?"
            PublicConst.Message_Question_UnLock = "Do you want to unlock ?"
            PublicConst.Message_Question_Backup = "Do you want to backup ?"
            PublicConst.Message_Question_Restore = "Do you want to restore ?"
            PublicConst.Message_Question_Confirm = "Do you want to confirm ?"
            PublicConst.Message_Question_UnConfirm = "Do you want to unconfirm ?"
            PublicConst.Message_Question_Run = "Do you want to run?"


            PublicConst.Message_Caption_Getdata = "GetData"
            PublicConst.Message_Caption_Save = "Save"
            PublicConst.Message_Caption_Update = "Update"
            PublicConst.Message_Caption_Delete = "Delete"
            PublicConst.Message_Caption_Insert = "Insert"
            PublicConst.Message_Caption_Import = "Import"
            PublicConst.Message_Caption_Export = "Export"
            PublicConst.Message_Caption_Print = "Print"
            PublicConst.Message_Caption_Sync = "Sync"
            PublicConst.Message_Caption_Exit = "Exit"
            PublicConst.Message_Caption_Back = "Back"
            PublicConst.Message_Caption_Lock = "Lock"
            PublicConst.Message_Caption_UnLock = "Unlock"
            PublicConst.Message_Caption_Backup = "Backup"
            PublicConst.Message_Caption_Restore = "Restore"
            PublicConst.Message_Caption_Confirm = "Confirm"
            PublicConst.Message_Caption_UnConfirm = "Unconfirm"
            PublicConst.Message_Caption_Run = "Run"
            PublicConst.Message_Caption_Condition = "Condition"
            PublicConst.Message_Caption_Error = "Error"
            PublicConst.Message_Caption_Help = "Help"
            PublicConst.Message_Caption_Info = "Information"
            PublicConst.Message_Caption_Warning = "Warning"

            PublicConst.Message_Successfully = "Success"
            PublicConst.Message_Warning_NotNull = " is not null."
            PublicConst.Message_Warning_ExistData = " Data is exist."
        End If
        If PublicConst.Language = PublicConst.EnumLanguage.Japan Then
            PublicConst.Message_Question_Getdata = "Do you want to get data ?"
            PublicConst.Message_Question_Save = "Do you want to save data ?"
            PublicConst.Message_Question_Update = "Do you want to update data ?"
            PublicConst.Message_Question_Delete = "Do you want to delete data ?"
            PublicConst.Message_Question_Insert = "Do you want to insert ?"
            PublicConst.Message_Question_Import = "Do you want to import ?"
            PublicConst.Message_Question_Export = "Do you want to export ?"
            PublicConst.Message_Question_Print = "Do you want to print ?"
            PublicConst.Message_Question_Sync = "Do you want to Sync data ?"
            PublicConst.Message_Question_Exit = "Do you want to exit ?"
            PublicConst.Message_Question_Back = "Do you want to back ?"
            PublicConst.Message_Question_Lock = "Do you want to lock ?"
            PublicConst.Message_Question_UnLock = "Do you want to unlock ?"
            PublicConst.Message_Question_Backup = "Do you want to backup ?"
            PublicConst.Message_Question_Restore = "Do you want to restore ?"
            PublicConst.Message_Question_Confirm = "Do you want to confirm ?"
            PublicConst.Message_Question_UnConfirm = "Do you want to unconfirm ?"
            PublicConst.Message_Question_Run = "Do you want to run?"


            PublicConst.Message_Caption_Getdata = "GetData"
            PublicConst.Message_Caption_Save = "Save"
            PublicConst.Message_Caption_Update = "Update"
            PublicConst.Message_Caption_Delete = "Delete"
            PublicConst.Message_Caption_Insert = "Insert"
            PublicConst.Message_Caption_Import = "Import"
            PublicConst.Message_Caption_Export = "Export"
            PublicConst.Message_Caption_Print = "Print"
            PublicConst.Message_Caption_Sync = "Sync"
            PublicConst.Message_Caption_Exit = "Exit"
            PublicConst.Message_Caption_Back = "Back"
            PublicConst.Message_Caption_Lock = "Lock"
            PublicConst.Message_Caption_UnLock = "Unlock"
            PublicConst.Message_Caption_Backup = "Backup"
            PublicConst.Message_Caption_Restore = "Restore"
            PublicConst.Message_Caption_Confirm = "Confirm"
            PublicConst.Message_Caption_UnConfirm = "Unconfirm"
            PublicConst.Message_Caption_Run = "Run"
            PublicConst.Message_Caption_Condition = "Condition"
            PublicConst.Message_Caption_Error = "Error"
            PublicConst.Message_Caption_Help = "Help"
            PublicConst.Message_Caption_Info = "Information"
            PublicConst.Message_Caption_Warning = "Warning"

            PublicConst.Message_Successfully = "Success"
            PublicConst.Message_Warning_NotNull = " is not null."
            PublicConst.Message_Warning_ExistData = " Data is exist."
        End If
        If PublicConst.Language = PublicConst.EnumLanguage.China Then
            PublicConst.Message_Question_Getdata = "Do you want to get data ?"
            PublicConst.Message_Question_Save = "Do you want to save data ?"
            PublicConst.Message_Question_Update = "Do you want to update data ?"
            PublicConst.Message_Question_Delete = "Do you want to delete data ?"
            PublicConst.Message_Question_Insert = "Do you want to insert ?"
            PublicConst.Message_Question_Import = "Do you want to import ?"
            PublicConst.Message_Question_Export = "Do you want to export ?"
            PublicConst.Message_Question_Print = "Do you want to print ?"
            PublicConst.Message_Question_Sync = "Do you want to Sync data ?"
            PublicConst.Message_Question_Exit = "Do you want to exit ?"
            PublicConst.Message_Question_Back = "Do you want to back ?"
            PublicConst.Message_Question_Lock = "Do you want to lock ?"
            PublicConst.Message_Question_UnLock = "Do you want to unlock ?"
            PublicConst.Message_Question_Backup = "Do you want to backup ?"
            PublicConst.Message_Question_Restore = "Do you want to restore ?"
            PublicConst.Message_Question_Confirm = "Do you want to confirm ?"
            PublicConst.Message_Question_UnConfirm = "Do you want to unconfirm ?"
            PublicConst.Message_Question_Run = "Do you want to run?"


            PublicConst.Message_Caption_Getdata = "GetData"
            PublicConst.Message_Caption_Save = "Save"
            PublicConst.Message_Caption_Update = "Update"
            PublicConst.Message_Caption_Delete = "Delete"
            PublicConst.Message_Caption_Insert = "Insert"
            PublicConst.Message_Caption_Import = "Import"
            PublicConst.Message_Caption_Export = "Export"
            PublicConst.Message_Caption_Print = "Print"
            PublicConst.Message_Caption_Sync = "Sync"
            PublicConst.Message_Caption_Exit = "Exit"
            PublicConst.Message_Caption_Back = "Back"
            PublicConst.Message_Caption_Lock = "Lock"
            PublicConst.Message_Caption_UnLock = "Unlock"
            PublicConst.Message_Caption_Backup = "Backup"
            PublicConst.Message_Caption_Restore = "Restore"
            PublicConst.Message_Caption_Confirm = "Confirm"
            PublicConst.Message_Caption_UnConfirm = "Unconfirm"
            PublicConst.Message_Caption_Run = "Run"
            PublicConst.Message_Caption_Condition = "Condition"
            PublicConst.Message_Caption_Error = "Error"
            PublicConst.Message_Caption_Help = "Help"
            PublicConst.Message_Caption_Info = "Information"
            PublicConst.Message_Caption_Warning = "Warning"

            PublicConst.Message_Successfully = "Success"
            PublicConst.Message_Warning_NotNull = " is not null."
            PublicConst.Message_Warning_ExistData = " Data is exist."
        End If
        If PublicConst.Language = PublicConst.EnumLanguage.VietNam Then
            PublicConst.Message_Question_Getdata = "Do you want to get data ?"
            PublicConst.Message_Question_Save = "Do you want to save data ?"
            PublicConst.Message_Question_Update = "Do you want to update data ?"
            PublicConst.Message_Question_Delete = "Do you want to delete data ?"
            PublicConst.Message_Question_Insert = "Do you want to insert ?"
            PublicConst.Message_Question_Import = "Do you want to import ?"
            PublicConst.Message_Question_Export = "Do you want to export ?"
            PublicConst.Message_Question_Print = "Do you want to print ?"
            PublicConst.Message_Question_Sync = "Do you want to Sync data ?"
            PublicConst.Message_Question_Exit = "Do you want to exit ?"
            PublicConst.Message_Question_Back = "Do you want to back ?"
            PublicConst.Message_Question_Lock = "Do you want to lock ?"
            PublicConst.Message_Question_UnLock = "Do you want to unlock ?"
            PublicConst.Message_Question_Backup = "Do you want to backup ?"
            PublicConst.Message_Question_Restore = "Do you want to restore ?"
            PublicConst.Message_Question_Confirm = "Do you want to confirm ?"
            PublicConst.Message_Question_UnConfirm = "Do you want to unconfirm ?"
            PublicConst.Message_Question_Run = "Do you want to run?"


            PublicConst.Message_Caption_Getdata = "GetData"
            PublicConst.Message_Caption_Save = "Save"
            PublicConst.Message_Caption_Update = "Update"
            PublicConst.Message_Caption_Delete = "Delete"
            PublicConst.Message_Caption_Insert = "Insert"
            PublicConst.Message_Caption_Import = "Import"
            PublicConst.Message_Caption_Export = "Export"
            PublicConst.Message_Caption_Print = "Print"
            PublicConst.Message_Caption_Sync = "Sync"
            PublicConst.Message_Caption_Exit = "Exit"
            PublicConst.Message_Caption_Back = "Back"
            PublicConst.Message_Caption_Lock = "Lock"
            PublicConst.Message_Caption_UnLock = "Unlock"
            PublicConst.Message_Caption_Backup = "Backup"
            PublicConst.Message_Caption_Restore = "Restore"
            PublicConst.Message_Caption_Confirm = "Confirm"
            PublicConst.Message_Caption_UnConfirm = "Unconfirm"
            PublicConst.Message_Caption_Run = "Run"
            PublicConst.Message_Caption_Condition = "Condition"
            PublicConst.Message_Caption_Error = "Error"
            PublicConst.Message_Caption_Help = "Help"
            PublicConst.Message_Caption_Info = "Information"
            PublicConst.Message_Caption_Warning = "Warning"

            PublicConst.Message_Successfully = "Success"
            PublicConst.Message_Warning_NotNull = " is not null."
            PublicConst.Message_Warning_ExistData = " Data is exist."
        End If
    End Sub
#End Region

#Region "Show New Form"

    'Public Sub ShowNewForm(ByVal frm As DevExpress.XtraEditors.XtraForm, Optional ByVal translate As Boolean = True)
    '    'Check ChildForm exist already.
    '    For Each Child As DevExpress.XtraEditors.XtraForm In PublicConst.DockPanel.Contents
    '        If Child.Tag = frm.Tag Then
    '            Child.Activate()
    '            Exit Sub
    '        End If
    '    Next
    '    frm.Show(PublicConst.DockPanel)
    '    'Set language
    '    If translate Then
    '        lang.ShowLanguage(frm, frm.Tag)
    '    End If
    'End Sub

    Public Sub ShowNewForm(ByVal frm As XtraForm, Optional ByVal translate As Boolean = True)
        'Check ChildForm exist already.
        Dim isExist As Boolean = False
        For Each Child As BaseDocument In PublicConst.MyTabbedView.Documents
            If Child.Form.Tag = frm.Tag Then
                'PublicConst.MyTabbedView.ActivateDocument(Child.Form)
                Child.Form.Close()
                isExist = True
                Exit For
            End If
        Next
        frm.TopLevel = False
        PublicConst.MyTabbedView.AddDocument(frm)
        'Set language
        If translate Then
            lang.ShowLanguage(frm, frm.Tag)
        End If
    End Sub

    Public Sub ShowNewForm(ByVal frmID As String, ByVal ID As String)
        ' Create a new instance of the child form.
        Dim ChildForm As New XtraForm
        Dim frm As New Main_FormRight
        frm.FormID_K = frmID
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
            ShowError(ex, "Open Form", "ShoNewFOrm")
            Return
        End Try

        'Check ChildForm exist already.
        Dim isExist As Boolean = False
        For Each Child As BaseDocument In PublicConst.MyTabbedView.Documents
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
        PublicConst.MyTabbedView.AddDocument(ChildForm)
        PublicConst.MyTabbedView.ActivateDocument(ChildForm)
    End Sub

    Public Sub ShowNewFormActive(ByVal frm As XtraForm, Optional ByVal translate As Boolean = True)
        'Check ChildForm exist already.
        Dim isExist As Boolean = False
        For Each Child As BaseDocument In PublicConst.MyTabbedView.Documents
            If Child.Form.Tag = frm.Tag Then
                PublicConst.MyTabbedView.ActivateDocument(Child.Form)
                isExist = True
                Exit For
            End If
        Next
    End Sub

    Public Function GetFormExisted(ByVal sFormName As String) As BaseDocument
        For Each Child As BaseDocument In PublicConst.MyTabbedView.Documents
            If Child.Form.Name = sFormName Then
                Return Child
            End If
        Next
        Return Nothing
    End Function

#End Region

#Region " Variable API 32bit"
    Private Declare Function GetSystemDefaultLCID Lib "kernel32" () As Integer
    Private Const LOCALE_SSHORTDATE As Short = &H1FS ' short date format string

    Public ReadOnly Property ColorOver1 As Color
        Get
            Return colorOver
        End Get
    End Property

    Private Declare Function GetLocaleInfo Lib "kernel32" Alias "GetLocaleInfoA" (ByVal Locale As Integer, ByVal LCType As Integer,
                                                                                  ByVal lpLCData As String, ByVal cchData As Integer) As Integer

#End Region

#Region "API function"
    Public Function GetDateShortLocal() As String
        Dim sReturn As String = ""
        Dim r As Integer
        Dim LCID As Integer
        LCID = GetSystemDefaultLCID()
        r = GetLocaleInfo(LCID, LOCALE_SSHORTDATE, sReturn, Len(sReturn))
        If r Then
            sReturn = Space(r)
            r = GetLocaleInfo(LCID, LOCALE_SSHORTDATE, sReturn, Len(sReturn))
            sReturn = Left(sReturn, r - 1)
        End If
        Return sReturn
    End Function
#End Region

#Region "Encryption Password MD5"
    Public Function EncryptPassword(ByVal Password As String) As String
        'Encrypt the Password       
        Dim sEncryptedPassword As String = ""
        Dim sEncryptKey As String = "P@SSW@RD@09"        'Should be minimum 8 characters       
        Try
            sEncryptedPassword = EncryptDecryptClass.EncryptPasswordMD5(Password, sEncryptKey)
        Catch ex As Exception
            Return sEncryptedPassword
        End Try
        Return sEncryptedPassword
    End Function
    Public Function DecryptPassword(ByVal Password As String) As String
        'Encrypt the Password       
        Dim sDecryptedPassword As String = ""
        Dim sEncryptKey As String = "P@SSW@RD@09" 'Should be minimum 8 characters      
        Try
            sDecryptedPassword = EncryptDecryptClass.DecryptPasswordMD5(Password, sEncryptKey)
        Catch ex As Exception
            Return sDecryptedPassword
        End Try
        Return sDecryptedPassword
    End Function
#End Region

#Region "Serialize, Deserialize"
    Public Sub BinarySerialize(ByVal filename As String, ByVal obj As Object)
        Dim fileStreamObject As FileStream
        fileStreamObject = New FileStream(filename, FileMode.Create)
        Dim binaryFormatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        binaryFormatter.Serialize(fileStreamObject, obj)
        fileStreamObject.Close()
    End Sub
    Public Function BinaryDeserialize(ByVal filename As String) As Object
        Dim fileStreamObject As New FileStream(filename, FileMode.Open)
        Dim binaryFormatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim obj As Object = binaryFormatter.Deserialize(fileStreamObject)
        fileStreamObject.Close()
        Return obj
    End Function
    Public Sub SoapSerialize(ByVal filename As String, ByVal obj As Object)
        Dim fileStreamObject As FileStream
        fileStreamObject = New FileStream(filename, FileMode.Create)
        Dim binaryFormatter As New Runtime.Serialization.Formatters.Soap.SoapFormatter()
        binaryFormatter.Serialize(fileStreamObject, obj)
        fileStreamObject.Close()
    End Sub
    Public Function SoapDeserialize(ByVal filename As String) As Object
        Dim fileStreamObject As New FileStream(filename, FileMode.Open)
        Dim binaryFormatter As New Runtime.Serialization.Formatters.Soap.SoapFormatter()
        Dim obj As Object = binaryFormatter.Deserialize(fileStreamObject)
        fileStreamObject.Close()
        Return obj
    End Function
    Public Sub XMLSerialize(ByVal filename As String, ByVal obj As Object)
        Dim fileStreamObject As FileStream
        fileStreamObject = New FileStream(filename, FileMode.Create)
        Dim binaryFormatter As New XmlSerializer(obj.GetType)
        binaryFormatter.Serialize(fileStreamObject, obj)
        fileStreamObject.Close()
    End Sub
    Public Function XMLDeserialize(ByVal filename As String, ByVal obj As Object) As Object
        Dim fileStreamObject As New FileStream(filename, FileMode.Open)
        Dim binaryFormatter As New XmlSerializer(obj.GetType)
        Dim o As Object = binaryFormatter.Deserialize(fileStreamObject)
        fileStreamObject.Close()
        Return o
    End Function


#End Region

#Region "File and Folder "

    Sub CopyChart(ByVal mChart As Chart)
        ' Create a memory stream to save the chart image    
        Dim stream As New System.IO.MemoryStream()

        ' Save the chart image to the stream    
        mChart.SaveImage(stream, System.Drawing.Imaging.ImageFormat.Bmp)

        ' Create a bitmap using the stream    
        Dim bmp As New Bitmap(stream)

        ' Save the bitmap to the clipboard    
        Clipboard.SetDataObject(bmp)
    End Sub

    Sub SaveChart(ByVal mChart As Chart)
        ' Create a new save file dialog
        ' Sets the current file name filter string, which determines 
        ' the choices that appear in the "Save as file type" or 
        ' "Files of type" box in the dialog box.
        Dim saveFileDialog1 As New SaveFileDialog With {
            .Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|EMF (*.emf)|*.emf|PNG (*.png)|*.png|GIF (*.gif)|*.gif|TIFF (*.tif)|*.tif",
            .FilterIndex = 2,
            .RestoreDirectory = True
        }

        ' Set image file format
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim format As ChartImageFormat = ChartImageFormat.Bmp

            If saveFileDialog1.FileName.EndsWith("bmp") Then
                format = ChartImageFormat.Bmp
            Else
                If saveFileDialog1.FileName.EndsWith("jpg") Then
                    format = ChartImageFormat.Jpeg
                Else
                    If saveFileDialog1.FileName.EndsWith("emf") Then
                        format = ChartImageFormat.Emf
                    Else
                        If saveFileDialog1.FileName.EndsWith("gif") Then
                            format = ChartImageFormat.Gif
                        Else
                            If saveFileDialog1.FileName.EndsWith("png") Then
                                format = ChartImageFormat.Png
                            Else
                                If saveFileDialog1.FileName.EndsWith("tif") Then
                                    format = ChartImageFormat.Tiff
                                End If
                            End If ' Save image
                        End If
                    End If
                End If
            End If
            mChart.SaveImage(saveFileDialog1.FileName, format)
        End If
    End Sub

    Private Sub DirectoryCopy(sourceDirName As String, destDirName As String, copySubDirs As Boolean)

        '// Get the subdirectories for the specified directory.
        Dim dir As DirectoryInfo = New DirectoryInfo(sourceDirName)
        Dim dirs() As DirectoryInfo = dir.GetDirectories()

        If Not dir.Exists() Then
            Throw New DirectoryNotFoundException(
                "Source directory does not exist or could not be found: " &
                 sourceDirName)
        End If

        '// If the destination directory doesn't exist, create it. 
        If (Not Directory.Exists(destDirName)) Then
            Directory.CreateDirectory(destDirName)
        End If

        ' // Get the files in the directory and copy them to the new location.
        Dim files() As FileInfo = dir.GetFiles()
        For Each file As FileInfo In files
            Dim temppath As String = Path.Combine(destDirName, file.Name)
            file.CopyTo(temppath, True)
        Next

        '// If copying subdirectories, copy them and their contents to new location. 
        If copySubDirs Then
            For Each subdir As DirectoryInfo In dirs
                Dim temppath As String = Path.Combine(destDirName, subdir.Name)
                DirectoryCopy(subdir.FullName, temppath, copySubDirs)
            Next
        End If
    End Sub

    Function ConvertFileToArrayByte(ByVal filename As String) As Byte()
        Dim fs As New FileStream(filename, FileMode.Open, FileAccess.Read)
        Dim ImageData(fs.Length) As Byte
        fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length))
        fs.Close()
        Return ImageData
    End Function

    Sub ConvertArrayByteToFile(ByVal fileName As String, ByVal Buffer() As Byte)
        If File.Exists(fileName) Then
            File.Delete(fileName)
        End If
        Dim fs = New FileStream(fileName, FileMode.Create)
        fs.Write(Buffer, 0, Buffer.Length)
        fs.Close()
    End Sub

    Function ConvertArrayByteToImage(ByVal Arraybyte As Byte()) As Image
        Dim ms As New MemoryStream(Arraybyte)
        Dim returnImage As Image = Image.FromStream(ms)
        Return returnImage
    End Function

    Function ConvertImageToByteArray(ByVal imageIn As Image) As Byte()
        Dim ms As New MemoryStream()
        imageIn.Save(ms, Imaging.ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

    Function GetImageFromArrayByte(ByVal Arraybyte As Byte()) As Image
        Dim ms As New MemoryStream(Arraybyte)
        Dim returnImage As Image = Image.FromStream(ms)
        Return returnImage
    End Function

    Function ImageToByteArray(ByVal imageIn As Image) As Byte()
        Dim ms As New MemoryStream()
        imageIn.Save(ms, Imaging.ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

    Function LoadFile() As String
        Dim ofdialog As New OpenFileDialog
        If ofdialog.ShowDialog = DialogResult.OK Then
            If File.Exists(ofdialog.FileName) Then
                Return ofdialog.FileName
            End If
        End If
        Return ""
    End Function
    ''' <summary>
    ''' Return FileName in Temp Folder
    ''' </summary>
    ''' <param name="pathFile"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function OpenfileTemp(ByVal pathFile As String) As String
        Dim tempFolder As String = Application.StartupPath + "\temp"
        Dim newfile As String = tempFolder & "\" & Path.GetFileName(pathFile)
        If Not Directory.Exists(tempFolder) Then
            Directory.CreateDirectory(tempFolder)
        End If
        Try
            File.Copy(pathFile, newfile, True)
        Catch
            Return Nothing
        End Try
        Return newfile
    End Function

    ''' <summary>
    ''' Vo Thanh Son IT
    ''' Copy file from folder to folder
    ''' </summary>
    ''' <param name="SourceFileName"></param>
    ''' <param name="DestFileName"></param>
    ''' <param name="Override"></param>
    ''' <remarks></remarks>
    Public Sub UpLoadFile(ByVal SourceFileName As String, ByVal DestFileName As String, ByVal Override As Boolean)
        Try
            If (File.Exists(SourceFileName)) Then
                'If (File.Exists(DestFileName)) Then
                '    File.SetAttributes(DestFileName, FileAttributes.Archive)
                'End If

                File.Copy(SourceFileName, DestFileName, Override)
            End If
        Catch ex As Exception
            'If ex.Message.Contains("because it is being used") Then
            '    ShowWarning("File đang mở vui lòng đóng lại !")
            'Else
            '    Throw ex
            'End If
        End Try
    End Sub
    ''' <summary>
    ''' Son IT
    ''' Open any file with current program
    ''' </summary>
    ''' <param name="sFileName"></param>
    ''' <remarks></remarks>
    Public Sub OpenFile(ByVal sFileName As String)
        Dim process As System.Diagnostics.ProcessStartInfo
        Try
            If (sFileName <> String.Empty) Then
                If (Not File.Exists(sFileName)) Then
                    XtraMessageBox.Show("File: " + sFileName + "not exist on server", "File")
                    Return
                Else
                    process = New ProcessStartInfo(sFileName) With {
                        .Verb = "open"
                    }
                    Dim sprocess = New System.Diagnostics.Process With {
                        .StartInfo = process
                    }
                    sprocess.Start()
                End If
            Else
                XtraMessageBox.Show("File not exist", "File")
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "Send Email"

    Sub SendMailOutlook(ByVal Subject As String,
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
            'myBody = olHello & body & olNewline
            If submit = PublicFunction.Submit.Confirm Then
                myBody += olApproved
            ElseIf submit = PublicFunction.Submit.Reject Then
                myBody += olReject
            ElseIf submit = PublicFunction.Submit.Info Then
                myBody += olInfo
            ElseIf submit = PublicFunction.Submit.Finished Then
                myBody += olFinished
            End If

            myBody = String.Format(myBody, body)

            'Subject 
            mail.Subject = Subject
            'Body
            If ID = "" Then
                myBody += String.Format("<br/><br/>" & "Open ERP/Mở ERP: " & String.Format("<a href=""{0}\app.bat"">Click here</a>", PublicUtility.CurrentUser.TempFolder & pathfile),
                                      tag & ID)
            Else
                myBody += String.Format("<br/><br/>" & "Open ERP/Mở ERP: " & "<a href=""{0}\{1}.bat"">Click here</a>", PublicUtility.CurrentUser.TempFolder & pathfile,
                                      tag & ID)
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


    Sub SendMailOutlookReport(ByVal Subject As String, ByVal body As String,
                        ByVal listTo As List(Of String),
                       Optional ByVal listCc As List(Of String) = Nothing,
                       Optional ByVal listBcc As List(Of String) = Nothing,
                       Optional ByVal listAttach As List(Of String) = Nothing,
                       Optional ByVal XinChao As Boolean = False)

        Try
            Dim ap As New Outlook.Application

            Dim mail As Outlook.MailItem = CType(ap.CreateItem(Outlook.OlItemType.olMailItem), Outlook.MailItem)

            Dim currentUser As Outlook.AddressEntry = ap.Session.CurrentUser.AddressEntry

            If currentUser.Type = "EX" Then
                If XinChao = False Then
                    body = olHello & body
                End If
                'Subject 
                mail.Subject = Subject
                'Body
                'body += "<br/><br/>" & "Open ERP/Mở ERP: " & "<a href=""C:\Programs_NDV\ERPNDV\ERPUpdate.exe"">Click here</a>"
                mail.HTMLBody = body

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
        Catch ex As Exception
            ShowErrorInvisible(ex, "SendmailOutLook", "PublicFunction")
        End Try
    End Sub

    Sub SendMail(person As String, sendto As Object,
                 ccto As Object, submit As Submit, Title As String,
                 comment As String, ByVal tag As String, ID As String, ByVal Month As String)


        'Kiểm tra người có thể gởi băng email outlook
        If CurrentUser.Mail.Contains("@nitto.com") Then
            Dim myTitle As String = String.Format("{0} {1}", Title, Month)
            SendMailOutlook(myTitle, comment, submit, GetListMail(sendto), GetListMail(ccto), Nothing, Nothing, tag, ID)
            Return
        End If


        CreateFileConfirm(ID, tag)

        '//Khởi tạo Lotus
        Dim notesSession As New NotesSession()
        Dim notesDataBase As NotesDatabase = Nothing
        Dim notesDocument As NotesDocument = Nothing

        '//Đăng nhập tự động với password = 12345
        notesSession.Initialize()
        'notesSession.InitializeUsingNotesUserName("tam_truongminh","minhtam");
        Dim server As String = notesSession.GetEnvironmentString("MailServer", True)
        Dim mailfile As String = notesSession.GetEnvironmentString("MailFile", True)
        Dim username As String = notesSession.GetEnvironmentString("User", True)

        notesDataBase = notesSession.GetDatabase(server, mailfile)

        If Not notesDataBase.IsOpen Then
            notesDataBase.Open()
        End If
        notesDocument = notesDataBase.CreateDocument()

        notesDocument.ReplaceItemValue("Form", "Memo")
        notesDocument.ReplaceItemValue("SendTo", "")
        notesDocument.ReplaceItemValue("CopyTo", "")
        notesDocument.ReplaceItemValue("Subject", String.Format("{0} {1}", Title, Month))

        ' //Khởi tạo richtext
        Dim strSpace As String = ""
        Dim richTextItem As NotesRichTextItem = notesDocument.CreateRichTextItem("Body")
        richTextItem.AppendText(" Dear Mr/Ms,")
        richTextItem.AddNewLine()
        richTextItem.AddNewLine()
        If submit = PublicFunction.Submit.Confirm Then
            richTextItem.AppendText(String.Format(contentApproved, person))
        Else
            richTextItem.AppendText(String.Format(contentReject, person))
        End If
        richTextItem.AddNewLine()
        richTextItem.AddNewLine()
        richTextItem.AppendText("Ghi chú (Comment): " + comment)
        richTextItem.AddNewLine()
        richTextItem.AddNewLine()
        richTextItem.AppendText("Mở file bên dưới để xem chi tiết (Please open file to show detail).")
        richTextItem.AddNewLine()
        richTextItem.AddNewLine()
        richTextItem.EmbedObject(EMBED_TYPE.EMBED_ATTACHMENT, Nothing, pathfile, Nothing)


        notesDocument.ReplaceItemValue("SendTo", sendto)
        notesDocument.ReplaceItemValue("CopyTo", ccto)
        Dim oItemValue As Object = notesDocument.GetItemValue("SendTo")

        notesDocument.Send(False, oItemValue)

        richTextItem = Nothing
        notesDocument = Nothing
        notesDataBase = Nothing
        notesSession = Nothing
    End Sub

    ''' <summary>
    ''' Hàm gởi mail phê duyệt
    ''' </summary>
    ''' <param name="person"></param>
    ''' <param name="sendto"></param>
    ''' <param name="ccto"></param>
    ''' <param name="submit"></param>
    ''' <param name="Title"></param>
    ''' <param name="comment"></param>
    ''' <param name="tag"></param>
    ''' <param name="ID"></param>
    ''' <param name="RQDate"></param>
    ''' <remarks></remarks>
    ''' 
    Sub SendMail(person As String, sendto As Object,
                 ccto As Object, submit As Submit, Title As String,
                 comment As String, ByVal tag As String, ID As String, ByVal RQDate As DateTime)


        'Kiểm tra người có thể gởi băng email outlook
        If CurrentUser.Mail.Contains("@nitto.com") Then
            Dim myTitle As String = String.Format("{0} ({1})", Title, RQDate.ToString("dd-MMM-yyyy"))
            SendMailOutlook(myTitle, comment, submit, GetListMail(sendto), GetListMail(ccto), Nothing, Nothing, tag, ID)
            Return
        End If

        CreateFileConfirm(ID, tag)

        '//Khởi tạo Lotus
        Dim notesSession As New NotesSession()
        Dim notesDataBase As NotesDatabase = Nothing
        Dim notesDocument As NotesDocument = Nothing

        '//Đăng nhập tự động với password = 12345
        notesSession.Initialize()
        'notesSession.InitializeUsingNotesUserName("tam_truongminh","minhtam");
        Dim server As String = notesSession.GetEnvironmentString("MailServer", True)
        Dim mailfile As String = notesSession.GetEnvironmentString("MailFile", True)
        Dim username As String = notesSession.GetEnvironmentString("User", True)

        notesDataBase = notesSession.GetDatabase(server, mailfile)

        If Not notesDataBase.IsOpen Then
            notesDataBase.Open()
        End If
        notesDocument = notesDataBase.CreateDocument()

        notesDocument.ReplaceItemValue("Form", "Memo")
        notesDocument.ReplaceItemValue("SendTo", "")
        notesDocument.ReplaceItemValue("CopyTo", "")
        notesDocument.ReplaceItemValue("Subject", String.Format("{0} {1}", Title, RQDate.ToString("dd-MMM-yyyy")))

        ' //Khởi tạo richtext
        Dim strSpace As String = ""
        Dim richTextItem As NotesRichTextItem = notesDocument.CreateRichTextItem("Body")
        richTextItem.AppendText(" Dear Mr/Ms,")
        richTextItem.AddNewLine()
        richTextItem.AddNewLine()
        If submit = PublicFunction.Submit.Confirm Then
            richTextItem.AppendText(String.Format(contentApproved, person))
        Else
            richTextItem.AppendText(String.Format(contentReject, person))
        End If
        richTextItem.AddNewLine()
        richTextItem.AddNewLine()
        richTextItem.AppendText("Ghi chú (Comment): " + comment)
        richTextItem.AddNewLine()
        richTextItem.AddNewLine()
        richTextItem.AppendText("Mở file bên dưới để xem chi tiết (Please open file to show detail).")
        richTextItem.AddNewLine()
        richTextItem.AddNewLine()
        richTextItem.EmbedObject(EMBED_TYPE.EMBED_ATTACHMENT, Nothing, pathfile, Nothing)


        notesDocument.ReplaceItemValue("SendTo", sendto)
        notesDocument.ReplaceItemValue("CopyTo", ccto)
        Dim oItemValue As Object = notesDocument.GetItemValue("SendTo")

        notesDocument.Send(False, oItemValue)

        richTextItem = Nothing
        notesDocument = Nothing
        notesDataBase = Nothing
        notesSession = Nothing

    End Sub

    Sub SendMailBaoCao(person As String, sendto As Object,
                 ccto As Object, submit As Submit, Title As String,
                 comment As String, ByVal tag As String, ID As String, ByVal RQDate As DateTime)


        'Kiểm tra người có thể gởi băng email outlook
        If CurrentUser.Mail.Contains("@nitto.com") Then
            Dim myTitle As String = Title
            SendMailOutlook(myTitle, comment, submit, GetListMail(sendto), GetListMail(ccto), Nothing, Nothing, tag, ID)
            Return
        End If

        CreateFileConfirm(ID, tag)

        '//Khởi tạo Lotus
        Dim notesSession As New NotesSession()
        Dim notesDataBase As NotesDatabase = Nothing
        Dim notesDocument As NotesDocument = Nothing

        '//Đăng nhập tự động với password = 12345
        notesSession.Initialize()
        'notesSession.InitializeUsingNotesUserName("tam_truongminh","minhtam");
        Dim server As String = notesSession.GetEnvironmentString("MailServer", True)
        Dim mailfile As String = notesSession.GetEnvironmentString("MailFile", True)
        Dim username As String = notesSession.GetEnvironmentString("User", True)

        notesDataBase = notesSession.GetDatabase(server, mailfile)

        If Not notesDataBase.IsOpen Then
            notesDataBase.Open()
        End If
        notesDocument = notesDataBase.CreateDocument()

        notesDocument.ReplaceItemValue("Form", "Memo")
        notesDocument.ReplaceItemValue("SendTo", "")
        notesDocument.ReplaceItemValue("CopyTo", "")
        notesDocument.ReplaceItemValue("Subject", String.Format("{0} {1}", Title, RQDate.ToString("dd-MMM-yyyy")))

        ' //Khởi tạo richtext
        Dim strSpace As String = ""
        Dim richTextItem As NotesRichTextItem = notesDocument.CreateRichTextItem("Body")
        'richTextItem.AppendText(" Dear Mr/Ms,")
        'richTextItem.AddNewLine()
        'richTextItem.AddNewLine()
        'If submit = PublicFunction.Submit.Confirm Then
        '    richTextItem.AppendText(String.Format(contentApproved, person))
        'Else
        '    richTextItem.AppendText(String.Format(contentReject, person))
        'End If
        'richTextItem.AddNewLine()
        'richTextItem.AddNewLine()
        richTextItem.AppendText(comment)
        richTextItem.AddNewLine()
        richTextItem.AddNewLine()
        'richTextItem.AppendText("Mở file bên dưới để xem chi tiết (Please open file to show detail).")
        'richTextItem.AddNewLine()
        'richTextItem.AddNewLine()
        richTextItem.EmbedObject(EMBED_TYPE.EMBED_ATTACHMENT, Nothing, pathfile, Nothing)

        notesDocument.ReplaceItemValue("SendTo", sendto)
        notesDocument.ReplaceItemValue("CopyTo", ccto)
        Dim oItemValue As Object = notesDocument.GetItemValue("SendTo")

        notesDocument.Send(False, oItemValue)

        richTextItem = Nothing
        notesDocument = Nothing
        notesDataBase = Nothing
        notesSession = Nothing
    End Sub

    Sub SendMailBaoCao(person As String, sendto As Object,
                 ccto As Object, submit As Submit, Title As String,
                 comment As String, ByVal tag As String, ID As String, ByVal DayMonth As String)

        'Kiểm tra người có thể gởi băng email outlook
        If CurrentUser.Mail.Contains("@nitto.com") Then
            Dim myTitle As String = Title
            SendMailOutlook(myTitle, comment, Submit.None, GetListMail(sendto), GetListMail(ccto), Nothing, Nothing, tag, ID)
            Return
        End If

        CreateFileConfirm(ID, tag)

        '//Khởi tạo Lotus
        Dim notesSession As New NotesSession()
        Dim notesDataBase As NotesDatabase = Nothing
        Dim notesDocument As NotesDocument = Nothing

        '//Đăng nhập tự động với password = 12345
        notesSession.Initialize()
        'notesSession.InitializeUsingNotesUserName("tam_truongminh","minhtam");
        Dim server As String = notesSession.GetEnvironmentString("MailServer", True)
        Dim mailfile As String = notesSession.GetEnvironmentString("MailFile", True)
        Dim username As String = notesSession.GetEnvironmentString("User", True)

        notesDataBase = notesSession.GetDatabase(server, mailfile)

        If Not notesDataBase.IsOpen Then
            notesDataBase.Open()
        End If
        notesDocument = notesDataBase.CreateDocument()

        notesDocument.ReplaceItemValue("Form", "Memo")
        notesDocument.ReplaceItemValue("SendTo", "")
        notesDocument.ReplaceItemValue("CopyTo", "")
        notesDocument.ReplaceItemValue("Subject", String.Format("{0} {1}", Title, DayMonth))

        ' //Khởi tạo richtext
        Dim strSpace As String = ""
        Dim richTextItem As NotesRichTextItem = notesDocument.CreateRichTextItem("Body")
        'richTextItem.AppendText(" Dear Mr/Ms,")
        'richTextItem.AddNewLine()
        'richTextItem.AddNewLine()
        'If submit = PublicFunction.Submit.Confirm Then
        '    richTextItem.AppendText(String.Format(contentApproved, person))
        'Else
        '    richTextItem.AppendText(String.Format(contentReject, person))
        'End If
        'richTextItem.AddNewLine()
        'richTextItem.AddNewLine()
        richTextItem.AppendText(comment)
        richTextItem.AddNewLine()
        richTextItem.AddNewLine()
        'richTextItem.AppendText("Mở file bên dưới để xem chi tiết (Please open file to show detail).")
        'richTextItem.AddNewLine()
        'richTextItem.AddNewLine()
        richTextItem.EmbedObject(EMBED_TYPE.EMBED_ATTACHMENT, Nothing, pathfile, Nothing)

        notesDocument.ReplaceItemValue("SendTo", sendto)
        notesDocument.ReplaceItemValue("CopyTo", ccto)
        Dim oItemValue As Object = notesDocument.GetItemValue("SendTo")

        notesDocument.Send(False, oItemValue)

        richTextItem = Nothing
        notesDocument = Nothing
        notesDataBase = Nothing
        notesSession = Nothing
    End Sub

    Sub SendMailBaoCaoAttach(person As String, sendto As Object,
                 ccto As Object, submit As Submit, Title As String,
                 comment As String, myfile1 As String, myfile2 As String)


        'Kiểm tra người có thể gởi băng email outlook
        If CurrentUser.Mail.Contains("@nitto.com") Then
            Dim myTitle As String = String.Format("{0} {1}", Title, "")
            SendMailOutlookReport(myTitle, comment, GetListMail(sendto), GetListMail(ccto), Nothing, GetListFile(myfile1 & "," & myfile2))
            Return
        End If

        'CreateFileConfirm(ID, tag)

        '//Khởi tạo Lotus
        Dim notesSession As New NotesSession()
        Dim notesDataBase As NotesDatabase = Nothing
        Dim notesDocument As NotesDocument = Nothing

        '//Đăng nhập tự động với password = 12345
        notesSession.Initialize()
        'notesSession.InitializeUsingNotesUserName("tam_truongminh","minhtam");
        Dim server As String = notesSession.GetEnvironmentString("MailServer", True)
        Dim mailfile As String = notesSession.GetEnvironmentString("MailFile", True)
        Dim username As String = notesSession.GetEnvironmentString("User", True)

        notesDataBase = notesSession.GetDatabase(server, mailfile)

        If Not notesDataBase.IsOpen Then
            notesDataBase.Open()
        End If
        notesDocument = notesDataBase.CreateDocument()

        notesDocument.ReplaceItemValue("Form", "Memo")
        notesDocument.ReplaceItemValue("SendTo", "")
        notesDocument.ReplaceItemValue("CopyTo", "")
        notesDocument.ReplaceItemValue("Subject", String.Format("{0} {1}", Title, ""))

        ' //Khởi tạo richtext
        Dim strSpace As String = ""
        Dim richTextItem As NotesRichTextItem = notesDocument.CreateRichTextItem("Body")
        'richTextItem.AppendText(" Dear Mr/Ms,")
        'richTextItem.AddNewLine()
        'richTextItem.AddNewLine()
        'If submit = PublicFunction.Submit.Confirm Then
        '    richTextItem.AppendText(String.Format(contentApproved, person))
        'Else
        '    richTextItem.AppendText(String.Format(contentReject, person))
        'End If
        'richTextItem.AddNewLine()
        'richTextItem.AddNewLine()
        richTextItem.AppendText(comment)
        richTextItem.AddNewLine()
        richTextItem.AddNewLine()
        'richTextItem.AppendText("Mở file bên dưới để xem chi tiết (Please open file to show detail).")
        'richTextItem.AddNewLine()
        'richTextItem.AddNewLine()
        richTextItem.AppendText("Hàng 4 số: ")
        If File.Exists(myfile1) Then
            richTextItem.EmbedObject(EMBED_TYPE.EMBED_ATTACHMENT, Nothing, myfile1, Nothing)
        End If
        richTextItem.AddNewLine()
        richTextItem.AddNewLine()
        richTextItem.AppendText("Hàng 5 số: ")
        If File.Exists(myfile2) Then
            richTextItem.EmbedObject(EMBED_TYPE.EMBED_ATTACHMENT, Nothing, myfile2, Nothing)
        End If

        notesDocument.ReplaceItemValue("SendTo", sendto)
        notesDocument.ReplaceItemValue("CopyTo", ccto)
        Dim oItemValue As Object = notesDocument.GetItemValue("SendTo")

        notesDocument.Send(False, oItemValue)

        richTextItem = Nothing
        notesDocument = Nothing
        notesDataBase = Nothing
        notesSession = Nothing
    End Sub

    ''' <summary>
    ''' Hàm gởi mail thông báo HR Report...
    ''' </summary>
    ''' <param name="person"></param>
    ''' <param name="sendto"></param>
    ''' <param name="ccto"></param>
    ''' <param name="Title"></param>
    ''' <param name="content"></param>
    ''' <param name="tag"></param>
    ''' <param name="ID"></param>
    ''' <param name="RQDate"></param>
    ''' <remarks></remarks>
    Sub SendMailInfo(person As String, sendto As Object,
             ccto As Object, Title As String,
             content As String, ByVal tag As String, ID As String, ByVal RQDate As DateTime, ByVal attachFile As String)


        'Kiểm tra người có thể gởi băng email outlook
        If CurrentUser.Mail.Contains("@nitto.com") Then
            Dim myTitle As String = Title
            SendMailOutlookReport(myTitle, content, GetListMail(sendto), GetListMail(ccto), Nothing, GetListFile(attachFile), False)

            Return
        End If

        If ID <> "" Then
            CreateFileConfirm(ID, tag)
        End If
        '//Khởi tạo Lotus
        Dim notesSession As New NotesSession()
        Dim notesDataBase As NotesDatabase = Nothing
        Dim notesDocument As NotesDocument = Nothing

        '//Đăng nhập tự động với password = 12345
        notesSession.Initialize()
        'notesSession.InitializeUsingNotesUserName("tam_truongminh","minhtam");
        Dim server As String = notesSession.GetEnvironmentString("MailServer", True)
        Dim mailfile As String = notesSession.GetEnvironmentString("MailFile", True)
        Dim username As String = notesSession.GetEnvironmentString("User", True)

        notesDataBase = notesSession.GetDatabase(server, mailfile)

        If Not notesDataBase.IsOpen Then
            notesDataBase.Open()
        End If
        notesDocument = notesDataBase.CreateDocument()

        notesDocument.ReplaceItemValue("Form", "Memo")
        notesDocument.ReplaceItemValue("SendTo", "")
        notesDocument.ReplaceItemValue("CopyTo", "")
        notesDocument.ReplaceItemValue("Subject", String.Format("{0} {1}", Title, ""))

        ' //Khởi tạo richtext
        Dim strSpace As String = ""
        Dim richTextItem As NotesRichTextItem = notesDocument.CreateRichTextItem("Body")
        'richTextItem.AppendText(" Dear All,")
        'richTextItem.AddNewLine()
        'richTextItem.AddNewLine()
        'richTextItem.AppendText(String.Format(contentInfor, person))
        'richTextItem.AddNewLine()
        'richTextItem.AddNewLine()
        richTextItem.AppendText(content)
        richTextItem.AddNewLine()
        richTextItem.AddNewLine()
        If File.Exists(attachFile) Then
            richTextItem.EmbedObject(EMBED_TYPE.EMBED_ATTACHMENT, Nothing, attachFile, Nothing)
        Else
            If File.Exists(pathfile) Then
                richTextItem.EmbedObject(EMBED_TYPE.EMBED_ATTACHMENT, Nothing, pathfile, Nothing)
            End If
        End If
        'richTextItem.AddNewLine()
        'richTextItem.AddNewLine()
        'richTextItem.AppendText("Mở file bên dưới để xem chi tiết (Please open file show detail).")
        'richTextItem.AddNewLine()
        'richTextItem.AddNewLine()
        'richTextItem.EmbedObject(EMBED_TYPE.EMBED_ATTACHMENT, Nothing, pathfile, Nothing)


        notesDocument.ReplaceItemValue("SendTo", sendto)
        notesDocument.ReplaceItemValue("CopyTo", ccto)
        Dim oItemValue As Object = notesDocument.GetItemValue("SendTo")

        notesDocument.Send(False, oItemValue)

        richTextItem = Nothing
        notesDocument = Nothing
        notesDataBase = Nothing
        notesSession = Nothing
    End Sub

    ''' <summary>
    ''' Hàm gởi mail thông báo đánh giá nhân viên...
    ''' </summary>
    ''' <param name="person"></param>
    ''' <param name="sendto"></param>
    ''' <param name="ccto"></param>
    ''' <param name="Title"></param>
    ''' <param name="content"></param>
    Sub SendMailHRAssissment(person As String, sendto As Object,
             ccto As Object, Title As String,
             content As String, ByVal MMYY As String)

        'Kiểm tra người có thể gởi băng email outlook
        If CurrentUser.Mail.Contains("@nitto.com") Then
            Dim myTitle As String = Title
            SendMailOutlookReport(myTitle, content, GetListMail(sendto), GetListMail(ccto), Nothing, Nothing, False)
            Return
        End If
        '//Khởi tạo Lotus
        Dim notesSession As New NotesSession()
        Dim notesDataBase As NotesDatabase = Nothing
        Dim notesDocument As NotesDocument = Nothing

        '//Đăng nhập tự động với password = 12345
        notesSession.Initialize()
        'notesSession.InitializeUsingNotesUserName("tam_truongminh","minhtam");
        Dim server As String = notesSession.GetEnvironmentString("MailServer", True)
        Dim mailfile As String = notesSession.GetEnvironmentString("MailFile", True)
        Dim username As String = notesSession.GetEnvironmentString("User", True)

        notesDataBase = notesSession.GetDatabase(server, mailfile)

        If Not notesDataBase.IsOpen Then
            notesDataBase.Open()
        End If
        notesDocument = notesDataBase.CreateDocument()

        notesDocument.ReplaceItemValue("Form", "Memo")
        notesDocument.ReplaceItemValue("SendTo", "")
        notesDocument.ReplaceItemValue("CopyTo", "")
        notesDocument.ReplaceItemValue("Subject", String.Format("{0} [{1}]", Title, MMYY))

        ' //Khởi tạo richtext
        Dim strSpace As String = ""
        Dim richTextItem As NotesRichTextItem = notesDocument.CreateRichTextItem("Body")
        richTextItem.AppendText(" Dear All,")
        richTextItem.AddNewLine()
        richTextItem.AddNewLine()
        richTextItem.AppendText(content)
        richTextItem.AddNewLine()
        richTextItem.AddNewLine()
        'If attachFile <> "" Then
        '    richTextItem.EmbedObject(EMBED_TYPE.EMBED_ATTACHMENT, Nothing, attachFile, Nothing)
        'End If
        'richTextItem.AddNewLine()
        'richTextItem.AddNewLine()
        'richTextItem.AppendText("Mở file bên dưới để xem chi tiết (Please open file to show detail).")
        'richTextItem.AddNewLine()
        'richTextItem.AddNewLine()
        'richTextItem.EmbedObject(EMBED_TYPE.EMBED_ATTACHMENT, Nothing, pathfile, Nothing)


        notesDocument.ReplaceItemValue("SendTo", sendto)
        notesDocument.ReplaceItemValue("CopyTo", ccto)
        Dim oItemValue As Object = notesDocument.GetItemValue("SendTo")

        notesDocument.Send(False, oItemValue)

        richTextItem = Nothing
        notesDocument = Nothing
        notesDataBase = Nothing
        notesSession = Nothing
    End Sub

    Sub CreateFileConfirm(ByVal ID As String, ByVal tag As String)
        Dim line1 As String = "@echo off"
        Dim line2 As String = String.Format("start C:\Programs_NDV\ERPNDV\ERPUpdate.exe {0},{1}", tag, ID)
        Dim line3 As String = "exit"
        Dim mFile As String = CurrentUser.TempFolder & pathfile & tag & ID & ".bat"
        If File.Exists(mFile) Then
            Return
        Else
            If Not Directory.Exists(CurrentUser.TempFolder & pathfile) Then
                Directory.CreateDirectory(CurrentUser.TempFolder & pathfile)
            End If
        End If
        PublicFunction.WriteLineEnd(mFile, line1)
        PublicFunction.WriteLineEnd(mFile, String.Format(line2, ID.Trim()))
        PublicFunction.WriteLineEnd(mFile, line3)
    End Sub
#End Region

#Region "Add char, string "
    ' <Extension>
    Public Sub GetNextChar(ByRef c As Char)

        'Remember if input is uppercase for later
        Dim isUpper = Char.IsUpper(c)

        'Work in lower case for ease
        c = Char.ToLower(c)

        'Check input range
        If c < "a" Or c > "z" Then Throw New ArgumentOutOfRangeException

        'Do the increment
        c = Chr(Asc(c) + 1)

        'Check not left alphabet
        If c > "z" Then c = "a"

        'Check if input was upper case
        If isUpper Then c = Char.ToUpper(c)

    End Sub

    Public Function AddLeft(ByVal charAdd As String, ByVal Value As String, ByVal length As Integer) As String
        Return Value.PadLeft(length, charAdd)
    End Function

    Public Function AddRight(ByVal charAdd As String, ByVal Value As String, ByVal length As Integer) As String
        Return Value.PadRight(length, charAdd)
    End Function
    ''' <summary>
    ''' Return '01,'02','03'
    ''' </summary>
    ''' <param name="table"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCodeString(ByVal table As DataTable) As String
        Dim strCode As String = ""
        If table Is Nothing Then Return strCode
        If table.Rows.Count > 0 Then
            For Each row As DataRow In table.Rows
                strCode += "'" & row(0) & "',"
            Next
            If strCode.Length > 0 Then
                strCode = strCode.Substring(0, strCode.Length - 1)
            End If
            Return strCode
        Else
            Return strCode
        End If
    End Function
    ''' <summary>
    ''' Return 01,02,03
    ''' </summary>
    ''' <param name="lst"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCodeString(ByVal lst As List(Of String)) As String
        Dim strCode As String = ""
        If lst.Count = 0 Then Return strCode
        For Each item As String In lst
            strCode += item & ","
        Next
        If strCode.Length > 0 Then
            strCode = strCode.Substring(0, strCode.Length - 1)
        End If
        Return strCode
    End Function
    Public Function Left(ByVal str As String, ByVal length As Integer) As String
        Return Microsoft.VisualBasic.Left(str, length)
    End Function

    Public Function Right(ByVal str As String, ByVal length As Integer) As String
        Return Microsoft.VisualBasic.Right(str, length)
    End Function

    Public Function GetStringName() As String
        Return DateTime.Now.ToString("yyyyMMddHHmmss")
    End Function
#End Region

#Region "Drawing"

    Sub FillControl(ByVal X As Integer, ByVal Y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim rectange As New System.Drawing.Rectangle(X, Y, width, height)
        Dim brush As New LinearGradientBrush(rectange, Color.White, Color.YellowGreen, LinearGradientMode.Horizontal)
        e.Graphics.FillRectangle(brush, rectange)
    End Sub

    Sub FillForm(ByVal X As Integer, ByVal Y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim rectange As New System.Drawing.Rectangle(X, Y, width, height)
        Dim brush As New LinearGradientBrush(rectange, Color.White, Color.YellowGreen, LinearGradientMode.Horizontal)
        e.Graphics.FillRectangle(brush, rectange)
    End Sub
    Sub FillControl(ByVal X As Integer, ByVal Y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal color1 As Color, ByVal color2 As Color, ByVal lineMode As LinearGradientMode, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim rectange As New System.Drawing.Rectangle(X, Y, width, height)
        Dim brush As New LinearGradientBrush(rectange, Color.White, Color.YellowGreen, LinearGradientMode.Horizontal)
        e.Graphics.FillRectangle(brush, rectange)
    End Sub
#End Region

#Region "Set color"
    Public Sub SetColorEnter(ByVal textBox As System.Windows.Forms.TextBox)
        textBox.BackColor = PublicConst.Color_Entry_Text
        textBox.SelectAll()
    End Sub
    Sub SetColorLeave(ByVal textBox As System.Windows.Forms.TextBox)
        textBox.BackColor = PublicConst.Color_Leave_Text
    End Sub
    Public Sub SetColorEnter(ByVal combo As Windows.Forms.ComboBox)
        combo.BackColor = PublicConst.Color_Entry_Text
        combo.SelectAll()
    End Sub
    Sub SetColorLeave(ByVal combo As Windows.Forms.ComboBox)
        combo.BackColor = PublicConst.Color_Leave_Text
    End Sub
    Public Sub SetColorEnter(ByVal maskBox As MaskedTextBox)
        maskBox.BackColor = PublicConst.Color_Entry_Text
        maskBox.Focus()
        maskBox.SelectAll()
    End Sub
    Sub SetColorLeave(ByVal maskBox As MaskedTextBox)
        maskBox.BackColor = PublicConst.Color_Leave_Text
    End Sub

    Function GetColor(ByVal index As Integer) As Color
        Select Case index
            Case 0
                Return Color.MediumVioletRed
            Case 1
                Return Color.BlueViolet
            Case 2
                Return Color.GreenYellow
            Case 3
                Return Color.Orange
            Case 4
                Return Color.MediumOrchid
            Case 5
                Return Color.Green
            Case 6
                Return Color.GreenYellow
            Case 7
                Return Color.LightBlue
            Case 8
                Return Color.LightGreen
            Case 9
                Return Color.LightPink
            Case 10
                Return Color.LightGray
            Case 11
                Return Color.AliceBlue
            Case 12
                Return Color.AntiqueWhite
            Case 13
                Return Color.Aqua
            Case 14
                Return Color.Aquamarine
            Case 15
                Return Color.Azure
            Case 16
                Return Color.Beige
            Case 17
                Return Color.Bisque
            Case 18
                Return Color.WhiteSmoke
            Case 19
                Return Color.BlanchedAlmond
            Case 20
                Return Color.BlueViolet
            Case 21
                Return Color.Brown
            Case 22
                Return Color.BurlyWood
            Case 23
                Return Color.CadetBlue
            Case 24
                Return Color.Chartreuse
            Case 25
                Return Color.Chocolate
            Case 26
                Return Color.Coral
            Case 27
                Return Color.CornflowerBlue
            Case 28
                Return Color.Cornsilk
            Case 29
                Return Color.Crimson
            Case 30
                Return Color.Cyan
            Case 31
                Return Color.BlueViolet
            Case 32
                Return Color.Cyan
            Case 33
                Return Color.Goldenrod
            Case 34
                Return Color.Gray
            Case 35
                Return Color.Honeydew
            Case 36
                Return Color.Khaki
            Case 37
                Return Color.Magenta
            Case 38
                Return Color.LawnGreen
            Case 39
                Return Color.PaleGreen
            Case 40
                Return Color.PaleGoldenrod
            Case 41
                Return Color.PowderBlue
            Case 42
                Return Color.Salmon
            Case 43
                Return Color.SeaGreen
            Case 44
                Return Color.SlateBlue
            Case 45
                Return Color.SlateGray
            Case 46
                Return Color.Turquoise
            Case 47
                Return Color.Turquoise
            Case 48
                Return Color.DeepPink
            Case 49
                Return Color.DeepSkyBlue
            Case 50
                Return Color.DimGray
            Case 51
                Return Color.DodgerBlue
            Case 52
                Return Color.Firebrick
            Case 53
                Return Color.FloralWhite
            Case 54
                Return Color.ForestGreen
            Case 55
                Return Color.Fuchsia
            Case 56
                Return Color.Gainsboro
            Case 57
                Return Color.GhostWhite
            Case 58
                Return Color.Gold
            Case 59
                Return Color.Goldenrod
            Case 60
                Return Color.Gray
            Case 61
                Return Color.Green
            Case 62
                Return Color.GreenYellow
            Case 63
                Return Color.Honeydew
            Case 64
                Return Color.HotPink
            Case 65
                Return Color.IndianRed
            Case 66
                Return Color.Indigo
            Case 67
                Return Color.Ivory
            Case 68
                Return Color.Khaki
            Case 69
                Return Color.Lavender
            Case 70
                Return Color.LavenderBlush
            Case 71
                Return Color.LawnGreen
            Case 72
                Return Color.LemonChiffon
            Case 73
                Return Color.LightBlue
            Case 74
                Return Color.LightCoral
            Case 75
                Return Color.LightCyan
            Case 76
                Return Color.LightGoldenrodYellow
            Case 77
                Return Color.LightGray
            Case 78
                Return Color.LightGreen
            Case 79
                Return Color.LightPink
            Case 80
                Return Color.LightSalmon
            Case 81
                Return Color.LightSeaGreen
            Case 82
                Return Color.LightSkyBlue
            Case 83
                Return Color.LightSlateGray
            Case 84
                Return Color.LightSteelBlue
            Case 85
                Return Color.LightYellow
            Case 86
                Return Color.Lime
            Case 87
                Return Color.LimeGreen
        End Select

    End Function

    Function GetColor(ByVal code As String) As Color
        Select Case code
            Case "001"
                Return Color.Black
            Case "002"
                Return Color.Goldenrod
            Case "003"
                Return Color.BlueViolet
            Case "004"
                Return Color.Brown
            Case "005"
                Return Color.Chocolate
            Case "006"
                Return Color.DarkBlue
            Case "007"
                Return Color.DarkGray
            Case "009"
                Return Color.DarkGreen
            Case "011"
                Return Color.DarkOrange
            Case "012"
                Return Color.DarkOrchid
            Case "013"
                Return Color.DarkRed
            Case "016"
                Return Color.DarkViolet
            Case "017"
                Return Color.DeepPink
            Case "018"
                Return Color.DeepSkyBlue
            Case "021"
                Return Color.Gold
            Case "024"
                Return Color.Gray
            Case "025"
                Return Color.Green
            Case "101"
                Return Color.GreenYellow
            Case "102"
                Return Color.HotPink
            Case "103"
                Return Color.IndianRed
            Case "104"
                Return Color.LemonChiffon
            Case "105"
                Return Color.LightBlue
            Case "106"
                Return Color.LightGreen
            Case "107"
                Return Color.LightPink
            Case "108"
                Return Color.LimeGreen
            Case "109"
                Return Color.Magenta
            Case "110"
                Return Color.MediumOrchid
            Case "111"
                Return Color.MediumSeaGreen
            Case "112"
                Return Color.Olive
            Case "113"
                Return Color.Orange
            Case "115"
                Return Color.OrangeRed
            Case "117"
                Return Color.Orchid
            Case "118"
                Return Color.Peru
            Case "122"
                Return Color.Pink
            Case "123"
                Return Color.Purple
            Case "125"
                Return Color.LightGray
            Case "126"
                Return Color.SeaGreen
            Case "127"
                Return Color.Silver
            Case "130"
                Return Color.SkyBlue
            Case "201"
                Return Color.SpringGreen
            Case "202"
                Return Color.Teal
            Case "204"
                Return Color.Thistle
            Case "205"
                Return Color.Tomato
            Case "206"
                Return Color.Turquoise
            Case "207"
                Return Color.Violet
            Case "208"
                Return Color.Yellow
            Case "209"
                Return Color.YellowGreen
            Case "219"
                Return Color.DarkViolet
            Case "225"
                Return Color.DeepPink
            Case "234"
                Return Color.DeepSkyBlue
            Case "401"
                Return Color.DimGray
            Case "402"
                Return Color.DodgerBlue
            Case "403"
                Return Color.Firebrick
            Case "404"
                Return Color.PeachPuff
            Case "409"
                Return Color.ForestGreen
            Case "410"
                Return Color.Fuchsia
            Case "411"
                Return Color.Gainsboro
            Case "412"
                Return Color.Peru
            Case "414"
                Return Color.Gold
            Case "415"
                Return Color.Blue
            Case "416"
                Return Color.Gray
            Case "419"
                Return Color.Green
            Case "422"
                Return Color.SkyBlue
            Case "423"
                Return Color.Plum
            Case "429"
                Return Color.HotPink
            Case "430"
                Return Color.IndianRed
            Case "431"
                Return Color.Indigo
            Case "501"
                Return Color.PowderBlue
            Case "505"
                Return Color.Khaki
            Case "506"
                Return Color.Lavender
            Case "507"
                Return Color.SeaGreen
            Case "509"
                Return Color.SlateGray
            Case "513"
                Return Color.LemonChiffon
            Case "601"
                Return Color.LightBlue
            Case "602"
                Return Color.Purple
            Case "603"
                Return Color.LightCyan
            Case "604"
                Return Color.RoyalBlue
            Case "607"
                Return Color.Red
            Case "608"
                Return Color.LightGreen
            Case "610"
                Return Color.Yellow
            Case "619"
                Return Color.LightSalmon
            Case "627"
                Return Color.LightSeaGreen
            Case "629"
                Return Color.LightSkyBlue
            Case "634"
                Return Color.LightSlateGray
            Case "635"
                Return Color.LightSteelBlue
            Case "636"
                Return Color.RosyBrown
            Case "637"
                Return Color.Lime
            Case "639"
                Return Color.LimeGreen
            Case "641"
                Return Color.Linen
            Case "642"
                Return Color.Magenta
            Case "649"
                Return Color.Maroon
            Case "656"
                Return Color.MediumAquamarine
            Case "664"
                Return Color.MediumBlue
            Case "676"
                Return Color.MediumOrchid
            Case "679"
                Return Color.MediumPurple
            Case "680"
                Return Color.MediumSeaGreen
            Case "681"
                Return Color.MediumSlateBlue
            Case "703"
                Return Color.MediumSpringGreen
            Case "724"
                Return Color.MediumVioletRed
            Case "725"
                Return Color.MidnightBlue
            Case "980"
                Return Color.MintCream
            Case "981"
                Return Color.MistyRose
            Case "982"
                Return Color.Moccasin
            Case "983"
                Return Color.NavajoWhite
            Case "987"
                Return Color.Navy
        End Select

    End Function

    Function GetListColor() As List(Of Color)
        Dim colors As New List(Of Color)
        Dim names As New List(Of String)

        For Each c As KnownColor In [Enum].GetValues(GetType(KnownColor))
            colors.Add(Color.FromKnownColor(c))
            names.Add([Enum].GetName(GetType(KnownColor), c))
        Next
        Return colors
    End Function

    Function GetListColorName() As List(Of String)
        Dim colors As New List(Of Color)
        Dim names As New List(Of String)

        For Each c As KnownColor In [Enum].GetValues(GetType(KnownColor))
            colors.Add(Color.FromKnownColor(c))
            names.Add([Enum].GetName(GetType(KnownColor), c))
        Next
        Return names
    End Function
#End Region

#Region "Show message"

    Function ShowQuestionGetData(Optional ByVal info As String = "") As DialogResult

        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_Getdata, info),
                               PublicConst.Message_Caption_Getdata,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question)


    End Function
    Function ShowQuestionGetDataAgain(Optional ByVal info As String = "") As DialogResult

        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_GetdataAgain, info),
                               PublicConst.Message_Caption_Getdata,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question)


    End Function
    Function ShowQuestion(ByVal info As String) As DialogResult
        Return XtraMessageBox.Show(info, "Xác nhận", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

    End Function
    Function ShowQuestionSave(Optional ByVal info As String = "") As DialogResult
        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_Save, info),
                               PublicConst.Message_Caption_Save, MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

    End Function
    Function ShowQuestionDelete(Optional ByVal info As String = "") As DialogResult
        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_Delete, info),
                               PublicConst.Message_Caption_Delete, MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    End Function
    Function ShowQuestionUpdate(Optional ByVal info As String = "") As DialogResult
        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_Update, info),
                               PublicConst.Message_Caption_Update,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    End Function
    Function ShowQuestionInsert(Optional ByVal info As String = "") As DialogResult
        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_Insert, 0),
                               PublicConst.Message_Caption_Insert,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1)
    End Function
    Function ShowQuestionImport(Optional ByVal info As String = "") As DialogResult
        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_Import, info),
                               PublicConst.Message_Caption_Import,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1)
    End Function
    Function ShowQuestionExport(Optional ByVal info As String = "") As DialogResult
        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_Export, info),
                               PublicConst.Message_Caption_Export,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1)
    End Function
    Function ShowQuestionPrint(Optional ByVal info As String = "") As DialogResult
        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_Print, info),
                               PublicConst.Message_Caption_Print,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1)
    End Function
    Function ShowQuestionExit(Optional ByVal info As String = "") As DialogResult
        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_Exit, info),
                               PublicConst.Message_Caption_Exit,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1)
    End Function
    Function ShowQuestionLock(Optional ByVal info As String = "") As DialogResult
        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_Lock, info),
                               PublicConst.Message_Caption_Lock,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1)
    End Function
    Function ShowQuestionUnLock(Optional ByVal info As String = "") As DialogResult
        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_UnLock, info),
                               PublicConst.Message_Caption_Confirm,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1)
    End Function
    Function ShowQuestionConfirm(Optional ByVal info As String = "") As DialogResult
        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_Confirm, info),
                               PublicConst.Message_Caption_Confirm,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1)
    End Function
    Function ShowQuestionUnConfirm(Optional ByVal info As String = "") As DialogResult
        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_UnConfirm, info),
                               PublicConst.Message_Caption_Confirm,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1)
    End Function
    Function ShowQuestionBackup(Optional ByVal info As String = "") As DialogResult
        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_Backup, info),
                               PublicConst.Message_Caption_Confirm,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1)
    End Function
    Function ShowQuestionRestore(Optional ByVal info As String = "") As DialogResult
        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_Restore, info),
                               PublicConst.Message_Caption_Confirm,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1)
    End Function
    Function ShowQuestionRun(Optional ByVal info As String = "") As DialogResult

        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_Run, info),
                               PublicConst.Message_Caption_Run,
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button1)

    End Function
    Function ShowQuestionRunAgain(Optional ByVal info As String = "") As DialogResult

        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_RunAgain, info),
                               PublicConst.Message_Caption_Run,
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button1)

    End Function
    Function ShowQuestionBack(Optional ByVal info As String = "") As DialogResult
        Return XtraMessageBox.Show(String.Format(PublicConst.Message_Question_Back, info),
                               PublicConst.Message_Caption_Back,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1)
    End Function
    'Warning mesage==============================================================================================================
    Sub ShowWarning(ByVal infor As String)
        XtraMessageBox.Show(infor, PublicConst.Message_Caption_Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Sub ShowWarningNotDataImport()
        XtraMessageBox.Show("Không có dữ liệu import ! Vui lòng thử copy qua sheet mới.", PublicConst.Message_Caption_Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Sub ShowWarningNotNull(ByVal columName As String)
        XtraMessageBox.Show(String.Format(PublicConst.Message_Warning_NotNull, columName), PublicConst.Message_Caption_Warning,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Sub ShowWarningNotEmpty(ByVal columName As String)
        XtraMessageBox.Show(String.Format(PublicConst.Message_Warning_NotEmpty, columName), PublicConst.Message_Caption_Warning,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Sub ShowWarningLength(ByVal columName As String, ByVal length As Integer)
        XtraMessageBox.Show(String.Format(PublicConst.Message_Warning_Length, columName, length), PublicConst.Message_Caption_Warning,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Sub ShowWarningLocked(Optional ByVal infor As String = "Data")
        XtraMessageBox.Show(String.Format(PublicConst.Message_Warning_Locked, infor), PublicConst.Message_Caption_Warning,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Sub ShowWarningNotConfirm(ByVal infor As String)
        XtraMessageBox.Show(String.Format(PublicConst.Message_Warning_NotConfirm, infor), PublicConst.Message_Caption_Warning,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Sub ShowWarningLockedBefore(ByVal infor As String)
        XtraMessageBox.Show(String.Format(PublicConst.Message_Warning_LockedBefore, infor), PublicConst.Message_Caption_Warning,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Sub ShowWarningExistData(ByVal infor As String)
        XtraMessageBox.Show(String.Format(PublicConst.Message_Warning_ExistData, infor), PublicConst.Message_Caption_Warning,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Sub ShowWarningNotModify(ByVal infor As String)
        XtraMessageBox.Show(String.Format(PublicConst.Message_Warning_CanNotModify, infor), PublicConst.Message_Caption_Warning,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Sub ShowWarningMustDigit(ByVal infor As String)
        XtraMessageBox.Show(String.Format(PublicConst.Message_Warning_MustDigit, infor), PublicConst.Message_Caption_Warning,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Sub ShowWarningMustString(ByVal infor As String)
        XtraMessageBox.Show(String.Format(PublicConst.Message_Warning_MustChar, infor), PublicConst.Message_Caption_Warning,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Sub ShowWarningNotCorrect(ByVal infor As String)
        XtraMessageBox.Show(String.Format(PublicConst.Message_Warning_NotCorrect, infor), PublicConst.Message_Caption_Warning,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Sub ShowWarningABMustDiff(ByVal infor As String)
        XtraMessageBox.Show(String.Format(PublicConst.Message_Warning_MustDiff, infor), PublicConst.Message_Caption_Warning,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Sub ShowWarningMustSame(ByVal infor As String)
        XtraMessageBox.Show(String.Format(PublicConst.Message_Warning_MustDiff, infor), PublicConst.Message_Caption_Warning,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    'Success mesage==============================================================================================================
    Sub ShowSuccess()
        XtraMessageBox.Show(PublicConst.Message_Successfully, PublicConst.Message_Caption_Info,
                        MessageBoxButtons.OK, MessageBoxIcon.None)
    End Sub
    Sub ShowSuccess(ByVal rowNumber As Integer)
        XtraMessageBox.Show(String.Format(PublicConst.Message_Successfully_Rows, rowNumber), PublicConst.Message_Caption_Info,
                        MessageBoxButtons.OK, MessageBoxIcon.None)
    End Sub
    Sub ShowSuccess(ByVal info As String)
        XtraMessageBox.Show(info, PublicConst.Message_Caption_Info,
                        MessageBoxButtons.OK, MessageBoxIcon.None)
    End Sub

    'Error mesage==============================================================================================================
    Sub ShowErrorInvisible(ByVal ex As Exception, ByVal functionName As String, ByVal formOrClassName As String)
        'Write log file
        If Not Directory.Exists(_folderLog) Then
            Directory.CreateDirectory(_folderLog)
        End If
        WriteLineEnd(_fileLog, _line)
        WriteLineEnd(_fileLog, "DateTime:" & DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss"))
        WriteLineEnd(_fileLog, "UserID:" & CurrentUser.UserID & "-" & CurrentUser.FullName)
        WriteLineEnd(_fileLog, "PC:" & Environment.MachineName & "-" & Environment.UserName)
        WriteLineEnd(_fileLog, "ClassOrForm:" & formOrClassName)
        WriteLineEnd(_fileLog, "FunctionName:" & functionName)
        If ex IsNot Nothing Then
            WriteLineEnd(_fileLog, "Error:" & ex.Message)
        End If
    End Sub

    Sub ShowError(ByVal ex As Exception, ByVal functionName As String, ByVal formOrClassName As String)
        XtraMessageBox.Show(ex.Message, PublicConst.Message_Caption_Error & "-" & functionName,
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Write log file
        If Not Directory.Exists(_folderLog) Then
            Directory.CreateDirectory(_folderLog)
        End If
        WriteLineEnd(_fileLog, _line)
        WriteLineEnd(_fileLog, "DateTime:" & DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss"))
        WriteLineEnd(_fileLog, "UserID:" & CurrentUser.UserID & "-" & CurrentUser.FullName)
        WriteLineEnd(_fileLog, "PC:" & Environment.MachineName & "-" & Environment.UserName)
        WriteLineEnd(_fileLog, "ClassOrForm:" & formOrClassName)
        WriteLineEnd(_fileLog, "FunctionName:" & functionName)
        WriteLineEnd(_fileLog, "Error:" & ex.Message)
    End Sub

    Sub ShowError(ByVal ex As Exception, ByVal functionName As String, ByVal formOrClassName As String, ByVal msg As String)
        XtraMessageBox.Show(ex.Message & msg, PublicConst.Message_Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        If Not Directory.Exists(_folderLog) Then
            Directory.CreateDirectory(_folderLog)
        End If
        WriteLineEnd(_fileLog, _line)
        WriteLineEnd(_fileLog, "DateTime:" & DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss"))
        WriteLineEnd(_fileLog, "UserID:" & CurrentUser.UserID & "-" & CurrentUser.FullName)
        WriteLineEnd(_fileLog, "PC:" & Environment.MachineName & "-" & Environment.UserName)
        WriteLineEnd(_fileLog, "ClassOrForm:" & formOrClassName)
        WriteLineEnd(_fileLog, "FunctionName:" & functionName)
        WriteLineEnd(_fileLog, "Error:" & ex.Message)
    End Sub
#End Region

#Region "Create ID"
    ''' <summary>
    ''' Increase index 
    ''' Example: 001-->002
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="lenght"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IncreaseIndex(ByVal index As String, ByVal lenght As Integer) As String
        If index.Length > 0 Then
            Dim value As Integer = CInt(index)
            value += 1
            Return AddLeft("0", value, lenght)
        End If
        Return AddLeft("0", 1, lenght)
    End Function
#End Region

#Region "Import , Export EXCEL "

    Function ConvertGridViewToDatatable(grid As DataGridView) As DataTable
        'Creating DataTable.
        Dim dt As New DataTable()
        Dim stt As Integer = grid.Columns("Total").Index
        'Adding the Columns.
        For Each column As DataGridViewColumn In grid.Columns
            If column.Index >= stt Then
                dt.Columns.Add(column.HeaderText, Type.GetType("System.Decimal"))
            Else
                dt.Columns.Add(column.HeaderText, Type.GetType("System.String"))
            End If
        Next

        'Adding the Rows.
        For Each row As DataGridViewRow In grid.Rows
            dt.Rows.Add()
            For Each cell As DataGridViewCell In row.Cells
                dt.Rows(dt.Rows.Count - 1)(cell.ColumnIndex) = cell.Value
            Next
        Next

        Return dt
    End Function
    Sub ExportEXCEL_File(ByVal grid As DataGridView, ByVal sheetName As String, ByVal fileName As String, Optional isVisible As Boolean = True)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If grid.DataSource Is Nothing Then Exit Sub
        If grid.RowCount = 0 Then Exit Sub


        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        If sheetName <> "" Then
            wSheet.Name = sheetName
        End If
        myExcel.Visible = isVisible

        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object


        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For
                If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                Else
                    If grid.Rows(i).Cells(j).Value.GetType().Name = "String" Then
                        DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        DataArray(i, j) = grid.Rows(i).Cells(j).Value
                    End If

                End If
            Next
        Next

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
        Next
        If DataArray IsNot Nothing Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If

        wSheet.Activate()
        wSheet.Application.ActiveWindow.SplitRow = 1
        wSheet.Application.ActiveWindow.SplitColumn = 5
        wSheet.Application.ActiveWindow.FreezePanes = True
        Dim firstRow As Excel.Range = CType(wSheet.Rows(1), Excel.Range)
        firstRow.AutoFilter(1,
                    Type.Missing,
                    Excel.XlAutoFilterOperator.xlAnd,
                    Type.Missing,
                    True)


        If File.Exists(fileName) Then
            File.Delete(fileName)
        End If

        wbook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlShared, Type.Missing,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing)


        myExcel.Quit()
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    End Sub

    Public Function ColumnLetterToColumnIndex(columnLetter As String) As Integer
        columnLetter = columnLetter.ToUpper()
        Dim sum As Integer = 0

        For i As Integer = 0 To columnLetter.Length - 1
            sum *= 26
            Dim charA As Integer = Char.GetNumericValue("A")
            Dim charColLetter As Integer = Char.GetNumericValue(columnLetter(i))
            sum += (charColLetter - charA) + 1
        Next
        Return sum
    End Function

    Sub SetFormatExcel(wSheet As Excel.Worksheet, grid As DataGridView)
        For Each c As DataGridViewColumn In grid.Columns
            If c.DefaultCellStyle.Format = "N0" Then
                Dim wRange = wSheet.Columns(c.Index + 1)
                wRange.NumberFormat = "#,###,###"
            ElseIf c.DefaultCellStyle.Format.Contains("N") Then
                Dim wRange = wSheet.Columns(c.Index + 1)
                wRange.NumberFormat = String.Format("#,###,##0.{0}", ("0").PadLeft(c.DefaultCellStyle.Format.Replace("N", ""), "0"))
            ElseIf c.DefaultCellStyle.Format.Contains("yyyy") Then
                Dim wRange = wSheet.Columns(c.Index + 1)
                wRange.NumberFormat = "dd-MMM-yyyy"
            End If
        Next
    End Sub

    Sub SetFormatExcel(wSheet As Excel.Worksheet, dt As DataTable)
        'Định dạng số
        Dim myColumn As Integer = 1
        For Each c As DataColumn In dt.Columns
            If c.DataType.ToString.Contains("Int") Then
                Dim wRange = wSheet.Columns(myColumn)
                wRange.NumberFormat = "#,###,###"
            ElseIf c.DataType.ToString.Contains("Decimal") Or
                c.DataType.ToString.Contains("Double") Or
                c.DataType.ToString.Contains("Float") Then
                Dim wRange = wSheet.Columns(myColumn)
                wRange.NumberFormat = "#,###,##0.00"
            ElseIf c.DataType.ToString.Contains("Date") Then
                Dim wRange = wSheet.Columns(myColumn)
                wRange.NumberFormat = "dd-MMM-yyyy"
            End If
            myColumn += 1
        Next
    End Sub

    Sub SetFreezePanes(myExcel As Excel.Application, wSheet As Excel.Worksheet)
        Try
            wSheet.Application.ActiveWindow.WindowState = Excel.XlWindowState.xlNormal
            wSheet.Rows("1:1").Select()
            wSheet.Application.ActiveWindow.FreezePanes = False
            With wSheet.Application.ActiveWindow
                .SplitRow = 1
            End With
            wSheet.Application.ActiveWindow.FreezePanes = True

            Dim firstRow As Excel.Range = CType(wSheet.Rows(1), Excel.Range)
            firstRow.AutoFilter(1,
                        Type.Missing,
                        Excel.XlAutoFilterOperator.xlAnd,
                        Type.Missing,
                        True)
        Catch ex As Exception
        End Try
    End Sub

    Function ExportDataTable(dgv As DataGridView) As DataTable
        Dim dt As New DataTable()
        For Each col As DataGridViewColumn In dgv.Columns
            dt.Columns.Add(col.Name)
        Next

        For Each row As DataGridViewRow In dgv.Rows

            Dim dRow As DataRow = dt.NewRow()
            For Each cell As DataGridViewCell In row.Cells
                dRow(cell.ColumnIndex) = cell.Value
            Next
            dt.Rows.Add(dRow)
        Next

        Return dt

    End Function

    Function ExportToFile(ByVal tbData As DataTable, ByVal fileName As String, Optional ByVal sheetName As String = Nothing) As String
        Dim tempfolder As String = Application.StartupPath & "\temp\"

        If Directory.Exists(tempfolder) Then
            Directory.CreateDirectory(tempfolder)
        End If

        Dim myFile As String = tempfolder & fileName

        If File.Exists(myFile) Then
            File.Delete(myFile)
        End If

        ExportEXCELToFile(tbData, myFile, sheetName)

        Return myFile
    End Function

    Sub ExportEXCELToFile(ByVal dt As System.Data.DataTable, ByVal filename As String, Optional ByVal sheetName As String = Nothing)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If dt Is Nothing Then Return
        If dt.Rows.Count = 0 Then Return

        Dim i, j As Integer
        Dim rows As Integer = dt.Rows.Count
        Dim cols As Integer = dt.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object
        Dim myExcel As Excel.Application = New Excel.Application
        Dim wSheet As Excel.Worksheet
        Dim wbook As Excel.Workbook

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If dt.Rows(i).Item(j) Is System.DBNull.Value Then Continue For
                If String.IsNullOrEmpty(dt.Rows(i).Item(j).ToString) Then
                Else
                    If dt.Rows(i).Item(j).GetType().Name = "String" Then
                        DataArray(i, j) = "'" + dt.Rows(i).Item(j).ToString()
                    Else
                        DataArray(i, j) = dt.Rows(i).Item(j)
                    End If
                End If
            Next
        Next

        wbook = myExcel.Application.Workbooks.Add(True)
        myExcel.Visible = False
        wSheet = myExcel.Application.Worksheets(1)
        'Set sheetname
        If sheetName <> "" Then
            wSheet.Name = sheetName
        End If

        wSheet.Activate()

        'Set header
        For j = 0 To cols - 1
            myExcel.Cells(1, j + 1) = "'" + dt.Columns(j).Caption
        Next
        'Set data
        If DataArray IsNot Nothing Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
            wSheet.Range("A2").Resize(rows, cols).RowHeight = 12
        End If

        'Định dạng số
        SetFormatExcel(wSheet, dt)

        'Cố định top row
        SetFreezePanes(myExcel, wSheet)


        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        myExcel.DisplayAlerts = False
        wbook.SaveAs(filename)

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
    End Sub

    Sub ExportWithFormat(ByVal grid As DataGridView)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim app As New Excel.Application
        Dim workBook As Excel.Workbook
        Dim workSheet As Excel.Worksheet
        Dim workRange As Excel.Range
        workBook = app.Workbooks.Add(Type.Missing)
        workSheet = CType(workBook.Sheets(1), Excel.Worksheet)
        workSheet.Name = "Sheet1"
        app.Visible = True


        'Header
        For col As Integer = 0 To grid.ColumnCount - 1
            workSheet.Cells(1, col + 1) = grid.Columns(col).HeaderText
        Next
        'Write data
        For row As Integer = 0 To grid.Rows.Count - 1
            For col As Integer = 0 To grid.ColumnCount - 1
                If grid.Rows(row).Cells(col).ValueType.Name = "String" Then
                    workSheet.Cells(row + 2, col + 1) = "'" + grid.Rows(row).Cells(col).Value
                Else
                    workSheet.Cells(row + 2, col + 1) = grid.Rows(row).Cells(col).Value
                End If
                If grid.Rows(row).Cells(col).Style.BackColor.Name <> "0" Then
                    workRange = workSheet.Range(workSheet.Cells(row + 2, col + 1), workSheet.Cells(row + 2, col + 1))
                    workRange.Interior.Color = ColorTranslator.ToWin32(grid.Rows(row).Cells(col).Style.BackColor)
                ElseIf grid.Rows(row).Cells(col).Style.ForeColor.Name <> "0" Then
                    workRange = workSheet.Range(workSheet.Cells(row + 2, col + 1), workSheet.Cells(row + 2, col + 1))
                    workRange.Interior.Color = ColorTranslator.ToWin32(grid.Rows(row).Cells(col).Style.ForeColor)
                End If
            Next

        Next

        workSheet.Application.ActiveWindow.WindowState = Excel.XlWindowState.xlMaximized
        workSheet.Rows("1:1").Select()
        workSheet.Application.ActiveWindow.FreezePanes = False
        With app.ActiveWindow
            .SplitColumn = 0
            .SplitRow = 1
        End With
        app.ActiveWindow.FreezePanes = True


        app.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    Sub ExportWithFormatRow(ByVal grid As DataGridView)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim app As New Excel.Application
        Dim workBook As Excel.Workbook
        Dim workSheet As Excel.Worksheet
        Dim workRange As Excel.Range
        workBook = app.Workbooks.Add(Type.Missing)
        workSheet = CType(workBook.Sheets(1), Excel.Worksheet)
        workSheet.Name = "Sheet1"
        app.Visible = True


        'Header
        For col As Integer = 0 To grid.ColumnCount - 1
            workSheet.Cells(1, col + 1) = grid.Columns(col).HeaderText
        Next
        'Write data
        For row As Integer = 0 To grid.Rows.Count - 1
            For col As Integer = 0 To grid.ColumnCount - 1
                If grid.Rows(row).Cells(col).ValueType.Name = "String" Then
                    workSheet.Cells(row + 2, col + 1) = "'" + grid.Rows(row).Cells(col).Value
                Else
                    workSheet.Cells(row + 2, col + 1) = grid.Rows(row).Cells(col).Value
                End If
                If grid.Rows(row).Cells(col).Style.BackColor.Name <> "0" Then
                    workRange = workSheet.Range(workSheet.Cells(row + 2, col + 1), workSheet.Cells(row + 2, col + 1))
                    workRange.Interior.Color = ColorTranslator.ToWin32(grid.Rows(row).Cells(col).Style.BackColor)
                ElseIf grid.Rows(row).Cells(col).Style.ForeColor.Name <> "0" Then
                    workRange = workSheet.Range(workSheet.Cells(row + 2, col + 1), workSheet.Cells(row + 2, col + 1))
                    workRange.Interior.Color = ColorTranslator.ToWin32(grid.Rows(row).Cells(col).Style.ForeColor)
                End If
            Next
            If grid.Rows(row).DefaultCellStyle.BackColor.Name <> "0" Then
                workRange = workSheet.Range(workSheet.Cells(row + 2, 1), workSheet.Cells(row + 2, grid.ColumnCount))
                workRange.Interior.Color = ColorTranslator.ToWin32(grid.Rows(row).DefaultCellStyle.BackColor)
            End If
        Next

        SetFreezePanes(app, workSheet)

        app.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault


        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    ''' <summary>
    ''' Vo Thanh Son IT
    ''' </summary>
    ''' <param name="grid"></param>
    ''' <param name="bWithoutInvisibleColumns"></param>
    ''' <remarks></remarks>
    Sub ExportEXCEL(ByVal grid As DataGridView, ByVal bWithoutInvisibleColumns As Boolean)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If grid.RowCount = 0 Then Exit Sub


        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        myExcel.Visible = True

        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object

        For i = 0 To rows - 1
            Dim iCol As Int16 = 0
            For j = 0 To cols - 1
                If bWithoutInvisibleColumns And Not grid.Columns(j).Visible Then
                    Continue For
                End If
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Or grid.Rows(i).Cells(j).Value Is Nothing Then
                Else
                    If grid.Rows(i).Cells(j).Value.GetType().Name = "String" Then
                        DataArray(i, iCol) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        DataArray(i, iCol) = grid.Rows(i).Cells(j).Value
                    End If
                End If
                iCol = iCol + 1
            Next
        Next

        Dim iColHeader As Int16 = 0
        For j = 0 To cols - 1
            If bWithoutInvisibleColumns And Not grid.Columns(j).Visible Then
                Continue For
            End If
            wSheet.Cells(1, iColHeader + 1) = "'" + grid.Columns(j).HeaderText
            iColHeader = iColHeader + 1
        Next

        If DataArray IsNot Nothing Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If


        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        ''myExcel.DisplayAlerts = False
        ' myExcel.Columns.AutoFit()
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    Sub ExportEXCEL(ByVal grid As DataGridView, ByVal fileName As String)

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")



        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        myExcel.Visible = True


        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For

                If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                Else
                    If grid.Rows(i).Cells(j).Value.GetType.Name = "String" Then
                        DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        DataArray(i, j) = grid.Rows(i).Cells(j).Value
                    End If
                End If
            Next
        Next

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
        Next
        If DataArray.Length > 0 Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If
        wSheet.Rows().RowHeight = 13

        'SetFormatExcel(wRange, wSheet, grid)
        SetFreezePanes(myExcel, wSheet)


        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        If fileName <> "" Then
            wbook.SaveAs(fileName)
        End If
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    Sub ExportEXCEL_HeaderText(ByVal grid As DataGridView)

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        myExcel.Visible = False


        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For

                If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                Else
                    If grid.Rows(i).Cells(j).Value.GetType.Name = "String" Then
                        DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                        'wSheet.Cells(i + 2, j + 2) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        DataArray(i, j) = grid.Rows(i).Cells(j).Value
                        'wSheet.Cells(i + 2, j + 2) = grid.Rows(i).Cells(j).Value
                    End If
                End If
            Next
        Next

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
        Next
        If DataArray.Length > 0 Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If
        wSheet.Rows().RowHeight = 13

        SetFormatExcel(wSheet, grid)
        SetFreezePanes(myExcel, wSheet)

        myExcel.Visible = True

        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    Sub ExportEXCEL_ColumnName(ByVal grid As DataGridView)

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        myExcel.Visible = False


        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For

                If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                Else
                    If grid.Rows(i).Cells(j).Value.GetType.Name = "String" Then
                        DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                        'wSheet.Cells(i + 2, j + 2) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        DataArray(i, j) = grid.Rows(i).Cells(j).Value
                        'wSheet.Cells(i + 2, j + 2) = grid.Rows(i).Cells(j).Value
                    End If
                End If
            Next
        Next

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).Name
        Next
        If DataArray.Length > 0 Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If

        wSheet.Rows().RowHeight = 13

        SetFormatExcel(wSheet, grid)
        SetFreezePanes(myExcel, wSheet)

        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    Sub ExportEXCEL_DataPropertyName(ByVal grid As DataGridView)

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        myExcel.Visible = False


        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For

                If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                Else
                    If grid.Rows(i).Cells(j).Value.GetType.Name = "String" Then
                        DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                        'wSheet.Cells(i + 2, j + 2) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        DataArray(i, j) = grid.Rows(i).Cells(j).Value
                        'wSheet.Cells(i + 2, j + 2) = grid.Rows(i).Cells(j).Value
                    End If
                End If
            Next
        Next

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).DataPropertyName
        Next
        If DataArray.Length > 0 Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If

        wSheet.Rows().RowHeight = 13

        SetFormatExcel(wSheet, grid)
        SetFreezePanes(myExcel, wSheet)

        myExcel.Visible = True
        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    Sub ExportEXCEL(ByVal grid As DataGridView)

        If grid.RowCount > 100000 Then
            ExportEXCEL_LargeRow(grid)
            Return
        End If

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")



        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim wRange As Excel.Range = Nothing
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        myExcel.Visible = False


        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If Not grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then
                    If Not String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                        If grid.Rows(i).Cells(j).Value.GetType.Name = "String" Then
                            DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                        Else
                            DataArray(i, j) = grid.Rows(i).Cells(j).Value
                        End If
                    End If
                End If
            Next
        Next

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
        Next
        If DataArray.Length > 0 Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
            SetFormatExcel(wSheet, grid)
            SetFreezePanes(myExcel, wSheet)
        End If

        wSheet.Rows().RowHeight = 13


        myExcel.Visible = True
        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub
    ''' <summary>
    ''' Export for >=200k Rows
    ''' </summary>
    ''' <param name="grid"></param>
    ''' <remarks></remarks>

    Sub ExportEXCEL_LargeRow(ByVal grid As DataGridView)

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        myExcel.Visible = False


        Dim maxRecord As Integer = 50000
        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(maxRecord, cols) As Object
        Dim R As Integer = 0, C = 0
        Dim Count As Integer = 0

        For i = 0 To rows - 1
            C = 0
            For j = 0 To cols - 1
                C = j
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For

                If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                Else
                    If grid.Rows(i).Cells(j).Value.GetType.Name = "String" Then
                        DataArray(R, C) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        DataArray(R, C) = grid.Rows(i).Cells(j).Value
                    End If
                End If
            Next
            R += 1
            If i > 0 Then
                If i Mod maxRecord = 0 Or i = rows - 1 Then
                    wSheet.Range("A" & (Count * maxRecord + 2)).Resize(R, C + 1).Value = DataArray
                    Array.Clear(DataArray, 0, R)
                    R = 0
                    C = 0
                    Count += 1
                End If
            End If

        Next

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
        Next


        wSheet.Rows().RowHeight = 13
        SetFormatExcel(wSheet, grid)
        SetFreezePanes(myExcel, wSheet)

        myExcel.Visible = True

        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    Sub ExportEXCELColumnName(ByVal grid As DataGridView)

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")



        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim wRange As Excel.Range = Nothing
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        myExcel.Visible = True


        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For

                If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                Else
                    If grid.Rows(i).Cells(j).Value.GetType.Name = "String" Then
                        DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        DataArray(i, j) = grid.Rows(i).Cells(j).Value
                    End If
                End If
            Next
        Next

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).Name
        Next
        If DataArray.Length > 0 Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
            SetFormatExcel(wSheet, grid)
            SetFreezePanes(myExcel, wSheet)
        End If



        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    Sub ExportEXCEL_CP_Daily(ByVal grid As DataGridView)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If grid.RowCount = 0 Then Exit Sub

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim range As Excel.Range
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        myExcel.Visible = True


        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object
        Dim mylist As New List(Of Integer)

        For i = 0 To rows - 1
            If grid.Rows(i).Cells(2).Value = "zTotal" Then
                mylist.Add(i)
            End If
            For j = 0 To cols - 1
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For
                If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                Else
                    If grid.Rows(i).Cells(j).Value.GetType.Name = "String" Then
                        DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        DataArray(i, j) = grid.Rows(i).Cells(j).Value
                    End If
                End If
            Next
        Next

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
        Next
        For Each idx As Integer In mylist
            range = wSheet.Range(wSheet.Cells(idx + 2, 1), wSheet.Cells(idx + 2, 13))
            range.Interior.Color = ColorTranslator.ToWin32(Color.Yellow)
        Next
        If DataArray IsNot Nothing Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If


        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    Sub ExportEXCELCP(ByVal grid As DataGridView)

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If grid.RowCount = 0 Then Exit Sub

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim range As Excel.Range
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        myExcel.Visible = True

        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For

                If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                Else
                    If grid.Rows(i).Cells(j).Value.GetType.Name = "String" Then
                        DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        DataArray(i, j) = grid.Rows(i).Cells(j).Value
                    End If
                End If
            Next
        Next

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
        Next
        If DataArray IsNot Nothing Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If
        range = wSheet.Range(wSheet.Cells(1, 5), wSheet.Cells(i, 5))
        range.Interior.Color = ColorTranslator.ToWin32(Color.LightGreen)

        range = wSheet.Range(wSheet.Cells(1, 16), wSheet.Cells(i, 16))
        range.Interior.Color = ColorTranslator.ToWin32(Color.LightPink)

        range = wSheet.Range(wSheet.Cells(1, 27), wSheet.Cells(i, 27))
        range.Interior.Color = ColorTranslator.ToWin32(Color.LightSkyBlue)

        range = wSheet.Range(wSheet.Cells(1, 38), wSheet.Cells(i, 38))
        range.Interior.Color = ColorTranslator.ToWin32(Color.Magenta)

        wSheet.Rows("1:1").Select()
        wSheet.Application.ActiveWindow.WindowState = Excel.XlWindowState.xlMaximized
        wSheet.Application.ActiveWindow.FreezePanes = False
        With myExcel.ActiveWindow
            .SplitColumn = 4
            .SplitRow = 1
        End With
        myExcel.ActiveWindow.FreezePanes = True


        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    Sub ExportEXCELPercent(ByVal grid As DataGridView)

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If grid.RowCount = 0 Then Exit Sub

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        myExcel.Visible = True


        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For

                If Not String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                    If grid.Rows(i).Cells(j).Value.GetType.Name = "String" Then
                        DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        If IsNumeric(grid.Rows(i).Cells(j).Value) Then
                            DataArray(i, j) = grid.Rows(i).Cells(j).Value / 100.0
                        Else
                            DataArray(i, j) = grid.Rows(i).Cells(j).Value
                        End If
                    End If
                End If
            Next
        Next

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
        Next
        If DataArray IsNot Nothing Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If
        Dim procentRange As Excel.Range = wSheet.Range(wSheet.Cells(2, 2), wSheet.Cells(i + 1, j))
        procentRange.NumberFormat = "###.##%"


        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    Sub ExportEXCEL_PropertyColName(ByVal grid As DataGridView)

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If grid.RowCount = 0 Then Exit Sub

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        myExcel.Visible = True


        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For

                If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                Else
                    If grid.Rows(i).Cells(j).Value.GetType.Name = "String" Then
                        DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        DataArray(i, j) = grid.Rows(i).Cells(j).Value
                    End If
                End If
            Next
        Next

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).Name
        Next
        If DataArray IsNot Nothing Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If


        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    ''' <summary>
    ''' Only use for Control Stock XOUT
    ''' </summary>
    ''' <param name="grid"></param>
    ''' <remarks></remarks>
    ''' 
    Sub ExportEXCELXOUT(ByVal grid As DataGridView)

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If grid.RowCount = 0 Then Exit Sub

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        myExcel.Visible = True
        Dim range As Excel.Range

        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For

                If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                Else
                    If grid.Rows(i).Cells(j).Value.GetType.Name = "String" Then
                        DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        DataArray(i, j) = grid.Rows(i).Cells(j).Value
                    End If
                End If
            Next
        Next

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
        Next
        If DataArray IsNot Nothing Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If
        i = 0
        Dim indexColor As Integer = 0
        Dim currentCorlor As Color = GetColor(indexColor)
        Dim pdcode As String = grid.Rows(0).Cells("ProductCode").Value
        For Each r As DataGridViewRow In grid.Rows
            If r.Cells("OverEntek").Value IsNot DBNull.Value Then
                range = wSheet.Range(wSheet.Cells(i + 2, 1), wSheet.Cells(i + 2, j))
                range.Interior.Color = ColorTranslator.ToWin32(ColorOver1)
            Else
                If r.Cells("ProductCode").Value <> pdcode Then
                    indexColor += 1
                    currentCorlor = GetColor(indexColor)
                    pdcode = r.Cells("ProductCode").Value
                    range = wSheet.Range(wSheet.Cells(i + 2, 1), wSheet.Cells(i + 2, j))
                    range.Interior.Color = ColorTranslator.ToWin32(currentCorlor)
                Else
                    range = wSheet.Range(wSheet.Cells(i + 2, 1), wSheet.Cells(i + 2, j))
                    range.Interior.Color = ColorTranslator.ToWin32(currentCorlor)
                End If
            End If
            i += 1
        Next
        range = wSheet.Cells(i + 2, 1)
        range.Value = "Total"
        range = wSheet.Cells(i + 2, 9)
        range.Formula = "=subtotal(109,I2:I" & i + 1 & ")"
        range = wSheet.Cells(i + 2, 11)
        range.Formula = "=subtotal(109,K2:K" & i + 1 & ")"
        range = wSheet.Range(wSheet.Cells(i + 2, 1), wSheet.Cells(i + 2, j))
        range.Interior.Color = ColorTranslator.ToWin32(Color.Yellow)
        range = wSheet.Range(wSheet.Cells(1, 1), wSheet.Cells(1, j))
        range.Interior.Color = ColorTranslator.ToWin32(Color.Yellow)
        range = wSheet.Range(wSheet.Cells(1, 1), wSheet.Cells(i + 2, j))
        range.Borders.LineStyle = 1

        wSheet.Application.ActiveWindow.WindowState = Excel.XlWindowState.xlMaximized
        wSheet.Application.ActiveWindow.FreezePanes = False
        wSheet.Application.ActiveWindow.SplitRow = 1
        wSheet.Application.ActiveWindow.FreezePanes = True

        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    ''' <summary>
    ''' Only use for Control Stock XOUT
    ''' </summary>
    ''' <param name="grid"></param>
    ''' <remarks></remarks>
    ''' 
    Sub ExportEXCELXOUT(ByVal grid As GridView)

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If grid.RowCount = 0 Then Exit Sub

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        myExcel.Visible = True
        Dim range As Excel.Range

        Dim i As Integer
        Dim rows As Integer = grid.RowCount
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object

        For i = 0 To rows - 1
            For Each col As GridColumn In grid.Columns
                If grid.GetRowCellValue(i, col) Is System.DBNull.Value Then Continue For

                If String.IsNullOrEmpty(grid.GetRowCellValue(i, col)) Then
                Else
                    If col.ColumnType.ToString = "String" Then
                        DataArray(i, col.VisibleIndex) = "'" & grid.GetRowCellValue(i, col)
                    Else
                        DataArray(i, col.VisibleIndex) = grid.GetRowCellValue(i, col)
                    End If
                End If
            Next
        Next

        For Each col As GridColumn In grid.Columns
            wSheet.Cells(1, col.VisibleIndex + 1) = "'" + col.FieldName
        Next
        If DataArray IsNot Nothing Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If
        i = 0
        Dim indexColor As Integer = 0
        Dim currentCorlor As Color = GetColor(indexColor)
        Dim pdcode As String = grid.GetRowCellValue(0, "ProductCode")
        For r As Integer = 0 To grid.RowCount - 1
            If grid.GetRowCellValue(r, "OverEntek") IsNot DBNull.Value Then
                range = wSheet.Range(wSheet.Cells(i + 2, 1), wSheet.Cells(i + 2, cols))
                range.Interior.Color = ColorTranslator.ToWin32(ColorOver1)
            Else
                If grid.GetRowCellValue(r, "ProductCode") <> pdcode Then
                    indexColor += 1
                    currentCorlor = GetColor(indexColor)
                    pdcode = grid.GetRowCellValue(r, "ProductCode")
                    range = wSheet.Range(wSheet.Cells(i + 2, 1), wSheet.Cells(i + 2, cols))
                    range.Interior.Color = ColorTranslator.ToWin32(currentCorlor)
                Else
                    range = wSheet.Range(wSheet.Cells(i + 2, 1), wSheet.Cells(i + 2, cols))
                    range.Interior.Color = ColorTranslator.ToWin32(currentCorlor)
                End If
            End If
            i += 1
        Next
        range = wSheet.Cells(i + 2, 1)
        range.Value = "Total"
        range = wSheet.Cells(i + 2, 9)
        range.Formula = "=subtotal(109,I2:I" & i + 1 & ")"
        range = wSheet.Cells(i + 2, 11)
        range.Formula = "=subtotal(109,K2:K" & i + 1 & ")"
        range = wSheet.Range(wSheet.Cells(i + 2, 1), wSheet.Cells(i + 2, cols))
        range.Interior.Color = ColorTranslator.ToWin32(Color.Yellow)
        range = wSheet.Range(wSheet.Cells(1, 1), wSheet.Cells(1, cols))
        range.Interior.Color = ColorTranslator.ToWin32(Color.Yellow)
        range = wSheet.Range(wSheet.Cells(1, 1), wSheet.Cells(i + 2, cols))
        range.Borders.LineStyle = 1

        wSheet.Application.ActiveWindow.WindowState = Excel.XlWindowState.xlMaximized
        wSheet.Application.ActiveWindow.FreezePanes = False
        wSheet.Application.ActiveWindow.SplitRow = 1
        wSheet.Application.ActiveWindow.FreezePanes = True

        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    End Sub

    Sub ExportEXCELSX(ByVal grid As DataGridView, ByVal sheetName As String, ByVal fileName As String, Optional isVisible As Boolean = True)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If grid.DataSource Is Nothing Then Exit Sub
        If grid.RowCount = 0 Then Exit Sub


        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim wRange As Excel.Range
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        If sheetName <> "" Then
            wSheet.Name = sheetName
        End If
        myExcel.Visible = isVisible

        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For
                If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                Else
                    If grid.Rows(i).Cells(j).Value.GetType().Name = "String" Then
                        DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        DataArray(i, j) = grid.Rows(i).Cells(j).Value
                    End If

                End If
            Next
        Next

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
        Next
        If DataArray IsNot Nothing Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If
        wRange = wSheet.Cells(i + 2, 7)
        wRange.Formula = "=sum(G2:G" & i + 1 & ")"
        wRange = wSheet.Cells(i + 2, 8)
        wRange.Formula = "=sum(H2:H" & i + 1 & ")"
        wRange = wSheet.Cells(i + 2, 9)
        wRange.Formula = "=sum(I2:I" & i + 1 & ")"
        wRange = wSheet.Cells(i + 2, 10)
        wRange.Formula = "=sum(J2:J" & i + 1 & ")"
        wRange = wSheet.Cells(i + 2, 11)
        wRange.Formula = "=sum(I2:I" & i + 1 & ")/sum(H2:H" & i + 1 & ")*100"
        wRange = wSheet.Cells(i + 2, 13)
        wRange.Formula = "=sum(M2:M" & i + 1 & ")"
        wRange = wSheet.Cells(i + 2, 14)
        wRange.Formula = "=sum(N2:N" & i + 1 & ")"
        For Each c As DataGridViewColumn In grid.Columns
            If c.DefaultCellStyle.Format = "N0" Then
                wRange = wSheet.Columns(c.Index + 1)
                wRange.NumberFormat = "#,###,###"
            ElseIf c.DefaultCellStyle.Format = "N2" Then
                wRange = wSheet.Columns(c.Index + 1)
                wRange.NumberFormat = "#,###,##0.00"
            End If
        Next

        'Định dạng số
        SetFormatExcel(wSheet, grid)

        'Cố định top row
        SetFreezePanes(myExcel, wSheet)

        If File.Exists(fileName) Then
            File.Delete(fileName)
        End If

        wbook.SaveAs(fileName)

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    Sub ExportEXCEL(ByVal grid As DataGridView, ByVal sheetName As String, ByVal fileName As String, Optional isVisible As Boolean = True)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If grid.DataSource Is Nothing Then Exit Sub
        If grid.RowCount = 0 Then Exit Sub


        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        If sheetName <> "" Then
            wSheet.Name = sheetName
        End If
        myExcel.Visible = isVisible

        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For
                If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                Else
                    If grid.Rows(i).Cells(j).Value.GetType().Name = "String" Then
                        DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        DataArray(i, j) = grid.Rows(i).Cells(j).Value
                    End If

                End If
            Next
        Next

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
        Next
        If DataArray IsNot Nothing Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If
        SetFormatExcel(wSheet, grid)
        SetFreezePanes(myExcel, wSheet)
        wSheet.Rows.RowHeight = 12

        If File.Exists(fileName) Then
            File.Delete(fileName)
            wbook.SaveAs(fileName)
        Else
            wbook.SaveAs(fileName)
        End If
        myExcel.Quit()

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    Sub ExportEXCEL(ByVal grids() As DataGridView)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        myExcel.Visible = True


        For Each grid As DataGridView In grids
            If grid Is Nothing Then Continue For
            If grid.Rows.Count = 0 Then Continue For

            wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
            wSheet = myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count - 1)
            wSheet.Activate()

            Dim i, j As Integer
            Dim rows As Integer = grid.Rows.Count
            Dim cols As Integer = grid.Columns.Count
            Dim DataArray(rows - 1, cols - 1) As Object

            For i = 0 To rows - 1
                For j = 0 To cols - 1
                    If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For
                    If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                    Else
                        If IsDate(grid.Rows(i).Cells(j).Value) Or IsNumeric(grid.Rows(i).Cells(j).Value) Then
                            DataArray(i, j) = grid.Rows(i).Cells(j).Value
                        Else
                            DataArray(i, j) = "'" + grid.Rows(i).Cells(j).Value.ToString()
                        End If
                    End If
                Next
            Next


            For j = 0 To cols - 1
                wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
            Next

            If DataArray IsNot Nothing Then
                wSheet.Range("A2").Resize(rows, cols).Value = DataArray
            End If
            SetFormatExcel(wSheet, grid)
            SetFreezePanes(myExcel, wSheet)
            wSheet.Rows().RowHeight = 12
        Next

        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    End Sub

    Sub ExportEXCEL(ByVal lst As List(Of DataGridView))
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        myExcel.Visible = True


        For Each grid As DataGridView In lst
            If grid Is Nothing Then Continue For
            If grid.Rows.Count = 0 Then Continue For

            wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
            wSheet = myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count - 1)
            wSheet.Activate()
            wSheet.Name = grid.Name
            Dim i, j As Integer
            Dim rows As Integer = grid.Rows.Count
            Dim cols As Integer = grid.Columns.Count
            Dim DataArray(rows - 1, cols - 1) As Object

            For i = 0 To rows - 1
                For j = 0 To cols - 1
                    If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then Continue For

                    If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                    Else
                        If grid.Rows(i).Cells(j).Value.GetType.Name = "String" Then
                            DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                        Else
                            DataArray(i, j) = grid.Rows(i).Cells(j).Value
                        End If
                    End If
                Next
            Next


            For j = 0 To cols - 1
                wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
            Next

            If DataArray IsNot Nothing Then
                wSheet.Range("A2").Resize(rows, cols).Value = DataArray
            End If
            SetFormatExcel(wSheet, grid)
            SetFreezePanes(myExcel, wSheet)
        Next

        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    End Sub

    Sub ExportEXCEL_ColumnVisible(ByVal lst As List(Of DataGridView))
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        myExcel.Visible = True


        For Each grid As DataGridView In lst
            If grid Is Nothing Then Continue For
            If grid.Rows.Count = 0 Then Continue For

            wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
            wSheet = myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count - 1)
            wSheet.Activate()

            Dim i, j As Integer
            Dim rows As Integer = grid.Rows.Count
            Dim cols As Integer = grid.Columns.Count
            Dim DataArray(rows - 1, cols - 1) As Object


            For j = 0 To cols - 1
                For i = 0 To rows - 1
                    If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then
                        Continue For
                    End If

                    If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                    Else
                        If grid.Rows(i).Cells(j).Value.GetType.Name = "String" Then
                            DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                        Else
                            DataArray(i, j) = grid.Rows(i).Cells(j).Value
                        End If
                    End If
                Next
            Next

            If DataArray IsNot Nothing Then
                wSheet.Range("A2").Resize(rows, cols).Value = DataArray
            End If

            For j = 0 To cols - 1
                wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
            Next
            Dim indexCount As Integer = 0

            For j = 0 To cols - 1
                If Not grid.Columns(j).Visible Then
                    wSheet.Columns(j + 1 - indexCount).Delete()
                    indexCount += 1
                End If
            Next

            SetFormatExcel(wSheet, grid)
            SetFreezePanes(myExcel, wSheet)
        Next

        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    End Sub

    Sub ExportEXCEL_ColumnVisible(ByVal grid As DataGridView)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        myExcel.Visible = True



        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count - 1)
        wSheet.Activate()

        Dim i, j As Integer
        Dim rows As Integer = grid.Rows.Count
        Dim cols As Integer = grid.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object


        For j = 0 To cols - 1
            For i = 0 To rows - 1
                If grid.Rows(i).Cells(j).Value Is System.DBNull.Value Then
                    Continue For
                End If

                If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                Else
                    If grid.Rows(i).Cells(j).Value.GetType.Name = "String" Then
                        DataArray(i, j) = "'" & grid.Rows(i).Cells(j).Value.ToString()
                    Else
                        DataArray(i, j) = grid.Rows(i).Cells(j).Value
                    End If
                End If
            Next
        Next

        If DataArray.Length > 0 Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If

        For j = 0 To cols - 1
            wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
        Next
        Dim indexCount As Integer = 0

        For j = 0 To cols - 1
            If Not grid.Columns(j).Visible Then
                wSheet.Columns(j + 1 - indexCount).Delete()
                indexCount += 1
            End If
        Next

        SetFormatExcel(wSheet, grid)
        SetFreezePanes(myExcel, wSheet)

        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    End Sub

    Sub ExportEXCEL(ByVal grids() As DataGridView, ByVal fileName As String)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        myExcel.Visible = True


        For Each grid As DataGridView In grids
            If grid Is Nothing Then Continue For
            If grid.Rows.Count = 0 Then Continue For

            wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
            wSheet = myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count - 1)
            wSheet.Activate()
            Dim i, j As Integer
            Dim rows As Integer = grid.Rows.Count
            Dim cols As Integer = grid.Columns.Count
            Dim DataArray(rows - 1, cols - 1) As Object

            For i = 0 To rows - 1
                For j = 0 To cols - 1
                    If grid.Rows(i).Cells(j) Is System.DBNull.Value Then Continue For
                    If String.IsNullOrEmpty(grid.Rows(i).Cells(j).Value) Then
                    Else
                        If grid.Rows(i).Cells(j).GetType().Name = "String" Then
                            DataArray(i, j) = "'" + grid.Rows(i).Cells(j).Value.ToString()
                        Else
                            DataArray(i, j) = grid.Rows(i).Cells(j).Value
                        End If
                    End If
                Next
            Next


            For j = 0 To cols - 1
                wSheet.Cells(1, j + 1) = "'" + grid.Columns(j).HeaderText
            Next

            If DataArray IsNot Nothing Then
                wSheet.Range("A2").Resize(rows, cols).Value = DataArray
            End If

        Next

        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        ''myExcel.DisplayAlerts = False
        'myExcel.Columns.AutoFit()
        If fileName = "" Then
            myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault

        Else
            Dim dialogsave As New SaveFileDialog
            fileName = dialogsave.FileName
            dialogsave.Filter = "Excel 2007|*.xlsx"
            If dialogsave.ShowDialog = DialogResult.OK Then
                wbook.SaveAs(dialogsave.FileName)
            End If
        End If

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    End Sub

    Sub ExportEXCEL(ByVal dt As System.Data.DataTable)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If dt Is Nothing Then Return
        If dt.Rows.Count = 0 Then Return

        Dim i, j As Integer
        Dim rows As Integer = dt.Rows.Count
        Dim cols As Integer = dt.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object
        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        myExcel.Visible = True

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If dt.Rows(i).Item(j) Is System.DBNull.Value Then Continue For
                If String.IsNullOrEmpty(dt.Rows(i).Item(j)) Then
                Else
                    If dt.Rows(i).Item(j).GetType().Name = "String" Then
                        DataArray(i, j) = "'" + dt.Rows(i).Item(j).ToString()
                    Else
                        DataArray(i, j) = dt.Rows(i).Item(j)
                    End If
                End If
            Next
        Next


        For j = 0 To cols - 1
            myExcel.Cells(1, j + 1) = "'" + dt.Columns(j).Caption
        Next

        If DataArray IsNot Nothing Then
            myExcel.Range("A2").Resize(rows, cols).Value = DataArray
        End If

        wSheet.Rows().RowHeight = 12
        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault

        SetFreezePanes(myExcel, wSheet)

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI



    End Sub

    Sub ExportEXCEL(ByVal dt As System.Data.DataTable, ByVal sheetName As String, ByVal fileName As String)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If dt Is Nothing Then Return
        If dt.Rows.Count = 0 Then Return

        Dim i, j As Integer
        Dim rows As Integer = dt.Rows.Count
        Dim cols As Integer = dt.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object
        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
        wSheet = myExcel.Application.Worksheets(1)
        wSheet.Activate()
        If sheetName <> "" Then
            wSheet.Name = sheetName
        End If
        myExcel.Visible = True

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If dt.Rows(i).Item(j) Is System.DBNull.Value Then Continue For
                If String.IsNullOrEmpty(dt.Rows(i).Item(j)) Then
                Else
                    If dt.Rows(i).Item(j).GetType().Name = "String" Then
                        DataArray(i, j) = "'" + dt.Rows(i).Item(j).ToString()
                    Else
                        DataArray(i, j) = dt.Rows(i).Item(j)
                    End If
                End If
            Next
        Next


        For j = 0 To cols - 1
            myExcel.Cells(1, j + 1) = "'" + dt.Columns(j).Caption
        Next

        If DataArray IsNot Nothing Then
            myExcel.Range("A2").Resize(rows, cols).Value = DataArray
        End If



        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault

        If Not File.Exists(fileName) Then
            myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
            fileName = Application.StartupPath & "\temp\" & sheetName & ".xlsx"
            If Not Directory.Exists(Application.StartupPath & "\temp") Then
                Directory.CreateDirectory(Application.StartupPath & "\temp")
            End If
            If File.Exists(fileName) Then
                File.Delete(fileName)
            End If
        End If

        wbook.SaveAs(fileName)

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI



    End Sub

    Sub ExportEXCEL(ByVal table() As DataTable)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        myExcel.Visible = True


        For Each dt As DataTable In table
            If dt Is Nothing Then Continue For
            If dt.Rows.Count = 0 Then Continue For

            wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
            wSheet = myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count - 1)
            wSheet.Activate()
            If dt.TableName <> "" Then
                wSheet.Name = dt.TableName
            End If
            Dim i, j As Integer
            Dim rows As Integer = dt.Rows.Count
            Dim cols As Integer = dt.Columns.Count
            Dim DataArray(rows - 1, cols - 1) As Object

            For i = 0 To rows - 1
                For j = 0 To cols - 1
                    If dt.Rows(i).Item(j) Is System.DBNull.Value Then Continue For
                    If String.IsNullOrEmpty(dt.Rows(i).Item(j).ToString) Then
                    Else
                        If dt.Rows(i).Item(j).GetType().Name = "String" Then
                            DataArray(i, j) = "'" + dt.Rows(i).Item(j).ToString()
                        Else
                            DataArray(i, j) = dt.Rows(i).Item(j)
                        End If
                    End If
                Next
            Next


            For j = 0 To cols - 1
                wSheet.Cells(1, j + 1) = "'" + dt.Columns(j).Caption
            Next

            If DataArray IsNot Nothing Then
                wSheet.Range("A2").Resize(rows, cols).Value = DataArray
            End If
            wSheet.Rows().RowHeight = 12
        Next

        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    End Sub

    Sub ExportEXCEL(ByVal lst As List(Of DataTable), ByVal filename As String)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        myExcel.Visible = True

        For Each dt As DataTable In lst
            If dt Is Nothing Then Continue For
            If dt.Rows.Count = 0 Then Continue For

            wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
            wSheet = myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count - 1)
            wSheet.Activate()
            If dt.TableName <> "" Then
                wSheet.Name = dt.TableName
            End If
            Dim i, j As Integer
            Dim rows As Integer = dt.Rows.Count
            Dim cols As Integer = dt.Columns.Count
            Dim DataArray(rows - 1, cols - 1) As Object

            For i = 0 To rows - 1
                For j = 0 To cols - 1
                    If dt.Rows(i).Item(j) Is System.DBNull.Value Then Continue For
                    If String.IsNullOrEmpty(dt.Rows(i).Item(j).ToString) Then
                    Else
                        If dt.Rows(i).Item(j).GetType().Name = "String" Then
                            DataArray(i, j) = "'" + dt.Rows(i).Item(j).ToString()
                        Else
                            DataArray(i, j) = dt.Rows(i).Item(j)
                        End If
                    End If
                Next
            Next


            For j = 0 To cols - 1
                wSheet.Cells(1, j + 1) = "'" + dt.Columns(j).Caption
            Next

            If DataArray.Length > 0 Then
                wSheet.Range("A2").Resize(rows, cols).Value = DataArray
            End If
            wSheet.Rows().RowHeight = 12
        Next

        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        myExcel.DisplayAlerts = False
        If filename = "" Then
            myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
            Dim dialogsave As New SaveFileDialog With {
                .FileName = filename,
                .Filter = "Excel 2007|*.xlsx"
            }
            If dialogsave.ShowDialog = DialogResult.OK Then
                wbook.SaveAs(filename)
            End If
        Else
            wbook.SaveAs(filename)
        End If

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    End Sub

    Sub ExportEXCEL(ByVal ds As DataSet)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        myExcel.Visible = True

        For Each dt As DataTable In ds.Tables
            If dt Is Nothing Then Continue For
            If dt.Rows.Count = 0 Then Continue For

            wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
            wSheet = myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count - 1)
            wSheet.Activate()
            If dt.TableName <> "" Then
                wSheet.Name = dt.TableName
            End If
            Dim i, j As Integer
            Dim rows As Integer = dt.Rows.Count
            Dim cols As Integer = dt.Columns.Count
            Dim DataArray(rows - 1, cols - 1) As Object

            For i = 0 To rows - 1
                For j = 0 To cols - 1
                    If dt.Rows(i).Item(j) Is System.DBNull.Value Then Continue For
                    If String.IsNullOrEmpty(dt.Rows(i).Item(j).ToString) Then
                    Else
                        If dt.Rows(i).Item(j).GetType().Name = "String" Then
                            DataArray(i, j) = "'" + dt.Rows(i).Item(j).ToString()
                        Else
                            DataArray(i, j) = dt.Rows(i).Item(j)
                        End If
                    End If
                Next
            Next
            For j = 0 To cols - 1
                wSheet.Cells(1, j + 1) = "'" + dt.Columns(j).Caption
            Next

            If DataArray IsNot Nothing Then
                wSheet.Range("A2").Resize(rows, cols).Value = DataArray
            End If
            wSheet.Rows().RowHeight = 12
        Next

        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    End Sub
    ''' <summary>
    ''' Only use for ControlStockXout
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Sub ExportEXCELXOUT(ByVal ds As DataSet)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim colorOver As Color = Color.Pink
        Dim colorAlready As Color = Color.LightGreen
        Dim colorNoYet As Color = Color.Gold
        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As New Excel.Worksheet
        Dim range As Excel.Range
        wbook = myExcel.Application.Workbooks.Add(True)
        myExcel.Visible = True

        For Each dt As DataTable In ds.Tables
            If dt Is Nothing Then Continue For
            If dt.Rows.Count = 0 Then Continue For

            wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
            wSheet = myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count - 1)
            wSheet.Activate()
            If dt.TableName <> "" Then
                wSheet.Name = dt.TableName
            End If
            Dim i, j As Integer
            Dim rows As Integer = dt.Rows.Count
            Dim cols As Integer = dt.Columns.Count
            Dim DataArray(rows - 1, cols - 1) As Object

            For i = 0 To rows - 1
                For j = 0 To cols - 1
                    If dt.Rows(i).Item(j) Is System.DBNull.Value Then Continue For
                    If String.IsNullOrEmpty(dt.Rows(i).Item(j).ToString) Then
                    Else
                        If dt.Rows(i).Item(j).GetType().Name = "String" Then
                            DataArray(i, j) = "'" + dt.Rows(i).Item(j).ToString()
                        Else
                            DataArray(i, j) = dt.Rows(i).Item(j)
                        End If
                    End If
                Next
            Next
            For j = 0 To cols - 1
                wSheet.Cells(1, j + 1) = "'" + dt.Columns(j).Caption
            Next

            If DataArray IsNot Nothing Then
                wSheet.Range("A2").Resize(rows, cols).Value = DataArray
            End If
            range = wSheet.Cells(i + 2, 1)
            range.Value = "Total"
            range = wSheet.Cells(i + 2, 7)
            range.Formula = "=sum(G2:G" & i + 1 & ")"
            range = wSheet.Cells(i + 2, 9)
            range.Formula = "=sum(I2:I" & i + 1 & ")"
            i = 0
            For Each r As DataRow In dt.Rows
                If r.Item("OverEntek") IsNot DBNull.Value Then
                    range = wSheet.Range(wSheet.Cells(i + 2, 1), wSheet.Cells(i + 2, j))
                    range.Interior.Color = ColorTranslator.ToWin32(colorOver)
                Else
                    If r.Item("Remark") = "Not yet" Then
                        range = wSheet.Range(wSheet.Cells(i + 2, 1), wSheet.Cells(i + 2, j))
                        range.Interior.Color = ColorTranslator.ToWin32(colorNoYet)
                    Else
                        range = wSheet.Range(wSheet.Cells(i + 2, 1), wSheet.Cells(i + 2, j))
                        range.Interior.Color = ColorTranslator.ToWin32(colorAlready)
                    End If
                End If
                i += 1
            Next
            wSheet.Rows().RowHeight = 12
            range = wSheet.Range(wSheet.Cells(i + 2, 1), wSheet.Cells(i + 2, j))
            range.Interior.Color = ColorTranslator.ToWin32(Color.LightGreen)
            range = wSheet.Range(wSheet.Cells(1, 1), wSheet.Cells(i + 2, j))
            range.Borders.LineStyle = 1
            range = wSheet.Range(wSheet.Cells(1, 1), wSheet.Cells(1, j))
            range.Interior.Color = ColorTranslator.ToWin32(Color.Yellow)

            wSheet.Application.ActiveWindow.WindowState = Excel.XlWindowState.xlMaximized
            wSheet.Application.ActiveWindow.FreezePanes = False
            wSheet.Application.ActiveWindow.SplitRow = 1
            wSheet.Application.ActiveWindow.FreezePanes = True

        Next



        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    End Sub

    Sub ExportEXCEL(ByVal dt As System.Data.DataTable, ByVal filename As String)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If dt Is Nothing Then Return
        If dt.Rows.Count = 0 Then Return

        Dim i, j As Integer
        Dim rows As Integer = dt.Rows.Count
        Dim cols As Integer = dt.Columns.Count
        Dim DataArray(rows - 1, cols - 1) As Object
        Dim myExcel As Excel.Application = New Excel.Application
        Dim wSheet As Excel.Worksheet
        Dim wbook As Excel.Workbook

        For i = 0 To rows - 1
            For j = 0 To cols - 1
                If dt.Rows(i).Item(j) Is System.DBNull.Value Then Continue For
                If String.IsNullOrEmpty(dt.Rows(i).Item(j).ToString) Then
                Else
                    If dt.Rows(i).Item(j).GetType().Name = "String" Then
                        DataArray(i, j) = "'" + dt.Rows(i).Item(j).ToString()
                    Else
                        DataArray(i, j) = dt.Rows(i).Item(j)
                    End If
                End If
            Next
        Next
        wbook = myExcel.Application.Workbooks.Add(True)
        myExcel.Visible = True
        wSheet = myExcel.Application.Worksheets(1)
        'wSheet.Name = filename
        wSheet.Activate()

        For j = 0 To cols - 1
            myExcel.Cells(1, j + 1) = "'" + dt.Columns(j).Caption
        Next

        If DataArray IsNot Nothing Then
            wSheet.Range("A2").Resize(rows, cols).Value = DataArray
        End If


        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        ''myExcel.DisplayAlerts = False
        If filename = "" Then
            myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
            Dim dialogsave As New SaveFileDialog With {
                .FileName = filename,
                .Filter = "Excel 2007|*.xlsx"
            }
            If dialogsave.ShowDialog = DialogResult.OK Then
                wbook.SaveAs(filename)
            End If
        Else
            wbook.SaveAs(filename)
        End If

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI



    End Sub

    Sub ExportEXCEL(ByVal table() As DataTable, ByVal fileName As String)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim myExcel As Excel.Application = New Excel.Application
        Dim wbook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        wbook = myExcel.Application.Workbooks.Add(True)
        myExcel.Visible = True


        For Each dt As DataTable In table
            If dt Is Nothing Then Continue For
            If dt.Rows.Count = 0 Then Continue For

            wbook.Sheets.Add(Type.Missing, myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count), 1, Excel.XlSheetType.xlWorksheet)
            wSheet = myExcel.Application.Worksheets(myExcel.Application.Worksheets.Count - 1)
            wSheet.Activate()
            If dt.TableName <> "" Then
                wSheet.Name = dt.TableName
            End If
            Dim i, j As Integer
            Dim rows As Integer = dt.Rows.Count
            Dim cols As Integer = dt.Columns.Count
            Dim DataArray(rows - 1, cols - 1) As Object

            For i = 0 To rows - 1
                For j = 0 To cols - 1
                    If dt.Rows(i).Item(j) Is System.DBNull.Value Then Continue For
                    If String.IsNullOrEmpty(dt.Rows(i).Item(j).ToString) Then
                    Else
                        If dt.Rows(i).Item(j).GetType().Name = "String" Then
                            DataArray(i, j) = "'" + dt.Rows(i).Item(j).ToString()
                        Else
                            DataArray(i, j) = dt.Rows(i).Item(j)
                        End If
                    End If
                Next
            Next


            For j = 0 To cols - 1
                wSheet.Cells(1, j + 1) = "'" + dt.Columns(j).Caption
            Next

            If DataArray IsNot Nothing Then
                wSheet.Range("A2").Resize(rows, cols).Value = DataArray
            End If

        Next

        myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault

        If fileName = "" Then
            myExcel.DefaultSaveFormat = Excel.XlFileFormat.xlWorkbookDefault
        Else
            Dim dialogsave As New SaveFileDialog With {
                .Filter = "Excel 2007|*.xlsx"
            }
            fileName = dialogsave.FileName
            If dialogsave.ShowDialog = DialogResult.OK Then
                wbook.SaveAs(fileName)
            End If
        End If

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


    End Sub

    Function ImportEXCEL(ByVal isHeader As Boolean) As System.Data.DataTable
        Try
            Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            Dim connectionString As String = ""
            Dim table As New DataTable
            Dim header As String = "No"
            If isHeader Then header = "Yes"

            Dim openFile As New OpenFileDialog With {
                .Filter = "All file(*.*)|*.*|Excel 2003(*.xls)|*.xls|Excel 2007(*.xlsx)|*.xlsx"
            }
            If openFile.ShowDialog() = DialogResult.OK Then

                connectionString = GetConnectStringExcel(openFile.FileName, header)

                Dim connection = New System.Data.OleDb.OleDbConnection(connectionString)

                connection.Open()
                Dim dt As DataTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                If dt IsNot Nothing Then
                    Dim command = New System.Data.OleDb.OleDbDataAdapter(String.Format("select * from [{0}] ",
                                                                                       dt.Rows(0).Item("TABLE_NAME")), connection)

                    command.TableMappings.Add("Table", "Table")

                    command.Fill(table)
                    command.Dispose()
                    dt.Dispose()
                End If

                connection.Close()
                connection.Dispose()
            End If

            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
            Return table

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function ImportEXCELFromFile(ByVal fileName As String) As System.Data.DataTable
        Try
            Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            Dim connectionString As String = ""
            Dim table As New DataTable
            Dim header As String = "No"


            If Not File.Exists(fileName) Then
                Return Nothing
            End If

            connectionString = GetConnectStringExcel(fileName, header)

            Dim connection = New System.Data.OleDb.OleDbConnection(connectionString)
            connection.Open()
            Dim dt As DataTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            If dt IsNot Nothing Then
                Dim command = New System.Data.OleDb.OleDbDataAdapter(String.Format("select * from [{0}] ", dt.Rows(0).Item("TABLE_NAME")), connection)

                command.TableMappings.Add("Table", "Table")

                command.Fill(table)
                command.Dispose()
                dt.Dispose()
            End If

            connection.Close()
            connection.Dispose()

            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
            Return table
            table.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function ImportEXCEL(ByVal SheetName As String) As System.Data.DataTable
        Try
            Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            Dim connectionString As String = ""
            Dim table As New DataTable
            Dim header As String = "No"
            Dim isHeader As Boolean = True
            If isHeader Then header = "Yes"

            Dim openFile As New OpenFileDialog With {
                .Filter = "All file(*.*)|*.*|Excel 2003(*.xls)|*.xls|Excel 2007(*.xlsx)|*.xlsx"
            }
            If openFile.ShowDialog() = DialogResult.OK Then
                Dim file As String = openFile.FileName

                connectionString = GetConnectStringExcel(openFile.FileName, header)

                Dim connection = New System.Data.OleDb.OleDbConnection(connectionString)
                connection.Open()
                Dim dt As DataTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                If dt IsNot Nothing Then
                    Dim command = New System.Data.OleDb.OleDbDataAdapter(String.Format("select * from [{0}$] ", SheetName), connection)
                    'If file.Contains(".xls") Then
                    '    command = New System.Data.OleDb.OleDbDataAdapter(String.Format("select * from ['{0}$'] ", SheetName), connection)
                    'End If
                    command.TableMappings.Add("Table", "Table")

                    command.Fill(table)
                    command.Dispose()
                    dt.Dispose()
                End If

                connection.Close()
                connection.Dispose()
            End If

            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
            Return table

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function ImportEXCEL(ByVal sheetname As String, ByVal fileName As String) As System.Data.DataTable
        Try
            Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            Dim connectionString As String = ""
            Dim table As New DataTable
            Dim header As String = "YES"

            If Not System.IO.File.Exists(fileName) Or sheetname = "" Then Return New DataTable

            connectionString = GetConnectStringExcel(fileName, header)

            Dim connection = New System.Data.OleDb.OleDbConnection(connectionString)
            connection.Open()
            Dim dt As DataTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

            If dt IsNot Nothing Then
                Dim command = New System.Data.OleDb.OleDbDataAdapter(String.Format("select * from [{0}$] ", sheetname), connection)

                command.TableMappings.Add("Table", "Table")

                command.Fill(table)
                command.Dispose()
                dt.Dispose()
            End If

            connection.Close()
            connection.Dispose()
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

            Return table

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function ImportEXCEL(ByVal isHeader As Boolean, ByRef fileName As String) As System.Data.DataTable
        Try
            Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            Dim connectionString As String = ""
            Dim table As New DataTable
            Dim header As String = "No"
            If isHeader Then header = "Yes"

            If Not File.Exists(fileName) Then

                Dim openFile As New OpenFileDialog With {
                    .Filter = "All file(*.*)|*.*|Excel 2003(*.xls)|*.xls|Excel 2007(*.xlsx)|*.xlsx"
                }
                If openFile.ShowDialog() = DialogResult.OK Then
                    fileName = openFile.FileName
                Else
                    ShowWarning("File không tồn tại !")
                    Return New DataTable
                End If
            End If

            connectionString = GetConnectStringExcel(fileName, header)

            Dim connection = New System.Data.OleDb.OleDbConnection(connectionString)
            connection.Open()
            Dim dt As DataTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

            If dt IsNot Nothing Then
                Dim command = New System.Data.OleDb.OleDbDataAdapter(String.Format("select * from [{0}] ", dt.Rows(0).Item("TABLE_NAME")), connection)

                command.TableMappings.Add("Table", "Table")

                command.Fill(table)
                command.Dispose()
                dt.Dispose()
            End If

            connection.Close()
            connection.Dispose()

            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
            Return table

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function ImportDataset(Optional ByVal isHeader As Boolean = True) As System.Data.DataSet
        Try
            Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            Dim connectionString As String = ""
            Dim dataset As New DataSet
            Dim header As String = "No"
            If isHeader Then header = "Yes"

            Dim openFile As New OpenFileDialog With {
                .Filter = "All file(*.*)|*.*|Excel 2003(*.xls)|*.xls|Excel 2007(*.xlsx)|*.xlsx"
            }
            If openFile.ShowDialog() = DialogResult.OK Then

                connectionString = GetConnectStringExcel(openFile.FileName, header)

                Dim connection = New System.Data.OleDb.OleDbConnection(connectionString)
                connection.Open()

                Dim dt As DataTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

                If dt IsNot Nothing Then
                    For Each row As DataRow In dt.Rows
                        Try
                            Dim command = New System.Data.OleDb.OleDbDataAdapter(String.Format("select * from [{0}] ", row("TABLE_NAME").ToString()), connection)
                            command.TableMappings.Add("Table", "Table")
                            command.Fill(dataset, row("TABLE_NAME").ToString().Replace("$", ""))
                            command.Dispose()
                        Catch ex As Exception
                        End Try
                    Next
                    dt.Dispose()
                End If

                connection.Close()
                connection.Dispose()
                System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
            End If
            Return dataset

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Son IT
    ''' </summary>
    ''' <param name="arrSheetName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ImportEXCEL(ByVal arrSheetName() As String, ByVal filename As String) As System.Data.DataSet
        Try
            Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            Dim connectionString As String = ""
            Dim dataset As New DataSet
            Dim header As String = "No"
            Dim isHeader As Boolean = True
            If isHeader Then header = "Yes"


            If Not File.Exists(filename) Then
                Dim openFile As New OpenFileDialog With {
                    .Filter = "All file(*.*)|*.*|Excel 2003(*.xls)|*.xls|Excel 2007(*.xlsx)|*.xlsx"
                }
                If openFile.ShowDialog() = DialogResult.OK Then
                    filename = openFile.FileName
                Else
                    ShowWarning("File không tồn tại !")
                    Return New DataSet
                End If
            End If

            connectionString = GetConnectStringExcel(filename, header)

            Dim connection = New System.Data.OleDb.OleDbConnection(connectionString)
            connection.Open()

            Dim dt As DataTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

            If dt IsNot Nothing Then
                For Each sheet As String In arrSheetName
                    Try
                        Dim command = New System.Data.OleDb.OleDbDataAdapter(String.Format("select * from [{0}$] ", sheet), connection)
                        command.TableMappings.Add("Table", "Table")
                        command.Fill(dataset, sheet)
                        command.Dispose()
                    Catch ex As Exception
                    End Try
                Next
                dt.Dispose()
            End If
            connection.Close()
            connection.Dispose()
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

            Return dataset

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function ImportEXCEL(ByVal arrSheetName() As String) As System.Data.DataSet
        Try
            Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            Dim connectionString As String = ""
            Dim dataset As New DataSet
            Dim header As String = "No"
            Dim isHeader As Boolean = True
            If isHeader Then header = "Yes"
            Dim filename As String = ""


            Dim openFile As New OpenFileDialog With {
                .Filter = "All file(*.*)|*.*|Excel 2003(*.xls)|*.xls|Excel 2007(*.xlsx)|*.xlsx"
            }
            If openFile.ShowDialog() = DialogResult.OK Then
                filename = openFile.FileName
            Else
                ShowWarning("File không tồn tại !")
                Return New DataSet
            End If


            connectionString = GetConnectStringExcel(filename, header)

            Dim connection = New System.Data.OleDb.OleDbConnection(connectionString)
            connection.Open()

            Dim dt As DataTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

            If dt IsNot Nothing Then
                For Each sheet As String In arrSheetName
                    Try
                        Dim command = New System.Data.OleDb.OleDbDataAdapter(String.Format("select * from [{0}$] ", sheet), connection)
                        command.TableMappings.Add("Table", "Table")
                        command.Fill(dataset, sheet)
                        command.Dispose()
                    Catch ex As Exception
                    End Try
                Next
                dt.Dispose()
            End If
            connection.Close()
            connection.Dispose()
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

            Return dataset

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function GetConnectStringExcel(ByVal filename As String, ByVal header As String)
        Dim connectionString As String = ""

        If filename.Contains(".xlsx") Then
            'read a 2007 xlsx file  
            connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" &
                    filename & ";Extended Properties='Excel 12.0 Xml;HDR={0}; IMEX=1' ", header)
        Else
            'read a 97-2003 xls file  
            connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" &
                    filename & ";Extended Properties='Excel 8.0;HDR={0}; IMEX=1' ", header)

            'connectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" &
            '    filename & ";Extended Properties='Excel 8.0;HDR={0}' ", header)
        End If

        Return connectionString
    End Function
#End Region

#Region "Import , Export file txt, csv "

    Function ImportCSV(ByVal isHeader As Boolean) As DataTable
        Dim openfile As New OpenFileDialog With {
            .Filter = "All file(*.*)|*.*|CSV file(*.csv)|*.csv|Text file(*.txt)|*.txt "
        }
        If openfile.ShowDialog() = DialogResult.OK Then
            Try
                Dim fileTemp As String = "C:\\temp" + DateTime.Now.ToString("ddMMyyyy") + ".txt"
                Dim writer As StreamWriter = File.CreateText(fileTemp)
                writer.Close()
                File.Copy(openfile.FileName, fileTemp, True)
                If Not isHeader Then
                    WriteLineFirst(fileTemp, "")
                End If
                Dim connect As String = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=C:\\;Extensions=asc,csv,tab,txt;"
                Dim cons As OdbcConnection = New OdbcConnection(connect)
                cons.Open()
                Dim dapter As OdbcDataAdapter = New OdbcDataAdapter(String.Format("select * from {0} ",
                                                                                 Path.GetFileName(fileTemp)), cons)
                Dim tb As DataTable = New DataTable()
                dapter.Fill(tb)
                File.Delete(fileTemp)
                cons.Dispose()
                Return tb
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error csv")
            End Try
        End If
        Return New DataTable()
    End Function
    Function ExportCSV(ByVal table As DataTable, ByVal isHeader As Boolean)
        Dim openfile As New SaveFileDialog With {
            .Filter = "All file(*.*)|*.*|CSV file(*.csv)|*.csv|Text file(*.txt)|*.txt "
        }
        Dim writer As StreamWriter = Nothing
        If openfile.ShowDialog() = DialogResult.OK Then
            Try
                Dim line As String = ""
                writer = File.CreateText(openfile.FileName)
                If isHeader Then
                    For Each column As DataColumn In table.Columns
                        line += column.ColumnName + vbTab + ","
                    Next
                    line = line.Substring(0, line.Length - 1)
                    writer.WriteLine(line)
                End If
                For Each row As DataRow In table.Rows
                    line = ""
                    For colum As Integer = 0 To table.Columns.Count - 1
                        If IsNumeric(row.Item(colum)) Then
                            line += row.Item(colum).ToString() + vbTab + ","
                        Else
                            line += """" + row.Item(colum).ToString() + """" + vbTab + ","
                        End If
                    Next
                    line = line.Substring(0, line.Length - 1)
                    writer.WriteLine(line)
                Next
                writer.Close()

            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error csv")
                If writer IsNot Nothing Then writer.Close()
            End Try
        End If
        Return New DataTable()
    End Function
    Function ExportCSV(ByVal grid As DataGridView, ByVal isHeader As Boolean)
        Dim openfile As New SaveFileDialog With {
            .Filter = "All file(*.*)|*.*|CSV file(*.csv)|*.csv|Text file(*.txt)|*.txt "
        }
        Dim writer As StreamWriter = Nothing
        If openfile.ShowDialog() = DialogResult.OK Then
            Try
                Dim line As String = ""
                writer = File.CreateText(openfile.FileName)
                If isHeader Then
                    For Each column As DataGridViewColumn In grid.Columns
                        line += column.HeaderText + vbTab + ","
                    Next
                    line = line.Substring(0, line.Length - 1)
                    writer.WriteLine(line)
                End If
                For Each row As DataGridViewRow In grid.Rows
                    If Not row.IsNewRow Then
                        line = ""
                        For colum As Integer = 0 To grid.Columns.Count - 1
                            If IsNumeric(row.Cells(colum).Value) Then
                                line += row.Cells(colum).Value.ToString() + vbTab + ","
                            Else
                                line += """" + row.Cells(colum).Value.ToString() + """" + vbTab + ","
                            End If
                        Next
                        line = line.Substring(0, line.Length - 1)
                        writer.WriteLine(line)
                    End If
                Next
                writer.Close()

            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error csv")
                If writer IsNot Nothing Then writer.Close()
            End Try
        End If
        Return New DataTable()
    End Function

    Public Sub WriteLineFirst(filename As String, line As String)

        Dim tempfile As String = Path.GetTempFileName()
        Dim writer As StreamWriter = New StreamWriter(tempfile)
        Dim reader As StreamReader = New StreamReader(filename)
        writer.WriteLine(line)
        While (Not reader.EndOfStream)
            writer.WriteLine(reader.ReadLine())
        End While
        writer.Close()
        reader.Close()
        File.Copy(tempfile, filename, True)
    End Sub
    Public Sub WriteLineEnd(filename As String, line As String)
        Dim writer As StreamWriter = New StreamWriter(filename, True)
        writer.WriteLine(line)
        writer.Close()
    End Sub

#End Region

#Region "Date and Time "

    Function GetDayOffWeek(ByVal startdate As DateTime, ByVal endDate As DateTime) As Integer
        Dim sql As String = String.Format(" select count(*) from [FPICS_HolidayDate] " +
                                          " where HolidayDate between @StartDate and @EndDate")
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", startdate)
        para(1) = New SqlClient.SqlParameter("@EndDate", endDate)

        Return _db.ExecuteScalar(sql, para)
    End Function

    Function GetDayOnWeek(ByVal startdate As DateTime, ByVal endDate As DateTime) As Integer
        Return (endDate - startdate).Days - GetDayOffWeek(startdate, endDate)
    End Function

    Function GetMonthByMMM(ByVal MMM As String) As Integer
        Dim month As Integer = 1
        If MMM = "Feb" Then
            Return 1
        ElseIf MMM = "Jan" Then
            Return 2
        ElseIf MMM = "Mar" Then
            Return 3
        ElseIf MMM = "Apr" Then
            Return 4
        ElseIf MMM = "May" Then
            Return 5
        ElseIf MMM = "Jun" Then
            Return 6
        ElseIf MMM = "Jul" Then
            Return 7
        ElseIf MMM = "Aug" Then
            Return 8
        ElseIf MMM = "Sep" Then
            Return 9
        ElseIf MMM = "Oct" Then
            Return 10
        ElseIf MMM = "Nov" Then
            Return 11
        ElseIf MMM = "Dec" Then
            Return 12
        End If
        Return month
    End Function
    ''' <summary>
    ''' Tính số ngày nghỉ công ty
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="endDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetOffDay(ByVal startDate As DateTime, ByVal endDate As DateTime) As Integer
        Dim para(1) As SqlClient.SqlParameter
        Dim total As New Object
        para(0) = New SqlClient.SqlParameter("@StartDate", startDate)
        para(1) = New SqlClient.SqlParameter("@EndDate", endDate)

        total = _db.ExecuteScalar("select count(*) from [FPICS_HolidayDate] where [HolidayDate] between @StartDate and @EndDate ", para)
        If total Is DBNull.Value Then
            Return 0
        End If
        Return total
    End Function
    ''' <summary>
    ''' Tính số ngày đi làm của công ty
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="endDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetTotalDay(ByVal startDate As DateTime, ByVal endDate As DateTime) As Integer
        Dim para(1) As SqlClient.SqlParameter
        Dim offDay As Integer = GetOffDay(startDate, endDate)
        Dim totalday As Integer = (endDate - startDate).Days

        Return totalday - offDay + 1
    End Function
    ''' <summary>
    ''' Get Monday of Week
    ''' </summary>
    ''' <param name="myDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetFirstDayOfWeek(ByVal myDate As DateTime) As DateTime
        Dim delta As Integer = DayOfWeek.Monday - myDate.DayOfWeek
        Dim monday As DateTime = myDate.AddDays(delta)
        Return monday
    End Function
    ''' <summary>
    ''' Get Sunday of Week
    ''' </summary>
    ''' <param name="myDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetLastDayOfWeek(ByVal myDate As DateTime) As DateTime
        Dim delta As Integer = DayOfWeek.Sunday - myDate.DayOfWeek
        Dim monday As DateTime = myDate.AddDays(delta)
        Return monday
    End Function
    ''' <summary>
    ''' Get monday of Plan Output
    ''' </summary>
    ''' <param name="myDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetFirstDayOfWeekPlan(ByVal myDate As DateTime) As DateTime
        If myDate.DayOfWeek < 4 Then
            Dim delta As Integer = DayOfWeek.Monday - myDate.DayOfWeek
            Dim monday As DateTime = myDate.AddDays(delta)
            Return monday
        Else
            Return GetFirstDayOfWeek(myDate.AddDays(6))
        End If

    End Function
    ''' <summary>
    ''' return MMyyy theo tháng lương HR
    ''' </summary>
    ''' <param name="today"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetThisMonth(ByVal today As DateTime) As String
        If today.Day <= 20 Then
            Return today.ToString("MMyyyy")
        Else
            Return today.AddMonths(1).ToString("MMyyyy")
        End If
    End Function
    ''' <summary>
    ''' Return yyyyMM
    ''' </summary>
    ''' <param name="today"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetThisMonthYYMM(ByVal today As DateTime) As String
        If today.Day <= 20 Then
            Return today.ToString("yyyyMM")
        Else
            Return today.AddMonths(1).ToString("yyyyMM")
        End If
    End Function
    ''' <summary>
    ''' Lấy ngày đầu tháng theo lương NDV
    ''' </summary>
    ''' <param name="today"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function FirstDayOfMonth(ByVal today As DateTime) As DateTime
        Dim NextMonth As DateTime = today.AddMonths(1)
        Dim PreviouMonth As DateTime = today.AddMonths(-1)
        If today.Day <= 20 Then
            Return New DateTime(PreviouMonth.Year, PreviouMonth.Month, 21)
        Else
            Return New DateTime(today.Year, today.Month, 21)
        End If
    End Function
    ''' <summary>
    ''' Lấy ngày cuối tháng theo lương NDV
    ''' </summary>
    ''' <param name="today"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function LastDayOfMonth(ByVal today As DateTime) As DateTime
        Dim NextMonth As DateTime = today.AddMonths(1)
        Dim PreviouMonth As DateTime = today.AddMonths(-1)
        If today.Day <= 20 Then
            Return New DateTime(today.Year, today.Month, 20)
        Else
            Return New DateTime(NextMonth.Year, NextMonth.Month, 20)
        End If
    End Function
    ''' <summary>
    ''' Lấy ngày thứ 2 của tuần
    ''' </summary>
    ''' <param name="today"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function FirstDayOfWeek(ByVal today As DateTime) As DateTime
        While (today.DayOfWeek <> DayOfWeek.Monday)
            today = today.AddDays(-1)
        End While
        Return New DateTime(today.Year, today.Month, today.Day)
    End Function
    ''' <summary>
    ''' Lấy ngày chủ nhật của tuần
    ''' </summary>
    ''' <param name="today"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function LastDayOfWeek(ByVal today As DateTime) As DateTime
        While (today.DayOfWeek <> DayOfWeek.Sunday)
            today = today.AddDays(+1)
        End While
        Return New DateTime(today.Year, today.Month, today.Day)
    End Function

    Function GetWeekNumberOfYear(ByVal value As DateTime) As Integer
        Return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(value, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
    End Function
    ''' <summary>
    ''' Lấy ngày cuối tháng
    ''' </summary>
    ''' <param name="datetime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetEndDayOfMonth(ByVal datetime As DateTime) As DateTime

        Return New DateTime(datetime.Year, datetime.Month, Date.DaysInMonth(datetime.Year, datetime.Month), 23, 59, 59)

    End Function
    ''' <summary>
    ''' Lấy ngày đầu tháng 01/MM/yyyy
    ''' </summary>
    ''' <param name="datetime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetStartDayOfMonth(ByVal datetime As DateTime) As DateTime
        Return New DateTime(datetime.Year, datetime.Month, 1, 0, 0, 0)
    End Function
    ''' <summary>
    ''' Ngày 21.MM.yyyy
    ''' </summary>
    ''' <param name="datetime"></param>
    ''' <returns></returns>
    Function GetStartDayOfMonthCT(ByVal datetime As DateTime) As DateTime
        If datetime.Day >= 21 Then
            Return New DateTime(datetime.Year, datetime.Month, 21, 0, 0, 0)
        Else
            Return New DateTime(datetime.AddMonths(-1).Year, datetime.AddMonths(-1).Month, 21, 0, 0, 0)
        End If
    End Function
    ''' <summary>
    ''' Ngày 20.MM.yyyy
    ''' </summary>
    ''' <param name="datetime"></param>
    ''' <returns></returns>
    Function GetEndDayOfMonthCT(ByVal datetime As DateTime) As DateTime
        If datetime.Day <= 20 Then
            Return New DateTime(datetime.Year, datetime.Month, 20, 0, 0, 0)
        Else
            Return New DateTime(datetime.AddMonths(1).Year, datetime.AddMonths(1).Month, 20, 0, 0, 0)
        End If
    End Function
    ''' <summary>
    ''' Lấy ngày đầu tiên của năm tài chính NDV
    ''' </summary>
    ''' <param name="datetime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetStartDayOfYear(ByVal datetime As DateTime) As DateTime
        If datetime.Month > 3 Then
            Return New DateTime(datetime.Year, 4, 1, 0, 0, 0)
        Else
            Return New DateTime(datetime.Year - 1, 4, 1, 0, 0, 0)
        End If
    End Function
    ''' <summary>
    ''' Lấy ngày đầu của năm 1.1.2018
    ''' </summary>
    ''' <param name="datetime"></param>
    ''' <returns></returns>
    Function GetStartDayOfYearNormal(ByVal datetime As DateTime) As DateTime
        Return New DateTime(datetime.Year, 1, 1, 0, 0, 0)
    End Function
    ''' <summary>
    ''' Lấy ngày cuối của năm 31.12.2018
    ''' </summary>
    ''' <param name="datetime"></param>
    ''' <returns></returns>
    Function GetEndDayOfYearNormal(ByVal datetime As DateTime) As DateTime
        Return New DateTime(datetime.Year, 12, 31, 0, 0, 0)
    End Function
    ''' <summary>
    ''' Lấy ngày đầu tiên của năm tài chính
    ''' </summary>
    ''' <param name="year"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetStartDayOfYear(ByVal year As Integer) As DateTime
        Return New DateTime(year, 4, 1, 0, 0, 0)
    End Function
    Function GetEndDayOfYear(ByVal year As Integer) As DateTime
        Return New DateTime(year + 1, 3, 31, 23, 59, 59)
    End Function
    Function GetEndDayOfYear(ByVal datetime As DateTime) As DateTime
        If datetime.Month > 3 Then
            Return New DateTime(datetime.Year + 1, 3, 31, 23, 59, 59)
        Else
            Return New DateTime(datetime.Year, 3, 31, 23, 59, 59)
        End If
    End Function
    Function GetStartDayOfQuarter(ByVal datetime As DateTime) As DateTime
        If datetime.Month >= 1 And datetime.Month <= 3 Then
            Return New DateTime(datetime.Year, 1, 1, 0, 0, 0)
        ElseIf datetime.Month >= 4 And datetime.Month <= 6 Then
            Return New DateTime(datetime.Year, 4, 1, 0, 0, 0)
        ElseIf datetime.Month >= 7 And datetime.Month <= 9 Then
            Return New DateTime(datetime.Year, 7, 1, 0, 0, 0)
        ElseIf datetime.Month >= 10 And datetime.Month <= 12 Then
            Return New DateTime(datetime.Year, 10, 1, 0, 0, 0)
        End If
        Return Nothing
    End Function
    Function GetEndDayOfQuarter(ByVal datetime As DateTime) As DateTime
        If datetime.Month >= 1 And datetime.Month <= 3 Then
            Return New DateTime(datetime.Year, 3, Date.DaysInMonth(datetime.Year, 3), 0, 0, 0)
        ElseIf datetime.Month >= 4 And datetime.Month <= 6 Then
            Return New DateTime(datetime.Year, 6, Date.DaysInMonth(datetime.Year, 6), 0, 0, 0)
        ElseIf datetime.Month >= 7 And datetime.Month <= 9 Then
            Return New DateTime(datetime.Year, 9, Date.DaysInMonth(datetime.Year, 9), 0, 0, 0)
        ElseIf datetime.Month >= 10 And datetime.Month <= 12 Then
            Return New DateTime(datetime.Year, 12, Date.DaysInMonth(datetime.Year, 12), 0, 0, 0)
        End If
        Return Nothing
    End Function
    ''' <summary>
    ''' Return datetime with time is 0,0,0
    ''' </summary>
    ''' <param name="dateValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Function GetStartDate(ByVal dateValue As DateTime) As DateTime
        Return New DateTime(dateValue.Year, dateValue.Month, dateValue.Day, 0, 0, 0)
    End Function
    ''' <summary>
    ''' Return datetime with time is 0,0,0
    ''' </summary>
    ''' <param name="PickerValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetStartDate(ByVal PickerValue As DateTimePicker) As DateTime
        Return New DateTime(PickerValue.Value.Year, PickerValue.Value.Month, PickerValue.Value.Day, 0, 0, 0)
    End Function
    ''' <summary>
    ''' Return datetime with time is 23,59,59
    ''' </summary>
    ''' <param name="dateValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetEndDate(ByVal dateValue As DateTime) As DateTime
        Return New DateTime(dateValue.Year, dateValue.Month, dateValue.Day, 23, 59, 59)
    End Function
    ''' <summary>
    '''Return datetime with time is 23,59,59 
    ''' </summary>
    ''' <param name="PickerValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetEndDate(ByVal PickerValue As DateTimePicker) As DateTime
        Return New DateTime(PickerValue.Value.Year, PickerValue.Value.Month, PickerValue.Value.Day, 23, 59, 59)
    End Function
    ''' <summary>
    ''' Return datetime with time of value
    ''' </summary>
    ''' <param name="dateValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetDateTime(ByVal dateValue As DateTime) As DateTime
        Return New DateTime(dateValue.Year, dateValue.Month, dateValue.Day, dateValue.Hour, dateValue.Minute, dateValue.Second)
    End Function
    ''' <summary>
    ''' Return datetime with time of value dd MM yyyy 6, 1, 0, 0
    ''' </summary>
    ''' <param name="dateValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetDateTimeStart6h(ByVal dateValue As DateTime) As DateTime
        Return New DateTime(dateValue.Year, dateValue.Month, dateValue.Day, 6, 1, 0, 0)
    End Function
    ''' <summary>
    '''  Return datetime with time of value dd MM yyyy 6, 0, 59, 999
    ''' </summary>
    ''' <param name="dateValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetDateTimeEnd6h(ByVal dateValue As DateTime) As DateTime
        Return New DateTime(dateValue.Year, dateValue.Month, dateValue.Day, 6, 0, 59, 59)
    End Function
    ''' <summary>
    ''' Return datetime with time of pickerdatetime
    ''' </summary>
    ''' <param name="PickerValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetDateTime(ByVal PickerValue As DateTimePicker) As DateTime
        Return New DateTime(PickerValue.Value.Year, PickerValue.Value.Month, PickerValue.Value.Day, PickerValue.Value.Hour, PickerValue.Value.Minute, PickerValue.Value.Second)
    End Function
    ''' <summary>
    ''' Return datetime with time of para(Hour),0,0
    ''' </summary>
    ''' <param name="dateValue"></param>
    ''' <param name="hour"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetDateTime(ByVal dateValue As DateTime, ByVal hour As Integer) As DateTime
        Return New DateTime(dateValue.Year, dateValue.Month, dateValue.Day, hour, 0, 0)
    End Function
    Function GetDateTime(ByVal dateValue As DateTime, ByVal hour As Integer, ByVal minute As Integer, ByVal second As Integer) As DateTime
        Return New DateTime(dateValue.Year, dateValue.Month, dateValue.Day, hour, minute, second)
    End Function
    Function GetDatetime(ByVal strDate As String, ByVal format As EnumDateFormat) As DateTime

        If format = EnumDateFormat.ddmmyyyy Then
            Return New DateTime(Microsoft.VisualBasic.Right(strDate, 4), Microsoft.VisualBasic.Mid(strDate, 4, 2), Microsoft.VisualBasic.Left(strDate, 2))
        End If
        If format = EnumDateFormat.mmddyyyy Then
            Return New DateTime(Microsoft.VisualBasic.Right(strDate, 4), Microsoft.VisualBasic.Left(strDate, 2), Microsoft.VisualBasic.Mid(strDate, 4, 2))
        End If

        Return DateTime.Now
    End Function
    ''' <summary>
    ''' Return datetime with time of para(Hour),0,0
    ''' </summary>
    ''' <param name="PickerValue"></param>
    ''' <param name="hour"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetDateTime(ByVal PickerValue As DateTimePicker, ByVal hour As Integer) As DateTime
        Return New DateTime(PickerValue.Value.Year, PickerValue.Value.Month, PickerValue.Value.Day, hour, 0, 0)
    End Function
    ''' <summary>
    ''' Return JAN,FER,MAR,APR,MAY,JUN,JUL,AUG,SEP,OCT,NOV,DEC
    ''' </summary>
    ''' <param name="month"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetNameOfMonth(ByVal month As Integer) As String
        If month <= 0 Or month > 12 Then
            Return ""
        End If

        Dim dateOfMonth As DateTime = New DateTime(DateTime.Now.Year, month, 1)
        Return UCase(dateOfMonth.ToString("MMM"))
    End Function
    ''' <summary>
    '''  Return value Q12012 
    ''' </summary>
    ''' <param name="datetime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetQuater(ByVal datetime As DateTime) As String
        Dim quater As String = ""
        Dim year As String = datetime.Year
        Dim month As Integer = datetime.Month
        If month <= 3 Then
            quater = "Q1" & year
        End If
        If month >= 4 And month <= 6 Then
            quater = "Q2" & year
        End If
        If month >= 7 And month <= 9 Then
            quater = "Q3" & year
        End If
        If month >= 10 Then
            quater = "Q4" & year
        End If
        Return quater

    End Function
    ''' <summary>
    ''' Return value Q12012
    ''' </summary>
    ''' <param name="datetime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetQuaterByFinancialXX(ByVal datetime As DateTime) As String
        Dim quater As String = ""

        Dim year As String = datetime.Year
        Dim month As Integer = datetime.Month
        If month <= 3 Then
            quater = "QIV." & (year - 1)
        End If
        If month >= 4 And month <= 6 Then
            quater = "QI." & year
        End If
        If month >= 7 And month <= 9 Then
            quater = "QII." & year
        End If
        If month >= 10 Then
            quater = "QIII." & year
        End If
        Return quater

    End Function
    ''' <summary>
    ''' Return Q12016
    ''' </summary>
    ''' <param name="datetime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetQuaterByFinancial(ByVal datetime As DateTime) As String
        Dim quater As String = ""

        Dim year As String = datetime.Year
        Dim month As Integer = datetime.Month
        If month <= 3 Then
            quater = "Q4" & (year - 1)
        End If
        If month >= 4 And month <= 6 Then
            quater = "Q1" & year
        End If
        If month >= 7 And month <= 9 Then
            quater = "Q2" & year
        End If
        If month >= 10 Then
            quater = "Q3" & year
        End If
        Return quater

    End Function
    ''' <summary>
    ''' Return 2016Q1
    ''' </summary>
    ''' <param name="datetime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetQuaterByFinancialYQ(ByVal datetime As DateTime) As String
        Dim quater As String = ""

        Dim year As String = datetime.Year
        Dim month As Integer = datetime.Month
        If month <= 3 Then
            quater = (year - 1) & "Q4"
        End If
        If month >= 4 And month <= 6 Then
            quater = year & "Q1"
        End If
        If month >= 7 And month <= 9 Then
            quater = year & "Q2"
        End If
        If month >= 10 Then
            quater = year & "Q3"
        End If
        Return quater

    End Function
    ''' <summary>
    ''' Return 2014Q1 (month 04-->09) or 2014Q3 (month 10-->03)
    ''' </summary>
    ''' <param name="datetime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetQuaterByFinancialBOM(ByVal datetime As DateTime) As String
        Dim quater As String = ""

        Dim year As String = datetime.Year
        Dim month As Integer = datetime.Month
        If month <= 3 Then
            quater = (year - 1) & "Q3"
        End If
        If month >= 4 And month <= 6 Then
            quater = year & "Q1"
        End If
        If month >= 7 And month <= 9 Then
            quater = year & "Q1"
        End If
        If month >= 10 Then
            quater = year & "Q3"
        End If
        Return quater

    End Function
    ''' <summary>
    ''' Return value 2012Q3
    ''' </summary>
    ''' <param name="datetime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetQuater2(ByVal datetime As DateTime) As String
        Dim quater As String = ""
        Dim year As String = datetime.Year
        Dim month As Integer = datetime.Month
        If month <= 3 Then
            quater = year & "Q1"
        End If
        If month >= 4 And month <= 6 Then
            quater = year & "Q2"
        End If
        If month >= 7 And month <= 9 Then
            quater = year & "Q3"
        End If
        If month >= 10 Then
            quater = year & "Q4"
        End If
        Return quater

    End Function
    Function GetMonthOfQuater(ByVal datetime As DateTime) As String
        Dim quater As String = ""
        Dim year As String = datetime.Year
        Dim month As Integer = datetime.Month
        If month <= 3 Then
            quater = year + "03"
        End If
        If month >= 4 And month <= 6 Then
            quater = year + "06"
        End If
        If month >= 7 And month <= 9 Then
            quater = year + "09"
        End If
        If month >= 10 Then
            quater = year + "12"
        End If
        Return quater
    End Function


#End Region

#Region "Validate"
    'Function IsNumber(ByVal textbox As TextBox) As Boolean
    '    If Not IsNumeric(textbox.Text) Then
    '        textbox.Text = ""
    '        textbox.Focus()
    '        Return False
    '    End If

    '    Return True
    'End Function
#End Region

#Region "Format Grid"
    ''' <summary>
    ''' Mergecell Datagridview
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub GridMergecell(grid As DataGridView, e As DataGridViewCellPaintingEventArgs)

        Using gridBrush As Brush = New SolidBrush(grid.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)
            Using gridLinePen As Pen = New Pen(gridBrush)
                ' Clear cell  
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds)
                ' Draw line (bottom border and right border of current cell)  
                'If next row cell has different content, only draw bottom border line of current cell  
                If e.RowIndex < grid.Rows.Count - 1 AndAlso grid.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                End If
                ' Draw right border line of current cell  
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)
                ' draw/fill content in current cell, and fill only one cell of multiple same cells  
                If Not e.Value Is Nothing And Not e.Value Is DBNull.Value Then
                    If e.RowIndex > 0 AndAlso grid.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value.ToString() = e.Value.ToString() Then

                    Else
                        e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                    End If
                End If
                e.Handled = True
            End Using
        End Using
    End Sub
    ''' <summary>
    ''' Set index first column of datagridview
    ''' </summary>
    ''' <param name="grid"></param>
    ''' <remarks></remarks>
    Sub SetIndexGrid(ByVal grid As DataGridView)
        For index As Integer = 0 To grid.RowCount - 1
            grid.Item(0, index).Value = index + 1
        Next
    End Sub
    ''' <summary>
    ''' Up currentrow of datagridview
    ''' </summary>
    ''' <param name="grid"></param>
    ''' <remarks></remarks>
    Sub GridViewUpRow(ByVal grid As DataGridView)
        If grid.CurrentRow IsNot Nothing Then
            Dim gridTemp As DataGridView = grid

            Dim totalRows As Integer = gridTemp.Rows.Count
            Dim idx As Integer = gridTemp.SelectedRows(0).Index
            If idx = 0 Then
                Return
            End If
            '   dim col As Integer = grid.SelectedCells[0].OwningColumn.Index;
            Dim rows As DataGridViewRowCollection = gridTemp.Rows
            Dim row As DataGridViewRow = rows(idx)
            rows.Remove(row)
            rows.Insert(idx - 1, row)
            gridTemp.ClearSelection()
            gridTemp.Rows(idx - 1).Selected = True

        End If
    End Sub
    ''' <summary>
    ''' Dow currentrow of datagridview
    ''' </summary>
    ''' <param name="grid"></param>
    ''' <remarks></remarks>
    Sub GridViewDown(ByVal grid As DataGridView)
        If grid.CurrentRow IsNot Nothing Then
            Dim gridTemp As DataGridView = grid

            Dim totalRows As Integer = gridTemp.Rows.Count
            Dim idx As Integer = gridTemp.SelectedRows(0).Index
            If idx = gridTemp.RowCount - 1 Then
                Return
            End If
            '   dim col As Integer = grid.SelectedCells[0].OwningColumn.Index;
            Dim rows As DataGridViewRowCollection = gridTemp.Rows
            Dim row As DataGridViewRow = rows(idx)
            rows.Remove(row)
            rows.Insert(idx + 1, row)
            gridTemp.ClearSelection()
            ' grid.Rows[idx - 1].Cells[col].Selected = true;
            gridTemp.Rows(idx + 1).Selected = True
            gridTemp.CurrentCell = gridTemp.CurrentRow.Cells(0)
        End If

    End Sub
    ''' <summary>
    ''' True is readonly, False is write
    ''' </summary>
    ''' <param name="rw"></param>
    ''' <param name="grid"></param>
    Sub SetGridReadWrite(ByVal rw As Boolean, ByVal grid As DataGridView)
        For Each c As DataGridViewColumn In grid.Columns
            c.ReadOnly = rw
        Next
    End Sub

    Sub LoadSumGrid(ByVal txt As ToolStripTextBox, ByVal grid As DataGridView)
        Dim mtotal As Decimal = 0
        txt.Text = ""
        If grid.SelectedCells.Count > 1 Then
            For Each c As DataGridViewCell In grid.SelectedCells
                If IsNumeric(c.Value) Then
                    mtotal += c.Value
                End If
            Next
            txt.Text = mtotal.ToString("N2")
        End If
    End Sub
    Sub LoadSumGrid(ByVal txt As TextBox, ByVal grid As DataGridView)
        Dim mtotal As Decimal = 0
        txt.Text = ""
        If grid.SelectedCells.Count > 1 Then
            For Each c As DataGridViewCell In grid.SelectedCells
                If IsNumeric(c.Value) Then
                    mtotal += c.Value
                End If
            Next
            txt.Text = mtotal.ToString("N2")
        End If
    End Sub

#End Region

#Region "Set Object to other, List <-->Datatable "
    Public Sub SetObjectToOther(Of T1, T2)(ByRef objOld As T1, ByRef objNew As T2)
        Dim typeOld As Type
        Dim typeNew As Type
        typeOld = objOld.GetType()
        typeNew = objNew.GetType
        Dim fieldsOld() As FieldInfo = typeOld.GetFields()
        Dim fieldsNew() As FieldInfo = typeNew.GetFields()
        For Each fOld As FieldInfo In fieldsOld
            For Each fNew As FieldInfo In fieldsNew
                If fOld.Name = fNew.Name Then
                    fNew.SetValue(objNew, fOld.GetValue(objOld))
                    Exit For
                End If
            Next
        Next

    End Sub
    ''' <summary>
    ''' Vo Thanh Son 12-Nov-2012
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="obj"></param>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Public Sub SetObjValue(Of T)(ByRef obj As T, ByVal row As DataRow)
        Try
            obj = Activator.CreateInstance(Of T)()
            If row Is Nothing Then Exit Sub
            Dim type As Type
            type = obj.GetType()
            Dim fields() As FieldInfo = type.GetFields()
            For index As Integer = 0 To fields.Length - 1
                Try
                    Dim value As Object = row(fields(index).Name.Replace(PublicConst.Key, ""))
                    If value IsNot DBNull.Value Then
                        fields(index).SetValue(obj, value)
                    Else
                        fields(index).SetValue(obj, Nothing)
                    End If
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ConvertTo(Of T)(ByVal list As IList(Of T)) As DataTable
        Dim table As DataTable = CreateTable(Of T)()
        Dim entityType As Type = GetType(T)
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(entityType)
        For Each item As T In list
            Dim row As DataRow = table.NewRow()
            For Each prop As PropertyDescriptor In properties
                row(prop.Name) = prop.GetValue(item)
            Next
            table.Rows.Add(row)
        Next
        Return table
    End Function

    Public Function ConvertTo(Of T)(ByVal rows As IList(Of DataRow)) As IList(Of T)
        Dim list As IList(Of T) = Nothing
        If rows IsNot Nothing Then
            list = New List(Of T)
            For Each row As DataRow In rows
                Dim item As T = CreateItem(Of T)(row)
                list.Add(item)
            Next
        End If
        Return list
    End Function

    Public Function ConvertTo(Of T)(ByVal table As DataTable) As IList(Of T)
        If table Is Nothing Then Return Nothing
        Dim rows As List(Of DataRow) = New List(Of DataRow)()
        For Each row As DataRow In table.Rows
            rows.Add(row)
        Next
        Return ConvertTo(Of T)(rows)
    End Function

    Public Function CreateItem(Of T)(ByVal row As DataRow) As T
        Dim obj As T
        If row IsNot Nothing Then
            obj = Activator.CreateInstance(Of T)()
            For Each column As DataColumn In row.Table.Columns
                Dim prop As PropertyInfo = obj.GetType().GetProperty(column.ColumnName)
                Try
                    Dim value As Object = row(column.ColumnName)
                    prop.SetValue(obj, value, Nothing)
                Catch
                    ' You can log something here
                    Throw
                End Try
            Next
        End If
        Return obj
    End Function

    Public Function CreateTable(Of T)() As DataTable
        Dim entityType As Type = GetType(T)
        Dim table As New DataTable(entityType.Name)
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(entityType)
        For Each prop As PropertyDescriptor In properties
            table.Columns.Add(prop.Name, prop.PropertyType)
        Next
        Return table
    End Function

#End Region

#Region "Check Workingtime"
    Function CalcWorkDay(ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal groupid As String) As Decimal
        Dim workday As Integer = 0
        Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        Dim stime As TimeSpan = endDate - startDate
        Dim para() As SqlClient.SqlParameter = GetSqlPara(startDate, endDate)
        Dim sql As String = String.Format(" select count(*) from {0} where [HolidayDate] between @StartDate and @EndDate ",
                                          PublicTable.Table_FPICS_HolidayDate)
        Dim o As Object = db.ExecuteScalar(sql, para)
        If o IsNot DBNull.Value Then
            workday = (stime.Days - o + 1)
        Else
            workday = stime.Days + 1
        End If
        Dim para2(3) As SqlClient.SqlParameter
        para2(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(startDate))
        para2(1) = New SqlClient.SqlParameter("@EndDate", GetEndDate(endDate))
        para2(2) = New SqlClient.SqlParameter("@WDDay", workday)
        para2(3) = New SqlClient.SqlParameter("@GroupID", groupid)
        Return db.ExecuteScalarSP("[sp_WTFC_GetWorkDay]", para2)
    End Function
    Function CheckApproved(ByVal LockDate As DateTime, ByVal groupID As String) As Boolean
        Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        Dim obj As New WT_LockGroup With {
            .DateLock_K = GetStartDate(LockDate),
            .GroupID_K = groupID
        }
        db.GetObject(obj)
        If obj.Approve Then
            XtraMessageBox.Show(String.Format("This group({0}) was Approved.", groupID), "Approved")
            Return True
        End If

        Return False
    End Function
    Function CheckLockgroup2(ByVal LockDate As DateTime, ByVal group2ID As String) As Boolean
        Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        Dim obj As New WT_LockGroup
        Dim objGroup As New WT_Group2 With {
            .Group2ID_K = group2ID
        }
        db.GetObject(objGroup)
        obj.DateLock_K = GetStartDate(LockDate)
        obj.GroupID_K = objGroup.GroupID
        db.GetObject(obj)
        If obj.IsLock Then
            XtraMessageBox.Show(String.Format("This group({0}) was locked.", objGroup.GroupID), "Lock")
            Return True
        End If

        Return False
    End Function
    Function CheckLockGroup1(ByVal LockDate As DateTime, ByVal groupID As String) As Boolean
        Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        Dim obj As New WT_LockGroup With {
            .DateLock_K = GetStartDate(LockDate),
            .GroupID_K = groupID
        }
        db.GetObject(obj)
        If obj.IsLock Then
            XtraMessageBox.Show(String.Format("This group({0}) was locked.", groupID), "Lock")
            Return True
        End If
        Return False
    End Function
    Function CheckLockGroup1NotShow(ByVal LockDate As DateTime, ByVal groupID As String) As Boolean
        Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
        Dim obj As New WT_LockGroup With {
            .DateLock_K = GetStartDate(LockDate),
            .GroupID_K = groupID
        }
        db.GetObject(obj)
        If obj.IsLock Then
            Return True
        End If
        Return False
    End Function
#End Region

#Region "HOST"
    ''' <summary>
    ''' Get IP current of computer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetIP() As String
        Dim strHostName As String = ""
        strHostName = System.Net.Dns.GetHostName()
        Dim ipEntry As IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)
        Dim addr() As IPAddress = ipEntry.AddressList
        Return addr(addr.Length - 1).ToString()
    End Function
    ''' <summary>
    ''' Get computername of this computer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetHostName() As String
        Return Environ("COMPUTERNAME")
    End Function
    ''' <summary>
    ''' Get username current login this computer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetUserName() As String
        Return Environ("USERNAME")
    End Function
#End Region

#Region "Para Sql, Odbc, Oledb, Oracel,..."
    ''' <summary>
    ''' Return para vith @Value
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    Function GetParameter(ByVal obj As Object) As SqlClient.SqlParameter()
        Dim para(0) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Value", obj)
        Return para
    End Function

    ''' <summary>
    ''' Return with para name @StartDate,@EndDate
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="endDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetSqlPara(ByVal startDate As DateTime, ByVal endDate As DateTime) As SqlClient.SqlParameter()
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", startDate)
        para(1) = New SqlClient.SqlParameter("@EndDate", endDate)
        Return para
    End Function
    ''' <summary>
    ''' Return with para name @StartDate,@EndDate
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="endDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetOdbcPara(ByVal startDate As DateTime, ByVal endDate As DateTime) As OdbcParameter()
        Dim para(1) As OdbcParameter
        para(0) = New OdbcParameter("@StartDate", startDate)
        para(1) = New OdbcParameter("@EndDate", endDate)
        Return para
    End Function
    ''' <summary>
    ''' Return with para name @StartDate,@EndDate
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="endDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetOracelPara(ByVal startDate As DateTime, ByVal endDate As DateTime) As OracleClient.OracleParameter()
        Dim para(1) As OracleParameter
        para(0) = New OracleParameter("@StartDate", startDate)
        para(1) = New OracleParameter("@EndDate", endDate)
        Return para
    End Function
    ''' <summary>
    ''' Return with para name @StartDate,@EndDate
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="endDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetOledbPara(ByVal startDate As DateTime, ByVal endDate As DateTime) As OleDbParameter()
        Dim para(1) As OleDbParameter
        para(0) = New OleDbParameter("@StartDate", startDate)
        para(1) = New OleDbParameter("@EndDate", endDate)
        Return para
    End Function

#End Region

#Region "AS400"


#End Region

#Region "Math..."
    Public Function RoundDown(ByVal number As Double, ByVal decimalPlaces As Integer) As Double
        Return Math.Floor(number * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces)
    End Function

    Public Function RoundUp(ByVal number As Double, ByVal decimalPlaces As Integer) As Double
        Return Math.Ceiling(number * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces)
    End Function
#End Region

#Region "Random"
    ''' <summary>
    ''' This function shuffle list
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="list"></param>
    ''' <remarks></remarks>
    Public Sub Shuffle(Of T)(ByRef list As IList(Of T))
        Dim provider As New RNGCryptoServiceProvider()
        Dim n As Integer = list.Count
        While (n > 1)
            Dim box(1) As Byte
            Do While (Not (box(0) < n * (Byte.MaxValue / n)))
                provider.GetBytes(box)
            Loop
            Dim k As Integer = (box(0) Mod n)
            n -= 1
            Dim value As T = list(k)
            list(k) = list(n)
            list(n) = value
        End While
    End Sub
    ''' <summary>
    ''' This function shuffle list 
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="list"></param>
    ''' <remarks></remarks>
    Sub QuickShuffle(Of T)(ByRef list As IList(Of T))
        Dim rng = New Random()
        Dim n = list.Count
        While (n > 1)
            n = n - 1
            Dim k = rng.Next(n + 1)
            Dim value As T = list(k)
            list(k) = list(n)
            list(n) = value
        End While
    End Sub
#End Region

#Region "Get Mail"
    Function GetEmailStaffTeam() As List(Of String)
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation='Staff' or  e.Observation='Team' " +
                                            " order by m.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        For Each row As DataRow In dtData.Rows
            lst.Add(row("Mail"))
        Next
        Return lst
    End Function
    Function GetEmailStaffTeamDataTable() As DataTable
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation='Staff' or  e.Observation='Team' " +
                                            " order by m.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        Return dtData
    End Function
    Function GetEmailLine() As List(Of String)
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID,  m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation='Line' " +
                                            " order by m.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        For Each row As DataRow In dtData.Rows
            lst.Add(row("Mail"))
        Next
        Return lst
    End Function
    Function GetEmailLine(section As String) As List(Of String)
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID,  m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation='Line' and e.Section='{0}' " +
                                            " order by m.Mail  ",
                                            section)
        Dim dtData As DataTable = _db.FillDataTable(sql)
        For Each row As DataRow In dtData.Rows
            lst.Add(row("Mail"))
        Next
        Return lst
    End Function
    Function GetEmailSCQT_CC() As List(Of String)
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT EMail " +
                                          " FROM  [MFPC_EmailLineGroupCC] e")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        For Each row As DataRow In dtData.Rows
            lst.Add(row("EMail"))
        Next
        Return lst
    End Function

    Function GetEmailSCQT_MG(ByVal empID As String) As List(Of String)
        Dim lst As New List(Of String)
        Dim sql As String = String.Format("SELECT [Manager] as EMail  from.[OT_SectionMail] m " +
                                            " inner join OT_Employee e " +
                                            " on m.Section=e.Section" +
                                            " where e.EmpID='{0}' ", empID)
        Dim dtData As DataTable = _db.FillDataTable(sql)
        For Each row As DataRow In dtData.Rows
            lst.Add(row("EMail"))
        Next
        Return lst
    End Function

    Function GetEmailLineDataTable(section As String) As DataTable
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID,  m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation='Line' and e.Section='{0}' " +
                                            " order by m.Mail  ",
                                            section)
        Dim dtData As DataTable = _db.FillDataTable(sql)
        Return dtData
    End Function
    Function GetEmailLineDataTable() As DataTable
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID,  m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation='Line' " +
                                            " order by m.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        Return dtData
    End Function
    Function GetEmailGroup() As List(Of String)
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation='Group Leader' " +
                                            " order by m.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        For Each row As DataRow In dtData.Rows
            lst.Add(row("Mail"))
        Next
        Return lst
    End Function
    Function GetEmailGroup(section As String) As List(Of String)
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation='Group Leader' and e.Section='{0}' " +
                                            " order by m.Mail  ",
                                            section)
        Dim dtData As DataTable = _db.FillDataTable(sql)
        For Each row As DataRow In dtData.Rows
            lst.Add(row("Mail"))
        Next
        Return lst
    End Function
    Function GetEmailGroupDatatable() As DataTable
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation='Group Leader' " +
                                            " order by m.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        Return dtData
    End Function
    Function GetEmailLineGroupDatatable() As DataTable
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation='Group Leader' or e.Observation='Line'   " +
                                            " order by m.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        Return dtData
    End Function
    Function GetEmailGroupDatatable(section As String) As DataTable
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation='Group Leader' and e.Section='{0}' " +
                                            " order by m.Mail  ",
                                            section)
        Dim dtData As DataTable = _db.FillDataTable(sql)
        Return dtData
    End Function
    Function GetEmailManager() As List(Of String)
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " right join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation like '%Manager%' or  " +
                                            " e.Observation like '%General%' or e.Observation like '%Director%' " +
                                            " order by m.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        For Each row As DataRow In dtData.Rows
            lst.Add(row("Mail"))
        Next
        Return lst
    End Function
    Function GetEmailManagerDatatable() As DataTable
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " right join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation like '%Manager%' or  " +
                                            " e.Observation like '%General%' or e.Observation like '%Director%' " +
                                            " order by m.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        Return dtData
    End Function
    Function GetEmailDManager() As List(Of String)
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " right join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation='%General%' or e.Observation='%Director%'  " +
                                            " order by m.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        For Each row As DataRow In dtData.Rows
            lst.Add(row("Mail"))
        Next
        Return lst
    End Function
    Function GetEmailHRA() As List(Of String)
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT EMail from HRA_Email")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        For Each row As DataRow In dtData.Rows
            lst.Add(row("EMail"))
        Next
        Return lst
    End Function
    Function GetEmailDManagerDataTable() As DataTable
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " right join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation='General Manager'  " +
                                            " order by m.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        Return dtData
    End Function
    Function GetEmailAll() As List(Of String)
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " right join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " order by m.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        For Each row As DataRow In dtData.Rows
            lst.Add(row("Mail"))
        Next
        Return lst
    End Function
    Function GetEmailAllHR() As List(Of String)
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT  EMail from HRT_Email " +
                                          " order by m.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        For Each row As DataRow In dtData.Rows
            lst.Add(row("EMail"))
        Next
        Return lst
    End Function
    Function GetEmailAll(section As String) As List(Of String)
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " right join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Section='{0}' " +
                                            " order by m.Mail  ",
                                            section)
        Dim dtData As DataTable = _db.FillDataTable(sql)
        For Each row As DataRow In dtData.Rows
            lst.Add(row("Mail"))
        Next
        Return lst
    End Function
    Function GetEmailAllDataTable() As DataTable
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail,e.Section " +
                                            " FROM  [OT_Employee] e" +
                                            " right join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " order by m.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        Return dtData
    End Function

    Function GetEmailAllDataTable(isOff As Boolean) As DataTable
        If isOff Then
            Return GetEmailAllDataTable()
        Else
            Dim lst As New List(Of String)
            Dim sql As String = String.Format("SELECT '' as EmpID, '' as Mail union all  SELECT m.EmpID, m.Mail " +
                                                " FROM  [OT_Employee] e" +
                                                " right join OT_Mail m" +
                                                " on e.EmpID=m.EMpID " +
                                                "  where m.Mail<>'' and m.EmpID not in (SELECT  [EmpID] " +
                                                "  FROM  [OT_HolidayStaff]" +
                                                "  where HolidayDate= cast(getdate() as date)) " +
                                                "  order by Mail  ")
            Dim dtData As DataTable = _db.FillDataTable(sql)
            Return dtData
        End If
    End Function
    ''' <summary>
    ''' Example: Information Technonoly (or IT), Production Planning (or PP)
    ''' </summary>
    ''' <param name="section"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetEmailAllDataTable(ByVal section As String) As DataTable
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Section = '{0}' or e.SectionSort = '{0}' " +
                                            " order by m.Mail  ",
                                            section)
        Dim dtData As DataTable = _db.FillDataTable(sql)
        Return dtData
    End Function

    Function GetEmailAllDataTable(ByVal section As String, isOff As Boolean) As DataTable
        If isOff Then
            Return GetEmailAllDataTable(section)
        Else
            Dim lst As New List(Of String)
            Dim sql As String = String.Format(" SELECT '' as EmpID, '' as Mail union all SELECT m.EmpID, m.Mail " +
                                                " FROM  [OT_Employee] e" +
                                                " inner join OT_Mail m" +
                                                " on e.EmpID=m.EMpID" +
                                                " where (e.Section = '{0}' or e.SectionSort = '{0}') " +
                                                " and m.Mail<>'' and m.EmpID not in (SELECT  [EmpID] " +
                                                "  FROM [NDVERP].[dbo].[OT_HolidayStaff]" +
                                                "  where HolidayDate= cast(getdate() as date)) " +
                                                " order by  Mail  ",
                                                section)
            Dim dtData As DataTable = _db.FillDataTable(sql)
            Return dtData
        End If
    End Function

    ''' <summary>
    ''' listsectionSort: 'QA','QC','IT',...
    ''' </summary>
    ''' <param name="listsectionSort"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetEmailDataTableByListSection(listsectionSort As String) As DataTable
        Dim lst As New List(Of String)
        Dim sql As String = String.Format(" SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.SectionSort in ({0}) " +
                                            " order by m.Mail  ",
                                            listsectionSort)
        Dim dtData As DataTable = _db.FillDataTable(sql)
        Return dtData
    End Function
#End Region

#Region "Mail Outlook"
    Function GetOLEmail(Optional section As String = Nothing,
                         Optional ByVal groupName As String = Nothing,
                         Optional ByVal Observation As String = Nothing) As List(Of String)
        Dim lst As New List(Of String)
        Dim condition As String = " 1=1 "
        If section IsNot Nothing Then
            condition += String.Format(" and e.Section like '%{0}%' ", section)
        End If
        If groupName IsNot Nothing Then
            condition += String.Format(" and e.GroupName like '%{0}%' ", groupName)
        End If
        If Observation IsNot Nothing Then
            condition += String.Format(" and e.Observation like '%{0}%' ", Observation)
        End If
        Dim sql As String = String.Format("select * from( select '' as EmpID,'' as Mail union all " +
                                              " SELECT m.EmpID, m.[Mail] as Mail " +
                                                " FROM  [OT_Employee] e" +
                                                " inner join OT_Mail m" +
                                                " on e.EmpID=m.EMpID" +
                                                " where {0} )s" +
                                                " order by s.Mail  ",
                                                condition)
        Dim dtData As DataTable = _db.FillDataTable(sql)
        For Each row As DataRow In dtData.Rows
            lst.Add(row("Mail"))
        Next
        Return lst
    End Function

    Function GetOLEmailTB(Optional section As String = Nothing,
                     Optional ByVal groupName As String = Nothing,
                     Optional ByVal Observation As String = Nothing) As DataTable
        Dim lst As New List(Of String)
        Dim condition As String = " 1=1 "
        If section IsNot Nothing Then
            condition += String.Format(" and e.Section like '%{0}%' ", section)
        End If
        If groupName IsNot Nothing Then
            condition += String.Format(" and e.GroupName like '%{0}%' ", groupName)
        End If
        If Observation IsNot Nothing Then
            condition += String.Format(" and e.Observation like '%{0}%' ", Observation)
        End If
        Dim sql As String = String.Format("select * from( select '' as EmpID,'' as Mail union all " +
                                          " SELECT m.EmpID, m.[Mail] as Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where {0} )s" +
                                            " order by s.Mail  ",
                                            condition)
        Dim dtData As DataTable = _db.FillDataTable(sql)
        Return dtData
    End Function

    Function GetOLEmailTBManagerAndUp() As DataTable
        Dim sql As String = String.Format("select * from( select '' as EmpID,'' as Mail union all " +
                                          " SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation like '%manager%' or " +
                                            " e.Observation like '%factory%' or e.Observation like '%bussiness%')s" +
                                            " order by s.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        Return dtData
    End Function

    Function GetOLEmailTBGroupAndUp() As DataTable
        Dim sql As String = String.Format("select * from( select '' as EmpID,'' as Mail union all " +
                                          " SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID" +
                                            " where e.Observation like '%Group%' or e.Observation like '%manager%' or " +
                                            " e.Observation like '%factory%' or e.Observation like '%bussiness%')s" +
                                            " order by s.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        Return dtData
    End Function

    Function GetOLEmailTBAll() As DataTable
        Dim sql As String = String.Format("select * from( select '' as EmpID,'' as Mail union all " +
                                          " SELECT m.EmpID, m.Mail " +
                                            " FROM  [OT_Employee] e" +
                                            " inner join OT_Mail m" +
                                            " on e.EmpID=m.EMpID  where m.Mail<>'')s" +
                                            " order by s.Mail  ")
        Dim dtData As DataTable = _db.FillDataTable(sql)
        Return dtData
    End Function

    Function GetListMail(ByVal lstEmail As Object) As List(Of String)
        If lstEmail Is Nothing Then
            Return Nothing
        ElseIf lstEmail.GetType.Name = "String" Then
            Return GetListMail(CType(lstEmail, String))
        ElseIf lstEmail.GetType.Name = "Array" Or lstEmail.GetType.Name = "String[]" Then
            Return GetListMail(CType(lstEmail, Array))
        ElseIf lstEmail.GetType.Name.Contains("List") Then
            Return CType(lstEmail, List(Of String))
        End If
        Return Nothing
    End Function

    Function GetListMail(ByVal lstEmail As String) As List(Of String)
        If lstEmail Is Nothing Then
            Return Nothing
        End If

        Dim lst As New List(Of String)

        Dim separators() As String = {",", ";"}

        For Each m As String In lstEmail.Split(separators, StringSplitOptions.RemoveEmptyEntries)
            lst.Add(m)
        Next

        If lst.Count > 0 Then
            Return lst
        Else
            Return Nothing
        End If

    End Function

    Function GetListMail(ByVal lstEmail As Array) As List(Of String)
        If lstEmail Is Nothing Then
            Return Nothing
        End If

        Dim lst As New List(Of String)

        For Each m As String In lstEmail
            lst.Add(m)
        Next

        If lst.Count > 0 Then
            Return lst
        Else
            Return Nothing
        End If

    End Function

    Function GetListFile(ByVal lstFile As Object) As List(Of String)
        If lstFile Is Nothing Then
            Return Nothing
        ElseIf lstFile.GetType.Name = "String" Then
            Return GetListFile(CType(lstFile, String))
        ElseIf lstFile.GetType.Name = "Array" Then
            Return GetListFile(CType(lstFile, Array))
        End If
        Return Nothing
    End Function

    Function GetListFile(ByVal lstFile As String) As List(Of String)
        If lstFile Is Nothing Then
            Return Nothing
        End If

        Dim lst As New List(Of String)

        Dim separators() As String = {",", ";"}

        For Each m As String In lstFile.Split(separators, StringSplitOptions.RemoveEmptyEntries)
            If File.Exists(m) Then
                lst.Add(m)
            End If
        Next

        If lst.Count > 0 Then
            Return lst
        Else
            Return Nothing
        End If

    End Function

    Function GetListFile(ByVal lstFile As Array) As List(Of String)
        If lstFile Is Nothing Then
            Return Nothing
        End If

        Dim lst As New List(Of String)

        For Each m As String In lstFile
            If File.Exists(m) Then
                lst.Add(m)
            End If
        Next

        If lst.Count > 0 Then
            Return lst
        Else
            Return Nothing
        End If

    End Function

#End Region

    Function NumberToText(ByVal n As Long) As String

        Select Case n
            Case 0
                Return ""

            Case 1 To 19
                Dim arr() As String = {"One", "Two", "Three", "Four", "Five", "Six", "Seven",
                  "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
                    "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
                Return arr(n - 1) & " "

            Case 20 To 99
                Dim arr() As String = {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"}
                Return arr(n \ 10 - 2) & " " & NumberToText(n Mod 10)

            Case 100 To 199
                Return "One Hundred " & NumberToText(n Mod 100)

            Case 200 To 999
                Return NumberToText(n \ 100) & "Hundreds " & NumberToText(n Mod 100)

            Case 1000 To 1999
                Return "One Thousand " & NumberToText(n Mod 1000)

            Case 2000 To 999999
                Return NumberToText(n \ 1000) & "Thousands " & NumberToText(n Mod 1000)

            Case 1000000 To 1999999
                Return "One Million " & NumberToText(n Mod 1000000)

            Case 1000000 To 999999999
                Return NumberToText(n \ 1000000) & "Millions " & NumberToText(n Mod 1000000)

            Case 1000000000 To 1999999999
                Return "One Billion " & NumberToText(n Mod 1000000000)

            Case Else
                Return NumberToText(n \ 1000000000) & "Billion " _
                  & NumberToText(n Mod 1000000000)
        End Select
    End Function

#Region "GridControl"
    Public Sub GridControlReadOnly(gridv As GridView, RW As Boolean)
        For Each c As GridColumn In gridv.Columns
            c.OptionsColumn.ReadOnly = RW
        Next
    End Sub

    Public Sub GridControlSetWidth(gridv As GridView, width As Integer)
        For Each c As GridColumn In gridv.Columns
            c.Width = width
        Next
    End Sub

    Public Sub GridControlSetWidth(gridv As GridView, cols As String, width As Integer)
        For Each c As String In cols.Split(",")
            gridv.Columns(c).Width = width
        Next
    End Sub

    Public Sub GridControlSetBestfit(gridv As GridView, cols As String)
        For Each c As String In cols.Split(",")
            gridv.Columns(c).BestFit()
        Next
    End Sub

    Public Sub GridControlSetBestfit(gridv As GridView, maxWidth As Integer)
        gridv.BestFitColumns()
        For Each c As GridColumn In gridv.Columns
            If c.Width > maxWidth Then
                c.Width = maxWidth
            End If
        Next
    End Sub

    Public Sub GridControlSetFormatNumber(gridv As GridView, StringCols As String, N As Integer)
        For Each c As String In StringCols.Split(",")
            With gridv.Columns(c)
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                .DisplayFormat.FormatString = "N" & N
                .SummaryItem.DisplayFormat = "{0:n" & N & "}"
            End With
        Next
    End Sub

    Public Sub GridControlSetFormatDateAndTime(gridv As GridView, StringCols As String)
        Dim editDate As New RepositoryItemDateEdit
        editDate.EditMask = "dd-MMM-yyyy HH:mm"
        editDate.Mask.UseMaskAsDisplayFormat = True
        For Each c As String In StringCols.Split(",")
            With gridv.Columns(c)
                .ColumnEdit = editDate

                '.DisplayFormat.FormatType = Utils.FormatType.DateTime
                '.DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm"
            End With
        Next
    End Sub

    Public Sub GridControlSetFormatTime(gridv As GridView, StringCols As String)
        Dim editDate As New RepositoryItemDateEdit
        editDate.EditMask = "HH:mm"
        editDate.Mask.UseMaskAsDisplayFormat = True
        For Each c As String In StringCols.Split(",")
            With gridv.Columns(c)
                .ColumnEdit = editDate

                '.DisplayFormat.FormatType = Utils.FormatType.DateTime
                '.DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm"
            End With
        Next
    End Sub

    Public Sub GridControlSetColor(gridv As GridView, cols As String, myColor As Color)
        For Each c As GridColumn In gridv.Columns
            If c.FieldName.Contains(cols) Then
                c.AppearanceCell.BackColor = myColor
            End If
        Next
    End Sub

    Public Sub GridControlSetColorEdit(gridv As GridView)
        gridv.OptionsBehavior.Editable = True
        gridv.OptionsBehavior.ReadOnly = False
        gridv.OptionsSelection.MultiSelect = True
        gridv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect
        For Each c As GridColumn In gridv.Columns
            If c.ReadOnly = False Then
                c.AppearanceHeader.BackColor = Color.Wheat
                c.AppearanceHeader.Options.UseBackColor = True
                c.OptionsColumn.AllowEdit = True
            Else
                c.OptionsColumn.AllowEdit = False
            End If
        Next
    End Sub

    Public Sub GridControlSetColumnEdit(gridv As GridView)
        gridv.OptionsBehavior.Editable = True
        gridv.OptionsBehavior.ReadOnly = False
        gridv.OptionsSelection.MultiSelect = True
        gridv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect
        For Each c As GridColumn In gridv.Columns
            If c.ReadOnly = False Then
                c.OptionsColumn.AllowEdit = True
            Else
                c.OptionsColumn.AllowEdit = False
            End If
        Next
    End Sub

    Public Sub GridControlSetColorReadonly(gridv As GridView)
        gridv.OptionsBehavior.Editable = False
        For Each c As GridColumn In gridv.Columns
            c.AppearanceHeader.BackColor = Color.Empty
        Next
    End Sub
    ''' <summary>
    ''' Định dạng chuẩn của Gridview
    ''' </summary>
    ''' <param name="gridv"></param>
    ''' <param name="colFixed"></param>
    ''' <param name="colTime"></param>
    ''' <param name="colPercent"></param>
    Public Sub GridControlSetFormat(gridv As GridView,
                                    Optional colFixed As Integer = -1,
                                    Optional colTime As String = "",
                                    Optional colPercent As String = "")
        gridv.OptionsBehavior.SummariesIgnoreNullValues = True
        gridv.OptionsBehavior.Editable = False
        gridv.OptionsSelection.MultiSelect = True
        gridv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect
        gridv.OptionsSelection.EnableAppearanceHotTrackedRow = Utils.DefaultBoolean.True
        gridv.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        If gridv.GridControl IsNot Nothing Then
            gridv.GridControl.UseEmbeddedNavigator = True
        End If
        gridv.OptionsClipboard.CopyColumnHeaders = Utils.DefaultBoolean.False
        gridv.OptionsView.ColumnHeaderAutoHeight = Utils.DefaultBoolean.True
        gridv.OptionsView.ColumnAutoWidth = False
        Dim isShowFooter As Boolean = False
        For Each c As GridColumn In gridv.Columns
            c.AppearanceHeader.BackColor = Color.Empty
            If c.Visible = True Then
                c.Summary.Clear()
                'c.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                If c.VisibleIndex <= colFixed Then
                    c.Fixed = FixedStyle.Left
                End If
                If c.ColumnType.Name = "String" Then
                    Continue For
                ElseIf c.ColumnType.Name = "Decimal" Or c.ColumnType.Name = "Double" Then
                    c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    c.DisplayFormat.FormatString = "N2"

                    c.Summary.Add(summaryType:=DevExpress.Data.SummaryItemType.Sum)
                    c.SummaryItem.DisplayFormat = "{0:n2}"
                    isShowFooter = True
                    If colPercent <> "" Then
                        If colPercent.ToLower.Contains(c.FieldName.ToLower) Then
                            c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            c.DisplayFormat.FormatString = "p"
                        End If
                    ElseIf c.FieldName.Contains("%") Then
                        c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        c.DisplayFormat.FormatString = "p"
                    End If
                ElseIf c.ColumnType.Name.Contains("Int") Then
                    c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    c.DisplayFormat.FormatString = "N0"

                    c.Summary.Add(summaryType:=DevExpress.Data.SummaryItemType.Sum)
                    c.SummaryItem.DisplayFormat = "{0:n0}"
                    isShowFooter = True
                    'ElseIf c.ColumnType.Name = "Double" Then
                    '    'c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    '    'c.DisplayFormat.FormatString = "N4"

                    '    c.Summary.Add(summaryType:=DevExpress.Data.SummaryItemType.Sum)
                    '    c.SummaryItem.DisplayFormat = "{0:n4}"
                    '    isShowFooter = True
                ElseIf c.ColumnType.Name = "DateTime" Then
                    'c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    'c.DisplayFormat.FormatString = "dd-MMM-yyyy"
                    Dim editDate As New RepositoryItemDateEdit
                    editDate.EditMask = "dd-MMM-yyyy"
                    editDate.Mask.UseMaskAsDisplayFormat = True
                    c.ColumnEdit = editDate
                    If colTime <> "" Then
                        If colTime.ToLower.Contains(c.FieldName.ToLower) Then
                            editDate.EditMask = "HH:mm"
                            'c.DisplayFormat.FormatString = "HH:mm"
                            'c.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
                        End If
                    Else
                        If c.FieldName.Contains("CreateDate") Or c.FieldName.Contains("CreatedDate") Then
                            editDate.EditMask = "dd-MMM-yyyy HH:mm"

                            'c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            'c.DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm"
                        End If
                    End If
                End If


            End If
        Next
        gridv.OptionsView.ShowFooter = isShowFooter
    End Sub
    ''' <summary>
    ''' Định dạng cho gridview đang trạng thái Edit
    ''' </summary>
    ''' <param name="gridv"></param>
    ''' <param name="colFixed"></param>
    ''' <param name="colTime"></param>
    ''' <param name="colPercent"></param>
    Public Sub GridControlSetFormatEdit(gridv As GridView,
                                    Optional colFixed As Integer = -1,
                                    Optional colTime As String = "",
                                    Optional colPercent As String = "")
        gridv.OptionsBehavior.SummariesIgnoreNullValues = True
        gridv.OptionsSelection.MultiSelect = True
        gridv.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        gridv.GridControl.UseEmbeddedNavigator = True
        gridv.OptionsClipboard.CopyColumnHeaders = Utils.DefaultBoolean.False
        gridv.OptionsView.ColumnHeaderAutoHeight = Utils.DefaultBoolean.True
        gridv.OptionsView.ColumnAutoWidth = False
        gridv.OptionsSelection.EnableAppearanceHotTrackedRow = Utils.DefaultBoolean.True
        Dim isShowFooter As Boolean = False
        For Each c As GridColumn In gridv.Columns
            If c.Visible = True Then
                c.Summary.Clear()
                'c.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                If c.VisibleIndex <= colFixed Then
                    c.Fixed = FixedStyle.Left
                End If
                If c.ColumnType.Name = "String" Then
                    Continue For
                ElseIf c.ColumnType.Name = "Decimal" Or c.ColumnType.Name = "Double" Then
                    c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    c.DisplayFormat.FormatString = "N2"

                    c.Summary.Add(summaryType:=DevExpress.Data.SummaryItemType.Sum)
                    c.SummaryItem.DisplayFormat = "{0:n2}"
                    isShowFooter = True
                    If colPercent <> "" Then
                        If colPercent.ToLower.Contains(c.FieldName.ToLower) Then
                            c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            c.DisplayFormat.FormatString = "p"
                        End If
                    End If
                ElseIf c.ColumnType.Name.Contains("Int") Then
                    c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    c.DisplayFormat.FormatString = "N0"

                    c.Summary.Add(summaryType:=DevExpress.Data.SummaryItemType.Sum)
                    c.SummaryItem.DisplayFormat = "{0:n0}"
                    isShowFooter = True
                    'ElseIf c.ColumnType.Name = "Double" Then
                    '    'c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    '    'c.DisplayFormat.FormatString = "N4"

                    '    c.Summary.Add(summaryType:=DevExpress.Data.SummaryItemType.Sum)
                    '    c.SummaryItem.DisplayFormat = "{0:n4}"
                    '    isShowFooter = True
                ElseIf c.ColumnType.Name = "DateTime" Then
                    'c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    'c.DisplayFormat.FormatString = "dd-MMM-yyyy"
                    Dim editDate As New RepositoryItemDateEdit
                    editDate.EditMask = "dd-MMM-yyyy"
                    editDate.Mask.UseMaskAsDisplayFormat = True
                    c.ColumnEdit = editDate
                    If colTime <> "" Then
                        If colTime.ToLower.Contains(c.FieldName.ToLower) Then
                            editDate.EditMask = "HH:mm"
                            'c.DisplayFormat.FormatString = "HH:mm"
                            'c.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
                        End If
                    Else
                        If c.FieldName.Contains("CreateDate") Or c.FieldName.Contains("CreatedDate") Then
                            editDate.EditMask = "dd-MMM-yyyy HH:mm"

                            'c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            'c.DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm"
                        End If
                    End If
                End If


            End If
        Next
        gridv.OptionsView.ShowFooter = isShowFooter
    End Sub
    ''' <summary>
    ''' Chỉ format không phục hồi mặc định. Áp dụng cho gridview detail
    ''' </summary>
    ''' <param name="gridv"></param>
    ''' <param name="colFixed"></param>
    ''' <param name="colTime"></param>
    ''' <param name="colPercent"></param>
    Public Sub GridControlSetFormatDetail(gridv As GridView,
                                    Optional colFixed As Integer = -1,
                                    Optional colTime As String = "",
                                    Optional colPercent As String = "")
        gridv.OptionsBehavior.SummariesIgnoreNullValues = True
        If gridv.GridControl IsNot Nothing Then
            gridv.GridControl.UseEmbeddedNavigator = True
        End If
        gridv.OptionsClipboard.CopyColumnHeaders = Utils.DefaultBoolean.False
        gridv.OptionsView.ColumnHeaderAutoHeight = Utils.DefaultBoolean.True
        gridv.OptionsView.ColumnAutoWidth = False
        gridv.OptionsSelection.EnableAppearanceHotTrackedRow = Utils.DefaultBoolean.True
        For Each c As GridColumn In gridv.Columns
            If c.Visible = True Then
                c.Summary.Clear()
                'c.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                If c.VisibleIndex <= colFixed Then
                    c.Fixed = FixedStyle.Left
                End If
                If c.ColumnType.Name = "String" Then
                    Continue For
                ElseIf c.ColumnType.Name = "Decimal" Or c.ColumnType.Name = "Double" Then
                    c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    c.DisplayFormat.FormatString = "N2"

                    c.Summary.Add(summaryType:=DevExpress.Data.SummaryItemType.Sum)
                    c.SummaryItem.DisplayFormat = "{0:n2}"
                    If colPercent <> "" Then
                        If colPercent.ToLower.Contains(c.FieldName.ToLower) Or c.FieldName.Contains(colPercent) Then
                            c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            c.DisplayFormat.FormatString = "p"
                        End If
                    End If
                ElseIf c.ColumnType.Name.Contains("Int") Then
                    c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    c.DisplayFormat.FormatString = "N0"

                    c.Summary.Add(summaryType:=DevExpress.Data.SummaryItemType.Sum)
                    c.SummaryItem.DisplayFormat = "{0:n0}"
                ElseIf c.ColumnType.Name = "DateTime" Then
                    'c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    'c.DisplayFormat.FormatString = "dd-MMM-yyyy"
                    Dim editDate As New RepositoryItemDateEdit
                    editDate.EditMask = "dd-MMM-yyyy"
                    editDate.Mask.UseMaskAsDisplayFormat = True
                    c.ColumnEdit = editDate
                    If colTime <> "" Then
                        If colTime.ToLower.Contains(c.FieldName.ToLower) Then
                            editDate.EditMask = "HH:mm"
                            'c.DisplayFormat.FormatString = "HH:mm"
                            'c.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
                        End If
                    Else
                        If c.FieldName.Contains("CreateDate") Or c.FieldName.Contains("CreatedDate") Then
                            editDate.EditMask = "dd-MMM-yyyy HH:mm"

                            'c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            'c.DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm"
                        End If
                    End If
                End If


            End If
        Next
    End Sub

    Public Sub GridControlSetFormatMM(gridv As GridView,
                                    Optional colFixed As Integer = -1,
                                    Optional colTime As String = "",
                                    Optional colPercent As String = ""
                                     )
        gridv.OptionsBehavior.SummariesIgnoreNullValues = True
        gridv.OptionsBehavior.Editable = False
        gridv.OptionsSelection.MultiSelect = True
        gridv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect
        gridv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        gridv.OptionsSelection.EnableAppearanceHotTrackedRow = Utils.DefaultBoolean.True
        gridv.OptionsView.ColumnHeaderAutoHeight = Utils.DefaultBoolean.True
        gridv.OptionsView.ColumnAutoWidth = False
        gridv.GridControl.UseEmbeddedNavigator = True
        gridv.OptionsClipboard.CopyColumnHeaders = Utils.DefaultBoolean.False
        Dim isShowFooter As Boolean = False
        For Each c As GridColumn In gridv.Columns
            If c.Visible = True Then
                c.Summary.Clear()
                'c.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                If c.VisibleIndex <= colFixed Then
                    c.Fixed = FixedStyle.Left
                End If

                If c.ColumnType.Name = "String" Then
                    Continue For
                ElseIf c.ColumnType.Name = "Decimal" Or c.ColumnType.Name = "Double" Then
                    c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    c.DisplayFormat.FormatString = "N2"

                    c.Summary.Add(summaryType:=DevExpress.Data.SummaryItemType.Sum)
                    c.SummaryItem.DisplayFormat = "{0:n2}"
                    isShowFooter = True
                    If colPercent <> "" Then
                        If colPercent.ToLower.Contains(c.FieldName.ToLower) Then
                            c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            c.DisplayFormat.FormatString = "p"
                        End If
                    End If
                ElseIf c.ColumnType.Name.Contains("Int") Then
                    c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    c.DisplayFormat.FormatString = "N0"

                    c.Summary.Add(summaryType:=DevExpress.Data.SummaryItemType.Sum)
                    c.SummaryItem.DisplayFormat = "{0:n0}"
                    isShowFooter = True
                    'ElseIf c.ColumnType.Name = "Double" Then
                    '    'c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    '    'c.DisplayFormat.FormatString = "N4"

                    '    c.Summary.Add(summaryType:=DevExpress.Data.SummaryItemType.Sum)
                    '    c.SummaryItem.DisplayFormat = "{0:n4}"
                    '    isShowFooter = True
                ElseIf c.ColumnType.Name = "DateTime" Then
                    c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    c.DisplayFormat.FormatString = "dd-MM-yyyy"
                    If colTime <> "" Then
                        If colTime.ToLower.Contains(c.FieldName.ToLower) Then
                            c.DisplayFormat.FormatString = "HH:mm"
                            c.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
                        End If
                    Else
                        If c.FieldName.Contains("CreateDate") Or c.FieldName.Contains("CreatedDate") Then
                            c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            c.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm"
                        End If
                    End If
                End If


            End If
        Next
        gridv.OptionsView.ShowFooter = isShowFooter
    End Sub

    Public Sub GridControlSetFormat(gridv As BandedGridView,
                                    Optional colFixed As Integer = -1,
                                    Optional colTime As String = "",
                                    Optional colPercent As String = "")
        gridv.OptionsBehavior.SummariesIgnoreNullValues = True
        gridv.OptionsBehavior.Editable = False
        gridv.OptionsSelection.MultiSelect = True
        gridv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect
        gridv.OptionsSelection.EnableAppearanceHotTrackedRow = Utils.DefaultBoolean.True
        gridv.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        gridv.OptionsView.ColumnHeaderAutoHeight = Utils.DefaultBoolean.True
        gridv.OptionsView.ColumnAutoWidth = False
        gridv.GridControl.UseEmbeddedNavigator = True
        gridv.OptionsClipboard.CopyColumnHeaders = Utils.DefaultBoolean.False
        For Each c As GridColumn In gridv.Columns
            c.AppearanceHeader.BackColor = Color.Empty
            If c.Visible = True Then
                c.Summary.Clear()
                'c.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                If c.VisibleIndex <= colFixed Then
                    c.Fixed = FixedStyle.Left
                End If
                If c.ColumnType.Name = "String" Then
                    Continue For
                ElseIf c.ColumnType.Name = "Decimal" Or c.ColumnType.Name = "Double" Then
                    c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    c.DisplayFormat.FormatString = "N2"

                    c.Summary.Add(summaryType:=DevExpress.Data.SummaryItemType.Sum)
                    c.SummaryItem.DisplayFormat = "{0:n2}"

                    If colPercent <> "" Then
                        If colPercent.ToLower.Contains(c.FieldName.ToLower) Then
                            c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            c.DisplayFormat.FormatString = "p"
                        End If
                    End If
                ElseIf c.ColumnType.Name.Contains("Int") Then
                    c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    c.DisplayFormat.FormatString = "N0"

                    c.Summary.Add(summaryType:=DevExpress.Data.SummaryItemType.Sum)
                    c.SummaryItem.DisplayFormat = "{0:n0}"
                    'ElseIf c.ColumnType.Name = "Double" Then
                    '    'c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    '    'c.DisplayFormat.FormatString = "N4"

                    '    c.Summary.Add(summaryType:=DevExpress.Data.SummaryItemType.Sum)
                    '    c.SummaryItem.DisplayFormat = "{0:n4}"
                ElseIf c.ColumnType.Name = "DateTime" Then
                    c.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    c.DisplayFormat.FormatString = "dd-MMM-yyyy"
                    If colTime <> "" Then
                        If colTime.ToLower.Contains(c.FieldName.ToLower) Then
                            c.DisplayFormat.FormatString = "HH:mm"
                            c.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Public Sub GridControlSum(gridv As GridView, ByVal txt As TextBox)
        Dim mTotal As Decimal = 0
        For Each c As GridCell In gridv.GetSelectedCells()
            If IsNumeric(gridv.GetRowCellValue(c.RowHandle, c.Column)) Then
                mTotal += gridv.GetRowCellValue(c.RowHandle, c.Column)
            End If
        Next
        txt.Text = mTotal.ToString("N2")
    End Sub

    Public Sub GridControlSum(gridv As GridView, ByVal txt As TextEdit)
        Dim mTotal As Decimal = 0
        For Each c As GridCell In gridv.GetSelectedCells()
            If IsNumeric(gridv.GetRowCellValue(c.RowHandle, c.Column)) Then
                mTotal += gridv.GetRowCellValue(c.RowHandle, c.Column)
            End If
        Next
        txt.Text = mTotal.ToString("N2")
    End Sub

    Public Sub GridControlExportExcel(gridv As GridView,
                                      Optional isShow As Boolean = True,
                                       Optional mFile As String = "")
        Try
            Dim myFolder As String = Application.StartupPath & "\Export"
            If Not Directory.Exists(myFolder) Then
                Directory.CreateDirectory(myFolder)
            End If
            Dim myName As String = Guid.NewGuid.ToString
            Dim myFile As String = String.Format("{0}\{1}.xlsx", myFolder, myName)
            If mFile <> "" Then
                myFile = mFile
            End If
            DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG
            gridv.OptionsPrint.AutoWidth = False
            gridv.OptionsPrint.UsePrintStyles = False

            If True Then
                gridv.OptionsPrint.AutoWidth = False
                gridv.OptionsPrint.UsePrintStyles = False
                gridv.ExportToXlsx(myFile)
                If isShow Then
                    Process.Start(myFile)
                End If
            Else
                Dim frm As New SaveFileDialog
                frm.Filter = "Excel 2016 (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls"
                frm.FilterIndex = 1
                frm.RestoreDirectory = True
                If frm.ShowDialog() = DialogResult.OK Then
                    gridv.OptionsPrint.AutoWidth = False
                    gridv.OptionsPrint.UsePrintStyles = False
                    gridv.ExportToXlsx(frm.FileName)
                    If isShow Then
                        Process.Start(frm.FileName)
                    End If
                End If
            End If

        Catch ex As Exception
            ShowError(ex, "ExportToXlsx", "PublicFunction")
        End Try
    End Sub

    Public Sub GridControlExportExcel(gridv As GridView, sheetName As String,
                                      Optional isShow As Boolean = True,
                                     ByRef Optional mFile As String = "")
        Try
            Dim myFolder As String = Application.StartupPath & "\Export"
            If Not Directory.Exists(myFolder) Then
                Directory.CreateDirectory(myFolder)
            End If
            Dim myName As String = Guid.NewGuid.ToString
            Dim myFile As String = String.Format("{0}\{1}.xlsx", myFolder, myName)
            If mFile = "" Then
                mFile = myFile
            End If
            Dim opt As XlsxExportOptionsEx = New XlsxExportOptionsEx()
            opt.SheetName = sheetName

            DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG
            gridv.OptionsPrint.AutoWidth = False
            gridv.OptionsPrint.UsePrintStyles = False

            If True Then
                gridv.OptionsPrint.AutoWidth = False
                gridv.OptionsPrint.UsePrintStyles = False
                gridv.ExportToXlsx(myFile, opt)
                If isShow Then
                    Process.Start(myFile)
                End If
            Else
                Dim frm As New SaveFileDialog
                frm.Filter = "Excel 2016 (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls"
                frm.FilterIndex = 1
                frm.RestoreDirectory = True
                If frm.ShowDialog() = DialogResult.OK Then
                    gridv.OptionsPrint.AutoWidth = False
                    gridv.OptionsPrint.UsePrintStyles = False
                    gridv.ExportToXlsx(frm.FileName, opt)
                    If isShow Then
                        Process.Start(frm.FileName)
                    End If
                End If
            End If
        Catch ex As Exception
            ShowError(ex, "ExportToXlsx", "PublicFunction")
        End Try
    End Sub

    Public Function GridControlExportExcels(gridvs As List(Of GridView),
                                      Optional isShow As Boolean = True,
                                      Optional mFile As String = "",
                                       Optional sheetName As String = "SheetName",
                                       Optional intoOneSheet As Boolean = False) As String
        Try
            Dim myFolder As String = Application.StartupPath & "\Export"
            If Not Directory.Exists(myFolder) Then
                Directory.CreateDirectory(myFolder)
            End If
            Dim myName As String = Guid.NewGuid.ToString
            Dim myFile As String = String.Format("{0}\{1}.xlsx", myFolder, myName)
            If mFile <> "" Then
                myFile = mFile
            End If

            Dim complink = New XtraPrintingLinks.CompositeLink(New XtraPrinting.PrintingSystem())
            For Each grv As GridView In gridvs
                Dim link = New PrintableComponentLink With {
                    .Component = grv.GridControl,
                    .PaperName = grv.GridControl.Tag
                }
                complink.Links.Add(link)
            Next

            Dim ExMode As New XlsxExportOptionsEx()
            If intoOneSheet Then
                ExMode.ExportMode = XlsxExportMode.SingleFile
                ExMode.SheetName = sheetName
            Else
                complink.CreatePageForEachLink()
                ExMode.ExportMode = XlsxExportMode.SingleFilePageByPage
                ExMode.SheetName = sheetName
            End If

            If True Then
                complink.ExportToXlsx(myFile, ExMode)
                If isShow Then
                    Process.Start(myFile)
                End If
                Return myFile
            Else
                Dim frm As New SaveFileDialog
                frm.Filter = "Excel 2016 (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls"
                frm.FilterIndex = 1
                frm.RestoreDirectory = True
                If frm.ShowDialog() = DialogResult.OK Then
                    complink.ExportToXlsx(frm.FileName, ExMode)
                    If isShow Then
                        Process.Start(frm.FileName)
                    End If
                End If
                Return frm.FileName
            End If

        Catch ex As Exception
            ShowError(ex, "ExportToXlsxs", "PublicFunction")
        End Try
        Return Nothing
    End Function

    Public Function GridControlExportExcels(dts As List(Of DataTable),
                                      Optional isShow As Boolean = True,
                                      Optional mFile As String = "",
                                      Optional sheetName As String = "SheetName",
                                      Optional intoOneSheet As Boolean = False) As String
        Try
            Dim myFolder As String = Application.StartupPath & "\Export"
            If Not Directory.Exists(myFolder) Then
                Directory.CreateDirectory(myFolder)
            End If

            Dim myName As String = Guid.NewGuid.ToString
            Dim myFile As String = String.Format("{0}\{1}.xlsx", myFolder, myName)
            If mFile <> "" Then
                myFile = mFile
            End If

            Dim complink = New XtraPrintingLinks.CompositeLink(New XtraPrinting.PrintingSystem())
            For Each tb As DataTable In dts
                Dim grv As GridView = GridControlConvertToGridview(tb)
                Dim link = New PrintableComponentLink With {
                    .Component = grv.GridControl,
                    .PaperName = grv.GridControl.Tag
                }
                complink.Links.Add(link)
            Next

            Dim ExMode As New XlsxExportOptionsEx()
            If intoOneSheet Then
                ExMode.ExportMode = XlsxExportMode.SingleFile
                ExMode.SheetName = sheetName
            Else
                complink.CreatePageForEachLink()
                ExMode.ExportMode = XlsxExportMode.SingleFilePageByPage
                ExMode.SheetName = sheetName
            End If

            If True Then
                complink.ExportToXlsx(myFile, ExMode)
                If isShow Then
                    Process.Start(myFile)
                End If
                Return myFile
            Else
                Dim frm As New SaveFileDialog
                frm.Filter = "Excel 2016 (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls"
                frm.FilterIndex = 1
                frm.RestoreDirectory = True
                If frm.ShowDialog() = DialogResult.OK Then
                    complink.ExportToXlsx(frm.FileName, ExMode)
                    If isShow Then
                        Process.Start(frm.FileName)
                    End If
                End If
                Return frm.FileName
            End If

        Catch ex As Exception
            ShowError(ex, "ExportToXlsxs", "PublicFunction")
        End Try
        Return Nothing
    End Function

    Sub MergeXlsxFilesDevExpress(destXlsxFileName As String, sourceXlsxFileNames() As String,
                                 Optional isShow As Boolean = False)
        Dim destWorkBook As New Spreadsheet.Workbook
        destWorkBook.CreateNewDocument()

        Dim myFolder As String = Application.StartupPath & "\Export"
        If Not Directory.Exists(myFolder) Then
            Directory.CreateDirectory(myFolder)
        End If
        Dim myName As String = Guid.NewGuid.ToString
        Dim myFile As String = String.Format("{0}\{1}.xlsx", myFolder, myName)
        If destXlsxFileName = "" Then
            destXlsxFileName = myFile
        End If

        For Each sourceXlsxFile As String In sourceXlsxFileNames
            Dim sourceWorkBook = New Spreadsheet.Workbook
            sourceWorkBook.LoadDocument(sourceXlsxFile)
            For Each sheet As Spreadsheet.Worksheet In sourceWorkBook.Worksheets
                Dim temp As Spreadsheet.Worksheet = destWorkBook.Worksheets.Add()
                temp.CopyFrom(sheet)
                temp.Name = sheet.Name
            Next
            sourceWorkBook.Dispose()
        Next

        destWorkBook.Worksheets.RemoveAt(0)
        destWorkBook.SaveDocument(destXlsxFileName)
        destWorkBook.Dispose()

        If isShow Then
            Process.Start(destXlsxFileName)
        End If
    End Sub

    Public Sub GridControlExportExcel(dt As DataTable,
                                      Optional isShow As Boolean = True,
                                      Optional mFile As String = "")
        Try
            Dim myGrid As New GridControl
            Dim myView As New GridView
            myGrid.ViewCollection.Add(myView)
            myGrid.MainView = myView
            myGrid.BindingContext = New BindingContext()
            myGrid.DataSource = dt
            GridControlSetFormat(myView)

            Dim myFolder As String = Application.StartupPath & "\Export"
            If Not Directory.Exists(myFolder) Then
                Directory.CreateDirectory(myFolder)
            End If
            Dim myName As String = Date.Now.ToString("yyMMddHHmmss")
            Dim myFile As String = String.Format("{0}\{1}.xlsx", myFolder, myName)
            If mFile <> "" Then
                myFile = mFile
            End If

            If True Then
                myView.OptionsPrint.AutoWidth = False
                myView.OptionsPrint.UsePrintStyles = False
                myView.ExportToXlsx(myFile)
                If isShow Then
                    Process.Start(myFile)
                End If
            Else
                Dim frm As New SaveFileDialog
                frm.Filter = "Excel 2016 (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls"
                frm.FilterIndex = 1
                frm.RestoreDirectory = True
                If frm.ShowDialog() = DialogResult.OK Then
                    myView.OptionsPrint.AutoWidth = False
                    myView.OptionsPrint.UsePrintStyles = False
                    myView.ExportToXlsx(frm.FileName)
                    If isShow Then
                        Process.Start(frm.FileName)
                    End If
                End If
            End If


        Catch ex As Exception
            ShowError(ex, "ExportToXlsx", "PublicFunction")
        End Try
    End Sub

    Public Sub GridControlExportPdf(gridv As GridView,
                                      Optional isShow As Boolean = True,
                                      Optional mFile As String = "")
        Try
            Dim myFolder As String = Application.StartupPath & "\Export"
            If Not Directory.Exists(myFolder) Then
                Directory.CreateDirectory(myFolder)
            End If
            Dim myName As String = Date.Now.ToString("yyMMddHHmmss")
            Dim myFile As String = String.Format("{0}\{1}.pdf", myFolder, myName)
            If mFile <> "" Then
                myFile = mFile
            End If

            DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG

            'gridv.OptionsPrint.AutoWidth = False
            'gridv.OptionsPrint.UsePrintStyles = False
            'gridv.ExportToPdf(myFile)
            'If isShow Then
            '    Process.Start(myFile)
            'End If

            Dim frm As New SaveFileDialog
            frm.Filter = "Pdf file (*.pdf)|*.pdf"
            frm.FilterIndex = 1
            frm.RestoreDirectory = True
            frm.ShowDialog()
            If frm.FileName <> "" Then
                gridv.OptionsPrint.AutoWidth = False
                gridv.OptionsPrint.UsePrintStyles = False
                gridv.ExportToPdf(frm.FileName)
                Process.Start(frm.FileName)
            End If
        Catch ex As Exception
            ShowWarning("File đang mở, vui lòng đóng lại trước khi Export.")
        End Try
    End Sub

    Public Sub GridControlExportDocx(gridv As GridView,
                                      Optional isShow As Boolean = True,
                                      Optional mFile As String = "")
        Try
            Dim myFolder As String = Application.StartupPath & "\Export"
            If Not Directory.Exists(myFolder) Then
                Directory.CreateDirectory(myFolder)
            End If
            Dim myName As String = Date.Now.ToString("yyMMddHHmmss")
            Dim myFile As String = String.Format("{0}\{1}.docx", myFolder, myName)
            If mFile <> "" Then
                myFile = mFile
            End If
            DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG

            'gridv.OptionsPrint.AutoWidth = False
            'gridv.OptionsPrint.UsePrintStyles = False
            'gridv.ExportToDocx(myFile)

            'If isShow Then
            '    Process.Start(myFile)
            'End If

            Dim frm As New SaveFileDialog
            frm.Filter = "Word file (*.docx)|*.docx"
            frm.FilterIndex = 1
            frm.RestoreDirectory = True
            frm.ShowDialog()
            If frm.FileName <> "" Then
                gridv.OptionsPrint.AutoWidth = False
                gridv.OptionsPrint.UsePrintStyles = False
                gridv.ExportToDocx(frm.FileName)
                Process.Start(frm.FileName)
            End If

        Catch ex As Exception
            ShowWarning("File đang mở, vui lòng đóng lại trước khi Export.")
        End Try
    End Sub

    Function GridControlLoadLookUpEdit(dtData As DataTable, myDisplay As String, myValue As String) As RepositoryItemSearchLookUpEdit
        Dim LookEdit As New RepositoryItemSearchLookUpEdit
        LookEdit.DataSource = dtData
        LookEdit.DisplayMember = myDisplay
        LookEdit.ValueMember = myValue
        LookEdit.NullText = Nothing
        Return LookEdit
    End Function

    Function GridControlTimeEdit() As RepositoryItemTimeEdit
        Dim timeEdit As New RepositoryItemTimeEdit
        timeEdit.Mask.EditMask = "HH:mm"
        timeEdit.Mask.MaskType = Mask.MaskType.DateTime
        timeEdit.Mask.UseMaskAsDisplayFormat = True
        Return timeEdit
    End Function

    Function GridControlDateTimeEdit() As RepositoryItemDateEdit
        Dim timeEdit As New RepositoryItemDateEdit
        timeEdit.Mask.EditMask = "dd-MM-yyyy HH:mm"
        timeEdit.Mask.MaskType = Mask.MaskType.DateTime
        timeEdit.Mask.UseMaskAsDisplayFormat = True
        Return timeEdit
    End Function

    Function GridControlLinkEdit() As RepositoryItemHyperLinkEdit
        Dim linkEdit As New RepositoryItemHyperLinkEdit
        linkEdit.LinkColor = Color.Blue
        Return linkEdit
    End Function

    Public Sub GridControlSetFormatPercentage(gridv As GridView, StringCols As String, N As Integer)
        For Each c As String In StringCols.Split(",")
            With gridv.Columns(c.Trim)
                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                .DisplayFormat.FormatString = "p" & N
            End With
        Next
    End Sub
    ''' <summary>
    ''' Convert Gridview to DataTable
    ''' </summary>
    ''' <param name="gridv"></param>
    ''' <returns></returns>
    ''' 
    Public Function GridcontrolConvertToDataTable(gridv As GridView) As DataTable
        Dim dt As New DataTable()
        For Each column As GridColumn In gridv.VisibleColumns
            dt.Columns.Add(column.FieldName, column.ColumnType)
        Next column
        For i As Integer = 0 To gridv.DataRowCount - 1
            Dim row As DataRow = dt.NewRow()
            For Each column As GridColumn In gridv.VisibleColumns
                row(column.FieldName) = gridv.GetRowCellValue(i, column)
            Next column
            dt.Rows.Add(row)
        Next i

        Return dt
    End Function

    ''' <summary>
    ''' Convert DataTable to Gridview
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    Public Function GridControlConvertToGridview(dt As DataTable) As GridView
        Dim myGrid As New GridControl
        Dim myView As New GridView
        myGrid.ViewCollection.Add(myView)
        myGrid.MainView = myView
        myGrid.BindingContext = New BindingContext()
        myGrid.DataSource = dt
        GridControlSetFormat(myView)
        Return myView
    End Function
#End Region
End Module
