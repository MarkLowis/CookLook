using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookLook.Models
{
    public class RandomRecipe
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
