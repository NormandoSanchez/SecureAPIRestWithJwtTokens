using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ProveedoresNfcondicione
{
    public int PnfId { get; set; }

    public DateTime PccFdesde { get; set; }

    public DateTime? PccFhasta { get; set; }

    public decimal PccDto { get; set; }

    public virtual ProveedoresNoFarmaceutico Pnf { get; set; } = null!;
}
