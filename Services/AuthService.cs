using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;
using SecureAPIRestWithJwtTokens.Tools;
using SecureAPIRestWithJwtTokens.Repository.Interfaces;
using SecureAPIRestWithJwtTokens.Services.Interfaces;

namespace SecureAPIRestWithJwtTokens.Services
{
    /// <summary>
    /// Servicio de autenticación que valida usuarios.
    /// </summary>
    /// <remarks>Este servicio utiliza un repositorio de usuarios para validar las credenciales de los usuarios.</remarks>
    /// <param name="securityRepo">Repositorio de seguridad</param>
    /// <param name="mapper">Servicio de mapeo</param>
    /// <param name="configuration">Configuracion API</param>
    /// <param name="externalCryptoService">Servicio criptográfico EXTERNAL</param>
    /// <param name="internalCryptoService">Servicio criptográfico INTERNAL</param>
    public class AuthService(ISecurityRepo securityRepo,
                              IMappingService mapper,
                              ApiConfiguration configuration,
                              ICryptoGraphicService internalCryptoService,
                              [FromKeyedServices("external")] ICryptoGraphicService externalCryptoService) : IAuthService 
 {
        private readonly ISecurityRepo _securityRepo = securityRepo ?? throw new ArgumentNullException(nameof(securityRepo));
        private readonly IMappingService _mappingService = mapper ?? throw new ArgumentNullException(nameof(mapper));
        private readonly ApiConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        private readonly ICryptoGraphicService _internalCryptoService = internalCryptoService ?? throw new ArgumentNullException(nameof(internalCryptoService));    
        private readonly ICryptoGraphicService _externalCryptoService = externalCryptoService ?? throw new ArgumentNullException(nameof(externalCryptoService));

        /// <summary>
        /// Validar credenciales de usuario contra la base de datos
        /// <param>loginRequest</param>
        /// </summary>
        public async Task<UserInfoDto?> ValidateUserCredentialsAsync(LoginApiRequest loginRequest)
        {
            loginRequest.EncryptedPassword = await ReencryptExternalToInternalAsync(loginRequest.EncryptedPassword);
            
            Usuario? user = await _securityRepo.GetByCredentialsAsync(loginRequest);
            if (user != null)
            {
                return  await _mappingService.MapUsuarioToUserInfoAsync(user);
            }

            return null;
        }

        /// <summary>
        /// Validar refresh token desde base de datos
        /// </summary>
        public async Task<UserInfoDto?> ValidateRefreshTokenAsync(int userId, string refreshToken)
        {
            string rtoken = await _securityRepo.GetRefreshToken(userId) ?? string.Empty;
            UserInfoDto? usuario = null;

            if (!string.IsNullOrWhiteSpace(rtoken) && rtoken == refreshToken)
            {
                Usuario? user = await _securityRepo.GetByIdAsync(userId);     
                if (user != null)
                {
                    usuario = await _mappingService.MapUsuarioToUserInfoAsync(user);
                }
            }

            return usuario;
        }

        /// <summary>
        /// Guarda el refresh token para el usuario indicado.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public async Task SaveRefreshToken(int userId, string userName, string refreshToken)
        {
            // Fecha Expiracion
            int ExpDays = _configuration.JwtSettings.RefreshTokenExpirationDays;
            DateTime ExpirationDate = DateTime.UtcNow.AddDays(ExpDays);
            // Guardar en BD y elimina los existentes si los hay 
            await _securityRepo.SaveRefreshToken(userId, userName, refreshToken, ExpirationDate);
        }

        /// <summary>
        /// Elimina cualquier refresh token almacenado para el usuario indicado.
        /// </summary>
        /// <param name="userId">ID del usuario</param>
        public async Task DeleteRefreshToken(int userId)
        {
            await _securityRepo.DeleteRefreshToken(userId);
        }

        /// <summary>
        /// Obtiene los procesos asociados al perfil del usuario indicado.   
        /// </summary>
        /// <param name="userId">ID del usuario</param>
        /// <param name="perfilId">ID del perfil</param>
        /// <param name="typeClass">Indica el tipo de procesos a recuperar (Constantes.PROCESS_TYPE_*)</param>
        /// <param name="visibleOn">Filtra por visibilidad si se indica</param>
        /// <Param name="idModulo">Código del Modulo para filtrar (Opcional)</Param>   
        /// <returns>Lista de procesos (authProcessDto)</returns>
        public async Task<List<AuthProcessDto>> GetProcessesByUserAndProfileAsync(int userId, int perfilId, 
                                                                                  ProcessType typeClass,
                                                                                  bool? visibleOn = true,
                                                                                  string? idModulo = null)
        {
            List<AuthProcessDto>? processes = await _securityRepo.GetProcessByUserAndProfileAsync(userId, perfilId, 
                                                                                                  typeClass, visibleOn, idModulo);
           
            return processes ?? [];
        }

        /// <summary>   
        /// Obtiene los códigos de proceso asociados al perfil del usuario indicado.   
        /// </summary>
        /// <param name="userId">ID del usuario</param>
        /// <param name="perfilId">ID del perfil</param>
        /// <returns>Lista de códigos de proceso</returns>  
        public async Task<List<string>?> GetCodeProcessByUserAndProfileAsync(int userId, int perfilId)
        {
            var processCodes = await _securityRepo.GetCodeProcessByUserAndProfileAsync(userId, perfilId);
            return processCodes;
        }

        #region Metodos Privados
        /// <summary>
        /// Convierte una contraseña encriptada con claves EXTERNAL a su representación encriptada con claves INTERNAL.
        /// </summary>
        /// <param name="externalEncryptedPassword">Contraseña encriptada con clave EXTERNAL</param>
        /// <returns>Contraseña re-encriptada con clave INTERNAL</returns>
        private async Task<string> ReencryptExternalToInternalAsync(string externalEncryptedPassword)
        {
            var decrypted = await _externalCryptoService.DecriptAsync(externalEncryptedPassword);
            return await _internalCryptoService.EncriptAsync(decrypted);
        }
        #endregion
    }
}