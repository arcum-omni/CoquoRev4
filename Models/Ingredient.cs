using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoquoRev4.Models
{
    /// <summary>
    /// Represents a single ingredient,
    /// any number of different ingredients can be in a dish.
    /// </summary>
    [DebuggerDisplay("IngredientID: {IngredientName}")]
    public class Ingredient
    {
        [Key]
        [Display(Name = "Ingredient ID")]
        public int IngredientID { get; set; }

        [Display(Name = "Ingredient Name")]
        public string IngredientName { get; set; }

        [Display(Name = "Ingredient Description")]
        public string IngredientDescription { get; set; }

        // Navigation Property
        public ICollection<Cook> Cooks { get; set; }
    }
}