using Portales.Dal.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace Portales.Api.Models
{
    public class ImageFormatter : MediaTypeFormatter
    {
        string path;

        public ImageFormatter(string path)
        {
            this.path = path;
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpeg"));
        }
        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(Client);
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            return Task.Factory.StartNew(() => WriteToStream(type, value, writeStream, content));
        }

        public void WriteToStream(Type type, object value, Stream stream, HttpContent content)
        {
            Client client = (Client)value;
            Image image = Image.FromFile(path + $"{client.Name}.jpeg");
            image.Save(stream, ImageFormat.Jpeg);
            image.Dispose();
        }
    }
}