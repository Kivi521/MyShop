using Microsoft.AspNetCore.Mvc;

namespace MyShop.Controllers
{
    public class ABCController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
