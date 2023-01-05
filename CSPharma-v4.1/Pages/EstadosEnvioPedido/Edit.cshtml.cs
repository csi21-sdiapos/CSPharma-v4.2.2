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

namespace CSPharma_v4._1.Pages.EstadosEnvioPedido
{
    public class EditModel : PageModel
    {
        private readonly CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext _context;

        public EditModel(CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TdcCatEstadosEnvioPedido TdcCatEstadosEnvioPedido { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TdcCatEstadosEnvioPedidos == null)
            {
                return NotFound();
            }

            var tdccatestadosenviopedido =  await _context.TdcCatEstadosEnvioPedidos.FirstOrDefaultAsync(m => m.CodEstadoEnvio == id);
            if (tdccatestadosenviopedido == null)
            {
                return NotFound();
            }
            TdcCatEstadosEnvioPedido = tdccatestadosenviopedido;
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

            _context.Attach(TdcCatEstadosEnvioPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TdcCatEstadosEnvioPedidoExists(TdcCatEstadosEnvioPedido.CodEstadoEnvio))
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

        private bool TdcCatEstadosEnvioPedidoExists(string id)
        {
          return _context.TdcCatEstadosEnvioPedidos.Any(e => e.CodEstadoEnvio == id);
        }
    }
}
