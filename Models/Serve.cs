using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoquoRev4.Models
{
    [DebuggerDisplay("ServeID: {MealID}")]
    public class Serve
    {
        [Key]
        public int ServeID { get; set; }

        //[ForeignKey]
        public int MealID { get; set; }

        public string MealName { get; set; }

        //[ForeignKey]
        public int DishID { get; set; }

        public string DishName { get; set; }

        // Navigation Properties
        public Meal Meal { get; set; }
        public Dish Dish { get; set; }
    }
}
