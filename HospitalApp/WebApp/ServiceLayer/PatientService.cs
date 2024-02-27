using Microsoft.EntityFrameworkCore;
using WebApp.Entities;
using WebApp.Models;

namespace WebApp.ServiceLayer
{
    public class PatientService
    {
        HospitalDbContext _dbContext;

        public PatientService()
        {
            _dbContext = new HospitalDbContext();
        }

        public IList<Patient> GetPatients()
        {
            IList<Patient> patients =
                _dbContext.Patients.Include(x=>x.Nationality) .ToList(); //fetching patients data from DB

            //return patients data(which is list of object of type Patient Model Class)
            return patients;
        }

        public Patient SavePatient(Patient patient)
        {
            if(patient.PatientId == 0)
            {
                _dbContext.Patients.Add(patient);//i am adding new patient 
            }
            else
            {
                _dbContext.Patients.Update(patient);    // i am updating the patient
            }

            _dbContext.SaveChanges();   // EF will bring the latest added Patient Id

            return patient;
        }

        public Patient GetPatientById(int patientId)
        {
            return _dbContext.Patients.Include(p=>p.Nationality).FirstOrDefault(p=>p.PatientId == patientId);
        }

        public PatientSectionModel GetPatientSectionModel()
        {
            var model = new PatientSectionModel
            {
               TotalPatients = TotalPatientsCount()
            };

            return model;
        }
        public int TotalPatientsCount()
        {
            return _dbContext.Patients.Count();
        }
    }
}
