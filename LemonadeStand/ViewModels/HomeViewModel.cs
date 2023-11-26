using LemonadeStand.Models;

namespace LemonadeStand.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Beverage> FeaturedBeverages { get; }

        public HomeViewModel(IEnumerable<Beverage> featuredBeverages)
        {
            FeaturedBeverages = featuredBeverages;
        }
    }
}
