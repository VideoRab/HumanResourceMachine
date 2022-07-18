using HRM.DAL.Context;
using HRM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRM.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly HRMContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(HRMContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll(CancellationToken token)
        {
            return await _dbSet.ToListAsync(token);
        }

        public async Task<TEntity> GetById(int id, CancellationToken token)
        {
            return (await _dbSet.FindAsync(new object[] { id }, token))!;
        }

        public async Task Add(TEntity tEntity, CancellationToken token)
        {
            await _dbSet.AddAsync(tEntity, token);
            await _context.SaveChangesAsync(token);
        }

        public async Task Update(TEntity tEntity, CancellationToken token)
        {
            _context.Entry(tEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync(token);
        }

        public async Task DeleteById(int id, CancellationToken token)
        {
            var target = await _context.People.FindAsync(new object[] { id }, token);
            _context.People.Remove(target!);
            await _context.SaveChangesAsync(token);
        }
    }
}