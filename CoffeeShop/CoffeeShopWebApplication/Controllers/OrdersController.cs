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
    public class OrdersController : Controller
    {
        public IOrderRepository orderRepository = new OrderRepository();
        public IDrinksRepository drinkRepository = new DrinksRepository();
        public OrdersController() => orderRepository = new OrderRepository();

        // GET: Orders
        public IActionResult Index()
        {
            
            var orderList = orderRepository.GetAllOrders();
            return View(orderList);
        }

        // GET: Orders/Details/5
        public IActionResult Details(int id)
        {
            if (id.ToString() == null || orderRepository.GetOrtherbyId(id) == null)
            {
                return NotFound();
            }

            var order = orderRepository.GetOrtherbyId(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            //ViewData["DrinksId"] = new SelectList(_context.Drinks, "DrinksId", "DrinksName");

            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("OrderId,DrinksId,DrinkQuantity,DrinkNote,TimeOrder,Total,StatusOrder,TableId")] Order order)
        {
            if (ModelState.IsValid)
            {
                orderRepository.AddOrder(order);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrinksId"] = new SelectList(drinksRepository.GetAll(), "DrinksId", "DrinksName", order.DrinksId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public IActionResult Edit(int id)
        {
            if (id.ToString() == null || orderRepository.GetOrtherbyId(id) == null)
            {
                return NotFound();
            }

            var order = orderRepository.GetOrtherbyId(id);
            if (order == null)
            {
                return NotFound();
            }
            //ViewData["DrinksId"] = new SelectList(_context.Drinks, "DrinksId", "DrinksName", order.DrinksId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("OrderId,DrinksId,DrinkQuantity,DrinkNote,TimeOrder,Total,StatusOrder,TableId")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    orderRepository.UpdateOrder(order);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (orderRepository.GetOrtherbyId(id) == null)
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
           // ViewData["DrinksId"] = new SelectList(_context.Drinks, "DrinksId", "DrinksName", order.DrinksId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public IActionResult Delete(int id)
        {
            if (id.ToString() == null || orderRepository.GetOrtherbyId(id) == null)
            {
                return NotFound();
            }

            var order = orderRepository.GetOrtherbyId(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (orderRepository.GetOrtherbyId(id) == null)
            {
                return Problem("Entity set 'CoffeeShopContext.Orders'  is null.");
            }
            var order = orderRepository.GetOrtherbyId(id);
            if (order != null)
            {
                orderRepository.DeleteOrder(id);
            }
            
            
            return RedirectToAction(nameof(Index));
        }

        
    }
}
