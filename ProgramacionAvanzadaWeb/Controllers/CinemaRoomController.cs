using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacionAvanzadaWeb.Models;

namespace ProgramacionAvanzadaWeb.Controllers
{
    public class CinemaRoomController : Controller
    {

        
        // GET: CinemaRoomController
        public ActionResult ListCinemaRooms()
        {
            List<CinemaRoomDTO> cinemaRooms = new List<CinemaRoomDTO>()
                {
                    new CinemaRoomDTO(){ id=1, nombre="Sala 1", type="2D", capacity=100, cantSold=93},
                    new CinemaRoomDTO(){ id=2, nombre="Sala 2", type="3D", capacity=100, cantSold=50},
                    new CinemaRoomDTO(){ id=3, nombre="Sala 3", type="IMAX", capacity=200, cantSold=80},
                };
            return View(cinemaRooms);
        }

        // GET: CinemaRoomController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CinemaRoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CinemaRoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CinemaRoomController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CinemaRoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
