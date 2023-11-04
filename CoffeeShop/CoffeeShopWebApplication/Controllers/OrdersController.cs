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
        public ICoffeeTablesRepository coffeeTablesRepository = new CoffeeTablesRepository();

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        public IActionResult Create(int _tableId)
        {
            
            
            if (!coffeeTablesRepository.CheckTableAvailable(_tableId))
            {
                Order order = new Order();
                order.TableId = _tableId;
                order.OrderStatus = 0;
                order.OrderDate = DateTime.Now;
                //order.AccountId = 1;
                orderRepository.AddOrder(order);

            }

            return RedirectToAction("Create", "OrderDetails", new { tableId = _tableId });



        }
       





    }
}






















/*
// GET: Orders
public async Task<IActionResult> Index()
{
    var coffeeShopContext = _context.Orders.Include(o => o.Account).Include(o => o.Table);
    return View(await coffeeShopContext.ToListAsync());
}

// GET: Orders/Details/5
public async Task<IActionResult> Details(int? id)
{
    if (id == null || _context.Orders == null)
    {
        return NotFound();
    }

    var order = await _context.Orders
        .Include(o => o.Account)
        .Include(o => o.Table)
        .FirstOrDefaultAsync(m => m.OrderId == id);
    if (order == null)
    {
        return NotFound();
    }

    return View(order);
}

// GET: Orders/Create
public IActionResult Create()
{
    ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Password");
    ViewData["TableId"] = new SelectList(_context.CoffeeTables, "TableId", "TableId");
    return View();
}

// POST: Orders/Create
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("OrderId,TableId,OrderStatus,OrderDate,AccountId")] Order order)
{
    if (ModelState.IsValid)
    {
        _context.Add(order);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Password", order.AccountId);
    ViewData["TableId"] = new SelectList(_context.CoffeeTables, "TableId", "TableId", order.TableId);
    return View(order);
}

// GET: Orders/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null || _context.Orders == null)
    {
        return NotFound();
    }

    var order = await _context.Orders.FindAsync(id);
    if (order == null)
    {
        return NotFound();
    }
    ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Password", order.AccountId);
    ViewData["TableId"] = new SelectList(_context.CoffeeTables, "TableId", "TableId", order.TableId);
    return View(order);
}

// POST: Orders/Edit/5
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("OrderId,TableId,OrderStatus,OrderDate,AccountId")] Order order)
{
    if (id != order.OrderId)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderExists(order.OrderId))
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
    ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Password", order.AccountId);
    ViewData["TableId"] = new SelectList(_context.CoffeeTables, "TableId", "TableId", order.TableId);
    return View(order);
}

// GET: Orders/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null || _context.Orders == null)
    {
        return NotFound();
    }

    var order = await _context.Orders
        .Include(o => o.Account)
        .Include(o => o.Table)
        .FirstOrDefaultAsync(m => m.OrderId == id);
    if (order == null)
    {
        return NotFound();
    }

    return View(order);
}

// POST: Orders/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    if (_context.Orders == null)
    {
        return Problem("Entity set 'CoffeeShopContext.Orders'  is null.");
    }
    var order = await _context.Orders.FindAsync(id);
    if (order != null)
    {
        _context.Orders.Remove(order);
    }

    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

private bool OrderExists(int id)
{
  return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
}*/

