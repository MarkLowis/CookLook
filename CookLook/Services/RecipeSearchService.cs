using CookLook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookLook.Services
{
    public class RecipeSearchService : IRecipeSearchService
    {
        public async Task<List<Recipe>> SearchRecipesAsync(string searchterm)
        {
            return new List<Recipe> { new Recipe { Label = "Cockroach Hotdog", Url = "www.cockroachhotdog.com" } };
        }
    }
}
