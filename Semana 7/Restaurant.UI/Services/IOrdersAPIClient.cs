using Restaurant.UI.Models;

namespace Restaurant.UI.Services
{
    public interface IOrdersAPIClient
    {
        Task<List<OrderViewModel>> GetOrdersAsync(CancellationToken cancellation = default);
        Task CreateOrderAsync(string customerName, string dish, CancellationToken cancellation = default);
        Task AdvanceOrderStatusAsync(int orderId, CancellationToken cancellation = default);
    }
}
