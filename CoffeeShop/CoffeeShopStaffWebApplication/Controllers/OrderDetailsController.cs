﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using DataAccess.Repository;
using Microsoft.IdentityModel.Tokens;

namespace CoffeeShopWebApplication.Controllers
{
    public class OrderDetailsController : Controller
    {
        public IOrderRepository orderRepository = new OrderRepository();
        public IDrinksRepository drinkRepository = new DrinksRepository();
        public IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        public ICoffeeTablesRepository coffeeTablesRepository = new CoffeeTablesRepository();
        public IAccountRepository accountRepository = new AccountRepository();

        public IActionResult CreateNew(int orderId)
        {
            var order = orderRepository.GetOrderbyId(orderId);
            if (order.OrderStatus == 0)
            {

                ViewData["TableId"] = coffeeTablesRepository.GetCoffeeTablebyId(order.TableId).TableNumber;
                ViewData["Account"] = accountRepository.GetAccountById(order.AccountId);
                ViewData["Order"] = order;
                ViewData["DrinkId"] = new SelectList(drinkRepository.GetAllDrinks(), "DrinkId", "DrinkName");
                ViewData["DrinkName"] = drinkRepository.GetAllDrinks();
                ViewData["ListDrink"] = orderDetailRepository.GetOrderDetail(order.OrderId);
                //    var listOrderOnTable = new List<Order>();
                ////get all unpaid bills
                //foreach (var o in orderRepository.GetAllOrders())
                //{
                //    if (o.OrderStatus == 0)
                //    {
                //        listOrderOnTable.Add(o);
                //    }
                //}
                //send to view
                //ViewData["listTableHaveOrder"] = listOrderOnTable;
            }



            return View("Create");
        }


        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        public IActionResult Create([Bind("OrderId,DrinkId,Quantity,DrinkNote")] OrderDetail orderDetail)
        {

            //if (ModelState.IsValid)
            //{
            if (orderDetailRepository.GetOrderDetailByIdDrinkAndOrder(orderDetail.OrderId, orderDetail.DrinkId) == null)
            {
                orderDetailRepository.AddDrinkDetail(orderDetail);

                return RedirectToAction("CreateNew", "OrderDetails", new { orderId = orderDetail.OrderId });
            }
            else
            {
                orderDetailRepository.UpdateDrinkDetail(orderDetail);
                return RedirectToAction("CreateNew", "OrderDetails", new { orderId = orderDetail.OrderId });
            }
            //}
            //else
            //{
            //ViewData["DrinkId"] = new SelectList(drinkRepository.GetAllDrinks(), "DrinkId", "DrinkName");
            //ViewData["OrderId"] = orderDetail.OrderId;
            //return View(orderDetail);
            //}
        }

        // GET: OrderDetails/Edit/5
        public IActionResult EditForm(int orderId, int drinkId)
        {

            if (orderId.ToString().IsNullOrEmpty() || drinkId.ToString().IsNullOrEmpty() || orderDetailRepository.GetOrderDetail(orderId).IsNullOrEmpty())
            {
                return NotFound();
            }
            var drinkDetail = orderDetailRepository.GetOrderDetailByIdDrinkAndOrder(orderId, drinkId);

            if (drinkDetail == null)
            {
                return NotFound();
            }
            else
            {

            }
            return View("Edit", drinkDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        public IActionResult Edit([Bind("OrderId,DrinkId,Quantity,DrinkNote")] OrderDetail orderDetail)
        {
            if (orderDetailRepository.GetOrderDetailByIdDrinkAndOrder(orderDetail.OrderId, orderDetail.DrinkId) != null)
            {
                orderDetailRepository.UpdateDrinkDetail(orderDetail);
                return RedirectToAction("CreateNew", new { orderId = orderDetail.OrderId });
            }
            else
            {
                return View(orderDetail);
            }
        }


        // GET: OrderDetails/Delete/5
        public IActionResult DeleteForm(int orderId, int drinkId)
        {
            if (orderId.ToString().IsNullOrEmpty() || drinkId.ToString().IsNullOrEmpty() || orderDetailRepository.GetOrderDetail(orderId).IsNullOrEmpty())
            {
                return NotFound();
            }

            var drinkDetail = orderDetailRepository.GetOrderDetailByIdDrinkAndOrder(orderId, drinkId);

            if (drinkDetail == null)
            {
                return NotFound();
            }
            else
            {

            }
            return View("Delete", drinkDetail);
        }

        // POST: OrderDetails/Delete/5

        public IActionResult DeleteConfirmed(int _orderId, int drinkId)
        {
            if (orderDetailRepository.GetOrderDetailByIdDrinkAndOrder(_orderId, drinkId) != null)
            {
                orderDetailRepository.DeleteDrinkDetail(_orderId, drinkId);

            }
            return RedirectToAction("CreateNew", new { orderId = _orderId });
        }

    }
}











/*
// GET: OrderDetails
public async Task<IActionResult> Index()
{
    var coffeeShopContext = _context.OrderDetails.Include(o => o.Drink).Include(o => o.Order);
    return View(await coffeeShopContext.ToListAsync());
}

// GET: OrderDetails/Details/5
public async Task<IActionResult> Details(int? id)
{
    if (id == null || _context.OrderDetails == null)
    {
        return NotFound();
    }

    var orderDetail = await _context.OrderDetails
        .Include(o => o.Drink)
        .Include(o => o.Order)
        .FirstOrDefaultAsync(m => m.OrderId == id);
    if (orderDetail == null)
    {
        return NotFound();
    }

    return View(orderDetail);
}

// GET: OrderDetails/Create
public IActionResult Create()
{
    ViewData["DrinkId"] = new SelectList(_context.Drinks, "DrinkId", "DrinkName");
    ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
    return View();
}

// POST: OrderDetails/Create
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("OrderId,DrinkId,Quantity,DrinkNote")] OrderDetail orderDetail)
{
    if (ModelState.IsValid)
    {
        _context.Add(orderDetail);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    ViewData["DrinkId"] = new SelectList(_context.Drinks, "DrinkId", "DrinkName", orderDetail.DrinkId);
    ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderDetail.OrderId);
    return View(orderDetail);
}

// GET: OrderDetails/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null || _context.OrderDetails == null)
    {
        return NotFound();
    }

    var orderDetail = await _context.OrderDetails.FindAsync(id);
    if (orderDetail == null)
    {
        return NotFound();
    }
    ViewData["DrinkId"] = new SelectList(_context.Drinks, "DrinkId", "DrinkName", orderDetail.DrinkId);
    ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderDetail.OrderId);
    return View(orderDetail);
}

// POST: OrderDetails/Edit/5
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("OrderId,DrinkId,Quantity,DrinkNote")] OrderDetail orderDetail)
{
    if (id != orderDetail.OrderId)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(orderDetail);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderDetailExists(orderDetail.OrderId))
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
    ViewData["DrinkId"] = new SelectList(_context.Drinks, "DrinkId", "DrinkName", orderDetail.DrinkId);
    ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderDetail.OrderId);
    return View(orderDetail);
}

// GET: OrderDetails/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null || _context.OrderDetails == null)
    {
        return NotFound();
    }

    var orderDetail = await _context.OrderDetails
        .Include(o => o.Drink)
        .Include(o => o.Order)
        .FirstOrDefaultAsync(m => m.OrderId == id);
    if (orderDetail == null)
    {
        return NotFound();
    }

    return View(orderDetail);
}

// POST: OrderDetails/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    if (_context.OrderDetails == null)
    {
        return Problem("Entity set 'CoffeeShopContext.OrderDetails'  is null.");
    }
    var orderDetail = await _context.OrderDetails.FindAsync(id);
    if (orderDetail != null)
    {
        _context.OrderDetails.Remove(orderDetail);
    }

    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

private bool OrderDetailExists(int id)
{
  return (_context.OrderDetails?.Any(e => e.OrderId == id)).GetValueOrDefault();
}*/

