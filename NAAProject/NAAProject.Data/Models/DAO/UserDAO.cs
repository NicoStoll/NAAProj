using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAAProject.Data.Models.Domain;
using NAAProject.Data.Models.IDAO;
using NAAProject.Data.Models.Repository;

namespace NAAProject.Data.Models.DAO
{
    public class UserDAO : IUsersDAO
    {
        public User GetUser(Application application, NAAContext context) {

            Application m = context.Applications.Find(application.ApplicationId);

            IList<User> users = GetUsers(context);

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Applications.Contains<Application>(m))
                {
                    return users[i];
                }
            }
            return null;
        }

        public IList<User> GetUsers(NAAContext context)
        {
            return context.Users.ToList();
        }
    }
}
