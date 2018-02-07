using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Portales.Web.Services
{
    public class AppSettingsConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            return ConfigurationManager.AppSettings[value.ToString()];
        }
    }
}