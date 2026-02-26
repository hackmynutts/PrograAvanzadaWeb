using Microsoft.AspNetCore.Mvc;
using Restaurant.API.DTO;
using Restaurant.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices) => _orderServices = orderServices;

        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> Get() => await _orderServices.GetAllOrdersAsync(); // Return all orders

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            var order = await _orderServices.GetOrderByIdAsync(id);
            return order is not null ? Ok(order) : NotFound(); // Return the order if found, otherwise return 404 Not Found
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Create(AddOrderDTO orderDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); // Validate the incoming DTO
            var createdOrder = await _orderServices.CreateOrderAsync(new OrderDTO
            {
                CustomerName = orderDto.CustomerName,
                Dish = orderDto.Dish
            });
            return CreatedAtAction(nameof(Get), new { id = createdOrder.ID }, createdOrder); // Return 201 Created with the location of the new resource
        }

        // Post api/<OrderController>/5
        [HttpPost("{id}/advance")]
        public async Task<ActionResult> AdvanceStatus(int id)
        {
            var result = await _orderServices.AdvanceOrderStatusAsync(id);
            return result ? NoContent() : NotFound(); // Return 204 No Content if successful, otherwise return 404 Not Found
        }
    }
}
