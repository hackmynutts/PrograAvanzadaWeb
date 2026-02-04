using Microsoft.AspNetCore.Mvc;

namespace MVCPersonaWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MVCPersonaWeb.Models;
    using MVCPersonaWeb.Service;

    public class PersonasController : Controller
    {
        private readonly IPersonaService _service;
        public PersonasController(IPersonaService service) => _service = service;

        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var persona = await _service.GetByIdAsync(id.Value);
            if (persona == null) return NotFound();
            return View(persona);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Persona persona)
        {
            if (!ModelState.IsValid) return View(persona);
            await _service.CreateAsync(persona);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var persona = await _service.GetByIdAsync(id.Value);
            if (persona == null) return NotFound();
            return View(persona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Persona persona)
        {
            if (id != persona.Id) return BadRequest();
            if (!ModelState.IsValid) return View(persona);
            var ok = await _service.UpdateAsync(persona);
            if (!ok) return NotFound();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var persona = await _service.GetByIdAsync(id.Value);
            if (persona == null) return NotFound();
            return View(persona);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
