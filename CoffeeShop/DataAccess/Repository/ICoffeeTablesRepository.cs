using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ICoffeeTablesRepository
    {
        IEnumerable<CoffeeTable> GetAllCoffeeTables();
        CoffeeTable GetCoffeeTablebyId(int coffeeTableId);
       
        CoffeeTable GetCoffeeTablebyNumber(int coffeeTableNumber);
        void AddCoffeeTable(CoffeeTable coffeeTable);
       // void UpdateCoffeeTable(CoffeeTable coffeeTable);
        void DeleteCoffeeTable(int coffeeTableId);
        IEnumerable<Order> CheckTableAvailable(int coffeeTableId);

    }
}
