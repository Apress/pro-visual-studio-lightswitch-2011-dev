
Namespace LightSwitchApplication

    Public Class ComboBoxControl902

        Private Sub ComboBoxControl902_InitializeDataWorkspace(ByVal saveChangesTo As Global.System.Collections.Generic.List(Of Global.Microsoft.LightSwitch.IDataService))
            ' Write your code here.
            Me.OrderProperty = New Order()
        End Sub

        Private Sub ComboBoxControl902_Saved()
            ' Write your code here.
            Me.Close(False)
            Application.Current.ShowDefaultScreen(Me.OrderProperty)
        End Sub

        Private Sub ComboBoxControl902_Activated()
            ' Write your code here.
            Dim comboControl As IContentItemProxy = Me.FindControl("Customer")
            comboControl.SetBinding(
            System.Windows.Controls.ComboBox.ItemsSourceProperty,
            "Screen.Customers",
            Windows.Data.BindingMode.TwoWay)

            comboControl.SetBinding(
            System.Windows.Controls.ComboBox.SelectedItemProperty,
            "Screen.OrderProperty.Customer",
            Windows.Data.BindingMode.TwoWay)

        End Sub
    End Class

End Namespace