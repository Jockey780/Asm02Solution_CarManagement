using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        public User GetUserByEmailAndPassword(string email, string password);
        public int GetNumberOfUserAccounts();
        public List<User> GetUsersList();
        public User CreateUserAccounts(User user);
    }
}
