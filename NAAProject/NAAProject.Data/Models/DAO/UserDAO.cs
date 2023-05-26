using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NAAProject.Data.Models.Domain;
using NAAProject.Data.Models.IDAO;
using NAAProject.Data.Models.Repository;

namespace NAAProject.Data.Models.DAO
{
    public class UserDAO : IUserDAO
    {

		public User GetUser(NAAContext context, string id)
		{
			context.Users.Include(user => user.Applications).ToList();
			return context.Users.Find(id);
		}
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
			context.Users.Include(user => user.Applications).ToList();
			context.Users.Include(user => user.Universities).ToList();
			return context.Users.ToList();
        }

        public void RemoveFromCollection(Application application, User user, NAAContext context)
        {
            context.Users.Find(application.ApplicationId).Applications.Remove(application);
        }
        public void AddToCollection(Application application, string userId, NAAContext context)
        {
            Application app = context.Applications.Find(application.ApplicationId);


            context.Users.Find(userId).Applications.Add(app);
        }

        public void AddUser(NAAContext context, User user)
        {
            context.Users.Add(user);
        }

        public void UpdateUser(NAAContext context, User user)
        {
            User u = context.Users.Find(user.UserId);
            context.Entry(u).CurrentValues.SetValues(user);
        }

        public IList<Application> GetApplicationCollection(NAAContext context, string userId)
        {
            return context.Users.Find(userId).Applications.ToList();
        }

        public IList<University> GetUniversitiesCollection(NAAContext context, string userId)
        {
            return context.Users.Find(userId).Universities.ToList();
        }

        public void RemoveUniversityFromCollection(University university, User user, NAAContext context)
        {
            context.Users.Find(user.UserId).Universities.Remove(university);
        }

        public void DeleteUser(NAAContext context, User user)
        {
            context.Users.Remove(user);
        }
    }
}
