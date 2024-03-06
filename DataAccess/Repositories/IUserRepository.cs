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
        public User GetUserByID(int id);
        public User CreateUserAccounts(User user);
        public User UpdateUsersAccount(User user);
        public List<User> SearchUsers(string searchTerm);
        public bool DeleteUser(int userId);
        public List<int> GetUserTypeList();
        public int GetNextUserId();
        Task<int> AddUserAsync(User user);
    }
}
