using Job.Data.IDAO;
using Job.Data.Models.Domain;
using Job.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Job.Services.Models;

namespace Job.Data.DAO
{
    public class JobDAO : IJobDAO
    {

        public Employer GetJob(JobContext context, int id)
        {
            return context.Employers.ToList().Find(b => b.JobId == id);
        }

        public App_User GetUserData(JobContext context, string id)
        {
            return context.AppUsers.ToList().Find(b => b.IdentityId == id);
        }

        public App_User GetAdminData(JobContext context)
        {
            return context.AppUsers.ToList().Find(b => b.Role == "Admin");
        }
        public IList<App_User> GetUsers(JobContext context)
        {
            return context.AppUsers.Where(x=> x.Role == "Customer").ToList();
        }
        public void AddJob(JobContext context, Employer employer)
        {
            context.Employers.Add(employer);
            context.SaveChanges();
        }

        public void DepositCash(JobContext context, Transaction transaction)
        {
            context.Transactions.Add(transaction);
            context.SaveChanges();


            var transactionBy = context.AppUsers.Where(x => x.IdentityId == transaction.TransactionBy).FirstOrDefault();
            context.AppUsers.Find(transactionBy.UserId).CurrentBalance = transactionBy.CurrentBalance - transaction.AmountToBeProcessed;
            context.SaveChanges();

            var transactionTo = context.AppUsers.Where(x => x.IdentityId == transaction.TransactionTo).FirstOrDefault();
            context.AppUsers.Find(transactionTo.UserId).CurrentBalance = transactionTo.CurrentBalance + transaction.AmountToBeProcessed; 
            context.SaveChanges();
        }

        public void WithDrawCash(JobContext context, Transaction transaction)
        {
            context.Transactions.Add(transaction);
            context.SaveChanges();


            var transactionBy = context.AppUsers.Where(x => x.IdentityId == transaction.TransactionBy).FirstOrDefault();
            context.AppUsers.Find(transactionBy.UserId).CurrentBalance = transactionBy.CurrentBalance - transaction.AmountToBeProcessed;
            context.SaveChanges();
        }

        public List<MyTransactionsDto> GetTransactionHistory(JobContext context, string id)
        {
            List<MyTransactionsDto> myTransactionsDtos = new List<MyTransactionsDto>();

            var myTransactions = context.Transactions.Where(b => b.TransactionBy == id).ToList();
            var transactionBy = context.AppUsers.Where(b => b.IdentityId == id).FirstOrDefault();

            foreach (var item in myTransactions)
            {
                App_User transactionTo = new App_User();
                if (item.TransactionTo!=null)
                {
                     transactionTo = context.AppUsers.Where(b => b.IdentityId == item.TransactionTo).SingleOrDefault();
                }

                MyTransactionsDto myTransactionsDto = new MyTransactionsDto();
                myTransactionsDto.AccountNumber = transactionTo.AccountNumber;
                myTransactionsDto.AmountToBeProcessed = item.AmountToBeProcessed;
                myTransactionsDto.TransactionType = item.TransactionType;
                myTransactionsDto.TransactionDate = item.TransactionDate;
                myTransactionsDto.CurrentBalance = transactionBy.CurrentBalance;
                myTransactionsDto.TransactionTo = transactionTo?.FirstName + " " + transactionTo?.LastName;
                myTransactionsDto.TransactionBy = transactionBy.FirstName + " " + transactionBy.LastName;
                myTransactionsDtos.Add(myTransactionsDto);
            }
            return myTransactionsDtos;
        }

        public void WithDraw(JobContext context, Employer employer)
        {
            context.Employers.Add(employer);
            context.SaveChanges();
        }

        public List<MyTransactionsDto> GetAdminTransactionHistory(JobContext context)
        {
            List<MyTransactionsDto> myTransactionsDtos = new List<MyTransactionsDto>();
            var alltransactions = context.Transactions.ToList();

            foreach (var item in alltransactions)
            {
                App_User transactionTo = new App_User();
                if (item.TransactionTo != null)
                {
                    transactionTo = context.AppUsers.Where(b => b.IdentityId == item.TransactionTo).SingleOrDefault();
                }

                App_User transactionBy = new App_User();
                if (item.TransactionBy != null)
                {
                    transactionBy = context.AppUsers.Where(b => b.IdentityId == item.TransactionBy).SingleOrDefault();
                }
                MyTransactionsDto myTransactionsDto = new MyTransactionsDto();
                myTransactionsDto.AccountNumber = transactionTo.AccountNumber;
                myTransactionsDto.AmountToBeProcessed = item.AmountToBeProcessed;
                myTransactionsDto.TransactionType = item.TransactionType;
                myTransactionsDto.TransactionDate = item.TransactionDate;
                myTransactionsDto.CurrentBalance = transactionBy.CurrentBalance;
                myTransactionsDto.TransactionTo = transactionTo?.FirstName + " " + transactionTo?.LastName;
                myTransactionsDto.TransactionBy = transactionBy.FirstName + " " + transactionBy.LastName;
                myTransactionsDtos.Add(myTransactionsDto);
            }
            return myTransactionsDtos;
        }
        public void AddUser(JobContext context, App_User app_User)
        {
            context.AppUsers.Add(app_User);
            context.SaveChanges();
        }

        public void RemoveUser(JobContext context, string identityId)
        {
            context.AppUsers.Remove(context.AppUsers.Where(c => c.IdentityId == identityId).FirstOrDefault());
            context.SaveChanges();
        }

        public void SaveJob(JobContext context,SavedJobs savedJobs)
        {
            context.SavedJobs.Add(savedJobs);
            context.SaveChanges();
        }

        public void ApplyJob(JobContext context, AppliedJobs appliedJobs)
        {
            context.AppliedJobs.Add(appliedJobs);
            context.SaveChanges();
        }

        public void EditJob(JobContext context, Employer employer, int jobId)
        {
            context.Employers.Find(jobId).JobTitle = employer.JobTitle;
            context.Employers.Find(jobId).JobDescription = employer.JobDescription;
            context.Employers.Find(jobId).JobCategory = employer.JobCategory;
            context.Employers.Find(jobId).Salary = employer.Salary;
            context.Employers.Find(jobId).CompanyName = employer.CompanyName;
            context.Employers.Find(jobId).CompanyAddress = employer.CompanyAddress;
            context.Employers.Find(jobId).ComapanyEmail = employer.ComapanyEmail;
            context.Employers.Find(jobId).CompanyWebsite = employer.CompanyWebsite;
            context.SaveChanges();
        }

        public void DeleteJob(JobContext context, int id)
        {
            context.Employers.Remove(context.Employers.Find(id));
            context.SaveChanges();
        }
    }

}
