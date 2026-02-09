using System;
using System.Collections.Generic;

namespace SecureAPIRestWithJwtTokens.Models.Entities;

public partial class DocumentosLopd
{
    public int DocId { get; set; }

    public string DocDescripcion { get; set; } = null!;

    public DateTime? DocFfinAviso { get; set; }

    public int DocUalta { get; set; }

    public DateTime DocFalta { get; set; }

    public int? DocUmodificacion { get; set; }

    public DateTime? DocFmodificafcion { get; set; }

    public virtual ICollection<ClientesDocumentosLopd> ClientesDocumentosLopds { get; set; } = new List<ClientesDocumentosLopd>();

    public virtual ICollection<Formulario> Formularios { get; set; } = new List<Formulario>();

    public virtual ICollection<Cliente> Clis { get; set; } = new List<Cliente>();

    public virtual ICollection<TarjetasTipo> Tats { get; set; } = new List<TarjetasTipo>();
}
