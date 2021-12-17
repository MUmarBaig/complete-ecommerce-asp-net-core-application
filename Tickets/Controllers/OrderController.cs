using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tickets.Data.Cart;
using Tickets.Data.Services;
using Tickets.Data.ViewModels;

namespace Tickets.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ShoppingCart _shoppingCart;
        public OrderController(IMovieService movieService, ShoppingCart shoppingCart)
        {
            _movieService = movieService;
            _shoppingCart = shoppingCart;
        }


        public IActionResult ShoppingCart()
        {
            var items=_shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                shoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            };

            return View(response);
        }

        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var item=await _movieService.GetByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveFromShoppingCart(int id)
        {
            var item = await _movieService.GetByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
