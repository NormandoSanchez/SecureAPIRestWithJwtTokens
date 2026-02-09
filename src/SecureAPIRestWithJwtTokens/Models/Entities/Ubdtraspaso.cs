using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class Ubdtraspaso
{
    public int FilaId { get; set; }

    public string? ArticuloCodigo { get; set; }

    public string? ArticuloDescripcion { get; set; }

    public string? ArticuloPvp { get; set; }

    public string? GrupoTerapeuticoOld { get; set; }

    public string? CodigoLaboratorioOld { get; set; }

    public string? TipoPrecio { get; set; }

    public string? TipoIva { get; set; }

    public string? UsaFrigorifico { get; set; }

    public string? ConCaducidad { get; set; }

    public string? Marca { get; set; }

    public string? MarcaSoe { get; set; }

    public string? TipoAportacion { get; set; }

    public string? TipoArticuloOld { get; set; }

    public string? PackSize { get; set; }

    public string? CodNacional { get; set; }

    public string? GrupoTerapeutico { get; set; }

    public string? CodigoCofaresLab { get; set; }

    public string? BonificacionPorc { get; set; }

    public string? TipoArticulo { get; set; }

    public string? PrecioLabSinIva { get; set; }
}
