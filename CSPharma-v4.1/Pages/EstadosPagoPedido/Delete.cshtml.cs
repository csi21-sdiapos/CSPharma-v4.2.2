using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CSPharma_v4._1_DAL.DataContexts;
using CSPharma_v4._1_DAL.Models;

namespace CSPharma_v4._1.Pages.EstadosPagoPedido
{
    public class DeleteModel : PageModel
    {
        private readonly CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext _context;

        public DeleteModel(CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TdcCatEstadosPagoPedido TdcCatEstadosPagoPedido { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TdcCatEstadosPagoPedidos == null)
            {
                return NotFound();
            }

            var tdccatestadospagopedido = await _context.TdcCatEstadosPagoPedidos.FirstOrDefaultAsync(m => m.CodEstadoPago == id);

            if (tdccatestadospagopedido == null)
            {
                return NotFound();
            }
            else 
            {
                TdcCatEstadosPagoPedido = tdccatestadospagopedido;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.TdcCatEstadosPagoPedidos == null)
            {
                return NotFound();
            }
            var tdccatestadospagopedido = await _context.TdcCatEstadosPagoPedidos.FindAsync(id);

            if (tdccatestadospagopedido != null)
            {
                TdcCatEstadosPagoPedido = tdccatestadospagopedido;
                _context.TdcCatEstadosPagoPedidos.Remove(TdcCatEstadosPagoPedido);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
