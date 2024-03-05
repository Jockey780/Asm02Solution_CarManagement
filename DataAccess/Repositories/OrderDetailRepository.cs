using BusinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetailList() => OrderDetailDAO.Instance.GetOrderDetailList();
        public List<OrderDetail> GetOrderDetail(int userID, int orderID) => OrderDetailDAO.Instance.GetOrderDetail(userID, orderID);
        public List<int> GetOrderDetailType() => OrderDetailDAO.Instance.GetOrderDetailType();
        public OrderDetail GetOrderDetailByID(int orderID) => OrderDetailDAO.Instance.GetOrderDetailByID(orderID);
        public OrderDetail CreateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.CreateOrderDetail(orderDetail);
        public OrderDetail UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.UpdateOrderDetail(orderDetail);
        public OrderDetail DeleteOrderDetail(int orderDetailID) => OrderDetailDAO.Instance.DeleteOrderDetail(orderDetailID);
    }
}
