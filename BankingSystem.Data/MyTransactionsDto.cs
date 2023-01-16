using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Services.Models
{
    public class MyTransactionsDto
    {
        public decimal? AmountToBeProcessed { get; set; }
        public string TransactionBy { get; set; }
        public string TransactionTo { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string AccountNumber { get; set; }
        public decimal? CurrentBalance { get; set; }
    }
}
