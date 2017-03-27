using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
using System.Windows;

namespace LightSwitchApplication
{
    public partial class PasswordBoxControl901
    {
        partial void PasswordBoxControl901_InitializeDataWorkspace(global::System.Collections.Generic.List<global::Microsoft.LightSwitch.IDataService> saveChangesTo)
        {
            // Write your code here.
            this.UserProperty = new User();
        }

        partial void PasswordBoxControl901_Saved()
        {
            // Write your code here.
            this.Close(false);
            Application.Current.ShowDefaultScreen(this.UserProperty);
        }

        partial void PasswordBoxControl901_Activated()
        {
            // Write your code here.

            var password = this.FindControl("Password");
            password.SetBinding(System.Windows.Controls.PasswordBox.PasswordProperty, "Value", System.Windows.Data.BindingMode.TwoWay );


        }
    }
}