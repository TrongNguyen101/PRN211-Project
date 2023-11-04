using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CoffeeTablesRepository :ICoffeeTablesRepository
    {
        public CoffeeTable GetCoffeeTablebyId(int coffeeTableId) => CoffeeTableDAO.Instance.GetCoffeeTableById(coffeeTableId);
        public CoffeeTable GetCoffeeTablebyNumber(int coffeeTableNumber) => CoffeeTableDAO.Instance.GetCoffeeTableByNumber(coffeeTableNumber);
        
        public IEnumerable<CoffeeTable> GetAllCoffeeTables() => CoffeeTableDAO.Instance.GetCoffeeTableList();
        public void AddCoffeeTable(CoffeeTable coffeeTable) => CoffeeTableDAO.Instance.AddCoffeeTable(coffeeTable);
        public void DeleteCoffeeTable(int coffeeTableId) => CoffeeTableDAO.Instance.DeleteCoffeeTable(coffeeTableId);
        public bool CheckTableAvailable(int coffeeTableId) => CoffeeTableDAO.Instance.CheckTableAvailable(coffeeTableId);

       // public void UpdateCoffeeTable(CoffeeTable coffeeTable) => DrinksDAO.Instance.UpdateDrinks(drink);
    }
}
