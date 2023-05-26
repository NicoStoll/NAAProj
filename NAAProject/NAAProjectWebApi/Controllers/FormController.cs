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

        // GET: api/<StyleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IUniversityService universityService;
            universityService = new UniversityService();
            University[] uni = universityService.GetUniversities().ToArray();
            JsonConvert.SerializeObject(uni);

            if (uni == null)
                return NotFound();
            return Ok(uni);



            //return StatusCode(StatusCodes.Status200OK, students);
        }

        // GET api/<StyleController>/5
        [HttpGet("{uniName}")]
        public async Task<IActionResult> Get(string uniName)
        {

            List<ApplicationForm> applicationForms = service.GetForms(uniName);

            if (applicationForms == null || applicationForms.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound);

            JsonConvert.SerializeObject(applicationForms);
            return Ok(applicationForms);



        }

        // POST api/<StyleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StyleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StyleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
