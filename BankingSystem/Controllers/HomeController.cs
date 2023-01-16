using BankingSystem.Data.Models.Domain;
using BankingSystem.Services.IService;
using BankingSystem.Services.Models;
using BankingSystem.Services.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using BankingSystem.Models;

namespace BankingSystem.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IBankingSystemService BankingSystemService;

        public HomeController()
        {
            BankingSystemService = new BankingSystemService();
        }
        public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            BankingSystemService = new BankingSystemService();
        }
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            App_User admin = BankingSystemService.GetAdminData();
            if(admin == null)
            {
                await Register();
            }
            App_User app_User = BankingSystemService.GetUserData(userId);
            Session["Data"] = app_User;
            if (userId != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

        public async Task<ActionResult> Register()
        {            
            var user = new ApplicationUser { UserName = "admin2@gmail.com", Email = "admin2@gmail.com" };
            var result = await UserManager.CreateAsync(user, "Test1234@");
            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                App_User app_User = new App_User
                {
                        IdentityId = user.Id,
                        FirstName = "Admin2",
                        LastName = "Admin2",
                        Email = "admin2@gmail.com",
                        Role = "Admin",
                };
                    BankingSystemService = new BankingSystemService();
                    BankingSystemService.AddUser(app_User);
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
    
            // If we got this far, something failed, redisplay form
            return RedirectToAction("Index", "Login");
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


        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(Microsoft.AspNet.Identity.IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}