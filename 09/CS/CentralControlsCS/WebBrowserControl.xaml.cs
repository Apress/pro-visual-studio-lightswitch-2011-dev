using System;
using System.Windows;
using System.Windows.Controls;

namespace CentralControlsCS
{
    public partial class WebBrowserControl : UserControl
    {
        public WebBrowserControl()
        {
            InitializeComponent();
        }


        public Uri uri
        {
            get { return (Uri)GetValue(URIProperty); }
            set { SetValue(URIProperty, value); }
        }

        public static readonly DependencyProperty URIProperty =
            DependencyProperty.Register(
                "uri",
                typeof(Uri),
                typeof(WebBrowserControl),
                new PropertyMetadata(null, OnUriPropertyChanged));

        private static void OnUriPropertyChanged(
            DependencyObject re, DependencyPropertyChangedEventArgs e)
        {

            if (e.NewValue != null)
            {
                WebBrowserControl wb = (WebBrowserControl)re;
                wb.wb1.Navigate((Uri)e.NewValue);
            }

        } 


    
    }



}
