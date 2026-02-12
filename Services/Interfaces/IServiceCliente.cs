using Projeto_Credito_Cliente.Models;

namespace Projeto_Credito_Cliente.Services.Interfaces;

public interface IServiceCliente : IServiceCrud<Cliente>
{

    Task<Cliente> GetClienteByEmail(string email);
    Task<Cliente> GetClienteByCpf(string cpf);
    Task<Cliente> GetClienteByName(string nome);

}