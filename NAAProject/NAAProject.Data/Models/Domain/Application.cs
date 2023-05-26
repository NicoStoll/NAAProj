using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAAProject.Data.Models.Domain
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }
        public string Course { get; set; }
        public string Statement { get; set; }
        public string TeacherContact { get; set; }
        public string TeacherReference { get; set; }
        public string Offer { get; set; } = "P";
        public bool Firm { get; set; } = false;

    }
}
