using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAAProject.Data.Models;
using NAAProject.Data.Models.Domain;

namespace NAAProject.OutServices.Models
{
	public class Record
	{
		public int Id;
		public string Name;
		public Record(int id, string name) {

			Id = id; 
			Name = name;
		}

		public static implicit operator	Record(Application application) { 
			return new Record(application.ApplicationId, application.Course); }
	}
}
