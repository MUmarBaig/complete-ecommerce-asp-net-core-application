using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Data;
using Tickets.Data.Services;
using Tickets.Models;

namespace Tickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _service;
        public MovieController(IMovieService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(a=>a.Cinema);

            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(a => a.Cinema);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(a=>a.Name.ToLower().Contains(searchString.ToLower()) 
                || a.Description.ToLower().Contains(searchString.ToLower())).ToList();
                if(filteredResult.Count > 0)
                {
                    return View("Index", filteredResult);
                }
                return View("Index",allMovies);
            }
            return View("Index",allMovies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);

            if(movieDetail == null)
            {
                return View("NotFound");
            }
            return View(movieDetail);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetMovieDropdownsValues();
            ViewBag.CinemaId = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.ProducerId = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.ActorId = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieVM movie)
        {
            
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetMovieDropdownsValues();
                ViewBag.CinemaId = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.ProducerId = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.ActorId = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }

            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            if (movieDetail == null)
            {
                return View("NotFound");
            }
            var response = new MovieVM()
            {
                Id = movieDetail.Id,
                Name = movieDetail.Name,
                Description = movieDetail.Description,
                Price = movieDetail.Price,
                ImageURL = movieDetail.ImageURL,
                StartDate=movieDetail.StartDate,
                EndDate=movieDetail.EndDate,
                MovieCategory = movieDetail.MovieCategory,
                CinemaId = movieDetail.CinemaId,
                ProducerId = movieDetail.ProducerId,
                ActorIds = movieDetail.Actors_Movies.Select(n => n.ActorId).ToList()
            };

            var movieDropdownsData = await _service.GetMovieDropdownsValues();
            ViewBag.CinemaId = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.ProducerId = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.ActorId = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,MovieVM movie)
        {
            if (id != movie.Id)
            {
                return View("NotFound");
            }
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetMovieDropdownsValues();
                ViewBag.CinemaId = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.ProducerId = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.ActorId = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }

            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
