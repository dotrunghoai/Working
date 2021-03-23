Imports System.Data.Common
Imports System.Data.OracleClient
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Text
Imports PublicUtility
Imports PublicUtility.PublicConst

Public Class DBOracle : Implements IDBFunction


#Region "Property"
    Private _server As EnumServers
    Private _sqlReader As OracleDataReader = Nothing
    Private _sqlTransaction As OracleTransaction = Nothing
    Private _sqlParameter As OracleParameter = Nothing
    Private _sqlBulkCopy As SqlBulkCopy = Nothing
    Private _timeOut As Integer = 10

    <Obsolete>
    Public ReadOnly Property Server As String Implements IDBFunction.Server
        Get
            Return SqlConnect.DataSource
        End Get
    End Property

    <Obsolete>
    ReadOnly Property Database As String Implements IDBFunction.Database
        Get
            Return SqlConnect.Database
        End Get
    End Property

    <Obsolete>
    ReadOnly Property ConnectString As String Implements IDBFunction.ConnectString
        Get
            Return SqlConnect.ConnectionString
        End Get
    End Property
    ReadOnly Property WorkStationID As String Implements IDBFunction.WorkStationID
        Get
            Return "" ' _sqlConnect.WorkstationId
        End Get
    End Property

    <Obsolete>
    ReadOnly Property ConnectionTimeout As Integer Implements IDBFunction.ConnectionTimeout
        Get
            Return SqlConnect.ConnectionTimeout
        End Get
    End Property

    <Obsolete>
    ReadOnly Property State As ConnectionState Implements IDBFunction.State
        Get
            Return SqlConnect.State
        End Get
    End Property

    <Obsolete>
    Public Property SqlCommand As OracleCommand = Nothing

    <Obsolete>
    Public Property SqlAdapter As OracleDataAdapter = Nothing

    <Obsolete>
    Public Property SqlConnect As OracleConnection = Nothing
#End Region

#Region "Constructor"
    <Obsolete>
    Public Sub New(ByVal server As EnumServers)
        _server = server
        SqlConnect = New OracleConnection(GetConnectString(server))
        OpenConnect()
    End Sub

    <Obsolete>
    Public Sub New(ByVal connectString As String)
        SqlConnect = New OracleConnection(connectString)
        OpenConnect()
    End Sub
#End Region

#Region "Delegates and events "
    Event eventBulkRowCopied As DelegateBulkRowCopied
#End Region

#Region "Functions"

    Sub BulkCopy(ByVal table As DataTable, ByVal destinationTable As String) Implements IDBFunction.BulkCopy
        'OpenConnect()
        '_sqlBulkCopy = New SqlBulkCopy(_sqlConnect)
        '_sqlBulkCopy.BulkCopyTimeout = 0
        '_sqlBulkCopy.BatchSize = 100
        '_sqlBulkCopy.NotifyAfter = 100
        '_sqlBulkCopy.DestinationTableName = destinationTable
        'AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
        '_sqlBulkCopy.WriteToServer(table)
        '_sqlBulkCopy.Close()
    End Sub
    Sub BulkCopy(ByVal table As DataTable, ByVal destinationTable As String, ByVal mapping() As SqlBulkCopyColumnMapping) Implements IDBFunction.BulkCopy
        'OpenConnect()
        '_sqlBulkCopy = New SqlBulkCopy(_sqlConnect)
        '_sqlBulkCopy.BulkCopyTimeout = 0
        '_sqlBulkCopy.BatchSize = 100
        '_sqlBulkCopy.NotifyAfter = 100
        '_sqlBulkCopy.DestinationTableName = destinationTable
        'For Each map As SqlBulkCopyColumnMapping In mapping
        '    _sqlBulkCopy.ColumnMappings.Add(map)
        'Next
        'AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
        '_sqlBulkCopy.WriteToServer(table)
        '_sqlBulkCopy.Close()
    End Sub
    Sub BulkCopy(ByVal reader As IDataReader, ByVal destinationTable As String) Implements IDBFunction.BulkCopy
        'OpenConnect()
        '_sqlBulkCopy = New SqlBulkCopy(_sqlConnect)
        '_sqlBulkCopy.BulkCopyTimeout = 0
        '_sqlBulkCopy.BatchSize = 100
        '_sqlBulkCopy.NotifyAfter = 100
        '_sqlBulkCopy.DestinationTableName = destinationTable
        'AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
        '_sqlBulkCopy.WriteToServer(reader)
        'reader.Close()
        '_sqlBulkCopy.Close()
    End Sub
    Sub BulkCopy(ByVal reader As IDataReader, ByVal destinationTable As String, ByVal mapping() As SqlBulkCopyColumnMapping) Implements IDBFunction.BulkCopy
        'OpenConnect()
        '_sqlBulkCopy = New SqlBulkCopy(_sqlConnect)
        '_sqlBulkCopy.BulkCopyTimeout = 0
        '_sqlBulkCopy.BatchSize = 100
        '_sqlBulkCopy.NotifyAfter = 100
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
        '_sqlBulkCopy.BatchSize = 100
        '_sqlBulkCopy.NotifyAfter = 100
        '_sqlBulkCopy.DestinationTableName = destinationTable
        'AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
        '_sqlBulkCopy.WriteToServer(dataRows)
        '_sqlBulkCopy.Close()
    End Sub
    Sub BulkCopy(ByVal dataRows As DataRow, ByVal destinationTable As String, ByVal mapping() As SqlBulkCopyColumnMapping) Implements IDBFunction.BulkCopy
        'OpenConnect()
        '_sqlBulkCopy = New SqlBulkCopy(_sqlConnect)
        '_sqlBulkCopy.BulkCopyTimeout = 0
        '_sqlBulkCopy.BatchSize = 100
        '_sqlBulkCopy.NotifyAfter = 100
        '_sqlBulkCopy.DestinationTableName = destinationTable
        'For Each map As SqlBulkCopyColumnMapping In mapping
        '    _sqlBulkCopy.ColumnMappings.Add(map)
        'Next
        'AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
        '_sqlBulkCopy.WriteToServer(dataRows)
        '_sqlBulkCopy.Close()
    End Sub
    Private Sub HandleBulkCopy(ByVal sender As Object, ByVal e As SqlRowsCopiedEventArgs) Implements IDBFunction.HandleBulkCopy
        RaiseEvent eventBulkRowCopied(sender, e.RowsCopied)
    End Sub

    <Obsolete>
    Function FillDataTable(ByVal selectCommand As String) As DataTable Implements IDBFunction.FillDataTable
        OpenConnect()
        Dim tb As New DataTable
        SqlCommand = New OracleCommand(selectCommand, SqlConnect)
        SqlCommand.CommandTimeout = 0
        SqlCommand.Transaction = _sqlTransaction
        SqlAdapter = New OracleDataAdapter(SqlCommand)
        SqlAdapter.Fill(tb)
        Return tb
    End Function

    <Obsolete>
    Function FillDataTable(ByVal selectCommand As String, ByVal para() As DbParameter) As DataTable Implements IDBFunction.FillDataTable
        OpenConnect()
        Dim tb As New DataTable
        Try
            SqlCommand = New OracleCommand(selectCommand, SqlConnect)
            SqlCommand.CommandTimeout = 0
            SqlCommand.Parameters.AddRange(para)
            SqlCommand.Transaction = _sqlTransaction
            SqlAdapter = New OracleDataAdapter(SqlCommand)
            SqlAdapter.Fill(tb)
            SqlCommand.Parameters.Clear()
        Catch ex As Exception
            SqlCommand.Parameters.Clear()
            Throw (ex)
        End Try
        Return tb
    End Function

    <Obsolete>
    Function FillDataTable(ByVal OracleCommand As DbCommand) As DataTable Implements IDBFunction.FillDataTable
        OpenConnect()
        Dim tb As New DataTable
        OracleCommand.CommandTimeout = 0
        OracleCommand.Connection = SqlConnect
        OracleCommand.Transaction = _sqlTransaction
        SqlAdapter = New OracleDataAdapter(OracleCommand)
        SqlAdapter.Fill(tb)
        Return tb
    End Function

    <Obsolete>
    Function FillDataTable(ByVal OracleCommand As DbCommand, ByVal para() As DbParameter) As DataTable Implements IDBFunction.FillDataTable
        OpenConnect()
        Dim tb As New DataTable
        OracleCommand.Connection = SqlConnect
        OracleCommand.Transaction = _sqlTransaction
        OracleCommand.CommandTimeout = 0
        OracleCommand.Parameters.AddRange(para)
        SqlAdapter = New OracleDataAdapter(OracleCommand)
        SqlAdapter.Fill(tb)
        OracleCommand.Parameters.Clear()
        Return tb
    End Function
    ''' <summary>
    ''' This function is obsolete
    ''' </summary>
    ''' <param name="selectCommand"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Obsolete>
    Function FillDataSet(ByVal selectCommand As String) As DataSet Implements IDBFunction.FillDataSet
        OpenConnect()
        Dim ds As New DataSet
        Try
            SqlCommand = New OracleCommand(selectCommand, SqlConnect)
            SqlCommand.CommandTimeout = 0
            SqlCommand.Transaction = _sqlTransaction
            SqlAdapter = New OracleDataAdapter(SqlCommand)
            SqlAdapter.Fill(ds)
            SqlCommand.Parameters.Clear()
        Catch ex As Exception
            SqlCommand.Parameters.Clear()
            Throw (ex)
        End Try
        Return ds
    End Function
    ''' <summary>
    ''' This function is obsolete
    ''' </summary>
    ''' <param name="selectCommand"></param>
    ''' <param name="para"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Obsolete>
    Function FillDataSet(ByVal selectCommand As String, ByVal para() As DbParameter) As DataSet Implements IDBFunction.FillDataSet
        OpenConnect()
        Dim ds As New DataSet
        Try
            SqlCommand = New OracleCommand(selectCommand, SqlConnect)
            SqlCommand.CommandTimeout = 0
            SqlCommand.Parameters.AddRange(para)
            SqlCommand.Transaction = _sqlTransaction
            SqlAdapter = New OracleDataAdapter(SqlCommand)
            SqlAdapter.Fill(ds)
            SqlCommand.Parameters.Clear()
        Catch ex As Exception
            SqlCommand.Parameters.Clear()
            Throw (ex)
        End Try
        Return ds
    End Function

    <Obsolete>
    Function FillDataSet(ByVal selectCommand As String, ByRef ds As DataSet, ByVal tableName As String) As DataSet Implements IDBFunction.FillDataSet
        OpenConnect()
        Try
            SqlCommand = New OracleCommand(selectCommand, SqlConnect)
            SqlCommand.CommandTimeout = 0
            SqlCommand.Transaction = _sqlTransaction
            SqlAdapter = New OracleDataAdapter(SqlCommand)
            SqlAdapter.Fill(ds, tableName)
            SqlCommand.Parameters.Clear()

        Catch ex As Exception
            SqlCommand.Parameters.Clear()
            Throw (ex)
        End Try
        Return ds
    End Function

    <Obsolete>
    Function FillDataSet(ByVal selectCommand As String, ByVal para() As DbParameter, ByRef ds As DataSet, ByVal tableName As String) As DataSet Implements IDBFunction.FillDataSet
        OpenConnect()
        Try
            SqlCommand = New OracleCommand(selectCommand, SqlConnect)
            SqlCommand.CommandTimeout = 0
            SqlCommand.Parameters.AddRange(para)
            SqlCommand.Transaction = _sqlTransaction
            SqlAdapter = New OracleDataAdapter(SqlCommand)
            SqlAdapter.Fill(ds, tableName)
            SqlCommand.Parameters.Clear()
        Catch ex As Exception
            SqlCommand.Parameters.Clear()
            Throw (ex)
        End Try
        Return ds
    End Function

    <Obsolete>
    Function ExecuteNonQuery(ByVal commandText As String) As Integer Implements IDBFunction.ExecuteNonQuery
        OpenConnect()
        SqlCommand = New OracleCommand(commandText, SqlConnect)
        SqlCommand.CommandTimeout = 0
        SqlCommand.Transaction = _sqlTransaction
        Return SqlCommand.ExecuteNonQuery()
    End Function

    <Obsolete>
    Function ExecuteNonQuery(ByVal commandText As String, ByVal para() As DbParameter) As Integer Implements IDBFunction.ExecuteNonQuery
        OpenConnect()
        Dim count As Integer = 0
        Try
            SqlCommand = New OracleCommand(commandText, SqlConnect)
            SqlCommand.CommandTimeout = 0
            SqlCommand.Transaction = _sqlTransaction
            SqlCommand.Parameters.AddRange(para)
            count = SqlCommand.ExecuteNonQuery()
            SqlCommand.Parameters.Clear()
        Catch ex As Exception
            SqlCommand.Parameters.Clear()
            Throw (ex)
        End Try
        Return count
    End Function

    <Obsolete>
    Function ExecuteReader(ByVal commandText As String) As DbDataReader Implements IDBFunction.ExecuteReader
        OpenConnect()
        SqlCommand = New OracleCommand(commandText, SqlConnect)
        SqlCommand.CommandTimeout = 0
        SqlCommand.Transaction = _sqlTransaction
        Return SqlCommand.ExecuteReader()
    End Function

    <Obsolete>
    Function ExecuteReader(ByVal commandText As String, ByVal para() As DbParameter) As DbDataReader Implements IDBFunction.ExecuteReader
        Dim reader As OracleDataReader
        Try
            OpenConnect()
            SqlCommand = New OracleCommand(commandText, SqlConnect)
            SqlCommand.CommandTimeout = 0
            SqlCommand.Transaction = _sqlTransaction
            SqlCommand.Parameters.AddRange(para)
            reader = SqlCommand.ExecuteReader()
            SqlCommand.Parameters.Clear()
        Catch ex As Exception
            SqlCommand.Parameters.Clear()
            Throw (ex)
        End Try
        Return reader
    End Function

    <Obsolete>
    Function ExecuteScalar(ByVal commandText As String, ByVal para() As DbParameter) As Object Implements IDBFunction.ExecuteScalar
        Dim obj As Object
        OpenConnect()
        Try
            SqlCommand = New OracleCommand(commandText, SqlConnect) With {
                .CommandTimeout = 0,
                .Transaction = _sqlTransaction
            }
            SqlCommand.Parameters.AddRange(para)
            obj = SqlCommand.ExecuteScalar()
            SqlCommand.Parameters.Clear()
        Catch ex As Exception
            SqlCommand.Parameters.Clear()
            Throw (ex)
        End Try
        Return obj
    End Function

    <Obsolete>
    Function ExecuteScalar(ByVal commandText As String) As Object Implements IDBFunction.ExecuteScalar
        Dim obj As Object
        OpenConnect()
        Try
            SqlCommand = New OracleCommand(commandText, SqlConnect)
            SqlCommand.CommandTimeout = 0
            SqlCommand.Transaction = _sqlTransaction
            obj = SqlCommand.ExecuteScalar()
        Catch ex As Exception
            Throw (ex)
        End Try
        Return obj
    End Function

    <Obsolete>
    Function ExecuteScalarSP(ByVal commandText As String, ByVal para() As DbParameter) As Object
        Dim obj As Object
        OpenConnect()
        Try
            SqlCommand = New OracleCommand(commandText, SqlConnect)
            SqlCommand.CommandTimeout = 0
            SqlCommand.Transaction = _sqlTransaction
            SqlCommand.CommandType = CommandType.StoredProcedure
            SqlCommand.Parameters.AddRange(para)
            obj = SqlCommand.ExecuteScalar()
            SqlCommand.Parameters.Clear()
        Catch ex As Exception
            SqlCommand.Parameters.Clear()
            Throw (ex)
        End Try
        Return obj
    End Function

    <Obsolete>
    Function ExecuteStoreProcedure(ByVal sp_name As String) As Integer
        OpenConnect()
        SqlCommand = New OracleCommand(sp_name, SqlConnect)
        SqlCommand.CommandTimeout = 0
        SqlCommand.CommandType = CommandType.StoredProcedure
        SqlCommand.Transaction = _sqlTransaction
        Return SqlCommand.ExecuteNonQuery()
    End Function

    <Obsolete>
    Function ExecuteStoreProcedure(ByVal sp_name As String, ByVal para() As DbParameter) As Integer
        Dim effect As Integer = 0
        Try
            OpenConnect()
            SqlCommand = New OracleCommand(sp_name, SqlConnect)
            SqlCommand.CommandTimeout = 0
            SqlCommand.CommandType = CommandType.StoredProcedure
            SqlCommand.Parameters.AddRange(para)
            SqlCommand.Transaction = _sqlTransaction
            effect = SqlCommand.ExecuteNonQuery()
            SqlCommand.Parameters.Clear()
        Catch ex As Exception
            SqlCommand.Parameters.Clear()
            Throw (ex)
        End Try
        Return effect
    End Function

    <Obsolete>
    Function ExecuteStoreProcedureTB(ByVal sp_name As String, ByVal para() As DbParameter) As DataTable
        Dim tb As New DataTable
        Try
            OpenConnect()
            SqlCommand = New OracleCommand(sp_name, SqlConnect)
            SqlCommand.CommandTimeout = 0
            SqlCommand.CommandType = CommandType.StoredProcedure
            SqlCommand.Transaction = _sqlTransaction
            tb = FillDataTable(SqlCommand, para)
            SqlCommand.Parameters.Clear()
        Catch ex As Exception
            SqlCommand.Parameters.Clear()
            Throw (ex)
        End Try
        Return tb
    End Function

    <Obsolete>
    Function ExecuteStoreProcedureTB(ByVal sp_name As String) As DataTable
        Dim unused As New DataTable

        Dim tb As DataTable
        Try
            OpenConnect()
            SqlCommand = New OracleCommand(sp_name, SqlConnect)
            SqlCommand.CommandTimeout = 0
            SqlCommand.CommandType = CommandType.StoredProcedure
            SqlCommand.Transaction = _sqlTransaction
            tb = FillDataTable(SqlCommand)
        Catch ex As Exception
            Throw (ex)
        End Try
        Return tb
    End Function

    <Obsolete>
    Function Update(Of T)(ByVal obj As T) As Integer Implements IDBFunction.Update
        OpenConnect()
        SqlCommand = New OracleCommand(CreateCommandUpdate(Of T)(obj), SqlConnect)
        SqlCommand.Parameters.AddRange(CreateParameter(Of T)(obj))
        SqlCommand.Transaction = _sqlTransaction
        SqlCommand.CommandTimeout = 3
        Return SqlCommand.ExecuteNonQuery()
    End Function

    <Obsolete>
    Function Update(Of T)(ByVal obj As T, ByVal condition As String) As Integer
        OpenConnect()
        SqlCommand = New OracleCommand(CreateCommandUpdate(Of T)(obj, condition), SqlConnect)
        SqlCommand.Parameters.AddRange(CreateParameter(Of T)(obj))
        SqlCommand.Transaction = _sqlTransaction
        SqlCommand.CommandTimeout = 3
        Return SqlCommand.ExecuteNonQuery()
    End Function

    <Obsolete>
    Function Insert(Of T)(ByVal obj As T) As Integer Implements IDBFunction.Insert
        OpenConnect()
        SqlCommand = New OracleCommand(CreateCommandInsert(Of T)(obj), SqlConnect)
        SqlCommand.Parameters.AddRange(CreateParameter(Of T)(obj))
        SqlCommand.Transaction = _sqlTransaction
        SqlCommand.CommandTimeout = 3
        Return SqlCommand.ExecuteNonQuery()
    End Function

    <Obsolete>
    Function Delete(Of T)(ByVal obj As T) As Integer Implements IDBFunction.Delete
        OpenConnect()
        SqlCommand = New OracleCommand(CreateCommandDelete(obj), SqlConnect)
        SqlCommand.Parameters.AddRange(CreateParameterKey(obj))
        SqlCommand.Transaction = _sqlTransaction
        SqlCommand.CommandTimeout = 3
        Return SqlCommand.ExecuteNonQuery()
    End Function

    <Obsolete>
    Sub GetObject(Of T)(ByRef obj As T) Implements IDBFunction.GetObject
        Dim type As Type
        Dim tb As DataTable = New DataTable
        OpenConnect()
        type = obj.GetType()
        Dim fields() As FieldInfo = type.GetFields()
        SqlCommand = New OracleCommand(CreateCommandSelect(obj), SqlConnect)
        SqlCommand.CommandTimeout = 0
        SqlCommand.Parameters.AddRange(CreateParameterKey(obj))
        SqlCommand.Transaction = _sqlTransaction
        _sqlReader = SqlCommand.ExecuteReader()
        If _sqlReader.Read Then
            For Each f As FieldInfo In fields
                If Not IsDBNull(_sqlReader.Item(f.Name.Replace(PublicConst.Key, ""))) Then f.SetValue(obj, _sqlReader.Item(f.Name.Replace(PublicConst.Key, "")))
            Next
        Else
            For Each f As FieldInfo In fields
                f.SetValue(obj, Nothing)
            Next
        End If
        SqlCommand.Dispose()
        _sqlReader.Close()
    End Sub

    <Obsolete>
    Function GetObject(Of T)(ByVal selectCommand As String) As T Implements IDBFunction.GetObject
        Dim type As Type
        Dim obj As T
        Dim tb As DataTable
        OpenConnect()
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

    <Obsolete>
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

    <Obsolete>
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

    <Obsolete>
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

    <Obsolete>
    Function GetAllTable(Of T)() As DataTable Implements IDBFunction.GetAllTable
        Dim tb As New DataTable
        Dim type As Type
        Dim obj As T
        obj = Activator.CreateInstance(Of T)()
        type = obj.GetType()
        tb = FillDataTable("select * from " & type.Name)
        Return tb
    End Function

    <Obsolete>
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

    <Obsolete>
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

    <Obsolete>
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

    ''' <summary>
    ''' Columns in table: table_name
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Obsolete>
    Function GetAllTableName() As DataTable
        Dim sql = String.Format(" select table_name " &
                        " from INFORMATION_SCHEMA.tables " &
                        " where " &
                        " TABLE_TYPE = 'BASE TABLE' order by table_name ")
        Return FillDataTable(sql)
    End Function
    ''' <summary>
    ''' Only a columns ame: name
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Obsolete>
    Function GetAllStoreProcedures() As DataTable
        Dim sql As String = String.Format(" select * from sysobjects " +
                                        " where xtype='P' " +
                                        " order by name ")
        Return FillDataTable(sql)
    End Function
    ''' <summary>
    ''' Columns in table: table_name, column_name, datatype, length
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Obsolete>
    Function GetAllColumn() As DataTable
        Dim sql As String = String.Format(" SELECT  table_name=sysobjects.name, " &
                            " column_name=syscolumns.name, " &
                            " datatype=systypes.name, " &
                            " length = syscolumns.length " &
                            " FROM sysobjects " &
                            " JOIN syscolumns ON sysobjects.id = syscolumns.id " &
                            " JOIN systypes ON syscolumns.xtype=systypes.xusertype " &
                            " WHERE sysobjects.xtype='U' " &
                            " ORDER BY sysobjects.name,syscolumns.colid ")

        Return FillDataTable(sql)
    End Function

    ''' <summary>
    ''' Columns in table: table_name, column_name, datatype, length
    ''' </summary>
    ''' <param name="tableName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Obsolete>
    Function GetAllColumn(ByVal tableName As String) As DataTable
        Dim sql As String = String.Format(" SELECT  table_name=sysobjects.name, " &
                            " column_name=syscolumns.name, " &
                            " datatype=systypes.name, " &
                            " length = syscolumns.length " &
                            " FROM sysobjects " &
                            " JOIN syscolumns ON sysobjects.id = syscolumns.id " &
                            " JOIN systypes ON syscolumns.xtype=systypes.xusertype " &
                            " WHERE sysobjects.xtype='U' and sysobjects.name='{0}'" &
                            " ORDER BY sysobjects.name,syscolumns.colid ", tableName)
        Return FillDataTable(sql)
    End Function

    <Obsolete>
    Function GetKeysOfTable(ByVal tableName As String) As DataTable
        Dim sql As String = ""
        sql = String.Format("")
        SqlCommand = New OracleCommand("sp_pkeys")
        SqlCommand.CommandType = CommandType.StoredProcedure
        SqlCommand.Parameters.AddWithValue("@table_name", tableName)
        Return FillDataTable(SqlCommand)
    End Function

    <Obsolete>
    Function GetMaxValue(Of T)(ByVal field As String) As Object Implements IDBFunction.GetMaxValue
        Dim tableName As String = ""
        tableName = Activator.CreateInstance(Of T)().GetType().Name
        Return ExecuteScalar(String.Format("select max({0}) from {1} ", field, tableName))
    End Function

    <Obsolete>
    Function ExistTable(ByVal tableName As String) As Boolean Implements IDBFunction.ExistTable
        Dim tb As DataTable
        tb = FillDataTable("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE Table_Name='" & tableName & "'")
        If tb.Rows.Count > 0 Then Return True
        Return False
    End Function

    <Obsolete>
    Function ExistObject(Of T)(ByVal obj As T) As Boolean Implements IDBFunction.ExistObject
        OpenConnect()
        Dim tb As DataTable
        SqlCommand = New OracleCommand(CreateCommandSelect(obj), SqlConnect)
        SqlCommand.Parameters.AddRange(CreateParameterKey(obj))
        SqlCommand.Transaction = _sqlTransaction
        tb = FillDataTable(SqlCommand)
        If Not IsDBNull(tb) And tb.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function CreateParameter(Of T)(ByVal obj As T) As DbParameter() Implements IDBFunction.CreateParameter
        Dim type As Type
        type = obj.GetType()
        Dim fields() As FieldInfo = type.GetFields()
        Dim paras(fields.Length - 1) As OracleParameter
        For index As Integer = 0 To fields.Length - 1
            If fields(index).GetValue(obj) IsNot Nothing Then
                If fields(index).FieldType.Name = "DateTime" Then
                    If CType(fields(index).GetValue(obj), DateTime).Year <= 1900 Then
                        paras(index) = New OracleParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), DBNull.Value)
                        paras(index).IsNullable = True
                    Else
                        paras(index) = New OracleParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), fields(index).GetValue(obj))
                        paras(index).IsNullable = True
                    End If
                Else
                    paras(index) = New OracleParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), fields(index).GetValue(obj))
                    paras(index).IsNullable = True
                End If
            Else
                paras(index) = New OracleParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), DBNull.Value)
                paras(index).IsNullable = True
                If fields(index).FieldType.Name = "Byte[]" Then
                    paras(index).OracleType = OracleType.Byte
                End If
            End If
        Next
        Return paras
    End Function
    Private Function CreateParameterKey(Of T)(ByVal obj As T) As DbParameter() Implements IDBFunction.CreateParameterKey
        Dim type As Type
        Dim indexKey As Integer = 0
        type = obj.GetType()
        Dim fields() As FieldInfo = type.GetFields()
        Dim countKey As Integer = 0
        For index As Integer = 0 To fields.Length - 1
            If fields(index).Name.Contains(PublicConst.Key) Then
                countKey += 1
            End If
        Next
        Dim paras(countKey - 1) As OracleParameter
        For index As Integer = 0 To fields.Length - 1
            If fields(index).Name.Contains(PublicConst.Key) Then
                If fields(index).GetValue(obj) IsNot Nothing Then
                    If fields(index).FieldType.Name = "DateTime" Then
                        If CType(fields(index).GetValue(obj), DateTime).Year <= 1900 Then
                            paras(indexKey) = New OracleParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), DBNull.Value)
                            paras(indexKey).IsNullable = True
                        Else
                            paras(indexKey) = New OracleParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), fields(index).GetValue(obj))
                            paras(indexKey).IsNullable = True
                        End If
                    Else
                        paras(indexKey) = New OracleParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), fields(index).GetValue(obj))
                        paras(indexKey).IsNullable = True
                    End If
                Else
                    paras(indexKey) = New OracleParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), DBNull.Value)
                    paras(indexKey).IsNullable = True
                End If
                indexKey += 1
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
                sql.Append(" [" & fields(index).Name.Replace(PublicConst.Key, "") & "] , ")
            Else
                sql.Append(" [" & fields(index).Name.Replace(PublicConst.Key, "") & "] ")
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
                sql.Append(" [" & fields(index).Name.Replace(PublicConst.Key, "") & "] = @" & fields(index).Name.Replace(PublicConst.Key, "") & " , ")
            Else
                sql.Append(" [" & fields(index).Name.Replace(PublicConst.Key, "") & "] = @" & fields(index).Name.Replace(PublicConst.Key, ""))
            End If
            If fields(index).Name.Contains(PublicConst.Key) Then
                key = index
            End If
        Next
        sql.Append(" Where ")
        For index As Integer = 0 To fields.Length - 1
            If fields(index).Name.Contains(PublicConst.Key) Then
                If key = index Then
                    sql.Append(" [" & fields(index).Name.Replace(PublicConst.Key, "") & "] = @" & fields(index).Name.Replace(PublicConst.Key, ""))
                Else
                    sql.Append(" [" & fields(index).Name.Replace(PublicConst.Key, "") & "] = @" & fields(index).Name.Replace(PublicConst.Key, "") & " And ")
                End If
            End If
        Next
        Return sql.ToString()
    End Function
    Private Function CreateCommandUpdate(Of T)(ByVal obj As T, ByVal condition As String) As String
        Dim key As Integer = 0
        Dim type As Type
        Dim sql As New StringBuilder()
        type = obj.GetType()
        Dim fields() As FieldInfo = type.GetFields()
        sql.Append(" Update " & type.Name)
        sql.Append(" SET  ")
        For index As Integer = 0 To fields.Length - 1
            If index < (fields.Length - 1) Then
                sql.Append(" [" & fields(index).Name.Replace(PublicConst.Key, "") & "] = @" & fields(index).Name.Replace(PublicConst.Key, "") & " , ")
            Else
                sql.Append(" [" & fields(index).Name.Replace(PublicConst.Key, "") & "] = @" & fields(index).Name.Replace(PublicConst.Key, ""))
            End If
            If fields(index).Name.Contains(PublicConst.Key) Then
                key = index
            End If
        Next
        sql.Append(" Where " & condition)
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
                    sql.Append(" [" & fields(index).Name.Replace(PublicConst.Key, "") & "] = @" & fields(index).Name.Replace(PublicConst.Key, ""))
                Else
                    sql.Append(" [" & fields(index).Name.Replace(PublicConst.Key, "") & "] = @" & fields(index).Name.Replace(PublicConst.Key, "") & " And ")
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
                    sql.Append(" [" & fields(index).Name.Replace(PublicConst.Key, "") & "] = @" & fields(index).Name.Replace(PublicConst.Key, ""))
                Else
                    sql.Append(" [" & fields(index).Name.Replace(PublicConst.Key, "") & "] = @" & fields(index).Name.Replace(PublicConst.Key, "") & " And ")
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
            Case EnumServers.NDV_SQL_ThaiSon
                Return PublicConst.SQL_DB_ThaiSon
            Case Else
                Return PublicConst.SQL_None
        End Select
        Return String.Empty
    End Function

    <Obsolete>
    Public Function CheckConnection() As Boolean Implements IDBFunction.CheckConnection
        Try
            OpenConnect()
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return False
        End Try
    End Function

    <Obsolete>
    Public Function OpenConnect() As Boolean Implements IDBFunction.OpenConnect
        Try
            If SqlConnect IsNot Nothing Then
                If SqlConnect.State <> ConnectionState.Open Then
                    Try
                        SqlConnect.Close()
                        SqlConnect.Open()
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End If
            Else
                SqlConnect = New OracleConnection(GetConnectString(_server))
                SqlConnect.Open()
            End If
            Return True
        Catch ex As Exception
            Throw (ex)
            Return False
        End Try
    End Function

    <Obsolete>
    Public Function CloseConnect() As Boolean Implements IDBFunction.CloseConnect
        Try
            If SqlConnect IsNot Nothing Then
                If SqlConnect.State <> ConnectionState.Closed Then
                    SqlConnect.Close()
                End If
            End If
            Return True
        Catch ex As Exception
            Throw (ex)
            Return False
        End Try
    End Function

#End Region

#Region "Transaction"

    <Obsolete>
    Sub BeginTransaction() Implements IDBFunction.BeginTransaction
        OpenConnect()
        _sqlTransaction = SqlConnect.BeginTransaction()
    End Sub
    Sub Commit() Implements IDBFunction.Commit
        _sqlTransaction.Commit()
        _sqlTransaction = Nothing
    End Sub
    Sub RollBack() Implements IDBFunction.RollBack
        _sqlTransaction.Rollback()
        _sqlTransaction = Nothing
    End Sub

#End Region
End Class
