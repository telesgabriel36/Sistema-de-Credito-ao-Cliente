using Projeto_Credito_Cliente.Models;
using Projeto_Credito_Cliente.Utils;
using Projeto_Credito_Cliente.ViewModels;

namespace Projeto_Credito_Cliente.Services.Interfaces;

public interface IServiceCliente
{
    Task<ServiceResult<ClienteViewModel>> RegisterEntity(Cliente cliente);
    Task<IEnumerable<Cliente>> GetAllEntityes();
    Task<Cliente> GetEntityById(int id);
    Task<bool> UpdateEntity(Cliente cliente);
    Task<bool> RemoveEntity(int id);
    Task<Cliente> GetClienteByEmail(string email);
    Task<Cliente> GetClienteByCpf(string cpf);
    Task<Cliente> GetClienteByName(string nome);

}