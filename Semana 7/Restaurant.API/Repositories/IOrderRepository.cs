using Restaurant.API.Models;

namespace Restaurant.API.Repositories
{
    public interface IOrderRepository
    {
            Task<List<Order>> GetAllOrdersAsync();
            Task<Order?> GetOrderByIdAsync(int id);
            Task AddAsync(Order order);
            Task UpdateAsync(Order order);
    }
}
