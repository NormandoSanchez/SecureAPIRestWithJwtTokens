namespace SecureAPIRestWithJwtTokens.Models.InternalDTO;

/// <summary>
/// Modelo con los datos de conexión a la base de datos de una farmacia
/// </summary>
public class FarmaciaDBConnectionInternal
{
    public int IdUnidadNegocioERP { get; set; }
    public string Server { get; set; } = string.Empty;
    public string DataBase { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string EncriptedPassword { get; set; } = string.Empty;
}
