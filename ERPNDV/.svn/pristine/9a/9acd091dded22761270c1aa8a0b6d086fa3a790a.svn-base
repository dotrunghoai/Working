Imports CommonDB
Imports System.IO

Imports PublicUtility
Imports LibEntity
Imports System.Threading
Imports DevExpress.CodeParser

Public Class FrmUtilityTool : Inherits DevExpress.XtraEditors.XtraForm
#Region "Variable"
    Dim db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim languageVB As String = ".vb"
    Dim languageCSharp As String = ".cs"
    Dim PublicTable As String = "PublicTable"
    Dim PublicStoreProcesdure As String = "PublicSP"

    Delegate Sub SafeCallDelegate(text As String)

#End Region

#Region "User function"

    Sub GenerateTableNameVB()
        If GridViewTB.RowCount = 0 Then Return

        Dim f As New StreamWriter(txtPathStore.Text & "\" & PublicTable & languageVB)
        f.WriteLine(" Public class " & PublicTable)
        For r As Integer = 0 To GridViewTB.RowCount - 1
            f.WriteLine("     Public Shared Table_" & GridViewTB.GetRowCellValue(r, "table_name") & " as String= """ & GridViewTB.GetRowCellValue(r, "table_name") & """ ")
        Next
        f.WriteLine(" End class ")
        f.Flush()
        f.Close()
    End Sub
    Sub GenerateTableNameCSharp()
        If GridViewTB.RowCount = 0 Then Return

        Dim f As New StreamWriter(txtPathStore.Text & "\" & PublicTable & languageCSharp)
        f.WriteLine(" Public class " & PublicTable)
        f.WriteLine(" { ")
        For r As Integer = 0 To GridViewTB.RowCount - 1
            f.WriteLine("     Public String Table_" & GridViewTB.GetRowCellValue(r, "table_name") & "= """ & GridViewTB.GetRowCellValue(r, "table_name") & """ ;")
        Next
        f.WriteLine(" } ")
        f.Flush()
        f.Close()
    End Sub
    Sub GenerateStoreProcedureVB()
        Dim tb As DataTable = db.GetAllStoreProcedures()
        Dim f As New StreamWriter(txtPathStore.Text & "\" & PublicStoreProcesdure & languageVB)
        f.WriteLine(" Public class " & PublicStoreProcesdure)
        For Each row As DataRow In tb.Rows
            f.WriteLine("     Public Shared " & row("name") & " as String= """ & row("name") & """ ")
        Next
        f.WriteLine(" End class ")
        f.Flush()
        f.Close()
    End Sub
    Sub GenerateStoreProcedureCSharp()
        Dim tb As DataTable = db.GetAllStoreProcedures()
        Dim f As New StreamWriter(txtPathStore.Text & "\" & PublicStoreProcesdure & languageCSharp)
        f.WriteLine(" Public class " & PublicStoreProcesdure)
        f.WriteLine(" { ")
        For Each row As DataRow In tb.Rows
            f.WriteLine("     Public String " & row("name") & "= """ & row("name") & """ ")
        Next
        f.WriteLine(" } ")
        f.Flush()
        f.Close()
    End Sub
    Sub GenerateVB()
        Dim tbColumn As DataTable
        Dim tbKeys As DataTable
        For Each r As Integer In GridViewTB.GetSelectedRows
            Dim myTable As String = GridViewTB.GetRowCellValue(r, "table_name")
            Dim f As New StreamWriter(txtPathEntity.Text & "\" & myTable & ".vb")
            f.WriteLine()
            f.WriteLine(" Public Class " & myTable)
            tbColumn = db.GetAllColumn(myTable)
            tbKeys = db.GetKeysOfTable(myTable)
            For Each rowColum As DataRow In tbColumn.Rows
                Dim key As Boolean = False
                For Each rowKey As DataRow In tbKeys.Rows
                    If rowColum("column_name") = rowKey("column_name") Then
                        key = True
                        Exit For
                    End If
                Next
                If key Then
                    f.WriteLine("     Public " & rowColum("column_name") & "_K As " & GetTypeColumnVB(rowColum("datatype")))
                Else
                    Dim datatype As String = GetTypeColumnVB(rowColum("datatype"))
                    f.WriteLine("     Public " & rowColum("column_name") & " As " & datatype)
                End If
            Next
            f.WriteLine(" End  Class")
            f.Flush()
            f.Close()
        Next



    End Sub
    Sub GenerateCSharp()
        Dim tbColumn As DataTable
        Dim tbKeys As DataTable
        For Each r As Integer In GridViewTB.GetSelectedRows
            Dim f As New StreamWriter(txtPathEntity.Text & "\" & GridViewTB.GetRowCellValue(r, "table_name").ToString & ".cs")
            f.WriteLine()
            f.WriteLine(" Public Class " & GridViewTB.GetRowCellValue(r, "table_name"))
            f.WriteLine(" {")
            tbColumn = db.GetAllColumn(GridViewTB.GetRowCellValue(r, "table_name"))
            tbKeys = db.GetKeysOfTable(GridViewTB.GetRowCellValue(r, "table_name"))
            For Each rowColum As DataRow In tbColumn.Rows
                Dim key As Boolean = False
                For Each rowKey As DataRow In tbKeys.Rows
                    If rowColum("column_name") = rowKey("column_name") Then
                        key = True
                        Exit For
                    End If
                Next
                If key Then
                    f.WriteLine("     Public " & GetTypeColumnCSharp(rowColum("datatype")) & " " & rowColum("column_name") & "_K ; ")
                Else
                    f.WriteLine("     Public " & GetTypeColumnCSharp(rowColum("datatype")) & " " & rowColum("column_name") & " ; ")
                End If
            Next
            f.WriteLine(" }")
            f.Flush()
            f.Close()
        Next


    End Sub

    Function GetTypeColumnVB(ByVal sqlType As String) As String
        Select Case sqlType
            Case "char", "nchar", "varchar", "nvarchar", "text", "ntext"
                Return "String "
            Case "datetime", "smalldatetime", "date"
                Return "DateTime "
            Case "bit"
                Return "Boolean "
            Case "int", "smallint", "tinyint"
                Return " Integer "
            Case "bigint"
                Return " Long "
            Case "decimal", "money"
                Return "Decimal "
            Case "float", "double", "real"
                Return "double"
            Case "binary", "varbinary"
                Return "byte()"
            Case "image"
                Return "byte()"
        End Select
        Return ""
    End Function
    Function GetTypeColumnCSharp(ByVal sqlType As String) As String
        Select Case sqlType
            Case "char", "nchar", "varchar", "nvarchar", "text", "ntext"
                Return "string "
            Case "datetime", "smalldatetime", "date"
                Return "DateTime "
            Case "bit"
                Return "bool "
            Case "int", "smallint"
                Return " int "
            Case "bigint"
                Return " long "
            Case "decimal", "money"
                Return "decimal "
            Case "float", "double", "real"
                Return "double"
            Case "binary"
                Return "byte[]"
            Case "image"
                Return "byte[]"
        End Select
        Return ""
    End Function
#End Region

#Region "Form function"

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttPathEntity.Click
        Dim browser As New FolderBrowserDialog()
        browser.ShowDialog()
        If browser.SelectedPath <> "" Then
            txtPathEntity.Text = browser.SelectedPath
        End If
    End Sub

    Private Sub bttConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttConnect.Click


        db = New DBSql(GetString())
        If Not db.CheckConnection Then Exit Sub
        ShowSuccess()

        Dim tb As DataTable
        tb = db.GetAllTableName()

        GridControlTB.DataSource = tb
        GridControlSetFormat(GridViewTB)
        GridViewTB.BestFitColumns()
    End Sub

    Function GetString() As String
        Dim connect As String = ""
        connect = String.Format("Server={0};Database={1};User id={2};Password={3};Connection timeout=0", txtServer.Text, txtDatabase.Text, txtUserId.Text, txtPassword.Text)

        Return connect
    End Function

    Private Sub tvwDB_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)

        For Each note As TreeNode In e.Node.Nodes
            note.Checked = e.Node.Checked
        Next

    End Sub

    Private Sub bttGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttGenerate.Click
        Cursor = Cursors.AppStarting

        If ckoCSharp.Checked Then
            If ckoTableClass.Checked Then
                GenerateCSharp()
            End If
            If ckoTableName.Checked Then
                GenerateTableNameCSharp()
            End If
            If ckoStore.Checked Then
                GenerateStoreProcedureCSharp()
            End If
        End If
        If ckoVB.Checked Then
            If ckoTableClass.Checked Then
                GenerateVB()
            End If
            If ckoTableName.Checked Then
                GenerateTableNameVB()
            End If
            If ckoStore.Checked Then
                GenerateStoreProcedureVB()
            End If
        End If

        ShowSuccess()

        Cursor = Cursors.Default

    End Sub
    Private Sub bttEncryption_Click(sender As System.Object, e As System.EventArgs) Handles bttEncryption.Click
        txtResult.Text = EncryptPassword(txtInput.Text)
    End Sub

    Private Sub bttDecryption_Click(sender As System.Object, e As System.EventArgs) Handles bttDecryption.Click
        txtResult.Text = DecryptPassword(txtInput.Text)
    End Sub

#End Region

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        'get data
        Dim para(2) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", New DateTime(2013, 5, 1))
        para(1) = New SqlClient.SqlParameter("@EndDate", New DateTime(2013, 5, 31))


        Dim obj() As WT_Group = db.GetObjects(Of WT_Group)("select * from WT_Group")
        For Each o As WT_Group In obj
            Application.DoEvents()
            para(2) = New SqlClient.SqlParameter("@GroupID", o.GroupID_K)
            Dim sql As String = String.Format("   SELECT   GroupID,PdCode, CustomerCode,CustomerName, " +
                      " sum([minute]) as KQCV,sum(QuantityGood) as PCQty" +
                      " FROM WT_WorkingResultHead h" +
                      " inner join dbo.WT_WorkingResultDetail d" +
                      " on h.ID=d.ID" +
                      " where WorkDate BETWEEN @StartDate AND @EndDate" +
                      " and CustomerCode in('0060','3060','0460','0560','6180')" +
                      " AND GroupID=@GroupID" +
                      " group by GroupID,PdCode,CustomerCode,CustomerName")
            db.ExecuteNonQuery(sql, para)
            '_db.ExecuteStoreProcedure("sp_WT_GetWorkTimeDetail", paraD)
        Next
    End Sub

    Private Sub bttSavePath_Click(sender As System.Object, e As System.EventArgs) Handles bttSavePath.Click
        Dim obj As New Main_PathInfo
        obj.UserID_K = CurrentUser.UserID
        _db.GetObjectNotReset(obj)
        obj.PathEntity = txtPathEntity.Text
        obj.PathStore = txtPathStore.Text
        If _db.ExistObject(obj) Then
            _db.Update(obj)
        Else
            _db.Insert(obj)
        End If
        ShowSuccess()
    End Sub

    Private Sub FrmUtilityTool_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        Dim obj As New Main_PathInfo
        obj.UserID_K = CurrentUser.UserID
        _db.GetObject(obj)
        txtPathEntity.Text = obj.PathEntity
        txtPathStore.Text = obj.PathStore
        txtBuildFolder.Text = obj.PathBuild
        txtDestination.Text = obj.PathServer


        Dim sql As String = String.Format("select Lib from (SELECT distinct [AssemblyName] as Lib " +
                                         " FROM [Main_FormRight] " +
                                         " where [AssemblyName]<>'' " +
                                         " union all select 'PublicUtility.dll' " +
                                         " union all select 'UtilityControl.dll' " +
                                         " union all select 'CommonDB.dll' " +
                                         " union all select 'LibEntity.dll' " +
                                         " union all select 'LibMaster.dll' " +
                                         " union all select 'ERPUpdate.exe' " +
                                         " union all select 'LibPermission.dll')l order by Lib ")
        GridControlUD.DataSource = db.FillDataTable(sql)
        GridControlSetFormat(GridViewUD)
        GridViewUD.BestFitColumns()


        LoadServerList()
    End Sub

    Sub LoadServerList()
        GridControlS.DataSource = _db.FillDataTable("select * from [Main_Connection]")
        GridControlSetFormat(GridViewS)
        GridViewS.BestFitColumns()
    End Sub

    Private Sub bttPathStore_Click(sender As System.Object, e As System.EventArgs) Handles bttPathStore.Click
        Dim browser As New FolderBrowserDialog()
        browser.ShowDialog()
        If browser.SelectedPath <> "" Then
            txtPathStore.Text = browser.SelectedPath
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles bttBuild.Click
        Dim browser As New FolderBrowserDialog()
        browser.ShowDialog()
        If browser.SelectedPath <> "" Then
            txtBuildFolder.Text = browser.SelectedPath
        End If
    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles bttServer.Click
        Dim browser As New FolderBrowserDialog()
        browser.ShowDialog()
        If browser.SelectedPath <> "" Then
            txtDestination.Text = browser.SelectedPath
        End If
    End Sub

    Private Sub bttSaveUpdate_Click(sender As System.Object, e As System.EventArgs) Handles bttSaveUpdate.Click
        Dim obj As New Main_PathInfo
        obj.UserID_K = CurrentUser.UserID
        _db.GetObjectNotReset(obj)
        obj.PathBuild = txtBuildFolder.Text
        obj.PathServer = txtDestination.Text
        If _db.ExistObject(obj) Then
            _db.Update(obj)
        Else
            _db.Insert(obj)
        End If
        ShowSuccess()
    End Sub

    Private Sub bttUpdate_Click(sender As System.Object, e As System.EventArgs) Handles bttUpdate.Click
        For Each r As Integer In GridViewUD.GetSelectedRows
            If File.Exists(txtBuildFolder.Text & GridViewUD.GetRowCellValue(r, "Lib")) Then
                File.Copy(txtBuildFolder.Text & GridViewUD.GetRowCellValue(r, "Lib"),
                      txtDestination.Text & GridViewUD.GetRowCellValue(r, "Lib"), True)
            End If
        Next
        ShowSuccess()
    End Sub

    Private Sub GridViewS_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridViewS.CellValueChanged
        Dim obj As New Main_Connection
        obj.ID_K = GridViewS.GetFocusedRowCellValue("ID")
        If GridViewS.GetFocusedRowCellValue("StringConnection") IsNot DBNull.Value Then
            obj.StringConnection = GridViewS.GetFocusedRowCellValue("StringConnection")
        End If
        If GridViewS.GetFocusedRowCellValue("IsOK") IsNot DBNull.Value Then
            obj.IsOK = GridViewS.GetFocusedRowCellValue("IsOK")
        End If
        If GridViewS.GetFocusedRowCellValue("PCNo") IsNot DBNull.Value Then
            obj.PCNo = GridViewS.GetFocusedRowCellValue("PCNo")
        End If
        If GridViewS.GetFocusedRowCellValue("EmpID") IsNot DBNull.Value Then
            obj.EmpID = GridViewS.GetFocusedRowCellValue("EmpID")
        End If
        If GridViewS.GetFocusedRowCellValue("Note") IsNot DBNull.Value Then
            obj.Note = GridViewS.GetFocusedRowCellValue("Note")
        End If

        If _db.ExistObject(obj) Then
            _db.Update(obj)
        Else
            _db.Insert(obj)
        End If
    End Sub

    Private Sub FrmUtilityTool_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            If CurrentUser.UserID = "15180" Then
                GridControlReadOnly(GridViewS, False)
                GridControlSetColorEdit(GridViewS)
                GridViewS.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            End If
        End If
    End Sub

    Private Sub bttSource_Click(sender As Object, e As EventArgs) Handles bttSource.Click
        Dim browser As New FolderBrowserDialog()
        browser.ShowDialog()
        If browser.SelectedPath <> "" Then
            txtSourceBK.Text = browser.SelectedPath
        End If
    End Sub

    Private Sub bttDestinationBK_Click(sender As Object, e As EventArgs) Handles bttDestinationBK.Click
        Dim browser As New FolderBrowserDialog()
        browser.ShowDialog()
        If browser.SelectedPath <> "" Then
            txtDestinationBK.Text = browser.SelectedPath
        End If
    End Sub

    Private Sub bttCopy_Click(sender As Object, e As EventArgs) Handles bttCopy.Click
        Dim mThread As New Thread(AddressOf CopyFileBK)
        mThread.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerCopyFile.Tick
        txtStatusBK.Text = Date.Now.ToString("hh:mm:ss")
        If txtNextCopy.Text = txtStatusBK.Text Then
            Dim mThread As New Thread(AddressOf CopyFileBK)
            mThread.Start()
        End If
    End Sub

    Private Sub WriteTextStatus(text As String)
        If txtStatusBK.InvokeRequired Then
            Dim d As New SafeCallDelegate(AddressOf CopyFileBK)
            txtStatusBK.Invoke(d, New Object() {text})
        Else
            txtStatusBK.Text = text
        End If
    End Sub

    Private Sub WriteTextLastCopy(text As String)
        If txtLastCopy.InvokeRequired Then
            Dim d As New SafeCallDelegate(AddressOf CopyFileBK)
            txtLastCopy.Invoke(d, New Object() {text})
        Else
            txtLastCopy.Text = text
        End If
    End Sub

    Private Sub WriteTextNextCopy(text As String)
        If txtNextCopy.InvokeRequired Then
            Dim d As New SafeCallDelegate(AddressOf CopyFileBK)
            txtNextCopy.Invoke(d, New Object() {text})
        Else
            txtNextCopy.Text = text
        End If
    End Sub

    Sub CopyFileBK()
        WriteTextStatus("Copy...")

        If ckoAutoCopy.Checked Then
            TimerCopyFile.Enabled = False
        End If

        Dim ArrFolder() As String
        ArrFolder = Directory.GetDirectories(txtSourceBK.Text)
        ''Copy file Backup Full
        For Each f As String In Directory.GetFiles(txtSourceBK.Text)
            If Not File.Exists(txtDestinationBK.Text & New FileInfo(f).Name) Then
                WriteTextStatus("Copy.." & txtDestinationBK.Text & New FileInfo(f).Name)
                File.Copy(f, txtDestinationBK.Text & New FileInfo(f).Name, True)
            End If
        Next

        ''Copy file Backup Differential
        For Each d As String In ArrFolder
            For Each f As String In Directory.GetFiles(d)
                If Not File.Exists(txtDestinationBK.Text & New FileInfo(f).Name) Then
                    WriteTextStatus("Copy.." & txtDestinationBK.Text & New FileInfo(f).Name)
                    File.Copy(f, txtDestinationBK.Text & New FileInfo(f).Name, True)
                End If
            Next
        Next
        ''Delete old File 
        For Each f As String In Directory.GetFiles(txtDestinationBK.Text)
            If New FileInfo(f).LastWriteTime.Date < Date.Now.AddDays(-5).Date Then
                File.Delete(f)
            End If
        Next

        If ckoAutoCopy.Checked Then
            TimerCopyFile.Enabled = True
            If IsNumeric(txthours.Text) Then
                WriteTextNextCopy(Date.Now.AddHours(txthours.Text).ToString("dd-MMM-yyyy hh:mm:ss"))
            Else
                WriteTextNextCopy(Date.Now.AddHours(1).ToString("dd-MMM-yyyy hh:mm:ss"))
            End If
        End If
        WriteTextLastCopy(Date.Now.ToString("dd-MMM-yyyy hh:mm:ss"))
        WriteTextStatus("Copy complete...")

    End Sub

    Private Sub ckoAutoCopy_CheckedChanged(sender As Object, e As EventArgs) Handles ckoAutoCopy.CheckedChanged
        TimerCopyFile.Enabled = ckoAutoCopy.Checked
        If ckoAutoCopy.Checked Then
            Dim mThread As New Thread(AddressOf CopyFileBK)
            mThread.Start()
        End If
    End Sub

    Private Sub mnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
        LoadServerList()
    End Sub
End Class
