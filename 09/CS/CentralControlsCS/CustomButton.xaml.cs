using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Windows;
using System.Windows.Controls;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Animation;
//using System.Windows.Shapes;
using Microsoft.LightSwitch.Presentation;

namespace CentralControlsCS
{
    public partial class CustomButton : UserControl
    {
        public CustomButton()
        {
            InitializeComponent();
        }

        private void CustomButton_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {
            // Get a reference to the LightSwitch Screen
            var objDataContext = (IContentItem)this.DataContext;
            var clientScreen = (Microsoft.LightSwitch.Client.IScreenObject)objDataContext.Screen;
            // Call the Method on the LightSwitch screen
            clientScreen.Details.Dispatcher.BeginInvoke(
                () => {
                    try
                    {
                        this.SetEnabled(false);
                        clientScreen.Details.Commands["SaveData"].Execute();
                    }
                    finally
                    {
                        this.SetEnabled(true);
                    }
                });
        }


        private void SetEnabled(bool value)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.CustomButton1.IsEnabled = value;
            });
        }


    }
}
