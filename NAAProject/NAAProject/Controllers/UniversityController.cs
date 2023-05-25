using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NAAProject.Services.IService;
using NAAProject.Services.Service;

namespace NAAProject.Controllers
{
    public class UniversityController : Controller
    {
        IUniversityService universityService;
        public UniversityController() 
        {
            universityService = new UniversityService();
        }
        // GET: UniversityController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetUniversities()
        {
            return View(universityService.GetUniversities());
        }
        public ActionResult GetUniversity(int id)
        {
            return View(universityService.GetUniversity(id));
        }
        // GET: UniversityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniversityController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversityController/Create
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

        // GET: UniversityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UniversityController/Edit/5
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

        // GET: UniversityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UniversityController/Delete/5
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
