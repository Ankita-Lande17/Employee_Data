using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeData.Models.Provider
{
    public class MyCustomRequestCultureProvider : RequestCultureProvider
    {


        public override async Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            await Task.Yield();
            string cultureName = string.IsNullOrEmpty(httpContext.Request.Query["culture"].ToString()) ?"en-us": httpContext.Request.Query["culture"].ToString();
            return new ProviderCultureResult( cultureName);
        }
    }
}
