using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_uploader.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "You must enter a username.")]
        [StringLength(20,ErrorMessage = "Your username must be between 6 and 20 symbols.", MinimumLength = 6)]
        public string Username { get; set; }

        [Required(ErrorMessage = "You must enter an E-Mail address.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "You must enter a valid E-Mail address.")]
        [Display(Name = "E-Mail Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter your University ID.")]
        [Display(Name = "University ID")]
        public string UniversityId { get; set; }

        [Required(ErrorMessage = "You must enter your First Name.")]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "You must enter your Last Name.")]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must enter a password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "You must confirm the password.")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Passwords must match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "You must enter your subject of study.")]
        [StringLength(20)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "You must choose your year in university.")]
        [Display(Name = "Year of study")]
        public int YearOfStudy { get; set; }

        [Required(ErrorMessage = "You must choose your form of study.")]
        [Display(Name = "Form of study")]
        public string FormOfStudy { get; set; }

        [Required(ErrorMessage = "You must choose your level of study.")]
        [Display(Name = "Level of study")]
        public string LevelOfStudy { get; set; }
    }
}
