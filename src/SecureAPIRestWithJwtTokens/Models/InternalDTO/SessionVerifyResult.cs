namespace SecureAPIRestWithJwtTokens.Models.InternalDTO
{
    /// <summary>
    /// Resultado de la verificación de sesión
    /// </summary>
    public class SessionVerifyResult
    {
        /// <summary>
        /// Indica si la sesión es válida
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// ID del usuario autenticado
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Nombre completo del usuario
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Permisos del usuario
        /// </summary>
        public List<int>? Permissions { get; set; }

        /// <summary>
        /// Mensaje de error si la sesión no es válida
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Indica si el token ha expirado
        /// </summary>
        public bool IsExpired { get; set; }
    }
}
