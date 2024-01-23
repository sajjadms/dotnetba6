using Microsoft.AspNetCore.Mvc;
using WebApp.Entities;
using WebApp.Models;
using WebApp.ServiceLayer;

namespace WebApp
{
    public class PatientController : Controller
    {
        public IActionResult GetPatients()
        {
            //Creating an object of PatientService
            PatientService patientService = new PatientService();

            IList<Patient> patientsData = patientService.GetPatients();

            return View("PatientsList", patientsData);
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
