using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProductService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.EnableCors();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            //var cors = new EnableCorsAttribute(origins: "*", "*", "*");
        
            //config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
        new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
