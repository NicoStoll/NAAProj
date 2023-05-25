using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAAProject.Data.Models.Domain;

namespace NAAProject.Services.IService
{
    public interface IApplicationService
    {
        IList<Application> GetApplications();
        Application GetApplication(int id);
        bool AddApplication(Application application, string userId);
        bool DeleteApplication(int id);
    }
}
