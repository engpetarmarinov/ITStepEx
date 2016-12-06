using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ChallengesProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services            

            // Web API routes
            config.MapHttpAttributeRoutes();

            // set formatter
            config.Formatters.Add(new BrowserJsonFormatter());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "Get", id = RouteParameter.Optional }
            );
        }
    }
}
