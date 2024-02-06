using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class PatientModel
    {
        [Required(ErrorMessage = "Enter Name")]
        [Display(Name = "Patient Name")] 
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Min 4 and Max 50 length")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Enter Mobile No")]
        [Phone]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Enter Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Enter Adhar No")]
        public string AdharNo { get; set; }

        [Required(ErrorMessage = "Specify Gender(M/F)")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Specify Gender")]
        public string Gender { get; set; }

        [StringLength(500, ErrorMessage = "Max limit 500 characters")]
        public string Address { get; set; }

        public string BloodGroup { get; set; }

        [Display(Name = "Nationality")]
        public int? NationalityID { get; set; }

        public bool IsActive { get; set; }

        [HiddenInput]
        public int PatientId { get; set; }

        public IList<SelectListItem> Nationalities { get; set; }

        public PatientModel()
        {

        }
    }
}
