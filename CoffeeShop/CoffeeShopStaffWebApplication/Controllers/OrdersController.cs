using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace CoffeeShopWebApplication.Controllers
{
    public class OrdersController : Controller
    {
        public IOrderRepository orderRepository = new OrderRepository();
        public ICoffeeTablesRepository coffeeTablesRepository = new CoffeeTablesRepository();
        public IDrinksRepository drinkRepository = new DrinksRepository();
        public IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        public IAccountRepository accountRepository = new AccountRepository();

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        public IActionResult Create(int _tableId, int accId)
        {
            if (coffeeTablesRepository.CheckTableAvailable(_tableId).IsNullOrEmpty())
            {
                Order order = new Order();
                order.TableId = _tableId;
                order.OrderStatus = 0;
                order.OrderDate = DateTime.Now;
                order.AccountId = accId;
                orderRepository.AddOrder(order);
            }
            return RedirectToAction("CreateNew", "OrderDetails", new { orderId = orderRepository.GetOrderJustCreate(_tableId).OrderId });
        }

        public IActionResult Payment(int orderId)
        {
            var order = orderRepository.GetOrderbyId(orderId);
            if (order.OrderStatus == 0)
            {

                ViewData["TableId"] = coffeeTablesRepository.GetCoffeeTablebyId(order.TableId).TableNumber;
                ViewData["OrderId"] = orderId;
                ViewData["Account"] = accountRepository.GetAccountById(order.AccountId);
                // ViewData["DrinkId"] = new SelectList(drinkRepository.GetAllDrinks(), "DrinkId", "DrinkName");
                ViewData["DrinkName"] = drinkRepository.GetAllDrinks();
                ViewData["ListDrink"] = orderDetailRepository.GetOrderDetail(order.OrderId);
            }



            return View(order);
        }

        public IActionResult EditStatus(int orderId)
        {
            var orderPayment = orderRepository.GetOrderbyId(orderId);
            if (orderPayment != null)
            {
                orderPayment.OrderStatus = 1;
                orderRepository.UpdateOrder(orderPayment);
            }
            
            
            return RedirectToAction("Index", "CoffeeTables", new {accId = orderPayment.AccountId} );

        }

        public IActionResult Delete(int orderId)
        {
            if (orderId.ToString() == null )
            {
                return NotFound();
            }
            var order = orderRepository.GetOrderbyId(orderId);
            int? accountId = order.AccountId;

            if (orderDetailRepository.GetOrderDetail(orderId).IsNullOrEmpty())
            {
                orderRepository.DeleteOrder(orderId);
                return RedirectToAction("Index", "CoffeeTables", new { accId = accountId });
            }
            else
            {
                return RedirectToAction("Index", "CoffeeTables", new { accId = accountId });
            }
            
        }

        // GET: Orders
        public IActionResult Index()
        {
            IDictionary<int,decimal> analysis = new Dictionary<int, decimal>();
            
            var orderList = orderRepository.GetAllOrders();
            

            foreach (var item in orderList)
            {
                item.Table = coffeeTablesRepository.GetCoffeeTablebyId(item.TableId);
                decimal sum = 0;
                var orderDetail = orderDetailRepository.GetOrderDetail(item.OrderId);
                foreach (var drink in orderDetail)
                {                 
                    var price = drinkRepository.GetDrinkbyId(drink.DrinkId).Price;
                    sum += drink.Quantity * price;
                }
                analysis[item.OrderId] = sum;
            }
            ViewData["Analysis"] = analysis;
            //orderList.
            //var orderDetail = orderList.FirstOrDefault().OrderDetails.FirstOrDefault();

            return View(orderList);
        }


        // GET: Orders/Details/5
        public IActionResult Details(int orderId)
        {
            if (orderId.ToString() == null)
            {
                return NotFound();
            }

            var order = orderRepository.GetOrderbyId(orderId);
            ICollection<OrderDetail> a = orderDetailRepository.GetOrderDetail(orderId).ToList();
            order.OrderDetails = a;
            order.Table = coffeeTablesRepository.GetCoffeeTablebyId(order.TableId);
            order.Account = accountRepository.GetAccountById(order.AccountId);

            ViewData["Drinks"] = drinkRepository.GetAllDrinks();
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
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

