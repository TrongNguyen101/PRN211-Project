using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using DataAccess.Repository;

namespace CoffeeShopWebApplication.Controllers
{
    public class CoffeeTablesController : Controller
    {
        public ICoffeeTablesRepository coffeeTablesRepository = new CoffeeTablesRepository();
        // public CoffeeTablesController() => coffeeTablesRepository = new CoffeeTablesRepository();

        // GET: CoffeeTables
        public IActionResult Index()
        {
            var orderList = coffeeTablesRepository.GetAllCoffeeTables();
            return View(orderList);
        }


        // GET: CoffeeTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoffeeTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TableId,TableNumber")] CoffeeTable coffeeTable)
        {
            if (ModelState.IsValid)
            {
                if (coffeeTablesRepository.GetCoffeeTablebyNumber(coffeeTable.TableNumber) == null)
                {
                    coffeeTablesRepository.AddCoffeeTable(coffeeTable);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["ReponeCreateCoffeTable"] = "The number of table is exist";
                    return View(coffeeTable);
                }

            } else
            {
                return View(coffeeTable);
            }

        }



        // GET: CoffeeTables/Delete/5
        public IActionResult Delete(int id)
        {
            if (id.ToString() == null || coffeeTablesRepository.GetCoffeeTablebyId(id) == null)
            {
                return NotFound();
            }

            var order = coffeeTablesRepository.GetCoffeeTablebyId(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: CoffeeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (coffeeTablesRepository.GetCoffeeTablebyId(id) == null)
            {
                return Problem("Entity set 'CoffeeShopContext.Orders'  is null.");
            }
            var order = coffeeTablesRepository.GetCoffeeTablebyId(id);
            if (order != null)
            {
                coffeeTablesRepository.DeleteCoffeeTable(id);
            }


            return RedirectToAction(nameof(Index));
        }


    }
}
