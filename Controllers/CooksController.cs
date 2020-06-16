using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoquoRev4.Data;
using CoquoRev4.Models;

namespace CoquoRev4.Controllers
{
    public class CooksController : Controller
    {
        private readonly KitchenDbContext _context;

        public CooksController(KitchenDbContext context)
        {
            _context = context;
        }

        // GET: Cooks
        public async Task<IActionResult> Index()
        {
            var kitchenDbContext = _context.Cooks.Include(c => c.Dish).Include(c => c.Ingredient);
            return View(await kitchenDbContext.ToListAsync());
        }

        // GET: Cooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cook = await _context.Cooks
                .Include(c => c.Dish)
                .Include(c => c.Ingredient)
                .FirstOrDefaultAsync(m => m.CookID == id);
            if (cook == null)
            {
                return NotFound();
            }

            return View(cook);
        }

        // GET: Cooks/Create
        public IActionResult Create()
        {
            ViewData["DishID"] = new SelectList(_context.Dishes, "DishID", "DishID");
            ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientID", "IngredientID");
            return View();
        }

        // POST: Cooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CookID,DishID,IngredientID")] Cook cook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DishID"] = new SelectList(_context.Dishes, "DishID", "DishID", cook.DishID);
            ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientID", "IngredientID", cook.IngredientID);
            return View(cook);
        }

        // GET: Cooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cook = await _context.Cooks.FindAsync(id);
            if (cook == null)
            {
                return NotFound();
            }
            ViewData["DishID"] = new SelectList(_context.Dishes, "DishID", "DishID", cook.DishID);
            ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientID", "IngredientID", cook.IngredientID);
            return View(cook);
        }

        // POST: Cooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CookID,DishID,IngredientID")] Cook cook)
        {
            if (id != cook.CookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CookExists(cook.CookID))
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
            ViewData["DishID"] = new SelectList(_context.Dishes, "DishID", "DishID", cook.DishID);
            ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientID", "IngredientID", cook.IngredientID);
            return View(cook);
        }

        // GET: Cooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cook = await _context.Cooks
                .Include(c => c.Dish)
                .Include(c => c.Ingredient)
                .FirstOrDefaultAsync(m => m.CookID == id);
            if (cook == null)
            {
                return NotFound();
            }

            return View(cook);
        }

        // POST: Cooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cook = await _context.Cooks.FindAsync(id);
            _context.Cooks.Remove(cook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CookExists(int id)
        {
            return _context.Cooks.Any(e => e.CookID == id);
        }
    }
}
