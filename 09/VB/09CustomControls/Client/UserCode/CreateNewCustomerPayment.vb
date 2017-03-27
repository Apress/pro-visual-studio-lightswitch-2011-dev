
Namespace LightSwitchApplication

    Public Class CreateNewCustomerPayment

        Private Sub CreateNewCustomerPayment_InitializeDataWorkspace(ByVal saveChangesTo As Global.System.Collections.Generic.List(Of Global.Microsoft.LightSwitch.IDataService))
            ' Write your code here.
            Me.CustomerPaymentProperty = New CustomerPayment()
        End Sub

        Private Sub CreateNewCustomerPayment_Saved()
            ' Write your code here.
            Me.Close(False)
            Application.Current.ShowDefaultScreen(Me.CustomerPaymentProperty)
        End Sub

    End Class

End Namespace