using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    public class HomeController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
