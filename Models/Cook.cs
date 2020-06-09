using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoquoRev4.Models
{
    [DebuggerDisplay("CookID: {IngredientID}")]
    public class Cook
    {
        [Key]
        public int CookID { get; set; }

        //[ForeignKey]
        [Display(Name = "Dish ID")]
        public int DishID { get; set; }

        //[ForeignKey]
        [Display(Name = "Ingredient ID")]
        public int IngredientID { get; set; }

        // Navigation Properties
        public Dish Dish { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
