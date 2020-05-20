﻿using CookLook.Models;
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
        public async Task<RecipeList> SearchRecipesAsync(string searchTerm)
        {
            var DownloadLink = "&q=" + searchTerm.Replace("  ", " ").Trim().Replace(" ", "+");
            using (var client = new WebClient())
            {

                var recipeJson = client.DownloadString("https://api.edamam.com/search?app_id=084c75ba&app_key=dc0c53baf15766be071aa494ecd8fae6&to=5" + DownloadLink);
                RecipeList recipeList = JsonSerializer.Deserialize<RecipeList>(recipeJson, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return recipeList;
            }
        }
    }
}
