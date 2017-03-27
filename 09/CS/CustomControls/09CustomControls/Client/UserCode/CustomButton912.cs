using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
namespace LightSwitchApplication
{
    public partial class CustomButton912
    {
        partial void SaveData_Execute()
        {
            // Write your code here.
            this.Save();
            this.ShowMessageBox("Saved");
        }


        partial void CustomButton912_InitializeDataWorkspace(global::System.Collections.Generic.List<global::Microsoft.LightSwitch.IDataService> saveChangesTo)
        {
            // Write your code here.
            this.CustomerProperty = new Customer();
        }

        partial void CustomButton912_Saved()
        {
            // Write your code here.
            //this.Close(false);
            Application.Current.ShowDefaultScreen(this.CustomerProperty);
        }

    }
}
