using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
using System.Windows.Data;
using System.Windows.Controls;

namespace LightSwitchApplication
{
    public partial class HyperlinkButton904
    {
        partial void HyperlinkButton904_Activated()
        {
            // Write your code here.
            IContentItemProxy product = this.FindControl("ProductName");
            targetProperty = "_blank";
            ProductID2UriConverter converter = new ProductID2UriConverter();
            product.SetBinding(HyperlinkButton.ContentProperty,
                "Value",
                BindingMode.OneWay);

            product.SetBinding(HyperlinkButton.NavigateUriProperty,
                "Details.Entity.ProductID",
                converter,
                BindingMode.OneWay);

            product.SetBinding(HyperlinkButton.TargetNameProperty,
                "Screen.targetProperty",
                BindingMode.OneWay);

            
        }
    }

    public class ProductID2UriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new Uri(@"http://lsfaq.com/ProVSExamples/Product.aspx?ProductId=" + value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

}
