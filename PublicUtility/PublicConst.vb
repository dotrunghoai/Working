Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraBars.Docking2010.Views.Tabbed


''' <summary>
''' Author: Truong Minh Tam (IT-Nitto Denko)
''' Date: 25-Aug-2011
''' Stored constants, variable, string
''' </summary>
''' <remarks></remarks>
''' 
<Serializable()>
Public Class PublicConst

#Region "Variable and Const"

    Public Const Version = "2.0"

    Public Const Length_ProductCode As Integer = 5
    Public Const Length_ProcessNumber As Integer = 2
    Public Const Length_Component As Integer = 3
    Public Const Length_ProcessCode As Integer = 4
    Public Const Length_LotNumber As Integer = 5
    Public Const Length_Revision As Integer = 2

    Public Shared CurrentDatabase As Boolean = True

    Public Shared MyTabbedView As TabbedView

#End Region

#Region "config file"

    Public Shared ERPNAME As String = "\ERPNDV.exe"
    Public Shared ERPUPDATENAME As String = "\ERPUpdate.exe"
    Public Shared CONFIGUPDATE As String = "\ERPUpdate.exe.config"
    Public Shared CONFIG As String = "\config.ndv"
    Public Shared FOLDER_TEMP As String = "\BK_Temp"
    Public Shared FOLDER_LABLE As String = Application.StartupPath + "\Label\"

    Public Const IP_S As String = "10.153.1.13"
    Public Const IP_Z As String = "10.153.1.13"
    Public Const IP_V As String = "10.153.1.13"

    Public Shared CurrentDate As DateTime = DateTime.Today.AddDays(-1)
    Public Shared SiteStockDate As DateTime = DateTime.Today
    Public Shared CurrentGroup As String = ""
    Public Shared VisibleAutoConnect As Boolean = False

    Public Const Group As String = "Group Leader"
    Public Const Gmanager As String = "General Manager"
    Public Const Factory As String = "Factory"
    Public Const Line As String = "Line"
    Public Const Manager As String = "Manager"
    Public Const Staff As String = "Staff"
    Public Const Bussiness As String = "Bussiness control"
    Public Const Op As String = "Operator"
    Public Const Head As String = "Head"
    Public Const Team As String = "Team"
    Public Const Assistant As String = "Assistant manager"

#End Region

#Region "Event and delegate "

    Public Delegate Sub DelegateBulkRowCopied(ByVal sender As Object, ByVal rowCopied As Long)
    Public Delegate Sub DelegateSetTotal(ByVal total As Long)
    Public Delegate Sub DelegateSetMessage(ByVal message As String)
    Public Delegate Sub DelegateSetIndex(ByVal index As Integer)

    'Public Shared Event EventBulkRowCopied As DelegateBulkRowCopied
    'Public Shared Event EventSetTotal As DelegateSetTotal
    'Public Shared Event EventSetMessage As DelegateSetMessage
    'Public Shared Event EventSetIndex As DelegateSetIndex

#End Region

#Region "Format"

    Public Shared Format_Date_Short As String = "dd/MM/yyyy"
    Public Shared Format_Date_Long As String = "dd/MM/yyyy HH:mm:ss"

    Public Shared DateTimeServer As DateTime
    Public Shared DateTimeLocal As DateTime = DateTime.Now
    Public Shared Format_Money As String = "N2"
    Public Shared Format_VAT As String = "N0"
    Public Shared Format_Quantity As String = "N0"
    Public Shared Format_NormalMaterial As String = "N8"
    Public Shared Format_StockQuantity As String = "N3"
    Public Shared Format_Price As String = "N4"
    Public Shared Format_N0 As String = "N0"
    Public Shared Format_N1 As String = "N1"
    Public Shared Format_N2 As String = "N2"
    Public Shared Format_N3 As String = "N3"
    Public Shared Format_N4 As String = "N4"
    Public Shared Format_N5 As String = "N5"
    Public Shared Format_N6 As String = "N6"
    Public Shared Format_N7 As String = "N7"
    Public Shared Format_N8 As String = "N8"

#End Region

#Region "Admin user"
    Public Shared ReadOnly AdminUser As String = "admin"
    Public Shared ReadOnly AdminPassword As String = "admin-ndv"
    Public Shared ReadOnly AdminID As String = "00000"
    Public Shared ReadOnly AdminName As String = "IT Nitto Denko"
    Public Shared ReadOnly LastUpdate As New DateTime(2012, 7, 25, 9, 0, 0)
#End Region

#Region "Connection string"
    Public Shared SQL_DB_QETTHE As String = "Data Source=10.153.1.7;initial catalog=abriDBHRPro7;user id=sa;password=P@ssw0rd;Connection Timeout=5;"
    Public Shared SQL_DB_FPICS As String = "Data Source=10.153.1.30;initial catalog=FPICS-B03;user id=FPICS-B03-RO;password=fpics;Connection Timeout=5;"
    Public Shared SQL_DB_ERP_NDV As String = "Data Source=10.153.1.7;initial catalog=NDVERP;user id=sa;password=P@ssw0rd;Connection Timeout=5;"
    Public Shared SQL_DB_ERP_NDV_BK As String = "Data Source=10.153.1.7;initial catalog=NDVERP_BK;user id=sa;password=P@ssw0rd;Connection Timeout=5;"
    Public Shared SQL_DB_ERP_NDV_Use As String = "Data Source=10.153.1.7;initial catalog=NDVERP;user id=sa;password=P@ssw0rd;Connection Timeout=5;"
    Public Shared SQL_DB_Factory As String = "Data Source=10.153.1.7;initial catalog=Acc_Prd;user id=sa;password=P@ssw0rd;Connection Timeout=5;"
    Public Shared DB2_DB_AS400 As String = "Driver={Client Access ODBC Driver (32-bit)};System=128.3.10.7;Uid=NDVHHH;Pwd=123456; Connection Timeout=5"
    Public Shared OLE_DB_AS400 As String = "PROVIDER=IBMDA400; DATA SOURCE=128.3.10.7;USER ID=NDVHHH;PASSWORD=123456"
    Public Shared SQL_DB_ThaiSon As String = "server=10.153.1.7; database=ECUS5VNACCS ; user=sa ; password=P@ssw0rd ; timeout=5 "
    Public Shared SQL_DB_Pacemaker As String = "Data Source=10.153.1.24;initial catalog=NITTOPM;user id=sa;password= ;Connection Timeout=5;"

    Public Shared SQL_None As String = ""
    Public Shared DB2_None As String = ""
    Public Shared Oracle_None As String = ""
    Public Shared MySql_None As String = ""
#End Region

#Region "Enums"

    Public Enum EnumServers
        NDV_SQL_Fpics = 1
        NDV_SQL_ERP_NDV = 2
        NDV_SQL_Factory = 3
        NDV_DB2_AS400 = 4
        NDV_SQL_ThaiSon = 5
    End Enum

    Public Enum EnumReport
        'Logistic============================================================================
        ReportNormal = 1
        ReportSummary = 2
        ReportCustom = 3
        ReportExport = 4
        ReportImport = 5
    End Enum

    Public Enum EnumLanguage
        English = 1
        VietNam = 2
        Japan = 3
        China = 4
    End Enum

    Enum enumBorrowLend
        Borrow
        Lend
    End Enum

    Public Enum enumProduct
        TOSHIBA = 1
        SAMSUNG = 2
        SEAGATE = 3
        WD = 4
        HangThuong = 5
        OTHER = 6
        HITACHI = 7
        CaseMark = 8
        NhanTim = 9
        SEAGATENEW = 10
        SEAGATEXOUT = 11
    End Enum

    Public Enum EnumForecsat
        DVC = 1
        TE = 2
        TT = 3
        SX = 4
    End Enum

    Public Enum FormStatus
        AddNew
        Read
        Edit
        Load
    End Enum
#End Region

#Region "Const primary key"
    Public Shared ReadOnly Key As String = "_K"

#End Region

#Region "Colors"
    Public Shared Color1 As Color = Color.White
    Public Shared Color2 As Color = Color.YellowGreen
    Public Shared Color_Key As Color = Color.Yellow
    Public Shared Color_Entry_Text As Color = Color.FromArgb(255, 255, 192)
    Public Shared Color_Leave_Text As Color = Color.White
    Public Shared Color_Boder As Color = Color.FromArgb(0, 192, 0)

    'Color Chart
    Public Shared Color_01 As Color = Color.FromArgb(128, 0, 0)
    Public Shared Color_02 As Color = Color.FromArgb(255, 255, 153)
    Public Shared Color_03 As Color = Color.FromArgb(204, 0, 0)
    Public Shared Color_04 As Color = Color.FromArgb(0, 255, 0)
    Public Shared Color_05 As Color = Color.FromArgb(255, 124, 128)
    Public Shared Color_06 As Color = Color.FromArgb(102, 153, 255)
    Public Shared Color_07 As Color = Color.FromArgb(204, 102, 0)
    Public Shared Color_08 As Color = Color.FromArgb(204, 204, 255)
    Public Shared Color_09 As Color = Color.FromArgb(255, 153, 255)
    Public Shared Color_10 As Color = Color.FromArgb(255, 0, 255)
    Public Shared Color_11 As Color = Color.FromArgb(255, 102, 0)
    Public Shared Color_12 As Color = Color.FromArgb(255, 153, 0)
    Public Shared Color_13 As Color = Color.FromArgb(102, 204, 255)
    Public Shared Color_14 As Color = Color.FromArgb(153, 102, 51)
    Public Shared Color_15 As Color = Color.FromArgb(0, 128, 0)
    Public Shared Color_16 As Color = Color.FromArgb(204, 102, 255)
    Public Shared Color_17 As Color = Color.FromArgb(51, 51, 255)
    Public Shared Color_18 As Color = Color.FromArgb(204, 153, 0)
    Public Shared Color_19 As Color = Color.FromArgb(102, 102, 153)
    Public Shared Color_20 As Color = Color.FromArgb(255, 255, 0)
    Public Shared Color_21 As Color = Color.FromArgb(51, 204, 204)
    Public Shared Color_22 As Color = Color.FromArgb(0, 102, 102)
    Public Shared Color_23 As Color = Color.FromArgb(102, 153, 0)
    Public Shared Color_99 As Color = Color.FromArgb(255, 204, 153)


#End Region

#Region "Message"
    'Question'
    Public Shared Message_Question_Getdata As String = "Bạn muốn lấy dữ liệu không {0} ?"
    Public Shared Message_Question_GetdataAgain As String = "Dữ liệu đã tồn tại. Bạn muốn lấy lại không {0} ?"
    Public Shared Message_Question_Save As String = "Bạn muốn lưu dữ liệu không {0} ?"
    Public Shared Message_Question_Update As String = "Bạn muốn cập nhật dữ liệu không {0} ?"
    Public Shared Message_Question_Delete As String = "Bạn muốn xóa dữ liệu không {0} ?"
    Public Shared Message_Question_Insert As String = "Bạn muốn thêm dữ liệu không {0} ?"
    Public Shared Message_Question_Import As String = "Bạn muốn import dữ liệu không {0} ?"
    Public Shared Message_Question_Export As String = "Bạn muốn xuất dữ liệu {0} ?"
    Public Shared Message_Question_Print As String = "Bạn muôn in dữ liệu không {0} ?"
    Public Shared Message_Question_Sync As String = "Bạn muốn đồng bộ dữ liệu không {0} ?"
    Public Shared Message_Question_Exit As String = "Bạn muốn thoát chương trình {0} ?"
    Public Shared Message_Question_Back As String = "Bạn muốn trở lại không {0} ?"
    Public Shared Message_Question_Lock As String = "Bạn muốn khóa dữ liệu không {0} ?"
    Public Shared Message_Question_UnLock As String = "Bạn muốn mở khóa dữ liệu không {0} ?"
    Public Shared Message_Question_Backup As String = "Bạn muốn sao lưu dữ liệu không {0} ?"
    Public Shared Message_Question_Restore As String = "Bạn muốn phục hồi dữ liệu không {0} ?"
    Public Shared Message_Question_Confirm As String = "Bạn muốn xác nhận không {0} ?"
    Public Shared Message_Question_UnConfirm As String = "Bạn muốn hủy xác nhận không {0} ?"
    Public Shared Message_Question_Run As String = "Bạn muốn chạy dữ liệu không {0} ? "
    Public Shared Message_Question_RunAgain As String = "Dữ liệu đã tồn tại. Bạn muốn chạy lại lần nữa không {0} ? "

    'Warning
    Public Shared Message_Warning_NotNull As String = "{0} không được để trống."
    Public Shared Message_Warning_NotEmpty As String = "{0} không được để trống."
    Public Shared Message_Warning_Length As String = "{0} chiều dài phải là {1} ký tự."
    Public Shared Message_Warning_ExistData As String = "{0} dữ liệu đã tồn tại"
    Public Shared Message_Warning_Locked As String = "{0} dữ liệu đã khóa."
    Public Shared Message_Warning_LockedBefore As String = "Bạn phải khóa {0} trước."
    Public Shared Message_Warning_MustDigit As String = "{0} phải là ký tự số."
    Public Shared Message_Warning_MustChar As String = "{0} phải là ký tự alphabet."
    Public Shared Message_Warning_CanNotModify As String = "{0} không thể sửa."
    Public Shared Message_Warning_NotConfirm As String = "{0} chưa xác nhận."
    Public Shared Message_Warning_NotCorrect As String = "{0} đã bị sai."
    Public Shared Message_Warning_MustSame As String = "{0} phải giống nhau."
    Public Shared Message_Warning_MustDiff As String = "{0} phải khác nhau."
    'Info
    Public Shared Message_Successfully As String = "Thành công"
    Public Shared Message_Successfully_Rows As String = "Thành công, {0} dòng."

    'Caption
    Public Shared Message_Caption_Getdata As String = "Lấy dữ liệu"
    Public Shared Message_Caption_Save As String = "Lưu"
    Public Shared Message_Caption_Update As String = "Cập nhật"
    Public Shared Message_Caption_Delete As String = "Xóa"
    Public Shared Message_Caption_Insert As String = "Thêm"
    Public Shared Message_Caption_Import As String = "Nhập"
    Public Shared Message_Caption_Export As String = "Xuất"
    Public Shared Message_Caption_Print As String = "In"
    Public Shared Message_Caption_Sync As String = "Đồng bộ"
    Public Shared Message_Caption_Exit As String = "Thoát"
    Public Shared Message_Caption_Back As String = "Trở lại"
    Public Shared Message_Caption_Lock As String = "Khóa"
    Public Shared Message_Caption_UnLock As String = "Mở khóa"
    Public Shared Message_Caption_Backup As String = "Sao lưu"
    Public Shared Message_Caption_Restore As String = "Phục hồi"
    Public Shared Message_Caption_Confirm As String = "Xác nhận"
    Public Shared Message_Caption_UnConfirm As String = "Chưa xác nhận"
    Public Shared Message_Caption_Run As String = "Thực thi"
    Public Shared Message_Caption_Condition As String = "Điều kiện"
    Public Shared Message_Caption_Error As String = "Lỗi"
    Public Shared Message_Caption_Help As String = "Giúp đỡ"
    Public Shared Message_Caption_Info As String = "Thông tin"
    Public Shared Message_Caption_Warning As String = "Cảnh báo"



#End Region

#Region "Default"
    Public Shared ConditionDefault As String = " 1=1 "
    Public Shared Language As EnumLanguage = EnumLanguage.English
#End Region

#Region "Company"
    Public Shared Company_Name As String = "Cty TNHH Nitto Denko Việt Nam"
    Public Shared Company_Address As String = "Số 6, Đường Số 3, VSIP, Thuận An, Bình Dương"
    Public Shared Company_TaxNumber As String = "3700309367"
#End Region

End Class
