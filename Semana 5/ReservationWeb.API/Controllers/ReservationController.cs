using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationWeb.API.DataAccess;
using ReservationWeb.API.Services;
using ReservationWeb.API.DTO;

namespace ReservationWeb.API.Controllers
{
    [ApiController]
    [Route("api/Reservation")]//[Route("api/[controller]/[action]")]
    public class ReservationController : Controller
    {
        private readonly IReservationServices _reservationServices;
        public ReservationController( IReservationServices reservationServices) 
        {
                _reservationServices = reservationServices;
        }

        // GET: ReservationController
        [HttpGet]
        public async Task<ActionResult<List<ListReservationDTO>>> List()
        {
            var reservations = await _reservationServices.GetReservationsAsync();
            return Ok(reservations);
        }

        // POST: ReservationController/Create
        [HttpPost]
        public async Task<ActionResult> Create(AddReservationDTO addReservationDTO)
        {
            await _reservationServices.AddReservation(addReservationDTO);
            return Ok();
        }
    }
}
