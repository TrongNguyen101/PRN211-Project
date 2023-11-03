using BusinessObject;
namespace DataAccess
{
    public class OrderDAO
    {
        #region Singleton Pattern
        private static OrderDAO instance;
        private static readonly object lockInstance = new object();
        public static OrderDAO Instance
        {
            get
            {
                lock(lockInstance)
                {
                    if(instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region Get Order List
        public IEnumerable<Order> GetOrderList()
        {
            var ordersList = new List<Order>();
            try
            {
                using var context = new CoffeeShopContext();
                ordersList = context.Orders.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return ordersList;
        }
        #endregion

        #region Get Order By TableId
        public Order GetOrderByTableId(int tableId) 
        {
            Order table = null;
            try
            {
                using var context = new CoffeeShopContext();
                table = context.Orders.SingleOrDefault(t => t.TableId == tableId);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return table;
        }
        #endregion




        #region Get Order By Id
        public Order GetOrderById(int orderId)
        {
            Order order = null;
            try
            {
                using var context = new CoffeeShopContext();
                order = context.Orders.SingleOrDefault(o => o.OrderId == orderId);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return order;
        }
        #endregion

        #region Add New Order
        public void AddOrder(Order order)
        {
            try
            {
                Order _order = GetOrderById(order.OrderId);
                if (_order == null)
                {
                    using var context = new CoffeeShopContext();
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order is already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Update Order
        public void UpdateOrder(Order order)
        {
            try
            {
                Order _order = GetOrderById(order.OrderId);
                if (_order != null)
                {
                    using var context = new CoffeeShopContext();
                    context.Orders.Update(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Remove order
        public void DeleteOrder(int orderId)
        {
            try
            {
                if (orderId.ToString() != null)
                {
                    Order order = GetOrderById(orderId);
                    using var context = new CoffeeShopContext();
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
