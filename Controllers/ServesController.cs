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
    public class ServesController : Controller
    {
        private readonly KitchenDbContext _context;

        public ServesController(KitchenDbContext context)
        {
            _context = context;
        }

        // GET: Serves
        public async Task<IActionResult> Index()
        {
            var kitchenDbContext = _context.Serve.Include(s => s.Dish).Include(s => s.Meal);
            return View(await kitchenDbContext.ToListAsync());
        }

        // GET: Serves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serve = await _context.Serve
                .Include(s => s.Dish)
                .Include(s => s.Meal)
                .FirstOrDefaultAsync(m => m.ServeID == id);
            if (serve == null)
            {
                return NotFound();
            }

            return View(serve);
        }

        // GET: Serves/Create
        public IActionResult Create()
        {
            ViewData["DishID"] = new SelectList(_context.Dishes, "DishID", "DishID");
            ViewData["MealID"] = new SelectList(_context.Meal, "MealID", "MealID");
            return View();
        }

        // POST: Serves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServeID,MealID,MealName,DishID,DishName")] Serve serve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serve);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DishID"] = new SelectList(_context.Dishes, "DishID", "DishID", serve.DishID);
            ViewData["MealID"] = new SelectList(_context.Meal, "MealID", "MealID", serve.MealID);
            return View(serve);
        }

        // GET: Serves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serve = await _context.Serve.FindAsync(id);
            if (serve == null)
            {
                return NotFound();
            }
            ViewData["DishID"] = new SelectList(_context.Dishes, "DishID", "DishID", serve.DishID);
            ViewData["MealID"] = new SelectList(_context.Meal, "MealID", "MealID", serve.MealID);
            return View(serve);
        }

        // POST: Serves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServeID,MealID,MealName,DishID,DishName")] Serve serve)
        {
            if (id != serve.ServeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServeExists(serve.ServeID))
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
            ViewData["DishID"] = new SelectList(_context.Dishes, "DishID", "DishID", serve.DishID);
            ViewData["MealID"] = new SelectList(_context.Meal, "MealID", "MealID", serve.MealID);
            return View(serve);
        }

        // GET: Serves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serve = await _context.Serve
                .Include(s => s.Dish)
                .Include(s => s.Meal)
                .FirstOrDefaultAsync(m => m.ServeID == id);
            if (serve == null)
            {
                return NotFound();
            }

            return View(serve);
        }

        // POST: Serves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serve = await _context.Serve.FindAsync(id);
            _context.Serve.Remove(serve);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServeExists(int id)
        {
            return _context.Serve.Any(e => e.ServeID == id);
        }
    }
}
