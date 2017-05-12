using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.ServiceModel.Activation;
using System.Web.Routing;

namespace WcfOnlineRestfulAjaxWalkThrough
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {


        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {

                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers",
                               "Accept, Content-Type,customHeader");

                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods",
                              "POST,GET,OPTIONS");

                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age",
                              "172800");

                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Credentials",
                              "true");

                HttpContext.Current.Response.AddHeader("Access-Control-Expose-Headers",
                              "customHeader");

                HttpContext.Current.Response.AddHeader("Content-type",
                             "application/json");

                HttpContext.Current.Response.End();
            }
            else
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers",
                               "Accept, Content-Type,customHeader");


                HttpContext.Current.Response.AddHeader("Access-Control-Expose-Headers",
                              "customHeader");

                HttpContext.Current.Response.AddHeader("Content-type",
                             "application/json");

            }

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