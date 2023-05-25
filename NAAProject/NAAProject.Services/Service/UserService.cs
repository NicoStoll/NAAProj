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
        public UserService()
        {
            userDAO = new UserDAO();
        }
        public User GetUser(Application application)
        {
            using (NAAContext context = new NAAContext()) {
                return userDAO.GetUser(application, context);
            }
        }

        public IList<User> GetUsers()
        {
            using (NAAContext context = new NAAContext())
            {
                return userDAO.GetUsers(context);
            }
        }
}
