using Microsoft.AspNetCore.Authorization;
using System.Data;
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
        [Authorize(Roles = "User")]
        public ActionResult Index()
        {
            return View();
        }

       // [Authorize(Roles = "User")]
        public ActionResult GetUniversities()
        {
            return View(universityService.GetUniversities());
        }

        [Authorize(Roles = "User")]
        public ActionResult GetUniversity(int id)
        {
            return View(universityService.GetUniversity(id));
        }
        // GET: UniversityController/Details/5
        [Authorize(Roles = "User")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniversityController/Create
        [Authorize(Roles = "User")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversityController/Create
        [HttpPost]
        [Authorize(Roles = "User")]
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
        [Authorize(Roles = "User")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UniversityController/Edit/5
        [HttpPost]
        [Authorize(Roles = "User")]
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
        [Authorize(Roles = "User")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UniversityController/Delete/5
        [HttpPost]
        [Authorize(Roles = "User")]
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
