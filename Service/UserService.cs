using BusinessObjects.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }

        public User CreateUserAccounts(User user)
        {
            return userRepository.CreateUserAccounts(user);
        }

        public bool DeleteUser(int userId) => userRepository.DeleteUser(userId);

        public int GetNumberOfUserAccounts()
        {
            return userRepository.GetNumberOfUserAccounts();
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return userRepository.GetUserByEmailAndPassword(email, password);
        }

        public User GetUserByID(int id)
        {
            return userRepository.GetUserByID(id);
        }

        public List<User> GetUsersList()
        {
            return userRepository.GetUsersList();
        }

        public List<int> GetUserTypeList()
        {
            return userRepository.GetUserTypeList();
        }

        public List<User> SearchUsers(string searchTerm)
        {
            return userRepository.SearchUsers(searchTerm);
        }

        public User UpdateUsersAccount(User user)
        {
            return userRepository.UpdateUsersAccount(user);
        }
    }
}
