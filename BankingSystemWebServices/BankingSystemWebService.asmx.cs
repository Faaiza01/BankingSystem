using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Forest.OutServices.IService;
using Forest.OutServices.Service;
using Forest.OutServices.Models;
using System.Web.Services.Protocols;

namespace ForestWebServices
{
    /// <summary>
    /// Summary description for ForestWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ForestWebService : System.Web.Services.WebService
    {
        public AuthenticationHeader authHeader;
        IContract service;

        public ForestWebService()
        {
            service = new Service();
        }

        //[WebMethod, SoapHeader("authHeader")]
        //public Category[] GetMusicCategoriesByAuthenticating()
        // {
        //     if (authHeader.SecurityKey == "abc123")
        //     {
        //         return service.GetMusicCategories();
        //     }
        //     else
        //     {
        //         return service.GetMusicCategoriesEmpty();
        //     }
        // }
        //[WebMethod]
        //public Category[] GetMusicCategories()
        //{
        //        return service.GetMusicCategories();
        //}
    }
}
