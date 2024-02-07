using WebApp.Entities;

namespace WebApp.ServiceLayer
{
    public class CommonService
    {
        HospitalDbContext _dbContext;

        public CommonService() {
            _dbContext = new HospitalDbContext();
        }

        public IList<Nationality> GetNationalities()
        {
            IList<Nationality> nationalities = _dbContext.Nationalities.ToList();

            return nationalities;
        }
    }
}
