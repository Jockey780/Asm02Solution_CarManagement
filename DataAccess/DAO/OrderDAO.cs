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

        public Order GetOrderByID(int id)
        {
            Order order = null;
            try
            {
                var dbContext = new CarManagementContext();
                order = dbContext.Orders.SingleOrDefault(c => c.OrderId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public Order CreateOrders(Order order)
        {
            try
            {
                if (order != null)
                {
                    var dbContext = new CarManagementContext();
                    dbContext.Orders.Add(order);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public Order UpdateOrder(Order order)
        {
            try
            {
                if (order != null)
                {
                    var dbContext = new CarManagementContext();
                    dbContext.Orders.Update(order);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("The order is not existed.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public Order DeleteOrder(int orderID)
        {
            Order order = GetOrderByID(orderID);
            try
            {
                if (order != null)
                {
                    var dbContext = new CarManagementContext();
                    dbContext.Orders.Remove(order);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }
    }
}
