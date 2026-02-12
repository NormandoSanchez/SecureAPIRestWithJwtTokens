namespace SecureAPIRestWithJwtTokens.Constants;

public static class EnvironmentConstants
{
    public const string INTERNAL_API_KEY = "INTERNAL_API_KEY";
    public const string INTERNAL_API_IV = "INTERNAL_API_IV";
    public const string EXTERNAL_API_KEY = "EXTERNAL_API_KEY";
    public const string EXTERNAL_API_IV = "EXTERNAL_API_IV";
    public const string DB_PASSWORD = "DB_PASSWORD";
    public const string DB_STRING_CONNECTION = "DB_STRING_CONNECTION";
    public const string DBCOMUN_PASSWORD = "DBCOMUN_PASSWORD";
    public const string DBCOMUN_STRING_CONNECTION = "DBCOMUN_STRING_CONNECTION";
    public const string DB_PASSWORD_TOKEN = "${DB_PASSWORD}";
    public const string DB_COMUN_PASSWORD_TOKEN = "${DBCOMUN_PASSWORD}";    
}