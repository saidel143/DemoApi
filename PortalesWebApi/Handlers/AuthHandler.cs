using Portales.Api.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Portales.Api.Handlers
{
    public class AuthHandler : DelegatingHandler
    {
        string _userName = "";

        //Method to validate credentials from Authorization
        //header value
        private bool ValidateCredentials(AuthenticationHeaderValue headerAuth)
        {
            try
            {
                if (headerAuth != null && !string.IsNullOrEmpty(headerAuth.Parameter))
                {
                    string[] decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(headerAuth.Parameter)).Split(new[] { ':' });

                    //now decodedCredentials[0] will contain
                    //username and decodedCredentials[1] will
                    //contain password.

                    if (decodedCredentials[0].Equals("username") && decodedCredentials[1].Equals("password"))
                    {
                        _userName = "username";
                        return true;//request authenticated.
                    }
                }
                return false;//request not authenticated.
            }
            catch
            {
                return false;
            }
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //if the credentials are validated,
            //set CurrentPrincipal and Current.User
            if (ValidateCredentials(request.Headers.Authorization))
            {
                Thread.CurrentPrincipal = new ApiPrincipal(_userName);
                HttpContext.Current.User = new ApiPrincipal(_userName);
            }
            //Execute base.SendAsync to execute default
            //actions and once it is completed,
            //capture the response object and add
            //WWW-Authenticate header if the request
            //was marked as unauthorized.

            //Allow the request to process further down the pipeline
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized && !response.Headers.Contains("WWW-Authenticate"))
            {
                response.Headers.Add("WWW-Authenticate", "Basic");
            }

            return response;
        }

        private Task<HttpResponseMessage> Unauthorized()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}