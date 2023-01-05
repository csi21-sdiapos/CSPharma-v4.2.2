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

namespace CSPharma_v4._1.Pages.EstadoPedidos
{
    public class EditModel : PageModel
    {
        private readonly CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext _context;

        public EditModel(CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TdcTchEstadoPedidos TdcTchEstadoPedidos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TdcTchEstadoPedidos == null)
            {
                return NotFound();
            }

            var tdctchestadopedidos =  await _context.TdcTchEstadoPedidos.FirstOrDefaultAsync(m => m.Id == id);
            if (tdctchestadopedidos == null)
            {
                return NotFound();
            }
            TdcTchEstadoPedidos = tdctchestadopedidos;
           ViewData["CodEstadoDevolucion"] = new SelectList(_context.TdcCatEstadosDevolucionPedidos, "CodEstadoDevolucion", "CodEstadoDevolucion");
           ViewData["CodEstadoEnvio"] = new SelectList(_context.TdcCatEstadosEnvioPedidos, "CodEstadoEnvio", "CodEstadoEnvio");
           ViewData["CodEstadoPago"] = new SelectList(_context.TdcCatEstadosPagoPedidos, "CodEstadoPago", "CodEstadoPago");
           ViewData["CodLinea"] = new SelectList(_context.TdcCatLineasDistribucions, "CodLinea", "CodLinea");
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

            _context.Attach(TdcTchEstadoPedidos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TdcTchEstadoPedidosExists(TdcTchEstadoPedidos.Id))
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

        private bool TdcTchEstadoPedidosExists(int id)
        {
          return _context.TdcTchEstadoPedidos.Any(e => e.Id == id);
        }
    }
}
