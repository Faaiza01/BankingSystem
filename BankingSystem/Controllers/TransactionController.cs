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
    public class TransactionController : Controller
    {
        private IJobService JobService;

        public TransactionController()
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


        [HttpPost]
        public ActionResult DepositCash(DepositCashDto depositCashDto)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                JobService.DepositCash(depositCashDto, userId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult WithDraw()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WithDrawCash(DepositCashDto depositCashDto)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                JobService.WithDrawCash(depositCashDto, userId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}