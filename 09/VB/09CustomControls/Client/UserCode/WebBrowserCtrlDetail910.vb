
Namespace LightSwitchApplication

    Public Class WebBrowserCtrlDetail910

        Private Sub Hyperlink_Loaded(succeeded As Boolean)
            ' Write your code here.
            Me.SetDisplayNameFromEntity(Me.Hyperlink)
        End Sub

        Private Sub Hyperlink_Changed()
            ' Write your code here.
            Me.SetDisplayNameFromEntity(Me.Hyperlink)
        End Sub

        Private Sub WebBrowserCtrlDetail910_Saved()
            ' Write your code here.
            Me.SetDisplayNameFromEntity(Me.Hyperlink)
        End Sub

        Private Sub WebBrowserCtrlDetail910_Activated()
            ' Write your code here.

            Property1 = "Type in a URL and the control will update iteself automatically"
            Dim ctr As IContentItemProxy = Me.FindControl("URL1")
            ctr.SetBinding(CentralControls.WebBrowserControl.URIProperty, "Value", Windows.Data.BindingMode.OneWay)

        End Sub
    End Class

End Namespace