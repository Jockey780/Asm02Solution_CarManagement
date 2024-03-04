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
    }
}
