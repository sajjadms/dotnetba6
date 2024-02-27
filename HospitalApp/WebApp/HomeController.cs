using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ServiceLayer;

namespace WebApp
{
    public class HomeController : Controller
    {
        private AppointmentService _appointmentService;
        private PatientService _patientService;


        public HomeController()
        {
            _appointmentService = new AppointmentService();
            _patientService = new PatientService();
        }

        public IActionResult Dashboard()
        {
            var model = new DashboardModel
            {
                AppointmentSection = _appointmentService.GetAppointmentSection(),
                PatientSection = _patientService.GetPatientSectionModel()
            };

            return View(model);
        }
    }
}
