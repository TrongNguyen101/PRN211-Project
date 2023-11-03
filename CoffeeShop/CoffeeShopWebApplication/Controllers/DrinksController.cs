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
    public class DrinksController : Controller
    {
        public IDrinksRepository drinksRepository = null;
        public DrinksController() => drinksRepository = new DrinksRepository();

        

        // GET: Drinks
        public IActionResult Index()
        {
            var drinksList = drinksRepository.GetAllDrinks();
            return View(drinksList);
        }
        
        // GET: Drinks/Details/5
        public IActionResult Details(int id)
        {
            if (id == null || drinksRepository.GetAllDrinks().ToList() == null)
            {
                return NotFound();
            }

            var drink = drinksRepository.GetDrinkbyId(id);
            if (drink == null)
            {
                return NotFound();
            }

            return View(drink);
        }
        
        // GET: Drinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("DrinkId,DrinkName,Price,Status,TypeOfDrink")] Drink drink)
        {
            if (ModelState.IsValid)
            {
                drinksRepository.AddDrink(drink);
                return RedirectToAction(nameof(Index));
            }
            return View(drink);
        }

        // GET: Drinks/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null || drinksRepository.GetAllDrinks().ToList() == null)
            {
                return NotFound();
            }

            var drink = drinksRepository.GetDrinkbyId(id);
            if (drink == null)
            {
                return NotFound();
            }
            return View(drink);
        }
       
        // POST: Drinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("DrinkId,DrinkName,Price,Status,TypeOfDrink")] Drink drink)
        {
            if (id != drink.DrinkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    drinksRepository.UpdateDrink(drink);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (drink.DrinkId.ToString() == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(drink);
        }
        
       // GET: Drinks/Delete/5
       public IActionResult Delete(int id)
       {
           if (id.ToString() == null || drinksRepository.GetAllDrinks().ToList() == null)
           {
               return NotFound();
           }

           var drink = drinksRepository.GetDrinkbyId(id);
            if (drink == null)
           {
               return NotFound();
           }

           return View(drink);
       }

       // POST: Drinks/Delete/5
       [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> DeleteConfirmed(int id)
       {
           if (drinksRepository.GetAllDrinks().ToList() == null)
           {
               return Problem("Entity set 'CoffeeShopContext.Drinks'  is null.");
           }
           var drink = drinksRepository.GetDrinkbyId(id);
            if (drink != null)
           {
               drinksRepository.DeleteDrink(id);
           }

           return RedirectToAction(nameof(Index));
       }

       
       
    }
}
