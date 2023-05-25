using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Services.Models;

namespace NAAProject.Controllers
{
    public class SHUController : Controller
    {
        HttpClient client;
        public SHUController() 
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("54.235.143.83/api/shu");
        }
        public IList<Course> GetCourses()
        {
        IList<Course> courses = new List<Course>();
        HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            if (!response.IsSuccessStatusCode)
                return courses;
            string data = response.Content.ReadAsStringAsync().Result;
            dynamic[] dynamics = JsonConvert.DeserializeObject<dynamic>(data);
            foreach(var item in dynamics)
            {
                courses.Add(new Course
                {
                    Code = item.Code,
                    Name = item.Name,
                    Deegree = item.Degree,
                    University = item.University,
                    Overview = item.Overview,
                    Entry = item.Entry,
                    Nss = item.Nss
                }
                    );
                           }
            return courses;
        }
        // GET: SHUController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SHUController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SHUController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SHUController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SHUController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SHUController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SHUController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SHUController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
