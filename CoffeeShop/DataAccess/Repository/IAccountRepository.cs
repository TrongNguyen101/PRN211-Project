using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IAccountRepository
    {
        Account GetAccountToLogin(string username, string password);
        Account GetAccountById(int? accountId);
        IEnumerable<Account> GetAllAccounts();
        void AddAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(int accountId);
    }
}
