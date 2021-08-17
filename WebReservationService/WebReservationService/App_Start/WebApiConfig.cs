using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebReservationService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DropGuest",
                routeTemplate: "api/{controller}/{action}/{DropGuest}"
            );

            config.Routes.MapHttpRoute(
               name: "DropReservations",
               routeTemplate: "api/{controller}/{action}/{DropReservations}"
           );

           // config.Routes.MapHttpRoute(
           //    name: "CreateReservation",
           //    routeTemplate: "api/{controller}/{action}/{CreateReservation}"
           //);

           // config.Routes.MapHttpRoute(
           //    name: "CreateGuest",
           //    routeTemplate: "api/{controller}/{action}/{CreateGuest}"
           //);

            config.Formatters.JsonFormatter
                .SupportedMediaTypes
                .Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            config.Formatters.JsonFormatter
                .SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.EnableCors(new EnableCorsAttribute("*", "*", "GET,PUT,POST,DELETE"));
        }
    }
}
