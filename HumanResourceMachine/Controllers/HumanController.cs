using HumanResourceMachine.Context;
using HumanResourceMachine.Entities;
using HumanResourceMachine.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HumanResourceMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly IHumanService _service;

        public HumanController(IHumanService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Human> GetAllHumans()
        {
            return _service.GetAllHumans();
        }

        [HttpGet("{id}")]
        public Human GetHumanById([FromRoute] int id)
        {
            return _service.GetHumanById(id);
        }

        [HttpPost]
        public void AddHuman(Human human)
        {
            _service.AddHuman(human);
        }

        [HttpPut]
        public void UpdateHuman(Human human)    
        {
            _service.UpdateHuman(human);
        }

        [HttpDelete("{id}")]
        public void DeleteHumanById([FromRoute] int id)
        {
            _service.DeleteHumanById(id);
        }
    }
}
