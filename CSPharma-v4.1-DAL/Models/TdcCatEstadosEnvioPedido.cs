using System;
using System.Collections.Generic;

namespace CSPharma_v4._1_DAL.Models;

public partial class TdcCatEstadosEnvioPedido
{
    public string CodEstadoEnvio { get; set; } = null!;

    public string MdUuid { get; set; } = null!;

    public DateTime MdDate { get; set; }

    public int Id { get; set; }

    public string? DesEstadoEnvio { get; set; }

    public virtual ICollection<TdcTchEstadoPedidos>? TdcTchEstadoPedidos { get; } = new List<TdcTchEstadoPedidos>();
}
