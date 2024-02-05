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
                NationalityId = patientData.NationalityID
            };

            PatientService patientService = new PatientService();

            patientService.SavePatient(patient);

            //once new patient was added, new PatientID will be autoincremented
            // this newly incremented Patient value will be bindded to Patient.PatientID  by EF

            return RedirectToAction("PatientDetail",new {patientId = patient.PatientId });
        }

        public ActionResult PatientDetail(int patientId)
        {
            PatientService patientService = new PatientService();

            Patient patient = patientService.GetPatientById(patientId);

            return View(patient);
        }

        public ActionResult EditPatient(int patientId)
        {
            PatientService patientService = new PatientService();

            //Fetch the patient data
            Patient patient = patientService.GetPatientById(patientId);

            // bind patient data to model
            PatientModel model = new PatientModel
            {
                FullName = patient.PatientName,
                AdharNo = patient.AdharNo,
                BloodGroup = patient.BloodGroup,
                DateOfBirth = patient.DateOfBirth.Value,
                Gender = patient.Gender,
                IsActive = patient.IsActive.Value,
                MobileNo = patient.MobileNo,
                NationalityID = patient.NationalityId,
                PatientId = patient.PatientId
            };

            //render patient form
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdatePatient(PatientModel patientData)
        {
            PatientService patientService = new PatientService();

            Patient patient = patientService.GetPatientById(patientData.PatientId);

            patient.PatientName = patientData.FullName;
            patient.DateOfBirth = patientData.DateOfBirth;
            patient.AdharNo = patientData.AdharNo;
            patient.BloodGroup = patientData.BloodGroup;
            patient.Gender = patientData.Gender;
            patient.IsActive = patientData.IsActive;
            patient.NationalityId = patientData.NationalityID;

            patientService.SavePatient(patient);

            return RedirectToAction("PatientDetail", new { patientId = patient.PatientId});
        }
    }
}
