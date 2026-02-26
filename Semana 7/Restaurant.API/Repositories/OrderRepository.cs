using Microsoft.EntityFrameworkCore;
using Restaurant.API.Data;
using Restaurant.API.Models;

namespace Restaurant.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        // Aquí irían los métodos para manejar las operaciones CRUD de las órdenes
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext db) => _context = db;

        // Método para obtener todas las órdenes
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.AsNoTracking().ToListAsync();
        }
        // Método para obtener una orden por su ID (para el endpoint GET /orders/{id})
        // Este método devuelve una orden específica basada en su ID. Si no se encuentra la orden, devuelve null. por eso el ? en el tipo de retorno Order?
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.ID == id);
        }

        // Método para crear una nueva orden (para el endpoint POST /orders)
        //public async Task<Order> AddAsync(Order order)  si se maneja de esta manera se debe tener un return order; al final del método,
                                                        //pero como se maneja de esta manera no es necesario retornar nada, por eso el tipo de retorno es Task en lugar de Task<Order>
        public async Task AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        // Método para actualizar el estado de una orden (para el endpoint PUT /orders/{id})
        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
