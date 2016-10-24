
Namespace LightSwitchApplication

    Public Class PasswordBoxControl901

        Private Sub PasswordBoxControl901_InitializeDataWorkspace(ByVal saveChangesTo As Global.System.Collections.Generic.List(Of Global.Microsoft.LightSwitch.IDataService))
            ' Write your code here.
            Me.UserProperty = New User()
        End Sub

        Private Sub PasswordBoxControl901_Saved()
            ' Write your code here.
            Me.Close(False)
            Application.Current.ShowDefaultScreen(Me.UserProperty)
        End Sub

        Private Sub PasswordBoxControl901_Activated()
            ' Write your code here.
            Dim password As IContentItemProxy = Me.FindControl("Password")
            password.SetBinding(System.Windows.Controls.PasswordBox.PasswordProperty, "Value",
                Windows.Data.BindingMode.TwoWay)

        End Sub
    End Class

End Namespace