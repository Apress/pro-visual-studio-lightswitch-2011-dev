
Namespace LightSwitchApplication

    Public Class Product

        Private Sub ProductCode_Validate(results As EntityValidationResultsBuilder)
            ' results.AddPropertyError("<Error-Message>")

        End Sub


        Private Sub ProductName_Validate(results As EntityValidationResultsBuilder)

            If Len(Me.ProductName) > 0 Then
                Dim duplicateOnServer = (
                    From prod In Me.DataWorkspace.ShipperCentralData.Products.Cast(Of Product)()
                    Where
                    prod.ProductID <> Me.ProductID AndAlso
                    prod.ProductName.Equals(Me.ProductName, StringComparison.CurrentCultureIgnoreCase)
                    ).ToArray()

                Dim duplicateOnClients = (
                    From prod In Me.DataWorkspace.ShipperCentralData.Details.GetChanges().OfType(Of Product)()
                    Where
                    prod IsNot Me AndAlso
                    prod.ProductName.Equals(Me.ProductName, StringComparison.CurrentCultureIgnoreCase)
                    ).ToArray()

                Dim deleltedOnClient = Me.DataWorkspace.ShipperCentralData.Details.GetChanges().DeletedEntities.OfType(Of Product)().ToArray()

                Dim anyDuplicates = duplicateOnServer.Union(duplicateOnClients).Distinct().Except(deleltedOnClient).Any()

                If anyDuplicates Then
                    results.AddPropertyError("The product name already exists")
                End If

            End If

        End Sub



    End Class

End Namespace
























































