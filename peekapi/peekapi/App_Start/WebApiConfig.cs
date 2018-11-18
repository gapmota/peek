using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace peekapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();
            config.Formatters.Add(config.Formatters.JsonFormatter);
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "peek/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
