using Tickets.Data.Base;
using Tickets.Models;

namespace Tickets.Data.Services
{
    public class CinemaService:EntityBaseRepository<Cinema>,ICinemaService
    {
        public CinemaService(AppDbContext context):base(context)
        {

        }
    }
}
