using BankingSystem.Data.Models.Domain;
using BankingSystem.Data.Repository;
using BankingSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Data.IDAO
{
    public interface IBankingSystemDAO
    {
        App_User GetAdminData(BankingSystemContext context);
        void DepositCash(BankingSystemContext context, Transaction transaction);
        void WithDrawCash(BankingSystemContext context, Transaction transaction);
        List<MyTransactionsDto> GetTransactionHistory(BankingSystemContext context, string id);
        List<MyTransactionsDto> GetAdminTransactionHistory(BankingSystemContext context);
        void AddUser(BankingSystemContext context, App_User app_User);
        IList<App_User> GetUsers(BankingSystemContext context);
        void RemoveUser(BankingSystemContext context, string identityId);
        App_User GetUserData(BankingSystemContext context, string id);
    }
}
