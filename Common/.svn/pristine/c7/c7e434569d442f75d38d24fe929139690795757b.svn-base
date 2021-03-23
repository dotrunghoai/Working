Imports System.Data.Common
Imports Common.PublicConst
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Text



Public Class DBDB2 : Implements IDBFunction

#Region "Constructor"
    Public Sub New(ByVal server As EnumServers)
        _server = server
    End Sub

    Public Sub New(ByVal connectString As String)
        _sqlConnect = New OdbcConnection(connectString)
    End Sub
#End Region

#Region "Property"
    Private _server As EnumServers
    Private _sqlConnect As OdbcConnection = Nothing
    Private _sqlAdapter As OdbcDataAdapter = Nothing
    Private _sqlReader As OdbcDataReader = Nothing
    Private _sqlCommand As OdbcCommand = Nothing
    Private _sqlTransaction As OdbcTransaction = Nothing
    Private _sqlParameter As OdbcParameter = Nothing
    'Private _sqlBulkCopy As OdbcBulkCopy = Nothing

    Public ReadOnly Property Server As String Implements IDBFunction.Server
        Get
            Return _sqlConnect.DataSource
        End Get
    End Property
    ReadOnly Property Database As String Implements IDBFunction.Database
        Get
            Return _sqlConnect.Database
        End Get
    End Property
    ReadOnly Property ConnectString As String Implements IDBFunction.ConnectString
        Get
            Return _sqlConnect.ConnectionString
        End Get
    End Property
    ReadOnly Property WorkStationID As String Implements IDBFunction.WorkStationID
        Get
            Return "None" '_sqlConnect.WorkstationId
        End Get
    End Property
    ReadOnly Property ConnectionTimeout As Integer Implements IDBFunction.ConnectionTimeout
        Get
            Return _sqlConnect.ConnectionTimeout
        End Get
    End Property
    ReadOnly Property State As ConnectionState Implements IDBFunction.State
        Get
            Return _sqlConnect.State
        End Get
    End Property
#End Region
#Region "Delegates and events "
    Private Event UpdateBulkRowCopied(ByVal sender As Object, ByVal row As Long) Implements IDBFunction.UpdateBulkRowCopied
#End Region
#Region "Functions"

    Private Sub BulkCopy(ByVal table As DataTable, ByVal destinationTable As String) Implements IDBFunction.BulkCopy
        OpenConnect()
        '_sqlBulkCopy = New SqlBulkCopy(_sqlConnect)
        '_sqlBulkCopy.BulkCopyTimeout = 0
        '_sqlBulkCopy.BatchSize = 50
        '_sqlBulkCopy.NotifyAfter = 50
        '_sqlBulkCopy.DestinationTableName = destinationTable
        'AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
        '_sqlBulkCopy.WriteToServer(table)

        '_sqlBulkCopy.Close()
    End Sub
    Private Sub BulkCopy(ByVal table As DataTable, ByVal destinationTable As String, ByVal mapping() As SqlBulkCopyColumnMapping) Implements IDBFunction.BulkCopy
        OpenConnect()
        '_sqlBulkCopy = New SqlBulkCopy(_sqlConnect)
        '_sqlBulkCopy.BulkCopyTimeout = 0
        '_sqlBulkCopy.BatchSize = 50
        '_sqlBulkCopy.NotifyAfter = 50
        '_sqlBulkCopy.DestinationTableName = destinationTable
        'For Each map As SqlBulkCopyColumnMapping In mapping
        '    _sqlBulkCopy.ColumnMappings.Add(map)
        'Next
        'AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
        '_sqlBulkCopy.WriteToServer(table)

        '_sqlBulkCopy.Close()
    End Sub
    Private Sub BulkCopy(ByVal reader As IDataReader, ByVal destinationTable As String) Implements IDBFunction.BulkCopy
        'OpenConnect()
        '_sqlBulkCopy = New SqlBulkCopy(_sqlConnect)
        '_sqlBulkCopy.BulkCopyTimeout = 0
        '_sqlBulkCopy.BatchSize = 50
        '_sqlBulkCopy.NotifyAfter = 50
        '_sqlBulkCopy.DestinationTableName = destinationTable
        'AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
        '_sqlBulkCopy.WriteToServer(reader)

        'reader.Close()
        '_sqlBulkCopy.Close()
    End Sub
    Private Sub BulkCopy(ByVal reader As IDataReader, ByVal destinationTable As String, ByVal mapping() As SqlBulkCopyColumnMapping) Implements IDBFunction.BulkCopy
        'OpenConnect()
        '_sqlBulkCopy = New SqlBulkCopy(_sqlConnect)
        '_sqlBulkCopy.BulkCopyTimeout = 0
        '_sqlBulkCopy.BatchSize = 50
        '_sqlBulkCopy.NotifyAfter = 50
        '_sqlBulkCopy.DestinationTableName = destinationTable
        'For Each map As SqlBulkCopyColumnMapping In mapping
        '    _sqlBulkCopy.ColumnMappings.Add(map)
        'Next
        'AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
        '_sqlBulkCopy.WriteToServer(reader)

        'reader.Close()
        '_sqlBulkCopy.Close()
    End Sub
    Sub BulkCopy(ByVal dataRows As DataRow, ByVal destinationTable As String) Implements IDBFunction.BulkCopy
        'OpenConnect()
        '_sqlBulkCopy = New SqlBulkCopy(_sqlConnect)
        '_sqlBulkCopy.BulkCopyTimeout = 0
        '_sqlBulkCopy.BatchSize = 50
        '_sqlBulkCopy.NotifyAfter = 50
        '_sqlBulkCopy.DestinationTableName = destinationTable
        'AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
        '_sqlBulkCopy.WriteToServer(dataRows)

        '_sqlBulkCopy.Close()
    End Sub
    Sub BulkCopy(ByVal dataRows As DataRow, ByVal destinationTable As String, ByVal mapping() As SqlBulkCopyColumnMapping) Implements IDBFunction.BulkCopy
        'OpenConnect()
        '_sqlBulkCopy = New SqlBulkCopy(_sqlConnect)
        '_sqlBulkCopy.BulkCopyTimeout = 0
        '_sqlBulkCopy.BatchSize = 50
        '_sqlBulkCopy.NotifyAfter = 50
        '_sqlBulkCopy.DestinationTableName = destinationTable
        'For Each map As SqlBulkCopyColumnMapping In mapping
        '    _sqlBulkCopy.ColumnMappings.Add(map)
        'Next
        'AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
        '_sqlBulkCopy.WriteToServer(dataRows)

        '_sqlBulkCopy.Close()
    End Sub
    Private Sub HandleBulkCopy(ByVal sender As Object, ByVal e As SqlRowsCopiedEventArgs) Implements IDBFunction.HandleBulkCopy
        RaiseEvent UpdateBulkRowCopied(sender, e.RowsCopied)
    End Sub

    Function FillDataTable(ByVal selectCommand As String) As DataTable Implements IDBFunction.FillDataTable

        Dim tb As New DataTable
        OpenConnect()
        _sqlAdapter = New OdbcDataAdapter(selectCommand, _sqlConnect)
        _sqlAdapter.Fill(tb)

        Return tb

    End Function
    Function FillDataTable(ByVal selectCommand As String, ByVal para() As DbParameter) As DataTable Implements IDBFunction.FillDataTable

        Dim tb As New DataTable
        OpenConnect()
        _sqlCommand = New OdbcCommand(selectCommand, _sqlConnect)
        _sqlCommand.Parameters.AddRange(para)
        _sqlAdapter = New OdbcDataAdapter(_sqlCommand)
        _sqlAdapter.Fill(tb)

        Return tb

    End Function
    Function FillDataTable(ByVal sqlcommand As DbCommand) As DataTable Implements IDBFunction.FillDataTable

        Dim tb As New DataTable
        OpenConnect()
        _sqlAdapter = New OdbcDataAdapter(sqlcommand)
        _sqlAdapter.Fill(tb)

        Return tb

    End Function
    Function FillDataSet(ByVal selectCommand As String, ByVal para() As DbParameter) As DataSet Implements IDBFunction.FillDataSet

        Dim ds As New DataSet
        OpenConnect()
        _sqlCommand = New OdbcCommand(selectCommand, _sqlConnect)
        _sqlCommand.Parameters.AddRange(para)
        _sqlAdapter = New OdbcDataAdapter(_sqlCommand)
        _sqlAdapter.Fill(ds)

        Return ds
    End Function

    Function FillDataSet(ByVal selectCommand As String) As DataSet Implements IDBFunction.FillDataSet

        Dim ds As New DataSet
        OpenConnect()
        _sqlAdapter = New OdbcDataAdapter(selectCommand, _sqlConnect)
        _sqlAdapter.Fill(ds)

        Return ds

    End Function
    Function ExecuteNonQuery(ByVal commandText As String, ByVal para() As DbParameter) As Integer Implements IDBFunction.ExecuteNonQuery
        OpenConnect()
        _sqlCommand = New OdbcCommand(commandText, _sqlConnect)
        _sqlCommand.CommandTimeout = 0
        _sqlCommand.Parameters.AddRange(para)
        Dim count As Integer = _sqlCommand.ExecuteNonQuery()
        _sqlCommand.Parameters.Clear()
        Return count
    End Function
    Function ExecuteNonQuery(ByVal commandText As String) As Integer Implements IDBFunction.ExecuteNonQuery
        OpenConnect()
        _sqlCommand = New OdbcCommand(commandText, _sqlConnect)
        _sqlCommand.CommandTimeout = 0
        Return _sqlCommand.ExecuteNonQuery()
    End Function
    Function ExecuteReader(ByVal commandText As String) As DbDataReader Implements IDBFunction.ExecuteReader
        OpenConnect()
        _sqlCommand = New OdbcCommand(commandText, _sqlConnect)
        _sqlCommand.CommandTimeout = 0
        Return _sqlCommand.ExecuteReader()
    End Function
    Function ExecuteScalar(ByVal commandText As String) As Object Implements IDBFunction.ExecuteScalar
        OpenConnect()
        _sqlCommand = New OdbcCommand(commandText, _sqlConnect)
        _sqlCommand.CommandTimeout = 0
        Return _sqlCommand.ExecuteScalar()
    End Function

    Function Update(Of T)(ByVal obj As T) As Integer Implements IDBFunction.Update
        OpenConnect()
        _sqlCommand = New OdbcCommand(CreateCommandUpdate(Of T)(obj), _sqlConnect)
        _sqlCommand.Parameters.AddRange(CreateParameter(Of T)(obj))
        Return _sqlCommand.ExecuteNonQuery()
    End Function
    Function Insert(Of T)(ByVal obj As T) As Integer Implements IDBFunction.Insert
        OpenConnect()
        _sqlCommand = New OdbcCommand(CreateCommandInsert(Of T)(obj), _sqlConnect)
        _sqlCommand.Parameters.AddRange(CreateParameter(Of T)(obj))
        Return _sqlCommand.ExecuteNonQuery()
    End Function
    Function Delete(Of T)(ByVal obj As T) As Integer Implements IDBFunction.Delete
        OpenConnect()
        _sqlCommand = New OdbcCommand(CreateCommandDelete(obj), _sqlConnect)
        _sqlCommand.Parameters.AddRange(CreateParameterKey(obj))
        Return _sqlCommand.ExecuteNonQuery()
    End Function

    Sub GetObject(Of T)(ByRef obj As T) Implements IDBFunction.GetObject
        Dim type As Type
        Dim tb As DataTable

        type = obj.GetType()
        Dim fields() As FieldInfo = type.GetFields()

        _sqlCommand = New OdbcCommand(CreateCommandSelect(obj), _sqlConnect)
        _sqlCommand.Parameters.AddRange(CreateParameterKey(obj))
        tb = FillDataTable(_sqlCommand)

        If Not IsDBNull(tb) And tb.Rows.Count > 0 Then
            For Each f As FieldInfo In fields
                If Not IsDBNull(tb.Rows(0)(f.Name.Replace(PublicConst.Key, ""))) Then f.SetValue(obj, tb.Rows(0)(f.Name.Replace(PublicConst.Key, "")))
            Next
        End If


    End Sub
    Function GetObject(Of T)(ByVal selectCommand As String) As T Implements IDBFunction.GetObject
        Dim type As Type
        Dim obj As T
        Dim tb As DataTable

        obj = Activator.CreateInstance(Of T)()
        type = obj.GetType()
        Dim fields() As FieldInfo = type.GetFields()

        tb = FillDataTable(selectCommand)

        If Not IsDBNull(tb) And tb.Rows.Count > 0 Then
            For Each f As FieldInfo In fields
                If Not IsDBNull(tb.Rows(0)(f.Name.Replace(PublicConst.Key, ""))) Then f.SetValue(obj, tb.Rows(0)(f.Name.Replace(PublicConst.Key, "")))
            Next
        End If

        Return obj
    End Function
    Function GetObjects(Of T)(ByVal selectCommand As String) As T() Implements IDBFunction.GetObjects
        Dim type As Type
        Dim obj As T
        Dim tb As DataTable
        Dim objs() As T = Nothing

        tb = FillDataTable(selectCommand)

        If Not IsDBNull(tb) And tb.Rows.Count > 0 Then
            ReDim objs(tb.Rows.Count - 1)
            For rowNumer As Integer = 0 To tb.Rows.Count - 1
                obj = Activator.CreateInstance(Of T)()
                type = obj.GetType()
                Dim fields() As FieldInfo = type.GetFields()
                For Each f As FieldInfo In fields
                    If Not IsDBNull(tb.Rows(rowNumer)(f.Name.Replace(PublicConst.Key, ""))) Then f.SetValue(obj, tb.Rows(rowNumer)(f.Name.Replace(PublicConst.Key, "")))
                Next
                objs(rowNumer) = obj
            Next
        End If

        Return objs
    End Function
    Function GetObjects(Of T)(ByVal selectCommand As String, ByVal para() As DbParameter) As T() Implements IDBFunction.GetObjects
        Dim type As Type
        Dim obj As T
        Dim tb As DataTable
        Dim objs() As T = Nothing

        tb = FillDataTable(selectCommand, para)

        If Not IsDBNull(tb) And tb.Rows.Count > 0 Then
            ReDim objs(tb.Rows.Count - 1)
            For rowNumer As Integer = 0 To tb.Rows.Count - 1
                obj = Activator.CreateInstance(Of T)()
                type = obj.GetType()
                Dim fields() As FieldInfo = type.GetFields()
                For Each f As FieldInfo In fields
                    If Not IsDBNull(tb.Rows(rowNumer)(f.Name.Replace(PublicConst.Key, ""))) Then f.SetValue(obj, tb.Rows(rowNumer)(f.Name.Replace(PublicConst.Key, "")))
                Next
                objs(rowNumer) = obj
            Next
        End If

        Return objs
    End Function
    Function GetAll(Of T)() As T() Implements IDBFunction.GetAll

        Dim type As Type
        Dim obj As T
        Dim tb As DataTable
        Dim objs() As T = Nothing
        obj = Activator.CreateInstance(Of T)()
        type = obj.GetType()
        tb = FillDataTable("select * from " & type.Name)

        If Not IsDBNull(tb) And tb.Rows.Count > 0 Then
            ReDim objs(tb.Rows.Count - 1)
            For rowNumer As Integer = 0 To tb.Rows.Count - 1
                obj = Activator.CreateInstance(Of T)()
                type = obj.GetType()
                Dim fields() As FieldInfo = type.GetFields()
                For Each f As FieldInfo In fields
                    If Not IsDBNull(tb.Rows(rowNumer)(f.Name.Replace(PublicConst.Key, ""))) Then f.SetValue(obj, tb.Rows(rowNumer)(f.Name.Replace(PublicConst.Key, "")))
                Next
                objs(rowNumer) = obj
            Next
        End If

        Return objs
    End Function
    Function GetAllTable(Of T)() As DataTable Implements IDBFunction.GetAllTable
        Dim tb As New DataTable
        Dim type As Type
        Dim obj As T

        obj = Activator.CreateInstance(Of T)()
        type = obj.GetType()
        tb = FillDataTable("select * from " & type.Name)

        Return tb
    End Function
    Function GetAllList(Of T)() As List(Of T) Implements IDBFunction.GetAllList
        Dim type As Type
        Dim obj As T
        Dim tb As DataTable
        Dim objs As List(Of T) = Nothing
        obj = Activator.CreateInstance(Of T)()
        type = obj.GetType()
        tb = FillDataTable("select * from " & type.Name)

        If Not IsDBNull(tb) And tb.Rows.Count > 0 Then

            For rowNumer As Integer = 0 To tb.Rows.Count - 1
                obj = Activator.CreateInstance(Of T)()
                type = obj.GetType()
                Dim fields() As FieldInfo = type.GetFields()
                For Each f As FieldInfo In fields
                    If Not IsDBNull(tb.Rows(rowNumer)(f.Name.Replace(PublicConst.Key, ""))) Then f.SetValue(obj, tb.Rows(rowNumer)(f.Name.Replace(PublicConst.Key, "")))
                Next
                objs.Add(obj)
            Next
        End If

        Return objs
    End Function
    Function GetList(Of T)(ByVal selectCommand As String) As List(Of T) Implements IDBFunction.GetList
        Dim type As Type
        Dim obj As T
        Dim tb As DataTable
        Dim objs As List(Of T) = Nothing
        obj = Activator.CreateInstance(Of T)()
        type = obj.GetType()
        tb = FillDataTable(selectCommand)

        If Not IsDBNull(tb) And tb.Rows.Count > 0 Then

            For rowNumer As Integer = 0 To tb.Rows.Count - 1
                obj = Activator.CreateInstance(Of T)()
                type = obj.GetType()
                Dim fields() As FieldInfo = type.GetFields()
                For Each f As FieldInfo In fields
                    If Not IsDBNull(tb.Rows(rowNumer)(f.Name.Replace(PublicConst.Key, ""))) Then f.SetValue(obj, tb.Rows(rowNumer)(f.Name.Replace(PublicConst.Key, "")))
                Next
                objs.Add(obj)
            Next
        End If

        Return objs
    End Function
    Function GetList(Of T)(ByVal selectCommand As String, ByVal para() As DbParameter) As List(Of T) Implements IDBFunction.GetList
        Dim type As Type
        Dim obj As T
        Dim tb As DataTable
        Dim objs As List(Of T) = Nothing
        obj = Activator.CreateInstance(Of T)()
        type = obj.GetType()
        tb = FillDataTable(selectCommand, para)

        If Not IsDBNull(tb) And tb.Rows.Count > 0 Then

            For rowNumer As Integer = 0 To tb.Rows.Count - 1
                obj = Activator.CreateInstance(Of T)()
                type = obj.GetType()
                Dim fields() As FieldInfo = type.GetFields()
                For Each f As FieldInfo In fields
                    If Not IsDBNull(tb.Rows(rowNumer)(f.Name.Replace(PublicConst.Key, ""))) Then f.SetValue(obj, tb.Rows(rowNumer)(f.Name.Replace(PublicConst.Key, "")))
                Next
                objs.Add(obj)
            Next
        End If

        Return objs
    End Function

    Function ExistTable(ByVal tableName As String) As Boolean Implements IDBFunction.ExistTable
        Dim tb As DataTable
        tb = FillDataTable("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE Table_Name='" & tableName & "'")
        If tb.Rows.Count > 0 Then Return True
        Return False
    End Function
    Function ExistObject(Of T)(ByVal obj As T) As Boolean Implements IDBFunction.ExistObject

        Dim tb As DataTable
        _sqlCommand = New OdbcCommand(CreateCommandSelect(obj), _sqlConnect)
        _sqlCommand.Parameters.AddRange(CreateParameterKey(obj))
        tb = FillDataTable(_sqlCommand)

        If Not IsDBNull(tb) And tb.Rows.Count > 0 Then
            Return True
        End If

        Return False
    End Function

    Private Function CreateParameter(Of T)(ByVal obj As T) As DbParameter() Implements IDBFunction.CreateParameter
        Dim type As Type
        type = obj.GetType()
        Dim fields() As FieldInfo = type.GetFields()
        Dim paras(fields.Length - 1) As OdbcParameter

        For index As Integer = 0 To fields.Length - 1
            If fields(index).GetValue(obj) <> Nothing Then
                paras(index) = New OdbcParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), fields(index).GetValue(obj))
                paras(index).IsNullable = True
            Else
                paras(index) = New OdbcParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), DBNull.Value)
                paras(index).IsNullable = True
            End If

        Next

        Return paras

    End Function
    Private Function CreateParameterKey(Of T)(ByVal obj As T) As DbParameter() Implements IDBFunction.CreateParameterKey
        Dim type As Type
        type = obj.GetType()
        Dim fields() As FieldInfo = type.GetFields()
        Dim countKey As Integer = 0
        For index As Integer = 0 To fields.Length - 1
            If fields(index).Name.Contains(PublicConst.Key) Then
                countKey += 1
            End If
        Next

        Dim paras(countKey - 1) As OdbcParameter

        For index As Integer = 0 To fields.Length - 1
            If fields(index).Name.Contains(PublicConst.Key) Then
                If fields(index).GetValue(obj) <> Nothing Then
                    paras(index) = New OdbcParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), fields(index).GetValue(obj))
                    paras(index).IsNullable = True
                Else
                    paras(index) = New OdbcParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), DBNull.Value)
                    paras(index).IsNullable = True
                End If
            End If

        Next

        Return paras
    End Function

    Private Function CreateCommandInsert(Of T)(ByVal obj As T) As String Implements IDBFunction.CreateCommandInsert
        Dim type As Type
        Dim sql As New StringBuilder()
        type = obj.GetType()
        Dim fields() As FieldInfo = type.GetFields()
        sql.Append(" INSERT INTO " & type.Name)
        sql.Append(" ( ")
        For index As Integer = 0 To fields.Length - 1
            If index < (fields.Length - 1) Then
                sql.Append(fields(index).Name.Replace(PublicConst.Key, "") & " , ")
            Else
                sql.Append(fields(index).Name.Replace(PublicConst.Key, ""))
                sql.Append(" ) ")
            End If
        Next
        sql.Append(" VALUES ( ")
        For index As Integer = 0 To fields.Length - 1
            If index < (fields.Length - 1) Then
                sql.Append("@" & fields(index).Name.Replace(PublicConst.Key, "") & " , ")
            Else
                sql.Append("@" & fields(index).Name.Replace(PublicConst.Key, ""))
                sql.Append(" ) ")
            End If
        Next

        Return sql.ToString()
    End Function
    Private Function CreateCommandUpdate(Of T)(ByVal obj As T) As String Implements IDBFunction.CreateCommandUpdate
        Dim key As Integer = 0
        Dim type As Type
        Dim sql As New StringBuilder()
        type = obj.GetType()
        Dim fields() As FieldInfo = type.GetFields()
        sql.Append(" Update " & type.Name)

        sql.Append(" SET  ")
        For index As Integer = 0 To fields.Length - 1
            If index < (fields.Length - 1) Then
                sql.Append(fields(index).Name.Replace(PublicConst.Key, "") & "= @" & fields(index).Name.Replace(PublicConst.Key, "") & " , ")
            Else
                sql.Append(fields(index).Name.Replace(PublicConst.Key, "") & "= @" & fields(index).Name.Replace(PublicConst.Key, ""))
            End If
            If fields(index).Name.Contains(PublicConst.Key) Then
                key = index
            End If
        Next
        sql.Append(" Where ")
        For index As Integer = 0 To fields.Length - 1
            If fields(index).Name.Contains(PublicConst.Key) Then
                If key = index Then
                    sql.Append(fields(index).Name.Replace(PublicConst.Key, "") & "= @" & fields(index).Name.Replace(PublicConst.Key, ""))
                Else
                    sql.Append(fields(index).Name.Replace(PublicConst.Key, "") & "= @" & fields(index).Name.Replace(PublicConst.Key, "") & " And ")
                End If
            End If
        Next
        Return sql.ToString()
    End Function
    Private Function CreateCommandSelect(Of T)(ByVal obj As T) As String Implements IDBFunction.CreateCommandSelect
        Dim key As Integer = 0
        Dim type As Type
        Dim sql As New StringBuilder()
        type = obj.GetType()
        Dim fields() As FieldInfo = type.GetFields()
        sql.Append(" Select * From " & type.Name)

        For index As Integer = 0 To fields.Length - 1
            If fields(index).Name.Contains(PublicConst.Key) Then
                key = index
            End If
        Next
        sql.Append(" Where ")
        For index As Integer = 0 To fields.Length - 1
            If fields(index).Name.Contains(PublicConst.Key) Then
                If key = index Then
                    sql.Append(fields(index).Name.Replace(PublicConst.Key, "") & "= @" & fields(index).Name.Replace(PublicConst.Key, ""))
                Else
                    sql.Append(fields(index).Name.Replace(PublicConst.Key, "") & "= @" & fields(index).Name.Replace(PublicConst.Key, "") & " And ")
                End If
            End If
        Next
        Return sql.ToString()
    End Function
    Private Function CreateCommandDelete(Of T)(ByVal obj As T) As String Implements IDBFunction.CreateCommandDelete
        Dim key As Integer = 0
        Dim type As Type
        Dim sql As New StringBuilder()
        type = obj.GetType()
        Dim fields() As FieldInfo = type.GetFields()
        sql.Append(" Delete  From " & type.Name)

        For index As Integer = 0 To fields.Length - 1
            If fields(index).Name.Contains(PublicConst.Key) Then
                key = index
            End If
        Next
        sql.Append(" Where ")
        For index As Integer = 0 To fields.Length - 1
            If fields(index).Name.Contains(PublicConst.Key) Then
                If key = index Then
                    sql.Append(fields(index).Name.Replace(PublicConst.Key, "") & "= @" & fields(index).Name.Replace(PublicConst.Key, ""))
                Else
                    sql.Append(fields(index).Name.Replace(PublicConst.Key, "") & "= @" & fields(index).Name.Replace(PublicConst.Key, "") & " And ")
                End If
            End If
        Next
        Return sql.ToString()
    End Function

    Private Function GetConnectString(ByVal server As EnumServers) As String Implements IDBFunction.GetConnectString
        Select Case server
            Case EnumServers.NDV_SQL_ERP_NDV
                Return PublicConst.SQL_DB_ERP_NDV
            Case EnumServers.NDV_SQL_Factory
                Return PublicConst.SQL_DB_Factory
            Case EnumServers.NDV_SQL_Fpics
                Return PublicConst.SQL_DB_FPICS
            Case EnumServers.NDV_SQL_None
                Return PublicConst.SQL_None
        End Select

        Return String.Empty

    End Function
    Public Function CheckConnection() As Boolean Implements IDBFunction.CheckConnection
        Try
            _sqlConnect = New OdbcConnection(GetConnectString(_server))
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub OpenConnect() Implements IDBFunction.OpenConnect
        If _sqlConnect IsNot Nothing Then
            If _sqlConnect.State <> ConnectionState.Open Then
                _sqlConnect.Close()
                _sqlConnect.Open()
            End If
        Else
            _sqlConnect = New OdbcConnection(GetConnectString(_server))
            _sqlConnect.Open()
        End If
    End Sub

#End Region

#Region "Transaction"

    Sub BeginTransaction() Implements IDBFunction.BeginTransaction
        OpenConnect()
        _sqlTransaction = _sqlConnect.BeginTransaction()
    End Sub
    Sub Commit() Implements IDBFunction.Commit
        _sqlTransaction.Commit()
    End Sub
    Sub RollBack() Implements IDBFunction.RollBack
        _sqlTransaction.Rollback()
    End Sub

#End Region
End Class
