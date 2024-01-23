using WebApp.Entities;
using WebApp.Models;

namespace WebApp.ServiceLayer
{
    public class PatientService
    {

        public IList<Patient> GetPatients()
        {
            HospitalDbContext dbContext = new HospitalDbContext();

            IList<Patient> patients = dbContext.Patients.ToList();

            //return patients data(which is list of object of type Patient Model Class)
            return patients;
        }
    }
}
