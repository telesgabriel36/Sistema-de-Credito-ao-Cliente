using Microsoft.EntityFrameworkCore;
using Projeto_Credito_Cliente.Data;
using Projeto_Credito_Cliente.Models;
using Projeto_Credito_Cliente.Repositories.Infaces;

namespace Projeto_Credito_Cliente.Repositories.Implementations;

public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
{

    private readonly AppDbContext _context;
    public RepositoryCliente(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Cliente> GetByNameAsync(string nome)
    {
        return await _context.Clientes.FirstOrDefaultAsync(c => c.Nome == nome);
    }

    public async Task<Cliente> GetByCpfAsync(string cpf)
    {
        return await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);
    }

    public async Task<Cliente> GetByEmail(string email)
    {
        return await _context.Clientes.FirstOrDefaultAsync(c => c.Contato.Email == email);
    }

}