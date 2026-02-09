using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class PromocionesFranja
{
    public int PfrId { get; set; }

    public string PfrDescripcion { get; set; } = null!;

    public virtual ICollection<Promocione> Promociones { get; set; } = new List<Promocione>();

    public virtual ICollection<PromocionesFranjasLinea> PromocionesFranjasLineas { get; set; } = new List<PromocionesFranjasLinea>();
}
