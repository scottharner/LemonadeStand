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
        ViewBag.CurrentCategory = "Lemony";
        return View(_beverageRepository.AllBeverages);
    }
}