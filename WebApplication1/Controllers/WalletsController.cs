using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlockchainAnalysisTool.Models;

namespace BlockchainAnalysisTool.Controllers
{
    public class WalletsController : Controller
    {
        private readonly BlockchainContext _context;

        public WalletsController(BlockchainContext context)
        {
            _context = context;    
        }

        public async Task<IActionResult> Index(String adrs)
        {
            ViewData["searchedAddress"] = adrs;

            return View(Sort.getRelatedWallets(_context, adrs));
        }

        // GET: Wallets/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // Use data dictionary for wallet info, pass list of Addr to View()

            var wallet = await _context.Wallet
                .SingleOrDefaultAsync(m => m.Wid == id);
            ViewData["Wallet"] = wallet.Wid;

            var addList = await _context.Addr.Where(add => add.ParentWallet == id).ToListAsync();

            if (wallet == null)
            {
                return NotFound();
            }
            
            return View(addList);
        }

        // GET: Wallets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wallets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Wid,NumberOfAddresses,NumberOfTransactions,Priority,Balance")] Wallet wallet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wallet);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wallet);
        }

        // GET: Wallets/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var wallet = await _context.Wallet.SingleOrDefaultAsync(m => m.Wid == id);
            if (wallet == null)
            {
                return NotFound();
            }
            return View(wallet);
        }

        // POST: Wallets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Wid,NumberOfAddresses,NumberOfTransactions,Priority,Balance")] Wallet wallet)
        {
            if (id != wallet.Wid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wallet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalletExists(wallet.Wid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(wallet);
        }

        // GET: Wallets/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var wallet = await _context.Wallet
                .SingleOrDefaultAsync(m => m.Wid == id);
            if (wallet == null)
            {
                return NotFound();
            }

            return View(wallet);
        }

        // POST: Wallets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wallet = await _context.Wallet.SingleOrDefaultAsync(m => m.Wid == id);
            _context.Wallet.Remove(wallet);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WalletExists(int id)
        {
            return _context.Wallet.Any(e => e.Wid == id);
        }
    }
}
