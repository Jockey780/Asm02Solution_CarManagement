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

        public List<OrderDetail> GetOrderDetail(int userID, int orderID)
        {
            return orderDetailRepository.GetOrderDetail(userID, orderID);
        }

        public List<OrderDetail> GetOrderDetailList()
        {
            return orderDetailRepository.GetOrderDetailList();
        }
    }
}
