Partial Public Class RichTextEditorInternal
    Inherits UserControl
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Property Text As String
        Get
            Return MyBase.GetValue(RichTextEditorInternal.TextProperty)
        End Get
        Set(value As String)
            MyBase.SetValue(RichTextEditorInternal.TextProperty, value)
        End Set
    End Property

    Public Shared ReadOnly TextProperty As DependencyProperty =
        DependencyProperty.Register("Text", GetType(String), GetType(RichTextEditorInternal),
                                    New PropertyMetadata(Nothing, AddressOf OnTextPropertyChanged))

    Public Shared Sub OnTextPropertyChanged(
                                        re As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim richEdit As RichTextEditorInternal = DirectCast(re, RichTextEditorInternal)

        If richEdit.richTextBox.Xaml <> DirectCast(e.NewValue, String) Then
            Try
                richEdit.richTextBox.Blocks.Clear()

                If String.IsNullOrEmpty(DirectCast(e.NewValue, String)) = False Then
                    richEdit.richTextBox.Xaml = DirectCast(e.NewValue, String)
                End If
            Catch
                richEdit.richTextBox.Blocks.Clear()

                If String.IsNullOrEmpty(DirectCast(e.NewValue, String)) = False Then
                    richEdit.richTextBox.Selection.Text = DirectCast(e.NewValue, String)
                End If
            End Try
        End If
    End Sub

    Private Sub richTextBox_ContentChanged(
                                          sender As Object, e As System.Windows.Controls.ContentChangedEventArgs
                                          ) Handles richTextBox.ContentChanged
        Text = richTextBox.Xaml
    End Sub

End Class
