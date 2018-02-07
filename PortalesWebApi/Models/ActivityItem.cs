using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portales.Api.Models
{
    public class ActivityItem
    {
        public int ActivityId { get; set; }
        public string EventDescription { get; set; }
        public string PersonName { get; set; }
        public int ActivityLength { get; set; }
        public string ImageName { get; set; }
        public DateTime Date { get; set; }
    }
}