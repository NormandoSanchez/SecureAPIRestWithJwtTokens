using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Sociedade
{
    public int SocId { get; set; }

    public string SocRazon { get; set; } = null!;

    public string SocAlias { get; set; } = null!;

    public string SocIdFiscal { get; set; } = null!;

    public bool SocCalConImp { get; set; }

    public string? SocLinkLogoFac { get; set; }

    public int DirId { get; set; }

    public string? SocTelf1 { get; set; }

    public string? SocTelf2 { get; set; }

    public string? SocFax1 { get; set; }

    public string? DirFax2 { get; set; }

    public virtual ICollection<ContadoresFacTrebol> ContadoresFacTrebols { get; set; } = new List<ContadoresFacTrebol>();

    public virtual Direccion Dir { get; set; } = null!;

    public virtual ICollection<FacturasTrebolTexto> FacturasTrebolTextos { get; set; } = new List<FacturasTrebolTexto>();

    public virtual ICollection<SociedadesCcc> SociedadesCccs { get; set; } = new List<SociedadesCcc>();

    public virtual ICollection<UnidadesNegocioSoc> UnidadesNegocioSocs { get; set; } = new List<UnidadesNegocioSoc>();
}
