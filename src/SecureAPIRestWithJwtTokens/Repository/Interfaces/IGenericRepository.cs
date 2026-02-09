namespace SecureAPIRestWithJwtTokens.Repository.Interfaces;

public interface IGenericRepository<T>
{
    Task<IEnumerable<T>?> GetAllAsync(IDictionary<string, object>? filtros = null);
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T entidad);
    Task UpdateAsync(T entidad);
    Task DeleteAsync(int id);
}

