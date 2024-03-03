using BusinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public int GetNumberOfUserAccounts() => UserDAO.Instance.GetNumberOfUserAccounts();
        public User GetUserByEmailAndPassword(string email, string password) => UserDAO.Instance.GetUserByEmailAndPassword(email, password);
        public User CreateUserAccounts(User user) => UserDAO.Instance.CreateUserAccounts(user);
        public List<User> GetUsersList() => UserDAO.Instance.GetUsersList();
    }
}
