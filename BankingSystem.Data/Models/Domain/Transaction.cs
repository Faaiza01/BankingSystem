using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Data.Models.Domain
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public decimal? AmountToBeProcessed { get; set; }
        public string TransactionBy { get; set; }
        public string TransactionTo { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
