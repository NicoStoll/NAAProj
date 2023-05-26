using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

		public void MakeOffer(int id, string value)
		{
			IUserService userService;
			userService = new UserService();

			User[] users = userService.GetUsers().ToArray();
			List<ApplicationForm> applicationForms = new List<ApplicationForm>();

			IApplicationService applicationService;
			applicationService = new ApplicationService();

			

			for (int i = 0; i < users.Length; i++)
			{
				for (int j = 0; j < users[i].Universities.ToArray().Length; j++)
				{

					if (users[i].Applications.ToArray()[j].ApplicationId == id)
					{
						//int ApplicationId = users[i].Applications.ToArray()[j].ApplicationId;
						//string Course = users[i].Applications.ToArray()[j].Course;
						//string Statement = users[i].Applications.ToArray()[j].Statement;
						//string TeacherContact = users[i].Applications.ToArray()[j].TeacherContact;
						//string TeacherReference = users[i].Applications.ToArray()[j].TeacherReference;
						//bool Firm = users[i].Applications.ToArray()[j].Firm;
						//string Offer = value;

						Application applicationUpdated = users[i].Applications.ToArray()[j];

						applicationUpdated.Offer = value;

						applicationService.UpdateApplication(applicationUpdated);



					}
				}
			}
		}
	}
}
