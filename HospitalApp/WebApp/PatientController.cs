using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    public class PatientController : Controller
    {
        public IActionResult GetPatients()
        {
            return View("PatientsList");
        }

        public ActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SavePatient()
        {
            return RedirectToAction("GetPatients");
        }
    }
}
