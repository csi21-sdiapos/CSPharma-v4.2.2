using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSPharma_v4._1_DAL.DataContexts;
using CSPharma_v4._1_DAL.Models;

namespace CSPharma_v4._1.Pages.EstadosDevolucionPedido
{
    public class EditModel : PageModel
    {
        private readonly CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext _context;

        public EditModel(CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TdcCatEstadosDevolucionPedido TdcCatEstadosDevolucionPedido { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TdcCatEstadosDevolucionPedidos == null)
            {
                return NotFound();
            }

            var tdccatestadosdevolucionpedido =  await _context.TdcCatEstadosDevolucionPedidos.FirstOrDefaultAsync(m => m.CodEstadoDevolucion == id);
            if (tdccatestadosdevolucionpedido == null)
            {
                return NotFound();
            }
            TdcCatEstadosDevolucionPedido = tdccatestadosdevolucionpedido;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TdcCatEstadosDevolucionPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TdcCatEstadosDevolucionPedidoExists(TdcCatEstadosDevolucionPedido.CodEstadoDevolucion))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TdcCatEstadosDevolucionPedidoExists(string id)
        {
          return _context.TdcCatEstadosDevolucionPedidos.Any(e => e.CodEstadoDevolucion == id);
        }
    }
}
