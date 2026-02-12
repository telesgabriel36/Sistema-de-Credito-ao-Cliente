using Projeto_Credito_Cliente.Models;

namespace Projeto_Credito_Cliente.Services.Interfaces;

public interface IServiceCrud<TEntity> where TEntity : Entity
{
    Task<TEntity> RegisterEntity(Entity entity);

    Task<IEnumerable<TEntity>> GetAllEntityes();

    Task<TEntity> GetEntityById(int id);

    Task<bool> UpdateEntity(int id);

    Task<bool> RemoveEntity(int id);
}