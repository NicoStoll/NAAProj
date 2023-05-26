using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Services.Models;

namespace NAAProject.Controllers
{
    public class SheffieldController : Controller
    {
        HttpClient client;
        public SheffieldController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://54.235.143.83/api/sheffield");
        }
        public ActionResult GetCourses()
        {
            IList<Course> courses = new List<Course>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            if (!response.IsSuccessStatusCode)
                return View();
            string data = response.Content.ReadAsStringAsync().Result;
            dynamic[] dynamics = JsonConvert.DeserializeObject<dynamic[]>(data);
            foreach (var item in dynamics)
            {
                courses.Add(new Course
                {
                    Code = item.id,
                    Name = item.name,
                    Deegree = item.qualification,
                    University = item.university,
                    Overview = item.description,
                    Entry = item.entryRequirements,
                    Nss = item.nss
                }
                    );
            }
            return View(courses);
        }
        // GET: SheffieldController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SheffieldController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SheffieldController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SheffieldController/Create
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

        // GET: SheffieldController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SheffieldController/Edit/5
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

        // GET: SheffieldController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SheffieldController/Delete/5
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
