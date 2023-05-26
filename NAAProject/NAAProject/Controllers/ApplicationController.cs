using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NAAProject.Data.Models.Domain;
using NAAProject.Services.IService;
using NAAProject.Services.Service;

namespace NAAProject.Controllers
{
    public class ApplicationController : Controller
    {
        IApplicationService applicationService;

        public ApplicationController()
        {
            applicationService = new ApplicationService();
        }
        // GET: ApplicationController
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public ActionResult GetApplications()
        {
            string userId = HttpContext.Session.GetString("userId");
            return View(applicationService.GetApplications(userId));
        }
        // GET: ApplicationController/Details/5
        [Authorize(Roles = "User")]
        public ActionResult Details(int id)
        {
            return View(applicationService.GetApplication(id));
        }

        // GET: ApplicationController/Create
        [Authorize(Roles = "User")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationController/Create
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Application application)
        {
            try
            {
                string userId = HttpContext.Session.GetString("userId");

                applicationService.AddApplication(application, userId, ViewBag.uniId);
                return RedirectToAction("GetApplications", "Application",
                    new {id = application.ApplicationId});
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicationController/Edit/5
        [Authorize(Roles = "User")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicationController/Edit/5
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

        public ActionResult Accept(int id) // Nicht fertig. TODO: User darf nur eine akzeptieren
        {
            Application application = applicationService.GetApplication(id);
            application = new Application()
            {
                ApplicationId = application.ApplicationId,
                Course = application.Course,
                Statement = application.Statement,
                TeacherContact = application.TeacherContact,
                TeacherReference = application.TeacherReference,
                Offer = application.Offer,
                Firm = true
            };
            applicationService.UpdateApplication(application);
            return RedirectToAction("GetApplication", "Application",
                    new { id = application.ApplicationId });
        }
        // GET: ApplicationController/Delete/5
        [Authorize(Roles = "User")]
        public ActionResult Delete(int id)
        {
            Application application = applicationService.GetApplication(id);
            return View(application);
        }

        // POST: ApplicationController/Delete/5
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Application application = applicationService.GetApplication(id);
                applicationService.DeleteApplication(id);
                return RedirectToAction("GetApplications", "Application", application.ApplicationId);
            }
            catch
            {
                return View();
            }
        }
    }
}
