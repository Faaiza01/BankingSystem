using Job.Data;
using Job.Data.Models.Domain;
using Job.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Services.IService
{
    public interface IJobService
    {
        Employer GetJob(int id);
        void AddJob(PostJobDto postJobDto, string userId);
        void DepositCash(DepositCashDto depositCashDto, string userId);
        void AddUser(App_User app_User);
        void EditJob(PostJobDto postJobDto, string userId, int id);
        void DeleteJob(int id);
        void ApplyJob(AppliedJobs appliedJobs);
        void SaveJob(SavedJobs savedJobs);
        IList<App_User> GetUsers();
        void RemoveUser(string id);
        App_User GetUserData(string id);
    }
}
