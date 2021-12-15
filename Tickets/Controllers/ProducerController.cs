using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Data;
using Tickets.Data.Services;

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
    }
}
