using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portales.Api.Models
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class PostParamAttribute : Attribute
    {

    }
}