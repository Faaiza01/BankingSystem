using BankingSystem.Data.IDAO;
using BankingSystem.Data.Models.Domain;
using BankingSystem.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BankingSystem.Services.Models;

namespace BankingSystem.Data.DAO
{
    public class BankingSystemDAO : IBankingSystemDAO
    {
        public App_User GetUserData(BankingSystemContext context, string id)
        {
            return context.AppUsers.ToList().Find(b => b.IdentityId == id);
        }
        public App_User GetAdminData(BankingSystemContext context)
        {
            return context.AppUsers.ToList().Find(b => b.Role == "Admin");
        }
        public IList<App_User> GetUsers(BankingSystemContext context)
        {
            return context.AppUsers.Where(x=> x.Role == "Customer").ToList();
        }
        public void DepositCash(BankingSystemContext context, Transaction transaction)
        {
            context.Transactions.Add(transaction);
            context.SaveChanges();


            var transactionBy = context.AppUsers.Where(x => x.IdentityId == transaction.TransactionBy).FirstOrDefault();
            context.AppUsers.Find(transactionBy.UserId).CurrentBalance = transactionBy.CurrentBalance - transaction.AmountToBeProcessed;
            context.SaveChanges();

            var transactionTo = context.AppUsers.Where(x => x.IdentityId == transaction.TransactionTo).FirstOrDefault();
            context.AppUsers.Find(transactionTo.UserId).CurrentBalance = transactionTo.CurrentBalance + transaction.AmountToBeProcessed; 
            context.SaveChanges();
        }

        public void WithDrawCash(BankingSystemContext context, Transaction transaction)
        {
            context.Transactions.Add(transaction);
            context.SaveChanges();


            var transactionBy = context.AppUsers.Where(x => x.IdentityId == transaction.TransactionBy).FirstOrDefault();
            context.AppUsers.Find(transactionBy.UserId).CurrentBalance = transactionBy.CurrentBalance - transaction.AmountToBeProcessed;
            context.SaveChanges();
        }

        public List<MyTransactionsDto> GetTransactionHistory(BankingSystemContext context, string id)
        {
            List<MyTransactionsDto> myTransactionsDtos = new List<MyTransactionsDto>();

            var myTransactions = context.Transactions.Where(b => b.TransactionBy == id).ToList();
            var transactionBy = context.AppUsers.Where(b => b.IdentityId == id).FirstOrDefault();

            foreach (var item in myTransactions)
            {
                App_User transactionTo = new App_User();
                if (item.TransactionTo!=null)
                {
                     transactionTo = context.AppUsers.Where(b => b.IdentityId == item.TransactionTo).SingleOrDefault();
                }

                MyTransactionsDto myTransactionsDto = new MyTransactionsDto();
                myTransactionsDto.AccountNumber = transactionTo.AccountNumber;
                myTransactionsDto.AmountToBeProcessed = item.AmountToBeProcessed;
                myTransactionsDto.TransactionType = item.TransactionType;
                myTransactionsDto.TransactionDate = item.TransactionDate;
                myTransactionsDto.CurrentBalance = transactionBy.CurrentBalance;
                myTransactionsDto.TransactionTo = transactionTo?.FirstName + " " + transactionTo?.LastName;
                myTransactionsDto.TransactionBy = transactionBy.FirstName + " " + transactionBy.LastName;
                myTransactionsDtos.Add(myTransactionsDto);
            }
            return myTransactionsDtos;
        }
        public List<MyTransactionsDto> GetAdminTransactionHistory(BankingSystemContext context)
        {
            List<MyTransactionsDto> myTransactionsDtos = new List<MyTransactionsDto>();
            var alltransactions = context.Transactions.ToList();

            foreach (var item in alltransactions)
            {
                App_User transactionTo = new App_User();
                if (item.TransactionTo != null)
                {
                    transactionTo = context.AppUsers.Where(b => b.IdentityId == item.TransactionTo).SingleOrDefault();
                }

                App_User transactionBy = new App_User();
                if (item.TransactionBy != null)
                {
                    transactionBy = context.AppUsers.Where(b => b.IdentityId == item.TransactionBy).SingleOrDefault();
                }
                MyTransactionsDto myTransactionsDto = new MyTransactionsDto();
                myTransactionsDto.AccountNumber = transactionTo.AccountNumber;
                myTransactionsDto.AmountToBeProcessed = item.AmountToBeProcessed;
                myTransactionsDto.TransactionType = item.TransactionType;
                myTransactionsDto.TransactionDate = item.TransactionDate;
                myTransactionsDto.CurrentBalance = transactionBy.CurrentBalance;
                myTransactionsDto.TransactionTo = transactionTo?.FirstName + " " + transactionTo?.LastName;
                myTransactionsDto.TransactionBy = transactionBy.FirstName + " " + transactionBy.LastName;
                myTransactionsDtos.Add(myTransactionsDto);
            }
            return myTransactionsDtos;
        }
        public void AddUser(BankingSystemContext context, App_User app_User)
        {
            context.AppUsers.Add(app_User);
            context.SaveChanges();
        }

        public void RemoveUser(BankingSystemContext context, string identityId)
        {
            context.AppUsers.Remove(context.AppUsers.Where(c => c.IdentityId == identityId).FirstOrDefault());
            context.SaveChanges();
        }

    }

}
