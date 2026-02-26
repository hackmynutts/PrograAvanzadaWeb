using Restaurant.API.DTO;

namespace Restaurant.API.Services
{
    public interface IOrderServices
    {
        Task<List<OrderDTO>> GetAllOrdersAsync();
        Task<OrderDTO?> GetOrderByIdAsync(int id);
        Task<OrderDTO> CreateOrderAsync(OrderDTO orderDto);
        Task<bool> AdvanceOrderStatusAsync(int id);
    }
}
