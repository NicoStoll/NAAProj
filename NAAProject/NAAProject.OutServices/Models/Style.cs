using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAAProject.Data.Models.Domain;

namespace NAAProject.OutServices.Models
{
	public class Style
	{
		public string Id;
		public string Name;
		public Record[] Records;

		Style(string id, string name, Record[] records) {
			Id = id;
			Name = name;
			Records = records;
		}

		public static implicit operator Style(User user)
		{

			Application[] applications = user.Applications.ToArray();
			Record[] records=  new Record[applications.Length];
			if(applications.Length > 0 )
			{
				for (int i = 0; i < applications.Length; i++) {
					records[i] = applications[i];
				}
			}
			return new Style(user.UserId, user.Name, records);
		
		}
	}
}
