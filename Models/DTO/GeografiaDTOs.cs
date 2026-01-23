namespace SecureAPIRestWithJwtTokens.Models.DTO;

/// <summary>
/// Modelo de respuesta con la información de un país
/// </summary>
public class PaisDto
{
    /// <summary>
    /// Identificador único del país
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre del país
    /// </summary>
    public string Nombre { get; set; } = string.Empty;
}

/// <summary>
/// Modelo de respuesta con la información de una comunidad autónoma
/// </summary>
public class ComunidadAutDto
{
    /// <summary>
    /// Identificador único de comunidad
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre de comunidad
    /// </summary>
    public string Nombre { get; set; } = string.Empty;

    /// <summary>
    /// Identificador de país
    /// </summary>
    public int IdPais { get; set; }

    /// <summary>
    /// Indicador exencion IVA
    /// </summary>
    public bool ExencionIVA { get; set; }

    /// <summary>
    /// Identificador Comunidad en Consejo
    /// </summary>
    public int ComunidadConsejoId { get; set; }
}

/// <summary>
/// Modelo de respuesta con la información de una provincia
/// </summary>
public class ProvinciaDto
{
    /// <summary>
    /// Identificador único de provincia
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Nombre de provincia
    /// </summary>
    public string Nombre { get; set; } = string.Empty;
    
    /// <summary>
    /// Identificador de comunidad autónoma
    /// </summary>
    public int IdComunidadAut { get; set; }
    
    /// <summary>
    /// Identificador de país
    /// </summary>
    public int IdPais { get; set; }
}

/// <summary>
/// Modelo de respuesta con la información de una población
/// </summary>  
public class PoblacionDto
{
    /// <summary>
    /// Identificador único de Población
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Nombre de Población 
    /// </summary>
    public string Nombre { get; set; } = string.Empty;
    
    /// <summary>
    /// Identificador de provincia
    /// </summary>
    public int IdProvincia { get; set; }
    
    /// <summary>
    /// Identificador de país
    /// </summary>
    public int IdPais { get; set; }
}