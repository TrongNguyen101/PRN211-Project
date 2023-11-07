using BusinessObject;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderJustCreate(int tableId);
        Order GetTableJustCreateOrder(int orderId);
        Order GetOrderbyId(int orderId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
        CoffeeTable GetTableNumberJustCreate(int tableId);
    }
}
