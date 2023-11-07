using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetAccountToLogin(string username, string password) => AccountDAO.Instance.GetAccountToLogin(username, password);
        public Account GetAccountById(int? accountId) => AccountDAO.Instance.GetAccountById(accountId);
        public IEnumerable<Account> GetAllAccounts() => AccountDAO.Instance.GetAccountsList();
        public void AddAccount(Account account) => AccountDAO.Instance.AddAccount(account);
        public void UpdateAccount(Account account) => AccountDAO.Instance.UpdateAccount(account);    
        public void DeleteAccount(int accountId) => AccountDAO.Instance.DeleteAccount(accountId);
    }
}
