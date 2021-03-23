Imports System.Data.Common
Imports System.Data
Imports System.Data.SqlClient
Imports CommonDB
Imports System.Reflection
Imports System.Text
Imports PublicUtility
Imports PublicUtility.PublicConst
Imports LibEntity
''' <summary>
''' Author: Truong Minh Tam (IT-Nitto Denko)
''' Date: 25-Aug-2011
''' </summary>
''' <remarks> Management function to query only SQL Server</remarks>
''' 

Public Class DBSql : Implements IDBFunction
    Dim stdTimeOut As Integer = 0
    Dim midTimeOut As Integer = 0
    Dim longTimeOut As Integer = 0
    Dim verylongTimeOut As Integer = 0
    Dim minuteTimeOut As Integer = 0
    Dim noTimeout As Integer = 0

#Region "Constructor"
    Private _enumServers As EnumServers

    Public Sub New(ByVal server As EnumServers)

        _server = server
        _sqlConnect = New SqlConnection(GetConnectString(server))

    End Sub
    Public Sub New(ByVal connectString As String)
        _myConnectString = connectString
        _sqlConnect = New SqlConnection(connectString)

    End Sub
#End Region

#Region "Property"
    Private _myConnectString As String = Nothing
    Private _server As EnumServers = Nothing
    Private _sqlConnect As SqlConnection = Nothing
    Private _sqlAdapter As SqlDataAdapter = Nothing
    Private _sqlReader As SqlDataReader = Nothing
    Private _sqlCommand As SqlCommand = Nothing
    Private _sqlTransaction As SqlTransaction = Nothing
    Private _sqlParameter As SqlParameter = Nothing
    Private _sqlBulkCopy As SqlBulkCopy = Nothing
    Private _timeOut As Integer = 30

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
            Return _sqlConnect.WorkstationId
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
    Event eventBulkRowCopied As DelegateBulkRowCopied
#End Region

#Region "Functions"

    Sub BulkCopy(ByVal table As DataTable, ByVal destinationTable As String) Implements IDBFunction.BulkCopy
        If CheckConnection() Then
            _sqlBulkCopy = New SqlBulkCopy(_sqlConnect, SqlBulkCopyOptions.Default, _sqlTransaction)
            _sqlBulkCopy.BulkCopyTimeout = noTimeout
            _sqlBulkCopy.BatchSize = 100
            _sqlBulkCopy.NotifyAfter = 100
            _sqlBulkCopy.DestinationTableName = destinationTable
            AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
            _sqlBulkCopy.WriteToServer(table)
            _sqlBulkCopy.Close()
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                SqlConnection.ClearAllPools()
            End If
        End If
    End Sub
    Sub BulkCopy(ByVal table As DataTable, ByVal destinationTable As String, ByVal mapping() As SqlBulkCopyColumnMapping) Implements IDBFunction.BulkCopy
        If CheckConnection() Then
            _sqlBulkCopy = New SqlBulkCopy(_sqlConnect, SqlBulkCopyOptions.Default, _sqlTransaction)
            _sqlBulkCopy.BulkCopyTimeout = noTimeout
            _sqlBulkCopy.BatchSize = 100
            _sqlBulkCopy.NotifyAfter = 100
            _sqlBulkCopy.DestinationTableName = destinationTable
            For Each map As SqlBulkCopyColumnMapping In mapping
                _sqlBulkCopy.ColumnMappings.Add(map)
            Next
            AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
            _sqlBulkCopy.WriteToServer(table)
            _sqlBulkCopy.Close()
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                SqlConnection.ClearAllPools()
            End If
        End If
    End Sub
    Sub BulkCopy(ByVal reader As IDataReader, ByVal destinationTable As String) Implements IDBFunction.BulkCopy
        If CheckConnection() Then
            _sqlBulkCopy = New SqlBulkCopy(_sqlConnect, SqlBulkCopyOptions.Default, _sqlTransaction)
            _sqlBulkCopy.BulkCopyTimeout = noTimeout
            _sqlBulkCopy.BatchSize = 100
            _sqlBulkCopy.NotifyAfter = 100
            _sqlBulkCopy.DestinationTableName = destinationTable
            AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
            _sqlBulkCopy.WriteToServer(reader)
            reader.Close()
            _sqlBulkCopy.Close()
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                SqlConnection.ClearAllPools()
            End If
        End If
    End Sub
    Sub BulkCopy(ByVal reader As IDataReader, ByVal destinationTable As String, ByVal mapping() As SqlBulkCopyColumnMapping) Implements IDBFunction.BulkCopy
        If CheckConnection() Then
            _sqlBulkCopy = New SqlBulkCopy(_sqlConnect, SqlBulkCopyOptions.Default, _sqlTransaction)
            _sqlBulkCopy.BulkCopyTimeout = noTimeout
            _sqlBulkCopy.BatchSize = 100
            _sqlBulkCopy.NotifyAfter = 100
            _sqlBulkCopy.DestinationTableName = destinationTable
            For Each map As SqlBulkCopyColumnMapping In mapping
                _sqlBulkCopy.ColumnMappings.Add(map)
            Next
            AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
            _sqlBulkCopy.WriteToServer(reader)
            reader.Close()
            _sqlBulkCopy.Close()
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                SqlConnection.ClearAllPools()
            End If
        End If
    End Sub
    Sub BulkCopy(ByVal dataRows As DataRow, ByVal destinationTable As String) Implements IDBFunction.BulkCopy
        If CheckConnection() Then
            _sqlBulkCopy = New SqlBulkCopy(_sqlConnect, SqlBulkCopyOptions.Default, _sqlTransaction)
            _sqlBulkCopy.BulkCopyTimeout = noTimeout
            _sqlBulkCopy.BatchSize = 100
            _sqlBulkCopy.NotifyAfter = 100
            _sqlBulkCopy.DestinationTableName = destinationTable
            AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
            _sqlBulkCopy.WriteToServer(dataRows)
            _sqlBulkCopy.Close()
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                SqlConnection.ClearAllPools()
            End If
        End If
    End Sub
    Sub BulkCopy(ByVal dataRows As DataRow, ByVal destinationTable As String, ByVal mapping() As SqlBulkCopyColumnMapping) Implements IDBFunction.BulkCopy
        If CheckConnection() Then
            _sqlBulkCopy = New SqlBulkCopy(_sqlConnect, SqlBulkCopyOptions.Default, _sqlTransaction)
            _sqlBulkCopy.BulkCopyTimeout = verylongTimeOut
            _sqlBulkCopy.BatchSize = 100
            _sqlBulkCopy.NotifyAfter = 100
            _sqlBulkCopy.DestinationTableName = destinationTable
            For Each map As SqlBulkCopyColumnMapping In mapping
                _sqlBulkCopy.ColumnMappings.Add(map)
            Next
            AddHandler _sqlBulkCopy.SqlRowsCopied, AddressOf HandleBulkCopy
            _sqlBulkCopy.WriteToServer(dataRows)
            _sqlBulkCopy.Close()
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                _sqlConnect.Dispose()
                SqlConnection.ClearAllPools()
            End If
        End If
    End Sub
    Private Sub HandleBulkCopy(ByVal sender As Object, ByVal e As SqlRowsCopiedEventArgs) Implements IDBFunction.HandleBulkCopy
        RaiseEvent eventBulkRowCopied(sender, e.RowsCopied)
    End Sub

    Function FillDataTable(ByVal selectCommand As String) As DataTable Implements IDBFunction.FillDataTable
        Dim tb As New DataTable
        If CheckConnection() Then

            _sqlCommand = New SqlCommand(selectCommand, _sqlConnect)
            _sqlCommand.CommandTimeout = verylongTimeOut
            _sqlCommand.Transaction = _sqlTransaction
            _sqlAdapter = New SqlDataAdapter(_sqlCommand)
            _sqlAdapter.Fill(tb)
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
				_sqlConnect.Dispose()
				_sqlAdapter.Dispose()
				_sqlCommand.Dispose()
				SqlConnection.ClearAllPools()
			End If
        End If
        Return tb
    End Function

    Function FillDataTable(ByVal selectCommand As String, ByVal para() As DbParameter) As DataTable Implements IDBFunction.FillDataTable
        Dim tb As New DataTable
        If CheckConnection() Then

            Try
                _sqlCommand = New SqlCommand(selectCommand, _sqlConnect)
                _sqlCommand.CommandTimeout = verylongTimeOut
                _sqlCommand.Parameters.AddRange(para)
                _sqlCommand.Transaction = _sqlTransaction
                _sqlAdapter = New SqlDataAdapter(_sqlCommand)
                _sqlAdapter.Fill(tb)
                _sqlCommand.Parameters.Clear()
            Catch ex As Exception
                _sqlCommand.Parameters.Clear()
                Throw (ex)
            End Try
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
				_sqlConnect.Dispose()
				_sqlAdapter.Dispose()
				_sqlCommand.Dispose()
				SqlConnection.ClearAllPools()
			End If
        End If
        Return tb
    End Function

    Function FillDataTable(ByVal sqlcommand As DbCommand) As DataTable Implements IDBFunction.FillDataTable
        Dim tb As New DataTable
        If CheckConnection() Then

            sqlcommand.CommandTimeout = verylongTimeOut
            sqlcommand.Connection = _sqlConnect
            sqlcommand.Transaction = _sqlTransaction
            _sqlAdapter = New SqlDataAdapter(sqlcommand)
            _sqlAdapter.Fill(tb)
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
				_sqlConnect.Dispose()
				_sqlAdapter.Dispose()
				sqlcommand.Dispose()
				SqlConnection.ClearAllPools()
			End If
        End If
        Return tb
    End Function

    Function FillDataTable(ByVal sqlcommand As DbCommand, ByVal para() As DbParameter) As DataTable Implements IDBFunction.FillDataTable
        Dim tb As New DataTable
        If CheckConnection() Then

            sqlcommand.Connection = _sqlConnect
            sqlcommand.Transaction = _sqlTransaction
            sqlcommand.CommandTimeout = verylongTimeOut
            sqlcommand.Parameters.AddRange(para)
            _sqlAdapter = New SqlDataAdapter(sqlcommand)
            _sqlAdapter.Fill(tb)
            sqlcommand.Parameters.Clear()
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
				_sqlConnect.Dispose()
				_sqlAdapter.Dispose()
				sqlcommand.Dispose()
				SqlConnection.ClearAllPools()
			End If
        End If
        Return tb
    End Function
    ''' <summary>
    ''' This function is obsolete
    ''' </summary>
    ''' <param name="selectCommand"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function FillDataSet(ByVal selectCommand As String) As DataSet Implements IDBFunction.FillDataSet
        Dim ds As New DataSet
        If CheckConnection() Then

            Try
                _sqlCommand = New SqlCommand(selectCommand, _sqlConnect)
                _sqlCommand.CommandTimeout = verylongTimeOut
                _sqlCommand.Transaction = _sqlTransaction
                _sqlAdapter = New SqlDataAdapter(_sqlCommand)
                _sqlAdapter.Fill(ds)
            Catch ex As Exception
                Throw (ex)
            End Try
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close() 
                _sqlConnect.Dispose()
                SqlConnection.ClearAllPools()
                _sqlAdapter.Dispose()
                _sqlCommand.Dispose()
            End If
        End If
        Return ds
    End Function
    ''' <summary>
    ''' This function is obsolete
    ''' </summary>
    ''' <param name="selectCommand"></param>
    ''' <param name="para"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function FillDataSet(ByVal selectCommand As String, ByVal para() As DbParameter) As DataSet Implements IDBFunction.FillDataSet
        Dim ds As New DataSet
        If CheckConnection() Then

            Try
                _sqlCommand = New SqlCommand(selectCommand, _sqlConnect)
                _sqlCommand.CommandTimeout = verylongTimeOut
                _sqlCommand.Parameters.AddRange(para)
                _sqlCommand.Transaction = _sqlTransaction
                _sqlAdapter = New SqlDataAdapter(_sqlCommand)
                _sqlAdapter.Fill(ds)
                _sqlCommand.Parameters.Clear()
            Catch ex As Exception
                _sqlCommand.Parameters.Clear()
                Throw (ex)
            End Try
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                _sqlConnect.Dispose()
                SqlConnection.ClearAllPools()
                _sqlAdapter.Dispose()
                _sqlCommand.Dispose()
            End If
        End If
        Return ds
    End Function

    Function FillDataSet(ByVal selectCommand As String, ByRef ds As DataSet, ByVal tableName As String) As DataSet Implements IDBFunction.FillDataSet
        If CheckConnection() Then
            Try
                _sqlCommand = New SqlCommand(selectCommand, _sqlConnect)
                _sqlCommand.CommandTimeout = verylongTimeOut
                _sqlCommand.Transaction = _sqlTransaction
                _sqlAdapter = New SqlDataAdapter(_sqlCommand)
                _sqlAdapter.Fill(ds, tableName)
            Catch ex As Exception
                Throw (ex)
            End Try
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                _sqlConnect.Dispose()
                SqlConnection.ClearAllPools()
                _sqlAdapter.Dispose()
                _sqlCommand.Dispose()
            End If
        End If
        Return ds
    End Function

    Function FillDataSet(ByVal selectCommand As String, ByVal para() As DbParameter, ByRef ds As DataSet, ByVal tableName As String) As DataSet Implements IDBFunction.FillDataSet
        If CheckConnection() Then
            Try
                _sqlCommand = New SqlCommand(selectCommand, _sqlConnect)
                _sqlCommand.CommandTimeout = verylongTimeOut
                _sqlCommand.Parameters.AddRange(para)
                _sqlCommand.Transaction = _sqlTransaction
                _sqlAdapter = New SqlDataAdapter(_sqlCommand)
                _sqlAdapter.Fill(ds, tableName)
                _sqlCommand.Parameters.Clear()
            Catch ex As Exception
                _sqlCommand.Parameters.Clear()
                Throw (ex)
            End Try
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                _sqlConnect.Dispose()
                SqlConnection.ClearAllPools()
                _sqlAdapter.Dispose()
                _sqlCommand.Dispose()
            End If
            Return ds
        Else
            Return ds
        End If
    End Function


    Function ExecuteNonQuery(ByVal commandText As String) As Integer Implements IDBFunction.ExecuteNonQuery
        If CheckConnection() Then
            _sqlCommand = New SqlCommand(commandText, _sqlConnect)
            _sqlCommand.CommandTimeout = verylongTimeOut
            _sqlCommand.Transaction = _sqlTransaction
            Dim effect As Integer = _sqlCommand.ExecuteNonQuery()
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                _sqlConnect.Dispose()
                SqlConnection.ClearAllPools()
                _sqlCommand.Dispose()
            End If
            Return effect
        Else
            Return 0
        End If
    End Function

    Function ExecuteNonQuery(ByVal commandText As String, ByVal para() As DbParameter) As Integer Implements IDBFunction.ExecuteNonQuery
        Dim count As Integer = 0
        If CheckConnection() Then

            Try
                _sqlCommand = New SqlCommand(commandText, _sqlConnect)
                _sqlCommand.CommandTimeout = verylongTimeOut
                _sqlCommand.Transaction = _sqlTransaction
                _sqlCommand.Parameters.AddRange(para)
                count = _sqlCommand.ExecuteNonQuery()
                _sqlCommand.Parameters.Clear()
            Catch ex As Exception
                _sqlCommand.Parameters.Clear()
                Throw (ex)
            End Try
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                _sqlConnect.Dispose()
                SqlConnection.ClearAllPools()
                _sqlCommand.Dispose()
            End If
        End If
        Return count
    End Function

    Function ExecuteReader(ByVal commandText As String) As DbDataReader Implements IDBFunction.ExecuteReader
        If CheckConnection() Then
            _sqlCommand = New SqlCommand(commandText, _sqlConnect)
            _sqlCommand.CommandTimeout = verylongTimeOut
            _sqlCommand.Transaction = _sqlTransaction
            Dim reader As SqlDataReader = _sqlCommand.ExecuteReader()
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                _sqlConnect.Dispose()
                SqlConnection.ClearAllPools()
                _sqlCommand.Dispose()
            End If
            Return reader
        Else
            Return Nothing
        End If
    End Function

    Function ExecuteReader(ByVal commandText As String, ByVal para() As DbParameter) As DbDataReader Implements IDBFunction.ExecuteReader
        Dim reader As SqlDataReader = Nothing
        Try
            If CheckConnection() Then
                _sqlCommand = New SqlCommand(commandText, _sqlConnect)
                _sqlCommand.CommandTimeout = verylongTimeOut
                _sqlCommand.Transaction = _sqlTransaction
                _sqlCommand.Parameters.AddRange(para)
                reader = _sqlCommand.ExecuteReader()
                _sqlCommand.Parameters.Clear()
                If _sqlTransaction Is Nothing Then
                    _sqlConnect.Close()
                    _sqlConnect.Dispose()
                    SqlConnection.ClearAllPools()
                    _sqlCommand.Dispose()
                End If
            End If
        Catch ex As Exception
            _sqlCommand.Parameters.Clear()
            Throw (ex)
        End Try
        Return reader
    End Function

    Function ExecuteScalar(ByVal commandText As String, ByVal para() As DbParameter) As Object Implements IDBFunction.ExecuteScalar
        Dim obj As New Object
        If CheckConnection() Then
            Try
                _sqlCommand = New SqlCommand(commandText, _sqlConnect)
                _sqlCommand.CommandTimeout = midTimeOut
                _sqlCommand.Transaction = _sqlTransaction
                _sqlCommand.Parameters.AddRange(para)
                obj = _sqlCommand.ExecuteScalar()
                _sqlCommand.Parameters.Clear()
                If _sqlTransaction Is Nothing Then
                    _sqlConnect.Close()
                    _sqlConnect.Dispose()
                    SqlConnection.ClearAllPools()
                    _sqlCommand.Dispose()
                End If

            Catch ex As Exception
                _sqlCommand.Parameters.Clear()
                Throw (ex)
            End Try
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
            End If
        End If
        Return obj
    End Function

    Function ExecuteScalar(ByVal commandText As String) As Object Implements IDBFunction.ExecuteScalar
        Dim obj As New Object
        If CheckConnection() Then
            Try
                _sqlCommand = New SqlCommand(commandText, _sqlConnect)
                _sqlCommand.CommandTimeout = midTimeOut
                _sqlCommand.Transaction = _sqlTransaction
                obj = _sqlCommand.ExecuteScalar()
                If _sqlTransaction Is Nothing Then
                    _sqlConnect.Close()
                    _sqlConnect.Dispose()
                    SqlConnection.ClearAllPools()
                    _sqlCommand.Dispose()
                End If
            Catch ex As Exception
                Throw (ex)
            End Try
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
            End If
        End If
        Return obj
    End Function

    Function ExecuteScalarSP(ByVal commandText As String, ByVal para() As DbParameter) As Object
        Dim obj As New Object
        If CheckConnection() Then
            Try
                _sqlCommand = New SqlCommand(commandText, _sqlConnect)
                _sqlCommand.CommandTimeout = verylongTimeOut
                _sqlCommand.Transaction = _sqlTransaction
                _sqlCommand.CommandType = CommandType.StoredProcedure
                _sqlCommand.Parameters.AddRange(para)
                obj = _sqlCommand.ExecuteScalar()
                _sqlCommand.Parameters.Clear()
                If _sqlTransaction Is Nothing Then
                    _sqlConnect.Close()
                    _sqlConnect.Dispose()
                    SqlConnection.ClearAllPools()
                    _sqlCommand.Dispose()
                End If
            Catch ex As Exception
                _sqlCommand.Parameters.Clear()
                Throw (ex)
            End Try
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
            End If
        End If
        Return obj
    End Function

    Function ExecuteStoreProcedure(ByVal sp_name As String) As Integer
        If CheckConnection() Then
            _sqlCommand = New SqlCommand(sp_name, _sqlConnect)
            _sqlCommand.CommandTimeout = verylongTimeOut
            _sqlCommand.CommandType = CommandType.StoredProcedure
            _sqlCommand.Transaction = _sqlTransaction
            Dim effect As Integer = _sqlCommand.ExecuteNonQuery()
            If _sqlTransaction Is Nothing Then 
                _sqlConnect.Close()
                _sqlConnect.Dispose() 
                SqlConnection.ClearAllPools()
                _sqlCommand.Dispose()
            End If
            Return effect
        Else
            Return 0
        End If
    End Function

    Function ExecuteStoreProcedure(ByVal sp_name As String, ByVal para() As DbParameter) As Integer
        Dim effect As Integer = 0
        Try
            If CheckConnection() Then
                _sqlCommand = New SqlCommand(sp_name, _sqlConnect)
                _sqlCommand.CommandTimeout = verylongTimeOut
                _sqlCommand.CommandType = CommandType.StoredProcedure
                _sqlCommand.Parameters.AddRange(para)
                _sqlCommand.Transaction = _sqlTransaction
                effect = _sqlCommand.ExecuteNonQuery()
                _sqlCommand.Parameters.Clear()
                If _sqlTransaction Is Nothing Then
                    _sqlConnect.Close()
                    _sqlConnect.Dispose()
                    SqlConnection.ClearAllPools()
                    _sqlCommand.Dispose()
                End If
            End If
        Catch ex As Exception
            _sqlCommand.Parameters.Clear()
            Throw (ex)
        End Try
        If _sqlTransaction Is Nothing Then
            _sqlConnect.Close()
        End If
        Return effect
    End Function

    Function ExecuteStoreProcedureTB(ByVal sp_name As String, ByVal para() As DbParameter) As DataTable
        Dim tb As New DataTable
        Try
            If CheckConnection() Then
                _sqlCommand = New SqlCommand(sp_name, _sqlConnect)
                _sqlCommand.CommandTimeout = verylongTimeOut
                _sqlCommand.CommandType = CommandType.StoredProcedure
                _sqlCommand.Transaction = _sqlTransaction
                _sqlCommand.Parameters.AddRange(para)
                _sqlAdapter = New SqlDataAdapter(_sqlCommand)
                _sqlAdapter.Fill(tb)
                _sqlCommand.Parameters.Clear()

                If _sqlTransaction Is Nothing Then
                    _sqlConnect.Close()
                    _sqlConnect.Dispose()
                    SqlConnection.ClearAllPools()
                    _sqlAdapter.Dispose()
                    _sqlCommand.Dispose()
                End If
            End If
        Catch ex As Exception
            _sqlCommand.Parameters.Clear()
            CloseConnect()
            Throw (ex)
        End Try
        If _sqlTransaction Is Nothing Then
            _sqlConnect.Close()
        End If
        Return tb
    End Function

    Function ExecuteStoreProcedureTB(ByVal sp_name As String, ByVal para() As DbParameter, ByVal setTimeout As Integer) As DataTable
        Dim tb As New DataTable
        Try
            If CheckConnection() Then
                _sqlCommand = New SqlCommand(sp_name, _sqlConnect)
                _sqlCommand.CommandTimeout = setTimeout
                _sqlCommand.CommandType = CommandType.StoredProcedure
                _sqlCommand.Transaction = _sqlTransaction
                _sqlCommand.Parameters.AddRange(para)
                _sqlAdapter = New SqlDataAdapter(_sqlCommand)
                _sqlAdapter.Fill(tb)
                _sqlCommand.Parameters.Clear()
                If _sqlTransaction Is Nothing Then
                    _sqlConnect.Close()
                    _sqlConnect.Dispose()
                    SqlConnection.ClearAllPools()
                    _sqlAdapter.Dispose()
                    _sqlCommand.Dispose()
                End If
            End If
        Catch ex As Exception
            _sqlCommand.Parameters.Clear()
            CloseConnect()
            Throw (ex)
        End Try
        If _sqlTransaction Is Nothing Then
            _sqlConnect.Close()
        End If
        Return tb
    End Function

    Function ExecuteStoreProcedureTB(ByVal sp_name As String) As DataTable
        Dim tb As New DataTable
        Try
            If CheckConnection() Then
                _sqlCommand = New SqlCommand(sp_name, _sqlConnect)
                _sqlCommand.CommandTimeout = verylongTimeOut
                _sqlCommand.CommandType = CommandType.StoredProcedure
                _sqlCommand.Transaction = _sqlTransaction
                tb = FillDataTable(_sqlCommand)
                If _sqlTransaction Is Nothing Then
                    _sqlConnect.Close()
                    _sqlConnect.Dispose()
                    SqlConnection.ClearAllPools()
                    _sqlCommand.Dispose()
                End If
            End If
        Catch ex As Exception
            Throw (ex)
            CloseConnect()
        End Try
        If _sqlTransaction Is Nothing Then
            _sqlConnect.Close()
        End If
        Return tb
    End Function

    Function Update(Of T)(ByVal obj As T) As Integer Implements IDBFunction.Update
        If CheckConnection() Then
            _sqlCommand = New SqlCommand(CreateCommandUpdate(Of T)(obj), _sqlConnect)
            _sqlCommand.Parameters.AddRange(CreateParameter(Of T)(obj))
            _sqlCommand.Transaction = _sqlTransaction
            _sqlCommand.CommandTimeout = midTimeOut
            Dim effect As Integer = _sqlCommand.ExecuteNonQuery()
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                _sqlConnect.Dispose()
                SqlConnection.ClearAllPools()
                _sqlCommand.Dispose()
            End If
            Return effect
        Else
            Return 0
        End If
    End Function

    Function Update(Of T)(ByVal obj As T, ByVal condition As String) As Integer
        If CheckConnection() Then
            _sqlCommand = New SqlCommand(CreateCommandUpdate(Of T)(obj, condition), _sqlConnect)
            _sqlCommand.Parameters.AddRange(CreateParameter(Of T)(obj))
            _sqlCommand.Transaction = _sqlTransaction
            _sqlCommand.CommandTimeout = midTimeOut
            Dim effect As Integer = _sqlCommand.ExecuteNonQuery()
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                _sqlConnect.Dispose()
                SqlConnection.ClearAllPools()
                _sqlCommand.Dispose()
            End If
            Return effect
        Else
            Return 0
        End If
    End Function

    Function Insert(Of T)(ByVal obj As T) As Integer Implements IDBFunction.Insert
        If CheckConnection() Then
            _sqlCommand = New SqlCommand(CreateCommandInsert(Of T)(obj), _sqlConnect)
            _sqlCommand.Parameters.AddRange(CreateParameter(Of T)(obj))
            _sqlCommand.Transaction = _sqlTransaction
            _sqlCommand.CommandTimeout = midTimeOut
            Dim effect As Integer = _sqlCommand.ExecuteNonQuery()
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                _sqlConnect.Dispose()
                SqlConnection.ClearAllPools()
                _sqlCommand.Dispose()
            End If
            Return effect
        Else
            Return 0
        End If
    End Function

    Function Delete(Of T)(ByVal obj As T) As Integer Implements IDBFunction.Delete
        If CheckConnection() Then
            _sqlCommand = New SqlCommand(CreateCommandDelete(obj), _sqlConnect)
            _sqlCommand.Parameters.AddRange(CreateParameterKey(obj))
            _sqlCommand.Transaction = _sqlTransaction
            _sqlCommand.CommandTimeout = midTimeOut
            Dim effect As Integer = _sqlCommand.ExecuteNonQuery()
            If _sqlTransaction Is Nothing Then
                _sqlConnect.Close()
                _sqlConnect.Dispose()
                SqlConnection.ClearAllPools()
                _sqlCommand.Dispose()
            End If
            Return effect
        Else
            Return 0
        End If
    End Function

    Sub GetObject(Of T)(ByRef obj As T) Implements IDBFunction.GetObject
        Dim type As Type
        Dim tb As DataTable = New DataTable
        If CheckConnection() Then
            type = obj.GetType()
            Try
                Dim fields() As FieldInfo = type.GetFields()
                _sqlCommand = New SqlCommand(CreateCommandSelect(obj), _sqlConnect)
                _sqlCommand.CommandTimeout = longTimeOut
                _sqlCommand.Parameters.AddRange(CreateParameterKey(obj))
                _sqlCommand.Transaction = _sqlTransaction
                _sqlReader = _sqlCommand.ExecuteReader()

                If _sqlReader IsNot Nothing Then
                    If _sqlReader.Read() Then
                        For Each f As FieldInfo In fields
                            If Not IsDBNull(_sqlReader.Item(f.Name.Replace(PublicConst.Key, ""))) Then f.SetValue(obj, _sqlReader.Item(f.Name.Replace(PublicConst.Key, "")))
                        Next
                    Else
                        For Each f As FieldInfo In fields
                            f.SetValue(obj, Nothing)
                        Next
                    End If
                    _sqlCommand.Dispose()
                    _sqlReader.Close()
                End If
                If _sqlTransaction Is Nothing Then
                    _sqlConnect.Close()
                    SqlConnection.ClearAllPools()
                End If
            Catch ex As Exception
                If _sqlReader IsNot Nothing Then
                    _sqlReader.Close()
                End If
                CloseConnect()
                Throw ex
            End Try
        End If
    End Sub

    Sub GetObjectNotReset(Of T)(ByRef obj As T)
        Dim type As Type
        Dim tb As DataTable = New DataTable
        If CheckConnection() Then
            type = obj.GetType()
            Try
                Dim fields() As FieldInfo = type.GetFields()
                _sqlCommand = New SqlCommand(CreateCommandSelect(obj), _sqlConnect)
                _sqlCommand.CommandTimeout = longTimeOut
                _sqlCommand.Parameters.AddRange(CreateParameterKey(obj))
                _sqlCommand.Transaction = _sqlTransaction
                _sqlReader = _sqlCommand.ExecuteReader()
                If _sqlReader IsNot Nothing Then
                    If _sqlReader.Read() Then
                        For Each f As FieldInfo In fields
                            If Not IsDBNull(_sqlReader.Item(f.Name.Replace(PublicConst.Key, ""))) Then f.SetValue(obj, _sqlReader.Item(f.Name.Replace(PublicConst.Key, "")))
                        Next
                    End If
                End If
                _sqlCommand.Dispose()
                _sqlReader.Close()
                If _sqlTransaction Is Nothing Then
                    _sqlConnect.Close()
                    SqlConnection.ClearAllPools()
                End If

            Catch ex As Exception
                _sqlReader.Close()
                CloseConnect()
                Throw ex
            End Try
        End If
    End Sub

    Function GetObject(Of T)(ByVal selectCommand As String) As T Implements IDBFunction.GetObject
        Dim type As Type
        Dim obj As T
        Dim tb As DataTable
        If CheckConnection() Then
            obj = Activator.CreateInstance(Of T)()
            type = obj.GetType()
            Dim fields() As FieldInfo = type.GetFields()
            tb = FillDataTable(selectCommand)
            If Not IsDBNull(tb) And tb.Rows.Count > 0 Then
                For Each f As FieldInfo In fields
                    If Not IsDBNull(tb.Rows(0)(f.Name.Replace(PublicConst.Key, ""))) Then f.SetValue(obj, tb.Rows(0)(f.Name.Replace(PublicConst.Key, "")))
                Next
            End If
        End If
        Return obj
    End Function
    Function GetObject(Of T)(ByVal selectCommand As String, ByVal para() As DbParameter) As T
        Dim type As Type
        Dim obj As T
        Dim tb As DataTable
        If CheckConnection() Then
            obj = Activator.CreateInstance(Of T)()
            type = obj.GetType()
            Dim fields() As FieldInfo = type.GetFields()
            tb = FillDataTable(selectCommand, para)
            If Not IsDBNull(tb) And tb.Rows.Count > 0 Then
                For Each f As FieldInfo In fields
                    If Not IsDBNull(tb.Rows(0)(f.Name.Replace(PublicConst.Key, ""))) Then f.SetValue(obj, tb.Rows(0)(f.Name.Replace(PublicConst.Key, "")))
                Next
            End If
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
        Dim objs As New List(Of T)
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
        Dim objs As New List(Of T)
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
        Dim objs As New List(Of T)
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
    Function GetAllColumn(ByVal tableName As String) As DataTable
        Dim sql As String =String.Format(" SELECT  table_name=sysobjects.name, " &
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

    Function GetKeysOfTable(ByVal tableName As String) As DataTable
        Dim sql As String = ""
        sql = String.Format("")
        _sqlCommand = New SqlCommand("sp_pkeys")
        _sqlCommand.CommandType = CommandType.StoredProcedure
        _sqlCommand.Parameters.Add("@table_name", SqlDbType.NVarChar).Value = tableName

        Return FillDataTable(_sqlCommand)
    End Function

    Function GetMaxValue(Of T)(ByVal field As String) As Object Implements IDBFunction.GetMaxValue
        Dim tableName As String = ""
        tableName = Activator.CreateInstance(Of T)().GetType().Name
        Return ExecuteScalar(String.Format("select max({0}) from {1} ", field, tableName))
    End Function

    Function ExistTable(ByVal tableName As String) As Boolean Implements IDBFunction.ExistTable
        Dim tb As DataTable
        tb = FillDataTable("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE Table_Name='" & tableName & "'")
        If tb.Rows.Count > 0 Then Return True
        Return False
    End Function

    Function ExistObject(Of T)(ByVal obj As T) As Boolean Implements IDBFunction.ExistObject
        If CheckConnection() Then
            Dim tb As DataTable
            _sqlCommand = New SqlCommand(CreateCommandSelect(obj), _sqlConnect)
            _sqlCommand.Parameters.AddRange(CreateParameterKey(obj))
            _sqlCommand.Transaction = _sqlTransaction
            _sqlCommand.CommandTimeout = midTimeOut
            tb = FillDataTable(_sqlCommand)
            If Not IsDBNull(tb) And tb.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Function CreateParameter(Of T)(ByVal obj As T) As DbParameter() Implements IDBFunction.CreateParameter
        Dim type As Type
        type = obj.GetType()
        Dim fields() As FieldInfo = type.GetFields()
        Dim paras(fields.Length - 1) As SqlParameter
        For index As Integer = 0 To fields.Length - 1
            If fields(index).GetValue(obj) IsNot Nothing Then
                If fields(index).FieldType.Name = "DateTime" Then
                    If CType(fields(index).GetValue(obj), DateTime) <= DateTime.MinValue Then
                        paras(index) = New SqlParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), DBNull.Value)
                        paras(index).IsNullable = True
                    Else
                        paras(index) = New SqlParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), fields(index).GetValue(obj))
                        paras(index).IsNullable = True
                    End If
                Else
                    paras(index) = New SqlParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), fields(index).GetValue(obj))
                    paras(index).IsNullable = True
                End If
            Else
                paras(index) = New SqlParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), DBNull.Value)
                paras(index).IsNullable = True
                If fields(index).FieldType.Name = "Byte[]" Then
                    paras(index).SqlDbType = SqlDbType.Image
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
        Dim paras(countKey - 1) As SqlParameter
        For index As Integer = 0 To fields.Length - 1
            If fields(index).Name.Contains(PublicConst.Key) Then
                If fields(index).GetValue(obj) IsNot Nothing Then
                    If fields(index).FieldType.Name = "DateTime" Then
                        If CType(fields(index).GetValue(obj), DateTime) <= DateTime.MinValue Then
                            paras(indexKey) = New SqlParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), DBNull.Value)
                            paras(indexKey).IsNullable = True
                        Else
                            paras(indexKey) = New SqlParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), fields(index).GetValue(obj))
                            paras(indexKey).IsNullable = True
                        End If
                    Else
                        paras(indexKey) = New SqlParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), fields(index).GetValue(obj))
                        paras(indexKey).IsNullable = True
                    End If
                Else
                    paras(indexKey) = New SqlParameter("@" + fields(index).Name.Replace(PublicConst.Key, ""), DBNull.Value)
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
    Public Function CheckConnection() As Boolean Implements IDBFunction.CheckConnection
        Try
ReConnect:
            If _sqlConnect IsNot Nothing And _sqlConnect.ConnectionString <> "" Then
                If _sqlTransaction Is Nothing Then
                    If _sqlConnect.State <> ConnectionState.Open Then
                        _sqlConnect.Open()
                    End If
                    _sqlCommand = New SqlCommand
                    _sqlCommand.Connection = _sqlConnect
                    _sqlCommand.CommandText = "select 1"
                    _sqlCommand.CommandTimeout = 10
                    _sqlCommand.ExecuteNonQuery()
                End If
            Else
                If _server <> Nothing Then
                    _sqlConnect = New SqlConnection(GetConnectString(_server))
                Else
                    _sqlConnect = New SqlConnection(_myConnectString)
                End If
                _sqlConnect.Open()
                _sqlCommand = New SqlCommand
                _sqlCommand.Connection = _sqlConnect
                _sqlCommand.CommandText = "select 1"
                _sqlCommand.ExecuteNonQuery()
            End If
            _sqlCommand.Dispose()
            SqlConnection.ClearAllPools()
            Return True
        Catch ex As Exception
            Throw (ex)
            Return False
        End Try
    End Function
    Public Function OpenConnect() As Boolean Implements IDBFunction.OpenConnect
        Try
ReConnect:
            If _sqlConnect IsNot Nothing And _sqlConnect.ConnectionString <> "" Then
                If _sqlTransaction Is Nothing Then
                    If _sqlConnect.State <> ConnectionState.Open Then
                        _sqlConnect.Open()
                    End If 
                End If
            Else
                _sqlConnect = New SqlConnection(GetConnectString(_server))
                _sqlConnect.Open()
            End If
            PublicConst.VisibleAutoConnect = False
            Return True
        Catch ex As Exception
            '2 phut auto ket noi lai
            'If PublicConst.VisibleAutoConnect = False Then
            '    PublicConst.VisibleAutoConnect = True
            '    Dim frm As New FrmAutoConnect
            '    frm._ErrorMessage = ex.Message
            '    frm.ShowDialog()
            '    PublicConst.VisibleAutoConnect = False
            '    If frm._IsContinue Then
            '        GoTo ReConnect
            '    End If
            'End If
            Return False
        End Try
    End Function
    Public Function CloseConnect() As Boolean Implements IDBFunction.CloseConnect
        Try
            If _sqlConnect IsNot Nothing Then
                If _sqlConnect.State <> ConnectionState.Closed Then
                    _sqlConnect.Close()
                    _sqlConnect.Dispose()
                    SqlConnection.ClearAllPools()
                End If
            Else
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Transaction"

    Sub BeginTransaction() Implements IDBFunction.BeginTransaction
        If CheckConnection() Then
            _sqlTransaction = _sqlConnect.BeginTransaction()
        End If
    End Sub
    Sub Commit() Implements IDBFunction.Commit
        If _sqlTransaction IsNot Nothing Then
            _sqlTransaction.Commit()
        End If

        _sqlTransaction = Nothing
        _sqlConnect.Close()
        _sqlConnect.Dispose()
        SqlConnection.ClearAllPools()
    End Sub
    Sub RollBack() Implements IDBFunction.RollBack
        If _sqlTransaction IsNot Nothing Then
            _sqlTransaction.Rollback()
        End If

        _sqlTransaction = Nothing
        _sqlConnect.Close()
        _sqlConnect.Dispose()
        SqlConnection.ClearAllPools()
    End Sub

#End Region

End Class
