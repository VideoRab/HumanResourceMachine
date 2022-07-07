using HumanResourceMachine.Context;
using HumanResourceMachine.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HumanResourceMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly HRMContext _context;

        public HumanController(HRMContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Human> GetAllHumans()
        {
            return _context.People.ToList();
        }

        [HttpGet("{id}")]
        public Human GetHumanById([FromRoute] int id)
        {
            var result = _context.People.Find(id);
            if (result is null)
            {
                throw new ArgumentNullException("Object doesn't exist.", nameof(result));
            }

            return result;
        }

        [HttpPost]
        public void AddHuman(Human human)
        {
            _context.People.Add(human);
            _context.SaveChanges();
        }

        [HttpPut]
        public void UpdateHuman(Human human)    
        {
            _context.Update(human); 
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteHumanById([FromRoute] int id)
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
