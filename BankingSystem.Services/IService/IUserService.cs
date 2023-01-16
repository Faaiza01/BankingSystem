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
    public interface IUserService
    {
        IList<Employer> GetJobs();
        IList<AppliedJobsList> GetAppliedJobs(string UserId);
        IList<ListOfApplicantsDto> GetListOfApplicants();
        App_User GetLoggedInUserData(string IdentityId);
        void EditProfile(EditProfileDto editProfileDto, string userId);
        string GetResumePath(string identityId);
        IList<AppliedJobsList> GetUserAppliedJobs(string UserId);
        IList<SavedJobList> GetUserSavedJobs(string UserId);
        IList<AppliedJobsList> SearchByJobTitle(string text, string userId);
    }
}
