using HumanResourceMachine.Context;
using HumanResourceMachine.Entities;
using HumanResourceMachine.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceMachine.Services
{
    public class HumanService : IHumanService
    {
        private readonly HRMContext _context;

        public HumanService(HRMContext context)
        {
            _context = context;
        }

        public IEnumerable<Human> GetAllHumans()
        {
            return _context.People.ToList();
        }

        public Human GetHumanById(int id)
        {
            var result = _context.People.Find(id);
            if (result is null)
            {
                throw new ArgumentNullException("Object doesn't exist.", nameof(result));
            }

            return result;
        }

        public void AddHuman(Human human)
        {
            _context.People.Add(human);
            _context.SaveChanges();
        }

        public void UpdateHuman(Human human)
        {
            _context.Entry(human).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteHumanById(int id)
        {
            var target = _context.People.Find(id);
            if (target is null)
            {
                throw new ArgumentNullException("Object doesn't exist.", nameof(target));
            }

            _context.People.Remove(target);
            _context.SaveChanges();
        }
    }
}
