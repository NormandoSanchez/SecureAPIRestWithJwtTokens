using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ClientesDocumentosLopd
{
    public int CliId { get; set; }

    public int DocId { get; set; }

    public string CldCodBar { get; set; } = null!;

    public int UnnId { get; set; }

    public int? EnvLote { get; set; }

    public DateTime CldFalta { get; set; }

    public int CldUalta { get; set; }

    public virtual Cliente Cli { get; set; } = null!;

    public virtual DocumentosLopd Doc { get; set; } = null!;
}
