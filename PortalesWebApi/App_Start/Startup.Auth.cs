using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PortalesWebApi.Models;
using System.Web.Http;
using Microsoft.Owin.Cors;
using Portales.Api.Providers;
using Portales.Api.Models;
using Portales;
using System.Configuration;

namespace PortalesWebApi
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // Para obtener más información para configurar la autenticación, visite http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure el contexto de base de datos y el administrador de usuarios para usar una única instancia por solicitud
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            //// Permitir que la aplicación use una cookie para almacenar información para el usuario que inicia sesión
            //// y una cookie para almacenar temporalmente información sobre un usuario que inicia sesión con un proveedor de inicio de sesión de terceros
            //app.UseCookieAuthentication(new CookieAuthenticationOptions());
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            //// Configure la aplicación para el flujo basado en OAuth
            //PublicClientId = "self";
            //OAuthOptions = new OAuthAuthorizationServerOptions
            //{
            //    TokenEndpointPath = new PathString("/Token"),
            //    Provider = new ApplicationOAuthProvider(PublicClientId),
            //    AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
            //    // En el modo de producción establezca AllowInsecureHttp = false
            //    AllowInsecureHttp = true
            //};

            //// Quitar los comentarios de las siguientes líneas para habilitar el inicio de sesión con proveedores de inicio de sesión de terceros
            ////app.UseMicrosoftAccountAuthentication(
            ////    clientId: "",
            ////    clientSecret: "");

            ////app.UseTwitterAuthentication(
            ////    consumerKey: "",
            ////    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "1119349968102277",
            //    appSecret: "fc0789cf347f1229a377cd12c28eeac3");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "521908517745-6bv2ss8lp9u3an6ids723npvd2eq9bvk.apps.googleusercontent.com",
            //    ClientSecret = "vwyy8F70wGIEyme8jD_ibP09"
            //});

            //// Permitir que la aplicación use tokens portadores para autenticar usuarios

            //app.UseOAuthAuthorizationServer(OAuthOptions);
            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            //app.UseCors(CorsOptions.AllowAll);

            //app.UseWebApi(GlobalConfiguration.Configuration);
            
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new ApplicationOAuthProvider("self"),
                AccessTokenFormat = new CustomJwtFormat(ConfigurationManager.AppSettings["as:AuthServer"])
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
        }
    }
}
