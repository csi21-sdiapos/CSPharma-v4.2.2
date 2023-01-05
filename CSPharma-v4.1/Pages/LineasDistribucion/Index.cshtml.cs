using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CSPharma_v4._1_DAL.DataContexts;
using CSPharma_v4._1_DAL.Models;
using Microsoft.AspNetCore.Authorization;

namespace CSPharma_v4._1.Pages.LineasDistribucion
{
    [Authorize(Roles = "Users, Employees, Administrators")]
    public class IndexModel : PageModel
    {
        private readonly CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext _context;

        public IndexModel(CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        public IList<TdcCatLineasDistribucion> TdcCatLineasDistribucion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TdcCatLineasDistribucions != null)
            {
                TdcCatLineasDistribucion = await _context.TdcCatLineasDistribucions.ToListAsync();
            }
        }
    }
}
