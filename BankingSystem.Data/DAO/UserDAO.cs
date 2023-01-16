using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Job.Data.IDAO;
using Job.Data.Models.Domain;
using Job.Data.Repository;
using System.Data.Entity;


namespace Job.Data.DAO
{
    public class UserDAO : IUserDAO
    {

        public IList<Employer> GetJobs(JobContext context)
        {
            return context.Employers.ToList();
        }

        public App_User GetLoggedInUserData(JobContext context, string IdentityId)
        {
            return context.AppUsers.Where(d => d.IdentityId == IdentityId).FirstOrDefault();
        }

        public string GetResumePath(JobContext context, string IdentityId)
        {
            return context.AppUsers.Where(d => d.IdentityId == IdentityId).Select(v => v.FirstName).FirstOrDefault();
        }

        public List<ListOfApplicantsDto> GetListOfApplicants(JobContext context)
        {
            List<ListOfApplicantsDto> listOfApplicantsDtos = new List<ListOfApplicantsDto>();
            var applicants = context.AppliedJobs.ToList();
            foreach (var item in applicants)
            {
                ListOfApplicantsDto listOfApplicantsDtos1 = new ListOfApplicantsDto();

                var jobs = context.Employers.Where(c => c.JobId == item.JobId).FirstOrDefault();
                var jobSeeker = context.AppUsers.Where(f => f.IdentityId == item.UserIdentityId).FirstOrDefault();
                listOfApplicantsDtos1.NameOfApplicant = jobSeeker?.FirstName + ' ' + jobSeeker?.LastName;
                listOfApplicantsDtos1.Email = jobSeeker?.Email;
                listOfApplicantsDtos1.IdentityId = jobSeeker?.IdentityId;
                listOfApplicantsDtos1.JobTitle = jobs.JobTitle;
                listOfApplicantsDtos1.CompanyName = jobs.CompanyName;
                listOfApplicantsDtos1.ComapanyEmail = jobs.ComapanyEmail;
                listOfApplicantsDtos1.AppliedJobDate = item.AppliedJobDate;
                listOfApplicantsDtos.Add(listOfApplicantsDtos1);
            }
            return listOfApplicantsDtos;
        }

        public List<AppliedJobsList> GetUserAppliedJobs(JobContext context, string UserId)
        {
            List<AppliedJobsList> appliedJobsList = new List<AppliedJobsList>();
            var result = context.AppliedJobs.Where(x => x.UserIdentityId == UserId).ToList();
            foreach (var item in result)
            {
             
                var jobs = context.Employers.Where(x => x.JobId == item.JobId).FirstOrDefault();
                AppliedJobsList appliedJobsList1 = new AppliedJobsList();
                appliedJobsList1.JobId = item.JobId;
                appliedJobsList1.JobTitle = jobs.JobTitle;
                appliedJobsList1.JobDescription = jobs.JobDescription;
                appliedJobsList1.JobCategory = jobs.JobCategory;
                appliedJobsList1.Salary = jobs.Salary;
                appliedJobsList1.CompanyName = jobs.CompanyName;
                appliedJobsList1.ComapanyEmail = jobs.ComapanyEmail;
                appliedJobsList1.CompanyAddress = jobs.CompanyAddress;
                appliedJobsList1.CompanyWebsite = jobs.CompanyWebsite;
                appliedJobsList1.AppliedJobDate = item.AppliedJobDate;
                appliedJobsList1.AppliedJobId = item.AppliedJobId;
                appliedJobsList.Add(appliedJobsList1);
            }
            return appliedJobsList;
        }

        public List<SavedJobList> GetUserSavedJobs(JobContext context, string UserId)
        {
            List<SavedJobList> savedJobsList = new List<SavedJobList>();
            var result = context.SavedJobs.Where(x => x.UserIdentityId == UserId).ToList();
            foreach (var item in result)
            {

                var jobs = context.Employers.Where(x => x.JobId == item.JobId).FirstOrDefault();
                SavedJobList savedJobsList1 = new SavedJobList();
                savedJobsList1.JobId = item.JobId;
                savedJobsList1.JobTitle = jobs.JobTitle;
                savedJobsList1.JobDescription = jobs.JobDescription;
                savedJobsList1.JobCategory = jobs.JobCategory;
                savedJobsList1.Salary = jobs.Salary;
                savedJobsList1.CompanyName = jobs.CompanyName;
                savedJobsList1.ComapanyEmail = jobs.ComapanyEmail;
                savedJobsList1.CompanyAddress = jobs.CompanyAddress;
                savedJobsList1.CompanyWebsite = jobs.CompanyWebsite;
                savedJobsList1.SavedJobId = item.SavedJobId;
                savedJobsList.Add(savedJobsList1);
            }
            return savedJobsList;
        }

        public List<AppliedJobsList> GetAppliedJobs(JobContext context, string UserId)
        {
            List<AppliedJobsList> appliedJobsList = new List<AppliedJobsList>();
            var result = context.Employers.ToList();
            foreach (var item in result)
            {
                AppliedJobsList appliedJobsList1 = new AppliedJobsList();
                appliedJobsList1.JobId = item.JobId;
                appliedJobsList1.JobTitle = item.JobTitle;
                appliedJobsList1.JobDescription = item.JobDescription;
                appliedJobsList1.JobCategory = item.JobCategory;
                appliedJobsList1.Salary = item.Salary;
                appliedJobsList1.CompanyName = item.CompanyName;
                appliedJobsList1.ComapanyEmail = item.ComapanyEmail;
                appliedJobsList1.CompanyAddress = item.CompanyAddress;
                appliedJobsList1.CompanyWebsite = item.CompanyWebsite;
                appliedJobsList1.IsApplied = IsApplied(context, item.JobId, UserId);
                appliedJobsList1.IsSaved = IsSaved(context, item.JobId, UserId);
                appliedJobsList1.AppliedJobId = context.AppliedJobs.Where(c => c.JobId == item.JobId && c.UserIdentityId == UserId).Select(v => v.AppliedJobId).FirstOrDefault();
                appliedJobsList.Add(appliedJobsList1);
            }
            return appliedJobsList;
        }

        public List<AppliedJobsList> SearchByJobTitle(JobContext context, string text, string UserId)
        {
            List<AppliedJobsList> appliedJobsList = new List<AppliedJobsList>();
            var result = context.Employers.Where(p => p.JobTitle.Contains(text)).ToList();
            foreach (var item in result)
            {
                AppliedJobsList appliedJobsList1 = new AppliedJobsList();
                appliedJobsList1.JobId = item.JobId;
                appliedJobsList1.JobTitle = item.JobTitle;
                appliedJobsList1.JobDescription = item.JobDescription;
                appliedJobsList1.JobCategory = item.JobCategory;
                appliedJobsList1.Salary = item.Salary;
                appliedJobsList1.CompanyName = item.CompanyName;
                appliedJobsList1.ComapanyEmail = item.ComapanyEmail;
                appliedJobsList1.CompanyAddress = item.CompanyAddress;
                appliedJobsList1.CompanyWebsite = item.CompanyWebsite;
                appliedJobsList1.IsApplied = IsApplied(context, item.JobId, UserId);
                appliedJobsList1.IsSaved = IsSaved(context, item.JobId, UserId);
                appliedJobsList1.AppliedJobId = context.AppliedJobs.Where(c => c.JobId == item.JobId && c.UserIdentityId == UserId).Select(v => v.AppliedJobId).FirstOrDefault();
                appliedJobsList.Add(appliedJobsList1);
            }
            return appliedJobsList;
        }

        public bool IsApplied(JobContext context, int jobId, string UserId)
        {
           var result=  context.AppliedJobs.ToList().Find(a => a.JobId == jobId && a.UserIdentityId == UserId);
            if (result == null)
                return false;
            else
                return true;
        }

        public bool? IsSaved(JobContext context, int jobId, string UserId)
        {
            var result = context.SavedJobs.ToList().Find(a => a.JobId == jobId && a.UserIdentityId == UserId);
            if (result == null)
                return false;
            else
                return true;
        }

        public void EditProfile(JobContext context, App_User employer, string userId)
        {
            var Id = context.AppUsers.Where(x => x.IdentityId == userId).Select(d => d.UserId).FirstOrDefault();
            context.AppUsers.Find(Id).FirstName = employer.FirstName;
            context.AppUsers.Find(Id).LastName = employer.LastName;
        }    
    }  
}
