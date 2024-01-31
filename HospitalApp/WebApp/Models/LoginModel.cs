using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress(ErrorMessage = "Enter Valid Email Address")]
        [Display(Name = "Email Id")]     //<label asp-for ="Email" />  ->  <label>Email Id</label>
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Min 6 and Max 20 length")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [StringLength(10,MinimumLength = 4,ErrorMessage = "Min 4 and Max 10 length")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
    }
}
