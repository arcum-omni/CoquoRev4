using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoquoRev4.Models
{
    /// <summary>
    /// Represents a recipe to cook a single dish,
    /// and is comprised of one or more ingredients.
    /// </summary>
    public class Dish
    {
        public int DishID { get; set; }

        public string DishName { get; set; }

        public string DishDescription { get; set; }

        // Navigation Property
        public ICollection<Cook> Cooks { get; set; }
    }
}
