﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Portales.Api.Security
{
    public class ApiPrincipal : IPrincipal
    {
        public ApiPrincipal(string userName)
        {
            UserName = userName;
            Identity = new GenericIdentity(userName);
        }

        public string UserName { get; set; }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            if (role.Equals("user"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}