using Microsoft.EntityFrameworkCore;
using WebApp.Entities;
using WebApp.Models;

namespace WebApp.ServiceLayer
{
    public class AppointmentService
    {
        HospitalDbContext _dbContext;

        public AppointmentService()
        {
            _dbContext = new HospitalDbContext();
        }

        public IList<Appointment> GetAppointments()
        {
            // Eager Loading 
            return _dbContext.Appointments
                             .Include(p => p.Patient)
                             .Include(p => p.Doctor)
                             .Include(p => p.Clinic)
                             .OrderByDescending(p=>p.AppointmentDate)
                             .ToList();

                             
        }

        public void BookAppointment(BookAppointmentModel model)
        {
            var doctor = _dbContext.Doctors
                                   .FirstOrDefault(p => p.DoctorId == model.DoctorID);

            Appointment newAppt = new Appointment
            {
               PatientId = model.PatientID,
               DoctorId = model.DoctorID,
               ClinicId = doctor.ClinicId,
               AppointmentDate = model.AppointmentDate,
               AppointmentStatus = model.AppointmentStatus,
               CreationDate = DateTime.Now
            };

            _dbContext.Appointments.Add(newAppt);

            _dbContext.SaveChanges();

        }
    }
}
