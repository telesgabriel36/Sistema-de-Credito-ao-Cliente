
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualBasic;
using Projeto_Credito_Cliente.Data;
using Projeto_Credito_Cliente.Models;
using Projeto_Credito_Cliente.Repositories.Infaces;

namespace Projeto_Credito_Cliente.Repositories.Implementations;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
{
    private readonly DbSet<TEntity> _dbset;
    private readonly AppDbContext _context;

    public RepositoryBase(AppDbContext context)
    {
        _dbset = context.Set<TEntity>();
        _context = context;

    }

    //Método de montar a querry
    public IQueryable<TEntity> Query()
    {
        return _dbset;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbset.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _dbset.FirstOrDefaultAsync(e => e.Id == id);
        _dbset.Remove(entity);

        return await _context.SaveChangesAsync() >= 1 ? true : false;

    }

    //Tentar ver uma forma de melhorar o tipo de retorno da Expression
    public async Task<IEnumerable<TEntity>> GetAllAsync(IQueryable<TEntity> query)
    {

        return await query.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbset.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        var entityDb = await _dbset.FirstOrDefaultAsync(e => e.Id == entity.Id);

        _dbset.Entry(entityDb).CurrentValues.SetValues(entity);

        return await _context.SaveChangesAsync() >= 1 ? true : false;

    }
}