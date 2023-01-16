using Job.Services.IService;
using Job.Services.Models;
using Job.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job.Controllers
{
    public class PostJobController : Controller
    {
        private IJobService JobService;

        public PostJobController()
        {
            JobService = new JobService();
        }
        public ActionResult Index()
        {
            return View();
        }

        // POST: PostJob/Create
        [HttpPost]
        public ActionResult PostJob(PostJobDto postJobDto)
        {
            try
            {
                JobService.AddJob(postJobDto, "mo");
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
      
    }
}