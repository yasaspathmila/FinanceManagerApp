using MongoDB.Driver;
using PersonalFinanceManager.Models;
using PersonalFinanceManager.Utils;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            string hashedPassword = HashPassword(password);
            var user = new User { Username = username, Password = hashedPassword };
            _users.InsertOne(user);
            return true;
        }

        // Method to create a hashed password
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash as byte array
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Method to verify a password against a hashed password
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredHash = HashPassword(enteredPassword);
            return StringComparer.OrdinalIgnoreCase.Compare(enteredHash, storedHash) == 0;
        }

        public  bool AuthenticateUser(string username, string password)
        {
            var user =  _users.Find(u => u.Username == username).Project(u => new { Username = u.Username, Password = u.Password }).FirstOrDefaultAsync();
            if (user != null && VerifyPassword(password ,user.Result.Password ))
            {
                return true;
            }
            return false;
        }
    }
}
