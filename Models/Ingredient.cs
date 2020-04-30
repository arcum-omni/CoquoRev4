using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoquoRev4.Models
{
    /// <summary>
    /// Represents a single ingredient,
    /// any number of different ingredients can be in a dish.
    /// </summary>
    public class Ingredient
    {
        [Key]
        public int IngredientID { get; set; }

        public string IngredientName { get; set; }

        public string IngredientDescription { get; set; }

        // Navigation Property
        public ICollection<Cook> Cooks { get; set; }
    }
}