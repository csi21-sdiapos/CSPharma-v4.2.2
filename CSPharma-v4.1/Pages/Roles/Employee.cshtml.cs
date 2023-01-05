using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSPharma_v4._1.Pages.Roles
{
    [Authorize(Roles = "Employees, Administrators")]
    public class Employee : PageModel
    {
        public IActionResult Index()
        {
            return Page();
        }
    }
}
