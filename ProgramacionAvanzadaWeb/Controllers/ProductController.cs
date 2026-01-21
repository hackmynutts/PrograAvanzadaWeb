using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacionAvanzadaWeb.Models;

namespace ProgramacionAvanzadaWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,Price")] ProductDTO productDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(productDTO);
                }
                productDTO.PriceTotal = (productDTO.Price * (decimal)1.13);
                return View("Details", productDTO);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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
