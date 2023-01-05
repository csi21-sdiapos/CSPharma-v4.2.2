using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CSPharma_v4._1_DAL.DataContexts;
using CSPharma_v4._1_DAL.Models;

namespace CSPharma_v4._1.Pages.EstadosEnvioPedido
{
    public class DetailsModel : PageModel
    {
        private readonly CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext _context;

        public DetailsModel(CSPharma_v4._1_DAL.DataContexts.CspharmaInformacionalContext context)
        {
            _context = context;
        }

      public TdcCatEstadosEnvioPedido TdcCatEstadosEnvioPedido { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TdcCatEstadosEnvioPedidos == null)
            {
                return NotFound();
            }

            var tdccatestadosenviopedido = await _context.TdcCatEstadosEnvioPedidos.FirstOrDefaultAsync(m => m.CodEstadoEnvio == id);
            if (tdccatestadosenviopedido == null)
            {
                return NotFound();
            }
            else 
            {
                TdcCatEstadosEnvioPedido = tdccatestadosenviopedido;
            }
            return Page();
        }
    }
}
