using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_uploader.Models
{
    public class AppUser : IdentityUser
    {
        public string UniversityID { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string LastName { get; set; }

        public string Subject { get; set; }

        public int YearOfStudy { get; set; }

        public string FormOfStudy { get; set; }

        public string LevelOfStudy { get; set; }
    }
}
