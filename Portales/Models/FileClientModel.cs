using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portales.Models
{
    public class FileClientModel
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}