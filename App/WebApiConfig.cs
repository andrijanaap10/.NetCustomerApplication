using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Http;

namespace App
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "SoapClientApi",
                routeTemplate: "api/soapclient/{action}/{id}",
                defaults: new { controller = "SoapClient", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

    }
}
