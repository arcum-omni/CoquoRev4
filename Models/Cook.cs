using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoquoRev4.Models
{
    public class Cook
    {
        [Key]
        public int CookID { get; set; }

        public Dish DishID { get; set; }

        public Ingredient IngredientID { get; set; }

        // Navigation Properties
        public Dish Dish { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
