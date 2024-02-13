using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class BookAppointmentModel
    {
        [Required(ErrorMessage = "Select a patient")]
        [Display(Name = "Patient")]
        public int PatientID { get; set; }

        [Required(ErrorMessage = "Select a doctor")]
        [Display(Name = "Doctor")]
        public int DoctorID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Select a status")]
        public int AppointmentStatus { get; set; }


        public IList<SelectListItem> Doctors { get; set; }

        public IList<SelectListItem> Patients { get; set; }

    }
}
