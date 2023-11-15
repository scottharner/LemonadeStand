using LemonadeStand.Models;

namespace LemonadeStand.ViewModels
{
    public class BeverageListViewModel
    {
        public IEnumerable<Beverage> Beverages { get; }
        public string? CurrentCategory { get; }

        public BeverageListViewModel(IEnumerable<Beverage> beverages, string? currentCategory)
        {
            Beverages = beverages;
            CurrentCategory = currentCategory;
        }
    }
}
