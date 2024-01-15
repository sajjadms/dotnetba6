using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    public class ClinicController : Controller
    {
        public IActionResult GetClinics()
        {
            return View("ClinicsList");
        }
    }
}
