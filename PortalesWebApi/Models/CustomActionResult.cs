using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Portales.Api.Extensions;

namespace Portales.Api.Models
{
    public class CustomActionResult<T> : IHttpActionResult
    {
        CustomResult<T> customResult;

        public CustomActionResult(T content, int codigo)
        {
            customResult = new CustomResult<T>(content, codigo);
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings = JsonExtensions.ToJsonString(true, true);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent(typeof(CustomResult<T>), customResult, formatter)
            };

            return Task.FromResult(response);
        }
    }

    public class CustomResult<T>
    {
        public int Codigo { get; set; }

        public T Data { get; set; }

        public CustomResult(T data, int codigo)
        {
            Data = data;
            Codigo = codigo;
        }
    }
}