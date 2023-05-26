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
    public class UserService : IUserService
    {

        IUserDAO userDAO;
        IApplicationDAO applicationDAO;
        public UserService()
        {
            userDAO = new UserDAO();
            applicationDAO = new ApplicationDAO();
        }

        public void AddUser(User user)
        {
            using (NAAContext context = new NAAContext())
            {
                userDAO.AddUser(context, user);
                context.SaveChanges();
            }
        }

        public void DeleteUser(User user)
        {
            using (NAAContext context = new NAAContext())
            {
                //remove all applications of user
                IList<Application> applications = userDAO.GetApplicationCollection(context, user.UserId);
                for(int i = 0; i < applications.Count; i++)
                {
                    applicationDAO.DeleteApplication(context, applications[i]);
                }

                //remove all links to university
                IList<University> universities = userDAO.GetUniversitiesCollection(context, user.UserId);
                for(int i = 0; i < applications.Count; i++)
                {
                    userDAO.RemoveUniversityFromCollection(universities[i], user, context);
                }

                //remove user
                userDAO.DeleteUser(context, user);

                context.SaveChanges();
            }
        }

        public User GetUser(Application application)
        {
            using (NAAContext context = new NAAContext())
            {
                return userDAO.GetUser(application, context);
            }
        }

        public User GetUser(string userId)
        {
            using (NAAContext ctx = new NAAContext())
            {
                return userDAO.GetUser(ctx, userId);
            }
        }

        public IList<User> GetUsers()
        {
            using (NAAContext context = new NAAContext())
            {
                return userDAO.GetUsers(context);
            }
        }

        public void UpdateUser(User user)
        {
            using (NAAContext context = new NAAContext())
            {
                userDAO.UpdateUser(context, user);
                context.SaveChanges();
            }
        }
    }
}
