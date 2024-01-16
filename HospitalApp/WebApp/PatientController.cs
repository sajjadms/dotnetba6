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
            // code related to saving patient 

            return RedirectToAction("PatientDetail");
        }

        public ActionResult PatientDetail()
        {
            return View();
        }

        public ActionResult EditPatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdatePatient()
        {
            return RedirectToAction("PatientDetail");
        }
    }
}
