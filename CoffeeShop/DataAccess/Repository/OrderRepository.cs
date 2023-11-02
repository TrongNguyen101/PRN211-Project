using BusinessObject;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Order GetOrtherbyId(int id) => OrderDAO.Instance.GetOrderById(id);
        public IEnumerable<Order> GetAllOrders() => OrderDAO.Instance.GetOrderList();
        public void AddOrder(Order order) => OrderDAO.Instance.AddOrder(order);
        public void DeleteOrder(int orderId) => OrderDAO.Instance.DeleteOrder(orderId);
        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);
    }
}
