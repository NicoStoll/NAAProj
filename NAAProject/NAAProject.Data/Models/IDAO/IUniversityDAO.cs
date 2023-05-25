using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAAProject.Data.Models.Domain;
using NAAProject.Data.Models.Repository;

namespace NAAProject.Data.Models.IDAO
{
    public interface IUniversityDAO
    {
        IList<University> GetUniversities(NAAContext context);
        University GetUniversity(NAAContext context, int id);
        void AddUniversity(NAAContext context, University university);
        void DeleteUniversity(NAAContext context, University university);
        void UpdateUniversity(NAAContext context, University university);
    }
}
