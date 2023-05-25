using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAAProject.Data.Models.DAO;
using NAAProject.Data.Models.Domain;
using NAAProject.Data.Models.IDAO;
using NAAProject.Data.Models.Repository;
using NAAProject.Services.IService;

namespace NAAProject.Services.Service
{
    public class UniversityService : IUniversityService
    {
        IUniversityDAO universityDAO;
        public UniversityService()
        {
            universityDAO = new UniversityDAO();
        }
        public University GetUniversity(int id)
        {
            using (NAAContext context = new NAAContext())
            {
                University university = universityDAO.GetUniversity(context, id);
                return university;
            }
        }

        public IList<University> GetuUniversities()
        {
            using (NAAContext context = new NAAContext())
            {
                return universityDAO.GetUniversities(context);
            }
        }
    }
}
