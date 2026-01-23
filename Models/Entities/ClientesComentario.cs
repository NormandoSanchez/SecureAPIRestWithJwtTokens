using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ClientesComentario
{
    public int CliId { get; set; }

    public DateTime ClcFecha { get; set; }

    public string ClcComentarios { get; set; } = null!;

    public bool? ClcAutomatico { get; set; }

    public int ClcUalta { get; set; }

    public bool ClcAviso { get; set; }

    public bool ClcVisto { get; set; }

    public virtual Cliente Cli { get; set; } = null!;
}
