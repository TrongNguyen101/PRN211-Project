﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using DataAccess.Repository;
using System.Collections.Specialized;

namespace CoffeeShopWebApplication.Controllers
{
    public class AccountsController : Controller
    {
        IAccountRepository accountRepository = new AccountRepository();
        // GET: Accounts/Create
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("staffName") != null && HttpContext.Session.GetInt32("accountID") != null)
            {
                HttpContext.Session.Remove("staffName");
                HttpContext.Session.Remove("accountID");
            }
            return View();
        }


        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        public IActionResult Create(string username, string password)
        {
            
            var account = accountRepository.GetAccountToLogin(username, password);
            if (account.Role != 1)
            {
                TempData["MessageErrorPassOrEmail"] = "Sai email hoặc mật khẩu";
                return View(account);
            }
            else
            {
                
                    HttpContext.Session.SetString("staffName", account.StaffName);
                    HttpContext.Session.SetInt32("accountID", account.AccountId);
                    return RedirectToAction("Index", "CoffeeTables", new { accId = account.AccountId});
                
            }
            
        }

        public IActionResult Index()
        {
            var accountList = accountRepository.GetAllAccounts();
            return View(accountList);
        }

        // GET: Accounts/Create
        public IActionResult AddAccount()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAccount([Bind("AccountId,StaffName,UserName,Password,Role")] Account account)
        {
            if (ModelState.IsValid)
            {
                accountRepository.AddAccount(account);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }


        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id.ToString() == null )
            {
                return NotFound();
            }

            var account = accountRepository.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,StaffName,UserName,Password,Role")] Account account)
        {
            if (id != account.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    accountRepository.UpdateAccount(account);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (account.AccountId.ToString() == null)
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
            return View(account);
        }


        // GET: Accounts/Delete/5
        public IActionResult Delete(int id)
        {
            if (id.ToString() == null)
            {
                return NotFound();
            }

            var account = accountRepository.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (accountRepository.GetAllAccounts() == null)
            {
                return Problem("Entity set 'CoffeeShopContext.Accounts'  is null.");
            }
            var account = accountRepository.GetAccountById(id);
            if (account != null)
            {
                accountRepository.DeleteAccount(id);
            }

                
            return RedirectToAction(nameof(Index));
        }

    }
}
/*
private readonly CoffeeShopContext _context;

public AccountsController(CoffeeShopContext context)
{
    _context = context;
}

// GET: Accounts
public async Task<IActionResult> Index()
{
      return _context.Accounts != null ? 
                  View(await _context.Accounts.ToListAsync()) :
                  Problem("Entity set 'CoffeeShopContext.Accounts'  is null.");
}

// GET: Accounts/Details/5
public async Task<IActionResult> Details(int? id)
{
    if (id == null || _context.Accounts == null)
    {
        return NotFound();
    }

    var account = await _context.Accounts
        .FirstOrDefaultAsync(m => m.AccountId == id);
    if (account == null)
    {
        return NotFound();
    }

    return View(account);
}

// GET: Accounts/Create
public IActionResult Create()
{
    return View();
}

// POST: Accounts/Create
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("AccountId,StaffName,UserName,Password,Role")] Account account)
{
    if (ModelState.IsValid)
    {
        _context.Add(account);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(account);
}

// GET: Accounts/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null || _context.Accounts == null)
    {
        return NotFound();
    }

    var account = await _context.Accounts.FindAsync(id);
    if (account == null)
    {
        return NotFound();
    }
    return View(account);
}

// POST: Accounts/Edit/5
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("AccountId,StaffName,UserName,Password,Role")] Account account)
{
    if (id != account.AccountId)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(account);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AccountExists(account.AccountId))
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
    return View(account);
}

// GET: Accounts/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null || _context.Accounts == null)
    {
        return NotFound();
    }

    var account = await _context.Accounts
        .FirstOrDefaultAsync(m => m.AccountId == id);
    if (account == null)
    {
        return NotFound();
    }

    return View(account);
}

// POST: Accounts/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    if (_context.Accounts == null)
    {
        return Problem("Entity set 'CoffeeShopContext.Accounts'  is null.");
    }
    var account = await _context.Accounts.FindAsync(id);
    if (account != null)
    {
        _context.Accounts.Remove(account);
    }

    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

private bool AccountExists(int id)
{
  return (_context.Accounts?.Any(e => e.AccountId == id)).GetValueOrDefault();
}*/

