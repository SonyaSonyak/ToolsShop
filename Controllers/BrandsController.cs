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
    public class BrandsController : Controller
    {
        private readonly TSContext _context;

        public BrandsController(TSContext context)
        {
            _context = context;
        }

        // GET: Brands
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var tSContext = from b in _context.Brands.Include(b => b.Providers) select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                tSContext = tSContext.Where(b => b.Name.Contains(searchString));
            }
            return View(await tSContext.AsNoTracking().ToListAsync());
        }

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brands = await _context.Brands
                .Include(b => b.Providers)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (brands == null)
            {
                return NotFound();
            }

            return View(brands);
        }

        // GET: Brands/Create
        public IActionResult Create()
        {
            ViewData["ProvidersID"] = new SelectList(_context.Providers, "ID", "Name");
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Info,ProvidersID")] Brands brands)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brands);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvidersID"] = new SelectList(_context.Providers, "ID", "Name", brands.Providers.Name);
            return View(brands);
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brands = await _context.Brands.FindAsync(id);
            if (brands == null)
            {
                return NotFound();
            }
            ViewData["ProvidersID"] = new SelectList(_context.Providers, "ID", "Name");
            return View(brands);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Info,ProvidersID")] Brands brands)
        {
            if (id != brands.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brands);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandsExists(brands.ID))
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
            ViewData["ProvidersID"] = new SelectList(_context.Providers, "ID", "Name", brands.Providers.Name);
            return View(brands);
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brands = await _context.Brands
                .Include(b => b.Providers)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (brands == null)
            {
                return NotFound();
            }

            return View(brands);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brands = await _context.Brands.FindAsync(id);
            _context.Brands.Remove(brands);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandsExists(int id)
        {
            return _context.Brands.Any(e => e.ID == id);
        }
    }
}
