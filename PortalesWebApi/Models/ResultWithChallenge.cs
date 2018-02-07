using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Portales.Api.Models
{
    public class ResultWithChallenge : IHttpActionResult
    {
        private readonly string authenticationScheme = "amx";
        private readonly IHttpActionResult next;

        public ResultWithChallenge(IHttpActionResult next)
        {
            this.next = next;
        }

        Task<HttpResponseMessage> IHttpActionResult.ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = next.ExecuteAsync(cancellationToken);

            if (response.Result.StatusCode == HttpStatusCode.Unauthorized)
            {
                response.Result.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(authenticationScheme));
            }

            return response;
        }
    }
}