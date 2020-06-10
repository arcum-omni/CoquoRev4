using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoquoRev4.Data;
using CoquoRev4.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

namespace CoquoRev4.Controllers
{
    public class DishesController : Controller
    {
        private readonly KitchenDbContext _context;

        public DishesController(KitchenDbContext context)
        {
            _context = context;
        }

        // GET: Dishes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dishes.ToListAsync());
        }

        // GET: Dishes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singleDish = await _context.Dishes
                .Where(d => d.DishID == id)
                .Include(c => c.Cooks)
                .ThenInclude(i => i.Ingredient)
                .SingleOrDefaultAsync();
            if (singleDish == null)
            {
                return NotFound();
            }

            singleDish.Ingredients = await _context.Ingredients.ToListAsync();

            ViewBag.DishIngredients = await (from a in _context.Cooks
                                         where a.DishID == id
                                         select a.Ingredient.IngredientName).ToListAsync();

            ViewBag.Ingredient = await (from a in _context.Ingredients
                                        select a).ToListAsync();

            return View(singleDish);
        }

        public async Task<IActionResult> AddIngredientToDish(IFormCollection form) 
        {
            int dishId = Convert.ToInt32(form["dish-id"]);
            int ingredientId = Convert.ToInt32(form["ingredient-id"]);
            Cook c = new Cook()
            {
                DishID = dishId,
                IngredientID = ingredientId
            };

            await AddIngredient(c);
            return RedirectToAction(nameof(Details), new RouteValueDictionary(new { action = "Details", Id = dishId }));
        }

        public async Task<Cook> AddIngredient([Bind("CookID,DishID,IngredientID")] Cook c)
        {
            _context.Add(c);
            await _context.SaveChangesAsync();
            return c;
        }

        // GET: Dishes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dishes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DishID,DishName,DishDescription")] Dish dish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dish);
        }

        // GET: Dishes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }

        // POST: Dishes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DishID,DishName,DishDescription")] Dish dish)
        {
            if (id != dish.DishID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishExists(dish.DishID))
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
            return View(dish);
        }

        // GET: Dishes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .FirstOrDefaultAsync(m => m.DishID == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // POST: Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dish = await _context.Dishes.FindAsync(id);
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DishExists(int id)
        {
            return _context.Dishes.Any(e => e.DishID == id);
        }
    }
}
