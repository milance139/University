using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
    }
}
