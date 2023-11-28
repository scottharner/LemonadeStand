using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
