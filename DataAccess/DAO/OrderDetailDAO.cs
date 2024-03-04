using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private readonly CarManagementContext dbContext = null;

        private OrderDetailDAO()
        {
            dbContext = new CarManagementContext();
        }
        public static OrderDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDetailDAO();
                }
                return instance;
            }
        }
    }
}
