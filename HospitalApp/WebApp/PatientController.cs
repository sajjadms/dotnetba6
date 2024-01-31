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
        public ActionResult SavePatient(PatientModel patientData)
        {

            Patient patient = new Patient
            {
                PatientName = patientData.FullName,
                AdharNo = patientData.AdharNo,
                BloodGroup = patientData.BloodGroup,
                DateOfBirth = patientData.DateOfBirth,
                Gender = patientData.Gender,
                IsActive = patientData.IsActive,
                MobileNo = patientData.MobileNo,
                Nationality = patientData.Nationality
            };

            PatientService patientService = new PatientService();

            patientService.SavePatient(patient);

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
