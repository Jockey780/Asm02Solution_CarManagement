using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDAO
    {
        private static UserDAO instance = null;
        private readonly CarManagementContext dbContext = null;

        private UserDAO()
        {
            dbContext = new CarManagementContext();
        }
        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            var user = dbContext.Users.SingleOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                User mappedUser = new User
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    UserName = user.UserName,
                    City = user.City,
                    Country = user.Country,
                    Password = user.Password,
                    Birthday = user.Birthday,
                    Role = user.Role
                };
                return mappedUser;
            }
            return null;
        }
        public List<User> GetUsersList()
        {
            return dbContext.Users.ToList();
        }

        // thêm hàm này để hiện tổng User account trên dashboard
        public int GetNumberOfUserAccounts()
        {
            int NumberOfUserAccounts = 0;
            try
            {
                var dbContext = new CarManagementContext();
                NumberOfUserAccounts = dbContext.Users.Count(m => m.Role == "Customer");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NumberOfUserAccounts;
        }

        public User GetUserByEmail(string email)
        {
            User user = null;
            try
            {
                var dbContext = new CarManagementContext();
                user = dbContext.Users.SingleOrDefault(m => m.Email.Equals(email));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public User CreateUserAccounts(User user)
        {
            User _customer = GetUserByEmail(user.Email);
            try
            {
                if (_customer == null)
                {
                    var dbContext = new CarManagementContext();
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _customer;
        }
    }
}
