using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Data
{
    public class AppliedJobsList
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobCategory { get; set; }
        public string Salary { get; set; }
        public string CompanyName { get; set; }
        public string ComapanyEmail { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyAddress { get; set; }
        public int AppliedJobId { get; set; }
        public DateTime? AppliedJobDate { get; set; }
        public bool? IsApplied { get; set; }
        public bool? IsSaved { get; set; }

    }
}
