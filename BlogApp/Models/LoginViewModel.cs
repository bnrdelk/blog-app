using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(10, ErrorMessage = "Enter the {0} between {2}-{1} characters.", MinimumLength=6)]
        public string? Password { get; set; }


    }
}