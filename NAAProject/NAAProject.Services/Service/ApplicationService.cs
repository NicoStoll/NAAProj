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
    public class ApplicationService : IApplicationService
    {
        IApplicationDAO applicationDAO;
        public ApplicationService()
        {
            applicationDAO = new ApplicationDAO();
        }
        public Application GetApplication(int id)
        {
            using (NAAContext context = new NAAContext())
            {
                Application application = applicationDAO.GetApplication(context, id);
                return application;
            }
        }

        public IList<Application> GetApplications()
        {
            using (NAAContext context = new NAAContext())
            {
                return applicationDAO.GetApplications(context);
            }
        }
    }
}
