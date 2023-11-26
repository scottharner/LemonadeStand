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

    public IActionResult List()
    {
        BeverageListViewModel beverageListViewModel = new BeverageListViewModel(_beverageRepository.AllBeverages, "All beverages");
        return View(beverageListViewModel);
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
}