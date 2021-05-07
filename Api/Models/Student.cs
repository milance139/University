using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [ForeignKey("Status")]
        public int  StatusID { get; set; }
        [StringLength(25)]
        public string FirstName { get; set; }
        [StringLength(25)]
        public string LastName { get; set; }
        public string Index { get; set; }
        [Required]
        [StringLength(10)]
        public string Year { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
