Imports Microsoft.LightSwitch.Presentation

Partial Public Class CustomButton
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub CustomButton_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
        ' Get a reference to the LightSwitch Screen
        Dim objDataContext = DirectCast(Me.DataContext, IContentItem)
        Dim clientScreen = DirectCast(objDataContext.Screen, Microsoft.LightSwitch.Client.IScreenObject)

        clientScreen.Details.Dispatcher.BeginInvoke(
            Sub()
                Try
                    SetEnabled(False)
                    ' Call the Method on the LightSwitch screen
                    clientScreen.Details.Commands.Item("SaveData").Execute()
                Finally
                    SetEnabled(True)
                End Try
            End Sub)

    End Sub


    Private Sub SetEnabled(value As Boolean)
        Me.Dispatcher.BeginInvoke(
            Sub()
                Me.CustomButton.IsEnabled = value
            End Sub
        )
    End Sub


    'c:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\LightSwitch\1.0\Client\Microsoft.LightSwitch.Client.dll

End Class
