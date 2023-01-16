using Job.Services.IService;
using Job.Services.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job.Controllers
{
    public abstract class JobController : Controller
    {
       public IUserService UserService;

        protected JobController()
        {
            UserService = new UserService();
            ViewBag.genres = UserService.GetJobs();        
        }
    }
}