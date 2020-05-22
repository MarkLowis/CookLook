using CookLook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookLook.Services
{
    public class RecipeSearchService : IRecipeSearchService
    {
        public async Task<RecipeList> SearchRecipesAsync(string searchTerm, int numberOfRecipes, bool[] health)
        {
            var DownloadLink = "";
            if (health.Contains(true))
            {
                if (health[0]) DownloadLink += "&health=vegetarian";
                if (health[1]) DownloadLink += "&health=vegan";
                if (health[2]) DownloadLink += "&health=peanut-free";
                if (health[3]) DownloadLink += "&health=tree-nut-free";
                if (health[4]) DownloadLink += "&health=sugar-conscious";
                if (health[5]) DownloadLink += "&health=alcohol-free";
                if (health[6]) DownloadLink += "&diet=high-protein";
                if (health[7]) DownloadLink += "&dietlow-fat";
                if (health[8]) DownloadLink += "&diet=low-carb";
            }
            DownloadLink += "&q=" + searchTerm.Replace("  ", " ").Trim().Replace(" ", "+");
            using (var client = new WebClient())
            {
                var recipeJson = await client.DownloadStringTaskAsync("https://api.edamam.com/search?app_id=084c75ba&app_key=dc0c53baf15766be071aa494ecd8fae6&to=" + numberOfRecipes + DownloadLink);
                RecipeList recipeList = JsonSerializer.Deserialize<RecipeList>(recipeJson, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return recipeList;
            }
        }
    }
}
