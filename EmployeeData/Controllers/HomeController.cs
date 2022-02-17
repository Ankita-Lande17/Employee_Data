using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmployeeData.Models;

namespace EmployeeData.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> stringLocalizer)
        {
            _logger = logger;
            _stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {

            ViewData["Message"] = _stringLocalizer["GreetingMessage"].Value;
            ViewData["Text"] = _stringLocalizer["TextContent"].Value;
            ViewData["Title"] = _stringLocalizer["PageTitle"].Value;
            //   string cultureName = string.IsNullOrEmpty(httpContext.Request.Query["culture"].ToString()) ? "en-us": httpContext.Request.Query["culture"].ToString();
            string cultureName = string.IsNullOrEmpty(httpContext.Request.Query["culture"].ToString()) ? "en-us" : httpContext.Request.Query["culture"].ToString();
            //return new ProviderCultureResult(cultureName);
            ViewData["culture"] = cultureName;

            //TempData["TempModel"] = "This is temp data";
            //TempData["TempKeepModel"] = "This is my temp data";
            //TempData["TempPeekModel"] = "This is my peek data";
            //List<string> Student = new List<string>();
            //Student.Add("A");
            //Student.Add("B");
            //Student.Add("C");

            //ViewData["Student"] = Student;

            //ViewBag.StudentData = Student;

            return View();

        }

        public IActionResult Privacy()
        {
            var value = TempData["TempKeepModel"];
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(Registration registration)
        {
            if (ModelState.IsValid)
            {
                if (registration.Email == "abc@gmail.com")
                {
                    ModelState.AddModelError("Email", "Email cannot be abc");
                }
                if (ModelState.ErrorCount == 0)
                {
                    Debug.WriteLine("Valid");
                    TempData["SuccessMessage"] = "Account created Successfully";
                }
            }
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
