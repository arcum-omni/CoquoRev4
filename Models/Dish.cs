using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoquoRev4.Models
{
    /// <summary>
    /// Represents a recipe to cook a single dish,
    /// and is comprised of one or more ingredients.
    /// </summary>
    [DebuggerDisplay("Dishname: {DishName}")]
    public class Dish
    {
        [Display(Name = "Dish ID")]
        public int DishID { get; set; }

        [Display(Name = "Dish Name")]
        public string DishName { get; set; }

        [Display(Name = "Dish Description")]
        public string DishDescription { get; set; }

        [Display(Name = "Dish Cuisine")]
        public string DishCuisine { get; set; }

        // Navigation Property
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Cook> Cooks { get; set; }
        public ICollection<Serve> Serves { get; set; }
    }
}
