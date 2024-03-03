using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IUserRepository
    {
        public User GetUserByEmailAndPassword(string email, string password);
        public int GetNumberOfUserAccounts();
        public List<User> GetUsersList();
        public User CreateUserAccounts(User user);
    }
}
