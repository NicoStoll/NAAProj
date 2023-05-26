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

        void DeleteUser(User user);
    }
}
