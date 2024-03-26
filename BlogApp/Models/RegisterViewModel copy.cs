using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "Username")]
        public string? UserName { get; set; }

        [Required]
        [Display(Name = "Name Surname")]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set;}

        [Required]  
        [StringLength(10, ErrorMessage = "Enter the {0} between {2}-{1} characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required]  
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The passwords you entered do not match.")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }
    }
}