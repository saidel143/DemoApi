﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portales.Models
{
    public class DataTableParams
    {
        public string sEcho { get; set; }

        public string sSearch { get; set; }

        public int iDisplayLength { get; set; }

        public int iDisplayStart { get; set; }
    }
}