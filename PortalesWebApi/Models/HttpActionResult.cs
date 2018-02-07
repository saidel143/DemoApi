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
    public class HttpActionResult : IHttpActionResult
    {
        private readonly byte[] _content;
        private readonly HttpStatusCode _statusCode;

        public HttpActionResult(HttpStatusCode statusCode, byte[] content)
        {
            _statusCode = statusCode;
            _content = content;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(_statusCode);

            response.Content = new ByteArrayContent(_content);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

            return Task.FromResult(response);
        }
    }
}