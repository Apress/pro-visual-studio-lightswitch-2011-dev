
Namespace LightSwitchApplication

    Public Class CustomerPaymentDetail

        Private Sub CustomerPaymentProperty_Loaded(succeeded As Boolean)
            ' Write your code here.
            Me.SetDisplayNameFromEntity(Me.CustomerPaymentProperty)
        End Sub

        Private Sub CustomerPaymentProperty_Changed()
            ' Write your code here.
            Me.SetDisplayNameFromEntity(Me.CustomerPaymentProperty)
        End Sub

        Private Sub CustomerPaymentDetail_Saved()
            ' Write your code here.
            Me.SetDisplayNameFromEntity(Me.CustomerPaymentProperty)
        End Sub

        Private Sub CustomerPaymentDetail_Activated()
            ' Write your code here.
            'Me.Details.Properties.CustomerPaymentProperty.IsReadOnly

            'Dim i As IContentItem
            'i.ParentItem.
            'Dim i2 As IContentVisual
            'i2.Control.

            'Dim a = FindControl("")
            'CustomerPaymentProperty.CreditCardNumber.det()

            'CustomerPaymentProperty.Details



        End Sub
    End Class

End Namespace