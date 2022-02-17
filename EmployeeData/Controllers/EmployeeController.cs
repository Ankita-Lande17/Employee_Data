
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EmployeeData.Models;
using EmployeeData.Models.Service;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace Test.Controllers
{
   
    [TypeFilter(typeof(DebugLogAttribute))]
    [Route("Testing")]
    public class EmployeeController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        ModelView employeeViewModel;


        public EmployeeController(IMemoryCache memoryCache)
        {
            employeeViewModel = new ModelView();
            employeeViewModel.Employees.Add(new Employee()
            {

                Id = 1,
                EmployeeName = "Ankita",
                EmployeeAge = 22,
                EmployeeSalary = 32000

            });

            employeeViewModel.Employees.Add(new Employee()
            {
                Id = 2,
                EmployeeName = "Nikita",
                EmployeeAge = 26,
                EmployeeSalary = 35000
            });

            employeeViewModel.Employees.Add(new Employee()
            {
                Id = 3,
                EmployeeName = "Prashant",
                EmployeeAge = 24,
                EmployeeSalary = 50000

            });

            for (int i = 0; i <= 60; i++)
            {
                employeeViewModel.AgeDetails.Add(new Age
                {
                    Id = i,
                    Name = i

                });
            }
            _memoryCache = memoryCache;
        }
        [Route("")]
        public IActionResult Index(string id)
        {
            int empId = Convert.ToInt32(Common.DecryptString(id));
            List<SelectListItem> ObjList = new List<SelectListItem>();
            for(int i=0;i<= 60;i++)
            {
                ObjList.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            ViewBag.AgeList = employeeViewModel.AgeDetails;
            return View(employeeViewModel.Employees.FirstOrDefault(x => x.Id == empId));
        }
        [Route("Employees")]
        public IActionResult EmployeeList()
        {
            var CacheKey = "employeeList";
            if (!_memoryCache.TryGetValue(CacheKey, out ModelView employeeList))
            {
                employeeList = employeeViewModel;
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(20)
                };
                _memoryCache.Set(CacheKey, employeeList, cacheExpiryOptions);
            }
                return View(employeeViewModel);
        }
    }
}
