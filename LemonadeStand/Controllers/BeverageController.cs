using LemonadeStand.Models;
using LemonadeStand.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class BeverageController: Controller
{
    private readonly IBeverageRepository _beverageRepository;
    private readonly ICategoryRepository _categoryRepository;

    public BeverageController(IBeverageRepository beverageRepository, ICategoryRepository categoryRepository)
    {
        _beverageRepository = beverageRepository;
        _categoryRepository = categoryRepository;
    }

    public IActionResult Details(int id)
    {
        var beverage = _beverageRepository.GetBeverageById(id);
        if (beverage == null)
        {
            return NotFound();
        }

        return View(beverage);
    }

    public ViewResult List(string category)
    {
        IEnumerable<Beverage> beverages;
        string? currentCategory;

        if (string.IsNullOrEmpty(category))
        {
            beverages = _beverageRepository.AllBeverages.OrderBy(b => b.BeverageId);
            currentCategory = "All beverages";
        }
        else
        {
            beverages = _beverageRepository.AllBeverages.Where(b => b.Category.Name == category).OrderBy(b => b.BeverageId);
            currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.Name == category)?.Name;
        }

        return View(new BeverageListViewModel(beverages, currentCategory));
    }
}