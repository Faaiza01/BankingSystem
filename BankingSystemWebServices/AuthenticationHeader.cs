using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace JobWebServices
{
    public class AuthenticationHeader : SoapHeader
    {
        public AuthenticationHeader() { }
        public AuthenticationHeader(string key)
        {
            SecurityKey = key;
        }
        public string SecurityKey { get; set; }
    }
}