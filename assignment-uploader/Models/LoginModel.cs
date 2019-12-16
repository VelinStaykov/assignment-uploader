using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_uploader.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "You must enter your username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You must enter your password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
