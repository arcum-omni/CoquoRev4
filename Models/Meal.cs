using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoquoRev4.Models
{
    public class Meal
    {
        public int MealID { get; set; }

        [Display(Name = "Meal Name")]
        public string MealName { get; set; }

        [Display(Name = "Meal Description")]
        public string MealDescription { get; set; }

        // NavProp
        public ICollection<Serve> Serves { get; set; }
    }
}
