using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_uploader.Models
{
    public class AppAssignment
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public byte[] File { get; set; }

        public string Uploader { get; set; }
    }
}
