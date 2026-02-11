using Projeto_Credito_Cliente.Models;

namespace Projeto_Credito_Cliente.Repositories.Infaces;

public interface IRepositoryBase<TEntity> where TEntity : Entity
{
    Task<TEntity> AddAsync(TEntity Entity);
    Task<TEntity> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(int id);

}