using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CSPharma_v4._1_DAL.DataContexts;
using CSPharma_v4._1_DAL.Models;

namespace CSPharma_v4._1.Pages.EstadosDevolucionPedido
{
    public class DeleteModel : PageModel
    {
        private readonly CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext _context;

        public DeleteModel(CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TdcCatEstadosDevolucionPedido TdcCatEstadosDevolucionPedido { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TdcCatEstadosDevolucionPedidos == null)
            {
                return NotFound();
            }

            var tdccatestadosdevolucionpedido = await _context.TdcCatEstadosDevolucionPedidos.FirstOrDefaultAsync(m => m.CodEstadoDevolucion == id);

            if (tdccatestadosdevolucionpedido == null)
            {
                return NotFound();
            }
            else 
            {
                TdcCatEstadosDevolucionPedido = tdccatestadosdevolucionpedido;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.TdcCatEstadosDevolucionPedidos == null)
            {
                return NotFound();
            }
            var tdccatestadosdevolucionpedido = await _context.TdcCatEstadosDevolucionPedidos.FindAsync(id);

            if (tdccatestadosdevolucionpedido != null)
            {
                TdcCatEstadosDevolucionPedido = tdccatestadosdevolucionpedido;
                _context.TdcCatEstadosDevolucionPedidos.Remove(TdcCatEstadosDevolucionPedido);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
