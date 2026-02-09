namespace SecureAPIRestWithJwtTokens.Models.Entities;

/// <summary>
/// Modelo para almacenar tokens de refresco JWT asociados a un usuario
/// </summary>
public partial class UsuarioJwtRefresh
{
    /// <summary>
    /// Identificador del usuario asociado
    /// </summary>
    public int UsrId { get; set; }

    /// <summary>
    /// Nombre de usuario asociado
    /// </summary>
    public string UsrLogin { get; set; } = null!;

    /// <summary>
    /// Token de refresco
    /// </summary>
    public string RefreshToken { get; set; } = null!;

    /// <summary>
    /// Fecha y hora de expiración del token de refresco
    /// </summary>
    public DateTime ExpiryDate { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
