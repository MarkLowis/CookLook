using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CookLookUnitTests.TestValidJson
{
    public class PizzaFiveResults
    {
        public static string GetJsonString()
        {
            var jsonPath = "CookLookUnitTests.TestValidJson.PizzaFiveResults.json"; 
            var jsonStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(jsonPath);
            string jsonString;
            using (var streamReader = new StreamReader(jsonStream))
            {
                jsonString = streamReader.ReadToEnd();
            }
            return jsonString;
        }
    }
}
