using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Projeto_Credito_Cliente.Models;

namespace Projeto_Credito_Cliente.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Contato> Contatos { get; set; }

}