using Microsoft.AspNetCore.Mvc;
using ReservationWeb.UI.Models;
using ReservationWeb.UI.Services;

namespace ReservationWeb.UI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationServices _reservationServices;

        public ReservationController(ReservationServices reservationServices)
        {
            _reservationServices = reservationServices;// Inyectamos el servicio de reservas a través del constructor
        }
        public async Task<IActionResult> Index()
        {
            var reservations = await _reservationServices.GetReservationsAsync();// Obtenemos la lista de reservas utilizando el servicio
            return View(reservations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReservationModel reservation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _reservationServices.CreateReservationAsync(reservation);// Intentamos crear una nueva reserva utilizando el servicio
                    return RedirectToAction("Index");// Si la creación es exitosa, redirigimos a la acción Index para mostrar la lista de reservas actualizada
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Error al crear la reserva: {ex.Message}");// Si ocurre un error durante la creación, agregamos un mensaje de error al ModelState
                }
            }
            return View(reservation);// Si el modelo no es válido o si ocurre un error, volvemos a mostrar el formulario de creación con los datos ingresados
        }
    }
}
