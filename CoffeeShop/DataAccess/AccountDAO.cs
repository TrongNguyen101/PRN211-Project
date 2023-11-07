using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess
{
    public class AccountDAO
    {
        #region Singleton pattern
        private static AccountDAO instance;
        private static readonly object lockInstance = new object();
        public static AccountDAO Instance
        {
            get
            {
                lock (lockInstance)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }
        #endregion
        [return: MaybeNull]
        public Account GetAccountToLogin(string username, string password)
        {

            try
            {
                using var context = new CoffeeShopContext();
                var account = from acc in context.Accounts
                              where acc.UserName == username && acc.Password == password 
                              select acc;


                if (account == null)
                {
                    return null;
                }
                return account.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Account GetAccountById(int? accountId)
        {

            var account = new Account();
            try
            {
                using var context = new CoffeeShopContext();
                account = context.Accounts.SingleOrDefault(d => d.AccountId == accountId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return account;
        }

        #region Get Account List
        public IEnumerable<Account> GetAccountsList()
        {
            var accountList = new List<Account>();
            try
            {
                using var context = new CoffeeShopContext();
                accountList = context.Accounts.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return accountList;
        }
        #endregion

        #region Add New Account
        public void AddAccount(Account account)
        {
            try
            {
                Account _drink = GetAccountById(account.AccountId);
                if (_drink == null)
                {
                    using var context = new CoffeeShopContext();
                    context.Accounts.Add(account);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The account is already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Update Account
        public void UpdateAccount(Account account)
        {
            try
            {
                Account _account = GetAccountById(account.AccountId);
                if (_account != null)
                {
                    using var context = new CoffeeShopContext();
                    context.Accounts.Update(account);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The account does not already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Remove Account
        public void DeleteAccount(int accountId)
        {
            try
            {
                if (accountId.ToString() != null)
                {
                    Account account = GetAccountById(accountId);
                    using var context = new CoffeeShopContext();
                    context.Accounts.Remove(account);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The account does not already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
