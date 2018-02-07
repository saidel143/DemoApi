using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using Portales.Dal.Model;
using Portales.Api.Models;
using System.Net.Http.Formatting;
using System.Web;
using Portales.Api.Handlers;
using System.Web.Http.Cors;

namespace PortalesWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API
            // Configure Web API para usar solo la autenticación de token de portador.            

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Post de variables primitivas. Esta linea de codigo debe ir antes de registrar las rutas de Web Api
            // config.ParameterBindingRules.Insert(0, PostParamBinding.PostParameterBinding);

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                }
            );

            //FORMATTERS
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Add(new ImageFormatter(HttpContext.Current.Server.MapPath("~/Images/")));

            //HANDLERS
            //config.MessageHandlers.Add(new ApiKeyHandler());
            //config.MessageHandlers.Add(new AuthHandler());

            //NEGOTIATION
            //config.Services.Replace(typeof(IContentNegotiator), new CustomContentNegotiator());

            //ODATA
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            //builder.EntitySet<Client>("Clients");
            builder.EntitySet<Bill>("Bill");
            builder.EntitySet<Details>("Details");
            builder.EntitySet<Product>("Products");
            builder.EntitySet<Category>("Categories");

            var client = builder.EntitySet<Client>("Clients");

            // New code: Add an action to the EDM, and define the parameter and return type.
            ActionConfiguration rateProduct = builder.Entity<Client>().Collection.Action("ObtenerClientesPorNombre");
            rateProduct.Parameter<string>("name");
            rateProduct.ReturnsCollectionFromEntitySet(builder.EntitySet<Client>("Clients"));

            config.Routes.MapODataServiceRoute(
                routeName: "odata",
                routePrefix: "odata",
                model: builder.GetEdmModel());
        }
    }
}
