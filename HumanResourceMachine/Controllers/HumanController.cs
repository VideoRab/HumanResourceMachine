using HumanResourceMachine.Entities;
using HumanResourceMachine.Interfaces.Service;
using HumanResourceMachine.ViewModels;
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
        public IEnumerable<HumanViewModel> GetAllHumans()
        {
            var humans = _service.GetAllHumans();
            var result = MappingToHumanVM(humans);

            return result;
        }

        [HttpGet("{id}")]
        public HumanViewModel GetHumanById([FromRoute] int id)
        {
            var human = _service.GetHumanById(id);
            var result = MappingToHumanVM(human);

            return result;
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

        private List<HumanViewModel> MappingToHumanVM(IEnumerable<Human> humans)
        {
            var result = new List<HumanViewModel>();
            foreach (var human in humans)
            {
                result.Add(new HumanViewModel()
                {
                    Name = human.Name,
                    Surname = human.Surname,
                    Patronymic = human.Patronymic
                });
            }

            return result;
        }

        private HumanViewModel MappingToHumanVM(Human human)
        {
            var result = new HumanViewModel()
            {
                Name = human.Name,
                Surname = human.Surname,
                Patronymic = human.Patronymic
            };

            return result;
        }
    }
}
