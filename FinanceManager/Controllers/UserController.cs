using MongoDB.Driver;
using PersonalFinanceManager.Models;
using PersonalFinanceManager.Utils;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Controllers
{
    public class UserController
    {
        private readonly IMongoCollection<User> _users;

        public UserController()
        {
            _users = DatabaseHelper.GetCollection<User>("Users");
        }

        public bool RegisterUser(string username, string password)
        {
            if (_users.Find(u => u.Username == username).Any()) return false;

            var user = new User { Username = username, Password = password };
            _users.InsertOne(user);
            return true;
        }

        public bool LoginUser(string username, string password)
        {
            var user = _users.Find(u => u.Username == username && u.Password == password).FirstOrDefault();
            return user != null;
        }

        public  bool AuthenticateUser(string username, string password)
        {
            var user =  _users.Find(u => u.Username == username).Project(u => new { Username = u.Username, Password = u.Password }).FirstOrDefaultAsync();
            if (user != null && user.Result.Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
