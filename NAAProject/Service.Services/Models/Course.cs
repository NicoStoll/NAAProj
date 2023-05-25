using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Models
{
    public class Course
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; }
        public string Deegree { get; set; }
        public string University { get; set; }
        public string Overview { get; set; }
        public string Entry { get; set; }
        public int Nss { get; set; }

    }
}
