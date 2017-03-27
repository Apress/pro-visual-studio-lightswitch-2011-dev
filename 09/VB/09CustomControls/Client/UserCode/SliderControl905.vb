
Namespace LightSwitchApplication

    Public Class SliderControl905

        Private Sub SliderControl905_InitializeDataWorkspace(saveChangesTo As System.Collections.Generic.List(Of Microsoft.LightSwitch.IDataService))
            ' Write your code here.
            Me.ProductFeedbackProperty = New ProductFeedback()
        End Sub

        Private Sub SliderControl905_Saved()
            ' Write your code here.
            Me.Close(False)
            Application.Current.ShowDefaultScreen(Me.ProductFeedbackProperty)
        End Sub

    End Class

End Namespace