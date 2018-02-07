using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;

namespace Portales.Api.Models
{
    public class CustomContentNegotiator : DefaultContentNegotiator
    {
        public override ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        {
            return new ContentNegotiationResult(new JsonMediaTypeFormatter(), new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
        }
    }
}