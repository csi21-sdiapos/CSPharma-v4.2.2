using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CSPharma_v4._1.Pages.Roles
{
    [Authorize(Roles = "Administrators")]
    public class Admin : PageModel
    {
        public IActionResult Index()
        {
            return Page();
        }
    }
}
