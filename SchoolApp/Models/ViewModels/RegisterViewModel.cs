using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassApp.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }


        [Required]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage ="The {0} must be at least {2} characters long", MinimumLength = 6)]
        public string Password { get; set; }


        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage ="The password and confirmation password do not match. ")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
