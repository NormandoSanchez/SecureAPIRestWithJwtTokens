using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Tools;
using Microsoft.EntityFrameworkCore;

namespace SecureAPIRestWithJwtTokens.Repository
{
    public class SecurityRepository(TrebolDbContext context, ILogger<SecurityRepository> logger) : ISecurityRepo
    {
        private readonly TrebolDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<SecurityRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        /// <summary>
        /// Recupera un usuario por sus credenciales de inicio de sesión.
        /// </summary>
        /// <param name="login">Las credenciales de inicio de sesión del usuario.</param>
        /// <remarks>Este es el metodo inical para trabajo con la API</remarks>
        /// <returns>Un objeto <see cref="Usuario"/> que representa al usuario con las credenciales especificadas, 
        /// o <see langword="null"/> si no se encuentra. Si se encuentra devuelve el Perfil de Acceso.</returns>
        public async Task<Usuario?> GetByCredentialsAsync(LoginApiRequest login)
        {
            string userName = login.UserName ?? string.Empty;
            var safeUserName = Sanitizer.Sanitize(userName);

            // Buscar el usuario por su login de usuario y verificar que esté habilitado
            // Incluiir el perfil y los procesos asociados para los claims
            Usuario? user = await _context.Usuarios.AsNoTracking()
                                 .FirstOrDefaultAsync(u => u.UsrLogin == userName && u.UsrHabilitado);

            if (user != null && (string.IsNullOrWhiteSpace(login.EncryptedPassword) || 
                                    string.IsNullOrWhiteSpace(user.UsrPassword) ||
                                    login.EncryptedPassword != user.UsrPassword))
            {
                user = null;
            }
            if (user == null)
            {
                _logger.LogWarning("No se encontró un usuario habilitado con el login {UserName}.", safeUserName);
            }
            else
            {
                _logger.LogInformation("Usuario {UserName} recuperado correctamente por credenciales.", safeUserName);
            }

            return user;
        }

        /// <summary>
        /// Recupera un usuario por su identificador, incluyendo su perfil si el usuario está habilitado.
        /// </summary>
        /// <param name="id">Identificador único del usuario.</param>
        /// <returns>Objeto <see cref="Usuario"/> con la información de seguridad, o <see langword="null"/> si no se encuentra o no está habilitado.</returns>
        public async Task<Usuario?> GetByIdAsync(int id)
        {
            // Incluir perfil y procesos para el Usuario con acceso 
            var user = await _context.Usuarios.AsNoTracking()
                                        .FirstOrDefaultAsync(u => u.UsrId == id && u.UsrHabilitado);
            if (user != null)
            {
                _logger.LogInformation("Usuario {UserName} con ID {UserId} recuperado correctamente para seguridad.", Sanitizer.Sanitize(user.UsrLogin), id);
            }
            else
            {
                _logger.LogWarning("No se encontró un usuario habilitado con ID {UserId} para seguridad.", id);
            }

            return user;
        }

        /// <summary>
        /// Guarda el refreshToken en la base de datos para el usuario especificado.
        /// Elimina cualquier token anterior asociado al usuario antes de guardar el nuevo.
        /// Solo guarda el token si el usuario está habilitado.
        /// </summary>
        /// <param name="userId">Identificador único del usuario.</param>
        /// <param name="userName">Nombre de usuario (no se utiliza en la lógica actual).</param>
        /// <param name="refreshToken">Token de refresco JWT a guardar.</param>
        /// <param name="expiry">Fecha de expiración del token.</param>
        /// <returns></returns>
        public async Task SaveRefreshToken(int userId, string userName, string refreshToken, DateTime expiry)
        {
            var user = await _context.Usuarios.FindAsync(userId);
            if (user != null && user.UsrHabilitado)
            {
                var tokens = await _context.UsuariosJwtRefresh.Where(j => j.UsrId == user.UsrId).ToListAsync();
                if (tokens != null && tokens.Count > 0)
                {
                    _context.UsuariosJwtRefresh.RemoveRange(tokens);
                }

                var newToken = new UsuarioJwtRefresh
                {
                    UsrId = user.UsrId,
                    UsrLogin = user.UsrLogin,
                    RefreshToken = refreshToken,
                    ExpiryDate = expiry
                };
                _context.UsuariosJwtRefresh.Add(newToken);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Refresh token guardado para el usuario {UserName} (ID: {UserId}).", Sanitizer.Sanitize(userName), userId);
            }
        }

        /// <summary>
        /// Recupera el token de actualización activo para el usuario especificado, si existe, no ha expirado y el usuario está habilitado. 
        /// </summary>
        /// <remarks>Este método consulta la base de datos para obtener un token de actualización asociado al ID de usuario especificado que aún no haya expirado, solo si el usuario está habilitado.</remarks>
        /// <param name="userId">El identificador único del usuario cuyo token de actualización se está recuperando.</param>
        /// <returns>El token de actualización como una cadena si existe para el usuario; de lo contrario, <see langword="null"/>.</returns>
        public async Task<string?> GetRefreshToken(int userId)
        {
            var tokenEntry = await _context.UsuariosJwtRefresh.Include(j => j.Usuario)
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync(t => t.UsrId == userId && t.ExpiryDate > DateTime.UtcNow && t.Usuario.UsrHabilitado);
            if (tokenEntry != null)
            {
                _logger.LogInformation("Refresh token válido encontrado para el usuario ID: {UserId}.", userId);
            }
            else
            {
                _logger.LogWarning("No se encontró un refresh token válido para el usuario ID: {UserId}.", userId);
            }

            return tokenEntry?.RefreshToken;
        }

        /// <summary>
        /// Elimina cualquier refresh token almacenado para el usuario indicado.
        /// </summary>
        /// <param name="userId">Identificador único del usuario.</param>
        public async Task DeleteRefreshToken(int userId)
        {
            var tokens = await _context.UsuariosJwtRefresh
                                       .Where(t => t.UsrId == userId)
                                       .ToListAsync();

            if (tokens.Count == 0)
            {
                _logger.LogInformation("No había refresh tokens para eliminar del usuario ID: {UserId}.", userId);
                return;
            }

            _context.UsuariosJwtRefresh.RemoveRange(tokens);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Refresh tokens eliminados para el usuario ID: {UserId}.", userId);
        }

        /// <summary>
        /// Obtiene los procesos asociados al perfil del usuario indicado.   
        /// </summary>
        /// <param name="userId">ID del usuario</param> 
        /// <param name="perfilId">ID del perfil</param>
        /// <param name="typeClass">Tipo de proceso a recuperar</param>
        /// <param name="VisibleOn">Filtra por visibilidad si se indica</param>
        /// <Param name="idModulo">Código del Modulo para filtrar (Opcional)</Param>
        /// <returns> lista de módulos (AuthProcessDto)</returns>
        /// <remarks>Si el parámetro VisibleOn es nulo, no se aplica ningún filtro de visibilidad.</remarks>
        public async Task<List<AuthProcessDto>?> GetProcessByUserAndProfileAsync(int userId, int perfilId, 
                                                                                ProcessType typeClass, bool? VisibleOn = true,
                                                                                string? idModulo = null)
        {
            var procesos = await _context.Procesos
                            .AsNoTracking()
                            .Where(p =>
                                p.Perfiles.Any(pe => pe.Usuarios.Any(u =>
                                    u.UsrId == userId &&
                                    u.PeaId == perfilId &&
                                    u.UsrHabilitado
                                )) &&
                                (p.ProVisibleWeb == VisibleOn || VisibleOn == null) &&
                                (typeClass == ProcessType.All ||
                                    (typeClass == ProcessType.Modules && p.ProEsModulo) ||
                                    (typeClass == ProcessType.MenuOptions 
                                    && !p.ProEsModulo 
                                    && idModulo != null
                                    && p.ProId.Substring(0, 2) == idModulo.Substring(0, 2)
                                    && p.ProId.Substring(6, 2) == "00"))
                            )
                            .Select(p => new AuthProcessDto
                            {
                                ProId = p.ProId,
                                ProNombre = p.ProNombre,
                                ProEsModulo = p.ProEsModulo,
                                ProDescripcion = p.ProDescripcion,
                                ProFarmacia = p.ProFarmacia,
                                ProDialog = p.ProDialog,
                                ProNivel = p.ProNivel,
                                ProArea = p.ProArea,
                                ProAccion = p.ProAccion,
                                ProController = p.ProController,
                                ProImagen = p.ProImagen,
                                ProVisibleWeb = p.ProVisibleWeb,
                                ProIconClass = p.ProIconClass
                            })
                            .ToListAsync();

             
            _logger.LogInformation("Módulos obtenidos para el usuario ID: {UserId} y perfil ID: {PerfilId}", userId, perfilId);

            return procesos;
        }

        public async Task<List<string>?> GetCodeProcessByUserAndProfileAsync(int userId, int perfilId)
        {
            // Incluir codigos de procesos para el Usuario con acceso 
            var procesos = await _context.Procesos
                            .AsNoTracking()
                            .Where(p => p.Perfiles.Any(pe => pe.Usuarios.Any(u =>
                                    u.UsrId == userId &&
                                    u.PeaId == perfilId &&
                                    u.UsrHabilitado
                                )))
                            .Select(p => p.ProId)
                            .ToListAsync();
                            
            _logger.LogInformation("Codigos de proceso obtenidos para el usuario ID: {UserId} y perfil ID: {PerfilId}", userId, perfilId);

            return procesos;
        } 
    }   

    public interface ISecurityRepo
    {
        Task<Usuario?> GetByCredentialsAsync(LoginApiRequest login);
        Task<Usuario?> GetByIdAsync(int id);
        Task SaveRefreshToken(int userId, string userName, string refreshToken, DateTime expiry);
        Task<string?> GetRefreshToken(int userId);
        Task DeleteRefreshToken(int userId);
        Task<List<string>?> GetCodeProcessByUserAndProfileAsync(int userId, int perfilId); 
        Task<List<AuthProcessDto>?> GetProcessByUserAndProfileAsync(int userId, int perfilId, 
                                                                    ProcessType typeClass, bool? VisibleOn = true,
                                                                    string? idModulo = null);
    }
}
