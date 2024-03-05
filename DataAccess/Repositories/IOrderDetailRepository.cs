using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetailList();
        public List<OrderDetail> GetOrderDetail(int userID, int orderID);
        public List<int> GetOrderDetailType();
        public OrderDetail GetOrderDetailByID(int orderID);
        public OrderDetail CreateOrderDetail(OrderDetail orderDetail);
        public OrderDetail UpdateOrderDetail(OrderDetail orderDetail);
        public OrderDetail DeleteOrderDetail(int orderDetailID);
    }
}
