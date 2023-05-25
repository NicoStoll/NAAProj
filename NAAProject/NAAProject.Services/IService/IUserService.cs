using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAAProject.Data.Models.Domain;

namespace NAAProject.Services.IService
{
    public interface IUserService
    {
        IList<User> GetUsers();
        User GetUser(Application application);

        User GetUser(string userId);

        void AddUser(User user);

        void UpdateUser(User user);
    }
}
