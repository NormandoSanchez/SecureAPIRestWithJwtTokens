namespace SecureAPIRestWithJwtTokens.Models.InternalDTO
{
    /// <summary>
    /// Opciones JWT ya procesadas (incluye la clave secreta desencriptada).
    /// </summary>
    public class JwtAuthOptions
    {
        public string Issuer { get; init; } = default!;
        public string Audience { get; init; } = default!;
        public string SecretKey { get; init; } = default!;
        public int AccessTokenExpirationMinutes { get; init; }
    }
}