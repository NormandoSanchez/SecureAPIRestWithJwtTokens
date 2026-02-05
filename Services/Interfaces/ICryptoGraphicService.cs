namespace SecureAPIRestWithJwtTokens.Services.Interfaces;

/// <summary>
/// servicio para encriptar y desencriptar texto utilizando AES.
/// </summary>
public interface ICryptoGraphicService
{
    Task<string> EncriptAsync(string text);
    Task<string> DecriptAsync(string text);
}
