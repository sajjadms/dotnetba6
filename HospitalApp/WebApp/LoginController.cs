using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    public class LoginController : Controller
    {
        [HttpGet()]
        public IActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitLogin()
        {
            return RedirectToAction("Dashboard", "Home");
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Logon");
        }
    }
}
