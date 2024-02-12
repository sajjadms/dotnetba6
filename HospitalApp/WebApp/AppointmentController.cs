using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Entities;
using WebApp.Models;
using WebApp.ServiceLayer;

namespace WebApp
{
    public class AppointmentController : Controller
    {
        private AppointmentService _appointmentService;
        private DoctorService _doctorService;
        private PatientService _patientService;

        public AppointmentController()
        {
            _appointmentService = new AppointmentService();
            _doctorService = new DoctorService();
            _patientService = new PatientService();
        }

        public IActionResult Dashboard()
        {
            IList<Appointment> appointments = 
                _appointmentService.GetAppointments();

            return View(appointments);
        }

        public IActionResult BookAppointment()
        {
            BookAppointmentModel model = new BookAppointmentModel();

            model.AppointmentDate = DateTime.Now;   // current date & time

            model.Doctors = new List<SelectListItem>();
            model.Doctors.Add(new SelectListItem
            {
                Text = "--Select--"
            });

            IList<Doctor> doctors = _doctorService.GetDoctors();
            foreach(Doctor doctor in doctors)
            {
                model.Doctors.Add(new SelectListItem
                {
                    Text = doctor.DoctorName,
                    Value = doctor.DoctorId.ToString()
                });
            }

            model.Patients = new List<SelectListItem>();
            model.Patients.Add(new SelectListItem
            {
                Text = "--Select--"
            });
            IList<Patient> patients = _patientService.GetPatients();
            foreach(var patient in patients)
            {
                model.Patients.Add(new SelectListItem
                {
                    Text = patient.PatientName,
                    Value = patient.PatientId.ToString()
                });
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateAppointment(BookAppointmentModel model)
        {
            _appointmentService.BookAppointment(model);

            return RedirectToAction("Dashboard");
        }
    }
}
