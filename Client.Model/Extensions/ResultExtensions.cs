using BeMyGuest.Shared.Model.BusinessServices;
using Model.BusinessServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client.Model.Extensions
{
    public static class ResultExtensions
    {
        public static async Task<IServiceWrapper<T>> ToResult<T>(this HttpResponseMessage response)
        {
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<ServiceWrapper<T>>(responseAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return responseObject;
        }

        public static async Task<IServiceWrapper> ToResult(this HttpResponseMessage response)
        {
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<ServiceWrapper>(responseAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return responseObject;
        }
    }
}
