using System.ComponentModel.DataAnnotations;

namespace SecureAPIRestWithJwtTokens.Models.DTO
{
    /// <summary>
    /// Modelo para solicitud de login
    /// </summary>
    public class LoginApiRequest 
    {
        /// <summary>
        /// Login usuario
        /// Annotations para documentación y validación
        /// </summary>
        /// <example>Usuario</example>
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(15, ErrorMessage = "El nombre de usuario no puede exceder los 15 caracteres.")]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Contraseña encriptada del usuario
        /// </summary>
        /// <example>password123</example>
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "La contraseña debe tener entre 3 y 25 caracteres.")]
        public string EncryptedPassword { get; set; } = string.Empty;
    }
}