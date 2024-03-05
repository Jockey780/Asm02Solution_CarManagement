using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
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

        public List<int> GetOrderDetailType()
        {
            List<int> OrderDetailTypes;
            try
            {
                var dbContext = new CarManagementContext();
                OrderDetailTypes = dbContext.Orders
                .Where(car => car.OrderId != null)
                .Select(car => car.OrderId)
                .Distinct()
                .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return OrderDetailTypes;
        }

        public List<OrderDetail> GetOrderDetailList()
        {
            List<OrderDetail> list = null;
            try
            {
                var dbContext = new CarManagementContext();
                list = dbContext.OrderDetails.Include(td => td.Order).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public List<OrderDetail> GetOrderDetail(int userID, int orderID)
        {
            List<OrderDetail> list = null;
            try
            {
                var dbContext = new CarManagementContext();
                list = dbContext.OrderDetails
                                .Join(dbContext.Orders,
                                      td => td.OrderId,
                                      bt => bt.OrderId,
                                      (td, bt) => new { OrderDetail = td, Order = bt })
                                .Where(joinResult => joinResult.Order.UserId == userID &&
                                                    joinResult.OrderDetail.OrderId == orderID)
                                .Select(joinResult => joinResult.OrderDetail)
                                .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public OrderDetail GetOrderDetailByID(int orderID)
        {
            OrderDetail orderDetail = null;
            try
            {
                var dbContext = new CarManagementContext();
                orderDetail = dbContext.OrderDetails.SingleOrDefault(c => c.OrderId == orderID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public OrderDetail CreateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                if (orderDetail != null)
                {
                    var dbContext = new CarManagementContext();
                    dbContext.OrderDetails.Add(orderDetail);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public OrderDetail UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                if (orderDetail != null)
                {
                    var dbContext = new CarManagementContext();
                    dbContext.OrderDetails.Update(orderDetail);
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
            return orderDetail;
        }

        public OrderDetail DeleteOrderDetail(int orderDetailID)
        {
            OrderDetail orderDetail = GetOrderDetailByID(orderDetailID) ;
            if (orderDetail != null)
            {
                var dbContext = new CarManagementContext();
                dbContext.OrderDetails.Remove(orderDetail);
                dbContext.SaveChanges();
            }
            return orderDetail;
        }
    }
}
