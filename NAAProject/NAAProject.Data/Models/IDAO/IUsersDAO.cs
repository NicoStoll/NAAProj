using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAAProject.Data.Models.Domain;
using NAAProject.Data.Models.Repository;

namespace NAAProject.Data.Models.IDAO
{
    public interface IUsersDAO
    {
        public User GetUser(Application application, NAAContext context);
        public IList<User> GetUsers(NAAContext context);
    }
}
