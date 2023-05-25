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

namespace NAAProject.OutServices.Service
{
	public class Service: IContract
	{
		IUserService userService;
		public Service()
		{
			userService = new UserService();
		}

		public Style[] GetRecordStyles()
		{
			User[] users = userService.GetUsers().ToList().ToArray();
			Style[] styles = new Style[users.Length];

			if(users.Length > 0)
			{
				for(int i = 0;i < users.Length; i++)
				{
					styles[i] = users[i];
				}
			}
			return styles;
		}
	}
}
