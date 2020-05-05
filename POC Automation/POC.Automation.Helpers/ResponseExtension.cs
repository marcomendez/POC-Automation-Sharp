using Newtonsoft.Json;
using RestSharp;

namespace POC.Automation.Helpers
{
    public static class ResponseExtension
    {
        /// <summary>
        /// Converts IResponse to dymanic.
        /// </summary>
        /// <param name="response">Response to convert.</param>
        /// <returns>Dynamic data.</returns>
        public static dynamic ToDynamic(this IRestResponse response)
        {
            return JsonConvert.DeserializeObject(response.Content);
        }
    }
}
