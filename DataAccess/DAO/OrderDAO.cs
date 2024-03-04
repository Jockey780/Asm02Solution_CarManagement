using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private readonly CarManagementContext dbContext = null;

        private OrderDAO()
        {
            dbContext = new CarManagementContext();
        }
        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }

        public int GetNumberOfOrders()
        {
            int NumberOfOrders = 0;
            try
            {
                var dbContext = new CarManagementContext();
                NumberOfOrders = dbContext.Orders.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NumberOfOrders;
        }

        public List<Order> GetOrdersList()
        {
            return dbContext.Orders.ToList();
        }
    }
}
