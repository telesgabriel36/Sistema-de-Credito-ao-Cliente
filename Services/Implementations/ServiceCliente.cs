using Projeto_Credito_Cliente.Models;
using Projeto_Credito_Cliente.Repositories.Implementations;
using Projeto_Credito_Cliente.Repositories.Infaces;
using Projeto_Credito_Cliente.Services.Interfaces;
using Projeto_Credito_Cliente.Utils;
using Projeto_Credito_Cliente.ViewModels;

namespace Projeto_Credito_Cliente.Services.Implementations;

public class ServiceCliente : IServiceCliente
{
    private readonly IRepositoryCliente _CliRepo;

    public ServiceCliente(IRepositoryCliente _cliRepo)
    {
        _CliRepo = _cliRepo;
    }

    public async Task<IEnumerable<Cliente>> GetAllEntityes()
    {
        return await _CliRepo.GetAllAsync();
    }

    public async Task<Cliente> GetClienteByCpf(string cpf)
    {
        return await _CliRepo.GetByCpfAsync(cpf);
    }

    public async Task<Cliente> GetClienteByEmail(string email)
    {
        return await _CliRepo.GetByEmail(email);
    }

    public async Task<Cliente> GetClienteByName(string nome)
    {
        return await _CliRepo.GetByNameAsync(nome);
    }

    public async Task<Cliente> GetEntityById(int id)
    {
        return await _CliRepo.GetByIdAsync(id);
    }

    public async Task<ServiceResult<ClienteViewModel>> RegisterEntity(Cliente cliente)
    {
        cliente.Data_Cadastro = DateTime.Now;

        cliente.Data_Atualizacao = DateTime.Now;

        if (await _CliRepo.GetByCpfAsync(cliente.Cpf) != null)
        {
            return ServiceResult<ClienteViewModel>.Fail("O Cpf informado já está cadastrado no sistema.");
        }

        if (await _CliRepo.GetByEmail(cliente.Contato.Email) != null)
        {
            return ServiceResult<ClienteViewModel>.Fail("O Email informado já está casdatrado no sistema.");
        }

        var clienteCadastrado = await _CliRepo.AddAsync(cliente);

        if (clienteCadastrado == null)
        {
            return ServiceResult<ClienteViewModel>.Fail();
        }

        var clienteDto = new ClienteViewModel(clienteCadastrado.Nome);

        return ServiceResult<ClienteViewModel>.Ok(clienteDto);
    }

    public async Task<bool> RemoveEntity(int id)
    {
        return await _CliRepo.DeleteAsync(id);
    }

    public async Task<bool> UpdateEntity(Cliente cliente)
    {
        return await _CliRepo.UpdateAsync(cliente);
    }
}