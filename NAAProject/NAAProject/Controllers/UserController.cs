using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NAAProject.Services.Service;
using NAAProject.Services.IService;
using NAAProject.Data.Models.Domain;

namespace NAAProject.Controllers
{
    public class UserController : Controller
    {

        IUserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        [Authorize(Roles = "User")]
        public ActionResult Details(int id)
        {
            string userId = HttpContext.Session.GetString("userId");

            if (userId != null)
            {
                return View(userService.GetUser(userId));
            }
            return View();
        }

        // GET: UserController/Create
        [Authorize(Roles = "User")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        [Authorize(Roles = "User")]
        public ActionResult Edit(string id)
        {
            return View(userService.GetUser(id));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user, IFormCollection collection)
        {
            try
            {
                userService.UpdateUser(user);
                return RedirectToAction("Details", "User", new {id = user.UserId});
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        [Authorize(Roles = "User")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
