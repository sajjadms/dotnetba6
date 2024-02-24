using WebApp.Entities;

namespace WebApp.ServiceLayer
{
    public class UserService
    {

        private HospitalDbContext _dbContext;

        public UserService()
        {
            _dbContext = new HospitalDbContext();
        }

        public User GetByEmailAndPassword(string email, string password)
        {
           return _dbContext.Users.FirstOrDefault(p=>p.Email == email && p.Password == password);
        }
    }
}
