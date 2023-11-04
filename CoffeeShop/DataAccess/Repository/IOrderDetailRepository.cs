using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetail(int orderId);
        OrderDetail GetOrderDetailByIdDrinkAndOrder(int orderId, int drinkId);
        void AddDrinkDetail(OrderDetail drinkDetail);
        void UpdateDrinkDetail(int orderId, int drinkId);
        void DeleteDrinkDetail(int orderId, int drinkId);
    }
}
