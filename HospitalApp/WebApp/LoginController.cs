using Microsoft.AspNetCore.Mvc;
using WebApp.Entities;
using WebApp.Models;
using WebApp.ServiceLayer;

namespace WebApp
{
    public class LoginController : Controller
    {
        private UserService _userService;
        public LoginController()
        {
            _userService = new UserService();
        }

        [HttpGet()]
        public IActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitLogin(LoginModel model)
        {
            User userInfo = _userService.GetByEmailAndPassword(model.Email, model.Password);

            if (userInfo == null)
            {
                // user not exist with the email and password

                ModelState.AddModelError("", "Email or Password is not correct.");//Wrong Password or Email

                return View("Logon",model);
            }

            return RedirectToAction("Dashboard", "Home");
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Logon");
        }
    }
}
