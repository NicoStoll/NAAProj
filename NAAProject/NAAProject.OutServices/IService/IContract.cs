using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAAProject.OutServices.Models;

namespace NAAProject.OutServices.IService
{
	public interface IContract
	{
		public List<ApplicationForm> GetForms(string uniName);
	}
}
