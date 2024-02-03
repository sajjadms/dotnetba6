using WebApp.Entities;
using WebApp.Models;

namespace WebApp.ServiceLayer
{
    public class PatientService
    {

        public IList<Patient> GetPatients()
        {
            HospitalDbContext dbContext = new HospitalDbContext();

            IList<Patient> patients = dbContext.Patients.ToList(); //fetching patients data from DB

            //return patients data(which is list of object of type Patient Model Class)
            return patients;
        }

        public Patient SavePatient(Patient patient)
        {
            HospitalDbContext dbContext = new HospitalDbContext();

            if(patient.PatientId == 0)
            {
                dbContext.Patients.Add(patient);//i am adding new patient 
            }
            else
            {
                dbContext.Patients.Update(patient);    // i am updating the patient
            }

            dbContext.SaveChanges();   // EF will bring the latest added Patient Id

            return patient;
        }

        public Patient GetPatientById(int patientId)
        {
            HospitalDbContext dbContext = new HospitalDbContext();

            Patient patient = dbContext.Patients.FirstOrDefault(p=>p.PatientId == patientId);

            return patient;
        }
    }
}
