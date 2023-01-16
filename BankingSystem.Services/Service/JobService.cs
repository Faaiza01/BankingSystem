using BankingSystem.Data.DAO;
using BankingSystem.Data.IDAO;
using BankingSystem.Data.Models.Domain;
using BankingSystem.Data.Repository;
using BankingSystem.Services.IService;
using BankingSystem.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankingSystem.Services.Service
{
    public class BankingSystemService : IBankingSystemService
    {
        private IBankingSystemDAO BankingSystemDAO;
  
        public BankingSystemService()
        {
            BankingSystemDAO = new BankingSystemDAO();
        }

        public void DepositCash(DepositCashDto depositCashDto, string userId)
        {
         

            using (var context = new BankingSystemContext())
            {
                var transactionTo = context.AppUsers.Where(x => x.AccountNumber == depositCashDto.AccountNumber).Select(x => x.IdentityId).FirstOrDefault();
                Transaction transaction = new Transaction()
                {
                    AmountToBeProcessed = depositCashDto.Amount,
                    TransactionTo  = transactionTo,
                    TransactionBy = userId,
                    TransactionType = "Deposit",
                    TransactionDate = System.DateTime.Now
                };
                BankingSystemDAO.DepositCash(context, transaction);//Add BankingSystem
                context.SaveChanges();
            }
        }

        public IList<MyTransactionsDto> GetTransactionHistory(string userId)
        {
            using (var context = new BankingSystemContext())
            {
                return BankingSystemDAO.GetTransactionHistory(context, userId);
            }
        }

        public IList<MyTransactionsDto> GetAdminTransactionHistory()
        {
            using (var context = new BankingSystemContext())
            {
                return BankingSystemDAO.GetAdminTransactionHistory(context);
            }
        }
        public void WithDrawCash(DepositCashDto depositCashDto, string userId)
        {
            using (var context = new BankingSystemContext())
            {
                Transaction transaction = new Transaction()
                {
                    AmountToBeProcessed = depositCashDto.Amount,
                    TransactionBy = userId,
                    TransactionType = "WithDraw",
                    TransactionDate = System.DateTime.Now
                };
                BankingSystemDAO.WithDrawCash(context, transaction);//Add BankingSystem
                context.SaveChanges();
            }
        }

        public void AddUser(App_User app_User)
        {

            using (var context = new BankingSystemContext())
            {   
                BankingSystemDAO.AddUser(context, app_User);//Add user
                context.SaveChanges();
            }   
        }

        public App_User GetUserData(string id)
        {
            using (var context = new BankingSystemContext())
            {
                return BankingSystemDAO.GetUserData(context, id);
            }
        }

        public App_User GetAdminData()
        {
            using (var context = new BankingSystemContext())
            {
                return BankingSystemDAO.GetAdminData(context);
            }
        }
        public void RemoveUser(string id)
        {
            using (var context = new BankingSystemContext())
            {
                BankingSystemDAO.RemoveUser(context, id);
            }
        }
        public IList<App_User> GetUsers()
        {
            using (var context = new BankingSystemContext())
            {
                return BankingSystemDAO.GetUsers(context);
            }
        }
    }
}
