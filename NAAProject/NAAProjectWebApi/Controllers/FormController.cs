using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NAAProject.Data.Models.Domain;
using NAAProject.OutServices.IService;
using NAAProject.OutServices.Models;
using NAAProject.OutServices.Service;
using NAAProject.Services.IService;
using NAAProject.Services.Service;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NAAProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {

        IContract service;
        public FormController()
        {
            service = new FormService();
        }

		// GET: api/<FormController>/allUsers
		[HttpGet("allUsers")]
		public async Task<IActionResult> Get()
        {

            IUserService userService = new UserService();
            User[] users = userService.GetUsers().ToArray();

            if (users == null) {
				return StatusCode(StatusCodes.Status404NotFound, "There is no user in the system yet!");
			}

            return Ok(users);



            //return StatusCode(StatusCodes.Status200OK, students);
        }

		// GET api/<FormController>/5
		[HttpGet("{uniName}")]
        public async Task<IActionResult> Get(string uniName)
        {

            List<ApplicationForm> applicationForms = service.GetForms(uniName);

            if (applicationForms == null || applicationForms.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound);

            JsonConvert.SerializeObject(applicationForms);
            return Ok(applicationForms);



        }

		// POST api/<FormController>
		[HttpPost]
        public void Post([FromBody] string value)
        {
        }

		// PUT api/<FormController>/5
		[HttpPut("{id}")]
        public StatusCodeResult Put(int id, [FromBody] string value)

        {
			service.MakeOffer(id,value,0);
			return StatusCode(StatusCodes.Status204NoContent);



		}

		// DELETE api/<FormController>/5
		[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
