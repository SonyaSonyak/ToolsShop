using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TS.Data;
using TS.Models;

namespace TS.Controllers
{
    public class ShopsController : Controller
    {
        private readonly TSContext _context;

        public ShopsController(TSContext context)
        {
            _context = context;
        }

        // GET: Shops
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var tSContext = from s in _context.Shops.Include(s => s.Owners) select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                tSContext = tSContext.Where(s => s.Name.Contains(searchString));
            }
            return View(await tSContext.AsNoTracking().ToListAsync());
            //var tSContext = _context.Shops.Include(s => s.Owners);
            //return View(await tSContext.ToListAsync());
        }

        // GET: Shops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shops = await _context.Shops
                .Include(s => s.Owners)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shops == null)
            {
                return NotFound();
            }

            return View(shops);
        }

        // GET: Shops/Create
        public IActionResult Create()
        {
            ViewData["OwnersID"] = new SelectList(_context.Owners, "ID", "Name");
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address,OwnersID")] Shops shops)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shops);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnersID"] = new SelectList(_context.Owners, "ID", "Name", shops.Owners.Name);
            return View(shops);
        }

        // GET: Shops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shops = await _context.Shops.FindAsync(id);
            if (shops == null)
            {
                return NotFound();
            }
            ViewData["OwnersID"] = new SelectList(_context.Owners, "ID", "Name");
            return View(shops);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,OwnersID")] Shops shops)
        {
            if (id != shops.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shops);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopsExists(shops.ID))
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
            ViewData["OwnersID"] = new SelectList(_context.Owners, "ID", "Name", shops.Owners.Name);
            return View(shops);
        }

        // GET: Shops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shops = await _context.Shops
                .Include(s => s.Owners)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shops == null)
            {
                return NotFound();
            }

            return View(shops);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shops = await _context.Shops.FindAsync(id);
            _context.Shops.Remove(shops);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopsExists(int id)
        {
            return _context.Shops.Any(e => e.ID == id);
        }
    }
}
