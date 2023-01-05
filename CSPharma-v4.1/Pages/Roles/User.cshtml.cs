using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSPharma_v4._1.Pages.Roles
{
    [Authorize(Roles = "Users, Employees, Administrators")]
    public class User : PageModel
    {
        public IActionResult Index()
        {
            return Page();
        }
    }
}
