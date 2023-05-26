using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NAAProject.Data.Models.Domain;
using NAAProject.Data.Models.IDAO;
using NAAProject.Data.Models.Repository;
using static System.Net.Mime.MediaTypeNames;

namespace NAAProject.Data.Models.DAO
{
    public class UniversityDAO : IUniversityDAO
    {
		public IList<University> GetUniversities(NAAContext context)
		{
			context.Universities.Include(user => user.Applications).ToList();
			return context.Universities.ToList();
		}
		public University GetUniversity(NAAContext context, int id)
        {
            context.Universities.ToList();
            return context.Universities.Find(id);
        }
        public void AddUniversity(NAAContext context, University university)
        {
            context.Universities.Add(university);
        }

        public void DeleteUniversity(NAAContext context, University university)
        {
            context.Universities.Remove(university);
        }
        public void UpdateUniversity(NAAContext context, University university)
        {
            University a = context.Universities.Find(university.UniversityId);
            context.Entry(a).CurrentValues.SetValues(university);
        }

    }
}
