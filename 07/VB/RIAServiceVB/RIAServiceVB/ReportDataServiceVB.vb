
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
Imports System.Data.EntityClient
Imports System.Web.Configuration

Imports Central.Data.Services.ApplicationData.Implementation


'TODO: Create methods containing your application logic.
<EnableClientAccess()>  _
Public Class ReportDataServiceVB
    Inherits DomainService

    'the name of this project
    Const METADATA_NAME As String = "ApplicationData"

    'used to build the metatdata
    Const METADATA_FORMAT As String =
       "res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl"

    'LightSwitch uses a special name for its intrinsic database connection
    'instead of ApplicationData as you would normally expect
    Const CONNECTION_NAME As String = "_IntrinsicData"

    'the data provider name
    Const PROVIDER_NAME As String = "System.Data.SqlClient"

    Private _context As ApplicationDataObjectContext
    Public ReadOnly Property Context As ApplicationDataObjectContext
        Get
            If (_context Is Nothing) _
            Then
                Dim builder = New EntityConnectionStringBuilder

                builder.Metadata =
                   String.Format(METADATA_FORMAT, METADATA_NAME)
                builder.Provider = PROVIDER_NAME
                builder.ProviderConnectionString = WebConfigurationManager.ConnectionStrings(CONNECTION_NAME).ConnectionString()

                _context = New ApplicationDataObjectContext(builder.ConnectionString)
            End If

            Return _context
        End Get
    End Property

    <Query(IsDefault:=True)>
    Public Function GenderCount() As IQueryable(Of ReportDataClass)
        Dim result As IQueryable(Of ReportDataClass)

        result = From p In Me.Context.People
                 Group By Gender = p.Gender
                 Into g = Group
                         Select New ReportDataClass With
                   {
                        .Id = Gender.Id,
                        .Name = Gender.GenderName,
                        .Total = g.Count
                    }

        Return result
    End Function


End Class




Public Class ReportDataClass
    <Key()>
    Public Property Id As Integer

    Public Property Name As String
    Public Property Total As Decimal

    ' if you need to cast any values from one type to another, 
    ' you'll need to do it here
    ' because casts aren't allowed in LINQ to Entity queries
    Friend WriteOnly Property TotalSingle As Single
        Set(value As Single)
            Me.Total = New Decimal(value)
        End Set
    End Property

End Class
