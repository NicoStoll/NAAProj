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
        IUserDAO userDAO;
        public ApplicationService()
        {
            applicationDAO = new ApplicationDAO();
            userDAO = new UserDAO();
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
        public bool AddApplication(Application application, string userId)
        {
            try
            {
                using (NAAContext context = new NAAContext())
                {
            if (userDAO.GetUser(application, context).Applications.ToList().Count() >= 5) return false;             
                    applicationDAO.AddApplication(context, application);
                    userDAO.AddToCollection(application, userId, context);
                    context.SaveChanges();
                } 
                
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteApplication(int id)
        {
            try
            {
                using(NAAContext context = new NAAContext()){
                    Application application = applicationDAO.GetApplication(context, id);
                    applicationDAO.DeleteApplication(context, application);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
