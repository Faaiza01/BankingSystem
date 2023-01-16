using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Data.Models.Domain;

namespace BankingSystem.Data.Repository
{
    public class BankingSystemContext: DbContext
    {
        public BankingSystemContext() : base("BankingSystemContext")
        {
            Database.SetInitializer(new BankingSystemInitialiser());
        }
        public DbSet<App_User> AppUsers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
