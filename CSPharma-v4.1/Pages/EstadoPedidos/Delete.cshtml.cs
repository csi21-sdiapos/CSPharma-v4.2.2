using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CSPharma_v4._1_DAL.DataContexts;
using CSPharma_v4._1_DAL.Models;

namespace CSPharma_v4._1.Pages.EstadoPedidos
{
    public class DeleteModel : PageModel
    {
        private readonly CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext _context;

        public DeleteModel(CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TdcTchEstadoPedidos TdcTchEstadoPedidos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TdcTchEstadoPedidos == null)
            {
                return NotFound();
            }

            var tdctchestadopedidos = await _context.TdcTchEstadoPedidos.FirstOrDefaultAsync(m => m.Id == id);

            if (tdctchestadopedidos == null)
            {
                return NotFound();
            }
            else 
            {
                TdcTchEstadoPedidos = tdctchestadopedidos;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TdcTchEstadoPedidos == null)
            {
                return NotFound();
            }
            var tdctchestadopedidos = await _context.TdcTchEstadoPedidos.FindAsync(id);

            if (tdctchestadopedidos != null)
            {
                TdcTchEstadoPedidos = tdctchestadopedidos;
                _context.TdcTchEstadoPedidos.Remove(TdcTchEstadoPedidos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
