using SecureAPIRestWithJwtTokens.DataContexts;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Tools;
using Microsoft.EntityFrameworkCore;

namespace SecureAPIRestWithJwtTokens.Repository
{
    /// <summary>
    /// Proporciona métodos para acceder a la información de los usuarios en la base de datos.
    /// </summary>
    /// <remarks>Este repositorio es responsable de recuperar información de usuarios, incluidas entidades relacionadas
    /// como empleados y unidades de negocio, de la base de datos. Está diseñado para trabajar con el <see
    /// cref="TrebolDbContext"/> y implementa la interfaz <see cref="IUserRepo"/>.</remarks>
    /// <param name="context">Contexto de la base de datos.</param>
    /// <param name="logger">Instancia de logger para registrar información y errores.</param>
    public class UserRepository(TrebolDbContext context, ILogger<UserRepository> logger) : IUserRepo
    {
        private readonly TrebolDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<UserRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        /// <summary>
        /// Asynchronously retrieves a user by their unique identifier, including related employee and business unit
        /// data.   
        /// </summary>
        /// <remarks>If the user has multiple associated employees, only the first employee is included in
        /// the returned data.</remarks>
        /// <param name="id">The unique identifier of the user to retrieve.</param>
        /// <returns>A <see cref="Usuario"/> object representing the user with the specified identifier, including their
        /// associated  employee and business unit data, or <see langword="null"/> if no user with the specified
        /// identifier exists.</returns>
        public async Task<Usuario?> GetAccessByIdAsync(int id)
        {
            // Incluir empleado (primero) y unidades de negocio para el Usuario con acceso 
            var usuario = await _context.Usuarios.AsNoTracking()
                                         .Include(u => u.Empleados).ThenInclude(e => e.EmpleadosUnidadesNegs)
                                                                   .ThenInclude(ue => ue.UnidadNegocio)
                                                                   .ThenInclude(un => un.UnidadNegocioDb)
                                         .FirstOrDefaultAsync(u => u.UsrId == id);
            if (usuario != null && usuario.Empleados != null && usuario.Empleados.Count > 1)
            {
                _logger.LogInformation("Usuario con múltiples empleados encontrado. Limitando a uno solo.");
                usuario.Empleados = [usuario.Empleados.First()];
            }

            return usuario;
        }
    }

    public interface IUserRepo
    {
        Task<Usuario?> GetAccessByIdAsync(int id);
    }
}

