using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portales.Api.Extensions
{
    public static class JsonExtensions
    {
        public static JsonSerializerSettings ToJsonString(bool camelCase = false, bool indented = false)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            if (camelCase)
            {
                jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
            if (indented)
            {
                jsonSerializerSettings.Formatting = Formatting.Indented;
            }
            jsonSerializerSettings.Converters.Insert(0, new IsoDateTimeConverter());
            return jsonSerializerSettings;
        }
    }
}