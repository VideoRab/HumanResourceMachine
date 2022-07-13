using HRM.DAL.Context;
using HRM.DAL.Entities;
using HRM.DAL.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRM.DAL.Repositories
{
    public class HumanRepository : IHumanRepository
    {
        private readonly HRMContext _context;

        public HumanRepository(HRMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HumanEntity>> GetAllHumans(CancellationToken token)
        {
            return await _context.People.ToListAsync(token);
        }

        public async Task<HumanEntity> GetHumanById(int id, CancellationToken token)
        {
            return (await _context.People.FindAsync(new object[] { id }, token))!;
        }

        public async Task AddHuman(HumanEntity human, CancellationToken token)
        {
            await _context.People.AddAsync(human, token);
            await _context.SaveChangesAsync(token);
        }

        public async Task UpdateHuman(HumanEntity human, CancellationToken token)
        {
            _context.Entry(human).State = EntityState.Modified;
            await _context.SaveChangesAsync(token);
        }

        public async Task DeleteHumanById(int id, CancellationToken token)
        {
            var target = await _context.People.FindAsync(new object[] { id }, token);
            _context.People.Remove(target!);
            await _context.SaveChangesAsync(token);
        }
    }
}