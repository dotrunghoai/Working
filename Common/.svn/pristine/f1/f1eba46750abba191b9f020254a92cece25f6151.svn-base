Imports System.Data.Common
Imports System.Data.SqlClient
Imports PublicUtility.PublicConst
''' <summary>
''' Author: Truong Minh Tam (IT-Nitto Denko)
''' Date: 25-Aug-2011
''' </summary>
''' <remarks></remarks>
Public Interface IDBFunction

#Region "Delegates and events "

#End Region

#Region "Property"
    ReadOnly Property Server As String
    ReadOnly Property Database As String
    ReadOnly Property ConnectString As String
    ReadOnly Property WorkStationID As String
    ReadOnly Property ConnectionTimeout As Integer
    ReadOnly Property State As ConnectionState
#End Region

#Region "Functions"

    Sub BulkCopy(ByVal table As DataTable, ByVal destinationTable As String)
    Sub BulkCopy(ByVal table As DataTable, ByVal destinationTable As String, ByVal mapping() As SqlBulkCopyColumnMapping)
    Sub BulkCopy(ByVal reader As IDataReader, ByVal destinationTable As String)
    Sub BulkCopy(ByVal reader As IDataReader, ByVal destinationTable As String, ByVal mapping() As SqlBulkCopyColumnMapping)
    Sub BulkCopy(ByVal dataRows As DataRow, ByVal destinationTable As String)
    Sub BulkCopy(ByVal dataRows As DataRow, ByVal destinationTable As String, ByVal mapping() As SqlBulkCopyColumnMapping)
    Sub HandleBulkCopy(ByVal sender As Object, ByVal e As SqlRowsCopiedEventArgs)

    Function FillDataTable(ByVal commandText As String) As DataTable
    Function FillDataTable(ByVal commandText As String, ByVal para() As DbParameter) As DataTable
    Function FillDataTable(ByVal sqlcommand As DbCommand) As DataTable
    Function FillDataTable(ByVal sqlcommand As DbCommand, ByVal para() As DbParameter) As DataTable

    Function FillDataSet(ByVal commandText As String, ByVal para() As DbParameter) As DataSet
    Function FillDataSet(ByVal commandText As String) As DataSet
    Function FillDataSet(ByVal commandText As String, ByVal para() As DbParameter, ByRef ds As DataSet, ByVal tableName As String) As DataSet
    Function FillDataSet(ByVal commandText As String, ByRef ds As DataSet, ByVal tableName As String) As DataSet

    Function ExecuteNonQuery(ByVal commandText As String) As Integer
    Function ExecuteNonQuery(ByVal commandText As String, ByVal para() As DbParameter) As Integer
    Function ExecuteReader(ByVal commandText As String) As DbDataReader
    Function ExecuteReader(ByVal commandText As String, ByVal para() As DbParameter) As DbDataReader
    Function ExecuteScalar(ByVal commandText As String) As Object
    Function ExecuteScalar(ByVal commandText As String, ByVal para() As DbParameter) As Object

    Function Update(Of T)(ByVal obj As T) As Integer
    Function Insert(Of T)(ByVal obj As T) As Integer
    Function Delete(Of T)(ByVal obj As T) As Integer

    Sub GetObject(Of T)(ByRef obj As T)
    Function GetObject(Of T)(ByVal selectCommand As String) As T
    Function GetObjects(Of T)(ByVal selectCommad As String) As T()
    Function GetObjects(Of T)(ByVal selectCommad As String, ByVal para() As DbParameter) As T()
    Function GetAll(Of T)() As T()
    Function GetAllTable(Of T)() As DataTable
    Function GetAllList(Of T)() As List(Of T)
    Function GetList(Of T)(ByVal selectCommand As String) As List(Of T)
    Function GetList(Of T)(ByVal selectCommand As String, ByVal para() As DbParameter) As List(Of T)
    Function GetMaxValue(Of T)(ByVal field As String) As Object

    Function ExistTable(ByVal tableName As String) As Boolean
    Function ExistObject(Of T)(ByVal obj As T) As Boolean

    Function CreateParameter(Of T)(ByVal obj As T) As DbParameter()
    Function CreateParameterKey(Of T)(ByVal obj As T) As DbParameter()

    Function CreateCommandInsert(Of T)(ByVal obj As T) As String
    Function CreateCommandUpdate(Of T)(ByVal obj As T) As String
    Function CreateCommandSelect(Of T)(ByVal obj As T) As String
    Function CreateCommandDelete(Of T)(ByVal obj As T) As String

    Function GetConnectString(ByVal server As EnumServers) As String
    Function CheckConnection() As Boolean
    Function OpenConnect() As Boolean
    Function CloseConnect() As Boolean

#End Region

#Region "Transaction"

    Sub BeginTransaction()
    Sub Commit()
    Sub RollBack()

#End Region

End Interface
