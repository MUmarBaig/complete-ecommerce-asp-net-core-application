using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Data;
using Tickets.Data.Services;
using Tickets.Models;

namespace Tickets.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService _service;
        public ProducerController(IProducerService service)
        {
            _service= service;
        }
        public async Task<IActionResult> Index()
        {
            var data =await _service.GetAllAsync();

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
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
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
        public async Task<IActionResult> Edit([Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.UpdateAsync(id,producer);
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
