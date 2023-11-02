using BusinessObject;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrtherbyId(int orderId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
    }
}
