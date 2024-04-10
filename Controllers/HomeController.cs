using Microsoft.AspNetCore.Mvc;

namespace DemoAutorization.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
