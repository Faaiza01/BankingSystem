using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Data.Models.Domain
{
    public class SavedJobs
    {
        [Key]
        public int SavedJobId { get; set; }
        public string UserIdentityId { get; set; }
        public int JobId { get; set; }

    }
}
