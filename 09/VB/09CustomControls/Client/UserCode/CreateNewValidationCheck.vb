
Namespace LightSwitchApplication

    Public Class CreateNewValidationCheck

        Private Sub CreateNewValidationCheck_InitializeDataWorkspace(ByVal saveChangesTo As Global.System.Collections.Generic.List(Of Global.Microsoft.LightSwitch.IDataService))
            ' Write your code here.
            Me.ValidationCheckProperty = New ValidationCheck()
        End Sub

        Private Sub CreateNewValidationCheck_Saved()
            ' Write your code here.
            Me.Close(False)
            Application.Current.ShowDefaultScreen(Me.ValidationCheckProperty)
        End Sub

    End Class

End Namespace