using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        #region Singleton Pattern
        private static OrderDetailDAO instance;
        private static readonly object lockInstance = new object();
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (lockInstance)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region Get list of drink in Order
        public IEnumerable<OrderDetail> GetOrderDetail(int orderId)
        {
            var drinkList = new List<OrderDetail>();
            try
            {
                using var context = new CoffeeShopContext();
                drinkList = context.OrderDetails.Where(p => p.OrderId == orderId).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return drinkList;
        }
        #endregion


        #region Get drink detail by id orther and id drink
        public OrderDetail GetOrderDetailByIdDrinkAndOrder(int orderId, int drinkId)
        {
            OrderDetail orderDetail = null;
            try
            {
                using var context = new CoffeeShopContext();
                orderDetail = context.OrderDetails.SingleOrDefault(o => o.OrderId == orderId && o.DrinkId == drinkId);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return orderDetail;
        }
        #endregion


        #region Add drink detail into order

        public void AddDrinkDetail(OrderDetail drinkDetail)
        {
            try
            {
                using var context = new CoffeeShopContext();
                context.OrderDetails.Add(drinkDetail);
                context.SaveChanges();
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Remove drink detail
        public void DeleteOrderDetail(int orderId, int drinkId)
        {
            try
            {
                
                {
                    OrderDetail orderDetail = GetOrderDetailByIdDrinkAndOrder(orderId, drinkId);
                    using var context = new CoffeeShopContext();
                    context.OrderDetails.Remove(orderDetail);
                    context.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Update Drinks
        public void UpdateOrderDetail(OrderDetail newOrderDetail)
        {
            try
            {
               
                    using var context = new CoffeeShopContext();
                    context.OrderDetails.Update(newOrderDetail);
                    context.SaveChanges();
                
                    
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
