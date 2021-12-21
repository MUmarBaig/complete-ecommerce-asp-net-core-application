using System.Collections.Generic;
using System.Threading.Tasks;
using Tickets.Models;

namespace Tickets.Data.Services
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId,string userRole);
    }
}
