using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAAProject.Data.Models.Domain;
using NAAProject.Data.Models.Repository;

namespace NAAProject.Data.Models.IDAO
{
    public interface IUserDAO
    {

        public void AddUser(NAAContext context, User user);
        public User GetUser(Application application, NAAContext context);
        public User GetUser(NAAContext context, string id);
        public IList<User> GetUsers(NAAContext context);

        public void RemoveFromCollection(Application application, User user, NAAContext context);
        public void AddToCollection(Application application, string userId, NAAContext context);
        public void UpdateUser(NAAContext context, User user);
    }
}
