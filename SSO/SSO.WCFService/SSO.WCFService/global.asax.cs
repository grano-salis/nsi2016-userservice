using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SSO.WCFService
{
    public class global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string port = HttpContext.Current.Request.Url.Port.ToString();
            if (HttpContext.Current.Request.Url.Host.Equals("do.mac.ba"))
            {
                port = "88";
            }
            if (HttpContext.Current.Request.UrlReferrer != null)
            {
                if (HttpContext.Current.Request.UrlReferrer.Port != 80)
                {
                    port = ":" + HttpContext.Current.Request.UrlReferrer.Port.ToString();
                } else
                {
                    port = "";
                }
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://" + HttpContext.Current.Request.UrlReferrer.Host + port);
            } else
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://" + HttpContext.Current.Request.Url.Host + ":" + port);
            }
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Credentials", "true");

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");

                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
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