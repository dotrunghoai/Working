Imports System.Globalization
Imports System.Windows.Forms
Imports System.IO
Imports CommonDB
Imports PublicUtility
Imports LibEntity

Public Class clsApplication
    Dim nvd As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Public Shared FileTmp As String = Application.StartupPath + "\Template Excel\Template PCM\"
    Public Shared FileExp As String = Application.StartupPath + "\Template Excel\Template PCM\Export PCM\"
    Dim minYMD As String = ""

    Function checkUser() As Boolean
        Dim sqlcondi As String = String.Format("select IsAll from {0} where UserID = '{1}'",
                                               PublicTable.Table_PCM_UserRight,
                                               CurrentUser.UserID)
        Dim dtcondi As DataTable = nvd.FillDataTable(sqlcondi)
        If dtcondi.Rows.Count <> 0 Then
            If dtcondi.Rows(0).Item("IsAll") = True Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
        Return False
    End Function
    Function checAdmin() As Boolean
        Dim sqlcondi As String = String.Format("select IsAdmin from {0} where UserID = '{1}'",
                                               PublicTable.Table_PCM_UserRight,
                                               CurrentUser.UserID)
        Dim dtcondi As DataTable = nvd.FillDataTable(sqlcondi)
        If dtcondi.Rows.Count <> 0 Then
            If dtcondi.Rows(0).Item("IsAdmin") = True Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
        Return False
    End Function
    Function checkUserIsView() As Boolean

        Dim sqlcondi As String = String.Format("select IsView from {0} where UserID = '{1}'",
                                               PublicTable.Table_PCM_UserRight,
                                               CurrentUser.UserID)

        Dim dtcondi As DataTable = nvd.FillDataTable(sqlcondi)
        If dtcondi.Rows.Count <> 0 Then
            If dtcondi.Rows(0).Item("IsView") = True Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

        Return False

    End Function

    Public Sub InsertStock(YMD As String, FormOutName As String)
        Dim param(1) As SqlClient.SqlParameter
        param(0) = New SqlClient.SqlParameter("@Date", YMD) 
        param(1) = New SqlClient.SqlParameter("@Action", FormOutName)
        Dim dt As DataTable = nvd.ExecuteStoreProcedureTB("sp_PCM_WorkshopInsertStock", param)

        If dt.Rows.Count <> 0 Then

            For i As Integer = 0 To dt.Rows.Count - 1
                Dim obj As New PCM_WorkshopStock

                obj.YMD_K = dt.Rows(i).Item("YMD")
                obj.JCode_K = dt.Rows(i).Item("JCode")
                obj.PrcName_K = dt.Rows(i).Item("PrcName")
                If nvd.ExistObject(obj) Then
                    nvd.GetObject(obj)
                    obj.QtyIn = dt.Rows(i).Item("Qty")
                    nvd.Update(obj)
                Else
                    Dim sql = String.Format("Select JCode, PrcName, JEName, JVName, Unit from PCM_NotJCode " +
                    "Where JCode = '{0}' and PrcName = '{1}' and YMD = '{2}' " +
                    "union all Select JCode, PrcName, JEName, JVName, Unit from PCM_TrayU00 " +
                    "Where JCode = '{0}' and PrcName = '{1}' and YMD = '{2}' " +
                    "union all Select JCode, PrcName, JEName, JVName, Unit from PCM_OutDirect " +
                    "Where JCode = '{0}' and PrcName = '{1}' and OutYMD = '{2}'", dt.Rows(i).Item("JCode"), dt.Rows(i).Item("PrcName"), YMD)
                    Dim dtJCode As DataTable = nvd.FillDataTable(sql)

                    obj.QtyIn = dt.Rows(i).Item("Qty")

                    obj.JEName = IIf(dtJCode.Rows(0).Item("JEName") Is DBNull.Value, "", dtJCode.Rows(0).Item("JEName"))
                    obj.JVName = IIf(dtJCode.Rows(0).Item("JVName") Is DBNull.Value, "", dtJCode.Rows(0).Item("JVName"))
                    obj.Unit = IIf(dtJCode.Rows(0).Item("Unit") Is DBNull.Value, "", dtJCode.Rows(0).Item("Unit"))
                    nvd.Insert(obj)
                End If
            Next

        End If
    End Sub

    Public Sub CopyStockWS(YMD As String)
        Dim sqlmaxday As String = String.Format("select max(YMD) YMD from {0}", PublicTable.Table_PCM_WorkshopStock)
        Dim dtmaxday As DataTable = nvd.FillDataTable(sqlmaxday)

        If dtmaxday.Rows(0)("YMD").ToString() = "" Then Exit Sub
        If YMD <= dtmaxday.Rows(0)("YMD").ToString() Then Exit Sub
        minYMD = dtmaxday.Rows(0)("YMD").ToString()

        Dim param(1) As SqlClient.SqlParameter
        param(0) = New SqlClient.SqlParameter("@Date", dtmaxday.Rows(0)("YMD"))
        param(1) = New SqlClient.SqlParameter("@Action", "CopyStockWS")
        Dim dt As DataTable = nvd.ExecuteStoreProcedureTB("sp_PCM_WorkshopInsertStock", param)

        If dt.Rows.Count <> 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim obj As New PCM_WorkshopStock

                obj.YMD_K = YMD
                obj.JCode_K = dt.Rows(i).Item("JCode")
                obj.PrcName_K = dt.Rows(i).Item("PrcName")
                obj.FirstStock = dt.Rows(i).Item("ConvertedQtyRestore")
                obj.JEName = dt.Rows(i).Item("JEName")
                obj.JVName = dt.Rows(i).Item("JVName")
                obj.Unit = dt.Rows(i).Item("Unit")
                'If obj.JCode_K = "J03259" Then
                '    ShowWarning(" J03259")
                'End If
                'QtyIn
                Dim paQtyIn(3) As SqlClient.SqlParameter
                paQtyIn(0) = New SqlClient.SqlParameter("@StartDate", dtmaxday.Rows(0)("YMD"))
                paQtyIn(1) = New SqlClient.SqlParameter("@EndDate", obj.YMD_K)
                paQtyIn(2) = New SqlClient.SqlParameter("@JCode", obj.JCode_K)
                paQtyIn(3) = New SqlClient.SqlParameter("@PrcName", obj.PrcName_K)
                Dim dtQtyIn As DataTable = nvd.ExecuteStoreProcedureTB("sp_PCM_InsertQtyIn", paQtyIn)
                If dtQtyIn.Rows.Count <> 0 Then
                    obj.QtyIn = dtQtyIn.Compute("Sum(NDVQty)", "")
                End If

                nvd.Insert(obj)
            Next
        End If
    End Sub

    Function CheckInsert(YMD As String) As Boolean
        Dim sqlmaxday As String = String.Format("select max(YMD) YMD from {0}", PublicTable.Table_PCM_WorkshopInsertStock)
        Dim dtmaxday As DataTable = nvd.FillDataTable(sqlmaxday)

        Dim check = True

        If dtmaxday.Rows(0)("YMD").ToString() <> "" _
            And YMD > dtmaxday.Rows(0)("YMD").ToString() Then
            Dim objInsertStock As New PCM_WorkshopInsertStock
            objInsertStock.YMD_K = dtmaxday.Rows(0)("YMD").ToString()
            nvd.GetObject(objInsertStock)

            If objInsertStock.OutMter = False Then
                MessageBox.Show(objInsertStock.YMD_K & " OutMter is not inserted", "Insert Stock")
                check = False
            End If
            If objInsertStock.OutTray = False Then
                MessageBox.Show(objInsertStock.YMD_K & " OutTray is not inserted", "Insert Stock")
                check = False
            End If
            If objInsertStock.OutDirect = False Then
                MessageBox.Show(objInsertStock.YMD_K & " OutDirect is not inserted", "Insert Stock")
                check = False
            End If
            If objInsertStock.OutWS = False Then
                MessageBox.Show(objInsertStock.YMD_K & " OutWS is not inserted", "Insert Stock")
                check = False
            End If
        End If

        Return check
    End Function

    Public Sub InsertStockFromOutWS(YMD As String, FormOutName As String)
        Dim param(1) As SqlClient.SqlParameter
        param(0) = New SqlClient.SqlParameter("@Date", YMD)
        param(1) = New SqlClient.SqlParameter("@Action", FormOutName)
        Dim dt As DataTable = nvd.ExecuteStoreProcedureTB("sp_PCM_WorkshopInsertStock", param)

        If dt.Rows.Count <> 0 Then

            For i As Integer = 0 To dt.Rows.Count - 1

                Dim obj As New PCM_WorkshopStock

                obj.YMD_K = dt.Rows(i).Item("YMD")
                obj.JCode_K = dt.Rows(i).Item("JCode")
                obj.PrcName_K = dt.Rows(i).Item("PrcName")
                'If obj.JCode_K = "J03259" Then
                '    ShowWarning(" J03259 ")
                'End If
                'QtyIn
                Dim paQtyIn(3) As SqlClient.SqlParameter
                paQtyIn(0) = New SqlClient.SqlParameter("@StartDate", minYMD)
                paQtyIn(1) = New SqlClient.SqlParameter("@EndDate", obj.YMD_K)
                paQtyIn(2) = New SqlClient.SqlParameter("@JCode", obj.JCode_K)
                paQtyIn(3) = New SqlClient.SqlParameter("@PrcName", obj.PrcName_K)
                Dim dtQtyIn As DataTable = nvd.ExecuteStoreProcedureTB("sp_PCM_InsertQtyIn", paQtyIn)
                If dtQtyIn.Rows.Count <> 0 Then
                    obj.QtyIn = dtQtyIn.Compute("Sum(NDVQty)", "")
                End If

                If nvd.ExistObject(obj) Then
                    nvd.GetObject(obj)
                    obj.ConvertedQtyRestore = obj.ConvertedQtyRestore + dt.Rows(i).Item("ConvertedQtyRestore")
                    nvd.Update(obj)
                Else
                    Dim sql = String.Format("Select JCode, PrcName, JEName, JVName, Unit from PCM_WorkshopOut " +
                    "Where JCode = '{0}' and PrcName = '{1}' and left(YMD, 8) = '{2}' ", dt.Rows(i).Item("JCode"), dt.Rows(i).Item("PrcName"), YMD)
                    Dim dtJCode As DataTable = nvd.FillDataTable(sql)

                    obj.ConvertedQtyRestore = dt.Rows(i).Item("ConvertedQtyRestore")

                    obj.JEName = IIf(dtJCode.Rows(0).Item("JEName") Is DBNull.Value, "", dtJCode.Rows(0).Item("JEName"))
                    obj.JVName = IIf(dtJCode.Rows(0).Item("JVName") Is DBNull.Value, "", dtJCode.Rows(0).Item("JVName"))
                    obj.Unit = IIf(dtJCode.Rows(0).Item("Unit") Is DBNull.Value, "", dtJCode.Rows(0).Item("Unit"))
                    nvd.Insert(obj)
                End If
            Next

        End If
    End Sub

    Function checkImportStock() As Boolean
        Dim sql As String = String.Format(" SELECT TOP 1 " +
                                        " CONVERT(VARCHAR(10), DDate, 112) DDate " +
                                        " FROM  PCM_Stock")
        Dim dt As DataTable = nvd.FillDataTable(sql)
        If DateTime.Now.ToString("yyyyMMdd") = dt.Rows(0)("DDate") Then
            Return True
        End If
        Return False
    End Function

    Public Shared Sub UpLoadFile(ByVal SourceFileName As String, ByVal DestFileName As String, ByVal Override As Boolean)
        Try
            If (File.Exists(SourceFileName)) Then
                If (File.Exists(DestFileName)) Then
                    File.SetAttributes(DestFileName, FileAttributes.Archive)
                End If
                File.Copy(SourceFileName, DestFileName, Override)
            End If
        Catch ex As Exception
            If ex.Message.Contains("because it is being used") Then
                ShowWarning("File đang mở vui lòng đóng lại !")
            Else
                Throw ex
            End If
        End Try
    End Sub
End Class
