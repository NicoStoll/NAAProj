using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAAProject.Data.Models.Domain;
using NAAProject.OutServices.IService;
using NAAProject.OutServices.Models;
using NAAProject.Services.IService;
using NAAProject.Services.Service;
using Newtonsoft.Json;

namespace NAAProject.OutServices.Service
{
	public class FormService : IContract
	{
		IUserService userService;
		public FormService()
		{
			userService = new UserService();
		}

		public List<ApplicationForm> GetForms(string uniName)
		{
			IUserService userService;
			userService = new UserService();

			User[] users = userService.GetUsers().ToArray();
			List<ApplicationForm> applicationForms = new List<ApplicationForm>();



			for (int i = 0; i < users.Length; i++)
			{
				for (int j = 0; j < users[i].Universities.ToArray().Length; j++)
				{

					if (users[i].Universities.ToArray()[j].Name == uniName)
					{
						string name = users[i].Name;
						string address = users[i].Address;
						string phone = users[i].Phone;
						string email = users[i].Email;
						Application[] applications = users[i].Universities.ToArray()[j].Applications.ToArray();

						ApplicationForm form = new ApplicationForm(name, address, phone, email, applications);
						applicationForms.Add(form);
					}
				}
			}

			return applicationForms;
		}
	}
}
