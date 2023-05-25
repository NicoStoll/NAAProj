using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAAProject.Data.Models.Domain;
using NAAProject.Data.Models.Repository;

namespace NAAProject.Data.Models.IDAO
{
    public interface IApplicationDAO
    {
        IList<Application> GetApplications(NAAContext context);
        Application GetApplication(NAAContext context, int id);
        void AddApplication(NAAContext context, Application application);
        void DeleteApplication(NAAContext context, Application application);
        void UpdateApplication(NAAContext contet, Application application);
    }
}
