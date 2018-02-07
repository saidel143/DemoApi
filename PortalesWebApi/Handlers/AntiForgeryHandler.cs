using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Portales.Api.Handlers
{
    public class AntiForgeryHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string cookieToken = "";
            string formToken = "";

            if (request.Headers.GetValues("X-Requested-With").Contains("XMLHttpRequest"))
            {

            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}