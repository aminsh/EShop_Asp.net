using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using Newtonsoft.Json.Serialization;
using WebSite.App_Start;
using System.Web.Http;

namespace WebSite
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                                                              new ScriptResourceDefinition
                                                                  {
                                                                      Path = "~/scripts/jquery-1.7.2.min.js",
                                                                      DebugPath = "~/scripts/jquery-1.7.2.min.js",
                                                                      CdnPath =
                                                                          "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.min.js",
                                                                      CdnDebugPath =
                                                                          "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.js"
                                                                  });

            RouteTable.Routes.MapPageRoute("Product",
                                           "Product",
                                           "~/Admin/PageProduct.aspx");

            RouteTable.Routes.MapPageRoute("ProductCategory",
                                           "ProductCategory",
                                           "~/Admin/PageProductCategory.aspx");

            HttpConfiguration config = GlobalConfiguration.Configuration;
            ((DefaultContractResolver)config.Formatters.JsonFormatter.SerializerSettings.ContractResolver).IgnoreSerializableAttribute = true;
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