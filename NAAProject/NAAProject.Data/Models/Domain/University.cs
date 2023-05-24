

using System.ComponentModel.DataAnnotations;

namespace NAAProject.Data.Models.Domain
{
    public class University
    {
        [Key]
        public int UniversityId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Application> Applications { get; set; }

    }
}
