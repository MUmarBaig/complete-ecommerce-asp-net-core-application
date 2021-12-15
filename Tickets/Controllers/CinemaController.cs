using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Data;

namespace Tickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly AppDbContext _context;
        public CinemaController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Cinemas.ToListAsync();

            return View(data);
        }
    }
}
