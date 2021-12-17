using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Data;
using Tickets.Data.Services;
using Tickets.Models;

namespace Tickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _service;
        public CinemaController(ICinemaService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();

            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var producerDetail = await _service.GetByIdAsync(id);
            if (producerDetail == null)
            {
                return View("NotFound");
            }
            return View(producerDetail);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Logo,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var producerDetail = await _service.GetByIdAsync(id);
            if (producerDetail == null)
            {
                return View("NotFound");
            }
            return View(producerDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Name,Logo,Description")] Cinema cinema, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.UpdateAsync(id,cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var producerDetail = await _service.GetByIdAsync(id);
            if (producerDetail == null)
            {
                return View("NotFound");
            }
            return View(producerDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
