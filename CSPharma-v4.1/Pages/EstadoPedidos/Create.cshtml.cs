using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CSPharma_v4._1_DAL.DataContexts;
using CSPharma_v4._1_DAL.Models;

namespace CSPharma_v4._1.Pages.EstadoPedidos
{
    public class CreateModel : PageModel
    {
        private readonly CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext _context;

        public CreateModel(CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CodEstadoDevolucion"] = new SelectList(_context.TdcCatEstadosDevolucionPedidos, "CodEstadoDevolucion", "CodEstadoDevolucion");
        ViewData["CodEstadoEnvio"] = new SelectList(_context.TdcCatEstadosEnvioPedidos, "CodEstadoEnvio", "CodEstadoEnvio");
        ViewData["CodEstadoPago"] = new SelectList(_context.TdcCatEstadosPagoPedidos, "CodEstadoPago", "CodEstadoPago");
        ViewData["CodLinea"] = new SelectList(_context.TdcCatLineasDistribucions, "CodLinea", "CodLinea");
            return Page();
        }

        [BindProperty]
        public TdcTchEstadoPedidos TdcTchEstadoPedidos { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TdcTchEstadoPedidos.Add(TdcTchEstadoPedidos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
