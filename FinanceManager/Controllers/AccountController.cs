using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using PersonalFinanceManager.Models;
using PersonalFinanceManager.Utils;

namespace PersonalFinanceManager.Controllers
{
    public class AccountController
    {
        private readonly IMongoCollection<Account> _accounts;

        public AccountController()
        {
            _accounts = DatabaseHelper.GetCollection<Account>("Accounts");
        }

        public void AddAccount(Account account)
        {
            _accounts.InsertOne(account);
        }

        public Account GetAccountById(string accountId)
        {
            return _accounts.Find(a => a.Id == accountId).FirstOrDefault();
        }

        public List<Account> GetAccountsByUserId(string userName)
        {
            return _accounts.Find(a => a.UserId == userName).ToList();
        }

        public void UpdateAccountBalance(string accountId, double newBalance)
        {
            var filter = Builders<Account>.Filter.Eq(a => a.Id, accountId);
            var update = Builders<Account>.Update.Set(a => a.Balance, newBalance);
            _accounts.UpdateOne(filter, update);
        }

        public double GetAccountBalance(string userName)
        {
            Account account = _accounts.Find(a => a.UserId == userName).FirstOrDefault();
            return account.Balance;
        }
    }
}
