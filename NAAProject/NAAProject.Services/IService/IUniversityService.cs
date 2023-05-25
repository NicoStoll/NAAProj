using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAAProject.Data.Models.Domain;

namespace NAAProject.Services.IService
{
    public interface IUniversityService
    {
        IList<University> GetuUniversities();
        University GetUniversity(int id);
    }
}
