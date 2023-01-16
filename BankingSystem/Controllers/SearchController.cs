using Job.Controllers;
using Job.Data;
using Job.Data.Models.Domain;
using Job.Services.IService;
using Job.Services.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobWebApi.Controllers
{
    public class SearchController : JobController
    {
        private IJobService JobService;
        public IUserService UserService;

        public SearchController()
        {
            JobService = new JobService();
            UserService = new UserService();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Search";
            var userId = User.Identity.GetUserId();     
            ViewBag.jobs = UserService.GetAppliedJobs(userId);          
            return View(ViewBag.jobs);
        }

        public ActionResult ApplyJob(int id)
        {
            var userId = User.Identity.GetUserId();

            AppliedJobs appliedJobs = new AppliedJobs
            {
                JobId = id,
                UserIdentityId = userId,
                AppliedJobDate = DateTime.Now,
            };

            JobService.ApplyJob(appliedJobs);
            return RedirectToAction("Index", "Search"); ;
        }

        public ActionResult SaveJob(int id)
        {
            var userId = User.Identity.GetUserId();

            SavedJobs appliedJobs = new SavedJobs
            {
                JobId = id,
                UserIdentityId = userId,
            };
            JobService.SaveJob(appliedJobs);
            return RedirectToAction("Index", "Search"); ;
        }

        [HttpPost]
        public ActionResult Index(string JobTitle)
        {
            var userId = User.Identity.GetUserId();           
            ViewBag.jobs= UserService.SearchByJobTitle(JobTitle, userId);                    
            return View(ViewBag.jobs);
          
        }
       

    }
}
