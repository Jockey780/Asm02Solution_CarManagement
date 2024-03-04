using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IOrderDetailService
    {
        public List<OrderDetail> GetOrderDetailList();
        public List<OrderDetail> GetOrderDetail(int userID, int orderID);
    }
}
