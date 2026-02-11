
using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbset.ToListAsync();
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