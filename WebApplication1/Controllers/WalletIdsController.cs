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
    public class WalletIdsController : Controller
    {
        private readonly GEN_BLKContext _context;

        public WalletIdsController(GEN_BLKContext context)
        {
            _context = context;
        }

        // GET: WalletIds
        public async Task<IActionResult> Index()
        {
            return View(await _context.WalletId.ToListAsync());
        }

        // GET: WalletIds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walletId = await _context.WalletId
                .SingleOrDefaultAsync(m => m.Wid == id);
            if (walletId == null)
            {
                return NotFound();
            }

            return View(walletId);
        }

        // GET: WalletIds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WalletIds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Wid,NumberOfAddresses,NumberOfTransactions,Priority,Balance")] WalletId walletId)
        {
            if (ModelState.IsValid)
            {
                _context.Add(walletId);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(walletId);
        }

        // GET: WalletIds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walletId = await _context.WalletId.SingleOrDefaultAsync(m => m.Wid == id);
            if (walletId == null)
            {
                return NotFound();
            }
            return View(walletId);
        }

        // POST: WalletIds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Wid,NumberOfAddresses,NumberOfTransactions,Priority,Balance")] WalletId walletId)
        {
            if (id != walletId.Wid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(walletId);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalletIdExists(walletId.Wid))
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
            return View(walletId);
        }

        // GET: WalletIds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walletId = await _context.WalletId
                .SingleOrDefaultAsync(m => m.Wid == id);
            if (walletId == null)
            {
                return NotFound();
            }

            return View(walletId);
        }

        // POST: WalletIds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var walletId = await _context.WalletId.SingleOrDefaultAsync(m => m.Wid == id);
            _context.WalletId.Remove(walletId);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WalletIdExists(int id)
        {
            return _context.WalletId.Any(e => e.Wid == id);
        }
    }
}
