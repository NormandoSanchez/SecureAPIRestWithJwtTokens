namespace SecureAPIRestWithJwtTokens.Models.DTO;

/// <summary>
/// Farmacia C&amp;C  
/// </summary>
public class FarmaciaCCDto
{
    /// <summary>
    /// Identificador. Desde Comun.totalfarmacias
    /// </summary>
    public string? IdFarmacia { get; set; }

    /// <summary>
    /// Denominacion Trebol de la Farmacia
    /// </summary>
    public string? Descripcion { get; set; }

    /// <summary>
    /// Direccion TipoVia Nombre Via, nº {{Portal} {Escalera} {Piso} {Puerta}} CodigoPostal Poblacon Provincia 
    /// </summary>
    public string? Direccion { get; set; }

    /// <summary>
    /// Teléfono contacto
    /// </summary>
    public string? Telefono { get; set; }

    /// <summary>
    /// Correo electronico 
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Url GoogleMaps 
    /// </summary>
    public string? UrlGoogleMaps { get; set; }

    /// <summary>
    /// Horario de apertura 
    /// </summary>
    public string? Horario { get; set; }

    /// <summary>
    /// Titular de farmacia
    /// </summary>
    public TitularFarmaciaResult? Titular { get; set; }
}

/// <summary>
/// Titular de Farmacia
/// </summary>
public class TitularFarmaciaResult
{
    /// <summary>
    /// Nombre de la sociedad / titular
    /// </summary>
    public string? Nombre { get; set; }

    /// <summary>
    /// Identificacion fiscal sociedad / Titular
    /// </summary>
    public string? IdFiscal { get; set; }
}
