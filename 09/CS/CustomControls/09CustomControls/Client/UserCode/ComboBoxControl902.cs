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
    public partial class ComboBoxControl902
    {
        partial void ComboBoxControl902_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            // Write your code here.
            this.OrderProperty = new Order();
        }

        partial void ComboBoxControl902_Saved()
        {
            // Write your code here.
            this.Close(false);
            Application.Current.ShowDefaultScreen(this.OrderProperty);
        }

        partial void ComboBoxControl902_Activated()
        {
            // Write your code here.
            IContentItemProxy comboControl = this.FindControl("Customer");
            comboControl.SetBinding(
                System.Windows.Controls.ComboBox.ItemsSourceProperty,
                "Screen.Customers",
                System.Windows.Data.BindingMode.TwoWay);

            comboControl.SetBinding(
                System.Windows.Controls.ComboBox.SelectedItemProperty,
                "Screen.OrderProperty.Customer",
                System.Windows.Data.BindingMode.TwoWay); 

            
        }
    }
}