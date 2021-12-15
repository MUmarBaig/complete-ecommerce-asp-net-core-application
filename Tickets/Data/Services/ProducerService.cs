using Tickets.Data.Base;
using Tickets.Models;

namespace Tickets.Data.Services
{
    public class ProducerService:EntityBaseRepository<Producer>,IProducerService
    {
        public ProducerService(AppDbContext context):base(context)
        {

        }
    }
}
