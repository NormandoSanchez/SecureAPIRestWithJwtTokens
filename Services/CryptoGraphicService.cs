using System.Security.Cryptography;
using System.Text;
using SecureAPIRestWithJwtTokens.Constants;

namespace SecureAPIRestWithJwtTokens.Services
{
    public interface ICryptoGraphicService
    {
        Task<string> EncriptAsync(string text);
        Task<string> DecriptAsync(string text);
    }

    /// <summary>
    /// servicio para encriptar y desencriptar texto utilizando AES.
    /// </summary>
    public class CryptoGraphicService : ICryptoGraphicService
    {
        private readonly byte[] key;
        private readonly byte[] iv;

        public CryptoGraphicService(bool useInternalKeys = true)
        {
            (key, iv) = GetKeys(useInternalKeys);
        }

        /// <summary>
        /// Encripta un texto de forma asíncrona.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task<string> EncriptAsync(string text)
        {
            string sRet;

            using (var ms = new MemoryStream())
            {
                try
                {
                    using var rm = Aes.Create();
                    var ue = new UTF8Encoding();
                    byte[] bytes;

                    rm.Mode = CipherMode.CBC;
                    using (var cs = new CryptoStream(ms, rm.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                    {
                        // Encriptar de forma asíncrona
                        bytes = ue.GetBytes(text);
                        await cs.WriteAsync(bytes.AsMemory(), default);
                        await cs.FlushFinalBlockAsync(); 
                    }

                    // Recuperar del MemoryStream los bytes encriptados
                    sRet = Convert.ToBase64String(ms.ToArray());
                }
                catch
                {
                    sRet = string.Empty;
                }
            }

            return sRet;
        }

        /// <summary>
        /// Desencripta un texto de forma asíncrona.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task<string> DecriptAsync(string text)
        {
            string sRet;

            using (var ms = new MemoryStream())
            {
                try
                {
                    using var rm = Aes.Create();
                    byte[] bytes = Convert.FromBase64String(text);

                    using (var cs = new CryptoStream(ms, rm.CreateDecryptor(key, iv), CryptoStreamMode.Write))
                    {
                        await cs.WriteAsync(bytes.AsMemory(), default);
                        await cs.FlushAsync();
                        await cs.FlushFinalBlockAsync();
                    }

                    sRet = Encoding.UTF8.GetString(ms.ToArray());
                }
                catch
                {
                    sRet = string.Empty;
                }
            }

            return sRet;
        }

        /// <summary>
        /// Obtiene las claves de encriptación y vector de inicialización desde las variables de entorno.
        /// </summary>
        /// <param name="useInternalKeys">Indica que claves se deben usar internas o externas.</param>
        /// <exception cref="InvalidOperationException"></exception>
        private static (byte[] Key, byte[] IV) GetKeys(bool useInternalKeys)
        {
            string envKeys = $"{(useInternalKeys ? EnvironmentConstants.INTERNAL_API_KEY : EnvironmentConstants.EXTERNAL_API_KEY)}";
            string envIV = $"{(useInternalKeys ? EnvironmentConstants.INTERNAL_API_IV : EnvironmentConstants.EXTERNAL_API_IV)}";

            string base64Input = Environment.GetEnvironmentVariable(envKeys) ?? throw new InvalidOperationException($"{envKeys} environment variable no establecida.");
            var k = Convert.FromBase64String(base64Input) ?? throw new InvalidOperationException($"{envKeys} environment variable no establecida.");
            if (k.Length != 16)
            {
                throw new InvalidOperationException($"{envKeys} no tiene el formato adecuado");
            }

            base64Input = Environment.GetEnvironmentVariable(envIV) ?? throw new InvalidOperationException($"{envIV} environment variable no establecida.");
            var v = Convert.FromBase64String(base64Input) ?? throw new InvalidOperationException($"{envIV} environment variable no establecida.");
            if (v.Length != 16)
            {
                throw new InvalidOperationException($"{envIV} no tiene el formato adecuado");
            }

            return (k, v);
        }
    }
}
        
    



