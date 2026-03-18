using Microsoft.AspNetCore.Mvc;
using ProjectAgileBoard.API.DTO;
using ProjectAgileBoard.API.Services;

namespace ProjectAgileBoard.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuariosServices _services;

        public UsuarioController(IUsuariosServices services) => _services = services;

        [HttpGet]
        public async Task<IEnumerable<UsuarioDTO>> Get() => await _services.GetAllUsersAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            var user = await _services.GetUserByIdAsync(id);
            return user is not null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> Create(AddUsuarioDTO userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createdUser = await _services.CreateUserAsync(new UsuarioDTO
            {
                Nombre = userDto.Nombre,
                Apellido = userDto.Apellido,
                Email = userDto.Email
            });
            return CreatedAtAction(nameof(Get), new { id = createdUser.ID }, createdUser);
        }
    }
}
