using EntregaJaAPI.Domain.Entities;
using EntregaJaAPI.Domain.Repositories;
using EntregaJaAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EntregaJaAPI.Infra.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> ListAsync()
            => await _context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(int id)
            => await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task RemoveAsync(TEntity entity)
        {
            _context.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression)
            => await _context.Set<TEntity>().Where(expression).ToListAsync();

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
