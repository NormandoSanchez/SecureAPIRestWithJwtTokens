namespace SecureAPIRestWithJwtTokens.Constants;

public static class AuthTextConstants
{
    public const string AUTH_FAILED = "Autenticación fallida";
    public const string AUTH_INCORRECT_CREDENTIALS = "Credenciales incorrectas";
    public const string AUTH_LOGOUT_FAILED = "Logout no efectuado";
    public const string AUTH_INVALID_DATA = "Datos de autentificación erroneos o inexistentes. Motivo: {0}";
    public const string AUTH_MOTIVE01_FAILED = "Intento de login con body vacío o inválido";
    public const string AUTH_MOTIVE02_FAILED = "Faltan tokens de autenticación";
    public const string AUTH_MOTIVE03_FAILED = "Token de Acceso inválido";
    public const string AUTH_MOTIVE04_FAILED = "ID de usuario inválido en el token";
    public const string AUTH_MOTIVE05_FAILED = "Token de refresco inválido o expirado.";
    public const string AUTH_MOTIVE06_FAILED = "userName inválido en el token";
    public const string AUTH_MOTIVE07_FAILED = "ID de perfil inválido en el token";
    public const string AUTH_OK = "Login exitoso para usuario: {0}";
    public const string AUTH_CHALLENGE = "Intento de login para usuario: {0}";
    public const string AUTH_REFRESH = "Intento de refresco de token";
    public const string AUTH_REFRESH_OK = "Tokens refrescados exitosamente para usuario: {0}";
    public const string AUTH_EXIT = "Logout exitoso para usuario: {0}";
    public const string AUTH_SESSION_VERIFICATION = "Verificación de sesión solicitada";
    public const string AUTH_SESSION_VERIFICATION_FAILED = "Verificación de sesión fallida: {0}";   
    public const string AUTH_SESSION_VERIFICATION_OK = "Verificación de sesión exitosa: {0}";  
    public const string AUTH_PROFILE_MODULES_RETRIEVAL_ATTEMPT = "Intento de obtención de Modulos del perfil del usuario";
    public const string AUTH_PROFILE_MENU_OPTIONS_RETRIEVAL_ATTEMPT = "Intento de obtención de opciones de menú del perfil del usuario";
    public const string AUTH_PROFILE_MODULES_RETRIEVAL_OK = "Módulos del perfil del usuario obtenidos exitosamente para usuario: {0}";
    public const string AUTH_PROFILE_MENU_OPTIONS_RETRIEVAL_OK = "Opciones de menú del perfil del usuario obtenidas exitosamente para usuario: {0}";
    public const string AUTH_PROFILE_PROCESS_CODES_RETRIEVAL_ATTEMPT = "Intento de obtención de códigos de procesos autorizados del perfil del usuario.";
    public const string AUTH_PROFILE_PROCESS_CODES_RETRIEVAL_OK = "Códigos de procesos autorizados obtenidos exitosamente para usuario: {0}";
}
