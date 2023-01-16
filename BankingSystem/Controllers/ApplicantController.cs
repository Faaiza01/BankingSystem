using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job.Controllers
{
    public class ApplicantController : JobController
    {
        // GET: Applicant
        public ActionResult Index()
        {
            ViewBag.applicants = UserService.GetListOfApplicants();
            return View(ViewBag.applicants);    
        }

        public ActionResult PdfDownload(string userId)
        {
            string TempFilePath = UserService.GetResumePath(userId);
            if (System.IO.File.Exists(TempFilePath))
            {
                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = "Resume.pdf",
                    Inline = false,
                };
                Response.AppendHeader("Content-Disposition", cd.ToString());
                return File(TempFilePath, "application/pdf");
            }
            else
            {
                return null;
            }

        }
    }
}