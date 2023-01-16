using Job;
using Job.Services.IService;
using Job.Services.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JobWebApi.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IJobService JobService;

        public AdminController()
        {
            JobService = new JobService();
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Admin";
            ViewBag.users = JobService.GetUsers();
            return View(ViewBag.users);
        }

        public async Task<ActionResult> RemoveLogin(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return View("Error");
            }
            var result = await UserManager.DeleteAsync(user);
            JobService.RemoveUser(id);
            return RedirectToAction("Index", "Admin");
        }
    }
}
