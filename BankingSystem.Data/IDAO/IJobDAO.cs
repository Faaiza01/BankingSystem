using Job.Data.Models.Domain;
using Job.Data.Repository;
using Job.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Data.IDAO
{
    public interface IJobDAO
    {
        Employer GetJob(JobContext context, int id);
        App_User GetAdminData(JobContext context);
        void DepositCash(JobContext context, Transaction transaction);
        void WithDrawCash(JobContext context, Transaction transaction);
        List<MyTransactionsDto> GetTransactionHistory(JobContext context, string id);
        void AddJob(JobContext context, Employer employer);
        void EditJob(JobContext context, Employer employer, int jobId);
        void AddUser(JobContext context, App_User app_User);
        void DeleteJob(JobContext context, int id);
        void ApplyJob(JobContext context, AppliedJobs appliedJobs);
        void SaveJob(JobContext context, SavedJobs savedJobs);
        IList<App_User> GetUsers(JobContext context);
        void RemoveUser(JobContext context, string identityId);
        App_User GetUserData(JobContext context, string id);
    }
}
