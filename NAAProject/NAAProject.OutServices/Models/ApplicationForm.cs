using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAAProject.Data.Models;
using NAAProject.Data.Models.Domain;

namespace NAAProject.OutServices.Models
{
	public class ApplicationForm
	{

		public string Name { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public virtual ICollection<Application> Applications { get; set; }
		public ApplicationForm(string name,string address, string phone, string email, ICollection<Application> Application)
		{

			
			Name = name;
			Address = address;
			Phone = phone;
			Email = email;
			Applications = Application;
		}

		public static implicit operator ApplicationForm(User user)
		{
			return new ApplicationForm(user.Name,user.Address,user.Phone,user.Email, user.Applications);
		}
	
	}
}
