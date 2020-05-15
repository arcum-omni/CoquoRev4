using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoquoRev4.Models
{
    public class Meal
    {
        public int MealID { get; set; }

        public string MealName { get; set; }

        public string MealDescription { get; set; }

        // NavProp
        public ICollection<Serve> Serves { get; set; }
    }
}
