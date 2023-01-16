using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Data.Models.Domain;
using BankingSystem.Data.DAO;
using BankingSystem.Data.IDAO;

namespace BankingSystem.Data.Repository
{
    public class BankingSystemInitialiser :
        System.Data.Entity.DropCreateDatabaseIfModelChanges<BankingSystemContext>
    {
        protected override void Seed(BankingSystemContext context)
        {
            //Employer employer1 = new Employer()
            //{ 
            //    BankingSystemTitle = "Software Engineer", 
            //    BankingSystemDescription = "Full Stack Developer",
            //    BankingSystemCategory = "Permanent",
            //    Salary = "50000",
            //    CompanyName = "Telenor",
            //    ComapanyEmail = "mo@mo.com",
            //    CompanyAddress = "XYZ",
            //    CompanyWebsite = "mo@mo.com",
            //};
            //context.Employers.Add(employer1);

            //App_User appUser1 = new App_User()
            //{
            //    FirstName = "Faaiza",
            //    LastName = "Rashid",
            //    Email = "faaizarashid@hotmail.com",
            //    Role = "Admin",
            //};
            //context.AppUsers.Add(appUser1);

            context.SaveChanges();
        }
    }
}
