using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace EmployeeData.Models.Service
{
    public class DebugLogAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Log("On Executing- " + context.ActionDescriptor.RouteValues["action"]); 
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Log("On Executed- " + context.ActionDescriptor.RouteValues["action"]);
        }
        private void Log(string text)
        {
            Debug.WriteLine(text);
        }
    }
}
