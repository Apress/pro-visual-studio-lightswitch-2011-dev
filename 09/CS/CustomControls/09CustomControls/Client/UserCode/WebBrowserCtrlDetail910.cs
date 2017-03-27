using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
using CentralControlsCS;

namespace LightSwitchApplication
{
    public partial class WebBrowserCtrlDetail910
    {
        partial void Hyperlink_Loaded(bool succeeded)
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Hyperlink);
        }

        partial void Hyperlink_Changed()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Hyperlink);
        }

        partial void WebBrowserCtrlDetail910_Saved()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Hyperlink);
        }

        partial void WebBrowserCtrlDetail910_Activated()
        {
            // Write your code here.
            Property1 = "Type in a URL and the control will update iteself automatically";
            IContentItemProxy ctrl = this.FindControl("URL");
            ctrl.SetBinding(CentralControlsCS.WebBrowserControl.URIProperty, "Value", System.Windows.Data.BindingMode.OneWay );

        }
    }
}