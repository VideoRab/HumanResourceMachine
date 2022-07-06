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
        public async Task<ActionResult<IEnumerable<Human>>> GetAll()
        {
            return Ok(await _context.People.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Human>> Get([FromRoute] int id)
        {
            var result = await _context.People.FindAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Human human)
        {
            _context.People.Add(human);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Human request)    
        {
            _context.Update(request);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var target = await _context.People.FindAsync(id);
            _context.People.Remove(target);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
