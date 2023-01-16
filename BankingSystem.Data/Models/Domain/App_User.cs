using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Data.Models.Domain
{
    public class App_User
    {
        [Key]
        public int UserId { get; set; }
        public string IdentityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public DateTime? OpenDate { get; set; }
        public decimal? CurrentBalance { get; set; }


    }
}
