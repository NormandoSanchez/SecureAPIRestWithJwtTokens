namespace SecureAPIRestWithJwtTokens.Exceptions;

// Base exception
public abstract class ApiBusinessException : Exception
{
    protected ApiBusinessException(string message) : base(message) { }
    protected ApiBusinessException(string message, Exception innerException)
        : base(message, innerException) { }
}

// Not Found Exceptions
public class SimpleNotFoundException(string entidadName, int? entidadId = null) : ApiBusinessException(entidadId == null 
                                                                                                        ? $"No se encontraron {entidadName}" 
                                                                                                        : $"No se encontró {entidadName} con ID {entidadId}.")
{
    public int? EntidadId { get; } = entidadId;
    public string EntidadName { get; } = entidadName;
}

public class FechaInvalidaException(DateTime fecha, string contexto) : ApiBusinessException($"Fecha inválida en {contexto}: {fecha:dd/MM/yyyy}")
{
    public DateTime Fecha { get; } = fecha;
}

public class JwtKeyFFailureException(string motivo) : ApiBusinessException($"Fallo al obtener la clave JWT: {motivo}")
{
    public string Motivo { get; } = motivo;
}

/// <summary>
/// Excepción para credenciales inválidas
/// </summary>
public class ValidateCredentialsFailException(string username) : ApiBusinessException($"Error durante el proceso de login para usuario '{username}'.")
{
    public string Username { get; } = username;
}

/// <summary>
/// Excepción para token JWT inválido
/// </summary>
public class InvalidTokenException : ApiBusinessException
{
    public InvalidTokenException(string message) : base(message) { }

    public InvalidTokenException() : base("Token JWT inválido o expirado.") { }
}