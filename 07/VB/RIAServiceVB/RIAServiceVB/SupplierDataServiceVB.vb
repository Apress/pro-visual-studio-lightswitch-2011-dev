
Option Compare Binary
Option Infer On
Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.ServiceModel.DomainServices.Hosting
Imports System.ServiceModel.DomainServices.Server

Imports System.Configuration
Imports System.Data.SqlClient

Public Class SupplierDataServiceVB
    Inherits DomainService

    Private ReadOnly _supplierRecordList As List(Of SupplierRecord)
    Public Sub New()
        _supplierRecordList = New List(Of SupplierRecord)()
    End Sub
    Private _connectionString As String
    Public Overrides Sub Initialize(context As System.ServiceModel.DomainServices.Server.DomainServiceContext)

        _connectionString = ConfigurationManager.ConnectionStrings(Me.[GetType]().FullName).ConnectionString

        MyBase.Initialize(context)
    End Sub

    <Query(IsDefault:=True)>
    Public Function GetSampleCustomerData() As IQueryable(Of SupplierRecord)
        _supplierRecordList.Clear()
        Dim cnn As New SqlConnection(_connectionString)
        Dim cmd As New SqlCommand("SELECT SupplierID, CompanyName,ContactFirstname, ContactSurname FROM Supplier", cnn)

        Try
            cnn.Open()
            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    Dim supplier As New SupplierRecord()
                    supplier.SupplierID = CInt(dr("SupplierID"))
                    supplier.SupplierName = dr("CompanyName").ToString()
                    supplier.FirstName = dr("ContactFirstname").ToString()
                    supplier.LastName = dr("ContactSurname").ToString()
                    _supplierRecordList.Add(supplier)
                End While
            End Using
        Finally
            cnn.Close()
        End Try

        Return _supplierRecordList.AsQueryable()
    End Function


    Public Sub UpdateSupplierData(Supplier As SupplierRecord)
        Dim cnn As New SqlConnection(_connectionString)
        Dim cmd As New SqlCommand("UPDATE Supplier SET  CompanyName = @CompanyName ,ContactFirstname=@ContactFirstname, ContactSurname=@ContactSurname WHERE SupplierID = @SupplierID", cnn)
        cmd.Parameters.AddWithValue("CompanyName", Supplier.SupplierName)
        cmd.Parameters.AddWithValue("ContactFirstName", Supplier.FirstName)
        cmd.Parameters.AddWithValue("ContactSurname", Supplier.LastName)
        cmd.Parameters.AddWithValue("SupplierID", Supplier.SupplierID)

        Try
            cnn.Open()
            cmd.ExecuteNonQuery()
        Finally
            cnn.Close()
        End Try

    End Sub

    Public Sub InsertSupplierData(Supplier As SupplierRecord)

        Dim cnn As New SqlConnection(_connectionString)
        Dim cmd As New SqlCommand("INSERT INTO Supplier (CompanyName,ContactFirstname, ContactSurname) VALUES ( @CompanyName ,@ContactFirstname, @ContactSurname); SELECT @@Identity ", cnn)
        cmd.Parameters.AddWithValue("CompanyName", Supplier.SupplierName)
        cmd.Parameters.AddWithValue("ContactFirstName", Supplier.FirstName)
        cmd.Parameters.AddWithValue("ContactSurname", Supplier.LastName)

        Try
            cnn.Open()
            Supplier.SupplierID = CInt(cmd.ExecuteScalar())
        Finally
            cnn.Close()
        End Try

    End Sub

    Public Sub DeleteCustomerData(Supplier As SupplierRecord)

        Dim cnn As New SqlConnection(_connectionString)
        Dim cmd As New SqlCommand("DeleteSupplier", cnn)
        cmd.Parameters.AddWithValue("@SupplierID", Supplier.SupplierID)
        cmd.CommandType = System.Data.CommandType.StoredProcedure
        Try
            cnn.Open()
            cmd.ExecuteNonQuery()
        Finally
            cnn.Close()
        End Try

    End Sub

End Class

Public Class SupplierRecord
    <Key(), Editable(False)>
    Public Property SupplierID As Integer
    <Required(ErrorMessage:="Supplier Name must be entered"), StringLength(60)>
    Public Property SupplierName As String
    <StringLength(25)>
    Public Property FirstName As String
    <StringLength(25)>
    Public Property LastName As String
End Class

