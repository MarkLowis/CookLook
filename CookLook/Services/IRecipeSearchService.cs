using CookLook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookLook.Services
{
    interface IRecipeSearchService
    {
        Task<RecipeList> SearchRecipesAsync(string searchTerm, int numberOfRecipes);

    }
}
