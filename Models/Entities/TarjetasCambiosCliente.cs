using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class TarjetasCambiosCliente
{
    public int TacId { get; set; }

    public int CliId { get; set; }

    public int TatIdnueva { get; set; }

    public int TccEstado { get; set; }

    public virtual Cliente Cli { get; set; } = null!;

    public virtual TarjetasCambio Tac { get; set; } = null!;
}
