using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CoffeeTableDAO
    {
        #region Singleton pattern
        private static CoffeeTableDAO instance;
        private static readonly object lockInstance = new object();
        private CoffeeShopContext context = new CoffeeShopContext();
        public static CoffeeTableDAO Instance
        {
            get
            {
                lock (lockInstance)
                {
                    if (instance == null)
                    {
                        instance = new CoffeeTableDAO();
                    }
                    return instance;
                }
            }
        }
        #endregion
        #region Get Coffee Table List
        public IEnumerable<CoffeeTable> GetCoffeeTableList()
        {
            var coffeeTableList = new List<CoffeeTable>();
            try
            {
                using var context = new CoffeeShopContext();
                coffeeTableList = context.CoffeeTables.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return coffeeTableList;
        }
        #endregion


        #region Get Coffee Table By Id
        public CoffeeTable GetCoffeeTableById(int coffeeTableId)
        {
            CoffeeTable coffeeTable = null;
            try
            {
                using var context = new CoffeeShopContext();
                coffeeTable = context.CoffeeTables.SingleOrDefault(d => d.TableId == coffeeTableId);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return coffeeTable;
        }
        #endregion
        #region Get Coffee Table By Number 
        public CoffeeTable GetCoffeeTableByNumber(int coffeeTableNumber)
        {
            CoffeeTable coffeeTable = null;
            try
            {
                using var context = new CoffeeShopContext();
                coffeeTable = context.CoffeeTables.SingleOrDefault(d => d.TableNumber == coffeeTableNumber);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return coffeeTable;
        }
        #endregion

        #region Add New Coffee Table
        public void AddCoffeeTable(CoffeeTable coffeeTable)
        {
            try
            {
                using var context = new CoffeeShopContext();
                context.CoffeeTables.Add(coffeeTable);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region Remove Coffee Table
        public void DeleteCoffeeTable(int coffeeTableId)
        {
            try
            {
                if (coffeeTableId.ToString() != null)
                {
                    CoffeeTable coffeeTable = GetCoffeeTableById(coffeeTableId);
                    using var context = new CoffeeShopContext();
                    context.CoffeeTables.Remove(coffeeTable);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The drinks does not already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region  check table available
        // write a function to check table is available or not 
        public IEnumerable<Order>  CheckTableAvailable(int tableId)
        {
            var check = from table in context.CoffeeTables
                        join order in context.Orders on table.TableId equals order.TableId
                        where order.OrderStatus == 0 && table.TableId == tableId
                        select order;
            //select new { TableId = tableId, OrderStatusSelect = OrderStatus.OrderStatus };
            var result = check.ToList();

            return result;

        }

        #endregion


    }
}
