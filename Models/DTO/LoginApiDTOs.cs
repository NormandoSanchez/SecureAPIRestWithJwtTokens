namespace SecureAPIRestWithJwtTokens.Models.DTO
{
    /// <summary>
    /// Respuesta del login exitoso con tokens JWT
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// Fecha de expiración del access token
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// Tipo de token (Bearer)
        /// </summary>
        public string TokenType { get; set; } = "Bearer";
    }

    /// <summary>
    /// Información básica del usuario autenticado
    /// </summary>
    public class UserInfoDto
    {
        /// <summary>
        /// ID del usuario
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Login de usuario
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Nombre completo del usuario
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Identificador de Perfil del usuario
        /// </summary>
        public int PerfilId { get; set; }
    }

    /// <summary>
    /// Respuesta del refresco de token
    /// </summary>
    public class RefreshTokenDto
    {
        /// <summary>
        /// Fecha de expiración del nuevo access token
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// Tipo de token (Bearer)
        /// </summary>
        public string TokenType { get; set; } = "Bearer";
    }
}