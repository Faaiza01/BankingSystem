using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Data.Models.Domain
{
    public class AppliedJobs
    {
        [Key]
        public int AppliedJobId { get; set; }
        public string UserIdentityId { get; set; }
        public int JobId { get; set; }
        public DateTime? AppliedJobDate { get; set; }
    }
}
