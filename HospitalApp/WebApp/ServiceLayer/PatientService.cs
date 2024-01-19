using WebApp.Models;

namespace WebApp.ServiceLayer
{
    public class PatientService
    {

        public IList<PatientModel> GetPatients()
        {
            //Declare a list and assing with empty list
            IList<PatientModel> patientsData = new List<PatientModel>();

            //TODO: fetch the data from database

            //Adding dummy patient's data
            patientsData.Add(new PatientModel
            {
                FullName = "Sajjad Khan",
                AdharNo = "1232-1231-1231",
                Address = "NR NAGAR KURNOOL",
                DateOfBirth = DateTime.Now.AddYears(-35),
                IsActive = true,
                MobileNo = "998877442211",
                Nationality = "INDIAN"
            });
            patientsData.Add(new PatientModel
            {
                FullName = "Akram Ali",
                AdharNo = "4444-5555-33433",
                Address = "NR NAGAR KURNOOL",
                DateOfBirth = DateTime.Now.AddYears(-34),
                IsActive = true,
                MobileNo = "886674424223",
                Nationality = "INDIAN"
            });
            patientsData.Add(new PatientModel
            {
                FullName = "Younus Hussain",
                AdharNo = "9999-0000-21111",
                Address = "Buwarpeta KURNOOL",
                DateOfBirth = DateTime.Now.AddYears(-32),
                IsActive = true,
                MobileNo = "77888674424223",
                Nationality = "INDIAN"
            });

            //return patients data(which is list of object of type Patient Model Class)
            return patientsData;
        }
    }
}
