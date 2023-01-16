using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Job.Data.Models.Domain;
using Job.Data.DAO;
using Job.Data.IDAO;

namespace Job.Data.Repository
{
    public class JobInitialiser :
        System.Data.Entity.DropCreateDatabaseIfModelChanges<JobContext>
    {
        protected override void Seed(JobContext context)
        {
            Employer employer1 = new Employer()
            { 
                JobTitle = "Software Engineer", 
                JobDescription = "Full Stack Developer",
                JobCategory = "Permanent",
                Salary = "50000",
                CompanyName = "Telenor",
                ComapanyEmail = "mo@mo.com",
                CompanyAddress = "XYZ",
                CompanyWebsite = "mo@mo.com",
            };
            context.Employers.Add(employer1);

            App_User appUser1 = new App_User()
            {
                FirstName = "Faaiza",
                LastName = "Rashid",
                Email = "faaizarashid@hotmail.com",
                Role = "Admin",
            };
            context.AppUsers.Add(appUser1);

            context.SaveChanges();
        }
    }
}
