using Projeto_Credito_Cliente.Models;

namespace Projeto_Credito_Cliente.Repositories.Infaces;

public interface IRepositoryCliente : IRepositoryBase<Cliente>
{
    Task<Cliente> GetByNameAsync(string nome);
    Task<Cliente> GetByCpfAsync(string cpf);
    Task<Cliente> GetByEmail(string email);
}