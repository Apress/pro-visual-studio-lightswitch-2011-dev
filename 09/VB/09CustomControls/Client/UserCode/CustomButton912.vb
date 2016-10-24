
Namespace LightSwitchApplication

    Public Class CustomButton912

        Private Sub CustomButton912_InitializeDataWorkspace(ByVal saveChangesTo As Global.System.Collections.Generic.List(Of Global.Microsoft.LightSwitch.IDataService))
            ' Write your code here.
            Me.CustomerProperty = New Customer()
        End Sub

        Private Sub CustomButton912_Saved()
            ' Write your code here.
            'Me.Close(False)
            Application.Current.ShowDefaultScreen(Me.CustomerProperty)
        End Sub

        Private Sub SaveData_Execute()
            ' Write your code here.
            Me.Save()
            ' You can call some some other logic here...
            ShowMessageBox("Data Saved")

        End Sub
    End Class

End Namespace