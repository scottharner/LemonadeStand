using LemonadeStand.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBeverageRepository _beverageRepository;

        public HomeController(IBeverageRepository beverageRepository)
        {
            _beverageRepository = beverageRepository;
        }

        public IActionResult Index()
        {
            var featuredBeverages = _beverageRepository.FeaturedBeverages;
            var homeViewModel = new HomeViewModel(featuredBeverages);
            return View(homeViewModel);
        }
    }
}
