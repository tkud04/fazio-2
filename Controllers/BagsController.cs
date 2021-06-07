using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ass_2.Data;
using ass_2.Models;

namespace ass_2.Controllers
{
    public class BagsController : Controller
    {
        private readonly ass_2Context _context;

        public BagsController(ass_2Context context)
        {
            _context = context;
        }

        // GET: Bags
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bag.ToListAsync());
        }

        // GET: Bags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bag = await _context.Bag
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bag == null)
            {
                return NotFound();
            }

            return View(bag);
        }

        // GET: Bags/Create
        public IActionResult Create()
        {
            return View();
        }

		// GET: Bags/Add
        public async Task<IActionResult> Add(string sku,int qty)
        {
			Bag bag = new Bag();
			bag.Sku = sku;
			bag.qty = qty;
            _context.Add(bag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // POST: Bags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,DateAdded,Quantity,Sku")] Bag bag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bag);
        }

        // GET: Bags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bag = await _context.Bag.FindAsync(id);
            if (bag == null)
            {
                return NotFound();
            }
            return View(bag);
        }

        // POST: Bags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,DateAdded,Quantity,Sku")] Bag bag)
        {
            if (id != bag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BagExists(bag.Id))
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
            return View(bag);
        }

        // GET: Bags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bag = await _context.Bag
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bag == null)
            {
                return NotFound();
            }

            return View(bag);
        }

        // POST: Bags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bag = await _context.Bag.FindAsync(id);
            _context.Bag.Remove(bag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BagExists(int id)
        {
            return _context.Bag.Any(e => e.Id == id);
        }
    }
}
