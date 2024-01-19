namespace WebApp.Models
{
    public class PatientModel
    {
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string AdharNo { get; set; }
        public string Nationality { get; set; }
        public bool IsActive { get; set; }

        public int AgeInYears()
        {
            int age = 0;

            // Code to calcualte age of the patient

            return age;
            
        }

        public PatientModel()
        {

        }
    }
}
