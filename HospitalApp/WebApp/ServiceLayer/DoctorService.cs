using WebApp.Entities;

namespace WebApp.ServiceLayer
{
    public class DoctorService
    {
        HospitalDbContext _dbContext;

        public DoctorService() {

            _dbContext = new HospitalDbContext();   
        }

        public IList<Doctor> GetDoctors()
        {
            return _dbContext.Doctors.ToList();
        }

    }
}
