using BankingSystem.Data;
using BankingSystem.Data.Models.Domain;
using BankingSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Services.IService
{
    public interface IBankingSystemService
    {
        App_User GetAdminData();
        void DepositCash(DepositCashDto depositCashDto, string userId);
        void WithDrawCash(DepositCashDto depositCashDto, string userId);
        IList<MyTransactionsDto> GetTransactionHistory(string userId);
        IList<MyTransactionsDto> GetAdminTransactionHistory();
        void AddUser(App_User app_User);
        IList<App_User> GetUsers();
        void RemoveUser(string id);
        App_User GetUserData(string id);
    }
}
