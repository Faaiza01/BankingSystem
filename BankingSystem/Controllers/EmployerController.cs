using Job.Data.Models.Domain;
using Job.Services.IService;
using Job.Services.Models;
using Job.Services.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job.Controllers
{
    public class EmployerController : JobController
    {
        private IJobService JobService;

        public EmployerController()
        {
            JobService = new JobService();
        }

        // GET: Get Jobs
        public ActionResult Index()
        {
            ViewBag.applicants = UserService.GetListOfApplicants();

            return View(ViewBag.genres);
        }

        [HttpPost]
        public ActionResult PostJob(PostJobDto postJobDto)
        {
            try
            {
                JobService.AddJob(postJobDto, "mo");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        //GET: EditJob/Edit
        public ActionResult EditJob(int id)
        {
            PostJobDto postJobDto = new PostJobDto();
            Employer job = JobService.GetJob(id);
            postJobDto.JobTitle = job.JobTitle;
            postJobDto.JobDescription = job.JobDescription;
            postJobDto.JobCategory = job.JobCategory;
            postJobDto.Salary = job.Salary;
            postJobDto.CompanyName = job.CompanyName;
            postJobDto.CompanyAddress = job.CompanyAddress;
            postJobDto.ComapanyEmail = job.ComapanyEmail;
            postJobDto.CompanyWebsite = job.CompanyWebsite;
            return View(postJobDto);
        }

        [HttpPost]
        public ActionResult EditJob(int id, PostJobDto postJobDto)
        {
            try
            {
                JobService.EditJob(postJobDto, "mo", id);
                return RedirectToAction("Index", "Employer");
            }
            catch
            {
                return View();
            }
        }

 
        //// GET: DeleteJob/Delete/5
        public ActionResult DeleteJob(int id)
        {
            Employer job = JobService.GetJob(id);
            return View(job);
        }

        //// POST: DeleteJob/Delete/5
        [HttpPost]
        public ActionResult DeleteJob(int id, Employer music)
        {
            try
            {
                JobService.DeleteJob(id);
                return RedirectToAction("Index", new { Controller = "Employer" });
            }
            catch
            {
                return View();
            }
        }
    }
}
