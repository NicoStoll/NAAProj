using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NAAProject.Services.Service;
using NAAProject.Services.IService;
using NAAProject.Data.Models.Domain;
using Microsoft.AspNetCore.Identity;
using NAAProject.Data;

namespace NAAProject.Controllers
{
    public class UserController : Controller
    {

        IUserService userService;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(SignInManager<IdentityUser> signInManager)
        {
            userService = new UserService();
            _signInManager = signInManager;
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

        [Authorize(Roles = "User")]
        public ActionResult Edit(string id)
        {
            return View(userService.GetUser(id));
        }

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

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            User u = userService.GetUser(id);
            return View(u);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, IFormCollection collection)
        {
            try
            {

                //remove user info
                userService.DeleteUser(userService.GetUser(id));

                //remove from identity
                IdentityUser user = await _signInManager.UserManager.FindByIdAsync(id);
                _signInManager.UserManager.DeleteAsync(user);

                return RedirectToAction("Admin", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
