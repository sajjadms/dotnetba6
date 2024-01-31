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

        public void SavePatient(Patient patient)
        {
            HospitalDbContext dbContext = new HospitalDbContext();

            dbContext.Patients.Add(patient);// adding an object to Save/Insert Patient into the DB

            dbContext.SaveChanges();
        }
    }
}
