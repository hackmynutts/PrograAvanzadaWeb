using Restaurant.UI.Models;

namespace Restaurant.UI.Services
{
    public class OrdersAPIClient : IOrdersAPIClient
    {
        private readonly HttpClient _httpClient;
        // The constructor takes an HttpClient as a parameter and assigns it to the private field _httpClient.
        // This allows the OrdersAPIClient to use the HttpClient for making HTTP requests to the API.
        public OrdersAPIClient(HttpClient httpClient) => _httpClient = httpClient;

        // The GetOrdersAsync method is an asynchronous method that retrieves a list of orders from the API.
        public async Task<List<OrderViewModel>> GetOrdersAsync(CancellationToken cancellation = default)// The method takes an optional CancellationToken parameter that can be used to cancel the operation if needed.
        {
            // It uses the GetFromJsonAsync extension method to send a GET request to the "api/order" endpoint and deserialize the response into a List of OrderViewModel objects.
            return await _httpClient.GetFromJsonAsync<List<OrderViewModel>>("api/Order", cancellation)
                ?? new List<OrderViewModel>(); // If the response is null, it returns an empty list.
        }

        public async Task CreateOrderAsync(string customerName, string dish, CancellationToken cancellation = default)
        {
            var newOrder = new OrderViewModel
            {
                CustomerName = customerName,
                Dish = dish
            };
            // It uses the PostAsJsonAsync extension method to send a POST request to the "api/order" endpoint with the new order data serialized as JSON.
            var response = await _httpClient.PostAsJsonAsync("api/Order", newOrder, cancellation);
            response.EnsureSuccessStatusCode(); // Ensure the request was successful, otherwise throw an exception.
        }

        public async Task AdvanceOrderStatusAsync(int orderId, CancellationToken cancellation = default)
        {
            // It sends a POST request to the "api/order/{id}/advance" endpoint to advance the status of the specified order.
            var response = await _httpClient.PostAsync($"api/Order/{orderId}/advance", null, cancellation);
            response.EnsureSuccessStatusCode(); // Ensure the request was successful, otherwise throw an exception.
        }
    }
}
