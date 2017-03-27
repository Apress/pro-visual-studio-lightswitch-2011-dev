
Namespace LightSwitchApplication

    Public Class HyperlinkControl901Pt2

        Private Sub HyperlinkControl901Pt2_Activated()
            ' Write your code here.

            Dim hyperlinkCtrl = Me.FindControl("URL")

            hyperlinkCtrl.SetBinding(System.Windows.Controls.HyperlinkButton.NavigateUriProperty, "StringValue")
            hyperlinkCtrl.SetBinding(System.Windows.Controls.HyperlinkButton.ContentProperty, "Name")


        End Sub

    End Class

End Namespace
