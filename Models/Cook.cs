using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoquoRev4.Models
{
    public class Cook
    {
        [Key]
        public int CookID { get; set; }

        //[ForeignKey]
        public int DishID { get; set; }

        //[ForeignKey]
        public int IngredientID { get; set; }

        // Navigation Properties
        public Dish Dish { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
