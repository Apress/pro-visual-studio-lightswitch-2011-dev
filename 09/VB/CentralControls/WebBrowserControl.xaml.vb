Imports System.Windows
Imports System.Windows.Controls

Partial Public Class WebBrowserControl
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Property uri() As Uri
        Get
            Return DirectCast(GetValue(URIProperty), Uri)
        End Get
        Set(value As Uri)
            SetValue(URIProperty, value)
        End Set
    End Property

    Public Shared ReadOnly URIProperty As DependencyProperty =
        DependencyProperty.Register(
            "uri",
            GetType(Uri),
            GetType(WebBrowserControl),
            New PropertyMetadata(Nothing, AddressOf OnUriPropertyChanged))

    Private Shared Sub OnUriPropertyChanged(
        re As DependencyObject, e As DependencyPropertyChangedEventArgs)

        If e.NewValue IsNot Nothing Then
            Dim wb As WebBrowserControl = DirectCast(re, WebBrowserControl)
            wb.wb1.Navigate(DirectCast(e.NewValue, Uri))
        End If
    End Sub


End Class
