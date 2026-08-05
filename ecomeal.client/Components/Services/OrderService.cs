using System.Net.Http.Json;
using System.Text.Json;
using EcoMeal.Client.Models;

namespace EcoMeal.Client.Services
{
    public class OrderService
    {
        private readonly HttpClient _http;

        public OrderService(HttpClient http)
        {
            _http = http;
        }

        public async Task<OrderResult> PlaceOrderAsync(int packageId)
        {
            var response = await _http.PostAsJsonAsync("api/order", new OrderCreateModel { PackageId = packageId });
            if (response.IsSuccessStatusCode)
            {
                return OrderResult.Ok();
            }

            var errorMessage = await ReadErrorMessageAsync(response);
            return OrderResult.Fail(errorMessage ?? "Comanda nu a putut fi plasată.");
        }

        private static async Task<string?> ReadErrorMessageAsync(HttpResponseMessage response)
        {
            var body = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(body))
            {
                return null;
            }

            // Some error responses are plain text, others are JSON-encoded strings ("message") - handle both.
            if (body.Length >= 2 && body[0] == '"' && body[^1] == '"')
            {
                try
                {
                    return JsonSerializer.Deserialize<string>(body) ?? body;
                }
                catch (JsonException)
                {
                    return body;
                }
            }

            return body;
        }

        public async Task<List<OrderGetModel>> GetMyOrdersAsync()
        {
            var response = await _http.GetAsync("api/order");
            response.EnsureSuccessStatusCode();

            var orders = await response.Content.ReadFromJsonAsync<List<OrderGetModel>>();
            return orders ?? new List<OrderGetModel>();
        }
    }
}
