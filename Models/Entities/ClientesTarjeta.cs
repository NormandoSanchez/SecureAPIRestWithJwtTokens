using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ClientesTarjeta
{
    public int CliId { get; set; }

    public string TarId { get; set; } = null!;

    public int TatId { get; set; }

    public DateTime? CltFcaducidad { get; set; }

    public bool CltActiva { get; set; }

    public int? EnvLote { get; set; }

    public DateTime CltFactivacion { get; set; }

    public DateTime? CltFanulacion { get; set; }

    public int CltUactivacion { get; set; }

    public int? CltUanulacion { get; set; }

    public string? CltMotivoAnulacion { get; set; }

    public int UnnIdactivacion { get; set; }

    public int? UnnIdanulacion { get; set; }

    public DateTime CltFalta { get; set; }

    public int CltUalta { get; set; }

    public virtual Cliente Cli { get; set; } = null!;

    public virtual TarjetasTipo Tat { get; set; } = null!;
}
