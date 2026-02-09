using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class ClientesCalidadDato
{
    public int CliId { get; set; }

    public bool IdfiscalIncorrecta { get; set; }

    public string? CliIdfiscalAnterior { get; set; }

    public string? CliIdfiscalNueva { get; set; }

    public bool EMailIncorrecto { get; set; }

    public string? CliEMail { get; set; }

    public virtual Cliente Cli { get; set; } = null!;
}
