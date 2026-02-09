using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class IftopActualizacionPendientesBi
{
    public DateTime FechaInsercion { get; set; }

    public int UnnId { get; set; }

    public long OpaId { get; set; }

    public int OpeId { get; set; }

    public string? ProId { get; set; }

    public int? UsrId { get; set; }

    public DateTime? OpaFejecutar { get; set; }

    public string? ArtCodigo { get; set; }

    public string? CliCodigo { get; set; }

    public int? SfamId { get; set; }

    public short? FamId { get; set; }

    public int? LstId { get; set; }

    public string? TclId { get; set; }

    public string? LabCodigo { get; set; }

    public string? PrvCodigo { get; set; }

    public int? AuxInt1 { get; set; }

    public int? AuxInt2 { get; set; }

    public double? AuxFloat1 { get; set; }

    public double? AuxFloat2 { get; set; }
}
