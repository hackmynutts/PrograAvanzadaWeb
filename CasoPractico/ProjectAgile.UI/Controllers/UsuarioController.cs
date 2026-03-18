using Microsoft.AspNetCore.Mvc;
using ProjectAgile.UI.Services;

namespace ProjectAgile.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUserApiClient _userApiClient;

        public UsuarioController(IUserApiClient userApiClient) => _userApiClient = userApiClient;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userApiClient.GetUsersAsync();
            return View(users.OrderBy(u => u.ID).ToList());
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(string nombre, string apellido, string email, int pokeNumber)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(email) || pokeNumber < 0)
                {
                    TempData["Error"] = "Datos inválidos.";
                    return RedirectToAction(nameof(Index));
                }
                await _userApiClient.AddUserAsync(nombre, apellido, email, pokeNumber);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(new { message = "An error occurred while creating the user." });
            }
        }
    }
}
