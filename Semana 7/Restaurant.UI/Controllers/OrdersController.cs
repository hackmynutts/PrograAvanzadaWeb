using Microsoft.AspNetCore.Mvc;
using Restaurant.UI.Services;

namespace Restaurant.UI.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersAPIClient _ordersApi;

        public OrdersController(IOrdersAPIClient ordersApi) => _ordersApi = ordersApi;

        public async Task<IActionResult> Index()
        {
            var list = await _ordersApi.GetOrdersAsync(); // Get the list of orders from the API client
            return View(list.OrderBy(o => o.ID));//ordered by ID
        }

        [HttpPost]
        public async Task<IActionResult> Create(string customerName, string dish)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(dish))
                {
                    return BadRequest("Nombre del cliente o el plato son requeridos"); // Return a 400 Bad Request response if the input is invalid
                }
                await _ordersApi.CreateOrderAsync(customerName, dish); // Create a new order using the API client
                return RedirectToAction(nameof(Index)); // Redirect to the Index action to display the updated list of orders
            }
            catch
            {
                return BadRequest(); // Return a 400 Bad Request response if an error occurs
            }
        }

        [HttpPost]
        public async Task<IActionResult> Advance(int id)
        {
            try
            {
                await _ordersApi.AdvanceOrderStatusAsync(id); // Advance the status of the specified order using the API client
                return RedirectToAction(nameof(Index)); // Redirect to the Index action to display the updated list of orders
            }
            catch
            {
                return BadRequest(); // Return a 400 Bad Request response if an error occurs
            }
        }
    }
}
