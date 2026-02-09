using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PromocionesFranjasCierre
{
    public int PfcId { get; set; }

    public string PfcDescripcion { get; set; } = null!;

    public virtual ICollection<PromocionesCierre> PromocionesCierres { get; set; } = new List<PromocionesCierre>();

    public virtual ICollection<PromocionesFranjasLineasCierre> PromocionesFranjasLineasCierres { get; set; } = new List<PromocionesFranjasLineasCierre>();

    public virtual ICollection<PromocionesFranjasUnncierre> PromocionesFranjasUnncierres { get; set; } = new List<PromocionesFranjasUnncierre>();
}
