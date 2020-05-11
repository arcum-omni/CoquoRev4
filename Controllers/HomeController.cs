using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoquoRev4.Models;
using CoquoRev4.Data;
using Microsoft.EntityFrameworkCore;

namespace CoquoRev4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KitchenDbContext _context;

        public HomeController(ILogger<HomeController> logger,
            KitchenDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int id)
        {
            // Single dish with ingredients
            Dish singleDish = _context.Dishes
                    .Where(d => d.DishID == 2)
                    .Include(d => d.Cooks)          // Include Cooks in Dishes
                    .ThenInclude(c => c.Ingredient) // Include the Ingredients for each Cook
                    .SingleOrDefault();

            

            return View(singleDish);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
