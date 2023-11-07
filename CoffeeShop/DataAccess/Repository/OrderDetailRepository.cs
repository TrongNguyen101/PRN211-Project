using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository

    {
        public IEnumerable<OrderDetail> GetOrderDetail(int orderId) => OrderDetailDAO.Instance.GetOrderDetail(orderId);
        public void AddDrinkDetail(OrderDetail drinkDetail) => OrderDetailDAO.Instance.AddDrinkDetail(drinkDetail);
        public void UpdateDrinkDetail(OrderDetail drinkDetail) => OrderDetailDAO.Instance.UpdateOrderDetail(drinkDetail);
        public void DeleteDrinkDetail(int orderId, int drinkId) => OrderDetailDAO.Instance.DeleteOrderDetail(orderId, drinkId);
        public OrderDetail GetOrderDetailByIdDrinkAndOrder(int orderId, int drinkId) => OrderDetailDAO.Instance.GetOrderDetailByIdDrinkAndOrder(orderId,drinkId);
    }
}
