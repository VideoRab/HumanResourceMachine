using HRM.BLL.Context;
using HRM.BLL.Entities;
using HRM.BLL.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRM.BLL.Repositories
{
    public class HumanRepository : IHumanRepository
    {
        private readonly HRMContext _context;

        public HumanRepository(HRMContext context)
        {
            _context = context;
        }

        public IEnumerable<HumanEntity> GetAllHumans()
        {
            return _context.People.ToList();
        }

        public HumanEntity GetHumanById(int id)
        {
            return _context.People.Find(id);
        }

        public void AddHuman(HumanEntity human)
        {
            _context.People.Add(human);
            _context.SaveChanges();
        }

        public void UpdateHuman(HumanEntity human)
        {
            _context.Entry(human).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteHumanById(int id)
        {
            var target = _context.People.Find(id);
            _context.People.Remove(target!);
            _context.SaveChanges();
        }
    }
}