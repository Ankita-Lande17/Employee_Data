using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeData.Models
{
    public class ModelView
    {
        public ModelView()
        {
            Employees = new List<Employee>();
            AgeDetails = new List<Age>();
        }
        public List<Employee> Employees { get; set; }
        public List<Age> AgeDetails { get; set; }


    }
    public class Age
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
    public class Employee
    {
        [Display (Name = "Employee Id")]
        public int Id { get; set; }

        [Display(Name = "Employee Name")]
        public string? EmployeeName { get; set; }

        [Display(Name = "Employee Age")]
        public int EmployeeAge { get; set; }

      

        [Display(Name = "Employee Salary")]
        public int EmployeeSalary { get; set; }
    }
}
