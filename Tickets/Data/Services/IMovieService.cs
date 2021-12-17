using System.Threading.Tasks;
using Tickets.Data.Base;
using Tickets.Data.ViewModels;
using Tickets.Models;

namespace Tickets.Data.Services
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<MovieDropdownsVM> GetMovieDropdownsValues();

        Task AddNewMovieAsync(MovieVM data);
        Task UpdateMovieAsync(MovieVM data);
    }
}
