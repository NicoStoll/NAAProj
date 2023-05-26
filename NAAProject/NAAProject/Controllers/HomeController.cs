using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NAAProject.Data;
using NAAProject.Models;
using NAAProject.Services.Service;

namespace NAAProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            context  = new ApplicationDbContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Admin()
        {
            UserRolesViewModel userRolesModel = new UserRolesViewModel()
            {
                Users = context.Users.ToList(),
                Roles = context.Roles.ToList(),
            };

            return View(userRolesModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}