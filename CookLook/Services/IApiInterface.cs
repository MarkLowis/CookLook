using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookLook.Services
{
    public interface IApiInterface
    {
        Task<string> CallRecipeApi(string searchString);

        Task<string> CallGoogleImageApi(string searchString);

    }
}
