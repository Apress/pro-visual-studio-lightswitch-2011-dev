Imports System.ComponentModel
Imports System.Windows.Data

Imports System.Windows.Controls

Imports Microsoft.LightSwitch.Presentation

Namespace LightSwitchApplication

    Public Class EditableProductsGrid


        Private Sub EditableProductsGrid_Activated()
            Dim product As IContentItemProxy = Me.FindControl("ProductName")
            targetProperty = "_blank"
            Dim converter As New ProductID2UriConverter()
            product.SetBinding(HyperlinkButton.ContentProperty, "Value", BindingMode.OneWay)
            product.SetBinding(HyperlinkButton.NavigateUriProperty, "Details.Entity.ProductID", converter, BindingMode.OneWay)
            product.SetBinding(HyperlinkButton.TargetNameProperty, "Screen.targetProperty", BindingMode.OneWay)
        End Sub


    End Class

    Public Class ProductID2UriConverter
        Implements IValueConverter

        Public Function Convert(value As Object, targetType As System.Type, parameter As Object, culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
            Return New Uri("http://localhost:1419/timesheetentries.aspx?userid=" & value.ToString())
        End Function

        Public Function ConvertBack(value As Object, targetType As System.Type, parameter As Object, culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
            Return Nothing
        End Function
    End Class

End Namespace




