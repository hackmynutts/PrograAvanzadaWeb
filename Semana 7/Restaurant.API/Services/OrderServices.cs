using Restaurant.API.DTO;
using Restaurant.API.Models;
using Restaurant.API.Repositories;

namespace Restaurant.API.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        public OrderServices(IOrderRepository orderRepository) => _orderRepository = orderRepository;
        //lista ordenes
        public async Task<List<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return orders.Select(o => new OrderDTO// Map to DTO
            {
                ID = o.ID,
                CustomerName = o.CustomerName,
                Dish = o.Dish,
                status = o.status.ToString(),
                CreateAt = o.CreateAt
            }).ToList();// Convert to DTO
        }
        //obtener orden por id
        public async Task<OrderDTO?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            // Map to DTO if order exists, otherwise return null
            return order is null ? null : new OrderDTO //operador ternário 
            //syntax: condition ? true_expression : false_expression
            {
                ID = order.ID,
                CustomerName = order.CustomerName,
                Dish = order.Dish,
                status = order.status.ToString(),
                CreateAt = order.CreateAt
            };
        }
        //crear orden
        public async Task<OrderDTO> CreateOrderAsync(OrderDTO orderDto)
        {
            var order = new Order
            {
                CustomerName = orderDto.CustomerName,
                Dish = orderDto.Dish,
                status = OrderStatus.Pending,
                CreateAt = DateTime.UtcNow
            };
            await _orderRepository.AddAsync(order);
            // Map to DTO after saving to get the generated ID
            return new OrderDTO
            {
                ID = order.ID,
                CustomerName = order.CustomerName,
                Dish = order.Dish,
                status = order.status.ToString(),
                CreateAt = order.CreateAt
            };
        }

        //Avanzar estado de la orden
        public async Task<bool> AdvanceOrderStatusAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order is null) return false;
            // Avanzar al siguiente estado
            order.status = order.status switch
            {
                OrderStatus.Pending => OrderStatus.InProgress,
                OrderStatus.InProgress => OrderStatus.Completed,
                OrderStatus.Completed => OrderStatus.Delivered,
                _ => order.status // No avanzar si ya está en Delivered o Cancelled
            };
            await _orderRepository.UpdateAsync(order);
            return true;
        }
    }
}
