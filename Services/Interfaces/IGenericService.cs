namespace SecureAPIRestWithJwtTokens.Services.Interfaces;

/// <summary>
/// Interfaz para servicios genéricos que manejan operaciones CRUD básicas.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IGenericService<T>
{
    Task<List<T>?> GetAllAsync(Dictionary<string, object>? filtros = null);
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T entidad);
    Task UpdateAsync(T entidad);
    Task DeleteAsync(int id);
}

