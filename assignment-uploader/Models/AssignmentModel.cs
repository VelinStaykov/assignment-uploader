using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_uploader.Models
{
    public class AssignmentModel
    {
        [Required(ErrorMessage = "You must enter a title.")]
        [StringLength(20)]
        public string Title { get; set; }

        [Required(ErrorMessage = "You must choose a file.")]
        public IFormFile File { get; set; }
    }
}
