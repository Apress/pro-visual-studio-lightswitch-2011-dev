
Namespace LightSwitchApplication

    Public Class RichTextControl908

        Private Sub RichTextControl908_InitializeDataWorkspace(ByVal saveChangesTo As Global.System.Collections.Generic.List(Of Global.Microsoft.LightSwitch.IDataService))
            ' Write your code here.
            Me.ProductProperty = New Product()
        End Sub

        Private Sub RichTextControl908_Saved()
            ' Write your code here.
            Me.Close(False)
            Application.Current.ShowDefaultScreen(Me.ProductProperty)
        End Sub

        Private Sub RichTextControl908_Activated()
            ' Write your code here.

            Dim rt As IContentItemProxy = Me.FindControl("RichTextDescription")
            rt.SetBinding(CentralControls.RichTextEditorInternal.TextProperty, "Value", Windows.Data.BindingMode.TwoWay)

        End Sub
    End Class

End Namespace