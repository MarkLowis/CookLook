using CookLook.Services;
using System.Net;
using System.Threading.Tasks;

namespace CookLook.Services
{
    public class ApiInterface : IApiInterface
    {
        public virtual async Task<string> CallGoogleImageApi(string searchString)
        {
            using (var client = new WebClient())
            {
                return await client.DownloadStringTaskAsync("No secrets here oops" + searchString);
            }
        }

        public virtual async Task<string> CallRecipeApi(string searchString)
        {
            using (var client = new WebClient())
            {
                return await client.DownloadStringTaskAsync("https://api.edamam.com/search?app_id=084c75ba&app_key=dc0c53baf15766be071aa494ecd8fae6&to=" + searchString);
            }
        }
    }
}