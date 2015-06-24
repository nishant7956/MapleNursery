using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using Parse;
namespace maplenursery
{
    public class Global : System.Web.HttpApplication
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
            "https://justtest1.azure-mobile.net/",
            "mJEgatlxaTwcURdtCcoAxwfEZsSNhB37"
        );
        protected void Application_Start(object sender, EventArgs e)
        {
            
           
            ParseClient.Initialize("ex2AU6Rib2KDkBGC4WrkTF4UuVTTEmFVYNiqofNC", "MBBD0DacqJtLbZjApXhk1WjiRtwo5YbOSoT31Vea");


            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-1.7.1.js",
                DebugPath = "~/Scripts/jquery-1.7.1.js"
            });

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}