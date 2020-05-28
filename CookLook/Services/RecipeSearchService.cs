using CookLook.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<List<string>> ImportIngredientList()
        {
            List<string> listOfIngredients = new List<string>();
            using (StreamReader file = File.OpenText(@"C:\Repos\CookLookBlazor\CookLook\CookLook\Data\Ingredients.json"))
            {
                var json = await file.ReadToEndAsync();
                listOfIngredients = JsonSerializer.Deserialize<List<string>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }

            return listOfIngredients;
        }

        public async Task<RandomRecipe> GenerateRandomRecipe()
        {
            RandomRecipe deliciousRecipe = new RandomRecipe();
            List<string> dishes = GetRecipeTypes();
            List<string> ingredients = await ImportIngredientList();
            Random rand = new Random();

            int numberOfIngredients = rand.Next(4, 7);
            List<Ingredient> chosenIngredients = new List<Ingredient>();
            for (int i = 0; i < numberOfIngredients; i++)
            {
                chosenIngredients.Add(new Ingredient { Text = ingredients[rand.Next(ingredients.Count())], 
                                                       Weight = RoundUp(rand.Next(2000)) });
            }
            deliciousRecipe.Ingredients = chosenIngredients;
            deliciousRecipe.Name = deliciousRecipe.Ingredients[0].Text + " and " + deliciousRecipe.Ingredients[1].Text + " " + dishes[rand.Next(dishes.Count())];
            deliciousRecipe.Image = await SearchGoogleForImage(deliciousRecipe.Name);
            return deliciousRecipe;
        }

        public async Task<string> SearchGoogleForImage(string searchTerm)
        {
            var DownloadLink = "&q=" + searchTerm.Replace("  ", " ").Trim().Replace(" ", "+");
            using (var client = new WebClient())
            {
                var searchResult = await client.DownloadStringTaskAsync("https://www.googleapis.com/customsearch/v1?key=AIzaSyAqwYETDhyrgfi0WnBbUowiZd7l8ea-voc&cx=013804392218156844819:ymg35lhfayb&searchType=image&num=1&start=1&imgSize=medium" + DownloadLink);
                ImageSearch imageResult = JsonSerializer.Deserialize<ImageSearch>(searchResult, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return imageResult.items[0].link;
            }


        }

        public List<string> GetRecipeTypes()
        {
            return new List<string>
            {
                "casserole",
                "soup",
                "patty",
                "sausage",
                "omelette",
                "hot-pot",
                "supreme",
                "surprise",
                "pizza",
                "cake",
                "loaf",
                "curry",
                "pie"
            };

        }

        int RoundUp(int toRound)
        {
            if (toRound % 100 == 0) return toRound;
            return (100 - toRound % 100) + toRound;
        }
    }
}
