using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Data;
using Tickets.Data.Services;
using Tickets.Models;

namespace Tickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService _service;
        public ActorController(IActorService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        public async  Task<IActionResult> Details(int id)
        {
            var actorDetail =await _service.GetByIdAsync(id);
            if(actorDetail == null)
            {
                return View("NotFound");
            }
            return View(actorDetail);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetail = await _service.GetByIdAsync(id);
            if (actorDetail == null)
            {
                return View("NotFound");
            }
            return View(actorDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor,int id)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetail = await _service.GetByIdAsync(id);
            if (actorDetail == null)
            {
                return View("NotFound");
            }
            return View(actorDetail);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var actorDetails= await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
           
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
