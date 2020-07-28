using NUnit.Framework;
using CookLook.Services;
using Moq;
using Newtonsoft.Json;
using CookLookUnitTests;
using CookLookUnitTests.TestValidJson;

namespace CookLookUnitTests
{
    public class RecipeSearchServiceTests
    {
        RecipeSearchService recipeSearchService;
        Mock<ApiInterface> mockApiInterface;
        bool[] health;

        [SetUp]
        public void Setup()
        {
            mockApiInterface = new Mock<ApiInterface>();
            recipeSearchService = new RecipeSearchService(mockApiInterface.Object);
            bool vegetarian = false;
            bool vegan = false;
            bool peanutFree = false;
            bool treenutfree = false;
            bool sugar = false;
            bool alcohol = false;
            bool protein = false;
            bool fat = false;
            bool carbs = false;
            health = new bool[] { vegetarian, vegan, peanutFree, treenutfree, sugar, alcohol, protein, fat, carbs };
    }

        [Test]
        public void SearchRecipesAsyncCallsEdamamAPIAndReturnsHits()
        {
            string pizzaFiveResults = PizzaFiveResults.GetJsonString();

            mockApiInterface.Setup(m => m.CallRecipeApi(It.IsAny<string>())).ReturnsAsync(pizzaFiveResults);
            var recipeResult = recipeSearchService.SearchRecipesAsync("Pizza", 5, health);

            Assert.IsNotNull(recipeResult.Result.Hits);
        }

        [Test]
        public void SearchGoogleForAnImageCallsGoogleAPIAndReturnsAURL()
        {
            var expected = "https://i.guim.co.uk/img/media/7c639bb26439ad5983c4fa9825e1e516794feb45/0_309_7216_4330/master/7216.jpg?width=300&quality=85&auto=format&fit=max&s=40806a3b9bac54a0324cfc8b5f70ad25";
            string googleImageResult = GoogleImageResult.GetJsonString();

            mockApiInterface.Setup(m => m.CallGoogleImageApi(It.IsAny<string>())).ReturnsAsync(googleImageResult);
            var imageResult = recipeSearchService.SearchGoogleForImage("legitimate search term");

            Assert.AreEqual(expected, imageResult.Result);
        }
    }
}