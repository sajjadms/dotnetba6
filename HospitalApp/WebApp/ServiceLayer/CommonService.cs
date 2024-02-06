using WebApp.Entities;

namespace WebApp.ServiceLayer
{
    public class CommonService
    {

        public CommonService() { }

        public IList<Nationality> GetNationalities()
        {
            HospitalDbContext dbContext = new HospitalDbContext();

            IList<Nationality> nationalities = dbContext.Nationalities.ToList();

            return nationalities;
        }
    }
}
