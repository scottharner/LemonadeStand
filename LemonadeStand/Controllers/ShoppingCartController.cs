using LemonadeStand.Models;
using LemonadeStand.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.Controllers
{
    public class ShoppingCartController: Controller
    {
        private readonly IBeverageRepository _beverageRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IBeverageRepository beverageRepository, IShoppingCart shoppingCart)
        {
            _beverageRepository = beverageRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int beverageId)
        {
            var selectedBeverage = _beverageRepository.AllBeverages.FirstOrDefault(b => b.BeverageId == beverageId);

            if ( selectedBeverage != null)
            {
                _shoppingCart.AddToCart(selectedBeverage);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int beverageId)
        {
            var selectedBeverage = _beverageRepository.AllBeverages.FirstOrDefault(b => b.BeverageId == beverageId);

            if (selectedBeverage != null)
            {
                _shoppingCart.RemoveFromCart(selectedBeverage);
            }

            return RedirectToAction("Index");
        }
    }
}
