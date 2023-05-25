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
        public ActionResult GetApplications()
        {
            return View(applicationService.GetApplications());
        }
        // GET: ApplicationController/Details/5
        public ActionResult Details(int id)
        {
            return View(applicationService.GetApplication(id));
        }

        // GET: ApplicationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Application application)
        {
            try
            {
                applicationService.AddApplication(application, "mo");
                return RedirectToAction("GetApplications", "Application",
                    new {id = application.ApplicationId});
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicationController/Edit/5
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

        // GET: ApplicationController/Delete/5
        public ActionResult Delete(int id)
        {
            Application application = applicationService.GetApplication(id);
            return View(application);
        }

        // POST: ApplicationController/Delete/5
        [HttpPost]
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
