
Namespace LightSwitchApplication

    Public Class CreateControlAvailable

        Private Sub CreateControlAvailable_InitializeDataWorkspace(ByVal saveChangesTo As Global.System.Collections.Generic.List(Of Global.Microsoft.LightSwitch.IDataService))
            ' Write your code here.
            Me.ProductFeedbackProperty = New ProductFeedback()
        End Sub

        Private Sub CreateControlAvailable_Saved()
            ' Write your code here.
            Me.Close(False)
            Application.Current.ShowDefaultScreen(Me.ProductFeedbackProperty)
        End Sub

        Private Sub CreateControlAvailable_Activated()
            ' Write your code here.

            AddHandler Me.FindControl("Satisfaction").ControlAvailable,
                Sub(sender As Object, e As ControlAvailableEventArgs)
                    ShowMessageBox("got here")
                End Sub

        End Sub



        Private Sub CreateControlAvailable_Created()
            ' Write your code here.

        End Sub
    End Class

End Namespace