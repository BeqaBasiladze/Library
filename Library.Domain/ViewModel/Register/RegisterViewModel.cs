using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.ViewModel.Register
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter your name")]
        [StringLength(50,MinimumLength = 3, ErrorMessage = "The string length must be between 3 and 50 characters")]
        public string Name { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The string length must be between 3 and 50 characters")]
        [Required(ErrorMessage = "Enter your last name")]
        public string LastName { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = " Email address is wrong")]
        [EmailAddress(ErrorMessage = "Incorrect email")]
        public string EmailAddress { get; set; }
        [Compare("EmailAddress", ErrorMessage = "Email do not match")]
        public string ConfirmEmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is wrong")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
