Imports System.ComponentModel.DataAnnotations
Public Class ReportClass2
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
