using HumanResourceMachine.Context;
using HumanResourceMachine.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IEnumerable<Human> GetAll()
        {
            return _context.People.ToList();
        }

        [HttpGet("{id}")]
        public Human Get([FromRoute] int id)
        {
            var result = _context.People.Find(id);

            return result;
        }

        [HttpPost]
        public void Post(Human human)
        {
            _context.People.Add(human);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put(Human request)    
        {
            _context.Update(request); 
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            var target = _context.People.Find(id);
            _context.People.Remove(target); 
            _context.SaveChanges();
        }
    }
}
