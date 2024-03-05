using BusinessObjects.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderDetailService : IOrderDetailService
    {
        private IOrderDetailRepository orderDetailRepository;
        public OrderDetailService()
        {
            orderDetailRepository = new OrderDetailRepository();
        }

        public OrderDetail CreateOrderDetail(OrderDetail orderDetail)
        {
            return orderDetailRepository.CreateOrderDetail(orderDetail);
        }

        public OrderDetail DeleteOrderDetail(int orderDetailID)
        {
            return orderDetailRepository.DeleteOrderDetail(orderDetailID);
        }

        public List<OrderDetail> GetOrderDetail(int userID, int orderID)
        {
            return orderDetailRepository.GetOrderDetail(userID, orderID);
        }

        public OrderDetail GetOrderDetailByID(int orderID)
        {
            return orderDetailRepository.GetOrderDetailByID(orderID);
        }

        public List<OrderDetail> GetOrderDetailList()
        {
            return orderDetailRepository.GetOrderDetailList();
        }

        public List<int> GetOrderDetailType()
        {
            return orderDetailRepository.GetOrderDetailType();
        }

        public OrderDetail UpdateOrderDetail(OrderDetail orderDetail)
        {
            return orderDetailRepository.UpdateOrderDetail(orderDetail);
        }
    }
}
